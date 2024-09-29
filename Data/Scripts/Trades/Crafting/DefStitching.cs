using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefStitching : CraftSystem
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
            get { return 0; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Skin; }
		}
 
        public override string GumpTitleString
        {
            get { return "<BASEFONT Color=#FBFBFB><CENTER>STITCHING MENU</CENTER></BASEFONT>"; }
        }

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override string CraftSystemTxt
		{
			get { return "Crafting: Stitching"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefStitching();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefStitching() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !(tool.Parent == from ) )
				return 1044263; // The tool must be on your person to use.
			else if ( from.Skills[SkillName.Tailoring].Value < 65.0 )
				return 1063799;
			else if ( from.Map == Map.SavagedEmpire && from.X > 1087 && from.X < 1105 && from.Y > 1968 && from.Y < 1982 )
				return 0;

			return 1044145;
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
			AddCraft( typeof( LeatherSandals ), 1015288, "leather sandals", 42.4, 67.4, typeof( DemonSkins ), 1063757, 4, 1042081 );
			AddCraft( typeof( LeatherShoes ), 1015288, "leather shoes", 56.5, 71.5, typeof( DemonSkins ), 1063757, 6, 1042081 );
			AddCraft( typeof( LeatherBoots ), 1015288, "leather boots", 63.1, 88.1, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( LeatherThighBoots ), 1015288, "leather thigh boots", 71.4, 96.4, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( LeatherSoftBoots ), 1015288, "soft leather boots", 81.4, 106.4, typeof( DemonSkins ), 1063757, 8, 1042081 );

			if ( MyServerSettings.MonstersAllowed() )
				AddCraft( typeof( HikingBoots ), 1015288, "hiking boots", 83.1, 108.1, typeof( DemonSkins ), 1063757, 8, 1042081 );

			AddCraft( typeof( OniwabanBoots ), 1015288, "oniwaban boots", 81.4, 106.4, typeof( DemonSkins ), 1063757, 8, 1042081 );
			#endregion

			#region Leather Armor
			AddCraft( typeof( LeatherGorget ), 1015293, 1025063, 53.9, 78.9, typeof( DemonSkins ), 1063757, 4, 1042081 );
			AddCraft( typeof( LeatherCap ), 1015293, 1027609, 6.2, 31.2, typeof( DemonSkins ), 1063757, 2, 1042081 );
			AddCraft( typeof( LeatherGloves ), 1015293, 1025062, 51.8, 76.8, typeof( DemonSkins ), 1063757, 3, 1042081 );
			AddCraft( typeof( LeatherArms ), 1015293, 1025061, 53.9, 78.9, typeof( DemonSkins ), 1063757, 4, 1042081 );
			AddCraft( typeof( LeatherLegs ), 1015293, 1025067, 66.3, 91.3, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( LeatherChest ), 1015293, 1025068, 70.5, 95.5, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( LeatherCloak ), 1015293, "leather cloak", 66.3, 91.3, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( LeatherRobe ), 1015293, "leather robe", 76.3, 101.3, typeof( DemonSkins ), 1063757, 18, 1042081 );
			AddCraft( typeof( LeatherShorts ), 1015293, 1027168, 62.2, 87.2, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( LeatherSkirt ), 1015293, 1027176, 58.0, 83.0, typeof( DemonSkins ), 1063757, 6, 1042081 );
			AddCraft( typeof( LeatherBustierArms ), 1015293, 1027178, 58.0, 83.0, typeof( DemonSkins ), 1063757, 6, 1042081 );
			AddCraft( typeof( FemaleLeatherChest ), 1015293, 1027174, 62.2, 87.2, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( LeatherJingasa ), 1015293, 1030177, 45.0, 70.0, typeof( DemonSkins ), 1063757, 4, 1042081 );
			AddCraft( typeof( LeatherMempo ), 1015293, 1030181, 80.0, 105.0, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( LeatherDo ), 1015293, 1030182, 75.0, 100.0, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( LeatherHiroSode ), 1015293, 1030185, 55.0, 80.0, typeof( DemonSkins ), 1063757, 5, 1042081 );
			AddCraft( typeof( LeatherSuneate ), 1015293, 1030193, 68.0, 93.0, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( LeatherHaidate ), 1015293, 1030197, 68.0, 93.0, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( LeatherNinjaPants ), 1015293, 1030204, 80.0, 105.0, typeof( DemonSkins ), 1063757, 13, 1042081 );
			AddCraft( typeof( LeatherNinjaJacket ), 1015293, 1030206, 85.0, 110.0, typeof( DemonSkins ), 1063757, 13, 1042081 );
			AddCraft( typeof( LeatherNinjaMitts ), 1015293, 1030205, 65.0, 90.0, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( LeatherNinjaHood ), 1015293, 1030201, 90.0, 115.0, typeof( DemonSkins ), 1063757, 14, 1042081 );
			AddCraft( typeof( ShinobiRobe ), 1015293, "leather shinobi robe", 76.3, 101.3, typeof( DemonSkins ), 1063757, 18, 1042081 );
			AddCraft( typeof( ShinobiCowl ), 1015293, "leather shinobi cowl", 6.2, 31.2, typeof( DemonSkins ), 1063757, 2, 1042081 );
			AddCraft( typeof( ShinobiHood ), 1015293, "leather shinobi hood", 6.2, 31.2, typeof( DemonSkins ), 1063757, 2, 1042081 );
			AddCraft( typeof( ShinobiMask ), 1015293, "leather shinobi mask", 6.2, 31.2, typeof( DemonSkins ), 1063757, 2, 1042081 );
			AddCraft( typeof( OniwabanHood ), 1015293, "oniwaban hood", 6.2, 31.2, typeof( DemonSkins ), 1063757, 2, 1042081 );
			AddCraft( typeof( OniwabanGloves ), 1015293, "oniwaban gloves", 51.8, 76.8, typeof( DemonSkins ), 1063757, 3, 1042081 );
			AddCraft( typeof( OniwabanLeggings ), 1015293, "oniwaban leggings", 66.3, 91.3, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( OniwabanTunic ), 1015293, "oniwaban tunic", 70.5, 95.5, typeof( DemonSkins ), 1063757, 12, 1042081 );

			#endregion

			#region Studded Armor
			AddCraft( typeof( StuddedGorget ), 1015300, 1025078, 78.8, 103.8, typeof( DemonSkins ), 1063757, 6, 1042081 );
			AddCraft( typeof( StuddedGloves ), 1015300, 1025077, 82.9, 107.9, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( StuddedArms ), 1015300, 1025076, 87.1, 112.1, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( StuddedLegs ), 1015300, 1025082, 91.2, 116.2, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( StuddedSkirt ), 1015300, "studded skirt", 91.2, 116.2, typeof( DemonSkins ), 1063757, 12, 1042081 );
			AddCraft( typeof( StuddedChest ), 1015300, 1025083, 94.0, 119.0, typeof( DemonSkins ), 1063757, 14, 1042081 );
			AddCraft( typeof( StuddedBustierArms ), 1015300, 1027180, 82.9, 107.9, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( FemaleStuddedChest ), 1015300, 1027170, 87.1, 112.1, typeof( DemonSkins ), 1063757, 10, 1042081 );
			AddCraft( typeof( StuddedMempo ), 1015300, 1030216, 80.0, 105.0, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( StuddedDo ), 1015300, 1030183, 95.0, 120.0, typeof( DemonSkins ), 1063757, 14, 1042081 );
			AddCraft( typeof( StuddedHiroSode ), 1015300, 1030186, 85.0, 110.0, typeof( DemonSkins ), 1063757, 8, 1042081 );
			AddCraft( typeof( StuddedSuneate ), 1015300, 1030194, 92.0, 117.0, typeof( DemonSkins ), 1063757, 14, 1042081 );
			AddCraft( typeof( StuddedHaidate ), 1015300, 1030198, 92.0, 117.0, typeof( DemonSkins ), 1063757, 14, 1042081 );
			#endregion

			#region Misc
			AddCraft( typeof( PugilistMits ), 1015283, "pugilist gloves", 32.9, 57.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( ThrowingGloves ), 1015283, "throwing gloves", 32.9, 57.9, typeof( Leather ), 1044462, 8, 1044463 );
			AddCraft( typeof( Whips ), 1015283, "whip", 14.5, 64.5, typeof( Leather ), 1044462, 6, 1044463 );
			AddCraft( typeof( BearCap ), 1015283, "bearskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( DeerCap ), 1015283, "deerskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( StagCap ), 1015283, "stagskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			AddCraft( typeof( WolfCap ), 1015283, "wolfskin cap", 26.2, 51.2, typeof( Leather ), 1044462, 4, 1044463 );
			#endregion

			// Set the overridable material
			SetSubRes( typeof( DemonSkins ), CraftResources.GetClilocCraftName( CraftResource.DemonSkin ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1079600; // You have no idea how to work this skin.

			AddSubRes( typeof( DemonSkins ),		CraftResources.GetClilocCraftName( CraftResource.DemonSkin ), CraftResources.GetSkill( CraftResource.DemonSkin ), CraftResources.GetClilocMaterialName( CraftResource.DemonSkin ), cannot );
			AddSubRes( typeof( DragonSkins ),		CraftResources.GetClilocCraftName( CraftResource.DragonSkin ), CraftResources.GetSkill( CraftResource.DragonSkin ), CraftResources.GetClilocMaterialName( CraftResource.DragonSkin ), cannot );
			AddSubRes( typeof( NightmareSkins ),	CraftResources.GetClilocCraftName( CraftResource.NightmareSkin ), CraftResources.GetSkill( CraftResource.NightmareSkin ), CraftResources.GetClilocMaterialName( CraftResource.NightmareSkin ), cannot );
			AddSubRes( typeof( SnakeSkins ),		CraftResources.GetClilocCraftName( CraftResource.SnakeSkin ), CraftResources.GetSkill( CraftResource.SnakeSkin ), CraftResources.GetClilocMaterialName( CraftResource.SnakeSkin ), cannot );
			AddSubRes( typeof( TrollSkins ),		CraftResources.GetClilocCraftName( CraftResource.TrollSkin ), CraftResources.GetSkill( CraftResource.TrollSkin ), CraftResources.GetClilocMaterialName( CraftResource.TrollSkin ), cannot );
			AddSubRes( typeof( UnicornSkins ),		CraftResources.GetClilocCraftName( CraftResource.UnicornSkin ), CraftResources.GetSkill( CraftResource.UnicornSkin ), CraftResources.GetClilocMaterialName( CraftResource.UnicornSkin ), cannot );
			AddSubRes( typeof( IcySkins ),			CraftResources.GetClilocCraftName( CraftResource.IcySkin ), CraftResources.GetSkill( CraftResource.IcySkin ), CraftResources.GetClilocMaterialName( CraftResource.IcySkin ), cannot );
			AddSubRes( typeof( LavaSkins ),			CraftResources.GetClilocCraftName( CraftResource.LavaSkin ), CraftResources.GetSkill( CraftResource.LavaSkin ), CraftResources.GetClilocMaterialName( CraftResource.LavaSkin ), cannot );
			AddSubRes( typeof( Seaweeds ),			CraftResources.GetClilocCraftName( CraftResource.Seaweed ), CraftResources.GetSkill( CraftResource.Seaweed ), CraftResources.GetClilocMaterialName( CraftResource.Seaweed ), cannot );
			AddSubRes( typeof( DeadSkins ),			CraftResources.GetClilocCraftName( CraftResource.DeadSkin ), CraftResources.GetSkill( CraftResource.DeadSkin ), CraftResources.GetClilocMaterialName( CraftResource.DeadSkin ), cannot );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}