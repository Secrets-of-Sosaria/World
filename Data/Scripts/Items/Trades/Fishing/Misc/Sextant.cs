using System;
using Server;
using Server.Network;
using Server.Misc;
using Server.Regions;
using Server.Mobiles;
using Server.Gumps;
using System.Collections.Generic;
using System.Collections;

namespace Server.Items
{
    class Sextants
    {
		public static bool HasSextant( Mobile m )
		{
			bool sxtnt = false;

			if ( m != null && m.Backpack != null )
			{
				List<Item> list = new List<Item>();
				(m.Backpack).RecurseItems( list );
				foreach ( Item i in list )
				{
					if ( i is Sextant || i is MagicSextant )
						sxtnt = true;
				}
			}

			return sxtnt;
		}

		public class MapGump : Gump
		{
			public MapGump( Mobile from, Map map, int x, int y, Item parchment ): base( 100, 100 )
			{
				if ( HasSextant( from ) || parchment is MapWorld || parchment is PlaceMap )
				{
					from.CloseGump( typeof( MapGump ) );
					Point3D loc = new Point3D( x, y, 0 );
					Land land = Lands.GetLand( map, loc, x, y );
					if ( parchment is MapWorld )
						land = ((MapWorld)parchment).WorldMap;

					from.PlaySound( 0x249 );
					Closable=true;
					Disposable=true;
					Dragable=true;
					Resizable=false;

					int modX = 0;
					int modY = 0;

					AddPage(0);

					if ( Sextants.HasSextant( from ) )
						this.AddButton(377, 325, 10461, 10461, 666, GumpButtonType.Reply, 0);

					if ( land == Land.Lodoria )
					{
						modX = 43;
						modY = 39;

						AddImage(0, 0, 10430);
						AddImage(479, 0, 10431);
						AddImage(0, 378, 10432);
						AddImage(479, 378, 10440);
						AddImage(147, 2, 10450);
						AddImage(269, 2, 10450);
						AddImage(537, 176, 10460);
						AddImage(1, 187, 10452);
						AddImage(193, 414, 10451);
						AddImage(43, 39, 10410);
						AddImage(551, 442, 2529);
					}
					else if ( land == Land.Ambrosia )
					{
						modX = 29;
						modY = 31;

						AddImage(38, 1, 10450);
						AddImage(16, 356, 10451);
						AddImage(0, 0, 10430);
						AddImage(306, 0, 10431);
						AddImage(-3, 322, 10432);
						AddImage(303, 316, 10440);
						AddImage(365, 188, 10460);
						AddImage(1, 199, 10452);
						AddImage(29, 31, 10400);
						AddImage(383, 74, 2529);
					}
					else if ( land == Land.IslesDread )
					{
						modX = 50;
						modY = 49;

						AddImage(60, 3, 10450);
						AddImage(49, 380, 10451);
						AddImage(0, 0, 10430);
						AddImage(345, 4, 10431);
						AddImage(1, 346, 10432);
						AddImage(342, 342, 10440);
						AddImage(404, 194, 10460);
						AddImage(1, 154, 10452);
						AddImage(50, 49, 10401);
						AddImage(86, 413, 2529);
					}
					else if ( land == Land.Kuldar )
					{
						modX = 54;
						modY = 36;

						AddImage(60, 3, 10450);
						AddImage(49, 380, 10451);
						AddImage(0, 0, 10430);
						AddImage(191, 0, 10431);
						AddImage(1, 346, 10432);
						AddImage(192, 344, 10440);
						AddImage(250, 182, 10460);
						AddImage(1, 154, 10452);
						AddImage(54, 36, 10402);
						AddImage(83, 70, 2529);
					}
					else if ( land == Land.Sosaria )
					{
						modX = 40;
						modY = 40;

						AddImage(0, 0, 10430);
						AddImage(479, 0, 10431);
						AddImage(1, 278, 10432);
						AddImage(479, 275, 10440);
						AddImage(147, 2, 10450);
						AddImage(269, 2, 10450);
						AddImage(537, 176, 10460);
						AddImage(1, 187, 10452);
						AddImage(187, 315, 10451);
						AddImage(40, 40, 10420);
						AddImage(550, 80, 2529);
					}
					else if ( land == Land.Savaged )
					{
						modX = 38;
						modY = 36;

						AddImage(38, 1, 10450);
						AddImage(16, 356, 10451);
						AddImage(0, 0, 10430);
						AddImage(172, 3, 10431);
						AddImage(-3, 322, 10432);
						AddImage(169, 322, 10440);
						AddImage(231, 179, 10460);
						AddImage(1, 199, 10452);
						AddImage(38, 36, 10411);
						AddImage(290, 43, 2529);
					}
					else if ( land == Land.Serpent )
					{
						modX = 38;
						modY = 36;

						AddImage(99, 406, 10451);
						AddImage(0, 0, 10430);
						AddImage(337, 1, 10431);
						AddImage(2, 370, 10432);
						AddImage(333, 368, 10440);
						AddImage(126, 1, 10450);
						AddImage(395, 177, 10460);
						AddImage(1, 199, 10452);
						AddImage(38, 36, 10412);
						AddImage(72, 68, 2529);
					}
					else if ( land == Land.UmberVeil )
					{
						modX = 29;
						modY = 31;

						AddImage(144, 0, 10450);
						AddImage(164, 275, 10451);
						AddImage(0, 0, 10430);
						AddImage(411, -1, 10431);
						AddImage(4, 239, 10432);
						AddImage(408, 237, 10440);
						AddImage(470, 95, 10460);
						AddImage(2, 137, 10452);
						AddImage(29, 31, 10421);
						AddImage(72, 308, 2529);
					}
					else if ( land == Land.Underworld )
					{
						modX = 47;
						modY = 36;

						AddImage(96, 316, 10451);
						AddImage(0, 0, 10430);
						AddImage(303, 3, 10431);
						AddImage(1, 278, 10432);
						AddImage(299, 280, 10440);
						AddImage(126, 1, 10450);
						AddImage(362, 148, 10460);
						AddImage(1, 187, 10452);
						AddImage(47, 36, 10422);
						AddImage(389, 368, 2529);
					}

					modX += 40;
					modY += 40;

					int px = PinDrop( land, from, x, y, modX, modY, true );
					int py = PinDrop( land, from, x, y, modX, modY, false ) - 8;

					if ( !(parchment is MapWorld) )
					{
						AddImage( px, py, 2530 ); // PIN
						AddHtml( px+10, py-10, 92, 21, @"<BODY><BASEFONT Color=#FFFC00>" + x + ", " + y + "</BASEFONT></BODY>", (bool)false, (bool)false);
					}

					if ( Worlds.IsPlayerInTheLand( from.Map, from.Location, from.X, from.Y ) && from.Land == land )
					{
						int ix = PinDrop( land, from, from.X, from.Y, modX, modY, true ) - 8;
						int iy = PinDrop( land, from, from.X, from.Y, modX, modY, false ) - 9;

						AddImage(ix, iy, 10462); // PLAYER LOCATION
					}
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.PlaySound( 0x249 );
			}

			public static int PinDrop( Land land, Mobile m, int x, int y, int mx, int my, bool dir )
			{
				if ( land == Land.Lodoria || land == Land.Sosaria )
				{
					x = (int)( x * 0.1 ) + mx;
					y = (int)( y * 0.1 ) + my;
				}
				else if ( land == Land.Serpent || land == Land.Underworld )
				{
					x = (int)( x * 0.2 ) + mx;
					y = (int)( y * 0.2 ) + my;
				}
				else if ( land == Land.IslesDread )
				{
					x = (int)( x * 0.25 ) + mx;
					y = (int)( y * 0.25 ) + my;
				}
				else if ( land == Land.Savaged )
				{
					x = (int)( ( x - 136 ) * 0.2 ) + mx;
					y = (int)( ( y - 8 ) * 0.2 ) + my;
				}
				else if ( land == Land.Ambrosia )
				{
					x = (int)( ( x - 5122 ) * 0.35 ) + mx;
					y = (int)( ( y - 3036 ) * 0.35 ) + my;
				}
				else if ( land == Land.Kuldar )
				{
					x = (int)( ( x - 6127 ) * 0.2 ) + mx;
					y = (int)( ( y - 828 ) * 0.2 ) + my;
				}
				else if ( land == Land.UmberVeil )
				{
					x = (int)( ( x - 699 ) * 0.3 ) + mx;
					y = (int)( ( y - 3129 ) * 0.3 ) + my;
				}

				if ( dir )
					return x;

				return y;
			}
		}
	}

	public class Sextant : Item
	{
		public override string DefaultDescription{ get{ return "Sextants are used to gaze at the stars and determine your location. If you are carrying a sextant, and you examine items like a treasure map or a parchment with sextant coordinates on it, you may be able to open a world map to see the location. These maps will have a red pin for the location. If you are traveling in that world, you will see a blue pin to where you are."; } }

		[Constructable]
		public Sextant() : base( 0x1058 )
		{
			Weight = 2.0;
			Name = "sextant";
		}

		public Sextant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			int xLong = 0, yLat = 0;
			int xMins = 0, yMins = 0;
			bool xEast = false, ySouth = false;

			if ( from.Land == Land.Underworld && !(this is MagicSextant) ){ from.SendMessage( "You will need a magical sextant to see the stars through the cavern ceiling!" ); } 
			else if ( Sextant.Format( from.Location, from.Map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
			{
				string location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
				from.LocalOverheadMessage( MessageType.Regular, from.SpeechHue, false, location );
			}
			else if ( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) == "Ravendark Woods" ) { from.SendMessage( "You can't use a sextant as the sun and stars are blocked by the evil darkness here!" ); }
			else if ( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) == "the Village of Ravendark" ) { from.SendMessage( "You can't use a sextant as the sun and stars are blocked by the evil darkness here!" ); }
			else if ( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) == "the Ranger Outpost" ) { from.SendMessage( "You can't use a sextant as the mountain clouds block the sky!" ); } 
			else if ( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) == "the Valley of Dark Druids" ) { from.SendMessage( "The druids mask this valley with thick clouds!" ); } 
			else { from.SendMessage( "The sextant does not seem to work here!" ); } 
		}

		public static bool ComputeMapDetails( Map map, int x, int y, out int xCenter, out int yCenter, out int xWidth, out int yHeight )
		{
			xWidth = 0;
			yHeight = 0;

			int startX = -1;
			int startY = -1;

			Point3D location = new Point3D( x, y, 0 );
			Land land = Server.Lands.GetLand( map, location, x, y );

			if ( land == Land.Luna && x >= 5801 && y >= 2716 && x <= 6125 && y <= 3034 )
			{
				xWidth = 324; yHeight = 411; startX = 5801; startY = 2716;
			}
			if ( land == Land.Sosaria && x >= 0 && y >= 0 && x <= 5120 && y <= 3127 )
			{
				xWidth = 5120; yHeight = 3127; startX = 0; startY = 0;
			}
			else if ( land == Land.Lodoria && x >= 0 && y >= 0 && x <= 5120 && y <= 4095 )
			{
				xWidth = 5120; yHeight = 4095; startX = 0; startY = 0;
			}
			else if ( land == Land.Serpent && x >= 0 && y >= 0 && x <= 1870 && y <= 2047 )
			{
				xWidth = 1870; yHeight = 2047; startX = 0; startY = 0;
			}
			else if ( land == Land.IslesDread && x >= 0 && y >= 0 && x <= 1447 && y <= 1447 )
			{
				xWidth = 1447; yHeight = 1447; startX = 0; startY = 0;
			}
			else if ( land == Land.Savaged && x >= 136 && y >= 8 && x <= 1160 && y <= 1792 )
			{
				xWidth = 1024; yHeight = 1784; startX = 136; startY = 8;
			}
			else if ( land == Land.Ambrosia && x >= 5122 && y >= 3036 && x <= 6126 && y <= 4095 )
			{
				xWidth = 1004; yHeight = 1059; startX = 5122; startY = 3036;
			}
			else if ( land == Land.UmberVeil && x >= 699 && y >= 3129 && x <= 2272 && y <= 4095 )
			{
				xWidth = 1573; yHeight = 966; startX = 699; startY = 3129;
			}
			else if ( land == Land.Kuldar && x >= 6127 && y >= 828 && x <= 7168 && y <= 2743 )
			{
				xWidth = 1041; yHeight = 1915; startX = 6127; startY = 828;
			}
			else if ( land == Land.Underworld && x >= 0 && y >= 0 && x <= 1581 && y <= 1599 )
			{
				xWidth = 1581; yHeight = 1599; startX = 0; startY = 0;
			}

			if ( startX > -1 )
			{
				xCenter = (int)(startX+(xWidth/2));
				yCenter = (int)(startY+(yHeight/2));
			}
			else
			{
				xCenter = 0; yCenter = 0;
				return false;
			}

			return true;
		}

		public static Point3D ReverseLookup( Map map, int xLong, int yLat, int xMins, int yMins, bool xEast, bool ySouth )
		{
			if ( map == null || map == Map.Internal )
				return Point3D.Zero;

			int xCenter, yCenter;
			int xWidth, yHeight;

			if ( !ComputeMapDetails( map, 0, 0, out xCenter, out yCenter, out xWidth, out yHeight ) )
				return Point3D.Zero;

			double absLong = xLong + ((double)xMins / 60);
			double absLat  = yLat  + ((double)yMins / 60);

			if ( !xEast )
				absLong = 360.0 - absLong;

			if ( !ySouth )
				absLat = 360.0 - absLat;

			int x, y, z;

			x = xCenter + (int)((absLong * xWidth) / 360);
			y = yCenter + (int)((absLat * yHeight) / 360);

			if ( x < 0 )
				x += xWidth;
			else if ( x >= xWidth )
				x -= xWidth;

			if ( y < 0 )
				y += yHeight;
			else if ( y >= yHeight )
				y -= yHeight;

			z = map.GetAverageZ( x, y );

			return new Point3D( x, y, z );
		}

		public static bool Format( Point3D p, Map map, ref int xLong, ref int yLat, ref int xMins, ref int yMins, ref bool xEast, ref bool ySouth )
		{
			if ( map == null || map == Map.Internal )
				return false;

			int x = p.X, y = p.Y;
			int xCenter, yCenter;
			int xWidth, yHeight;

			if ( !ComputeMapDetails( map, x, y, out xCenter, out yCenter, out xWidth, out yHeight ) )
				return false;

			double absLong = (double)((x - xCenter) * 360) / xWidth;
			double absLat  = (double)((y - yCenter) * 360) / yHeight;

			if ( absLong > 180.0 )
				absLong = -180.0 + (absLong % 180.0);

			if ( absLat > 180.0 )
				absLat = -180.0 + (absLat % 180.0);

			bool east = ( absLong >= 0 ), south = ( absLat >= 0 );

			if ( absLong < 0.0 )
				absLong = -absLong;

			if ( absLat < 0.0 )
				absLat = -absLat;

			xLong = (int)absLong;
			yLat  = (int)absLat;

			xMins = (int)((absLong % 1.0) * 60);
			yMins = (int)((absLat  % 1.0) * 60);

			xEast = east;
			ySouth = south;

			return true;
		}
	}
}