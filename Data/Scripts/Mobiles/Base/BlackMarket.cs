using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Regions;
using System.Collections;
using Server.Accounting;

namespace Server
{
    public class BlackMarketGump : Gump
    {
        private Mobile m_Merchant;
        private Mobile m_From;
		private Item m_Item;
		private int m_Page;
		private int m_ID;

        public BlackMarketGump( Mobile merchant, Mobile from, Item item, int page, int id ): base( 50, 50 )
        {
			string color = "#EEEEEE";
			string gold = "#E8EB30";

            m_Merchant = merchant;
            m_From = from;
            m_Item = item;
            m_Page = page;
			m_ID = id;

			Container bank = m_Merchant.BankBox;
			int itemCount = 0;
			int itemMin = (m_Page*8);
			int itemMax = itemMin+7;
			int entryLow = 62;
			int entry1y = 69;
			int entry2y = 93;
			int entry3y = 94;
			int entry4y = 123;
			int stock = bank.TotalItems;
			string itemName = "";

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;

			AddPage(0);

			AddImage(0, 0, 2629);

			// navigation buttons
			if ( m_Page > 1 )
				AddButton(23, 32, 4014, 4014, m_Page-1, GumpButtonType.Reply, 0);
			if ( stock > itemMax )
				AddButton(62, 32, 4005, 4005, m_Page+1, GumpButtonType.Reply, 0);

			// number of pages
			AddHtml( 110, 33, 63, 21, @"<BODY><BASEFONT Color=" + color + ">" + (m_Page) + " / " + ((int)(stock/8)) + "</BASEFONT></BODY>", (bool)false, (bool)false);

			// close
			AddButton(193, 32, 4017, 4017, -1, GumpButtonType.Reply, 0);

			foreach( Item i in bank.Items )
			{
				itemCount++;

				if ( itemCount >= itemMin && itemCount <= itemMax )
				{
					itemName = ItemProps.GetItemName( i );
					if ( itemName.Contains("Magic Wand Of ") )
						itemName = itemName.Replace("Magic Wand Of ", "");

					AddHtml( 29, entry1y, 192, 21, @"<BODY><BASEFONT Color=" + color + ">" + itemName + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddButton(29, entry2y, 4011, 4011, i.Serial, GumpButtonType.Reply, 0);
					AddHtml( 150, entry3y, 102, 21, @"<BODY><BASEFONT Color=" + gold + ">Gold: " + Price( i, m_From, m_Merchant ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(35, entry4y, 96, 2995);

					entry1y += entryLow;
					entry2y += entryLow;
					entry3y += entryLow;
					entry4y += entryLow;
				}
			}

			m_Item = GetItem( m_Merchant, m_ID );

			if ( m_Item != null ) // INFORMATION SCROLL
			{
				AddImage(0, 0, 2630);

				// buy item
				AddButton(439, 55, 4023, 4023, -2, GumpButtonType.Reply, 0);

				// item image
				AddItem(272, 57, m_Item.ItemID, m_Item.Hue);

				// gold image
				AddItem(400, 58, 3823);

				// price
				AddHtml( 402, 86, 64, 21, @"<BODY><BASEFONT Color=" + gold + ">" + Price( m_Item, m_From, m_Merchant ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

				// description
				AddHtml( 266, 138, 201, 379, @"<BODY><BASEFONT Color=" + color + ">" + ItemProps.ItemProperties( m_Item, false ) + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}
		}

		public static Item GetItem( Mobile m, int id )
		{
			Item item = null;
			Container bank = m.BankBox;

			foreach( Item i in bank.Items )
			{
				if ( i.Serial == id )
					item = i;
			}

			return item;
		}

		public static int Price( Item item, Mobile m, Mobile vendor )
		{
			int price = ItemInformation.GetBuysPrice( ItemInformation.GetInfo( item.GetType() ), false, item, false, true );

			BaseVendor merchant = (BaseVendor)vendor;
			PlayerMobile pm = (PlayerMobile)m;

			int barter = (int)m.Skills[SkillName.Mercantile].Value;

			bool GuildMember = false;

			if ( barter < 100 && merchant.NpcGuild != NpcGuild.None && merchant.NpcGuild == pm.NpcGuild ){ barter = 100; GuildMember = true; } // FOR GUILD MEMBERS

			if ( BaseVendor.BeggingPose( m ) > 0 && !GuildMember ) // LET US SEE IF THEY ARE BEGGING
				barter = (int)m.Skills[SkillName.Begging].Value;

			if ( barter > 0 )
				price = price - (int)( ( barter * 0.005 ) * price ); if ( price < 1 ){ price = 1; }

			return price;
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == -2 && m_Item != null )
			{
				int price = Price( m_Item, m_From, m_Merchant );

				if ( m_Item == null || m_Item.RootParent != m_Merchant )
				{
					m_Item = null;
					m_ID = 0;
					m_Merchant.SayTo( m_From, "Sorry, but that item was already sold.");
				}
				else
				{
					Container packs = m_From.Backpack;
					bool bought = false;
					bool fromBank = false;

					if ( packs != null )
					{
						if ( packs.ConsumeTotal( typeof( Gold ), price ) )
						{
							bought = true;
							m_From.PlaySound( 0x32 );
							packs.DropItem( m_Item );
							m_Item = null;
							m_ID = 0;

							if ( BaseVendor.BeggingPose( m_From ) > 0 )
								Titles.AwardKarma( m_From, -BaseVendor.BeggingKarma( m_From ), true );
						}
						else if ( price < 2000 )
							m_Merchant.SayTo( m_From, 500192 ); //Begging thy pardon, but thou casnt afford that.
					}

					if ( !bought && price >= 2000 )
					{
						Container bank = m_From.FindBankNoCreate();
						if ( bank != null && bank.ConsumeTotal( typeof( Gold ), price ) )
						{
							bought = true;
							fromBank = true;
						}
						else
						{
							m_Merchant.SayTo( m_From, 500191 ); //Begging thy pardon, but thy bank account lacks these funds.
						}
					}

					if ( bought )
					{
						m_From.PlaySound( 0x32 );
						packs.DropItem( m_Item );
						m_Merchant.CoinPurse += price;
						m_Item = null;
						m_ID = 0;

						if ( BaseVendor.BeggingPose( m_From ) > 0 )
							Titles.AwardKarma( m_From, -BaseVendor.BeggingKarma( m_From ), true );

						if ( fromBank )
							m_Merchant.SayTo( m_From, true, "The total of thy purchase is {0} gold, which has been withdrawn from your bank account.  My thanks for the patronage.", price );
						else
							m_Merchant.SayTo( m_From, true, "The total of thy purchase is {0} gold.  My thanks for the patronage.", price );

						m_Merchant.InvalidateProperties();
					}
				}

				m_From.SendGump( new BlackMarketGump( m_Merchant, m_From, m_Item, m_Page, m_ID ) );
			}
			else if ( info.ButtonID > 0 )
			{
				if ( info.ButtonID < 100 )
					m_Page = info.ButtonID;
				else if ( info.ButtonID > 0 )
				{
					Item item = GetItem( m_Merchant, info.ButtonID );

					if ( item == null )
					{
						m_Item = null;
						m_ID = 0;
					}
					else
					{
						m_Item = item;
						m_ID = item.Serial;
					}
				}

				m_From.SendGump( new BlackMarketGump( m_Merchant, m_From, m_Item, m_Page, m_ID ) );
			}
		}
    }
}