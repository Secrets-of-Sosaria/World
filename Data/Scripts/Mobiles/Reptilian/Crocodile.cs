using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a reptile corpse" )]
	public class Crocodile : BaseCreature
	{
		[Constructable]
		public Crocodile() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a crocodile";
			Body = 377;
			BaseSoundID = 660;

			SetStr( 106, 130 );
			SetDex( 16, 35 );
			SetInt( 11, 20 );

			SetHits( 76, 90 );
			SetStam( 46, 65 );
			SetMana( 0 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.FistFighting, 40.1, 60.0 );

			Fame = 900;
			Karma = -900;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 57.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override int Skeletal{ get{ return Utility.Random(2); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Reptile; } }

		public Crocodile(Serial serial) : base(serial)
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