using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Spells.Elementalism
{
	public class Elemental_Lord_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Lord", "Dumnezeu",
				269,
				9010,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.25 ); } }

		public Elemental_Lord_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 3) > Caster.FollowersMax )
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
				TimeSpan duration = TimeSpan.FromMinutes( (Caster.Skills[CastSkill].Value*9)/60 );

				BaseCreature m_Creature = new ElementalSteed();
					m_Creature.Delete();

				string elm = ElementalSpell.GetElement( Caster );
				int hue = 0;

				if ( elm == "air" )
				{
					m_Creature = new ElementalLordAir();
					hue = 0xB42;
				}
				else if ( elm == "earth" )
				{
					m_Creature = new ElementalLordEarth();
					hue = 0xB26;
				}
				else if ( elm == "fire" )
				{
					m_Creature = new ElementalLordFire();
					hue = 0x981;
				}
				else if ( elm == "water" )
				{
					m_Creature = new ElementalLordWater();
					hue = 0xB3E;
				}

				SpellHelper.Summon( m_Creature, Caster, 0x216, duration, false, false );

				Point3D loc = new Point3D( m_Creature.X+1, m_Creature.Y+1, m_Creature.Z+10 );
				Item gate = new ElementalEffect( 0x3EED, 5.0, null );
				gate.Name = "magic portal";
				gate.Hue = hue;
				gate.Movable = false;
				gate.Light = LightType.Circle300;
				gate.MoveToWorld( loc, m_Creature.Map );
				m_Creature.PlaySound( 0x20E );
				if ( elm == "water" ){ AddWater( m_Creature ); }
			}

			FinishSequence();
		}
	}
}