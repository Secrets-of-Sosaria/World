using System.Collections.Generic;
using Server.Gumps;
using Server.Items;
using Server.Misc;

namespace Server.Misc
{
    public class ShantyGumpEntry
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

        public ShantyGumpEntry(int itemID, string name, int price, string title)
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

    public class ShantyGumpCategory
    {
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private List<Dictionary<int, ShantyGumpEntry>> m_Pages;
        public List<Dictionary<int, ShantyGumpEntry>> Pages
        {
            get
            {
                if (m_Pages == null)
                {
                    m_Pages = new List<Dictionary<int, ShantyGumpEntry>>();
                }
                return m_Pages;
            }
            set { m_Pages = value; }
        }

        public ShantyGumpCategory(string name)
        {
            Name = name;
            Pages = new List<Dictionary<int, ShantyGumpEntry>>();
        }

        public void AddEntry(ShantyGumpEntry entry)
        {
            if (Pages.Count == 0)
            {
                Pages.Add(new Dictionary<int, ShantyGumpEntry>());
                Pages[0].Add(entry.ItemID, entry);
            }
            else
            {
                if (Pages[Pages.Count - 1].Count >= 12)
                {
                    Pages.Add(new Dictionary<int, ShantyGumpEntry>());
                }

                Pages[Pages.Count - 1].Add(entry.ItemID, entry);
            }
        }

        public ShantyGumpEntry GetEntry(int itemID)
        {
            if (Pages.Count == 0)
            {
                return null;
            }

            foreach (Dictionary<int, ShantyGumpEntry> item in Pages)
            {
                if (item.ContainsKey(itemID) && item[itemID] != null)
                {
                    return item[itemID];
                }
            }

            return null;
        }
    }

    class ShantyRegistry
    {
        public static Dictionary<int, List<ShantyMultiInfo>> ShantyMultiIDs;

        /* This dictionary keeps track of the directions for each primary stair ID
         * When a ShantyStair is double clicked, it changes the ItemID to the next in the list
         * which changes the direction of the stair.
         */
        public static Dictionary<int, int[]> ShantyStairIDGroups;

        public static Dictionary<string, ShantyGumpCategory> Categories = new Dictionary<string, ShantyGumpCategory>();

        public static void RegisterCategory(string category)
        {
            if (Categories == null)
            {
                Categories = new Dictionary<string, ShantyGumpCategory>();
            }

            if (Categories.ContainsKey(category))
            {
                return;
            }

            Categories.Add(category, new ShantyGumpCategory(category));
        }

        public static ShantyGumpCategory GetRegisteredCategory(string category)
        {
            if (!Categories.ContainsKey(category))
            {
                RegisterCategory(category);
            }

            return Categories[category];
        }

        public static void RegisterEntry(string categoryName, int itemID, string name, string title, int price)
        {
            ShantyGumpCategory category = GetRegisteredCategory(categoryName);
            if (category == null)
            {
                return;
            }

            ShantyGumpEntry entry = new ShantyGumpEntry(itemID, name, price, title);

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

			RegisterEntry("Barricade", 0x41, "Brick, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x43, "Brick, East", "wall", 150);
			RegisterEntry("Barricade", 0x44, "Brick, Post", "wall", 150);
			RegisterEntry("Barricade", 0x42, "Brick, South", "wall", 150);
			RegisterEntry("Barricade", 0x2FD, "Dungeon, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x2FF, "Dungeon, East", "wall", 150);
			RegisterEntry("Barricade", 0x300, "Dungeon, Post", "wall", 150);
			RegisterEntry("Barricade", 0x2FE, "Dungeon, South", "wall", 150);
			RegisterEntry("Barricade", 0x9A, "Log, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x9B, "Log, East", "wall", 150);
			RegisterEntry("Barricade", 0x9D, "Log, Post", "wall", 150);
			RegisterEntry("Barricade", 0x9C, "Log, South", "wall", 150);
			RegisterEntry("Barricade", 0x10E, "Marble, Dark Deco, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x110, "Marble, Dark Deco, East", "wall", 150);
			RegisterEntry("Barricade", 0x111, "Marble, Dark Deco, Post", "wall", 150);
			RegisterEntry("Barricade", 0x10F, "Marble, Dark Deco, South", "wall", 150);
			RegisterEntry("Barricade", 0x117, "Marble, Dark, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x119, "Marble, Dark, East", "wall", 150);
			RegisterEntry("Barricade", 0x11A, "Marble, Dark, Post", "wall", 150);
			RegisterEntry("Barricade", 0x118, "Marble, Dark, South", "wall", 150);
			RegisterEntry("Barricade", 0x2B9, "Marble, Light Deco, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x2BB, "Marble, Light Deco, East", "wall", 150);
			RegisterEntry("Barricade", 0x2BC, "Marble, Light Deco, Post", "wall", 150);
			RegisterEntry("Barricade", 0x2BA, "Marble, Light Deco, South", "wall", 150);
			RegisterEntry("Barricade", 0x2B5, "Marble, Light, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x2B7, "Marble, Light, East", "wall", 150);
			RegisterEntry("Barricade", 0x2B8, "Marble, Light, Post", "wall", 150);
			RegisterEntry("Barricade", 0x2B6, "Marble, Light, South", "wall", 150);
			RegisterEntry("Barricade", 0x168, "Sandstone, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x169, "Sandstone, East", "wall", 150);
			RegisterEntry("Barricade", 0x16B, "Sandstone, Post", "wall", 150);
			RegisterEntry("Barricade", 0x16A, "Sandstone, South", "wall", 150);
			RegisterEntry("Barricade", 0x164, "Sandstone, Deco, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x166, "Sandstone, Deco, East", "wall", 150);
			RegisterEntry("Barricade", 0x167, "Sandstone, Deco, Post", "wall", 150);
			RegisterEntry("Barricade", 0x165, "Sandstone, Deco, South", "wall", 150);
			RegisterEntry("Barricade", 0xDC, "Stone, Dark, Corner", "wall", 150);
			RegisterEntry("Barricade", 0xDD, "Stone, Dark, East", "wall", 150);
			RegisterEntry("Barricade", 0xDF, "Stone, Dark, Post", "wall", 150);
			RegisterEntry("Barricade", 0xDE, "Stone, Dark, South", "wall", 150);
			RegisterEntry("Barricade", 0x1E8, "Stone, Gray, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x1EA, "Stone, Gray, East", "wall", 150);
			RegisterEntry("Barricade", 0x1EB, "Stone, Gray, Post", "wall", 150);
			RegisterEntry("Barricade", 0x1E9, "Stone, Gray, South", "wall", 150);
			RegisterEntry("Barricade", 0x6B, "Stone, White, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x69, "Stone, White, East", "wall", 150);
			RegisterEntry("Barricade", 0x6C, "Stone, White, Post", "wall", 150);
			RegisterEntry("Barricade", 0x6A, "Stone, White, South", "wall", 150);
			RegisterEntry("Barricade", 0x2D, "Stone, White-Gray, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x2E, "Stone, White-Gray, East", "wall", 150);
			RegisterEntry("Barricade", 0x30, "Stone, White-Gray, Post", "wall", 150);
			RegisterEntry("Barricade", 0x2F, "Stone, White-Gray, South", "wall", 150);
			RegisterEntry("Barricade", 0x14, "Wood, Dark, Corner", "wall", 150);
			RegisterEntry("Barricade", 0x15, "Wood, Dark, East", "wall", 150);
			RegisterEntry("Barricade", 0x17, "Wood, Dark, Post", "wall", 150);
			RegisterEntry("Barricade", 0x16, "Wood, Dark, South", "wall", 150);
			RegisterEntry("Barricade", 0xBD, "Wood, Light, Corner", "wall", 150);
			RegisterEntry("Barricade", 0xBE, "Wood, Light, East", "wall", 150);
			RegisterEntry("Barricade", 0xC0, "Wood, Light, Post", "wall", 150);
			RegisterEntry("Barricade", 0xBF, "Wood, Light, South", "wall", 150);

			RegisterEntry("Cemetery", 3087, "Barrel Bones", "barrel of bones", 200);
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
			RegisterEntry("Cemetery", 0xEE3, "Web 1", "web", 50);
			RegisterEntry("Cemetery", 0xEE4, "Web 2", "web", 50);
			RegisterEntry("Cemetery", 0xEE5, "Web 3", "web", 50);
			RegisterEntry("Cemetery", 0xEE6, "Web 3", "web", 50);

			RegisterEntry("Doors", 1679, "Barred Door E-N", "door", 200);
			RegisterEntry("Doors", 1677, "Barred Door E-S", "door", 200);
			RegisterEntry("Doors", 1671, "Barred Door S-E", "door", 200);
			RegisterEntry("Doors", 1669, "Barred Door S-W", "door", 200);
			RegisterEntry("Doors", 8183, "Barred Short Door E-N", "door", 200);
			RegisterEntry("Doors", 8181, "Barred Short Door E-S", "door", 200);
			RegisterEntry("Doors", 8175, "Barred Short Door S-E", "door", 200);
			RegisterEntry("Doors", 8173, "Barred Short Door S-W", "door", 200);
			RegisterEntry("Doors", 1743, "Metal Door E-N", "door", 200);
			RegisterEntry("Doors", 1741, "Metal Door E-S", "door", 200);
			RegisterEntry("Doors", 1735, "Metal Door S-E", "door", 200);
			RegisterEntry("Doors", 1733, "Metal Door S-W", "door", 200);
			RegisterEntry("Doors", 1663, "Metal Door Short E-N", "door", 200);
			RegisterEntry("Doors", 1661, "Metal Door Short E-S", "door", 200);
			RegisterEntry("Doors", 1655, "Metal Door Short S-E", "door", 200);
			RegisterEntry("Doors", 1653, "Metal Door Short S-W", "door", 200);
			RegisterEntry("Doors", 1695, "Rattan Door E-N", "door", 200);
			RegisterEntry("Doors", 1693, "Rattan Door E-S", "door", 200);
			RegisterEntry("Doors", 1687, "Rattan Door S-E", "door", 200);
			RegisterEntry("Doors", 1685, "Rattan Door S-W", "door", 200);
			RegisterEntry("Doors", 1727, "Wood Door E-N", "door", 200);
			RegisterEntry("Doors", 1725, "Wood Door E-S", "door", 200);
			RegisterEntry("Doors", 1719, "Wood Door S-E", "door", 200);
			RegisterEntry("Doors", 1717, "Wood Door S-W", "door", 200);
			RegisterEntry("Doors", 1711, "Wood Dark Door E-N", "door", 200);
			RegisterEntry("Doors", 1709, "Wood Dark Door E-S", "door", 200);
			RegisterEntry("Doors", 1703, "Wood Dark Door S-E", "door", 200);
			RegisterEntry("Doors", 1701, "Wood Dark Door S-W", "door", 200);
			RegisterEntry("Doors", 0x6DF, "Wood Light Door E-N", "door", 200);
			RegisterEntry("Doors", 0x6DD, "Wood Light Door E-S", "door", 200);
			RegisterEntry("Doors", 0x6D7, "Wood Light Door S-E", "door", 200);
			RegisterEntry("Doors", 0x6D5, "Wood Light Door S-W", "door", 200);
			RegisterEntry("Doors", 1775, "Wood Iron Door E-N", "door", 200);
			RegisterEntry("Doors", 1773, "Wood Iron Door E-S", "door", 200);
			RegisterEntry("Doors", 1767, "Wood Iron Door S-E", "door", 200);
			RegisterEntry("Doors", 1765, "Wood Iron Door S-W", "door", 200);

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

			//For adding new gates/doors, please see ShantyDoor.cs in the Items folder for examples.

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

			RegisterEntry("Items", 0x45A, "Bench Marble East", "bench", 100);
			RegisterEntry("Items", 0x459, "Bench Marble South", "bench", 100);
			RegisterEntry("Items", 0x45C, "Bench Sandstone East", "bench", 100);
			RegisterEntry("Items", 0x45B, "Bench Sandstone South", "bench", 100);
			RegisterEntry("Items", 0xB2D, "Bench Wooden East", "bench", 100);
			RegisterEntry("Items", 0xB2C, "Bench Wooden South", "bench", 100);
			RegisterEntry("Items", 21281, "Bonfire Lit", "bonfire", 350);
			RegisterEntry("Items", 21280, "Bonfire Unlit", "pile of wood", 350);
			RegisterEntry("Items", 21408, "Bonfire Social", "huge fire", 3500);
			RegisterEntry("Items", 8885, "Bridge Board Dark East", "bridge", 100);
			RegisterEntry("Items", 8886, "Bridge Board Dark South", "bridge", 100);
			RegisterEntry("Items", 8883, "Bridge Board Light East", "bridge", 100);
			RegisterEntry("Items", 8884, "Bridge Board Light South", "bridge", 100);
			RegisterEntry("Items", 749, "Bridge Log East", "bridge", 100);
			RegisterEntry("Items", 750, "Bridge Log South", "bridge", 100);
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
			RegisterEntry("Items", 25667, "Ladder North", "ladder", 2000);
			RegisterEntry("Items", 25668, "Ladder West", "ladder", 2000);
			RegisterEntry("Items", 7135, "Logs East", "logs", 50);
			RegisterEntry("Items", 7138, "Logs South", "logs", 50);
			RegisterEntry("Items", 1981, "Platform 1", "platform", 50);
			RegisterEntry("Items", 1983, "Platform 2", "platform", 50);
			RegisterEntry("Items", 1987, "Platform 3", "platform", 50);
			RegisterEntry("Items", 2327, "Stone Step Dark", "stone step", 100);
			RegisterEntry("Items", 2325, "Stone Step Light", "stone step", 100);
			RegisterEntry("Items", 1, "Telescope", "telescope", 10000);
			RegisterEntry("Items", 705, "Trapdoor East", "trapdoor", 2000);
			RegisterEntry("Items", 708, "Trapdoor South", "trapdoor", 2000);

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

			RegisterEntry("Walls", 0x33, "Brick, Corner", "wall", 200);
			RegisterEntry("Walls", 0x35, "Brick, East", "wall", 200);
			RegisterEntry("Walls", 0x36, "Brick, Post", "wall", 200);
			RegisterEntry("Walls", 0x34, "Brick, South", "wall", 200);
			RegisterEntry("Walls", 0x243, "Dungeon, Corner", "wall", 200);
			RegisterEntry("Walls", 0x242, "Dungeon, East", "wall", 200);
			RegisterEntry("Walls", 0x244, "Dungeon, Post", "wall", 200);
			RegisterEntry("Walls", 0x241, "Dungeon, South", "wall", 200);
			RegisterEntry("Walls", 0x1B6, "Hide, Corner", "wall", 200);
			RegisterEntry("Walls", 0x1B7, "Hide, East", "wall", 200);
			RegisterEntry("Walls", 0x1B9, "Hide, Post", "wall", 200);
			RegisterEntry("Walls", 0x1B8, "Hide, South", "wall", 200);
			RegisterEntry("Walls", 0x90, "Log, Corner", "wall", 200);
			RegisterEntry("Walls", 0x91, "Log, East", "wall", 200);
			RegisterEntry("Walls", 0x93, "Log, Post", "wall", 200);
			RegisterEntry("Walls", 0x92, "Log, South", "wall", 200);
			RegisterEntry("Walls", 0x226, "Log, Small, Corner", "wall", 200);
			RegisterEntry("Walls", 0x227, "Log, Small, East", "wall", 200);
			RegisterEntry("Walls", 0x229, "Log, Small, Post", "wall", 200);
			RegisterEntry("Walls", 0x228, "Log, Small, South", "wall", 200);
			RegisterEntry("Walls", 0xF8, "Marble, Dark Deco, Corner", "wall", 200);
			RegisterEntry("Walls", 0xFA, "Marble, Dark Deco, East", "wall", 200);
			RegisterEntry("Walls", 0xFB, "Marble, Dark Deco, Post", "wall", 200);
			RegisterEntry("Walls", 0xF9, "Marble, Dark Deco, South", "wall", 200);
			RegisterEntry("Walls", 0x104, "Marble, Dark, Corner", "wall", 200);
			RegisterEntry("Walls", 0x106, "Marble, Dark, East", "wall", 200);
			RegisterEntry("Walls", 0x107, "Marble, Dark, Post", "wall", 200);
			RegisterEntry("Walls", 0x105, "Marble, Dark, South", "wall", 200);
			RegisterEntry("Walls", 0x297, "Marble, Light Deco, Corner", "wall", 200);
			RegisterEntry("Walls", 0x299, "Marble, Light Deco, East", "wall", 200);
			RegisterEntry("Walls", 0x29A, "Marble, Light Deco, Post", "wall", 200);
			RegisterEntry("Walls", 0x298, "Marble, Light Deco, South", "wall", 200);
			RegisterEntry("Walls", 0x29D, "Marble, Light Fancy, Corner", "wall", 200);
			RegisterEntry("Walls", 0x29F, "Marble, Light Fancy, East", "wall", 200);
			RegisterEntry("Walls", 0x2A0, "Marble, Light Fancy, Post", "wall", 200);
			RegisterEntry("Walls", 0x29E, "Marble, Light Fancy, South", "wall", 200);
			RegisterEntry("Walls", 0x291, "Marble, Light, Corner", "wall", 200);
			RegisterEntry("Walls", 0x293, "Marble, Light, East", "wall", 200);
			RegisterEntry("Walls", 0x294, "Marble, Light, Post", "wall", 200);
			RegisterEntry("Walls", 0x292, "Marble, Light, South", "wall", 200);
			RegisterEntry("Walls", 0x1FF, "Plaster, Brick, Corner", "wall", 200);
			RegisterEntry("Walls", 0x201, "Plaster, Brick, East", "wall", 200);
			RegisterEntry("Walls", 0x202, "Plaster, Brick, Post", "wall", 200);
			RegisterEntry("Walls", 0x200, "Plaster, Brick, South", "wall", 200);
			RegisterEntry("Walls", 0x135, "Plaster, Corner", "wall", 200);
			RegisterEntry("Walls", 0x137, "Plaster, East", "wall", 200);
			RegisterEntry("Walls", 0x12A, "Plaster, Post", "wall", 200);
			RegisterEntry("Walls", 0x136, "Plaster, South", "wall", 200);
			RegisterEntry("Walls", 0x132, "Plaster, Wood, Corner", "wall", 200);
			RegisterEntry("Walls", 0x134, "Plaster, Wood, East", "wall", 200);
			RegisterEntry("Walls", 0x133, "Plaster, Wood, South", "wall", 200);
			RegisterEntry("Walls", 0x127, "Plaster, Wooded, Corner", "wall", 200);
			RegisterEntry("Walls", 0x129, "Plaster, Wooded, East", "wall", 200);
			RegisterEntry("Walls", 0x128, "Plaster, Wooded, South", "wall", 200);
			RegisterEntry("Walls", 0x1A5, "Rattan, Corner", "wall", 200);
			RegisterEntry("Walls", 0x1A9, "Rattan, East", "wall", 200);
			RegisterEntry("Walls", 0x1A8, "Rattan, Post", "wall", 200);
			RegisterEntry("Walls", 0x1A6, "Rattan, South", "wall", 200);
			RegisterEntry("Walls", 0x15E, "Sandstone, Corner", "wall", 200);
			RegisterEntry("Walls", 0x15F, "Sandstone, East", "wall", 200);
			RegisterEntry("Walls", 0x161, "Sandstone, Post", "wall", 200);
			RegisterEntry("Walls", 0x160, "Sandstone, South", "wall", 200);
			RegisterEntry("Walls", 0x24C, "Sandstone, Carved, Corner", "wall", 200);
			RegisterEntry("Walls", 0x24E, "Sandstone, Carved, East", "wall", 200);
			RegisterEntry("Walls", 0x25B, "Sandstone, Carved, Post", "wall", 200);
			RegisterEntry("Walls", 0x24D, "Sandstone, Carved, South", "wall", 200);
			RegisterEntry("Walls", 0x158, "Sandstone, Deco, Corner", "wall", 200);
			RegisterEntry("Walls", 0x15A, "Sandstone, Deco, East", "wall", 200);
			RegisterEntry("Walls", 0x15B, "Sandstone, Deco, Post", "wall", 200);
			RegisterEntry("Walls", 0x159, "Sandstone, Deco, South", "wall", 200);
			RegisterEntry("Walls", 0x24F, "Sandstone, Fancy, Corner", "wall", 200);
			RegisterEntry("Walls", 0x251, "Sandstone, Fancy, East", "wall", 200);
			RegisterEntry("Walls", 0x258, "Sandstone, Fancy, Post", "wall", 200);
			RegisterEntry("Walls", 0x250, "Sandstone, Fancy, South", "wall", 200);
			RegisterEntry("Walls", 0x255, "Sandstone, Ornate, Corner", "wall", 200);
			RegisterEntry("Walls", 0x257, "Sandstone, Ornate, East", "wall", 200);
			RegisterEntry("Walls", 0x259, "Sandstone, Ornate, Post", "wall", 200);
			RegisterEntry("Walls", 0x256, "Sandstone, Ornate, South", "wall", 200);
			RegisterEntry("Walls", 0x3C7, "Stone, Dark Sand, Corner", "wall", 200);
			RegisterEntry("Walls", 0x3C9, "Stone, Dark Sand, East", "wall", 200);
			RegisterEntry("Walls", 0x3CA, "Stone, Dark Sand, Post", "wall", 200);
			RegisterEntry("Walls", 0x3C8, "Stone, Dark Sand, South", "wall", 200);
			RegisterEntry("Walls", 0xC7, "Stone, Dark, Corner", "wall", 200);
			RegisterEntry("Walls", 0xC9, "Stone, Dark, East", "wall", 200);
			RegisterEntry("Walls", 0xCC, "Stone, Dark, Post", "wall", 200);
			RegisterEntry("Walls", 0xC8, "Stone, Dark, South", "wall", 200);
			RegisterEntry("Walls", 0x1CF, "Stone, Gray, Corner", "wall", 200);
			RegisterEntry("Walls", 0x1D1, "Stone, Gray, East", "wall", 200);
			RegisterEntry("Walls", 0x1D2, "Stone, Gray, Post", "wall", 200);
			RegisterEntry("Walls", 0x1D0, "Stone, Gray, South", "wall", 200);
			RegisterEntry("Walls", 0x3CB, "Stone, Light Sand, Corner", "wall", 200);
			RegisterEntry("Walls", 0x3CD, "Stone, Light Sand, East", "wall", 200);
			RegisterEntry("Walls", 0x3CE, "Stone, Light Sand, Post", "wall", 200);
			RegisterEntry("Walls", 0x3CC, "Stone, Light Sand, South", "wall", 200);
			RegisterEntry("Walls", 0x123A, "Stone, Spider East 1", "wall", 200);
			RegisterEntry("Walls", 0x123B, "Stone, Spider East 2", "wall", 200);
			RegisterEntry("Walls", 0x123C, "Stone, Spider East 3", "wall", 200);
			RegisterEntry("Walls", 0x1237, "Stone, Spider South 1", "wall", 200);
			RegisterEntry("Walls", 0x1238, "Stone, Spider South 2", "wall", 200);
			RegisterEntry("Walls", 0x1239, "Stone, Spider South 3", "wall", 200);
			RegisterEntry("Walls", 0x59, "Stone, White, Corner", "wall", 200);
			RegisterEntry("Walls", 0x57, "Stone, White, East", "wall", 200);
			RegisterEntry("Walls", 0x5A, "Stone, White, Post", "wall", 200);
			RegisterEntry("Walls", 0x58, "Stone, White, South", "wall", 200);
			RegisterEntry("Walls", 0x1A, "Stone, White-Gray, Corner", "wall", 200);
			RegisterEntry("Walls", 0x1B, "Stone, White-Gray, East", "wall", 200);
			RegisterEntry("Walls", 0x1D, "Stone, White-Gray, Post", "wall", 200);
			RegisterEntry("Walls", 0x1C, "Stone, White-Gray, South", "wall", 200);
			RegisterEntry("Walls", 0x6, "Wood, Dark, Corner", "wall", 200);
			RegisterEntry("Walls", 0x8, "Wood, Dark, East", "wall", 200);
			RegisterEntry("Walls", 0x9, "Wood, Dark, Post", "wall", 200);
			RegisterEntry("Walls", 0x7, "Wood, Dark, South", "wall", 200);
			RegisterEntry("Walls", 0xA6, "Wood, Light, Corner", "wall", 200);
			RegisterEntry("Walls", 0xA7, "Wood, Light, East", "wall", 200);
			RegisterEntry("Walls", 0xA9, "Wood, Light, Post", "wall", 200);
			RegisterEntry("Walls", 0xA8, "Wood, Light, South", "wall", 200);

			RegisterEntry("Water", 13422, "Water", "water", 100);
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
            ShantyMultiIDs = new Dictionary<int, List<ShantyMultiInfo>>();
            int locationID;
            List<ShantyMultiInfo> infos;



            #region Tables
            infos = new List<ShantyMultiInfo>();
            locationID = 2938;
			infos.Add(new ShantyMultiInfo(2912, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(2913, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(2911, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(2934, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(2933, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(2912, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(2913, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(2911, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 2957;
			infos.Add(new ShantyMultiInfo(2918, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(2953, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(2918, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(2919, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(2919, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(2917, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(2952, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(2917, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion



            #region Pentagrams
            //Altar
            infos = new List<ShantyMultiInfo>();
            locationID = 4630;
			infos.Add(new ShantyMultiInfo(4622, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4629, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4628, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(4623, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(4627, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(4624, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4625, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4626, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //Red Pentagram
            infos = new List<ShantyMultiInfo>();
            locationID = 4074;
			infos.Add(new ShantyMultiInfo(4071, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4070, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4073, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(4072, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(4076, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(4075, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4078, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4077, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //Dark Pentagram
            infos = new List<ShantyMultiInfo>();
            locationID = 1607;
			infos.Add(new ShantyMultiInfo(1599, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(1606, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(1605, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(1600, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(1604, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(1601, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(1602, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(1603, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //Red Pentagram Summoning
            infos = new List<ShantyMultiInfo>();
            locationID = 8602;
			infos.Add(new ShantyMultiInfo(4071, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4070, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4073, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(4072, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(4076, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(4075, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(4078, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(4077, new Point3D(1, 1, 0)));
			infos.Add(new ShantyMultiInfo(4074, new Point3D(0, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //Dark Pentagram Summoning
            infos = new List<ShantyMultiInfo>();
            locationID = 8603;
			infos.Add(new ShantyMultiInfo(1599, new Point3D(-1, -1, 0)));
			infos.Add(new ShantyMultiInfo(1606, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(1605, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(1600, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(1604, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(1601, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(1602, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(1603, new Point3D(1, 1, 0)));
			infos.Add(new ShantyMultiInfo(1607, new Point3D(0, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);
			#endregion



			#region Telescope
            infos = new List<ShantyMultiInfo>();
            locationID = 1;
			infos.Add(new ShantyMultiInfo(0x1494, new Point3D(0, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x145B, new Point3D(0, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x145A, new Point3D(0, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1495, new Point3D(1, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x145C, new Point3D(1, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x145D, new Point3D(1, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x1496, new Point3D(2, 3, 0)));
			infos.Add(new ShantyMultiInfo(0x1499, new Point3D(2, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x148E, new Point3D(2, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1493, new Point3D(2, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1492, new Point3D(2, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x145E, new Point3D(2, 9, 0)));
			infos.Add(new ShantyMultiInfo(0x1459, new Point3D(2,10, 0)));
			infos.Add(new ShantyMultiInfo(0x1497, new Point3D(3, 2, 0)));
			infos.Add(new ShantyMultiInfo(0x145F, new Point3D(3, 9, 0)));
			infos.Add(new ShantyMultiInfo(0x1461, new Point3D(3,10, 0)));
			infos.Add(new ShantyMultiInfo(0x149A, new Point3D(4, 1, 0)));
			infos.Add(new ShantyMultiInfo(0x1498, new Point3D(4, 2, 0)));
			infos.Add(new ShantyMultiInfo(0x148F, new Point3D(4, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x148D, new Point3D(4, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1488, new Point3D(4, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x1460, new Point3D(4, 9, 0)));
			infos.Add(new ShantyMultiInfo(0x1462, new Point3D(4,10, 0)));
			infos.Add(new ShantyMultiInfo(0x147D, new Point3D(5, 0, 0)));
			infos.Add(new ShantyMultiInfo(0x1490, new Point3D(5, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x148B, new Point3D(5, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x148A, new Point3D(5, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1486, new Point3D(5, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1485, new Point3D(5, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x147C, new Point3D(6, 0, 0)));
			infos.Add(new ShantyMultiInfo(0x1491, new Point3D(6, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x148C, new Point3D(6, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x1489, new Point3D(6, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1487, new Point3D(6, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1484, new Point3D(6, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x1463, new Point3D(6,10, 0)));
			infos.Add(new ShantyMultiInfo(0x147B, new Point3D(7, 0, 0)));
			infos.Add(new ShantyMultiInfo(0x147F, new Point3D(7, 3, 0)));
			infos.Add(new ShantyMultiInfo(0x1480, new Point3D(7, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x1482, new Point3D(7, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x1469, new Point3D(7, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1468, new Point3D(7, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1465, new Point3D(7, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x1464, new Point3D(7, 9, 0)));
			infos.Add(new ShantyMultiInfo(0x147A, new Point3D(8, 0, 0)));
			infos.Add(new ShantyMultiInfo(0x1479, new Point3D(8, 1, 0)));
			infos.Add(new ShantyMultiInfo(0x1477, new Point3D(8, 2, 0)));
			infos.Add(new ShantyMultiInfo(0x147E, new Point3D(8, 3, 0)));
			infos.Add(new ShantyMultiInfo(0x1481, new Point3D(8, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x1483, new Point3D(8, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x146A, new Point3D(8, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x1467, new Point3D(8, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1466, new Point3D(8, 8, 0)));
			infos.Add(new ShantyMultiInfo(0x1478, new Point3D(9, 1, 0)));
			infos.Add(new ShantyMultiInfo(0x1475, new Point3D(9, 2, 0)));
			infos.Add(new ShantyMultiInfo(0x1474, new Point3D(9, 3, 0)));
			infos.Add(new ShantyMultiInfo(0x146F, new Point3D(9, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x146E, new Point3D(9, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x146D, new Point3D(9, 6, 0)));
			infos.Add(new ShantyMultiInfo(0x146B, new Point3D(9, 7, 0)));
			infos.Add(new ShantyMultiInfo(0x1476, new Point3D(10, 2, 0)));
			infos.Add(new ShantyMultiInfo(0x1473, new Point3D(10, 3, 0)));
			infos.Add(new ShantyMultiInfo(0x1470, new Point3D(10, 4, 0)));
			infos.Add(new ShantyMultiInfo(0x1471, new Point3D(10, 5, 0)));
			infos.Add(new ShantyMultiInfo(0x1472, new Point3D(10, 6, 0)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion



			#region Skull Pile
            infos = new List<ShantyMultiInfo>();
            locationID = 6875;
			infos.Add(new ShantyMultiInfo(6877, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(6878, new Point3D(2, -1, 0)));
			infos.Add(new ShantyMultiInfo(6874, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(6873, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(6876, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(6872, new Point3D(1, 1, 0)));
			infos.Add(new ShantyMultiInfo(6879, new Point3D(2, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion



			#region Tombs
            infos = new List<ShantyMultiInfo>();
            locationID = 7206;
			infos.Add(new ShantyMultiInfo(7205, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7204, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(7203, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7207, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7202, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7219;
			infos.Add(new ShantyMultiInfo(7218, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7220, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7217, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(7216, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7215, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7251;
			infos.Add(new ShantyMultiInfo(7250, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7252, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7240;
			infos.Add(new ShantyMultiInfo(7239, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7241, new Point3D(1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7237;
			infos.Add(new ShantyMultiInfo(7236, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7238, new Point3D(1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7254;
			infos.Add(new ShantyMultiInfo(7255, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7253, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7339;
			infos.Add(new ShantyMultiInfo(7338, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7340, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7337, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(7336, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7335, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7316;
			infos.Add(new ShantyMultiInfo(7315, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7314, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(7313, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7317, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7312, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7325;
			infos.Add(new ShantyMultiInfo(7324, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(7326, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7323, new Point3D(1, -1, 0)));
			infos.Add(new ShantyMultiInfo(7322, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7321, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7291;
			infos.Add(new ShantyMultiInfo(7290, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7289, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(7288, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7292, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7287, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7268;
			infos.Add(new ShantyMultiInfo(7267, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7266, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(7265, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7269, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7264, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 7277;
			infos.Add(new ShantyMultiInfo(7276, new Point3D(-1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7275, new Point3D(-1, 1, 0)));
			infos.Add(new ShantyMultiInfo(7274, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(7278, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(7273, new Point3D(1, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 12990;
			infos.Add(new ShantyMultiInfo(12988, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 12994;
			infos.Add(new ShantyMultiInfo(13003, new Point3D(1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 12992;
			infos.Add(new ShantyMultiInfo(12990, new Point3D(0, -1, 0)));
			infos.Add(new ShantyMultiInfo(12988, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 13005;
			infos.Add(new ShantyMultiInfo(13003, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(12994, new Point3D(-1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 8605;
			infos.Add(new ShantyMultiInfo(12991, new Point3D(0, 1, 0)));
			infos.Add(new ShantyMultiInfo(12990, new Point3D(0, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 8604;
			infos.Add(new ShantyMultiInfo(13006, new Point3D(1, 0, 0)));
			infos.Add(new ShantyMultiInfo(12994, new Point3D(0, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 12993;
			infos.Add(new ShantyMultiInfo(12988, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 13004;
			infos.Add(new ShantyMultiInfo(13003, new Point3D(1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 8600;
			infos.Add(new ShantyMultiInfo(12993, new Point3D(0, 0, 0)));
			infos.Add(new ShantyMultiInfo(12991, new Point3D(0, 1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 8601;
			infos.Add(new ShantyMultiInfo(13004, new Point3D(0, 0, 0)));
			infos.Add(new ShantyMultiInfo(13006, new Point3D(1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);
			#endregion



            #region Graves
            //Restless
            infos = new List<ShantyMultiInfo>();
            locationID = 13335;
            infos.Add(new ShantyMultiInfo(3809, new Point3D(0, -1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //NS
            infos = new List<ShantyMultiInfo>();
            locationID = 3807;
            infos.Add(new ShantyMultiInfo(3809, new Point3D(0, -1, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //EW
            infos = new List<ShantyMultiInfo>();
            locationID = 3808;
            infos.Add(new ShantyMultiInfo(3810, new Point3D(-1, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion



            #region Hammock
            //NS
            infos = new List<ShantyMultiInfo>();
            locationID = 4592;
            infos.Add(new ShantyMultiInfo(4593, new Point3D(2, 0, 0)));
            ShantyMultiIDs.Add(locationID, infos);

            //EW
            infos = new List<ShantyMultiInfo>();
            locationID = 4595;
            infos.Add(new ShantyMultiInfo(4594, new Point3D(0, 2, 0)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion



            #region Sparkles
            infos = new List<ShantyMultiInfo>();
            locationID = 0x373A;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x3039;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x374A;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x375A;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x376A;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x5469;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);

            infos = new List<ShantyMultiInfo>();
            locationID = 0x54E1;
            infos.Add(new ShantyMultiInfo(0x17F3, new Point3D(0, 0, 5)));
            ShantyMultiIDs.Add(locationID, infos);
            #endregion
        }

        #region ShantyStairIDGroups

        public static void RegisterStairs()
        {
            ShantyStairIDGroups = new Dictionary<int, int[]>();

            ShantyStairIDGroups.Add(1006, new int[] { 1006, 1006, 1006, 1006 });
            ShantyStairIDGroups.Add(1007, new int[] { 1007, 1008, 1009, 1010 });
            ShantyStairIDGroups.Add(1011, new int[] { 1011, 1012, 1013, 1014 });
            ShantyStairIDGroups.Add(1015, new int[] { 1015, 1016, 1017, 1018 });
            ShantyStairIDGroups.Add(1019, new int[] { 1019, 1020, 1021, 1022 });
            ShantyStairIDGroups.Add(1023, new int[] { 1023, 1024, 1025, 1026 });
            ShantyStairIDGroups.Add(1801, new int[] { 1801, 1801, 1801, 1801 });
            ShantyStairIDGroups.Add(1802, new int[] { 1802, 1803, 1804, 1805 });
            ShantyStairIDGroups.Add(1806, new int[] { 1806, 1807, 1808, 1809 });
            ShantyStairIDGroups.Add(1810, new int[] { 1810, 1811, 1812, 1813 });
            ShantyStairIDGroups.Add(1814, new int[] { 1814, 1815, 1816, 1817 });
            ShantyStairIDGroups.Add(1818, new int[] { 1818, 1819, 1820, 1821 });
            ShantyStairIDGroups.Add(1822, new int[] { 1822, 1822, 1822, 1822 });
            ShantyStairIDGroups.Add(1823, new int[] { 1823, 1846, 1847, 1865 });
            ShantyStairIDGroups.Add(1825, new int[] { 1825, 1825, 1825, 1825 });
            ShantyStairIDGroups.Add(1826, new int[] { 1826, 1827, 1828, 1829 });
            ShantyStairIDGroups.Add(1830, new int[] { 1830, 1831, 1832, 1833 });
            ShantyStairIDGroups.Add(1834, new int[] { 1834, 1835, 1836, 1837 });
            ShantyStairIDGroups.Add(1838, new int[] { 1838, 1839, 1840, 1841 });
            ShantyStairIDGroups.Add(1842, new int[] { 1842, 1843, 1844, 1845 });
            ShantyStairIDGroups.Add(1848, new int[] { 1848, 1848, 1848, 1848 });
            ShantyStairIDGroups.Add(1849, new int[] { 1849, 1850, 1851, 1852 });
            ShantyStairIDGroups.Add(1853, new int[] { 1853, 1854, 1855, 1856 });
            ShantyStairIDGroups.Add(1857, new int[] { 1857, 1858, 1859, 1860 });
            ShantyStairIDGroups.Add(1861, new int[] { 1861, 1862, 1863, 1864 });
            ShantyStairIDGroups.Add(1866, new int[] { 1866, 1867, 1868, 1869 });
            ShantyStairIDGroups.Add(1870, new int[] { 1870, 1871, 1922, 1923 });
            ShantyStairIDGroups.Add(1872, new int[] { 1872, 1872, 1872, 1872 });
            ShantyStairIDGroups.Add(1873, new int[] { 1873, 1874, 1875, 1876 });
            ShantyStairIDGroups.Add(1877, new int[] { 1877, 1878, 1879, 1880 });
            ShantyStairIDGroups.Add(1881, new int[] { 1881, 1882, 1883, 1884 });
            ShantyStairIDGroups.Add(1885, new int[] { 1885, 1886, 1887, 1888 });
            ShantyStairIDGroups.Add(1889, new int[] { 1889, 1890, 1891, 1892 });
            ShantyStairIDGroups.Add(1900, new int[] { 1900, 1900, 1900, 1900 });
            ShantyStairIDGroups.Add(1901, new int[] { 1901, 1902, 1903, 1904 });
            ShantyStairIDGroups.Add(1905, new int[] { 1905, 1906, 1907, 1908 });
            ShantyStairIDGroups.Add(1909, new int[] { 1909, 1910, 1911, 1912 });
            ShantyStairIDGroups.Add(1913, new int[] { 1913, 1914, 1915, 1916 });
            ShantyStairIDGroups.Add(1917, new int[] { 1917, 1918, 1919, 1920 });
            ShantyStairIDGroups.Add(1928, new int[] { 1928, 1928, 1928, 1928 });
            ShantyStairIDGroups.Add(1929, new int[] { 1929, 1930, 1931, 1932 });
            ShantyStairIDGroups.Add(1933, new int[] { 1933, 1934, 1935, 1936 });
            ShantyStairIDGroups.Add(1937, new int[] { 1937, 1938, 1939, 1940 });
            ShantyStairIDGroups.Add(1941, new int[] { 1941, 1942, 1943, 1944 });
            ShantyStairIDGroups.Add(1945, new int[] { 1945, 1946, 1947, 1948 });
            ShantyStairIDGroups.Add(1952, new int[] { 1952, 1953, 1954, 2010 });
            ShantyStairIDGroups.Add(1955, new int[] { 1955, 1955, 1955, 1955 });
            ShantyStairIDGroups.Add(1956, new int[] { 1956, 1957, 1958, 1959 });
            ShantyStairIDGroups.Add(1960, new int[] { 1960, 1961, 1962, 1963 });
            ShantyStairIDGroups.Add(1964, new int[] { 1964, 1965, 1966, 1967 });
            ShantyStairIDGroups.Add(1978, new int[] { 1978, 1978, 1978, 1978 });
            ShantyStairIDGroups.Add(1979, new int[] { 1979, 1980, 996, 997 });
            ShantyStairIDGroups.Add(1981, new int[] { 1981, 1982, 1981, 1982 });
            ShantyStairIDGroups.Add(1983, new int[] { 1983, 1984, 1985, 1986 });
            ShantyStairIDGroups.Add(1987, new int[] { 1987, 1988, 1989, 1990 });
            ShantyStairIDGroups.Add(998, new int[] { 998, 1991, 995, 1992 });
            ShantyStairIDGroups.Add(2015, new int[] { 2015, 2016, 2100, 2166 });
            ShantyStairIDGroups.Add(2170, new int[] { 2170, 2171, 2172, 2173 });
        }
        #endregion
    }
}
