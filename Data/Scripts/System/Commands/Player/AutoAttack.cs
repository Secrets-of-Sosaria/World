using System;
using Server;
using System.Collections.Generic;
using Server.Commands;
using Server.Mobiles;

namespace Server.Items
{
    class AutoAttack
    {
        public static void Initialize()
        {
			CommandSystem.Register("autoattack", AccessLevel.Player, new CommandEventHandler(OnToggleAutoAttack));
        }

        [Usage("autoattack")]
        [Description("Enables or disables auto attacking when attacked.")]
        private static void OnToggleAutoAttack(CommandEventArgs e)
        {
            Mobile m = e.Mobile;

			if ( m.NoAutoAttack == false )
			{
				m.SendMessage(38, "You have disabled auto attacking.");
				m.NoAutoAttack = true;
			}
			else
			{
				m.SendMessage(68, "You have enabled auto attacking.");
				m.NoAutoAttack = false;
			}
        }
    }
}
