using System.Collections.Generic;
using Server.Gumps;
using Server.Items;
using Server.Misc;

namespace Server.Misc
{
    public class LawnGumpEntry
    {
        private int m_ItemID;
        public int ItemID
        {
            get { return m_ItemID; }
            set { m_ItemID = value; }
        }

        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private int m_Price;
        public int Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }

        private string m_Title;
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public LawnGumpEntry(int itemID, string name, int price, string title)
        {
            ItemID = itemID;
            Price = price;
            Name = name;
			Title = title;
        }

        public void AppendToGump(Gump g, int x, int y, int i)
        {
			int button = 2447; if ( i == ItemID ){ button = 2449; }
			int color = 1477; if ( i == ItemID ){ color = 1671; }
			y = y+7;
			x = x+20;
            g.AddLabel(x, y, color, Name);
            g.AddButton(x - 18, y + 5, button, button, ItemID, GumpButtonType.Reply, 0);
        }
    }

    public class LawnGumpCategory
    {
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private List<Dictionary<int, LawnGumpEntry>> m_Pages;
        public List<Dictionary<int, LawnGumpEntry>> Pages
        {
            get
            {
                if (m_Pages == null)
                {
                    m_Pages = new List<Dictionary<int, LawnGumpEntry>>();
                }
                return m_Pages;
            }
            set { m_Pages = value; }
        }

        public LawnGumpCategory(string name)
        {
            Name = name;
            Pages = new List<Dictionary<int, LawnGumpEntry>>();
        }

        public void AddEntry(LawnGumpEntry entry)
        {
            if (Pages.Count == 0)
            {
                Pages.Add(new Dictionary<int, LawnGumpEntry>());
                Pages[0].Add(entry.ItemID, entry);
            }
            else
            {
                if (Pages[Pages.Count - 1].Count >= 12)
                {
                    Pages.Add(new Dictionary<int, LawnGumpEntry>());
                }

                Pages[Pages.Count - 1].Add(entry.ItemID, entry);
            }
        }

        public LawnGumpEntry GetEntry(int itemID)
        {
            if (Pages.Count == 0)
            {
                return null;
            }

            foreach (Dictionary<int, LawnGumpEntry> item in Pages)
            {
                if (item.ContainsKey(itemID) && item[itemID] != null)
                {
                    return item[itemID];
                }
            }

            return null;
        }
    }

    class LawnRegistry
    {
        public static Dictionary<int, List<LawnMultiInfo>> LawnMultiIDs;

        /* This dictionary keeps track of the directions for each primary stair ID
         * When a LawnStair is double clicked, it changes the ItemID to the next in the list
         * which changes the direction of the stair.
         */
        public static Dictionary<int, int[]> LawnStairIDGroups;

        public static Dictionary<string, LawnGumpCategory> Categories = new Dictionary<string, LawnGumpCategory>();

        public static void RegisterCategory(string category)
        {
            if (Categories == null)
            {
                Categories = new Dictionary<string, LawnGumpCategory>();
            }

            if (Categories.ContainsKey(category))
            {
                return;
            }

            Categories.Add(category, new LawnGumpCategory(category));
        }

        public static LawnGumpCategory GetRegisteredCategory(string category)
        {
            if (!Categories.ContainsKey(category))
            {
                RegisterCategory(category);
            }

            return Categories[category];
        }

        public static void RegisterEntry(string categoryName, int itemID, string name, string title, int price)
        {
            LawnGumpCategory category = GetRegisteredCategory(categoryName);
            if (category == null)
            {
                return;
            }

            LawnGumpEntry entry = new LawnGumpEntry(itemID, name, price, title);

            category.AddEntry(entry);
        }

        public static void Configure()
        {
            RegisterItems();
            RegisterMultis();
            RegisterStairs();
        }

        public static void RegisterItems()
        {
            //Each category will hold 12 entries per page in order of their registration.

			RegisterEntry("Cemetery", 3087, "Barrel Bones", "barrel of bones", 200);
			RegisterEntry("Cemetery", 15213, "Blood Fountain", "blood fountain", 500);
			RegisterEntry("Cemetery", 6921, "Bones", "bones", 50);
			RegisterEntry("Cemetery", 7219, "Casket East", "casket", 250);
			RegisterEntry("Cemetery", 7206, "Casket South", "casket", 250);
			RegisterEntry("Cemetery", 7251, "Coffin East", "coffin", 200);
			RegisterEntry("Cemetery", 7254, "Coffin East Open", "coffin", 200);
			RegisterEntry("Cemetery", 7237, "Coffin South", "coffin", 200);
			RegisterEntry("Cemetery", 7240, "Coffin South Open", "coffin", 200);
			RegisterEntry("Cemetery", 22357, "Ghost East", "ghost", 300);
			RegisterEntry("Cemetery", 22363, "Ghost South", "ghost", 300);
			RegisterEntry("Cemetery", 3807, "Grave Dirt East", "grave", 100);
			RegisterEntry("Cemetery", 13335, "Grave Dirt Restless", "grave", 150);
			RegisterEntry("Cemetery", 3808, "Grave Dirt South", "grave", 100);
			RegisterEntry("Cemetery", 9895, "Lamp Post 1", "lamp post", 300);
			RegisterEntry("Cemetery", 9893, "Lamp Post 2", "lamp post", 300);
			RegisterEntry("Cemetery", 9897, "Lamp Post 3", "lamp post", 300);
			RegisterEntry("Cemetery", 6875, "Pile of Skulls", "skull pile", 500);
			RegisterEntry("Cemetery", 7339, "Sarcophagus East Man", "sarcophagus", 250);
			RegisterEntry("Cemetery", 7316, "Sarcophagus East Woman", "sarcophagus", 250);
			RegisterEntry("Cemetery", 7325, "Sarcophagus East Open", "sarcophagus", 250);
			RegisterEntry("Cemetery", 7291, "Sarcophagus South Man", "sarcophagus", 250);
			RegisterEntry("Cemetery", 7268, "Sarcophagus South Woman", "sarcophagus", 250);
			RegisterEntry("Cemetery", 7277, "Sarcophagus South Open", "sarcophagus", 250);
			RegisterEntry("Cemetery", 18076, "Scarecrow East", "scarecrow", 250);
			RegisterEntry("Cemetery", 18075, "Scarecrow South", "scarecrow", 250);
			RegisterEntry("Cemetery", 4671, "Skeleton 1 East", "skeleton", 100);
			RegisterEntry("Cemetery", 4662, "Skeleton 1 South", "skeleton", 100);
			RegisterEntry("Cemetery", 6657, "Skeleton 2 East", "skeleton", 100);
			RegisterEntry("Cemetery", 6658, "Skeleton 2 South", "skeleton", 100);
			RegisterEntry("Cemetery", 6659, "Skeleton 3 East", "skeleton", 100);
			RegisterEntry("Cemetery", 6660, "Skeleton 3 South", "skeleton", 100);
			RegisterEntry("Cemetery", 12990, "Tomb East", "tomb", 250);
			RegisterEntry("Cemetery", 12994, "Tomb South", "tomb", 250);
			RegisterEntry("Cemetery", 12992, "Tomb Scorpion East", "tomb", 250);
			RegisterEntry("Cemetery", 13005, "Tomb Scorpion South", "tomb", 250);
			RegisterEntry("Cemetery", 8605, "Tomb Deco 1 East", "tomb", 250);
			RegisterEntry("Cemetery", 8604, "Tomb Deco 1 South", "tomb", 250);
			RegisterEntry("Cemetery", 12993, "Tomb Deco 2 East", "tomb", 250);
			RegisterEntry("Cemetery", 13004, "Tomb Deco 2 South", "tomb", 250);
			RegisterEntry("Cemetery", 8600, "Tomb Deco 3 East", "tomb", 250);
			RegisterEntry("Cemetery", 8601, "Tomb Deco 3 South", "tomb", 250);
			RegisterEntry("Cemetery", 3797, "Tombstone 1 East", "tombstone", 50);
			RegisterEntry("Cemetery", 3796, "Tombstone 1 South", "tombstone", 50);
			RegisterEntry("Cemetery", 3799, "Tombstone 2 East", "tombstone", 50);
			RegisterEntry("Cemetery", 3806, "Tombstone 3 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4453, "Tombstone 4 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4454, "Tombstone 4 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4455, "Tombstone 5 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4456, "Tombstone 5 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4457, "Tombstone 6 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4458, "Tombstone 6 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4459, "Tombstone 7 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4460, "Tombstone 7 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4461, "Tombstone 8 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4462, "Tombstone 8 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4463, "Tombstone 9 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4464, "Tombstone 9 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4465, "Tombstone 10 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4466, "Tombstone 10 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4467, "Tombstone 11 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4468, "Tombstone 11 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4469, "Tombstone 12 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4470, "Tombstone 12 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4471, "Tombstone 13 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4472, "Tombstone 13 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4473, "Tombstone 14 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4474, "Tombstone 14 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4475, "Tombstone 15 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4476, "Tombstone 15 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4479, "Tombstone 16 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4480, "Tombstone 16 South", "tombstone", 50);
			RegisterEntry("Cemetery", 4481, "Tombstone 17 East", "tombstone", 50);
			RegisterEntry("Cemetery", 4482, "Tombstone 17 South", "tombstone", 50);
			RegisterEntry("Cemetery", 0x224A, "Tree 1", "tree", 200);
			RegisterEntry("Cemetery", 0x224B, "Tree 2", "tree", 200);
			RegisterEntry("Cemetery", 0xCFE, "Tree 3", "tree", 200);
			RegisterEntry("Cemetery", 0xD01, "Tree 4", "tree", 200);
			RegisterEntry("Cemetery", 0x224D, "Tree 5", "tree", 200);
			RegisterEntry("Cemetery", 3959, "Tree Spooky 1", "spooky tree", 500);
			RegisterEntry("Cemetery", 3986, "Tree Spooky 2", "spooky tree", 500);
			RegisterEntry("Cemetery", 3987, "Tree Spooky 3", "spooky tree", 500);
			RegisterEntry("Cemetery", 3988, "Tree Spooky 4", "spooky tree", 500);
			RegisterEntry("Cemetery", 0xEE3, "Web 1", "web", 50);
			RegisterEntry("Cemetery", 0xEE4, "Web 2", "web", 50);
			RegisterEntry("Cemetery", 0xEE5, "Web 3", "web", 50);
			RegisterEntry("Cemetery", 0xEE6, "Web 3", "web", 50);

			RegisterEntry("Construction", 8885, "Bridge Board Dark East", "bridge", 100);
			RegisterEntry("Construction", 8886, "Bridge Board Dark South", "bridge", 100);
			RegisterEntry("Construction", 8883, "Bridge Board Light East", "bridge", 100);
			RegisterEntry("Construction", 8884, "Bridge Board Light South", "bridge", 100);
			RegisterEntry("Construction", 749, "Bridge Log East", "bridge", 100);
			RegisterEntry("Construction", 750, "Bridge Log South", "bridge", 100);
			RegisterEntry("Construction", 942, "Dock", "dock", 100);
			RegisterEntry("Construction", 1993, "Dock Planks 1", "dock", 50);
			RegisterEntry("Construction", 1997, "Dock Planks 2", "dock", 50);
			RegisterEntry("Construction", 933, "Dock Post", "dock", 50);
			RegisterEntry("Construction", 938, "Dock Post Roped", "dock", 50);
			RegisterEntry("Construction", 5952, "Fountain 1", "fountain", 500);
			RegisterEntry("Construction", 6610, "Fountain 2", "fountain", 500);
			RegisterEntry("Construction", 9541, "Lighthouse", "lighthouse", 8000);
			RegisterEntry("Construction", 15196, "Outhouse East", "outhouse", 200);
			RegisterEntry("Construction", 15195, "Outhouse South", "outhouse", 200);
			RegisterEntry("Construction", 1981, "Platform 1", "platform", 50);
			RegisterEntry("Construction", 1983, "Platform 2", "platform", 50);
			RegisterEntry("Construction", 1987, "Platform 3", "platform", 50);
			RegisterEntry("Construction", 2327, "Stone Step Dark", "stone step", 100);
			RegisterEntry("Construction", 2325, "Stone Step Light", "stone step", 100);
			RegisterEntry("Construction", 1, "Telescope", "telescope", 10000);
			RegisterEntry("Construction", 15724, "Water Wheel 1 East", "water wheel", 1000);
			RegisterEntry("Construction", 15832, "Water Wheel 1 South", "water wheel", 1000);
			RegisterEntry("Construction", 15728, "Water Wheel 2 East", "water wheel", 1200);
			RegisterEntry("Construction", 15867, "Water Wheel 2 South", "water wheel", 1200);
			RegisterEntry("Construction", 8690, "Well", "well", 500);
			RegisterEntry("Construction", 9358, "Well Dark", "well", 1000);
			RegisterEntry("Construction", 9343, "Well Green", "well", 1000);
			RegisterEntry("Construction", 8636, "Well Marble", "well", 1000);
			RegisterEntry("Construction", 10555, "Well Red", "well", 1000);
			RegisterEntry("Construction", 65, "Well Stone", "well", 1000);
			RegisterEntry("Construction", 9, "Well Wood", "well", 1000);

			RegisterEntry("Fences", 0x2F9, "Dungeon Corner", "brick fence", 150);
			RegisterEntry("Fences", 0x2FA, "Dungeon South", "brick fence", 150);
			RegisterEntry("Fences", 0x2FB, "Dungeon East", "brick fence", 150);
			RegisterEntry("Fences", 0x2FC, "Dungeon Post", "brick fence", 150);
			RegisterEntry("Fences", 0x24, "Gray Block Corner", "stone fence", 150);
			RegisterEntry("Fences", 0x25, "Gray Block South", "stone fence", 150);
			RegisterEntry("Fences", 0x26, "Gray Block East", "stone fence", 150);
			RegisterEntry("Fences", 0x27, "Gray Block Post", "stone fence", 150);
			RegisterEntry("Fences", 0x3D, "Gray Brick Corner", "brick fence", 150);
			RegisterEntry("Fences", 0x3E, "Gray Brick South", "brick fence", 150);
			RegisterEntry("Fences", 0x3F, "Gray Brick East", "brick fence", 150);
			RegisterEntry("Fences", 0x40, "Gray Brick Post", "brick fence", 150);
			RegisterEntry("Fences", 2082, "Iron Tall Corner", "iron fence", 150);
			RegisterEntry("Fences", 2081, "Iron Tall South", "iron fence", 150);
			RegisterEntry("Fences", 2083, "Iron Tall East", "iron fence", 150);
			RegisterEntry("Fences", 2122, "Iron Short Corner", "iron fence", 150);
			RegisterEntry("Fences", 2121, "Iron Short South", "iron fence", 150);
			RegisterEntry("Fences", 2123, "Iron Short East", "iron fence", 150);
			RegisterEntry("Fences", 0x9A, "Log Corner", "log fence", 150);
			RegisterEntry("Fences", 0x9B, "Log East", "log fence", 150);
			RegisterEntry("Fences", 0x9C, "Log South", "log fence", 150);
			RegisterEntry("Fences", 0x9D, "Log Post", "log fence", 150);
			RegisterEntry("Fences", 0xA0, "Log East Post", "log fence", 150);
			RegisterEntry("Fences", 0xA1, "Log South Post", "log fence", 150);
			RegisterEntry("Fences", 0x168, "Sandstone Corner", "sandstone fence", 150);
			RegisterEntry("Fences", 0x16A, "Sandstone South", "sandstone fence", 150);
			RegisterEntry("Fences", 0x169, "Sandstone East", "sandstone fence", 150);
			RegisterEntry("Fences", 0x16B, "Sandstone Post", "sandstone fence", 150);
			RegisterEntry("Fences", 0x164, "Sandstone Corner Decorative", "sandstone fence", 150);
			RegisterEntry("Fences", 0x165, "Sandstone South Decorative", "sandstone fence", 150);
			RegisterEntry("Fences", 0x166, "Sandstone East Decorative", "sandstone fence", 150);
			RegisterEntry("Fences", 0x167, "Sandstone Post Decorative", "sandstone fence", 150);
			RegisterEntry("Fences", 0x3BE, "Sandstone Block Corner", "sandstone fence", 150);
			RegisterEntry("Fences", 0x3C0, "Sandstone Block South", "sandstone fence", 150);
			RegisterEntry("Fences", 0x3C1, "Sandstone Block East", "sandstone fence", 150);
			RegisterEntry("Fences", 0x3C2, "Sandstone Block Post", "sandstone fence", 150);
			RegisterEntry("Fences", 655, "Stone Iron Wall Corner", "stone wall", 150);
			RegisterEntry("Fences", 654, "Stone Iron Wall South", "stone wall", 150);
			RegisterEntry("Fences", 653, "Stone Iron Wall East", "stone wall", 150);
			RegisterEntry("Fences", 656, "Stone Iron Wall Post", "stone wall", 150);
			RegisterEntry("Fences", 0x61, "White Brick Corner", "brick fence", 150);
			RegisterEntry("Fences", 0x5F, "White Brick South", "brick fence", 150);
			RegisterEntry("Fences", 0x60, "White Brick East", "brick fence", 150);
			RegisterEntry("Fences", 0x62, "White Brick Post", "brick fence", 150);
			RegisterEntry("Fences", 2101, "Wood Light Corner", "wooden fence", 150);
			RegisterEntry("Fences", 2103, "Wood Light South", "wooden fence", 150);
			RegisterEntry("Fences", 2102, "Wood Light East", "wooden fence", 150);
			RegisterEntry("Fences", 2104, "Wood Light Post", "wooden fence", 150);
			RegisterEntry("Fences", 2140, "Wood Dark Rail Corner", "wooden fence", 150);
			RegisterEntry("Fences", 2142, "Wood Dark Rail South", "wooden fence", 150);
			RegisterEntry("Fences", 2141, "Wood Dark Rail East", "wooden fence", 150);
			RegisterEntry("Fences", 2143, "Wood Dark Rail Post", "wooden fence", 150);
			RegisterEntry("Fences", 2145, "Wood Dark Rails South", "wooden fence", 150);
			RegisterEntry("Fences", 2144, "Wood Dark Rails East", "wooden fence", 150);
			RegisterEntry("Fences", 2146, "Wood Dark Lattice Corner", "wooden fence", 150);
			RegisterEntry("Fences", 2148, "Wood Dark Lattice South", "wooden fence", 150);
			RegisterEntry("Fences", 2147, "Wood Dark Lattice East", "wooden fence", 150);
			RegisterEntry("Fences", 2149, "Wood Dark Lattice Post", "wooden fence", 150);

			RegisterEntry("Floor", 0x215D, "Astral Tile", "tile", 50);
			RegisterEntry("Floor", 1179, "Blue Tile", "tile", 50);
			RegisterEntry("Floor", 1189, "Boards EW", "boards", 50);
			RegisterEntry("Floor", 1191, "Boards NS", "boards", 50);
			RegisterEntry("Floor", 1251, "Brick Red EW", "bricks", 50);
			RegisterEntry("Floor", 1250, "Brick Red NS", "bricks", 50);
			RegisterEntry("Floor", 1327, "Brick Sandstone Dark EW", "bricks", 50);
			RegisterEntry("Floor", 1331, "Brick Sandstone Dark NS", "bricks", 50);
			RegisterEntry("Floor", 1317, "Brick Sandstone Light EW", "bricks", 50);
			RegisterEntry("Floor", 1321, "Brick Sandstone Light NS", "bricks", 50);
			RegisterEntry("Floor", 1301, "Cobblestone", "cobblestone", 50);
			RegisterEntry("Floor", 0x2160, "Cracked Crimson Tile", "tile", 50);
			RegisterEntry("Floor", 0x215F, "Designer Tile 1", "tile", 50);
			RegisterEntry("Floor", 0x4082, "Designer Tile 2", "tile", 50);
			RegisterEntry("Floor", 0x3004, "Emerald Tile", "tile", 50);
			RegisterEntry("Floor", 0x2E40, "Ethereal Void", "void", 50);
			RegisterEntry("Floor", 1276, "Flagstone EW", "flagstone", 50);
			RegisterEntry("Floor", 1277, "Flagstone NS", "flagstone", 50);
			RegisterEntry("Floor", 1280, "Flagstone Sand EW", "flagstone", 50);
			RegisterEntry("Floor", 1281, "Flagstone Sand NS", "flagstone", 50);
			RegisterEntry("Floor", 0x2161, "Gargoyle Tile", "tile", 50);
			RegisterEntry("Floor", 1180, "Grey Tile", "tile", 50);
			RegisterEntry("Floor", 0x2162, "Holy Tile", "tile", 50);
			RegisterEntry("Floor", 1292, "Logs Dark EW", "logs", 50);
			RegisterEntry("Floor", 1291, "Logs Dark NS", "logs", 50);
			RegisterEntry("Floor", 1290, "Logs EW", "logs", 50);
			RegisterEntry("Floor", 1289, "Logs NS", "logs", 50);
			RegisterEntry("Floor", 1297, "Marble Tile", "marble", 50);
			RegisterEntry("Floor", 1295, "Marble Tile Blue", "marble", 50);
			RegisterEntry("Floor", 1293, "Marble Tile Light", "marble", 50);
			RegisterEntry("Floor", 1173, "Marble", "marble", 50);
			RegisterEntry("Floor", 0x22BE, "Obsidian Tile", "obsidian", 50);
			RegisterEntry("Floor", 0x22C1, "Onyx Tile", "onyx", 50);
			RegisterEntry("Floor", 0x46CC, "Ruin Tile", "stone", 50);
			RegisterEntry("Floor", 0x40A3, "Runic Tile", "runic tile", 200);
			RegisterEntry("Floor", 1181, "Sandstone", "sandstone", 50);
			RegisterEntry("Floor", 1309, "Stone", "stone", 50);
			RegisterEntry("Floor", 1313, "Stone Dark", "stone", 50);
			RegisterEntry("Floor", 1305, "Stone Light", "stone", 50);
			RegisterEntry("Floor", 1306, "Stone Mix", "stone", 50);
			RegisterEntry("Floor", 25578, "Stone Tile Mossy Mix", "stone", 50);
			RegisterEntry("Floor", 0x2163, "Syth Tile", "tile", 50);
			RegisterEntry("Floor", 0x215E, "Vortex Tile", "tile", 50);
			RegisterEntry("Floor", 1222, "Wooden Planks EW", "planks", 50);
			RegisterEntry("Floor", 1236, "Wooden Planks NS", "planks", 50);

			//For adding new gates/doors, please see LawnGate.cs in the Items folder for examples.

			RegisterEntry("Gates", 2124, "Iron Short Gate SDW", "iron gate", 150);
			RegisterEntry("Gates", 2126, "Iron Short Gate SDE", "iron gate", 150);
			RegisterEntry("Gates", 2128, "Iron Short Gate SUW", "iron gate", 150);
			RegisterEntry("Gates", 2130, "Iron Short Gate SUE", "iron gate", 150);
			RegisterEntry("Gates", 2132, "Iron Short Gate EUE", "iron gate", 150);
			RegisterEntry("Gates", 2134, "Iron Short Gate EDE", "iron gate", 150);
			RegisterEntry("Gates", 2136, "Iron Short Gate EDW", "iron gate", 150);
			RegisterEntry("Gates", 2138, "Iron Short Gate EUW", "iron gate", 150);
			RegisterEntry("Gates", 2084, "Iron Tall Gate SDW", "iron gate", 150);
			RegisterEntry("Gates", 2086, "Iron Tall Gate SDE", "iron gate", 150);
			RegisterEntry("Gates", 2088, "Iron Tall Gate SUW", "iron gate", 150);
			RegisterEntry("Gates", 2090, "Iron Tall Gate SUE", "iron gate", 150);
			RegisterEntry("Gates", 2092, "Iron Tall Gate EUE", "iron gate", 150);
			RegisterEntry("Gates", 2094, "Iron Tall Gate EDE", "iron gate", 150);
			RegisterEntry("Gates", 2096, "Iron Tall Gate EDW", "iron gate", 150);
			RegisterEntry("Gates", 2098, "Iron Tall Gate EUW", "iron gate", 150);
			RegisterEntry("Gates", 2150, "Wood Dark Gate SDW", "wooden gate", 150);
			RegisterEntry("Gates", 2152, "Wood Dark Gate SDE", "wooden gate", 150);
			RegisterEntry("Gates", 2154, "Wood Dark Gate SUW", "wooden gate", 150);
			RegisterEntry("Gates", 2156, "Wood Dark Gate SUE", "wooden gate", 150);
			RegisterEntry("Gates", 2158, "Wood Dark Gate EUE", "wooden gate", 150);
			RegisterEntry("Gates", 2160, "Wood Dark Gate EDE", "wooden gate", 150);
			RegisterEntry("Gates", 2162, "Wood Dark Gate EDW", "wooden gate", 150);
			RegisterEntry("Gates", 2164, "Wood Dark Gate EUW", "wooden gate", 150);
			RegisterEntry("Gates", 2105, "Wood Light Gate SDW", "wooden gate", 150);
			RegisterEntry("Gates", 2107, "Wood Light Gate SDE", "wooden gate", 150);
			RegisterEntry("Gates", 2109, "Wood Light Gate SUW", "wooden gate", 150);
			RegisterEntry("Gates", 2111, "Wood Light Gate SUE", "wooden gate", 150);
			RegisterEntry("Gates", 2113, "Wood Light Gate EUE", "wooden gate", 150);
			RegisterEntry("Gates", 2115, "Wood Light Gate EDE", "wooden gate", 150);
			RegisterEntry("Gates", 2117, "Wood Light Gate EDW", "wooden gate", 150);
			RegisterEntry("Gates", 2119, "Wood Light Gate EUW", "wooden gate", 150); 

			int cycle = 0;
			while ( cycle < 18 )
			{
				cycle++;

				string x_ground = "";
				string x_name = "";

				if ( cycle == 1 ){ 			x_ground = "Blood Rock";	x_name = "blood rock ground"; 	}
				else if ( cycle == 2 ){ 	x_ground = "Cave";			x_name = "cavern ground"; 		}
				else if ( cycle == 3 ){ 	x_ground = "Desert";		x_name = "desert ground"; 		}
				else if ( cycle == 4 ){ 	x_ground = "Dirt";			x_name = "dirt ground"; 		}
				else if ( cycle == 5 ){ 	x_ground = "Dirt Light";	x_name = "light dirt ground"; 	}
				else if ( cycle == 6 ){ 	x_ground = "Dirt Dark";		x_name = "dark dirt ground"; 	}
				else if ( cycle == 7 ){ 	x_ground = "Forest";		x_name = "forest ground"; 		}
				else if ( cycle == 8 ){ 	x_ground = "Grass";			x_name = "grassy ground"; 		}
				else if ( cycle == 9 ){ 	x_ground = "Jungle";		x_name = "jungle ground"; 		}
				else if ( cycle == 10 ){ 	x_ground = "Lava Rock";		x_name = "lava rock ground"; 	}
				else if ( cycle == 11 ){ 	x_ground = "Lunar Rock";	x_name = "lunar rock ground"; 	}
				else if ( cycle == 12 ){ 	x_ground = "Magma Rock";	x_name = "magma rock ground"; 	}
				else if ( cycle == 13 ){ 	x_ground = "Mud";			x_name = "muddy ground"; 		}
				else if ( cycle == 14 ){ 	x_ground = "Snow";			x_name = "snowy ground"; 		}
				else if ( cycle == 15 ){ 	x_ground = "Stone";			x_name = "stone ground"; 		}
				else if ( cycle == 16 ){ 	x_ground = "Stone Light";	x_name = "light stone ground"; 	}
				else if ( cycle == 17 ){ 	x_ground = "Stone Dark";	x_name = "dark stone ground"; 	}
				else if ( cycle == 18 ){ 	x_ground = "Swamp";			x_name = "swampy ground"; 		}

				int x_id = Remodeling.GroundID( x_name );

				if ( cycle == 14 )
				{
					RegisterEntry("Ground", 6077, "Snow", "snow", 50);
					RegisterEntry("Ground", 6081, "Snow Edging 1", "snow", 50);
					RegisterEntry("Ground", 6082, "Snow Edging 2", "snow", 50);
					RegisterEntry("Ground", 6083, "Snow Edging 3", "snow", 50);
					RegisterEntry("Ground", 6084, "Snow Edging 4", "snow", 50);
					RegisterEntry("Ground", 6085, "Snow Edging 5", "snow", 50);
					RegisterEntry("Ground", 6086, "Snow Edging 6", "snow", 50);
					RegisterEntry("Ground", 6087, "Snow Edging 7", "snow", 50);
					RegisterEntry("Ground", 6088, "Snow Edging 8", "snow", 50);
					RegisterEntry("Ground", 6089, "Snow Edging 9", "snow", 50);
					RegisterEntry("Ground", 6090, "Snow Edging 10", "snow", 50);
					RegisterEntry("Ground", 6091, "Snow Edging 11", "snow", 50);
					RegisterEntry("Ground", 6092, "Snow Edging 12", "snow", 50);
				}
				else if ( cycle == 18 )
				{
					RegisterEntry("Ground", 12813, "Swamp", "swamp", 100);
					RegisterEntry("Ground", 12844, "Swamp Bubble 1", "bubble", 100);
					RegisterEntry("Ground", 12854, "Swamp Bubble 2", "bubble", 100);
					RegisterEntry("Ground", 12865, "Swamp Bubble 3", "bubble", 100);
					RegisterEntry("Ground", 12876, "Swamp Stump 1", "stump", 100);
					RegisterEntry("Ground", 12877, "Swamp Stump 2", "stump", 100);
					RegisterEntry("Ground", 12878, "Swamp og North 1", "log", 100);
					RegisterEntry("Ground", 12879, "Swamp Log North 2", "log", 100);
					RegisterEntry("Ground", 12880, "Swamp Log East 1", "log", 100);
					RegisterEntry("Ground", 12881, "Swamp Log East 2", "log", 100);
					RegisterEntry("Ground", 12888, "Swamp Edging 1", "swamp", 100);
					RegisterEntry("Ground", 12889, "Swamp Edging 2", "swamp", 100);
					RegisterEntry("Ground", 12890, "Swamp Edging 3", "swamp", 100);
					RegisterEntry("Ground", 12891, "Swamp Edging 4", "swamp", 100);
					RegisterEntry("Ground", 12892, "Swamp Edging 5", "swamp", 100);
					RegisterEntry("Ground", 12893, "Swamp Edging 6", "swamp", 100);
					RegisterEntry("Ground", 12894, "Swamp Edging 7", "swamp", 100);
					RegisterEntry("Ground", 12895, "Swamp Edging 8", "swamp", 100);
					RegisterEntry("Ground", 12896, "Swamp Edging 9", "swamp", 100);
					RegisterEntry("Ground", 12897, "Swamp Edging 10", "swamp", 100);
					RegisterEntry("Ground", 12898, "Swamp Edging 11", "swamp", 100);
					RegisterEntry("Ground", 12899, "Swamp Edging 12", "swamp", 100);
					RegisterEntry("Ground", 12900, "Swamp Edging 13", "swamp", 100);
					RegisterEntry("Ground", 12901, "Swamp Edging 14", "swamp", 100);
					RegisterEntry("Ground", 12902, "Swamp Edging 15", "swamp", 100);
					RegisterEntry("Ground", 12903, "Swamp Edging 16", "swamp", 100);
					RegisterEntry("Ground", 12904, "Swamp Edging 17", "swamp", 100);
					RegisterEntry("Ground", 12912, "Swamp Edging 18", "swamp", 50);
					RegisterEntry("Ground", 12913, "Swamp Edging 19", "swamp", 50);
					RegisterEntry("Ground", 12914, "Swamp Edging 20", "swamp", 50);
					RegisterEntry("Ground", 12915, "Swamp Edging 21", "swamp", 50);
					RegisterEntry("Ground", 12916, "Swamp Edging 22", "swamp", 50);
					RegisterEntry("Ground", 12917, "Swamp Edging 23", "swamp", 50);
					RegisterEntry("Ground", 12918, "Swamp Edging 24", "swamp", 50);
					RegisterEntry("Ground", 12919, "Swamp Edging 25", "swamp", 50);
					RegisterEntry("Ground", 12920, "Swamp Edging 26", "swamp", 50);
					RegisterEntry("Ground", 12921, "Swamp Edging 27", "swamp", 50);
					RegisterEntry("Ground", 12922, "Swamp Edging 28", "swamp", 50);
					RegisterEntry("Ground", 12923, "Swamp Edging 29", "swamp", 50);
					RegisterEntry("Ground", 12924, "Swamp Edging 30", "swamp", 50);
					RegisterEntry("Ground", 12925, "Swamp Edging 31", "swamp", 50);
					RegisterEntry("Ground", 12926, "Swamp Edging 32", "swamp", 50);
					RegisterEntry("Ground", 12927, "Swamp Edging 33", "swamp", 50);
				}
				else
				{
					RegisterEntry("Ground", 0x5C16+x_id, x_ground, x_name, 50);
					RegisterEntry("Ground", 0x5C46+x_id, x_ground + " Edging 1", x_name, 50);
					RegisterEntry("Ground", 0x5C47+x_id, x_ground + " Edging 2", x_name, 50);
					RegisterEntry("Ground", 0x5C48+x_id, x_ground + " Edging 3", x_name, 50);
					RegisterEntry("Ground", 0x5C49+x_id, x_ground + " Edging 4", x_name, 50);
					RegisterEntry("Ground", 0x5C4A+x_id, x_ground + " Edging 5", x_name, 50);
					RegisterEntry("Ground", 0x5C4B+x_id, x_ground + " Edging 6", x_name, 50);
					RegisterEntry("Ground", 0x5C4C+x_id, x_ground + " Edging 7", x_name, 50);
					RegisterEntry("Ground", 0x5C4D+x_id, x_ground + " Edging 8", x_name, 50);
					RegisterEntry("Ground", 0x5C7C+x_id, x_ground + " Edging 9", x_name, 50);
					RegisterEntry("Ground", 0x5C7D+x_id, x_ground + " Edging 10", x_name, 50);
					RegisterEntry("Ground", 0x5C7E+x_id, x_ground + " Edging 11", x_name, 50);
					RegisterEntry("Ground", 0x5C7F+x_id, x_ground + " Edging 12", x_name, 50);
					RegisterEntry("Ground", 0x5C80+x_id, x_ground + " Edging 13", x_name, 50);
					RegisterEntry("Ground", 0x5C81+x_id, x_ground + " Edging 14", x_name, 50);
					RegisterEntry("Ground", 0x5C82+x_id, x_ground + " Edging 15", x_name, 50);
					RegisterEntry("Ground", 0x5C83+x_id, x_ground + " Edging 16", x_name, 50);
				}
			}

			RegisterEntry("Items", 20404, "Anchor East", "anchor", 75);
			RegisterEntry("Items", 20403, "Anchor South", "anchor", 75);
			RegisterEntry("Items", 0x45A, "Bench Marble East", "bench", 100);
			RegisterEntry("Items", 0x459, "Bench Marble South", "bench", 100);
			RegisterEntry("Items", 0x45C, "Bench Sandstone East", "bench", 100);
			RegisterEntry("Items", 0x45B, "Bench Sandstone South", "bench", 100);
			RegisterEntry("Items", 0xB2D, "Bench Wooden East", "bench", 100);
			RegisterEntry("Items", 0xB2C, "Bench Wooden South", "bench", 100);
			RegisterEntry("Items", 8857, "Boat Large East", "boat", 250);
			RegisterEntry("Items", 8864, "Boat Large South", "boat", 250);
			RegisterEntry("Items", 8860, "Boat Small East", "boat", 200);
			RegisterEntry("Items", 8862, "Boat Small South", "boat", 200);
			RegisterEntry("Items", 21281, "Bonfire Lit", "bonfire", 350);
			RegisterEntry("Items", 21280, "Bonfire Unlit", "pile of wood", 350);
			RegisterEntry("Items", 21408, "Bonfire Social", "huge fire", 3500);
			RegisterEntry("Items", 21516, "Cart East", "cart", 150);
			RegisterEntry("Items", 14999, "Cart South", "cart", 150);
			RegisterEntry("Items", 2879, "Counter East", "counter", 100);
			RegisterEntry("Items", 2880, "Counter South", "counter", 100);
			RegisterEntry("Items", 10749, "Fire Pit", "fire pit", 300);
			RegisterEntry("Items", 10750, "Fire Pit Social", "burning pit", 3000);
			RegisterEntry("Items", 19663, "Fish Tub", "tub of fish", 300);
			RegisterEntry("Items", 4595, "Hammock East", "hammock", 150);
			RegisterEntry("Items", 4592, "Hammock South", "hammock", 150);
			RegisterEntry("Items", 3894, "Hay Sheaf", "hay", 50);
			RegisterEntry("Items", 4201, "Hide Stretched East", "hide", 50);
			RegisterEntry("Items", 4218, "Hide Stretched South", "hide", 50);
			RegisterEntry("Items", 2848, "Lamp Post 1", "lamp post", 300);
			RegisterEntry("Items", 2850, "Lamp Post 2", "lamp post", 300);
			RegisterEntry("Items", 2852, "Lamp Post 3", "lamp post", 300);
			RegisterEntry("Items", 20313, "Lantern Post East", "lantern post", 300);
			RegisterEntry("Items", 20312, "Lantern Post South", "lantern post", 300);
			RegisterEntry("Items", 7135, "Logs East", "logs", 50);
			RegisterEntry("Items", 7138, "Logs South", "logs", 50);
			RegisterEntry("Items", 7723, "Oars East", "oars", 50);
			RegisterEntry("Items", 7722, "Oars South", "oars", 50);
			RegisterEntry("Items", 2938, "Picnic Table East", "table", 200);
			RegisterEntry("Items", 2957, "Picnic Table South", "table", 200);

			RegisterEntry("Lava", 13371, "Bubble 1", "lava", 100);
			RegisterEntry("Lava", 13401, "Bubble 2", "lava", 100);
			RegisterEntry("Lava", 13390, "Bubble 3", "lava", 100);
			RegisterEntry("Lava", 4846, "Lava East", "lava", 100);
			RegisterEntry("Lava", 4870, "Lava South", "lava", 100);
			RegisterEntry("Lava", 4894, "Lava Edge 1", "lava", 100);
			RegisterEntry("Lava", 4897, "Lava Edge 2", "lava", 100);
			RegisterEntry("Lava", 4900, "Lava Edge 3", "lava", 100);
			RegisterEntry("Lava", 4903, "Lava Edge 4", "lava", 100);
			RegisterEntry("Lava", 4906, "Lava Edge 5", "lava", 100);
			RegisterEntry("Lava", 4909, "Lava Edge 6", "lava", 100);
			RegisterEntry("Lava", 4912, "Lava Edge 7", "lava", 100);
			RegisterEntry("Lava", 4915, "Lava Edge 8", "lava", 100);
			RegisterEntry("Lava", 4918, "Lava Edge 9", "lava", 100);
			RegisterEntry("Lava", 4921, "Lava Edge 10", "lava", 100);
			RegisterEntry("Lava", 4924, "Lava Edge 11", "lava", 100);
			RegisterEntry("Lava", 4927, "Lava Edge 12", "lava", 100);
			RegisterEntry("Lava", 4930, "Lava Edge 13", "lava", 100);
			RegisterEntry("Lava", 4933, "Lava Edge 14", "lava", 100);
			RegisterEntry("Lava", 4936, "Lava Edge 15", "lava", 100);
			RegisterEntry("Lava", 4939, "Lava Edge 16", "lava", 100);
			RegisterEntry("Lava", 6681, "Lavafall East 1", "lava", 100);
			RegisterEntry("Lava", 6686, "Lavafall East 2", "lava", 100);
			RegisterEntry("Lava", 6691, "Lavafall East 3", "lava", 100);
			RegisterEntry("Lava", 6696, "Lavafall East 4", "lava", 100);
			RegisterEntry("Lava", 6701, "Lavafall East 5", "lava", 100);
			RegisterEntry("Lava", 6706, "Lavafall East 6", "lava", 100);
			RegisterEntry("Lava", 6711, "Lavafall East 7", "lava", 100);
			RegisterEntry("Lava", 6715, "Lavafall East 8", "lava", 100);
			RegisterEntry("Lava", 6719, "Lavafall East 9", "lava", 100);
			RegisterEntry("Lava", 6723, "Lavafall East 10", "lava", 100);
			RegisterEntry("Lava", 6727, "Lavafall South 1", "lava", 100);
			RegisterEntry("Lava", 6732, "Lavafall South 2", "lava", 100);
			RegisterEntry("Lava", 6737, "Lavafall South 3", "lava", 100);
			RegisterEntry("Lava", 6742, "Lavafall South 4", "lava", 100);
			RegisterEntry("Lava", 6747, "Lavafall South 5", "lava", 100);
			RegisterEntry("Lava", 6752, "Lavafall South 6", "lava", 100);
			RegisterEntry("Lava", 6757, "Lavafall South 7", "lava", 100);
			RegisterEntry("Lava", 6761, "Lavafall South 8", "lava", 100);
			RegisterEntry("Lava", 6765, "Lavafall South 9", "lava", 100);
			RegisterEntry("Lava", 6769, "Lavafall South 10", "lava", 100);
			RegisterEntry("Lava", 13410, "Lava Stagnant 1", "lava", 100);
			RegisterEntry("Lava", 13416, "Lava Stagnant 2", "lava", 100);

			RegisterEntry("Magical", 6173, "Alchemy Symbol 1", "alchemy symbol", 200);
			RegisterEntry("Magical", 6174, "Alchemy Symbol 2", "alchemy symbol", 200);
			RegisterEntry("Magical", 6175, "Alchemy Symbol 3", "alchemy symbol", 200);
			RegisterEntry("Magical", 6176, "Alchemy Symbol 4", "alchemy symbol", 200);
			RegisterEntry("Magical", 6177, "Alchemy Symbol 5", "alchemy symbol", 200);
			RegisterEntry("Magical", 6178, "Alchemy Symbol 6", "alchemy symbol", 200);
			RegisterEntry("Magical", 6179, "Alchemy Symbol 7", "alchemy symbol", 200);
			RegisterEntry("Magical", 6180, "Alchemy Symbol 8", "alchemy symbol", 200);
			RegisterEntry("Magical", 6181, "Alchemy Symbol 9", "alchemy symbol", 200);
			RegisterEntry("Magical", 6182, "Alchemy Symbol 10", "alchemy symbol", 200);
			RegisterEntry("Magical", 6183, "Alchemy Symbol 11", "alchemy symbol", 200);
			RegisterEntry("Magical", 6184, "Alchemy Symbol 12", "alchemy symbol", 200);
			RegisterEntry("Magical", 4630, "Altar", "altar", 500);
			RegisterEntry("Magical", 3676, "Glowing Rune 1", "glowing rune", 300);
			RegisterEntry("Magical", 3679, "Glowing Rune 2", "glowing rune", 300);
			RegisterEntry("Magical", 3682, "Glowing Rune 3", "glowing rune", 300);
			RegisterEntry("Magical", 3685, "Glowing Rune 4", "glowing rune", 300);
			RegisterEntry("Magical", 3688, "Glowing Rune 5", "glowing rune", 300);
			RegisterEntry("Magical", 8990, "Mushroom Glowing 1", "mushroom", 250);
			RegisterEntry("Magical", 8991, "Mushroom Glowing 2", "mushroom", 250);
			RegisterEntry("Magical", 8992, "Mushroom Glowing 3", "mushroom", 250);
			RegisterEntry("Magical", 8993, "Mushroom Glowing 4", "mushroom", 250);
			RegisterEntry("Magical", 8994, "Mushroom Glowing 5", "mushroom", 250);
			RegisterEntry("Magical", 8995, "Mushroom Glowing 6", "mushroom", 250);
			RegisterEntry("Magical", 8996, "Mushroom Glowing 7", "mushroom", 250);
			RegisterEntry("Magical", 8997, "Mushroom Glowing 8", "mushroom", 250);
			RegisterEntry("Magical", 8987, "Mushroom Large 1 East", "mushroom", 500);
			RegisterEntry("Magical", 8986, "Mushroom Large 1 South", "mushroom", 500);
			RegisterEntry("Magical", 8989, "Mushroom Large 2 East", "mushroom", 500);
			RegisterEntry("Magical", 8988, "Mushroom Large 2 South", "mushroom", 500);
			RegisterEntry("Magical", 4074, "Pentagram Red", "pentagram", 500);
			RegisterEntry("Magical", 8602, "Pentagram Red Summon", "summoning pentagram", 4000);
			RegisterEntry("Magical", 1607, "Pentagram Dark", "pentagram", 500);
			RegisterEntry("Magical", 8603, "Pentagram Dark Summon", "summoning pentagram", 4000);
			RegisterEntry("Magical", 18491, "Runic Symbol 1", "runic symbol", 350);
			RegisterEntry("Magical", 18494, "Runic Symbol 2", "runic symbol", 350);
			RegisterEntry("Magical", 18497, "Runic Symbol 3", "runic symbol", 350);
			RegisterEntry("Magical", 18500, "Runic Symbol 4", "runic symbol", 350);
			RegisterEntry("Magical", 18503, "Runic Symbol 5", "runic symbol", 350);
			RegisterEntry("Magical", 18506, "Runic Symbol 6", "runic symbol", 350);
			RegisterEntry("Magical", 18509, "Runic Symbol 7", "runic symbol", 350);
			RegisterEntry("Magical", 18512, "Runic Symbol 8", "runic symbol", 350);
			RegisterEntry("Magical", 18515, "Runic Symbol 9", "runic symbol", 350);
			RegisterEntry("Magical", 18518, "Runic Symbol 10", "runic symbol", 350);
			RegisterEntry("Magical", 18521, "Runic Symbol 11", "runic symbol", 350);
			RegisterEntry("Magical", 18524, "Runic Symbol 12", "runic symbol", 350);
			RegisterEntry("Magical", 18527, "Runic Symbol 13", "runic symbol", 350);
			RegisterEntry("Magical", 18530, "Runic Symbol 14", "runic symbol", 350);
			RegisterEntry("Magical", 18533, "Runic Symbol 15", "runic symbol", 350);
			RegisterEntry("Magical", 18536, "Runic Symbol 16", "runic symbol", 350);
			RegisterEntry("Magical", 18539, "Runic Symbol 17", "runic symbol", 350);
			RegisterEntry("Magical", 18542, "Runic Symbol 18", "runic symbol", 350);
			RegisterEntry("Magical", 18545, "Runic Symbol 19", "runic symbol", 350);
			RegisterEntry("Magical", 18548, "Runic Symbol 20", "runic symbol", 350);
			RegisterEntry("Magical", 18551, "Runic Symbol 21", "runic symbol", 350);
			RegisterEntry("Magical", 18554, "Runic Symbol 22", "runic symbol", 350);
			RegisterEntry("Magical", 18557, "Runic Symbol 23", "runic symbol", 350);
			RegisterEntry("Magical", 18560, "Runic Symbol 24", "runic symbol", 350);
			RegisterEntry("Magical", 18563, "Runic Symbol 25", "runic symbol", 350);
			RegisterEntry("Magical", 0x373A, "Sparkles Blue", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x3039, "Sparkles Green", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x374A, "Sparkles Red", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x375A, "Sparkles Dense", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x376A, "Sparkles Swirl", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x5469, "Sparkles Fire", "magic sparkles", 1000);
			RegisterEntry("Magical", 0x54E1, "Sparkles Stars", "magic sparkles", 1000);
			RegisterEntry("Magical", 14752, "Wizard Stone Table East", "stone table", 400);
			RegisterEntry("Magical", 14753, "Wizard Stone Table South", "stone table", 400);

			RegisterEntry("Plants", 3242, "Banana Tree", "tree", 150);
			RegisterEntry("Plants", 3219, "Blade Plant", "plant", 100);
			RegisterEntry("Plants", 3220, "Bulrushes", "bush", 100);
			RegisterEntry("Plants", 3365, "Cactus 1", "cactus", 100);
			RegisterEntry("Plants", 3366, "Cactus 2", "cactus", 100);
			RegisterEntry("Plants", 3367, "Cactus 3", "cactus", 100);
			RegisterEntry("Plants", 3368, "Cactus 4", "cactus", 100);
			RegisterEntry("Plants", 3370, "Cactus 5", "cactus", 100);
			RegisterEntry("Plants", 3372, "Cactus 6", "cactus", 100);
			RegisterEntry("Plants", 3374, "Cactus 7", "cactus", 100);
			RegisterEntry("Plants", 3203, "Campion Flowers 1", "flowers", 100);
			RegisterEntry("Plants", 3207, "Campion Flowers 2", "flowers", 100);
			RegisterEntry("Plants", 3209, "Campion Flowers 3", "flowers", 100);
			RegisterEntry("Plants", 3255, "Cattails 1", "cattails", 50);
			RegisterEntry("Plants", 3256, "Cattails 2", "cattails", 50);
			RegisterEntry("Plants", 3276, "Century Plant 1", "plant", 150);
			RegisterEntry("Plants", 3277, "Century Plant 2", "plant", 150);
			RegisterEntry("Plants", 3221, "Coconut Palm", "palm tree", 100);
			RegisterEntry("Plants", 3222, "Date Palm", "palm tree", 100);
			RegisterEntry("Plants", 3223, "Elephant Ear", "plant", 100);
			RegisterEntry("Plants", 3224, "Fan Plant", "plant", 100);
			RegisterEntry("Plants", 3231, "Fern 1", "fern", 100);
			RegisterEntry("Plants", 3232, "Fern 2", "fern", 100);
			RegisterEntry("Plants", 3233, "Fern 3", "fern", 100);
			RegisterEntry("Plants", 3234, "Fern 4", "fern", 100);
			RegisterEntry("Plants", 3235, "Fern 5", "fern", 100);
			RegisterEntry("Plants", 3236, "Fern 6", "fern", 100);
			RegisterEntry("Plants", 3204, "Foxglove Flowers 1", "flowers", 100);
			RegisterEntry("Plants", 3210, "Foxglove Flowers 2", "flowers", 100);
			RegisterEntry("Plants", 3355, "Grapevines 1", "vines", 100);
			RegisterEntry("Plants", 3356, "Grapevines 2", "vines", 100);
			RegisterEntry("Plants", 3357, "Grapevines 3", "vines", 100);
			RegisterEntry("Plants", 3358, "Grapevines 4", "vines", 100);
			RegisterEntry("Plants", 3359, "Grapevines 5", "vines", 100);
			RegisterEntry("Plants", 3360, "Grapevines 6", "vines", 100);
			RegisterEntry("Plants", 3361, "Grapevines 7", "vines", 100);
			RegisterEntry("Plants", 3362, "Grapevines 8", "vines", 100);
			RegisterEntry("Plants", 3363, "Grapevines 9", "vines", 100);
			RegisterEntry("Plants", 3364, "Grapevines 10", "vines", 100);
			RegisterEntry("Plants", 3244, "Grass 1", "grass", 50);
			RegisterEntry("Plants", 3245, "Grass 2", "grass", 50);
			RegisterEntry("Plants", 3246, "Grass 3", "grass", 50);
			RegisterEntry("Plants", 3247, "Grass 4", "grass", 50);
			RegisterEntry("Plants", 3248, "Grass 5", "grass", 50);
			RegisterEntry("Plants", 3249, "Grass 6", "grass", 50);
			RegisterEntry("Plants", 3250, "Grass 7", "grass", 50);
			RegisterEntry("Plants", 3251, "Grass 8", "grass", 50);
			RegisterEntry("Plants", 3252, "Grass 9", "grass", 50);
			RegisterEntry("Plants", 3253, "Grass 10", "grass", 50);
			RegisterEntry("Plants", 3254, "Grass 11", "grass", 50);
			RegisterEntry("Plants", 3257, "Grass 12", "grass", 50);
			RegisterEntry("Plants", 3258, "Grass 13", "grass", 50);
			RegisterEntry("Plants", 3259, "Grass 14", "grass", 50);
			RegisterEntry("Plants", 3260, "Grass 15", "grass", 50);
			RegisterEntry("Plants", 3261, "Grass 16", "grass", 50);
			RegisterEntry("Plants", 3269, "Grass 17", "grass", 50);
			RegisterEntry("Plants", 3270, "Grass 18", "grass", 50);
			RegisterEntry("Plants", 3278, "Grass 19", "grass", 50);
			RegisterEntry("Plants", 3279, "Grass 20", "grass", 50);
			RegisterEntry("Plants", 3272, "Juniper Bush", "bush", 150);
			RegisterEntry("Plants", 3334, "Lilypad 1", "lilypad", 50);
			RegisterEntry("Plants", 3335, "Lilypad 2", "lilypad", 50);
			RegisterEntry("Plants", 3336, "Lilypad 3", "lilypad", 50);
			RegisterEntry("Plants", 3337, "Lilypad 4", "lilypad", 50);
			RegisterEntry("Plants", 3338, "Lilypad 5", "lilypad", 50);
			RegisterEntry("Plants", 3339, "Lilypads", "lilypad", 100);
			RegisterEntry("Plants", 3315, "Log Piece 1", "log", 50);
			RegisterEntry("Plants", 3316, "Log Piece 2", "log", 50);
			RegisterEntry("Plants", 3317, "Log Piece 3", "log", 33);
			RegisterEntry("Plants", 3318, "Log Piece 4", "log", 33);
			RegisterEntry("Plants", 3319, "Log Piece 5", "log", 33);
			RegisterEntry("Plants", 3380, "Morning Glories", "flowers", 50);
			RegisterEntry("Plants", 3267, "Muck", "muck", 50);
			RegisterEntry("Plants", 3342, "Mushrooms 1", "mushrooms", 50);
			RegisterEntry("Plants", 3343, "Mushrooms 2", "mushrooms", 50);
			RegisterEntry("Plants", 3344, "Mushrooms 3", "mushrooms", 50);
			RegisterEntry("Plants", 3347, "Mushrooms 4", "mushrooms", 50);
			RegisterEntry("Plants", 3348, "Mushrooms 5", "mushrooms", 50);
			RegisterEntry("Plants", 3349, "Mushrooms 6", "mushrooms", 50);
			RegisterEntry("Plants", 3350, "Mushrooms 7", "mushrooms", 50);
			RegisterEntry("Plants", 3351, "Mushrooms 8", "mushrooms", 50);
			RegisterEntry("Plants", 3230, "O'hii Tree", "tree", 100);
			RegisterEntry("Plants", 3205, "Orfluer Flower", "flowers", 100);
			RegisterEntry("Plants", 3264, "Orfluer Flowers 1", "flowers", 100);
			RegisterEntry("Plants", 3265, "Orfluer Flowers 2", "flowers", 100);
			RegisterEntry("Plants", 3237, "Pampas Grass 1", "grass", 100);
			RegisterEntry("Plants", 3268, "Pampas Grass 2", "grass", 100);
			RegisterEntry("Plants", 3381, "Pipe Cactus", "cactus", 150);
			RegisterEntry("Plants", 3238, "Ponytail Palm", "palm tree", 100);
			RegisterEntry("Plants", 3262, "Poppies 1", "flowers", 50);
			RegisterEntry("Plants", 3263, "Poppies 2", "flowers", 50);
			RegisterEntry("Plants", 3206, "Red Poppies", "flowers", 100);
			RegisterEntry("Plants", 3333, "Reeds", "reeds", 100);
			RegisterEntry("Plants", 3239, "Rushes", "bush", 100);
			RegisterEntry("Plants", 3305, "Sapling 1", "sapling", 150);
			RegisterEntry("Plants", 3306, "Sapling 2", "sapling", 150);
			RegisterEntry("Plants", 3215, "Short Bush 1", "bush", 150);
			RegisterEntry("Plants", 3217, "Short Bush 2", "bush", 150);
			RegisterEntry("Plants", 3240, "Small Banana Tree", "tree", 150);
			RegisterEntry("Plants", 3225, "Small Palm 1", "palm tree", 100);
			RegisterEntry("Plants", 3226, "Small Palm 2", "palm tree", 100);
			RegisterEntry("Plants", 3227, "Small Palm 3", "palm tree", 100);
			RegisterEntry("Plants", 3228, "Small Palm 4", "palm tree", 100);
			RegisterEntry("Plants", 3229, "Small Palm 5", "palm tree", 100);
			RegisterEntry("Plants", 3241, "Snake Plant", "plant", 100);
			RegisterEntry("Plants", 3208, "Snowdrops 1", "flowers", 100);
			RegisterEntry("Plants", 3214, "Snowdrops 2", "flowers", 100);
			RegisterEntry("Plants", 3273, "Spider Tree", "tree", 150);
			RegisterEntry("Plants", 3512, "Tall Bush", "bush", 150);
			RegisterEntry("Plants", 3307, "Vines 1", "vines", 100);
			RegisterEntry("Plants", 3308, "Vines 2", "vines", 100);
			RegisterEntry("Plants", 3309, "Vines 3", "vines", 100);
			RegisterEntry("Plants", 3310, "Vines 4", "vines", 100);
			RegisterEntry("Plants", 3311, "Vines 5", "vines", 100);
			RegisterEntry("Plants", 3312, "Vines 6", "vines", 100);
			RegisterEntry("Plants", 3313, "Vines 7", "vines", 100);
			RegisterEntry("Plants", 3314, "Vines 8", "vines", 100);
			RegisterEntry("Plants", 3413, "Vines 9", "vines", 100);
			RegisterEntry("Plants", 3457, "Vines 10", "vines", 100);
			RegisterEntry("Plants", 3436, "Vines 11", "vines", 100);
			RegisterEntry("Plants", 3474, "Vines 12", "vines", 100);
			RegisterEntry("Plants", 3332, "Water Plant", "plant", 100);
			RegisterEntry("Plants", 3271, "Weed", "plant", 50);
			RegisterEntry("Plants", 3211, "White Flowers 1", "flowers", 100);
			RegisterEntry("Plants", 3212, "White Flowers 2", "flowers", 100);
			RegisterEntry("Plants", 3213, "White Poppies", "flowers", 100);
			RegisterEntry("Plants", 3383, "Yucca", "plant", 150);

			RegisterEntry("Rocks", 4963, "Rock 1", "rock", 50);
			RegisterEntry("Rocks", 4964, "Rock 2", "rock", 50);
			RegisterEntry("Rocks", 4965, "Rock 3", "rock", 50);
			RegisterEntry("Rocks", 4966, "Rock 4", "rock", 50);
			RegisterEntry("Rocks", 4967, "Rock 5", "rock", 50);
			RegisterEntry("Rocks", 4968, "Rock 6", "rock", 50);
			RegisterEntry("Rocks", 4969, "Rock 7", "rock", 50);
			RegisterEntry("Rocks", 4970, "Rock 8", "rock", 50);
			RegisterEntry("Rocks", 4971, "Rock 9", "rock", 50);
			RegisterEntry("Rocks", 4972, "Rock 10", "rock", 50);
			RegisterEntry("Rocks", 4973, "Rock 11", "rock", 50);
			RegisterEntry("Rocks", 6001, "Rock 12", "rock", 50);
			RegisterEntry("Rocks", 6002, "Rock 13", "rock", 50);
			RegisterEntry("Rocks", 6003, "Rock 14", "rock", 50);
			RegisterEntry("Rocks", 6004, "Rock 15", "rock", 50);
			RegisterEntry("Rocks", 6005, "Rock 16", "rock", 50);
			RegisterEntry("Rocks", 6006, "Rock 17", "rock", 50);
			RegisterEntry("Rocks", 6007, "Rock 18", "rock", 50);
			RegisterEntry("Rocks", 6008, "Rock 19", "rock", 50);
			RegisterEntry("Rocks", 6009, "Rock 20", "rock", 50);
			RegisterEntry("Rocks", 6010, "Rock 21", "rock", 50);
			RegisterEntry("Rocks", 6011, "Rock 22", "rock", 50);
			RegisterEntry("Rocks", 6012, "Rock 23", "rock", 50);

			RegisterEntry("Stairs", 1978, "Carpeted Red Block", "stairs", 50);
			RegisterEntry("Stairs", 1979, "Carpeted Red Stair", "stairs", 50);
			RegisterEntry("Stairs", 998, "Carpeted Red Curved", "stairs", 50);
			RegisterEntry("Stairs", 1801, "Marble Block", "stairs", 50);
			RegisterEntry("Stairs", 1802, "Marble Stair", "stairs", 50);
			RegisterEntry("Stairs", 1806, "Marble Corner", "stairs", 50);
			RegisterEntry("Stairs", 1810, "Marble Curved", "stairs", 50);
			RegisterEntry("Stairs", 1814, "Marble Invert", "stairs", 50);
			RegisterEntry("Stairs", 1818, "Marble ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1822, "Stone Dark Block", "stairs", 50);
			RegisterEntry("Stairs", 1823, "Stone Dark Stair", "stairs", 50);
			RegisterEntry("Stairs", 1866, "Stone Dark Corner", "stairs", 50);
			RegisterEntry("Stairs", 1870, "Stone Dark Curved", "stairs", 50);
			RegisterEntry("Stairs", 1952, "Stone Dark Invert", "stairs", 50);
			RegisterEntry("Stairs", 2015, "Stone Dark ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1955, "Stone Dungeon Block", "stairs", 50);
			RegisterEntry("Stairs", 1956, "Stone Dungeon Stair", "stairs", 50);
			RegisterEntry("Stairs", 1960, "Stone Dungeon Corner", "stairs", 50);
			RegisterEntry("Stairs", 1964, "Stone Dungeon Invert", "stairs", 50);
			RegisterEntry("Stairs", 1928, "Stone Light Block", "stairs", 50);
			RegisterEntry("Stairs", 1929, "Stone Light Stair", "stairs", 50);
			RegisterEntry("Stairs", 1933, "Stone Light Corner", "stairs", 50);
			RegisterEntry("Stairs", 1937, "Stone Light Curved", "stairs", 50);
			RegisterEntry("Stairs", 1941, "Stone Light Invert", "stairs", 50);
			RegisterEntry("Stairs", 1945, "Stone Light ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1006, "Stone Sand Block", "stairs", 50);
			RegisterEntry("Stairs", 1007, "Stone Sand Stair", "stairs", 50);
			RegisterEntry("Stairs", 1011, "Stone Sand Corner", "stairs", 50);
			RegisterEntry("Stairs", 1015, "Stone Sand Curved", "stairs", 50);
			RegisterEntry("Stairs", 1019, "Stone Sand Invert", "stairs", 50);
			RegisterEntry("Stairs", 1023, "Stone Sand ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1900, "Stone Sand Smooth Block", "stairs", 50);
			RegisterEntry("Stairs", 1901, "Stone Sand Smooth Stair", "stairs", 50);
			RegisterEntry("Stairs", 1905, "Stone Sand Smooth Corner", "stairs", 50);
			RegisterEntry("Stairs", 1909, "Stone Sand Smooth Curved", "stairs", 50);
			RegisterEntry("Stairs", 1913, "Stone Sand Smooth Invert", "stairs", 50);
			RegisterEntry("Stairs", 1917, "Stone Sand Smooth ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1872, "Stone White Block", "stairs", 50);
			RegisterEntry("Stairs", 1873, "Stone White Stair", "stairs", 50);
			RegisterEntry("Stairs", 1877, "Stone White Corner", "stairs", 50);
			RegisterEntry("Stairs", 1881, "Stone White Curved", "stairs", 50);
			RegisterEntry("Stairs", 1885, "Stone White Invert", "stairs", 50);
			RegisterEntry("Stairs", 1889, "Stone White ICurved", "stairs", 50);
			RegisterEntry("Stairs", 1848, "Wood Dark Block", "stairs", 50);
			RegisterEntry("Stairs", 1849, "Wood Dark Stair", "stairs", 50);
			RegisterEntry("Stairs", 1853, "Wood Dark Corner", "stairs", 50);
			RegisterEntry("Stairs", 1861, "Wood Dark Curved", "stairs", 50);
			RegisterEntry("Stairs", 1857, "Wood Dark Invert", "stairs", 50);
			RegisterEntry("Stairs", 1825, "Wood Light Block", "stairs", 50);
			RegisterEntry("Stairs", 1826, "Wood Light Stair", "stairs", 50);
			RegisterEntry("Stairs", 1830, "Wood Light Corner", "stairs", 50);
			RegisterEntry("Stairs", 1834, "Wood Light Curved", "stairs", 50);
			RegisterEntry("Stairs", 1838, "Wood Light Invert", "stairs", 50);
			RegisterEntry("Stairs", 1842, "Wood Light ICurved", "stairs", 50);
			RegisterEntry("Stairs", 2170, "Wooden Ramp", "ramp", 50);

			RegisterEntry("Trees", 3277, "Tree 1 Main", "tree", 200);
			RegisterEntry("Trees", 3278, "Leaves 1 Spring", "leaves", 50);
			RegisterEntry("Trees", 3279, "Leaves 1 Fall", "leaves", 50);
			RegisterEntry("Trees", 3280, "Tree 2 Main", "tree", 200);
			RegisterEntry("Trees", 3281, "Leaves 2 Spring", "leaves", 50);
			RegisterEntry("Trees", 3282, "Leaves 2 Fall", "leaves", 50);
			RegisterEntry("Trees", 3283, "Tree 3 Main", "tree", 200);
			RegisterEntry("Trees", 3284, "Leaves 3 Spring", "leaves", 50);
			RegisterEntry("Trees", 3285, "Leaves 3 Fall", "leaves", 50);
			RegisterEntry("Trees", 3290, "Tree 4 Main", "tree", 200);
			RegisterEntry("Trees", 3291, "Leaves 4 Spring", "leaves", 50);
			RegisterEntry("Trees", 3292, "Leaves 4 Fall", "leaves", 50);
			RegisterEntry("Trees", 3293, "Tree 5 Main", "tree", 200);
			RegisterEntry("Trees", 3294, "Leaves 5 Spring", "leaves", 50);
			RegisterEntry("Trees", 3295, "Leaves 5 Fall", "leaves", 50);
			RegisterEntry("Trees", 3296, "Tree 6 Main", "tree", 200);
			RegisterEntry("Trees", 3297, "Leaves 6 Spring", "leaves", 50);
			RegisterEntry("Trees", 3298, "Leaves 6 Fall", "leaves", 50);
			RegisterEntry("Trees", 3299, "Tree 7 Main", "tree", 200);
			RegisterEntry("Trees", 3300, "Leaves 7 Spring", "leaves", 50);
			RegisterEntry("Trees", 3301, "Leaves 7 Fall", "leaves", 50);
			RegisterEntry("Trees", 3302, "Tree 8 Main", "tree", 200);
			RegisterEntry("Trees", 3303, "Leaves 8 Spring", "leaves", 50);
			RegisterEntry("Trees", 3304, "Leaves 8 Fall", "leaves", 50);
			RegisterEntry("Trees", 3476, "Tree 9 Main", "tree", 200);
			RegisterEntry("Trees", 3477, "Leaves 9 Spring", "leaves", 50);
			RegisterEntry("Trees", 3478, "Leaves 9 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3479, "Leaves 9 Fall", "leaves", 50);
			RegisterEntry("Trees", 3480, "Tree 10 Main", "tree", 200);
			RegisterEntry("Trees", 3481, "Leaves 10 Spring", "leaves", 50);
			RegisterEntry("Trees", 3482, "Leaves 10 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3483, "Leaves 10 Fall", "leaves", 50);
			RegisterEntry("Trees", 3484, "Tree 11 Main", "tree", 200);
			RegisterEntry("Trees", 3485, "Leaves 11 Spring", "leaves", 50);
			RegisterEntry("Trees", 3486, "Leaves 11 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3487, "Leaves 11 Fall", "leaves", 50);
			RegisterEntry("Trees", 3488, "Tree 12 Main", "tree", 200);
			RegisterEntry("Trees", 3489, "Leaves 12 Spring", "leaves", 50);
			RegisterEntry("Trees", 3490, "Leaves 12 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3491, "Leaves 12 Fall", "leaves", 50);
			RegisterEntry("Trees", 3492, "Tree 13 Main", "tree", 200);
			RegisterEntry("Trees", 3493, "Leaves 13 Spring", "leaves", 50);
			RegisterEntry("Trees", 3494, "Leaves 13 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3495, "Leaves 13 Fall", "leaves", 50);
			RegisterEntry("Trees", 3496, "Tree 14 Main", "tree", 200);
			RegisterEntry("Trees", 3497, "Leaves 14 Spring", "leaves", 50);
			RegisterEntry("Trees", 3498, "Leaves 14 Fruit", "leaves", 50);
			RegisterEntry("Trees", 3499, "Leaves 14 Fall", "leaves", 50);
			RegisterEntry("Trees", 3286, "Tree 15 Main", "tree", 200);
			RegisterEntry("Trees", 3287, "Leaves 15 Spring", "leaves", 100);
			RegisterEntry("Trees", 3288, "Tree 16 Main", "tree", 200);
			RegisterEntry("Trees", 3289, "Leaves 16 Spring", "leaves", 100);
			RegisterEntry("Trees", 3395, "Jungle 1 Main", "tree", 400);
			RegisterEntry("Trees", 3401, "Leaves 1 Thick", "leaves", 200);
			RegisterEntry("Trees", 3408, "Leaves 1 Thin", "leaves", 200);
			RegisterEntry("Trees", 3417, "Jungle 2 Main", "tree", 400);
			RegisterEntry("Trees", 3423, "Leaves 2 Thick", "leaves", 200);
			RegisterEntry("Trees", 3430, "Leaves 2 Thin", "leaves", 200);
			RegisterEntry("Trees", 3440, "Jungle 3 Main", "tree", 400);
			RegisterEntry("Trees", 3446, "Leaves 3 Thick", "leaves", 200);
			RegisterEntry("Trees", 3453, "Leaves 3 Thin", "leaves", 200);
			RegisterEntry("Trees", 3461, "Jungle 4 Main", "tree", 400);
			RegisterEntry("Trees", 3465, "Leaves 4 Thick", "leaves", 200);
			RegisterEntry("Trees", 3470, "Leaves 4 Thin", "leaves", 200);
			RegisterEntry("Trees", 4793, "Redwood Tree Main", "tree", 1000);
			RegisterEntry("Trees", 4802, "Redwood Tree Leaves", "leaves", 500);
			RegisterEntry("Trees", 3672, "Stump Axe East", "stump", 250);
			RegisterEntry("Trees", 3670, "Stump Axe South", "stump", 250);
			RegisterEntry("Trees", 3673, "Stump East", "stump", 200);
			RegisterEntry("Trees", 3671, "Stump South", "stump", 200);

			RegisterEntry("Water", 13422, "Water", "water", 100);
			RegisterEntry("Water", 13493, "Whirlpool", "whirlpool", 100);
			RegisterEntry("Water", 13555, "Waterfall East 1", "waterfall", 100);
			RegisterEntry("Water", 13549, "Waterfall East 2", "waterfall", 100);
			RegisterEntry("Water", 13561, "Waterfall East 3", "waterfall", 100);
			RegisterEntry("Water", 13567, "Waterfall East 4", "waterfall", 100);
			RegisterEntry("Water", 13573, "Waterfall East 5", "waterfall", 100);
			RegisterEntry("Water", 13585, "Waterfall South 1", "waterfall", 100);
			RegisterEntry("Water", 13579, "Waterfall South 2", "waterfall", 100);
			RegisterEntry("Water", 13591, "Waterfall South 3", "waterfall", 100);
			RegisterEntry("Water", 13597, "Waterfall South 4", "waterfall", 100);
			RegisterEntry("Water", 13603, "Waterfall South 5", "waterfall", 100);
			RegisterEntry("Water", 13446, "Large Rock 1", "rock", 100);
			RegisterEntry("Water", 13451, "Large Rock 2", "rock", 100);
			RegisterEntry("Water", 13345, "Large Rock 3", "rock", 100);
			RegisterEntry("Water", 13356, "Small Rock 1", "rock", 100);
			RegisterEntry("Water", 13484, "Small Rock 2", "rock", 100);
			RegisterEntry("Water", 13488, "Small Rock 3", "rock", 100);
			RegisterEntry("Water", 13350, "Small Rock 4", "rock", 100);
			RegisterEntry("Water", 8099, "Small Wave North", "wave", 100);
			RegisterEntry("Water", 8104, "Small Wave West", "wave", 100);
			RegisterEntry("Water", 8109, "Small Wave East", "wave", 100);
			RegisterEntry("Water", 8114, "Small Wave South", "wave", 100);
			RegisterEntry("Water", 8119, "Large Wave North", "wave", 100);
			RegisterEntry("Water", 8124, "Large Wave West", "wave", 100);
			RegisterEntry("Water", 8129, "Large Wave East", "wave", 100);
			RegisterEntry("Water", 8134, "Large Wave South", "wave", 100);
			RegisterEntry("Water", 6045, "Edging 1", "water", 50);
			RegisterEntry("Water", 6046, "Edging 2", "water", 50);
			RegisterEntry("Water", 6047, "Edging 3", "water", 50);
			RegisterEntry("Water", 6048, "Edging 4", "water", 50);
			RegisterEntry("Water", 6049, "Edging 5", "water", 50);
			RegisterEntry("Water", 6050, "Edging 6", "water", 50);
			RegisterEntry("Water", 6051, "Edging 7", "water", 50);
			RegisterEntry("Water", 6052, "Edging 8", "water", 50);
			RegisterEntry("Water", 6053, "Edging 9", "water", 50);
			RegisterEntry("Water", 6054, "Edging 10", "water", 50);
			RegisterEntry("Water", 6055, "Edging 11", "water", 50);
			RegisterEntry("Water", 6056, "Edging 12", "water", 50);
			RegisterEntry("Water", 6057, "Edging 13", "water", 50);
			RegisterEntry("Water", 6058, "Edging 14", "water", 50);
			RegisterEntry("Water", 6059, "Edging 15", "water", 50);
			RegisterEntry("Water", 6060, "Edging 16", "water", 50);
        }

        public static void RegisterMultis()
        {
            LawnMultiIDs = new Dictionary<int, List<LawnMultiInfo>>();
            int locationID;
            List<LawnMultiInfo> infos;



            #region Tables
            infos = new List<LawnMultiInfo>();
            locationID = 2938;
			infos.Add(new LawnMultiInfo(2912, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(2913, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(2911, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(2934, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(2933, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(2912, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(2913, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(2911, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 2957;
			infos.Add(new LawnMultiInfo(2918, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(2953, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(2918, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(2919, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(2919, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(2917, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(2952, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(2917, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



            #region Lighthouse
            infos = new List<LawnMultiInfo>();
            locationID = 9541;
			infos.Add(new LawnMultiInfo(6843, new Point3D(-3, -3, 28)));
			infos.Add(new LawnMultiInfo(6844, new Point3D(-3, -2, 28)));
			infos.Add(new LawnMultiInfo(6845, new Point3D(-3, -1, 28)));
			infos.Add(new LawnMultiInfo(6842, new Point3D(-2, -3, 28)));
			infos.Add(new LawnMultiInfo(6862, new Point3D(-2, -2, 28)));
			infos.Add(new LawnMultiInfo(6861, new Point3D(-2, -1, 28)));
			infos.Add(new LawnMultiInfo(6846, new Point3D(-2, 0, 28)));
			infos.Add(new LawnMultiInfo(6849, new Point3D(-2, 1, 28)));
			infos.Add(new LawnMultiInfo(6841, new Point3D(-1, -3, 28)));
			infos.Add(new LawnMultiInfo(6863, new Point3D(-1, -2, 28)));
			infos.Add(new LawnMultiInfo(6859, new Point3D(-1, -1, 28)));
			infos.Add(new LawnMultiInfo(6858, new Point3D(-1, 0, 28)));
			infos.Add(new LawnMultiInfo(9535, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(1932, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(1932, new Point3D(-1, 1, 5)));
			infos.Add(new LawnMultiInfo(6855, new Point3D(-1, 1, 28)));
			infos.Add(new LawnMultiInfo(9543, new Point3D(-1, 2, 0)));
			infos.Add(new LawnMultiInfo(1939, new Point3D(-1, 2, 0)));
			infos.Add(new LawnMultiInfo(1939, new Point3D(-1, 2, 5)));
			infos.Add(new LawnMultiInfo(6852, new Point3D(-1, 2, 28)));
			infos.Add(new LawnMultiInfo(9546, new Point3D(-1, 3, 0)));
			infos.Add(new LawnMultiInfo(6820, new Point3D(-1, 3, 28)));
			infos.Add(new LawnMultiInfo(6838, new Point3D(0, -2, 28)));
			infos.Add(new LawnMultiInfo(6860, new Point3D(0, -1, 28)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 0, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 1, 5)));
			infos.Add(new LawnMultiInfo(1941, new Point3D(0, 1, 22)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 2, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 2, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(0, 2, 22)));
			infos.Add(new LawnMultiInfo(1944, new Point3D(0, 3, 22)));
			infos.Add(new LawnMultiInfo(6821, new Point3D(0, 3, 28)));
			infos.Add(new LawnMultiInfo(6835, new Point3D(1, -2, 28)));
			infos.Add(new LawnMultiInfo(9537, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(1931, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(1931, new Point3D(1, -1, 5)));
			infos.Add(new LawnMultiInfo(6832, new Point3D(1, -1, 28)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 0, 5)));
			infos.Add(new LawnMultiInfo(1941, new Point3D(1, 0, 22)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 1, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 1, 22)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(1, 2, 0)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(1, 2, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 2, 22)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(1, 3, 22)));
			infos.Add(new LawnMultiInfo(6822, new Point3D(1, 3, 28)));
			infos.Add(new LawnMultiInfo(9550, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(1940, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(1940, new Point3D(2, -1, 5)));
			infos.Add(new LawnMultiInfo(6829, new Point3D(2, -1, 28)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 0, 0)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 0, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 0, 22)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(2, 1, 0)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(2, 1, 5)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 1, 22)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 2, 22)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(2, 3, 22)));
			infos.Add(new LawnMultiInfo(6823, new Point3D(2, 3, 28)));
			infos.Add(new LawnMultiInfo(9551, new Point3D(3, -1, 0)));
			infos.Add(new LawnMultiInfo(6828, new Point3D(3, -1, 28)));
			infos.Add(new LawnMultiInfo(1943, new Point3D(3, 0, 22)));
			infos.Add(new LawnMultiInfo(6827, new Point3D(3, 0, 28)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(3, 1, 22)));
			infos.Add(new LawnMultiInfo(6826, new Point3D(3, 1, 28)));
			infos.Add(new LawnMultiInfo(1928, new Point3D(3, 2, 22)));
			infos.Add(new LawnMultiInfo(6825, new Point3D(3, 2, 28)));
			infos.Add(new LawnMultiInfo(9541, new Point3D(3, 3, 0)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(3, 3, 22)));
			infos.Add(new LawnMultiInfo(6824, new Point3D(3, 3, 28)));
			infos.Add(new LawnMultiInfo(9553, new Point3D(4, 0, 0)));
			infos.Add(new LawnMultiInfo(1940, new Point3D(4, 0, 22)));
			infos.Add(new LawnMultiInfo(9543, new Point3D(4, 1, 0)));
			infos.Add(new LawnMultiInfo(1930, new Point3D(4, 1, 22)));
			infos.Add(new LawnMultiInfo(9539, new Point3D(4, 2, 0)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(4, 2, 22)));
			infos.Add(new LawnMultiInfo(9548, new Point3D(0, 4, 0)));
			infos.Add(new LawnMultiInfo(1939, new Point3D(0, 4, 22)));
			infos.Add(new LawnMultiInfo(9550, new Point3D(1, 4, 0)));
			infos.Add(new LawnMultiInfo(1929, new Point3D(1, 4, 22)));
			infos.Add(new LawnMultiInfo(9544, new Point3D(2, 4, 0)));
			infos.Add(new LawnMultiInfo(1938, new Point3D(2, 4, 22)));
			infos.Add(new LawnMultiInfo(6864, new Point3D(2, 2, 28)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



            #region Pentagrams
            //Altar
            infos = new List<LawnMultiInfo>();
            locationID = 4630;
			infos.Add(new LawnMultiInfo(4622, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(4629, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(4628, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(4623, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(4627, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(4624, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(4625, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(4626, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //Red Pentagram
            infos = new List<LawnMultiInfo>();
            locationID = 4074;
			infos.Add(new LawnMultiInfo(4071, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(4070, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(4073, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(4072, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(4076, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(4075, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(4078, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(4077, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //Dark Pentagram
            infos = new List<LawnMultiInfo>();
            locationID = 1607;
			infos.Add(new LawnMultiInfo(1599, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(1606, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(1605, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(1600, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(1604, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(1601, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(1602, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(1603, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //Red Pentagram Summoning
            infos = new List<LawnMultiInfo>();
            locationID = 8602;
			infos.Add(new LawnMultiInfo(4071, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(4070, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(4073, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(4072, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(4076, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(4075, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(4078, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(4077, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(4074, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //Dark Pentagram Summoning
            infos = new List<LawnMultiInfo>();
            locationID = 8603;
			infos.Add(new LawnMultiInfo(1599, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(1606, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(1605, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(1600, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(1604, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(1601, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(1602, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(1603, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(1607, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);
			#endregion



            #region Fountains
            //Sand
            infos = new List<LawnMultiInfo>();
            locationID = 5946;
            infos.Add(new LawnMultiInfo(locationID - 9, new Point3D(-2, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 8, new Point3D(-1, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 7, new Point3D(-0, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 6, new Point3D(+1, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 5, new Point3D(+1, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID - 4, new Point3D(+1, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 3, new Point3D(+1, -2, 0)));
            infos.Add(new LawnMultiInfo(locationID - 2, new Point3D(+0, -2, 0)));
            infos.Add(new LawnMultiInfo(locationID - 1, new Point3D(+0, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 1, new Point3D(-1, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID + 2, new Point3D(-2, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID + 3, new Point3D(-2, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 4, new Point3D(-1, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 5, new Point3D(-1, -2, 0)));
            infos.Add(new LawnMultiInfo(5953, new Point3D(-2, -2, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //Stone
            infos = new List<LawnMultiInfo>();
            locationID = 6604;
            infos.Add(new LawnMultiInfo(locationID - 9, new Point3D(-2, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 8, new Point3D(-1, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 7, new Point3D(-0, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 6, new Point3D(+1, 1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 5, new Point3D(+1, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID - 4, new Point3D(+1, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID - 3, new Point3D(+1, -2, 0)));
            infos.Add(new LawnMultiInfo(locationID - 2, new Point3D(+0, -2, 0)));
            infos.Add(new LawnMultiInfo(locationID - 1, new Point3D(+0, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 1, new Point3D(-1, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID + 2, new Point3D(-2, +0, 0)));
            infos.Add(new LawnMultiInfo(locationID + 3, new Point3D(-2, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 4, new Point3D(-1, -1, 0)));
            infos.Add(new LawnMultiInfo(locationID + 5, new Point3D(-1, -2, 0)));
            infos.Add(new LawnMultiInfo(6611, new Point3D(-2, -2, 0)));
            LawnMultiIDs.Add(locationID, infos);

			//Blood
            infos = new List<LawnMultiInfo>();
            locationID = 15213;
			infos.Add(new LawnMultiInfo(15223, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(15208, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(15221, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(15220, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(15205, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(15212, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(15214, new Point3D(-1, 2, 0)));
			infos.Add(new LawnMultiInfo(15199, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(15215, new Point3D(0, 2, 0)));
			infos.Add(new LawnMultiInfo(15202, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(15222, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(15216, new Point3D(1, 2, 0)));
			infos.Add(new LawnMultiInfo(15219, new Point3D(2, 0, 0)));
			infos.Add(new LawnMultiInfo(15218, new Point3D(2, 1, 0)));
			infos.Add(new LawnMultiInfo(15217, new Point3D(2, 2, 0)));
			LawnMultiIDs.Add(locationID, infos);
            #endregion



			#region Telescope
            infos = new List<LawnMultiInfo>();
            locationID = 1;
			infos.Add(new LawnMultiInfo(0x1494, new Point3D(0, 5, 0)));
			infos.Add(new LawnMultiInfo(0x145B, new Point3D(0, 6, 0)));
			infos.Add(new LawnMultiInfo(0x145A, new Point3D(0, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1495, new Point3D(1, 4, 0)));
			infos.Add(new LawnMultiInfo(0x145C, new Point3D(1, 7, 0)));
			infos.Add(new LawnMultiInfo(0x145D, new Point3D(1, 8, 0)));
			infos.Add(new LawnMultiInfo(0x1496, new Point3D(2, 3, 0)));
			infos.Add(new LawnMultiInfo(0x1499, new Point3D(2, 4, 0)));
			infos.Add(new LawnMultiInfo(0x148E, new Point3D(2, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1493, new Point3D(2, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1492, new Point3D(2, 8, 0)));
			infos.Add(new LawnMultiInfo(0x145E, new Point3D(2, 9, 0)));
			infos.Add(new LawnMultiInfo(0x1459, new Point3D(2,10, 0)));
			infos.Add(new LawnMultiInfo(0x1497, new Point3D(3, 2, 0)));
			infos.Add(new LawnMultiInfo(0x145F, new Point3D(3, 9, 0)));
			infos.Add(new LawnMultiInfo(0x1461, new Point3D(3,10, 0)));
			infos.Add(new LawnMultiInfo(0x149A, new Point3D(4, 1, 0)));
			infos.Add(new LawnMultiInfo(0x1498, new Point3D(4, 2, 0)));
			infos.Add(new LawnMultiInfo(0x148F, new Point3D(4, 4, 0)));
			infos.Add(new LawnMultiInfo(0x148D, new Point3D(4, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1488, new Point3D(4, 8, 0)));
			infos.Add(new LawnMultiInfo(0x1460, new Point3D(4, 9, 0)));
			infos.Add(new LawnMultiInfo(0x1462, new Point3D(4,10, 0)));
			infos.Add(new LawnMultiInfo(0x147D, new Point3D(5, 0, 0)));
			infos.Add(new LawnMultiInfo(0x1490, new Point3D(5, 4, 0)));
			infos.Add(new LawnMultiInfo(0x148B, new Point3D(5, 5, 0)));
			infos.Add(new LawnMultiInfo(0x148A, new Point3D(5, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1486, new Point3D(5, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1485, new Point3D(5, 8, 0)));
			infos.Add(new LawnMultiInfo(0x147C, new Point3D(6, 0, 0)));
			infos.Add(new LawnMultiInfo(0x1491, new Point3D(6, 4, 0)));
			infos.Add(new LawnMultiInfo(0x148C, new Point3D(6, 5, 0)));
			infos.Add(new LawnMultiInfo(0x1489, new Point3D(6, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1487, new Point3D(6, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1484, new Point3D(6, 8, 0)));
			infos.Add(new LawnMultiInfo(0x1463, new Point3D(6,10, 0)));
			infos.Add(new LawnMultiInfo(0x147B, new Point3D(7, 0, 0)));
			infos.Add(new LawnMultiInfo(0x147F, new Point3D(7, 3, 0)));
			infos.Add(new LawnMultiInfo(0x1480, new Point3D(7, 4, 0)));
			infos.Add(new LawnMultiInfo(0x1482, new Point3D(7, 5, 0)));
			infos.Add(new LawnMultiInfo(0x1469, new Point3D(7, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1468, new Point3D(7, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1465, new Point3D(7, 8, 0)));
			infos.Add(new LawnMultiInfo(0x1464, new Point3D(7, 9, 0)));
			infos.Add(new LawnMultiInfo(0x147A, new Point3D(8, 0, 0)));
			infos.Add(new LawnMultiInfo(0x1479, new Point3D(8, 1, 0)));
			infos.Add(new LawnMultiInfo(0x1477, new Point3D(8, 2, 0)));
			infos.Add(new LawnMultiInfo(0x147E, new Point3D(8, 3, 0)));
			infos.Add(new LawnMultiInfo(0x1481, new Point3D(8, 4, 0)));
			infos.Add(new LawnMultiInfo(0x1483, new Point3D(8, 5, 0)));
			infos.Add(new LawnMultiInfo(0x146A, new Point3D(8, 6, 0)));
			infos.Add(new LawnMultiInfo(0x1467, new Point3D(8, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1466, new Point3D(8, 8, 0)));
			infos.Add(new LawnMultiInfo(0x1478, new Point3D(9, 1, 0)));
			infos.Add(new LawnMultiInfo(0x1475, new Point3D(9, 2, 0)));
			infos.Add(new LawnMultiInfo(0x1474, new Point3D(9, 3, 0)));
			infos.Add(new LawnMultiInfo(0x146F, new Point3D(9, 4, 0)));
			infos.Add(new LawnMultiInfo(0x146E, new Point3D(9, 5, 0)));
			infos.Add(new LawnMultiInfo(0x146D, new Point3D(9, 6, 0)));
			infos.Add(new LawnMultiInfo(0x146B, new Point3D(9, 7, 0)));
			infos.Add(new LawnMultiInfo(0x1476, new Point3D(10, 2, 0)));
			infos.Add(new LawnMultiInfo(0x1473, new Point3D(10, 3, 0)));
			infos.Add(new LawnMultiInfo(0x1470, new Point3D(10, 4, 0)));
			infos.Add(new LawnMultiInfo(0x1471, new Point3D(10, 5, 0)));
			infos.Add(new LawnMultiInfo(0x1472, new Point3D(10, 6, 0)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



			#region Skull Pile
            infos = new List<LawnMultiInfo>();
            locationID = 6875;
			infos.Add(new LawnMultiInfo(6877, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(6878, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(6874, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(6873, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(6876, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(6872, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(6879, new Point3D(2, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



			#region Tombs
            infos = new List<LawnMultiInfo>();
            locationID = 7206;
			infos.Add(new LawnMultiInfo(7205, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7204, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(7203, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7207, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7202, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7219;
			infos.Add(new LawnMultiInfo(7218, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7220, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7217, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(7216, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7215, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7251;
			infos.Add(new LawnMultiInfo(7250, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7252, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7240;
			infos.Add(new LawnMultiInfo(7239, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7241, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7237;
			infos.Add(new LawnMultiInfo(7236, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7238, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7254;
			infos.Add(new LawnMultiInfo(7255, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7253, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7339;
			infos.Add(new LawnMultiInfo(7338, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7340, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7337, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(7336, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7335, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7316;
			infos.Add(new LawnMultiInfo(7315, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7314, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(7313, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7317, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7312, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7325;
			infos.Add(new LawnMultiInfo(7324, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(7326, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7323, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(7322, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7321, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7291;
			infos.Add(new LawnMultiInfo(7290, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7289, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(7288, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7292, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7287, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7268;
			infos.Add(new LawnMultiInfo(7267, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7266, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(7265, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7269, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7264, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 7277;
			infos.Add(new LawnMultiInfo(7276, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(7275, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(7274, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(7278, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(7273, new Point3D(1, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 12990;
			infos.Add(new LawnMultiInfo(12988, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 12994;
			infos.Add(new LawnMultiInfo(13003, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 12992;
			infos.Add(new LawnMultiInfo(12990, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(12988, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 13005;
			infos.Add(new LawnMultiInfo(13003, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(12994, new Point3D(-1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 8605;
			infos.Add(new LawnMultiInfo(12991, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(12990, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 8604;
			infos.Add(new LawnMultiInfo(13006, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(12994, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 12993;
			infos.Add(new LawnMultiInfo(12988, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 13004;
			infos.Add(new LawnMultiInfo(13003, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 8600;
			infos.Add(new LawnMultiInfo(12993, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(12991, new Point3D(0, 1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 8601;
			infos.Add(new LawnMultiInfo(13004, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(13006, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);
			#endregion



			#region SpookyTrees
            infos = new List<LawnMultiInfo>();
            locationID = 3959;
            infos.Add(new LawnMultiInfo(2073, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 3986;
            infos.Add(new LawnMultiInfo(2073, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 3987;
            infos.Add(new LawnMultiInfo(2073, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 3988;
            infos.Add(new LawnMultiInfo(2073, new Point3D(0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);
			#endregion



			#region Wells
            infos = new List<LawnMultiInfo>();
            locationID = 9358;
			infos.Add(new LawnMultiInfo(9156, new Point3D(2, 1, 15)));
			infos.Add(new LawnMultiInfo(3348, new Point3D(0, 1, 3)));
			infos.Add(new LawnMultiInfo(9364, new Point3D(0, 0, 5)));
			infos.Add(new LawnMultiInfo(6008, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(3244, new Point3D(2, -1, 0)));
			infos.Add(new LawnMultiInfo(9364, new Point3D(0, -1, 5)));
			infos.Add(new LawnMultiInfo(9158, new Point3D(1, 1, 15)));
			infos.Add(new LawnMultiInfo(3248, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(9357, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(9364, new Point3D(1, 0, 5)));
			infos.Add(new LawnMultiInfo(6039, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(9158, new Point3D(1, 0, 15)));
			infos.Add(new LawnMultiInfo(9156, new Point3D(2, 0, 15)));
			infos.Add(new LawnMultiInfo(6007, new Point3D(2, 0, 0)));
			infos.Add(new LawnMultiInfo(4090, new Point3D(2, 0, 9)));
			infos.Add(new LawnMultiInfo(7840, new Point3D(2, 0, 4)));
			infos.Add(new LawnMultiInfo(3244, new Point3D(2, 0, 0)));
			infos.Add(new LawnMultiInfo(3347, new Point3D(2, 0, 3)));
			infos.Add(new LawnMultiInfo(7070, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(9359, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(9364, new Point3D(1, -1, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 9343;
			infos.Add(new LawnMultiInfo(10489, new Point3D(1, 1, 15)));
			infos.Add(new LawnMultiInfo(4973, new Point3D(1, 1, 4)));
			infos.Add(new LawnMultiInfo(3212, new Point3D(2, 0, 3)));
			infos.Add(new LawnMultiInfo(10491, new Point3D(0, 1, 15)));
			infos.Add(new LawnMultiInfo(4090, new Point3D(0, 1, 9)));
			infos.Add(new LawnMultiInfo(7840, new Point3D(0, 1, 4)));
			infos.Add(new LawnMultiInfo(3248, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(3250, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(9353, new Point3D(0, 0, 5)));
			infos.Add(new LawnMultiInfo(6039, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(10491, new Point3D(0, 0, 15)));
			infos.Add(new LawnMultiInfo(9344, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(9353, new Point3D(-1, 0, 5)));
			infos.Add(new LawnMultiInfo(3234, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(9353, new Point3D(-1, -1, 5)));
			infos.Add(new LawnMultiInfo(9352, new Point3D(-1, -1, 0)));
			infos.Add(new LawnMultiInfo(9345, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(9353, new Point3D(0, -1, 5)));
			infos.Add(new LawnMultiInfo(3248, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(9327, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(10489, new Point3D(1, 0, 15)));
			infos.Add(new LawnMultiInfo(4969, new Point3D(1, 0, 2)));
			infos.Add(new LawnMultiInfo(4968, new Point3D(1, 0, 4)));
			infos.Add(new LawnMultiInfo(3244, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(3251, new Point3D(1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 8636;
			infos.Add(new LawnMultiInfo(6012, new Point3D(-1, 1, 1)));
			infos.Add(new LawnMultiInfo(3248, new Point3D(-1, 1, 1)));
			infos.Add(new LawnMultiInfo(272, new Point3D(-1, 0, 1)));
			infos.Add(new LawnMultiInfo(269, new Point3D(-1, 0, 4)));
			infos.Add(new LawnMultiInfo(3208, new Point3D(-1, 0, 1)));
			infos.Add(new LawnMultiInfo(269, new Point3D(-1, -1, 4)));
			infos.Add(new LawnMultiInfo(271, new Point3D(0, -1, 1)));
			infos.Add(new LawnMultiInfo(269, new Point3D(0, -1, 4)));
			infos.Add(new LawnMultiInfo(4090, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(3250, new Point3D(1, -1, 1)));
			infos.Add(new LawnMultiInfo(3241, new Point3D(1, -1, 1)));
			infos.Add(new LawnMultiInfo(10420, new Point3D(0, 1, 16)));
			infos.Add(new LawnMultiInfo(3245, new Point3D(0, 1, 1)));
			infos.Add(new LawnMultiInfo(10419, new Point3D(1, 1, 16)));
			infos.Add(new LawnMultiInfo(4972, new Point3D(1, 1, 1)));
			infos.Add(new LawnMultiInfo(3246, new Point3D(1, 1, 1)));
			infos.Add(new LawnMultiInfo(10419, new Point3D(1, 0, 16)));
			infos.Add(new LawnMultiInfo(4963, new Point3D(1, 0, 1)));
			infos.Add(new LawnMultiInfo(4090, new Point3D(1, 0, 8)));
			infos.Add(new LawnMultiInfo(7840, new Point3D(1, 0, 3)));
			infos.Add(new LawnMultiInfo(6814, new Point3D(1, 0, 1)));
			infos.Add(new LawnMultiInfo(270, new Point3D(0, 0, 1)));
			infos.Add(new LawnMultiInfo(269, new Point3D(0, 0, 4)));
			infos.Add(new LawnMultiInfo(6039, new Point3D(0, 0, 1)));
			infos.Add(new LawnMultiInfo(10420, new Point3D(0, 0, 16)));
			infos.Add(new LawnMultiInfo(3247, new Point3D(2, 0, 1)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 10555;
			infos.Add(new LawnMultiInfo(10562, new Point3D(-1, -1, 5)));
			infos.Add(new LawnMultiInfo(10558, new Point3D(0, -1, 0)));
			infos.Add(new LawnMultiInfo(10562, new Point3D(0, -1, 5)));
			infos.Add(new LawnMultiInfo(3232, new Point3D(-1, 1, 0)));
			infos.Add(new LawnMultiInfo(10555, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(10562, new Point3D(-1, 0, 5)));
			infos.Add(new LawnMultiInfo(3247, new Point3D(-1, 0, 0)));
			infos.Add(new LawnMultiInfo(9181, new Point3D(1, 1, 15)));
			infos.Add(new LawnMultiInfo(3245, new Point3D(1, 1, 0)));
			infos.Add(new LawnMultiInfo(9181, new Point3D(1, 0, 15)));
			infos.Add(new LawnMultiInfo(4973, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(4967, new Point3D(1, 0, 2)));
			infos.Add(new LawnMultiInfo(6814, new Point3D(1, 0, 0)));
			infos.Add(new LawnMultiInfo(3262, new Point3D(1, 0, 2)));
			infos.Add(new LawnMultiInfo(4970, new Point3D(1, -1, 0)));
			infos.Add(new LawnMultiInfo(10558, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(10562, new Point3D(0, 0, 5)));
			infos.Add(new LawnMultiInfo(6039, new Point3D(0, 0, 0)));
			infos.Add(new LawnMultiInfo(9183, new Point3D(0, 0, 15)));
			infos.Add(new LawnMultiInfo(9183, new Point3D(0, 1, 15)));
			infos.Add(new LawnMultiInfo(4090, new Point3D(0, 1, 8)));
			infos.Add(new LawnMultiInfo(7840, new Point3D(0, 1, 3)));
			infos.Add(new LawnMultiInfo(3245, new Point3D(0, 1, 0)));
			infos.Add(new LawnMultiInfo(3247, new Point3D(2, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 65;
			infos.Add(new LawnMultiInfo(3214, new Point3D( 1, 1, 0)));
			infos.Add(new LawnMultiInfo(3252, new Point3D( 1, 1, 0)));
			infos.Add(new LawnMultiInfo(6457, new Point3D( 1, 1, 20)));
			infos.Add(new LawnMultiInfo(3245, new Point3D( 0, 1, 0)));
			infos.Add(new LawnMultiInfo(4970, new Point3D( 0, 1, 0)));
			infos.Add(new LawnMultiInfo(6459, new Point3D( 0, 1, 20)));
			infos.Add(new LawnMultiInfo(3272, new Point3D( 1, -1, 0)));
			infos.Add(new LawnMultiInfo(64, new Point3D( 0, -1, 5)));
			infos.Add(new LawnMultiInfo(66, new Point3D( 0, -1, 0)));
			infos.Add(new LawnMultiInfo(64, new Point3D( -1, -1, 6)));
			infos.Add(new LawnMultiInfo(7840, new Point3D( 1, 0, 6)));
			infos.Add(new LawnMultiInfo(4090, new Point3D( 1, 0, 10)));
			infos.Add(new LawnMultiInfo(3247, new Point3D( 1, 0, 0)));
			infos.Add(new LawnMultiInfo(4967, new Point3D( 1, 0, 0)));
			infos.Add(new LawnMultiInfo(6457, new Point3D( 1, 0, 20)));
			infos.Add(new LawnMultiInfo(3204, new Point3D( -1, 1, 0)));
			infos.Add(new LawnMultiInfo(64, new Point3D( -1, 0, 5)));
			infos.Add(new LawnMultiInfo(67, new Point3D( -1, 0, 0)));
			infos.Add(new LawnMultiInfo(64, new Point3D( 0, 0, 5)));
			infos.Add(new LawnMultiInfo(6459, new Point3D( 0, 0, 20)));
			infos.Add(new LawnMultiInfo(6039, new Point3D( 0, 0, 1)));
			infos.Add(new LawnMultiInfo(65, new Point3D( 0, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 9;
			infos.Add(new LawnMultiInfo(8564, new Point3D( 0, 1, 20)));
			infos.Add(new LawnMultiInfo(7840, new Point3D( 0, 1, 8)));
			infos.Add(new LawnMultiInfo(4090, new Point3D( 0, 1, 13)));
			infos.Add(new LawnMultiInfo(3264, new Point3D( 0, 1, 0)));
			infos.Add(new LawnMultiInfo(9, new Point3D( -1, -1, 0)));
			infos.Add(new LawnMultiInfo(3264, new Point3D( 1, 1, 0)));
			infos.Add(new LawnMultiInfo(3244, new Point3D( 1, 1, 0)));
			infos.Add(new LawnMultiInfo(8561, new Point3D( 1, 1, 20)));
			infos.Add(new LawnMultiInfo(9, new Point3D( 0, -1, 0)));
			infos.Add(new LawnMultiInfo(22, new Point3D( 0, -1, 0)));
			infos.Add(new LawnMultiInfo(3207, new Point3D( -1, 1, 0)));
			infos.Add(new LawnMultiInfo(3223, new Point3D( -1, 1, 0)));
			infos.Add(new LawnMultiInfo(3248, new Point3D( 1, 0, 8)));
			infos.Add(new LawnMultiInfo(3246, new Point3D( 1, 0, 3)));
			infos.Add(new LawnMultiInfo(4973, new Point3D( 1, 0, 6)));
			infos.Add(new LawnMultiInfo(4963, new Point3D( 1, 0, 0)));
			infos.Add(new LawnMultiInfo(8561, new Point3D( 1, 0, 20)));
			infos.Add(new LawnMultiInfo(8564, new Point3D( 0, 0, 20)));
			infos.Add(new LawnMultiInfo(6039, new Point3D( 0, 0, 1)));
			infos.Add(new LawnMultiInfo(20, new Point3D( 0, 0, 0)));
			infos.Add(new LawnMultiInfo(9, new Point3D( -1, 0, 0)));
			infos.Add(new LawnMultiInfo(21, new Point3D( -1, 0, 0)));
			infos.Add(new LawnMultiInfo(3203, new Point3D( -1, 0, 0)));
			infos.Add(new LawnMultiInfo(3223, new Point3D( 1, -1, 0)));
            LawnMultiIDs.Add(locationID, infos);
			#endregion



            #region Graves
            //Restless
            infos = new List<LawnMultiInfo>();
            locationID = 13335;
            infos.Add(new LawnMultiInfo(3809, new Point3D(0, -1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //NS
            infos = new List<LawnMultiInfo>();
            locationID = 3807;
            infos.Add(new LawnMultiInfo(3809, new Point3D(0, -1, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //EW
            infos = new List<LawnMultiInfo>();
            locationID = 3808;
            infos.Add(new LawnMultiInfo(3810, new Point3D(-1, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



            #region Hammock
            //NS
            infos = new List<LawnMultiInfo>();
            locationID = 4592;
            infos.Add(new LawnMultiInfo(4593, new Point3D(2, 0, 0)));
            LawnMultiIDs.Add(locationID, infos);

            //EW
            infos = new List<LawnMultiInfo>();
            locationID = 4595;
            infos.Add(new LawnMultiInfo(4594, new Point3D(0, 2, 0)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



            #region Sparkles
            infos = new List<LawnMultiInfo>();
            locationID = 0x373A;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x3039;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x374A;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x375A;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x376A;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x5469;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);

            infos = new List<LawnMultiInfo>();
            locationID = 0x54E1;
            infos.Add(new LawnMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            LawnMultiIDs.Add(locationID, infos);
            #endregion



            #region Trees
            AddTreeInfo(3395, 2, 1, out infos);
            LawnMultiIDs.Add(3395, infos);

            AddTreeInfo(3401, 4, 3, out infos);
            LawnMultiIDs.Add(3401, infos);

            AddTreeInfo(3408, 3, 3, out infos);
            LawnMultiIDs.Add(3408, infos);

            AddTreeInfo(3417, 2, 2, out infos);
            LawnMultiIDs.Add(3417, infos);

            AddTreeInfo(3423, 3, 3, out infos);
            LawnMultiIDs.Add(3423, infos);

            AddTreeInfo(3430, 3, 3, out infos);
            LawnMultiIDs.Add(3430, infos);

            AddTreeInfo(3440, 2, 2, out infos);
            LawnMultiIDs.Add(3440, infos);

            AddTreeInfo(3446, 2, 2, out infos);
            LawnMultiIDs.Add(3446, infos);

            AddTreeInfo(3453, 3, 2, out infos);
            LawnMultiIDs.Add(3453, infos);

            AddTreeInfo(3461, 1, 1, out infos);
            LawnMultiIDs.Add(3461, infos);

            AddTreeInfo(3465, 2, 2, out infos);
            LawnMultiIDs.Add(3465, infos);

            AddTreeInfo(3470, 2, 2, out infos);
            LawnMultiIDs.Add(3470, infos);

            AddTreeInfo(4793, 3, 4, out infos);
            LawnMultiIDs.Add(4793, infos);

            AddTreeInfo(4802, 4, 5, out infos);
            LawnMultiIDs.Add(4802, infos);

            AddTreeInfo(3413, 1, 1, out infos);
            LawnMultiIDs.Add(3413, infos);

            AddTreeInfo(3436, -2, -1, out infos);
            LawnMultiIDs.Add(3436, infos);

            AddTreeInfo(3457, 1, 2, out infos);
            LawnMultiIDs.Add(3457, infos);

            AddTreeInfo(3474, 1, 1, out infos);
            LawnMultiIDs.Add(3474, infos);
            #endregion
        }

        public static void AddTreeInfo(int locationID, int lowRange, int highRange, out List<LawnMultiInfo> infos)
        {//Used while registering any trees that contain multiple itemIDs
            infos = new List<LawnMultiInfo>();
            while (lowRange > 0)
            {
                infos.Add(new LawnMultiInfo(locationID - lowRange, new Point3D(-lowRange, +lowRange, 0)));
                lowRange--;
            }
            while (highRange > 0)
            {
                infos.Add(new LawnMultiInfo(locationID + highRange, new Point3D(+highRange, -highRange, 0)));
                highRange--;
            }
        }
        #region LawnStairIDGroups

        public static void RegisterStairs()
        {
            LawnStairIDGroups = new Dictionary<int, int[]>();

            LawnStairIDGroups.Add(1006, new int[] { 1006, 1006, 1006, 1006 });
            LawnStairIDGroups.Add(1007, new int[] { 1007, 1008, 1009, 1010 });
            LawnStairIDGroups.Add(1011, new int[] { 1011, 1012, 1013, 1014 });
            LawnStairIDGroups.Add(1015, new int[] { 1015, 1016, 1017, 1018 });
            LawnStairIDGroups.Add(1019, new int[] { 1019, 1020, 1021, 1022 });
            LawnStairIDGroups.Add(1023, new int[] { 1023, 1024, 1025, 1026 });
            LawnStairIDGroups.Add(1801, new int[] { 1801, 1801, 1801, 1801 });
            LawnStairIDGroups.Add(1802, new int[] { 1802, 1803, 1804, 1805 });
            LawnStairIDGroups.Add(1806, new int[] { 1806, 1807, 1808, 1809 });
            LawnStairIDGroups.Add(1810, new int[] { 1810, 1811, 1812, 1813 });
            LawnStairIDGroups.Add(1814, new int[] { 1814, 1815, 1816, 1817 });
            LawnStairIDGroups.Add(1818, new int[] { 1818, 1819, 1820, 1821 });
            LawnStairIDGroups.Add(1822, new int[] { 1822, 1822, 1822, 1822 });
            LawnStairIDGroups.Add(1823, new int[] { 1823, 1846, 1847, 1865 });
            LawnStairIDGroups.Add(1825, new int[] { 1825, 1825, 1825, 1825 });
            LawnStairIDGroups.Add(1826, new int[] { 1826, 1827, 1828, 1829 });
            LawnStairIDGroups.Add(1830, new int[] { 1830, 1831, 1832, 1833 });
            LawnStairIDGroups.Add(1834, new int[] { 1834, 1835, 1836, 1837 });
            LawnStairIDGroups.Add(1838, new int[] { 1838, 1839, 1840, 1841 });
            LawnStairIDGroups.Add(1842, new int[] { 1842, 1843, 1844, 1845 });
            LawnStairIDGroups.Add(1848, new int[] { 1848, 1848, 1848, 1848 });
            LawnStairIDGroups.Add(1849, new int[] { 1849, 1850, 1851, 1852 });
            LawnStairIDGroups.Add(1853, new int[] { 1853, 1854, 1855, 1856 });
            LawnStairIDGroups.Add(1857, new int[] { 1857, 1858, 1859, 1860 });
            LawnStairIDGroups.Add(1861, new int[] { 1861, 1862, 1863, 1864 });
            LawnStairIDGroups.Add(1866, new int[] { 1866, 1867, 1868, 1869 });
            LawnStairIDGroups.Add(1870, new int[] { 1870, 1871, 1922, 1923 });
            LawnStairIDGroups.Add(1872, new int[] { 1872, 1872, 1872, 1872 });
            LawnStairIDGroups.Add(1873, new int[] { 1873, 1874, 1875, 1876 });
            LawnStairIDGroups.Add(1877, new int[] { 1877, 1878, 1879, 1880 });
            LawnStairIDGroups.Add(1881, new int[] { 1881, 1882, 1883, 1884 });
            LawnStairIDGroups.Add(1885, new int[] { 1885, 1886, 1887, 1888 });
            LawnStairIDGroups.Add(1889, new int[] { 1889, 1890, 1891, 1892 });
            LawnStairIDGroups.Add(1900, new int[] { 1900, 1900, 1900, 1900 });
            LawnStairIDGroups.Add(1901, new int[] { 1901, 1902, 1903, 1904 });
            LawnStairIDGroups.Add(1905, new int[] { 1905, 1906, 1907, 1908 });
            LawnStairIDGroups.Add(1909, new int[] { 1909, 1910, 1911, 1912 });
            LawnStairIDGroups.Add(1913, new int[] { 1913, 1914, 1915, 1916 });
            LawnStairIDGroups.Add(1917, new int[] { 1917, 1918, 1919, 1920 });
            LawnStairIDGroups.Add(1928, new int[] { 1928, 1928, 1928, 1928 });
            LawnStairIDGroups.Add(1929, new int[] { 1929, 1930, 1931, 1932 });
            LawnStairIDGroups.Add(1933, new int[] { 1933, 1934, 1935, 1936 });
            LawnStairIDGroups.Add(1937, new int[] { 1937, 1938, 1939, 1940 });
            LawnStairIDGroups.Add(1941, new int[] { 1941, 1942, 1943, 1944 });
            LawnStairIDGroups.Add(1945, new int[] { 1945, 1946, 1947, 1948 });
            LawnStairIDGroups.Add(1952, new int[] { 1952, 1953, 1954, 2010 });
            LawnStairIDGroups.Add(1955, new int[] { 1955, 1955, 1955, 1955 });
            LawnStairIDGroups.Add(1956, new int[] { 1956, 1957, 1958, 1959 });
            LawnStairIDGroups.Add(1960, new int[] { 1960, 1961, 1962, 1963 });
            LawnStairIDGroups.Add(1964, new int[] { 1964, 1965, 1966, 1967 });
            LawnStairIDGroups.Add(1978, new int[] { 1978, 1978, 1978, 1978 });
            LawnStairIDGroups.Add(1979, new int[] { 1979, 1980, 996, 997 });
            LawnStairIDGroups.Add(1981, new int[] { 1981, 1982, 1981, 1982 });
            LawnStairIDGroups.Add(1983, new int[] { 1983, 1984, 1985, 1986 });
            LawnStairIDGroups.Add(1987, new int[] { 1987, 1988, 1989, 1990 });
            LawnStairIDGroups.Add(998, new int[] { 998, 1991, 995, 1992 });
            LawnStairIDGroups.Add(2015, new int[] { 2015, 2016, 2100, 2166 });
            LawnStairIDGroups.Add(2170, new int[] { 2170, 2171, 2172, 2173 });
        }
        #endregion
    }
}
