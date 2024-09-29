using System;
using Server.Targeting;
using Server.Network;
using Server.Regions;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Elementalism
{
	public class Elemental_Warp_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Warp", "Urzeala",
				215,
				9031
			);

		public override SpellCircle Circle { get { return SpellCircle.Third; } }

		public Elemental_Warp_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Server.Misc.WeightOverloading.IsOverloaded( Caster ) )
			{
				Caster.SendLocalizedMessage( 502359, "", 0x22 ); // Thou art too encumbered to move.
				return false;
			}

			return SpellHelper.CheckTravel( Caster, TravelCheckType.TeleportFrom );
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			IPoint3D orig = p;
			Map map = Caster.Map;

			SpellHelper.GetSurfaceTop( ref p );

			if ( Server.Misc.WeightOverloading.IsOverloaded( Caster ) )
			{
				Caster.SendLocalizedMessage( 502359, "", 0x22 ); // Thou art too encumbered to move.
			}
			else if ( !SpellHelper.CheckTravel( Caster, TravelCheckType.TeleportFrom ) )
			{
			}
			else if ( !SpellHelper.CheckTravel( Caster, map, new Point3D( p ), TravelCheckType.TeleportTo ) )
			{
			}
			else if ( map == null || !map.CanSpawnMobile( p.X, p.Y, p.Z ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( SpellHelper.CheckMulti( new Point3D( p ), map ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( CheckSequence() )
			{
				Point3D peto = new Point3D( p );
				BaseCreature.TeleportPets( Caster, peto, map, false );
				SpellHelper.Turn( Caster, orig );

				Mobile m = Caster;

				Point3D from = m.Location;
				Point3D to = new Point3D( p );

				m.Location = to;
				m.ProcessDelta();

				string elm = ElementalSpell.GetElement( Caster );

				if ( elm == "air" )
				{
					Point3D air1 = new Point3D( ( from.X ), ( from.Y ), from.Z+10 );
					Point3D air2 = new Point3D( ( to.X ), ( to.Y ), to.Z+10 );
					Effects.SendLocationEffect( air1, m.Map, 0x2A4E, 30, 10, 0, 0 );
					Effects.SendLocationEffect( air2, m.Map, 0x2A4E, 30, 10, 0, 0 );
					m.PlaySound( 0x029 );
				}
				else if ( elm == "earth" )
				{
					Point3D hands1 = new Point3D( ( from.X ), ( from.Y ), ( from.Z+5 ) );
					Point3D hands2 = new Point3D( ( to.X ), ( to.Y ), ( to.Z+5 ) );
					Effects.SendLocationEffect( hands1, m.Map, 0x3837, 23, 10, 0, 0 );
					Effects.SendLocationEffect( hands2, m.Map, 0x3837, 23, 10, 0, 0 );
					m.PlaySound( 0x65A );
				}
				else if ( elm == "fire" )
				{
					Effects.SendLocationEffect( from, m.Map, 0x3709, 30, 10, 0, 0 );
					Effects.SendLocationEffect( to, m.Map, 0x3709, 30, 10, 0, 0 );
					m.PlaySound( 0x208 );
				}
				else if ( elm == "water" )
				{
					Point3D water1 = new Point3D( ( from.X ), ( from.Y ), from.Z+5 );
					Point3D water2 = new Point3D( ( to.X ), ( to.Y ), to.Z+5 );
					Effects.SendLocationEffect( water1, m.Map, 0x23B2, 16, 0, 0 );
					Effects.SendLocationEffect( water2, m.Map, 0x23B2, 16, 0, 0 );
					m.PlaySound( 0x026 );
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private Elemental_Warp_Spell m_Owner;

			public InternalTarget( Elemental_Warp_Spell owner ) : base( Core.ML ? 11 : 12, true, TargetFlags.None )
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