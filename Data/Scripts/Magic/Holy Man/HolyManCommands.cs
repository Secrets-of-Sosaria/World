using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.HolyMan;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class HolyManCommands
	{
		public static void Initialize()
		{
            Properties.Initialize();

			Register( "HMBanish", AccessLevel.Player, new CommandEventHandler( HMBanish_OnCommand ) );
			Register( "HMDampenSpirit", AccessLevel.Player, new CommandEventHandler( HMDampenSpirit_OnCommand ) );
			Register( "HMEnchant", AccessLevel.Player, new CommandEventHandler( HMEnchant_OnCommand ) );
			Register( "HMHammerFaith", AccessLevel.Player, new CommandEventHandler( HMHammerFaith_OnCommand ) );
			Register( "HMHeavenlyLight", AccessLevel.Player, new CommandEventHandler( HMHeavenlyLight_OnCommand ) );
			Register( "HMNourish", AccessLevel.Player, new CommandEventHandler( HMNourish_OnCommand ) );
			Register( "HMPurge", AccessLevel.Player, new CommandEventHandler( HMPurge_OnCommand ) );
			Register( "HMRebirth", AccessLevel.Player, new CommandEventHandler( HMRebirth_OnCommand ) );
			Register( "HMSacredBoon", AccessLevel.Player, new CommandEventHandler( HMSacredBoon_OnCommand ) );
			Register( "HMSanctify", AccessLevel.Player, new CommandEventHandler( HMSanctify_OnCommand ) );
			Register( "HMSeance", AccessLevel.Player, new CommandEventHandler( HMSeance_OnCommand ) );
			Register( "HMSmite", AccessLevel.Player, new CommandEventHandler( HMSmite_OnCommand ) );
			Register( "HMTouchLife", AccessLevel.Player, new CommandEventHandler( HMTouchLife_OnCommand ) );
			Register( "HMTrialFire", AccessLevel.Player, new CommandEventHandler( HMTrialFire_OnCommand ) );
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

		[Usage( "HMBanish" )]
		[Description( "Casts Banish" )]
		public static void HMBanish_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 770 ) ){ new BanishEvilSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMDampenSpirit" )]
		[Description( "Casts Dampen Spirit" )]
		public static void HMDampenSpirit_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 771 ) ){ new DampenSpiritSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMEnchant" )]
		[Description( "Casts Enchant" )]
		public static void HMEnchant_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 772 ) ){ new EnchantSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMHammerFaith" )]
		[Description( "Casts Hammer of Faith" )]
		public static void HMHammerFaith_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 773 ) ){ new HammerOfFaithSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMHeavenlyLight" )]
		[Description( "Casts Heavenly Light" )]
		public static void HMHeavenlyLight_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 774 ) ){ new HeavenlyLightSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMNourish" )]
		[Description( "Casts Nourish" )]
		public static void HMNourish_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 775 ) ){ new NourishSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMPurge" )]
		[Description( "Casts Purge" )]
		public static void HMPurge_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 776 ) ){ new PurgeSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMRebirth" )]
		[Description( "Casts Rebirth" )]
		public static void HMRebirth_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 777 ) ){ new RebirthSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMSacredBoon" )]
		[Description( "Casts Sacred Boon" )]
		public static void HMSacredBoon_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 778 ) ){ new SacredBoonSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMSanctify" )]
		[Description( "Casts Sanctify" )]
		public static void HMSanctify_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 779 ) ){ new SanctifySpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMSeance" )]
		[Description( "Casts Seance" )]
		public static void HMSeance_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 780 ) ){ new SeanceSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMSmite" )]
		[Description( "Casts Smite" )]
		public static void HMSmite_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 781 ) ){ new SmiteSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMTouchLife" )]
		[Description( "Casts Touch of Life" )]
		public static void HMTouchLife_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 782 ) ){ new TouchOfLifeSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "HMTrialFire" )]
		[Description( "Casts Trial by Fire" )]
		public static void HMTrialFire_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 783 ) ){ new TrialByFireSpell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}
	}
}
