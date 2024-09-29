using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Multis
{
	public class ConfirmDryDockGump : Gump
	{
		private Mobile m_From;
		private BaseBoat m_Boat;
		private int m_Hue;

		public ConfirmDryDockGump( Mobile from, BaseBoat boat, int hue ) : base( 50, 50 )
		{
			from.SendSound( 0x4A ); 
			string color = "#dbc082";
			int img = 7002;
			string msg = "Do you want to dry dock your ship now?";
			string title = "SAFE HARBOR";

			m_From = from;
			m_Boat = boat;
			m_Hue = hue;

			if ( BaseBoat.isCarpet( m_Boat ) )
			{
				msg = "Do you want to roll up your carpet now?";
				title = "ROLL IT UP";
				color = "#d2a098";
				img = 7004;
			}

			m_From.CloseGump( typeof( ConfirmDryDockGump ) );

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, img, Server.Misc.PlayerSettings.GetGumpHue( from ));

			AddButton(268, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 10, 10, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 11, 40, 285, 183, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(11, 231, 4023, 4023, 2, GumpButtonType.Reply, 0);
			AddButton(267, 232, 4020, 4020, 0, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			m_From.SendSound( 0x4A ); 
			if ( info.ButtonID == 2 )
				m_Boat.EndDryDock( m_From, m_Hue );
		}
	}
}