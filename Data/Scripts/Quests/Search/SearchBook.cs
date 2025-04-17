using System;
using Server; 
using Server.Network;
using System.Collections; 
using Server.Items;
using Server.Misc;
using Server.Gumps;

namespace Server.Items
{
	public class SearchBook : Item
	{
		public Mobile owner;
		public int LegendLore;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner { get{ return owner; } set{ owner = value; } }

		[CommandProperty(AccessLevel.Owner)]
		public int Legend_Lore { get { return LegendLore; } set { LegendLore = value; InvalidateProperties(); } }

		[Constructable]
		public SearchBook( Mobile from, int paid ) : base( 0x22C5 )
		{
			this.owner = from;
			LegendLore = ( paid / 1000 ) - 4;
			Weight = 1.0;
			Hue = 0x978;
			Name = "Artifact Encyclopedia";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to read." );
				return;
			}
			else if ( this.owner != from  )
			{
				from.SendMessage( "This is not your book." );
				return;
			}
			else 
			{
				from.SendSound( 0x55 );
				from.CloseGump( typeof( SearchBookGump ) );
				from.SendGump( new SearchBookGump( from, this, 0 ) );
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( owner != null ){ list.Add( 1070722, "Belongs to " + owner.Name + "" ); }

			string sLegend = LegendLore.ToString();
            list.Add( 1049644, "Legend Lore: Level " + sLegend + "");
        }

		public class SearchBookGump : Gump
		{
			private SearchBook m_Book;

			public SearchBookGump( Mobile from, SearchBook wikipedia, int page ): base( 100, 100 )
			{
				m_Book = wikipedia;
				string color = "#d6c382";

				int NumberOfArtifacts = 383; // SEE LISTING BELOW AND MAKE SURE IT MATCHES THE AMOUNT
				decimal PageCount = NumberOfArtifacts / 16;
				int TotalBookPages = ( 100000 ) + ( (int)Math.Ceiling( PageCount ) );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7005);
				AddImage(0, 0, 7006);
				AddImage(0, 0, 7024, 2736);
				AddButton(590, 48, 4017, 4017, 0, GumpButtonType.Reply, 0);

				int subItem = page * 16;

				int showItem1 = subItem + 1;
				int showItem2 = subItem + 2;
				int showItem3 = subItem + 3;
				int showItem4 = subItem + 4;
				int showItem5 = subItem + 5;
				int showItem6 = subItem + 6;
				int showItem7 = subItem + 7;
				int showItem8 = subItem + 8;
				int showItem9 = subItem + 9;
				int showItem10 = subItem + 10;
				int showItem11 = subItem + 11;
				int showItem12 = subItem + 12;
				int showItem13 = subItem + 13;
				int showItem14 = subItem + 14;
				int showItem15 = subItem + 15;
				int showItem16 = subItem + 16;

				int page_prev = ( 100000 + page ) - 1;
					if ( page_prev < 100000 ){ page_prev = TotalBookPages; }
				int page_next = ( 100000 + page ) + 1;
					if ( page_next > TotalBookPages ){ page_next = 100000; }

				AddButton(75, 374, 4014, 4014, page_prev, GumpButtonType.Reply, 0);
				AddButton(590, 375, 4005, 4005, page_next, GumpButtonType.Reply, 0);

				AddHtml( 77, 49, 259, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>ARTIFACTS</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				///////////////////////////////////////////////////////////////////////////////////

				int x = 115;
				int y = 64;
				int s = 64;
				int z = 34;

				y=y+z;
				if ( GetArtifactListForBook( showItem1, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem1, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem2, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem2, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem3, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem3, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem4, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem4, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem5, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem5, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem6, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem6, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem7, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem7, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem8, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem8, GumpButtonType.Reply, 0); } y=s-3;
				y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem1, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem2, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem3, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem4, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem5, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem6, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem7, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem8, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=s-3;

				///////////////////////////////////////////////////////////////////////////////////

				x = 407;
				y = s;

				y=y+z;
				if ( GetArtifactListForBook( showItem9, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem9, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem10, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem10, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem11, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem11, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem12, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem12, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem13, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem13, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem14, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem14, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem15, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem15, GumpButtonType.Reply, 0); } y=y+z;
				if ( GetArtifactListForBook( showItem16, 1 ) != "" ){ AddButton(x, y, 2447, 2447, showItem16, GumpButtonType.Reply, 0); } y=s-3;
				y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem9, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem10, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem11, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem12, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem13, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem14, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem15, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=y+z;
				AddHtml( x+20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook( showItem16, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false); y=s-3;
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile; 

				from.SendSound( 0x55 );

				if ( info.ButtonID >= 100000 )
				{
					int page = info.ButtonID - 100000;
					from.SendGump( new SearchBookGump( from, m_Book, page ) );
				}
				else if (info.ButtonID >= 1 && info.ButtonID != null)
				{
					// we debug like the ancient sumerians did
					//from.SendMessage("show id: " + info.ButtonID);
					from.SendGump(new ConfirmGump(from, info.ButtonID, m_Book));
				}
			}
		}

		public class ConfirmGump : Gump
		{
			private SearchBook m_Book;
		    private Mobile m_User;
		    private int m_ButtonID;

			private static bool gumpOpened = false;

		    public ConfirmGump(Mobile user, int buttonID, SearchBook wikipedia) : base(50, 50)
		    {
		    	if (gumpOpened)
            		return;
				
				gumpOpened = true; 

				m_Book = wikipedia;
		        m_User = user;
		        m_ButtonID = buttonID;
				Closable = true;
    		    Disposable = true;
    		    Dragable = true;
	    	    Resizable = false;

				AddBackground(0, 0, 400, 160, 9270);

				AddLabel(30, 20, 2120, "Are you sure you want to search for The");
			    AddLabel(30, 40, 2120, GetArtifactListForBook(m_ButtonID, 1) + " ?");
    			AddLabel(30, 70, 2120, "Confirming will consume your Artifact Encyclopedia");

			
   				AddButton(80, 120, 4005, 4007, 1, GumpButtonType.Reply, 0); // Yes
    			AddLabel(115, 122, 2120, "Yes");

    			AddButton(200, 120, 4017, 4019, 0, GumpButtonType.Reply, 0); // No
    			AddLabel(235, 122, 2120, "No");
		    
			}

		    public override void OnResponse(NetState sender, RelayInfo info)
		    {
		        if (info.ButtonID == 1) // Yes
		        {
		            string sType = GetArtifactListForBook(m_ButtonID, 2);
		            string sName = GetArtifactListForBook(m_ButtonID, 1);
		            if (sName != "")
		            {
		                m_User.AddToBackpack(new SearchPage(m_User, m_Book.LegendLore, sType, sName));
		                m_User.SendMessage("You tear the page out of the book.");
		                m_Book.Delete();
		            }
		        }
		        m_User.CloseGump(typeof(SearchBookGump));
				m_User.CloseGump(typeof(ConfirmGump));
				gumpOpened = false;
			}
		}

		public SearchBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
			writer.Write( (Mobile)owner );
            writer.Write( LegendLore );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			owner = reader.ReadMobile();
			LegendLore = reader.ReadInt();
		}

		public static string GetArtifactListForBook( int artifact, int part )
		{
			string item = "";
			string name = "";
			int arty = 1;

			if ( artifact == arty) { name="Artifact_AbysmalGloves"; item="Abysmal Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_AchillesShield"; item="Achille's Shield"; } arty++;
			if ( artifact == arty) { name="Artifact_AchillesSpear"; item="Achille's Spear"; } arty++;
			if ( artifact == arty) { name="Artifact_AcidProofRobe"; item="Acidic Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_Aegis"; item="Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_AegisOfGrace"; item="Aegis of Grace"; } arty++;
			if ( artifact == arty) { name="Artifact_AilricsLongbow"; item="Ailric's Longbow"; } arty++;
			if ( artifact == arty) { name="Artifact_AlchemistsBauble"; item="Alchemist's Bauble"; } arty++;
			if ( artifact == arty) { name="Artifact_SamuraiHelm"; item="Ancient Samurai Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_AngelicEmbrace"; item="Angelic Embrace"; } arty++;
			if ( artifact == arty) { name="Artifact_AngeroftheGods"; item="Anger of the Gods"; } arty++;
			if ( artifact == arty) { name="Artifact_Annihilation"; item="Annihilation"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneArms"; item="Arcane Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneCap"; item="Arcane Cap"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneGloves"; item="Arcane Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneGorget"; item="Arcane Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneLeggings"; item="Arcane Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneShield"; item="Arcane Shield"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcaneTunic"; item="Arcane Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcanicRobe"; item="Arcanic Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcticDeathDealer"; item="Arctic Death Dealer"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmorOfFortune"; item="Armor of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmorOfInsight"; item="Armor of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmorOfNobility"; item="Armor of Nobility"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfAegis"; item="Arms of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfFortune"; item="Arms of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfInsight"; item="Arms of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfNobility"; item="Arms of Nobility"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfTheFallenKing"; item="Arms of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfTheHarrower"; item="Arms of the Harrower"; } arty++;
			if ( artifact == arty) { name="Artifact_ArmsOfToxicity"; item="Arms Of Toxicity"; } arty++;
			if ( artifact == arty) { name="Artifact_AuraOfShadows"; item="Aura Of Shadows"; } arty++;
			if ( artifact == arty) { name="Artifact_AxeOfTheHeavens"; item="Axe of the Heavens"; } arty++;
			if ( artifact == arty) { name="Artifact_AxeoftheMinotaur"; item="Axe of the Minotaur"; } arty++;
			if ( artifact == arty) { name="Artifact_BeggarsRobe"; item="Beggar's Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_BeltofHercules"; item="Belt of Hercules"; } arty++;
			if ( artifact == arty) { name="Artifact_TheBeserkersMaul"; item="Berserker's Maul"; } arty++;
			if ( artifact == arty) { name="Artifact_BladeDance"; item="Blade Dance"; } arty++;
			if ( artifact == arty) { name="Artifact_BladeOfInsanity"; item="Blade of Insanity"; } arty++;
			if ( artifact == arty) { name="Artifact_ConansSword"; item="Blade of the Cimmerian"; } arty++;
			if ( artifact == arty) { name="Artifact_BladeOfTheRighteous"; item="Blade of the Righteous"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowBlade"; item="Blade of the Shadows"; } arty++;
			if ( artifact == arty) { name="Artifact_BlazeOfDeath"; item="Blaze of Death"; } arty++;
			if ( artifact == arty) { name="Artifact_BlightGrippedLongbow"; item="Blight Gripped Longbow"; } arty++;
			if ( artifact == arty) { name="Artifact_BloodwoodSpirit"; item="Bloodwood Spirit"; } arty++;
			if ( artifact == arty) { name="Artifact_BoneCrusher"; item="Bone Crusher"; } arty++;
			if ( artifact == arty) { name="Artifact_Bonesmasher"; item="Bonesmasher"; } arty++;
			if ( artifact == arty) { name="Arty_BookOfKnowledge"; item="Book Of Knowledge"; } arty++;
			if ( artifact == arty) { name="Artifact_Boomstick"; item="Boomstick"; } arty++;
			if ( artifact == arty) { name="Artifact_BootsofHermes"; item="Boots of Hermes"; } arty++;
			if ( artifact == arty) { name="Artifact_BootsofPyros"; item="Boots of the Daemon King"; } arty++;
			if ( artifact == arty) { name="Artifact_BootsofHydros"; item="Boots of the Lurker"; } arty++;
			if ( artifact == arty) { name="Artifact_BootsofLithos"; item="Boots of the Mountain King"; } arty++;
			if ( artifact == arty) { name="Artifact_BootsofStratos"; item="Boots of the Mystic Voice"; } arty++;
			if ( artifact == arty) { name="Artifact_BowOfTheJukaKing"; item="Bow of the Juka King"; } arty++;
			if ( artifact == arty) { name="Artifact_BowofthePhoenix"; item="Bow of the Phoenix"; } arty++;
			if ( artifact == arty) { name="Artifact_BraceletOfHealth"; item="Bracelet of Health"; } arty++;
			if ( artifact == arty) { name="Artifact_BraceletOfTheElements"; item="Bracelet of the Elements"; } arty++;
			if ( artifact == arty) { name="Artifact_BraceletOfTheVile"; item="Bracelet of the Vile"; } arty++;
			if ( artifact == arty) { name="Artifact_BrambleCoat"; item="Bramble Coat"; } arty++;
			if ( artifact == arty) { name="Artifact_BraveKnightOfTheBritannia"; item="Brave Knight of Sosaria"; } arty++;
			if ( artifact == arty) { name="Artifact_BreathOfTheDead"; item="Breath of the Dead"; } arty++;
			if ( artifact == arty) { name="Artifact_BurglarsBandana"; item="Burglar's Bandana"; } arty++;
			if ( artifact == arty) { name="Artifact_Calm"; item="Calm"; } arty++;
			if ( artifact == arty) { name="Artifact_CandleCold"; item="Candle of Cold Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CandleEnergy"; item="Candle of Energized Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CandleFire"; item="Candle of Fire Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CandleNecromancer"; item="Candle of Ghostly Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CandlePoison"; item="Candle of Poisonous Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CandleWizard"; item="Candle of Wizardly Light"; } arty++;
			if ( artifact == arty) { name="Artifact_CapOfFortune"; item="Cap of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_CapOfTheFallenKing"; item="Cap of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_CaptainJohnsHat"; item="Captain John's Hat"; } arty++;
			if ( artifact == arty) { name="Artifact_CaptainQuacklebushsCutlass"; item="Captain Quacklebush's Cutlass"; } arty++;
			if ( artifact == arty) { name="Artifact_CavortingClub"; item="Cavorting Club"; } arty++;
			if ( artifact == arty) { name="Artifact_CircletOfTheSorceress"; item="Circlet Of The Sorceress"; } arty++;
			if ( artifact == arty) { name="Artifact_GrayMouserCloak"; item="Cloak of the Rogue"; } arty++;
			if ( artifact == arty) { name="Artifact_CoifOfBane"; item="Coif of Bane"; } arty++;
			if ( artifact == arty) { name="Artifact_CoifOfFire"; item="Coif of Fire"; } arty++;
			if ( artifact == arty) { name="Artifact_ColdBlood"; item="Cold Blood"; } arty++;
			if ( artifact == arty) { name="Artifact_ColdForgedBlade"; item="Cold Forged Blade"; } arty++;
			if ( artifact == arty) { name="Artifact_CrimsonCincture"; item="Crimson Cincture"; } arty++;
			if ( artifact == arty) { name="Artifact_CrownOfTalKeesh"; item="Crown of Tal'Keesh"; } arty++;
			if ( artifact == arty) { name="Artifact_DaggerOfVenom"; item="Dagger of Venom"; } arty++;
			if ( artifact == arty) { name="Artifact_DarkGuardiansChest"; item="Dark Guardian's Chest"; } arty++;
			if ( artifact == arty) { name="Artifact_DarkLordsPitchfork"; item="Dark Lord's PitchFork"; } arty++;
			if ( artifact == arty) { name="Artifact_DarkNeck"; item="Dark Neck"; } arty++;
			if ( artifact == arty) { name="Artifact_DetectiveBoots"; item="Detective Boots of the Royal Guard"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineArms"; item="Divine Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineCountenance"; item="Divine Countenance"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineGloves"; item="Divine Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineGorget"; item="Divine Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineLeggings"; item="Divine Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_DivineTunic"; item="Divine Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_DjinnisRing"; item="Djinni's Ring"; } arty++;
			if ( artifact == arty) { name="Artifact_DreadPirateHat"; item="Dread Pirate Hat"; } arty++;
			if ( artifact == arty) { name="Artifact_TheDryadBow"; item="Dryad Bow"; } arty++;
			if ( artifact == arty) { name="Artifact_DupresCollar"; item="Dupre's Collar"; } arty++;
			if ( artifact == arty) { name="Artifact_DupresShield"; item="Dupre's Shield"; } arty++;
			if ( artifact == arty) { name="Artifact_EarringsOfHealth"; item="Earrings of Health"; } arty++;
			if ( artifact == arty) { name="Artifact_EarringsOfTheElements"; item="Earrings of the Elements"; } arty++;
			if ( artifact == arty) { name="Artifact_EarringsOfTheMagician"; item="Earrings of the Magician"; } arty++;
			if ( artifact == arty) { name="Artifact_EarringsOfTheVile"; item="Earrings of the Vile"; } arty++;
			if ( artifact == arty) { name="Artifact_EmbroideredOakLeafCloak"; item="Embroidered Oak Leaf Cloak"; } arty++;
			if ( artifact == arty) { name="Artifact_EnchantedTitanLegBone"; item="Enchanted Pirate Rapier"; } arty++;
			if ( artifact == arty) { name="Artifact_EssenceOfBattle"; item="Essence of Battle"; } arty++;
			if ( artifact == arty) { name="Artifact_EternalFlame"; item="Eternal Flame"; } arty++;
			if ( artifact == arty) { name="Artifact_EvilMageGloves"; item="Evil Mage Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_Excalibur"; item="Excalibur"; } arty++;
			if ( artifact == arty) { name="Artifact_FangOfRactus"; item="Fang of Ractus"; } arty++;
			if ( artifact == arty) { name="Artifact_FesteringWound"; item="Festering Wound"; } arty++;
			if ( artifact == arty) { name="Artifact_FeyLeggings"; item="Fey Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_FleshRipper"; item="Flesh Ripper"; } arty++;
			if ( artifact == arty) { name="Artifact_Fortifiedarms"; item="Fortified Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_FortunateBlades"; item="Fortunate Blades"; } arty++;
			if ( artifact == arty) { name="Artifact_Frostbringer"; item="Frostbringer"; } arty++;
			if ( artifact == arty) { name="Artifact_FurCapeOfTheSorceress"; item="Fur Cape Of The Sorceress"; } arty++;
			if ( artifact == arty) { name="Artifact_Fury"; item="Fury"; } arty++;
			if ( artifact == arty) { name="Artifact_MarbleShield"; item="Gargoyle Shield"; } arty++;
			if ( artifact == arty) { name="Artifact_GuantletsOfAnger"; item="Gauntlets of Anger"; } arty++;
			if ( artifact == arty) { name="Artifact_GauntletsOfNobility"; item="Gauntlets of Nobility"; } arty++;
			if ( artifact == arty) { name="Artifact_GeishasObi"; item="Geishas Obi"; } arty++;
			if ( artifact == arty) { name="Artifact_GiantBlackjack"; item="Giant Blackjack"; } arty++;
			if ( artifact == arty) { name="Artifact_GladiatorsCollar"; item="Gladiator's Collar"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfAegis"; item="Gloves of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfCorruption"; item="Gloves Of Corruption"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfDexterity"; item="Gloves of Dexterity"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfFortune"; item="Gloves of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfInsight"; item="Gloves of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfRegeneration"; item="Gloves Of Regeneration"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfTheFallenKing"; item="Gloves of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfTheHarrower"; item="Gloves of the Harrower"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfThePugilist"; item="Gloves of the Pugilist"; } arty++;
			if ( artifact == arty) { name="Artifact_SamaritanRobe"; item="Good Samaritan Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_GorgetOfAegis"; item="Gorget of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_GorgetOfFortune"; item="Gorget of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_GorgetOfInsight"; item="Gorget of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_GrimReapersLantern"; item="Grim Reaper's Lantern"; } arty++;
			if ( artifact == arty) { name="Artifact_GrimReapersMask"; item="Grim Reaper's Mask"; } arty++;
			if ( artifact == arty) { name="Artifact_GrimReapersRobe"; item="Grim Reaper's Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_GrimReapersScythe"; item="Grim Reaper's Scythe"; } arty++;
			if ( artifact == arty) { name="Arty_PyrosGrimoire"; item="Grimoire of the Daemon King"; } arty++;
			if ( artifact == arty) { name="Artifact_TownGuardsHalberd"; item="Guardsman Halberd"; } arty++;
			if ( artifact == arty) { name="GwennosHarp"; item="Gwenno's Harp"; } arty++;
			if ( artifact == arty) { name="Artifact_HammerofThor"; item="Hammer of Thor"; } arty++;
			if ( artifact == arty) { name="Artifact_HatOfTheMagi"; item="Hat of the Magi"; } arty++;
			if ( artifact == arty) { name="Artifact_HeartOfTheLion"; item="Heart of the Lion"; } arty++;
			if ( artifact == arty) { name="Artifact_HellForgedArms"; item="Hell Forged Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_HelmOfAegis"; item="Helm of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_HelmOfBrilliance"; item="Helm of Brilliance"; } arty++;
			if ( artifact == arty) { name="Artifact_HelmOfInsight"; item="Helm of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_HelmOfSwiftness"; item="Helm of Swiftness"; } arty++;
			if ( artifact == arty) { name="Artifact_ConansHelm"; item="Helm of the Cimmerian"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsArmPlates"; item="Holy Knight's Arm Plates"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsBreastplate"; item="Holy Knight's Breastplate"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsGloves"; item="Holy Knight's Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsGorget"; item="Holy Knight's Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsLegging"; item="Holy Knight's Legging"; } arty++;
			if ( artifact == arty) { name="Artifact_HolyKnightsPlateHelm"; item="Holy Knight's Plate Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_LunaLance"; item="Holy Lance"; } arty++;
			if ( artifact == arty) { name="Artifact_HolySword"; item="Holy Sword"; } arty++;
			if ( artifact == arty) { name="Artifact_HoodedShroudOfShadows"; item="Hooded Shroud of Shadows"; } arty++;
			if ( artifact == arty) { name="HornOfKingTriton"; item="Horn of King Triton"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersArms"; item="Hunter's Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersGloves"; item="Hunter's Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersGorget"; item="Hunter's Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersHeaddress"; item="Hunter's Headdress"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersLeggings"; item="Hunter's Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_HuntersTunic"; item="Hunter's Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_Indecency"; item="Indecency"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsArms"; item="Inquisitor's Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsGorget"; item="Inquisitor's Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsHelm"; item="Inquisitor's Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsLeggings"; item="Inquisitor's Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsResolution"; item="Inquisitor's Resolution"; } arty++;
			if ( artifact == arty) { name="Artifact_InquisitorsTunic"; item="Inquisitor's Tunic"; } arty++;
			if ( artifact == arty) { name="IolosLute"; item="Iolo's Lute"; } arty++;
			if ( artifact == arty) { name="Artifact_IronwoodCrown"; item="Ironwood Crown"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsArms"; item="Jackal's Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsCollar"; item="Jackal's Collar"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsGloves"; item="Jackal's Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsHelm"; item="Jackal's Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsLeggings"; item="Jackal's Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_JackalsTunic"; item="Jackal's Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_JadeScimitar"; item="Jade Scimitar"; } arty++;
			if ( artifact == arty) { name="Artifact_JesterHatofChuckles"; item="Jester Hat of Chuckles"; } arty++;
			if ( artifact == arty) { name="Artifact_JinBaoriOfGoodFortune"; item="Jin-Baori Of Good Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_KamiNarisIndestructableDoubleAxe"; item="Kami-Naris Indestructable Axe"; } arty++;
			if ( artifact == arty) { name="Artifact_KodiakBearMask"; item="Kodiak Bear Mask"; } arty++;
			if ( artifact == arty) { name="Artifact_PowerSurge"; item="Lantern of Power"; } arty++;
			if ( artifact == arty) { name="Artifact_LegacyOfTheDreadLord"; item="Legacy of the Dread Lord"; } arty++;
			if ( artifact == arty) { name="Artifact_LegsOfFortune"; item="Legging of Fortune"; } arty++;
			if ( artifact == arty) { name="Artifact_LegsOfInsight"; item="Legging of Insight"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfAegis"; item="Leggings of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfBane"; item="Leggings of Bane"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfDeceit"; item="Leggings Of Deceit"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfEnlightenment"; item="Leggings Of Enlightenment"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfFire"; item="Leggings of Fire"; } arty++;
			if ( artifact == arty) { name="Artifact_LegsOfTheFallenKing"; item="Leggings of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_LegsOfTheHarrower"; item="Leggings of the Harrower"; } arty++;
			if ( artifact == arty) { name="Artifact_LegsOfNobility"; item="Legs of Nobility"; } arty++;
			if ( artifact == arty) { name="Arty_HydrosLexicon"; item="Lexicon of the Lurker"; } arty++;
			if ( artifact == arty) { name="Artifact_ConansLoinCloth"; item="Loin Cloth of the Cimmerian"; } arty++;
			if ( artifact == arty) { name="Artifact_LongShot"; item="Long Shot"; } arty++;
			if ( artifact == arty) { name="Artifact_LuckyEarrings"; item="Lucky Earrings"; } arty++;
			if ( artifact == arty) { name="Artifact_LuckyNecklace"; item="Lucky Necklace"; } arty++;
			if ( artifact == arty) { name="Artifact_LuminousRuneBlade"; item="Luminous Rune Blade"; } arty++;
			if ( artifact == arty) { name="Artifact_MadmansHatchet"; item="Madman's Hatchet"; } arty++;
			if ( artifact == arty) { name="Artifact_MagesBand"; item="Mage's Band"; } arty++;
			if ( artifact == arty) { name="Artifact_MagiciansIllusion"; item="Magician's Illusion"; } arty++;
			if ( artifact == arty) { name="Artifact_MagiciansMempo"; item="Magician's Mempo"; } arty++;
			if ( artifact == arty) { name="Artifact_MantleofPyros"; item="Mantle of the Daemon King"; } arty++;
			if ( artifact == arty) { name="Artifact_MantleofHydros"; item="Mantle of the Lurker"; } arty++;
			if ( artifact == arty) { name="Artifact_MantleofLithos"; item="Mantle of the Mountain King"; } arty++;
			if ( artifact == arty) { name="Artifact_MantleofStratos"; item="Mantle of the Mystic Voice"; } arty++;
			if ( artifact == arty) { name="Arty_StratosManual"; item="Manual of the Mystic Voice"; } arty++;
			if ( artifact == arty) { name="Artifact_DeathsMask"; item="Mask of Death"; } arty++;
			if ( artifact == arty) { name="Artifact_MauloftheBeast"; item="Maul of the Beast"; } arty++;
			if ( artifact == arty) { name="Artifact_MaulOfTheTitans"; item="Maul of the Titans"; } arty++;
			if ( artifact == arty) { name="Artifact_MelisandesCorrodedHatchet"; item="Melisande's Corroded Hatchet"; } arty++;
			if ( artifact == arty) { name="Artifact_GandalfsHat"; item="Merlin's Mystical Hat"; } arty++;
			if ( artifact == arty) { name="Artifact_GandalfsRobe"; item="Merlin's Mystical Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_GandalfsStaff"; item="Merlin's Mystical Staff"; } arty++;
			if ( artifact == arty) { name="Artifact_MidnightBracers"; item="Midnight Bracers"; } arty++;
			if ( artifact == arty) { name="Artifact_MidnightGloves"; item="Midnight Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_MidnightHelm"; item="Midnight Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_MidnightLegs"; item="Midnight Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_MidnightTunic"; item="Midnight Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_MinersPickaxe"; item="Miner's Pickaxe"; } arty++;
			if ( artifact == arty) { name="Artifact_ANecromancerShroud"; item="Necromancer Shroud"; } arty++;
			if ( artifact == arty) { name="Artifact_TheNightReaper"; item="Night Reaper"; } arty++;
			if ( artifact == arty) { name="Artifact_NightsKiss"; item="Night's Kiss"; } arty++;
			if ( artifact == arty) { name="Artifact_NordicVikingSword"; item="Nordic Dragon Blade"; } arty++;
			if ( artifact == arty) { name="Artifact_VampiresRobe"; item="Nosferatu's Robe"; } arty++;
			if ( artifact == arty) { name="Artifact_NoxBow"; item="Nox Ranger's Light Croosbow"; } arty++;
			if ( artifact == arty) { name="Artifact_NoxNightlight"; item="Nox Nightlight"; } arty++;
			if ( artifact == arty) { name="Artifact_NoxRangersHeavyCrossbow"; item="Nox Ranger's Heavy Crossbow"; } arty++;
			if ( artifact == arty) { name="Artifact_OblivionsNeedle"; item="Oblivion Needle"; } arty++;
			if ( artifact == arty) { name="Artifact_OrcChieftainHelm"; item="Orc Chieftain Helm"; } arty++;
			if ( artifact == arty) { name="Artifact_OrcishVisage"; item="Orcish Visage"; } arty++;
			if ( artifact == arty) { name="Artifact_OrnamentOfTheMagician"; item="Ornament of the Magician"; } arty++;
			if ( artifact == arty) { name="Artifact_OrnateCrownOfTheHarrower"; item="Ornate Crown of the Harrower"; } arty++;
			if ( artifact == arty) { name="Arty_OssianGrimoire"; item="Ossian Grimoire"; } arty++;
			if ( artifact == arty) { name="Artifact_OverseerSunderedBlade"; item="Overseer Sundered Blade"; } arty++;
			if ( artifact == arty) { name="Artifact_Pacify"; item="Pacify"; } arty++;
			if ( artifact == arty) { name="Artifact_PadsOfTheCuSidhe"; item="Pads of the Cu Sidhe"; } arty++;
			if ( artifact == arty) { name="Artifact_PendantOfTheMagi"; item="Pendant of the Magi"; } arty++;
			if ( artifact == arty) { name="Artifact_Pestilence"; item="Pestilence"; } arty++;
			if ( artifact == arty) { name="Artifact_PhantomStaff"; item="Phantom Staff"; } arty++;
			if ( artifact == arty) { name="Artifact_PixieSwatter"; item="Pixie Swatter"; } arty++;
			if ( artifact == arty) { name="Artifact_PolarBearBoots"; item="Polar Bear Boots"; } arty++;
			if ( artifact == arty) { name="Artifact_PolarBearCape"; item="Polar Bear Cape"; } arty++;
			if ( artifact == arty) { name="Artifact_Quell"; item="Quell"; } arty++;
			if ( artifact == arty) { name="QuiverOfBlight"; item="Quiver of Blight"; } arty++;
			if ( artifact == arty) { name="QuiverOfFire"; item="Quiver of Fire"; } arty++;
			if ( artifact == arty) { name="QuiverOfIce"; item="Quiver of Ice"; } arty++;
			if ( artifact == arty) { name="QuiverOfInfinity"; item="Quiver of Infinity"; } arty++;
			if ( artifact == arty) { name="QuiverOfLightning"; item="Quiver of Lightning"; } arty++;
			if ( artifact == arty) { name="QuiverOfRage"; item="Quiver of Rage"; } arty++;
			if ( artifact == arty) { name="QuiverOfElements"; item="Quiver of the Elements"; } arty++;
			if ( artifact == arty) { name="Artifact_RaedsGlory"; item="Raed's Glory"; } arty++;
			if ( artifact == arty) { name="Artifact_RamusNecromanticScalpel"; item="Ramus' Necromantic Scalpel"; } arty++;
			if ( artifact == arty) { name="Artifact_ResilientBracer"; item="Resillient Bracer"; } arty++;
			if ( artifact == arty) { name="Artifact_Retort"; item="Retort"; } arty++;
			if ( artifact == arty) { name="Artifact_RighteousAnger"; item="Righteous Anger"; } arty++;
			if ( artifact == arty) { name="Artifact_RingOfHealth"; item="Ring of Health"; } arty++;
			if ( artifact == arty) { name="Artifact_RingOfProtection"; item="Ring of Protection"; } arty++;
			if ( artifact == arty) { name="Artifact_RingOfTheElements"; item="Ring of the Elements"; } arty++;
			if ( artifact == arty) { name="Artifact_RingOfTheMagician"; item="Ring of the Magician"; } arty++;
			if ( artifact == arty) { name="Artifact_RingOfTheVile"; item="Ring of the Vile"; } arty++;
			if ( artifact == arty) { name="Artifact_TheRobeOfBritanniaAri"; item="Robe of Sosaria"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeOfTeleportation"; item="Robe Of Teleportation"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeofPyros"; item="Robe of the Daemon King"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeOfTheEclipse"; item="Robe of the Eclipse"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeOfTheEquinox"; item="Robe of the Equinox"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeofHydros"; item="Robe of the Lurker"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeofLithos"; item="Robe of the Mountain King"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeofStratos"; item="Robe of the Mystic Voice"; } arty++;
			if ( artifact == arty) { name="Artifact_RobeOfTreason"; item="Robe Of Treason"; } arty++;
			if ( artifact == arty) { name="Artifact_RobinHoodsBow"; item="Robin Hood's Bow"; } arty++;
			if ( artifact == arty) { name="Artifact_RobinHoodsFeatheredHat"; item="Robin Hood's Feathered Hat"; } arty++;
			if ( artifact == arty) { name="Artifact_RodOfResurrection"; item="Rod Of Resurrection"; } arty++;
			if ( artifact == arty) { name="Artifact_RoyalArchersBow"; item="Royal Archer's Bow"; } arty++;
			if ( artifact == arty) { name="Artifact_LieutenantOfTheBritannianRoyalGuard"; item="Royal Guard Sash"; } arty++;
			if ( artifact == arty) { name="Artifact_RoyalGuardSurvivalKnife"; item="Royal Guard Survival Knife"; } arty++;
			if ( artifact == arty) { name="Artifact_RoyalGuardsGorget"; item="Royal Guardian's Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_RoyalGuardsChestplate"; item="Royal Guard's Chest Plate"; } arty++;
			if ( artifact == arty) { name="Artifact_LeggingsOfEmbers"; item="Royal Leggings of Embers"; } arty++;
			if ( artifact == arty) { name="Artifact_RuneCarvingKnife"; item="Rune Carving Knife"; } arty++;
			if ( artifact == arty) { name="Artifact_FalseGodsScepter"; item="Scepter Of The False Goddess"; } arty++;
			if ( artifact == arty) { name="Artifact_SerpentsFang"; item="Serpent's Fang"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerArms"; item="Shadow Dancer Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerCap"; item="Shadow Dancer Cap"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerGloves"; item="Shadow Dancer Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerGorget"; item="Shadow Dancer Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerLeggings"; item="Shadow Dancer Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_ShadowDancerTunic"; item="Shadow Dancer Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_ShaMontorrossbow"; item="Shamino's Crossbow"; } arty++;
			if ( artifact == arty) { name="Artifact_ShardThrasher"; item="Shard Thrasher"; } arty++;
			if ( artifact == arty) { name="Artifact_ShieldOfInvulnerability"; item="Shield of Invulnerability"; } arty++;
			if ( artifact == arty) { name="Artifact_ShimmeringTalisman"; item="Shimmering Talisman"; } arty++;
			if ( artifact == arty) { name="Artifact_ShroudOfDeciet"; item="Shroud of Deceit"; } arty++;
			if ( artifact == arty) { name="Artifact_SilvanisFeywoodBow"; item="Silvani's Feywood Bow"; } arty++;
			if ( artifact == arty) { name="Artifact_TheDragonSlayer"; item="Slayer of Dragons"; } arty++;
			if ( artifact == arty) { name="Artifact_SongWovenMantle"; item="Song Woven Mantle"; } arty++;
			if ( artifact == arty) { name="Artifact_SoulSeeker"; item="Soul Seeker"; } arty++;
			if ( artifact == arty) { name="Artifact_SpellWovenBritches"; item="Spell Woven Britches"; } arty++;
			if ( artifact == arty) { name="Artifact_PolarBearMask"; item="Spirit of the Polar Bear"; } arty++;
			if ( artifact == arty) { name="Artifact_SpiritOfTheTotem"; item="Spirit of the Totem"; } arty++;
			if ( artifact == arty) { name="Artifact_SprintersSandals"; item="Sprinter's Sandals"; } arty++;
			if ( artifact == arty) { name="Artifact_StaffOfPower"; item="Staff of Power"; } arty++;
			if ( artifact == arty) { name="Artifact_StaffOfTheMagi"; item="Staff of the Magi"; } arty++;
			if ( artifact == arty) { name="Artifact_StaffofSnakes"; item="Staff of the Serpent"; } arty++;
			if ( artifact == arty) { name="Artifact_StitchersMittens"; item="Stitcher's Mittens"; } arty++;
			if ( artifact == arty) { name="Artifact_Stormbringer"; item="Stormbringer"; } arty++;
			if ( artifact == arty) { name="Artifact_Subdue"; item="Subdue"; } arty++;
			if ( artifact == arty) { name="Artifact_SwiftStrike"; item="Swift Strike"; } arty++;
			if ( artifact == arty) { name="Artifact_GlassSword"; item="Sword of Shattered Hopes"; } arty++;
			if ( artifact == arty) { name="Artifact_SinbadsSword"; item="Sword of Sinbad"; } arty++;
			if ( artifact == arty) { name="Artifact_TalonBite"; item="Talon Bite"; } arty++;
			if ( artifact == arty) { name="Artifact_TheTaskmaster"; item="Taskmaster"; } arty++;
			if ( artifact == arty) { name="Artifact_TitansHammer"; item="Titan's Hammer"; } arty++;
			if ( artifact == arty) { name="Arty_LithosTome"; item="Tome of the Mountain King"; } arty++;
			if ( artifact == arty) { name="Artifact_TorchOfTrapFinding"; item="Torch of Trap Burning"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemArms"; item="Totem Arms"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemGloves"; item="Totem Gloves"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemGorget"; item="Totem Gorget"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemLeggings"; item="Totem Leggings"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemOfVoid"; item="Totem of the Void"; } arty++;
			if ( artifact == arty) { name="Artifact_TotemTunic"; item="Totem Tunic"; } arty++;
			if ( artifact == arty) { name="Artifact_TunicOfAegis"; item="Tunic of Aegis"; } arty++;
			if ( artifact == arty) { name="Artifact_TunicOfBane"; item="Tunic of Bane"; } arty++;
			if ( artifact == arty) { name="Artifact_TunicOfFire"; item="Tunic of Fire"; } arty++;
			if ( artifact == arty) { name="Artifact_TunicOfTheFallenKing"; item="Tunic of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_TunicOfTheHarrower"; item="Tunic of the Harrower"; } arty++;
			if ( artifact == arty) { name="Artifact_BelmontWhip"; item="Vampire Killer"; } arty++;
			if ( artifact == arty) { name="Artifact_VampiricDaisho"; item="Vampiric Daisho"; } arty++;
			if ( artifact == arty) { name="Artifact_VioletCourage"; item="Violet Courage"; } arty++;
			if ( artifact == arty) { name="Artifact_VoiceOfTheFallenKing"; item="Voice of the Fallen King"; } arty++;
			if ( artifact == arty) { name="Artifact_WarriorsClasp"; item="Warrior's Clasp"; } arty++;
			if ( artifact == arty) { name="Artifact_WildfireBow"; item="Wildfire Bow"; } arty++;
			if ( artifact == arty) { name="Artifact_Windsong"; item="Windsong"; } arty++;
			if ( artifact == arty) { name="Artifact_ArcticBeacon"; item="Winter Beacon"; } arty++;
			if ( artifact == arty) { name="Artifact_WizardsPants"; item="Wizard's Pants"; } arty++;
			if ( artifact == arty) { name="Artifact_WrathOfTheDryad"; item="Wrath of the Dryad"; } arty++;
			if ( artifact == arty) { name="Artifact_YashimotosHatsuburi"; item="Yashimoto's Hatsuburi"; } arty++;
			if ( artifact == arty) { name="Artifact_ZyronicClaw"; item="Zyronic Claw"; } arty++;
			if ( artifact == arty) { name="Artifact_GlovesOfThePiper"; item="Gloves of the Pied Piper";} arty++;
			if ( artifact == arty) { name="Artifact_PiedPiperFeatheredHat"; item="Pied Piper's Feathered Hat";} arty++;
			if ( artifact == arty) { name="Artifact_ShirtOfThePiper"; item="Shirt of the Pied Piper";} arty++;
			if ( artifact == arty) { name="Artifact_BootsOfThePiper"; item="Boots of the Pied Piper";} arty++;
			if ( artifact == arty) { name="Artifact_TrousersOfThePiper"; item="Trousers of the Pied Piper";} arty++;
			if ( artifact == arty) { name="Artifact_WhistleofthePiper"; item="Whistle of the Pied Piper";} arty++;
			if ( artifact == arty) { name="Artifact_NatureVengeanceMask"; item="Mask of Natural Vengeance";} arty++;
			if ( artifact == arty) { name="Artifact_NatureVengeanceCoat"; item="Coat of Natural Vengeance";} arty++;
			if ( artifact == arty) { name="Artifact_NatureVengeanceLeggings"; item="Leggings of Natural Vengeance";} arty++;
			if ( artifact == arty) { name="Artifact_NatureVengeanceArms"; item="Arms of Natural Vengeance";} arty++;
			if ( artifact == arty) { name="Artifact_NatureVengeanceGloves"; item="Gloves of Natural Vengeance";} arty++;
			if ( artifact == arty) { name="Artifact_NatureMasterHeaddress"; item="Headdress of the Nature's Master";} arty++;
			if ( artifact == arty) { name="Artifact_NatureMasterCoat"; item="Coat of the Nature's Master";} arty++;
			if ( artifact == arty) { name="Artifact_NatureMasterLeggings"; item="Leggings of the Nature's Master";} arty++;
			if ( artifact == arty) { name="Artifact_NatureMasterArms"; item="Arms of the Nature's Master";} arty++;
			if ( artifact == arty) { name="Artifact_NatureMasterGloves"; item="Gloves of the Nature's Master";} arty++;
			if ( artifact == arty) { name="Artifact_ProwleroftheWildsLegging"; item="Leggings of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_ProwleroftheWildsHelmet"; item="Mask of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_ProwleroftheWildsGloves"; item="Gloves of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_ProwleroftheWildsTunic"; item="Tunic of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_ProwleroftheWildsArms"; item="Arms of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_ProtectoroftheWildsChestplate"; item="Chestplate of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_ProtectoroftheWildsLeggings"; item="Leggings of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_ProtectoroftheWildsGloves"; item="Gloves of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_ProtectoroftheWildsArms"; item="Arms of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_ProtectoroftheWildsHelmet"; item="Helmet of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_RobeOfWilds"; item="Robe of the Wilds";} arty++;
			if ( artifact == arty) { name="Artifact_RobeOfWildLegion"; item="Robe of the Wild Legion";} arty++;
			if ( artifact == arty) { name="Artifact_StaffoftheWoodlands"; item="Staff of the Woodlands";} arty++;
			if ( artifact == arty) { name="Artifact_BowOfTheProwler"; item="Bow of the Prowler";} arty++;
			if ( artifact == arty) { name="Artifact_BladeOfTheWilds"; item="Blade of the Wilds";} arty++;
			if ( part == 2 ){ item = name; }

			return item;
		}
	}
}