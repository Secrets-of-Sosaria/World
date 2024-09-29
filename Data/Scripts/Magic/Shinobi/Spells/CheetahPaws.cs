using System;
using Server;
using System.Collections;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Shinobi
{
	public class CheetahPaws : ShinobiSpell
	{
		public override int spellIndex { get { return 290; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Cheetah Paws", "Chita no ashi",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public CheetahPaws( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public static Hashtable TableCheetahPaws = new Hashtable();

		public static bool HasEffect( Mobile m )
		{
			return ( TableCheetahPaws[m] != null );
		}

		public static bool UnderEffect( Mobile m )
		{
			return TableCheetahPaws.Contains( m );
		}

		public static void RemoveEffect( Mobile m )
		{
			m.Send(SpeedControl.Disable);
			TableCheetahPaws.Remove( m );
			m.EndAction( typeof( CheetahPaws ) );
			BuffInfo.RemoveBuff( m, BuffIcon.CheetahPaws );
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
				if ( !Caster.CanBeginAction( typeof( CheetahPaws ) ) )
				{
					CheetahPaws.RemoveEffect( Caster );
				}

				int TotalTime = (int)( Caster.Skills[SkillName.Ninjitsu].Value * 5 );
				TableCheetahPaws[Caster] = SpeedControl.MountSpeed;
				Caster.Send(SpeedControl.MountSpeed);
				new InternalTimer( Caster, TimeSpan.FromSeconds( TotalTime ) ).Start();
				BuffInfo.RemoveBuff( Caster, BuffIcon.CheetahPaws );
				BuffInfo.AddBuff( Caster, new BuffInfo( BuffIcon.CheetahPaws, 1063490, TimeSpan.FromSeconds( TotalTime ), Caster ) );
				Caster.BeginAction( typeof( CheetahPaws ) );
				Caster.PlaySound( 0x077 );
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
					CheetahPaws.RemoveEffect( m_m );
					Stop();
				}
			}
		}
	}
}