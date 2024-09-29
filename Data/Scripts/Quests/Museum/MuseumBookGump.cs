using System;
using Server;
using System.Collections; 
using Server.Items; 
using Server.Misc; 
using Server.Network; 
using Server.Regions; 

namespace Server.Gumps 
{ 
	public class MuseumBookGump : Gump 
	{
		private MuseumBook m_Book; 

		public MuseumBookGump( Mobile from, MuseumBook book, int page, int lookat ) : base( 50, 50 ) 
		{
			from.SendSound( 0x4A );
			string plain = "#d1b2a6";
			string white = "#ffffff";
			string losts = "#d71c1c";
			string found = "#68d560";

			if ( lookat > 60 || lookat < 1 ){ lookat = 1; }

			m_Book = book; 

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7023, Server.Misc.PlayerSettings.GetGumpHue( from ));

			AddHtml( 12, 12, 603, 20, @"<BODY><BASEFONT Color=" + plain + ">TOME OF MUSEUM ANTIQUES</BASEFONT></BODY>", (bool)false, (bool)false);

			if ( page == 3 )
			{
				AddButton(864, 12, 4017, 4017, 901, GumpButtonType.Reply, 0);
				AddHtml( 12, 42, 880, 549, @"<BODY><BASEFONT Color=" + plain + ">The Search For Museum Antiques<BR><BR>You have decided to embark on a search for 60 different antiques that the Art Collector would like to have researched. The problem is, you don’t know where to begin. In order to get clues, you will need to talk to citizens (orange names) to see if they can perhaps tell you where to search. If a citizen doesn’t initially mention anything about antiques, you will have to seek out another. When you finally get a clue, a small tune will play and your book will be updated with that rumor they gave you. It could be true or it could be false. You won’t know until you go there. Sometimes the antique may be in a chest or bag on a pedestal in a dungeon, or held by one of the more powerful creatures within that dungeon. As you collect antiques, they will be marked off in your book. When they are all marked off, then you can give the book to the Art Collector to claim your " + MuseumBook.QuestValue() + " gold. The antiques you collected can also be given to the Art Collector, and you can double click the item in your pack to see what the value of it is. Some antiques are lights or fires that can be turned on or off. Each antique has a base value and then a value affected by certain characteristics you have. You can only embark on this search once, so don’t lose your book.<BR><BR><BR>Antiques Value Modifiers<br><br>- Merchant Skill<br>    (Mercantile)<br><br>- Begging Skill<br>    (If Demeanor Is Set)<br><br>- Merchant Guild Member</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else
			{
				if ( page == 1 )
				{
					AddButton(863, 570, 4005, 4005, 902, GumpButtonType.Reply, 0);
				}
				else
				{
					AddButton(12, 570, 4014, 4014, 901, GumpButtonType.Reply, 0);
				}

				AddButton(864, 12, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddButton(805, 12, 3610, 3610, 903, GumpButtonType.Reply, 0);

				string rumor = "";
				if ( m_Book.RumorFrom != "" )
				{
					rumor = MuseumBook.GetRumor( m_Book, MuseumBook.GetNext( m_Book ), false );
				}

				AddHtml( 12, 50, 880, 50, @"<BODY><BASEFONT Color=" + white + ">" + rumor + "</BASEFONT></BODY>", (bool)false, (bool)false);

				int cycle = 30;
				int txt = 320;
				int btn = 275;
				int down = 45;
				int item = 1; if ( page == 2 ){ item = 31; }

				while ( cycle > 0 )
				{
					if ( cycle == 15 ){ txt = 645; btn = 600; down = 45; }
						down = down + 30;

					int button = 3609;
					string color = plain;
					if ( item == MuseumBook.GetNext( m_Book ) && m_Book.RumorFrom != "" ){ button = 4011; }
					else if ( MuseumBook.GetMuseums( item, m_Book ) > 0 ){ button = 4017; color = found; }

					if ( item == lookat ){ color = white; }

					AddButton(btn, down+30, button, button, item, GumpButtonType.Reply, 0);
					AddHtml( txt, down+30, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + MuseumBook.AntiqueInfo( item, 4, m_Book ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					item++;
					cycle--;
				}

				if ( MuseumBook.GetMuseums( lookat, m_Book ) > 0 ){ AddHtml( 55, 450, 100, 20, @"<BODY><BASEFONT Color=" + found + ">Found</BASEFONT></BODY>", (bool)false, (bool)false); }
				else { AddHtml( 55, 450, 100, 20, @"<BODY><BASEFONT Color=" + losts + ">Lost</BASEFONT></BODY>", (bool)false, (bool)false); }

				if ( lookat == MuseumBook.GetNext( m_Book ) && m_Book.ItemValue > 0 )
				{
					AddItem(40, 481, 3823);
					int cost = Museums.AntiqueTotalValue( m_Book.ItemValue, from, false );
					AddHtml( 80, 485, 100, 20, @"<BODY><BASEFONT Color=" + white + ">" + cost + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				AddHtml( 50, 327, 210, 115, @"<BODY><BASEFONT Color=" + white + ">" + MuseumBook.AntiqueInfo( lookat, 4, m_Book ) + "<br><br>" + MuseumBook.AntiqueInfo( lookat, 5, m_Book ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

				int i = -35;

				if ( lookat == 1 ){ AddItem(i+149, 201, 20425); }
				else if ( lookat == 2 ){ AddItem(i+156, 183, 8850); }
				else if ( lookat == 3 ){ AddItem(i+128, 179, 20411); }
				else if ( lookat == 4 ){ AddItem(i+160, 193, 20414); }
				else if ( lookat == 5 ){ AddItem(i+152, 180, 20407); }
				else if ( lookat == 6 ){ AddItem(i+145, 187, 20403); }
				else if ( lookat == 7 ){ AddItem(i+146, 190, 1167); }
				else if ( lookat == 8 ){ AddItem(i+145, 173, 20415); }
				else if ( lookat == 9 ){ AddItem(i+149, 182, 21187); }
				else if ( lookat == 10 ){ AddItem(i+155, 184, 8836); }
				else if ( lookat == 11 ){ AddItem(i+145, 197, 21189); }
				else if ( lookat == 12 ){ AddItem(i+125, 183, 20388); }
				else if ( lookat == 13 ){ AddItem(i+149, 187, 21288); }
				else if ( lookat == 14 ){ AddItem(i+147, 184, 21355); }
				else if ( lookat == 15 ){ AddItem(i+147, 185, 21323); }
				else if ( lookat == 16 ){ AddItem(i+117, 176, 20401); }
				else if ( lookat == 17 ){ AddItem(i+121, 159, 20393); }
				else if ( lookat == 18 ){ AddItem(i+125, 197, 21276); }
				else if ( lookat == 19 ){ AddItem(i+149, 194, 21256); }
				else if ( lookat == 20 ){ AddItem(i+152, 210, 20399); }
				else if ( lookat == 21 ){ AddItem(i+148, 187, 20429); }
				else if ( lookat == 22 ){ AddItem(i+150, 216, 8519); }
				else if ( lookat == 23 ){ AddItem(i+140, 216, 20413); }
				else if ( lookat == 24 ){ AddItem(i+150, 193, 8829); }
				else if ( lookat == 25 ){ AddItem(i+147, 182, 20420); }
				else if ( lookat == 26 ){ AddItem(i+148, 207, 20384); }
				else if ( lookat == 27 ){ AddItem(i+132, 161, 20391); }
				else if ( lookat == 28 ){ AddItem(i+138, 206, 21191); }
				else if ( lookat == 29 ){ AddItem(i+151, 201, 20387); }
				else if ( lookat == 30 ){ AddItem(i+137, 210, 18080); }
				else if ( lookat == 31 ){ AddItem(i+144, 186, 20418); }
				else if ( lookat == 32 ){ AddItem(i+112, 158, 6247); }
				else if ( lookat == 33 ){ AddItem(i+116, 146, 20422); }
				else if ( lookat == 34 ){ AddItem(i+141, 198, 21333); }
				else if ( lookat == 35 ){ AddItem(i+148, 207, 20386); }
				else if ( lookat == 36 ){ AddItem(i+159, 220, 732); }
				else if ( lookat == 37 ){ AddItem(i+154, 207, 21244); }
				else if ( lookat == 38 ){ AddItem(i+145, 205, 20383); }
				else if ( lookat == 39 ){ AddItem(i+147, 211, 4085); }
				else if ( lookat == 40 ){ AddItem(i+109, 171, 19724); }
				else if ( lookat == 41 ){ AddItem(i+149, 187, 20409); }
				else if ( lookat == 42 ){ AddItem(i+148, 201, 15283); }
				else if ( lookat == 43 ){ AddItem(i+142, 181, 20390); }
				else if ( lookat == 44 ){ AddItem(i+145, 191, 21395); }
				else if ( lookat == 45 ){ AddItem(i+131, 170, 21280); }
				else if ( lookat == 46 ){ AddItem(i+137, 191, 21393); }
				else if ( lookat == 47 ){ AddItem(i+145, 197, 21208); }
				else if ( lookat == 48 ){ AddItem(i+152, 146, 20430); }
				else if ( lookat == 49 ){ AddItem(i+149, 188, 21332); }
				else if ( lookat == 50 ){ AddItem(i+150, 188, 20424); }
				else if ( lookat == 51 ){ AddItem(i+157, 199, 20405); }
				else if ( lookat == 52 ){ AddItem(i+131, 131, 20395); }
				else if ( lookat == 53 ){ AddItem(i+157, 190, 8843); }
				else if ( lookat == 54 ){ AddItem(i+154, 190, 21347); }
				else if ( lookat == 55 ){ AddItem(i+114, 116, 21171); }
				else if ( lookat == 56 ){ AddItem(i+147, 212, 20397); }
				else if ( lookat == 57 ){ AddItem(i+151, 194, 21287); }
				else if ( lookat == 58 ){ AddItem(i+144, 210, 21206); }
				else if ( lookat == 59 ){ AddItem(i+148, 212, 18406); }
				else if ( lookat == 60 ){ AddItem(i+147, 193, 21258); }
			}
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile; 
			from.SendSound( 0x4A );

			int turner = MuseumBook.GetNext( m_Book );

			if ( info.ButtonID == 901 ){ if ( turner > 30 ){ turner = 1; } from.SendGump( new MuseumBookGump( from, m_Book, 1, turner ) ); }
			else if ( info.ButtonID == 902 ){ if ( turner < 31 ){ turner = 31; }  from.SendGump( new MuseumBookGump( from, m_Book, 2, turner ) ); }
			else if ( info.ButtonID == 903 ){ from.SendGump( new MuseumBookGump( from, m_Book, 3, 1 ) ); }
			else if ( info.ButtonID > 0 )
			{
				int page = 1;
					if ( info.ButtonID > 30 ){ page = 2; }
				from.SendGump( new MuseumBookGump( from, m_Book, page, info.ButtonID ) );
			}
		}
	}
}