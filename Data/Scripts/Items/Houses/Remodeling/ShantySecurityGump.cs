using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Gumps
{
    public class ShantySecurityGump : Gump
    {
        BaseDoor m_Door;
        Mobile m_From;
        public ShantySecurityGump(Mobile from, BaseDoor door): base(50, 50)
        {
			string color = "#7ebfe1";
            m_Door = door;
            m_From = from;
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);

			AddImage(0, 0, 164, 2932);
			AddImage(2, 2, 165);
			AddHtml( 9, 8, 132, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>SET ACCESS</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

			int notlock = 3609;
			int yeslock = 3609;
				if ( !(m_Door.Locked) ){ notlock = 4017; } else { yeslock = 4017; }

			AddButton(15, 55, yeslock, yeslock, 1, GumpButtonType.Reply, 0);
			AddHtml( 55, 55, 90, 20, @"<BODY><BASEFONT Color=" + color + ">Locked</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(15, 100, notlock, notlock, 2, GumpButtonType.Reply, 0);
			AddHtml( 55, 100, 90, 20, @"<BODY><BASEFONT Color=" + color + ">Unlocked</BASEFONT></BODY>", (bool)false, (bool)false);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
			m_From.SendSound( 0x4A ); 
            switch (info.ButtonID)
            {
                case 1:
                    {
                        m_Door.Locked = true;
                        m_From.SendMessage("You lock it");
                        break;
                    }
                case 2:
                    {
                        m_Door.Locked = false;
                        m_From.SendMessage("You unlock it");
                        break;
                    }
            }
        }
    }
}
