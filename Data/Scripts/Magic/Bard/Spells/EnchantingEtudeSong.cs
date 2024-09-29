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
	public class EnchantingEtudeSong : Song
	{
		private static SpellInfo m_Info = new SpellInfo(
			"Enchanting Etude", "*plays an enchanting etude*",
			-1
			);
		
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2 ); } }
		public override double RequiredSkill{ get{ return 60.0; } }
		public override int RequiredMana{ get{ return 20; } }

		public EnchantingEtudeSong( Mobile caster, Item scroll) : base( caster, scroll, m_Info )
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
					string intt = "int";
						
					double duration = (double)(MusicSkill( Caster ) * 2);
						
					StatMod mod = new StatMod( StatType.Int, intt, + amount, TimeSpan.FromSeconds( duration ) );
						
					m.AddStatMod( mod );
						
					m.FixedParticles( 0x375A, 10, 15, 5017, 0x1F8, 3, EffectLayer.Waist );

					string args = String.Format("{0}", amount);
					BuffInfo.RemoveBuff( m, BuffIcon.EnchantingEtude );
					BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.EnchantingEtude, 1063563, 1063564, TimeSpan.FromSeconds( duration ), m, args.ToString(), true));
				}
			}

			BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
			FinishSequence();
		}
	}
}
