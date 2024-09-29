using System;
using Server;
using System.Collections;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Mystic
{
	public class WindRunner : MysticSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Wind Runner", "Beh Ra Mu Ahm",
				269,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3 ); } }
		public override int RequiredTithing{ get{ return 250; } }
		public override double RequiredSkill{ get{ return 70.0; } }
		public override int RequiredMana{ get{ return 50; } }
		public override int MysticSpellCircle{ get{ return 2; } }

		public WindRunner( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public static Hashtable TableWindRunning = new Hashtable();

		public static bool HasEffect( Mobile m )
		{
			return ( TableWindRunning[m] != null );
		}

		public static bool UnderEffect( Mobile m )
		{
			return TableWindRunning.Contains( m );
		}

		public static void RemoveEffect( Mobile m )
		{
			m.Send(SpeedControl.Disable);
			TableWindRunning.Remove( m );
			m.EndAction( typeof( WindRunner ) );
			BuffInfo.RemoveBuff( m, BuffIcon.WindRunner );
		}

		public override void OnCast()
		{
			Item shoes = Caster.FindItemOnLayer( Layer.Shoes );

            if ( Caster.Mounted )
            {
                Caster.SendMessage( "You cannot use this ability while on a mount!" );
            }
			else if ( shoes is Artifact_BootsofHermes || shoes is Artifact_SprintersSandals )
			{
                Caster.SendMessage( "You cannot use this ability while wearing those magical shoes!" );
			}
			else if ( shoes is HikingBoots && Caster.RaceID > 0 )
			{
                Caster.SendMessage( "You cannot use this ability while wearing hiking boots!" );
			}
			else
			{
				if ( !Caster.CanBeginAction( typeof( WindRunner ) ) )
				{
					WindRunner.RemoveEffect( Caster );
				}

				int TotalTime = (int)( Caster.Skills[SkillName.FistFighting].Value * 5 );
				TableWindRunning[Caster] = SpeedControl.MountSpeed;
				Caster.Send(SpeedControl.MountSpeed);
				new InternalTimer( Caster, TimeSpan.FromSeconds( TotalTime ) ).Start();
				BuffInfo.RemoveBuff( Caster, BuffIcon.WindRunner );
				BuffInfo.AddBuff( Caster, new BuffInfo( BuffIcon.WindRunner, 1063516, TimeSpan.FromSeconds( TotalTime ), Caster ) );
				Caster.BeginAction( typeof( WindRunner ) );
				Point3D air = new Point3D( ( Caster.X+1 ), ( Caster.Y+1 ), ( Caster.Z+5 ) );
				Effects.SendLocationParticles(EffectItem.Create(air, Caster.Map, EffectItem.DefaultDuration), 0x5590, 9, 32, 0, 0, 5022, 0);
				Caster.PlaySound( 0x64F );
			}

            FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_m;
			private DateTime m_Expire;

			public InternalTimer( Mobile Caster, TimeSpan duration ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 0.1 ) )
			{
				m_m = Caster;
				m_Expire = DateTime.Now + duration;
			}

			protected override void OnTick()
			{
				if ( DateTime.Now >= m_Expire )
				{
					WindRunner.RemoveEffect( m_m );
					Stop();
				}
			}
		}
	}
}