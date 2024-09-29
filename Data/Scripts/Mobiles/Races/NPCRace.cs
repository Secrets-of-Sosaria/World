using Server;
using System;
using Server.Mobiles;
using Server.Misc;
using System.Collections;

namespace Server.Items
{
	public class NPCRace : Item
	{
		[Constructable]
		public NPCRace() : base( 0x4047 )
		{
			Layer = Layer.Special;
			LootType = LootType.Blessed;
			Movable = false;
			Weight = 0;
		}

		public static void ConfigureCostume( int race, NPCRace costume )
		{
			string configs = RaceDefined( race );

			if ( configs.Length > 0 )
			{
				string[] setups = configs.Split(',');
				int entry = 1;
				foreach (string stats in setups)
				{
					if ( entry == 1 ){ costume.SpeciesBody = Int32.Parse(stats); }
					else if ( entry == 2 ){ costume.SpeciesItemID = Int32.Parse(stats); costume.ItemID = costume.SpeciesItemID; }
					else if ( entry == 3 )
					{
						int sound = Int32.Parse(stats)+1;

						if ( sound == 10000 ) // mushrooms
						{
							costume.SpeciesAngerSound = 0x451-1;
							costume.SpeciesIdleSound = 0x452-1;
							costume.SpeciesDeathSound = 0x455-1;
							costume.SpeciesAttackSound = 0x453-1;
							costume.SpeciesHurtSound = 0x454-1;
						}
						else
						{
							costume.SpeciesAngerSound = sound-1;
							costume.SpeciesIdleSound = sound;
							costume.SpeciesDeathSound = sound+3;
							costume.SpeciesAttackSound = sound+1;
							costume.SpeciesHurtSound = sound+2;
						}
					}
					else if ( entry == 4 ){ costume.SpeciesGender = Int32.Parse(stats); }

					entry++;
				}
			}
		}

		public static void CreateRace( Mobile m, int id, int hue )
		{
			if ( m.Alive && m is BaseCreature )
			{
				NPCRace race = new NPCRace();
				ConfigureCostume( id, race );

				if ( m.FindItemOnLayer( Layer.Special ) != null ){ (m.FindItemOnLayer( Layer.Special )).Delete(); }

				race.Hue = hue;
				m.AddToBackpack( race );
				m.EquipItem( race );
			}
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
			}
		}

		public override bool OnEquip( Mobile m )
		{
      		if( base.OnEquip( m ) )
      		{
				if ( SpeciesGender == 1 )
				{
					m.Female = true;
					m.Body = 401;
				}
				else
				{
					m.Female = false;
					m.Body = 400;
				}

				m.BodyMod = SpeciesBody;
				m.RaceID = SpeciesBody;
				m.HueMod = this.Hue;
				m.RaceSection = this.Hue;
				this.Name = m.Name;
					if ( m.Title != null && m.Title != "" ){ this.Name = m.Name + " " + m.Title; }
				m.RaceAngerSound = SpeciesAngerSound;
				m.RaceIdleSound = SpeciesIdleSound;
				m.RaceDeathSound = SpeciesDeathSound;
				m.RaceAttackSound = SpeciesAttackSound;
				m.RaceHurtSound = SpeciesHurtSound;

				Mobiles.IMount mt = m.Mount;
				if ( mt != null )
				{
					Server.Mobiles.EtherealMount.EthyDismount( m );
					mt.Rider = null;
				}
      		}
			return base.OnEquip( m );
		}

		public NPCRace( Serial serial ) : base( serial )
		{
		}

		public static string RaceDefined( int val )
		{
			// ItemID,Sound

			string race = "";

			switch ( val )
			{
				case 194: race = "" + val + ",25754,684,0"; break; // Lurker
				case 676: race = "" + val + ",8387,1363,0"; break; // Neptar
				case 677: race = "" + val + ",8387,1363,0"; break; // Neptar
				case 678: race = "" + val + ",8322,1363,0"; break; // Tritun
				case 690: race = "" + val + ",8322,1363,0"; break; // Tritun
				case 343: race = "" + val + ",8341,427,0"; break; // Bugbear
				case 101: race = "" + val + ",16460,679,0"; break; // Centaur
				case 75: race = "" + val + ",8343,604,0"; break; // Cyclops
				case 475: race = "" + val + ",8343,604,0"; break; // Cyclops
				case 259: race = "" + val + ",16472,604,0"; break; // Cyclops
				case 43: race = "" + val + ",8340,357,0"; break; // Balron
				case 38: race = "" + val + ",8338,357,0"; break; // Balron
				case 40: race = "" + val + ",8339,357,0"; break; // Balron
				case 102: race = "" + val + ",8337,357,0"; break; // Balron
				case 88: race = "" + val + ",8363,357,0"; break; // Daemon
				case 765: race = "" + val + ",16462,357,0"; break; // Daemon
				case 9: race = "" + val + ",8337,357,0"; break; // Daemon
				case 10: race = "" + val + ",8337,357,0"; break; // Daemon
				case 320: race = "" + val + ",8337,357,0"; break; // Daemon
				case 748: race = "" + val + ",8356,357,0"; break; // Daemon
				case 764: race = "" + val + ",16473,353,0"; break; // Dagon
				case 146: race = "" + val + ",25755,353,0"; break; // Dagon
				case 112: race = "" + val + ",8383,357,0"; break; // Devil Kin
				case 126: race = "" + val + ",8384,357,0"; break; // Devil Kin
				case 93: race = "" + val + ",8357,655,0"; break; // Shadow Demon
				case 137: race = "" + val + ",8344,357,0"; break; // Demon
				case 195: race = "" + val + ",8364,357,0"; break; // Demon
				case 509: race = "" + val + ",8345,357,0"; break; // Devil
				case 191: race = "" + val + ",8337,357,0"; break; // Balron
				case 427: race = "" + val + ",8337,357,0"; break; // Balron
				case 138: race = "" + val + ",8385,357,0"; break; // Devil
				case 804: race = "" + val + ",8388,357,0"; break; // Devil
				case 436: race = "" + val + ",8386,1200,1"; break; // Devil
				case 766: race = "" + val + ",8347,427,0"; break; // Dragon Ogre
				case 668: race = "" + val + ",16487,357,0"; break; // Drakkul
				case 669: race = "" + val + ",16488,357,1"; break; // Drakkul
				case 670: race = "" + val + ",8346,357,0"; break; // Drakkul
				case 301: race = "" + val + ",25761,442,0"; break; // Ent
				case 309: race = "" + val + ",16489,442,0"; break; // Ent
				case 312: race = "" + val + ",16490,442,0"; break; // Ent
				case 285: race = "" + val + ",25760,442,0"; break; // Reaper
				case 313: race = "" + val + ",8320,442,0"; break; // Reaper
				case 89: race = "" + val + ",16476,367,0"; break; // Ettin
				case 2: race = "" + val + ",16475,367,0"; break; // Ettin
				case 18: race = "" + val + ",16475,367,0"; break; // Ettin
				case 729: race = "" + val + ",16477,367,0"; break; // Ettin
				case 730: race = "" + val + ",16477,367,0"; break; // Ettin
				case 316: race = "" + val + ",16478,367,0"; break; // Ettin
				case 732: race = "" + val + ",16471,367,0"; break; // Ettin
				case 128: race = "" + val + ",8377,1127,1"; break; // Fairy
				case 356: race = "" + val + ",8376,1127,1"; break; // Fairy
				case 363: race = "" + val + ",8375,1127,0"; break; // Pixie
				case 127: race = "" + val + ",8348,372,0"; break; // Astral Gargoyle
				case 257: race = "" + val + ",8327,372,0"; break; // Gargoyle
				case 4: race = "" + val + ",8328,372,0"; break; // Gargoyle
				case 158: race = "" + val + ",8329,372,1"; break; // Gargoyle
				case 772: race = "" + val + ",8362,609,0"; break; // Abysmal Giant
				case 773: race = "" + val + ",8342,609,0"; break; // Cloud Giant
				case 433: race = "" + val + ",16474,609,0"; break; // Earth Giant
				case 774: race = "" + val + ",8321,609,0"; break; // Fire Giant
				case 264: race = "" + val + ",8325,609,0"; break; // Forest Giant
				case 777: race = "" + val + ",8326,609,0"; break; // Frost Giant
				case 325: race = "" + val + ",8365,609,0"; break; // Frost Giant
				case 725: race = "" + val + ",8350,609,0"; break; // Hill Giant
				case 726: race = "" + val + ",8350,609,0"; break; // Hill Giant
				case 771: race = "" + val + ",8367,609,0"; break; // Jungle Giant
				case 770: race = "" + val + ",8331,609,0"; break; // Sand Giant
				case 792: race = "" + val + ",16470,609,0"; break; // Sea Giant
				case 485: race = "" + val + ",8380,609,0"; break; // Stone Giant
				case 510: race = "" + val + ",8349,1269,0"; break; // Gnoll
				case 592: race = "" + val + ",25776,422,0"; break; // Goblin
				case 632: race = "" + val + ",16463,422,0"; break; // Goblin
				case 647: race = "" + val + ",16463,422,0"; break; // Goblin
				case 69: race = "" + val + ",8324,684,0"; break; // Flesh Golem
				case 999: race = "" + val + ",8323,684,0"; break; // Flesh Golem
				case 11: race = "" + val + ",16480,1114,0"; break; // Hobgoblin
				case 786: race = "" + val + ",8389,898,0"; break; // Mind Flayer
				case 202: race = "" + val + ",16486,594,0"; break; // Imp
				case 359: race = "" + val + ",25756,594,0"; break; // Imp
				case 176: race = "" + val + ",8351,1006,0"; break; // Kilrathi
				case 245: race = "" + val + ",16481,1347,0"; break; // Kobold
				case 253: race = "" + val + ",16481,1347,0"; break; // Kobold
				case 255: race = "" + val + ",16481,1347,0"; break; // Kobold
				case 78: race = "" + val + ",8371,1358,0"; break; // Minotaur
				case 263: race = "" + val + ",8370,1358,0"; break; // Minotaur
				case 280: race = "" + val + ",8370,1358,0"; break; // Minotaur
				case 281: race = "" + val + ",8370,1358,0"; break; // Minotaur
				case 357: race = "" + val + ",8369,1358,1"; break; // Minotaur
				case 650: race = "" + val + ",8368,1358,0"; break; // Minotaur
				case 154: race = "" + val + ",25757,471,0"; break; // Mummy
				case 601: race = "" + val + ",25758,1149,0"; break; // Mummy
				case 341: race = "" + val + ",8390,9999,0"; break; // Fungal
				case 342: race = "" + val + ",8391,9999,0"; break; // Fungal
				case 261: race = "" + val + ",16479,634,0"; break; // Naga
				case 704: race = "" + val + ",16465,644,1"; break; // Naga
				case 66: race = "" + val + ",16482,644,1"; break; // Naga
				case 1: race = "" + val + ",16468,427,0"; break; // Ogre
				case 428: race = "" + val + ",16461,427,0"; break; // Ogre
				case 303: race = "" + val + ",16469,427,0"; break; // Ogre
				case 7: race = "" + val + ",8352,1114,0"; break; // Orc
				case 17: race = "" + val + ",8352,1114,0"; break; // Orc
				case 41: race = "" + val + ",8352,1114,0"; break; // Orc
				case 108: race = "" + val + ",8354,1114,0"; break; // Orc
				case 182: race = "" + val + ",8353,1114,0"; break; // Orc
				case 328: race = "" + val + ",8355,1114,0"; break; // Orc
				case 65: race = "" + val + ",8354,1114,0"; break; // Orc
				case 20: race = "" + val + ",8381,1114,0"; break; // Urk
				case 157: race = "" + val + ",8382,1114,0"; break; // Urk
				case 252: race = "" + val + ",8381,1114,0"; break; // Urk
				case 758: race = "" + val + ",8330,163,0"; break; // Owlbear
				case 779: race = "" + val + ",25759,442,0"; break; // Shambler
				case 172: race = "" + val + ",16485,427,0"; break; // Swamp Thing
				case 534: race = "" + val + ",16455,417,0"; break; // Grathek
				case 33: race = "" + val + ",16456,417,0"; break; // Lizardman
				case 34: race = "" + val + ",16456,417,0"; break; // Lizardman
				case 35: race = "" + val + ",16456,417,0"; break; // Lizardman
				case 324: race = "" + val + ",16457,417,0"; break; // Sakkhra
				case 326: race = "" + val + ",16457,417,0"; break; // Sakkhra
				case 333: race = "" + val + ",16457,417,0"; break; // Sakkhra
				case 541: race = "" + val + ",16458,417,0"; break; // Sleestax
				case 768: race = "" + val + ",16464,1149,0"; break; // Revenant
				case 42: race = "" + val + ",16483,437,0"; break; // Ratman
				case 44: race = "" + val + ",16483,437,0"; break; // Ratman
				case 45: race = "" + val + ",16483,437,0"; break; // Ratman
				case 73: race = "" + val + ",16483,437,0"; break; // Ratman
				case 163: race = "" + val + ",16483,437,0"; break; // Ratman
				case 164: race = "" + val + ",16483,437,0"; break; // Ratman
				case 165: race = "" + val + ",16483,437,0"; break; // Ratman
				case 673: race = "" + val + ",16484,634,0"; break; // Salamander
				case 271: race = "" + val + ",16459,1414,0"; break; // Satyr
				case 86: race = "" + val + ",8374,634,0"; break; // Ophidian
				case 85: race = "" + val + ",8373,644,1"; break; // Ophidian
				case 87: race = "" + val + ",8373,644,1"; break; // Ophidian
				case 306: race = "" + val + ",8332,219,0"; break; // Serpyn
				case 145: race = "" + val + ",16466,634,0"; break; // Serpyn
				case 143: race = "" + val + ",16467,634,0"; break; // Serpyn
				case 144: race = "" + val + ",8372,644,1"; break; // Serpyn
				case 50: race = "" + val + ",25762,1165,0"; break; // Skeleton
				case 56: race = "" + val + ",25763,1165,0"; break; // Skeleton
				case 57: race = "" + val + ",25764,1165,0"; break; // Skeleton
				case 110: race = "" + val + ",25765,1001,0"; break; // Skeleton
				case 148: race = "" + val + ",25766,1001,0"; break; // Skeleton
				case 167: race = "" + val + ",25767,1165,0"; break; // Skeleton
				case 168: race = "" + val + ",25768,1165,0"; break; // Skeleton
				case 170: race = "" + val + ",25769,1165,0"; break; // Skeleton
				case 247: race = "" + val + ",25770,1165,0"; break; // Skeleton
				case 699: race = "" + val + ",25771,1165,0"; break; // Skeleton
				case 724: race = "" + val + ",25772,412,0"; break; // Skeleton
				case 24: race = "" + val + ",25773,412,0"; break; // Skeleton
				case 314: race = "" + val + ",8379,1640,0"; break; // Sphinx
				case 808: race = "" + val + ",8378,1640,0"; break; // Sphinx
				case 689: race = "" + val + ",8333,1200,1"; break; // Succubus
				case 149: race = "" + val + ",8334,1200,1"; break; // Succubus
				case 174: race = "" + val + ",8358,1200,1"; break; // Succubus
				case 76: race = "" + val + ",8359,609,0"; break; // Titan
				case 189: race = "" + val + ",8360,609,0"; break; // Titan
				case 156: race = "" + val + ",8335,461,0"; break; // Troll
				case 499: race = "" + val + ",8366,461,0"; break; // Troll
				case 53: race = "" + val + ",8361,461,0"; break; // Troll
				case 54: race = "" + val + ",8361,461,0"; break; // Troll
				case 439: race = "" + val + ",8361,461,0"; break; // Troll
				case 95: race = "" + val + ",8336,461,0"; break; // Troll
				case 124: race = "" + val + ",25774,1149,0"; break; // Vampyre
				case 125: race = "" + val + ",25775,1149,0"; break; // Vampyre
				case 311: race = "" + val + ",25777,1149,0"; break; // Vampyre
				case 3: race = "" + val + ",25778,471,0"; break; // Zombi
				case 181: race = "" + val + ",25779,471,0"; break; // Ghoul
				case 304: race = "" + val + ",25780,471,0"; break; // Sea Zombi
				case 305: race = "" + val + ",25781,471,0"; break; // Zombi Lord
				case 307: race = "" + val + ",25782,471,0"; break; // Wight
				case 728: race = "" + val + ",25778,471,0"; break; // Zombi
				case 810: race = "" + val + ",25783,471,0"; break; // Zombi Mage
			}

			return race;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( SpeciesBody );
			writer.Write( SpeciesItemID );
			writer.Write( SpeciesAngerSound );
			writer.Write( SpeciesIdleSound );
			writer.Write( SpeciesDeathSound );
			writer.Write( SpeciesAttackSound );
			writer.Write( SpeciesHurtSound );
			writer.Write( SpeciesGender );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			SpeciesBody = reader.ReadInt();
			SpeciesItemID = reader.ReadInt();
			SpeciesAngerSound = reader.ReadInt();
			SpeciesIdleSound = reader.ReadInt();
			SpeciesDeathSound = reader.ReadInt();
			SpeciesAttackSound = reader.ReadInt();
			SpeciesHurtSound = reader.ReadInt();
			SpeciesGender = reader.ReadInt();
		}

		public override bool DisplayLootType{ get{ return false; } }

		public int m_SpeciesBody;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesBody { get{ return m_SpeciesBody; } set{ m_SpeciesBody = value; } }

		public int m_SpeciesItemID;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesItemID { get{ return m_SpeciesItemID; } set{ m_SpeciesItemID = value; } }

		public int m_SpeciesAngerSound;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesAngerSound { get{ return m_SpeciesAngerSound; } set{ m_SpeciesAngerSound = value; } }

		public int m_SpeciesIdleSound;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesIdleSound { get{ return m_SpeciesIdleSound; } set{ m_SpeciesIdleSound = value; } }

		public int m_SpeciesDeathSound;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesDeathSound { get{ return m_SpeciesDeathSound; } set{ m_SpeciesDeathSound = value; } }

		public int m_SpeciesAttackSound;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesAttackSound { get{ return m_SpeciesAttackSound; } set{ m_SpeciesAttackSound = value; } }

		public int m_SpeciesHurtSound;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesHurtSound { get{ return m_SpeciesHurtSound; } set{ m_SpeciesHurtSound = value; } }

		public int m_SpeciesGender;
		[CommandProperty( AccessLevel.GameMaster )]
		public int SpeciesGender { get{ return m_SpeciesGender; } set{ m_SpeciesGender = value; } }
	}
}