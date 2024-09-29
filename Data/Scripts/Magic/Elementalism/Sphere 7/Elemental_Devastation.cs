using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Regions;
using Server.Mobiles;

namespace Server.Spells.Elementalism
{
	public class Elemental_Devastation_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Devastation", "Devasta",
				209,
				9022,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		public Elemental_Devastation_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				bool playerVsPlayer = false;

				if ( map != null )
				{
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), 5 );

					foreach ( Mobile m in eable )
					{
						Mobile pet = m;

						if ( Caster.Region == m.Region && Caster != m )
						{
							if ( m is BaseCreature )
								pet = ((BaseCreature)m).GetMaster();

							if ( Caster != pet )
							{
								targets.Add( m );

								if ( m.Player )
									playerVsPlayer = true;
							}
						}
					}

					eable.Free();
				}

				int nBenefit = (int)(Caster.Skills[CastSkill].Value / 5);

				double damage = GetNewAosDamage( 48, 1, 5, Caster.Player && playerVsPlayer ) + nBenefit;

				if ( targets.Count > 0 )
				{
					if (targets.Count > 1)
						damage = (damage * 2) / targets.Count;

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = (Mobile)targets[i];

						Region house = m.Region;

						double toDeal = damage;

						if( !(house is Regions.HouseRegion) )
						{
							Caster.DoHarmful( m );

							string elm = ElementalSpell.GetElement( Caster );

							if ( elm == "air" )
							{
								Point3D ert = new Point3D( ( m.X+1 ), ( m.Y+1 ), m.Z+5 );
								Effects.SendLocationEffect( ert, m.Map, 0x55A6, 30, 10, 0, 0 );
								m.PlaySound( 0x028 );
								SpellHelper.Damage( this, m, toDeal, 0, 0, 0, 0, 100 );
							}
							else if ( elm == "earth" )
							{
								Point3D ert = new Point3D( ( m.X+2 ), ( m.Y ), m.Z );
								Effects.SendLocationEffect( ert, m.Map, 0x55BB, 30, 10, 0xAC0-1, 0 );
								m.PlaySound( 0x207 );
								SpellHelper.Damage( this, m, toDeal, 100, 0, 0, 0, 0 );
							}
							else if ( elm == "fire" )
							{
								Point3D ert = new Point3D( ( m.X+2 ), ( m.Y+2 ), m.Z+15 );
								Effects.SendLocationEffect( ert, m.Map, 0x551A, 30, 10, 0, 0 );
								m.PlaySound( 0x345 );
								SpellHelper.Damage( this, m, toDeal, 0, 100, 0, 0, 0 );
							}
							else if ( elm == "water" )
							{
								Point3D ert = new Point3D( ( m.X+2 ), ( m.Y ), m.Z );
								Effects.SendLocationEffect( ert, m.Map, 0x55BB, 30, 10, 0, 0 );
								m.PlaySound( 0x64F );
								SpellHelper.Damage( this, m, toDeal, 0, 0, 100, 0, 0 );
							}
						}
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private Elemental_Devastation_Spell m_Owner;

			public InternalTarget( Elemental_Devastation_Spell owner ) : base( 12, true, TargetFlags.None )
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