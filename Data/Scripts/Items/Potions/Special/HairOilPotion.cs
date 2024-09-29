using System;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class HairOilPotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "This potion will allow you to permanently dye your hair to another color of limited choices."; } }

		[Constructable]
		public HairOilPotion() : base( 0x180F, PotionEffect.HairOil )
		{
			Hue = 0xB50;
            Name = "hair styling potion";
		}

		public HairOilPotion( Serial serial ) : base( serial )
		{
		}

		public static void ConsumeCharge( HairOilPotion potion, Mobile from )
		{
			potion.Consume();
			from.RevealingAction();
			BasePotion.PlayDrinkEffect( from );
			from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );
		}

 		public override void Drink( Mobile from )
		{
			if ( from.RaceID > 0 )
			{
				from.SendMessage( "You don't find this really useful." );
			}
			else if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.CloseGump( typeof( PotionGump ) );
				from.SendGump( new PotionGump( this, from ) );
			}
		}

		private class PotionGump : Gump
		{
			private HairOilPotion m_Potion;
			private Mobile m_From;

			public PotionGump( HairOilPotion potion, Mobile from ) : base( 25, 25 )
			{
				from.SendSound( 0x2D6 );
				m_Potion = potion;
				m_From = from;
				string color = "#ece64c";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9545, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(328, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 12, 13, 293, 20, @"<BODY><BASEFONT Color=" + color + ">CHOOSE A NEW HAIR STYLE</BASEFONT></BODY>", (bool)false, (bool)false);

				int y = 45;

				if ( m_From.HairItemID != 0x203B )
				{
					AddButton(20, y, 4005, 4005, 0x203B, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Short</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x203C )
				{
					AddButton(20, y, 4005, 4005, 0x203C, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Long</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x203D )
				{
					AddButton(20, y, 4005, 4005, 0x203D, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Pony Tail</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x2044 )
				{
					AddButton(20, y, 4005, 4005, 0x2044, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Mohawk</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x2045 )
				{
					AddButton(20, y, 4005, 4005, 0x2045, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Pageboy</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x2047 )
				{
					AddButton(20, y, 4005, 4005, 0x2047, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Afro</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x2049 )
				{
					AddButton(20, y, 4005, 4005, 0x2049, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Pig Tails</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.HairItemID != 0x204A )
				{
					AddButton(20, y, 4005, 4005, 0x204A, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Krisna</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				if ( m_From.Female && m_From.HairItemID != 0x2046 )
				{
					AddButton(20, y, 4005, 4005, 0x2046, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Buns</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
				else if ( !(m_From.Female) && m_From.HairItemID != 0x2048 )
				{
					AddButton(20, y, 4005, 4005, 0x2048, GumpButtonType.Reply, 0);
					AddHtml( 55, y, 195, 20, @"<BODY><BASEFONT Color=" + color + ">Receeding</BASEFONT></BODY>", (bool)false, (bool)false);
					y=y+35;
				}
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( info.ButtonID > 0 )
				{
					if ( m_From.Backpack.FindItemByType( typeof ( HairOilPotion ) ) != null )
					{
						m_From.HairItemID = info.ButtonID;
						Server.Items.HairOilPotion.ConsumeCharge( m_Potion, m_From );
						m_From.SendMessage("You have changed your hair style.");
					}
				}
				m_From.SendSound( 0x2D6 );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}