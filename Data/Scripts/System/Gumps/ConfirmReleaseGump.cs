using System;
using Server;
using Server.Mobiles;

namespace Server.Gumps
{
	public class ConfirmReleaseGump : Gump
	{
		private Mobile m_From;
		private BaseCreature m_Pet;

		public ConfirmReleaseGump( Mobile from, BaseCreature pet ) : base( 50, 50 )
		{
			from.SendSound( 0x4A ); 
			string color = "#d3aeae";

			m_From = from;
			m_Pet = pet;

			m_From.CloseGump( typeof( ConfirmReleaseGump ) );

			AddPage(0);

			AddImage(0, 0, 7003, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddButton(268, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 10, 10, 200, 20, @"<BODY><BASEFONT Color=" + color + ">FAREWELL</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 40, 285, 162, @"<BODY><BASEFONT Color=" + color + ">Are you sure you want to release them?</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(10, 215, 4023, 4023, 2, GumpButtonType.Reply, 0);
			AddButton(267, 215, 4020, 4020, 1, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			m_From.SendSound( 0x4A ); 
			if ( info.ButtonID == 2 )
			{
				if ( !m_Pet.Deleted && m_Pet.Controlled && m_From == m_Pet.ControlMaster && m_From.CheckAlive() /*&& m_Pet.CheckControlChance( m_From )*/ )
				{
					if ( m_Pet.Map == m_From.Map && m_Pet.InRange( m_From, 14 ) )
					{
						m_Pet.ControlTarget = null;
						m_Pet.ControlOrder = OrderType.Release;
					}
				}
			}
		}
	}
}