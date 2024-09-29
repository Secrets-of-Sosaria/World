using System;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells.Elementalism
{
	public class Elemental_Wall_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Wall", "Perete",
				227,
				9011,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Third; } }

		public Elemental_Wall_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				int dx = Caster.Location.X - p.X;
				int dy = Caster.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if ( rx >= 0 && ry >= 0 )
				{
					eastToWest = false;
				}
				else if ( rx >= 0 )
				{
					eastToWest = true;
				}
				else if ( ry >= 0 )
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				string elm = ElementalSpell.GetElement( Caster );

				if ( elm == "air" )
				{
					Effects.PlaySound( p, Caster.Map, 0x016 );
				}
				else if ( elm == "earth" )
				{
					Effects.PlaySound( p, Caster.Map, 0x65A );
				}
				else if ( elm == "fire" )
				{
					Effects.PlaySound( p, Caster.Map, 0x5CF );
				}
				else if ( elm == "water" )
				{
					Effects.PlaySound( p, Caster.Map, 0x364 );
				}

				for ( int i = -1; i <= 1; ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					bool canFit = SpellHelper.AdjustField( ref loc, Caster.Map, 22, true );

					if ( !canFit )
						continue;

					Item item = new InternalItem( loc, Caster.Map, Caster, false, false );
					Item block = new InternalItem( loc, Caster.Map, Caster, true, false );
					Item water = new InternalItem( loc, Caster.Map, Caster, false, true );
					Item vine = new InternalItem( loc, Caster.Map, Caster, true, true );

					Effects.SendLocationParticles( item, 0x376A, 9, 10, 0, 0, 5025, 0 );
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;

			public override bool BlocksFit{ get{ return true; } }

			public InternalItem( Point3D loc, Map map, Mobile caster, bool blocker, bool extra ) : base( 0x82 )
			{
				string elm = ElementalSpell.GetElement( caster );

				if ( extra && blocker && elm == "water" )
				{
					ItemID = 0xCF2;
					Hue = 0xB51;
					Name = "seaweed";
				}
				else if ( extra && elm == "water" )
				{
					ItemID = Utility.RandomList( 0x5691, 0x5692 );
					Hue = 0xB3F;
					Name = "water";
				}
				else if ( blocker )
				{
					ItemID = 0x0082;
				}
				else if ( elm == "air" )
				{
					ItemID = 0x2007;
					Name = "tornado";
				}
				else if ( elm == "earth" )
				{
					ItemID = Utility.RandomList( 0x8E8, 0x8E2 );
					Hue = Utility.RandomList( 0xABE, 0xABF, 0xAC0 );
					Name = "mud";
				}
				else if ( elm == "fire" )
				{
					ItemID = 0x55B1;
					Light = LightType.Circle225;
					Name = "fire";
				}
				else if ( elm == "water" )
				{
					ItemID = 0xCEE;
					Hue = 0xB51;
					Name = "seaweed";
				}

				Visible = false;
				Movable = false;

				MoveToWorld( loc, map );

				m_Caster = caster;

				if ( caster.InLOS( this ) && blocker && !extra )
					Visible = false;
				else if ( caster.InLOS( this ) )
					Visible = true;
				else
					Delete();

				if ( Deleted )
					return;

				int nBenefit = (int)(caster.Skills[SkillName.Elementalism].Value / 2);

				m_Timer = new InternalTimer( this, TimeSpan.FromSeconds( 10.0 + nBenefit ) );
				m_Timer.Start();

				m_End = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 1 ); // version

				writer.WriteDeltaTime( m_End );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 1:
					{
						m_End = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_End - DateTime.Now );
						m_Timer.Start();

						break;
					}
					case 0:
					{
						TimeSpan duration = TimeSpan.FromSeconds( 10.0 );

						m_Timer = new InternalTimer( this, duration );
						m_Timer.Start();

						m_End = DateTime.Now + duration;

						break;
					}
				}
			}

			public override bool OnMoveOver( Mobile m )
			{
				if ( Server.Spells.SpellHelper.isFriend( m_Caster, m ) )
					return true;

				return false;
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer( InternalItem item, TimeSpan duration ) : base( duration )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private Elemental_Wall_Spell m_Owner;

			public InternalTarget( Elemental_Wall_Spell owner ) : base( Core.ML ? 10 : 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
					m_Owner.Target( (IPoint3D)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}