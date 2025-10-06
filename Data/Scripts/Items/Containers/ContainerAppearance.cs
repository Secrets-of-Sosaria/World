using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Misc
{
	public static class ContainerAppearance
	{
		// CONSTANTS – itemIDs, gumps, hues, and resources
		
		// Basic chest IDs
		private static readonly int[] WoodenChestIDs = { 0xE42, 0xE43 };
		private static readonly int[] IronChestIDs = { 0xE40, 0xE41, 0x4FE1, 0x4FE2 };
		private static readonly int[] WoodenBoxIDs = { 0x9AA, 0xE7D, 0x4C2B, 0x4C2C, 0x1C0E, 0x1C0F };
		private static readonly int[] MetalBoxIDs = { 0x9A8, 0xE80 };
		// Bags, crates, barrels
		private static readonly int[] BagIDs = { 0xE76, 0x1E3F, 0x1E52, 0x1248, 0x1264, 0x5777, 0x5776 };
		private static readonly int[] BackpackIDs = { 0xE75, 0x53D5, 0x27BE, 0x27D7, 0x4C53, 0x4C54, 0x1C10, 0x1CC6 };
		private static readonly int[] SmallCrateIDs = { 0xE3F, 0xE3E };
		private static readonly int[] LargeCrateIDs = { 0xE3D, 0xE3C };
		private static readonly int[] BarrelIDs = { 0xFAE };
		// Tombs and coffins
		private static readonly int[] SarcophagusIDs = { 0x27E0, 0x280A, 0x2802, 0x2803 };
		private static readonly int[] CoffinIDs = { 0x2800, 0x2801, 0x27E9, 0x27EA };
		// Urns and stone coffers
		private static readonly int[] UrnVaseIDs = { 0x1AFC, 0x1AFD, 0x1AFE, 0x1AFF, 0x398B, 0x39A2, 0x4B59, 0x4C2A };
		private static readonly int[] StoneCofferIDs = { 0x281D, 0x281E, 0x281F, 0x2820, 0x2821, 0x2822, 0x2823, 0x2824, 0x2825, 0x2826, 0x4FE6, 0x4FE7 };
		// Sci-fi containers
		private static readonly int[] SciFiCrateIDs = { 0x10EA, 0x10EB, 0x10EC, 0x10ED };
		// Gump IDs
		private const int GumpWoodChest = 0x49;
		private const int GumpIronChest = 0x4A;
		private const int GumpWoodBox   = 0x43;
		private const int GumpMetalBox  = 0x4B;
		private const int GumpBag       = 0x3D;
		private const int GumpBackpack  = 0x3C;
		private const int GumpCrate     = 0x44;
		private const int GumpBarrel    = 0x3E;
		private const int GumpCorpse    = 0x3C;
		private const int GumpUrn       = 0x13B1;
		private const int GumpStone     = 0x2810;
		private const int GumpSarc      = 0x1D;
		private const int GumpCoffin    = 0x41D;
		private const int GumpBoat      = 0x4C;
		private const int GumpSciFi     = 0x976;
		// Common hues
		private const int HueWood = 0x724;
		private const int HueIron = 0x835;
		private const int HueBox  = 0x83E;

		public static void Apply(LockableContainer box, int type, int hue, int gumpOverride, int design)
		{
			switch (type)
			{
				case 1: ApplyWoodenChest(box, design); break;
				case 2: ApplyIronChest(box, design); break;
				case 3: ApplyWoodenFootlocker(box); break;
				case 4: ApplyWoodenTrunk(box); break;
				case 5: ApplyWoodenBox(box); break;
				case 6: ApplyMetalBox(box); break;
				case 7: ApplyBag(box); break;
				case 8: ApplyBackpack(box); break;
				case 9: ApplyWoodenCrate(box, false); break;
				case 10: ApplyWoodenCrate(box, true); break;
				case 11: ApplyBarrel(box); break;
				case 12: ApplyCorpse(box); break;
				case 13: ApplyUrnOrVase(box); break;
				case 14: ApplyCoffinOrSarcophagus(box); break;
				case 15: ApplyBoat(box); break;
				case 16: ApplyStoneCoffer(box); break;
				case 17: ApplyAlienRemains(box); break;
				default: ApplyCargoContainer(box); break;
			}

			if (hue > 0)
				box.Hue = hue;

			if (gumpOverride > 0)
				box.GumpID = gumpOverride;

			ApplyDesignHue(box, design);
		}

		private static void ApplyDesignHue(LockableContainer box, int design)
		{
			if (design == 1)
				box.Hue = Utility.RandomList(0x47E, 0x47F, 0x481, 0x482, 0x48D, 0x9C2);
			else if (design == 6)
				box.Hue = Utility.RandomOrangeHue();
		}

		private static void ApplyWoodenChest(LockableContainer box, int design)
		{
			box.Weight = 10.0;
			box.ItemID = Utility.RandomList(WoodenChestIDs);
			box.GumpID = GumpWoodChest;
			box.Name = "Wooden Chest";
			box.Hue = HueWood;
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyIronChest(LockableContainer box, int design)
		{
			box.Weight = 20.0;
			box.ItemID = Utility.RandomList(IronChestIDs);
			box.GumpID = GumpIronChest;
			box.Name = "Iron Chest";
			ResourceMods.SetRandomResource(false, false, box, CraftResource.Iron, false, null);
		}

		private static void ApplyWoodenFootlocker(LockableContainer box)
		{
			box.Weight = 12.0;
			box.ItemID = Utility.RandomList(0x2811, 0x2812);
			box.GumpID = 0x10C;
			box.Name = "Wooden Footlocker";
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyWoodenTrunk(LockableContainer box)
		{
			box.Weight = 15.0;
			box.ItemID = Utility.RandomList(0x2813, 0x2814);
			box.GumpID = 0x10D;
			box.Name = "Wooden Trunk";
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyWoodenBox(LockableContainer box)
		{
			box.Weight = 10.0;
			box.ItemID = Utility.RandomList(WoodenBoxIDs);
			box.GumpID = GumpWoodBox;
			box.Name = "Wooden Box";
			box.Hue = HueBox;
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyMetalBox(LockableContainer box)
		{
			box.Weight = 10.0;
			box.ItemID = Utility.RandomList(MetalBoxIDs);
			box.GumpID = GumpMetalBox;
			box.Name = "Metal Box";
			box.Hue = HueIron;
			ResourceMods.SetRandomResource(false, false, box, CraftResource.Iron, false, null);
		}

		private static void ApplyBag(LockableContainer box)
		{
			box.Weight = 2.0;
			box.Locked = false;
			box.ItemID = Utility.RandomList(BagIDs);
			box.GumpID = GumpBag;
			box.Name = "Bag";
			box.Hue = Utility.RandomMinMax(2401, 2430);
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularLeather, false, null);
		}

		private static void ApplyBackpack(LockableContainer box)
		{
			box.Weight = 3.0;
			box.ItemID = Utility.RandomList(BackpackIDs);
			box.GumpID = GumpBackpack;
			box.Name = "Backpack";
			box.Hue = Utility.RandomMinMax(2401, 2430);
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularLeather, false, null);
		}

		private static void ApplyWoodenCrate(LockableContainer box, bool small)
		{
			box.Weight = small ? 8.0 : 10.0;
			box.ItemID = Utility.RandomList(small ? SmallCrateIDs : LargeCrateIDs);
			box.GumpID = GumpCrate;
			box.Name = "Wooden Crate";
			box.Hue = Utility.RandomMinMax(2413, 2430);
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyBarrel(LockableContainer box)
		{
			box.Weight = 25.0;
			box.ItemID = Utility.RandomList(BarrelIDs);
			box.GumpID = GumpBarrel;
			box.Name = "Barrel";
			ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
		}

		private static void ApplyCorpse(LockableContainer box)
		{
			box.Weight = 25.0;
			box.ItemID = Utility.RandomMinMax(19290, 19371);
			if (box.ItemID > 19357) box.Hue = Utility.RandomColor(0);
			box.GumpID = GumpCorpse;
			box.Name = ContainerFunctions.GetOwner("Corpse");
			box.Resource = CraftResource.BrittleSkeletal;
		}

		private static void ApplyUrnOrVase(LockableContainer box)
		{
			box.Weight = 20.0;
			box.ItemID = Utility.RandomList(UrnVaseIDs);
			box.GumpID = GumpUrn;
			box.Name = (Utility.Random(2) == 0 ? "Urn" : "Vase");
			ResourceMods.SetRandomResource(false, false, box, CraftResource.Iron, false, null);
			box.Catalog = Catalogs.Stone;
		}

		private static void ApplyCoffinOrSarcophagus(LockableContainer box)
		{
			box.Locked = false;
			if (Utility.Random(4) == 1)
			{
				box.Weight = 100.0;
				box.ItemID = Utility.RandomList(SarcophagusIDs);
				box.GumpID = GumpSarc;
				box.Name = "Sarcophagus";
				ResourceMods.SetRandomResource(false, false, box, CraftResource.Iron, false, null);
				box.Catalog = Catalogs.Stone;
			}
			else
			{
				box.Weight = 25.0;
				box.ItemID = Utility.RandomList(CoffinIDs);
				box.GumpID = GumpCoffin;
				box.Name = ((box.ItemID == 0x27E9 || box.ItemID == 0x27EA) ? "Casket" : "Coffin");
				ResourceMods.SetRandomResource(false, false, box, CraftResource.RegularWood, false, null);
			}
		}

		private static void ApplyBoat(LockableContainer box)
		{
			box.Weight = 100.0;
			box.Movable = false;
			box.ItemID = Utility.RandomList(0x2299, 0x229A, 0x229B, 0x229C, 0x229D, 0x229E, 0x229F, 0x22A0);
			box.GumpID = GumpBoat;
			box.Resource = CraftResource.RegularWood;
			box.Name = "Boat";

			switch (Utility.Random(6))
			{
				case 1: box.Name = "Abandoned Boat"; break;
				case 2: box.Name = "Deserted Boat"; break;
				case 3: box.Name = "Discarded Boat"; break;
				case 4: box.Name = "Lost Boat"; break;
				case 5: box.Name = "Adrift Boat"; break;
			}
		}

		private static void ApplyStoneCoffer(LockableContainer box)
		{
			box.Weight = 10.0;
			box.GumpID = GumpStone;
			box.Catalog = Catalogs.Stone;
			box.Resource = CraftResource.Iron;
			box.ItemID = Utility.RandomList(StoneCofferIDs);
			box.Name = "Stone Chest";
		}

		private static void ApplyAlienRemains(LockableContainer box)
		{
			box.Weight = 25.0;
			box.ItemID = Utility.RandomList(0x3564, 0x3565, 0x3582, 0x3583, 0x35AD, 0x3868);
			box.GumpID = GumpCorpse;
			box.Resource = CraftResource.BrittleSkeletal;

			if (box.ItemID == 0x3564 || box.ItemID == 0x3565)
			{
				box.GumpID = GumpSciFi;
				box.Name = RandomBrokenRobotName();
				box.Resource = CraftResource.Iron;
			}
			else if (box.ItemID == 0x3582 || box.ItemID == 0x3583)
			{
				box.Name = "alien corpse";
				box.Resource = ResourceMods.SciFiResource(CraftResource.BrittleSkeletal);
			}
			else
			{
				box.Name = "mutant corpse";
				box.Resource = ResourceMods.SciFiResource(CraftResource.BrittleSkeletal);
			}
		}

		private static string RandomBrokenRobotName()
		{
			string[] states = { "broken", "busted", "crippled", "crumbled", "crushed", "damaged", "defective", "demolished", "mangled", "smashed" };
			int idx = Utility.Random(states.Length);
			return states[idx] + " " + Server.Misc.RandomThings.GetRandomRobot(0);
		}

		private static void ApplyCargoContainer(LockableContainer box)
		{
			box.Weight = 10.0;
			box.ItemID = Utility.RandomList(SciFiCrateIDs);
			box.GumpID = GumpSciFi;
			box.Name = "Cargo Container";
			box.Resource = ResourceMods.SciFiResource(CraftResource.Iron);
			box.Catalog = Catalogs.SciFi;
		}
	}
}
