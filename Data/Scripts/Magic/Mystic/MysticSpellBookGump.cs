using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Misc; 
using Server.Network; 
using Server.Spells; 
using Server.Spells.Mystic; 
using Server.Prompts; 

namespace Server.Gumps 
{ 
	public class MysticSpellbookGump : Gump 
	{
		private MysticSpellbook m_Book; 
		private int m_Page; 
		private Map m_Map;
		private int m_X;
		private int m_Y;

		public bool HasSpell(Mobile from, int spellID)
		{
			if ( m_Book.RootParentEntity == from )
				return (m_Book.HasSpell(spellID));
			else
				return false;
		}

		public MysticSpellbookGump( Mobile from, MysticSpellbook book, int page ) : base( 100, 100 ) 
		{
			m_Book = book;
			m_Page = page;

			string color = "#d6c382";

			bool showScrollBar = true;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			int PriorPage = page - 1;
				if ( PriorPage < 1 ){ PriorPage = 12; }
			int NextPage = page + 1;

			AddImage(0, 0, 7005);
			AddImage(0, 0, 7006);
			AddImage(0, 0, 7024, 2736);
			AddButton(72, 45, 4014, 4014, PriorPage, GumpButtonType.Reply, 0);
			AddButton(590, 48, 4005, 4005, NextPage, GumpButtonType.Reply, 0);
			AddImage(83, 110, 7044);
			AddImage(380, 110, 7044);

			string abil_name = "";
			int abil_icon = 0;
			string abil_text = "";
			string abil_info = "<br><br>To learn the secrets of this ability, you need to find the following location and open this book there to reach into your ki for enlightenment:<br><br>";
			string abil_skil = "";
			string abil_mana = "";
			string abil_tith = "";
			int abil_spid = (page+248);

			if ( page == 2 ){ 		abil_name = "Astral Projection";	abil_icon = 0x500E;	abil_skil = "80"; abil_mana = "50"; abil_tith = "300"; 
				m_Map = book.WritMap01;
				m_X = (int)( ( book.WritX101 + book.WritX201 ) / 2 );
				m_Y = (int)( ( book.WritY101 + book.WritY201 ) / 2 );
				abil_info += "Place: " + book.WritPlace01 + "<br><br>";
				abil_info += "World: " + book.WritWorld01 + "<br><br>";
				abil_info += "Location: " + book.WritCoord01 + "<br>";
				abil_text = "Enter the astral plane where your soul is immune to harm. While you are in this state, you can freely travel but your interraction with the world is minimal. The better your skill, the longer it lasts. Monks use this ability to safely travel through dangerous areas."; }
			else if ( page == 3 ){ 	abil_name = "Astral Travel";		abil_icon = 0x410;	abil_skil = "50"; abil_mana = "40"; abil_tith = "35"; 
				m_Map = book.WritMap02;
				m_X = (int)( ( book.WritX102 + book.WritX202 ) / 2 );
				m_Y = (int)( ( book.WritY102 + book.WritY202 ) / 2 );
				abil_info += "Place: " + book.WritPlace02 + "<br><br>";
				abil_info += "World: " + book.WritWorld02 + "<br><br>";
				abil_info += "Location: " + book.WritCoord02 + "<br>";
				abil_text = "Travel through the astral plane to another location with the use of a magical recall rune. The rune must be marked by other magical means before you can travel to that location. If you wish to travel using a rune book, then set your rune book's default location and then you can target the book while using this ability."; }
			else if ( page == 4 ){ 	abil_name = "Create Robe";			abil_icon = 0x15;	abil_skil = "25"; abil_mana = "20"; abil_tith = "150"; 
				m_Map = book.WritMap03;
				m_X = (int)( ( book.WritX103 + book.WritX203 ) / 2 );
				m_Y = (int)( ( book.WritY103 + book.WritY203 ) / 2 );
				abil_info += "Place: " + book.WritPlace03 + "<br><br>";
				abil_info += "World: " + book.WritWorld03 + "<br><br>";
				abil_info += "Location: " + book.WritCoord03 + "<br>";
				abil_text = "Creates a robe that you will need in order to use the other abilities in this tome. The robe will have power based on your overall skill as a monk, and no one else may wear the robe. You can only have one such robe at a time, so creating a new robe will cause any others you own to go back to the astral plane. After creation, single click the robe and select the 'Enchant' option to spend the points on attributes you want the robe to have."; }
			else if ( page == 5 ){ 	abil_name = "Gentle Touch";			abil_icon = 0x971;	abil_skil = "30"; abil_mana = "25"; abil_tith = "15"; 
				m_Map = book.WritMap04;
				m_X = (int)( ( book.WritX104 + book.WritX204 ) / 2 );
				m_Y = (int)( ( book.WritY104 + book.WritY204 ) / 2 );
				abil_info += "Place: " + book.WritPlace04 + "<br><br>";
				abil_info += "World: " + book.WritWorld04 + "<br><br>";
				abil_info += "Location: " + book.WritCoord04 + "<br>";
				abil_text = "Perform a soothing touch, healing damage sustained. The higher your skill, the more damage you will heal with your touch."; }
			else if ( page == 6 ){ 	abil_name = "Leap";					abil_icon = 0x4B2;	abil_skil = "35"; abil_mana = "20"; abil_tith = "10"; 
				m_Map = book.WritMap05;
				m_X = (int)( ( book.WritX105 + book.WritX205 ) / 2 );
				m_Y = (int)( ( book.WritY105 + book.WritY205 ) / 2 );
				abil_info += "Place: " + book.WritPlace05 + "<br><br>";
				abil_info += "World: " + book.WritWorld05 + "<br><br>";
				abil_info += "Location: " + book.WritCoord05 + "<br>";
				abil_text = "Allows you to leap over a long distance. This is a quick action and can allow a monk to leap toward an opponent, leap away to safety, or leap over some obstacles like rivers and streams."; }
			else if ( page == 7 ){ 	abil_name = "Psionic Blast";		abil_icon = 0x5DC2;	abil_skil = "30"; abil_mana = "35"; abil_tith = "15"; 
				m_Map = book.WritMap06;
				m_X = (int)( ( book.WritX106 + book.WritX206 ) / 2 );
				m_Y = (int)( ( book.WritY106 + book.WritY206 ) / 2 );
				abil_info += "Place: " + book.WritPlace06 + "<br><br>";
				abil_info += "World: " + book.WritWorld06 + "<br><br>";
				abil_info += "Location: " + book.WritCoord06 + "<br>";
				abil_text = "Summon your Ki to perform a mental attack that deals an amount of energy damage based upon your fist fighting and intelligence values. Elemental Resistances may reduce damage done by this attack."; }
			else if ( page == 8 ){ 	abil_name = "Psychic Wall";			abil_icon = 0x1A;	abil_skil = "60"; abil_mana = "45"; abil_tith = "500"; 
				m_Map = book.WritMap07;
				m_X = (int)( ( book.WritX107 + book.WritX207 ) / 2 );
				m_Y = (int)( ( book.WritY107 + book.WritY207 ) / 2 );
				abil_info += "Place: " + book.WritPlace07 + "<br><br>";
				abil_info += "World: " + book.WritWorld07 + "<br><br>";
				abil_info += "Location: " + book.WritCoord07 + "<br>";
				abil_text = "You sheer force of will creates a barrier around you, deflecting magical attacks. This does not work against odd magics like necromancy. Affected spells will often bounce back onto the caster."; }
			else if ( page == 9 ){ 	abil_name = "Purity of Body";		abil_icon = 0x96D;	abil_skil = "40"; abil_mana = "35"; abil_tith = "25"; 
				m_Map = book.WritMap08;
				m_X = (int)( ( book.WritX108 + book.WritX208 ) / 2 );
				m_Y = (int)( ( book.WritY108 + book.WritY208 ) / 2 );
				abil_info += "Place: " + book.WritPlace08 + "<br><br>";
				abil_info += "World: " + book.WritWorld08 + "<br><br>";
				abil_info += "Location: " + book.WritCoord08 + "<br>";
				abil_text = "You can cleanse your body of poisons with this ability due to your physical discipline, and as such, it cannot be used to aid anyone else."; }
			else if ( page == 10 ){	abil_name = "Quivering Palm";		abil_icon = 0x5001;	abil_skil = "20"; abil_mana = "20"; abil_tith = "20"; 
				m_Map = book.WritMap09;
				m_X = (int)( ( book.WritX109 + book.WritX209 ) / 2 );
				m_Y = (int)( ( book.WritY109 + book.WritY209 ) / 2 );
				abil_info += "Place: " + book.WritPlace09 + "<br><br>";
				abil_info += "World: " + book.WritWorld09 + "<br><br>";
				abil_info += "Location: " + book.WritCoord09 + "<br>";
				abil_text = "You must be wearing some sort of pugilist gloves for this ability to work. It temporarily enhances the kind of damage the gloves do. The type of damage inflicted when hitting a target will be converted to the target's worst resistance type. The duration of the effect is affected by your fist fighting skill."; }
			else if ( page == 11 ){	abil_name = "Wind Runner";			abil_icon = 0x19;	abil_skil = "70"; abil_mana = "50"; abil_tith = "250"; 
				m_Map = book.WritMap10;
				m_X = (int)( ( book.WritX110 + book.WritX210 ) / 2 );
				m_Y = (int)( ( book.WritY110 + book.WritY210 ) / 2 );
				abil_info += "Place: " + book.WritPlace10 + "<br><br>";
				abil_info += "World: " + book.WritWorld10 + "<br><br>";
				abil_info += "Location: " + book.WritCoord10 + "<br>";
				abil_text = "This ability allows the monk to run as fast as a steed. This ability should be avoided if you already have a mount you are riding, or perhaps you have magical boots that allow you to run at this speed. using this ability in such conditions may cause unusual travel speeds, so be leery.";
					if ( MySettings.S_NoMountsInCertainRegions )
					{
						abil_text = abil_text + " Be aware when exploring the land, that there are some areas you cannot use this ability in. These are areas such as dungeons, caves, and some indoor areas. If you enter such an area, this ability will be hindered.";
					}
				}

			abil_info += "<br>Make sure you bring a blank scroll with you, so you can write what you have learned. You can then place your writings within this book.<br>";

			if ( page == 1 )
			{
				AddHtml( 110, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK ABILITIES</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 404, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK ABILITIES</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				int SpellsInBook = 10;
				int SafetyCatch = 0;
				int SpellsListed = 249;
				string SpellName = "";

				int nHTMLx = 130;
				int nHTMLy = 105;

				int nBUTTONx = 75;
				int nBUTTONy = 93;

				int iBUTTON = 1;

				while ( SpellsInBook > 0 )
				{
					SpellsListed++;
					SafetyCatch++;

					if ( this.HasSpell( from, SpellsListed ) )
					{
						SpellsInBook--;

						if ( SpellsListed == 250 ){ SpellName = "Astral Projection"; iBUTTON = 0x500E; }
						else if ( SpellsListed == 251 ){ SpellName = "Astral Travel"; iBUTTON = 0x410; }
						else if ( SpellsListed == 252 ){ SpellName = "Create Robe"; iBUTTON = 0x15; }
						else if ( SpellsListed == 253 ){ SpellName = "Gentle Touch"; iBUTTON = 0x971; }
						else if ( SpellsListed == 254 ){ SpellName = "Leap"; iBUTTON = 0x4B2; }
						else if ( SpellsListed == 255 ){ SpellName = "Psionic Blast"; iBUTTON = 0x5DC2; }
						else if ( SpellsListed == 256 ){ SpellName = "Psychic Wall"; iBUTTON = 0x1A; }
						else if ( SpellsListed == 257 ){ SpellName = "Purity of Body"; iBUTTON = 0x96D; }
						else if ( SpellsListed == 258 ){ SpellName = "Quivering Palm"; iBUTTON = 0x5001; }
						else if ( SpellsListed == 259 ){ SpellName = "Wind Runner"; iBUTTON = 0x19; }

						AddButton(nBUTTONx, nBUTTONy, iBUTTON, iBUTTON, SpellsListed, GumpButtonType.Reply, 0);
						AddImage(nBUTTONx, nBUTTONy, iBUTTON, 2422);
						AddHtml( nHTMLx, nHTMLy, 177, 20, @"<BODY><BASEFONT Color=" + color + ">" + SpellName + "</BASEFONT></BODY>", (bool)false, (bool)false);

						nHTMLy = nHTMLy + 65;
						if ( SpellsInBook == 5 ){ nHTMLx = 432; nHTMLy = 105; }

						nBUTTONy = nBUTTONy + 65;
						if ( SpellsInBook == 5 ){ nBUTTONx = 375; nBUTTONy = 93; }
					}

					if ( SafetyCatch > 10 ){ SpellsInBook = 0; }
				}
			}
			else if ( page > 1 && page < 12 )
			{
				AddHtml( 110, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK ABILITIES</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 404, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK ABILITIES</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				string know = "<BODY><BASEFONT Color=#f58a8a>Not Learned</BASEFONT></BODY>"; if ( this.HasSpell( from, abil_spid ) ){ know = "<BODY><BASEFONT Color=#8af599>Learned</BASEFONT></BODY>"; }

				string ismonk = "<BODY><BASEFONT Color=#f58a8a>You are not a Monk!</BASEFONT></BODY>";
				if ( Server.Misc.GetPlayerInfo.isMonk( from ) )
					ismonk = "<BODY><BASEFONT Color=#8af599>You are on the path...</BASEFONT></BODY>";

				AddHtml( 130, 105, 200, 20, @"<BODY><BASEFONT Color=" + color + ">" + abil_name + "</BASEFONT></BODY>", (bool)false, (bool)false);
				if ( this.HasSpell( from, abil_spid) ){ abil_info = ""; showScrollBar = false; AddButton(78, 94, abil_icon, abil_icon, abil_spid, GumpButtonType.Reply, 0); }
				AddImage(78, 94, abil_icon, 2422);

				AddHtml( 75, 370, 253, 20, @"" + ismonk + "", (bool)false, (bool)false);

				AddHtml( 75, 336, 253, 20, @"" + know + "", (bool)false, (bool)false);

				AddHtml( 130, 160, 88, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 225, 160, 88, 20, @"<BODY><BASEFONT Color=" + color + ">" + abil_skil + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 210, 88, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 225, 210, 88, 20, @"<BODY><BASEFONT Color=" + color + ">" + abil_mana + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 260, 88, 20, @"<BODY><BASEFONT Color=" + color + ">Tithe:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 225, 260, 88, 20, @"<BODY><BASEFONT Color=" + color + ">" + abil_tith + "</BASEFONT></BODY>", (bool)false, (bool)false);

				AddHtml( 370, 82, 247, 309, @"<BODY><BASEFONT Color=" + color + ">" + abil_text + abil_info + "</BASEFONT></BODY>", (bool)false, (bool)showScrollBar);

				if ( !this.HasSpell( from, abil_spid ) && Sextants.HasSextant( from ) )
					AddButton(305, 52, 10461, 10461, 800, GumpButtonType.Reply, 0);
			}
			else if ( page == 12 )
			{
				AddHtml( 110, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK ABILITIES</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 404, 47, 177, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>MONK RUCKSACK</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				AddHtml( 78, 83, 247, 309, @"<BODY><BASEFONT Color=" + color + ">Monks are an order of those that hone their body and spirit. To become a monk, one must become a natural grandmaster in both focus and mediation. Monks may not use any weapons nor use any type of armor, unless the armor is light or enough to allow the channeling of spells. Their innate abilities come from their skills in fist fighting, so they may make use of pugilist gloves. To perform any of the monk abilities, one must adhere to these rules. A monk is also not considered such unless they wear a mystical monk's robe that they themselves create by using the associated monk ability. Along with that, monks do not require the donning of this robe if they are to create such a robe. That is the only exception.<br><br>When you acquired this tome, you likely looked through the pages to see the various abilities a monk may learn. In order to learn the secrets of these abilities, you need to travel to the various locations and open this book there to reach into your ki for enlightenment. Make sure you bring a blank scroll with you, so you can write what you have learned. You can then place your writings within this book and use the abilities if your skill and mana allow it. Whenever one touches these tomes, it is bound to their individual ki unless it is already bound to another. This means you will be the only one able to open the book as it belongs to you. Your writings also share this quality, so when you learn about new abilities, the parchments belong to you. Anyone else that touches these parchments will cause the paper to crumble to dust.<br><br>As previously stated, monks can create their own robes and this is something every monk must seek to do quickly. Without wearing this robe, a monk cannot perform the abilities they have learned. A monk's ability level will determine the power of the robe created. When you create the robe, it will appear in your pack and it will have a number of points you can spend to enhance it. This allows you to tailor the robe to suit your style. To begin, single click the robe and select 'Status'. A menu will appear that you can choose which attributes you want the robe to have. Be careful, as you cannot change an attribute once you select it. The points you can spend is equal to the power of the robe. Only one of your robes may exist in the world at a time, so if you create another, any previous robes will vanish to the astral plane.<br><br>Monks seek to contribute to causes other than their own, so some monks seek to help those less fortunate, while more vile monks seek to help causes that dampen the good of the land. As such they must tithe gold in order to use their abilities. You can tithe gold at any shrine you can find by single clicking the shrine and choosing the appropriate option. Abilities require varying amounts of tithing points to use. This tome will show you how many points you have available, and this information can also be seen by pressing the 'Info' button on your character's paper doll.<br><br>To demonstrate your title of 'Monk', you should set your skill title to 'Fist Fighting'. As long as you follow the rules of monkhood, your title will remain as such. If you have an apprentice ability in either magical or necromantic arts, but live the life of a monk, then your title would be that of 'Mystic'. Adventurous monks can learn skills other than those monks must know, just make sure any other skills will bit hinder the life of a monk (do not learn sword fighting, for example, as swords are useless to monks). There are no other behavioral requirements to be a monk. Some are good, and some are evil. It is all up to you on the path you take.<br><br>You can have tool bars to quickly use these abilities, and although you can manage this in the 'Help' menu, below are commands you can type to use these tool bars:<br><br>Open the first ability bar editor:<br><br>[monkspell1<br><br>Open the second ability bar editor:<br><br>[monkspell2<br><br>Open the first ability bar:<br><br>[monktool1<br><br>Open the second ability bar:<br><br>[monktool2<br><br>Close the first ability bar:<br><br>[monkclose1<br><br>Close the second ability bar:<br><br>[monkclose2<br><br><br><br>Below are some commands you can type to use these abilities, and can help when creating macros:<br><br>[AstralProjection<br><br>[AstralTravel<br><br>[CreateRobe<br><br>[GentleTouch<br><br>[Leap<br><br>[PsionicBlast<br><br>[PsychicWall<br><br>[PurityOfBody<br><br>[QuiveringPalm<br><br>[WindRunner<br><br></BASEFONT></BODY>", (bool)false, (bool)true);
				AddHtml( 370, 83, 247, 309, @"<BODY><BASEFONT Color=" + color + ">When you have reached the level of grandmaster monk or mystic, you can travel to the " + book.PackShrine + " in Ambrosia and use your ki to call forth a monk's rucksack from the astral plane. You will need a pearl in order to do this. When you step into the shrine, open this book and if you are worthy, the rucksack will appear. Be careful, however, as you can only have one rucksack at a time and any others you may have like this will vanish back to the astral plane and any items in it. These rucksacks allow a monk to carry 100 different items with virtually no weight to anything placed within the rucksack. You will be the only one able to open this particular rucksack, and if you lose your path of a grandmaster monk or mystic, you will not be able to open the rucksack. You cannot store your monk's robe or your tome in this bag.</BASEFONT></BODY>", (bool)false, (bool)true);
			}
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile; 

			if ( info.ButtonID == 800 )
			{
				from.PlaySound( 0x249 );
				from.SendGump( new MysticSpellbookGump( from, m_Book, m_Page ) );
				from.CloseGump( typeof( Sextants.MapGump ) );
				from.SendGump( new Sextants.MapGump( from, m_Map, m_X, m_Y, null ) );
			}
			else if ( info.ButtonID < 200 && info.ButtonID > 0 )
			{
				from.SendSound( 0x55 );
				int page = info.ButtonID;
				if ( page < 1 ){ page = 12; }
				if ( page > 12 ){ page = 1; }
				from.SendGump( new MysticSpellbookGump( from, m_Book, page ) );
				from.CloseGump( typeof( Sextants.MapGump ) );
			}
			else if ( info.ButtonID > 200 && HasSpell(from, info.ButtonID) )
			{
				if ( info.ButtonID == 250 ){ new AstralProjection( from, null ).Cast(); }
				else if ( info.ButtonID == 251 ){ new AstralTravel( from, null ).Cast(); }
				else if ( info.ButtonID == 252 ){ new CreateRobe( from, null ).Cast(); }
				else if ( info.ButtonID == 253 ){ new GentleTouch( from, null ).Cast(); }
				else if ( info.ButtonID == 254 ){ new Leap( from, null ).Cast(); }
				else if ( info.ButtonID == 255 ){ new PsionicBlast( from, null ).Cast(); }
				else if ( info.ButtonID == 256 ){ new PsychicWall( from, null ).Cast(); }
				else if ( info.ButtonID == 257 ){ new PurityOfBody( from, null ).Cast(); }
				else if ( info.ButtonID == 258 ){ new QuiveringPalm( from, null ).Cast(); }
				else if ( info.ButtonID == 259 ){ new WindRunner( from, null ).Cast(); }

				from.SendGump( new MysticSpellbookGump( from, m_Book, 1 ) );
				from.CloseGump( typeof( Sextants.MapGump ) );
			}
			else
			{
				from.SendSound( 0x55 );
				from.CloseGump( typeof( Sextants.MapGump ) );
			}
		}
	}
}