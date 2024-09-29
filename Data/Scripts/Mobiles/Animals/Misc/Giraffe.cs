using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giraffe corpse" )]
	public class Giraffe : BaseCreature
	{
		[Constructable]
		public Giraffe() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a giraffe";
			Body = 894;
			BaseSoundID = 0x3F3;

			SetStr( 31, 59 );
			SetDex( 46, 65 );
			SetInt( 26, 40 );

			SetHits( 25, 37 );
			SetMana( 0 );

			SetDamage( 5, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.2, 29.0 );
			SetSkill( SkillName.FistFighting, 19.2, 29.0 );

			Fame = 600;
			Karma = 0;

			VirtualArmor = 26;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 45.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Cloths{ get{ return 8; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Timer.DelayCall( TimeSpan.FromSeconds( 1.5 ), new TimerStateCallback( SetLook ), c );
		}

		private void SetLook( object state )
		{
			Item c = state as Item;

			c.ItemID = Utility.RandomList( 0x65E8, 0x65E9 );
		}

		public Giraffe(Serial serial) : base(serial)
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