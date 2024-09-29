using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Accounting;
using Server.Mobiles;
using Server.Regions;
using Server.Commands;
using Server.Misc;

namespace Server.Gumps
{
	public class ClueGump : Gump
	{
		public ClueGump( Mobile from, string text, string title ) : base( 50, 50 )
		{
			from.SendSound( 0x4A ); 
			string color = "#b7765d";

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 9544, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddButton(368, 8, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 11, 12, 345, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 44, 382, 259, @"<BODY><BASEFONT Color=" + color + ">" + text + "</BASEFONT></BODY>", (bool)false, (bool)false);
		}

        public override void OnResponse(NetState state, RelayInfo info)
        {
			Mobile from = state.Mobile;
			from.SendSound( 0x4A ); 
        }
	}
}