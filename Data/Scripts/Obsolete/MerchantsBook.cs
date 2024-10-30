using System;
using Server; 
using Server.Network;
using System.Collections;
using System.Globalization;
using Server.Items;
using Server.Misc;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	public class MerchantsBook : Item
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			InvalidateProperties();
		}

		public static MerchantsBook m_Book;

		// SEE LISTING BELOW AND MAKE SURE IT MATCHES THE AMOUNT
		// DO THIS NUMBER+1 IN THE AmountSold SECTION BELOW

		public int AmountSold;
		[CommandProperty(AccessLevel.Owner)]
		public int Amount_Sold { get { return AmountSold; } set { AmountSold = value; InvalidateProperties(); } }

		public string BookTitle;
		[CommandProperty(AccessLevel.Owner)]
		public string Book_Title { get { return BookTitle; } set { BookTitle = value; InvalidateProperties(); } }

		public string MaterialType;
		[CommandProperty(AccessLevel.Owner)]
		public string Material_Type { get { return MaterialType; } set { MaterialType = value; InvalidateProperties(); } }

		public string MaterialSpecific;
		[CommandProperty(AccessLevel.Owner)]
		public string Material_Specific { get { return MaterialSpecific; } set { MaterialSpecific = value; InvalidateProperties(); } }

		public double MarkUp;
		[CommandProperty(AccessLevel.Owner)]
		public double Mark_Up { get { return MarkUp; } set { MarkUp = value; InvalidateProperties(); } }

		[Constructable]
		public MerchantsBook() : base( 0x4FDF )
		{
			Weight = 1.0;
			Movable = false;
			Name = null;
			AmountSold = 0;
			BookTitle = null;
			MaterialType = null;
			MaterialSpecific = null;
			MarkUp = 0.00;
			Resource = CraftResource.Copper;
			Visible = false;
			this.Delete();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Visible )
			{
				if ( from.InRange( this.GetWorldLocation(), 5 ) )
				{
					from.SendSound( 0x55 );
					from.CloseGump( typeof( MerchantsBookGump ) );
					from.SendGump( new MerchantsBookGump( from, this, 0 ) );
				}
				else
				{
					from.SendMessage( "That is too far away to read." );
				}
			}
		}

		public class MerchantsBookGump : Gump
		{
			public MerchantsBookGump( Mobile from, MerchantsBook salesbook, int page ): base( 100, 100 )
			{
				m_Book = salesbook;

				decimal PageCount = m_Book.AmountSold / 16;
				int TotalBookPages = ( 100000 ) + ( (int)Math.Ceiling( PageCount ) );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				string color = "#d6c382";

				AddPage(0);

				int subItem = page * 16;

				int showItem1 = subItem + 1;
				int showItem2 = subItem + 2;
				int showItem3 = subItem + 3;
				int showItem4 = subItem + 4;
				int showItem5 = subItem + 5;
				int showItem6 = subItem + 6;
				int showItem7 = subItem + 7;
				int showItem8 = subItem + 8;
				int showItem9 = subItem + 9;
				int showItem10 = subItem + 10;
				int showItem11 = subItem + 11;
				int showItem12 = subItem + 12;
				int showItem13 = subItem + 13;
				int showItem14 = subItem + 14;
				int showItem15 = subItem + 15;
				int showItem16 = subItem + 16;

				int page_prev = ( 100000 + page ) - 1;
					if ( page_prev < 100000 ){ page_prev = TotalBookPages; }
				int page_next = ( 100000 + page ) + 1;
					if ( page_next > TotalBookPages ){ page_next = 100000; }

				AddImage(0, 0, 7005, salesbook.Hue-1);
				AddImage(0, 0, 7006);
				AddImage(0, 0, 7024, 2736);
				AddButton(72, 45, 4014, 4014, page_prev, GumpButtonType.Reply, 0);
				AddButton(590, 48, 4005, 4005, page_next, GumpButtonType.Reply, 0);
				AddHtml( 107, 45, 214, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + m_Book.BookTitle + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 368, 45, 214, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + m_Book.BookTitle + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				///////////////////////////////////////////////////////////////////////////////////

				int x = 83;
				int y = 84;
				int s = 84;
				int z = 34;

				y=y+z;
				if ( GetSalesForBook( m_Book, showItem1, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem1, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem2, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem2, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem3, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem3, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem4, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem4, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem5, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem5, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem6, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem6, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem7, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem7, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem8, 1 , from) != "" ){ AddButton(x, y, 2447, 2447, showItem8, GumpButtonType.Reply, 0); } y=s-3;

				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">ITEM</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem1, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem2, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem3, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem4, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem5, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem6, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem7, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem8, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=s-3;

				AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>GOLD</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				if ( GetSalesForBook( m_Book, showItem1, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem1, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem2, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem2, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem3, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem3, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem4, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem4, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem5, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem5, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem6, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem6, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem7, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem7, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem8, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem8, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;

				///////////////////////////////////////////////////////////////////////////////////

				x = 375;
				y = s;

				y=y+z;
				if ( GetSalesForBook( m_Book, showItem9, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem9, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem10, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem10, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem11, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem11, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem12, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem12, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem13, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem13, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem14, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem14, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem15, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem15, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem16, 1, from ) != "" ){ AddButton(x, y, 2447, 2447, showItem16, GumpButtonType.Reply, 0); } y=s-3;

				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">ITEM</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem9, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem10, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem11, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem12, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem13, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem14, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem15, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetSalesForBook( m_Book, showItem16, 1, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=s-3;

				AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>GOLD</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				if ( GetSalesForBook( m_Book, showItem9, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem9, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem10, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem10, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem11, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem11, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem12, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem12, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem13, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem13, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem14, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem14, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem15, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem15, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
				if ( GetSalesForBook( m_Book, showItem16, 1, from ) != "" ){ AddHtml( x+180, y, 58, 20, @"<BODY><BASEFONT Color=" + color + "><RIGHT>" + GetSalesForBook( m_Book, showItem16, 3, from ) + "</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false); } y=y+z;
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile; 
				Container pack = from.Backpack;
				from.SendSound( 0x55 );
				int NumItemsSold = m_Book.AmountSold;

				if ( info.ButtonID >= 100000 )
				{
					int page = info.ButtonID - 100000;
					from.SendGump( new MerchantsBookGump( from, m_Book, page ) );
				}
				else if ( info.ButtonID < NumItemsSold )
				{
					bool run = false;

					foreach ( Mobile who in from.GetMobilesInRange( 15 ) )
					{
						if ( ( who is BlacksmithGuildmaster || who is Garth || who is IronWorker || who is Weaponsmith || who is Armorer || who is Blacksmith ) && m_Book.MaterialType == "metal" )
						{
							run = true;
						}
						else if ( ( who is Carpenter || who is CarpenterGuildmaster ) && m_Book.MaterialType == "wood" )
						{
							run = true;
						}
						else if ( ( who is Tanner || who is Cobbler || who is Furtrader || who is LeatherWorker || who is Tailor || who is TailorGuildmaster ) && m_Book.MaterialType == "leather" )
						{
							run = true;
						}
						else if ( ( (who.Name == "Iolo" && who.Title == "the Bowman") || who is Ranger || who is RangerGuildmaster || who is Bowyer || who is ArcherGuildmaster ) && m_Book.MaterialType == "bows" )
						{
							run = true;
						}
					}

					if ( run )
					{
						string sType = GetSalesForBook( m_Book, info.ButtonID, 2, from );
						string sName = GetSalesForBook( m_Book, info.ButtonID, 1, from );
						int cost = Int32.Parse( GetSalesForBook( m_Book, info.ButtonID, 3, from ) );
						string spentMessage = "You pay a total of " + cost.ToString() + " gold.";

						if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
						{
							cost = cost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * cost ); if ( cost < 1 ){ cost = 1; }
							spentMessage = "You only pay a total of " + cost.ToString() + " gold because of your begging.";
						}

						bool nearBook = false;
						foreach ( Item tome in from.GetItemsInRange( 10 ) )
						{
							if ( tome == m_Book ){ nearBook = true; }
						}

						if ( sName != "" && nearBook == true )
						{
							if ( from.TotalGold >= cost )
							{
								Item item = null;
								Type itemType = ScriptCompiler.FindTypeByName( sType );
								item = (Item)Activator.CreateInstance(itemType);

								pack.ConsumeTotal(typeof(Gold), cost);
								from.SendMessage( spentMessage );

								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = m_Book.Resource; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = m_Book.Resource; }
								else if ( item is BaseInstrument ){ BaseInstrument lute = (BaseInstrument)item; lute.Resource = m_Book.Resource; }
								else if ( item is TenFootPole ){ item.Resource = m_Book.Resource; }
								else if ( item is FishingPole ){ item.Resource = m_Book.Resource; }

								from.AddToBackpack ( item );
								if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -Server.Mobiles.BaseVendor.BeggingKarma( from ), true ); } // DO ANY KARMA LOSS

								int OneSay = 0;

								foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
								{
									if ( ( who is BlacksmithGuildmaster || who is Garth || who is IronWorker || who is Weaponsmith || who is Armorer || who is Blacksmith ) && m_Book.MaterialType == "metal" && OneSay == 0 )
									{
										who.PlaySound( 0x2A );
										
										switch( Utility.Random( 2 ) )
										{
											case 0: who.Say( "I have spent years learning the art of forging this metal." ); 	break;
											case 1: who.Say( "Let me see what I can make here." );								break;
											case 2: who.Say( "People come from afar for this forged metal." );	 				break;
											case 3: who.Say( "You won't see many items like this." );							break;
											case 4: who.Say( "I think I can forge that for you." );								break;
											case 5: who.Say( "The fires are hot so I am ready to forge that metal." );			break;
										}

										OneSay = 1;
									}
									else if ( ( who is Carpenter || who is CarpenterGuildmaster ) && m_Book.MaterialType == "wood" && OneSay == 0 )
									{
										who.PlaySound( 0x23D );
										
										switch( Utility.Random( 2 ) )
										{
											case 0: who.Say( "I have spent years learning the art of carving this wood." ); 	break;
											case 1: who.Say( "Let me see what I can make here." );								break;
											case 2: who.Say( "People come from afar for this crafted wood" );	 				break;
											case 3: who.Say( "You won't see many items like this." );							break;
											case 4: who.Say( "I think I can carve that for you." );								break;
											case 5: who.Say( "The blades are sharpened so I can carve that for you." );			break;
										}

										OneSay = 1;
									}
									else if ( ( who is Tanner || who is Cobbler || who is Furtrader || who is LeatherWorker || who is Tailor || who is TailorGuildmaster ) && m_Book.MaterialType == "leather" && OneSay == 0 )
									{
										who.PlaySound( 0x248 );
										
										switch( Utility.Random( 2 ) )
										{
											case 0: who.Say( "I have spent years learning the art of leather working." );	 	break;
											case 1: who.Say( "Let me see what I can make here." );								break;
											case 2: who.Say( "People come from afar for this tanned leather." );	 			break;
											case 3: who.Say( "You won't see many items like this." );							break;
											case 4: who.Say( "I think I can stitch that for you." );							break;
											case 5: who.Say( "I found my sewing kit so I can stitch that together for you." );	break;
										}

										OneSay = 1;
									}
									else if ( ( (who.Name == "Iolo" && who.Title == "the Bowman") || who is Ranger || who is RangerGuildmaster || who is Bowyer || who is ArcherGuildmaster ) && m_Book.MaterialType == "bows" && OneSay == 0 )
									{
										who.PlaySound( 0x55 );
										
										switch( Utility.Random( 2 ) )
										{
											case 0: who.Say( "I have spent years learning the art of carving this wood." ); 	break;
											case 1: who.Say( "Let me see what I can make here." );								break;
											case 2: who.Say( "People come from afar for this crafted wood" );	 				break;
											case 3: who.Say( "You won't see many items like this." );							break;
											case 4: who.Say( "I think I can carve that for you." );								break;
											case 5: who.Say( "The blades are sharpened so I can carve that for you." );			break;
										}

										OneSay = 1;
									}
								}
							}
							else
							{
								int NoGold = 0;

								foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
								{
									if ( ( who is BlacksmithGuildmaster || who is Garth || who is IronWorker || who is Weaponsmith || who is Armorer || who is Blacksmith ) && m_Book.MaterialType == "metal" && NoGold == 0 )
									{
										who.Say( "You don't seem to have enough gold for me to make that." );
										NoGold = 1;
									}
									else if ( ( who is Carpenter || who is CarpenterGuildmaster ) && m_Book.MaterialType == "wood" && NoGold == 0 )
									{
										who.Say( "You don't seem to have enough gold for me to make that." );
										NoGold = 1;
									}
									else if ( ( who is Tanner || who is Cobbler || who is Furtrader || who is LeatherWorker || who is Tailor || who is TailorGuildmaster ) && m_Book.MaterialType == "leather" && NoGold == 0 )
									{
										who.Say( "You don't seem to have enough gold for me to make that." );
										NoGold = 1;
									}
									else if ( ( (who.Name == "Iolo" && who.Title == "the Bowman") || who is Ranger || who is RangerGuildmaster || who is Bowyer || who is ArcherGuildmaster ) && m_Book.MaterialType == "bows" && NoGold == 0 )
									{
										who.Say( "You don't seem to have enough gold for me to make that." );
										NoGold = 1;
									}
								}
							}
						}
					}
				}
			}
		}

		public MerchantsBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)2 ); // version
            writer.Write( AmountSold );
            writer.Write( BookTitle );
            writer.Write( MaterialType );
            writer.Write( MaterialSpecific );
            writer.Write( MarkUp );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            AmountSold = reader.ReadInt();
            BookTitle = reader.ReadString();
            MaterialType = reader.ReadString();
			MaterialSpecific = reader.ReadString();
            MarkUp = reader.ReadDouble();

			if ( version < 2 )
				m_Resource = (CraftResource)reader.ReadEncodedInt();

			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			((Item)state).Delete();
		}

		public static string GetSalesForBook( MerchantsBook book, int selling, int part, Mobile player )
		{
			double barter = player.Skills[SkillName.Mercantile].Value * 0.001;

			string item = "";
			string name = "";
			int cost = 0;

			int sales = 1;
			int rate = 4; // STANDARD MARKUP

			double markup = book.MarkUp * rate;

			markup = markup - ( markup * barter );

			if ( book.MaterialType == "metal" )
			{
				if ( selling == sales ) { name="AssassinSpike"; item="Assassin Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenSpellblade"; item="Assassin Sword"; cost = 33; } sales++;
				if ( selling == sales ) { name="Axe"; item="Axe"; cost = 40; } sales++;
				if ( selling == sales ) { name="OrnateAxe"; item="Barbarian Axe"; cost = 42; } sales++;
				if ( selling == sales ) { name="VikingSword"; item="Barbarian Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Bardiche"; item="Bardiche"; cost = 60; } sales++;
				if ( selling == sales ) { name="Bascinet"; item="Bascinet"; cost = 18; } sales++;
				if ( selling == sales ) { name="BattleAxe"; item="Battle Axe"; cost = 26; } sales++;
				if ( selling == sales ) { name="DiamondMace"; item="Battle Mace"; cost = 31; } sales++;
				if ( selling == sales ) { name="BladedStaff"; item="Bladed Staff"; cost = 40; } sales++;
				if ( selling == sales ) { name="Broadsword"; item="Broadsword"; cost = 35; } sales++;
				if ( selling == sales ) { name="Buckler"; item="Buckler"; cost = 50; } sales++;
				if ( selling == sales ) { name="ButcherKnife"; item="Butcher Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="ChainChest"; item="Chain Chest"; cost = 143; } sales++;
				if ( selling == sales ) { name="ChainCoif"; item="Chain Coif"; cost = 17; } sales++;
				if ( selling == sales ) { name="ChainHatsuburi"; item="Chain Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="ChainLegs"; item="Chain Legs"; cost = 149; } sales++;
				if ( selling == sales ) { name="ChampionShield"; item="Champion Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="ChaosShield"; item="Chaos Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="Claymore"; item="Claymore"; cost = 55; } sales++;
				if ( selling == sales ) { name="Cleaver"; item="Cleaver"; cost = 15; } sales++;
				if ( selling == sales ) { name="CloseHelm"; item="Close Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="CrescentBlade"; item="Crescent Blade"; cost = 37; } sales++;
				if ( selling == sales ) { name="CrestedShield"; item="Crested Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Cutlass"; item="Cutlass"; cost = 24; } sales++;
				if ( selling == sales ) { name="Dagger"; item="Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="Daisho"; item="Daisho"; cost = 66; } sales++;
				if ( selling == sales ) { name="DarkShield"; item="Dark Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="DecorativePlateKabuto"; item="Decorative Plate Kabuto"; cost = 95; } sales++;
				if ( selling == sales ) { name="DoubleAxe"; item="Double Axe"; cost = 52; } sales++;
				if ( selling == sales ) { name="DoubleBladedStaff"; item="Double Bladed Staff"; cost = 35; } sales++;
				if ( selling == sales ) { name="DreadHelm"; item="Dread Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenShield"; item="Elven Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="RadiantScimitar"; item="Falchion"; cost = 35; } sales++;
				if ( selling == sales ) { name="FemalePlateChest"; item="Female Plate Chest"; cost = 113; } sales++;
				if ( selling == sales ) { name="ExecutionersAxe"; item="Executioner Axe"; cost = 30; } sales++;
				if ( selling == sales ) { name="GuardsmanShield"; item="Guardsman Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Halberd"; item="Halberd"; cost = 42; } sales++;
				if ( selling == sales ) { name="Hammers"; item="Hammer"; cost = 28; } sales++;
				if ( selling == sales ) { name="HammerPick"; item="Hammer Pick"; cost = 26; } sales++;
				if ( selling == sales ) { name="Harpoon"; item="Harpoon"; cost = 40; } sales++;
				if ( selling == sales ) { name="HeaterShield"; item="Heater Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="HeavyPlateJingasa"; item="Heavy Plate Jingasa"; cost = 76; } sales++;
				if ( selling == sales ) { name="Helmet"; item="Helmet"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrcHelm"; item="Horned Helm"; cost = 24; } sales++;
				if ( selling == sales ) { name="JeweledShield"; item="Jeweled Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Kama"; item="Kama"; cost = 61; } sales++;
				if ( selling == sales ) { name="Katana"; item="Katana"; cost = 33; } sales++;
				if ( selling == sales ) { name="Kryss"; item="Kryss"; cost = 32; } sales++;
				if ( selling == sales ) { name="Lajatang"; item="Lajatang"; cost = 108; } sales++;
				if ( selling == sales ) { name="Lance"; item="Lance"; cost = 34; } sales++;
				if ( selling == sales ) { name="LargeBattleAxe"; item="Large Battle Axe"; cost = 33; } sales++;
				if ( selling == sales ) { name="LargeKnife"; item="Large Knife"; cost = 21; } sales++;
				if ( selling == sales ) { name="BronzeShield"; item="Large Shield"; cost = 66; } sales++;
				if ( selling == sales ) { name="LightPlateJingasa"; item="Light Plate Jingasa"; cost = 56; } sales++;
				if ( selling == sales ) { name="Longsword"; item="Longsword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Mace"; item="Mace"; cost = 28; } sales++;
				if ( selling == sales ) { name="ElvenMachete"; item="Machete"; cost = 35; } sales++;
				if ( selling == sales ) { name="Maul"; item="Maul"; cost = 21; } sales++;
				if ( selling == sales ) { name="MetalKiteShield"; item="Metal Kite Shield"; cost = 123; } sales++;
				if ( selling == sales ) { name="MetalShield"; item="Metal Shield"; cost = 121; } sales++;
				if ( selling == sales ) { name="NoDachi"; item="NoDachi"; cost = 82; } sales++;
				if ( selling == sales ) { name="NorseHelm"; item="Norse Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrderShield"; item="Order Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="Pike"; item="Pike"; cost = 39; } sales++;
				if ( selling == sales ) { name="Pitchforks"; item="Pitchfork"; cost = 19; } sales++;
				if ( selling == sales ) { name="PlateArms"; item="Plate Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="PlateBattleKabuto"; item="Plate Battle Kabuto"; cost = 94; } sales++;
				if ( selling == sales ) { name="PlateChest"; item="Plate Chest"; cost = 243; } sales++;
				if ( selling == sales ) { name="PlateDo"; item="Plate Do"; cost = 310; } sales++;
				if ( selling == sales ) { name="PlateGloves"; item="Plate Gloves"; cost = 155; } sales++;
				if ( selling == sales ) { name="PlateGorget"; item="Plate Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="PlateHaidate"; item="Plate Haidate"; cost = 235; } sales++;
				if ( selling == sales ) { name="PlateHatsuburi"; item="Plate Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateHelm"; item="Plate Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="PlateHiroSode"; item="Plate Hiro Sode"; cost = 222; } sales++;
				if ( selling == sales ) { name="PlateLegs"; item="Plate Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="PlateMempo"; item="Plate Mempo"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateSuneate"; item="Plate Suneate"; cost = 224; } sales++;
				if ( selling == sales ) { name="ShortSpear"; item="Rapier"; cost = 23; } sales++;
				if ( selling == sales ) { name="RingmailArms"; item="Ringmail Arms"; cost = 85; } sales++;
				if ( selling == sales ) { name="RingmailChest"; item="Ringmail Chest"; cost = 121; } sales++;
				if ( selling == sales ) { name="RingmailGloves"; item="Ringmail Gloves"; cost = 93; } sales++;
				if ( selling == sales ) { name="RingmailLegs"; item="Ringmail Legs"; cost = 90; } sales++;
				if ( selling == sales ) { name="RoyalArms"; item="Royal Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="RoyalBoots"; item="Royal Boots"; cost = 40; } sales++;
				if ( selling == sales ) { name="RoyalChest"; item="Royal Chest"; cost = 242; } sales++;
				if ( selling == sales ) { name="RoyalGloves"; item="Royal Gloves"; cost = 144; } sales++;
				if ( selling == sales ) { name="RoyalGorget"; item="Royal Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="RoyalHelm"; item="Royal Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="RoyalShield"; item="Royal Shield"; cost = 230; } sales++;
				if ( selling == sales ) { name="RoyalsLegs"; item="Royal Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="RoyalSword"; item="Royal Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Sai"; item="Sai"; cost = 56; } sales++;
				if ( selling == sales ) { name="Scepter"; item="Scepter"; cost = 39; } sales++;
				if ( selling == sales ) { name="Sceptre"; item="Sceptre"; cost = 38; } sales++;
				if ( selling == sales ) { name="Scimitar"; item="Scimitar"; cost = 36; } sales++;
				if ( selling == sales ) { name="Scythe"; item="Scythe"; cost = 39; } sales++;
				if ( selling == sales ) { name="ShortSword"; item="Short Sword"; cost = 35; } sales++;
				if ( selling == sales ) { name="BoneHarvester"; item="Sickle"; cost = 35; } sales++;
				if ( selling == sales ) { name="SkinningKnife"; item="Skinning Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="SmallPlateJingasa"; item="Small Plate Jingasa"; cost = 66; } sales++;
				if ( selling == sales ) { name="Spear"; item="Spear"; cost = 31; } sales++;
				if ( selling == sales ) { name="SpikedClub"; item="Spiked Club"; cost = 28; } sales++;
				if ( selling == sales ) { name="StandardPlateKabuto"; item="Standard Plate Kabuto"; cost = 74; } sales++;
				if ( selling == sales ) { name="WizardStaff"; item="Stave"; cost = 40; } sales++;
				if ( selling == sales ) { name="SunShield"; item="Sun Shield"; cost = 76; } sales++;
				if ( selling == sales ) { name="ThinLongsword"; item="Sword"; cost = 27; } sales++;
				if ( selling == sales ) { name="Tekagi"; item="Tekagi"; cost = 55; } sales++;
				if ( selling == sales ) { name="Tessen"; item="Tessen"; cost = 83; } sales++;
				if ( selling == sales ) { name="Tetsubo"; item="Tetsubo"; cost = 43; } sales++;
				if ( selling == sales ) { name="Pitchfork"; item="Trident"; cost = 19; } sales++;
				if ( selling == sales ) { name="TwoHandedAxe"; item="Two Handed Axe"; cost = 32; } sales++;
				if ( selling == sales ) { name="VirtueShield"; item="Virtue Shield"; cost = 76; } sales++;
				if ( selling == sales ) { name="Wakizashi"; item="Wakizashi"; cost = 38; } sales++;
				if ( selling == sales ) { name="WarAxe"; item="War Axe"; cost = 29; } sales++;
				if ( selling == sales ) { name="RuneBlade"; item="War Blades"; cost = 55; } sales++;
				if ( selling == sales ) { name="WarCleaver"; item="War Cleaver"; cost = 25; } sales++;
				if ( selling == sales ) { name="Leafblade"; item="War Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="WarFork"; item="War Fork"; cost = 32; } sales++;
				if ( selling == sales ) { name="WarHammer"; item="War Hammer"; cost = 24; } sales++;
				if ( selling == sales ) { name="WarMace"; item="War Mace"; cost = 31; } sales++;
				if ( selling == sales ) { name="BlackStaff"; item="Wizard Staff"; cost = 22; } sales++;
				if ( selling == sales ) { name="Trumpet"; item="Trumpet"; cost = 21; } sales++;
			}
			else if ( book.MaterialType == "leather" )
			{
				if ( selling == sales ) { name="PugilistMits"; item="Pugilist Gloves"; cost = 18; } sales++;
				if ( selling == sales ) { name="ThrowingGloves"; item="Throwing Gloves"; cost = 26; } sales++;
				if ( selling == sales ) { name="Whips"; item="Whip"; cost = 16; } sales++;
				if ( selling == sales ) { name="BoneArms"; item="Bone Arms"; cost = 90; } sales++;
				if ( selling == sales ) { name="BoneChest"; item="Bone Chest"; cost = 111; } sales++;
				if ( selling == sales ) { name="BoneGloves"; item="Bone Gloves"; cost = 70; } sales++;
				if ( selling == sales ) { name="BoneHelm"; item="Bone Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="BoneLegs"; item="Bone Legs"; cost = 90; } sales++;
				if ( selling == sales ) { name="BoneSkirt"; item="Bone Skirt"; cost = 95; } sales++;
				if ( selling == sales ) { name="HikingBoots"; item="Hiking Boots"; cost = 800; } sales++;
				if ( selling == sales ) { name="OrcHelm"; item="Horned Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="LeatherArms"; item="Leather Arms"; cost = 80; } sales++;
				if ( selling == sales ) { name="LeatherBustierArms"; item="Leather Arms, Bustier"; cost = 97; } sales++;
				if ( selling == sales ) { name="LeatherBoots"; item="Leather Boots"; cost = 90; } sales++;
				if ( selling == sales ) { name="LeatherCap"; item="Leather Cap"; cost = 10; } sales++;
				if ( selling == sales ) { name="LeatherChest"; item="Leather Chest"; cost = 101; } sales++;
				if ( selling == sales ) { name="FemaleLeatherChest"; item="Leather Chest, Female"; cost = 116; } sales++;
				if ( selling == sales ) { name="LeatherCloak"; item="Leather Cloak"; cost = 120; } sales++;
				if ( selling == sales ) { name="LeatherGloves"; item="Leather Gloves"; cost = 60; } sales++;
				if ( selling == sales ) { name="LeatherGorget"; item="Leather Gorget"; cost = 74; } sales++;
				if ( selling == sales ) { name="LeatherLegs"; item="Leather Legs"; cost = 80; } sales++;
				if ( selling == sales ) { name="LeatherRobe"; item="Leather Robe"; cost = 160; } sales++;
				if ( selling == sales ) { name="LeatherSandals"; item="Leather Sandals"; cost = 60; } sales++;
				if ( selling == sales ) { name="LeatherShoes"; item="Leather Shoes"; cost = 75; } sales++;
				if ( selling == sales ) { name="LeatherShorts"; item="Leather Shorts"; cost = 86; } sales++;
				if ( selling == sales ) { name="LeatherSkirt"; item="Leather Skirt"; cost = 87; } sales++;
				if ( selling == sales ) { name="LeatherSoftBoots"; item="Leather Soft Boots"; cost = 120; } sales++;
				if ( selling == sales ) { name="LeatherThighBoots"; item="Leather Thigh Boots"; cost = 105; } sales++;
				if ( selling == sales ) { name="OniwabanBoots"; item="Oniwaban Boots"; cost = 90; } sales++;
				if ( selling == sales ) { name="OniwabanGloves"; item="Oniwaban Gloves"; cost = 60; } sales++;
				if ( selling == sales ) { name="OniwabanHood"; item="Oniwaban Hood"; cost = 10; } sales++;
				if ( selling == sales ) { name="OniwabanLeggings"; item="Oniwaban Leggingss"; cost = 80; } sales++;
				if ( selling == sales ) { name="OniwabanTunic"; item="Oniwaban Tunic"; cost = 101; } sales++;
				if ( selling == sales ) { name="SavageArms"; item="Savage Arms"; cost = 90; } sales++;
				if ( selling == sales ) { name="SavageChest"; item="Savage Chest"; cost = 111; } sales++;
				if ( selling == sales ) { name="SavageGloves"; item="Savage Gloves"; cost = 70; } sales++;
				if ( selling == sales ) { name="SavageHelm"; item="Savage Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="SavageLegs"; item="Savage Legs"; cost = 90; } sales++;
				if ( selling == sales ) { name="StuddedArms"; item="Studded Arms"; cost = 87; } sales++;
				if ( selling == sales ) { name="StuddedBustierArms"; item="Studded Arms, Bustier"; cost = 120; } sales++;
				if ( selling == sales ) { name="StuddedChest"; item="Studded Chest"; cost = 128; } sales++;
				if ( selling == sales ) { name="FemaleStuddedChest"; item="Studded Chest, Female"; cost = 62; } sales++;
				if ( selling == sales ) { name="StuddedGloves"; item="Studded Gloves"; cost = 79; } sales++;
				if ( selling == sales ) { name="StuddedGorget"; item="Studded Gorget"; cost = 73; } sales++;
				if ( selling == sales ) { name="StuddedLegs"; item="Studded Legs"; cost = 103; } sales++;
				if ( selling == sales ) { name="StuddedSkirt"; item="Studded Skirt"; cost = 103; } sales++;
				if ( selling == sales ) { name="LeatherDo"; item="Leather Do"; cost = 87; } sales++;
				if ( selling == sales ) { name="LeatherHaidate"; item="Leather Haidate"; cost = 54; } sales++;
				if ( selling == sales ) { name="LeatherHiroSode"; item="Leather Hiro Sode"; cost = 49; } sales++;
				if ( selling == sales ) { name="LeatherJingasa"; item="Leather Jingasa"; cost = 11; } sales++;
				if ( selling == sales ) { name="LeatherMempo"; item="Leather Mempo"; cost = 40; } sales++;
				if ( selling == sales ) { name="LeatherNinjaHood"; item="Leather Ninja Hood"; cost = 10; } sales++;
				if ( selling == sales ) { name="LeatherNinjaJacket"; item="Leather Ninja Jacket"; cost = 51; } sales++;
				if ( selling == sales ) { name="LeatherNinjaMitts"; item="Leather Ninja Mitts"; cost = 60; } sales++;
				if ( selling == sales ) { name="LeatherNinjaPants"; item="Leather Ninja Pants"; cost = 49; } sales++;
				if ( selling == sales ) { name="ShinobiCowl"; item="Leather Shinobi Cowl"; cost = 10; } sales++;
				if ( selling == sales ) { name="ShinobiHood"; item="Leather Shinobi Hood"; cost = 10; } sales++;
				if ( selling == sales ) { name="ShinobiMask"; item="Leather Shinobi Mask"; cost = 10; } sales++;
				if ( selling == sales ) { name="ShinobiRobe"; item="Leather Shinobi Robe"; cost = 160; } sales++;
				if ( selling == sales ) { name="LeatherSuneate"; item="Leather Suneate"; cost = 55; } sales++;
				if ( selling == sales ) { name="StuddedDo"; item="Studded Do"; cost = 130; } sales++;
				if ( selling == sales ) { name="StuddedHaidate"; item="Studded Haidate"; cost = 76; } sales++;
				if ( selling == sales ) { name="StuddedHiroSode"; item="Studded Hiro Sode"; cost = 73; } sales++;
				if ( selling == sales ) { name="StuddedMempo"; item="Studded Mempo"; cost = 61; } sales++;
				if ( selling == sales ) { name="StuddedSuneate"; item="Studded Suneate"; cost = 78; } sales++;
			}
			else if ( book.MaterialType == "wood" )
			{
				if ( selling == sales ) { name="Club"; item="Club"; cost = 16; } sales++;
				if ( selling == sales ) { name="WildStaff"; item="Druid Staff"; cost = 20; } sales++;
				if ( selling == sales ) { name="ShepherdsCrook"; item="Shepherd Crook"; cost = 20; } sales++;
				if ( selling == sales ) { name="QuarterStaff"; item="Quarter Staff"; cost = 19; } sales++;
				if ( selling == sales ) { name="GnarledStaff"; item="Gnarled Staff"; cost = 16; } sales++;
				if ( selling == sales ) { name="WoodenShield"; item="Wooden Shield"; cost = 30; } sales++;
				if ( selling == sales ) { name="WoodenPlateArms"; item="Wooden Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="WoodenPlateGloves"; item="Wooden Gauntlets"; cost = 155; } sales++;
				if ( selling == sales ) { name="WoodenPlateGorget"; item="Wooden Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="WoodenPlateHelm"; item="Wooden Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="WoodenPlateLegs"; item="Wooden Leggings"; cost = 218; } sales++;
				if ( selling == sales ) { name="WoodenPlateChest"; item="Wooden Tunic"; cost = 243; } sales++;
				if ( selling == sales ) { name="Bokuto"; item="Bokuto"; cost = 21; } sales++;
				if ( selling == sales ) { name="Fukiya"; item="Fukiya"; cost = 20; } sales++;
				if ( selling == sales ) { name="Tetsubo"; item="Tetsubo"; cost = 43; } sales++;
				if ( selling == sales ) { name="Drums"; item="Drum"; cost = 21; } sales++;
				if ( selling == sales ) { name="BambooFlute"; item="Flute"; cost = 21; } sales++;
				if ( selling == sales ) { name="LapHarp"; item="Harp"; cost = 21; } sales++;
				if ( selling == sales ) { name="Lute"; item="Lute"; cost = 21; } sales++;
				if ( selling == sales ) { name="Tambourine"; item="Tambourine"; cost = 21; } sales++;
				if ( selling == sales ) { name="FishingPole"; item="Fishing Pole"; cost = 25; } sales++;
				if ( selling == sales ) { name="TenFootPole"; item="Ten Foot Pole"; cost = 500; } sales++;
			}
			else if ( book.MaterialType == "bows" )
			{
				if ( selling == sales ) { name="Bow"; item="Bow"; cost = 40; } sales++;
				if ( selling == sales ) { name="CompositeBow"; item="Composite Bow"; cost = 45; } sales++;
				if ( selling == sales ) { name="Crossbow"; item="Crossbow"; cost = 55; } sales++;
				if ( selling == sales ) { name="HeavyCrossbow"; item="Heavy Crossbow"; cost = 55; } sales++;
				if ( selling == sales ) { name="RepeatingCrossbow"; item="Repeating Crossbow"; cost = 46; } sales++;
				if ( selling == sales ) { name="ElvenCompositeLongbow"; item="Woodland Longbow"; cost = 42; } sales++;
				if ( selling == sales ) { name="MagicalShortbow"; item="Woodland Shortbow"; cost = 42; } sales++;
				if ( selling == sales ) { name="Yumi"; item="Yumi"; cost = 53; } sales++;
			}

			if ( part == 2 ){ item = name; }
			else if ( part == 3 ){ item = ((int)(cost*markup)).ToString(); }

			return item;
		}

		public static void SetupSaleBooks()
		{
			if ( MyServerSettings.BlackMarket() )
			{
				TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

				foreach ( Item item in World.Items.Values )
				if ( item is MerchantsBook )
				{
					MerchantsBook book = (MerchantsBook)item;

					string material = "";
					string category = "";
					string[] subType = new string[] { "" };
					book.Visible = false;

					if ( (book.Name).Contains("Leather") ){ material = "leather"; }
					else if ( (book.Name).Contains("Wood") ){ material = "wood"; }
					else if ( (book.Name).Contains("Bows") ){ material = "bows"; }
					else if ( (book.Name).Contains("Metal") ){ material = "metal"; }

					if ( material == "metal" )
					{
						book.AmountSold = 125;
						book.MaterialType = "metal";

						subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite" };

						if ( book.Land == Land.Serpent )
							subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite", "obsidian" };

						if ( book.Land == Land.Savaged )
							subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite", "steel" };

						if ( book.Land == Land.UmberVeil )
							subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite", "brass" };

						if ( book.Land == Land.Underworld )
							subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite", "mithril", "xormite" };

						if ( Server.Misc.Worlds.IsSeaTown( book.Location, book.Map ) )
							subType = new string[] { "dull copper", "shadow iron", "copper", "bronze", "gold", "agapite", "verite", "valorite", "nepturite" };

						category = subType[Utility.RandomMinMax( 0, (subType.Length-1) )];
							if ( Utility.RandomMinMax( 1,50 ) == 1 ){ category = "dwarven"; }

						book.Name = cultInfo.ToTitleCase(category) + " Metal Crafted Items";
						book.BookTitle = category.ToUpper() + " METAL";
					}
					else if ( material == "leather" )
					{
						book.AmountSold = 66;
						book.MaterialType = "leather";

						subType = new string[] { "frozen", "volcanic", "serpent", "lizard", "draconic", "hellish", "goliath" };

						if ( book.Land == Land.Underworld )
							subType = new string[] { "frozen", "volcanic", "serpent", "lizard", "draconic", "hellish", "goliath", "alien" };

						if ( Worlds.IsCrypt( book.Location, book.Map ) )
							subType = new string[] { "frozen", "volcanic", "serpent", "lizard", "draconic", "hellish", "goliath", "necrotic" };

						if ( Server.Misc.Worlds.IsSeaTown( book.Location, book.Map ) )
							subType = new string[] { "frozen", "volcanic", "serpent", "lizard", "deep sea", "draconic", "hellish", "goliath" };

						if ( book.Land == Land.Savaged )
							subType = new string[] { "frozen", "volcanic", "dinosaur", "serpent", "lizard", "draconic", "hellish", "goliath" };

						category = subType[Utility.RandomMinMax( 0, (subType.Length-1) )];

						book.Name = cultInfo.ToTitleCase(category) + " Leather Crafted Items";
						book.BookTitle = category.ToUpper() + " LEATHER";
					}
					else if ( material == "wood" )
					{
						book.AmountSold = 23;
						book.MaterialType = "wood";

						subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut" };

						if ( book.Land == Land.Underworld )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut", "petrified" };

						if ( Worlds.IsCrypt( book.Location, book.Map ) )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut", "ghostwood" };

						if ( Server.Misc.Worlds.IsSeaTown( book.Location, book.Map ) )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "driftwood", "oak", "pine", "rosewood", "walnut" };

						category = subType[Utility.RandomMinMax( 0, (subType.Length-1) )];
							if ( Utility.RandomMinMax( 1,50 ) == 1 ){ category = "elven"; }

						book.Name = cultInfo.ToTitleCase(category) + " Wood Crafted Items";
						book.BookTitle = category.ToUpper() + " WOOD";
					}
					else if ( material == "bows" )
					{
						book.AmountSold = 9;
						book.MaterialType = "bows";

						subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut" };

						if ( book.Land == Land.Underworld )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut", "petrified" };

						if ( Worlds.IsCrypt( book.Location, book.Map ) )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "oak", "pine", "rosewood", "walnut", "ghostwood" };

						if ( Server.Misc.Worlds.IsSeaTown( book.Location, book.Map ) )
							subType = new string[] { "ash", "cherry", "ebony", "golden oak", "hickory", "mahogany", "driftwood", "oak", "pine", "rosewood", "walnut" };

						category = subType[Utility.RandomMinMax( 0, (subType.Length-1) )];
							if ( Utility.RandomMinMax( 1,50 ) == 1 ){ category = "elven"; }

						book.Name = cultInfo.ToTitleCase(category) + " Crafted Bows";
						book.BookTitle = category.ToUpper() + " BOWYER";
					}

					if ( category == "dull copper" ){ book.MarkUp = 2; book.Resource = CraftResource.DullCopper; }
					else if ( category == "shadow iron" ){ book.MarkUp = 3; book.Resource = CraftResource.ShadowIron; }
					else if ( category == "copper" ){ book.MarkUp = 4; book.Resource = CraftResource.Copper; }
					else if ( category == "bronze" ){ book.MarkUp = 5; book.Resource = CraftResource.Bronze; }
					else if ( category == "gold" ){ book.MarkUp = 6; book.Resource = CraftResource.Gold; }
					else if ( category == "agapite" ){ book.MarkUp = 7; book.Resource = CraftResource.Agapite; }
					else if ( category == "verite" ){ book.MarkUp = 8; book.Resource = CraftResource.Verite; }
					else if ( category == "valorite" ){ book.MarkUp = 9; book.Resource = CraftResource.Valorite; }
					else if ( category == "nepturite" ){ book.MarkUp = 9; book.Resource = CraftResource.Nepturite; }
					else if ( category == "obsidian" ){ book.MarkUp = 9; book.Resource = CraftResource.Obsidian; }
					else if ( category == "steel" ){ book.MarkUp = 10; book.Resource = CraftResource.Steel; }
					else if ( category == "brass" ){ book.MarkUp = 11; book.Resource = CraftResource.Brass; }
					else if ( category == "mithril" ){ book.MarkUp = 12; book.Resource = CraftResource.Mithril; }
					else if ( category == "xormite" ){ book.MarkUp = 12; book.Resource = CraftResource.Xormite; }
					else if ( category == "dwarven" ){ book.MarkUp = 24; book.Resource = CraftResource.Dwarven; }

					else if ( category == "ash" ){ book.MarkUp = 1.5; book.Resource = CraftResource.AshTree; }
					else if ( category == "cherry" ){ book.MarkUp = 1.5; book.Resource = CraftResource.CherryTree; }
					else if ( category == "ebony" ){ book.MarkUp = 2; book.Resource = CraftResource.EbonyTree; }
					else if ( category == "golden oak" ){ book.MarkUp = 2; book.Resource = CraftResource.GoldenOakTree; }
					else if ( category == "hickory" ){ book.MarkUp = 2.5; book.Resource = CraftResource.HickoryTree; }
					else if ( category == "mahogany" ){ book.MarkUp = 2.5; book.Resource = CraftResource.MahoganyTree; }
					else if ( category == "driftwood" ){ book.MarkUp = 2.5; book.Resource = CraftResource.DriftwoodTree; }
					else if ( category == "oak" ){ book.MarkUp = 3; book.Resource = CraftResource.OakTree; }
					else if ( category == "pine" ){ book.MarkUp = 3; book.Resource = CraftResource.PineTree; }
					else if ( category == "ghost" ){ book.MarkUp = 3; book.Resource = CraftResource.GhostTree; }
					else if ( category == "rosewood" ){ book.MarkUp = 3.5; book.Resource = CraftResource.RosewoodTree; }
					else if ( category == "walnut" ){ book.MarkUp = 3.5; book.Resource = CraftResource.WalnutTree; }
					else if ( category == "elven" ){ book.MarkUp = 7; book.Resource = CraftResource.ElvenTree; }
					else if ( category == "petrified" ){ book.MarkUp = 3; book.Resource = CraftResource.PetrifiedTree; }

					else if ( category == "lizard" ){ book.MarkUp = 2; book.Resource = CraftResource.HornedLeather; }
					else if ( category == "serpent" ){ book.MarkUp = 2; book.Resource = CraftResource.BarbedLeather; }
					else if ( category == "necrotic" ){ book.MarkUp = 2.5; book.Resource = CraftResource.NecroticLeather; }
					else if ( category == "volcanic" ){ book.MarkUp = 2.5; book.Resource = CraftResource.VolcanicLeather; }
					else if ( category == "frozen" ){ book.MarkUp = 3; book.Resource = CraftResource.FrozenLeather; }
					else if ( category == "deep sea" ){ book.MarkUp = 3; book.Resource = CraftResource.SpinedLeather; }
					else if ( category == "goliath" ){ book.MarkUp = 3.5; book.Resource = CraftResource.GoliathLeather; }
					else if ( category == "draconic" ){ book.MarkUp = 3.5; book.Resource = CraftResource.DraconicLeather; }
					else if ( category == "hellish" ){ book.MarkUp = 4; book.Resource = CraftResource.HellishLeather; }
					else if ( category == "dinosaur" ){ book.MarkUp = 4.5; book.Resource = CraftResource.DinosaurLeather; }
					else if ( category == "alien" ){ book.MarkUp = 5; book.Resource = CraftResource.AlienLeather; }

					book.MaterialSpecific = category;

					if ( Utility.RandomBool() ){ book.Visible = true; }
				}
			}
		}
	}
}