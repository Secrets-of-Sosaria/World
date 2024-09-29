using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Items;

namespace Server
{
	public class SpawnList
	{
		private static Type[] ForestCritters = new Type[]
		{
			typeof( Critter ),	typeof( Critter ),		typeof( Critter ),			typeof( Critter ),
			typeof( Rat ),		typeof( Snake ),		typeof( Rabbit ),			typeof( Squirrel )
		};

		private static Type[] DesertCritters = new Type[]
		{
			typeof( Critter ),	typeof( Critter ),		typeof( Critter ),
			typeof( Weasel ),	typeof( Snake ),		typeof( JackRabbit )
		};

		private static Type[] SnowCritters = new Type[]
		{
			typeof( Rabbit ),		typeof( Squirrel )
		};

		private static Type[] JungleCritters = new Type[]
		{
			typeof( Critter ),		typeof( Snake )
		};

		private static Type[] FieldCritters = new Type[]
		{
			typeof( Critter ),		typeof( Ferret )
		};

		private static Type[] SwampCritters = new Type[]
		{
			typeof( Critter ),		typeof( Critter ),		typeof( Rat ),		typeof( Snake )
		};

		private static Type[] DirtCritters = new Type[]
		{
			typeof( Critter ),		typeof( Rat )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] ForestBirds = new Type[]
		{
			typeof( Bird ),		typeof( Bird ),		typeof( Bird ),		typeof( Bird ),		typeof( Turkey ),	typeof( Eagle )
		};

		private static Type[] DesertBirds = new Type[]
		{
			typeof( DesertBird ),			typeof( DesertBird ),			typeof( Hawk )
		};

		private static Type[] SnowBirds = new Type[]
		{
			typeof( Penguin ),				typeof( Hawk )
		};

		private static Type[] JungleBirds = new Type[]
		{
			typeof( TropicalBird ),		typeof( TropicalBird ),		typeof( TropicalBird ),		typeof( Crane )
		};

		private static Type[] FieldBirds = new Type[]
		{
			typeof( Bird ),		typeof( Bird ),		typeof( Bird ),		typeof( Bird ),		typeof( Eagle ),	typeof( Hawk )
		};

		private static Type[] SwampBirds = new Type[]
		{
			typeof( SwampBird ),		typeof( SwampBird ),		typeof( Crane )
		};

		private static Type[] DirtBirds = new Type[]
		{
			typeof( Bird )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] ForestAnimals = new Type[]
		{
			typeof( BlackBear ),			typeof( Boar ),					typeof( BrownBear ),
			typeof( Cougar ),				typeof( Fox ),					typeof( GreatHart ),
			typeof( Moose ),				typeof( BlackWolf ),			typeof( GrizzlyBearRiding ),
			typeof( Hind ),					typeof( Jaguar ), 				typeof( TimberWolf ),
			typeof( KodiakBear ),			typeof( ForestOstard ),			typeof( GreyWolf )
		};

		private static Type[] JungleAnimals = new Type[]
		{
			typeof( Boar ),					typeof( Gorilla ),				typeof( Monkey ),
			typeof( PandaRiding ),			typeof( Panther ),				typeof( Toad ),
			typeof( BullradonRiding ),		typeof( Ridgeback )
		};

		private static Type[] FieldAnimals = new Type[]
		{
			typeof( ZebraRiding ),			typeof( Elephant ),				typeof( BrownBear ),
			typeof( Fox ),					typeof( Goat ),					typeof( Gazelle ),
			typeof( Moose ),				typeof( Hyena ),				typeof( Cheetah ),
			typeof( MountainGoat ),			typeof( Giraffe ),				typeof( Ostrich ),
			typeof( Worg ),					typeof( Ridgeback ),			typeof( RidableLlama ),
			typeof( DireGoat ),				typeof( Mastadon )
		};

		private static Type[] SnowAnimals = new Type[]
		{
			typeof( PolarBear ),			typeof( SnowLeopard ),			typeof( Hind ),
			typeof( Goat ),					typeof( Walrus ),				typeof( GreatHart ),
			typeof( Moose ),				typeof( WhiteRabbit ),			typeof( WhiteWolf ),
			typeof( SnowOstard ),			typeof( Mammoth ),				typeof( Ramadon ),
			typeof( MountainGoat ),			typeof( DireGoat )
		};

		private static Type[] DesertAnimals = new Type[]
		{
			typeof( Jackal ),				typeof( Antelope ),				typeof( DesertOstard ),
			typeof( Bobcat )
		};

		private static Type[] SwampAnimals = new Type[]
		{
			typeof( Boar ),					typeof( Bull ),					typeof( BlackBear ),
			typeof( Turtle ),				typeof( Frog ),					typeof( SwampDragon ),
			typeof( GreatHart ),			typeof( Moose ),				typeof( Toad ),
			typeof( Ridgeback ),			typeof( GiantSnake ),			typeof( SwampGator ),
			typeof( SabreclawCub ),			typeof( SabretoothCub ),		typeof( Reptaur ),

		};

		private static Type[] DirtAnimals = new Type[]
		{
			typeof( Boar ),					typeof( BlackBear ),			typeof( BlackWolf )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Dirt_A = new Type[]
		{
			typeof( DireBoar ),				typeof( GiantBat ),				typeof( GiantRat ),
			typeof( GiantSpider ),			typeof( LargeSnake ),			typeof( Ratman ),
			typeof( Mongbat ),				typeof( GiantLizard ),			typeof( BloodLotus ),
			typeof( BlackPudding )
		};
		private static Type[] Dirt_B = new Type[]
		{
			typeof( ElectricalElemental ),	typeof( SpawnMan ),				typeof( MudMan ),
			typeof( StoneGargoyle ),		typeof( Ogre ),					typeof( GorgonRiding )
		};
		private static Type[] Dirt_C = new Type[]
		{
			typeof( ManticoreRiding ),		typeof( WhippingVine ),			typeof( Xorn ),
			typeof( CaveBearRiding ),		typeof( Drake ),				typeof( Beetle )
		};
		private static Type[] Dirt_D = new Type[]
		{
			typeof( Daemon ),				typeof( Hydra ),				typeof( Wyrms ),
			typeof( Giant ),				typeof( OgreLord ),				typeof( Balron ),
			typeof( RidingDragon ),			typeof( Nightmare )
		};
		private static Type[] Dirt_E = new Type[]
		{
			typeof( AsianDragon ),			typeof( Angel ),				typeof( Archangel ),
			typeof( Wisp )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Forest_A = new Type[]
		{
			typeof( WolfDire ),				typeof( GiantBat ),				typeof( GiantRat ),
			typeof( GiantSpider ),			typeof( GiantToad ),			typeof( Ratman ),
			typeof( GiantLizard ),			typeof( LargeSnake ),			typeof( DeathwatchBeetleHatchling ),
			typeof( DireBoar ),				typeof( Mongbat ),				typeof( SpawnMinor )
		};
		private static Type[] Forest_B = new Type[]
		{
			typeof( Anhkheg ),				typeof( SpawnMan ),				typeof( Ettin ),
			typeof( ForestElemental ),		typeof( RandomSerpent ),		typeof( RavenousRiding ),
			typeof( DeathwatchBeetle ),		typeof( Ogre ),					typeof( Neanderthal ),
			typeof( TrollWitchDoctor )
		};
		private static Type[] Forest_C = new Type[]
		{
			typeof( WalkingReaper ),		typeof( Reaper ),				typeof( Jackalwitch ),
			typeof( Sprite ),				typeof( Owlbear ),				typeof( Ettin ),
			typeof( ElderBrownBearRiding ),	typeof( Drake ),				typeof( SpawnMajor ),
			typeof( ElderBlackBearRiding ),	typeof( DireBear ),				typeof( SabretoothBearRiding ),
			typeof( Titanoboa ),			typeof( Beetle )
		};
		private static Type[] Forest_D = new Type[]
		{
			typeof( AncientReaper ),		typeof( Dreadhorn ),			typeof( Balron ),
			typeof( Daemon ),				typeof( Hydra ),				typeof( Wyrms ),
			typeof( ForestGiant ),			typeof( OgreLord ),				typeof( EttinShaman ),
			typeof( RidingDragon ),			typeof( WoodlandDevil ),		typeof( Tyranasaur )
		};
		private static Type[] Forest_E = new Type[]
		{
			typeof( AncientEnt ),			typeof( Ent ),					typeof( Faerie ),
			typeof( Pixie ),				typeof( Unicorn ),				typeof( xDryad ),
			typeof( AsianDragon ),			typeof( Angel ),				typeof( Archangel )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Jungle_A = new Type[]
		{
			typeof( SpawnMinor ),			typeof( TigerBeetleRiding ),	typeof( TigerRiding ),
			typeof( SkeletonArcher ),		typeof( Skeleton ),				typeof( SabretoothTigerRiding ),
			typeof( GiantSpider ),			typeof( GiantRat ),				typeof( GiantBat ),
			typeof( BullFrog ),				typeof( Ape ),					typeof( Savage ),
			typeof( Mongbat ),				typeof( BloodLotus ),			typeof( DireBoar )
		};
		private static Type[] Jungle_B = new Type[]
		{
			typeof( WeedElemental ),		typeof( Troll ),				typeof( StrangleVine ),
			typeof( JungleViper ),			typeof( SpawnMan ),				typeof( Mantis ),
			typeof( Gargoyle ),				typeof( HugeLizard ),			typeof( Crocodile ),
			typeof( GorceratopsRiding ),	typeof( Neanderthal ),			typeof( RaptorRiding ),
			typeof( RavenousRiding )
		};
		private static Type[] Jungle_C = new Type[]
		{
			typeof( Wyverns ),				typeof( SwampDrakeRiding ),		typeof( Cyclops ),
			typeof( Gorakong ),				typeof( Meglasaur ),			typeof( SpawnMajor ),
			typeof( Stegosaurus ),			typeof( Brontosaur ),			typeof( Titanoboa )
		};
		private static Type[] Jungle_D = new Type[]
		{
			typeof( Balron ),				typeof( Daemon ),				typeof( Hydra ),
			typeof( Wyrms ),				typeof( JungleGiant ),			typeof( ShamanicCyclops ),
			typeof( RidingDragon ),			typeof( Tyranasaur )
		};
		private static Type[] Jungle_E = new Type[]
		{
			typeof( Faerie ),				typeof( Pixie ),
			typeof( AsianDragon ),			typeof( Angel ),				typeof( Archangel )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Field_A = new Type[]
		{
			typeof( Gnome ),				typeof( GnomeWarrior ),			typeof( GnomeMage ),
			typeof( WolfDire ),				typeof( LionRiding ),			typeof( Ratman ),
			typeof( Skeleton ),				typeof( SkeletonArcher ),		typeof( Tarantula ),
			typeof( TigerRiding ),			typeof( SpawnMinor ),			typeof( DeathwatchBeetleHatchling )
		};
		private static Type[] Field_B = new Type[]
		{
			typeof( AirElemental ),			typeof( Anhkheg ),				typeof( SpawnMan ),
			typeof( Corpser ),				typeof( Ettin ),				typeof( Gargoyle ),
			typeof( GiantHawk ),			typeof( GiantRaven ),			typeof( HippogriffRiding ),
			typeof( Ogre ),					typeof( WeedElemental ),		typeof( DeathwatchBeetle )
		};
		private static Type[] Field_C = new Type[]
		{
			typeof( BasiliskRiding ),		typeof( ElderBrownBearRiding ),	typeof( Harpy ),
			typeof( SpawnMajor ),			typeof( Beetle ),				typeof( YoungRoc ),
			typeof( Xatyr ),				typeof( CorruptCentaur )
		};
		private static Type[] Field_D = new Type[]
		{
			typeof( EttinShaman ),			typeof( HillGiant ),			typeof( Giant ),
			typeof( HillGiantShaman ),		typeof( Dragons ),				typeof( Wyrms ),
			typeof( Hydra ),				typeof( Daemon ),				typeof( Balron ),
			typeof( RuneBeetle ),			typeof( Roc )
		};
		private static Type[] Field_E = new Type[]
		{
			typeof( Centaur ),				typeof( Pegasus ),				typeof( GriffonRiding ),
			typeof( Satyr )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Snow_A = new Type[]
		{
			typeof( FrostOoze ),			typeof( FrostSpider ),			typeof( IceSnake ),
			typeof( IceToad ),				typeof( IceSerpent ),			typeof( SnowHarpy ),
			typeof( WinterWolf ),			typeof( SpawnMinor )
		};
		private static Type[] Snow_B = new Type[]
		{
			typeof( SpawnMan ),				typeof( Yeti ),					typeof( WhiteTigerRiding ),
			typeof( TundraOgre ),			typeof( IceGhoul ),				typeof( IceElemental ),
			typeof( FrozenCorpse ),			typeof( FrostTrollShaman ),		typeof( FrostTroll ),
			typeof( ArcticEttin ),			typeof( SnowLion )
		};
		private static Type[] Snow_C = new Type[]
		{
			typeof( ElderPolarBearRiding ),	typeof( GiantIceWorm ),			typeof( SnowElemental ),
			typeof( SpawnMajor )
		};
		private static Type[] Snow_D = new Type[]
		{
			typeof( Balron ),			typeof( Daemon ),					typeof( Hydra ),
			typeof( Wyrms ),			typeof( FrostGiant ),				typeof( RidingDragon ),
			typeof( IcebergElemental ),	typeof( ArcticOgreLord )
		};
		private static Type[] Snow_E = new Type[]
		{
			typeof( AsianDragon ),			typeof( Angel ),				typeof( Archangel )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Desert_A = new Type[]
		{
			typeof( LionRiding ),			typeof( SandVortex ),			typeof( SpawnMinor ),
			typeof( Scorpion )
		};
		private static Type[] Desert_B = new Type[]
		{
			typeof( EarthElemental ),		typeof( SandVortex ),			typeof( Iguanodon ),
			typeof( FireElemental ),		typeof( GiantAdder ),			typeof( Iguana ),
			typeof( DustElemental ),		typeof( RatmanArcher ),			typeof( RatmanMage ),
			typeof( SphinxRiding ),			typeof( SpawnMan )
		};
		private static Type[] Desert_C = new Type[]
		{
			typeof( SandSpider ),			typeof( GorgonRiding ),			typeof( SpawnMajor ),
			typeof( ManticoreRiding ),		typeof( Mummy ),				typeof( RoyalSphinx ),
			typeof( SandSquid )
		};
		private static Type[] Desert_D = new Type[]
		{
			typeof( RidingDragon ),			typeof( DuneBeetle ),			typeof( Daemon ),
			typeof( Afreet ),				typeof( SandGiant ),			typeof( Hydra ),
			typeof( Balron ),				typeof( Wyrms ),				typeof( AncientSphinx )
		};
		private static Type[] Desert_E = new Type[]
		{
			typeof( AsianDragon ),			typeof( Angel ),				typeof( Archangel )
		};

		// ----------------------------------------------------------------------------------------

		private static Type[] Swamp_A = new Type[]
		{
			typeof( Alligator ),			typeof( Bogling ),				typeof( GiantLeech ),
			typeof( GiantRat ),				typeof( GreenSlime ),			typeof( PoisonFrog ),
			typeof( Quagmire ),				typeof( SpawnMinor ),			typeof( Mongbat ),
			typeof( DireBoar )
		};
		private static Type[] Swamp_B = new Type[]
		{
			typeof( SpawnMan ),				typeof( GiantSerpent ),			typeof( Mantis ),
			typeof( SwampTentacle ),		typeof( MarshWurm ),			typeof( PoisonBeetleRiding ),
			typeof( SwampTroll ),			typeof( HugeLizard )
		};
		private static Type[] Swamp_C = new Type[]
		{
			typeof( SwampThing ),			typeof( SpawnMajor ),			typeof( CreepingFungus )
		};
		private static Type[] Swamp_D = new Type[]
		{
			typeof( RidingDragon ),			typeof( JungleGiant ),			typeof( Wyrms ),
			typeof( Hydra ),				typeof( Daemon ),				typeof( Balron ),
			typeof( BogThing )
		};
		private static Type[] Swamp_E = new Type[]
		{
			typeof( Wisp ),					typeof( AsianDragon ),			typeof( Angel ),
			typeof( Archangel )
		};

		// ----------------------------------------------------------------------------------------

		public static Mobile RandomSpawn( Item spawn, Land land, Point3D loc, Map map )
		{
			Mobile m = null;
			bool safari = MyServerSettings.Safari( land );
			spawn.MoveToWorld( loc, map );
			int npc = 0;
			int tries = 100;
			Terrain terrain = spawn.Terrain;

			if ( terrain != Terrain.Water && terrain != Terrain.Cave && terrain != Terrain.Dirt && terrain != Terrain.Rock )
				terrain = Terrains.TestAround( terrain, map, spawn.X, spawn.Y, 15 );

			while ( m == null && tries > 0 )
			{
				tries--;

				if ( spawn is SpawnCritters )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( ForestCritters ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( DesertCritters ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( JungleCritters ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( FieldCritters ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( SnowCritters ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( SwampCritters ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( DirtCritters ) as Mobile;
				}
				if ( spawn is SpawnBirds )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( ForestBirds ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( DesertBirds ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( JungleBirds ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( FieldBirds ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( SnowBirds ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( SwampBirds ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( DirtBirds ) as Mobile;
				}
				else if ( spawn is SpawnAnimals )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( ForestAnimals ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( DesertAnimals ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( JungleAnimals ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( FieldAnimals ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( SnowAnimals ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( SwampAnimals ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( DirtAnimals ) as Mobile;
				}
				else if ( spawn is Spawn_A )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( Forest_A ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( Desert_A ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( Jungle_A ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( Field_A ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( Snow_A ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( Swamp_A ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( Dirt_A ) as Mobile;
				}
				else if ( spawn is Spawn_B )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( Forest_B ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( Desert_B ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( Jungle_B ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( Field_B ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( Snow_B ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( Swamp_B ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( Dirt_B ) as Mobile;
				}
				else if ( spawn is Spawn_C )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( Forest_C ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( Desert_C ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( Jungle_C ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( Field_C ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( Snow_C ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( Swamp_C ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( Dirt_C ) as Mobile;
				}
				else if ( spawn is Spawn_D )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( Forest_D ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( Desert_D ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( Jungle_D ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( Field_D ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( Snow_D ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( Swamp_D ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( Dirt_D ) as Mobile;
				}
				else if ( spawn is Spawn_E )
				{
					if ( terrain == Terrain.Forest )
						m = Construct( Forest_E ) as Mobile;
					else if ( terrain == Terrain.Sand )
						m = Construct( Desert_E ) as Mobile;
					else if ( terrain == Terrain.Jungle )
						m = Construct( Jungle_E ) as Mobile;
					else if ( terrain == Terrain.Grass )
						m = Construct( Field_E ) as Mobile;
					else if ( terrain == Terrain.Snow )
						m = Construct( Snow_E ) as Mobile;
					else if ( terrain == Terrain.Swamp )
						m = Construct( Swamp_E ) as Mobile;
					else if ( terrain == Terrain.Dirt )
						m = Construct( Dirt_E ) as Mobile;
				}

				if ( m is SpawnMinor )
				{
					m.Delete();

					if ( terrain == Terrain.Forest )
						npc = Utility.RandomList( 0, 1, 2, 3, 4, 5, 6, 7 );
					else if ( terrain == Terrain.Sand )
						npc = Utility.RandomList( 2, 5, 7, 14, 15 );
					else if ( terrain == Terrain.Jungle )
						npc = Utility.RandomList( 2, 6, 8, 9, 10, 11, 12, 13 );
					else if ( terrain == Terrain.Grass )
						npc = Utility.RandomList( 0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 14 );
					else if ( terrain == Terrain.Snow )
						npc = Utility.RandomList( 2, 4 );
					else if ( terrain == Terrain.Swamp )
						npc = Utility.RandomList( 6, 8, 9, 10, 11, 12, 13 );
					else if ( terrain == Terrain.Dirt )
						npc = Utility.RandomList( 0, 1, 2, 5, 6, 7, 14 );

					switch ( npc )
					{
						case 0: m = new GoblinArcher(); break;
						case 1: m = new Goblin(); break;
						case 2: m = new Orc(); break;
						case 3: m = new Gnome(); break;
						case 4: m = new Gnoll(); break;
						case 5: m = new Skeleton(); break;
						case 6: m = new Zombie(); break;
						case 7: m = new SkeletonArcher(); break;
						case 8: m = new Kobold(); break;
						case 9: m = new KoboldMage(); break;
						case 10: m = new Lizardman(); break;
						case 11: m = new LizardmanArcher(); break;
						case 12: m = new Sakleth(); break;
						case 13: m = new Reptaur(); break;
						case 14: m = new Ratman(); break;
						case 15: m = new AntaurWorker(); break;
					}
				}
				else if ( m is SpawnMan )
				{
					m.Delete();

					if ( terrain == Terrain.Forest )
						npc = Utility.RandomList( 1, 2, 4, 10, 15, 16, 21, 22, 23, 24 );
					else if ( terrain == Terrain.Sand )
						npc = Utility.RandomList( 4, 5, 6, 17, 18, 19, 20, 24 );
					else if ( terrain == Terrain.Jungle )
						npc = Utility.RandomList( 1, 3, 4, 9, 10, 11, 12, 13, 14, 21, 22, 23, 24 );
					else if ( terrain == Terrain.Grass )
						npc = Utility.RandomList( 1, 4, 5, 6, 7, 8, 9, 10, 15, 16, 21, 22, 23, 24 );
					else if ( terrain == Terrain.Snow )
						npc = Utility.RandomList( 1, 2, 4, 10, 15, 16, 24 );
					else if ( terrain == Terrain.Swamp )
						npc = Utility.RandomList( 1, 3, 9, 10, 11, 12, 13, 14, 22, 23, 24 );
					else if ( terrain == Terrain.Dirt )
						npc = Utility.RandomList( 0, 4, 5, 6, 9, 15, 16 );

					switch ( npc )
					{
						case 0: m = new Fungal(); break;
						case 1: m = new WereWolf(); break;
						case 2: m = new Bugbear(); break;
						case 3: m = new Naga(); break;
						case 4: m = new OrcBomber(); break;
						case 5: m = new RatmanArcher(); break;
						case 6: m = new RatmanMage(); break;
						case 7: m = new GnomeMage(); break;
						case 8: m = new GnomeWarrior(); break;
						case 9: m = new Ghoul(); break;
						case 10: m = new Hobgoblin(); break;
						case 11: m = new ReptalarShaman(); break;
						case 12: m = new Reptalar(); break;
						case 13: m = new SaklethArcher(); break;
						case 14: m = new SaklethMage(); break;
						case 15: m = new MinotaurSmall(); break;
						case 16: m = new Minotaur(); break;
						case 17: m = new SandSerpyn(); break;
						case 18: m = new FireSalamander(); break;
						case 19: m = new FireNaga(); break;
						case 20: m = new AntaurSoldier(); break;
						case 21: m = new TerathanWarrior(); break;
						case 22: m = new OphidianMage(); break;
						case 23: m = new OphidianWarrior(); break;
						case 24:
							if ( land == Land.Lodoria )
							{
								switch ( Utility.Random( 5 ) )
								{
									case 0: m = new ElfMinstrel(); break;
									case 1: m = new ElfMonks(); break;
									case 2: m = new ElfRogue(); break;
									case 3: m = new ElfBerserker(); break;
									case 4: m = new ElfMage(); break;
								}
							}
							else if ( land == Land.Savaged )
							{
								switch ( Utility.Random( 7 ) )
								{
									case 0: m = new OrkMage(); break;
									case 1: m = new OrkMonks(); break;
									case 2: m = new OrkRogue(); break;
									case 3: m = new OrkWarrior(); break;
									case 4: m = new SavageRider(); break;
									case 5: m = new SavageShaman(); break;
									case 6: m = new Savage(); break;
								}
							}
							else if ( land == Land.IslesDread )
							{
								switch ( Utility.Random( 3 ) )
								{
									case 0: m = new Native(); break;
									case 1: m = new NativeArcher(); break;
									case 2: m = new NativeWitchDoctor(); break;
								}
							}
							else if ( land == Land.Ambrosia )
							{
								switch ( Utility.Random( 5 ) )
								{
									case 0: m = new ZuluuArcher(); break;
									case 1: m = new ZuluuNative(); break;
									case 2: m = new ZuluuWitchDoctor(); break;
									case 3: m = new AbrozShaman(); break;
									case 4: m = new AbrozWarrior(); break;
								}
							}
							else
							{
								switch ( Utility.Random( 5 ) )
								{
									case 0: m = new Minstrel(); break;
									case 1: m = new Monks(); break;
									case 2: m = new Rogue(); break;
									case 3: m = new Berserker(); break;
									case 4: m = new EvilMage(); break;
								}
							}
						break;
					}
				}
				else if ( m is SpawnMajor )
				{
					m.Delete();

					if ( terrain == Terrain.Forest )
						npc = Utility.RandomList( 3, 4, 5, 7, 10, 11, 18, 19 );
					else if ( terrain == Terrain.Sand )
						npc = Utility.RandomList( 3, 4, 5, 7, 12 );
					else if ( terrain == Terrain.Jungle )
						npc = Utility.RandomList( 1, 2, 6, 7, 8, 9, 13, 14, 15, 18 );
					else if ( terrain == Terrain.Grass )
						npc = Utility.RandomList( 3, 4, 5, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 19 );
					else if ( terrain == Terrain.Snow )
						npc = Utility.RandomList( 3, 4, 5, 10, 11, 18 );
					else if ( terrain == Terrain.Swamp )
						npc = Utility.RandomList( 0, 1, 2, 6, 7, 8, 9, 13, 14, 15 );
					else if ( terrain == Terrain.Dirt )
						npc = Utility.RandomList( 0, 3, 4, 5, 7, 10, 11 );

					switch ( npc )
					{
						case 0: m = new FungalMage(); break;
						case 1: m = new ReptalarChieftain(); break;
						case 2: m = new SaklethMage(); break;
						case 3: m = new OrcishMage(); break;
						case 4: m = new OrcishLord(); break;
						case 5: m = new OrcCaptain(); break;
						case 6: m = new Sleestax(); break;
						case 7: m = new Grathek(); break;
						case 8: m = new SerpentarWizard(); break;
						case 9: m = new Serpentar(); break;
						case 10: m = new MinotaurCaptain(); break;
						case 11: m = new MinotaurScout(); break;
						case 12: m = new AntaurProgenitor(); break;
						case 13: m = new OphidianMatriarch(); break;
						case 14: m = new OphidianKnight(); break;
						case 15: m = new OphidianArchmage(); break;
						case 16: m = new TerathanAvenger(); break;
						case 17: m = new TerathanMatriarch(); break;
						case 18: m = new SavageLord(); break;
						case 19: m = new AbrozChieftain(); break;
					}
				}

				if ( land != Land.Lodoria && m is KodiakBear ) m.Delete();
				else if ( land != Land.Lodoria && m is ForestOstard ) m.Delete();
				else if ( land != Land.Serpent && ( m is RandomSerpent || m is RavenousRiding ) ) m.Delete();
				else if ( land != Land.Lodoria && m is DesertOstard ) m.Delete();
				else if ( land != Land.Lodoria && m is SnowOstard ) m.Delete();
				else if ( land != Land.IslesDread && ( m is DireBear || m is Sleestax || m is Native || m is NativeArcher || m is NativeWitchDoctor ) ) m.Delete();
				else if ( land != Land.Savaged && m is SaklethMage ) m.Delete();
				else if ( land != Land.Serpent && land != Land.Savaged && land != Land.IslesDread && m is BloodLotus ) m.Delete();
				else if ( land != Land.Ambrosia && land != Land.Savaged && land != Land.IslesDread && m is SavageLord ) m.Delete();
				else if ( land != Land.Savaged && land != Land.IslesDread && ( 
						m is Meglasaur || 
						m is HugeLizard || 
						m is Mastadon || 
						m is GorceratopsRiding || 
						m is SabretoothTigerRiding ) )
					{ m.Delete(); }
				else if ( land != Land.Savaged && ( 
						m is Titanoboa || 
						m is Mammoth || 
						m is DireBoar || 
						m is Iguanodon || 
						m is Neanderthal || 
						m is Tyranasaur || 
						m is Sakleth || 
						m is SaklethArcher || 
						m is SaklethMage || 
						m is Stegosaurus || 
						m is Brontosaur || 
						m is RaptorRiding ) )
					{ m.Delete(); }
				else if ( land != Land.Serpent && ( 
						m is OphidianMage || 
						m is OphidianMatriarch || 
						m is OphidianKnight || 
						m is OphidianArchmage || 
						m is OphidianWarrior ) )
					{ m.Delete(); }
				else if ( land != Land.Serpent && m is SwampDragon ) m.Delete();
				else if ( land != Land.IslesDread && land != Land.Savaged && m is Ramadon ) m.Delete();
				else if ( land != Land.Savaged && m is Ridgeback && terrain == Terrain.Grass ) m.Delete();
				else if ( land != Land.Savaged && m is Ridgeback && terrain == Terrain.Jungle ) m.Delete();
				else if ( land != Land.Savaged && m is Ridgeback && terrain == Terrain.Swamp ) m.Delete();
				else if ( land != Land.Ambrosia && m is AbrozChieftain ) m.Delete();
				else if ( land != Land.Savaged && ( m is BullradonRiding || m is Worg || m is DireGoat || m is SabretoothBearRiding || m is SabreclawCub || m is SabretoothCub || m is Reptaur ) ) m.Delete();
				else if ( land != Land.Lodoria && ( m is TerathanWarrior || m is TerathanAvenger || m is TerathanMatriarch || m is Serpentar || m is SerpentarWizard || m is ReptalarChieftain || m is Reptalar || m is ReptalarShaman ) ) m.Delete();
				else if ( ( land == Land.Savaged || land == Land.IslesDread ) && m is Elephant ) m.Delete();

				if ( !safari && ( m is Mastadon || m is Mammoth || m is Elephant || m is ZebraRiding || m is Giraffe || m is Ostrich || m is Cheetah || m is Hyena || m is Gazelle ) ) m.Delete();
			}

			spawn.Delete();

			return m;
		}

		#region Construction methods
		public static Mobile Construct( Type type )
		{
			try
			{
				return Activator.CreateInstance( type ) as Mobile;
			}
			catch
			{
				return null;
			}
		}

		public static Mobile Construct( Type[] types )
		{
			if ( types.Length > 0 )
				return Construct( types, Utility.Random( types.Length ) );

			return null;
		}

		public static Mobile Construct( Type[] types, int index )
		{
			if ( index >= 0 && index < types.Length )
				return Construct( types[index] );

			return null;
		}

		public static Mobile Construct( params Type[][] types )
		{
			int totalLength = 0;

			for ( int i = 0; i < types.Length; ++i )
				totalLength += types[i].Length;

			if ( totalLength > 0 )
			{
				int index = Utility.Random( totalLength );

				for ( int i = 0; i < types.Length; ++i )
				{
					if ( index >= 0 && index < types[i].Length )
						return Construct( types[i][index] );

					index -= types[i].Length;
				}
			}

			return null;
		}
		#endregion
	}
}
