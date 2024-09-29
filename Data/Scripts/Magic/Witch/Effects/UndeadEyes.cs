using System;
using Server.Targeting;
using Server.Network;
using Server;

namespace Server.Spells.Undead
{
	public class UndeadEyesSpell : UndeadSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "", "", 239, 9021 );
		public override double RequiredSkill{ get{ return 10.0; } }
		public override int RequiredMana{ get{ return 0; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		
		public UndeadEyesSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
		
		public override void OnCast()
		{
			Caster.Target = new EyesSpellTarget( this );
		}

		public class DarkTimer : Timer
		{
			private Mobile m_Owner;

			public DarkTimer( Mobile owner, TimeSpan duration ) : base( duration )
			{
				m_Owner = owner;
				BuffInfo.RemoveBuff( owner, BuffIcon.EyesOfTheDead );
				BuffInfo.AddBuff( owner, new BuffInfo( BuffIcon.EyesOfTheDead, 1063496, duration, owner ) );
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m_Owner.EndAction( typeof( LightCycle ) );
				m_Owner.LightLevel = 0;
				BuffInfo.RemoveBuff( m_Owner, BuffIcon.EyesOfTheDead );
			}
		}

		private class EyesSpellTarget : Target
		{
			private Spell m_Spell;
			
			public EyesSpellTarget( Spell spell ) : base( 10, false, TargetFlags.None )
			{
				m_Spell = spell;
			}
			
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile && m_Spell.CheckSequence() )
				{
					Mobile targ = (Mobile)targeted;
					
					SpellHelper.Turn( m_Spell.Caster, targ );
					
					if ( targ.BeginAction( typeof( LightCycle ) ) )
					{
						int enhance = Server.Items.BasePotion.EnhancePotions( m_Spell.Caster );
						TimeSpan duration = TimeSpan.FromMinutes( Utility.Random( 15+enhance, 25+enhance ) );
						new DarkTimer( targ, duration ).Start();
						int level = (int)Math.Abs( LightCycle.DungeonLevel * ( m_Spell.Caster.Skills[SkillName.Necromancy].Base / 100 ) );
						
						if ( level > 25 || level < 0 )
							level = 25;

						level = 12;
						
						targ.LightLevel = level;
						
						targ.FixedParticles( 0x376A, 9, 32, 5007, EffectLayer.Waist );
						targ.PlaySound( 0x37A );
					}
					else
					{
						from.SendMessage( "{0} already have undead vision.", from == targ ? "You" : "They" );
					}
				}
				
				m_Spell.FinishSequence();
			}
			
			protected override void OnTargetFinish( Mobile from )
			{
				m_Spell.FinishSequence();
			}
		}
	}
}
