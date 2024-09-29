using System;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
	[Flipable(0x577B, 0x577C)]
    public class AdminBoard : Item
    {
        [Constructable]
        public AdminBoard() : base( 0x577B )
        {
            Name = "News From The Nobles";
			Hue = 0x981;
        }

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 6 ) )
			{
				e.CloseGump( typeof( AdminBoardGump ) );
				e.SendGump( new AdminBoardGump( e ) );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public class AdminBoardGump : Gump
		{
			public AdminBoardGump( Mobile from ): base( 100, 100 )
			{
				from.SendSound( 0x59 );

				int face = GetBoardAvatar( from, from.Map, from.Location, from.X, from.Y );
				string title = GetBoardName( face );
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9541, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(609, 8, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddImage(8, 8, 1127);
				AddImage(8, 8, face);
				AddHtml( 130, 13, 424, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 43, 424, 20, @"<BODY><BASEFONT Color=" + color + ">Recent Messages from Throughout the Land</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 73, 424, 20, @"<BODY><BASEFONT Color=" + color + ">Select an Article Below to Read</BASEFONT></BODY>", (bool)false, (bool)false);

				int i = 115;

				string message10 = Server.Misc.LoggingFunctions.LogArticles( 10, 1 );
				if ( message10 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 10, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message10 + " - " + Server.Misc.LoggingFunctions.LogArticles( 10, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message9 = Server.Misc.LoggingFunctions.LogArticles( 9, 1 );
				if ( message9 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 9, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message9 + " - " + Server.Misc.LoggingFunctions.LogArticles( 9, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message8 = Server.Misc.LoggingFunctions.LogArticles( 8, 1 );
				if ( message8 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 8, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message8 + " - " + Server.Misc.LoggingFunctions.LogArticles( 8, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message7 = Server.Misc.LoggingFunctions.LogArticles( 7, 1 );
				if ( message7 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 7, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message7 + " - " + Server.Misc.LoggingFunctions.LogArticles( 7, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message6 = Server.Misc.LoggingFunctions.LogArticles( 6, 1 );
				if ( message6 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 6, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message6 + " - " + Server.Misc.LoggingFunctions.LogArticles( 6, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message5 = Server.Misc.LoggingFunctions.LogArticles( 5, 1 );
				if ( message5 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 5, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message5 + " - " + Server.Misc.LoggingFunctions.LogArticles( 5, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message4 = Server.Misc.LoggingFunctions.LogArticles( 4, 1 );
				if ( message4 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 4, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message4 + " - " + Server.Misc.LoggingFunctions.LogArticles( 4, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message3 = Server.Misc.LoggingFunctions.LogArticles( 3, 1 );
				if ( message3 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 3, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message3 + " - " + Server.Misc.LoggingFunctions.LogArticles( 3, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message2 = Server.Misc.LoggingFunctions.LogArticles( 2, 1 );
				if ( message2 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 2, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message2 + " - " + Server.Misc.LoggingFunctions.LogArticles( 2, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				string message1 = Server.Misc.LoggingFunctions.LogArticles( 1, 1 );
				if ( message1 != "" )
				{
					i = i+28;
					AddButton(10, i, 4005, 4005, 1, GumpButtonType.Reply, 0);
					AddHtml( 50, i, 581, 20, @"<BODY><BASEFONT Color=" + color + ">" + message1 + " - " + Server.Misc.LoggingFunctions.LogArticles( 1, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile; 

				from.SendSound( 0x59 );

				if ( info.ButtonID > 0 )
				{
					from.SendGump( new BoardMessage( from, info.ButtonID ) );
				}
			}
		}

		public class BoardMessage : Gump
		{
			public BoardMessage( Mobile from, int message ): base( 100, 100 )
			{
				from.SendSound( 0x59 );

				int face = GetBoardAvatar( from, from.Map, from.Location, from.X, from.Y );
				string title = GetBoardName( face );
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9541, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(609, 8, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddImage(8, 8, 1127);
				AddImage(8, 8, face);
				AddHtml( 130, 13, 424, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 43, 424, 20, @"<BODY><BASEFONT Color=" + color + ">" + Server.Misc.LoggingFunctions.LogArticles( message, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 130, 73, 424, 20, @"<BODY><BASEFONT Color=" + color + ">" + Server.Misc.LoggingFunctions.LogArticles( message, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 11, 144, 625, 278, @"<BODY><BASEFONT Color=" + color + ">" + Server.Misc.LoggingFunctions.LogArticles( message, 3 ) + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile; 
				from.SendSound( 0x59 );
				from.SendGump( new AdminBoardGump( from ) );
			}
		}

		public static int GetBoardAvatar( Mobile m, Map map, Point3D location, int x, int y )
		{
			int face = 0x478;

			int mX = 0;
			int mY = 0;
			int mZ = 0;
			Map mWorld = null;

			string sPublicDoor = ((PlayerMobile)m).CharacterPublicDoor;
			if ( sPublicDoor != null )
			{
				if ( sPublicDoor.Length > 0 )
				{
					string[] sPublicDoors = sPublicDoor.Split('#');
					int nEntry = 1;
					foreach (string exits in sPublicDoors)
					{
						if ( nEntry == 1 ){ mX = Convert.ToInt32(exits); }
						else if ( nEntry == 2 ){ mY = Convert.ToInt32(exits); }
						else if ( nEntry == 3 ){ mZ = Convert.ToInt32(exits); }
						else if ( nEntry == 4 ){ try { mWorld = Map.Parse( exits ); } catch{} if ( mWorld == null ){ mWorld = Map.Sosaria; } }
						nEntry++;
					}

					location = new Point3D( mX, mY, mZ );
					map = mWorld;
					x = mX;
					y = mY;
				}
			}

			Land land = Server.Lands.GetLand( map, location, x, y );

			if ( land == Land.Kuldar ){ face = 0x479; }
			else if ( land == Land.Lodoria ){ face = 0x4DC; }
			else if ( land == Land.Serpent ){ face = 0x46A; }
			else if ( land == Land.IslesDread ){ face = 0x469; }
			else if ( land == Land.Savaged ){ face = 0x468; }
			else if ( land == Land.UmberVeil ){ face = 0x4DD; }
			else if ( land == Land.Luna ){ face = 0x47A; }
			else if ( land == Land.Underworld ){ face = 0x4DE; }

			return face;
		}

		public static string GetBoardName( int face )
		{
			string name = "Lord British";

			if ( face == 0x479 ){ name = "Lord Blackthorn"; }
			else if ( face == 0x4DC ){ name = "Arandur the Elven Prince"; }
			else if ( face == 0x46A ){ name = "Lord Draxinusom"; }
			else if ( face == 0x469 ){ name = "Gorn the Barbarian"; }
			else if ( face == 0x468 ){ name = "Vorgarag the Ork Lord"; }
			else if ( face == 0x4DD ){ name = "Dupre the Paladin"; }
			else if ( face == 0x47A ){ name = "Kalana the Oracle"; }
			else if ( face == 0x4DE ){ name = "Xavier the Theurgist"; }

			return name;
		}

        public AdminBoard( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
    }
}