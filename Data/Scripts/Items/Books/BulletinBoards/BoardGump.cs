using System;
using Server;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Commands;
using Server.Commands.Generic;
using Server.Prompts;
using Server.Gumps;

namespace Server.Gumps 
{
	public class BoardGump : Gump
	{
		public BoardGump( Mobile from, string title, string txt, string color, bool bars ): base( 100, 100 )
		{
			from.SendSound( 0x59 );

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 9541, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddHtml( 11, 12, 562, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 44, 623, 378, @"<BODY><BASEFONT Color=" + color + ">" + txt + "</BASEFONT></BODY>", (bool)false, (bool)bars);
			AddButton(609, 8, 4017, 4017, 0, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile;
			from.SendSound( 0x59 );
		}
	}
}