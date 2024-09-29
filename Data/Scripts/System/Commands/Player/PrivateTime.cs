using System;
using Server;
using System.Collections.Generic;
using Server.Commands;
using Server.Mobiles;

namespace Server.Items
{
    class PrivateTime
    {
        public static void Initialize()
        {
            CommandSystem.Register("private", AccessLevel.Player, new CommandEventHandler(OnTogglePrivateTime));
        }

        [Usage("private")]
        [Description("Enables or disables the privacy for the town crier.")]
        private static void OnTogglePrivateTime(CommandEventArgs e)
        {
            Mobile m = e.Mobile;
			PlayerMobile pm = (PlayerMobile)m;

            if ( pm.PublicInfo == false )
            {
				pm.PublicInfo = true;
                m.SendMessage(68, "You set your town crier news to public.");
            }
            else
            {
				pm.PublicInfo = false;
                m.SendMessage(38, "You set your town crier news to private.");
            }
        }
    }
}
