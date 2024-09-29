using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Gumps
{
	public enum ResurrectMessage
	{
		ChaosShrine = 0,
		VirtueShrine = 1,
		Healer = 2,
		Generic = 3,
	}

	public class ResurrectGump : Gump
	{
		private Mobile m_Healer;
		private int m_Price;
		private bool m_FromSacrifice;
		private double m_HitsScalar;
		private int m_Bank;
		private int m_Tithe;

		public ResurrectGump( Mobile owner ): this( owner, owner, ResurrectMessage.Generic, false )
		{
		}

		public ResurrectGump( Mobile owner, double hitsScalar ): this( owner, owner, ResurrectMessage.Generic, false, hitsScalar )
		{
		}

		public ResurrectGump( Mobile owner, bool fromSacrifice ): this( owner, owner, ResurrectMessage.Generic, fromSacrifice )
		{
		}

		public ResurrectGump( Mobile owner, Mobile healer ): this( owner, healer, ResurrectMessage.Generic, false )
		{
		}

		public ResurrectGump( Mobile owner, ResurrectMessage msg ): this( owner, owner, msg, false )
		{
		}

		public ResurrectGump( Mobile owner, Mobile healer, ResurrectMessage msg ): this( owner, healer, msg, false )
		{
		}

		public ResurrectGump( Mobile owner, Mobile healer, ResurrectMessage msg, bool fromSacrifice ): this( owner, healer, msg, fromSacrifice, 0.0 )
		{
		}

		public ResurrectGump( Mobile owner, Mobile healer, ResurrectMessage msg, bool fromSacrifice, double hitsScalar ): base( 50, 50 )
		{
			owner.SendSound( 0x0F8 ); 
			string color = "#b7cbda";

			m_Healer = healer;
			m_FromSacrifice = fromSacrifice;
			m_HitsScalar = hitsScalar;
			m_Bank = Banker.GetBalance( owner );
			m_Tithe = owner.TithingPoints;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			int img = 9586;
				if ( owner.Karma < 0 ){ img = 9587; }

			AddImage(0, 0, img, Server.Misc.PlayerSettings.GetGumpHue( owner ));
			AddHtml( 10, 11, 349, 20, @"<BODY><BASEFONT Color=" + color + ">RESURRECTION</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(368, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 11, 41, 385, 141, @"<BODY><BASEFONT Color=" + color + ">It is possible for you to be resurrected here by this healer. Do you want to return to the land of the living? If not, you can remain in the spirit realm.</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(10, 225, 4023, 4023, 1, GumpButtonType.Reply, 0);
			AddButton(367, 225, 4020, 4020, 0, GumpButtonType.Reply, 0);
		}

		public ResurrectGump( Mobile owner, Mobile healer, int price ): base( 25, 25 )
		{
			m_Healer = healer;
			m_Price = price;
			m_Bank = Banker.GetBalance( owner );
			m_Tithe = owner.TithingPoints;

			Closable = false;

			AddPage( 0 );

			AddImage( 0, 0, 3600 );

			AddImageTiled( 0, 14, 15, 200, 3603 );
			AddImageTiled( 380, 14, 14, 200, 3605 );

			AddImage( 0, 201, 3606 );

			AddImageTiled( 15, 201, 370, 16, 3607 );
			AddImageTiled( 15, 0, 370, 16, 3601 );

			AddImage( 380, 0, 3602 );

			AddImage( 380, 201, 3608 );

			AddImageTiled( 15, 15, 365, 190, 2624 );

			AddRadio( 30, 140, 9727, 9730, true, 1 );
			AddHtmlLocalized( 65, 145, 300, 25, 1060015, 0x7FFF, false, false ); // Grudgingly pay the money

			AddRadio( 30, 175, 9727, 9730, false, 0 );
			AddHtmlLocalized( 65, 178, 300, 25, 1060016, 0x7FFF, false, false ); // I'd rather stay dead, you scoundrel!!!

			AddHtmlLocalized( 30, 20, 360, 35, 1060017, 0x7FFF, false, false ); // Wishing to rejoin the living, are you?  I can restore your body... for a price of course...

			AddHtmlLocalized( 30, 105, 345, 40, 1060018, 0x5B2D, false, false ); // Do you accept the fee, which will be withdrawn from your bank?

			AddImage( 65, 72, 5605 );

			AddImageTiled( 80, 90, 200, 1, 9107 );
			AddImageTiled( 95, 92, 200, 1, 9157 );

			AddLabel( 90, 70, 1645, price.ToString() );
			AddHtmlLocalized( 140, 70, 100, 25, 1023823, 0x7FFF, false, false ); // gold coins

			AddButton( 290, 175, 247, 248, 2, GumpButtonType.Reply, 0 );

			AddImageTiled( 15, 14, 365, 1, 9107 );
			AddImageTiled( 380, 14, 1, 190, 9105 );
			AddImageTiled( 15, 205, 365, 1, 9107 );
			AddImageTiled( 15, 14, 1, 190, 9105 );
			AddImageTiled( 0, 0, 395, 1, 9157 );
			AddImageTiled( 394, 0, 1, 217, 9155 );
			AddImageTiled( 0, 216, 395, 1, 9157 );
			AddImageTiled( 0, 0, 1, 217, 9155 );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

			from.CloseGump( typeof( ResurrectGump ) );

			if( info.ButtonID == 1 || info.ButtonID == 2 )
			{
				if( from.Map == null || !from.Map.CanFit( from.Location, 16, false, false ) )
				{
					from.SendLocalizedMessage( 502391 ); // Thou can not be resurrected there!
					return;
				}

				if( m_Price > 0 )
				{
					if( info.IsSwitched( 1 ) )
					{
						if ( m_Bank >= m_Price )
						{
							Banker.Withdraw( from, m_Price );
							from.SendLocalizedMessage( 1060398, m_Price.ToString() ); // ~1_AMOUNT~ gold has been withdrawn from your bank box.
							from.SendLocalizedMessage( 1060022, Banker.GetBalance( from ).ToString() ); // You have ~1_AMOUNT~ gold in cash remaining in your bank box.
							Server.Misc.Death.Penalty( from, false );
						}
						else if ( m_Tithe >= m_Price )
						{
							from.TithingPoints = from.TithingPoints - m_Price;
							from.SendMessage( "" + m_Price.ToString() + " tithing has been offered to the gods." );
							from.SendMessage( "" + (from.TithingPoints).ToString() + " tithing remains." );
							Server.Misc.Death.Penalty( from, false );
							Server.Misc.Death.Penalty( from, false );
						}
						else
						{
							from.SendMessage( "You do not have enough gold or tithing tribute to be resurrected by a healer." );
							return;
						}
					}
					else
					{
						from.SendLocalizedMessage( 1060019 ); // You decide against paying the healer, and thus remain dead.
						return;
					}
				}

				from.PlaySound( 0x214 );
				from.FixedEffect( 0x376A, 10, 16 );

				from.Resurrect();
			}
		}
	}
}