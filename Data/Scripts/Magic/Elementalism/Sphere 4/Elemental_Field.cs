using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells.Elementalism
{
	public class Elemental_Field_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Field", "Limite",
				215,
				9041,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Fourth; } }

		public Elemental_Field_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
					Effects.PlaySound( p, Caster.Map, 0x20C );
				}
				else if ( elm == "earth" )
				{
					Effects.PlaySound( p, Caster.Map, 0x162 );
				}
				else if ( elm == "fire" )
				{
					Effects.PlaySound( p, Caster.Map, 0x208 );
				}
				else if ( elm == "water" )
				{
					Effects.PlaySound( p, Caster.Map, 0x025 );
				}

				int itemID = eastToWest ? 0x398C : 0x3996;

				if ( elm == "air" )
					itemID = eastToWest ? 0x3967 : 0x3979;
				else if ( elm == "earth" )
					itemID = 0x5487;
				else if ( elm == "water" )
					itemID = 0x23B2;

				int damage = (int)(Caster.Skills[SkillName.Elementalism].Value / 10 );

				int nBenefit = (int)(Caster.Skills[SkillName.Elementalism].Value / 2);

				TimeSpan duration = TimeSpan.FromSeconds( ((15 + (Caster.Skills.Elementalism.Fixed / 5)) / 4) + nBenefit );

				for ( int i = -2; i <= 2; ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					new ElementalFieldItem( itemID, loc, Caster, Caster.Map, duration, i, damage );
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class ElementalFieldItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;
			private int m_Damage;

			public override bool BlocksFit{ get{ return true; } }

			public ElementalFieldItem( int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val ) : this( itemID, loc, caster, map, duration, val, 2 )
			{
			}

			public ElementalFieldItem( int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val, int damage ) : base( itemID )
			{
				bool canFit = SpellHelper.AdjustField( ref loc, map, 12, false );

				Visible = false;
				Movable = false;

				m_Caster = caster;

				m_End = DateTime.Now + duration;

				string elm = ElementalSpell.GetElement( m_Caster );

				if ( elm == "air" )
				{
					Hue = 0;
				}
				else if ( elm == "earth" )
				{
					Hue = 0;
				}
				else if ( elm == "fire" )
				{
					Light = LightType.Circle300;
					Hue = 0;
				}
				else if ( elm == "water" )
				{
					Hue = 0xB75;
				}

				MoveToWorld( loc, map );

				m_Damage = damage;

				m_Timer = new InternalTimer( this, TimeSpan.FromSeconds( Math.Abs( val ) * 0.2 ), caster.InLOS( this ), canFit );
				m_Timer.Start();
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			public ElementalFieldItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 2 ); // version

				writer.Write( m_Damage );
				writer.Write( m_Caster );
				writer.WriteDeltaTime( m_End );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 2:
					{
						m_Damage = reader.ReadInt();
						goto case 1;
					}
					case 1:
					{
						m_Caster = reader.ReadMobile();

						goto case 0;
					}
					case 0:
					{
						m_End = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, TimeSpan.Zero, true, true );
						m_Timer.Start();

						break;
					}
				}

				if( version < 2 )
					m_Damage = 2;
			}

			public override bool OnMoveOver( Mobile m )
			{
				if ( Visible && !Server.Spells.SpellHelper.isFriend( m_Caster, m ) )
				{
					if ( SpellHelper.CanRevealCaster( m ) )
						m_Caster.RevealingAction();
					
					m_Caster.DoHarmful( m );

					int damage = m_Damage;

					string elm = ElementalSpell.GetElement( m_Caster );

					if ( elm == "air" )
					{
						AOS.Damage( m, m_Caster, damage, 0, 0, 0, 0, 100 );
						m.BoltEffect( 0 );
					}
					else if ( elm == "earth" )
					{
						AOS.Damage( m, m_Caster, damage, 50, 0, 0, 50, 0 );
						m.PlaySound( 0x162 );
					}
					else if ( elm == "fire" )
					{
						AOS.Damage( m, m_Caster, damage, 0, 100, 0, 0, 0 );
						m.PlaySound( 0x208 );
					}
					else if ( elm == "water" )
					{
						AOS.Damage( m, m_Caster, damage, 0, 0, 100, 0, 0 );
						m.PlaySound( 0x025 );
						AddWater( m );
					}

					if ( m is BaseCreature )
						((BaseCreature) m).OnHarmfulSpell( m_Caster );
				}

				return true;
			}

			private class InternalTimer : Timer
			{
				private ElementalFieldItem m_Item;
				private bool m_InLOS, m_CanFit;

				private static Queue m_Queue = new Queue();

				public InternalTimer( ElementalFieldItem item, TimeSpan delay, bool inLOS, bool canFit ) : base( delay, TimeSpan.FromSeconds( 1.0 ) )
				{
					m_Item = item;
					m_InLOS = inLOS;
					m_CanFit = canFit;

					Priority = TimerPriority.FiftyMS;
				}

				protected override void OnTick()
				{
					if ( m_Item.Deleted )
						return;

					if ( !m_Item.Visible )
					{
						if ( m_InLOS && m_CanFit )
							m_Item.Visible = true;
						else
							m_Item.Delete();

						if ( !m_Item.Deleted )
						{
							m_Item.ProcessDelta();
						}
					}
					else if ( DateTime.Now > m_Item.m_End )
					{
						m_Item.Delete();
						Stop();
					}
					else
					{
						Map map = m_Item.Map;
						Mobile caster = m_Item.m_Caster;

						if ( map != null && caster != null )
						{
							foreach ( Mobile m in m_Item.GetMobilesInRange( 0 ) )
							{
								if ( (m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && !Server.Spells.SpellHelper.isFriend( caster, m ) )
									m_Queue.Enqueue( m );
							}

							while ( m_Queue.Count > 0 )
							{
								Mobile m = (Mobile)m_Queue.Dequeue();
								
								if ( SpellHelper.CanRevealCaster( m ) )
									caster.RevealingAction();

								caster.DoHarmful( m );

								int damage = m_Item.m_Damage;

								string elm = ElementalSpell.GetElement( caster );

								if ( elm == "air" )
								{
									AOS.Damage( m, caster, damage, 0, 0, 0, 0, 100 );
									m.BoltEffect( 0 );
								}
								else if ( elm == "earth" )
								{
									AOS.Damage( m, caster, damage, 50, 0, 0, 50, 0 );
									m.PlaySound( 0x162 );
								}
								else if ( elm == "fire" )
								{
									AOS.Damage( m, caster, damage, 0, 100, 0, 0, 0 );
									m.PlaySound( 0x208 );
								}
								else if ( elm == "water" )
								{
									AddWater( m );
									AOS.Damage( m, caster, damage, 0, 0, 100, 0, 0 );
									m.PlaySound( 0x025 );
								}

								if ( m is BaseCreature )
									((BaseCreature) m).OnHarmfulSpell( caster );
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private Elemental_Field_Spell m_Owner;

			public InternalTarget( Elemental_Field_Spell owner ) : base( Core.ML ? 10 : 12, true, TargetFlags.None )
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