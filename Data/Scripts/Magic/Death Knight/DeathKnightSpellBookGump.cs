using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Misc; 
using Server.Network; 
using Server.Spells; 
using Server.Spells.DeathKnight; 
using Server.Prompts; 

namespace Server.Gumps 
{ 
	public class DeathKnightSpellbookGump : Gump 
	{
		private DeathKnightSpellbook m_Book;

		private Map m_Map_1;
		private int m_X_1;
		private int m_Y_1;
		private bool m_NotHave_1;

		private Map m_Map_2;
		private int m_X_2;
		private int m_Y_2;
		private bool m_NotHave_2;

		public bool HasSpell( Mobile from, int spellID )
		{
			if ( m_Book.RootParentEntity == from )
				return (m_Book.HasSpell(spellID));
			else
				return false;
		}

		public DeathKnightSpellbookGump( Mobile from, DeathKnightSpellbook book, int page ) : base( 100, 100 ) 
		{
			from.PlaySound( 0x55 );
			m_Book = book;

			m_Map_1 = Map.Internal;
			m_X_1 = 0;
			m_Y_1 = 0;
			m_NotHave_1 = false;
			m_Map_2 = Map.Internal;
			m_X_2 = 0;
			m_Y_2 = 0;
			m_NotHave_2 = false;

			string color = "#df5e5e";

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7005, 2873);
			AddImage(0, 0, 7006);
			AddImage(0, 0, 7024, 2736);
			AddImage(69, 53, 7046);
			AddImage(373, 53, 7046);

			int PriorPage = page - 1;
				if ( PriorPage < 1 ){ PriorPage = 9; }
			int NextPage = page + 1;
				if ( NextPage > 9 ){ NextPage = 1; }

			string sGrave = "";
			string info = "";

			AddButton(72, 45, 4014, 4014, PriorPage, GumpButtonType.Reply, 0);
			AddButton(590, 48, 4005, 4005, NextPage, GumpButtonType.Reply, 0);

			AddHtml( 107, 46, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>DEATH MAGIC</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 398, 48, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>DEATH MAGIC</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

			if ( page == 1 )
			{
				int SpellsInBook = 14;
				int SafetyCatch = 0;
				int SpellsListed = 749;
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

						if ( SpellsListed == 750 ){ SpellName = "Banish"; }
						else if ( SpellsListed == 751 ){ SpellName = "Demonic Touch"; }
						else if ( SpellsListed == 752 ){ SpellName = "Devil Pact"; }
						else if ( SpellsListed == 753 ){ SpellName = "Grim Reaper"; }
						else if ( SpellsListed == 754 ){ SpellName = "Hag Hand"; }
						else if ( SpellsListed == 755 ){ SpellName = "Hellfire"; }
						else if ( SpellsListed == 756 ){ SpellName = "Lucifer's Bolt"; }
						else if ( SpellsListed == 757 ){ SpellName = "Orb of Orcus"; }
						else if ( SpellsListed == 758 ){ SpellName = "Shield of Hate"; }
						else if ( SpellsListed == 759 ){ SpellName = "Soul Reaper"; }
						else if ( SpellsListed == 760 ){ SpellName = "Strength of Steel"; }
						else if ( SpellsListed == 761 ){ SpellName = "Strike"; }
						else if ( SpellsListed == 762 ){ SpellName = "Succubus Skin"; }
						else if ( SpellsListed == 763 ){ SpellName = "Wrath"; }

						AddHtml( x+30, y, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + SpellName + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(x, y-4, 7050, 7050, SpellsListed, GumpButtonType.Reply, 0);
						y=y+v;

						if ( SafetyCatch == 7 ){ x = 382; y = o; }
					}

					if ( SafetyCatch > 14 ){ SpellsInBook = 0; }
				}
			}
			else if ( page == 9 )
			{
				string lowreg = "Magic from lower reagent properties can affect the amount of souls needed to invoke the magic. ";
					if ( MyServerSettings.LowerReg() < 1 )
						lowreg = "";

				info = "In order to learn the ways of the Death Knight, you must master the art of Knightship while spreading evil deeds throughout the land, avoiding Karmic influences. One must seek out the 14 Disciple Knights of Kas, and learn the power they each mastered. Find their resting places, speak their names, and claim their skulls which contains the knowledge they had. Placing the skulls onto this book will increase its spell potential, but be quick about it. Anyone that calls forth their skull will cause it to appear no matter where it is in the land, taking it from another that may possess it. You will need the power of souls to use such magic. Find humanoid creatures like brigands, orcs, titans, goblins, or trolls...those that carry gold, and slay them while holding the lantern in your left hand. Although their gold will turn to dust, your lantern will increase in power that will drain as you use this magic. You do not need to hold the lantern while unleashing this power, but only when collecting souls. The lantern does not need to be in your possession either, as death magic will claim the souls from the lantern wherever it is. " + lowreg + "Although most magic relies on your Knightship skill alone, there are also some elements that will have greater effect the lower your Karma is. Go forth Death Knight, and bring our order back to this world. Beware, Death Knight. Powerful Death Knights are often not tolerated in the city streets and may be attacked on site.";

				AddHtml( 78, 80, 250, 314, @"<BODY><BASEFONT Color=" + color + ">" + info + "</BASEFONT></BODY>", (bool)false, (bool)true);

				info = "Magic Toolbars: Here are the commands you can use (include the bracket) to manage magic toolbars that might help you play better.<BR><BR>[deathspell1 - Opens the 1st death knight spell bar editor.<BR><BR>[deathspell2 - Opens the 2nd death knight spell bar editor.<BR><BR>[deathtool1 - Opens the 1st death knight spell bar.<BR><BR>[deathtool2 - Opens the 2nd death knight spell bar.<BR><BR>[deathclose1 - Closes the 1st death knight spell bar.<BR><BR>[deathclose2 - Closes the 2nd death knight spell bar.<BR><BR>Below are the [ commands you can either type to quickly cast a particular spell, or set a hot key to issue this command and cast the spell.<BR><BR>[DKBanish<BR>    Cast Banish<BR><BR>[DKDemonicTouch<BR>    Cast Demonic Touch<BR><BR>[DKDevilPact<BR>    Cast Devil Pact<BR><BR>[DKGrimReaper<BR>    Cast Grim Reaper<BR><BR>[DKHagHand<BR>    Cast Hag Hand<BR><BR>[DKHellfire<BR>    Cast Hellfire<BR><BR>[DKLucifersBolt<BR>    Cast Lucifer's Bolt<BR><BR>[DKOrbOrcus<BR>    Cast Orb of Orcus<BR><BR>[DKShieldHate<BR>    Cast Shield of Hate<BR><BR>[DKSoulReaper<BR>    Cast Soul Reaper<BR><BR>[DKStrengthSteel<BR>    Cast Strength of Steel<BR><BR>[DKStrike<BR>    Cast Strike<BR><BR>[DKSuccubusSkin<BR>    Cast Succubus Skin<BR><BR>[DKWrath<BR>    Cast Wrath<BR><BR>";

				AddHtml( 366, 80, 250, 314, @"<BODY><BASEFONT Color=" + color + ">" + info + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}
			else
			{
				int icon1 = 0;
				string name1 = "";
				string soul1 = "";
				string skil1 = "";
				string mana1 = "";
				string text1 = "";
				int z1 = 280;

				int icon2 = 0;
				string name2 = "";
				string soul2 = "";
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
					sGrave = Worlds.GetAreaEntrance( 0, "the Ancient Pyramid", Map.Sosaria, out placer_1, out xc_1, out yc_1 );
					name1 = "Banish";
					soul1 = "56";
					skil1 = "40";
					mana1 = "36";
					text1 = ""; if ( !this.HasSpell( from, 750) ){ m_NotHave_1 = true; z1=220; text1 = "Saint Kargoth<BR>Land of Sosaria: Ancient Pyramid<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Banish summoned creatures back to their realm, demons back to hell, or elementals back to their plane of existence.";
					icon1 = 0x5010;

					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Clues", Map.Sosaria, out placer_2, out xc_2, out yc_2 );
					name2 = "Demonic Touch";
					soul2 = "21";
					skil2 = "15";
					mana2 = "16";
					text2 = ""; if ( !this.HasSpell( from, 751) ){ m_NotHave_2 = true; z2=220; text2 = "Lord Monduiz Dephaar<BR>Land of Sosaria: Dungeon Clues<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The death knight's target is healed by demonic forces for a significant amount.";
					icon2 = 0x5009;
				}
				else if ( page == 3 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Doom", Map.Sosaria, out placer_1, out xc_1, out yc_1 );
					name1 = "Devil Pact";
					soul1 = "98";
					skil1 = "90";
					mana1 = "60";
					text1 = ""; if ( !this.HasSpell( from, 752) ){ m_NotHave_1 = true; z1=220; text1 = "Lady Kath of Naelex<BR>Land of Sosaria: Dungeon Doom<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Summons the devil to battle with the death knight.";
					icon1 = 0x5005;

					sGrave = Worlds.GetAreaEntrance( 0, "the Fires of Hell", Map.Sosaria, out placer_2, out xc_2, out yc_2 );
					name2 = "Grim Reaper";
					soul2 = "42";
					skil2 = "30";
					mana2 = "28";
					text2 = ""; if ( !this.HasSpell( from, 753) ){ m_NotHave_2 = true; z2=220; text2 = "Prince Myrhal of Rax<BR>Land of Sosaria: Fires of Hell<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The next target hit becomes marked by the grim reaper. All damage dealt to it is increased, but the death knight takes extra damage from other kinds of creatures.";
					icon2 = 0x402;
				}
				else if ( page == 4 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Exodus", Map.Sosaria, out placer_1, out xc_1, out yc_1 );
					name1 = "Hag Hand";
					soul1 = "7";
					skil1 = "5";
					mana1 = "8";
					text1 = ""; if ( !this.HasSpell( from, 754) ){ m_NotHave_1 = true; z1=220; text1 = "Sir Maeril of Naelax<BR>Land of Sosaria: Dungeon Exodus<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Your hand holds the powers of a hag, where it can remove curses from items and others.";
					icon1 = 0x5002;

					sGrave = Worlds.GetAreaEntrance( 0, "the City of the Dead", Map.Sosaria, out placer_2, out xc_2, out yc_2 );
					name2 = "Hellfire";
					soul2 = "84";
					skil2 = "70";
					mana2 = "52";
					text2 = ""; if ( !this.HasSpell( from, 755) ){ m_NotHave_2 = true; z2=220; text2 = "Sir Farian of Lirtham<BR>Land of Ambrosia: City of the Dead<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The death knights's enemy is scorched by a hellfire that continues to burn the enemy for a short duration.";
					icon2 = 0x3E9;
				}
				else if ( page == 5 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "the Mausoleum", Map.Sosaria, out placer_1, out xc_1, out yc_1 );
					name1 = "Lucifer's Bolt";
					soul1 = "35";
					skil1 = "25";
					mana1 = "24";
					text1 = ""; if ( !this.HasSpell( from, 756) ){ m_NotHave_1 = true; z1=220; text1 = "Lord Androma of Gara<BR>Island of Umber Veil: the Mausoleum<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Calls down a bolt of energy from Lucifer himself, and temporarily stuns the enemy.";
					icon1 = 0x5DC0;

					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Despise", Map.Lodor, out placer_2, out xc_2, out yc_2 );
					name2 = "Orb of Orcus";
					soul2 = "200";
					skil2 = "80";
					mana2 = "56";
					text2 = ""; if ( !this.HasSpell( from, 757) ){ m_NotHave_2 = true; z2=220; text2 = "Sir Oslan Knarren<BR>Land of Lodoria: Dungeon Despise<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The forces of Orcus surround the knight and refelecta a certain amount of magical effects back at the caster.";
					icon2 = 0x1B;
				}
				else if ( page == 6 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Deceit", Map.Lodor, out placer_1, out xc_1, out yc_1 );
					name1 = "Shield of Hate";
					soul1 = "77";
					skil1 = "60";
					mana1 = "48";
					text1 = ""; if ( !this.HasSpell( from, 758) ){ m_NotHave_1 = true; z1=220; text1 = "Sir Rezinar of Haxx<BR>Land of Lodoria: Dungeon Deceit<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Channels hatred to form a barrier around the target, shielding them from physical harm.";
					icon1 = 0x3EE;

					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Wrong", Map.Lodor, out placer_2, out xc_2, out yc_2 );
					name2 = "Soul Reaper";
					soul2 = "63";
					skil2 = "45";
					mana2 = "40";
					text2 = ""; if ( !this.HasSpell( from, 759) ){ m_NotHave_2 = true; z2=220; text2 = "Lord Thyrian of Naelax<BR>Land of Lodoria: Dungeon Wrong<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "Drains the enemy of their soul, reducing their mana for a short period of time.";
					icon2 = 0x5006;
				}
				else if ( page == 7 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "the Lodoria Catacombs", Map.Lodor, out placer_1, out xc_1, out yc_1 );
					name1 = "Strength of Steel";
					soul1 = "28";
					skil1 = "20";
					mana1 = "20";
					text1 = ""; if ( !this.HasSpell( from, 760) ){ m_NotHave_1 = true; z1=220; text1 = "Sir Minar of Darmen<BR>Land of Lodoria: Lodoria Catacombs<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "Greatly increases the target's strength for a short period.";
					icon1 = 0x2B;

					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Shame", Map.Lodor, out placer_2, out xc_2, out yc_2 );
					name2 = "Strike";
					soul2 = "14";
					skil2 = "10";
					mana2 = "12";
					text2 = ""; if ( !this.HasSpell( from, 761) ){ m_NotHave_2 = true; z2=220; text2 = "Duke Urkar of Torquann<BR>Land of Lodoria: Dungeon Shame<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The death knight's enemy is damaged by a demonic energy from the nine hells.";
					icon2 = 0x12;
				}
				else if ( page == 8 )
				{
					sGrave = Worlds.GetAreaEntrance( 0, "the City of Embers", Map.Lodor, out placer_1, out xc_1, out yc_1 );
					name1 = "Succubus Skin";
					soul1 = "49";
					skil1 = "35";
					mana1 = "32";
					text1 = ""; if ( !this.HasSpell( from, 762) ){ m_NotHave_1 = true; z1=220; text1 = "Sir Luren the Boar<BR>Land of Lodoria: the City of Embers<BR>" + sGrave + "<BR><BR>"; }
					text1 = text1 + "The death knight's target has their skin regenerate health over time.";
					icon1 = 0x500C;

					sGrave = Worlds.GetAreaEntrance( 0, "Dungeon Hythloth", Map.Lodor, out placer_2, out xc_2, out yc_2 );
					name2 = "Wrath";
					soul2 = "70";
					skil2 = "50";
					mana2 = "44";
					text2 = ""; if ( !this.HasSpell( from, 763) ){ m_NotHave_2 = true; z2=220; text2 = "Lord Khayven of Rax<BR>Land of Lodoria: Dungeon Hythloth<BR>" + sGrave + "<BR><BR>"; }
					text2 = text2 + "The death knight unleashes the forces of hell unto his nearby enemies, causing much damage.";
					icon2 = 0x2E;
				}

				m_Map_1 = placer_1;
				m_X_1 = xc_1;
				m_Y_1 = yc_1;
				m_Map_2 = placer_2;
				m_X_2 = xc_2;
				m_Y_2 = yc_2;

				AddImage(73, 78, 7052);
				AddImage(75, 80, icon1, 2405);
				AddHtml( 129, 93, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + name1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Souls:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + soul1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 160, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + skil1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 134, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 196, 190, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + mana1 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 78, z1, 250, 175, @"<BODY><BASEFONT Color=" + color + ">" + text1 + "</BASEFONT></BODY>", (bool)false, (bool)false);

				AddImage(360, 78, 7052);
				AddImage(362, 80, icon2, 2405);
				AddHtml( 417, 93, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + name2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 422, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">Souls:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 484, 130, 57, 20, @"<BODY><BASEFONT Color=" + color + ">" + soul2 + "</BASEFONT></BODY>", (bool)false, (bool)false);
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
				from.SendGump( new DeathKnightSpellbookGump( from, m_Book, pg ) );
				from.SendGump( new Sextants.MapGump( from, m_Map_2, m_X_2, m_Y_2, null ) );
			}
			else if ( info.ButtonID >= 98000 )
			{
				int pg = info.ButtonID - 98000;
				from.SendGump( new DeathKnightSpellbookGump( from, m_Book, pg ) );
				from.SendGump( new Sextants.MapGump( from, m_Map_1, m_X_1, m_Y_1, null ) );
			}
			else if ( info.ButtonID < 700 && info.ButtonID > 0 )
			{
				from.SendSound( 0x55 );
				int page = info.ButtonID;
				if ( page < 1 ){ page = 9; }
				if ( page > 9 ){ page = 1; }
				from.SendGump( new DeathKnightSpellbookGump( from, m_Book, page ) );
			}
			else if ( info.ButtonID > 700 && HasSpell(from, info.ButtonID) )
			{
				if ( info.ButtonID == 750 ){ new BanishSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 751 ){ new DemonicTouchSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 752 ){ new DevilPactSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 753 ){ new GrimReaperSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 754 ){ new HagHandSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 755 ){ new HellfireSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 756 ){ new LucifersBoltSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 757 ){ new OrbOfOrcusSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 758 ){ new ShieldOfHateSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 759 ){ new SoulReaperSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 760 ){ new StrengthOfSteelSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 761 ){ new StrikeSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 762 ){ new SuccubusSkinSpell( from, null ).Cast(); }
				else if ( info.ButtonID == 763 ){ new WrathSpell( from, null ).Cast(); }

				from.SendGump( new DeathKnightSpellbookGump( from, m_Book, 1 ) );
			}
			else
				from.SendSound( 0x55 );
		}
	}
}