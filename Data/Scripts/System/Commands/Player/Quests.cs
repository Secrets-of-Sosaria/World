using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class QuestsGump : Gump
    {
        public QuestsGump( Mobile from ) : base( 50, 50 )
        {
			from.SendSound( 0x4A ); 
			string color = "#b0cfb8";

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 9585, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddButton(668, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 13, 13, 637, 20, @"<BODY><BASEFONT Color=" + color + ">QUESTS & DISCOVERIES</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 16, 48, 675, 488, @"<BODY><BASEFONT Color=" + color + ">" + Server.Engines.Help.HelpGump.MyQuests( from ) + "</BASEFONT></BODY>", (bool)false, (bool)true);
        }

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;
			from.SendSound( 0x4A ); 
		}
    }
}