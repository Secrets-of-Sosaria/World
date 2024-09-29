using System;
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.Elementalism
{
	public class Elemental_Fall_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Fall", "Toamna",
				233,
				9042,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		public Elemental_Fall_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				if ( p is Item )
					p = ((Item)p).GetWorldLocation();

				List<Mobile> targets = new List<Mobile>();

				Map map = Caster.Map;

				bool playerVsPlayer = false;

				if ( map != null )
				{
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), 5 );

					foreach ( Mobile m in eable )
					{
						Mobile pet = m;
						if ( m is BaseCreature )
							pet = ((BaseCreature)m).GetMaster();

						if ( Caster.Region == m.Region && Caster != m && Caster != pet && Caster.InLOS( m ) && m.Blessed == false && Caster.CanBeHarmful( m, true ) )
						{
							targets.Add( m );

							if ( m.Player )
								playerVsPlayer = true;
						}
					}

					eable.Free();
				}

				int nBenefit = (int)(Caster.Skills[CastSkill].Value / 5);

				double damage = GetNewAosDamage( 51, 1, 5, playerVsPlayer ) + nBenefit;

				if ( targets.Count > 0 )
				{
					Effects.PlaySound( p, Caster.Map, 0x160 );

					if (targets.Count > 1)
						damage = (damage * 2) / targets.Count;

					double toDeal;
					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = targets[i];

						toDeal  = damage;

						toDeal *= GetDamageScalar( m );
						Caster.DoHarmful( m );

						string elm = ElementalSpell.GetElement( Caster );

						if ( elm == "air" )
						{
							Point3D wet = new Point3D( ( m.X+2 ), ( m.Y+2 ), m.Z+15 );
							Effects.SendLocationEffect( wet, m.Map, 0x5508, 30, 10, 0, 0 );
							m.PlaySound( 0x5CA );
							SpellHelper.Damage( this, m, toDeal, 50, 0, 0, 0, 50 );
						}
						else if ( elm == "earth" )
						{
							Point3D ert = new Point3D( ( m.X+2 ), ( m.Y ), m.Z+15 );
							Effects.SendLocationEffect( ert, m.Map, 0x5562, 30, 10, 0xACC-1, 0 );
							m.PlaySound( 0x207 );
							SpellHelper.Damage( this, m, toDeal, 50, 0, 0, 50, 0 );
						}
						else if ( elm == "fire" )
						{
							Point3D flam = new Point3D( ( m.X+2 ), ( m.Y ), m.Z+15 );
							Effects.SendLocationEffect( flam, m.Map, 0x5562, 30, 10, 0, 0 );
							m.PlaySound( 0x658 );
							SpellHelper.Damage( this, m, toDeal, 50, 50, 0, 0, 0 );
						}
						else if ( elm == "water" )
						{
							Point3D wet = new Point3D( ( m.X+2 ), ( m.Y ), m.Z+15 );
							Effects.SendLocationEffect( wet, m.Map, 0x5492, 30, 10, 0xB75-1, 0 );
							m.PlaySound( 0x64F );
							SpellHelper.Damage( this, m, toDeal, 50, 0, 50, 0, 0 );
						}
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private Elemental_Fall_Spell m_Owner;

			public InternalTarget( Elemental_Fall_Spell owner ) : base( Core.ML ? 10 : 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}