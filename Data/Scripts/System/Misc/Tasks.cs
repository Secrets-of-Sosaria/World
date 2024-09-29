using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Spells;
using Server.Targeting;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System;

namespace Server.Items
{
	public class TaskManager150Min : Item
	{
		[Constructable]
		public TaskManager150Min () : base( 0x0EDE )
		{
			Movable = false;
			Name = "Task Manager 150 Min";
			Visible = false;
			TaskTimer thisTimer = new TaskTimer( this ); 
			thisTimer.Start(); 
		}

        public TaskManager150Min(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			if ( MySettings.S_RunRoutinesAtStartup && !( File.Exists( "Data/Data.ref" ) ) )
			{
				FirstTimer thisTimer = new FirstTimer( this ); 
				thisTimer.Start();
			}
			else
			{
				TaskTimer thisTimer = new TaskTimer( this ); 
				thisTimer.Start(); 
			}
		}

		public class TaskTimer : Timer 
		{ 
			private Item i_item; 
			public TaskTimer( Item task ) : base( TimeSpan.FromMinutes( 150.0 ) )
			{ 
				Priority = TimerPriority.OneMinute; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( false, i_item );
			} 
		}

		public class FirstTimer : Timer 
		{ 
			private Item i_item; 
			public FirstTimer( Item task ) : base( TimeSpan.FromSeconds( 5.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( true, i_item );
			} 
		}

		public static void RunThis( bool DoAction, Item item )
		{
			///// PLANT THE GARDENS //////////////////////////////////////
			Farms.PlantGardens();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(150) Regrow Gardens" ); }
			TaskTimer thisTimer = new TaskTimer( item ); 
			thisTimer.Start(); 
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(150 Minute) Tasks Complete!" ); }
		}
	}
}

namespace Server.Items
{
	public class TaskManager200Min : Item
	{
		[Constructable]
		public TaskManager200Min () : base( 0x0EDE )
		{
			Movable = false;
			Name = "Task Manager 200 Minutes";
			Visible = false;
			TaskTimer thisTimer = new TaskTimer( this ); 
			thisTimer.Start(); 
		}

        public TaskManager200Min(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			if ( MySettings.S_RunRoutinesAtStartup && !( File.Exists( "Data/Data.ref" ) ) )
			{
				FirstTimer thisTimer = new FirstTimer( this ); 
				thisTimer.Start();
			}
			else
			{
				TaskTimer thisTimer = new TaskTimer( this ); 
				thisTimer.Start(); 
			}
		}

		public class TaskTimer : Timer 
		{ 
			private Item i_item; 
			public TaskTimer( Item task ) : base( TimeSpan.FromMinutes( 200.0 ) )
			{ 
				Priority = TimerPriority.OneMinute; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( false, i_item );
			} 
		}

		public class FirstTimer : Timer 
		{ 
			private Item i_item; 
			public FirstTimer( Item task ) : base( TimeSpan.FromSeconds( 10.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( true, i_item );
			} 
		}

		public static void RunThis( bool DoAction, Item it )
		{
			TaskTimer thisTimer = new TaskTimer( it ); 
			thisTimer.Start(); 

			ArrayList spawns = new ArrayList();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(200) Rebuild Coffers, Stumps, and Hay..." ); }
			foreach ( Item item in World.Items.Values )
			{
				if ( item is PremiumSpawner )
				{
					PremiumSpawner spawner = (PremiumSpawner)item;

					if ( spawner.SpawnID == 8888 )
					{
						bool reconfigure = true;

						foreach ( NetState state in NetState.Instances )
						{
							Mobile m = state.Mobile;

							if ( m is PlayerMobile && m.InRange( spawner.Location, (spawner.HomeRange+20) ) )
							{
								reconfigure = false;
							}
						}

						if ( reconfigure ){ spawns.Add( item ); }
					}
				}
				else if ( item is Coffer )
				{
					Coffer coffer = (Coffer)item;
					Server.Items.Coffer.SetupCoffer( coffer );
				}
				else if ( item is HayCrate || item is HollowStump )
				{
					item.Stackable = false;
				}
			}

			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(200) Reconfigure Spawners..." ); }
			for ( int i = 0; i < spawns.Count; ++i )
			{
				PremiumSpawner spawners = ( PremiumSpawner )spawns[ i ];
				Server.Mobiles.PremiumSpawner.Reconfigure( spawners, DoAction );
			}
			if ( MySettings.ConsoleLog )
				Console.WriteLine( "(200 Minute) Tasks Complete!" );
			if ( MySettings.S_RunRoutinesAtStartup && DoAction && !( File.Exists( "Data/Data.ref" ) ) )
			{
				Console.WriteLine("You may now play " + MySettings.S_ServerName + "!");
				Console.WriteLine("");
			}
		}
	}
}

namespace Server.Items
{
	public class TaskManager250Min : Item
	{
		[Constructable]
		public TaskManager250Min () : base( 0x0EDE )
		{
			Movable = false;
			Name = "Task Manager 250 Minutes";
			Visible = false;
			TaskTimer thisTimer = new TaskTimer( this ); 
			thisTimer.Start(); 
		}

        public TaskManager250Min(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			if ( MySettings.S_RunRoutinesAtStartup && !( File.Exists( "Data/Data.ref" ) ) )
			{
				FirstTimer thisTimer = new FirstTimer( this ); 
				thisTimer.Start();
			}
			else
			{
				TaskTimer thisTimer = new TaskTimer( this ); 
				thisTimer.Start(); 
			}
		}

		public class TaskTimer : Timer 
		{ 
			private Item i_item; 
			public TaskTimer( Item task ) : base( TimeSpan.FromMinutes( 250.0 ) )
			{ 
				Priority = TimerPriority.OneMinute; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( false, i_item );
			} 
		}

		public class FirstTimer : Timer 
		{ 
			private Item i_item; 
			public FirstTimer( Item task ) : base( TimeSpan.FromSeconds( 5.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( true, i_item );
			} 
		}

		public static void RunThis( bool DoAction, Item item )
		{
			TaskTimer thisTimer = new TaskTimer( item ); 
			thisTimer.Start(); 

			///// ADD RANDOM CITIZENS IN SETTLEMENTS /////////////////////
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(250) Repopulate Cities..." ); }
			Server.Mobiles.Citizens.PopulateCities();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(250) Repopulate Homes..." ); }
			Server.Items.TavernTable.PopulateHomes();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(250) Repopulate Villages..." ); }
			Server.Items.WorkingSpots.PopulateVillages();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(250 Minute) Tasks Complete!" ); }
		}
	}
}

namespace Server.Items
{
	public class TaskManagerDaily : Item
	{
		[Constructable]
		public TaskManagerDaily () : base( 0x0EDE )
		{
			Movable = false;
			Name = "Task Manager Daily";
			Visible = false;
			TaskTimer thisTimer = new TaskTimer( this ); 
			thisTimer.Start(); 
		}

        public TaskManagerDaily(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			if ( MySettings.S_RunRoutinesAtStartup && !( File.Exists( "Data/Data.ref" ) ) )
			{
				FirstTimer thisTimer = new FirstTimer( this ); 
				thisTimer.Start();
			}
			else
			{
				TaskTimer thisTimer = new TaskTimer( this ); 
				thisTimer.Start(); 
			}
		}

		public class TaskTimer : Timer 
		{
			private Item i_item; 
			public TaskTimer( Item task ) : base( TimeSpan.FromHours( 24.0 ) )
			{ 
				Priority = TimerPriority.OneMinute; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( i_item );
			} 
		}

		public class FirstTimer : Timer 
		{ 
			private Item i_item; 
			public FirstTimer( Item task ) : base( TimeSpan.FromSeconds( 10.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( i_item );
			} 
		}

		public static void RunThis( Item item )
		{
			TaskTimer thisTimer = new TaskTimer( item ); 
			thisTimer.Start(); 
			
			///// MOVE THE SEARCH PEDESTALS //////////////////////////////////////
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Reconfigure Quest Pedestals..." ); }
			BuildQuests.SearchCreate();

			///// MAKE THE STEAL PEDS LOOK DIFFERENT /////////////////////////////
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Reconfigure Thief Pedestals..." ); }
			BuildPedestals.CreateStealPeds();
			
			///// CLEANUP THE CREATURES MASS SPREAD OUT IN THE LAND //////////////

			ArrayList targets = new ArrayList();
			ArrayList healers = new ArrayList();
			ArrayList exodus = new ArrayList();
			ArrayList serpent = new ArrayList();
			ArrayList gargoyle = new ArrayList();
			ArrayList cleanup = new ArrayList();
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Respawn The Mass Spawns..." ); }
			foreach ( Mobile creature in World.Mobiles.Values )
			{
				if ( creature is CodexGargoyleA || creature is CodexGargoyleB )
				{
					gargoyle.Add( creature );
				}
				else if ( creature is BaseCreature && creature.Map == Map.Internal )
				{
					if (((BaseCreature)creature).IsStabled){} // DO NOTHING
					else if ( creature is BaseMount && ((BaseMount)creature).Rider != null ){} // DO NOTHING
					else { cleanup.Add( creature ); }
				}
				else if ( creature.WhisperHue == 999 || creature.WhisperHue == 911 )
				{
					if ( creature != null )
					{
						if ( creature is Adventurers || creature is WanderingHealer || creature is Courier || creature is Syth || creature is Jedi ){ healers.Add( creature ); }
						else if ( creature is Exodus ){ exodus.Add( creature ); }
						else if ( creature is Jormungandr ){ serpent.Add( creature ); }
						else { targets.Add( creature ); }
					}
				}
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Remove Lost Boats..." ); }
			Server.Multis.BaseBoat.ClearShip(); // SAFETY CATCH TO CLEAR THE SHIPS OFF THE SEA

			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Respawn Sea..." ); }
			for ( int i = 0; i < targets.Count; ++i )
			{
				Mobile creature = ( Mobile )targets[ i ];
				if ( creature.Hidden == false )
				{
					if ( creature.WhisperHue == 911 )
					{
						Effects.SendLocationEffect( creature.Location, creature.Map, 0x3400, 60, 0x6E4, 0 );
						Effects.PlaySound( creature.Location, creature.Map, 0x108 );
					}
					else
					{
						creature.PlaySound( 0x026 );
						Effects.SendLocationEffect( creature.Location, creature.Map, 0x352D, 16, 4 );
					}
				}
				creature.Delete();
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Move Exodus..." ); }
			for ( int i = 0; i < exodus.Count; ++i )
			{
				Mobile creature = ( Mobile )exodus[ i ];
				Server.Misc.IntelligentAction.BurnAway( creature );
				Worlds.MoveToRandomDungeon( creature );
				Server.Misc.IntelligentAction.BurnAway( creature );
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Special Sea Serpent..." ); }
			for ( int i = 0; i < serpent.Count; ++i )
			{
				Mobile creature = ( Mobile )serpent[ i ];
				creature.PlaySound( 0x026 );
				Effects.SendLocationEffect( creature.Location, creature.Map, 0x352D, 16, 4 );
				Worlds.MoveToRandomOcean( creature );
				creature.PlaySound( 0x026 );
				Effects.SendLocationEffect( creature.Location, creature.Map, 0x352D, 16, 4 );
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Respawn Gargoyles..." ); }
			for ( int i = 0; i < gargoyle.Count; ++i )
			{
				Mobile creature = ( Mobile )gargoyle[ i ];
				Server.Misc.IntelligentAction.BurnAway( creature );
				Worlds.MoveToRandomDungeon( creature );
				Server.Misc.IntelligentAction.BurnAway( creature );
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Remove Lost Creatures..." ); }
			for ( int i = 0; i < cleanup.Count; ++i )
			{
				Mobile creature = ( Mobile )cleanup[ i ];
				creature.Delete();
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Respawn Jedis, Healers, etc..." ); }
			for ( int i = 0; i < healers.Count; ++i )
			{
				Mobile healer = ( Mobile )healers[ i ];
				if ( !(healer is Citizens) )
				{
					Effects.SendLocationParticles( EffectItem.Create( healer.Location, healer.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
					healer.PlaySound( 0x1FE );
				}
				healer.Delete();
			}

			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Respawn Tavern Patrons..." ); }
			ArrayList drinkers = new ArrayList();
			foreach ( Mobile drunk in World.Mobiles.Values )
			if ( drunk is AdventurerWest || drunk is AdventurerSouth || drunk is AdventurerNorth || drunk is AdventurerEast || drunk is TavernPatronWest || drunk is TavernPatronSouth || drunk is TavernPatronNorth || drunk is TavernPatronEast )
			{
				if ( drunk != null )
				{
					drinkers.Add( drunk );
				}
			}
			for ( int i = 0; i < drinkers.Count; ++i )
			{
				Mobile drunk = ( Mobile )drinkers[ i ];
				drunk.Delete();
			}

			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Daily) Tasks Complete!" ); }
		}
	}
}

namespace Server.Items
{
	public class TaskManager : Item
	{
		[Constructable]
		public TaskManager () : base( 0x0EDE )
		{
			Movable = false;
			Name = "Task Manager 1 Hour";
			Visible = false;
			TaskTimer thisTimer = new TaskTimer( this ); 
			thisTimer.Start(); 
		}

        public TaskManager(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			if ( MySettings.S_RunRoutinesAtStartup && !( File.Exists( "Data/Data.ref" ) ) )
			{
				FirstTimer thisTimer = new FirstTimer( this ); 
				thisTimer.Start();
			}
			else
			{
				TaskTimer thisTimer = new TaskTimer( this ); 
				thisTimer.Start(); 
			}

			if ( File.Exists( "Data/Data.ref" ) )
			{
				BuildWorlds buildTimer = new BuildWorlds( this ); 
				buildTimer.Start();
			}
		}

		public class TaskTimer : Timer 
		{
			private Item i_item; 
			public TaskTimer( Item task ) : base( TimeSpan.FromMinutes( 60.0 ) )
			{ 
				Priority = TimerPriority.OneMinute; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( i_item );
			} 
		}

		public class BuildWorlds : Timer 
		{ 
			private Item i_item; 
			public BuildWorlds( Item task ) : base( TimeSpan.FromSeconds( 10.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				BuildThis( i_item );
			} 
		}

		public static void BuildThis( Item itm )
		{
			Mobile from = null;

			foreach ( Account a in Accounts.GetAccounts() )
			{
				if (a == null)
					break;

				int index = 0;

				for (int i = 0; i < a.Length; ++i)
				{
					Mobile m = a[i];

					if (m == null)
						continue;

					if ( m.AccessLevel == AccessLevel.Owner )
						from = m;

					++index;
				}
			}

			if ( from != null )
				CommandSystem.Handle(from, String.Format("{0}{1}", CommandSystem.Prefix, "BuildWorld"));

			Console.WriteLine("You may now play " + MySettings.S_ServerName + "!");
			Console.WriteLine("");
		}

		public class FirstTimer : Timer 
		{ 
			private Item i_item; 
			public FirstTimer( Item task ) : base( TimeSpan.FromSeconds( 10.0 ) )
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = task; 
			} 

			protected override void OnTick() 
			{
				RunThis( i_item );
			} 
		}

		public static void RunThis( Item itm )
		{
			TaskTimer thisTimer = new TaskTimer( itm ); 
			thisTimer.Start(); 

			// SWITCH UP THE MAGIC MIRRORS
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Reconfigure Magic Mirrors..." ); }
			Server.Items.MagicMirror.SetMirrors();

			// REMOVE ACTION SET PIECES
			Server.Items.ActionFunc.RemoveActions( false, itm.Location, itm.Map );

			// MOVE SHOPKEEPERS AND GUARDS TO WHERE THEY BELONG...IN CASE THEY MOVED FAR AWAY
			// ALSO CLEAN UP ANY GRAVE DISTURBED MONSTERS OR TREASURE MAP MONSTERS
			ArrayList vendors = new ArrayList();
			ArrayList citizens = new ArrayList();
			ArrayList wanderers = new ArrayList();
			ArrayList monsters = new ArrayList();
			foreach ( Mobile vendor in World.Mobiles.Values )
			{
				if ( vendor is BaseVendor && vendor.WhisperHue != 911 && vendor.WhisperHue != 999 && !(vendor is PlayerVendor) && !(vendor is PlayerBarkeeper) )
				{
					vendors.Add( vendor );
				}
				else if ( vendor is TownGuards )
				{
					vendors.Add( vendor );
				}
				else if ( vendor is Citizens && vendor.Fame > 0 )
				{
					citizens.Add( vendor );
				}
				else if ( vendor is BaseCreature && ( ((BaseCreature)vendor).WhisperHue == 999 || ((BaseCreature)vendor).WhisperHue == 999 ) && vendor.Location == ((BaseCreature)vendor).Home )
				{
					wanderers.Add( vendor );
				}
				else if ( vendor is BaseCreature && ((BaseCreature)vendor).ControlSlots == 666 && vendor.Combatant == null )
				{
					monsters.Add( vendor );
				}
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Move Vendors and Guards Back..." ); }
			for ( int i = 0; i < vendors.Count; ++i )
			{
				Mobile vendor = ( Mobile )vendors[ i ];
				BaseCreature vendur = ( BaseCreature )vendors[ i ];

				vendor.Location = vendur.Home;

				if ( Server.Items.ActionFunc.HasActs( vendor ) )
					Server.Items.ActionFunc.MakeActs( (BaseCreature)vendor );
				else if ( vendor is BaseVendor )
					((BaseCreature)vendor).RangeHome = ((BaseCreature)vendor).ControlSlots;
			}
			for ( int i = 0; i < citizens.Count; ++i )
			{
				Mobile citizen = ( Mobile )citizens[ i ];
				citizen.Fame = 0;
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Removing Wandering Creatures..." ); }
			for ( int i = 0; i < wanderers.Count; ++i )
			{
				Mobile wanderer = ( Mobile )wanderers[ i ];
				wanderer.Delete();
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Remove Certain Creatures..." ); }
			for ( int i = 0; i < monsters.Count; ++i )
			{
				Mobile ridof = ( Mobile )monsters[ i ];
				Effects.SendLocationParticles( EffectItem.Create( ridof.Location, ridof.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 5042 );
				Effects.PlaySound( ridof, ridof.Map, 0x201 );
				ridof.Delete();
			}
			
			ArrayList targets = new ArrayList();
			foreach ( Item item in World.Items.Values )
			if ( item is MushroomTrap || item is LandChest || item is Strange_Portal || item is StrangePortal || item is WaterChest || item is RavendarkStorm || item is HiddenTrap || item is DungeonChest || item is HiddenChest || item is AltarGodsEast || item is AltarGodsSouth || item is AltarShrineEast || item is AltarShrineSouth || item is AltarStatue || item is AltarSea || item is AltarDryad || item is AltarEvil || item is AltarDaemon )
			{
				if ( item != null )
				{
					targets.Add( item );
				}
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Reconfigure Traps, Chests, and Altars..." ); }
			for ( int i = 0; i < targets.Count; ++i )
			{
				Item item = ( Item )targets[ i ];

				if ( item is MushroomTrap )
				{
					item.Hue = Utility.RandomList( 0x47E, 0x48B, 0x495, 0xB95, 0x5B6, 0x5B7, 0x55F, 0x55C, 0x556, 0x54F, 0x489 );

					switch( Utility.RandomMinMax( 1, 6 ) )
					{
						case 1: item.Name = "strange mushroom"; break;
						case 2: item.Name = "weird mushroom"; break;
						case 3: item.Name = "odd mushroom"; break;
						case 4: item.Name = "curious mushroom"; break;
						case 5: item.Name = "peculiar mushroom"; break;
						case 6: item.Name = "bizarre mushroom"; break;
					}
				}
				else if ( item is AltarGodsEast )
				{
					Item shrine = new AltarGodsEast();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarGodsSouth )
				{
					Item shrine = new AltarGodsSouth();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarShrineEast )
				{
					Item shrine = new AltarShrineEast();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarShrineSouth )
				{
					Item shrine = new AltarShrineSouth();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarStatue )
				{
					Item shrine = new AltarStatue();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarSea )
				{
					Item shrine = new AltarSea();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					if ( item.ItemID == 0x4FB1 || item.ItemID == 0x4FB2 )
					{
						shrine.Hue = 0;
						shrine.Name = "Shrine of Poseidon";
						shrine.ItemID = Utility.RandomList( 0x4FB1, 0x4FB2 );
					}
					else if ( item.ItemID == 0x6395 )
					{
						shrine.Hue = 0;
						shrine.Name = "Shrine of Neptune";
						shrine.ItemID = 0x6395;
					}
					item.Delete();
				}
				else if ( item is AltarEvil )
				{
					Item shrine = new AltarEvil();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarDryad )
				{
					Item shrine = new AltarDryad();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is AltarDaemon )
				{
					Item shrine = new AltarDaemon();
					shrine.Weight = -2.0;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					if ( item.ItemID == 0x6393 || item.ItemID == 0x6394 )
					{
						shrine.Hue = 0;
						shrine.Name = "Shrine of Ktulu";
						shrine.ItemID = item.ItemID;
					}
					item.Delete();
				}
				else if ( item is AltarGargoyle )
				{
					Item shrine = new AltarGargoyle();
					shrine.Weight = -2.0;
					shrine.ItemID = item.ItemID;
					shrine.Movable = false;
					shrine.MoveToWorld (new Point3D(item.X, item.Y, item.Z), item.Map);
					item.Delete();
				}
				else if ( item is DungeonChest )
				{
					DungeonChest box = (DungeonChest)item;
					if ( box.ContainerLockable > 0 && box.ContainerTouched != 1 )
					{
						box.Locked = false;
						switch( Utility.Random( 3 ) )
						{
							case 0: box.Locked = true; break;
						}
					}
					else
					{
						box.Locked = false;
					}
					if ( box.ContainerLevel > 0 && box.ContainerTouched != 1 )
					{
						switch ( Utility.Random( 9 ) )
						{
							case 0: box.TrapType = TrapType.DartTrap; break;
							case 1: box.TrapType = TrapType.None; break;
							case 2: box.TrapType = TrapType.ExplosionTrap; break;
							case 3: box.TrapType = TrapType.MagicTrap; break;
							case 4: box.TrapType = TrapType.PoisonTrap; break;
							case 5: box.TrapType = TrapType.None; break;
							case 6: box.TrapType = TrapType.None; break;
							case 7: box.TrapType = TrapType.None; break;
							case 8: box.TrapType = TrapType.None; break;
						}
					}
				}
				else
				{
					item.Delete();
				}
			}
			if ( MySettings.ConsoleLog ){ Console.WriteLine( "(Hourly) Tasks Complete!" ); }
		}
	}
}