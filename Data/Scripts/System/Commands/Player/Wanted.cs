using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class Wanted : Gump
    {
        public Wanted( Mobile from ) : base( 100, 100 )
        {
			string color = "#7ab582";
			bool scrollBar = false;
				if ( Server.Misc.GetPlayerInfo.IsWanted( from ) )
				{
					color = "#d38a8a";
					scrollBar = true;
				}

			from.SendSound( 0x59 );
			int hue = Server.Misc.PlayerSettings.GetGumpHue( from );

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7043, hue);

			if ( hue > 0 )
			{
				AddHtml( 9, 9, 104, 20, @"<BODY><BASEFONT Color=" + color + ">WANTED</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(224, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
			}
			else
			{
				AddButton(224, 277, 4017, 4017, 0, GumpButtonType.Reply, 0);
			}

			AddHtml( 12, 49, 239, 217, @"<BODY><BASEFONT Color=" + color + ">" + Server.Misc.GetPlayerInfo.GetWantedStatus( from ) + "</BASEFONT></BODY>", (bool)false, (bool)scrollBar);
        }

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			from.SendSound( 0x59 );
		}
    }
}