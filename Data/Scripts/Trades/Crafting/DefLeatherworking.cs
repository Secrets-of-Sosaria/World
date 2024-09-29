using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefLeatherworking : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Tailoring; }
		}

        public override int GumpImage
        {
            get { return 9605; }
        }

		public override int GumpTitleNumber
		{
			get { return 1044005; } // <CENTER>LEATHERWORKING MENU</CENTER>
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Leather; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Leather"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefLeatherworking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefLeatherworking() : base( 1, 1, 1.25 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public static bool IsNonColorable(Type type)
		{
			for (int i = 0; i < m_TailorNonColorables.Length; ++i)
			{
				if (m_TailorNonColorables[i] == type)
				{
					return true;
				}
			}

			return false;
		}

		private static Type[] m_TailorNonColorables = new Type[]
			{
				//typeof( OrcHelm )
			};

		private static Type[] m_TailorColorables = new Type[]
			{
				typeof( GozaMatEastDeed ), typeof( GozaMatSouthDeed ),
				typeof( SquareGozaMatEastDeed ), typeof( SquareGozaMatSouthDeed ),
				typeof( BrocadeGozaMatEastDeed ), typeof( BrocadeGozaMatSouthDeed ),
				typeof( BrocadeSquareGozaMatEastDeed ), typeof( BrocadeSquareGozaMatSouthDeed )
			};

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			if ( type != typeof( Fabric ) )
				return false;

			type = item.ItemType;

			bool contains = false;

			for ( int i = 0; !contains && i < m_TailorColorables.Length; ++i )
				contains = ( m_TailorColorables[i] == type );

			return contains;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x248, m_Tools );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			#region Footwear
			AddCraft( typeof( Sandals ), 1015288, 1025901, 12.4, 37.4, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( Shoes ), 1015288, 1025904, 16.5, 41.5, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( Boots ), 1015288, 1025899, 33.1, 58.1, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( ThighBoots ), 1015288, 1025906, 41.4, 66.4, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( LeatherSandals ), 1015288, "leather sandals", 42.4, 67.4, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( LeatherShoes ), 1015288, "leather shoes", 56.5, 71.5, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( LeatherBoots ), 1015288, "leather boots", 63.1, 88.1, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( LeatherThighBoots ), 1015288, "leather thigh boots", 71.4, 96.4, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( LeatherSoftBoots ), 1015288, "soft leather boots", 81.4, 106.4, typeof( Leather ), 1044462, 8, 1044463 );

			if ( MyServerSettings.MonstersAllowed() )
				AddCraft( typeof( HikingBoots ), 1015288, "hiking boots", 83.1, 108.1, typeof( Leather ), 1044462, 8, 1044463 );

			AddCraft( typeof( OniwabanBoots ), 1015288, "oniwaban boots", 81.4, 106.4, typeof( Leather ), 1044462, 8, 1044463 );
			#endregion

			#region Leather Armor
			AddCraft( typeof( LeatherGorget ), 1015293, 1025063, 53.9, 78.9, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( LeatherCap ), 1015293, 1027609, 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( LeatherGloves ), 1015293, 1025062, 51.8, 76.8, typeof( Leather ), 1044462, 3, 1044463 );
			AddCraft( typeof( LeatherArms ), 1015293, 1025061, 53.9, 78.9, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( LeatherLegs ), 1015293, 1025067, 66.3, 91.3, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( LeatherChest ), 1015293, 1025068, 70.5, 95.5, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( LeatherCloak ), 1015293, "leather cloak", 66.3, 91.3, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( LeatherRobe ), 1015293, "leather robe", 76.3, 101.3, typeof( Leather ), 1044462, 18, 1044463 );
			AddCraft( typeof( LeatherShorts ), 1015293, 1027168, 62.2, 87.2, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( LeatherSkirt ), 1015293, 1027176, 58.0, 83.0, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( LeatherBustierArms ), 1015293, 1027178, 58.0, 83.0, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( FemaleLeatherChest ), 1015293, 1027174, 62.2, 87.2, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( LeatherJingasa ), 1015293, 1030177, 45.0, 70.0, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( LeatherMempo ), 1015293, 1030181, 80.0, 105.0, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( LeatherDo ), 1015293, 1030182, 75.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( LeatherHiroSode ), 1015293, 1030185, 55.0, 80.0, typeof( Leather ), 1044462, 5, 1044463 );
			AddCraft( typeof( LeatherSuneate ), 1015293, 1030193, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( LeatherHaidate ), 1015293, 1030197, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( LeatherNinjaPants ), 1015293, 1030204, 80.0, 105.0, typeof( Leather ), 1044462, 13, 1044463 );
			AddCraft( typeof( LeatherNinjaJacket ), 1015293, 1030206, 85.0, 110.0, typeof( Leather ), 1044462, 13, 1044463 );
			AddCraft( typeof( LeatherNinjaMitts ), 1015293, 1030205, 65.0, 90.0, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( LeatherNinjaHood ), 1015293, 1030201, 90.0, 115.0, typeof( Leather ), 1044462, 14, 1044463 );
			AddCraft( typeof( ShinobiRobe ), 1015293, "leather shinobi robe", 76.3, 101.3, typeof( Leather ), 1044462, 18, 1044463 );
			AddCraft( typeof( ShinobiCowl ), 1015293, "leather shinobi cowl", 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( ShinobiHood ), 1015293, "leather shinobi hood", 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( ShinobiMask ), 1015293, "leather shinobi mask", 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( OniwabanHood ), 1015293, "oniwaban hood", 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( OniwabanGloves ), 1015293, "oniwaban gloves", 51.8, 76.8, typeof( Leather ), 1044462, 3, 1044463 );
			AddCraft( typeof( OniwabanLeggings ), 1015293, "oniwaban leggings", 66.3, 91.3, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( OniwabanTunic ), 1015293, "oniwaban tunic", 70.5, 95.5, typeof( Leather ), 1044462, 12, 1044463 );

			#endregion

			#region Studded Armor
			AddCraft( typeof( StuddedGorget ), 1015300, 1025078, 78.8, 103.8, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( StuddedGloves ), 1015300, 1025077, 82.9, 107.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( StuddedArms ), 1015300, 1025076, 87.1, 112.1, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( StuddedLegs ), 1015300, 1025082, 91.2, 116.2, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( StuddedSkirt ), 1015300, "studded skirt", 91.2, 116.2, typeof( Leather ), 1044462, 12, 1044463 );
			AddCraft( typeof( StuddedChest ), 1015300, 1025083, 94.0, 119.0, typeof( Leather ), 1044462, 14, 1044463 );
			AddCraft( typeof( StuddedBustierArms ), 1015300, 1027180, 82.9, 107.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( FemaleStuddedChest ), 1015300, 1027170, 87.1, 112.1, typeof( Leather ), 1044462, 10, 1044463 );
			AddCraft( typeof( StuddedMempo ), 1015300, 1030216, 80.0, 105.0, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( StuddedDo ), 1015300, 1030183, 95.0, 120.0, typeof( Leather ), 1044462, 14, 1044463 );
			AddCraft( typeof( StuddedHiroSode ), 1015300, 1030186, 85.0, 110.0, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( StuddedSuneate ), 1015300, 1030194, 92.0, 117.0, typeof( Leather ), 1044462, 14, 1044463 );
			AddCraft( typeof( StuddedHaidate ), 1015300, 1030198, 92.0, 117.0, typeof( Leather ), 1044462, 14, 1044463 );
			#endregion

			#region Misc
			AddCraft( typeof( PugilistMits ), 1015283, "pugilist gloves", 32.9, 57.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( ThrowingGloves ), 1015283, "throwing gloves", 32.9, 57.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( Whips ), 1015283, "whip", 14.5, 64.5, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( Backpack ), 1015283, "backpack", 8.2, 33.2, typeof( Leather ), 1044462, 3, 1044463 );
			AddCraft( typeof( RuggedBackpack ), 1015283, "backpack, rugged", 10.7, 40.7, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( Pouch ), 1015283, "pouch", 0.0, 25.0, typeof( Leather ), 1044462, 2, 1044463 );
			AddCraft( typeof( Bag ), 1015283, "bag", 0.0, 25.0, typeof( Leather ), 1044462, 3, 1044463 );
			AddCraft( typeof( BigBag ), 1015283, "bag, big", 22.0, 47.0, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( LargeBag ), 1015283, "bag, large", 16.5, 41.5, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( GiantBag ), 1015283, "bag, giant", 26.0, 51.0, typeof( Leather ), 1044462, 9, 1044463 );
			AddCraft( typeof( LargeSack ), 1015283, "rucksack", 20.7, 45.7, typeof( Leather ), 1044462, 7, 1044463 );
			AddCraft( typeof( BearCap ), 1015283, "bearskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( DeerCap ), 1015283, "deerskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( StagCap ), 1015283, "stagskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( WolfCap ), 1015283, "wolfskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			#endregion

			// Set the overridable material
			SetSubRes( typeof( Leather ), CraftResources.GetClilocCraftName( CraftResource.RegularLeather ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1049312; // You have no idea how to work this leather.

			AddSubRes( typeof( Leather ),				CraftResources.GetClilocCraftName( CraftResource.RegularLeather ), CraftResources.GetSkill( CraftResource.RegularLeather ), CraftResources.GetClilocMaterialName( CraftResource.RegularLeather ), cannot );
			AddSubRes( typeof( HornedLeather ),			CraftResources.GetClilocCraftName( CraftResource.HornedLeather ), CraftResources.GetSkill( CraftResource.HornedLeather ), CraftResources.GetClilocMaterialName( CraftResource.HornedLeather ), cannot );
			AddSubRes( typeof( BarbedLeather ),			CraftResources.GetClilocCraftName( CraftResource.BarbedLeather ), CraftResources.GetSkill( CraftResource.BarbedLeather ), CraftResources.GetClilocMaterialName( CraftResource.BarbedLeather ), cannot );
			AddSubRes( typeof( NecroticLeather ),		CraftResources.GetClilocCraftName( CraftResource.NecroticLeather ), CraftResources.GetSkill( CraftResource.NecroticLeather ), CraftResources.GetClilocMaterialName( CraftResource.NecroticLeather ), cannot );
			AddSubRes( typeof( VolcanicLeather ),		CraftResources.GetClilocCraftName( CraftResource.VolcanicLeather ), CraftResources.GetSkill( CraftResource.VolcanicLeather ), CraftResources.GetClilocMaterialName( CraftResource.VolcanicLeather ), cannot );
			AddSubRes( typeof( FrozenLeather ),			CraftResources.GetClilocCraftName( CraftResource.FrozenLeather ), CraftResources.GetSkill( CraftResource.FrozenLeather ), CraftResources.GetClilocMaterialName( CraftResource.FrozenLeather ), cannot );
			AddSubRes( typeof( SpinedLeather ),			CraftResources.GetClilocCraftName( CraftResource.SpinedLeather ), CraftResources.GetSkill( CraftResource.SpinedLeather ), CraftResources.GetClilocMaterialName( CraftResource.SpinedLeather ), cannot );
			AddSubRes( typeof( GoliathLeather ),		CraftResources.GetClilocCraftName( CraftResource.GoliathLeather ), CraftResources.GetSkill( CraftResource.GoliathLeather ), CraftResources.GetClilocMaterialName( CraftResource.GoliathLeather ), cannot );
			AddSubRes( typeof( DraconicLeather ),		CraftResources.GetClilocCraftName( CraftResource.DraconicLeather ), CraftResources.GetSkill( CraftResource.DraconicLeather ), CraftResources.GetClilocMaterialName( CraftResource.DraconicLeather ), cannot );
			AddSubRes( typeof( HellishLeather ),		CraftResources.GetClilocCraftName( CraftResource.HellishLeather ), CraftResources.GetSkill( CraftResource.HellishLeather ), CraftResources.GetClilocMaterialName( CraftResource.HellishLeather ), cannot );
			AddSubRes( typeof( DinosaurLeather ),		CraftResources.GetClilocCraftName( CraftResource.DinosaurLeather ), CraftResources.GetSkill( CraftResource.DinosaurLeather ), CraftResources.GetClilocMaterialName( CraftResource.DinosaurLeather ), cannot );
			AddSubRes( typeof( AlienLeather ),			CraftResources.GetClilocCraftName( CraftResource.AlienLeather ), CraftResources.GetSkill( CraftResource.AlienLeather ), CraftResources.GetClilocMaterialName( CraftResource.AlienLeather ), cannot );
			AddSubRes( typeof( AdesoteLeather ),		CraftResources.GetClilocCraftName( CraftResource.Adesote ), CraftResources.GetSkill( CraftResource.Adesote ), CraftResources.GetClilocMaterialName( CraftResource.Adesote ), cannot );
			AddSubRes( typeof( BiomeshLeather ),		CraftResources.GetClilocCraftName( CraftResource.Biomesh ), CraftResources.GetSkill( CraftResource.Biomesh ), CraftResources.GetClilocMaterialName( CraftResource.Biomesh ), cannot );
			AddSubRes( typeof( CerlinLeather ),			CraftResources.GetClilocCraftName( CraftResource.Cerlin ), CraftResources.GetSkill( CraftResource.Cerlin ), CraftResources.GetClilocMaterialName( CraftResource.Cerlin ), cannot );
			AddSubRes( typeof( DurafiberLeather ),		CraftResources.GetClilocCraftName( CraftResource.Durafiber ), CraftResources.GetSkill( CraftResource.Durafiber ), CraftResources.GetClilocMaterialName( CraftResource.Durafiber ), cannot );
			AddSubRes( typeof( FlexicrisLeather ),		CraftResources.GetClilocCraftName( CraftResource.Flexicris ), CraftResources.GetSkill( CraftResource.Flexicris ), CraftResources.GetClilocMaterialName( CraftResource.Flexicris ), cannot );
			AddSubRes( typeof( HyperclothLeather ),		CraftResources.GetClilocCraftName( CraftResource.Hypercloth ), CraftResources.GetSkill( CraftResource.Hypercloth ), CraftResources.GetClilocMaterialName( CraftResource.Hypercloth ), cannot );
			AddSubRes( typeof( NylarLeather ),			CraftResources.GetClilocCraftName( CraftResource.Nylar ), CraftResources.GetSkill( CraftResource.Nylar ), CraftResources.GetClilocMaterialName( CraftResource.Nylar ), cannot );
			AddSubRes( typeof( NyloniteLeather ),		CraftResources.GetClilocCraftName( CraftResource.Nylonite ), CraftResources.GetSkill( CraftResource.Nylonite ), CraftResources.GetClilocMaterialName( CraftResource.Nylonite ), cannot );
			AddSubRes( typeof( PolyfiberLeather ),		CraftResources.GetClilocCraftName( CraftResource.Polyfiber ), CraftResources.GetSkill( CraftResource.Polyfiber ), CraftResources.GetClilocMaterialName( CraftResource.Polyfiber ), cannot );
			AddSubRes( typeof( SynclothLeather ),		CraftResources.GetClilocCraftName( CraftResource.Syncloth ), CraftResources.GetSkill( CraftResource.Syncloth ), CraftResources.GetClilocMaterialName( CraftResource.Syncloth ), cannot );
			AddSubRes( typeof( ThermoweaveLeather ),	CraftResources.GetClilocCraftName( CraftResource.Thermoweave ), CraftResources.GetSkill( CraftResource.Thermoweave ), CraftResources.GetClilocMaterialName( CraftResource.Thermoweave ), cannot );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}