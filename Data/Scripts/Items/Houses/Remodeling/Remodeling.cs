using System;
using System.Collections.Generic;
using System.Text;
using Server.Multis;
using Server.Items;
using Server.Gumps;

namespace Server.Misc
{
    public class Remodeling
    {
        //Dimensions of the lawn can be set here.
        //Set all to 0 if you only want the player to place inside their house.

        // Spaces to left of house allowed for placement.
        public static int Left = 15;
        
        // Spaces to right of house allowed for placement.
        public static int Right = 15;

        // Spaces to front of house allowed for placement.
        public static int Front = 15;

        // Spaces to back of house allowed for placement.
        public static int Back = 15;

        //This variable is used to tell the system how many seconds after 
        //the World.Save the cleanup of any orphaned LawnItems happens.
        //Set it so it runs after the save is complete, so if your saves 
        //take 10 seconds, set it to 15.
        public static int SecondsToCleanup = 30;

		public static int ItemColor( string name, int item )
		{
			int color = 0;

			if ( name == "magma rock ground" ){ color = 0xB71; }
			else if ( name == "lava rock ground" ){ color = 0xB17; }
			else if ( name == "grassy ground" ){ color = 0xB6A; }
			else if ( name == "forest ground" ){ color = 0xB6C; }
			else if ( name == "cavern ground" ){ color = 0xB67; }
			else if ( name == "desert ground" ){ color = 0xB4E; }
			else if ( name == "jungle ground" ){ color = 0xACE; }
			else if ( name == "lunar rock ground" ){ color = 0xB25; }
			else if ( name == "blood rock ground" ){ color = 0xB01; }
			else if ( name == "stone ground" ){ color = 0xB3A; }
			else if ( name == "light stone ground" ){ color = 0xB26; }
			else if ( name == "dark stone ground" ){ color = 0xB38; }
			else if ( name == "muddy ground" ){ color = 0xB69; }
			else if ( name == "dirt ground" ){ color = 0xABF; }
			else if ( name == "light dirt ground" ){ color = 0xABE; }
			else if ( name == "dark dirt ground" ){ color = 0x9BB; }
			else if ( item == 0x224A || item == 0x224B || item == 0xCFE || item == 0xD01 || item == 0x224D ){ color = Utility.RandomList(0xB3A, 0xB25, 0xB26, 0xACE, 0xABF, 0xB70); }
			else if ( item == 9895 || item == 9893 || item == 9897 ){ color = 0x982; }

			return color;
		}

		public static int GroundID( string name )
		{
			int val = 0;

			if ( name == "blood rock ground" ){ 		val = 40000 + 5000; }
			else if ( name == "cavern ground" ){ 		val = 40000 + 10000; }
			else if ( name == "desert ground" ){ 		val = 40000 + 15000; }
			else if ( name == "dirt ground" ){ 			val = 40000 + 20000; }
			else if ( name == "light dirt ground" ){ 	val = 40000 + 25000; }
			else if ( name == "dark dirt ground" ){ 	val = 40000 + 30000; }
			else if ( name == "forest ground" ){ 		val = 40000 + 35000; }
			else if ( name == "grassy ground" ){ 		val = 40000 + 40000; }
			else if ( name == "jungle ground" ){ 		val = 40000 + 45000; }
			else if ( name == "lava rock ground" ){ 	val = 40000 + 50000; }
			else if ( name == "lunar rock ground" ){ 	val = 40000 + 55000; }
			else if ( name == "magma rock ground" ){ 	val = 40000 + 60000; }
			else if ( name == "muddy ground" ){ 		val = 40000 + 65000; }
			else if ( name == "snowy ground" ){ 		val = 40000 + 70000; }
			else if ( name == "stone ground" ){ 		val = 40000 + 75000; }
			else if ( name == "light stone ground" ){ 	val = 40000 + 80000; }
			else if ( name == "dark stone ground" ){ 	val = 40000 + 85000; }

			return val;
		}

		public static int DisplayID( int itemid )
		{
			if ( itemid == 0x373A ){ itemid = 0x3742; }
			else if ( itemid == 0x3039 ){ itemid = 0x303E; }
			else if ( itemid == 0x374A ){ itemid = 0x374E; }
			else if ( itemid == 0x375A ){ itemid = 0x375F; }
			else if ( itemid == 0x376A ){ itemid = 0x376E; }
			else if ( itemid == 0x5469 ){ itemid = 0x546C; }
			else if ( itemid == 0x54E1 ){ itemid = 0x54E6; }
			else if ( itemid == 0x40A3 ){ itemid = Utility.RandomMinMax( 0x40A3, 0x40BB ); }

			return itemid;
		}

		public static void SetID( int itemID, Item item, string title )
		{
			if ( itemID > 40000 ){ item.ItemID = itemID = itemID - Remodeling.GroundID( title ); }

			if ( item.ItemID == 0x5321 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 1301 ){ item.ItemID = Utility.RandomMinMax( 1301, 1304 ); }
			else if ( item.ItemID == 6077 ){ item.ItemID = Utility.RandomMinMax( 6077, 6080 ); }
			else if ( item.ItemID == 25578 ){ item.ItemID = Utility.RandomMinMax( 25578, 25609 ); }
			else if ( item.ItemID == 0x3004 ){ item.ItemID = Utility.RandomMinMax( 0x3004, 0x3007 ); }
			else if ( item.ItemID == 0x40A3 ){ item.ItemID = Utility.RandomMinMax( 0x40A3, 0x40BB ); }
			else if ( item.ItemID == 0x46CC ){ item.ItemID = Utility.RandomMinMax( 0x46CC, 0x46CF ); }
			else if ( item.ItemID == 0x5C16 ){ item.ItemID = Utility.RandomList( 0x5C16, 0x5C17, 0x5D1F, 0x5D29 ); }
			else if ( item.ItemID == 0x22BE ){ item.ItemID = Utility.RandomList( 0x22BE, 0x22BF, 0x22C0, 0x22C2 ); }
			else if ( item.ItemID >= 8990 && item.ItemID <= 8997 ){ item.Light = LightType.Circle150; }
			else if ( item.ItemID >= 3676 && item.ItemID <= 3688 ){ item.Light = LightType.Circle150; }
			else if ( item.ItemID == 12345 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID >= 18491 && item.ItemID <= 18563 ){ item.Light = LightType.Circle150; }
			else if ( item.ItemID == 22357 || item.ItemID == 22363 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 2848 || item.ItemID == 2850 || item.ItemID == 2852 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 9895 || item.ItemID == 9893 || item.ItemID == 9897 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 20313 || item.ItemID == 20312 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 21281 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 21408 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 10749 ){ item.Light = LightType.Circle300; }
			else if ( item.ItemID == 10750 ){ item.ItemID = 10749; item.Light = LightType.Circle300; }
			else if ( item.ItemID == 6921 ){ item.ItemID = Utility.RandomMinMax( 6921, 6928 ); }
			else if ( item.ItemID == 3894 ){ item.ItemID = Utility.RandomList( 3894, 4108, 4109 ); }
			else if ( item.ItemID == 4201 ){ item.ItemID = Utility.RandomList( 4201, 4202, 4203 ); }
			else if ( item.ItemID == 4218 ){ item.ItemID = Utility.RandomList( 4218, 4219, 4220 ); }
			else if ( item.ItemID == 1997 ){ item.ItemID = Utility.RandomList( 1997, 1998, 1999, 2000 ); }
			else if ( item.ItemID == 1993 ){ item.ItemID = Utility.RandomList( 1993, 1994, 1995, 1996 ); }
			else if ( item.ItemID == 2327 ){ item.ItemID = Utility.RandomList( 2327, 2328 ); }
			else if ( item.ItemID == 2325 ){ item.ItemID = Utility.RandomList( 2325, 2326 ); }
			else if ( item.ItemID == 0x2E40 ){ item.ItemID = Utility.RandomList( 0x2E40, 0x32FB, 0x3301, 0x2E41, 0x2E42, 0x2E44, 0x2E45, 0x2E40 ); }
			else if ( item.ItemID == 12813 ){ item.ItemID = Utility.RandomList( 12813, 12814, 12815, 12816, 12817, 12819, 12820, 12821, 12822, 12823, 12824, 12826, 12827, 12828, 12829, 12830 ); }
			else if ( item.ItemID == 13422 ){ item.ItemID = Utility.RandomList( 13422, 13423, 13424, 13425, 13426, 13427, 13428, 13429, 13430, 13431, 13432, 13433, 13434, 13435, 13436, 13437, 13438, 13439, 13440, 13441, 13442, 13443, 13444, 13445 ); }
			else if ( item.ItemID == 4846 ){ item.ItemID = Utility.RandomList( 4846, 4852, 4858, 4864 ); item.Light = LightType.Circle225; }
			else if ( item.ItemID == 4870 ){ item.ItemID = Utility.RandomList( 4870, 4876, 4882, 4888 ); item.Light = LightType.Circle225; }
			else if ( item.ItemID == 1173 ){ item.ItemID = Utility.RandomList( 1173, 1174, 1175, 1176 ); }
			else if ( item.ItemID == 1181 ){ item.ItemID = Utility.RandomList( 1181, 1182, 1183, 1184 ); }
			else if ( item.ItemID == 1305 ){ item.ItemID = Utility.RandomList( 1305, 1306, 1307, 1308 ); }
			else if ( item.ItemID == 1309 ){ item.ItemID = Utility.RandomList( 1309, 1310, 1311, 1312 ); }
			else if ( item.ItemID == 1313 ){ item.ItemID = Utility.RandomList( 1313, 1314, 1315, 1316 ); }
			else if ( item.ItemID == 1306 ){ item.ItemID = Utility.RandomList( 1305, 1306, 1307, 1308, 1309, 1310, 1311, 1312, 1313, 1314, 1315, 1316 ); }
			else if ( item.ItemID == 1191 ){ item.ItemID = Utility.RandomList( 1191, 1192, 1205, 1206, 1207, 1208 ); }
			else if ( item.ItemID == 1189 ){ item.ItemID = Utility.RandomList( 1189, 1190, 1193, 1194, 1195, 1196 ); }
			else if ( item.ItemID == 1305 ){ item.ItemID = Utility.RandomList( 1297, 1298, 1299, 1300 ); }
			else if ( item.ItemID == 1295 ){ item.ItemID = Utility.RandomList( 1295, 1296 ); }
			else if ( item.ItemID == 1222 ){ item.ItemID = Utility.RandomMinMax( 1222, 1229 ); }
			else if ( item.ItemID == 3383 ){ item.ItemID = Utility.RandomMinMax( 3383, 3384 ); }
			else if ( item.ItemID == 1236 ){ item.ItemID = Utility.RandomMinMax( 1236, 1239 ); }
			else if ( item.ItemID == 1250 ){ item.ItemID = Utility.RandomList( 1250, 1252, 1256, 1257 ); }
			else if ( item.ItemID == 1251 ){ item.ItemID = Utility.RandomList( 1251, 1253, 1254, 1255 ); }
			else if ( item.ItemID == 1276 ){ item.ItemID = Utility.RandomList( 1276, 1278 ); }
			else if ( item.ItemID == 1277 ){ item.ItemID = Utility.RandomList( 1277, 1279 ); }
			else if ( item.ItemID == 1280 ){ item.ItemID = Utility.RandomList( 1280, 1282 ); }
			else if ( item.ItemID == 1281 ){ item.ItemID = Utility.RandomList( 1281, 1283 ); }
			else if ( item.ItemID == 1317 ){ item.ItemID = Utility.RandomList( 1317, 1318, 1319, 1320 ); }
			else if ( item.ItemID == 1321 ){ item.ItemID = Utility.RandomList( 1321, 1322, 1323, 1324 ); }
			else if ( item.ItemID == 1327 ){ item.ItemID = Utility.RandomList( 1327, 1328, 1329, 1330 ); }
			else if ( item.ItemID == 1331 ){ item.ItemID = Utility.RandomList( 1331, 1332, 1333, 1334 ); }
			else if ( item.ItemID == 1293 ){ item.ItemID = Utility.RandomList( 1293, 1294 ); }
		}

		public static void EndPut( int m_SelectedID, Mobile m_From, int m_Price, string m_Title, BaseHouse m_House, Point3D loc )
		{
			switch (m_SelectedID)
			{
				//Tall Iron
				case 2084: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2086: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2088: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2090: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2092: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2094: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2096: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2098: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Short Iron
				case 2124: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2126: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2128: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2130: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2132: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2134: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2136: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2138: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Light Wood
				case 2105: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2107: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2109: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2111: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2113: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2115: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2117: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2119: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Dark Wood
				case 2150: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2152: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2154: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2156: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2158: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2160: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2162: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2164: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }

				//Doors

				case 1679: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1677: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1671: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1669: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 8183: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 8181: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 8175: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 8173: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1743: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1741: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1735: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1733: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1663: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1661: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1655: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1653: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1695: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1693: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1687: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1685: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1711: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1709: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1703: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1701: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1727: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1725: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1719: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1717: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1775: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1773: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1767: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1765: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 0x6DF: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 0x6DD: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 0x6D7: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 0x6D5: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				//Ladders & Trapdoors
				case 25667: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 25668: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 705: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 708: { new LawnGate(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				//Other
				case 5952: { new LawnItem(5946, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 6610: { new LawnItem(6604, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 15223: { new LawnItem(15223, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 3807: { new LawnItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 13335: { new LawnItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 3808: { new LawnItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 4595: { new LawnItem(m_SelectedID, m_From, "Hammock", loc, m_Price, m_Title, m_House); break; }
				case 4592: { new LawnItem(m_SelectedID, m_From, "Hammock", loc, m_Price, m_Title, m_House); break; }

				default:
				{
					if (LawnRegistry.LawnStairIDGroups.ContainsKey(m_SelectedID))
					{
						new LawnStair(m_From, m_SelectedID, loc, m_Price, m_Title, m_House);
					}
					else
					{
						new LawnItem(m_SelectedID, m_From, "Lawn", loc, m_Price, m_Title, m_House);
					}
					break;
				}
			}
		}

		public static void EndPlacement( int m_SelectedID, Mobile m_From, int m_Price, string m_Title, BaseHouse m_House, Point3D loc )
		{
			switch (m_SelectedID)
			{
				//Tall Iron
				case 2084: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2086: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2088: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2090: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2092: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2094: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2096: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2098: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Short Iron
				case 2124: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2126: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2128: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2130: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2132: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2134: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2136: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2138: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Light Wood
				case 2105: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2107: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2109: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2111: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2113: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2115: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2117: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2119: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }
				//Dark Wood
				case 2150: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 2152: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 2154: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCCW); break; }
				case 2156: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 2158: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 2160: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCCW); break; }
				case 2162: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCCW); break; }
				case 2164: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.NorthCW); break; }

				//Doors

				case 1679: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1677: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1671: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1669: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 8183: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 8181: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 8175: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 8173: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1743: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1741: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1735: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1733: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1663: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1661: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1655: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1653: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1695: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1693: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1687: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1685: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1711: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1709: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1703: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1701: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1727: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1725: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1719: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1717: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 1775: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 1773: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 1767: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 1765: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				case 0x6DF: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCW); break; }
				case 0x6DD: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.EastCCW); break; }
				case 0x6D7: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.SouthCW); break; }
				case 0x6D5: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }

				//Ladders & Trapdoors
				case 25667: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 25668: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 705: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				case 708: { new ShantyDoor(m_SelectedID, m_From, m_Price, m_Title, m_House, loc, DoorFacing.WestCW); break; }
				//Other
				case 5952: { new ShantyItem(5946, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 6610: { new ShantyItem(6604, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 15223: { new ShantyItem(15223, m_From, "Fountain", loc, m_Price, m_Title, m_House); break; }
				case 3807: { new ShantyItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 13335: { new ShantyItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 3808: { new ShantyItem(m_SelectedID, m_From, "Grave", loc, m_Price, m_Title, m_House); break; }
				case 4595: { new ShantyItem(m_SelectedID, m_From, "Hammock", loc, m_Price, m_Title, m_House); break; }
				case 4592: { new ShantyItem(m_SelectedID, m_From, "Hammock", loc, m_Price, m_Title, m_House); break; }

				default:
				{
					if (ShantyRegistry.ShantyStairIDGroups.ContainsKey(m_SelectedID))
					{
						new ShantyStair(m_From, m_SelectedID, loc, m_Price, m_Title, m_House);
					}
					else
					{
						new ShantyItem(m_SelectedID, m_From, "Shanty", loc, m_Price, m_Title, m_House);
					}
					break;
				}
			}
		}

		public static void ItemLayout( int m_SelectedID, string m_ItemTitle, Gump gump )
		{
			int itemid = m_SelectedID - Remodeling.GroundID( m_ItemTitle );
			itemid = Remodeling.DisplayID( itemid );

			if ( itemid == 9541 )
			{
				gump.AddImage(300, 40, 40014);
				gump.AddHtml( 300, 60, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>This lighthouse will allow public houses, or friends of houses, to dock and launch ships.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 15213 ){ gump.AddImage(300, 60, 40006); }
			else if ( itemid == 5952 ){ gump.AddImage(300, 60, 40008); }
			else if ( itemid == 6610 ){ gump.AddImage(300, 60, 40007); }
			else if ( itemid == 7219 ){ gump.AddImage(300, 60, 40000); }
			else if ( itemid == 7206 ){ gump.AddImage(300, 60, 40001); }
			else if ( itemid == 7251 ){ gump.AddImage(300, 60, 40002); }
			else if ( itemid == 7254 ){ gump.AddImage(300, 60, 40004); }
			else if ( itemid == 7237 ){ gump.AddImage(300, 60, 40003); }
			else if ( itemid == 7240 ){ gump.AddImage(300, 60, 40005); }
			else if ( itemid == 3807 ){ gump.AddImage(300, 60, 40010); }
			else if ( itemid == 13335 ){ gump.AddImage(300, 60, 40009); }
			else if ( itemid == 3808 ){ gump.AddImage(300, 60, 40011); }
			else if ( itemid == 7339 ){ gump.AddImage(300, 60, 40035); }
			else if ( itemid == 7316 ){ gump.AddImage(300, 60, 40033); }
			else if ( itemid == 7325 ){ gump.AddImage(300, 60, 40031); }
			else if ( itemid == 7291 ){ gump.AddImage(300, 60, 40036); }
			else if ( itemid == 7268 ){ gump.AddImage(300, 60, 40034); }
			else if ( itemid == 7277 ){ gump.AddImage(300, 60, 40032); }
			else if ( itemid == 12990 ){ gump.AddImage(300, 60, 40037); }
			else if ( itemid == 12994 ){ gump.AddImage(300, 60, 40038); }
			else if ( itemid == 12992 ){ gump.AddImage(300, 60, 40039); }
			else if ( itemid == 13005 ){ gump.AddImage(300, 60, 40040); }
			else if ( itemid == 8605 ){ gump.AddImage(300, 60, 40041); }
			else if ( itemid == 8604 ){ gump.AddImage(300, 60, 40042); }
			else if ( itemid == 12993 ){ gump.AddImage(300, 60, 40043); }
			else if ( itemid == 13004 ){ gump.AddImage(300, 60, 40044); }
			else if ( itemid == 8600 ){ gump.AddImage(300, 60, 40045); }
			else if ( itemid == 8601 ){ gump.AddImage(300, 60, 40046); }
			else if ( itemid == 4595 ){ gump.AddImage(300, 60, 40012); }
			else if ( itemid == 4592 ){ gump.AddImage(300, 60, 40013); }
			else if ( itemid == 4630 ){ gump.AddImage(300, 60, 40047); }
			else if ( itemid == 4074 ){ gump.AddImage(300, 60, 40016); }
			else if ( itemid == 8602 )
			{
				gump.AddImage(300, 60, 40016);
				gump.AddHtml( 300, 160, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>This pentagram will eventually bring forth a demon that will be trapped within its circle.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 1607 ){ gump.AddImage(300, 60, 40015); }
			else if ( itemid == 8603 )
			{
				gump.AddImage(300, 60, 40015);
				gump.AddHtml( 300, 160, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>This pentagram will eventually bring forth a demon that will be trapped within its circle.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 3395 ){ gump.AddImage(300, 60, 40017); }
			else if ( itemid == 3401 ){ gump.AddImage(300, 60, 40021); }
			else if ( itemid == 3408 ){ gump.AddImage(300, 60, 40022); }
			else if ( itemid == 3417 ){ gump.AddImage(300, 60, 40018); }
			else if ( itemid == 3423 ){ gump.AddImage(300, 60, 40023); }
			else if ( itemid == 3430 ){ gump.AddImage(300, 60, 40024); }
			else if ( itemid == 3440 ){ gump.AddImage(300, 60, 40019); }
			else if ( itemid == 3446 ){ gump.AddImage(300, 60, 40025); }
			else if ( itemid == 3453 ){ gump.AddImage(300, 60, 40026); }
			else if ( itemid == 3461 ){ gump.AddImage(300, 60, 40020); }
			else if ( itemid == 3465 ){ gump.AddImage(300, 60, 40027); }
			else if ( itemid == 3470 ){ gump.AddImage(300, 60, 40028); }
			else if ( itemid == 4793 ){ gump.AddImage(300, 60, 40029); }
			else if ( itemid == 2938 ){ gump.AddImage(300, 60, 40056); }
			else if ( itemid == 2957 ){ gump.AddImage(300, 60, 40057); }
			else if ( itemid == 4802 ){ gump.AddImage(300, 60, 40030); }
			else if ( itemid == 1 ){ gump.AddImage(300, 60, 40048); }
			else if ( itemid == 9358 ){ gump.AddImage(300, 60, 40049); }
			else if ( itemid == 9343 ){ gump.AddImage(300, 60, 40050); }
			else if ( itemid == 8636 ){ gump.AddImage(300, 60, 40054); }
			else if ( itemid == 10555 ){ gump.AddImage(300, 60, 40051); }
			else if ( itemid == 65 && m_ItemTitle != "wall" ){ gump.AddImage(300, 60, 40052); }
			else if ( itemid == 9 && m_ItemTitle != "wall" ){ gump.AddImage(300, 60, 40053); }
			else if ( itemid == 6875 ){ gump.AddImage(300, 60, 40055); }
			else if ( m_ItemTitle == "dark stone ground" )
			{
				gump.AddImage(300, 60, 164, 2871);
				gump.AddItem(340, 100, itemid, Remodeling.ItemColor( m_ItemTitle, itemid ) );
			}
			else { gump.AddItem(300, 60, itemid, Remodeling.ItemColor( m_ItemTitle, itemid ) ); }

			if ( m_ItemTitle == "ladder" )
			{
				gump.AddHtml( 300, 180, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>Once placed, you can double click these ladders and move up to the next level of your home. They can also be secured like doors. They are usually used with trapdoors to get back down.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( m_ItemTitle == "trapdoor" )
			{
				gump.AddHtml( 300, 160, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>Once placed, you can double click these doors and move down to the next level of your home. They can also be secured like doors. They are usually used with ladders to get back up.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( m_ItemTitle == "stairs" || m_ItemTitle == "ramp" )
			{
				gump.AddHtml( 300, 160, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>Once placed, you can double click these items to turn them in the direction you want. Single click them to select the option to sell them back.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( m_ItemTitle == "iron gate" || m_ItemTitle == "wooden gate" || m_ItemTitle == "door" )
			{
				gump.AddHtml( 300, 180, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>Once placed, you can double click these items to open or close them. Single click them to select the option to sell them back or to set the security level to allow friends and co-owners to use them when locked.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( m_ItemTitle == "void" )
			{
				gump.AddHtml( 300, 180, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>WARNING: These tiles cannot be traversed over, meaning they will block your movement when trying to cross them.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 942 || itemid == 20403 || itemid == 20404 )
			{
				gump.AddHtml( 300, 160, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>This item will allow public houses, or friends of houses, to dock and launch ships.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 10750 || itemid == 21408 )
			{
				gump.AddHtml( 300, 170, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>Place this fire in an open space so adventurers can eventually stand 2 tiles away on the north, south, east, and west sides of it. Placing these items near other objects may have the risk of no adventurer visiting the particular fire because there isn't a place for them to stand. Also keep in mind that these items should be level with the ground as not to obstruct a visiting adventurer from stopping by.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 9895 || itemid == 9893 || itemid == 9897 )
			{
				gump.AddHtml( 300, 170, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>These lamps will glow a Ravendark Red when placed on your land, making them appropriate for evil looking cemeteries.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 0x224A || itemid == 0x224B || itemid == 0xCFE || itemid == 0xD01 || itemid == 0x224D )
			{
				gump.AddHtml( 300, 250, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>These trees are from the dark forests of Ravendark, and they will be planted to appear in one of six different shades of evil and death.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else if ( itemid == 3959 || itemid == 3986 || itemid == 3987 || itemid == 3988 )
			{
				gump.AddHtml( 300, 250, 300, 200, @"<BODY><BASEFONT Color=#FBFBFB>These trees are said to house the souls of the most wicked and vile. Planting them will reveal their faces and the eerie looks that gaze upon you.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
		}
    }
}