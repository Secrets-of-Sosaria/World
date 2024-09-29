using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Shinobi
{
	public class MysticShuriken : ShinobiSpell
	{
		public override int spellIndex { get { return 296; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Mystic Shuriken", "Misutikku Shuriken",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public MysticShuriken( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				Mobile source = Caster;

				SpellHelper.Turn( Caster, m );

				double damage = GetNewAosDamage( 40, 1, 5, m );

				// Do the effects
				source.MovingParticles( m, 0x27AC, 7, 0, false, false, 0, 0, 0 );
				source.PlaySound( 0x5D2 );

				// Deal the damage
				SpellHelper.Damage( this, m, damage, 100, 0, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MysticShuriken m_Owner;

			public InternalTarget( MysticShuriken owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}