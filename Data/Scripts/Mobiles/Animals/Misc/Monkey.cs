using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a monkey corpse" )]
	public class Monkey : BaseCreature
	{
		[Constructable]
		public Monkey() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a monkey";
			Body = 892;
			BaseSoundID = 0x9E;

			SetStr( 10, 15 );
			SetDex( 20, 35 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );
			SetMana( 0 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 10 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Fire, 2, 4 );
			SetResistance( ResistanceType.Poison, 2, 4 );
			SetResistance( ResistanceType.Energy, 2, 4 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 45.1, 70.0 );

			Fame = 100;
			Karma = -100;

			VirtualArmor = 5;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 5.9;

			PackItem( new Banana( Utility.RandomMinMax(1,2) ) );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
		public override int Cloths{ get{ return 1; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }

		public Monkey( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}