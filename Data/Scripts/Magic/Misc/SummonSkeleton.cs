using System;
using Server;
using Server.Items;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Magical
{
	public class SummonSkeletonSpell : MagicalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"", "", 
				266,
				9040,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.First; } }
		public override double RequiredSkill{ get{ return 0.0; } }
		public override int RequiredMana{ get{ return 1; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }
		
		public SummonSkeletonSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 1) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				TimeSpan duration = TimeSpan.FromMinutes( 60 );
				SpellHelper.Summon( new SummonSkeleton(), Caster, 0x48D, duration, false, false );
			}

			FinishSequence();
		}
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SummonSkeleton : BaseCreature
	{
		public override bool DeleteCorpseOnDeath { get { return Summoned; } }
		public override double DispelDifficulty { get { return 900.0; } }
		public override double DispelFocus { get { return 900.0; } }

		public override double GetFightModeRanking( Mobile m, FightMode acqType, bool bPlayerOnly )
		{
			return 200 / Math.Max( GetDistanceToSqrt( m ), 1.0 );
		}

		[Constructable]
		public SummonSkeleton() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a skeleton";
			Body = Utility.RandomList( 57, 168, 170, 327 );
			if ( Body == 327 ){ Hue = 0x9C4; }
			BaseSoundID = 451;

			SetStr( 196, 250 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 118, 150 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.FistFighting, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;

			ControlSlots = 1;
		}

		public SummonSkeleton( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}