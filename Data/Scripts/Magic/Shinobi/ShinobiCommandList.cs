using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Shinobi;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class CastShinobiSpells
	{
		public static void Initialize()
		{
            Properties.Initialize();

			Register( "CheetahPaws", AccessLevel.Player, new CommandEventHandler( CheetahPaws_OnCommand ) );

			Register( "Deception", AccessLevel.Player, new CommandEventHandler( Deception_OnCommand ) );

			Register( "EagleEye", AccessLevel.Player, new CommandEventHandler( EagleEye_OnCommand ) );

			Register( "Espionage", AccessLevel.Player, new CommandEventHandler( Espionage_OnCommand ) );

			Register( "FerretFlee", AccessLevel.Player, new CommandEventHandler( FerretFlee_OnCommand ) );

			Register( "MonkeyLeap", AccessLevel.Player, new CommandEventHandler( MonkeyLeap_OnCommand ) );

			Register( "MysticShuriken", AccessLevel.Player, new CommandEventHandler( MysticShuriken_OnCommand ) );

			Register( "TigerStrength", AccessLevel.Player, new CommandEventHandler( TigerStrength_OnCommand ) );
		}

	    public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}

		[Usage( "CheetahPaws" )]
		[Description( "Casts Cheetah Paw" )]
		public static void CheetahPaws_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 290 ) )
			{
				new CheetahPaws( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
        }

		[Usage( "Deception" )]
		[Description( "Casts Deception" )]
		public static void Deception_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 291 ) )
			{
				new Deception( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "EagleEye" )]
		[Description( "Casts Eagle Eye" )]
		public static void EagleEye_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 292 ) )
			{
				new EagleEye( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "Espionage" )]
		[Description( "Casts Espionage" )]
		public static void Espionage_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 293 ) )
			{
				new Espionage( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "FerretFlee" )]
		[Description( "Casts Ferret Flee" )]
		public static void FerretFlee_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 294 ) )
			{
				new FerretFlee( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "MonkeyLeap" )]
		[Description( "Casts Monkey Leap" )]
		public static void MonkeyLeap_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 295 ) )
			{
				new MonkeyLeap( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "MysticShuriken" )]
		[Description( "Casts Mystic Shuriken" )]
		public static void MysticShuriken_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 296 ) )
			{
				new MysticShuriken( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}

		[Usage( "TigerStrength" )]
		[Description( "Casts Tiger Strength" )]
		public static void TigerStrength_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing

			if ( Server.Items.ShinobiScroll.GetShinobi( from, 297 ) )
			{
				new TigerStrength( e.Mobile, null ).Cast();
			}
			else
			{
				from.SendMessage( "You did not learn that ability." );
			}
		}
	}
}
