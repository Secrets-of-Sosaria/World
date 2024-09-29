using System;
using Server;
using Server.Misc;
using Server.Gumps;
using Server.Network;

namespace Server.Gumps 
{
    public class PrisonGump : Gump
    {
        public PrisonGump ( Mobile from ) : base ( 50, 50 )
        {
			from.SendSound( 0x4A ); 
			string color = "#e98650";

			this.Closable=true;
			this.Disposable=false;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7021, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddHtml( 13, 13, 415, 20, @"<BODY><BASEFONT Color=" + color + ">SENT TO PRISON</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(466, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 16, 46, 475, 246, @"<BODY><BASEFONT Color=" + color + ">For your deeds you have been sent to prison! Although the guards intended for you to rot forever in your cell, they have been careless. Not only did they forget to lock your cell, but they left you alone for a brief time. You decided to use this opportunity to make your escape, but the doorway out is locked. You gather your belongings from the chest the guards put them in, only to discover they confiscated some of your things. You will surely never see them again. You have heard rumors of others escaping this prison through a tunnel they dug out of one of the cells. Perhaps you can do the same.</BASEFONT></BODY>", (bool)false, (bool)false);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
			Mobile from = state.Mobile;
			from.SendSound( 0x4A ); 
        }
    }
}