using System;
using Server.ContextMenus;
using Server.Items;
using Server.Multis;
using Server.Misc;
using Server.Gumps;

namespace Server.Items
{
    public class LawnStair : LawnItem
    {
        #region Properties
        private int m_DefaultID;
        public int DefaultID
        {
            get { return m_DefaultID; }
            set { m_DefaultID = value; }
        }
        #endregion

        #region Constructors
        [Constructable]
        public LawnStair(Mobile placer, int defaultID, Point3D loc, int price, string title, BaseHouse house) : base(defaultID, placer, "Stairs", loc, price, "stairs", house)
        {
            DefaultID = defaultID;
			Name = title;
			if ( defaultID > 40000 ){ ItemID = defaultID = defaultID - Remodeling.GroundID( title ); }
        }

        public LawnStair(Serial serial): base(serial)
        {
        }
        #endregion

        #region Overrides
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //version

            writer.Write((int)DefaultID);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            DefaultID = reader.ReadInt();
        }

        public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            if ( House.IsCoOwner( from ) || House.IsOwner( from ) || from.AccessLevel >= AccessLevel.GameMaster )
            {
                list.Add(new StairRefundEntry(from, this, Price));
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 10))
            {
                if ( House.IsCoOwner( from ) || House.IsOwner( from ) || from.AccessLevel >= AccessLevel.GameMaster )
                {
                    if (LawnRegistry.LawnStairIDGroups.ContainsKey(DefaultID) && LawnRegistry.LawnStairIDGroups[DefaultID] != null && LawnRegistry.LawnStairIDGroups[DefaultID].Length > 0)
                    {
                        int index;
                        for (index = 0; index < LawnRegistry.LawnStairIDGroups[DefaultID].Length; index++)
                        {
                            if (LawnRegistry.LawnStairIDGroups[DefaultID][index] == ItemID)
                            {
                                break;
                            }
                        }
                        ItemID = (index == LawnRegistry.LawnStairIDGroups[DefaultID].Length - 1 ? LawnRegistry.LawnStairIDGroups[DefaultID][0] : LawnRegistry.LawnStairIDGroups[DefaultID][index+1]);
                    }
                }
            }
            else
            {
                from.SendMessage("The item is too far away");
            }
        }
        #endregion
    }
}