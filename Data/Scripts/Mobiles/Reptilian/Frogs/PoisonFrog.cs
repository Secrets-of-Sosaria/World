using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a frog corpse" )]
	public class PoisonFrog : BaseCreature
	{
		private Timer m_Timer;

		[Constructable]
		public PoisonFrog() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a marsh frog";
			Body = 270;
			Hue = Utility.RandomList( 0x5AC,0x5A3,0x59A,0x591,0x588,0x57F );
			BaseSoundID = 0x266;

			SetStr( 92, 140 );
			SetDex( 12, 50 );
			SetInt( 22, 40 );

			SetHits( 56, 84 );
			SetMana( 0 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 70, 90 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.Poisoning, 70.1, 100.0 );
			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 65.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 32;

			Item Venom = new VenomSack();
				Venom.Name = "deadly venom sack";
				AddItem( Venom );

			m_Timer = new GiantToad.TeleportTimer( this, 0x1CC );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }

		public PoisonFrog(Serial serial) : base(serial)
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
			m_Timer = new GiantToad.TeleportTimer( this, 0x1CC );
			m_Timer.Start();
		}
	}
}