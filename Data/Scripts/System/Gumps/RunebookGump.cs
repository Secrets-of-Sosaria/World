using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Spells.Seventh;
using Server.Spells.Chivalry;
using Server.Spells.Herbalist;
using Server.Spells.Undead;
using Server.Spells.Magical;
using Server.Spells.Mystic;
using Server.Spells.Research;
using Server.Spells.Elementalism;
using Server.Prompts;
using Server.Mobiles;

namespace Server.Gumps
{
	public class RunebookGump : Gump
	{
		private int m_Page;
		private Runebook m_Book;
		private string fonts = "#d6c382";
		private Map sx_Map01; private Map sx_Map02; private Map sx_Map03; private Map sx_Map04; private Map sx_Map05; private Map sx_Map06; private Map sx_Map07; private Map sx_Map08; private Map sx_Map09; private Map sx_Map10; private Map sx_Map11; private Map sx_Map12; private Map sx_Map13; private Map sx_Map14; private Map sx_Map15; private Map sx_Map16;
		private int sx_X01; private int sx_X02; private int sx_X03; private int sx_X04; private int sx_X05; private int sx_X06; private int sx_X07; private int sx_X08; private int sx_X09; private int sx_X10; private int sx_X11; private int sx_X12; private int sx_X13; private int sx_X14; private int sx_X15; private int sx_X16;
		private int sx_Y01; private int sx_Y02; private int sx_Y03; private int sx_Y04; private int sx_Y05; private int sx_Y06; private int sx_Y07; private int sx_Y08; private int sx_Y09; private int sx_Y10; private int sx_Y11; private int sx_Y12; private int sx_Y13; private int sx_Y14; private int sx_Y15; private int sx_Y16;

		public Runebook Book{ get{ return m_Book; } }

		public string GetEntryHue( Map map )
		{
			if ( map == Map.Sosaria )
				return "#dddddd";
			else if ( map == Map.Lodor )
				return "#f7a6fa";
			else if ( map == Map.Underworld )
				return "#7083aa";
			else if ( map == Map.SerpentIsland )
				return "#ed6060";
			else if ( map == Map.IslesDread )
				return "#eabd6f";
			else if ( map == Map.SavagedEmpire )
				return "#81db9f";

			return "" + fonts + "";
		}

		public string GetName( string name )
		{
			if ( name == null || (name = name.Trim()).Length <= 0 )
				return "Marked Location";

			return name;
		}

		private void AddBackground( Runebook book )
		{
            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			int color = book.Hue - 1;

			if ( book.ItemID == 0x22C5 && book.Hue == 0 ){ color = 2847; }
			else if ( book.ItemID == 0x0F3D && book.Hue == 0 ){ color = 2881; }
			else if ( book.ItemID == 0x4F50 && book.Hue == 0 ){ color = 2847; }
			else if ( book.ItemID == 0x4F51 && book.Hue == 0 ){ color = 2847; }
			else if ( book.ItemID == 0x5463 && book.Hue == 0 ){ color = 2847; }
			else if ( book.ItemID == 0x5464	&& book.Hue == 0 ){ color = 2847; }

			AddPage(0);

			// Background image
			AddImage(0, 0, 7010, color);
			AddImage(0, 0, 7011);
			AddImage(0, 0, 7025, 2736);

			// Charges
			AddHtml( 251, 71, 200, 20, @"<BODY><BASEFONT Color=" + fonts + ">CHARGES: " + m_Book.CurCharges.ToString() + "/" + m_Book.MaxCharges.ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);
		}

		private void AddNavigation()
		{
			// Page Buttons
			int btn0 = 3609; if ( m_Page == 1 ){ btn0 = 4017; }
			int btn1 = 3609; if ( m_Page == 2 ){ btn1 = 4017; }
			int btn2 = 3609; if ( m_Page == 3 ){ btn2 = 4017; }
			int btn3 = 3609; if ( m_Page == 4 ){ btn3 = 4017; }
			int btn4 = 3609; if ( m_Page == 5 ){ btn4 = 4017; }
			int btn5 = 3609; if ( m_Page == 6 ){ btn5 = 4017; }
			int btn6 = 3609; if ( m_Page == 7 ){ btn6 = 4017; }
			int btn7 = 3609; if ( m_Page == 8 ){ btn7 = 4017; }
			int btn8 = 3609; if ( m_Page == 9 ){ btn8 = 4017; }
			int btn9 = 3609; if ( m_Page == 10 ){ btn9 = 4017; }

			int g = 120;
			AddButton(48, g, btn0, btn0, 0, GumpButtonType.Page, 1); g=g+45;
			AddButton(48, g, btn1, btn1, 0, GumpButtonType.Page, 2); g=g+45;
			AddButton(48, g, btn2, btn2, 0, GumpButtonType.Page, 3); g=g+45;
			AddButton(48, g, btn3, btn3, 0, GumpButtonType.Page, 4); g=g+45;
			AddButton(48, g, btn4, btn4, 0, GumpButtonType.Page, 5); g=g+45;
			AddButton(48, g, btn5, btn5, 0, GumpButtonType.Page, 6); g=g+45;
			AddButton(48, g, btn6, btn6, 0, GumpButtonType.Page, 7); g=g+45;
			AddButton(48, g, btn7, btn7, 0, GumpButtonType.Page, 8); g=g+45;
			AddButton(48, g, btn8, btn8, 0, GumpButtonType.Page, 9); g=g+45;
			AddButton(48, g, btn9, btn9, 0, GumpButtonType.Page, 10); g=g+45;
		}

		private void AddIndex()
		{
			// Index
			AddPage( 1 );
			m_Page = 1;
			AddNavigation();

			// Rename button
			AddHtml( 637, 74, 137, 20, @"<BODY><BASEFONT Color=" + fonts + ">RENAME BOOK</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(614, 79, 2447, 2447, 1, GumpButtonType.Reply, 0);

			// List of entries
			List<RunebookEntry> entries = m_Book.Entries;

			int c = 0;
			int x1 = 123;
			int y1 = 78;
				int x4 = 570;
				int y3 = 57;
				int x2 = 0;
				int x3 = 0;
				int y2 = 0;

			for ( int i = 0; i < 16; ++i )
			{
				c++;

				if ( c == 9 ){ x1 = x4; y1 = 78; }

				y1 = y1 + y3;
				x2 = x1+40;
				x3 = x1+75;
				y2 = y1+23;

				string desc;
				string hue;
				string world;

				if ( i < entries.Count )
				{
					desc = GetName( entries[i].Description );
					hue = GetEntryHue( entries[i].Map );
					world = Server.Lands.LandName( Server.Lands.GetLand( entries[i].Map, entries[i].Location, entries[i].Location.X, entries[i].Location.Y ) );

					AddButton(x1, y1, 4005, 4005, (2 + (i * 6) + 0), GumpButtonType.Reply, 0);
					AddHtml( x2, y1, 313, 20, @"<BODY><BASEFONT Color=" + hue + ">" + desc + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( x3, y2, 268, 20, @"<BODY><BASEFONT Color=" + hue + ">" + world + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}
			}

			// Turn page button
			AddButton(905, 72, 4005, 4005, 0, GumpButtonType.Page, 2);
		}

		private void AddInstructions()
		{
			string title = "RUNEBOOK";
				if ( m_Book.Description != null && m_Book.Description != "" ){ title = m_Book.Description; }
			AddHtml( 593, 75, 302, 20, @"<BODY><BASEFONT Color=" + fonts + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 116, 110, 377, 487, @"<BODY><BASEFONT Color=" + fonts + ">Rune Books are designed to help reduce the total number of carried runes and to assist rune libraries.<br><br>General Features:<br><br>- A rune book can hold a total of 16 locations.<br><br>- One of these locations can be set as the 'default' location.<br><br>- Casting the recall, gate, ethereal travel, or sacred journey spell on the rune book will treat the book like a rune marked with the default location.<br><br>- using the astral travel skill on the rune book will treat the book like a rune marked with the default location.<br><br>- using potions of nature fury, mushroom gateway, demonic fire, and black gate on the rune book will treat the book like a rune marked with the default location.<br><br>- Books can have charges that will allow you to recall to locations in the book without using spells, skills, or potions.<br><br>- Rune Books can be recharged with recall, gate, or astral travel scrolls. They can also be recharged with potions of nature fury, mushroom gateway, demonic fire, and black gate. Dragging such items onto the book will add one charge (up to its maximum).<br><br>- Books cannot be recharged while open.<br><br>- Dragging a rune onto a book will add that location to the book.<br><br>- You can name the rune book by opening the book and selecting 'Rename Book'. After selecting that, simply type in the name of the book and hit enter.<br><br>- You can change the appearance of this book by giving it to a local scribe or librarian.</BASEFONT></BODY>", (bool)false, (bool)true);

			AddHtml( 555, 113, 377, 487, @"<BODY><BASEFONT Color=" + fonts + ">Using Rune Books:<br><br>- On the top right of the first index page is an option to rename the book.<br><br>- Casting recall, ethereal travel, or sacred journey directly on the rune book will transport you to the location set as the 'default'.<br><br>- using the astral travel skill directly on the rune book will transport you to the location set as the 'default'.<br><br>- using potions of nature fury and demonic fire directly on the rune book will transport you to the location set as the 'default'.<br><br>- Casting gate directly on the rune book will open a gate with the destination to the 'default' location of the book.<br><br>- using potions of mushroom gateway and black gate directly on the rune book will open a gate with the destination to the 'default' location of the book.<br><br>- To access the non-default locations, you will be able to open the book by double clicking on it.<br><br>- When open, the book will display two index pages with 8 locations on each page.<br><br>- Each page will have the current number of charges listed on the top left side.<br><br>- Each location entry will have a button that will use a charge and transport you to that location. If the book has no charges left, you will not be able to do this.<br><br>- The index pages will display the first 18 characters from the marked rune’s name.<br><br>- The side of the book has book markers. Clicking these numbers will bring you to that page.<br><br>- After each use (success or failure) the rune book needs a few seconds to recharge.<br><br>Rune Book Pages:<br><br>Each rune page will contain buttons that...<br><br>- will use a charge and recall to that location.<br><br>- will set that location as the book's default location.<br><br>- will remove the rune from the book.<br><br>- will use the astral travel ability if you know it.<br><br>- will use a black gate potion if you have one.<br><br>- will use a demonic fire potion if you have one.<br><br>- will cast the elemental gate spell if you have one.<br><br>- will cast the elemental void spell if you have one.<br><br>- will use the etheral travel spell if prepared.<br><br>- will cast the gate travel spell if you know it.<br><br>- will use a mushroom gateway potion if you have one.<br><br>- will use a nature passage potion if you have one.<br><br>- will cast the recall spell if you know it.<br><br>- will cast the sacred journey spell if you know it.</BASEFONT></BODY>", (bool)false, (bool)true);
		}

		private void AddDetails( int index, int half, Mobile from )
		{
			string title = "RUNEBOOK";
				if ( m_Book.Description != null && m_Book.Description != "" ){ title = m_Book.Description; }
			AddHtml( 593, 75, 302, 20, @"<BODY><BASEFONT Color=" + fonts + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);

			string desc;
			string hue;
			string world = "";
			int filled = 0;
			string Sextants = "";
			int defButtonID = 0;

			int rX = 0;
			int rY = 0;
			Map rMap = Map.Sosaria;

			if ( index < m_Book.Entries.Count )
			{
				RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

				desc = GetName( e.Description );
				hue = GetEntryHue( e.Map );
				filled = 1;

				rX = e.Location.X;
				rY = e.Location.Y;
				rMap = e.Map;

				// Location labels
				int xLong = 0, yLat = 0;
				int xMins = 0, yMins = 0;
				bool xEast = false, ySouth = false;

				if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
				{
					Sextants = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
				}

				// Set as default button
				defButtonID = e != m_Book.Default ? 3609 : 4017;

				world = Server.Lands.LandName( Server.Lands.GetLand( e.Map, e.Location, e.Location.X, e.Location.Y ) );
			}
			else
			{
				desc = "Empty";
				hue = fonts;
				filled = 0;
			}

			int v = 0;
			if ( half == 1 ){ v = 437; }

			AddHtml( 150+v, 120, 339, 20, @"<BODY><BASEFONT Color=" + hue + ">" + desc + "</BASEFONT></BODY>", (bool)false, (bool)false);
			if ( filled > 0 )
			{
				AddButton(115+v, 120, 4011, 4011, 2 + (index * 6) + 0, GumpButtonType.Reply, 0);

				AddHtml( 150+v, 150, 339, 20, @"<BODY><BASEFONT Color=" + hue + ">" + Sextants + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 150+v, 180, 339, 20, @"<BODY><BASEFONT Color=" + hue + ">" + world + "</BASEFONT></BODY>", (bool)false, (bool)false);

				if ( Server.Items.Sextants.HasSextant( from ) )
				{
					int btn = 0;
					if ( v == 0 )
					{
						if ( m_Page == 2 ){			btn = 90501; sx_Map01 = rMap; sx_X01 = rX; sx_Y01 = rY; }
						else if ( m_Page == 3 ){	btn = 90503; sx_Map03 = rMap; sx_X03 = rX; sx_Y03 = rY; }
						else if ( m_Page == 4 ){	btn = 90505; sx_Map05 = rMap; sx_X05 = rX; sx_Y05 = rY; }
						else if ( m_Page == 5 ){	btn = 90507; sx_Map07 = rMap; sx_X07 = rX; sx_Y07 = rY; }
						else if ( m_Page == 6 ){	btn = 90509; sx_Map09 = rMap; sx_X09 = rX; sx_Y09 = rY; }
						else if ( m_Page == 7 ){	btn = 90511; sx_Map11 = rMap; sx_X11 = rX; sx_Y11 = rY; }
						else if ( m_Page == 8 ){	btn = 90513; sx_Map13 = rMap; sx_X13 = rX; sx_Y13 = rY; }
						else if ( m_Page == 9 ){	btn = 90515; sx_Map15 = rMap; sx_X15 = rX; sx_Y15 = rY; }
					}
					else
					{
						if ( m_Page == 2 ){			btn = 90502; sx_Map02 = rMap; sx_X02 = rX; sx_Y02 = rY; }
						else if ( m_Page == 3 ){	btn = 90504; sx_Map04 = rMap; sx_X04 = rX; sx_Y04 = rY; }
						else if ( m_Page == 4 ){	btn = 90506; sx_Map06 = rMap; sx_X06 = rX; sx_Y06 = rY; }
						else if ( m_Page == 5 ){	btn = 90508; sx_Map08 = rMap; sx_X08 = rX; sx_Y08 = rY; }
						else if ( m_Page == 6 ){	btn = 90510; sx_Map10 = rMap; sx_X10 = rX; sx_Y10 = rY; }
						else if ( m_Page == 7 ){	btn = 90512; sx_Map12 = rMap; sx_X12 = rX; sx_Y12 = rY; }
						else if ( m_Page == 8 ){	btn = 90514; sx_Map14 = rMap; sx_X14 = rX; sx_Y14 = rY; }
						else if ( m_Page == 9 ){	btn = 90516; sx_Map16 = rMap; sx_X16 = rX; sx_Y16 = rY; }
					}
					AddButton(115+v, 150, 10461, 10461, btn, GumpButtonType.Reply, 0);
				}

				AddButton(155+v, 210, defButtonID, defButtonID, 2 + (index * 6) + 2, GumpButtonType.Reply, 0);
				AddHtml( 190+v, 210, 151, 20, @"<BODY><BASEFONT Color=" + hue + ">Set As Default</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(160+v, 240, 11156, 248, 2 + (index * 6) + 1, GumpButtonType.Reply, 0);
				AddHtml( 190+v, 240, 151, 20, @"<BODY><BASEFONT Color=" + hue + ">Remove Rune</BASEFONT></BODY>", (bool)false, (bool)false);

				int d = 28;
				int s = 280;

				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Astral Travel</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 602 + (index * 6) + 5, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 165+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + "><RIGHT>Black Gate</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(465+v, s, 4014, 4014, 602 + (index * 6) + 4, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Demonic Fire</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 602 + (index * 6) + 3, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 165+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + "><RIGHT>Elemental Gate</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(465+v, s, 4014, 4014, 902 + (index * 6) + 1, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Elemental Void</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 802 + (index * 6) + 1, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 165+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + "><RIGHT>Ethereal Travel</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(465+v, s, 4014, 4014, 702 + (index * 6) + 1, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Gate</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 2 + (index * 6) + 4, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 165+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + "><RIGHT>Mushroom Gateway</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(465+v, s, 4014, 4014, 602 + (index * 6) + 2, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Nature Passage</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 602 + (index * 6) + 1, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 165+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + "><RIGHT>Recall</RIGHT></BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(465+v, s, 4014, 4014, 2 + (index * 6) + 3, GumpButtonType.Reply, 0);
				s=s+d;
				AddHtml( 159+v, s, 291, 20, @"<BODY><BASEFONT Color=" + fonts + ">Sacred Journey</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(115+v, s, 4005, 4005, 2 + (index * 6) + 5, GumpButtonType.Reply, 0);
			}
		}

		public RunebookGump( Mobile from, Runebook book ) : base( 50, 50 )
		{
			from.SendSound( 0x55 );
			m_Book = book;

			AddBackground( book );
			AddIndex();

			for ( int page = 0; page < 9; ++page )
			{
				AddPage( 2 + page );
				m_Page = 2 + page;
				AddNavigation();

				AddButton(111, 70, 4014, 4014, 0, GumpButtonType.Page, 1 + page);

				if ( page < 8 )
					AddButton(905, 72, 4005, 4005, 0, GumpButtonType.Page, 3 + page);

				if ( page < 8 )
				{
					for ( int half = 0; half < 2; ++half )
						AddDetails( (page * 2) + half, half, from );
				}
				else if ( page > 7 )
				{
					AddInstructions();
				}
			}
		}

		public static bool HasSpell( Mobile from, int spellID )
		{
			Spellbook book = Spellbook.Find( from, spellID );

			return ( book != null && book.HasSpell( spellID ) );
		}

		private class InternalPrompt : Prompt
		{
			private Runebook m_Book;

			public InternalPrompt( Runebook book )
			{
				m_Book = book;
			}

			public override void OnResponse( Mobile from, string text )
			{
				if ( m_Book.Deleted || !from.InRange( m_Book.GetWorldLocation(), (Core.ML ? 3 : 1) ) )
					return;

				if ( m_Book.CheckAccess( from ) )
				{
					m_Book.Description = Utility.FixHtml( text.Trim() );

					from.CloseGump( typeof( RunebookGump ) );
					from.SendGump( new RunebookGump( from, m_Book ) );

					from.SendMessage( "The book's title has been changed." );
				}
				else
				{
					m_Book.Openers.Remove( from );
					
					from.SendLocalizedMessage( 502416 ); // That cannot be done while the book is locked down.
				}
			}

			public override void OnCancel( Mobile from )
			{
				from.SendLocalizedMessage( 502415 ); // Request cancelled.

				if ( !m_Book.Deleted && from.InRange( m_Book.GetWorldLocation(), (Core.ML ? 3 : 1) ) )
				{
					from.CloseGump( typeof( RunebookGump ) );
					from.SendGump( new RunebookGump( from, m_Book ) );
				}
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			from.SendSound( 0x55 );

			if ( m_Book.Deleted || !from.InRange( m_Book.GetWorldLocation(), (Core.ML ? 3 : 1) ) || !Multis.DesignContext.Check( from ) )
			{
				m_Book.Openers.Remove( from );
				return;
			}

			int buttonID = info.ButtonID;

			from.CloseGump( typeof( Sextants.MapGump ) );

			if ( buttonID >= 90500 )
			{
				from.SendGump( new RunebookGump( from, m_Book ) );
				if ( buttonID == 90501 ){ 		from.SendGump( new Sextants.MapGump( from, sx_Map01, sx_X01, sx_Y01, null ) ); }
				else if ( buttonID == 90502 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map02, sx_X02, sx_Y02, null ) ); }
				else if ( buttonID == 90503 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map03, sx_X03, sx_Y03, null ) ); }
				else if ( buttonID == 90504 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map04, sx_X04, sx_Y04, null ) ); }
				else if ( buttonID == 90505 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map05, sx_X05, sx_Y05, null ) ); }
				else if ( buttonID == 90506 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map06, sx_X06, sx_Y06, null ) ); }
				else if ( buttonID == 90507 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map07, sx_X07, sx_Y07, null ) ); }
				else if ( buttonID == 90508 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map08, sx_X08, sx_Y08, null ) ); }
				else if ( buttonID == 90509 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map09, sx_X09, sx_Y09, null ) ); }
				else if ( buttonID == 90510 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map10, sx_X10, sx_Y10, null ) ); }
				else if ( buttonID == 90511 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map11, sx_X11, sx_Y11, null ) ); }
				else if ( buttonID == 90512 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map12, sx_X12, sx_Y12, null ) ); }
				else if ( buttonID == 90513 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map13, sx_X13, sx_Y13, null ) ); }
				else if ( buttonID == 90514 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map14, sx_X14, sx_Y14, null ) ); }
				else if ( buttonID == 90515 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map15, sx_X15, sx_Y15, null ) ); }
				else if ( buttonID == 90516 ){ 	from.SendGump( new Sextants.MapGump( from, sx_Map16, sx_X16, sx_Y16, null ) ); }
			}
			else if ( buttonID == 1 ) // Rename book
			{
				if ( !m_Book.IsLockedDown || from.AccessLevel >= AccessLevel.GameMaster )
				{
					from.SendLocalizedMessage( 502414 ); // Please enter a title for the runebook:
					from.Prompt = new InternalPrompt( m_Book );
				}
				else
				{
					m_Book.Openers.Remove( from );
					
					from.SendLocalizedMessage( 502413, null, 0x35 ); // That cannot be done while the book is locked down.
				}
			}
			else if ( buttonID > 600 && buttonID < 700 )
			{
				buttonID -= 602;

				int index = buttonID / 6;
				int type = buttonID % 6;

				if ( index >= 0 && index < m_Book.Entries.Count )
				{
					RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

					switch ( type )
					{
						case 1: // Nature Passage
						{
							if ( from.Backpack.FindItemByType( typeof ( NaturesPassagePotion ) ) == null )
							{
								from.SendMessage( "You do not have that potion!" );
							}
							else
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new NaturesPassageSpell( from, null, e, null ).Cast();
								from.SendMessage( "You empty a jar in the attempt." );
								from.AddToBackpack( new Jar() );
								(from.Backpack.FindItemByType( typeof ( NaturesPassagePotion ) )).Consume();
							}
							break;
						}
						case 2: // Mushroom Gateway
						{
							if ( from.Backpack.FindItemByType( typeof ( MushroomGatewayPotion ) ) == null )
							{
								from.SendMessage( "You do not have that potion!" );
							}
							else
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new MushroomGatewaySpell( from, null, e ).Cast();
								from.SendMessage( "You empty a jar in the attempt." );
								from.AddToBackpack( new Jar() );
								(from.Backpack.FindItemByType( typeof ( MushroomGatewayPotion ) )).Consume();
							}
							break;
						}
						case 3: // Demonic Fire
						{
							if ( from.Backpack.FindItemByType( typeof ( HellsGateScroll ) ) == null )
							{
								from.SendMessage( "You do not have that potion!" );
							}
							else
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new HellsGateSpell( from, null, e, null ).Cast();
								from.SendMessage( "You empty a jar in the attempt." );
								from.AddToBackpack( new Jar() );
								(from.Backpack.FindItemByType( typeof ( HellsGateScroll ) )).Consume();
							}
							break;
						}
						case 4: // Black Gate
						{
							if ( from.Backpack.FindItemByType( typeof ( GraveyardGatewayScroll ) ) == null )
							{
								from.SendMessage( "You do not have that potion!" );
							}
							else
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new UndeadGraveyardGatewaySpell( from, null, e ).Cast();
								from.SendMessage( "You empty a jar in the attempt." );
								from.AddToBackpack( new Jar() );
								(from.Backpack.FindItemByType( typeof ( GraveyardGatewayScroll ) )).Consume();
							}
							break;
						}
						case 5: // Astral Travel
						{
							if ( HasSpell( from, 251 ) )
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new AstralTravel( from, null, e, null ).Cast();
							}
							else
							{
								from.SendMessage( "You do not have that skill!" );
							}
							
							m_Book.Openers.Remove( from );

							break;
						}
					}
				}
			}
			else if ( buttonID > 700 && buttonID < 800 )
			{
				buttonID -= 702;

				int index = buttonID / 6;
				int type = buttonID % 6;

				if ( index >= 0 && index < m_Book.Entries.Count )
				{
					RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

					switch ( type )
					{
						case 1: // Ethereal Travel
						{
							int xLong = 0, yLat = 0;
							int xMins = 0, yMins = 0;
							bool xEast = false, ySouth = false;

							if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
							{
								string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
								from.SendMessage( location );
							}

							m_Book.OnTravel();
							new ResearchEtherealTravel( from, null, e, null ).Cast();
							
							m_Book.Openers.Remove( from );

							break;
						}
					}
				}
				else
					m_Book.Openers.Remove( from );
			}
			else if ( buttonID > 800 && buttonID < 900 ) // Elemental Void
			{
				buttonID -= 802;

				int index = buttonID / 6;
				int type = buttonID % 6;

				if ( index >= 0 && index < m_Book.Entries.Count )
				{
					RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

					if ( HasSpell( from, 315 ) )
					{
						int xLong = 0, yLat = 0;
						int xMins = 0, yMins = 0;
						bool xEast = false, ySouth = false;

						if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
						{
							string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
							from.SendMessage( location );
						}

						m_Book.OnTravel();
						new Elemental_Void_Spell( from, null, e, null ).Cast();
					}
					else
					{
						from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					}
					
					m_Book.Openers.Remove( from );
				}
				else
					m_Book.Openers.Remove( from );
			}
			else if ( buttonID > 900 && buttonID < 1000 ) // Elemental Gate
			{
				buttonID -= 902;

				int index = buttonID / 6;
				int type = buttonID % 6;

				if ( index >= 0 && index < m_Book.Entries.Count )
				{
					RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

					if ( HasSpell( from, 326 ) )
					{
						int xLong = 0, yLat = 0;
						int xMins = 0, yMins = 0;
						bool xEast = false, ySouth = false;

						if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
						{
							string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
							from.SendMessage( location );
						}

						m_Book.OnTravel();
						new Elemental_Gate_Spell( from, null, e ).Cast();
					}
					else
					{
						from.SendLocalizedMessage( 500015 ); // You do not have that spell!
					}
					
					m_Book.Openers.Remove( from );
				}
				else
					m_Book.Openers.Remove( from );
			}
			else
			{
				buttonID -= 2;

				int index = buttonID / 6;
				int type = buttonID % 6;

				if ( index >= 0 && index < m_Book.Entries.Count )
				{
					RunebookEntry e = (RunebookEntry)m_Book.Entries[index];

					switch ( type )
					{
						case 0: // Use charges
						{
							if ( m_Book.CurCharges <= 0 )
							{
								from.CloseGump( typeof( RunebookGump ) );
								from.SendGump( new RunebookGump( from, m_Book ) );

								from.SendLocalizedMessage( 502412 ); // There are no charges left on that item.
							}
							else
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new TravelSpell( from, m_Book, e, m_Book ).Cast();
								
								m_Book.Openers.Remove( from );
							}

							break;
						}
						case 1: // Drop rune
						{
							if ( !m_Book.IsLockedDown || from.AccessLevel >= AccessLevel.GameMaster )
							{
								m_Book.DropRune( from, e, index );

								from.CloseGump( typeof( RunebookGump ) );
								if ( !Core.ML )
									from.SendGump( new RunebookGump( from, m_Book ) );
							}
							else
							{
								m_Book.Openers.Remove( from );
								
								from.SendLocalizedMessage( 502413, null, 0x35 ); // That cannot be done while the book is locked down.
							}

							break;
						}
						case 2: // Set default
						{
							if ( m_Book.CheckAccess( from ) )
							{
								m_Book.Default = e;

								from.CloseGump( typeof( RunebookGump ) );
								from.SendGump( new RunebookGump( from, m_Book ) );

								from.SendLocalizedMessage( 502417 ); // New default location set.
							}

							break;
						}
						case 3: // Recall
						{
							if ( HasSpell( from, 31 ) )
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new RecallSpell( from, null, e, null ).Cast();
							}
							else
							{
								from.SendLocalizedMessage( 500015 ); // You do not have that spell!
							}
							
							m_Book.Openers.Remove( from );

							break;
						}
						case 4: // Gate
						{
							if ( HasSpell( from, 51 ) )
							{
								int xLong = 0, yLat = 0;
								int xMins = 0, yMins = 0;
								bool xEast = false, ySouth = false;

								if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
								{
									string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
									from.SendMessage( location );
								}

								m_Book.OnTravel();
								new GateTravelSpell( from, null, e ).Cast();
							}
							else
							{
								from.SendLocalizedMessage( 500015 ); // You do not have that spell!
							}
							
							m_Book.Openers.Remove( from );

							break;
						}
						case 5: // Sacred Journey
						{
							if ( Core.AOS )
							{
								if ( HasSpell( from, 209 ) )
								{
									int xLong = 0, yLat = 0;
									int xMins = 0, yMins = 0;
									bool xEast = false, ySouth = false;

									if ( Sextant.Format( e.Location, e.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
									{
										string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
										from.SendMessage( location );
									}

									m_Book.OnTravel();
									new SacredJourneySpell( from, null, e, null ).Cast();
								}
								else
								{
									from.SendLocalizedMessage( 500015 ); // You do not have that spell!
								}
							}
							
							m_Book.Openers.Remove( from );

							break;
						}
					}
				}
				else
					m_Book.Openers.Remove( from );
			}
		}
	}
}