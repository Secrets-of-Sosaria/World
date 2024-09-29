using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a snake corpse" )]
	[TypeAlias( "Server.Mobiles.Iceserpant" )]
	public class IceSnake : BaseCreature
	{
		[Constructable]
		public IceSnake() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ice snake";
			Body = 950;
			Hue = 0xB55;
			BaseSoundID = 219;

			SetStr( 116, 145 );
			SetDex( 26, 50 );
			SetInt( 66, 85 );

			SetHits( 60, 87 );
			SetMana( 0 );

			SetDamage( 5, 13 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 90 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.Anatomy, 27.5, 50.0 );
			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 75.1, 80.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 22;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 7; } }
		public override HideType HideType{ get{ return HideType.Frozen; } }

		public IceSnake(Serial serial) : base(serial)
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