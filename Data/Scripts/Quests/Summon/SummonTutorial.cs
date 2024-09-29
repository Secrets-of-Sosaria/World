using System;
using Server;
using Server.Misc;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;
using System.Text;
using Server.Mobiles;
using System.Collections;
using Server.Commands.Generic;

namespace Server.Gumps
{
	public class SummonTutorial : Gump
	{
        public SummonTutorial( Mobile from, SummonPrison item ) : base( 50, 50 )
        {
			string color = "#90c5d0";
			string regs = "#b8d090";
			from.SendSound( 0x5C9 ); 

			string sEnding = "If one were to touch more than one such magical prisons, All but one would vanish into the void.";
				if ( item.owner != null ){ sEnding = "If " + item.owner.Name + " happens to touch another such magical prison, this sealed prison would vanish into the void."; }
			string sPrisoner = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.Prisoner.ToLower());

			string sText = "You have found a rare orb that contains the spirit of " + sPrisoner + ". Magically sealed here by " + item.Jailor + ", you have no clue as to how long they have been locked away. In order to free " + sPrisoner + " from this magical prison, you will need to find some special items. Once the items have been found, this crystal prison will need to be brought to " + item.Dungeon + " where which they were ensorcelled into the orb. If they are freed, they will surely seek to unleash wrath on all who stand before them, but what they held before their imprisonment may be worth the risk.<br><br><br><br>Below you can see what items you need to unlock the cell. When you have obtained all of the needed items, venture to the place of imprisonment and use the orb there. Be ready for battle in such a case, as you may not know what you truly face. They have been locked away for years, or maybe centuries, so madness has surely claimed them by now. Once they are freed, they will remain for one hour before they leave the area and go off elsewhere, forever. Be quick with the coming attack if this fight is truly the desired course you wish to take. " + sEnding;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 5595, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddButton(767, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 12, 12, 667, 20, @"<BODY><BASEFONT Color=" + color + ">PRISONS OF WIZARDRY</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 45, 783, 353, @"<BODY><BASEFONT Color=" + color + ">" + sText + "</BASEFONT></BODY>", (bool)false, (bool)false);

			sText = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.Prisoner.ToLower());

			sText = sText + "<br><br>To free them, you need:";

			sText = sText + "<br><br>" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.KeyA.ToLower());
			sText = sText + "<br>" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.KeyB.ToLower());
			sText = sText + "<br>" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.KeyC.ToLower());

			sText = sText + "<br>" + item.ReagentQtyA.ToString() + " " + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.ReagentNameA.ToLower());
			sText = sText + "<br>" + item.ReagentQtyB.ToString() + " " + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(item.ReagentNameB.ToLower());

			sText = sText + "<br><br>Then bring it to " + item.Dungeon;

			AddHtml( 12, 368, 783, 266, @"<BODY><BASEFONT Color=" + regs + ">" + sText + "</BASEFONT></BODY>", (bool)false, (bool)false);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
			Mobile from = state.Mobile;
			from.SendSound( 0x5C9 ); 
        }
    }
}