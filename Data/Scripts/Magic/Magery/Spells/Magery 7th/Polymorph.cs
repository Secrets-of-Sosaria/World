using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Shinobi;
using Server.Misc;

namespace Server.Spells.Seventh
{
	public class PolymorphSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Polymorph", "Vas Ylem Rel",
				221,
				9002,
				Reagent.Bloodmoss,
				Reagent.SpidersSilk,
				Reagent.MandrakeRoot
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		private int m_NewBody;

		public PolymorphSpell( Mobile caster, Item scroll, int body ) : base( caster, scroll, m_Info )
		{
			m_NewBody = body;
		}

		public PolymorphSpell( Mobile caster, Item scroll ) : this(caster,scroll,0)
		{
		}

		public override bool CheckCast()
		{
			if( TransformationSpellHelper.UnderTransformation( Caster ) )
			{
				Caster.SendLocalizedMessage( 1061633 ); // You cannot polymorph while in that form.
				return false;
			}
			else if ( DisguiseTimers.IsDisguised( Caster ) )
			{
				Caster.SendLocalizedMessage( 502167 ); // You cannot polymorph while disguised.
				return false;
			}
			else if ( !Caster.CanBeginAction( typeof( PolymorphSpell ) ) )
			{
				EndPolymorph( Caster );
				return false;
			}
			else if ( m_NewBody == 0 )
			{
				Gump gump = new NewPolymorphGump( Caster, Scroll );
				Caster.SendGump( gump );
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( !Caster.CanBeginAction( typeof( PolymorphSpell ) ) )
			{
				EndPolymorph( Caster );
			}
			else if( TransformationSpellHelper.UnderTransformation( Caster ) )
			{
				Caster.SendLocalizedMessage( 1061633 ); // You cannot polymorph while in that form.
			}
			else if ( DisguiseTimers.IsDisguised( Caster ) )
			{
				Caster.SendLocalizedMessage( 502167 ); // You cannot polymorph while disguised.
			}
			else if ( !Caster.CanBeginAction( typeof( Deception ) ) || !Caster.CanBeginAction( typeof( IncognitoSpell ) ) || (Caster.IsBodyMod && Caster.RaceID != Caster.BodyMod) )
			{
				DoFizzle();
			}
			else if ( CheckSequence() )
			{
				if ( Caster.BeginAction( typeof( PolymorphSpell ) ) )
				{
					if ( m_NewBody != 0 )
					{
						if ( !((Body)m_NewBody).IsHuman )
						{
							Mobiles.IMount mt = Caster.Mount;

							if ( mt != null )
							{
								Server.Mobiles.EtherealMount.EthyDismount( Caster );
								mt.Rider = null;
							}
						}

						if ( Caster.RaceID > 0 && ( m_NewBody == 0x190 || m_NewBody == 0x191 ) )
							m_NewBody = 0x3CA;

						Caster.BodyMod = m_NewBody;

						if ( m_NewBody == 400 || m_NewBody == 401 )
							Caster.HueMod = Utility.RandomSkinColor();
						else
							Caster.HueMod = 0;

						Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 0, 0, 5042, 0 );
						Effects.PlaySound( Caster, Caster.Map, 0x201 );

						BaseArmor.ValidateMobile( Caster );
						BaseClothing.ValidateMobile( Caster );

						BuffInfo.RemoveBuff( Caster, BuffIcon.Polymorph );
						BuffInfo.AddBuff( Caster, new BuffInfo( BuffIcon.Polymorph, 1063619 ) );

						StopTimer( Caster );

						Timer t = new InternalTimer( Caster );

						m_Timers[Caster] = t;

						t.Start();
					}
				}
				else
				{
					Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				}
			}

			FinishSequence();
		}

		private static Hashtable m_Timers = new Hashtable();

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );
			}

			return ( t != null );
		}

		private static void EndPolymorph( Mobile m )
		{
			if( !m.CanBeginAction( typeof( PolymorphSpell ) ) )
			{
				m.BodyMod = 0;
				m.HueMod = -1;
				m.RaceBody();
				m.EndAction( typeof( PolymorphSpell ) );

				BuffInfo.RemoveBuff( m, BuffIcon.Polymorph );

				Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 0, 0, 5042, 0 );
				Effects.PlaySound( m, m.Map, 0x201 );

				BaseArmor.ValidateMobile( m );
				BaseClothing.ValidateMobile( m );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 0 ) )
			{
				m_Owner = owner;

				int val = (int)( Spell.ItemSkillValue( m_Owner, SkillName.Magery, false ) ) * 5;

				if ( val > 625 )
					val = 625;

				Delay = TimeSpan.FromSeconds( val );
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				EndPolymorph( m_Owner );
			}
		}
	}
}
