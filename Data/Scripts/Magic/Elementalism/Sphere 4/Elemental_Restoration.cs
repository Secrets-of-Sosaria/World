using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Elementalism
{
	public class Elemental_Restoration_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Restoration", "Restabili",
				204,
				9061
			);

		public override SpellCircle Circle { get { return SpellCircle.Fourth; } }

		public Elemental_Restoration_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( m is BaseCreature && ((BaseCreature)m).IsAnimatedDead )
			{
				Caster.SendLocalizedMessage( 1061654 ); // You cannot heal that which is not alive.
			}
			else if ( m.IsDeadBondedPet )
			{
				Caster.SendLocalizedMessage( 1060177 ); // You cannot heal a creature that is already dead!
			}
			else if ( m is Golem )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x3B2, 500951 ); // You cannot heal that.
			}
			else if ( m.Poisoned || Server.Items.MortalStrike.IsWounded( m ) )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398 );
			}
			else if ( CheckBSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				int toHeal = (int)(Caster.Skills[CastSkill].Value * 0.4);
				toHeal += Utility.Random( 1, 10 );
				toHeal = MyServerSettings.PlayerLevelMod( toHeal, Caster );

				SpellHelper.Heal( toHeal, m, Caster );

				string elm = ElementalSpell.GetElement( Caster );
				int hue = 0;

				if ( elm == "air" )
					hue = 0xBB4;

				else if ( elm == "earth" )
					hue = 0xB44;

				else if ( elm == "fire" )
					hue = 0;

				else if ( elm == "water" )
					hue = 0xB3F;

				Point3D loc1 = new Point3D( m.X, m.Y, m.Z+10 );
				Point3D loc2 = new Point3D( m.X-1, m.Y, m.Z+5 );
				Point3D loc3 = new Point3D( m.X, m.Y-1, m.Z+5 );
				Point3D loc4 = new Point3D( m.X+1, m.Y+1, m.Z+15 );

				Effects.SendLocationEffect( loc1, m.Map, 0x5469, 30, 10, hue, 0 );
				Effects.SendLocationEffect( loc2, m.Map, 0x5469, 30, 10, hue, 0 );
				Effects.SendLocationEffect( loc3, m.Map, 0x5469, 30, 10, hue, 0 );
				Effects.SendLocationEffect( loc4, m.Map, 0x5469, 30, 10, hue, 0 );

				m.PlaySound( 0x65C );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private Elemental_Restoration_Spell m_Owner;

			public InternalTarget( Elemental_Restoration_Spell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}