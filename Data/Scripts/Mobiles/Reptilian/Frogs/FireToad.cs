using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire toad corpse" )]
	public class FireToad : BaseCreature
	{
		private Timer m_Timer;

		[Constructable]
		public FireToad () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire toad";
			Body = 270;
			Hue = 0xB73;
			BaseSoundID = 0x266;

			SetStr( 56, 75 );
			SetDex( 96, 105 );
			SetInt( 31, 45 );

			SetHits( 56, 80 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Psychology, 60.1, 75.0 );
			SetSkill( SkillName.Magery, 60.1, 75.0 );
			SetSkill( SkillName.MagicResist, 75.2, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.FistFighting, 70.1, 100.0 );

			Fame = 2000;
			Karma = -2000;

			VirtualArmor = 12;
			PackItem( new SulfurousAsh( 30 ) );

			AddItem( new LightSource() );

			m_Timer = new GiantToad.TeleportTimer( this, 0x1CC );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }

		public FireToad( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
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