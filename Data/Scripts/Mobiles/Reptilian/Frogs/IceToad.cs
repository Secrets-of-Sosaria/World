using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ice toad corpse" )]
	[TypeAlias( "Server.Mobiles.IceToad" )]
	public class IceToad : BaseCreature
	{
		private Timer m_Timer;

		[Constructable]
		public IceToad() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ice toad";
			Body = 270;
			BaseSoundID = 0x26B;
			Hue = 0xB78;

			SetStr( 96, 120 );
			SetDex( 26, 45 );
			SetInt( 31, 40 );

			SetHits( 66, 80 );
			SetMana( 0 );

			SetDamage( 7, 19 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 75 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.FistFighting, 40.1, 60.0 );

			Fame = 800;
			Karma = -800;

			VirtualArmor = 29;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 79.1;

			AddItem( new LightSource() );

			m_Timer = new GiantToad.TeleportTimer( this, 0x1CC );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Frozen; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public IceToad(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_Timer = new GiantToad.TeleportTimer( this, 0x1CC );
			m_Timer.Start();
		}
	}
}