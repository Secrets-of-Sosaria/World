using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a moose corpse" )]
	public class Moose : BaseCreature
	{
		[Constructable]
		public Moose() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a moose";
			Body = 957;

			SetStr( 51, 81 );
			SetDex( 57, 87 );
			SetInt( 37, 67 );

			SetHits( 37, 51 );
			SetMana( 0 );

			SetDamage( 6, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Cold, 5, 10 );

			SetSkill( SkillName.MagicResist, 26.8, 44.5 );
			SetSkill( SkillName.Tactics, 29.8, 47.5 );
			SetSkill( SkillName.FistFighting, 29.8, 47.5 );

			Fame = 350;
			Karma = 0;

			VirtualArmor = 26;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 62.1;
		}

		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 18; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public Moose(Serial serial) : base(serial)
		{
		}

		public override int GetAttackSound() 
		{ 
			return 0x82; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x83; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x84; 
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
		}
	}
}