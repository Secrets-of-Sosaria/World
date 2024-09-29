using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Elementalism;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class ElementalCommands
	{
		public static void Initialize()
		{
            Properties.Initialize();
			Register( "EArmor", AccessLevel.Player, new CommandEventHandler( EArmor_OnCommand ) );
			Register( "EBolt", AccessLevel.Player, new CommandEventHandler( EBolt_OnCommand ) );
			Register( "EMend", AccessLevel.Player, new CommandEventHandler( EMend_OnCommand ) );
			Register( "ESanctuary", AccessLevel.Player, new CommandEventHandler( ESanctuary_OnCommand ) );
			Register( "EPain", AccessLevel.Player, new CommandEventHandler( EPain_OnCommand ) );
			Register( "EProtection", AccessLevel.Player, new CommandEventHandler( EProtection_OnCommand ) );
			Register( "EPurge", AccessLevel.Player, new CommandEventHandler( EPurge_OnCommand ) );
			Register( "ESteed", AccessLevel.Player, new CommandEventHandler( ESteed_OnCommand ) );
			Register( "ECall", AccessLevel.Player, new CommandEventHandler( ECall_OnCommand ) );
			Register( "EForce", AccessLevel.Player, new CommandEventHandler( EForce_OnCommand ) );
			Register( "EWall", AccessLevel.Player, new CommandEventHandler( EWall_OnCommand ) );
			Register( "EWarp", AccessLevel.Player, new CommandEventHandler( EWarp_OnCommand ) );
			Register( "EField", AccessLevel.Player, new CommandEventHandler( EField_OnCommand ) );
			Register( "ERestoration", AccessLevel.Player, new CommandEventHandler( ERestoration_OnCommand ) );
			Register( "EStrike", AccessLevel.Player, new CommandEventHandler( EStrike_OnCommand ) );
			Register( "EVoid", AccessLevel.Player, new CommandEventHandler( EVoid_OnCommand ) );
			Register( "EBlast", AccessLevel.Player, new CommandEventHandler( EBlast_OnCommand ) );
			Register( "EEcho", AccessLevel.Player, new CommandEventHandler( EEcho_OnCommand ) );
			Register( "EFiend", AccessLevel.Player, new CommandEventHandler( EFiend_OnCommand ) );
			Register( "EHold", AccessLevel.Player, new CommandEventHandler( EHold_OnCommand ) );
			Register( "EBarrage", AccessLevel.Player, new CommandEventHandler( EBarrage_OnCommand ) );
			Register( "ERune", AccessLevel.Player, new CommandEventHandler( ERune_OnCommand ) );
			Register( "EStorm", AccessLevel.Player, new CommandEventHandler( EStorm_OnCommand ) );
			Register( "ESummon", AccessLevel.Player, new CommandEventHandler( ESummon_OnCommand ) );
			Register( "EDevastation", AccessLevel.Player, new CommandEventHandler( EDevastation_OnCommand ) );
			Register( "EFall", AccessLevel.Player, new CommandEventHandler( EFall_OnCommand ) );
			Register( "EGate", AccessLevel.Player, new CommandEventHandler( EGate_OnCommand ) );
			Register( "EHavoc", AccessLevel.Player, new CommandEventHandler( EHavoc_OnCommand ) );
			Register( "EApocalypse", AccessLevel.Player, new CommandEventHandler( EApocalypse_OnCommand ) );
			Register( "ELord", AccessLevel.Player, new CommandEventHandler( ELord_OnCommand ) );
			Register( "ESoul", AccessLevel.Player, new CommandEventHandler( ESoul_OnCommand ) );
			Register( "ESpirit", AccessLevel.Player, new CommandEventHandler( ESpirit_OnCommand ) );
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

		[Usage( "EArmor" )]
		[Description( "Casts Elemental Armor" )]
		public static void EArmor_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 300 ) ){ new Elemental_Armor_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EBolt" )]
		[Description( "Casts Elemental Bolt" )]
		public static void EBolt_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 301 ) ){ new Elemental_Bolt_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EMend" )]
		[Description( "Casts Elemental Mend" )]
		public static void EMend_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 302 ) ){ new Elemental_Mend_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ESanctuary" )]
		[Description( "Casts Elemental Sanctuary" )]
		public static void ESanctuary_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 303 ) ){ new Elemental_Sanctuary_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EPain" )]
		[Description( "Casts Elemental Pain" )]
		public static void EPain_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 304 ) ){ new Elemental_Pain_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EProtection" )]
		[Description( "Casts Elemental Protection" )]
		public static void EProtection_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 305 ) ){ new Elemental_Protection_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EPurge" )]
		[Description( "Casts Elemental Purge" )]
		public static void EPurge_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 306 ) ){ new Elemental_Purge_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ESteed" )]
		[Description( "Casts Elemental Steed" )]
		public static void ESteed_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 307 ) ){ new Elemental_Steed_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ECall" )]
		[Description( "Casts Elemental Call" )]
		public static void ECall_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 308 ) ){ new Elemental_Call_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EForce" )]
		[Description( "Casts Elemental Force" )]
		public static void EForce_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 309 ) ){ new Elemental_Force_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EWall" )]
		[Description( "Casts Elemental Wall" )]
		public static void EWall_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 310 ) ){ new Elemental_Wall_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EWarp" )]
		[Description( "Casts Elemental Warp" )]
		public static void EWarp_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 311 ) ){ new Elemental_Warp_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EField" )]
		[Description( "Casts Elemental Field" )]
		public static void EField_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 312 ) ){ new Elemental_Field_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ERestoration" )]
		[Description( "Casts Elemental Restoration" )]
		public static void ERestoration_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 313 ) ){ new Elemental_Restoration_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EStrike" )]
		[Description( "Casts Elemental Strike" )]
		public static void EStrike_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 314 ) ){ new Elemental_Strike_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EVoid" )]
		[Description( "Casts Elemental Void" )]
		public static void EVoid_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 315 ) ){ new Elemental_Void_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EBlast" )]
		[Description( "Casts Elemental Blast" )]
		public static void EBlast_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 316 ) ){ new Elemental_Blast_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EEcho" )]
		[Description( "Casts Elemental Echo" )]
		public static void EEcho_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 317 ) ){ new Elemental_Echo_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EFiend" )]
		[Description( "Casts Elemental Fiend" )]
		public static void EFiend_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 318 ) ){ new Elemental_Fiend_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EHold" )]
		[Description( "Casts Elemental Hold" )]
		public static void EHold_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 319 ) ){ new Elemental_Hold_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EBarrage" )]
		[Description( "Casts Elemental Barrage" )]
		public static void EBarrage_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 320 ) ){ new Elemental_Barrage_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ERune" )]
		[Description( "Casts Elemental Rune" )]
		public static void ERune_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 321 ) ){ new Elemental_Rune_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EStorm" )]
		[Description( "Casts Elemental Storm" )]
		public static void EStorm_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 322 ) ){ new Elemental_Storm_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ESummon" )]
		[Description( "Casts Elemental Summon" )]
		public static void ESummon_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 323 ) ){ new Elemental_Summon_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EDevastation" )]
		[Description( "Casts Elemental Devastation" )]
		public static void EDevastation_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 324 ) ){ new Elemental_Devastation_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EFall" )]
		[Description( "Casts Elemental Fall" )]
		public static void EFall_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 325 ) ){ new Elemental_Fall_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EGate" )]
		[Description( "Casts Elemental Gate" )]
		public static void EGate_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 326 ) ){ new Elemental_Gate_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EHavoc" )]
		[Description( "Casts Elemental Havoc" )]
		public static void EHavoc_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 327 ) ){ new Elemental_Havoc_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "EApocalypse" )]
		[Description( "Casts Elemental Apocalypse" )]
		public static void EApocalypse_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 328 ) ){ new Elemental_Apocalypse_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ELord" )]
		[Description( "Casts Elemental Lord" )]
		public static void ELord_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 329 ) ){ new Elemental_Lord_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ESoul" )]
		[Description( "Casts Elemental Soul" )]
		public static void ESoul_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 330 ) ){ new Elemental_Soul_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}

		[Usage( "ESpirit" )]
		[Description( "Casts Elemental Spirit" )]
		public static void ESpirit_OnCommand( CommandEventArgs e )
		{
		Mobile from = e.Mobile;
		if ( !Multis.DesignContext.Check( e.Mobile ) ){ return; }
		if ( HasSpell( from, 331 ) ){ new Elemental_Spirit_Spell( e.Mobile, null ).Cast(); } else { from.SendLocalizedMessage( 500015 ); }
		}
	}
}
