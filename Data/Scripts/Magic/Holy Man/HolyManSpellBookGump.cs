using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Misc; 
using Server.Network; 
using Server.Spells; 
using Server.Spells.HolyMan; 
using Server.Prompts; 

namespace Server.Gumps 
{ 
	public class HolyManSpellbookGump : Gump 
	{
		private HolyManSpellbook m_Book; 

		private Map m_Map_1;
		private int m_X_1;
		private int m_Y_1;
		private bool m_NotHave_1;

		private Map m_Map_2;
		private int m_X_2;
		private int m_Y_2;
		private bool m_NotHave_2;

		public bool HasSpell(Mobile from, int spellID)
		{
			if ( m_Book.RootParentEntity == from )
				return (m_Book.HasSpell(spellID));
			else
				return false;
		}

		public HolyManSpellbookGump( Mobile from, HolyManSpellbook book, int page ) : base( 100, 100 ) 
		{
			from.PlaySound( 0x55 );
			m_Book = book;
			string color = "#dddddd";

			m_Map_1 = Map.Internal;
			m_X_1 = 0;
			m_Y_1 = 0;
			m_NotHave_1 = false;
			m_Map_2 = Map.Internal;
			m_X_2 = 0;
			m_Y_2 = 0;
			m_NotHave_2 = false;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7005, 2995);
			AddImage(0, 0, 7006);
			AddImage(0, 0, 7024, 2736);
			AddImage(131, 125, 7051);
			AddImage(431, 125, 7051);

			int PriorPage = page - 1;
				if ( PriorPage < 1 ){ PriorPage = 9; }
			int NextPage = page + 1;
				if ( NextPage > 9 ){ NextPage = 1; }

			string info = "";

			AddButton(72, 45, 4014, 4014, PriorPage, GumpButtonType.Reply, 0);
			AddButton(590, 48, 4005, 4005, NextPage, GumpButtonType.Reply, 0);

			AddHtml( 107, 46, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>PRAYER BOOK</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 398, 48, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>PRAYER BOOK</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

			if ( page == 1 )
			{
				int SpellsInBook = 14;
				int SafetyCatch = 0;
				int SpellsListed = 769;
				string SpellName = "";

				int x = 84;
				int y = 95;
				int o = 95;
				int v = 45;

				while ( SpellsInBook > 0 )
				{
					SpellsListed++;
					SafetyCatch++;

					if ( this.HasSpell( from, SpellsListed) )
					{
						SpellsInBook--;

						if ( SpellsListed == 770 ){ SpellName = "Banish"; }
						else if ( SpellsListed == 771 ){ SpellName = "Dampen Spirit"; }
						else if ( SpellsListed == 772 ){ SpellName = "Enchant"; }
						else if ( SpellsListed == 773 ){ SpellName = "Hammer of Faith"; }
						else if ( SpellsListed == 774 ){ SpellName = "Heavenly Light"; }
						else if ( SpellsListed == 775 ){ SpellName = "Nourish"; }
						else if ( SpellsListed == 776 ){ SpellName = "Purge"; }
						else if ( SpellsListed == 777 ){ SpellName = "Rebirth"; }
						else if ( SpellsListed == 778 ){ SpellName = "Sacred Boon"; }
						else if ( SpellsListed == 779 ){ SpellName = "Sanctify"; }
						else if ( SpellsListed == 780 ){ SpellName = "Seance"; }
						else if ( SpellsListed == 781 ){ SpellName = "Smite"; }
						else if ( SpellsListed == 782 ){ SpellName = "Touch of Life"; }
						else if ( SpellsListed == 783 ){ SpellName = "Trial by Fire"; }

						AddHtml( x+30, y, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + SpellName + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(x, y-4, 7049, 7049, SpellsListed, GumpButtonType.Reply, 0);
						y=y+v;

						if ( SafetyCatch == 7 ){ x = 382; y = o; }
					}

					if ( SafetyCatch > 14 ){ SpellsInBook = 0; }
				}
			}
			else if ( page == 9 )
			{
				string lowreg = "Magic from lower reagent properties can affect the amount of piety needed to invoke the prayer. ";
					if ( MyServerSettings.LowerReg() < 1 )
						lowreg = "";

				info = "In order to learn the ways of the light, you must pursue proficiency in healing and spiritualism. One must seek out the graves of 14 priests, which are spread throughout the lands. Find their resting places, speak their mantra, and claim theirholy symbols which contains the power granted from the gods. Placing the symbols onto this book will add the prayer, but be quick about it. Anyone that calls forth their symbols will cause it to appear no matter where it is in the land, taking it from another that may possess it. You will need to banish evil to use such prayers. Find creatures like demons and the undead...those that carry gold, and slay them while holding the symbol where trinkets go. Although their gold will vanish, your symbol will increase in piety that will deplete as you use these prayers. You do not need to hold the symbol while praying, but only when dispatching such evil. The symbol does not need to be in your possession either, as prayers will use the piety wherever it is. " + lowreg + "Although most prayers rely on your Spiritualism skill alone, there are also some elements that will have greater effect based on your Healing skill. Go forth Priest, and rid the world of evil.";

				AddHtml( 78, 80, 250, 314, @"<BODY><BASEFONT Color=" + color + ">" + info + "</BASEFONT></BODY>", (bool)false, (bool)true);

				info = "Magic Toolbars: Here are the commands you can use (include the bracket) to manage magic toolbars that might help you play better.<br><br>[holyspell1 - Opens the 1st priest spell bar editor.<BR><BR>[holyspell2 - Opens the 2nd priest spell bar editor.<BR><BR>[holytool1 - Opens the 1st priest spell bar.<BR><BR>[holytool2 - Opens the 2nd priest spell bar.<BR><BR>[holyclose1 - Closes the 1st priest spell bar.<BR><BR>[holyclose2 - Closes the 2nd priest spell bar.<BR><BR>Below are the [ commands you can either type to quickly cast a particular spell, or set a hot key to issue this command and cast the spell.<BR><BR>[HMBanish<BR>    Cast Banish<BR><BR>[HMDampenSpirit<BR>    Cast Dampen Spirit<BR><BR>[HMEnchant<BR>    Cast Enchant<BR><BR>[HMHammerFaith<BR>    Cast Hammer of Faith<BR><BR>[HMHeavenlyLight<BR>    Cast Heavenly Light<BR><BR>[HMNourish<BR>    Cast Nourish<BR><BR>[HMPurge<BR>    Cast Purge<BR><BR>[HMRebirth<BR>    Cast Rebirth<BR><BR>[HMSacredBoon<BR>    Cast Sacred Boon<BR><BR>[HMSanctify<BR>    Cast Sanctify<BR><BR>[HMSeance<BR>    Cast Seance<BR><BR>[HMSmite<BR>    Cast Smite<BR><BR>[HMTouchLife<BR>    Cast Touch of Life<BR><BR>[HMTrialFire<BR>    Cast Trial by Fire<BR><BR>";

				AddHtml( 366, 80, 250, 314, @"<BODY><BASEFONT Color=" + color + ">" + info + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}
			else
			{
				int icon1 = 0;
				string grav1 = "";
				string name1 = "";
				string pity1 = "";
				string skil1 = "";
				string mana1 = "";
				string text1 = "";
				int z1 = 280;

				int icon2 = 0;
				string grav2 = "";
				string name2 = "";
				string pity2 = "";
				string skil2 = "";
				string mana2 = "";
				string text2 = "";
				int z2 = 280;

				Map placer_1 = Map.Internal;
				int xc_1 = 0;
				int yc_1 = 0;

				Map placer_2 = Map.Internal;
				int xc_2 = 0;
				int yc_2 = 0;

				if ( page == 2 )
				{
					grav1 = Worlds.GetTown( 0, "the Village of Springvale", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Banish";
					pity1 = "120";
					skil1 = "60";
					mana1 = "30";
					text1 = ""; if ( !this.HasSpell( from, 770) ){ m_NotHave_1 = true; z1=220; text1 = "Patriarch Morden rests south of the Village of Springvale<br>" + grav1 + "<br><br>Mantra: exilium<BR><BR>"; }
					text1 = text1 + "Sends demons and the dead back to the realms of hell.";
					icon1 = 0x965;

					grav2 = Worlds.GetTown( 0, "the Village of Whisper", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Dampen Spirit";
					pity2 = "140";
					skil2 = "70";
					mana2 = "35";
					text2 = ""; if ( !this.HasSpell( from, 771) ){ m_NotHave_2 = true; z2=220; text2 = "Archbishop Halyrn rests by the Village of Whisper<br>" + grav2 + "<br><br>Mantra: accipe spiritum<BR><BR>"; }
					text2 = text2 + "Absorbs mana from others and bestows it to the priest.";
					icon2 = 0x966;
				}
				else if ( page == 3 )
				{
					grav1 = Worlds.GetTown( 0, "the City of Kuldara", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Enchant";
					pity1 = "180";
					skil1 = "90";
					mana1 = "45";
					text1 = ""; if ( !this.HasSpell( from, 772) ){ m_NotHave_1 = true; z1=220; text1 = "Bishop Leantre rests in the Kuldar Cemetery<br>" + grav1 + "<br><br>Mantra: fascinare<BR><BR>"; }
					text1 = text1 + "Temporarily imbues a weapon with holy powers.";
					icon1 = 0x967;

					grav2 = Worlds.GetTown( 0, "the City of Elidor", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Hammer of Faith";
					pity2 = "100";
					skil2 = "50";
					mana2 = "25";
					text2 = ""; if ( !this.HasSpell( from, 773) ){ m_NotHave_2 = true; z2=220; text2 = "Deacon Wilems rests in the City of Elidor<br>" + grav2 + "<br><br>Mantra: malleo fidei<BR><BR>"; }
					text2 = text2 + "Temporarily summons a hammer from the gods.";
					icon2 = 0x968;
				}
				else if ( page == 4 )
				{
					grav1 = Worlds.GetTown( 0, "the City of Britain", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Heavenly Light";
					pity1 = "20";
					skil1 = "10";
					mana1 = "5";
					text1 = ""; if ( !this.HasSpell( from, 774) ){ m_NotHave_1 = true; z1=220; text1 = "Drumat the Apostle rests by the City of Britain<br>" + grav1 + "<br><br>Mantra: caelesti lumine<BR><BR>"; }
					text1 = text1 + "Destroys the darkness, allowing for one to see better.";
					icon1 = 0x969;

					grav2 = Worlds.GetTown( 0, "the Town of Moon", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Nourish";
					pity2 = "20";
					skil2 = "10";
					mana2 = "5";
					text2 = ""; if ( !this.HasSpell( from, 775) ){ m_NotHave_2 = true; z2=220; text2 = "Vincent the Priest rests by the Town of Moon<br>" + grav2 + "<br><br>Mantra: famem prohibere<BR><BR>"; }
					text2 = text2 + "The priest is able to help those that are starving or thirsty.";
					icon2 = 0x96A;
				}
				else if ( page == 5 )
				{
					grav1 = Worlds.GetTown( 0, "the Town of Renika", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Purge";
					pity1 = "80";
					skil1 = "40";
					mana1 = "20";
					text1 = ""; if ( !this.HasSpell( from, 776) ){ m_NotHave_1 = true; z1=220; text1 = "Abigayl the Preacher rests near the Church of the Divine in the Town of Renika<br>" + grav1 + "<br><br>Mantra: deiectionem<BR><BR>"; }
					text1 = text1 + "Removes curses and other ailing effects.";
					icon1 = 0x96B;

					grav2 = Worlds.GetTown( 0, "Greensky Village", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Rebirth";
					pity2 = "400";
					skil2 = "80";
					mana2 = "40";
					text2 = ""; if ( !this.HasSpell( from, 777) ){ m_NotHave_2 = true; z2=220; text2 = "Cardinal Greggs rests near the Greensky Village<br>" + grav2 + "<br><br>Mantra: reditus vitae<BR><BR>"; }
					text2 = text2 + "Brings one back to life, or summons an orb to resurrect the priest later on.";
					icon2 = 0x96C;
				}
				else if ( page == 6 )
				{
					grav1 = Worlds.GetTown( 0, "the Village of Grey", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Sacred Boon";
					pity1 = "40";
					skil1 = "20";
					mana1 = "10";
					text1 = ""; if ( !this.HasSpell( from, 778) ){ m_NotHave_1 = true; z1=220; text1 = "Father Michal rests by the Village of Grey<br>" + grav1 + "<br><br>Mantra: sacrum munus<BR><BR>"; }
					text1 = text1 + "Surrounds one with a holy aura that heals wounds much quicker.";
					icon1 = 0x96E;

					grav2 = Worlds.GetTown( 0, "the City of Montor", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Sanctify";
					pity2 = "60";
					skil2 = "30";
					mana2 = "15";
					text2 = ""; if ( !this.HasSpell( from, 779) ){ m_NotHave_2 = true; z2=220; text2 = "Sister Tiana rests south of the City of Montor<br>" + grav2 + "<br><br>Mantra: benedicite<BR><BR>"; }
					text2 = text2 + "The gods grant the priest greater strength, speed, and intelligence.";
					icon2 = 0x96D;
				}
				else if ( page == 7 )
				{
					grav1 = Worlds.GetTown( 0, "the Village of Islegem", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Seance";
					pity1 = "120";
					skil1 = "60";
					mana1 = "30";
					text1 = ""; if ( !this.HasSpell( from, 780) ){ m_NotHave_1 = true; z1=220; text1 = "Brother Kurklan rests near the Village of Islegem<br>" + grav1 + "<br><br>Mantra: spiritus mundi<BR><BR>"; }
					text1 = text1 + "Allows the priest to enter the realm of the dead, avoiding any harm.";
					icon1 = 0x96F;

					grav2 = Worlds.GetTown( 0, "the City of Lodoria", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Smite";
					pity2 = "80";
					skil2 = "40";
					mana2 = "20";
					text2 = ""; if ( !this.HasSpell( from, 781) ){ m_NotHave_2 = true; z2=220; text2 = "Edwin the Pope rests in the Lodoria Cemetery<br>" + grav2 + "<br><br>Mantra: percutiat<BR><BR>"; }
					text2 = text2 + "Calls down a bolt from the heavens, doing double damage to demons and undead.";
					icon2 = 0x970;
				}
				else if ( page == 8 )
				{
					grav1 = Worlds.GetTown( 0, "the Town of Devil Guard", Map.Internal, out placer_1, out xc_1, out yc_1 );
					name1 = "Touch of Life";
					pity1 = "40";
					skil1 = "20";
					mana1 = "10";
					text1 = ""; if ( !this.HasSpell( from, 782) ){ m_NotHave_1 = true; z1=220; text1 = "Xephyn the Monk rests near the Town of Devil Guard<br>" + grav1 + "<br><br>Mantra: tactus vitae<BR><BR>"; }
					text1 = text1 + "Restores health and stamina to the weary.";
					icon1 = 0x971;

					grav2 = Worlds.GetTown( 0, "the Village of Fawn", Map.Internal, out placer_2, out xc_2, out yc_2 );
					name2 = "Trial by Fire";
					pity2 = "500";
					skil2 = "30";
					mana2 = "15";
					text2 = ""; if ( !this.HasSpell( from, 783) ){ m_NotHave_2 = true; z2=220; text2 = "Chancellor Davis rests on an island near the Village of Fawn<br>" + grav2 + "<br><br>Mantra: igne iudicii<BR><BR>"; }
					text2 = text2 + "Engulfs the priest in holy flames, reflecting magic back at the caster.";
					icon2 = 0x972;
				}

				m_Map_1 = placer_1;
				m_X_1 = xc_1;
				m_Y_1 = yc_1;
				m_Map_2 = placer_2;
				m_X_2 = xc_2;
				m_Y_2 = yc_2;

				AddImage(75, 80, icon1, 1071);
				AddHtml( 129, 93, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + name1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Piety:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + pity1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + skil1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + mana1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 78, z1, 250, 175, @"<BODY><BASEFONT Color=" + color + ">" + text1 + "</BASEFONT></BODY>", (bool)false, (bool)false);

				AddImage(362, 80, icon2, 1071);
				AddHtml( 417, 93, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + name2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 422, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Piety:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 484, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + pity2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 422, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 484, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + skil2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 422, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 484, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + mana2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 366, z2, 250, 175, @"<BODY><BASEFONT Color=" + color + ">" + text2 + "</BASEFONT></BODY>", (bool)false, (bool)false);

				if ( Sextants.HasSextant( from ) && m_X_1 > 0 && m_NotHave_1 )
					AddButton(73, 368, 10461, 10461, 98000+page, GumpButtonType.Reply, 0);

				if ( Sextants.HasSextant( from ) && m_X_2 > 0 && m_NotHave_2 )
					AddButton(592, 368, 10461, 10461, 99000+page, GumpButtonType.Reply, 0);
			}
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile; 

			from.CloseGump( typeof( Sextants.MapGump ) );

			if ( info.ButtonID >= 99000 )
			{
				int pg = info.ButtonID - 99000;
				from.SendGump( new HolyManSpellbookGump( from, m_Book, pg ) );
				from.SendGump( new Sextants.MapGump( from, m_Map_2, m_X_2, m_Y_2, null ) );
			}
			else if ( info.ButtonID >= 98000 )
			{
				int pg = info.ButtonID - 98000;
				from.SendGump( new HolyManSpellbookGump( from, m_Book, pg ) );
				from.SendGump( new Sextants.MapGump( from, m_Map_1, m_X_1, m_Y_1, null ) );
			}
			else if ( info.ButtonID < 700 && info.ButtonID > 0 )
			{
				from.SendSound( 0x55 );
				int page = info.ButtonID;
				if ( page < 1 ){ page = 9; }
				if ( page > 9 ){ page = 1; }
				from.SendGump( new HolyManSpellbookGump( from, m_Book, page ) );
			}
			else if ( info.ButtonID > 700 && HasSpell(from, info.ButtonID) )
			{
				if ( info.ButtonID == 770 ){ new BanishEvilSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 771 ){ new DampenSpiritSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 772 ){ new EnchantSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 773 ){ new HammerOfFaithSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 774 ){ new HeavenlyLightSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 775 ){ new NourishSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 776 ){ new PurgeSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 777 ){ new RebirthSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 778 ){ new SacredBoonSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 779 ){ new SanctifySpell( from, null ).Cast(); }
				else if ( info.ButtonID == 780 ){ new SeanceSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 781 ){ new SmiteSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 782 ){ new TouchOfLifeSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 783 ){ new TrialByFireSpell( from, null ).Cast(); }

				from.SendGump( new HolyManSpellbookGump( from, m_Book, 1 ) );
			}
			else
				from.PlaySound( 0x55 );
		}
	}
}