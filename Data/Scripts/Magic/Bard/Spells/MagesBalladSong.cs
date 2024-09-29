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
    public class MagesBalladSong : Song
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Mage's Ballad", "*plays a mage's ballad*",
            -1);

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(6); } }
        public override double RequiredSkill { get { return 55; } }
        public override int RequiredMana { get { return 15; } }

        public MagesBalladSong(Mobile caster, Item scroll): base(caster, scroll, m_Info){}

        public override void OnCast()
        {
			base.OnCast();

			bool sings = false;
 
            if (CheckSequence())
			{
				sings = true;
 
                double allvalue = (double)MusicSkill( Caster );

                    {
                        ArrayList targets = new ArrayList();

                        foreach (Mobile m in Caster.GetMobilesInRange( 10 ))
                        {
                            if ( isFriendly( Caster, m ) )
                                targets.Add(m);
                        }

                        for (int i = 0; i < targets.Count; ++i)
                        {
                            Mobile m = (Mobile)targets[i];

                            //TimeSpan duration = TimeSpan.FromSeconds(Caster.Skills[SkillName.Musicianship].Value * 0.375);
                            TimeSpan duration = TimeSpan.FromSeconds(allvalue/4 * 0.5);
                            int rounds = (int)(Caster.Skills[SkillName.Musicianship].Value * .16);

                            if (allvalue < 120)
                            { new ExpireTimer(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //2 mana
                            else if (allvalue < 240)
                            { new ExpireTimer1(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //3 mana
                            else if (allvalue < 360)
                            { new ExpireTimer2(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //4 mana
                            else if (allvalue < 480)
                            { new ExpireTimer3(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //5
                            else if (allvalue >= 480)
                            { new ExpireTimer4(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //10
                            else
                            { new ExpireTimer(m, 0, rounds, TimeSpan.FromSeconds(2)).Start(); }
                            //not required, just in case the else if dont cover it all, same as first if 

                            m.FixedParticles(0x376A, 9, 32, 5030, 0x256, 3, EffectLayer.Waist);
                            m.PlaySound(0x1F2);

							BuffInfo.RemoveBuff( m, BuffIcon.MagesBallad );
							BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.MagesBallad, 1063580, TimeSpan.FromSeconds( (double)( rounds * 2.0 ) ), m ) );
                        }
                    }

                FinishSequence();
            }
			BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
        }

        private class ExpireTimer : Timer
        {
            private Mobile m_Mobile;
            private int m_Round;
            private int m_Totalrounds;

            public ExpireTimer(Mobile m, int round, int totalrounds, TimeSpan delay)
                : base(delay)
            {
                m_Mobile = m;
                m_Round = round;
                m_Totalrounds = totalrounds;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.Mana += MyServerSettings.PlayerLevelMod( 6, m_Mobile );

                    if (m_Round >= m_Totalrounds)
                    {
                        m_Mobile.SendMessage("The effect of mage's ballad wears off.");
						BuffInfo.RemoveBuff( m_Mobile, BuffIcon.MagesBallad );
					}
                    else
                    {
                        m_Round += 1;
                        new ExpireTimer(m_Mobile, m_Round, m_Totalrounds, TimeSpan.FromSeconds(2)).Start();
                    }
                }
            }
        }

        private class ExpireTimer1 : Timer
        {
            private Mobile m_Mobile;
            private int m_Round;
            private int m_Totalrounds;

            public ExpireTimer1(Mobile m, int round, int totalrounds, TimeSpan delay)
                : base(delay)
            {
                m_Mobile = m;
                m_Round = round;
                m_Totalrounds = totalrounds;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.Mana += MyServerSettings.PlayerLevelMod( 7, m_Mobile );

                    if (m_Round >= m_Totalrounds)
                    {
                        m_Mobile.SendMessage("The effect of mage's ballad wears off.");
 						BuffInfo.RemoveBuff( m_Mobile, BuffIcon.MagesBallad );
					}
                    else
                    {
                        m_Round += 1;
                        new ExpireTimer1(m_Mobile, m_Round, m_Totalrounds, TimeSpan.FromSeconds(2)).Start();
                    }
                }
            }
        }

        private class ExpireTimer2 : Timer
        {
            private Mobile m_Mobile;
            private int m_Round;
            private int m_Totalrounds;

            public ExpireTimer2(Mobile m, int round, int totalrounds, TimeSpan delay)
                : base(delay)
            {
                m_Mobile = m;
                m_Round = round;
                m_Totalrounds = totalrounds;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.Mana += MyServerSettings.PlayerLevelMod( 8, m_Mobile );

                    if (m_Round >= m_Totalrounds)
                    {
                        m_Mobile.SendMessage("The effect of mage's ballad wears off.");
						BuffInfo.RemoveBuff( m_Mobile, BuffIcon.MagesBallad );
					}
                    else
                    {
                        m_Round += 1;
                        new ExpireTimer2(m_Mobile, m_Round, m_Totalrounds, TimeSpan.FromSeconds(2)).Start();
                    }
                }
            }
        }

        private class ExpireTimer3 : Timer
        {
            private Mobile m_Mobile;
            private int m_Round;
            private int m_Totalrounds;

            public ExpireTimer3(Mobile m, int round, int totalrounds, TimeSpan delay)
                : base(delay)
            {
                m_Mobile = m;
                m_Round = round;
                m_Totalrounds = totalrounds;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.Mana += MyServerSettings.PlayerLevelMod( 9, m_Mobile );

                    if (m_Round >= m_Totalrounds)
                    {
                        m_Mobile.SendMessage("The effect of mage's ballad wears off.");
						BuffInfo.RemoveBuff( m_Mobile, BuffIcon.MagesBallad );
					}
                    else
                    {
                        m_Round += 1;
                        new ExpireTimer3(m_Mobile, m_Round, m_Totalrounds, TimeSpan.FromSeconds(2)).Start();
                    }
                }
            }
        }

        private class ExpireTimer4 : Timer
        {
            private Mobile m_Mobile;
            private int m_Round;
            private int m_Totalrounds;

            public ExpireTimer4(Mobile m, int round, int totalrounds, TimeSpan delay)
                : base(delay)
            {
                m_Mobile = m;
                m_Round = round;
                m_Totalrounds = totalrounds;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.Mana += MyServerSettings.PlayerLevelMod( 10, m_Mobile );

                    if (m_Round >= m_Totalrounds)
                    {
                        m_Mobile.SendMessage("The effect of mage's ballad wears off.");
						BuffInfo.RemoveBuff( m_Mobile, BuffIcon.MagesBallad );
					}
                    else
                    {
                        m_Round += 1;
                        new ExpireTimer4(m_Mobile, m_Round, m_Totalrounds, TimeSpan.FromSeconds(2)).Start();
                    }
                }
            }
        }
    }
}