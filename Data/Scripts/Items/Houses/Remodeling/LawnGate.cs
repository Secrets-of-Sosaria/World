using System;
using System.Collections.Generic;
using Server.Commands;
using Server.ContextMenus;
using Server.Items;
using Server.Multis;
using Server.Misc;
using Server.Gumps;

namespace Server.Items
{
    public class LawnGate : BaseDoor
    {
        #region Properties
        private Mobile m_Placer;
        [CommandProperty(AccessLevel.GameMaster)]
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
        #endregion

        #region Constructors
        public LawnGate(int itemID, Mobile placer, int price, string title, BaseHouse house, Point3D location, DoorFacing facing): base(itemID, itemID + 1, GetOpenedSound(itemID), GetClosedSound(itemID), BaseDoor.GetOffset(facing))
        {
            Placer = placer;
            Price = price;
			Title = title;

            Movable = false;
            MoveToWorld(location, placer.Map);

            if (house == null)
            {
                FindHouseOfPlacer();
            }
            else
            {
                House = house;
            }
			Name = title;
			if ( itemID > 40000 ){ ItemID = itemID = itemID - Remodeling.GroundID( title ); }
        }

        public LawnGate(Serial serial): base(serial)
        {
        }
        #endregion

        #region Overrides
        public override void Use(Mobile from)
        {
			if ( Locked && ( House.IsFriend( from ) || House.IsCoOwner( from ) || House.IsOwner( from ) || House.IsGuildMember( from ) || from.AccessLevel >= AccessLevel.GameMaster ) )
            {
                Locked = false;
                from.SendMessage("You unlock the gate and lock again.");
                base.Use(from);
                Locked = true;
            }
            else if ( Locked )
            {
                from.SendMessage("That gate is locked!");
            }
            else
            {
                base.Use(from);
            }
        }

        public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            if ( House.IsCoOwner( from ) || House.IsOwner( from ) || from.AccessLevel >= AccessLevel.GameMaster )
            {
                list.Add(new LawnSecurityEntry(from, this));
                list.Add(new RefundEntry(from, this, m_Price));
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

            if ( House == null || House.Deleted || !MySettings.S_LawnsAllowed )
            {
                writer.Write(false);
                LawnSystem.AddOrphanedItem(this);
            }
            else
            {
                writer.Write(true);
                writer.Write(House);
            }

            writer.WriteMobile(Placer);
            writer.Write(Price);
            writer.Write(Title);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (reader.ReadBool())
            {
                House = reader.ReadItem() as BaseHouse;
            }

            Placer = reader.ReadMobile();
            Price = reader.ReadInt();
            Title = reader.ReadString();

            if (House == null)
            {
                FindHouseOfPlacer();
                if ( House == null || !MySettings.S_LawnsAllowed )
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
					LawnSystem.RemoveVisitors( this );
					Delete();
					from.SendLocalizedMessage(1060397, toGive.Amount.ToString()); // ~1_AMOUNT~ gold has been deposited into your bank box.
				}
				else
				{
					toGive.Delete();
					from.SendMessage("Your bank box is full!");
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

        #region Static
        public static int GetClosedSound(int itemID)
        {
            if ((itemID >= 2084 && itemID <= 2098) ||
                (itemID >= 2124 && itemID <= 2138))
            {
                return 243;
            }
            else if ((itemID >= 2105 && itemID <= 2119) ||
                     (itemID >= 2150 && itemID <= 2162))
            {
                return 242;
            }
            else
            {
                return 243;
            }
        }

        public static int GetOpenedSound(int itemID)
        {
            if ((itemID >= 2084 && itemID <= 2098) ||
                (itemID >= 2124 && itemID <= 2138))
            {
                return 236;
            }
            else if ((itemID >= 2105 && itemID <= 2119) ||
                     (itemID >= 2150 && itemID <= 2162))
            {
                return 235;
            }
            else
            {
                return 236;
            }
        }
        #endregion
    }
}