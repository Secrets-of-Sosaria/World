using System;
using Server.Items;
using Server.Regions;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a ghastly corpse" )]
	public class GraveSeeker : BaseCreature
	{
		private Timer m_Timer;

		[Constructable]
		public GraveSeeker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a grave seeker";
			Body = 8;
			Hue = 0x47E;
			BaseSoundID = 0x4F5;

			SetStr( 146, 170 );
			SetDex( 116, 135 );
			SetInt( 16, 30 );

			SetHits( 200 );
			SetMana( 0 );

			SetDamage( 8, 15 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 60, 80 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 95.1, 100.0 );
			SetSkill( SkillName.Tactics, 95.1, 120.0 );
			SetSkill( SkillName.FistFighting, 95.1, 120.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 30;

			PackItem( new GraveDust(5) );

			m_Timer = new GiantToad.TeleportTimer( this, 0x1FE );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool BleedImmune{ get{ return true; } }

		public GraveSeeker( Serial serial ) : base( serial )
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