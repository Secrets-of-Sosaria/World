using System;
using System.Collections.Generic;
using Server.Items;
using Server.Multis;
using Server.Misc;
using Server.Mobiles;
using Server.Regions;
using Server.Gumps;

namespace Server.Items
{
    public class ShantyMultiInfo
    {
        public int ItemID;
        public Point3D Offset;

        public ShantyMultiInfo(int itemID, Point3D offset)
        {
            ItemID = itemID;
            Offset = offset;
        }
    }

    public class ShantyItem : ShantyPiece
    {
        #region Properties
        private Mobile m_Placer;
        public Mobile Placer
        {
            get { return m_Placer; }
            set { m_Placer = value; }
        }

        private int m_Price;
        [CommandProperty(AccessLevel.GameMaster)]
        public int Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }

        private string m_Title;
        [CommandProperty(AccessLevel.GameMaster)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private BaseHouse m_House;
        [CommandProperty(AccessLevel.GameMaster)]
        public BaseHouse House
        {
            get { return m_House; }
            set { m_House = value; }
        }

        private List<ShantyPiece> m_Pieces;
        public List<ShantyPiece> Pieces
        {
            get
            {
                if (m_Pieces == null)
                {
                    m_Pieces = new List<ShantyPiece>();
                }
                return m_Pieces;
            }
            set { m_Pieces = value; }
        }
        #endregion

        #region Constructors
        public ShantyItem(int itemID, Mobile from, string itemName, Point3D location, int price, string title, BaseHouse house): base(itemID, itemName)
        {
            Price = price;
			Title = title;
            Placer = from;

            Movable = false;
            HasMoved = true;
            MoveToWorld(location, from.Map);

            if (house == null)
            {
                FindHouseOfPlacer();
            }
            else
            {
                House = house;
            }

            Pieces = new List<ShantyPiece>();
            ParentShantyItem = this;
            Pieces.Add(this);
			Remodeling.SetID( itemID, this, title );

            if (ShantyRegistry.ShantyMultiIDs.ContainsKey(ItemID) && ShantyRegistry.ShantyMultiIDs[ItemID] != null)
            {
                ShantyPiece piece;
                foreach (ShantyMultiInfo info in ShantyRegistry.ShantyMultiIDs[ItemID])
                {
                    piece = new ShantyPiece(info.ItemID, title, this);
                    piece.HasMoved = true;
                    piece.MoveToWorld(new Point3D(Location.X + info.Offset.X,
                                                  Location.Y + info.Offset.Y,
                                                  Location.Z + info.Offset.Z),
                                                  from.Map);
                    Pieces.Add(piece);
                }
            }

            for (int i = 0; i < Pieces.Count; i++)
            {
                Pieces[i].HasMoved = false;
            }
			Name = title;
			Hue = Remodeling.ItemColor( Name, ItemID );
        }

        public ShantyItem(Serial serial): base(serial)
        {
        }
        #endregion

        #region Overrides
        public override void OnAfterDelete()
        {
            for (int i = 0; i < Pieces.Count; ++i)
            {
				ShantySystem.RemoveVisitors( Pieces[i] );
                Pieces[i].Delete();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 10))
            {
                if ( House.IsCoOwner( from ) || House.IsOwner( from ) || from.AccessLevel >= AccessLevel.GameMaster )
                {
                    Refund( from );
                }
            }
            else
            {
                from.SendMessage("The item is too far away");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

            //Version 1
            if ( House == null || House.Deleted || !MySettings.S_ShantysAllowed )
            {
                writer.Write(false);
                ShantySystem.AddOrphanedItem(this);
            }
            else
            {
                writer.Write(true);
                writer.Write(House);
            }

            //Version 0
            writer.WriteMobile(Placer);
            writer.Write(Price);
            writer.Write(Title);
            writer.WriteItemList(Pieces);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        if (reader.ReadBool())
                        {
                            House = reader.ReadItem() as BaseHouse;
                        }
                        goto case 0;
                    }
                case 0:
                    {
                        Placer = reader.ReadMobile();
                        Price = reader.ReadInt();
                        Title = reader.ReadString();

                        Pieces = new List<ShantyPiece>();
                        foreach (ShantyPiece item in reader.ReadItemList())
                        {
                            Pieces.Add(item);
                        }
                        break;
                    }
            }

            if (House == null)
            {
                FindHouseOfPlacer();
                if ( House == null || !MySettings.S_ShantysAllowed )
                {
                    Refund( Placer );                    
                }
            }
        }
        #endregion

        #region Methods
        public void Refund( Mobile from )
        {
			if ( from != null )
			{
				Gold toGive = new Gold(Price);
				if (from.BankBox.TryDropItem(from, toGive, false))
				{
					ShantySystem.RemoveVisitors( this );
					Delete();
					from.SendLocalizedMessage(1060397, toGive.Amount.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
				}
				else
				{
					toGive.Delete();
					from.SendMessage("Your bankbox is full!");
				}
			}
			else { Delete(); }
        }

        public void FindHouseOfPlacer()
        {
            if (Placer == null || House != null)
            {
                return;
            }

            IPooledEnumerable eable = Map.GetItemsInRange(Location, 20);
            foreach (Item item in eable)
            {
                if (item is BaseHouse)
                {
                    BaseHouse house = (BaseHouse)item;
                    if (house.Owner == Placer)
                    {
                        House = house;
                        return;
                    }
                }
            }
        }
        #endregion
    }

    public class ShantyPiece : Item
    {
        private ShantyItem m_ParentShantyItem;
        public ShantyItem ParentShantyItem
        {
            get { return m_ParentShantyItem; }
            set { m_ParentShantyItem = value; }
        }

        private bool m_HasMoved;
        public bool HasMoved
        {
            get { return m_HasMoved; }
            set { m_HasMoved = value; }
        }

        public ShantyPiece(int itemID, string name): this(itemID, name, null)
        {
        }

        public ShantyPiece(int itemID, string name, ShantyItem multiParent): base(itemID)
        {
            Movable = false;
            Name = name;
			if ( itemID > 40000 ){ ItemID = itemID = itemID - Remodeling.GroundID( name ); }
            ItemID = itemID;

            if (multiParent != null)
            {
                ParentShantyItem = multiParent;
            }
			if ( ItemID == 0x373A || ItemID == 0x3039 || ItemID == 0x374A || ItemID == 0x375A || ItemID == 0x376A || ItemID == 0x5469 || ItemID == 0x54E1 || ItemID == 0x17F3 ){ Light = LightType.Circle225; }
			else if ( ItemID == 6864 ){ Light = LightType.Circle300; }
        }

        public ShantyPiece(Serial serial): base(serial)
        {
        }

        public override void OnAfterDelete()
        {
            if (ParentShantyItem != null)
            {
                ParentShantyItem.OnAfterDelete();
            }
            else
            {
                base.OnAfterDelete();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (ParentShantyItem != null)
            {
                ParentShantyItem.OnDoubleClick(from);
            }
            else
            {
                base.OnDoubleClick(from);
            }
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            if (HasMoved)
            {
                base.OnLocationChange(oldLocation);
                return;
            }

            int xOff = 0, yOff = 0, zOff = 0;

            xOff = Location.X - oldLocation.X;
            yOff = Location.Y - oldLocation.Y;
            zOff = Location.Z - oldLocation.Z;

            if (ParentShantyItem != null && ParentShantyItem.Pieces != null)
            {
                HasMoved = true;

                for (int i = 0; i < ParentShantyItem.Pieces.Count; i++)
                {
                    if (!ParentShantyItem.Pieces[i].HasMoved)
                    {
                        ParentShantyItem.Pieces[i].HasMoved = true;
                        ParentShantyItem.Pieces[i].MoveToWorld(new Point3D(ParentShantyItem.Pieces[i].Location.X + xOff,
                                                                      ParentShantyItem.Pieces[i].Location.Y + yOff,
                                                                      ParentShantyItem.Pieces[i].Location.Z + zOff),
                                                                      Map);
                    }
                }

                for (int i = 0; i < ParentShantyItem.Pieces.Count; i++)
                {
                    ParentShantyItem.Pieces[i].HasMoved = false;
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write(ParentShantyItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            switch (version)
            {
                case 0:
                    {
                        ParentShantyItem = reader.ReadItem() as ShantyItem;
                        break;
                    }
            }
        }
    }
}