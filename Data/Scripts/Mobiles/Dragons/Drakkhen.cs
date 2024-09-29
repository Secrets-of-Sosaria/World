using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a drakkhen corpse" )]
	public class DrakkhenRed : BaseMount
	{
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		[Constructable]
		public DrakkhenRed() : this( "a drakkhen" )
		{
		}

		[Constructable]
		public DrakkhenRed( string name ) : base( name, 596, 596, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a drakkhen";
			Body = 596;
			BaseSoundID = 362;
			Resource = CraftResource.RedScales;

			SetStr( 201, 230 );
			SetDex( 103, 122 );
			SetInt( 71, 110 );

			SetHits( 141, 158 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 15, 30 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 45.1, 70.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 26;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 20.0;
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ResourceScales(); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override int Skin{ get{ return Utility.Random(2); } }
		public override SkinType SkinType{ get{ return SkinType.Dragon; } }
		public override int Skeletal{ get{ return Utility.Random(2); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Draco; } }

		public DrakkhenRed( Serial serial ) : base( serial )
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
	[CorpseName( "a drakkhen corpse" )]
	public class DrakkhenBlack : BaseMount
	{
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		[Constructable]
		public DrakkhenBlack() : this( "a drakkhen" )
		{
		}

		[Constructable]
		public DrakkhenBlack( string name ) : base( name, 595, 595, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a drakkhen";
			Body = 595;
			BaseSoundID = 362;
			Resource = CraftResource.BlackScales;

			SetStr( 201, 230 );
			SetDex( 103, 122 );
			SetInt( 71, 110 );

			SetHits( 141, 158 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 15, 30 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 45.1, 70.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 26;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 20.0;
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ResourceScales(); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public DrakkhenBlack( Serial serial ) : base( serial )
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