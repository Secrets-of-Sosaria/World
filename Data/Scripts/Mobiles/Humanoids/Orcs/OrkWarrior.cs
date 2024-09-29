using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{
	[CorpseName( "an orcish corpse" )] 
	public class OrkWarrior : BaseCreature 
	{
		[Constructable] 
		public OrkWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{
			SpeechHue = Utility.RandomTalkHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 606; 
				Name = NameList.RandomName( "ork_female" );
				Utility.AssignRandomHair( this );
				HairHue = Utility.RandomHairHue();
			} 
			else 
			{ 
				Body = 605; 
				Name = NameList.RandomName( "ork_male" );
				Utility.AssignRandomHair( this );
				FacialHairItemID = Utility.RandomList( 0, 8254, 8255, 8256, 8257, 8267, 8268, 8269 );
				HairHue = Utility.RandomHairHue();
				FacialHairHue = HairHue;
			}

			SetStr( Utility.RandomMinMax( 150, 170 ) );
			SetDex( Utility.RandomMinMax( 70, 90 ) );
			SetInt( Utility.RandomMinMax( 40, 60 ) );

			SetHits( RawStr );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Searching, 20.0 );
			SetSkill( SkillName.Anatomy, 50.0 );
			SetSkill( SkillName.MagicResist, 20.0 );
			SetSkill( SkillName.Bludgeoning, 50.0 );
			SetSkill( SkillName.Fencing, 50.0 );
			SetSkill( SkillName.FistFighting, 50.0 );
			SetSkill( SkillName.Swords, 50.0 );
			SetSkill( SkillName.Tactics, 50.0 );

			Fame = 100;
			Karma = -100;

			VirtualArmor = 0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Skeletal{ get{ return Utility.Random(2); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Orc; } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.CryOut( this );
		}

		public override void OnAfterSpawn()
		{
			Server.Misc.IntelligentAction.ChooseFighter( this, "ork " );
			base.OnAfterSpawn();
			Server.Misc.MorphingTime.CheckMorph( this );
		}

		public OrkWarrior( Serial serial ) : base( serial ) 
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