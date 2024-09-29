using System;
using Server;
using Server.Items;
using System.Collections;
using Server.Gumps;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a jellyfish corpse" )]
	public class Jellyfish : BaseCreature
	{
		[Constructable]
		public Jellyfish () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a jellyfish";
			Body = 979;
			Hue = Utility.RandomList( 0xBA7, 0xBA8, 0xB94, 0xB64, 0xB3E, 0xAF8 );
			BaseSoundID = 456;
			CanSwim = true;
			CantWalk = true;

			SetStr( 188, 220 );
			SetDex( 51, 100 );
			SetInt( 28, 37 );

			SetHits( 112, 153 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Poison, 75 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.Tactics, 70.1, 80.0 );
			SetSkill( SkillName.FistFighting, 70.1, 80.0 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 20;

			AddItem( new LightSource() );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 1 );
		}

		public Jellyfish( Serial serial ) : base( serial )
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