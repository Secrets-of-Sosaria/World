using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Magical
{
	public class IdentifySpell : MagicalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"", "",
				239,
				9021
			);

		public override SpellCircle Circle { get { return SpellCircle.First; } }
		public override double RequiredSkill{ get{ return 0.0; } }
		public override int RequiredMana{ get{ return 1; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		public IdentifySpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Object i )
		{
			if ( !Caster.CanSee( i ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( Server.Items.ArtifactManual.LookupTheItem( Caster, i ) )
			{
				CheckSequence();
				Caster.PlaySound( 0x1FD );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private IdentifySpell m_Owner;

			public InternalTarget( IdentifySpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Item )
					m_Owner.Target( o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}