using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
	public class VampiricEmbraceSpell : TransformationSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Vampiric Embrace", "Rel Xen An Sanct",
				203,
				9031,
				Reagent.BatWing,
				Reagent.NoxCrystal,
				Reagent.PigIron
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		public override double RequiredSkill{ get{ return 99.0; } }
		public override int RequiredMana{ get{ return 23; } }

		public override int Body
		{
			get
			{
				if ( Caster.RaceID > 0 )
					return 125;

				return Caster.Female ? 606 : 605;
			}
		}

		public override int Hue
		{
			get
			{
				if ( Caster.RaceID > 0 )
					return 0;

				return 0xB70;
			}
		}

		public override int FireResistOffset{ get{ return -25; } }

		public VampiricEmbraceSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void GetCastSkills( out double min, out double max )
		{
			if ( Caster.Skills[CastSkill].Value >= RequiredSkill )
			{
				min = 80.0;
				max = 120.0;
			}
			else
			{
				base.GetCastSkills( out min, out max );
			}
		}

		public override void DoEffect( Mobile m )
		{
			Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x373A, 1, 17, 1108, 7, 9914, 0 );
			Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x376A, 1, 22, 67, 7, 9502, 0 );
			Effects.PlaySound( m.Location, m.Map, 0x4B1 );

			BuffInfo.RemoveBuff( m, BuffIcon.VampiricEmbrace );
			BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.VampiricEmbrace, 1063609 ) );
		}
	}
}