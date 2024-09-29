using System;
using Server.Items;
using Server.Engines.Plants;

namespace Server.Mobiles
{
	[CorpseName( "a kuthulu corpse" )]
	public class Kuthulu : BaseCreature
	{
		private Timer m_Timer;

		[Constructable]
		public Kuthulu() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

			if ( Utility.RandomBool() )
			{
				Name = "a kuthulu";
				Body = 352;
				BaseSoundID = 357;

				SetStr( 601, 750 );
				SetDex( 126, 175 );
				SetInt( 201, 250 );

				SetHits( 450 );

				SetDamage( 16, 20 );

				SetDamageType( ResistanceType.Physical, 60 );
				SetDamageType( ResistanceType.Cold, 20 );
				SetDamageType( ResistanceType.Energy, 20 );

				SetResistance( ResistanceType.Physical, 25, 35 );
				SetResistance( ResistanceType.Fire, 15, 25 );
				SetResistance( ResistanceType.Cold, 15, 25 );
				SetResistance( ResistanceType.Poison, 40, 50 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 70.1, 80.0 );
				SetSkill( SkillName.Magery, 70.1, 80.0 );
				SetSkill( SkillName.Meditation, 70.1, 80.0 );
				SetSkill( SkillName.MagicResist, 70.1, 85.0 );
				SetSkill( SkillName.Tactics, 55.1, 65.0 );
				SetSkill( SkillName.FistFighting, 60.1, 80.0 );

				Fame = 9500;
				Karma = -9500;

				VirtualArmor = 34;
			}
			else
			{
				Name = "an azathoth";
				Body = 222;
				BaseSoundID = 357;

				SetStr( 801, 950 );
				SetDex( 126, 175 );
				SetInt( 201, 250 );

				SetHits( 650 );

				SetDamage( 22, 26 );

				SetDamageType( ResistanceType.Physical, 60 );
				SetDamageType( ResistanceType.Cold, 20 );
				SetDamageType( ResistanceType.Energy, 20 );

				SetResistance( ResistanceType.Physical, 45, 55 );
				SetResistance( ResistanceType.Fire, 25, 35 );
				SetResistance( ResistanceType.Cold, 15, 25 );
				SetResistance( ResistanceType.Poison, 60, 70 );
				SetResistance( ResistanceType.Energy, 40, 50 );

				SetSkill( SkillName.Psychology, 90.1, 100.0 );
				SetSkill( SkillName.Magery, 90.1, 100.0 );
				SetSkill( SkillName.Meditation, 90.1, 100.0 );
				SetSkill( SkillName.MagicResist, 90.1, 105.0 );
				SetSkill( SkillName.Tactics, 75.1, 85.0 );
				SetSkill( SkillName.FistFighting, 80.1, 100.0 );

				Fame = 9500;
				Karma = -9500;

				VirtualArmor = 44;

			}

			PackReg( 24, 45 );

			m_Timer = new GiantToad.TeleportTimer( this, 0x1FE );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			if ( Body == 222 ){ AddLoot( LootPack.FilthyRich, 2 ); } else { AddLoot( LootPack.Rich, 2 ); } 
		}

		public override Poison PoisonImmune
		{
			get
			{
				if ( Body == 222 ){ return Poison.Lethal; } return Poison.Greater;
			}
		}

		public override int Meat{ get{ return 3; } }

		public Kuthulu( Serial serial ) : base( serial )
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
			m_Timer = new GiantToad.TeleportTimer( this, 0x1FE );
			m_Timer.Start();
		}
	}
}