using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SkeletalPirate : BaseCreature
	{
		[Constructable]
		public SkeletalPirate() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a skeletal pirate";
			BaseSoundID = 451;

			Body = 0x190;
			if ( Utility.RandomMinMax( 0, 1 ) == 1 )
			{
				Body = 0x191;
			}

			Hue = 0xB97;

			SetStr( 196, 250 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 118, 150 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.FistFighting, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;

			AddItem( new LongPants () );
			AddItem( new FancyShirt() );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Dagger() ); break;
			}

			MorphingTime.BlessMyClothes( this );
			MorphingTime.ColorMyClothes( this, 0xB9A, 0 );

			Item helm = new WornHumanDeco();
				helm.Name = "skull";
				helm.ItemID = 0x1451;
				helm.Hue = this.Hue;
				helm.Layer = Layer.Helm;
				AddItem( helm );

			Item hands = new WornHumanDeco();
				hands.Name = "bony fingers";
				hands.ItemID = 0x1450;
				hands.Hue = this.Hue;
				hands.Layer = Layer.Gloves;
				AddItem( hands );

			Item feet = new WornHumanDeco();
				feet.Name = "bony feet";
				feet.ItemID = 0x170D;
				feet.Hue = this.Hue;
				feet.Layer = Layer.Shoes;
				AddItem( feet );
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 50;
			return base.OnBeforeDeath();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public SkeletalPirate( Serial serial ) : base( serial )
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