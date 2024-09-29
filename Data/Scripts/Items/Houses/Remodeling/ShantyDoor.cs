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
    public class ShantyDoor : BaseDoor
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
        public ShantyDoor(int itemID, Mobile placer, int price, string title, BaseHouse house, Point3D location, DoorFacing facing): base(itemID, itemID + 1, GetOpenedSound(itemID), GetClosedSound(itemID), BaseDoor.GetOffset(facing))
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

        public ShantyDoor(Serial serial): base(serial)
        {
        }
        #endregion

        #region Overrides
        public override void Use(Mobile from)
        {
			if ( Locked && ( House.IsFriend( from ) || House.IsCoOwner( from ) || House.IsOwner( from ) || House.IsGuildMember( from ) || from.AccessLevel >= AccessLevel.GameMaster ) )
            {
				if ( this.Name == "ladder" )
				{
					from.X = this.X;
					from.Y = this.Y;
					from.Z = this.Z + 20;
					from.SendSound( 0x24C );
				}
				else if ( this.Name == "trapdoor" )
				{
					Map map = this.Map;
					Point3D loc = new Point3D( this.X, this.Y, (this.Z-20) );

					if ( map.CanSpawnMobile( this.X, this.Y, (this.Z-20) ) )
					{
						from.Location = loc;
						from.SendSound( 234 );
					}
				}
				else
				{
					Locked = false;
					from.SendMessage("You unlock it and lock again.");
					base.Use(from);
					Locked = true;
				}
            }
            else if ( Locked )
            {
                from.SendMessage("That is locked!");
            }
            else if ( this.Name != "ladder" && this.Name != "trapdoor" )
            {
                base.Use(from);
            }
			else if ( this.Name == "ladder" || this.Name == "trapdoor" )
			{
				if ( this.Name == "ladder" )
				{
					from.X = this.X;
					from.Y = this.Y;
					from.Z = this.Z + 20;
					from.SendSound( 0x24C );
				}
				else if ( this.Name == "trapdoor" )
				{
					Map map = this.Map;
					Point3D loc = new Point3D( this.X, this.Y, (this.Z-20) );

					if ( map.CanSpawnMobile( this.X, this.Y, (this.Z-20) ) )
					{
						from.Location = loc;
						from.SendSound( 234 );
					}
				}
			}
        }

        public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            if ( House.IsCoOwner( from ) || House.IsOwner( from ) || from.AccessLevel >= AccessLevel.GameMaster )
            {
                list.Add(new ShantySecurityEntry(from, this));
                list.Add(new ShantyRefundEntry(from, this, m_Price));
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

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
            else if ( itemID == 1679 || itemID == 1680 || itemID == 1677 || itemID == 1678 || itemID == 1671 || itemID == 1672 || itemID == 1669 || itemID == 1670 || 
				itemID == 8183 || itemID == 8184 || itemID == 8181 || itemID == 8182 || itemID == 8175 || itemID == 8176 || itemID == 8173 || 
				itemID == 8174 || itemID == 1743 || itemID == 1744 || itemID == 1741 || itemID == 1742 || itemID == 1735 || itemID == 1736 || 
				itemID == 1663 || itemID == 1664 || itemID == 1661 || itemID == 1662 || itemID == 1655 || itemID == 1656 || itemID == 1653 || 
				itemID == 1654 || itemID == 1733 || itemID == 1734 )
            {
                return 243;
            }
            else if ( itemID == 1695 || itemID == 1696 || itemID == 1693 || itemID == 1694 || itemID == 1687 || itemID == 1688 || itemID == 1685 || itemID == 1686 )
            {
                return 242;
            }
            else if ( itemID == 25667 || itemID == 25668 || itemID == 705 || itemID == 708 || itemID == 1701 || itemID == 1702 || itemID == 1703 || itemID == 1704 || itemID == 1711 || itemID == 1712 || itemID == 1709 || itemID == 1710 || 
				itemID == 1765 || itemID == 1766 || itemID == 1767 || itemID == 1768 || itemID == 1775 || itemID == 1776 || itemID == 1773 || itemID == 1774 || 
				itemID == 1717 || itemID == 1718 || itemID == 1719 || itemID == 1720 || itemID == 1727 || itemID == 1728 || itemID == 1725 || itemID == 1726 || 
				itemID == 0x6D5 || itemID == 0x6D6 || itemID == 0x6D7 || itemID == 0x6D8 || itemID == 0x6DF || itemID == 0x6E0 || itemID == 0x6DD || itemID == 0x6DE )
            {
                return 241;
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
            else if ( itemID == 1679 || itemID == 1680 || itemID == 1677 || itemID == 1678 || itemID == 1671 || itemID == 1672 || itemID == 1669 || itemID == 1670 || 
				itemID == 8183 || itemID == 8184 || itemID == 8181 || itemID == 8182 || itemID == 8175 || itemID == 8176 || itemID == 8173 || 
				itemID == 8174 || itemID == 1743 || itemID == 1744 || itemID == 1741 || itemID == 1742 || itemID == 1735 || itemID == 1736 || 
				itemID == 1663 || itemID == 1664 || itemID == 1661 || itemID == 1662 || itemID == 1655 || itemID == 1656 || itemID == 1653 || 
				itemID == 1654 || itemID == 1733 || itemID == 1734 )
            {
                return 236;
            }
            else if ( itemID == 1695 || itemID == 1696 || itemID == 1693 || itemID == 1694 || itemID == 1687 || itemID == 1688 || itemID == 1685 || itemID == 1686 )
            {
                return 235;
            }
            else if ( itemID == 25667 || itemID == 25668 || itemID == 705 || itemID == 708 || itemID == 1701 || itemID == 1702 || itemID == 1703 || itemID == 1704 || itemID == 1711 || itemID == 1712 || itemID == 1709 || itemID == 1710 || 
				itemID == 1765 || itemID == 1766 || itemID == 1767 || itemID == 1768 || itemID == 1775 || itemID == 1776 || itemID == 1773 || itemID == 1774 || 
				itemID == 1717 || itemID == 1718 || itemID == 1719 || itemID == 1720 || itemID == 1727 || itemID == 1728 || itemID == 1725 || itemID == 1726 || 
				itemID == 0x6D5 || itemID == 0x6D6 || itemID == 0x6D7 || itemID == 0x6D8 || itemID == 0x6DF || itemID == 0x6E0 || itemID == 0x6DD || itemID == 0x6DE )
            {
                return 234;
            }
            else
            {
                return 236;
            }
        }
        #endregion
    }
}