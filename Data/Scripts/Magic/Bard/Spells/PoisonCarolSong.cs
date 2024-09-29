using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Gumps;
using Server.Spells;
using Server.Misc;

namespace Server.Spells.Song
{
	public class PoisonCarolSong : Song
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Poison Carol", "*plays a poison carol*",
				-1
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 5 ); } }
		public override double RequiredSkill{ get{ return 50.0; } }
		public override int RequiredMana{ get{ return 12; } }
		
		public PoisonCarolSong( Mobile caster, Item scroll) : base( caster, scroll, m_Info )
		{
			
		}

        public override void OnCast()
        {
			base.OnCast();

			bool sings = false;
 
			if( CheckSequence() )
			{
				sings = true;
 
				ArrayList targets = new ArrayList();

				foreach ( Mobile m in Caster.GetMobilesInRange( 10 ) )
				{
					if ( isFriendly( Caster, m ) && m.PoisonResistance < MySettings.S_MaxResistance )
						targets.Add( m );
				}
				
				
				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];
					
					TimeSpan duration = TimeSpan.FromSeconds( (double)(MusicSkill( Caster ) * 2) );
                    int amount = MyServerSettings.PlayerLevelMod( (int)(MusicSkill( Caster ) / 16), Caster );
	
					if ( ( amount + m.PoisonResistance ) > MySettings.S_MaxResistance )
						amount = MySettings.S_MaxResistance - m.PoisonResistance;

					m.SendMessage( "Your resistance to poison has increased." );
					ResistanceMod mod1 = new ResistanceMod( ResistanceType.Poison, + amount );
						
					m.AddResistanceMod( mod1 );
						
					m.FixedParticles( 0x373A, 10, 15, 5012, 0x238, 3, EffectLayer.Waist );
						
					new ExpireTimer( m, mod1, duration ).Start();

					string args = String.Format("{0}", amount);
					BuffInfo.RemoveBuff( m, BuffIcon.PoisonCarol );
					BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.PoisonCarol, 1063581, 1063582, duration, m, args.ToString(), true));
				}
			}

			BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
			FinishSequence();
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mods;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mod;
			}

			public void DoExpire()
			{
				PlayerMobile dpm = m_Mobile as PlayerMobile;
				m_Mobile.RemoveResistanceMod( m_Mods );
				
				Stop();
			}

			protected override void OnTick()
			{
				if ( m_Mobile != null )
				{
					m_Mobile.SendMessage( "The effect of the poison carol wears off." );
					DoExpire();
				}
			}
		}
	}
}
