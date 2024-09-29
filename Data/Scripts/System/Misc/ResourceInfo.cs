using System;
using System.Collections;
using Server.Misc;

namespace Server.Items
{
	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood,
		Block,
		Skin,
		Special,
		Skeletal,
		Fabric
	}

	public class CraftAttributeInfo
	{
		private int m_WeaponFireDamage;
		private int m_WeaponColdDamage;
		private int m_WeaponPoisonDamage;
		private int m_WeaponEnergyDamage;
		private int m_WeaponChaosDamage;
		private int m_WeaponDirectDamage;
		private int m_WeaponDurability;
		private int m_WeaponLuck;
		private int m_WeaponGoldIncrease;
		private int m_WeaponLowerRequirements;

		private int m_ArmorPhysicalResist;
		private int m_ArmorFireResist;
		private int m_ArmorColdResist;
		private int m_ArmorPoisonResist;
		private int m_ArmorEnergyResist;
		private int m_ArmorDurability;
		private int m_ArmorLuck;
		private int m_ArmorGoldIncrease;
		private int m_ArmorLowerRequirements;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;

		public int WeaponFireDamage{ get{ return m_WeaponFireDamage; } set{ m_WeaponFireDamage = value; } }
		public int WeaponColdDamage{ get{ return m_WeaponColdDamage; } set{ m_WeaponColdDamage = value; } }
		public int WeaponPoisonDamage{ get{ return m_WeaponPoisonDamage; } set{ m_WeaponPoisonDamage = value; } }
		public int WeaponEnergyDamage{ get{ return m_WeaponEnergyDamage; } set{ m_WeaponEnergyDamage = value; } }
		public int WeaponChaosDamage{ get{ return m_WeaponChaosDamage; } set{ m_WeaponChaosDamage = value; } }
		public int WeaponDirectDamage{ get{ return m_WeaponDirectDamage; } set{ m_WeaponDirectDamage = value; } }
		public int WeaponDurability{ get{ return m_WeaponDurability; } set{ m_WeaponDurability = value; } }
		public int WeaponLuck{ get{ return m_WeaponLuck; } set{ m_WeaponLuck = value; } }
		public int WeaponGoldIncrease{ get{ return m_WeaponGoldIncrease; } set{ m_WeaponGoldIncrease = value; } }
		public int WeaponLowerRequirements{ get{ return m_WeaponLowerRequirements; } set{ m_WeaponLowerRequirements = value; } }

		public int ArmorPhysicalResist{ get{ return m_ArmorPhysicalResist; } set{ m_ArmorPhysicalResist = value; } }
		public int ArmorFireResist{ get{ return m_ArmorFireResist; } set{ m_ArmorFireResist = value; } }
		public int ArmorColdResist{ get{ return m_ArmorColdResist; } set{ m_ArmorColdResist = value; } }
		public int ArmorPoisonResist{ get{ return m_ArmorPoisonResist; } set{ m_ArmorPoisonResist = value; } }
		public int ArmorEnergyResist{ get{ return m_ArmorEnergyResist; } set{ m_ArmorEnergyResist = value; } }
		public int ArmorDurability{ get{ return m_ArmorDurability; } set{ m_ArmorDurability = value; } }
		public int ArmorLuck{ get{ return m_ArmorLuck; } set{ m_ArmorLuck = value; } }
		public int ArmorGoldIncrease{ get{ return m_ArmorGoldIncrease; } set{ m_ArmorGoldIncrease = value; } }
		public int ArmorLowerRequirements{ get{ return m_ArmorLowerRequirements; } set{ m_ArmorLowerRequirements = value; } }

		public int RunicMinAttributes{ get{ return m_RunicMinAttributes; } set{ m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes{ get{ return m_RunicMaxAttributes; } set{ m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity{ get{ return m_RunicMinIntensity; } set{ m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity{ get{ return m_RunicMaxIntensity; } set{ m_RunicMaxIntensity = value; } }

		public static CraftAttributeInfo CraftAttInfo( int armorphy, int armorcld, int armorfir, int armoregy, int armorpsn, int runminat, int runmaxat, int runminin, int runmaxin, int weapcold, int weapfire, int weapengy, int weappois, int durable, int lowreq, int luck )
		{
			CraftAttributeInfo var = new CraftAttributeInfo();

			var.ArmorPhysicalResist = 		armorphy;
			var.ArmorColdResist = 			armorcld;
			var.ArmorFireResist = 			armorfir;
			var.ArmorEnergyResist = 		armoregy;
			var.ArmorPoisonResist = 		armorpsn;
			var.ArmorDurability = 			durable;
			var.ArmorLowerRequirements = 	lowreq;
			var.ArmorLuck = 				luck;
			var.RunicMinAttributes = 		runminat;
			var.RunicMaxAttributes = 		runmaxat;
			var.RunicMinIntensity = 		runminin;
			var.RunicMaxIntensity = 		runmaxin;
			var.WeaponColdDamage = 			weapcold;
			var.WeaponFireDamage = 			weapfire;
			var.WeaponEnergyDamage = 		weapengy;
			var.WeaponPoisonDamage = 		weappois;
			var.WeaponDurability = 			durable;
			var.WeaponLowerRequirements = 	lowreq;
			var.WeaponLuck = 				luck;

			return var;
		}

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite, Valorite, Nepturite, Obsidian, Steel, Brass, Mithril, Xormite, Dwarven, Agrinium, Beskar, Carbonite, Cortosis, Durasteel, Durite, Farium, Laminasteel, Neuranium, Phrik, Promethium, Quadranium, Songsteel, Titanium, Trimantium, Xonolite;
		public static readonly CraftAttributeInfo Horned, Barbed, Necrotic, Volcanic, Frozen, Spined, Goliath, Draconic, Hellish, Dinosaur, Alien, Adesote, Biomesh, Cerlin, Durafiber, Flexicris, Hypercloth, Nylar, Nylonite, Polyfiber, Syncloth, Thermoweave;
		public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales, DinosaurScales, MetallicScales, BrazenScales, UmberScales, VioletScales, PlatinumScales, CadalyteScales, GornScales, TrandoshanScales, SilurianScales, KraytScales;
		public static readonly CraftAttributeInfo AshTree, CherryTree, EbonyTree, GoldenOakTree, HickoryTree, MahoganyTree, OakTree, PineTree, GhostTree, RosewoodTree, WalnutTree, PetrifiedTree, DriftwoodTree, ElvenTree, BorlTree, CosianTree, GreelTree, JaporTree, KyshyyykTree, LaroonTree, TeejTree, VeshokTree;
		public static readonly CraftAttributeInfo AmethystBlock, EmeraldBlock, GarnetBlock, IceBlock, JadeBlock, MarbleBlock, OnyxBlock, QuartzBlock, RubyBlock, SapphireBlock, SilverBlock, SpinelBlock, StarRubyBlock, TopazBlock, CaddelliteBlock;
		public static readonly CraftAttributeInfo DemonSkin, DragonSkin, NightmareSkin, SnakeSkin, TrollSkin, UnicornSkin, IcySkin, Seaweed, LavaSkin, DeadSkin;
		public static readonly CraftAttributeInfo SpectralSpec, DreadSpec, GhoulishSpec, WyrmSpec, HolySpec, BloodlessSpec, GildedSpec, DemilichSpec, WintrySpec, FireSpec, ColdSpec, PoisSpec, EngySpec, ExodusSpec, TurtleSpec;
		public static readonly CraftAttributeInfo DrowSkeletal, OrcSkeletal, ReptileSkeletal, OgreSkeletal, TrollSkeletal, GargoyleSkeletal, MinotaurSkeletal, LycanSkeletal, SharkSkeletal, ColossalSkeletal, MysticalSkeletal, VampireSkeletal, LichSkeletal, SphinxSkeletal, DevilSkeletal, DracoSkeletal, XenoSkeletal, AndorianSkeletal, CardassianSkeletal, MartianSkeletal, RodianSkeletal, TuskenSkeletal, TwilekSkeletal, XindiSkeletal, ZabrakSkeletal;
		public static readonly CraftAttributeInfo FurryFabric, WoolyFabric, SilkFabric, HauntedFabric, ArcticFabric, PyreFabric, VenomousFabric, MysteriousFabric, VileFabric, DivineFabric, FiendishFabric;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();
			DullCopper	 = CraftAttInfo( 	3	,	0	,	0	,	0	,	0	,	1	,	2	,	40	,	100	,	0	,	0	,	0	,	0	,	75	,	35	,	0	 );
			ShadowIron	 = CraftAttInfo( 	1	,	0	,	1	,	3	,	0	,	2	,	2	,	45	,	100	,	0	,	0	,	0	,	0	,	75	,	0	,	0	 );
			Copper	 = CraftAttInfo( 	1	,	0	,	1	,	1	,	3	,	2	,	3	,	50	,	100	,	0	,	0	,	20	,	10	,	25	,	0	,	0	 );
			Bronze	 = CraftAttInfo( 	2	,	3	,	0	,	1	,	1	,	3	,	3	,	55	,	100	,	0	,	40	,	0	,	0	,	30	,	0	,	0	 );
			Golden	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	0	,	3	,	4	,	60	,	100	,	0	,	0	,	0	,	0	,	30	,	40	,	40	 );
			Agapite	 = CraftAttInfo( 	1	,	1	,	2	,	1	,	1	,	4	,	4	,	65	,	100	,	30	,	0	,	20	,	0	,	25	,	0	,	0	 );
			Verite	 = CraftAttInfo( 	2	,	1	,	2	,	1	,	2	,	4	,	5	,	70	,	100	,	0	,	0	,	20	,	40	,	25	,	0	,	0	 );
			Valorite	 = CraftAttInfo( 	2	,	2	,	0	,	2	,	2	,	5	,	5	,	85	,	100	,	20	,	10	,	20	,	10	,	40	,	0	,	0	 );
			Nepturite	 = CraftAttInfo( 	4	,	3	,	0	,	0	,	3	,	5	,	5	,	85	,	100	,	25	,	0	,	0	,	25	,	40	,	0	,	0	 );
			Obsidian	 = CraftAttInfo( 	3	,	1	,	3	,	1	,	1	,	5	,	5	,	85	,	100	,	0	,	20	,	10	,	0	,	40	,	0	,	0	 );
			Steel	 = CraftAttInfo( 	3	,	3	,	0	,	3	,	3	,	6	,	7	,	85	,	100	,	0	,	0	,	0	,	0	,	50	,	25	,	0	 );
			Brass	 = CraftAttInfo( 	4	,	4	,	0	,	4	,	4	,	8	,	9	,	85	,	100	,	0	,	20	,	20	,	0	,	55	,	45	,	0	 );
			Mithril	 = CraftAttInfo( 	5	,	5	,	0	,	5	,	5	,	10	,	11	,	85	,	100	,	0	,	0	,	30	,	0	,	100	,	75	,	100	 );
			Xormite	 = CraftAttInfo( 	5	,	5	,	5	,	6	,	5	,	10	,	11	,	85	,	100	,	0	,	0	,	30	,	0	,	100	,	75	,	0	 );
			Dwarven	 = CraftAttInfo( 	7	,	5	,	5	,	0	,	0	,	20	,	22	,	170	,	200	,	0	,	0	,	0	,	0	,	100	,	10	,	0	 );
			Agrinium	 = CraftAttInfo( 	5	,	3	,	3	,	5	,	0	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Beskar	 = CraftAttInfo( 	6	,	2	,	2	,	3	,	2	,	15	,	16	,	170	,	200	,	0	,	10	,	0	,	0	,	80	,	25	,	0	 );
			Carbonite	 = CraftAttInfo( 	4	,	5	,	1	,	4	,	1	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Cortosis	 = CraftAttInfo( 	4	,	3	,	3	,	6	,	0	,	15	,	16	,	170	,	200	,	0	,	0	,	25	,	0	,	80	,	25	,	0	 );
			Durasteel	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	3	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Durite	 = CraftAttInfo( 	4	,	4	,	4	,	2	,	1	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Farium	 = CraftAttInfo( 	4	,	0	,	7	,	4	,	0	,	15	,	16	,	170	,	200	,	0	,	35	,	0	,	0	,	80	,	25	,	0	 );
			Laminasteel	 = CraftAttInfo( 	4	,	0	,	0	,	4	,	7	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	25	,	80	,	25	,	0	 );
			Neuranium	 = CraftAttInfo( 	5	,	0	,	5	,	5	,	0	,	15	,	16	,	170	,	200	,	0	,	25	,	0	,	0	,	80	,	25	,	0	 );
			Phrik	 = CraftAttInfo( 	4	,	1	,	2	,	6	,	2	,	15	,	16	,	170	,	200	,	0	,	0	,	35	,	0	,	80	,	25	,	0	 );
			Promethium	 = CraftAttInfo( 	5	,	0	,	0	,	5	,	5	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	35	,	80	,	25	,	0	 );
			Quadranium	 = CraftAttInfo( 	4	,	3	,	3	,	4	,	2	,	15	,	16	,	170	,	200	,	10	,	10	,	10	,	10	,	80	,	25	,	0	 );
			Songsteel	 = CraftAttInfo( 	6	,	2	,	2	,	4	,	2	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Titanium	 = CraftAttInfo( 	7	,	2	,	2	,	4	,	1	,	15	,	16	,	170	,	200	,	0	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Trimantium	 = CraftAttInfo( 	4	,	7	,	2	,	2	,	1	,	15	,	16	,	170	,	200	,	50	,	0	,	0	,	0	,	80	,	25	,	0	 );
			Xonolite	 = CraftAttInfo( 	4	,	2	,	7	,	2	,	1	,	15	,	16	,	170	,	200	,	0	,	50	,	0	,	0	,	80	,	25	,	0	 );
																																				
			RedScales	 = CraftAttInfo( 	3	,	0	,	3	,	0	,	0	,	6	,	11	,	75	,	100	,	0	,	25	,	0	,	0	,	30	,	0	,	0	 );
			YellowScales	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	1	,	6	,	11	,	75	,	100	,	10	,	10	,	10	,	10	,	30	,	0	,	30	 );
			BlackScales	 = CraftAttInfo( 	2	,	0	,	0	,	2	,	2	,	6	,	11	,	75	,	100	,	0	,	0	,	0	,	0	,	30	,	0	,	0	 );
			GreenScales	 = CraftAttInfo( 	2	,	0	,	0	,	0	,	3	,	6	,	11	,	75	,	100	,	0	,	0	,	0	,	25	,	30	,	0	,	0	 );
			WhiteScales	 = CraftAttInfo( 	2	,	3	,	0	,	0	,	0	,	6	,	11	,	75	,	100	,	25	,	0	,	0	,	0	,	30	,	0	,	0	 );
			BlueScales	 = CraftAttInfo( 	2	,	2	,	0	,	0	,	1	,	6	,	11	,	75	,	100	,	15	,	0	,	0	,	15	,	30	,	0	,	0	 );
			DinosaurScales	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	1	,	6	,	11	,	75	,	100	,	0	,	0	,	0	,	0	,	30	,	0	,	0	 );
			MetallicScales	 = CraftAttInfo( 	2	,	0	,	2	,	2	,	0	,	6	,	11	,	75	,	100	,	0	,	0	,	0	,	0	,	30	,	0	,	0	 );
			BrazenScales	 = CraftAttInfo( 	2	,	0	,	2	,	1	,	0	,	6	,	11	,	75	,	100	,	0	,	15	,	15	,	0	,	30	,	0	,	0	 );
			UmberScales	 = CraftAttInfo( 	3	,	0	,	0	,	3	,	0	,	6	,	11	,	75	,	100	,	0	,	0	,	35	,	0	,	30	,	0	,	0	 );
			VioletScales	 = CraftAttInfo( 	3	,	0	,	0	,	3	,	0	,	6	,	11	,	75	,	100	,	0	,	0	,	25	,	0	,	30	,	0	,	0	 );
			PlatinumScales	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	1	,	6	,	11	,	75	,	100	,	15	,	15	,	15	,	15	,	30	,	0	,	50	 );
			CadalyteScales	 = CraftAttInfo( 	7	,	4	,	4	,	7	,	4	,	20	,	22	,	170	,	200	,	0	,	0	,	50	,	0	,	200	,	30	,	0	 );
			GornScales	 = CraftAttInfo( 	5	,	2	,	4	,	2	,	2	,	12	,	20	,	125	,	175	,	0	,	25	,	0	,	0	,	100	,	10	,	0	 );
			TrandoshanScales	 = CraftAttInfo( 	5	,	4	,	2	,	2	,	2	,	12	,	20	,	125	,	175	,	25	,	0	,	0	,	0	,	100	,	10	,	0	 );
			SilurianScales	 = CraftAttInfo( 	5	,	2	,	2	,	4	,	2	,	12	,	20	,	125	,	175	,	0	,	0	,	25	,	0	,	100	,	10	,	0	 );
			KraytScales	 = CraftAttInfo( 	5	,	2	,	2	,	2	,	4	,	12	,	20	,	125	,	175	,	0	,	0	,	0	,	25	,	100	,	0	,	0	 );
																																				
			SpectralSpec	 = CraftAttInfo( 	3	,	3	,	0	,	0	,	0	,	10	,	11	,	85	,	100	,	50	,	0	,	0	,	0	,	20	,	0	,	0	 );
			DreadSpec	 = CraftAttInfo( 	2	,	1	,	1	,	2	,	0	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	0	,	90	,	0	,	20	 );
			GhoulishSpec	 = CraftAttInfo( 	3	,	2	,	2	,	3	,	2	,	10	,	11	,	85	,	100	,	10	,	10	,	10	,	10	,	200	,	0	,	50	 );
			WyrmSpec	 = CraftAttInfo( 	4	,	2	,	6	,	2	,	2	,	10	,	11	,	85	,	100	,	10	,	10	,	10	,	10	,	200	,	0	,	50	 );
			HolySpec	 = CraftAttInfo( 	4	,	5	,	4	,	5	,	4	,	10	,	11	,	85	,	100	,	35	,	10	,	35	,	10	,	100	,	0	,	0	 );
			BloodlessSpec	 = CraftAttInfo( 	3	,	0	,	0	,	0	,	5	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	0	,	70	,	20	,	0	 );
			GildedSpec	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	3	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	0	,	120	,	0	,	200	 );
			DemilichSpec	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	5	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	30	,	200	,	0	,	0	 );
			WintrySpec	 = CraftAttInfo( 	2	,	5	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	50	,	0	,	0	,	0	,	70	,	0	,	0	 );
			FireSpec	 = CraftAttInfo( 	1	,	1	,	4	,	1	,	1	,	3	,	3	,	55	,	100	,	0	,	100	,	0	,	0	,	25	,	10	,	0	 );
			ColdSpec	 = CraftAttInfo( 	1	,	4	,	1	,	1	,	1	,	3	,	3	,	55	,	100	,	100	,	0	,	0	,	0	,	25	,	10	,	0	 );
			PoisSpec	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	4	,	3	,	3	,	55	,	100	,	0	,	0	,	0	,	100	,	25	,	10	,	0	 );
			EngySpec	 = CraftAttInfo( 	1	,	1	,	1	,	4	,	1	,	3	,	3	,	55	,	100	,	0	,	0	,	100	,	0	,	25	,	10	,	0	 );
			ExodusSpec	 = CraftAttInfo( 	0	,	0	,	0	,	0	,	0	,	20	,	22	,	170	,	200	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 );
			TurtleSpec	 = CraftAttInfo( 	4	,	2	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	0	,	120	,	30	,	0	 );
																																				
			Horned	 = CraftAttInfo( 	2	,	1	,	1	,	1	,	1	,	3	,	4	,	45	,	100	,	0	,	0	,	0	,	0	,	10	,	0	,	0	 );
			Barbed	 = CraftAttInfo( 	2	,	1	,	1	,	2	,	3	,	4	,	5	,	50	,	100	,	0	,	0	,	0	,	70	,	20	,	0	,	0	 );
			Necrotic	 = CraftAttInfo( 	2	,	2	,	1	,	1	,	3	,	5	,	6	,	50	,	100	,	0	,	0	,	0	,	50	,	30	,	0	,	0	 );
			Volcanic	 = CraftAttInfo( 	3	,	1	,	3	,	2	,	2	,	6	,	7	,	50	,	100	,	0	,	50	,	0	,	0	,	40	,	0	,	0	 );
			Frozen	 = CraftAttInfo( 	3	,	3	,	1	,	2	,	2	,	6	,	7	,	50	,	100	,	50	,	0	,	0	,	0	,	50	,	0	,	0	 );
			Spined	 = CraftAttInfo( 	2	,	3	,	1	,	2	,	3	,	5	,	7	,	50	,	100	,	0	,	0	,	0	,	20	,	50	,	0	,	40	 );
			Goliath	 = CraftAttInfo( 	3	,	2	,	2	,	4	,	2	,	7	,	8	,	50	,	100	,	0	,	0	,	25	,	0	,	60	,	0	,	0	 );
			Draconic	 = CraftAttInfo( 	4	,	3	,	3	,	3	,	3	,	8	,	9	,	50	,	100	,	0	,	25	,	0	,	0	,	70	,	0	,	0	 );
			Hellish	 = CraftAttInfo( 	4	,	4	,	4	,	4	,	4	,	10	,	11	,	50	,	100	,	0	,	50	,	0	,	0	,	80	,	0	,	0	 );
			Dinosaur	 = CraftAttInfo( 	5	,	4	,	4	,	4	,	4	,	11	,	12	,	50	,	100	,	0	,	0	,	0	,	0	,	100	,	0	,	0	 );
			Alien	 = CraftAttInfo( 	5	,	4	,	4	,	4	,	4	,	15	,	18	,	85	,	200	,	0	,	0	,	50	,	0	,	100	,	0	,	0	 );
			Adesote	 = CraftAttInfo( 	5	,	3	,	3	,	5	,	3	,	14	,	17	,	75	,	180	,	0	,	0	,	25	,	0	,	80	,	50	,	0	 );
			Biomesh	 = CraftAttInfo( 	5	,	3	,	3	,	3	,	5	,	14	,	17	,	75	,	180	,	0	,	0	,	0	,	0	,	80	,	40	,	0	 );
			Cerlin	 = CraftAttInfo( 	5	,	5	,	3	,	3	,	3	,	14	,	17	,	75	,	180	,	25	,	0	,	0	,	0	,	80	,	60	,	0	 );
			Durafiber	 = CraftAttInfo( 	6	,	3	,	3	,	4	,	3	,	14	,	17	,	75	,	180	,	0	,	0	,	0	,	0	,	80	,	40	,	0	 );
			Flexicris	 = CraftAttInfo( 	4	,	4	,	4	,	4	,	4	,	14	,	17	,	75	,	180	,	0	,	25	,	25	,	0	,	80	,	50	,	0	 );
			Hypercloth	 = CraftAttInfo( 	4	,	3	,	3	,	3	,	6	,	14	,	17	,	75	,	180	,	0	,	0	,	0	,	25	,	80	,	60	,	0	 );
			Nylar	 = CraftAttInfo( 	4	,	3	,	6	,	3	,	3	,	14	,	17	,	75	,	180	,	0	,	50	,	0	,	0	,	80	,	60	,	0	 );
			Nylonite	 = CraftAttInfo( 	4	,	3	,	3	,	6	,	3	,	14	,	17	,	75	,	180	,	0	,	0	,	50	,	0	,	80	,	50	,	0	 );
			Polyfiber	 = CraftAttInfo( 	5	,	3	,	3	,	3	,	5	,	14	,	17	,	75	,	180	,	0	,	0	,	0	,	50	,	80	,	50	,	0	 );
			Syncloth	 = CraftAttInfo( 	4	,	4	,	4	,	4	,	2	,	14	,	17	,	75	,	180	,	0	,	0	,	0	,	0	,	80	,	40	,	0	 );
			Thermoweave	 = CraftAttInfo( 	5	,	3	,	5	,	5	,	0	,	14	,	17	,	75	,	180	,	0	,	20	,	20	,	0	,	80	,	50	,	0	 );
																																				
			AshTree	 = CraftAttInfo( 	1	,	1	,	1	,	1	,	1	,	1	,	2	,	40	,	100	,	5	,	5	,	5	,	5	,	10	,	0	,	0	 );
			CherryTree	 = CraftAttInfo( 	1	,	1	,	1	,	2	,	1	,	2	,	2	,	45	,	100	,	0	,	0	,	20	,	10	,	25	,	0	,	0	 );
			EbonyTree	 = CraftAttInfo( 	1	,	0	,	1	,	3	,	0	,	2	,	3	,	50	,	100	,	20	,	0	,	0	,	0	,	40	,	0	,	0	 );
			GoldenOakTree	 = CraftAttInfo( 	2	,	1	,	1	,	1	,	0	,	3	,	3	,	55	,	100	,	0	,	0	,	0	,	0	,	20	,	40	,	40	 );
			HickoryTree	 = CraftAttInfo( 	3	,	1	,	1	,	1	,	1	,	3	,	4	,	60	,	100	,	0	,	0	,	0	,	0	,	50	,	30	,	0	 );
			MahoganyTree	 = CraftAttInfo( 	1	,	0	,	1	,	1	,	3	,	4	,	4	,	65	,	100	,	0	,	0	,	20	,	10	,	55	,	0	,	0	 );
			OakTree	 = CraftAttInfo( 	2	,	3	,	0	,	1	,	1	,	4	,	5	,	70	,	100	,	0	,	40	,	0	,	0	,	55	,	0	,	0	 );
			PineTree	 = CraftAttInfo( 	2	,	1	,	2	,	1	,	1	,	5	,	5	,	85	,	100	,	30	,	0	,	20	,	0	,	60	,	0	,	0	 );
			GhostTree	 = CraftAttInfo( 	1	,	2	,	1	,	2	,	2	,	5	,	5	,	85	,	100	,	25	,	0	,	25	,	0	,	60	,	0	,	0	 );
			RosewoodTree	 = CraftAttInfo( 	2	,	1	,	2	,	1	,	2	,	5	,	5	,	85	,	100	,	0	,	0	,	20	,	40	,	60	,	0	,	0	 );
			WalnutTree	 = CraftAttInfo( 	2	,	2	,	1	,	2	,	1	,	6	,	7	,	85	,	100	,	20	,	10	,	20	,	10	,	65	,	0	,	0	 );
			PetrifiedTree	 = CraftAttInfo( 	4	,	1	,	1	,	1	,	1	,	8	,	9	,	85	,	100	,	0	,	25	,	0	,	0	,	70	,	0	,	0	 );
			DriftwoodTree	 = CraftAttInfo( 	2	,	1	,	3	,	1	,	0	,	10	,	11	,	85	,	100	,	10	,	10	,	10	,	20	,	80	,	0	,	0	 );
			ElvenTree	 = CraftAttInfo( 	4	,	3	,	0	,	3	,	3	,	20	,	22	,	170	,	200	,	0	,	0	,	0	,	0	,	100	,	0	,	100	 );
			BorlTree	 = CraftAttInfo( 	4	,	0	,	5	,	3	,	0	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
			CosianTree	 = CraftAttInfo( 	4	,	0	,	0	,	4	,	4	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	50	 );
			GreelTree	 = CraftAttInfo( 	4	,	0	,	5	,	3	,	0	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
			JaporTree	 = CraftAttInfo( 	4	,	5	,	0	,	3	,	0	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
			KyshyyykTree	 = CraftAttInfo( 	5	,	3	,	1	,	3	,	1	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	100	,	0	,	0	 );
			LaroonTree	 = CraftAttInfo( 	5	,	1	,	1	,	4	,	2	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
			TeejTree	 = CraftAttInfo( 	4	,	0	,	0	,	3	,	5	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
			VeshokTree	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	3	,	15	,	16	,	125	,	150	,	0	,	0	,	0	,	0	,	80	,	0	,	0	 );
																																				
			FurryFabric	 = CraftAttInfo( 	1	,	1	,	0	,	0	,	0	,	1	,	3	,	40	,	80	,	0	,	0	,	0	,	0	,	5	,	0	,	0	 );
			WoolyFabric	 = CraftAttInfo( 	1	,	1	,	0	,	0	,	0	,	1	,	3	,	40	,	80	,	25	,	0	,	0	,	0	,	5	,	0	,	0	 );
			SilkFabric	 = CraftAttInfo( 	1	,	0	,	0	,	0	,	2	,	2	,	4	,	45	,	85	,	0	,	0	,	0	,	25	,	10	,	5	,	10	 );
			HauntedFabric	 = CraftAttInfo( 	2	,	1	,	0	,	1	,	0	,	3	,	5	,	50	,	90	,	0	,	0	,	25	,	0	,	15	,	10	,	0	 );
			ArcticFabric	 = CraftAttInfo( 	2	,	2	,	0	,	0	,	0	,	4	,	6	,	55	,	95	,	50	,	0	,	0	,	0	,	20	,	15	,	0	 );
			PyreFabric	 = CraftAttInfo( 	2	,	0	,	2	,	0	,	0	,	4	,	6	,	55	,	95	,	0	,	50	,	0	,	0	,	20	,	15	,	0	 );
			VenomousFabric	 = CraftAttInfo( 	3	,	0	,	0	,	0	,	3	,	5	,	7	,	60	,	100	,	0	,	0	,	0	,	50	,	25	,	20	,	0	 );
			MysteriousFabric	 = CraftAttInfo( 	3	,	0	,	0	,	3	,	0	,	6	,	8	,	65	,	105	,	0	,	0	,	50	,	0	,	30	,	25	,	20	 );
			VileFabric	 = CraftAttInfo( 	4	,	0	,	0	,	0	,	4	,	7	,	9	,	70	,	110	,	0	,	0	,	25	,	25	,	35	,	30	,	0	 );
			DivineFabric	 = CraftAttInfo( 	4	,	0	,	0	,	4	,	0	,	7	,	9	,	70	,	110	,	10	,	10	,	25	,	0	,	35	,	30	,	50	 );
			FiendishFabric	 = CraftAttInfo( 	4	,	0	,	3	,	3	,	0	,	8	,	10	,	80	,	120	,	10	,	25	,	10	,	0	,	40	,	35	,	0	 );
																																				
			AmethystBlock	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	3	,	10	,	11	,	85	,	100	,	0	,	0	,	25	,	0	,	100	,	0	,	10	 );
			EmeraldBlock	 = CraftAttInfo( 	4	,	2	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	25	,	100	,	0	,	0	 );
			GarnetBlock	 = CraftAttInfo( 	3	,	2	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	0	,	10	,	10	,	100	,	0	,	5	 );
			IceBlock	 = CraftAttInfo( 	3	,	4	,	0	,	0	,	0	,	10	,	11	,	85	,	100	,	50	,	0	,	0	,	0	,	100	,	0	,	0	 );
			JadeBlock	 = CraftAttInfo( 	4	,	1	,	1	,	1	,	1	,	10	,	11	,	85	,	100	,	0	,	10	,	0	,	20	,	100	,	40	,	40	 );
			MarbleBlock	 = CraftAttInfo( 	4	,	1	,	1	,	1	,	1	,	10	,	11	,	85	,	100	,	0	,	0	,	0	,	0	,	150	,	0	,	0	 );
			OnyxBlock	 = CraftAttInfo( 	2	,	1	,	1	,	1	,	1	,	10	,	11	,	85	,	100	,	20	,	20	,	20	,	20	,	100	,	40	,	30	 );
			QuartzBlock	 = CraftAttInfo( 	4	,	3	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	25	,	25	,	0	,	100	,	20	,	0	 );
			RubyBlock	 = CraftAttInfo( 	2	,	0	,	4	,	0	,	0	,	10	,	11	,	85	,	100	,	0	,	60	,	0	,	0	,	100	,	0	,	10	 );
			SapphireBlock	 = CraftAttInfo( 	5	,	3	,	3	,	3	,	3	,	10	,	11	,	85	,	100	,	0	,	30	,	0	,	0	,	100	,	0	,	0	 );
			SilverBlock	 = CraftAttInfo( 	3	,	1	,	2	,	2	,	1	,	10	,	11	,	85	,	100	,	20	,	20	,	20	,	20	,	100	,	0	,	20	 );
			SpinelBlock	 = CraftAttInfo( 	2	,	2	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	0	,	30	,	0	,	100	,	0	,	0	 );
			StarRubyBlock	 = CraftAttInfo( 	3	,	0	,	3	,	0	,	0	,	10	,	11	,	85	,	100	,	0	,	15	,	15	,	0	,	100	,	10	,	10	 );
			TopazBlock	 = CraftAttInfo( 	0	,	2	,	2	,	2	,	2	,	10	,	11	,	85	,	100	,	0	,	0	,	20	,	20	,	100	,	10	,	0	 );
			CaddelliteBlock	 = CraftAttInfo( 	7	,	4	,	4	,	7	,	4	,	20	,	22	,	170	,	200	,	0	,	0	,	50	,	0	,	200	,	0	,	0	 );
																																				
			DemonSkin	 = CraftAttInfo( 	2	,	0	,	3	,	2	,	2	,	10	,	11	,	50	,	100	,	0	,	50	,	0	,	0	,	50	,	0	,	20	 );
			DragonSkin	 = CraftAttInfo( 	2	,	2	,	2	,	2	,	2	,	10	,	11	,	50	,	100	,	20	,	20	,	20	,	20	,	50	,	0	,	0	 );
			NightmareSkin	 = CraftAttInfo( 	2	,	0	,	3	,	3	,	0	,	10	,	11	,	50	,	100	,	0	,	30	,	0	,	0	,	40	,	0	,	0	 );
			SnakeSkin	 = CraftAttInfo( 	4	,	0	,	0	,	0	,	4	,	10	,	11	,	50	,	100	,	0	,	0	,	0	,	50	,	60	,	0	,	0	 );
			TrollSkin	 = CraftAttInfo( 	4	,	1	,	0	,	0	,	3	,	10	,	11	,	50	,	100	,	0	,	0	,	0	,	0	,	60	,	0	,	0	 );
			UnicornSkin	 = CraftAttInfo( 	2	,	0	,	0	,	4	,	2	,	10	,	11	,	50	,	100	,	0	,	0	,	50	,	0	,	30	,	0	,	50	 );
			IcySkin	 = CraftAttInfo( 	4	,	5	,	0	,	2	,	2	,	10	,	11	,	50	,	100	,	50	,	0	,	0	,	0	,	30	,	0	,	0	 );
			Seaweed	 = CraftAttInfo( 	4	,	2	,	1	,	2	,	4	,	10	,	11	,	50	,	100	,	0	,	0	,	0	,	25	,	20	,	50	,	0	 );
			LavaSkin	 = CraftAttInfo( 	4	,	0	,	5	,	2	,	2	,	10	,	11	,	50	,	100	,	0	,	80	,	0	,	0	,	40	,	0	,	0	 );
			DeadSkin	 = CraftAttInfo( 	2	,	4	,	1	,	2	,	4	,	10	,	11	,	50	,	100	,	0	,	0	,	0	,	60	,	40	,	0	,	0	 );
																																				
			DrowSkeletal	 = CraftAttInfo( 	1	,	0	,	0	,	1	,	0	,	1	,	2	,	40	,	100	,	0	,	0	,	25	,	0	,	5	,	0	,	5	 );
			OrcSkeletal	 = CraftAttInfo( 	2	,	1	,	1	,	0	,	0	,	2	,	2	,	45	,	100	,	0	,	0	,	0	,	0	,	10	,	5	,	0	 );
			ReptileSkeletal	 = CraftAttInfo( 	2	,	0	,	0	,	0	,	2	,	2	,	3	,	50	,	100	,	0	,	0	,	0	,	25	,	10	,	5	,	0	 );
			OgreSkeletal	 = CraftAttInfo( 	2	,	1	,	1	,	0	,	0	,	3	,	3	,	55	,	100	,	0	,	0	,	0	,	0	,	20	,	10	,	0	 );
			TrollSkeletal	 = CraftAttInfo( 	2	,	0	,	0	,	0	,	2	,	3	,	4	,	60	,	100	,	0	,	0	,	0	,	0	,	20	,	10	,	0	 );
			GargoyleSkeletal	 = CraftAttInfo( 	3	,	0	,	2	,	1	,	0	,	4	,	4	,	65	,	100	,	0	,	50	,	0	,	0	,	30	,	15	,	0	 );
			MinotaurSkeletal	 = CraftAttInfo( 	3	,	1	,	1	,	0	,	0	,	4	,	5	,	70	,	100	,	0	,	0	,	0	,	0	,	30	,	15	,	0	 );
			LycanSkeletal	 = CraftAttInfo( 	3	,	1	,	0	,	1	,	2	,	5	,	5	,	85	,	100	,	0	,	0	,	0	,	0	,	40	,	20	,	0	 );
			SharkSkeletal	 = CraftAttInfo( 	3	,	3	,	0	,	1	,	0	,	5	,	5	,	85	,	100	,	25	,	0	,	0	,	0	,	40	,	20	,	0	 );
			ColossalSkeletal	 = CraftAttInfo( 	4	,	1	,	1	,	1	,	0	,	5	,	5	,	85	,	100	,	0	,	0	,	0	,	0	,	40	,	20	,	0	 );
			MysticalSkeletal	 = CraftAttInfo( 	3	,	1	,	1	,	3	,	0	,	6	,	7	,	85	,	100	,	0	,	0	,	50	,	0	,	50	,	25	,	10	 );
			VampireSkeletal	 = CraftAttInfo( 	3	,	3	,	0	,	3	,	3	,	8	,	9	,	85	,	100	,	0	,	0	,	25	,	25	,	60	,	30	,	0	 );
			LichSkeletal	 = CraftAttInfo( 	2	,	3	,	0	,	4	,	3	,	8	,	9	,	85	,	100	,	25	,	0	,	0	,	25	,	60	,	30	,	0	 );
			SphinxSkeletal	 = CraftAttInfo( 	3	,	3	,	3	,	3	,	0	,	10	,	11	,	85	,	100	,	15	,	15	,	15	,	15	,	70	,	35	,	30	 );
			DevilSkeletal	 = CraftAttInfo( 	2	,	4	,	0	,	4	,	2	,	10	,	11	,	85	,	100	,	0	,	35	,	15	,	0	,	70	,	35	,	50	 );
			DracoSkeletal	 = CraftAttInfo( 	4	,	3	,	3	,	3	,	3	,	20	,	22	,	170	,	200	,	20	,	20	,	20	,	20	,	100	,	50	,	0	 );
			XenoSkeletal	 = CraftAttInfo( 	4	,	2	,	2	,	2	,	2	,	14	,	16	,	120	,	150	,	10	,	10	,	30	,	10	,	80	,	40	,	0	 );
			AndorianSkeletal	 = CraftAttInfo( 	3	,	5	,	1	,	3	,	1	,	14	,	16	,	120	,	150	,	0	,	50	,	0	,	0	,	80	,	35	,	0	 );
			CardassianSkeletal	 = CraftAttInfo( 	4	,	0	,	4	,	4	,	0	,	14	,	16	,	120	,	150	,	10	,	10	,	10	,	10	,	80	,	30	,	50	 );
			MartianSkeletal	 = CraftAttInfo( 	4	,	0	,	0	,	3	,	5	,	14	,	16	,	120	,	150	,	0	,	0	,	0	,	50	,	80	,	40	,	0	 );
			RodianSkeletal	 = CraftAttInfo( 	4	,	0	,	0	,	4	,	4	,	14	,	16	,	120	,	150	,	0	,	0	,	25	,	25	,	80	,	45	,	0	 );
			TuskenSkeletal	 = CraftAttInfo( 	4	,	0	,	4	,	4	,	0	,	14	,	16	,	120	,	150	,	0	,	25	,	25	,	0	,	80	,	30	,	0	 );
			TwilekSkeletal	 = CraftAttInfo( 	4	,	2	,	2	,	2	,	2	,	14	,	16	,	120	,	150	,	15	,	15	,	15	,	0	,	80	,	35	,	0	 );
			XindiSkeletal	 = CraftAttInfo( 	4	,	4	,	0	,	4	,	0	,	14	,	16	,	120	,	150	,	10	,	10	,	10	,	10	,	80	,	30	,	0	 );
			ZabrakSkeletal	 = CraftAttInfo( 	4	,	0	,	4	,	4	,	0	,	14	,	16	,	120	,	150	,	0	,	30	,	30	,	0	,	80	,	40	,	0	 );
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Clr;
		private int m_Dmg;
		private int m_Arm;
		private double m_Gold;
		private double m_Skill;
		private int m_Uses;
		private int m_Weight;
		private int m_Bonus;
		private int m_Xtra;
		private	int m_WepArmor;
		private int m_CraftText;
		private int m_MaterialText;
		private int m_LowCaseText;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Clr{ get{ return m_Clr; } }
		public int Dmg{ get{ return m_Dmg; } }
		public int Arm{ get{ return m_Arm; } }
		public double Gold{ get{ return m_Gold; } }
		public double Skill{ get{ return m_Skill; } }
		public int Uses{ get{ return m_Uses; } }
		public int Weight{ get{ return m_Weight; } }
		public int Bonus{ get{ return m_Bonus; } }
		public int Xtra{ get{ return m_Xtra; } }
		public int WepArmor{ get{ return m_WepArmor; } }
		public int CraftText{ get{ return m_CraftText; } }
		public int MaterialText{ get{ return m_MaterialText; } }
		public int LowCaseText{ get{ return m_LowCaseText; } }
		public string Name{ get{ return m_Name; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int clr, int dmg, int ar, double gold, double skill, int uses, int weight, int bonus, int xtra, int weparm, int num1, int num2, int num3, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;			// Hue for items
			m_Clr = clr;			// Hue for creatures
			m_Dmg = dmg;			// Damage Mod
			m_Arm = ar;				// Armor Mod
			m_Gold = gold;			// Gold Mod
			m_Skill = skill;		// Skill Required
			m_Uses = uses;			// Instrument & Fishing Pole Uses
			m_Weight = weight;		// Ten Foot Pole Weight
			m_Bonus = bonus;		// Ten Foot Pole & Fishing Pole Effectiveness
			m_Xtra = xtra;			// Horse Barding Bonus & Spyglass bonus
			m_WepArmor = weparm;	// Indicates if a Weapon will get Half of the Armor Bonuses
			m_CraftText = num1;		// Text Like: GOLD (100)
			m_MaterialText = num2;	// Text Like: Gold Ingot
			m_LowCaseText = num3;	// Text Like: gold
			m_Name = name;
			m_AttributeInfo = attributeInfo;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for ( int i = 0; i < resourceTypes.Length; ++i )
				CraftResources.RegisterType( resourceTypes[i], resource );
		}
	}

	public class CraftResources
	{
			//					   Item		NPC					Gold			Skill						Cliloc		Cliloc		Cliloc
			//					   Hue		Clr		Dmg		Arm	Xtra			Need	Use	Wgt	Bon	Xtr	WAr	CRFT 0		Mateial		LowCase		Name	Attribute	Resource	Begin Resource Types

			private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x000,	0x000,	0	,	0	,	1.00	,	0.0	,	0	,	0	,	0	,	0	,	0	,	1044022	,	1044036	,	1053109,	 "Iron",	CraftAttributeInfo.Blank,	CraftResource.Iron,typeof( IronIngot ),	typeof( IronOre ),	typeof( Granite ) ),	
			new CraftResourceInfo( 0x436, 	0x973,	1	,	1	,	1.25	,	65.0	,	10	,	2	,	3	,	1	,	0	,	1044023	,	1074916	,	1053108,	 "Dull Copper",	CraftAttributeInfo.DullCopper,	CraftResource.DullCopper,	typeof( DullCopperIngot ),	typeof( DullCopperOre ),	typeof( DullCopperGranite ) ),
			new CraftResourceInfo( 0x445, 	0x966,	2	,	2	,	1.50	,	70.0	,	20	,	4	,	6	,	2	,	0	,	1044024	,	1074917	,	1053107,	 "Shadow Iron",	CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron,	typeof( ShadowIronIngot ),	typeof( ShadowIronOre ),	typeof( ShadowIronGranite ) ),
			new CraftResourceInfo( 0x435, 	0x54E,	3	,	3	,	1.75	,	75.0	,	30	,	6	,	9	,	3	,	0	,	1044025	,	1074918	,	1053106,	 "Copper",	CraftAttributeInfo.Copper,	CraftResource.Copper,	typeof( CopperIngot ),	typeof( CopperOre ),	typeof( CopperGranite ) ),
			new CraftResourceInfo( 0x433, 	0x972,	4	,	4	,	2.00	,	80.0	,	40	,	8	,	12	,	4	,	0	,	1044026	,	1074919	,	1053105,	 "Bronze",	CraftAttributeInfo.Bronze,	CraftResource.Bronze,	typeof( BronzeIngot ),	typeof( BronzeOre ),	typeof( BronzeGranite ) ),
			new CraftResourceInfo( 0x43A, 	0x8A5,	4	,	5	,	2.25	,	85.0	,	50	,	10	,	15	,	5	,	0	,	1044027	,	1074920	,	1053104,	 "Gold",	CraftAttributeInfo.Golden,	CraftResource.Gold,typeof( GoldIngot ),	typeof( GoldOre ),	typeof( GoldGranite ) ),	
			new CraftResourceInfo( 0x424, 	0x979,	5	,	6	,	2.50	,	90.0	,	60	,	12	,	18	,	6	,	0	,	1044028	,	1074921	,	1053103,	 "Agapite",	CraftAttributeInfo.Agapite,	CraftResource.Agapite,	typeof( AgapiteIngot ),	typeof( AgapiteOre ),	typeof( AgapiteGranite ) ),
			new CraftResourceInfo( 0x44C, 	0x89F,	5	,	7	,	2.75	,	95.0	,	70	,	14	,	21	,	7	,	0	,	1044029	,	1074922	,	1053102,	 "Verite",	CraftAttributeInfo.Verite,	CraftResource.Verite,	typeof( VeriteIngot ),	typeof( VeriteOre ),	typeof( VeriteGranite ) ),
			new CraftResourceInfo( 0x44B, 	0x8AB,	6	,	8	,	3.00	,	99.0	,	80	,	16	,	24	,	8	,	0	,	1044030	,	1074923	,	1053101,	 "Valorite",	CraftAttributeInfo.Valorite,	CraftResource.Valorite,	typeof( ValoriteIngot ),	typeof( ValoriteOre ),	typeof( ValoriteGranite ) ),
			new CraftResourceInfo( 0x43F, 	0x847,	6	,	9	,	3.10	,	99.0	,	90	,	18	,	27	,	9	,	0	,	1036173	,	1036174	,	1036175,	 "Nepturite",	CraftAttributeInfo.Nepturite,	CraftResource.Nepturite,	typeof( NepturiteIngot ),	typeof( NepturiteOre ),	typeof( NepturiteGranite ) ),
			new CraftResourceInfo( 0x440, 	0x4AE,	6	,	9	,	3.10	,	99.0	,	100	,	20	,	30	,	10	,	0	,	1036162	,	1036164	,	1036165,	 "Obsidian",	CraftAttributeInfo.Obsidian,	CraftResource.Obsidian,	typeof( ObsidianIngot ),	typeof( ObsidianOre ),	typeof( ObsidianGranite ) ),
			new CraftResourceInfo( 0x449, 	0x42A,	7	,	10	,	3.25	,	99.0	,	110	,	22	,	33	,	11	,	0	,	1036144	,	1036145	,	1036146,	 "Steel",	CraftAttributeInfo.Steel,	CraftResource.Steel,	typeof( SteelIngot ) ),		
			new CraftResourceInfo( 0x432, 	0x7B7,	8	,	11	,	3.50	,	105.0	,	120	,	24	,	36	,	12	,	0	,	1036152	,	1036153	,	1036154,	 "Brass",	CraftAttributeInfo.Brass,	CraftResource.Brass,	typeof( BrassIngot ) ),		
			new CraftResourceInfo( 0x43E, 	0x482,	9	,	12	,	3.75	,	110.0	,	130	,	26	,	39	,	13	,	0	,	1036137	,	1036138	,	1036139,	 "Mithril",	CraftAttributeInfo.Mithril,	CraftResource.Mithril,	typeof( MithrilIngot ),	typeof( MithrilOre ),	typeof( MithrilGranite ) ),
			new CraftResourceInfo( 0x44D, 	0x4F6,	9	,	12	,	3.75	,	115.0	,	140	,	27	,	41	,	14	,	1	,	1034437	,	1034438	,	1034439,	 "Xormite",	CraftAttributeInfo.Xormite,	CraftResource.Xormite,	typeof( XormiteIngot ),	typeof( XormiteOre ),	typeof( XormiteGranite ) ),
			new CraftResourceInfo( 0x437, 	0x437,	11	,	14	,	4.50	,	120.0	,	160	,	28	,	42	,	15	,	1	,	1036181	,	1036182	,	1036183,	 "Dwarven",	CraftAttributeInfo.Dwarven,	CraftResource.Dwarven,	typeof( DwarvenIngot ),	typeof( DwarvenOre ),	typeof( DwarvenGranite ) ),
			new CraftResourceInfo( 0x8C1,	0x8C1,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1063982	,	1063983	,	1063981,	 "Agrinium",	CraftAttributeInfo.Agrinium,	CraftResource.Agrinium,	typeof( AgriniumIngot ) ),		
			new CraftResourceInfo( 0x6F8,	0x6F8,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1063986	,	1063987	,	1063985,	 "Beskar",	CraftAttributeInfo.Beskar,	CraftResource.Beskar,	typeof( BeskarIngot ) ),		
			new CraftResourceInfo( 0x829,	0x829,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1063990	,	1063991	,	1063989,	 "Carbonite",	CraftAttributeInfo.Carbonite,	CraftResource.Carbonite,	typeof( CarboniteIngot ) ),		
			new CraftResourceInfo( 0x82C,	0x82C,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1063994	,	1063995	,	1063993,	 "Cortosis",	CraftAttributeInfo.Cortosis,	CraftResource.Cortosis,	typeof( CortosisIngot ) ),		
			new CraftResourceInfo( 0x7A9,	0x7A9,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1063998	,	1063999	,	1063997,	 "Durasteel",	CraftAttributeInfo.Durasteel,	CraftResource.Durasteel,	typeof( DurasteelIngot ) ),		
			new CraftResourceInfo( 0x877,	0x877,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064002	,	1064003	,	1064001,	 "Durite",	CraftAttributeInfo.Durite,	CraftResource.Durite,	typeof( DuriteIngot ) ),		
			new CraftResourceInfo( 0x775,	0x775,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064006	,	1064007	,	1064005,	 "Farium",	CraftAttributeInfo.Farium,	CraftResource.Farium,	typeof( FariumIngot ) ),		
			new CraftResourceInfo( 0x77F,	0x77F,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064010	,	1064011	,	1064009,	 "Laminasteel",	CraftAttributeInfo.Laminasteel,	CraftResource.Laminasteel,	typeof( LaminasteelIngot ) ),		
			new CraftResourceInfo( 0x870,	0x870,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064014	,	1064015	,	1064013,	 "Neuranium",	CraftAttributeInfo.Neuranium,	CraftResource.Neuranium,	typeof( NeuraniumIngot ) ),		
			new CraftResourceInfo( 0xAF8,	0xAF8,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064018	,	1064019	,	1064017,	 "Phrik",	CraftAttributeInfo.Phrik,	CraftResource.Phrik,	typeof( PhrikIngot ) ),		
			new CraftResourceInfo( 0x6F6,	0x6F6,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064022	,	1064023	,	1064021,	 "Promethium",	CraftAttributeInfo.Promethium,	CraftResource.Promethium,	typeof( PromethiumIngot ) ),		
			new CraftResourceInfo( 0x705,	0x705,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064026	,	1064027	,	1064025,	 "Quadranium",	CraftAttributeInfo.Quadranium,	CraftResource.Quadranium,	typeof( QuadraniumIngot ) ),		
			new CraftResourceInfo( 0xB42,	0xB42,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064030	,	1064031	,	1064029,	 "Songsteel",	CraftAttributeInfo.Songsteel,	CraftResource.Songsteel,	typeof( SongsteelIngot ) ),		
			new CraftResourceInfo( 0xB70,	0xB70,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064034	,	1064035	,	1064033,	 "Titanium",	CraftAttributeInfo.Titanium,	CraftResource.Titanium,	typeof( TitaniumIngot ) ),		
			new CraftResourceInfo( 0x8C3,	0x8C3,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064038	,	1064039	,	1064037,	 "Trimantium",	CraftAttributeInfo.Trimantium,	CraftResource.Trimantium,	typeof( TrimantiumIngot ) ),		
			new CraftResourceInfo( 0x701,	0x701,	10	,	13	,	4.25	,	117.0	,	150	,	27	,	41	,	14	,	1	,	1064042	,	1064043	,	1064041,	 "Xonolite",	CraftAttributeInfo.Xonolite,	CraftResource.Xonolite,	typeof( XonoliteIngot ) )		
			};																														
			private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x807,	0x66D,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060875	,	1053129	,	1063788,	 "Crimson",	CraftAttributeInfo.RedScales,	CraftResource.RedScales,	typeof( RedScales ) ),		
			new CraftResourceInfo( 0x809,	0x8A8,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060876	,	1053130	,	1053104,	 "Golden",	CraftAttributeInfo.YellowScales,	CraftResource.YellowScales,	typeof( YellowScales ) ),		
			new CraftResourceInfo( 0x803,	0x455,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060877	,	1053131	,	1063790,	 "Dark",	CraftAttributeInfo.BlackScales,	CraftResource.BlackScales,	typeof( BlackScales ) ),		
			new CraftResourceInfo( 0x806,	0x851,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060878	,	1053132	,	1063791,	 "Viridian",	CraftAttributeInfo.GreenScales,	CraftResource.GreenScales,	typeof( GreenScales ) ),		
			new CraftResourceInfo( 0x808,	0x8FD,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060879	,	1053133	,	1063792,	 "Ivory",	CraftAttributeInfo.WhiteScales,	CraftResource.WhiteScales,	typeof( WhiteScales ) ),		
			new CraftResourceInfo( 0x804,	0x8B0,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1060880	,	1053134	,	1063793,	 "Azure",	CraftAttributeInfo.BlueScales,	CraftResource.BlueScales,	typeof( BlueScales ) ),		
			new CraftResourceInfo( 0x805,	0x805,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054017	,	1054016	,	1063794,	 "Dinosaur",	CraftAttributeInfo.DinosaurScales,	CraftResource.DinosaurScales,	typeof( DinosaurScales ) ),		
			new CraftResourceInfo( 0xB80,	0xB80,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054153	,	1054019	,	1063820,	 "Metallic",	CraftAttributeInfo.MetallicScales,	CraftResource.MetallicScales,	typeof( MetallicScales ) ),		
			new CraftResourceInfo( 0x436, 	0x973,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054154	,	1054026	,	1063822,	 "Brazen",	CraftAttributeInfo.BrazenScales,	CraftResource.BrazenScales,	typeof( BrazenScales ) ),		
			new CraftResourceInfo( 0x435, 	0x54E,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054155	,	1054027	,	1063824,	 "Umber",	CraftAttributeInfo.UmberScales,	CraftResource.UmberScales,	typeof( UmberScales ) ),		
			new CraftResourceInfo( 0x424, 	0x979,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054156	,	1054028	,	1063826,	 "Violet",	CraftAttributeInfo.VioletScales,	CraftResource.VioletScales,	typeof( VioletScales ) ),		
			new CraftResourceInfo( 0x449, 	0x42A,	4	,	5	,	2.40	,	45.0	,	90	,	20	,	32	,	10	,	1	,	1054157	,	1054029	,	1063828,	 "Platinum",	CraftAttributeInfo.PlatinumScales,	CraftResource.PlatinumScales,	typeof( PlatinumScales ) ),		
			new CraftResourceInfo( 0x99D,	0x99D,	6	,	9	,	3.40	,	115.0	,	90	,	26	,	32	,	10	,	1	,	1054158	,	1060096	,	1063830,	 "Cadalyte",	CraftAttributeInfo.CadalyteScales,	CraftResource.CadalyteScales,	typeof( CadalyteScales ) ),		
			new CraftResourceInfo( 0x5D6,	0x5D6,	5	,	7	,	3.00	,	110.0	,	90	,	22	,	32	,	10	,	1	,	1064170	,	1064171	,	1064172,	 "Gorn",	CraftAttributeInfo.GornScales,	CraftResource.CadalyteScales,	typeof( GornScales ) ),		
			new CraftResourceInfo( 0x5D8,	0x5D8,	5	,	7	,	3.00	,	110.0	,	90	,	22	,	32	,	10	,	1	,	1064174	,	1064175	,	1064176,	 "Trandoshan",	CraftAttributeInfo.TrandoshanScales,	CraftResource.CadalyteScales,	typeof( TrandoshanScales ) ),		
			new CraftResourceInfo( 0x5D5,	0x5D5,	5	,	7	,	3.00	,	110.0	,	90	,	22	,	32	,	10	,	1	,	1064178	,	1064179	,	1064180,	 "Silurian",	CraftAttributeInfo.SilurianScales,	CraftResource.CadalyteScales,	typeof( SilurianScales ) ),		
			new CraftResourceInfo( 0x692,	0x692,	5	,	7	,	3.00	,	110.0	,	90	,	22	,	32	,	10	,	1	,	1064182	,	1064183	,	1064184,	 "Krayt",	CraftAttributeInfo.KraytScales,	CraftResource.CadalyteScales,	typeof( KraytScales ) )		
			};																														
			private static CraftResourceInfo[] m_SpecialInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 2859,	2859,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064088	,	1064102	,	1063811,	 "Spectral",	CraftAttributeInfo.SpectralSpec,	CraftResource.SpectralSpec,	typeof( SpectralSpec ) ),		
			new CraftResourceInfo( 2860,	2860,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064089	,	1064103	,	1063812,	 "Dread",	CraftAttributeInfo.DreadSpec,	CraftResource.DreadSpec,	typeof( DreadSpec ) ),		
			new CraftResourceInfo( 2937,	2937,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064090	,	1064104	,	1063813,	 "Ghoulish",	CraftAttributeInfo.GhoulishSpec,	CraftResource.GhoulishSpec,	typeof( GhoulishSpec ) ),		
			new CraftResourceInfo( 2817,	2817,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064091	,	1064105	,	1063814,	 "Wyrm",	CraftAttributeInfo.WyrmSpec,	CraftResource.WyrmSpec,	typeof( WyrmSpec ) ),		
			new CraftResourceInfo( 2882,	2882,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064092	,	1064106	,	1063815,	 "Holy",	CraftAttributeInfo.HolySpec,	CraftResource.HolySpec,	typeof( HolySpec ) ),		
			new CraftResourceInfo( 1194,	1194,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064093	,	1064107	,	1063816,	 "Bloodless",	CraftAttributeInfo.BloodlessSpec,	CraftResource.BloodlessSpec,	typeof( BloodlessSpec ) ),		
			new CraftResourceInfo( 2815,	2815,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064094	,	1064108	,	1063817,	 "Gilded",	CraftAttributeInfo.GildedSpec,	CraftResource.GildedSpec,	typeof( GildedSpec ) ),		
			new CraftResourceInfo( 2858,	2858,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064095	,	1064109	,	1063818,	 "Demilich",	CraftAttributeInfo.DemilichSpec,	CraftResource.DemilichSpec,	typeof( DemilichSpec ) ),		
			new CraftResourceInfo( 2867,	2867,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	1	,	1064096	,	1064110	,	1063819,	 "Wintry",	CraftAttributeInfo.WintrySpec,	CraftResource.WintrySpec,	typeof( WintrySpec ) ),		
			new CraftResourceInfo( 0xB54,	0xB54,	3	,	6	,	1.60	,	80.0	,	30	,	6	,	9	,	3	,	0	,	1064097	,	1064111	,	1064077,	 "Fire",	CraftAttributeInfo.FireSpec,	CraftResource.FireSpec,	typeof( FireSpec ) ),		
			new CraftResourceInfo( 0xB57,	0xB57,	3	,	6	,	1.60	,	80.0	,	30	,	6	,	9	,	3	,	0	,	1064098	,	1064112	,	1064079,	 "Cold",	CraftAttributeInfo.ColdSpec,	CraftResource.ColdSpec,	typeof( ColdSpec ) ),		
			new CraftResourceInfo( 0xB51,	0xB51,	3	,	6	,	1.60	,	80.0	,	30	,	6	,	9	,	3	,	0	,	1064099	,	1064113	,	1064081,	 "Venom",	CraftAttributeInfo.PoisSpec,	CraftResource.PoisSpec,	typeof( PoisSpec ) ),		
			new CraftResourceInfo( 0xAFE,	0xAFE,	3	,	6	,	1.60	,	80.0	,	30	,	6	,	9	,	3	,	0	,	1064100	,	1064114	,	1064083,	 "Energy",	CraftAttributeInfo.EngySpec,	CraftResource.EngySpec,	typeof( EngySpec ) ),		
			new CraftResourceInfo( 1072,	1072,	8	,	16	,	4.20	,	120.0	,	150	,	27	,	41	,	14	,	1	,	1064101	,	1064115	,	1018194,	 "Exodus",	CraftAttributeInfo.ExodusSpec,	CraftResource.ExodusSpec,	typeof( ExodusSpec ) ),		
			new CraftResourceInfo( 0x9ED,	0x9ED,	5	,	10	,	3.00	,	110.0	,	130	,	26	,	42	,	13	,	0	,	1064116	,	1064117	,	1064119,	 "Turtle Shell",	CraftAttributeInfo.TurtleSpec,	CraftResource.TurtleSpec,	typeof( TurtleSpec ) )		
			};																														
			private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x000, 	0x000,	0	,	0	,	1.00	,	0.0	,	0	,	0	,	0	,	0	,	0	,	1049150	,	1034455	,	1049353,	 "Normal",	CraftAttributeInfo.Blank,	CraftResource.RegularLeather,	typeof( Leather ),	typeof( Hides ) ),	
			new CraftResourceInfo( 0x69C, 	0x69C,	1	,	1	,	1.25	,	55.0	,	10	,	2	,	3	,	1	,	0	,	1049152	,	1034457	,	1061117,	 "Lizard",	CraftAttributeInfo.Horned,	CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),	
			new CraftResourceInfo( 0x69E, 	0x69E,	2	,	2	,	1.50	,	60.0	,	20	,	4	,	6	,	2	,	0	,	1049153	,	1034458	,	1061116,	 "Serpent",	CraftAttributeInfo.Barbed,	CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),	
			new CraftResourceInfo( 0x69D, 	0x69D,	3	,	3	,	1.75	,	65.0	,	30	,	6	,	9	,	3	,	0	,	1034403	,	1034459	,	1034413,	 "Necrotic",	CraftAttributeInfo.Necrotic,	CraftResource.NecroticLeather,	typeof( NecroticLeather ),	typeof( NecroticHides ) ),	
			new CraftResourceInfo( 0x69F, 	0x69F,	4	,	4	,	2.00	,	70.0	,	40	,	8	,	12	,	4	,	0	,	1034414	,	1034460	,	1034424,	 "Volcanic",	CraftAttributeInfo.Volcanic,	CraftResource.VolcanicLeather,	typeof( VolcanicLeather ),	typeof( VolcanicHides ) ),	
			new CraftResourceInfo( 0x699, 	0x699,	4	,	5	,	2.25	,	75.0	,	50	,	10	,	15	,	5	,	0	,	1034425	,	1034461	,	1034435,	 "Frozen",	CraftAttributeInfo.Frozen,	CraftResource.FrozenLeather,	typeof( FrozenLeather ),	typeof( FrozenHides ) ),	
			new CraftResourceInfo( 0x696, 	0x696,	5	,	6	,	2.50	,	80.0	,	60	,	12	,	18	,	6	,	0	,	1049151	,	1034456	,	1061118,	 "Deep Sea",	CraftAttributeInfo.Spined,	CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),	
			new CraftResourceInfo( 0x69A, 	0x69A,	5	,	7	,	2.75	,	85.0	,	70	,	14	,	21	,	7	,	0	,	1034370	,	1034462	,	1034380,	 "Goliath",	CraftAttributeInfo.Goliath,	CraftResource.GoliathLeather,	typeof( GoliathLeather ),	typeof( GoliathHides ) ),	
			new CraftResourceInfo( 0x698, 	0x698,	6	,	8	,	3.00	,	90.0	,	80	,	16	,	24	,	8	,	0	,	1034381	,	1034463	,	1034391,	 "Draconic",	CraftAttributeInfo.Draconic,	CraftResource.DraconicLeather,	typeof( DraconicLeather ),	typeof( DraconicHides ) ),	
			new CraftResourceInfo( 0x69B, 	0x69B,	7	,	9	,	3.25	,	85.0	,	90	,	18	,	27	,	9	,	0	,	1034392	,	1034464	,	1034402,	 "Hellish",	CraftAttributeInfo.Hellish,	CraftResource.HellishLeather,	typeof( HellishLeather ),	typeof( HellishHides ) ),	
			new CraftResourceInfo( 0x697, 	0x697,	8	,	10	,	3.50	,	99.0	,	100	,	20	,	30	,	10	,	1	,	1036104	,	1034465	,	1036161,	 "Dinosaur",	CraftAttributeInfo.Dinosaur,	CraftResource.DinosaurLeather,	typeof( DinosaurLeather ),	typeof( DinosaurHides ) ),	
			new CraftResourceInfo( 0x695, 	0x695,	9	,	11	,	3.75	,	99.0	,	110	,	22	,	33	,	11	,	1	,	1034444	,	1034466	,	1034454,	 "Alien",	CraftAttributeInfo.Alien,	CraftResource.AlienLeather,	typeof( AlienLeather ),	typeof( AlienHides ) ),	
			new CraftResourceInfo( 0xAF8,	0xAF8,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063938	,	1063939	,	1063937,	 "Adesote",	CraftAttributeInfo.Adesote,	CraftResource.Adesote,	typeof( AdesoteLeather ) ),		
			new CraftResourceInfo( 0x829,	0x829,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063942	,	1063943	,	1063941,	 "Biomesh",	CraftAttributeInfo.Biomesh,	CraftResource.Biomesh,	typeof( BiomeshLeather ) ),		
			new CraftResourceInfo( 0xB57,	0xB57,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063946	,	1063947	,	1063945,	 "Cerlin",	CraftAttributeInfo.Cerlin,	CraftResource.Cerlin,	typeof( CerlinLeather ) ),		
			new CraftResourceInfo( 0x8C1,	0x8C1,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063950	,	1063951	,	1063949,	 "Durafiber",	CraftAttributeInfo.Durafiber,	CraftResource.Durafiber,	typeof( DurafiberLeather ) ),		
			new CraftResourceInfo( 0x705,	0x705,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063954	,	1063955	,	1063953,	 "Flexicris",	CraftAttributeInfo.Flexicris,	CraftResource.Flexicris,	typeof( FlexicrisLeather ) ),		
			new CraftResourceInfo( 0x77F,	0x77F,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063958	,	1063959	,	1063957,	 "Hypercloth",	CraftAttributeInfo.Hypercloth,	CraftResource.Hypercloth,	typeof( HyperclothLeather ) ),		
			new CraftResourceInfo( 0x701,	0x701,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063962	,	1063963	,	1063961,	 "Nylar",	CraftAttributeInfo.Nylar,	CraftResource.Nylar,	typeof( NylarLeather ) ),		
			new CraftResourceInfo( 0x6F8,	0x6F8,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063966	,	1063967	,	1063965,	 "Nylonite",	CraftAttributeInfo.Nylonite,	CraftResource.Nylonite,	typeof( NyloniteLeather ) ),		
			new CraftResourceInfo( 0x6F6,	0x6F6,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063970	,	1063971	,	1063969,	 "Polyfiber",	CraftAttributeInfo.Polyfiber,	CraftResource.Polyfiber,	typeof( PolyfiberLeather ) ),		
			new CraftResourceInfo( 0x7A9,	0x7A9,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063974	,	1063975	,	1063973,	 "Syncloth",	CraftAttributeInfo.Syncloth,	CraftResource.Syncloth,	typeof( SynclothLeather ) ),		
			new CraftResourceInfo( 0x775,	0x775,	10	,	12	,	3.75	,	110.0	,	120	,	24	,	36	,	12	,	1	,	1063978	,	1063979	,	1063977,	 "Thermoweave",	CraftAttributeInfo.Thermoweave,	CraftResource.Thermoweave,	typeof( ThermoweaveLeather ) )		
			};																														
			private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x000,	0x000,	0	,	0	,	1.00	,	0.0	,	0	,	0	,	0	,	0	,	0	,	1072643	,	1015101	,	1011542,	 "Normal",	CraftAttributeInfo.Blank,	CraftResource.RegularWood,	typeof( Board ),	typeof( Log ) ),	
			new CraftResourceInfo( 0x509,	0x509,	1	,	1	,	1.20	,	65.0	,	10	,	2	,	3	,	1	,	0	,	1095379	,	1095389	,	1095399,	 "Ash",	CraftAttributeInfo.AshTree,	CraftResource.AshTree,	typeof( AshBoard ),	typeof( AshLog ) ),	
			new CraftResourceInfo( 0x50A,	0x50A,	1	,	2	,	1.40	,	70.0	,	20	,	4	,	6	,	2	,	0	,	1095380	,	1095390	,	1095400,	 "Cherry",	CraftAttributeInfo.CherryTree,	CraftResource.CherryTree,	typeof( CherryBoard ),	typeof( CherryLog ) ),	
			new CraftResourceInfo( 0x50B,	0x50B,	2	,	3	,	1.60	,	75.0	,	30	,	6	,	9	,	3	,	0	,	1095381	,	1095391	,	1095401,	 "Ebony",	CraftAttributeInfo.EbonyTree,	CraftResource.EbonyTree,	typeof( EbonyBoard ),	typeof( EbonyLog ) ),	
			new CraftResourceInfo( 0x50E,	0x50E,	2	,	4	,	1.80	,	80.0	,	40	,	8	,	12	,	4	,	0	,	1095382	,	1095392	,	1095402,	 "Golden Oak",	CraftAttributeInfo.GoldenOakTree,	CraftResource.GoldenOakTree,	typeof( GoldenOakBoard ),	typeof( GoldenOakLog ) ),	
			new CraftResourceInfo( 0x508,	0x508,	3	,	5	,	2.00	,	85.0	,	50	,	10	,	15	,	5	,	0	,	1095383	,	1095393	,	1095403,	 "Hickory",	CraftAttributeInfo.HickoryTree,	CraftResource.HickoryTree,	typeof( HickoryBoard ),	typeof( HickoryLog ) ),	
			new CraftResourceInfo( 0x50F,	0x50F,	3	,	6	,	2.20	,	90.0	,	60	,	12	,	18	,	6	,	0	,	1095384	,	1095394	,	1095404,	 "Mahogany",	CraftAttributeInfo.MahoganyTree,	CraftResource.MahoganyTree,	typeof( MahoganyBoard ),	typeof( MahoganyLog ) ),	
			new CraftResourceInfo( 0x510,	0x510,	3	,	7	,	2.40	,	95.0	,	70	,	14	,	21	,	7	,	0	,	1095385	,	1095395	,	1095405,	 "Oak",	CraftAttributeInfo.OakTree,	CraftResource.OakTree,	typeof( OakBoard ),	typeof( OakLog ) ),	
			new CraftResourceInfo( 0x512,	0x512,	4	,	8	,	2.60	,	95.0	,	80	,	16	,	24	,	8	,	0	,	1095386	,	1095396	,	1095406,	 "Pine",	CraftAttributeInfo.PineTree,	CraftResource.PineTree,	typeof( PineBoard ),	typeof( PineLog ) ),	
			new CraftResourceInfo( 0x50D,	0x50D,	4	,	9	,	2.60	,	99.0	,	90	,	18	,	27	,	9	,	0	,	1095511	,	1095512	,	1095513,	 "Ghostwood",	CraftAttributeInfo.GhostTree,	CraftResource.GhostTree,	typeof( GhostBoard ),	typeof( GhostLog ) ),	
			new CraftResourceInfo( 0x513,	0x513,	4	,	10	,	2.80	,	99.0	,	100	,	20	,	30	,	10	,	0	,	1095387	,	1095397	,	1095407,	 "Rosewood",	CraftAttributeInfo.RosewoodTree,	CraftResource.RosewoodTree,	typeof( RosewoodBoard ),	typeof( RosewoodLog ) ),	
			new CraftResourceInfo( 0x514,	0x514,	5	,	11	,	3.00	,	99.0	,	110	,	22	,	33	,	11	,	0	,	1095388	,	1095398	,	1095408,	 "Walnut",	CraftAttributeInfo.WalnutTree,	CraftResource.WalnutTree,	typeof( WalnutBoard ),	typeof( WalnutLog ) ),	
			new CraftResourceInfo( 0x511,	0x511,	5	,	12	,	3.25	,	100.0	,	120	,	24	,	36	,	12	,	0	,	1095532	,	1095533	,	1095534,	 "Petrified",	CraftAttributeInfo.PetrifiedTree,	CraftResource.PetrifiedTree,	typeof( PetrifiedBoard ),	typeof( PetrifiedLog ) ),	
			new CraftResourceInfo( 0x507,	0x507,	6	,	13	,	2.40	,	105.0	,	130	,	26	,	39	,	13	,	0	,	1095409	,	1095410	,	1095510,	 "Driftwood",	CraftAttributeInfo.DriftwoodTree,	CraftResource.DriftwoodTree,	typeof( DriftwoodBoard ),	typeof( DriftwoodLog ) ),	
			new CraftResourceInfo( 0x50C,	0x50C,	7	,	14	,	3.40	,	110.0	,	140	,	27	,	41	,	14	,	1	,	1095535	,	1095536	,	1095537,	 "Elven",	CraftAttributeInfo.ElvenTree,	CraftResource.ElvenTree,	typeof( ElvenBoard ),	typeof( ElvenLog ) ),	
			new CraftResourceInfo( 0x775,	0x775,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064046	,	1064047	,	1064045,	 "Borl",	CraftAttributeInfo.BorlTree,	CraftResource.BorlTree,	typeof( BorlBoard ) ),		
			new CraftResourceInfo( 0x77F,	0x77F,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064050	,	1064051	,	1064049,	 "Cosian",	CraftAttributeInfo.CosianTree,	CraftResource.CosianTree,	typeof( CosianBoard ) ),		
			new CraftResourceInfo( 0x870,	0x870,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064054	,	1064055	,	1064053,	 "Greel",	CraftAttributeInfo.GreelTree,	CraftResource.GreelTree,	typeof( GreelBoard ) ),		
			new CraftResourceInfo( 0x948,	0x948,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064058	,	1064059	,	1064057,	 "Japor",	CraftAttributeInfo.JaporTree,	CraftResource.JaporTree,	typeof( JaporBoard ) ),		
			new CraftResourceInfo( 0x705,	0x705,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064062	,	1064063	,	1064061,	 "Kyshyyyk",	CraftAttributeInfo.KyshyyykTree,	CraftResource.KyshyyykTree,	typeof( KyshyyykBoard ) ),		
			new CraftResourceInfo( 0x877,	0x877,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064066	,	1064067	,	1064065,	 "Laroon",	CraftAttributeInfo.LaroonTree,	CraftResource.LaroonTree,	typeof( LaroonBoard ) ),		
			new CraftResourceInfo( 0x6F6,	0x6F6,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064070	,	1064071	,	1064069,	 "Teej",	CraftAttributeInfo.TeejTree,	CraftResource.TeejTree,	typeof( TeejBoard ) ),		
			new CraftResourceInfo( 0x6F8,	0x6F8,	8	,	15	,	3.50	,	115.0	,	150	,	28	,	42	,	15	,	1	,	1064074	,	1064075	,	1064073,	 "Veshok",	CraftAttributeInfo.VeshokTree,	CraftResource.VeshokTree,	typeof( VeshokBoard ) )		
			};																														
			private static CraftResourceInfo[] m_FabricInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x000,	0x000,	0	,	0	,	1.00	,	0.0	,	0	,	0	,	0	,	0	,	0	,	1064120	,	1064121	,	1064123,	 "Normal",	CraftAttributeInfo.Blank,	CraftResource.Fabric,	typeof( Fabric ) ),		
			new CraftResourceInfo( 0x8BC,	0x8BC,	1	,	1	,	1.20	,	45.0	,	10	,	2	,	3	,	1	,	0	,	1064124	,	1064125	,	1064127,	 "Furry",	CraftAttributeInfo.FurryFabric,	CraftResource.FurryFabric,	typeof( FurryFabric ) ),		
			new CraftResourceInfo( 0x911,	0x911,	1	,	2	,	1.40	,	50.0	,	20	,	4	,	6	,	2	,	0	,	1064128	,	1064129	,	1064131,	 "Wooly",	CraftAttributeInfo.WoolyFabric,	CraftResource.WoolyFabric,	typeof( WoolyFabric ) ),		
			new CraftResourceInfo( 0xAFE,	0xAFE,	2	,	3	,	1.60	,	60.0	,	30	,	6	,	9	,	3	,	0	,	1064132	,	1064133	,	1064135,	 "Silk",	CraftAttributeInfo.SilkFabric,	CraftResource.SilkFabric,	typeof( SilkFabric ) ),		
			new CraftResourceInfo( 0xB3B,	0xB3B,	3	,	4	,	1.80	,	65.0	,	40	,	8	,	12	,	4	,	0	,	1064136	,	1064137	,	1064139,	 "Haunted",	CraftAttributeInfo.HauntedFabric,	CraftResource.HauntedFabric,	typeof( HauntedFabric ) ),		
			new CraftResourceInfo( 0x9A3,	0x9A3,	4	,	5	,	2.00	,	70.0	,	50	,	10	,	15	,	5	,	0	,	1064140	,	1064141	,	1064142,	 "Arctic",	CraftAttributeInfo.ArcticFabric,	CraftResource.ArcticFabric,	typeof( ArcticFabric ) ),		
			new CraftResourceInfo( 0x981,	0x981,	4	,	5	,	2.20	,	75.0	,	60	,	12	,	18	,	6	,	0	,	1064144	,	1064145	,	1064147,	 "Pyre",	CraftAttributeInfo.PyreFabric,	CraftResource.PyreFabric,	typeof( PyreFabric ) ),		
			new CraftResourceInfo( 0xB0C,	0xB0C,	4	,	5	,	2.40	,	75.0	,	70	,	14	,	21	,	7	,	0	,	1064148	,	1064149	,	1064151,	 "Venomous",	CraftAttributeInfo.VenomousFabric,	CraftResource.VenomousFabric,	typeof( VenomousFabric ) ),		
			new CraftResourceInfo( 0x8E4,	0x8E4,	5	,	6	,	2.60	,	80.0	,	80	,	16	,	24	,	8	,	0	,	1064152	,	1064153	,	1064155,	 "Mysterious",	CraftAttributeInfo.MysteriousFabric,	CraftResource.MysteriousFabric,	typeof( MysteriousFabric ) ),		
			new CraftResourceInfo( 0x7B1,	0x7B1,	6	,	7	,	2.60	,	90.0	,	90	,	18	,	27	,	9	,	0	,	1064156	,	1064157	,	1064159,	 "Vile",	CraftAttributeInfo.VileFabric,	CraftResource.VileFabric,	typeof( VileFabric ) ),		
			new CraftResourceInfo( 0x8D7,	0x8D7,	6	,	7	,	2.80	,	99.0	,	100	,	20	,	30	,	10	,	1	,	1064160	,	1064161	,	1064163,	 "Divine",	CraftAttributeInfo.DivineFabric,	CraftResource.DivineFabric,	typeof( DivineFabric ) ),		
			new CraftResourceInfo( 0x870,	0x870,	7	,	8	,	3.00	,	105.0	,	110	,	22	,	33	,	11	,	1	,	1064164	,	1064165	,	1064167,	 "Fiendish",	CraftAttributeInfo.FiendishFabric,	CraftResource.FiendishFabric,	typeof( FiendishFabric ) )		
			};																														
			private static CraftResourceInfo[] m_BlockInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x8D5,	0x8D5,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063690	,	1063706	,	1063707,	 "Amethyst",	CraftAttributeInfo.AmethystBlock,	CraftResource.AmethystBlock,	typeof( AmethystBlocks ),	typeof( AmethystStone ) ),	
			new CraftResourceInfo( 0x950,	0x950,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063691	,	1063709	,	1063710,	 "Emerald",	CraftAttributeInfo.EmeraldBlock,	CraftResource.EmeraldBlock,	typeof( EmeraldBlocks ),	typeof( EmeraldStone ) ),	
			new CraftResourceInfo( 0x4A2,	0x4A2,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063692	,	1063712	,	1063713,	 "Garnet",	CraftAttributeInfo.GarnetBlock,	CraftResource.GarnetBlock,	typeof( GarnetBlocks ),	typeof( GarnetStone ) ),	
			new CraftResourceInfo( 0x8E2,	0xAF3,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063693	,	1063715	,	1063716,	 "Ice",	CraftAttributeInfo.IceBlock,	CraftResource.IceBlock,	typeof( IceBlocks ),	typeof( IceStone ) ),	
			new CraftResourceInfo( 0xB0C,	0xB0C,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063694	,	1063718	,	1063719,	 "Jade",	CraftAttributeInfo.JadeBlock,	CraftResource.JadeBlock,	typeof( JadeBlocks ),	typeof( JadeStone ) ),	
			new CraftResourceInfo( 0xB3B,	0xB3B,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063695	,	1063721	,	1063722,	 "Marble",	CraftAttributeInfo.MarbleBlock,	CraftResource.MarbleBlock,	typeof( MarbleBlocks ),	typeof( MarbleStone ) ),	
			new CraftResourceInfo( 0xB5E,	0x839,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063696	,	1063724	,	1063725,	 "Onyx",	CraftAttributeInfo.OnyxBlock,	CraftResource.OnyxBlock,	typeof( OnyxBlocks ),	typeof( OnyxStone ) ),	
			new CraftResourceInfo( 0x869,	0x84D,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063697	,	1063727	,	1063728,	 "Quartz",	CraftAttributeInfo.QuartzBlock,	CraftResource.QuartzBlock,	typeof( QuartzBlocks ),	typeof( QuartzStone ) ),	
			new CraftResourceInfo( 0x982,	0x982,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063698	,	1063730	,	1063731,	 "Ruby",	CraftAttributeInfo.RubyBlock,	CraftResource.RubyBlock,	typeof( RubyBlocks ),	typeof( RubyStone ) ),	
			new CraftResourceInfo( 0x5CE,	0x5CE,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063699	,	1063733	,	1063734,	 "Sapphire",	CraftAttributeInfo.SapphireBlock,	CraftResource.SapphireBlock,	typeof( SapphireBlocks ),	typeof( SapphireStone ) ),	
			new CraftResourceInfo( 0xB2A,	0xB2A,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063700	,	1063736	,	1063737,	 "Silver",	CraftAttributeInfo.SilverBlock,	CraftResource.SilverBlock,	typeof( SilverBlocks ),	typeof( SilverStone ) ),	
			new CraftResourceInfo( 0x7CB,	0x6DF,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063701	,	1063739	,	1063740,	 "Spinel",	CraftAttributeInfo.SpinelBlock,	CraftResource.SpinelBlock,	typeof( SpinelBlocks ),	typeof( SpinelStone ) ),	
			new CraftResourceInfo( 0x7CA,	0x7CA,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063702	,	1063742	,	1063743,	 "Star Ruby",	CraftAttributeInfo.StarRubyBlock,	CraftResource.StarRubyBlock,	typeof( StarRubyBlocks ),	typeof( StarRubyStone ) ),	
			new CraftResourceInfo( 0x856,	0x883,	5	,	12	,	3.40	,	85.0	,	140	,	20	,	32	,	12	,	1	,	1063703	,	1063745	,	1063746,	 "Topaz",	CraftAttributeInfo.TopazBlock,	CraftResource.TopazBlock,	typeof( TopazBlocks ),	typeof( TopazStone ) ),	
			new CraftResourceInfo( 0x99D,	0x99D,	8	,	16	,	4.00	,	115.0	,	200	,	28	,	42	,	15	,	1	,	1063704	,	1063748	,	1063749,	 "Caddellite",	CraftAttributeInfo.CaddelliteBlock,	CraftResource.CaddelliteBlock,	typeof( CaddelliteBlocks ),	typeof( CaddelliteStone ) )	
			};																														
			private static CraftResourceInfo[] m_SkinInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0xB1E,	0xB1E,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063750	,	1063757	,	1063758,	 "Demon",	CraftAttributeInfo.DemonSkin,	CraftResource.DemonSkin,	typeof( DemonSkins ) ),		
			new CraftResourceInfo( 0x960,	0x960,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063751	,	1063760	,	1063761,	 "Dragon",	CraftAttributeInfo.DragonSkin,	CraftResource.DragonSkin,	typeof( DragonSkins ) ),		
			new CraftResourceInfo( 0xB80,	0xB80,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063752	,	1063763	,	1063764,	 "Nightmare",	CraftAttributeInfo.NightmareSkin,	CraftResource.NightmareSkin,	typeof( NightmareSkins ) ),		
			new CraftResourceInfo( 0xB79,	0xB79,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063753	,	1063766	,	1063767,	 "Snake",	CraftAttributeInfo.SnakeSkin,	CraftResource.SnakeSkin,	typeof( SnakeSkins ) ),		
			new CraftResourceInfo( 0xB4C,	0xB4C,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063754	,	1063769	,	1063770,	 "Troll",	CraftAttributeInfo.TrollSkin,	CraftResource.TrollSkin,	typeof( TrollSkins ) ),		
			new CraftResourceInfo( 0xBB4,	0xBB4,	4	,	8	,	3.20	,	65.0	,	100	,	20	,	30	,	10	,	1	,	1063755	,	1063772	,	1063773,	 "Unicorn",	CraftAttributeInfo.UnicornSkin,	CraftResource.UnicornSkin,	typeof( UnicornSkins ) ),		
			new CraftResourceInfo( 0xB7A,	0xB7A,	6	,	10	,	3.40	,	75.0	,	100	,	24	,	40	,	12	,	1	,	1064084	,	1063775	,	1063776,	 "Icy",	CraftAttributeInfo.IcySkin,	CraftResource.IcySkin,	typeof( IcySkins ) ),		
			new CraftResourceInfo( 0xB17,	0xB17,	6	,	10	,	3.40	,	75.0	,	100	,	24	,	40	,	12	,	1	,	1064085	,	1063778	,	1063779,	 "Lava",	CraftAttributeInfo.LavaSkin,	CraftResource.LavaSkin,	typeof( LavaSkins ) ),		
			new CraftResourceInfo( 0x98D,	0x98D,	6	,	10	,	3.40	,	75.0	,	100	,	24	,	40	,	12	,	1	,	1064086	,	1063781	,	1063782,	 "Seaweed",	CraftAttributeInfo.Seaweed,	CraftResource.Seaweed,	typeof( Seaweeds ) ),		
			new CraftResourceInfo( 0xB4A,	0xB4A,	6	,	10	,	3.40	,	75.0	,	100	,	24	,	40	,	12	,	1	,	1064087	,	1063784	,	1063785,	 "Dead",	CraftAttributeInfo.DeadSkin,	CraftResource.DeadSkin,	typeof( DeadSkins ) )		
			};																														
			private static CraftResourceInfo[] m_SkeletalInfo = new CraftResourceInfo[]																														
			{																														
			new CraftResourceInfo( 0x000,	0x000,	0	,	0	,	1.00	,	0.0	,	0	,	0	,	0	,	0	,	0	,	1063832	,	1063833	,	1063835,	 "Brittle",	CraftAttributeInfo.Blank,	CraftResource.BrittleSkeletal,	typeof( BrittleSkeletal ) ),		
			new CraftResourceInfo( 0x424,	0x424,	1	,	1	,	1.20	,	55.0	,	10	,	2	,	3	,	1	,	0	,	1063840	,	1063841	,	1063843,	 "Drow",	CraftAttributeInfo.DrowSkeletal,	CraftResource.DrowSkeletal,	typeof( DrowSkeletal ) ),		
			new CraftResourceInfo( 0x44C,	0x44C,	1	,	2	,	1.20	,	60.0	,	20	,	4	,	6	,	2	,	0	,	1063844	,	1063845	,	1063847,	 "Orc",	CraftAttributeInfo.OrcSkeletal,	CraftResource.OrcSkeletal,	typeof( OrcSkeletal ) ),		
			new CraftResourceInfo( 0x806,	0x806,	2	,	3	,	1.40	,	65.0	,	30	,	6	,	9	,	3	,	0	,	1063848	,	1063849	,	1063851,	 "Reptile",	CraftAttributeInfo.ReptileSkeletal,	CraftResource.ReptileSkeletal,	typeof( ReptileSkeletal ) ),		
			new CraftResourceInfo( 0x5B2,	0x5B2,	2	,	4	,	1.40	,	70.0	,	40	,	8	,	12	,	4	,	0	,	1063852	,	1063853	,	1063855,	 "Ogre",	CraftAttributeInfo.OgreSkeletal,	CraftResource.OgreSkeletal,	typeof( OgreSkeletal ) ),		
			new CraftResourceInfo( 0x961,	0x961,	2	,	4	,	1.40	,	70.0	,	40	,	8	,	12	,	4	,	0	,	1063856	,	1063857	,	1063859,	 "Troll",	CraftAttributeInfo.TrollSkeletal,	CraftResource.TrollSkeletal,	typeof( TrollSkeletal ) ),		
			new CraftResourceInfo( 0x807,	0x807,	3	,	5	,	1.60	,	75.0	,	50	,	10	,	15	,	5	,	0	,	1063860	,	1063861	,	1063863,	 "Gargoyle",	CraftAttributeInfo.GargoyleSkeletal,	CraftResource.GargoyleSkeletal,	typeof( GargoyleSkeletal ) ),		
			new CraftResourceInfo( 0x83F,	0x83F,	3	,	6	,	1.60	,	80.0	,	60	,	12	,	18	,	6	,	0	,	1063864	,	1063865	,	1063867,	 "Minotaur",	CraftAttributeInfo.MinotaurSkeletal,	CraftResource.MinotaurSkeletal,	typeof( MinotaurSkeletal ) ),		
			new CraftResourceInfo( 0x436,	0x436,	3	,	7	,	1.60	,	85.0	,	70	,	14	,	21	,	7	,	0	,	1063868	,	1063869	,	1063871,	 "Lycan",	CraftAttributeInfo.LycanSkeletal,	CraftResource.LycanSkeletal,	typeof( LycanSkeletal ) ),		
			new CraftResourceInfo( 0x43F,	0x43F,	4	,	8	,	1.80	,	90.0	,	80	,	16	,	24	,	8	,	0	,	1063872	,	1063873	,	1063875,	 "Shark",	CraftAttributeInfo.SharkSkeletal,	CraftResource.SharkSkeletal,	typeof( SharkSkeletal ) ),		
			new CraftResourceInfo( 0x69A,	0x69A,	4	,	9	,	1.80	,	91.0	,	90	,	18	,	27	,	9	,	0	,	1063876	,	1063877	,	1063879,	 "Colossal",	CraftAttributeInfo.ColossalSkeletal,	CraftResource.ColossalSkeletal,	typeof( ColossalSkeletal ) ),		
			new CraftResourceInfo( 0x809,	0x809,	5	,	10	,	2.00	,	93.0	,	100	,	20	,	30	,	10	,	0	,	1063880	,	1063881	,	1063883,	 "Mystical",	CraftAttributeInfo.MysticalSkeletal,	CraftResource.MysticalSkeletal,	typeof( MysticalSkeletal ) ),		
			new CraftResourceInfo( 0x803,	0x803,	5	,	11	,	2.00	,	95.0	,	110	,	21	,	31	,	11	,	0	,	1063884	,	1063885	,	1063887,	 "Vampire",	CraftAttributeInfo.VampireSkeletal,	CraftResource.VampireSkeletal,	typeof( VampireSkeletal ) ),		
			new CraftResourceInfo( 0x808,	0x808,	6	,	12	,	2.20	,	97.0	,	120	,	22	,	32	,	12	,	0	,	1063888	,	1063889	,	1063891,	 "Lich",	CraftAttributeInfo.LichSkeletal,	CraftResource.LichSkeletal,	typeof( LichSkeletal ) ),		
			new CraftResourceInfo( 0x804,	0x804,	6	,	13	,	2.20	,	99.0	,	130	,	23	,	33	,	13	,	1	,	1063892	,	1063893	,	1063895,	 "Sphinx",	CraftAttributeInfo.SphinxSkeletal,	CraftResource.SphinxSkeletal,	typeof( SphinxSkeletal ) ),		
			new CraftResourceInfo( 0x648,	0x648,	7	,	15	,	2.40	,	102.0	,	150	,	24	,	34	,	14	,	1	,	1063896	,	1063897	,	1063899,	 "Devil",	CraftAttributeInfo.DevilSkeletal,	CraftResource.DevilSkeletal,	typeof( DevilSkeletal ) ),		
			new CraftResourceInfo( 0x437,	0x698,	8	,	17	,	2.40	,	105.0	,	170	,	25	,	35	,	15	,	1	,	1063836	,	1063837	,	1063839,	 "Draco",	CraftAttributeInfo.DracoSkeletal,	CraftResource.DracoSkeletal,	typeof( DracoSkeletal ) ),		
			new CraftResourceInfo( 0x44D,	0x44D,	9	,	18	,	3.00	,	110.0	,	180	,	28	,	38	,	16	,	1	,	1063900	,	1063901	,	1063903,	 "Xeno",	CraftAttributeInfo.XenoSkeletal,	CraftResource.XenoSkeletal,	typeof( XenoSkeletal ) ),		
			new CraftResourceInfo( 0xB3D,	0xB3D,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063906	,	1063907	,	1063905,	 "Andorian",	CraftAttributeInfo.AndorianSkeletal,	CraftResource.AndorianSkeletal,	typeof( AndorianSkeletal ) ),		
			new CraftResourceInfo( 0x986,	0x986,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063910	,	1063911	,	1063909,	 "Cardassian",	CraftAttributeInfo.CardassianSkeletal,	CraftResource.CardassianSkeletal,	typeof( CardassianSkeletal ) ),		
			new CraftResourceInfo( 0x6F6,	0x6F6,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063914	,	1063915	,	1063913,	 "Martian",	CraftAttributeInfo.MartianSkeletal,	CraftResource.MartianSkeletal,	typeof( MartianSkeletal ) ),		
			new CraftResourceInfo( 0x77F,	0x77F,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063918	,	1063919	,	1063917,	 "Rodian",	CraftAttributeInfo.RodianSkeletal,	CraftResource.RodianSkeletal,	typeof( RodianSkeletal ) ),		
			new CraftResourceInfo( 0x775,	0x775,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063922	,	1063923	,	1063921,	 "Tusken",	CraftAttributeInfo.TuskenSkeletal,	CraftResource.TuskenSkeletal,	typeof( TuskenSkeletal ) ),		
			new CraftResourceInfo( 0xAF8,	0xAF8,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063926	,	1063927	,	1063925,	 "Twi'lek",	CraftAttributeInfo.TwilekSkeletal,	CraftResource.TwilekSkeletal,	typeof( TwilekSkeletal ) ),		
			new CraftResourceInfo( 0x877,	0x877,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063930	,	1063931	,	1063929,	 "Xindi",	CraftAttributeInfo.XindiSkeletal,	CraftResource.XindiSkeletal,	typeof( XindiSkeletal ) ),		
			new CraftResourceInfo( 0xB01,	0xB01,	7	,	14	,	3.10	,	100.1	,	140	,	26	,	37	,	16	,	1	,	1063934	,	1063935	,	1063933,	 "Zabrak",	CraftAttributeInfo.ZabrakSkeletal,	CraftResource.ZabrakSkeletal,	typeof( ZabrakSkeletal ) )		
			};																														

		private static Hashtable m_TypeTable;

		public static void RegisterType( Type resourceType, CraftResource resource )
		{
			if ( m_TypeTable == null )
				m_TypeTable = new Hashtable();

			m_TypeTable[resourceType] = resource;
		}

		public static CraftResource GetFromType( Type resourceType )
		{
			if ( m_TypeTable == null )
				return CraftResource.None;

			object obj = m_TypeTable[resourceType];

			if ( !(obj is CraftResource) )
				return CraftResource.None;

			return (CraftResource)obj;
		}

		public static CraftResourceInfo GetInfo( CraftResource resource )
		{
			CraftResourceInfo[] list = null;

			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = m_LeatherInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
				case CraftResourceType.Block: list = m_BlockInfo; break;
				case CraftResourceType.Skin: list = m_SkinInfo; break;
				case CraftResourceType.Special: list = m_SpecialInfo; break;
				case CraftResourceType.Skeletal: list = m_SkeletalInfo; break;
				case CraftResourceType.Fabric: list = m_FabricInfo; break;
			}

			if ( list != null )
			{
				int index = GetIndex( resource );

				if ( index >= 0 && index < list.Length )
					return list[index];
			}

			return null;
		}

		public static CraftResourceType GetType( CraftResource resource )
		{
			if ( resource >= CraftResource.Iron && resource <= CraftResource.Xonolite )
				return CraftResourceType.Metal;

			if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.Thermoweave )
				return CraftResourceType.Leather;

			if ( resource >= CraftResource.SpectralSpec && resource <= CraftResource.TurtleSpec )
				return CraftResourceType.Special;

			if ( resource >= CraftResource.RedScales && resource <= CraftResource.KraytScales )
				return CraftResourceType.Scales;

			if ( resource >= CraftResource.RegularWood && resource <= CraftResource.VeshokTree )
				return CraftResourceType.Wood;

			if ( resource >= CraftResource.AmethystBlock && resource <= CraftResource.CaddelliteBlock )
				return CraftResourceType.Block;

			if ( resource >= CraftResource.DemonSkin && resource <= CraftResource.DeadSkin )
				return CraftResourceType.Skin;

			if ( resource >= CraftResource.BrittleSkeletal && resource <= CraftResource.ZabrakSkeletal )
				return CraftResourceType.Skeletal;

			if ( resource >= CraftResource.Fabric && resource <= CraftResource.FiendishFabric )
				return CraftResourceType.Fabric;

			return CraftResourceType.None;
		}

		public static Density GetDensity( Item item )
		{
			if ( GetType( item.Resource ) == CraftResourceType.Fabric || ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Cloth ) )
				return Density.Weak;
			else if ( GetType( item.Resource ) == CraftResourceType.Leather || ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Leather ) || ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Studded ) )
				return Density.Regular;
			else if ( GetType( item.Resource ) == CraftResourceType.Skin )
				return Density.Regular;
			else if ( GetType( item.Resource ) == CraftResourceType.Wood )
				return Density.Great;
			else if ( GetType( item.Resource ) == CraftResourceType.Skeletal || ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Bone ) )
				return Density.Great;
			else if ( GetType( item.Resource ) == CraftResourceType.Scales || ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Scaled ) )
				return Density.Greater;
			else if ( item is BaseArmor && ((BaseArmor)item).MaterialType == ArmorMaterialType.Plate )
			{
				if ( GetType( item.Resource ) == CraftResourceType.Metal )
					return Density.Superior;
				else if ( GetType( item.Resource ) == CraftResourceType.Block )
					return Density.Ultimate;
			}
			else if ( item is BaseArmor && ( ((BaseArmor)item).MaterialType == ArmorMaterialType.Chainmail || ((BaseArmor)item).MaterialType == ArmorMaterialType.Ringmail ) )
			{
				if ( GetType( item.Resource ) == CraftResourceType.Metal )
					return Density.Greater;
				else if ( GetType( item.Resource ) == CraftResourceType.Block )
					return Density.Superior;
			}
			else if ( GetType( item.Resource ) == CraftResourceType.Metal )
				return Density.Greater;
			else if ( GetType( item.Resource ) == CraftResourceType.Block )
				return Density.Superior;
			else if ( GetType( item.Resource ) == CraftResourceType.Special )
				return Density.Ultimate;

			return Density.None;
		}

		public static Item ArmorItem( Mobile defender )
		{
			int subset = 0;
			int cycle = 0;
			double positionChance = Utility.RandomDouble();
			Item armorItem = null;

			while ( cycle < 5 )
			{
				cycle++;
				positionChance = Utility.RandomDouble();

				if( positionChance < 0.07 && defender.FindItemOnLayer( Layer.Neck ) != null && (defender.FindItemOnLayer( Layer.Neck )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Neck );
				else if( positionChance < 0.14 && defender.FindItemOnLayer( Layer.Gloves ) != null && (defender.FindItemOnLayer( Layer.Gloves )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Gloves );
				else if( positionChance < 0.21 && defender.FindItemOnLayer( Layer.Arms ) != null && (defender.FindItemOnLayer( Layer.Arms )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Arms );
				else if( positionChance < 0.35 && defender.FindItemOnLayer( Layer.Helm ) != null && (defender.FindItemOnLayer( Layer.Helm )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Helm );
				else if( positionChance < 0.49 )
				{
					subset = Utility.Random( 4 );

					if ( defender.FindItemOnLayer( Layer.Pants ) != null && (defender.FindItemOnLayer( Layer.Pants )).Density != Density.None && subset == 0 )
						armorItem = defender.FindItemOnLayer( Layer.Pants );
					else if ( defender.FindItemOnLayer( Layer.Waist ) != null && (defender.FindItemOnLayer( Layer.Waist )).Density != Density.None && subset == 1 )
						armorItem = defender.FindItemOnLayer( Layer.Waist );
					else if ( defender.FindItemOnLayer( Layer.OuterLegs ) != null && (defender.FindItemOnLayer( Layer.OuterLegs )).Density != Density.None && subset == 2 )
						armorItem = defender.FindItemOnLayer( Layer.OuterLegs );
					else if ( defender.FindItemOnLayer( Layer.InnerLegs ) != null && (defender.FindItemOnLayer( Layer.InnerLegs )).Density != Density.None && subset == 3 )
						armorItem = defender.FindItemOnLayer( Layer.InnerLegs );
				}
				else if( positionChance < 0.56 && defender.FindItemOnLayer( Layer.Shoes ) != null && (defender.FindItemOnLayer( Layer.Shoes )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Shoes );
				else if( positionChance < 0.63 && defender.FindItemOnLayer( Layer.Cloak ) != null && (defender.FindItemOnLayer( Layer.Cloak )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.Cloak );
				else if( positionChance < 0.70 && defender.FindItemOnLayer( Layer.OuterTorso ) != null && (defender.FindItemOnLayer( Layer.OuterTorso )).Density != Density.None )
					armorItem = defender.FindItemOnLayer( Layer.OuterTorso );
				else
				{
					subset = Utility.Random( 3 );

					if ( defender.FindItemOnLayer( Layer.InnerTorso ) != null && (defender.FindItemOnLayer( Layer.InnerTorso )).Density != Density.None && subset == 0 )
						armorItem = defender.FindItemOnLayer( Layer.InnerTorso );
					else if ( defender.FindItemOnLayer( Layer.MiddleTorso ) != null && (defender.FindItemOnLayer( Layer.MiddleTorso )).Density != Density.None && subset == 1 )
						armorItem = defender.FindItemOnLayer( Layer.MiddleTorso );
					else if ( defender.FindItemOnLayer( Layer.Shirt ) != null && (defender.FindItemOnLayer( Layer.Shirt )).Density != Density.None && subset == 2 )
						armorItem = defender.FindItemOnLayer( Layer.Shirt );
				}

				if ( armorItem != null )
					cycle = 20;
			}
			return armorItem;
		}

		public static string GetTradeItemName( CraftResource resource, bool sub, bool sub2 )
		{
			if ( resource >= CraftResource.Iron && resource <= CraftResource.Dwarven && sub && sub2 )
				return "granite";
			else if ( resource >= CraftResource.Iron && resource <= CraftResource.Dwarven && sub )
				return "ore";
			else if ( resource >= CraftResource.Iron && resource <= CraftResource.Dwarven )
				return "ingot";
			else if ( resource >= CraftResource.Agrinium && resource <= CraftResource.Xonolite )
				return "metal";
			else if ( resource >= CraftResource.AmethystBlock && resource <= CraftResource.CaddelliteBlock && sub )
				return "stone";
			else if ( resource >= CraftResource.AmethystBlock && resource <= CraftResource.CaddelliteBlock )
				return "block";
			else if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.AlienLeather && sub )
				return "hide";
			else if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.AlienLeather )
				return "leather";
			else if ( resource >= CraftResource.DemonSkin && resource <= CraftResource.DeadSkin )
				return "skin";
			else if ( resource >= CraftResource.Adesote && resource <= CraftResource.Thermoweave )
				return "material";
			else if ( resource >= CraftResource.RedScales && resource <= CraftResource.KraytScales )
				return "scale";
			else if ( resource >= CraftResource.RegularWood && resource <= CraftResource.ElvenTree && sub )
				return "log";
			else if ( resource >= CraftResource.RegularWood && resource <= CraftResource.ElvenTree )
				return "board";
			else if ( resource >= CraftResource.BorlTree && resource <= CraftResource.VeshokTree )
				return "timber";
			else if ( resource >= CraftResource.SpectralSpec && resource <= CraftResource.TurtleSpec )
				return "rune";
			else if ( resource >= CraftResource.BrittleSkeletal && resource <= CraftResource.ZabrakSkeletal )
				return "bone";
			else if ( resource >= CraftResource.Fabric && resource <= CraftResource.FiendishFabric )
				return "cloth";

			return null;
		}

		public static string GetTradeItemFullName( Item item, CraftResource resource, bool sub, bool sub2, string name )
		{
			string material = (CraftResources.GetName( resource )).ToLower();

			if ( Item.IsStandardResource( resource ) )
				material = "";

			string sufx = GetTradeItemName( resource, sub, sub2 );
				if ( name != null )
					sufx = name;

			if ( sufx != null && material != "" )
				material = material + " " + sufx;
			else if ( sufx != null )
				material = sufx;

			return material;
		}

		public static string GetResourceName( CraftResource resource )
		{
			return (CraftResources.GetName( resource )).ToLower();
		}

		public static CraftResource GetStart( CraftResource resource )
		{
			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: return CraftResource.Iron;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
				case CraftResourceType.Scales: return CraftResource.RedScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
				case CraftResourceType.Block: return CraftResource.AmethystBlock;
				case CraftResourceType.Skin: return CraftResource.DemonSkin;
				case CraftResourceType.Special: return CraftResource.SpectralSpec;
				case CraftResourceType.Skeletal: return CraftResource.BrittleSkeletal;
				case CraftResourceType.Fabric: return CraftResource.Fabric;
			}

			return CraftResource.None;
		}

		public static int GetIndex( CraftResource resource )
		{
			CraftResource start = GetStart( resource );

			if ( start == CraftResource.None )
				return 0;

			return (int)(resource - start);
		}

		public static int GetClilocCraftName( CraftResource resource ) // RETURNS LIKE: GOLD (100)
		{
			CraftResourceInfo info = GetInfo( resource );

			if ( resource == CraftResource.None )
				return 0;

			return ( info == null ? 0 : info.CraftText );
		}

		public static int GetClilocMaterialName( CraftResource resource ) // RETURNS LIKE: Gold Ingots
		{
			CraftResourceInfo info = GetInfo( resource );

			if ( resource == CraftResource.None )
				return 0;

			return ( info == null ? 0 : info.MaterialText );
		}

		public static int GetClilocLowerCaseName( CraftResource resource ) // RETURNS LIKE: gold
		{
			CraftResourceInfo info = GetInfo( resource );

			// DO NOT RETURN A VALUE FOR REGULAR IRON, WOOD, OR LEATHER ... AND NONE.
			if ( resource == CraftResource.None || resource == CraftResource.Fabric || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood || resource == CraftResource.BrittleSkeletal )
				return 0;

			return ( info == null ? 0 : info.LowCaseText );
		}

		public static int GetHue( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Hue );
		}

		public static int GetClr( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Clr );
		}

		public static string GetName( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? String.Empty : info.Name );
		}

		public static string GetPrefix( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			if ( info != null && info.Name != "Iron" && info.Name != "Normal" && info.Name != "Brittle" )
				return "" + info.Name + " ";

			return "";
		}

		public static int GetDmg( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Dmg );
		}

		public static int GetArm( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Arm );
		}

		public static double GetGold( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0.0 : info.Gold );
		}

		public static double GetSkill( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0.0 : info.Skill );
		}

		public static int GetUses( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Uses );
		}

		public static int GetWeight( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Weight );
		}

		public static int GetBonus( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Bonus );
		}

		public static int GetXtra( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Xtra );
		}

		public static int GetWeaponArmor( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.WepArmor );
		}

		public static void GetAosMods( CraftResource resource, Item item, bool reduce )
		{
			if ( resource == 	CraftResource.Iron	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DullCopper	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ShadowIron	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Copper	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Bronze	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Gold	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Agapite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Verite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Valorite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Nepturite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Obsidian	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Steel	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Brass	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Mithril	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Xormite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Dwarven	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	2	,	4	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Agrinium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	23	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Beskar	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	4	,	0	,	45	,	1	,	43	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	10	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Carbonite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	3	,	0	,	2	,	1	,	23	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Cortosis	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	27	,	0	,	1	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Durasteel	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	32	,	0	,	99	,	1	,	48	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	15	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Durite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	31	,	0	,	6	,	1	,	8	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	10	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Farium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	20	,	0	,	15	,	1	,	42	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Laminasteel	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	33	,	0	,	3	,	1	,	4	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Neuranium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	6	,	0	,	31	,	1	,	33	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	1	,	2	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Phrik	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	35	,	0	,	55	,	1	,	21	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	2	,	2	,	0	,	0	,	3	,	1	,	1	,	0	,	2	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Promethium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	9	,	0	,	40	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Quadranium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	28	,	0	,	28	,	1	,	27	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Songsteel	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	21	,	0	,	35	,	1	,	39	,	1	,	16	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Titanium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	18	,	0	,	99	,	1	,	48	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.Trimantium	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	34	,	0	,	19	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Xonolite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	29	,	0	,	36	,	1	,	44	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	2	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }

			else if ( resource == 	CraftResource.RedScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	1	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	3	,	2	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.YellowScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	35	,	1	,	16	,	1	,	39	,	2	,	41	,	2	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	5	,	5	,	5	,	5	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.BlackScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	25	,	2	,	46	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	3	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GreenScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	40	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.WhiteScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	23	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.BlueScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	19	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	15	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DinosaurScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	4	,	1	,	24	,	1	,	53	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.MetallicScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	8	,	1	,	34	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	2	,	2	,	2	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	10	,	10	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.BrazenScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	4	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	10	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.UmberScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	36	,	1	,	44	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	4	,	0	,	0	,	2	,	1	,	1	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	10	,	5	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.VioletScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	55	,	1	,	21	,	1	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	4	,	0	,	0	,	2	,	1	,	1	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.PlatinumScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	13	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	2	,	2	,	5	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.CadalyteScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	4	,	32	,	4	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	3	,	3	,	0	,	7	,	7	,	0	,	0	,	0	,	0	,	0	,	4	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	10	,	10	,	10	,	10	,	0	,	0	,	2	,	0	 ); }
			else if ( resource == 	CraftResource.GornScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	3	,	48	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	3	,	0	,	0	,	6	,	5	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.TrandoshanScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	3	,	19	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	3	,	0	,	6	,	5	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.SilurianScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	3	,	17	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	3	,	5	,	0	,	2	,	2	,	2	,	0	,	0	,	3	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	1	,	1	,	1	 ); }
			else if ( resource == 	CraftResource.KraytScales	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	25	,	3	,	46	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	3	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	1	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	1	,	0	 ); }

			else if ( resource == 	CraftResource.SpectralSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	5	,	36	,	5	,	19	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	2	,	0	,	0	,	5	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	 ); }
			else if ( resource == 	CraftResource.DreadSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	5	,	48	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	5	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GhoulishSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	5	,	0	,	99	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.WyrmSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	6	,	0	,	99	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	8	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	50	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.HolySpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	1	,	14	,	99	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	2	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	 ); }
			else if ( resource == 	CraftResource.BloodlessSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	5	,	0	,	36	,	5	,	22	,	5	,	44	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	8	,	0	,	0	,	0	,	0	,	5	,	5	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.GildedSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	28	,	30	,	99	,	10	,	48	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DemilichSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	5	,	0	,	99	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.WintrySpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	19	,	0	,	99	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	8	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.FireSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ColdSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.PoisSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.EngySpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ExodusSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	32	,	13	,	99	,	15	,	32	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	1	,	5	,	5	,	2	,	1	,	1	,	4	,	3	,	0	,	9	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	20	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	3	,	1	 ); }
			else if ( resource == 	CraftResource.TurtleSpec	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	34	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	50	,	0	,	0	,	0	,	0	,	0	,	5	,	0	 ); }

			else if ( resource == 	CraftResource.RegularLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.HornedLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.BarbedLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.NecroticLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.VolcanicLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.FrozenLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.SpinedLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GoliathLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DraconicLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.HellishLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DinosaurLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.AlienLeather	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Adesote	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	35	,	0	,	99	,	2	,	17	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	5	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Biomesh	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	16	,	0	,	99	,	2	,	21	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	7	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Cerlin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	21	,	0	,	99	,	2	,	13	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Durafiber	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	2	,	0	,	99	,	2	,	23	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	3	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Flexicris	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	27	,	0	,	99	,	2	,	27	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	3	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Hypercloth	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	29	,	0	,	99	,	2	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Nylar	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	11	,	0	,	99	,	2	,	50	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Nylonite	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	4	,	0	,	25	,	2	,	46	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Polyfiber	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	3	,	0	,	99	,	2	,	52	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Syncloth	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	23	,	0	,	99	,	2	,	6	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	3	,	1	,	1	,	0	,	0	,	0	,	5	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.Thermoweave	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	32	,	0	,	99	,	2	,	15	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }

			else if ( resource == 	CraftResource.RegularWood	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.AshTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.CherryTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.EbonyTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GoldenOakTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.HickoryTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.MahoganyTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.OakTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.PineTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GhostTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.RosewoodTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.WalnutTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.PetrifiedTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DriftwoodTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	19	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ElvenTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	3	,	52	,	2	,	10	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	5	,	0	,	1	,	1	,	0	,	0	,	0	,	7	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	1	,	2	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	1	 ); }
			else if ( resource == 	CraftResource.BorlTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	23	,	0	,	15	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.CosianTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	33	,	0	,	23	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GreelTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	12	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.JaporTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	15	,	0	,	19	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	6	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.KyshyyykTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	17	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	7	,	8	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.LaroonTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	7	,	0	,	44	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	8	,	11	,	2	,	1	,	1	,	3	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.TeejTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	8	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	9	,	12	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.VeshokTree	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	25	,	0	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	10	,	13	,	0	,	0	,	0	,	0	,	0	,	0	,	12	,	0	,	1	,	0	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	 ); }

			else if ( resource == 	CraftResource.Fabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.FurryFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.WoolyFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.SilkFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.HauntedFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	44	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.ArcticFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	19	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.PyreFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.VenomousFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	22	,	0	,	40	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.MysteriousFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	27	,	0	,	33	,	2	,	32	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	2	,	1	,	1	,	0	,	3	,	2	,	10	,	1	,	1	,	0	,	0	,	0	,	15	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.VileFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	5	,	0	,	99	,	3	,	36	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	0	,	8	,	2	,	0	,	0	,	0	,	3	,	0	,	7	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	1	,	0	,	0	,	15	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.DivineFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	1	,	0	,	99	,	3	,	13	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	1	,	5	,	5	,	1	,	1	,	1	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	12	,	1	,	1	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	1	 ); }
			else if ( resource == 	CraftResource.FiendishFabric	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	14	,	0	,	99	,	4	,	32	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	0	,	5	,	2	,	0	,	2	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	12	,	1	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }

			else if ( resource == 	CraftResource.AmethystBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	32	,	0	,	38	,	2	,	48	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	80	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.EmeraldBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	33	,	0	,	40	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	1	,	0	,	0	,	1	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GarnetBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	22	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	2	,	1	,	1	,	3	,	3	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.IceBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	19	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.JadeBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	22	,	0	,	99	,	3	,	9	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	5	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.MarbleBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	23	,	32	,	99	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	8	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.OnyxBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	31	,	5	,	36	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	5	,	0	,	0	,	1	,	0	,	0	,	2	,	7	,	0	,	2	,	1	,	1	,	3	,	3	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.QuartzBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	8	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.RubyBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	24	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	7	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.SapphireBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	28	,	0	,	17	,	1	,	31	,	1	,	32	,	3	,	33	,	3	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.SilverBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	1	,	0	,	13	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	7	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.SpinelBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	35	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	8	,	0	,	0	,	0	,	0	,	3	,	3	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.StarRubyBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	12	,	0	,	55	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	7	,	8	,	2	,	0	,	0	,	0	,	0	,	0	,	8	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.TopazBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	7	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	 ); }
			else if ( resource == 	CraftResource.CaddelliteBlock	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	27	,	0	,	99	,	3	,	32	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	9	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	30	,	0	,	0	,	0	,	2	,	0	 ); }

			else if ( resource == 	CraftResource.DemonSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	11	,	0	,	32	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	1	,	3	,	3	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.DragonSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	6	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.NightmareSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	1	,	1	,	0	,	0	,	0	,	0	,	25	,	25	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.SnakeSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	8	,	0	,	40	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	6	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.TrollSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	 ); }
			else if ( resource == 	CraftResource.UnicornSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	2	,	0	,	0	,	2	,	1	,	1	,	3	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	25	,	25	,	30	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.IcySkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	19	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.LavaSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	20	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.Seaweed	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	34	,	0	,	19	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	4	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	30	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.DeadSkin	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	1	,	0	,	36	,	2	,	22	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }

			else if ( resource == 	CraftResource.BrittleSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.DrowSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.OrcSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ReptileSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.OgreSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.TrollSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.GargoyleSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.MinotaurSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	0	,	0	,	99	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.LycanSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	30	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.SharkSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	34	,	0	,	99	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ColossalSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	31	,	0	,	99	,	2	,	22	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.MysticalSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	27	,	0	,	99	,	2	,	22	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	2	,	1	,	1	,	0	,	3	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.VampireSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	5	,	0	,	99	,	2	,	22	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	2	,	0	,	0	,	1	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.LichSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	1	,	0	,	99	,	3	,	22	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	2	,	1	,	1	,	0	,	3	,	0	,	2	,	1	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.SphinxSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	12	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	3	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	5	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.DevilSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	11	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	2	,	0	,	2	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	0	,	0	,	1	,	1	 ); }
			else if ( resource == 	CraftResource.DracoSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	6	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	1	,	0	,	0	,	3	,	0	,	0	,	5	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	25	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.XenoSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	2	,	0	,	99	,	3	,	22	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	2	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	15	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.AndorianSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	3	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.CardassianSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	4	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	1	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	10	,	0	,	0	,	0	,	1	,	0	 ); }
			else if ( resource == 	CraftResource.MartianSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	7	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.RodianSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	8	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	CraftResource.TuskenSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	9	,	0	,	99	,	3	,	22	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	4	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	25	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.TwilekSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	16	,	0	,	35	,	3	,	39	,	3	,	16	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	20	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.XindiSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	17	,	0	,	99	,	4	,	48	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	10	,	10	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	CraftResource.ZabrakSkeletal	 ){ ResourceMods.ModifyItem( item, resource, reduce, 	29	,	0	,	99	,	3	,	48	,	3	,	38	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	3	,	0	,	1	,	0	,	0	,	2	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	2	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	10	,	0	,	10	,	0	,	0	,	0	,	2	,	0	 ); }
		}

		public static void GetGemMods( GemType resource, Item item, bool reduce )
		{
			if ( resource == 	GemType.None	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.Amber	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	 ); }
			else if ( resource == 	GemType.Citrine	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.Ruby	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	GemType.Tourmaline	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.Amethyst	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	2	,	1	,	0	,	3	,	0	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.Emerald	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	5	,	5	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.Sapphire	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	3	,	0	,	0	,	0	,	0	,	0	,	4	,	4	,	0	,	0	,	0	,	0	 ); }
			else if ( resource == 	GemType.StarSapphire	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	0	,	0	,	1	,	0	,	0	,	0	,	0	,	1	,	0	,	0	,	0	,	0	,	0	,	5	,	1	,	1	,	0	,	0	,	0	,	5	,	0	,	1	 ); }
			else if ( resource == 	GemType.Diamond	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	1	,	0	,	0	,	5	,	0	,	2	,	0	,	0	,	5	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	0	,	1	 ); }
			else if ( resource == 	GemType.Pearl	 ){ ResourceMods.ModifyJewelry( item, resource, reduce, 	2	,	2	,	2	,	0	,	0	,	2	,	2	,	2	,	0	,	0	,	0	,	0	,	0	,	5	,	1	,	1	,	10	,	10	,	0	,	0	,	0	,	1	 ); }
		}
	}
}