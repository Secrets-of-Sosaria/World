using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ape corpse" )]
	public class Gorakong : BaseCreature
	{
		[Constructable]
		public Gorakong () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorakong";
			Body = 464;
			BaseSoundID = 0x9E;

			SetStr( 336, 385 );
			SetDex( 96, 115 );
			SetInt( 281, 305 );

			SetHits( 202, 231 );
			SetMana( 0 );

			SetDamage( 7, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 50;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 50.9;

			PackItem( new Banana( Utility.RandomMinMax(5,20) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor, 2 );
		}

		public override int Meat{ get{ return 12; } }
		public override int Hides{ get{ return 22; } }
		public override int Cloths{ get{ return 10; } }
		public override ClothType ClothType{ get{ return ClothType.Furry; } }

		public Gorakong( Serial serial ) : base( serial )
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