using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.DeathKnight;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class DeathKnightCommands
	{
		public static void Initialize()
		{
            Properties.Initialize();

			Register( "DKBanish", AccessLevel.Player, new CommandEventHandler( DKBanish_OnCommand ) );
			Register( "DKDemonicTouch", AccessLevel.Player, new CommandEventHandler( DKDemonicTouch_OnCommand ) );
			Register( "DKDevilPact", AccessLevel.Player, new CommandEventHandler( DKDevilPact_OnCommand ) );
			Register( "DKGrimReaper", AccessLevel.Player, new CommandEventHandler( DKGrimReaper_OnCommand ) );
			Register( "DKHagHand", AccessLevel.Player, new CommandEventHandler( DKHagHand_OnCommand ) );
			Register( "DKHellfire", AccessLevel.Player, new CommandEventHandler( DKHellfire_OnCommand ) );
			Register( "DKLucifersBolt", AccessLevel.Player, new CommandEventHandler( DKLucifersBolt_OnCommand ) );
			Register( "DKOrbOrcus", AccessLevel.Player, new CommandEventHandler( DKOrbOrcus_OnCommand ) );
			Register( "DKShieldHate", AccessLevel.Player, new CommandEventHandler( DKShieldHate_OnCommand ) );
			Register( "DKSoulReaper", AccessLevel.Player, new CommandEventHandler( DKSoulReaper_OnCommand ) );
			Register( "DKStrengthSteel", AccessLevel.Player, new CommandEventHandler( DKStrengthSteel_OnCommand ) );
			Register( "DKStrike", AccessLevel.Player, new CommandEventHandler( DKStrike_OnCommand ) );
			Register( "DKSuccubusSkin", AccessLevel.Player, new CommandEventHandler( DKSuccubusSkin_OnCommand ) );
			Register( "DKWrath", AccessLevel.Player, new CommandEventHandler( DKWrath_OnCommand ) );
		}

	    public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}

		public static bool HasSpell( Mobile from, int spellID )
		{
			Spellbook book = Spellbook.Find( from, spellID );

			return ( book != null && book.HasSpell( spellID ) );
		}

		[Usage( "DKBanish" )]
		[Description( "Casts Banish" )]
		public static void DKBanish_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 750 ) ){ new BanishSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKDemonicTouch" )]
		[Description( "Casts Demonic Touch" )]
		public static void DKDemonicTouch_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 751 ) ){ new DemonicTouchSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKDevilPact" )]
		[Description( "Casts Devil Pact" )]
		public static void DKDevilPact_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 752 ) ){ new DevilPactSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKGrimReaper" )]
		[Description( "Casts Grim Reaper" )]
		public static void DKGrimReaper_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 753 ) ){ new GrimReaperSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKHagHand" )]
		[Description( "Casts Hag Hand" )]
		public static void DKHagHand_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 754 ) ){ new HagHandSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKHellfire" )]
		[Description( "Casts Hellfire" )]
		public static void DKHellfire_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 755 ) ){ new HellfireSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKLucifersBolt" )]
		[Description( "Casts Lucifers Bolt" )]
		public static void DKLucifersBolt_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 756 ) ){ new LucifersBoltSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKOrbOrcus" )]
		[Description( "Casts Orb of Orcus" )]
		public static void DKOrbOrcus_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 757 ) ){ new OrbOfOrcusSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKShieldHate" )]
		[Description( "Casts Shield of Hate" )]
		public static void DKShieldHate_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 758 ) ){ new ShieldOfHateSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKSoulReaper" )]
		[Description( "Casts Soul Reaper" )]
		public static void DKSoulReaper_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 759 ) ){ new SoulReaperSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKStrengthSteel" )]
		[Description( "Casts Strength of Steel" )]
		public static void DKStrengthSteel_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 760 ) ){ new StrengthOfSteelSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKStrike" )]
		[Description( "Casts Strike" )]
		public static void DKStrike_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 761 ) ){ new StrikeSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKSuccubusSkin" )]
		[Description( "Casts Succubus Skin" )]
		public static void DKSuccubusSkin_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 762 ) ){ new SuccubusSkinSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "DKWrath" )]
		[Description( "Casts Wrath" )]
		public static void DKWrath_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 763 ) ){ new WrathSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}
	}
}
