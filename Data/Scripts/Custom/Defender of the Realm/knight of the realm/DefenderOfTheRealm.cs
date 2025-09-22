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
using Server.Custom.DefenderOfTheRealm.Vow;

namespace Server.Custom.DefenderOfTheRealm.Knight
{
    public class DefenderOfRealm : BaseCreature
    {
        [Constructable]
        public DefenderOfRealm() : base(AIType.AI_Thief, FightMode.None, 10, 1, 0.4, 1.6)
        {
            InitStats( 125, 55, 65 ); 
			Name = this.Female ? NameList.RandomName( "female" ) : NameList.RandomName( "male" );
			Title = "Defender of the Realm";
            HairHue = Utility.RandomHairHue(); 
			Body = this.Female? 0x191: 0x191;
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
            chest.Hue = 0x35;
            AddItem(chest);
            Item legs = new PlateLegs();
            legs.Hue = 0x35;
            AddItem(legs);
            Item arms = new PlateArms();
            arms.Hue = 0x35;
            AddItem(arms);
            Item gloves = new PlateGloves();
            gloves.Hue = 0x35;
            AddItem(gloves);
            Item gorget = new PlateGorget();
            gorget.Hue = 0x35;
            AddItem(gorget);
        }

        public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( InRange( m, 4 ) && !InRange( oldLocation, 4 ) )
			{
				if ( m is PlayerMobile && !m.Hidden ) 
				{
					switch (Utility.Random(16))
					{
							case 0: Say("The Defenders of the Realm are in need of reinforcements!"); break;
							case 1: Say("Slay many a foul beast and make our land safer!"); break;
							case 2: Say("By decree of the king, we shall rid this land of evil!"); break;
							case 3: Say("Stand tall, mighty warriors of the realm! Our loved ones count on thy courage!"); break;
							case 4: Say("Steel your heart, for restless darkness roams these lands!"); break;
							case 5: Say("Prove thy valor in the name of our king!"); break;
                            case 6: Say("Honor is it's own reward for the worthy!");break;
                            case 7: Say("Raise thy blade in the name of virtue!");break;
                            case 8: Say("Beware! Many dangers lie ahead!");break;
                            case 9: Say("The foul hordes shall be made headless by the culling of their generals!");break;
                            case 10: Say("Many have we lost in our struggle against darkness, but we shall not give it rest!");break;
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
            private DefenderOfRealm m_Npc;
            private static TimeSpan Delay = TimeSpan.FromHours(6);
			private static Dictionary<PlayerMobile,DateTime> LastUsers = new Dictionary<PlayerMobile,DateTime>();

            public GiveVowEntry(Mobile from, DefenderOfRealm npc) : base(6146)
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
                    mobile.SendMessage("You must be alive to receive a Vow of Honor.");
                    return;
                }
                if (mobile.Backpack == null)
                {
                    mobile.SendMessage("You have no backpack to receive the Vow of honor.");
                    return;
                }
                if (LastUsers.TryGetValue(mobile, out lastUse))
    			{
    			    TimeSpan cooldown = Delay - (DateTime.UtcNow - lastUse);
    			    if (cooldown > TimeSpan.Zero)
    			    {
				        m_Npc.Say(String.Format("I'll have another contract for you in  {0} hour{1} and {2} minute{3}.",
  					    cooldown.Hours, cooldown.Hours == 1 ? "" : "s",
  					    cooldown.Minutes, cooldown.Minutes == 1 ? "" : "s"));
    			        return;
    			    } 
    			}
                if(CanGetVow(mobile))
				{
					LastUsers[mobile] = DateTime.UtcNow;
                    VowOfHonor vow = new VowOfHonor(mobile);
                    m_From.Backpack.DropItem(vow);

                    if (vow.Parent == mobile.Backpack)
                    {
                        mobile.SendGump(new SpeechGump( mobile, "Defender of the Realm", SpeechFunctions.SpeechText( m_Npc, mobile, "Defender of the Realm" ) ));
                        mobile.SendMessage("You receive a Vow of Honor.");
                    }
                    else
                    {
                        vow.Delete();
                        mobile.SendMessage("You do not have enough inventory space to receive a Vow of Honor.");
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

        public DefenderOfRealm(Serial serial) : base(serial) { }

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