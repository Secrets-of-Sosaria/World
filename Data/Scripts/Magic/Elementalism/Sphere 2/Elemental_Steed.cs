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

				BaseMount mount = null;

				string elm = ElementalSpell.GetElement( Caster );

				if ( elm == "air" )
				{
					mount = new AirDragonElementalSteed();
				}
				else if ( elm == "earth" )
				{
					mount = new BearElementalSteed();
				}
				else if ( elm == "fire" )
				{
					mount = new PhoenixElementalSteed();
				}
				else if ( elm == "water" )
				{
					mount = new WaterBeetleElementalSteed();
				}

				if ( mount != null ) {
					SpellHelper.Summon( mount, Caster, 0x216, duration, false, false );
					mount.FixedParticles(0x3728, 8, 20, 5042, 0, 0, EffectLayer.Head );

					if ( elm == "water" )
						AddWater( mount );
				}
			}

			FinishSequence();
		}
	}
}