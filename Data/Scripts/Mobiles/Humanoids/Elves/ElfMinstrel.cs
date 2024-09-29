using System;
using Server;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class ElfMinstrel : BaseCreature
	{
		[Constructable]
		public ElfMinstrel() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 0: Title = "the drow bard"; break;
				case 1: Title = "the drow minstrel"; break;
				case 2: Title = "the drow troubadour"; break;
				case 3: Title = "the drow musician"; break;
				case 4: Title = "the drow balladeer"; break;
			}

			Hue = 1316;
			Race = Race.Elf;
			HairHue = 1150;

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 606;
				Name = NameList.RandomName( "dark_elf_prefix_female" ) + NameList.RandomName( "dark_elf_suffix_female" );
				Utility.AssignRandomHair( this );
			}
			else
			{
				Body = 605;
				Name = NameList.RandomName( "dark_elf_prefix_male" ) + NameList.RandomName( "dark_elf_suffix_male" );
				Utility.AssignRandomHair( this );
			}

			SetStr( 86, 100 );
			SetDex( 81, 95 );
			SetInt( 61, 75 );

			SetDamage( 10, 23 );

			SetSkill( SkillName.Marksmanship, 80.1, 90.0 );
			SetSkill( SkillName.FistFighting, 66.0, 97.5 );
			SetSkill( SkillName.MagicResist, 25.0, 47.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Musicianship, 65.0, 87.5 );

			Fame = 2000;
			Karma = -2000;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new BambooFlute() );	SpeechHue = 0x504;	break;
				case 1: PackItem( new Drums() );		SpeechHue = 0x38;	break;
				case 2: PackItem( new Tambourine() );	SpeechHue = 0x52;	break;
				case 3: PackItem( new LapHarp() );		SpeechHue = 0x45;	break;
				case 4: PackItem( new Lute() );			SpeechHue = 0x4C;	break;
				case 5: PackItem( new Trumpet() );		SpeechHue = 0x3CE;	break;
			}

			switch ( Utility.Random( 2 ))
			{
				case 0: AddItem( new Crossbow() ); PackItem( new Bolt( Utility.RandomMinMax( 5, 15 ) ) ); break;
				case 1: AddItem( new Bow() ); PackItem( new Arrow( Utility.RandomMinMax( 5, 15 ) ) ); break;
			}

			Server.Misc.IntelligentAction.DressUpBards( this );
			Server.Misc.IntelligentAction.GiveAdventureGear( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Songs );
		}

		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override int Skeletal{ get{ return Utility.Random(2); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Drow; } }

		public override void OnThink()
		{
			if ( DateTime.Now >= NextPickup )
			{
				switch( Utility.RandomMinMax( 0, 3 ) )
				{
					case 0:	Peace( Combatant ); break;
					case 1:	Undress( Combatant ); break;
					case 2:	Suppress( Combatant ); break;
					case 3:	Provoke( Combatant ); break;
				}
			}
			base.OnThink();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.CryOut( this );
		}

		public ElfMinstrel( Serial serial ) : base( serial )
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
		}
	}
}