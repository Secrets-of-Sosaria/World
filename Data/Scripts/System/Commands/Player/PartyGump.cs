using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Engines.PartySystem;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Server.Mobiles;

namespace Server.Gumps
{
    public class PartyGump : Gump
    {
        private Mobile m_Target, m_Leader;

        public PartyGump(Mobile leader, Mobile target) : base(50, 50)
        {
			target.SendSound( 0x4A ); 
			string color = "#b0b7ce";

            m_Leader = leader;
            m_Target = target;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7000, Server.Misc.PlayerSettings.GetGumpHue( target ));

			AddButton(324, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 10, 10, 300, 20, @"<BODY><BASEFONT Color=" + color + ">JOIN A GROUP OF ADVENTURERS</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 40, 340, 130, @"<BODY><BASEFONT Color=" + color + ">" + m_Leader.Name + " is asking you to join their party! If you wish to accompany them, select the appropriate button. Otherwise, you can simply cancel the request and continue on your own journey.</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(9, 176, 4023, 4023, 1, GumpButtonType.Reply, 0);
			AddButton(324, 176, 4020, 4020, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
			m_Target.SendSound( 0x4A ); 

            if (m_Leader == null || m_Target == null)
                return;

            switch (info.ButtonID)
            {
                case 1:
				{
					PartyCommands.Handler.OnAccept(m_Target, m_Leader);
					break;
				}
                case 2:
				{
					PartyCommands.Handler.OnDecline(m_Target, m_Leader);
					break;
				}
            }
        }
    }
}