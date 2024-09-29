using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Regions;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;

namespace Server.Items
{
    public class LawnTools : Item
    {
        private string m_Category;
        public string Category
        {
            get { return m_Category; }
            set { m_Category = value; }
        }

        private string m_Title;
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private int m_Page;
        public int Page
        {
            get { return m_Page; }
            set { m_Page = value; }
        }

        [Constructable]
        public LawnTools(): base(0x63E6)
        {
            Movable = true;
			Weight = 5.0;
            Name = "lawn tools";
            Category = "";
            Page = 0;
			ItemID = Utility.RandomList( 0x63E6, 0x63E7 );
        }

        public LawnTools(Serial serial): base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
			if ( !Server.Items.InteriorDecorator.InHouse( from ) )
			{
				from.SendLocalizedMessage( 502092 ); // You must be in your house to do this.
				return;
			}

            LawnTarget yt;
            
            if (m_Category != null)
            {
                yt = new LawnTarget(this, from, 0, 0, Category, Title, Page);
            }
            else
            {
                yt = new LawnTarget(this, from, 0, 0, "", "", 0);
            }

            yt.GumpUp();
			from.SendSound( 0x4A ); 
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write(Category);
            writer.Write(Page);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            switch (version)
            {
                case 0:
                    {
                        Category = reader.ReadString();
                        Page = reader.ReadInt();
                        break;
                    }
            }
			if ( !MySettings.S_LawnsAllowed ){ this.Delete(); }
        }

		public static bool InHouse( Mobile from )
		{
			BaseHouse house = BaseHouse.FindHouseAt( from );
			return ( house != null && house.IsCoOwner( from ) );
		}

		public static bool CheckUse( Mobile from )
		{
			if ( !InHouse( from ) )
				from.SendLocalizedMessage( 502092 ); // You must be in your house to do this.
			else
				return true;

			return false;
		}
    }
}