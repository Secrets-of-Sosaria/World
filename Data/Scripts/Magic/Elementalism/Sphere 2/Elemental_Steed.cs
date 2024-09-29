using System;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Elementalism
{
	public class Elemental_Steed_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Steed", "Faptura",
				269,
				9050
			);

		public override SpellCircle Circle { get { return SpellCircle.Second; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.25 ); } }

		public Elemental_Steed_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
				double time = Caster.Skills[CastSkill].Value*6;
					if ( time > 1500 ){ time = 1500.0; }
					if ( time < 480 ){ time = 480.0; }

				TimeSpan duration = TimeSpan.FromSeconds( time );

				BaseCreature m_Creature = new ElementalSteed();

				string elm = ElementalSpell.GetElement( Caster );

				if ( elm == "air" )
				{
					m_Creature.Name = "an air dragon";
					m_Creature.Body = 596;
					m_Creature.Hue = 0x9A3;
					m_Creature.BaseSoundID = 362;
					((BaseMount)m_Creature).ItemID = 596;
				}
				else if ( elm == "earth" )
				{
					m_Creature.Name = "a bear";
					m_Creature.Body = 23;
					m_Creature.Hue = 0;
					m_Creature.BaseSoundID = 0xA3;
					((BaseMount)m_Creature).ItemID = 23;
				}
				else if ( elm == "fire" )
				{
					m_Creature.Name = "a phoenix";
					m_Creature.Body = 243;
					m_Creature.Hue = 0xB73;
					m_Creature.BaseSoundID = 0x8F;
					((BaseMount)m_Creature).ItemID = 0x3E94;
				}
				else if ( elm == "water" )
				{
					m_Creature.Name = "a water beetle";
					m_Creature.Body = 0xA9;
					m_Creature.Hue = 0x555;
					m_Creature.BaseSoundID = 0x388;
					((BaseMount)m_Creature).ItemID = 0x3E95;
				}

				SpellHelper.Summon( m_Creature, Caster, 0x216, duration, false, false );
				m_Creature.FixedParticles(0x3728, 8, 20, 5042, 0, 0, EffectLayer.Head );

				if ( elm == "water" )
					AddWater( m_Creature );
			}

			FinishSequence();
		}
	}
}