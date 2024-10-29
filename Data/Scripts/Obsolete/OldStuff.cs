using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Engines.Plants;
using Server.Guilds;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Spells.Fifth;
using Server.Spells.First;
using Server.Spells.Fourth;
using Server.Spells.Second;
using Server.Spells.Seventh;
using Server.Spells.Sixth;
using Server.Spells.Third;
using Server.Spells;
using Server.Targeting;
using Server.Targets;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.Data.Odbc;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System;


namespace Server.Items
{
	public class TribalPaint : Item
	{
		public override int LabelNumber{ get{ return 1040000; } } // savage kin paint

		[Constructable]
		public TribalPaint() : base( 0x9EC )
		{
		}

		public TribalPaint( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
	public class TribalBerry : Item
	{
		[Constructable]
		public TribalBerry() : this( 1 )
		{
		}

		[Constructable]
		public TribalBerry( int amount ) : base( 0x9D0 )
		{
		}

		public TribalBerry( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}

	public class CharacterDatabase : Item
	{
		public Mobile CharacterOwner;
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Character_Owner { get{ return CharacterOwner; } set{ CharacterOwner = value; } }

		public int CharacterMOTD;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_MOTD { get { return CharacterMOTD; } set { CharacterMOTD = value; InvalidateProperties(); } }

		public int CharacterSkill;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Skill { get { return CharacterSkill; } set { CharacterSkill = value; InvalidateProperties(); } }

		public string CharacterKeys;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Keys { get { return CharacterKeys; } set { CharacterKeys = value; InvalidateProperties(); } }

		public string CharacterDiscovered;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Discovered { get { return CharacterDiscovered; } set { CharacterDiscovered = value; InvalidateProperties(); } }

		public int CharacterSheath;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Sheath { get { return CharacterSheath; } set { CharacterSheath = value; InvalidateProperties(); } }

		public int CharacterGuilds;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Guilds { get { return CharacterGuilds; } set { CharacterGuilds = value; InvalidateProperties(); } }

		public string CharacterBoatDoor;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_BoatDoor { get { return CharacterBoatDoor; } set { CharacterBoatDoor = value; InvalidateProperties(); } }

		public string CharacterPublicDoor;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_PublicDoor { get { return CharacterPublicDoor; } set { CharacterPublicDoor = value; InvalidateProperties(); } }

		public int CharacterBegging;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Begging { get { return CharacterBegging; } set { CharacterBegging = value; InvalidateProperties(); } }

		public int CharacterWepAbNames;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_WepAbNames { get { return CharacterWepAbNames; } set { CharacterWepAbNames = value; InvalidateProperties(); } }

		public int GumpHue;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Gump_Hue { get { return GumpHue; } set { GumpHue = value; InvalidateProperties(); } }

		public int WeaponBarOpen;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Weapon_yBarOpen { get { return WeaponBarOpen; } set { WeaponBarOpen = value; InvalidateProperties(); } }

		public string CharMusical;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Char_Musical { get{ return CharMusical; } set{ CharMusical = value; } }

		public string CharacterLoot;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Loot { get{ return CharacterLoot; } set{ CharacterLoot = value; } }

		public string CharacterWanted;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Wanted { get{ return CharacterWanted; } set{ CharacterWanted = value; } }

		public int CharacterOriental;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Oriental { get { return CharacterOriental; } set { CharacterOriental = value; InvalidateProperties(); } }

		public int CharacterEvil;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Evil { get { return CharacterEvil; } set { CharacterEvil = value; InvalidateProperties(); } }

		public int CharacterElement;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Element { get { return CharacterElement; } set { CharacterElement = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string MessageQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Message_Quest { get { return MessageQuest; } set { MessageQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string ArtifactQuestTime;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Artifact_QuestTime { get { return ArtifactQuestTime; } set { ArtifactQuestTime = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string StandardQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Standard_Quest { get { return StandardQuest; } set { StandardQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string FishingQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Fishing_Quest { get { return FishingQuest; } set { FishingQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string AssassinQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Assassin_Quest { get { return AssassinQuest; } set { AssassinQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string BardsTaleQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string BardsTale_Quest { get { return BardsTaleQuest; } set { BardsTaleQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string EpicQuestName;
		[CommandProperty( AccessLevel.GameMaster )]
		public string EpicQuest_Name { get{ return EpicQuestName; } set{ EpicQuestName = value; } }

		public int EpicQuestNumber;
		[CommandProperty( AccessLevel.GameMaster )]
		public int EpicQuest_Number { get { return EpicQuestNumber; } set { EpicQuestNumber = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string SpellBarsMage1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage1 { get { return SpellBarsMage1; } set { SpellBarsMage1 = value; InvalidateProperties(); } }

		public string SpellBarsMage2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage2 { get { return SpellBarsMage2; } set { SpellBarsMage2 = value; InvalidateProperties(); } }

		public string SpellBarsMage3;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage3 { get { return SpellBarsMage3; } set { SpellBarsMage3 = value; InvalidateProperties(); } }

		public string SpellBarsMage4;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage4 { get { return SpellBarsMage4; } set { SpellBarsMage4 = value; InvalidateProperties(); } }

		public string SpellBarsNecro1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Necro1 { get { return SpellBarsNecro1; } set { SpellBarsNecro1 = value; InvalidateProperties(); } }

		public string SpellBarsNecro2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Necro2 { get { return SpellBarsNecro2; } set { SpellBarsNecro2 = value; InvalidateProperties(); } }

		public string SpellBarsKnight1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Knight1 { get { return SpellBarsKnight1; } set { SpellBarsKnight1 = value; InvalidateProperties(); } }

		public string SpellBarsKnight2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Knight2 { get { return SpellBarsKnight2; } set { SpellBarsKnight2 = value; InvalidateProperties(); } }

		public string SpellBarsDeath1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Death1 { get { return SpellBarsDeath1; } set { SpellBarsDeath1 = value; InvalidateProperties(); } }

		public string SpellBarsDeath2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Death2 { get { return SpellBarsDeath2; } set { SpellBarsDeath2 = value; InvalidateProperties(); } }

		public string SpellBarsBard1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Bard1 { get { return SpellBarsBard1; } set { SpellBarsBard1 = value; InvalidateProperties(); } }

		public string SpellBarsBard2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Bard2 { get { return SpellBarsBard2; } set { SpellBarsBard2 = value; InvalidateProperties(); } }

		public string SpellBarsPriest1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Priest1 { get { return SpellBarsPriest1; } set { SpellBarsPriest1 = value; InvalidateProperties(); } }

		public string SpellBarsPriest2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Priest2 { get { return SpellBarsPriest2; } set { SpellBarsPriest2 = value; InvalidateProperties(); } }

		public string SpellBarsMonk1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Monk1 { get{ return SpellBarsMonk1; } set{ SpellBarsMonk1 = value; } }

		public string SpellBarsMonk2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Monk2 { get{ return SpellBarsMonk2; } set{ SpellBarsMonk2 = value; } }

		public string SpellBarsWizard1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard1 { get { return SpellBarsWizard1; } set { SpellBarsWizard1 = value; InvalidateProperties(); } }

		public string SpellBarsWizard2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard2 { get { return SpellBarsWizard2; } set { SpellBarsWizard2 = value; InvalidateProperties(); } }

		public string SpellBarsWizard3;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard3 { get { return SpellBarsWizard3; } set { SpellBarsWizard3 = value; InvalidateProperties(); } }

		public string SpellBarsElly1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Elly1 { get { return SpellBarsElly1; } set { SpellBarsElly1 = value; InvalidateProperties(); } }

		public string SpellBarsElly2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Elly2 { get { return SpellBarsElly2; } set { SpellBarsElly2 = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string ThiefQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Thief_Quest { get{ return ThiefQuest; } set{ ThiefQuest = value; } }

		public string KilledSpecialMonsters;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Killed_SpecialMonsters { get{ return KilledSpecialMonsters; } set{ KilledSpecialMonsters = value; } }

		public string MusicPlaylist;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Music_Playlist { get{ return MusicPlaylist; } set{ MusicPlaylist = value; } }

		public int CharacterBarbaric;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Conan { get { return CharacterBarbaric; } set { CharacterBarbaric = value; InvalidateProperties(); } }

		public int SkillDisplay;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Skill_Display { get { return SkillDisplay; } set { SkillDisplay = value; InvalidateProperties(); } }

		public int MagerySpellHue;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Magery_SpellHue { get { return MagerySpellHue; } set { MagerySpellHue = value; InvalidateProperties(); } }

		public int ClassicPoisoning;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Classic_Poisoning { get { return ClassicPoisoning; } set { ClassicPoisoning = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string QuickBar;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Quick_Bar { get { return QuickBar; } set { QuickBar = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[Constructable]
		public CharacterDatabase() : base( 0x3F1A )
		{
			LootType = LootType.Blessed;
			Visible = false;
			Movable = false;
			Weight = 1.0;
			Name = "Character Statue";
			Hue = 0;
		}

		public override bool DisplayLootType{ get{ return false; } }
		public override bool DisplayWeight{ get{ return false; } }

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( CharacterOwner != null ){ list.Add( 1070722, "Statue of " + CharacterOwner.Name + "" ); }
        }

		public CharacterDatabase( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)3 ); // version

			writer.Write( QuickBar );

			writer.Write( SpellBarsElly1 );
			writer.Write( SpellBarsElly2 );
			writer.Write( CharacterElement );

			writer.Write( (Mobile)CharacterOwner );
			writer.Write( CharacterMOTD );
			writer.Write( CharacterSkill );
			writer.Write( CharacterKeys );
			writer.Write( CharacterDiscovered );
			writer.Write( CharacterSheath );
			writer.Write( CharacterGuilds );
			writer.Write( CharacterBoatDoor );
			writer.Write( CharacterPublicDoor );
			writer.Write( CharacterBegging );
			writer.Write( CharacterWepAbNames );

			writer.Write( ArtifactQuestTime );

			writer.Write( StandardQuest );
			writer.Write( FishingQuest );
			writer.Write( AssassinQuest );
			writer.Write( MessageQuest );
			writer.Write( BardsTaleQuest );

			writer.Write( SpellBarsMage1 );
			writer.Write( SpellBarsMage2 );
			writer.Write( SpellBarsMage3 );
			writer.Write( SpellBarsMage4 );
			writer.Write( SpellBarsNecro1 );
			writer.Write( SpellBarsNecro2 );
			writer.Write( SpellBarsKnight1 );
			writer.Write( SpellBarsKnight2 );
			writer.Write( SpellBarsDeath1 );
			writer.Write( SpellBarsDeath2 );
			writer.Write( SpellBarsBard1 );
			writer.Write( SpellBarsBard2 );
			writer.Write( SpellBarsPriest1 );
			writer.Write( SpellBarsPriest2 );
			writer.Write( SpellBarsWizard1 );
			writer.Write( SpellBarsWizard2 );
			writer.Write( SpellBarsWizard3 );
			writer.Write( SpellBarsMonk1 );
			writer.Write( SpellBarsMonk2 );

			writer.Write( ThiefQuest );
			writer.Write( KilledSpecialMonsters );
			writer.Write( MusicPlaylist );
			writer.Write( CharacterWanted );
			writer.Write( CharacterLoot );
			writer.Write( CharMusical );
			writer.Write( EpicQuestName );
			writer.Write( CharacterBarbaric );
			writer.Write( SkillDisplay );
			writer.Write( MagerySpellHue );
			writer.Write( ClassicPoisoning );
			writer.Write( CharacterEvil );
			writer.Write( CharacterOriental );
			writer.Write( GumpHue );
			writer.Write( WeaponBarOpen );
			writer.Write( EpicQuestNumber );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			switch( version )
			{
				case 3:
				{
					QuickBar = reader.ReadString();
					goto case 2;
				}
				case 2:
				{
					SpellBarsElly1 = reader.ReadString();
					SpellBarsElly2 = reader.ReadString();
					CharacterElement = reader.ReadInt();
					goto case 1;
				}
				case 1:
				{
					CharacterOwner = reader.ReadMobile();
					CharacterMOTD = reader.ReadInt();
					CharacterSkill = reader.ReadInt();
					CharacterKeys = reader.ReadString();
					CharacterDiscovered = reader.ReadString();
					CharacterSheath = reader.ReadInt();
					CharacterGuilds = reader.ReadInt();
					CharacterBoatDoor = reader.ReadString();
					CharacterPublicDoor = reader.ReadString();
					CharacterBegging = reader.ReadInt();
					CharacterWepAbNames = reader.ReadInt();

					ArtifactQuestTime = reader.ReadString();

					StandardQuest = reader.ReadString();
					FishingQuest = reader.ReadString();
					AssassinQuest = reader.ReadString();
					MessageQuest = reader.ReadString();
					BardsTaleQuest = reader.ReadString();

					SpellBarsMage1 = reader.ReadString();
					SpellBarsMage2 = reader.ReadString();
					SpellBarsMage3 = reader.ReadString();
					SpellBarsMage4 = reader.ReadString();
					SpellBarsNecro1 = reader.ReadString();
					SpellBarsNecro2 = reader.ReadString();
					SpellBarsKnight1 = reader.ReadString();
					SpellBarsKnight2 = reader.ReadString();
					SpellBarsDeath1 = reader.ReadString();
					SpellBarsDeath2 = reader.ReadString();
					SpellBarsBard1 = reader.ReadString();
					SpellBarsBard2 = reader.ReadString();
					SpellBarsPriest1 = reader.ReadString();
					SpellBarsPriest2 = reader.ReadString();
					SpellBarsWizard1 = reader.ReadString();
					SpellBarsWizard2 = reader.ReadString();
					SpellBarsWizard3 = reader.ReadString();
					SpellBarsMonk1 = reader.ReadString();
					SpellBarsMonk2 = reader.ReadString();

					ThiefQuest = reader.ReadString();
					KilledSpecialMonsters = reader.ReadString();
					MusicPlaylist = reader.ReadString();
					CharacterWanted = reader.ReadString();
					CharacterLoot = reader.ReadString();
					CharMusical = reader.ReadString();
					EpicQuestName = reader.ReadString();
					CharacterBarbaric = reader.ReadInt();
					SkillDisplay = reader.ReadInt();
					MagerySpellHue = reader.ReadInt();
					ClassicPoisoning = reader.ReadInt();
					CharacterEvil = reader.ReadInt();
					CharacterOriental = reader.ReadInt();
					GumpHue = reader.ReadInt();
					WeaponBarOpen = reader.ReadInt();
					EpicQuestNumber = reader.ReadInt();
					break;
				}
			}
			Hue = 0;
			this.Delete();
		}
	}
}


namespace Server.Items
{
	public class SavageBook : DynamicBook
	{
		[Constructable]
		public SavageBook( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0x2253;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 73, this );
			SetStaticText( this );
			BookTitle = "The Savaged Empire";
			Name = BookTitle;
			BookAuthor = "Brom the Conquerer";
		}

		public SavageBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
			this.Delete();
		}
	}

	public class WelcomeBookWanted : DynamicBook
	{
		[Constructable]
		public WelcomeBookWanted( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0xFBE;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 60, this );
			SetStaticText( this );
			BookTitle = "Life of a Fugitive";
			Name = BookTitle;
			BookAuthor = "Seryl the Assassin";
		}

		public WelcomeBookWanted( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
			this.Delete();
		}
	}

	public class WelcomeBookElf : DynamicBook
	{
		[Constructable]
		public WelcomeBookElf( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0xFBE;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 64, this );
			SetStaticText( this );
			BookTitle = "Elven Lore";
			Name = BookTitle;
			BookAuthor = "Horance the Mage";
		}

		public WelcomeBookElf( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
			this.Delete();
		}
	}

	public class DoorTimeLord : Item
	{
		[Constructable]
		public DoorTimeLord() : base( 0x675 )
		{
			Name = "metal door";
			Weight = 1.0;
		}

		public DoorTimeLord( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if ( m.InRange( this.GetWorldLocation(), 2 ) && MySettings.S_AllowAlienChoice )
			{
				DoTeleport( m );
			}
			else if ( !MySettings.S_AllowAlienChoice )
			{
				m.SendMessage( "This door doesn't seem to budge." );
			}
			else
			{
				m.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public virtual void DoTeleport( Mobile m )
		{
			Point3D p = this.Location;

			if ( m.Y < this.Y ){ p = new Point3D(this.X, (this.Y+1), this.Z); }
			else if ( m.Y > this.Y ){ p = new Point3D(this.X, (this.Y-1), this.Z); }
			m.PlaySound( 0xEC );

			Server.Mobiles.BaseCreature.TeleportPets( m, p, m.Map );

			m.MoveToWorld( p, m.Map );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class AmethystWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public AmethystWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the amethyst wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "amethyst scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public AmethystWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dire wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : BaseCreature
	{
		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dire wolf";
			Body = 225;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = -2500;

			this.Delete();
VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 83.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override int Cloths{ get{ return 4; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public DireWolf(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			this.Delete();
		}
	}
}

namespace Server.Mobiles
{
	[CorpseName( "a nightmare corpse" )]
	public class AncientNightmare : BaseCreature
	{
		public override bool HasBreath{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public AncientNightmare() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ancient nightmare";
			Body = 795;
			BaseSoundID = 0xA8;

			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Psychology, 10.4, 50.0 );
			SetSkill( SkillName.Magery, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			this.Delete();
VirtualArmor = 60;

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 13, 19 ) ) );

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.LowPotions );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Hellish; } }
		public override int Cloths{ get{ return 5; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }

		public AncientNightmare( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}















// using Server;// using System;// using Server.Misc;// using Server.Mobiles;

namespace Server.Items
{
	public class AssassinShroud : BaseOuterTorso // OBSOLETE SEE SCHOLAR ROBE
	{
		[Constructable]
		public AssassinShroud() : this( 0 )
		{
		}

		[Constructable]
		public AssassinShroud( int hue ) : base( 0x2652, hue )
		{
			Name = "scholar robe";
			Weight = 3.0;
		}

		public AssassinShroud( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			if ( Name == "assassin shroud" ){ Name = "scholar robe"; }
			this.Delete();
		}
	}
}

namespace Server.Items
{
	public abstract class BasePigmentsOfIslesDread : Item, IUsesRemaining
	{
		public override int LabelNumber { get { return 1070933; } } // Pigments of IslesDread
		
		private int m_UsesRemaining;
		private TextDefinition m_Label;
		
		protected TextDefinition Label 
		{ 
			get { return m_Label; }
			set { m_Label = value; InvalidateProperties(); }
		}
		
		#region Old Item Serialization Vars
		/* DO NOT USE! Only used in serialization of pigments that originally derived from Item */
		private bool m_InheritsItem;
		
		protected bool InheritsItem
		{ 
			get{ return m_InheritsItem; } 
		}
		#endregion

		public BasePigmentsOfIslesDread() : base( 0xEFF )
		{
			Weight = 1.0;
			m_UsesRemaining = 1;
		}
		
		public BasePigmentsOfIslesDread(  int uses ) : base( 0xEFF )
		{
			Weight = 1.0;
			m_UsesRemaining = uses;
		}
		
		public BasePigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( IsAccessibleTo( from ) && from.InRange( GetWorldLocation(), 3 ) )
			{
				from.SendLocalizedMessage( 1070929 ); // Select the artifact or enhanced magic item to dye.
				from.BeginTarget( 3, false, Server.Targeting.TargetFlags.None, new TargetStateCallback( InternalCallback ), this );
			}
			else
				from.SendLocalizedMessage( 502436 ); // That is not accessible.
		}
		
		private void InternalCallback( Mobile from, object targeted, object state )
		{
			BasePigmentsOfIslesDread pigment = (BasePigmentsOfIslesDread)state;

			if( pigment.Deleted || pigment.UsesRemaining <= 0 || !from.InRange( pigment.GetWorldLocation(), 3 ) || !pigment.IsAccessibleTo( from ))
				return;

			Item i = targeted as Item;

			if( i == null )
				from.SendLocalizedMessage( 1070931 ); // You can only dye artifacts and enhanced magic items with this tub.
			else if( !from.InRange( i.GetWorldLocation(), 3 ) || !IsAccessibleTo( from ) )
				from.SendLocalizedMessage( 502436 ); // That is not accessible.
			else if( from.Items.Contains( i ) )
				from.SendLocalizedMessage( 1070930 ); // Can't dye artifacts or enhanced magic items that are being worn.
			else if( i.IsLockedDown )
				from.SendLocalizedMessage( 1070932 ); // You may not dye artifacts and enhanced magic items which are locked down.
			else if( i is MetalPigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( i is LesserPigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( i is PigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( !IsValidItem( i ) )
				from.SendLocalizedMessage( 1070931 ); // You can only dye artifacts and enhanced magic items with this tub.	//Yes, it says tub on OSI.  Don't ask me why ;p
			else
			{
				//Notes: on OSI there IS no hue check to see if it's already hued.  and no messages on successful hue either
				i.Hue = Hue;

				if( --pigment.UsesRemaining <= 0 )
					pigment.Delete();

				from.PlaySound(0x23E); // As per OSI TC1
			}
		}
		
		public static bool IsValidItem( Item i )
		{
			if( i is BasePigmentsOfIslesDread )
				return false;

			Type t = i.GetType();

			CraftResource resource = CraftResource.None;

			if( i is BaseWeapon )
				resource = ((BaseWeapon)i).Resource;
			else if( i is BaseArmor )
				resource = ((BaseArmor)i).Resource;
			else if (i is BaseClothing)
				resource = ((BaseClothing)i).Resource;

			return false;
		}  

		private static bool IsInTypeList( Type t, Type[] list )
		{
			for( int i = 0; i < list.Length; i++ )
			{
				if( list[i] == t ) return true;
			}

			return false;
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( m_UsesRemaining );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 1: 
				{
					m_UsesRemaining = reader.ReadEncodedInt();
					break;
				}
				case 0: // Old pigments that inherited from item
				{
					m_InheritsItem = true;
					
					if ( this is LesserPigmentsOfIslesDread )
						((LesserPigmentsOfIslesDread)this).Type = (LesserPigmentType)reader.ReadEncodedInt();
					else if ( this is PigmentsOfIslesDread )
						((PigmentsOfIslesDread)this).Type = (PigmentType)reader.ReadEncodedInt();
					else if ( this is MetalPigmentsOfIslesDread )
						reader.ReadEncodedInt();
					
					m_UsesRemaining = reader.ReadEncodedInt();
					
					break;
				}
			}
			this.Delete();

			
		}
		
		#region IUsesRemaining Members

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		public bool ShowUsesRemaining
		{
			get { return true; }
			set {}
		}
		
		#endregion
	}
}// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.ContextMenus;























// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlackDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public BlackDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black dragon";
			Body = 12;
			Hue = 0x966;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Black", "", c, 25, 0 );
				}
			}
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Black ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public BlackDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Spells;


// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlueDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 13 ); }

		[Constructable]
		public BlueDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a blue dragon";
			Body = 12;
			Hue = 0x1F4;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Energy, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Fire, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Blue", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public BlueDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;


// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bullradon corpse" )]
	public class Bullradon : BaseCreature
	{
		[Constructable]
		public Bullradon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a bullradon";
			Body = 0x11C;

			SetStr( 146, 175 );
			SetDex( 111, 150 );
			SetInt( 46, 60 );

			SetHits( 131, 160 );
			SetMana( 0 );

			SetDamage( 6, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 70 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 40, 60 );
			SetResistance( ResistanceType.Energy, 30, 50 );

			SetSkill( SkillName.MagicResist, 37.6, 42.5 );
			SetSkill( SkillName.Tactics, 70.6, 83.0 );
			SetSkill( SkillName.FistFighting, 50.1, 57.5 );

			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 68.7;
		}

		public override int GetAngerSound()
		{
			return 0x4F8;
		}

		public override int GetIdleSound()
		{
			return 0x4F7;
		}

		public override int GetAttackSound()
		{
			return 0x4F6;
		}

		public override int GetHurtSound()
		{
			return 0x4F9;
		}

		public override int GetDeathSound()
		{
			return 0x4F5;
		}

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public Bullradon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			Body = 0x11C;
			this.Delete();
		}
	}
}// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;

// using System;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a cave bear corpse" )]
	public class CaveBear : BaseCreature
	{
		[Constructable]
		public CaveBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a cave bear";
			Body = 190;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			this.Delete();
VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public CaveBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;




namespace Server.Mobiles
{
	[CorpseName( "a dark unicorn corpse" )]
	public class DarkUnicorn : BaseCreature
	{
		[Constructable]
		public DarkUnicorn() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark unicorn";
			Body = 27;
			BaseSoundID = 0xA8;

			SetStr( 596, 625 );
			SetDex( 186, 205 );
			SetInt( 186, 225 );

			SetHits( 398, 415 );

			SetDamage( 22, 28 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Psychology, 30.4, 70.0 );
			SetSkill( SkillName.Magery, 30.4, 70.0 );
			SetSkill( SkillName.MagicResist, 105.3, 120.0 );
			SetSkill( SkillName.Tactics, 117.6, 120.0 );
			SetSkill( SkillName.FistFighting, 100.5, 112.5 );

			Fame = 19000;
			Karma = -19000;

			this.Delete();
VirtualArmor = 70;

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.LowPotions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override int Cloths{ get{ return 5; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }

		public DarkUnicorn( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;

			this.Delete();
		}
	}
}
// using System;// using System.Threading;// using System.Collections;// using System.Data;// using System.Data.Odbc;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DeepSeaDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public DeepSeaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sea wyrm";
			Body = MyServerSettings.WyrmBody();
			Hue = 1365;
			BaseSoundID = 362;
			CanSwim = true;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;

			this.Delete();
VirtualArmor = 60;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H

		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override MeatType MeatType{ get{ return MeatType.Fish; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Spined; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DeepSeaDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DesertWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 50; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x96D; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } }
		public override int BreathEffectSound{ get{ return 0x654; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 8 ); }

		[Constructable]
		public DesertWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the desert wyrm";
			BaseSoundID = 362;
			Hue = 1719;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Yellow; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DesertWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;



















namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class Dragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public Dragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a red dragon";
			Body = 59;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Red", "", c, 25, 0x845 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Dragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBlackBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderBlackBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder black bear";
			Body = 177;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			this.Delete();
VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderBlackBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBrownBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderBrownBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder brown bear";
			Body = 23;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			this.Delete();
VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderBrownBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			Body = 23;
			this.Delete();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderPolarBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderPolarBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder polar bear";
			Body = 179;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			this.Delete();
VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Wooly; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderPolarBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using System.Net;// using System.Collections;// using Server;// using Server.Mobiles;// using System.Collections.Generic;




namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class EmeraldWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public EmeraldWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the emerald wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "emerald scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public EmeraldWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Network;



















namespace Server.Items
{
	public class EnchantedSextant : Item
	{
		//TODO: Sosaria/Haven
		private static readonly Point2D[] m_SosariaBanks = new Point2D[]
			{
				new Point2D( 652, 820 ),
				new Point2D( 1813, 2825 ),
				new Point2D( 3734, 2149 ),
				new Point2D( 2503, 552 ),
				new Point2D( 3764, 1317 ),
				new Point2D( 587, 2146 ),
				new Point2D( 1655, 1606 ),
				new Point2D( 1425, 1690 ),
				new Point2D( 4471, 1156 ),
				new Point2D( 1317, 3773 ),
				new Point2D( 2881, 684 ),
				new Point2D( 2731, 2192 ),
				new Point2D( 3620, 2617 ),
				new Point2D( 2880, 3472 ),
				new Point2D( 1897, 2684 ),
				new Point2D( 5346, 74 ),
				new Point2D( 5275, 3977 ),
				new Point2D( 5669, 3131 )
			};

		private static readonly Point2D[] m_LodorBanks = new Point2D[]
			{
				new Point2D( 652, 820 ),
				new Point2D( 1813, 2825 ),
				new Point2D( 3734, 2149 ),
				new Point2D( 2503, 552 ),
				new Point2D( 3764, 1317 ),
				new Point2D( 3695, 2511 ),
				new Point2D( 587, 2146 ),
				new Point2D( 1655, 1606 ),
				new Point2D( 1425, 1690 ),
				new Point2D( 4471, 1156 ),
				new Point2D( 1317, 3773 ),
				new Point2D( 2881, 684 ),
				new Point2D( 2731, 2192 ),
				new Point2D( 2880, 3472 ),
				new Point2D( 1897, 2684 ),
				new Point2D( 5346, 74 ),
				new Point2D( 5275, 3977 ),
				new Point2D( 5669, 3131 )
			};

		private static readonly Point2D[] m_UnderworldBanks = new Point2D[]
			{
				new Point2D( 854, 680 ),
				new Point2D( 855, 603 ),
				new Point2D( 1226, 554 ),
				new Point2D( 1610, 556 )
			};

		private static readonly Point2D[] m_SerpentIslandBanks = new Point2D[]
			{
				new Point2D( 996, 519 ),
				new Point2D( 2048, 1345 )
			};

		private const double m_LongDistance = 300.0;
		private const double m_ShortDistance = 5.0;

		public override int LabelNumber { get { return 1046226; } } // an enchanted sextant

		[Constructable]
		public EnchantedSextant() : base( 0x1058 )
		{
			Weight = 2.0;
		}

		public EnchantedSextant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class GarnetWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public GarnetWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the garnet wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "garnet scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public GarnetWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server.Commands;// using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class GlowBeetle : BaseCreature
	{
		[Constructable]
		public GlowBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a glow beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;

			SetStr( 156, 180 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 110, 150 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 90, 100 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 4000;
			Karma = -4000;

			this.Delete();
VirtualArmor = 26;

			AddItem( new LighterSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( Utility.RandomMinMax( 1, 4 ) == 1 )
			{
				int goo = 0;

				foreach ( Item splash in this.GetItemsInRange( 10 ) ){ if ( splash is MonsterSplatter && splash.Name == "glowing goo" ){ goo++; } }

				if ( goo == 0 )
				{
					MonsterSplatter.AddSplatter( this.X, this.Y, this.Z, this.Map, this.Location, this, "glowing goo", 0xB93, 1 );
				}
			}
		}

		public GlowBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;



















namespace Server.Mobiles
{
	[CorpseName( "a gorceratops corpse" )]
	public class Gorceratops : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Gorceratops () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorceratops";
			Body = 0x11C;
			BaseSoundID = 0x4F5;
			Hue = Utility.RandomList( 0x7D7, 0x7D8, 0x7D9, 0x7DA, 0x7DB, 0x7DC );

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			this.Delete();
VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 63.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Scales{ get{ return 4; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Gorceratops( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;



















namespace Server.Mobiles
{
	[CorpseName( "a gorgon corpse" )]
	public class Gorgon : BaseCreature
	{
		[Constructable]
		public Gorgon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorgon";
			Body = 0x11C;
			BaseSoundID = 362;
			Hue = 0x961;

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			this.Delete();
VirtualArmor = 40;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public void TurnStone()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;

				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}

			foreach ( Mobile m in list )
			{
				DoHarmful( m );

				m.PlaySound(0x16B);
				m.FixedEffect(0x376A, 6, 1);

				int duration = Utility.RandomMinMax(4, 8);
				m.Paralyze(TimeSpan.FromSeconds(duration));

				m.SendMessage( "You are petrified from the gorgon breath!" );
			}
		}

		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );

			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iStone = Server.Items.HiddenTrap.GetMyItem( m );

				if ( iStone != null )
				{
					if ( m.CheckSkill( SkillName.MagicResist, 0, 100 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iStone, m ) )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The gorgon almost turned one of your protected items to stone!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "One of your items has been turned to stone!");
						m.PlaySound( 0x1FB );
						Item rock = new BrokenGear();
						rock.ItemID = iStone.GraphicID;
						rock.Hue = 2101;
						rock.Weight = iStone.Weight * 3;
						rock.Name = "useless stone";
						iStone.Delete();
						m.AddToBackpack ( rock );
					}
				}
			}

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public Gorgon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;



















namespace Server.Items
{
	public class DarkenedSky : Kama
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070966; } } // Darkened Sky

		[Constructable]
		public DarkenedSky() : base()
		{
			WeaponAttributes.HitLightning = 60;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 50;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = pois = chaos = direct = 0;
			cold = nrgy = 50;
		}

		public DarkenedSky( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

	}

	public class KasaOfTheRajin : Kasa
	{
		public override int LabelNumber { get { return 1070969; } } // Kasa of the Raj-in

		public override int BasePhysicalResistance { get { return 12; } }
		public override int BaseFireResistance { get { return 17; } }
		public override int BaseColdResistance { get { return 21; } }
		public override int BasePoisonResistance { get { return 17; } }
		public override int BaseEnergyResistance { get { return 17; } }

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public KasaOfTheRajin() : base()
		{
			Attributes.SpellDamage = 12;
		}

		public KasaOfTheRajin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();

			if ( version <= 1 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}

			if( version == 0 )
				LootType = LootType.Regular;
		}

	}

	public class RuneBeetleCarapace : PlateDo
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber{ get{ return 1070968; } } // Rune Beetle Carapace

		public override int BaseColdResistance { get { return 14; } }
		public override int BaseEnergyResistance { get { return 14; } }

		[Constructable]
		public RuneBeetleCarapace() : base()
		{
			Attributes.BonusMana = 10;
			Attributes.RegenMana = 3;
			Attributes.LowerManaCost = 15;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public RuneBeetleCarapace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

	}

	public class Stormgrip : LeatherNinjaMitts
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber{ get{ return 1070970; } } // Stormgrip

		public override int BasePhysicalResistance { get { return 10; } }
		public override int BaseColdResistance { get { return 18; } }
		public override int BaseEnergyResistance { get { return 18; } }

		[Constructable]
		public Stormgrip() : base()
		{
			Attributes.BonusInt = 8;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 25;
		}

		public Stormgrip( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

	}

	public class SwordOfTheStampede : NoDachi
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070964; } } // Sword of the Stampede

		[Constructable]
		public SwordOfTheStampede() : base()
		{
			WeaponAttributes.HitHarm = 100;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 60;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = pois = nrgy = chaos = direct = 0;
			cold = 100;
		}

		public SwordOfTheStampede( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

	}

	public class SwordsOfProsperity : Daisho
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070963; } } // Swords of Prosperity

		[Constructable]
		public SwordsOfProsperity() : base()
		{
			WeaponAttributes.MageWeapon = 30;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.Luck = 200;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public SwordsOfProsperity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

	}

	public class TheHorselord : Yumi
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070967; } } // The Horselord

		[Constructable]
		public TheHorselord() : base()
		{
			Attributes.BonusDex = 5;
			Attributes.RegenMana = 1;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 50;

			Slayer = SlayerName.ElementalBan;
			Slayer2 = SlayerName.ReptilianDeath;
		}

		public TheHorselord( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}
	}

	public class TomeOfLostKnowledge : Spellbook
	{
		public override int LabelNumber { get { return 1070971; } } // Tome of Lost Knowledge

		[Constructable]
		public TomeOfLostKnowledge() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x530;

			SkillBonuses.SetValues( 0, SkillName.Magery, 15.0 );
			Attributes.BonusInt = 8;
			Attributes.LowerManaCost = 15;
			Attributes.SpellDamage = 15;
		}

		public TomeOfLostKnowledge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}
	}

	public class WindsEdge : Tessen
	{
		public override int LabelNumber { get { return 1070965; } } // Wind's Edge

		[Constructable]
		public WindsEdge() : base()
		{
			WeaponAttributes.HitLeechMana = 40;

			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 50;
			Attributes.DefendChance = 10;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}

		public WindsEdge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public enum PigmentType
	{
		None,
		ParagonGold,
		VioletCouragePurple,
		InvulnerabilityBlue,
		LunaWhite,
		DryadGreen,
		ShadowDancerBlack,
		BerserkerRed,
		NoxGreen,
		RumRed,
		FireOrange,
		FadedCoal,
		Coal,
		FadedGold,
		StormBronze,
		Rose,
		MidnightCoal,
		FadedBronze,
		FadedRose,
		DeepRose
	}

	public class PigmentsOfIslesDread : BasePigmentsOfIslesDread
	{
		private static int[][] m_Table = new int[][]
		{
			// Hue, Label
			new int[]{ /*PigmentType.None,*/ 0, -1 },
			new int[]{ /*PigmentType.ParagonGold,*/ 0x501, 1070987 },
			new int[]{ /*PigmentType.VioletCouragePurple,*/ 0x486, 1070988 },
			new int[]{ /*PigmentType.InvulnerabilityBlue,*/ 0x4F2, 1070989 },
			new int[]{ /*PigmentType.LunaWhite,*/ 0x47E, 1070990 },
			new int[]{ /*PigmentType.DryadGreen,*/ 0x48F, 1070991 },
			new int[]{ /*PigmentType.ShadowDancerBlack,*/ 0x455, 1070992 },
			new int[]{ /*PigmentType.BerserkerRed,*/ 0x21, 1070993 },
			new int[]{ /*PigmentType.NoxGreen,*/ 0x58C, 1070994 },
			new int[]{ /*PigmentType.RumRed,*/ 0x66C, 1070995 },
			new int[]{ /*PigmentType.FireOrange,*/ 0x54F, 1070996 },
			new int[]{ /*PigmentType.Fadedcoal,*/ 0x96A, 1079579 },
			new int[]{ /*PigmentType.Coal,*/ 0x96B, 1079580 },
			new int[]{ /*PigmentType.FadedGold,*/ 0x972, 1079581 },
			new int[]{ /*PigmentType.StormBronze,*/ 0x977, 1079582 },
			new int[]{ /*PigmentType.Rose,*/ 0x97C, 1079583 },
			new int[]{ /*PigmentType.MidnightCoal,*/ 0x96C, 1079584 },
			new int[]{ /*PigmentType.FadedBronze,*/ 0x975, 1079585 },
			new int[]{ /*PigmentType.FadedRose,*/ 0x97B, 1079586 },
			new int[]{ /*PigmentType.DeepRose,*/ 0x97E, 1079587 }
		};
		
		public static int[] GetInfo( PigmentType type )
		{
			int v = (int)type;

			if( v < 0 || v >= m_Table.Length )
				v = 0;
			
			return m_Table[v];
		}

		private PigmentType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public PigmentType Type
		{
			get { return m_Type; }
			set
			{
				m_Type = value;
				
				int v = (int)m_Type;

				if ( v >= 0 && v < m_Table.Length )
				{
					Hue = m_Table[v][0];
					Label = m_Table[v][1];
				}
				else
				{
					Hue = 0;
					Label = -1;
				}
			}
		}
		
		public override int LabelNumber { get { return 1070933; } } // Pigments of IslesDread

		[Constructable]
		public PigmentsOfIslesDread() : this( PigmentType.None, 10 )
		{
		}

		[Constructable]
		public PigmentsOfIslesDread( PigmentType type ) : this( type, (type == PigmentType.None||type >= PigmentType.FadedCoal)? 10 : 50 )
		{
		}

		[Constructable]
		public PigmentsOfIslesDread( PigmentType type, int uses ) : base( uses )
		{
			Weight = 1.0;
			Type = type;
		}

		public PigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( (int)m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion
			
			switch ( version )
			{
				case 1: Type = (PigmentType)reader.ReadEncodedInt(); break;
				case 0: break;
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;



















namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class GreenDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public GreenDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a green dragon";
			Body = 12;
			Hue = 2001;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Green", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public GreenDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server.Items;// using Server.Targeting;



















namespace Server.Mobiles
{
	[CorpseName( "a griffon corpse" )]
	public class Griffon : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Griffon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a griffon";
			Body = 0x31F;
			BaseSoundID = 0x2EE;

			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );

			SetHits( 158, 172 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 3500;
			Karma = 3500;

			this.Delete();
VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }

		public Griffon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();
			Body = 0x31F;
		}
	}
}
// using System;// using Server.Mobiles;



















namespace Server.Mobiles
{
	[CorpseName( "a grizzly bear corpse" )]
	[TypeAlias( "Server.Mobiles.Grizzlybear" )]
	public class GrizzlyBear : BaseCreature
	{
		[Constructable]
		public GrizzlyBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a grizzly bear";
			Body = 212;
			BaseSoundID = 0xA3;

			SetStr( 126, 155 );
			SetDex( 81, 105 );
			SetInt( 16, 40 );

			SetHits( 76, 93 );
			SetMana( 0 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 45.1, 70.0 );

			Fame = 1000;
			Karma = 0;

			this.Delete();
VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public GrizzlyBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();

			int version = reader.ReadInt();
		}
	}
}

namespace Server.Mobiles
{
	[CorpseName( "a hippogriff corpse" )]
	public class Hippogriff : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Hippogriff() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hippogriff";
			Body = 188;
			BaseSoundID = 0x2EE;

			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );

			SetHits( 158, 172 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 3500;
			Karma = 3500;

			this.Delete();
VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }

		public Hippogriff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			Body = 188;
			this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class IceDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public IceDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ice wyrm";
			Body = 46;
			Hue = 1154;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;

			AddItem( new LighterSource() );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "ice scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public IceDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class JungleWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public JungleWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the jungle wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();
			Hue = 0x7D1;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Green; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public JungleWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class LavaDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public LavaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the fire wyrm";
			Body = MyServerSettings.WyrmBody();
			Hue = 0xB71;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public LavaDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();
			int version = reader.ReadInt();
			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using System.Collections;


namespace Server.Items
{
	public class AncientFarmersKasa : Kasa
	{
		public override int LabelNumber{ get{ return 1070922; } } // Ancient Farmer's Kasa
		public override int BaseColdResistance { get { return 19; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get { return 255; } }

		[Constructable]
		public AncientFarmersKasa() : base()
		{
			Attributes.BonusStr = 5;
			Attributes.BonusStam = 5;
			Attributes.RegenStam = 5;

			SkillBonuses.SetValues( 0, SkillName.Druidism, 5.0 );
		}

		public AncientFarmersKasa( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();

			if ( version <= 1 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}

			if( version == 0 )
				SkillBonuses.SetValues( 0, SkillName.Druidism, 5.0 );
		}
	}

	public class AncientSamuraiDo : PlateDo 
	{
		public override int LabelNumber { get { return 1070926; } } // Ancient Samurai Do

		public override int BasePhysicalResistance { get { return 15; } }
		public override int BaseFireResistance { get { return 12; } }
		public override int BaseColdResistance { get { return 10; } }
		public override int BasePoisonResistance { get { return 11; } }
		public override int BaseEnergyResistance { get { return 8; } }

		[Constructable]
		public AncientSamuraiDo() : base()
		{
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
			SkillBonuses.SetValues( 0, SkillName.Parry, 10.0 );
		}

		public AncientSamuraiDo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class ArmsOfTacticalExcellence : LeatherHiroSode
	{
		public override int LabelNumber { get { return 1070921; } } // Arms of Tactical Excellence

		public override int BaseFireResistance { get { return 9; } }
		public override int BaseColdResistance { get { return 13; } }
		public override int BasePoisonResistance { get { return 8; } }

		[Constructable]
		public ArmsOfTacticalExcellence() : base()
		{
			Attributes.BonusDex = 5;
			SkillBonuses.SetValues( 0, SkillName.Tactics, 12.0 );
		}

		public ArmsOfTacticalExcellence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class BlackLotusHood : ClothNinjaHood
	{
		public override int LabelNumber { get { return 1070919; } } // Black Lotus Hood

		public override int BasePhysicalResistance { get { return 0; } }
		public override int BaseFireResistance { get { return 11; } }
		public override int BaseColdResistance { get { return 15; } }
		public override int BasePoisonResistance { get { return 11; } }
		public override int BaseEnergyResistance { get { return 11; } }

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public BlackLotusHood() : base()
		{
			Attributes.LowerManaCost = 6;
			Attributes.AttackChance = 6;
			ClothingAttributes.SelfRepair = 5;
		}

		public BlackLotusHood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();

			if ( version == 0 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}
		}
	}

	public class DaimyosHelm : PlateBattleKabuto
	{
		public override int LabelNumber { get { return 1070920; } } // Daimyo's Helm

		public override int BaseColdResistance { get { return 10; } }

		[Constructable]
		public DaimyosHelm() : base()
		{
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.SelfRepair = 3;
			Attributes.WeaponSpeed = 10;
		}

		public DaimyosHelm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class DemonForks : Sai
	{
		public override int LabelNumber{ get{ return 1070917; } } // Demon Forks

		[Constructable]
		public DemonForks() : base()
		{
			WeaponAttributes.ResistFireBonus = 10;
			WeaponAttributes.ResistPoisonBonus = 10;

			Attributes.ReflectPhysical = 10;
			Attributes.WeaponDamage = 35;
			Attributes.DefendChance = 10;
		}

		public DemonForks( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class DragonNunchaku : Nunchaku
	{
		public override int LabelNumber{ get{ return 1070914; } } // Dragon Nunchaku

		[Constructable]
		public DragonNunchaku() : base()
		{
			WeaponAttributes.ResistFireBonus = 5;
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitFireball = 50;

			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
		}

		public DragonNunchaku( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class Exiler : Tetsubo
	{
		public override int LabelNumber{ get{ return 1070913; } } // Exiler

		[Constructable]
		public Exiler() : base()
		{
			WeaponAttributes.HitDispel = 33;
			Slayer = SlayerName.Exorcism;

			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;

			nrgy = 100;
		}

		public Exiler( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class GlovesOfTheSun : LeatherNinjaMitts
	{
		public override int LabelNumber { get { return 1070924; } } // Gloves of the Sun

		public override int BaseFireResistance { get { return 24; } }

		[Constructable]
		public GlovesOfTheSun() : base()
		{
			Attributes.RegenHits = 2;
			Attributes.NightSight = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 18;
		}

		public GlovesOfTheSun( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class HanzosBow : Yumi
	{
		public override int LabelNumber { get { return 1070918; } } // Hanzo's Bow

		[Constructable]
		public HanzosBow() : base()
		{
			WeaponAttributes.HitLeechHits = 40;
			WeaponAttributes.SelfRepair = 3;

			Attributes.WeaponDamage = 50;

			SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10 );
		}

		public HanzosBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class LegsOfStability : PlateSuneate
	{
		public override int LabelNumber { get { return 1070925; } } // Legs of Stability

		public override int BasePhysicalResistance { get { return 20; } }
		public override int BasePoisonResistance { get { return 18; } }

		[Constructable]
		public LegsOfStability() : base()
		{
			Attributes.BonusStam = 5;

			ArmorAttributes.SelfRepair = 3;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public LegsOfStability( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class PeasantsBokuto : Bokuto
	{
		public override int LabelNumber { get { return 1070912; } } // Peasant's Bokuto

		[Constructable]
		public PeasantsBokuto() : base()
		{
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitLowerDefend = 30;

			Attributes.WeaponDamage = 35;
			Attributes.WeaponSpeed = 10;
			Slayer = SlayerName.SnakesBane;
		}

		public PeasantsBokuto( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class PilferedDancerFans : Tessen
	{
		public override int LabelNumber { get { return 1070916; } } // Pilfered Dancer Fans

		[Constructable]
		public PilferedDancerFans() : base()
		{
			Attributes.WeaponDamage = 20;
			Attributes.WeaponSpeed = 20;
			Attributes.CastRecovery = 2;
			Attributes.DefendChance = 5;
			Attributes.SpellChanneling = 1;
		}

		public PilferedDancerFans( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class TheDestroyer : NoDachi
	{
		public override int LabelNumber { get { return 1070915; } } // The Destroyer

		[Constructable]
		public TheDestroyer() : base()
		{
			WeaponAttributes.HitLeechStam = 40;

			Attributes.BonusStr = 6;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 50;
		}

		public TheDestroyer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class TomeOfEnlightenment : Spellbook
	{
		public override int LabelNumber { get { return 1070934; } } // Tome of Enlightenment

		[Constructable]
		public TomeOfEnlightenment() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x455;

			Attributes.BonusInt = 5;
			Attributes.SpellDamage = 10;
			Attributes.CastSpeed = 1;
		}

		public TomeOfEnlightenment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}
	}
	
	public class LeurociansMempoOfFortune : LeatherMempo
	{
		public override int LabelNumber { get { return 1071460; } } // Leurocian's mempo of fortune

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 15; } }
		
		[Constructable]
		public LeurociansMempoOfFortune() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x501;

			Attributes.Luck = 300;
			Attributes.RegenMana = 1;
		}

		public LeurociansMempoOfFortune( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	//Non weapon/armor ones:

	public class AncientUrn : Item
	{
		private static string[] m_Names = new string[]
			{
				"Akira",
				"Avaniaga",
				"Aya",
				"Chie",
				"Emiko",
				"Fumiyo",
				"Gennai",
				"Gennosuke", 
				"Genjo",
				"Hamato",
				"Harumi",
				"Ikuyo",
				"Juri",
				"Kaori",
				"Kaoru",
				"Kiyomori",
				"Mayako",
				"Motoki",
				"Musashi",
				"Nami",
				"Nobukazu",
				"Roku",
				"Romi",
				"Ryo",
				"Sanzo",
				"Sakamae",
				"Satoshi",
				"Takamori",
				"Takuro",
				"Teruyo",
				"Toshiro",
				"Yago",
				"Yeijiro",
				"Yoshi",
				"Zeshin"
			};

		public static string[] Names { get { return m_Names; } }

		private string m_UrnName;

		[CommandProperty( AccessLevel.GameMaster )]
		public string UrnName
		{
			get { return m_UrnName; }
			set { m_UrnName = value; }
		}

		public override int LabelNumber { get { return 1071014; } } // Ancient Urn

		[Constructable]
		public AncientUrn( string urnName ) : base( 0x241D )
		{
			m_UrnName = urnName;
			Weight = 1.0;
		}

		[Constructable]
		public AncientUrn() : this( m_Names[Utility.Random( m_Names.Length )] )
		{
		}

		public AncientUrn( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
			writer.Write( m_UrnName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			m_UrnName = reader.ReadString();

			Utility.Intern( ref m_UrnName );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1070935, m_UrnName ); // Ancient Urn of ~1_name~
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, 1070935, m_UrnName ); // Ancient Urn of ~1_name~
		}

	}

	public class HonorableSwords : Item
	{
		private string m_SwordsName;

		[CommandProperty( AccessLevel.GameMaster )]
		public string SwordsName
		{
			get { return m_SwordsName; }
			set { m_SwordsName = value; }
		}

		public override int LabelNumber { get { return 1071015; } } // Honorable Swords

		[Constructable]
		public HonorableSwords( string swordsName ) : base( 0x2853 )
		{
			m_SwordsName = swordsName;

			Weight = 5.0;
		}

		[Constructable]
		public HonorableSwords() : this( AncientUrn.Names[Utility.Random( AncientUrn.Names.Length )] )
		{
		}

		public HonorableSwords( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
			writer.Write( m_SwordsName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
			m_SwordsName = reader.ReadString();

			Utility.Intern( ref m_SwordsName );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1070936, m_SwordsName ); // Honorable Swords of ~1_name~
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, 1070936, m_SwordsName ); // Honorable Swords of ~1_name~
		}
	}

	[Furniture]
	[Flipable( 0x2811, 0x2812 )]
	public class ChestOfHeirlooms : LockableContainer
	{
		public override int LabelNumber{ get{ return 1070937; } } // Chest of heirlooms
		
		[Constructable]
		public ChestOfHeirlooms() : base( 0x2811 )
		{
			Locked = true;
			LockLevel = 95;
			MaxLockLevel = 140;
			RequiredSkill = 95;
			
			TrapType = TrapType.ExplosionTrap;
			TrapLevel = 10;
			TrapPower = 100;
			
			GumpID = 0x10C;
		}

		public ChestOfHeirlooms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();
		}
	}

	public class FluteOfRenewal : BambooFlute
	{
		public override int LabelNumber { get { return 1070927; } } // Flute of Renewal

		[Constructable]
		public FluteOfRenewal() : base()
		{
			Slayer = SlayerGroup.Groups[Utility.Random( SlayerGroup.Groups.Length )].Super.Name;

			ReplenishesCharges = true;
		}

		public override int InitMinUses { get { return 300; } }
		public override int InitMaxUses { get { return 300; } }

		public FluteOfRenewal( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = reader.ReadInt();

			if( version == 0 && Slayer == SlayerName.Fey )
				Slayer = SlayerGroup.Groups[Utility.Random( SlayerGroup.Groups.Length )].Super.Name;
		}
	}
	
	public enum LesserPigmentType
	{
		None,
		PaleOrange,
		FreshRose,
		ChaosBlue,
		Silver,
		NobleGold,
		LightGreen,
		PaleBlue,
		FreshPlum,
		DeepBrown,
		BurntBrown
	}

	public class LesserPigmentsOfIslesDread : BasePigmentsOfIslesDread
	{
		
		private static int[][] m_Table = new int[][]
		{
			// Hue, Label
			new int[]{ /*PigmentType.None,*/ 0, -1 },
			new int[]{ /*PigmentType.PaleOrange,*/ 0x02E, 1071458 },
			new int[]{ /*PigmentType.FreshRose,*/ 0x4B9, 1071455 },
			new int[]{ /*PigmentType.ChaosBlue,*/ 0x005, 1071459 },
			new int[]{ /*PigmentType.Silver,*/ 0x3E9, 1071451 },
			new int[]{ /*PigmentType.NobleGold,*/ 0x227, 1071457 },
			new int[]{ /*PigmentType.LightGreen,*/ 0x1C8, 1071454 },
			new int[]{ /*PigmentType.PaleBlue,*/ 0x24F, 1071456 },
			new int[]{ /*PigmentType.FreshPlum,*/ 0x145, 1071450 },
			new int[]{ /*PigmentType.DeepBrown,*/ 0x3F0, 1071452 },
			new int[]{ /*PigmentType.BurntBrown,*/ 0x41A, 1071453 }
		};
		
		public static int[] GetInfo( LesserPigmentType type )
		{
			int v = (int)type;

			if( v < 0 || v >= m_Table.Length )
				v = 0;
			
			return m_Table[v];
		}

		private LesserPigmentType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public LesserPigmentType Type
		{
			get { return m_Type; }
			set
			{
				m_Type = value;
				
				int v = (int)m_Type;

				if ( v >= 0 && v < m_Table.Length )
				{
					Hue = m_Table[v][0];
					Label = m_Table[v][1];
				}
				else
				{
					Hue = 0;
					Label = -1;
				}
			}
		}

		[Constructable]
		public LesserPigmentsOfIslesDread() : this( (LesserPigmentType)Utility.Random(0,11) )
		{
		}
		
		[Constructable]
		public LesserPigmentsOfIslesDread( LesserPigmentType type ) : base( 1 )
		{
			Weight = 1.0;
			Type = type;
		}

		public LesserPigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( (int)m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion
			
			switch ( version )
			{
				case 1: Type = (LesserPigmentType)reader.ReadEncodedInt(); break;
				case 0: break;
			}
		}
	}

	public class MetalPigmentsOfIslesDread : BasePigmentsOfIslesDread
	{
		[Constructable]
		public MetalPigmentsOfIslesDread() : base( 1 )
		{
			RandomHue();
			Label = -1;
		}
		
		public MetalPigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}
		
		public void RandomHue()
		{
			int a = Utility.Random(0,30);
			if ( a != 0 )
				Hue = a + 0x960;
			else
				Hue = 0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); this.Delete();

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class Lion : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Lion() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lion";
			Body = 187;
			BaseSoundID = 0x3EE;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			this.Delete();
VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override int Cloths{ get{ return 5; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Lion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); this.Delete(); this.Delete();
			int version = reader.ReadInt();
			Body = 187;
		}
	}
}
// using System;



namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class MetalDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public MetalDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a metallic dragon";
			Body = 59;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnAfterSpawn()
		{
			bool IsChromatic = false;

			if ( IsChromatic ){ this.Name = "a chromatic dragon"; }

			base.OnAfterSpawn();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public MetalDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			this.Delete();
		}
	}
}
// using System;// using Server;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class MountainWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public MountainWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the mountain wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();
			Hue = 0x360;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public MountainWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using System.IO;// using System.Text;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Misc;// using Server.Items;// using Server.Guilds;// using Server.Mobiles;// using Server.Accounting;// using Server.Commands;









namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class NightWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }

		[Constructable]
		public NightWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the night wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();
			Hue = 0x8FD;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public NightWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class OnyxWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }

		[Constructable]
		public OnyxWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the onyx wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "onyx scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public OnyxWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
			this.Delete();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;



namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class PoisonBeetle : BaseCreature
	{
		[Constructable]
		public PoisonBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a poisonous beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;
			Hue = 1167;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			this.Delete();
VirtualArmor = 16;

			Item Venom = new VenomSack();
				Venom.Name = "lethal venom sack";
				AddItem( Venom );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

		public PoisonBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
			this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;





namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class QuartzWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public QuartzWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the quartz wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "quartz scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public QuartzWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.ContextMenus;


namespace Server.Mobiles
{
	[CorpseName( "a raptor corpse" )]
	public class Raptor : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Raptor() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a raptor";
			Body = 218;
			BaseSoundID = 0x5A;

			SetStr( 126, 150 );
			SetDex( 56, 75 );
			SetInt( 11, 20 );

			SetHits( 76, 90 );
			SetMana( 0 );

			SetDamage( 6, 24 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 3000;
			Karma = -3000;

			this.Delete();
VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 80.7;
		}

		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public override int GetAttackSound(){ return 0x622; }	// A
		public override int GetDeathSound(){ return 0x623; }	// D
		public override int GetHurtSound(){ return 0x624; }		// H

		public Raptor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;// using Server.Items;// using Server.Mobiles;



















namespace Server.Mobiles
{
	[CorpseName( "a ravenous corpse" )]
	public class Ravenous : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Ravenous() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a ravenous";
			Body = 218;
			BaseSoundID = 0x5A;
			Hue = 0x84E;

			SetStr( 166, 190 );
			SetDex( 96, 115 );
			SetInt( 51, 60 );

			SetHits( 116, 130 );
			SetMana( 0 );

			SetDamage( 12, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 3500;
			Karma = -3500;

			this.Delete();
VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.7;
		}

		public override int GetAttackSound(){ return 0x622; }	// A
		public override int GetDeathSound(){ return 0x623; }	// D
		public override int GetHurtSound(){ return 0x624; }		// H

		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public Ravenous(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;// using System.Reflection;// using System.Collections;// using Server;// using System.Collections.Generic;



namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class RubyWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public RubyWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ruby wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "ruby scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public RubyWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class SabretoothBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public SabretoothBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sabreclaw bear";
			Body = 34;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			this.Delete();
VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public override int GetAngerSound()
		{
			return 0x518;
		}

		public override int GetIdleSound()
		{
			return 0x517;
		}

		public override int GetAttackSound()
		{
			return 0x516;
		}

		public override int GetHurtSound()
		{
			return 0x519;
		}

		public override int GetDeathSound()
		{
			return 0x515;
		}

		public SabretoothBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;// using Server.Network;



namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SapphireWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public SapphireWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sapphire wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "sapphire scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public SapphireWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}
// using System;// using Server;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SpinelWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public SpinelWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the spinel wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "spinel scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public SpinelWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}
// using System;// using Server;


namespace Server.Mobiles
{
	[CorpseName( "a pile of stones" )]
	public class StoneDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public StoneDragon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a stone dragon";
			Body = 12;
			Hue = 2500;
			BaseSoundID = 268;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 75, 85 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "marble scales" );
   			c.DropItem(scale);

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Stone", "", c, 25, 0 );
				}
			}
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 0x33D;
			return base.OnBeforeDeath();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public StoneDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;



namespace Server.Mobiles
{
	[CorpseName( "a swamp drake corpse" )]
	public class SwampDrake : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 18 ); }

		[Constructable]
		public SwampDrake () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a swamp drake";
			Body = 55;
			BaseSoundID = 362;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 241, 258 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 5500;
			Karma = -5500;

			this.Delete();
VirtualArmor = 46;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 84.3;

			PackReg( 3 );

			if ( Utility.Random( 100 ) > 60 )
			{
				int seed_to_give = Utility.Random( 100 );

				if ( seed_to_give > 90 )
				{
					PlantType type;
					switch ( Utility.Random( 17 ) )
					{
						case 0: type = PlantType.CampionFlowers; break;
						case 1: type = PlantType.Poppies; break;
						case 2: type = PlantType.Snowdrops; break;
						case 3: type = PlantType.Bulrushes; break;
						case 4: type = PlantType.Lilies; break;
						case 5: type = PlantType.PampasGrass; break;
						case 6: type = PlantType.Rushes; break;
						case 7: type = PlantType.ElephantEarPlant; break;
						case 8: type = PlantType.Fern; break;
						case 9: type = PlantType.PonytailPalm; break;
						case 10: type = PlantType.SmallPalm; break;
						case 11: type = PlantType.CenturyPlant; break;
						case 12: type = PlantType.WaterPlant; break;
						case 13: type = PlantType.SnakePlant; break;
						case 14: type = PlantType.PricklyPearCactus; break;
						case 15: type = PlantType.BarrelCactus; break;
						default: type = PlantType.TribarrelCactus; break;
					}
						PlantHue hue;
						switch ( Utility.Random( 4 ) )
						{
							case 0: hue = PlantHue.Pink; break;
							case 1: hue = PlantHue.Magenta; break;
							case 2: hue = PlantHue.FireRed; break;
							default: hue = PlantHue.Aqua; break;
						}

						PackItem( new Seed( type, hue, false ) );
				}
				else if ( seed_to_give > 70 )
				{
					PackItem( Engines.Plants.Seed.RandomPeculiarSeed( Utility.RandomMinMax( 1, 4 ) ) );
				}
				else if ( seed_to_give > 40 )
				{
					PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				}
				else
				{
					PackItem( new Engines.Plants.Seed() );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override int TreasureMapLevel{ get{ return 2; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public SwampDrake( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class TigerBeetle : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public TigerBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			this.Delete();
VirtualArmor = 16;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public TigerBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class TopazWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public TopazWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the topaz wyrm";
			BaseSoundID = 362;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new Dagger(); //new HardScales( Utility.RandomMinMax( 15, 20 ), "topaz scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public TopazWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}


namespace Server.Mobiles
{
	public class IharaSoko : BaseVendor
	{
		public override bool IsActiveVendor { get { return false; } }
		public override bool IsInvulnerable { get { return true; } }
		public override bool DisallowAllMoves { get { return true; } }
		public override bool ClickTitle { get { return true; } }
		public override bool CanTeach { get { return false; } }

        protected List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }
		
		public override void InitSBInfo( Mobile m )
		{
		}

		public override void InitOutfit()
		{
			AddItem( new Waraji( 0x711 ) );
			AddItem( new Backpack() );
			AddItem( new Kamishimo( 0x483 ) );

			Item item = new LightPlateJingasa();
			item.Hue = 0x711;

			AddItem( item );
		}

		[Constructable]
		public IharaSoko() : base( "the Imperial Minister of Trade" )
		{
			Name = "Ihara Soko";
			Female = false;
			Body = 0x190;
			Hue = 0x8403;
		}

		public IharaSoko( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
	this.Delete();
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m.Alive && m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				int range = 3;


				int leaveRange = 7;

			}
		}

		//public override void TurnToIslesDread(){}
	}
}



namespace Server.Misc
{
	public enum TreasuresOfTokunoEra
	{
		None,
		ToTOne,
		ToTTwo,
		ToTThree
	}
	
	public class TreasuresOfTokuno
	{
		public const int ItemsPerReward = 10;
		
		private static Type[] m_LesserArtifactsTotal = new Type[]
			{
				typeof( Dagger )
 			};
		
		public static Type[] LesserArtifactsTotal { get { return m_LesserArtifactsTotal; } }
		
		private static TreasuresOfTokunoEra _DropEra = TreasuresOfTokunoEra.None;
		private static TreasuresOfTokunoEra _RewardEra = TreasuresOfTokunoEra.ToTOne;
		
		public static TreasuresOfTokunoEra DropEra
		{
			get { return _DropEra; }
			set { _DropEra = value; }
		}
		
		public static TreasuresOfTokunoEra RewardEra
		{
			get { return _RewardEra; }
			set { _RewardEra = value; }
		}

		private static Type[][] m_LesserArtifacts = new Type[][]
		{
			// ToT One Rewards
			new Type[] {
				typeof( Dagger )
			},
			// ToT Two Rewards
			new Type[] {
				typeof( Dagger )
			},
			// ToT Three Rewards
			new Type[] {
				typeof( Dagger )
			}
		};

		public static Type[] LesserArtifacts 
		{ 
			get { return m_LesserArtifacts[(int)RewardEra-1]; }
		}

		private static Type[][] m_GreaterArtifacts = null;
		
		public static Type[] GreaterArtifacts
		{
			get
			{
				return m_GreaterArtifacts[(int)RewardEra-1];
			}
		}

		private static bool CheckLocation( Mobile m )
		{
			Region r = m.Region;

			if( r.IsPartOf( typeof( Server.Regions.HouseRegion ) ) || Server.Multis.BaseBoat.FindBoatAt( m, m.Map ) != null )
				return false;
			//TODO: a CanReach of something check as opposed to above?

			if( r.IsPartOf( "Yomotsu Mines" ) || r.IsPartOf( "Fan Dancer's Dojo" ) )
				return true;

			return (m.Map == Map.IslesDread);
		}

		public static void HandleKill( Mobile victim, Mobile killer )
		{
			PlayerMobile pm = killer as PlayerMobile;
			BaseCreature bc = victim as BaseCreature;

			if( DropEra == TreasuresOfTokunoEra.None || pm == null || bc == null || !CheckLocation( bc ) || !CheckLocation( pm )|| !killer.InRange( victim, 18 ))
				return;

			if( bc.Controlled || bc.Owners.Count > 0 || bc.Fame <= 0 )
				return;

			//25000 for 1/100 chance, 10 hyrus
			//1500, 1/1000 chance, 20 lizard men for that chance.

			//This is the Exponentional regression with only 2 datapoints.
			//A log. func would also work, but it didn't make as much sense.
			//This function isn't OSI exact beign that I don't know OSI's func they used ;p
			int x = 0;

			//const double A = 8.63316841 * Math.Pow( 10, -4 );
			const double A = 0.000863316841;
			//const double B = 4.25531915 * Math.Pow( 10, -6 );
			const double B = 0.00000425531915;

			double chance = A * Math.Pow( 10, B * x );

			if( chance > Utility.RandomDouble() )
			{
				Item i = null;
				
				try
				{
					i = Activator.CreateInstance( m_LesserArtifacts[(int)DropEra-1][Utility.Random( m_LesserArtifacts[(int)DropEra-1].Length )] ) as Item;
				}
				catch
				{ }

				if( i != null )
				{
					pm.SendLocalizedMessage( 1062317 ); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
					
					if( !pm.PlaceInBackpack( i ) )
					{
						if( pm.BankBox != null && pm.BankBox.TryDropItem( killer, i, false ) )
							pm.SendLocalizedMessage( 1079730 ); // The item has been placed into your bank box.
						else
						{
							pm.SendLocalizedMessage( 1072523 ); // You find an artifact, but your backpack and bank are too full to hold it.
							i.MoveToWorld( pm.Location, pm.Map );
						}
					}
				}
			}
		}
	}
}
namespace Server.Misc
{
	public class TreasuresOfTokunoPersistance : Item
	{
		private static TreasuresOfTokunoPersistance m_Instance;

		public static TreasuresOfTokunoPersistance Instance{ get{ return m_Instance; } }

		public override string DefaultName
		{
			get { return "TreasuresOfTokuno Persistance - Internal"; }
		}

		public static void Initialize()
		{
		}

		public TreasuresOfTokunoPersistance() : base( 1 )
		{
			Movable = false;
		}

		public TreasuresOfTokunoPersistance( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int)TreasuresOfTokuno.RewardEra );
			writer.WriteEncodedInt( (int)TreasuresOfTokuno.DropEra );
		}

		public override void Deserialize(GenericReader reader)
		{
			this.Delete();
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					TreasuresOfTokuno.RewardEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();
					TreasuresOfTokuno.DropEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();
					
					break;
				}
			}
		}
	}
}// using System;



namespace Server.Mobiles
{
	[CorpseName( "an evil corpse" )]
	public class UnholyFamiliar : BaseCreature
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }

		[Constructable]
		public UnholyFamiliar()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark wolf";
			Body = 225;
			Hue = 1109;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = 2500;

			this.Delete();
VirtualArmor = 22;

			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat { get { return 1; } }
		public override int Hides { get { return 7; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

		public UnholyFamiliar( Serial serial )
			: base( serial )
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
this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "an unholy corpse" )]
	public class UnholySteed : BaseMount
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }

		public override bool HasBreath { get { return true; } }
		public override bool CanBreath { get { return true; } }

		[Constructable]
		public UnholySteed()
			: base( "a dark steed", 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			this.Delete();
VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public UnholySteed( Serial serial )
			: base( serial )
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
this.Delete();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;



namespace Server.Mobiles
{
	[CorpseName( "a water beetle corpse" )]
	public class WaterBeetle : BaseCreature
	{
		[Constructable]
		public WaterBeetle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water beetle";
			Body = 0xA9;
			Hue = 1365;
			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			CanSwim = true;

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			this.Delete();
VirtualArmor = 16;
		}

		public override bool BleedImmune{ get{ return true; } }

		public override int GetAngerSound()
		{
			return 0x21D;
		}

		public override int GetIdleSound()
		{
			return 0x21D;
		}

		public override int GetAttackSound()
		{
			return 0x162;
		}

		public override int GetHurtSound()
		{
			return 0x163;
		}

		public override int GetDeathSound()
		{
			return 0x21D;
		}

		public WaterBeetle( Serial serial ) : base( serial )
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

			Body = 0xA9;
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;



















namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class WhiteDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public WhiteDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a white dragon";
			Body = 12;
			Hue = 0x9C2;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			this.Delete();
VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					// Server.Mobiles.Dragons.DropSpecial( this, killer, "", "White", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.White ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public WhiteDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class WhiteWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public WhiteWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the white wyrm";
			BaseSoundID = 362;
			Hue = 0x9C2;
			Body = MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			this.Delete();
VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public WhiteWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = MyServerSettings.WyrmBody();
this.Delete();
		}
	}
}
// using System;// using Server.Items;



















namespace Server.Mobiles
{
	[CorpseName( "a wyvern corpse" )]
	public class Wyvern : BaseCreature
	{
		[Constructable]
		public Wyvern () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wyvern";
			Body = 62;
			BaseSoundID = 362;

			SetStr( 202, 240 );
			SetDex( 153, 172 );
			SetInt( 51, 90 );

			SetHits( 125, 141 );

			SetDamage( 8, 19 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Poisoning, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 4000;
			Karma = -4000;

			this.Delete();
VirtualArmor = 40;
			
			Item Venom = new VenomSack();
				Venom.Name = "deadly venom sack";
				AddItem( Venom );

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 63.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override int GetAttackSound()
		{
			return 713;
		}

		public override int GetAngerSound()
		{
			return 718;
		}

		public override int GetDeathSound()
		{
			return 716;
		}

		public override int GetHurtSound()
		{
			return 721;
		}

		public override int GetIdleSound()
		{
			return 725;
		}

		public Wyvern( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}
// using System;


namespace Server.Mobiles
{
	[CorpseName( "an axebeak corpse" )]
	public class AxeBeak : BaseCreature
	{
		[Constructable]
		public AxeBeak() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "an axebeak";
			Body = 25;
			BaseSoundID = 0x8F;

			SetStr( 96, 120 );
			SetDex( 86, 110 );
			SetInt( 51, 75 );

			SetHits( 58, 72 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 2500;
			Karma = -2500;

			this.Delete();
VirtualArmor = 28;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 39.1;
		}

		public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			base.OnCarve( from, corpse, with );

			if ( Utility.RandomMinMax( 1, 5 ) == 1 )
			{
				Item egg = new Eggs( Utility.RandomMinMax( 1, 5 ) );
				corpse.DropItem( egg );
			}
		}

		public override void OnAfterSpawn()
		{
			Region reg = Region.Find( this.Location, this.Map );

			if ( reg.IsPartOf( "Dungeon Covetous" ) )
			{
				AI = AIType.AI_Melee;
				FightMode = FightMode.Closest;
				Tamable = false;
				NameHue = 0x22;
			}

			base.OnAfterSpawn();
		}

		public override int Meat{ get{ return 4; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }
		public override int Hides{ get{ return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }
		public override HideType HideType{ get{ return HideType.Dinosaur; } }

		public AxeBeak(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a basilisk corpse" )]
	public class Basilisk : BaseCreature
	{
		[Constructable]
		public Basilisk () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a basilisk";
			Body = 483;
			Hue = 0x9C4;
			BaseSoundID = 0x5A;

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			this.Delete();
VirtualArmor = 40;
		}

		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 15; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public void TurnStone()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;

				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}

			foreach ( Mobile m in list )
			{
				if ( !m.CheckSkill( SkillName.MagicResist, 0, 80 ) && !Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
				{
					DoHarmful( m );

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 6, 1);

					int duration = Utility.RandomMinMax(4, 8);
					m.Paralyze(TimeSpan.FromSeconds(duration));

					m.SendMessage( "You are petrified!" );
				}
			}
		}

		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );

			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iStone = Server.Items.HiddenTrap.GetMyItem( m );

				if ( iStone != null )
				{
					if ( m.CheckSkill( SkillName.MagicResist, 0, 80 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iStone, m ) )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The basilisk almost turned one of your protected items to stone!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "One of your items has been turned to stone!");
						m.PlaySound( 0x1FB );
						Item rock = new BrokenGear();
						rock.ItemID = iStone.GraphicID;
						rock.Hue = 2101;
						rock.Weight = iStone.Weight * 3;
						rock.Name = "useless stone";
						iStone.Delete();
						m.AddToBackpack ( rock );
					}
				}
			}

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public Basilisk( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a manticore corpse" )]
	public class Manticore : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public override int BreathPhysicalDamage{ get{ return 100; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectSound{ get{ return 0x536; } }
		public override int BreathEffectItemID{ get{ return 0x10B5; } } // DART
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 5 ); }

		[Constructable]
		public Manticore () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a manticore";
			Body = 843;
			BaseSoundID = 0x3EE;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 241, 258 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 5500;
			Karma = -5500;

			this.Delete();
VirtualArmor = 46;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 94.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Hellish; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Manticore( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class Panda : BaseCreature
	{
		[Constructable]
		public Panda() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a panda bear";
			Body = 671;
			BaseSoundID = 0xA3;

			SetStr( 76, 100 );
			SetDex( 26, 45 );
			SetInt( 23, 47 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 30 );
			SetResistance( ResistanceType.Cold, 15, 20 );
			SetResistance( ResistanceType.Poison, 10, 15 );

			SetSkill( SkillName.MagicResist, 25.1, 35.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.FistFighting, 40.1, 60.0 );

			Fame = 450;
			Karma = 0;

			this.Delete();
VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 41.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override int Cloths{ get{ return 6; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public Panda( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a hell lion corpse" )]
	[TypeAlias( "Server.Mobiles.Preditorhellcat" )]
	public class PredatorHellCat : BaseCreature
	{
		public override bool HasBreath{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public PredatorHellCat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hell lion";
			Body = 340;
			Hue = 0x4AA;
			BaseSoundID = 0x3EE;

			SetStr( 161, 185 );
			SetDex( 96, 115 );
			SetInt( 76, 100 );

			SetHits( 97, 131 );

			SetDamage( 5, 17 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 75.1, 90.0 );
			SetSkill( SkillName.Tactics, 50.1, 65.0 );
			SetSkill( SkillName.FistFighting, 50.1, 65.0 );

			Fame = 2500;
			Karma = -2500;

			this.Delete();
VirtualArmor = 30;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 89.1;

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public PredatorHellCat(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class SabretoothTiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public SabretoothTiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sabretooth tiger";
			Body = 340;
			BaseSoundID = 0x462;
			Hue = 0x54F;

			SetStr( 400 );
			SetDex( 300 );
			SetInt( 120 );

			SetMana( 0 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.FistFighting, 120.0 );

			Fame = 3000;
			Karma = 0;

			this.Delete();
VirtualArmor = 50;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public SabretoothTiger( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class Tiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Tiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger";
			Body = 340;
			BaseSoundID = 0x3EE;
			Hue = 0x54F;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			this.Delete();
VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override int Cloths{ get{ return 5; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Tiger(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	[TypeAlias( "Server.Mobiles.WhiteTiger" )]
	public class WhiteTiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public WhiteTiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger";
			Body = 340;
			BaseSoundID = 0x3EE;
			Hue = 0x9C2;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			this.Delete();
VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Frozen; } }
		public override int Cloths{ get{ return 4; } }
		public override ClothType ClothType{ get{ return ClothType.Wooly; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public WhiteTiger(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
this.Delete();
		}
	}
}


















namespace Server.Mobiles
{
	[CorpseName( "a zebra corpse" )]
	public class Zebra : BaseCreature
	{
		[Constructable]
		public Zebra() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a zebra";
			Body = 115;
			BaseSoundID = 0xA8;

			SetStr( 22, 98 );
			SetDex( 56, 75 );
			SetInt( 6, 10 );

			SetHits( 28, 45 );
			SetMana( 0 );

			SetDamage( 3, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.FistFighting, 29.3, 44.0 );

			Fame = 300;
			Karma = 0;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override int Cloths{ get{ return 5; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }

		public Zebra( Serial serial ) : base( serial )
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
this.Delete();
		}
	}
}



















namespace Server.Items
{
	public class SalesBook : Item
	{
		public static SalesBook m_Book;

		[Constructable]
		public SalesBook() : base( 0x2254 )
		{
			Weight = 1.0;
			Movable = false;
			Hue = 0x515;
			Name = "Steel Crafted Items";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendSound( 0x55 );
			from.CloseGump( typeof( SalesBookGump ) );
			from.SendGump( new SalesBookGump( from, this, 0 ) );
		}

		public class SalesBookGump : Gump
		{
			public SalesBookGump( Mobile from, SalesBook wikipedia, int page ): base( 100, 100 )
			{
				m_Book = wikipedia;
				SalesBook pedia = (SalesBook)wikipedia;

				int NumberOfsellings = 121;	// SEE LISTING BELOW AND MAKE SURE IT MATCHES THE AMOUNT
											// DO THIS NUMBER+1 IN THE OnResponse SECTION BELOW

				string BookTitle = "";

				if ( m_Book.Name == "Steel Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Steel Crafted";
				}
				else if ( m_Book.Name == "Mithril Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Mithril Crafted";
				}
				else if ( m_Book.Name == "Brass Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Brass Crafted";
				}

				decimal PageCount = NumberOfsellings / 16;
				int TotalBookPages = ( 100000 ) + ( (int)Math.Ceiling( PageCount ) );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				int subItem = page * 16;

				int showItem1 = subItem + 1;
				int showItem2 = subItem + 2;
				int showItem3 = subItem + 3;
				int showItem4 = subItem + 4;
				int showItem5 = subItem + 5;
				int showItem6 = subItem + 6;
				int showItem7 = subItem + 7;
				int showItem8 = subItem + 8;
				int showItem9 = subItem + 9;
				int showItem10 = subItem + 10;
				int showItem11 = subItem + 11;
				int showItem12 = subItem + 12;
				int showItem13 = subItem + 13;
				int showItem14 = subItem + 14;
				int showItem15 = subItem + 15;
				int showItem16 = subItem + 16;

				int page_prev = ( 100000 + page ) - 1;
					if ( page_prev < 100000 ){ page_prev = TotalBookPages; }
				int page_next = ( 100000 + page ) + 1;
					if ( page_next > TotalBookPages ){ page_next = 100000; }

				AddImage(40, 36, 1054);

				AddHtml( 162, 64, 200, 34, @"<BODY><BASEFONT Color=#111111><BIG><CENTER>" + BookTitle + "</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 444, 64, 180, 34, @"<BODY><BASEFONT Color=#111111><BIG><CENTER>" + BookTitle + "</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(93, 53, 1055, 1055, page_prev, GumpButtonType.Reply, 0);
				AddButton(625, 53, 1056, 1056, page_next, GumpButtonType.Reply, 0);

				///////////////////////////////////////////////////////////////////////////////////

				AddHtml( 126, 112, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem1, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 148, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem2, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 184, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem3, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 220, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem4, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 256, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem5, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 292, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem6, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 328, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem7, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 364, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem8, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				if ( GetSalesForBook( m_Book.Name, showItem1, 1, from ) != "" ){ AddHtml( 328, 112, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem1, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem2, 1, from ) != "" ){ AddHtml( 328, 148, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem2, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem3, 1, from ) != "" ){ AddHtml( 328, 184, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem3, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem4, 1, from ) != "" ){ AddHtml( 328, 220, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem4, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem5, 1, from ) != "" ){ AddHtml( 328, 256, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem5, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem6, 1, from ) != "" ){ AddHtml( 328, 292, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem6, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem7, 1, from ) != "" ){ AddHtml( 328, 328, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem7, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem8, 1, from ) != "" ){ AddHtml( 328, 364, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem8, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }

				if ( GetSalesForBook( m_Book.Name, showItem1, 1, from ) != "" ){ AddButton(104, 115, 30008, 30008, showItem1, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem2, 1, from ) != "" ){ AddButton(104, 151, 30008, 30008, showItem2, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem3, 1, from ) != "" ){ AddButton(104, 187, 30008, 30008, showItem3, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem4, 1, from ) != "" ){ AddButton(104, 223, 30008, 30008, showItem4, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem5, 1, from ) != "" ){ AddButton(104, 259, 30008, 30008, showItem5, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem6, 1, from ) != "" ){ AddButton(104, 295, 30008, 30008, showItem6, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem7, 1, from ) != "" ){ AddButton(104, 331, 30008, 30008, showItem7, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem8, 1 , from) != "" ){ AddButton(104, 367, 30008, 30008, showItem8, GumpButtonType.Reply, 0); }

				///////////////////////////////////////////////////////////////////////////////////

				AddHtml( 443, 112, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem9, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 148, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem10, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 184, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem11, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 220, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem12, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 256, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem13, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 292, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem14, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 328, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem15, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 364, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem16, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				if ( GetSalesForBook( m_Book.Name, showItem9, 1, from ) != "" ){ AddHtml( 645, 112, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem9, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem10, 1, from ) != "" ){ AddHtml( 645, 148, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem10, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem11, 1, from ) != "" ){ AddHtml( 645, 184, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem11, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem12, 1, from ) != "" ){ AddHtml( 645, 220, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem12, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem13, 1, from ) != "" ){ AddHtml( 645, 256, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem13, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem14, 1, from ) != "" ){ AddHtml( 645, 292, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem14, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem15, 1, from ) != "" ){ AddHtml( 645, 328, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem15, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem16, 1, from ) != "" ){ AddHtml( 645, 364, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem16, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }

				if ( GetSalesForBook( m_Book.Name, showItem9, 1, from ) != "" ){ AddButton(421, 115, 30008, 30008, showItem9, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem10, 1, from ) != "" ){ AddButton(421, 151, 30008, 30008, showItem10, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem11, 1, from ) != "" ){ AddButton(421, 187, 30008, 30008, showItem11, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem12, 1, from ) != "" ){ AddButton(421, 223, 30008, 30008, showItem12, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem13, 1, from ) != "" ){ AddButton(421, 259, 30008, 30008, showItem13, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem14, 1, from ) != "" ){ AddButton(421, 295, 30008, 30008, showItem14, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem15, 1, from ) != "" ){ AddButton(421, 331, 30008, 30008, showItem15, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem16, 1, from ) != "" ){ AddButton(421, 367, 30008, 30008, showItem16, GumpButtonType.Reply, 0); }
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile; 
				Container pack = from.Backpack;
				from.SendSound( 0x55 );
				int NumItemsPlusOne = 121;

				if ( m_Book.Name == "Steel Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}
				else if ( m_Book.Name == "Mithril Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}
				else if ( m_Book.Name == "Brass Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}

				if ( info.ButtonID >= 100000 )
				{
					int page = info.ButtonID - 100000;
					from.SendGump( new SalesBookGump( from, m_Book, page ) );
				}
				else if ( info.ButtonID < NumItemsPlusOne )
				{
					string sType = GetSalesForBook( m_Book.Name, info.ButtonID, 2, from );
					string sName = GetSalesForBook( m_Book.Name, info.ButtonID, 1, from );
					int cost = Int32.Parse( GetSalesForBook( m_Book.Name, info.ButtonID, 3, from ) );
					string spentMessage = "You pay a total of " + cost.ToString() + " gold.";

					if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
					{
						cost = cost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * cost ); if ( cost < 1 ){ cost = 1; }
						spentMessage = "You only pay a total of " + cost.ToString() + " gold because of your begging.";
					}

					bool nearBook = false;
					foreach ( Item tome in from.GetItemsInRange( 10 ) )
					{
						if ( tome == m_Book ){ nearBook = true; }
					}

					if ( sName != "" && nearBook == true )
					{
						if ( from.TotalGold >= cost )
						{
							Item item = null;
							Type itemType = ScriptCompiler.FindTypeByName( sType );
							item = (Item)Activator.CreateInstance(itemType);

							pack.ConsumeTotal(typeof(Gold), cost);
							from.SendMessage( spentMessage );

							if ( m_Book.Name == "Steel Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Steel; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Steel; }
							}
							else if ( m_Book.Name == "Mithril Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Mithril; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Mithril; }
							}
							else if ( m_Book.Name == "Brass Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Brass; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Brass; }
							}

							from.AddToBackpack ( item );
							if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -Server.Mobiles.BaseVendor.BeggingKarma( from ), true ); } // DO ANY KARMA LOSS

							int OneSay = 0;

							foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
							{
								if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Steel Crafted Items" )
								{
									who.PlaySound( 0x2A );
									
									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of steel." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People come from afar for orkish steel." ); 			break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge steel." );	break;
									}

									OneSay = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Mithril Crafted Items" )
								{
									who.PlaySound( 0x2A );
									
									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of mithril." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People find their way here for our mithril." ); 		break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge mithril." );	break;
									}

									OneSay = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Brass Crafted Items" )
								{
									who.PlaySound( 0x2A );
									
									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of brass." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People find their way here for our brass." ); 		break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge brass." );	break;
									}

									OneSay = 1;
								}
							}
						}
						else
						{
							int NoGold = 0;

							foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
							{
								if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Steel Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Mithril Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Brass Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
							}
						}
					}
				}
			}
		}

		public SalesBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
this.Delete();
		}

		public static string GetSalesForBook( string book, int selling, int part, Mobile player )
		{
			double barter = player.Skills[SkillName.Mercantile].Value * 0.001;

			string item = "";
			string name = "";
			int cost = 0;

			int sales = 1;
			int rate = 4; // STANDARD MARKUP

			double markup = 1;

			if ( m_Book.Name == "Steel Crafted Items" )
			{
				markup = 3.00 * rate;
			}
			else if ( m_Book.Name == "Brass Crafted Items" )
			{
				markup = 6.00 * rate;
			}
			else if ( m_Book.Name == "Mithril Crafted Items" )
			{
				markup = 9.00 * rate;
			}

			markup = markup - ( markup * barter );

			if ( book == "Steel Crafted Items" || book == "Mithril Crafted Items" || book == "Brass Crafted Items" )
			{
				if ( selling == sales ) { name="AssassinSpike"; item="Assassin Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenSpellblade"; item="Assassin Sword"; cost = 33; } sales++;
				if ( selling == sales ) { name="Axe"; item="Axe"; cost = 40; } sales++;
				if ( selling == sales ) { name="OrnateAxe"; item="Barbarian Axe"; cost = 42; } sales++;
				if ( selling == sales ) { name="VikingSword"; item="Barbarian Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Bardiche"; item="Bardiche"; cost = 60; } sales++;
				if ( selling == sales ) { name="Bascinet"; item="Bascinet"; cost = 18; } sales++;
				if ( selling == sales ) { name="BattleAxe"; item="Battle Axe"; cost = 26; } sales++;
				if ( selling == sales ) { name="DiamondMace"; item="Battle Mace"; cost = 31; } sales++;
				if ( selling == sales ) { name="BladedStaff"; item="Bladed Staff"; cost = 40; } sales++;
				if ( selling == sales ) { name="Broadsword"; item="Broadsword"; cost = 35; } sales++;
				if ( selling == sales ) { name="Buckler"; item="Buckler"; cost = 50; } sales++;
				if ( selling == sales ) { name="ButcherKnife"; item="Butcher Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="ChainChest"; item="Chain Chest"; cost = 143; } sales++;
				if ( selling == sales ) { name="ChainCoif"; item="Chain Coif"; cost = 17; } sales++;
				if ( selling == sales ) { name="ChainHatsuburi"; item="Chain Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="ChainLegs"; item="Chain Legs"; cost = 149; } sales++;
				if ( selling == sales ) { name="ChampionShield"; item="Champion Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="ChaosShield"; item="Chaos Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="Claymore"; item="Claymore"; cost = 55; } sales++;
				if ( selling == sales ) { name="Cleaver"; item="Cleaver"; cost = 15; } sales++;
				if ( selling == sales ) { name="CloseHelm"; item="Close Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="CrescentBlade"; item="Crescent Blade"; cost = 37; } sales++;
				if ( selling == sales ) { name="CrestedShield"; item="Crested Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Cutlass"; item="Cutlass"; cost = 24; } sales++;
				if ( selling == sales ) { name="Dagger"; item="Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="Daisho"; item="Daisho"; cost = 66; } sales++;
				if ( selling == sales ) { name="DarkShield"; item="Dark Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="DecorativePlateKabuto"; item="Decorative Plate Kabuto"; cost = 95; } sales++;
				if ( selling == sales ) { name="DoubleAxe"; item="Double Axe"; cost = 52; } sales++;
				if ( selling == sales ) { name="DoubleBladedStaff"; item="Double Bladed Staff"; cost = 35; } sales++;
				if ( selling == sales ) { name="DreadHelm"; item="Dread Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenShield"; item="Elven Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="RadiantScimitar"; item="Falchion"; cost = 35; } sales++;
				if ( selling == sales ) { name="FemalePlateChest"; item="Female Plate Chest"; cost = 113; } sales++;
				if ( selling == sales ) { name="ExecutionersAxe"; item="Executioner Axe"; cost = 30; } sales++;
				if ( selling == sales ) { name="GuardsmanShield"; item="Guardsman Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Halberd"; item="Halberd"; cost = 42; } sales++;
				if ( selling == sales ) { name="Hammers"; item="Hammer"; cost = 28; } sales++;
				if ( selling == sales ) { name="HammerPick"; item="Hammer Pick"; cost = 26; } sales++;
				if ( selling == sales ) { name="Harpoon"; item="Harpoon"; cost = 40; } sales++;
				if ( selling == sales ) { name="HeaterShield"; item="Heater Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="HeavyPlateJingasa"; item="Heavy Plate Jingasa"; cost = 76; } sales++;
				if ( selling == sales ) { name="Helmet"; item="Helmet"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrcHelm"; item="Horned Helm"; cost = 24; } sales++;
				if ( selling == sales ) { name="JeweledShield"; item="Jeweled Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Kama"; item="Kama"; cost = 61; } sales++;
				if ( selling == sales ) { name="Katana"; item="Katana"; cost = 33; } sales++;
				if ( selling == sales ) { name="Kryss"; item="Kryss"; cost = 32; } sales++;
				if ( selling == sales ) { name="Lajatang"; item="Lajatang"; cost = 108; } sales++;
				if ( selling == sales ) { name="Lance"; item="Lance"; cost = 34; } sales++;
				if ( selling == sales ) { name="LargeBattleAxe"; item="Large Battle Axe"; cost = 33; } sales++;
				if ( selling == sales ) { name="LargeKnife"; item="Large Knife"; cost = 21; } sales++;
				if ( selling == sales ) { name="BronzeShield"; item="Large Shield"; cost = 66; } sales++;
				if ( selling == sales ) { name="LightPlateJingasa"; item="Light Plate Jingasa"; cost = 56; } sales++;
				if ( selling == sales ) { name="Longsword"; item="Longsword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Mace"; item="Mace"; cost = 28; } sales++;
				if ( selling == sales ) { name="ElvenMachete"; item="Machete"; cost = 35; } sales++;
				if ( selling == sales ) { name="Maul"; item="Maul"; cost = 21; } sales++;
				if ( selling == sales ) { name="MetalKiteShield"; item="Metal Kite Shield"; cost = 123; } sales++;
				if ( selling == sales ) { name="MetalShield"; item="Metal Shield"; cost = 121; } sales++;
				if ( selling == sales ) { name="NoDachi"; item="NoDachi"; cost = 82; } sales++;
				if ( selling == sales ) { name="NorseHelm"; item="Norse Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrderShield"; item="Order Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="OrnateAxe"; item="Barbarian Axe"; cost = 241; } sales++;
				if ( selling == sales ) { name="Pike"; item="Pike"; cost = 39; } sales++;
				if ( selling == sales ) { name="Pitchfork"; item="Trident"; cost = 19; } sales++;
				if ( selling == sales ) { name="PlateArms"; item="Plate Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="PlateBattleKabuto"; item="Plate Battle Kabuto"; cost = 94; } sales++;
				if ( selling == sales ) { name="PlateChest"; item="Plate Chest"; cost = 243; } sales++;
				if ( selling == sales ) { name="PlateDo"; item="Plate Do"; cost = 310; } sales++;
				if ( selling == sales ) { name="PlateGloves"; item="Plate Gloves"; cost = 155; } sales++;
				if ( selling == sales ) { name="PlateGorget"; item="Plate Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="PlateHaidate"; item="Plate Haidate"; cost = 235; } sales++;
				if ( selling == sales ) { name="PlateHatsuburi"; item="Plate Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateHelm"; item="Plate Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="PlateHiroSode"; item="Plate Hiro Sode"; cost = 222; } sales++;
				if ( selling == sales ) { name="PlateLegs"; item="Plate Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="PlateMempo"; item="Plate Mempo"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateSuneate"; item="Plate Suneate"; cost = 224; } sales++;
				if ( selling == sales ) { name="RingmailArms"; item="Ringmail Arms"; cost = 85; } sales++;
				if ( selling == sales ) { name="RingmailChest"; item="Ringmail Chest"; cost = 121; } sales++;
				if ( selling == sales ) { name="RingmailGloves"; item="Ringmail Gloves"; cost = 93; } sales++;
				if ( selling == sales ) { name="RingmailLegs"; item="Ringmail Legs"; cost = 90; } sales++;
				if ( selling == sales ) { name="RoyalArms"; item="Royal Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="RoyalBoots"; item="Royal Boots"; cost = 40; } sales++;
				if ( selling == sales ) { name="RoyalChest"; item="Royal Chest"; cost = 242; } sales++;
				if ( selling == sales ) { name="RoyalGloves"; item="Royal Gloves"; cost = 144; } sales++;
				if ( selling == sales ) { name="RoyalGorget"; item="Royal Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="RoyalHelm"; item="Royal Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="RoyalShield"; item="Royal Shield"; cost = 230; } sales++;
				if ( selling == sales ) { name="RoyalsLegs"; item="Royal Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="RoyalSword"; item="Royal Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Sai"; item="Sai"; cost = 56; } sales++;
				if ( selling == sales ) { name="Scepter"; item="Scepter"; cost = 39; } sales++;
				if ( selling == sales ) { name="Sceptre"; item="Sceptre"; cost = 38; } sales++;
				if ( selling == sales ) { name="Scimitar"; item="Scimitar"; cost = 36; } sales++;
				if ( selling == sales ) { name="Scythe"; item="Scythe"; cost = 39; } sales++;
				if ( selling == sales ) { name="ShortSpear"; item="Short Spear"; cost = 23; } sales++;
				if ( selling == sales ) { name="ShortSword"; item="Short Sword"; cost = 35; } sales++;
				if ( selling == sales ) { name="BoneHarvester"; item="Sickle"; cost = 35; } sales++;
				if ( selling == sales ) { name="SkinningKnife"; item="Skinning Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="SmallPlateJingasa"; item="Small Plate Jingasa"; cost = 66; } sales++;
				if ( selling == sales ) { name="Spear"; item="Spear"; cost = 31; } sales++;
				if ( selling == sales ) { name="SpikedClub"; item="Spiked Club"; cost = 28; } sales++;
				if ( selling == sales ) { name="StandardPlateKabuto"; item="Standard Plate Kabuto"; cost = 74; } sales++;
				if ( selling == sales ) { name="WizardStaff"; item="Stave"; cost = 40; } sales++;
				if ( selling == sales ) { name="ThinLongsword"; item="Sword"; cost = 27; } sales++;
				if ( selling == sales ) { name="Tekagi"; item="Tekagi"; cost = 55; } sales++;
				if ( selling == sales ) { name="Tessen"; item="Tessen"; cost = 83; } sales++;
				if ( selling == sales ) { name="Tetsubo"; item="Tetsubo"; cost = 43; } sales++;
				if ( selling == sales ) { name="TwoHandedAxe"; item="Two Handed Axe"; cost = 32; } sales++;
				if ( selling == sales ) { name="Wakizashi"; item="Wakizashi"; cost = 38; } sales++;
				if ( selling == sales ) { name="WarAxe"; item="War Axe"; cost = 29; } sales++;
				if ( selling == sales ) { name="RuneBlade"; item="War Blades"; cost = 55; } sales++;
				if ( selling == sales ) { name="WarCleaver"; item="War Cleaver"; cost = 25; } sales++;
				if ( selling == sales ) { name="Leafblade"; item="War Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="WarFork"; item="War Fork"; cost = 32; } sales++;
				if ( selling == sales ) { name="WarHammer"; item="War Hammer"; cost = 24; } sales++;
				if ( selling == sales ) { name="WarMace"; item="War Mace"; cost = 31; } sales++;
			}

			if ( part == 2 ){ item = name; }
			else if ( part == 3 ){ item = ((int)(cost*markup)).ToString(); }

			return item;
		}
	}
}









































































































































































































