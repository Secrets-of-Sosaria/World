using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Misc
{
	class ContainerFunctions
	{
		public static int LockTheContainer(int level, LockableContainer box, int containerType)
		{
			if (level > 0)
			{
				AssignTrapType(level, box);
				box.TrapPower = (level * Utility.RandomMinMax(20, 30)) + Utility.RandomMinMax(1, 10);
				box.TrapLevel = Math.Max(0, Math.Min(level, 90));
			}

			bool canLock = (containerType < 7 || containerType == 16 || containerType == 18);
			if (!canLock)
			{
				ClearLock(box);
				return 0;
			}

			box.Locked = (Utility.Random(3) == 0) || box is TreasureMapChest || box is ParagonChest;
			box.LockLevel = Math.Max(0, Math.Min(90, 1 + (level * 10)));
			box.MaxLockLevel = box.LockLevel + 20;
			box.RequiredSkill = box.LockLevel;

			return 1;
		}

		private static void AssignTrapType(int level, LockableContainer box)
		{
			int trapRoll = Utility.Random(9);
			switch (trapRoll)
			{
				case 0: box.TrapType = TrapType.DartTrap; break;
				case 2: box.TrapType = TrapType.ExplosionTrap; break;
				case 3: box.TrapType = TrapType.MagicTrap; break;
				case 4: box.TrapType = TrapType.PoisonTrap; break;
				default: box.TrapType = TrapType.None; break;
			}

			if (box is TreasureMapChest || (box.Catalog == Catalogs.SciFi && box.TrapType != TrapType.None))
				box.TrapType = TrapType.ExplosionTrap;

			if (box is ParagonChest)
			{
				switch (Utility.Random(4))
				{
					case 0: box.TrapType = TrapType.DartTrap; break;
					case 1: box.TrapType = TrapType.ExplosionTrap; break;
					case 2: box.TrapType = TrapType.MagicTrap; break;
					case 3: box.TrapType = TrapType.PoisonTrap; break;
				}
			}
		}

		private static void ClearLock(LockableContainer box)
		{
			box.Locked = false;
			box.LockLevel = 0;
			box.MaxLockLevel = 0;
			box.RequiredSkill = 0;
		}

		public static void FillTheContainer(int level, LockableContainer box, Mobile opener)
		{
			level = LootPackChange.ScaleLevel(level);
			LootPackChange.AddGoldToContainer(0, box, opener, level);
			GenerateTreasure(level, box, opener);
		}

		public static void GenerateTreasure(int level, LockableContainer box, Mobile from)
		{
			if (from.Land == Land.SkaraBrae && Utility.Random(20) == 0)
				box.DropItem(new BardsTaleNote());

			int fill = level + Utility.Random(3);
			for (int i = 0; i < LootPackChange.FillCycle(fill); i++)
			{
				int var = Math.Max(1, level - 4);
				int roll = Utility.RandomMinMax(var, level);
				AddTreasure(level, box, from, GetLootPackForLevel(roll));
			}
		}

		private static LootPack GetLootPackForLevel(int roll)
		{
			switch (roll)
			{
				case 1: return LootPack.TreasurePoor;
				case 2: return Utility.RandomBool() ? LootPack.TreasurePoor : LootPack.TreasureMeager;
				case 3: return Utility.RandomBool() ? LootPack.TreasureMeager : LootPack.TreasureAverage;
				case 4: return Utility.RandomBool() ? LootPack.TreasureAverage : LootPack.TreasureRich;
				case 5: return LootPack.TreasureRich;
				case 6: return Utility.RandomBool() ? LootPack.TreasureRich : LootPack.TreasureFilthyRich;
				case 7: return LootPack.TreasureFilthyRich;
				case 8: return Utility.RandomBool() ? LootPack.TreasureFilthyRich : LootPack.TreasureUltraRich;
				case 9: return LootPack.TreasureUltraRich;
				case 10: return Utility.RandomBool() ? LootPack.TreasureUltraRich : LootPack.TreasureMegaRich;
				default: return LootPack.TreasureMegaRich;
			}
		}

		public static void AddTreasure(int level, LockableContainer box, Mobile from, LootPack pack)
		{
			pack.Generate(from, box, false, from.Luck, level);

			if (!(box is TreasureMapChest) && !(box is GraveChest) && !(box is ParagonChest)
				&& !(box is SunkenChest) && !(box is BuriedChest) && !(box is BuriedBody))
			{
				for (int i = 0; i < level; i++)
				{
					if (Utility.Random(4) == 0 && MySettings.S_LootChance > Utility.Random(100))
					{
						Item item = Loot.RandomItem(from, level);
						item = LootPackChange.ChangeItem(item, from, level);
						box.DropItem(item);
						LootPackChange.RemoveItem(item, from, level);
					}
				}
			}

			if (Utility.Random(24) < level && MySettings.S_LootChance > Utility.Random(100))
			{
				Item treasure = Loot.RandomTreasure(from, level);
				treasure = LootPackChange.ChangeItem(treasure, from, level);
				box.DropItem(treasure);
				LootPackChange.RemoveItem(treasure, from, level);
			}
		}

		public static int BuildContainer(LockableContainer box, int hue, int itemOverride, int gumpOverride, int design)
		{
			int containerType = DetermineContainerType(itemOverride, box.Locked, design);

			ContainerAppearance.Apply(box, containerType, hue, gumpOverride, design);

			return containerType;
		}

		private static int DetermineContainerType(int itemOverride, bool locked, int design)
		{
			int baseType = (itemOverride > 0) ? itemOverride : Utility.RandomMinMax(1, 11);
			if (locked) baseType = Utility.RandomMinMax(1, 6);

			switch (design)
			{
				case 2: return Utility.RandomList(9, 10, 11, 12);
				case 4: return 12;
				case 5: return Utility.RandomList(9, 10, 11);
				case 6: return Utility.RandomList(2, 6);
				case 7: return Utility.RandomList(2, 6, 12, 13);
				case 8: return Utility.RandomList(2, 6, 13, 14);
				case 9: return 14;
				case 10: return 15;
				case 11: return Utility.RandomList(1, 2, 13, 16);
				case 12: return Utility.RandomList(1, 2, 7, 8, 12);
				case 13: return Utility.RandomList(17, 18, 18, 18);
				case 14: return 18;
				case 15: return Utility.RandomList(1, 2, 12, 16);
				case 16: return Utility.RandomList(2, 6, 13, 13, 16);
				default: return baseType;
			}
		}

		public static void MakeTomb(LockableContainer box, Mobile m, int tombType)
		{
			box.Locked = false;
			string owner = (m.Title != null && m.Title != "") ? m.Name + " " + m.Title : m.Name;

			bool makeSarcophagus = (Utility.Random(4) == 1 || tombType == 1) && tombType != 2;
			if (makeSarcophagus)
			{
				box.ItemID = Utility.RandomList(0x27E0, 0x280A, 0x2802, 0x2803);
				box.Name = "Sarcophagus of " + owner;
				ResourceMods.SetRandomResource(false, false, box, CraftResource.Iron, false, m);
				box.Catalog = Catalogs.Stone;
				box.GumpID = 0x1D;
			}
			else
			{
				box.ItemID = Utility.RandomList(0x2800, 0x2801, 0x27E9, 0x27EA);
				box.GumpID = 0x41D;
				box.Name = ((box.ItemID == 0x27E9 || box.ItemID == 0x27EA) ? "Casket" : "Coffin") + " of " + owner;
				ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, m);
			}
		}

		public static void MakeDemonBox(LockableContainer box, Mobile m)
		{
			box.Locked = false;
			string owner = (m.Title != null && m.Title != "") ? m.Name + " " + m.Title : m.Name;

			box.ItemID = Utility.RandomList(0x281F, 0x2820, 0x4FE6, 0x4FE7);
			box.Name = "Chest of " + owner;
			box.Resource = CraftResource.Iron;
			box.Hue = m.Hue;
			box.GumpID = 0x975;
		}

		public static void MakeSpaceCrate(LockableContainer box)
		{
			ContainerAppearance.Apply(box, 18, 0, 0x976, 3);
		}

		public static string GetOwner(string boxType)
		{
			string title = "";
			string namePart1 = "";
			string namePart2 = "";
			string baseName = "";
			string properName = "";
			int gender = Utility.RandomMinMax(1, 2);
			bool combinedName = (Utility.RandomMinMax(1, 3) == 1);

			if (gender == 1)
			{
				title = NameList.RandomName("men_titles");
				if (combinedName)
				{
					namePart1 = NameList.RandomName("men_names_1");
					namePart2 = NameList.RandomName("men_names_2");
					baseName = namePart1 + namePart2 + " the " + title;
				}
				else
				{
					baseName = NameList.RandomName("men_owners");
					properName = baseName;
					baseName = baseName + " the " + title;
				}
			}
			else
			{
				title = NameList.RandomName("women_titles");
				if (combinedName)
				{
					namePart1 = NameList.RandomName("women_names_1");
					namePart2 = NameList.RandomName("women_names_2");
					baseName = namePart1 + namePart2 + " the " + title;
				}
				else
				{
					baseName = NameList.RandomName("women_owners");
					properName = baseName;
					baseName = baseName + " the " + title;
				}
			}

			string[] adjectives = new string[]
			{
				"Exotic", "Mysterious", "Marvelous", "Amazing", "Astonishing", "Mystical", "Astounding",
				"Magnificent", "Phenomenal", "Fantastic", "Incredible", "Extraordinary", "Fabulous",
				"Wondrous", "Glorious", "Lost", "Fabled", "Legendary", "Mythical", "Missing",
				"Ancestral", "Ornate", "Wonderful", "Sacred", "Unspeakable", "Unknown", "Forgotten",
				"Ancient", "Enchanted", "Primordial", "Celestial", "Divine","Elusive", "Hidden", "Hallowed", 
				"Forbidden", "Otherwordly""Timeless", "Ageless", "Fated","Venerable","Revered","Shrouded", 
				"Veiled", "Primeval", "Immemorial", "Bygone"
			};
			string adj = adjectives[Utility.RandomMinMax(0, adjectives.Length - 1)] + " ";

			if (boxType == "Pilfer" || boxType == "Treasure Chest" || boxType == "property")
				return baseName;

			if (boxType == "cargo")
			{
				string person = Utility.RandomBool() ? NameList.RandomName("female") : NameList.RandomName("male");
				string[] roles = new string[]
				{
					"Mechanic", "Scientist", "Doctor", "Soldier", "Engineer", "Navigator", "Pilot",
					"Security Officer", "Medical Officer", "Robotics Engineer", "Linguist", "Marine",
					"Biologist", "Chemist", "Tactical Officer", "Weapons Officer", "Nurse", "Officer",
					"Mercenary", "Pathologist", "Botanist", "Anthropologist", "Chief Engineer"
				};
				return person + " the " + roles[Utility.Random(roles.Length)];
			}

			if (boxType == "Sunken" || boxType == "SunkenBag")
			{
				string[] pirateRoles = new string[]
				{
					"Captain", "First Mate", "Quartermaster", "Boatswain", "Navigator", "Master Gunner",
					"Gunner", "Sail Maker", "Sailor", "Privateer", "Buccaneer", "Rigger", "Swab"
				};
				string pirateRole = pirateRoles[Utility.Random(pirateRoles.Length)];

				if (boxType == "Sunken")
					return "The " + adj + "Chest of " + (combinedName ? (namePart1 + namePart2) : properName) + " the " + pirateRole;

				string pirateName = Utility.RandomBool() ? NameList.RandomName("female") : NameList.RandomName("male");
				string titleOrRole = (Utility.RandomMinMax(1, 3) == 3) ? title : pirateRole;
				return pirateName + " the " + titleOrRole;
			}

			if (boxType == "Body" || boxType == "BodySailor")
			{
				string corpseWord = RandomCorpseDescriptor();
				string ownerName = "";

				if (boxType == "BodySailor")
				{
					string[] pirateRoles = new string[]
					{
						"Captain", "First Mate", "Quartermaster", "Boatswain", "Navigator", "Master Gunner",
						"Gunner", "Sail Maker", "Sailor", "Privateer", "Buccaneer", "Rigger", "Swab"
					};
					string pirateRole = pirateRoles[Utility.Random(pirateRoles.Length)];
					string pirateName = Utility.RandomBool() ? NameList.RandomName("female") : NameList.RandomName("male");
					string titleOrRole = (Utility.RandomMinMax(1, 3) == 3) ? title : pirateRole;
					ownerName = pirateName + " the " + titleOrRole;
				}
				else
					ownerName = baseName;

				return "The " + corpseWord + " of " + ownerName;
			}

			if (boxType == "Corpse")
				adj = "";

			return "The " + adj + boxType + " of " + baseName;
		}

		private static string RandomCorpseDescriptor()
		{
			switch (Utility.RandomMinMax(0, 3))
			{
				case 1: return "body";
				case 2: return "skeletal remains";
				case 3: return "skeletal bones";
				case 4: return "carcass";
				case 5: return "cadaver";
				default: return "bones";
			}
		}
	}
}