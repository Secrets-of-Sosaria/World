using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an owlbear corpse" )]
	public class Owlbear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Owlbear() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an owlbear";
			Body = 758;
			BaseSoundID = 0xA3;

			SetStr( 276, 305 );
			SetDex( 121, 145 );
			SetInt( 56, 80 );

			SetHits( 236, 273 );
			SetMana( 0 );

			SetDamage( 16, 21 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }

        public override int GetIdleSound(){ return 0x635; }
        public override int GetAngerSound(){ return 0x632; }
        public override int GetHurtSound(){ return 0x634; }
        public override int GetDeathSound(){ return 0x633; }

		public Owlbear( Serial serial ) : base( serial )
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