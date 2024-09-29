using System;
using System.Collections;
using Server;
using Server.Commands;

namespace Server.Items
{
	public class StealableArtifactsSpawner : Item
	{
		public class StealableEntry
		{
			private Map m_Map;
			private Point3D m_Location;
			private int m_MinDelay;
			private int m_MaxDelay;
			private Type m_Type;
			private int m_Hue;

			public Map Map{ get{ return m_Map; } }
			public Point3D Location{ get{ return m_Location; } }
			public int MinDelay{ get{ return m_MinDelay; } }
			public int MaxDelay{ get{ return m_MaxDelay; } }
			public Type Type{ get{ return m_Type; } }
			public int Hue{ get{ return m_Hue; } }

			public StealableEntry( Map map, Point3D location, int minDelay, int maxDelay, Type type ) : this( map, location, minDelay, maxDelay, type, 0 )
			{
			}

			public StealableEntry( Map map, Point3D location, int minDelay, int maxDelay, Type type, int hue )
			{
				m_Map = map;
				m_Location = location;
				m_MinDelay = minDelay;
				m_MaxDelay = maxDelay;
				m_Type = type;
				m_Hue = hue;
			}

			public Item CreateInstance()
			{
				Item item = (Item) Activator.CreateInstance( m_Type );

				if ( m_Hue > 0 )
					item.Hue = m_Hue;

				item.Movable = false;
				item.MoveToWorld( this.Location, this.Map );

				return item;
			}
		}

		private static StealableEntry[] m_Entries = new StealableEntry[]
			{
				// Artifact rarity 1
				new StealableEntry( Map.Sosaria, new Point3D( 5603, 1231, 0 ), 72, 108, typeof( RockArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 3831, 3300, 46 ), 72, 108, typeof( SkullCandleArtifact ) ),
				new StealableEntry( Map.SerpentIsland, new Point3D( 2196, 842, 6 ), 72, 108, typeof( BottleArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 231, 3496, 20 ), 72, 108, typeof( DamagedBooksArtifact ) ),
				// Artifact rarity 2
				new StealableEntry( Map.Lodor, new Point3D( 5698, 525, 0 ), 144, 216, typeof( StretchedHideArtifact ) ),
				new StealableEntry( Map.SerpentIsland, new Point3D( 2457, 491, 0 ), 144, 216, typeof( BrazierArtifact ) ),
				// Artifact rarity 3
				new StealableEntry( Map.Sosaria, new Point3D( 5661, 3281, 0 ), 288, 432, typeof( LampPostArtifact ), GetLampPostHue() ),
				new StealableEntry( Map.Sosaria, new Point3D( 4021, 3423, 26 ), 288, 432, typeof( BooksNorthArtifact ) ),
				new StealableEntry( Map.SerpentIsland, new Point3D( 2051, 60, 0 ), 288, 432, typeof( BooksWestArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 5936, 1431, 6 ), 288, 432, typeof( BooksFaceDownArtifact ) ),
				// Artifact rarity 5
				new StealableEntry( Map.Sosaria, new Point3D( 5234, 230, 5 ), 1152, 1728, typeof( StuddedLeggingsArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 5479, 900, 0 ), 1152, 1728, typeof( EggCaseArtifact ) ),
				new StealableEntry( Map.Lodor, new Point3D( 5840, 361, 0 ), 1152, 1728, typeof( SkinnedGoatArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 4246, 3771, 0 ), 1152, 1728, typeof( GruesomeStandardArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 5374, 763, 0 ), 1152, 1728, typeof( BloodyWaterArtifact ) ),
				new StealableEntry( Map.Lodor, new Point3D( 5438, 187, 6 ), 1152, 1728, typeof( TarotCardsArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 5584, 412, 10 ), 1152, 1728, typeof( BackpackArtifact ) ),
				// Artifact rarity 7
				new StealableEntry( Map.Lodor, new Point3D( 6118, 208, 27 ), 4608, 6912, typeof( StuddedTunicArtifact ) ),
				new StealableEntry( Map.Lodor, new Point3D( 5142, 1669, 0 ), 4608, 6912, typeof( CocoonArtifact ) ),
				// Artifact rarity 8
				new StealableEntry( Map.Sosaria, new Point3D( 4337, 3452, 25 ), 9216, 13824, typeof( SkinnedDeerArtifact ) ),
				// Artifact rarity 9
				new StealableEntry( Map.Lodor, new Point3D( 5608, 1839, 0 ), 18432, 27648, typeof( SaddleArtifact ) ),
				new StealableEntry( Map.Sosaria, new Point3D( 5627, 2193, 5 ), 18432, 27648, typeof( LeatherTunicArtifact ) ),
				// Artifact rarity 12
				new StealableEntry( Map.SerpentIsland, new Point3D( 2207, 425, 0 ), 147456, 221184, typeof( RuinedPaintingArtifact ) )
			};

		public static StealableEntry[] Entries{ get{ return m_Entries; } }

		private static Type[] m_TypesOfEntries = null;
		public static Type[] TypesOfEntires
		{
			get
			{
				if( m_TypesOfEntries == null )
				{
					m_TypesOfEntries = new Type[m_Entries.Length];

					for( int i = 0; i < m_Entries.Length; i++ )
						m_TypesOfEntries[i] = m_Entries[i].Type;
				}

				return m_TypesOfEntries;
			}
		}

		private static StealableArtifactsSpawner m_Instance;

		public static StealableArtifactsSpawner Instance{ get{ return m_Instance; } }

		private static int GetLampPostHue()
		{
			if ( 0.9 > Utility.RandomDouble() )
				return 0;

			return Utility.RandomList( 0x455, 0x47E, 0x482, 0x486, 0x48F, 0x4F2, 0x58C, 0x66C );
		}

		public static void Initialize()
		{
			CommandSystem.Register( "GenStealArties", AccessLevel.Administrator, new CommandEventHandler( GenStealArties_OnCommand ) );
			CommandSystem.Register( "RemoveStealArties", AccessLevel.Administrator, new CommandEventHandler( RemoveStealArties_OnCommand ) );
		}

		[Usage( "GenStealArties" )]
		[Description( "Generates the stealable artifacts spawner." )]
		public static void GenStealArties_OnCommand( CommandEventArgs args )
		{
			Mobile from = args.Mobile;

			if ( Create() )
				from.SendMessage( "Stealable artifacts spawner generated." );
			else
				from.SendMessage( "Stealable artifacts spawner already present." );
		}

		[Usage( "RemoveStealArties" )]
		[Description( "Removes the stealable artifacts spawner and every not yet stolen stealable artifacts." )]
		public static void RemoveStealArties_OnCommand( CommandEventArgs args )
		{
			Mobile from = args.Mobile;

			if ( Remove() )
				from.SendMessage( "Stealable artifacts spawner removed." );
			else
				from.SendMessage( "Stealable artifacts spawner not present." );
		}

		public static bool Create()
		{
			if ( m_Instance != null && !m_Instance.Deleted )
				return false;

			m_Instance = new StealableArtifactsSpawner();
			return true;
		}

		public static bool Remove()
		{
			if ( m_Instance == null )
				return false;

			m_Instance.Delete();
			m_Instance = null;
			return true;
		}

		public static StealableInstance GetStealableInstance( Item item )
		{
			if ( Instance == null )
				return null;

			return (StealableInstance) Instance.m_Table[item];
		}

		public class StealableInstance
		{
			private StealableEntry m_Entry;
			private Item m_Item;
			private DateTime m_NextRespawn;

			public StealableEntry Entry{ get{ return m_Entry; } }

			public Item Item
			{
				get{ return m_Item; }
				set
				{
					if ( m_Item != null && value == null )
					{
						int delay = Utility.RandomMinMax( this.Entry.MinDelay, this.Entry.MaxDelay );
						this.NextRespawn = DateTime.Now + TimeSpan.FromMinutes( delay );
					}

					if ( Instance != null )
					{
						if ( m_Item != null	)
							Instance.m_Table.Remove( m_Item );

						if ( value != null )
							Instance.m_Table[value] = this;
					}

					m_Item = value;
				}
			}

			public DateTime NextRespawn
			{
				get{ return m_NextRespawn; }
				set{ m_NextRespawn = value; }
			}

			public StealableInstance( StealableEntry entry ) : this( entry, null, DateTime.Now )
			{
			}

			public StealableInstance( StealableEntry entry, Item item, DateTime nextRespawn )
			{
				m_Item = item;
				m_NextRespawn = nextRespawn;
				m_Entry = entry;
			}

			public void CheckRespawn()
			{
				if ( this.Item != null && ( this.Item.Deleted || this.Item.Movable || this.Item.Parent != null ) )
					this.Item = null;

				if ( this.Item == null && DateTime.Now >= this.NextRespawn )
				{
					this.Item = this.Entry.CreateInstance();
				}
			}
		}

		private Timer m_RespawnTimer;
		private StealableInstance[] m_Artifacts;
		private Hashtable m_Table;

		public override string DefaultName
		{
			get { return "Stealable Artifacts Spawner - Internal"; }
		}

		private StealableArtifactsSpawner() : base( 1 )
		{
			Movable = false;

			m_Artifacts = new StealableInstance[m_Entries.Length];
			m_Table = new Hashtable( m_Entries.Length );

			for ( int i = 0; i < m_Entries.Length; i++ )
			{
				m_Artifacts[i] = new StealableInstance( m_Entries[i] );
			}

			m_RespawnTimer = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromMinutes( 15.0 ), new TimerCallback( CheckRespawn ) );
		}

		public override void OnDelete()
		{
			base.OnDelete();

			if ( m_RespawnTimer != null )
			{
				m_RespawnTimer.Stop();
				m_RespawnTimer = null;
			}

			foreach ( StealableInstance si in m_Artifacts )
			{
				if ( si.Item != null )
					si.Item.Delete();
			}

			m_Instance = null;
		}

		public void CheckRespawn()
		{
			foreach ( StealableInstance si in m_Artifacts )
			{
				si.CheckRespawn();
			}
		}

		public StealableArtifactsSpawner( Serial serial ) : base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.WriteEncodedInt( m_Artifacts.Length );

			for ( int i = 0; i < m_Artifacts.Length; i++ )
			{
				StealableInstance si = m_Artifacts[i];

				writer.Write( (Item) si.Item );
				writer.WriteDeltaTime( (DateTime) si.NextRespawn );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Artifacts = new StealableInstance[m_Entries.Length];
			m_Table = new Hashtable( m_Entries.Length );

			int length = reader.ReadEncodedInt();

			for ( int i = 0; i < length; i++ )
			{
				Item item = reader.ReadItem();
				DateTime nextRespawn = reader.ReadDeltaTime();

				if ( i < m_Artifacts.Length )
				{
					StealableInstance si = new StealableInstance( m_Entries[i], item, nextRespawn );
					m_Artifacts[i] = si;

					if ( si.Item != null )
						m_Table[si.Item] = si;
				}
			}

			for ( int i = length; i < m_Entries.Length; i++ )
			{
				m_Artifacts[i] = new StealableInstance( m_Entries[i] );
			}

			m_RespawnTimer = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromMinutes( 15.0 ), new TimerCallback( CheckRespawn ) );
		}
	}
}