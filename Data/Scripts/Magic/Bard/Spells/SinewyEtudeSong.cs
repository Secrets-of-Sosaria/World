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
	public class SinewyEtudeSong : Song
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Sinewy Etude", "*plays a sinewy etude*",
				-1
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2 ); } }
		public override double RequiredSkill{ get{ return 60.0; } }
		public override int RequiredMana{ get{ return 20; } }
		
		public SinewyEtudeSong( Mobile caster, Item scroll) : base( caster, scroll, m_Info )
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
					if ( isFriendly( Caster, m ) )
						targets.Add( m );
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];
					
                    int amount = MyServerSettings.PlayerLevelMod( (int)(MusicSkill( Caster ) / 16), Caster );
					string str = "str";
						
					double duration = (double)(MusicSkill( Caster ) * 2);
						
					StatMod mod = new StatMod( StatType.Str, str, + amount, TimeSpan.FromSeconds( duration ) );
						
					m.AddStatMod( mod );
						
					m.FixedParticles( 0x375A, 10, 15, 5017, 0x224, 3, EffectLayer.Waist );

					string args = String.Format("{0}", amount);
					BuffInfo.RemoveBuff( m, BuffIcon.SinewyEtude );
					BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.SinewyEtude, 1063587, 1063588, TimeSpan.FromSeconds( duration ), m, args.ToString(), true));
				}
			}

			BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
			FinishSequence();
		}
	}
}
