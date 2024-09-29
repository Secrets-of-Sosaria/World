using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefTailoring : CraftSystem
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
			get { return 1044005; } // <CENTER>TAILORING MENU</CENTER>
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Fabric; }
		}

		public override CraftResourceType BreakDownTypeAlt
		{
			get { return CraftResourceType.Leather; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Tailoring"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefTailoring();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefTailoring() : base( 1, 1, 1.25 )
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
			int index = -1;

			#region Hats
			AddCraft( typeof( SkullCap ), 1011375, 1025444, 0.0, 25.0, typeof( Fabric ), 1044286, 2, 1044287 );
			AddCraft( typeof( Bandana ), 1011375, 1025440, 0.0, 25.0, typeof( Fabric ), 1044286, 2, 1044287 );
			AddCraft( typeof( FloppyHat ), 1011375, 1025907, 6.2, 31.2, typeof( Fabric ), 1044286, 11, 1044287 );
			AddCraft( typeof( Cap ), 1011375, 1025909, 6.2, 31.2, typeof( Fabric ), 1044286, 11, 1044287 );
			AddCraft( typeof( WideBrimHat ), 1011375, 1025908, 6.2, 31.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( StrawHat ), 1011375, 1025911, 6.2, 31.2, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( TallStrawHat ), 1011375, 1025910, 6.7, 31.7, typeof( Fabric ), 1044286, 13, 1044287 );
			AddCraft( typeof( WizardsHat ), 1011375, 1025912, 7.2, 32.2, typeof( Fabric ), 1044286, 15, 1044287 );
			AddCraft( typeof( WitchHat ), 1011375, "witch hat", 7.2, 32.2, typeof( Fabric ), 1044286, 15, 1044287 );
			AddCraft( typeof( Bonnet ), 1011375, 1025913, 6.2, 31.2, typeof( Fabric ), 1044286, 11, 1044287 );
			AddCraft( typeof( FeatheredHat ), 1011375, 1025914, 6.2, 31.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( TricorneHat ), 1011375, 1025915, 6.2, 31.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( PirateHat ), 1011375, "pirate hat", 6.2, 31.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( JesterHat ), 1011375, 1025916, 7.2, 32.2, typeof( Fabric ), 1044286, 15, 1044287 );
			AddCraft( typeof( ClothCowl ), 1011375, "cloth cowl", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( ClothHood ), 1011375, "cloth hood", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( FancyHood ), 1011375, "fancy hood", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( HoodedMantle ), 1011375, "hooded mantle", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( WizardHood ), 1011375, "wizard hood", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
			index = AddCraft( typeof( DeadMask ), 1011375, "mask of the dead", 7.2, 32.2, typeof( Fabric ), 1044286, 12, 1044287 );
				AddRes( index, typeof( BrittleSkeletal ), "Human Bones", 1, 1049063 );
			AddCraft( typeof( ClothNinjaHood ), 1011375, 1030202, 80.0, 105.0, typeof( Fabric ), 1044286, 13, 1044287 );
			AddCraft( typeof( Kasa ), 1011375, 1030211, 60.0, 85.0, typeof( Fabric ), 1044286, 12, 1044287 );	
			#endregion

			#region Shirts
			AddCraft( typeof( Doublet ), 1015269, 1028059, 0, 25.0, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( Shirt ), 1015269, 1025399, 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( BeggarVest ), 1015269, "beggar vest", 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( RoyalVest ), 1015269, "royal vest", 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( RusticVest ), 1015269, "rustic vest", 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( Tunic ), 1015269, 1028097, 00.0, 25.0, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( Surcoat ), 1015269, 1028189, 8.2, 33.2, typeof( Fabric ), 1044286, 14, 1044287 );
			AddCraft( typeof( PlainDress ), 1015269, 1027937, 12.4, 37.4, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( FancyDress ), 1015269, 1027935, 33.1, 58.1, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( GildedDress ), 1015269, 1028973, 37.5, 62.5, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( Cloak ), 1015269, 1025397, 41.4, 66.4, typeof( Fabric ), 1044286, 14, 1044287 );
			AddCraft( typeof( RoyalCape ), 1015269, "royal cloak", 91.4, 120.4, typeof( Fabric ), 1044286, 14, 1044287 );
			AddCraft( typeof( Robe ), 1015269, 1027939, 53.9, 78.9, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ArchmageRobe ), 1015269, "archmage robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( AssassinRobe ), 1015269, "assassin robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ChaosRobe ), 1015269, "chaos robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( CultistRobe ), 1015269, "cultist robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( DragonRobe ), 1015269, "dragon robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ElegantRobe ), 1015269, "elegant robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ExquisiteRobe ), 1015269, "exquisite robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FancyRobe ), 1015269, "fancy robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FoolsCoat ), 1015269, "fool's coat", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FormalRobe ), 1015269, "formal robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( GildedRobe ), 1015269, "gilded robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( GildedDarkRobe ), 1015269, "gilded dark robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( GildedLightRobe ), 1015269, "gilded light robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( JesterGarb ), 1015269, "jester garb", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( JesterSuit ), 1015269, 1028095, 8.2, 33.2, typeof( Fabric ), 1044286, 24, 1044287 );
			AddCraft( typeof( JokerRobe ), 1015269, "jester coat", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( MagistrateRobe ), 1015269, "magistrate robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( NecromancerRobe ), 1015269, "necromancer robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( OrnateRobe ), 1015269, "ornate robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( PirateCoat ), 1015269, "pirate coat", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( PriestRobe ), 1015269, "priest robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ProphetRobe ), 1015269, "prophet robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( RoyalRobe ), 1015269, "royal robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( SageRobe ), 1015269, "sage robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ScholarRobe ), 1015269, "scholar robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( SorcererRobe ), 1015269, "sorcerer robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( SpiderRobe ), 1015269, "spider robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( VagabondRobe ), 1015269, "vagabond robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( VampireRobe ), 1015269, "vampire robe", 70.0, 95.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FancyShirt ), 1015269, 1027933, 24.8, 49.8, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( FormalShirt ), 1015269, 1028975, 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FormalCoat ), 1015269, "formal coat", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( RoyalCoat ), 1015269, "royal coat", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( RoyalShirt ), 1015269, "royal shirt", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( RusticShirt ), 1015269, "rustic shirt", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( SquireShirt ), 1015269, "squire shirt", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( WizardShirt ), 1015269, "wizard shirt", 26.0, 51.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( ClothNinjaJacket ), 1015269, 1030207, 75.0, 100.0, typeof( Fabric ), 1044286, 12, 1044287 );
			AddCraft( typeof( Kamishimo ), 1015269, 1030212, 75.0, 100.0, typeof( Fabric ), 1044286, 15, 1044287 );
			AddCraft( typeof( HakamaShita ), 1015269, 1030215, 40.0, 65.0, typeof( Fabric ), 1044286, 14, 1044287 );
			AddCraft( typeof( MaleKimono ), 1015269, 1030189, 50.0, 75.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( FemaleKimono ), 1015269, 1030190, 50.0, 75.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( JinBaori ), 1015269, 1030220, 30.0, 55.0, typeof( Fabric ), 1044286, 12, 1044287 );
			#endregion

			#region Pants
			AddCraft( typeof( ShortPants ), 1015279, 1025422, 24.8, 49.8, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( LongPants ), 1015279, 1025433, 24.8, 49.8, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( SailorPants ), 1015279, "sailor pants", 24.8, 49.8, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( PiratePants ), 1015279, "pirate pants", 24.8, 49.8, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( Kilt ), 1015279, 1025431, 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( Skirt ), 1015279, 1025398, 29.0, 54.0, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( RoyalSkirt ), 1015279, "royal skirt", 20.7, 45.7, typeof( Fabric ), 1044286, 8, 1044287 );
			AddCraft( typeof( RoyalLongSkirt ), 1015279, "royal long skirt", 29.0, 54.0, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( Hakama ), 1015279, 1030213, 50.0, 75.0, typeof( Fabric ), 1044286, 16, 1044287 );
			AddCraft( typeof( TattsukeHakama ), 1015279, 1030214, 50.0, 75.0, typeof( Fabric ), 1044286, 16, 1044287 );
			#endregion

			#region Misc
			AddCraft( typeof( BodySash ), 1015283, 1025441, 4.1, 29.1, typeof( Fabric ), 1044286, 4, 1044287 );
			AddCraft( typeof( Belt ), 1015283, "belt", 20.7, 45.7, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( LoinCloth ), 1015283, "loin cloth", 20.7, 45.7, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( HalfApron ), 1015283, 1025435, 20.7, 45.7, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( FullApron ), 1015283, 1025437, 29.0, 54.0, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( Obi ), 1015283, 1030219, 20.0, 45.0, typeof( Fabric ), 1044286, 6, 1044287 );
			AddCraft( typeof( HarpoonRope ), 1015283, "harpoon rope", 0.0, 40.0, typeof( Fabric ), 1044286, 1, 1044287 );
			AddCraft( typeof( LeatherNinjaBelt ), 1015283, "ninja belt", 50.0, 75.0, typeof( Fabric ), 1044286, 5, 1044287 );
			AddCraft( typeof( OilCloth ), 1015283, 1041498, 74.6, 99.6, typeof( Fabric ), 1044286, 1, 1044287 );
			AddCraft( typeof( GozaMatEastDeed ), 1015283, 1030404, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( GozaMatSouthDeed ), 1015283, 1030405, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( SquareGozaMatEastDeed ), 1015283, 1030407, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( SquareGozaMatSouthDeed ), 1015283, 1030406, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeGozaMatEastDeed ), 1015283, 1030408, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeGozaMatSouthDeed ), 1015283, 1030409, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeSquareGozaMatEastDeed ), 1015283, 1030411, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeSquareGozaMatSouthDeed ), 1015283, 1030410, 55.0, 80.0, typeof( Fabric ), 1044286, 25, 1044287 );
			#endregion

			#region Footwear
			AddCraft( typeof( NinjaTabi ), 1015288, 1030210, 70.0, 95.0, typeof( Fabric ), 1044286, 10, 1044287 );
			AddCraft( typeof( SamuraiTabi ), 1015288, 1030209, 20.0, 45.0, typeof( Fabric ), 1044286, 6, 1044287 );
			#endregion

			// Set the overridable material
			SetSubRes( typeof( Fabric ), CraftResources.GetClilocCraftName( CraftResource.Fabric ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1060097; // You have no idea how to work this fabric.

			AddSubRes( typeof( Fabric ),				CraftResources.GetClilocCraftName( CraftResource.Fabric ), CraftResources.GetSkill( CraftResource.Fabric ), CraftResources.GetClilocMaterialName( CraftResource.Fabric ), cannot );
			AddSubRes( typeof( FurryFabric ),			CraftResources.GetClilocCraftName( CraftResource.FurryFabric ), CraftResources.GetSkill( CraftResource.FurryFabric ), CraftResources.GetClilocMaterialName( CraftResource.FurryFabric ), cannot );
			AddSubRes( typeof( WoolyFabric ),			CraftResources.GetClilocCraftName( CraftResource.WoolyFabric ), CraftResources.GetSkill( CraftResource.WoolyFabric ), CraftResources.GetClilocMaterialName( CraftResource.WoolyFabric ), cannot );
			AddSubRes( typeof( SilkFabric ),			CraftResources.GetClilocCraftName( CraftResource.SilkFabric ), CraftResources.GetSkill( CraftResource.SilkFabric ), CraftResources.GetClilocMaterialName( CraftResource.SilkFabric ), cannot );
			AddSubRes( typeof( HauntedFabric ),			CraftResources.GetClilocCraftName( CraftResource.HauntedFabric ), CraftResources.GetSkill( CraftResource.HauntedFabric ), CraftResources.GetClilocMaterialName( CraftResource.HauntedFabric ), cannot );
			AddSubRes( typeof( ArcticFabric ),			CraftResources.GetClilocCraftName( CraftResource.ArcticFabric ), CraftResources.GetSkill( CraftResource.ArcticFabric ), CraftResources.GetClilocMaterialName( CraftResource.ArcticFabric ), cannot );
			AddSubRes( typeof( PyreFabric ),			CraftResources.GetClilocCraftName( CraftResource.PyreFabric ), CraftResources.GetSkill( CraftResource.PyreFabric ), CraftResources.GetClilocMaterialName( CraftResource.PyreFabric ), cannot );
			AddSubRes( typeof( VenomousFabric ),		CraftResources.GetClilocCraftName( CraftResource.VenomousFabric ), CraftResources.GetSkill( CraftResource.VenomousFabric ), CraftResources.GetClilocMaterialName( CraftResource.VenomousFabric ), cannot );
			AddSubRes( typeof( MysteriousFabric ),		CraftResources.GetClilocCraftName( CraftResource.MysteriousFabric ), CraftResources.GetSkill( CraftResource.MysteriousFabric ), CraftResources.GetClilocMaterialName( CraftResource.MysteriousFabric ), cannot );
			AddSubRes( typeof( VileFabric ),			CraftResources.GetClilocCraftName( CraftResource.VileFabric ), CraftResources.GetSkill( CraftResource.VileFabric ), CraftResources.GetClilocMaterialName( CraftResource.VileFabric ), cannot );
			AddSubRes( typeof( DivineFabric ),			CraftResources.GetClilocCraftName( CraftResource.DivineFabric ), CraftResources.GetSkill( CraftResource.DivineFabric ), CraftResources.GetClilocMaterialName( CraftResource.DivineFabric ), cannot );
			AddSubRes( typeof( FiendishFabric ),		CraftResources.GetClilocCraftName( CraftResource.FiendishFabric ), CraftResources.GetSkill( CraftResource.FiendishFabric ), CraftResources.GetClilocMaterialName( CraftResource.FiendishFabric ), cannot );
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