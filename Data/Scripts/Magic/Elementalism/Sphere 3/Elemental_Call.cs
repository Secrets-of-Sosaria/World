using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Elementalism
{
	public class Elemental_Call_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Call", "Striga",
				269,
				9020,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Third; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.25 ); } }

		public Elemental_Call_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
				TimeSpan duration = TimeSpan.FromMinutes( (Caster.Skills[CastSkill].Value*27)/60 );

				BaseCreature m_Creature = new ElementalSteed();
					m_Creature.Delete();

				string elm = ElementalSpell.GetElement( Caster );

				if ( elm == "air" )
					m_Creature = new ElementalCalledAir();

				else if ( elm == "earth" )
					m_Creature = new ElementalCalledEarth();

				else if ( elm == "fire" )
					m_Creature = new ElementalCalledFire();

				else if ( elm == "water" )
					m_Creature = new ElementalCalledWater();

				SpellHelper.Summon( m_Creature, Caster, 0x216, duration, false, false );
				m_Creature.FixedParticles(0x3728, 8, 20, 5042, 0, 0, EffectLayer.Head );

				if ( elm == "water" )
					AddWater( m_Creature );
			}

			FinishSequence();
		}
	}
}