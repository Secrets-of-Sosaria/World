using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a savage corpse" )]
	public class Savage : BaseCreature
	{
		[Constructable]
		public Savage() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "savage" );

			int dino = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6 );

			if ( Female = Utility.RandomBool() )
			{
				Body = 401;
				Item cloth9 = new FemaleLeatherChest();
					cloth9.Hue = dino;
					cloth9.Name = "dracosaur tunic";
					AddItem( cloth9 );
			}
			else
			{
				Body = 400;
			}

			Hue = 0;

			SetStr( 96, 115 );
			SetDex( 86, 105 );
			SetInt( 51, 65 );

			SetDamage( 23, 27 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Fencing, 60.0, 82.5 );
			SetSkill( SkillName.Bludgeoning, 60.0, 82.5 );
			SetSkill( SkillName.Poisoning, 60.0, 82.5 );
			SetSkill( SkillName.MagicResist, 57.5, 80.0 );
			SetSkill( SkillName.Swords, 60.0, 82.5 );
			SetSkill( SkillName.Tactics, 60.0, 82.5 );

			Fame = 1000;
			Karma = -1000;

			PackItem( new Bandage( Utility.RandomMinMax( 1, 15 ) ) );

			if ( !Female && 0.1 > Utility.RandomDouble() )
				PackItem( new BolaBall() );

			AddItem( new Spear() );

			Item cloth1 = new SavageArms();
			  	cloth1.Hue = dino;
				cloth1.Name = "dracosaur gauntlets";
			  	AddItem( cloth1 );
			Item cloth2 = new SavageLegs();
			  	cloth2.Hue = dino;
				cloth2.Name = "dracosaur leggings";
			  	AddItem( cloth2 );
			Item cloth3 = new TribalMask();
			  	cloth3.Hue = dino;
				cloth3.Name = "savage tribal mask";
			  	AddItem( cloth3 );
			Item cloth4 = new LeatherSkirt();
			  	cloth4.Hue = dino;
				cloth4.Name = "dracosaur skirt";
			  	cloth4.Layer = Layer.Waist;
			  	AddItem( cloth4 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 1; } }
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public Savage( Serial serial ) : base( serial )
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
		}
	}
}