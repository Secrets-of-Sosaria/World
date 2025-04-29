using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class OrganizePotions
    {
        public static void Initialize()
        {
            CommandSystem.Register( "OrganizePotions", AccessLevel.Player, new CommandEventHandler( OrganizePotions_OnCommand ) );
        }

        public static void OrganizePotions_OnCommand( CommandEventArgs e )
        {
            Mobile m = e.Mobile;
            Item pouch = m.Backpack.FindItemByType( typeof( AlchemistPouch ) );

            if ( pouch != null )
            {
                AlchemistPouch ap = pouch as AlchemistPouch;
                ap.OrganizePotions( m );
            }
            else
            {
                m.SendMessage( "You need an alchemist's belt pouch in your backpack to organize your potions!" );
            }
        }
    }
}