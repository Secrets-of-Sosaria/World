using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a mountain goat corpse" )]
	public class DireGoat : BaseCreature
	{
		[Constructable]
		public DireGoat() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a dire goat";
			Body = 380;
			BaseSoundID = 0x99;

			SetStr( 82, 124 );
			SetDex( 56, 75 );
			SetInt( 16, 30 );

			SetHits( 80, 93 );
			SetMana( 0 );

			SetDamage( 6, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 35 );
			SetResistance( ResistanceType.Energy, 30, 35 );

			SetSkill( SkillName.MagicResist, 45.1, 50.0 );
			SetSkill( SkillName.Tactics, 49.3, 64.0 );
			SetSkill( SkillName.FistFighting, 49.3, 64.0 );

			Fame = 900;
			Karma = 0;

			VirtualArmor = 20;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 20.9;
		}

		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 14; } }
		public override int Cloths{ get{ return 6; } }
		public override ClothType ClothType{ get{ return ClothType.Wooly; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay | FoodType.FruitsAndVegies; } }

		public DireGoat(Serial serial) : base(serial)
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
		}
	}
}