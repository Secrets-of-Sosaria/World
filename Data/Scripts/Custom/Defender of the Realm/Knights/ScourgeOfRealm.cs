using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps; 
using Server.Network; 
using Server.Targeting; 
using Server.ContextMenus;
using Server.Custom.DefenderOfTheRealm.Vow.VowOfTheScourge;

namespace Server.Custom.DefenderOfTheRealm.Scourge
{
    public class ScourgeOfRealm : BaseCreature
    {
        private DateTime m_NextSpeechTime;
        [Constructable]
        public ScourgeOfRealm() : base(AIType.AI_Thief, FightMode.None, 10, 1, 0.4, 1.6)
        {
            InitStats( 125, 55, 65 ); 
			Name = this.Female ? NameList.RandomName( "female" ) : NameList.RandomName( "male" );
			Title = "Scourge of the Realm";
            HairHue = Utility.RandomHairHue(); 
			Body = this.Female? 0x191: 0x190;
            SpeechHue = Utility.RandomTalkHue();
			Hue = Utility.RandomSkinHue(); 
			Utility.AssignRandomHair( this );
			if(( !this.Female ))
            {
                FacialHairItemID = Utility.RandomList( 0, 8254, 8255, 8256, 8257, 8267, 8268, 8269 );
            }
            AddItem( new Boots( Utility.RandomBirdHue() ) );
            AddItem( new Cloak( Utility.RandomBirdHue() ) );
            Item chest = new PlateChest();
            chest.Hue = 0x26;
            AddItem(chest);
            Item legs = new PlateLegs();
            legs.Hue = 0x26;
            AddItem(legs);
            Item arms = new PlateArms();
            arms.Hue = 0x26;
            AddItem(arms);
            Item gloves = new PlateGloves();
            gloves.Hue = 0x26;
            AddItem(gloves);
            Item gorget = new PlateGorget();
            gorget.Hue = 0x26;
            AddItem(gorget);
        }

        public override void OnMovement( Mobile m, Point3D oldLocation )
        {
            if ( InRange( m, 6 ) && !InRange( oldLocation, 2 ) )
            {
                if ( m is PlayerMobile && !m.Hidden ) 
                {
                    if ( DateTime.UtcNow >= m_NextSpeechTime )
                    {
                        switch (Utility.Random(11))
                        {
                            case 0: Say("The Weak shall fall before us!"); break;
                            case 1: Say("Blood and fire will cleanse this land!"); break;
                            case 2: Say("The King's virtue is but a frail lie!"); break;
                            case 3: Say("Those that do not kneel shall be broken!"); break;
                            case 4: Say("Steel your heart, for we are heirs of endless darkness!"); break;
                            case 5: Say("All glory belongs to us!"); break;
                            case 6: Say("Sosaria shall burn!"); break;
                            case 7: Say("Raise thy blade in the name of vengeance!"); break;
                            case 8: Say("We shall make covenant with the ghosts of this land!"); break;
                            case 9: Say("We shall remove the rot of this realm!"); break;
                            case 10: Say("Hail the scourge, bane of virtue!"); break;
                        }

                        m_NextSpeechTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
                    }
                }
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new GiveVowEntry(from, this));
        }

        private class GiveVowEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private ScourgeOfRealm m_Npc;
            private static TimeSpan Delay = TimeSpan.FromHours(6);
			private static Dictionary<PlayerMobile,DateTime> LastUsers = new Dictionary<PlayerMobile,DateTime>();

            public GiveVowEntry(Mobile from, ScourgeOfRealm npc) : base(6146)
            {
                m_From = from;
                m_Npc = npc;
            }

            public override void OnClick()
            {
                if( !( m_From is PlayerMobile ) )
					return;
				
				if (m_From == null || m_From.Deleted || m_Npc == null || m_Npc.Deleted)
                    return;

                PlayerMobile mobile = (PlayerMobile) m_From;
                DateTime lastUse;

                if (!mobile.CheckAlive())
                {
                    mobile.SendMessage("You must be alive to receive a Vow of the Scourge.");
                    return;
                }
                else if (mobile.Backpack == null)
                {
                    mobile.SendMessage("You have no backpack to receive the Vow of the Scourge.");
                    return;
                }
                else if (LastUsers.TryGetValue(mobile, out lastUse))
                {
                    TimeSpan cooldown = Delay - (DateTime.UtcNow - lastUse);
                    if (cooldown > TimeSpan.Zero)
                    {
                        m_Npc.Say(String.Format("I'll have another Vow for you in  {0} hour{1} and {2} minute{3}.",
                          cooldown.Hours, cooldown.Hours == 1 ? "" : "s",
                          cooldown.Minutes, cooldown.Minutes == 1 ? "" : "s"));
                        return;
                    }
                }
                else if (mobile.Karma > 0)
                {
                    m_Npc.Say("Thou has yet to prove thy value! I shall not deal with those that dabble in meaningless virtue!");
                    return;
                }
                if (CanGetVow(mobile))
                    {
                        LastUsers[mobile] = DateTime.UtcNow;
                        VowOfTheScourge vow = new VowOfTheScourge(mobile);
                        m_From.Backpack.DropItem(vow);

                        if (vow.Parent == mobile.Backpack)
                        {
                            mobile.SendGump(new SpeechGump(mobile, "Scourge of the Realm", SpeechFunctions.SpeechText(m_Npc, mobile, "Scourge of the Realm")));
                            mobile.SendMessage("You receive a Vow of the Scourge.");
                        }
                        else
                        {
                            vow.Delete();
                            mobile.SendMessage("You do not have enough inventory space to receive a Vow of the Scourge.");
                        }
                    }
            }
            private bool CanGetVow(PlayerMobile asker)
			{
				if(!LastUsers.ContainsKey(asker))
				{
					LastUsers.Add(asker,DateTime.UtcNow);
					return true;
				}
				else
				{
					if(DateTime.UtcNow-LastUsers[asker] < Delay)
					{
						return false;
					}
					else
					{
						LastUsers[asker]=DateTime.UtcNow;
						return true;
					}
				}
			}
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            base.OnSpeech(e);

            Mobile from = e.Mobile;

            if (from == null || !(from is PlayerMobile))
                return;

            if (!from.InRange(this.Location, 3))
                return;

            string speech = e.Speech.ToLower();

            if (speech.IndexOf("reward") >= 0 && from.Karma < 0)
            {
                from.SendGump(new Server.Custom.DefenderOfTheRealm.RewardGump(from, false, 0));
                Say("These are the rewards I can offer thee.");
            } 
            else if (speech.IndexOf("reward") >= 0 && from.Karma > 0)
            {
                Say("I shall not dabble with the slaves of virtue!");
            }
        }

        public ScourgeOfRealm(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}