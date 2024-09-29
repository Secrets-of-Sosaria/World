using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefBowFletching : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Bowcraft; }
		}

        public override int GumpImage
        {
            get { return 9601; }
        }

		public override int GumpTitleNumber
		{
			get { return 1044006; } // <CENTER>BOWCRAFTING MENU</CENTER>
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Wood; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Bows & Fletching"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBowFletching();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefBowFletching() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x55, m_Tools );
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

		public override CraftECA ECA{ get{ return CraftECA.FiftyPercentChanceMinusTenPercent; } }

		public override void InitCraftList()
		{
			int index = -1;

			// Materials
			if ( !AllowManyCraft( m_Tools ) ){ AddCraft( typeof( Kindling ), 1044457, "kindling from a log", 0.0, 00.0, typeof( BaseLog ), 1044466, 1, 1044351 ); }

			index = AddCraft( typeof( Kindling ), 1044457, "kindling from logs", 0.0, 00.0, typeof( BaseLog ), 1044466, 1, 1044351 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			index = AddCraft( typeof( Shaft ), 1044457, "shafts from logs", 0.0, 40.0, typeof( BaseLog ), 1044466, 1, 1044351 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			if ( !AllowManyCraft( m_Tools ) ){ AddCraft( typeof( Kindling ), 1044457, "kindling from a board", 0.0, 00.0, typeof( Board ), 1015101, 1, 1044351 ); }

			index = AddCraft( typeof( Kindling ), 1044457, "kindling from boards", 0.0, 00.0, typeof( Board ), 1015101, 1, 1044351 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			index = AddCraft( typeof( Shaft ), 1044457, "shafts from boards", 0.0, 40.0, typeof( Board ), 1015101, 1, 1044351 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			// Ammunition
			index = AddCraft( typeof( Arrow ), 1044565, 1023903, 0.0, 40.0, typeof( Shaft ), 1044560, 1, 1044561 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			index = AddCraft( typeof( Bolt ), 1044565, 1027163, 0.0, 40.0, typeof( Shaft ), 1044560, 1, 1044561 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			index = AddCraft( typeof( FukiyaDarts ), 1044565, 1030246, 50.0, 90.0, typeof( Board ), 1015101, 1, 1044351 );
			if ( !AllowManyCraft( m_Tools ) ){ SetUseAllRes( index, true ); }

			// Weapons
			AddCraft( typeof( Bow ), 1044566, 1025042, 30.0, 70.0, typeof( Board ), 1015101, 7, 1044351 );
			AddCraft( typeof( Crossbow ), 1044566, 1023919, 60.0, 100.0, typeof( Board ), 1015101, 7, 1044351 );
			AddCraft( typeof( HeavyCrossbow ), 1044566, 1025117, 80.0, 120.0, typeof( Board ), 1015101, 10, 1044351 );
			AddCraft( typeof( CompositeBow ), 1044566, 1029922, 70.0, 110.0, typeof( Board ), 1015101, 7, 1044351 );
			AddCraft( typeof( RepeatingCrossbow ), 1044566, 1029923, 90.0, 130.0, typeof( Board ), 1015101, 10, 1044351 );
			AddCraft( typeof( Yumi ), 1044566, 1030224, 90.0, 130.0, typeof( Board ), 1015101, 10, 1044351 );
			AddCraft( typeof( MagicalShortbow ), 1044566, "woodland shortbow", 50.0, 80.0, typeof( Board ), 1015101, 7, 1044351 );
			AddCraft( typeof( ElvenCompositeLongbow ), 1044566, "woodland longbow", 50.0, 80.0, typeof( Board ), 1015101, 7, 1044351 );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;

			SetSubRes( typeof( Board ), CraftResources.GetClilocCraftName( CraftResource.RegularWood ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1079597; // You have no idea how to work this wood.

			AddSubRes( typeof( Board ),				CraftResources.GetClilocCraftName( CraftResource.RegularWood ), CraftResources.GetSkill( CraftResource.RegularWood ), CraftResources.GetClilocMaterialName( CraftResource.RegularWood ), cannot );
			AddSubRes( typeof( AshBoard ),			CraftResources.GetClilocCraftName( CraftResource.AshTree ), CraftResources.GetSkill( CraftResource.AshTree ), CraftResources.GetClilocMaterialName( CraftResource.AshTree ), cannot );
			AddSubRes( typeof( CherryBoard ),		CraftResources.GetClilocCraftName( CraftResource.CherryTree ), CraftResources.GetSkill( CraftResource.CherryTree ), CraftResources.GetClilocMaterialName( CraftResource.CherryTree ), cannot );
			AddSubRes( typeof( EbonyBoard ),		CraftResources.GetClilocCraftName( CraftResource.EbonyTree ), CraftResources.GetSkill( CraftResource.EbonyTree ), CraftResources.GetClilocMaterialName( CraftResource.EbonyTree ), cannot );
			AddSubRes( typeof( GoldenOakBoard ),	CraftResources.GetClilocCraftName( CraftResource.GoldenOakTree ), CraftResources.GetSkill( CraftResource.GoldenOakTree ), CraftResources.GetClilocMaterialName( CraftResource.GoldenOakTree ), cannot );
			AddSubRes( typeof( HickoryBoard ),		CraftResources.GetClilocCraftName( CraftResource.HickoryTree ), CraftResources.GetSkill( CraftResource.HickoryTree ), CraftResources.GetClilocMaterialName( CraftResource.HickoryTree ), cannot );
			AddSubRes( typeof( MahoganyBoard ),		CraftResources.GetClilocCraftName( CraftResource.MahoganyTree ), CraftResources.GetSkill( CraftResource.MahoganyTree ), CraftResources.GetClilocMaterialName( CraftResource.MahoganyTree ), cannot );
			AddSubRes( typeof( OakBoard ),			CraftResources.GetClilocCraftName( CraftResource.OakTree ), CraftResources.GetSkill( CraftResource.OakTree ), CraftResources.GetClilocMaterialName( CraftResource.OakTree ), cannot );
			AddSubRes( typeof( PineBoard ),			CraftResources.GetClilocCraftName( CraftResource.PineTree ), CraftResources.GetSkill( CraftResource.PineTree ), CraftResources.GetClilocMaterialName( CraftResource.PineTree ), cannot );
			AddSubRes( typeof( GhostBoard ),		CraftResources.GetClilocCraftName( CraftResource.GhostTree ), CraftResources.GetSkill( CraftResource.GhostTree ), CraftResources.GetClilocMaterialName( CraftResource.GhostTree ), cannot );
			AddSubRes( typeof( RosewoodBoard ),		CraftResources.GetClilocCraftName( CraftResource.RosewoodTree ), CraftResources.GetSkill( CraftResource.RosewoodTree ), CraftResources.GetClilocMaterialName( CraftResource.RosewoodTree ), cannot );
			AddSubRes( typeof( WalnutBoard ),		CraftResources.GetClilocCraftName( CraftResource.WalnutTree ), CraftResources.GetSkill( CraftResource.WalnutTree ), CraftResources.GetClilocMaterialName( CraftResource.WalnutTree ), cannot );
			AddSubRes( typeof( PetrifiedBoard ),	CraftResources.GetClilocCraftName( CraftResource.PetrifiedTree ), CraftResources.GetSkill( CraftResource.PetrifiedTree ), CraftResources.GetClilocMaterialName( CraftResource.PetrifiedTree ), cannot );
			AddSubRes( typeof( DriftwoodBoard ),	CraftResources.GetClilocCraftName( CraftResource.DriftwoodTree ), CraftResources.GetSkill( CraftResource.DriftwoodTree ), CraftResources.GetClilocMaterialName( CraftResource.DriftwoodTree ), cannot );
			AddSubRes( typeof( ElvenBoard ),		CraftResources.GetClilocCraftName( CraftResource.ElvenTree ), CraftResources.GetSkill( CraftResource.ElvenTree ), CraftResources.GetClilocMaterialName( CraftResource.ElvenTree ), cannot );
			AddSubRes( typeof( BorlBoard ),			CraftResources.GetClilocCraftName( CraftResource.BorlTree ), CraftResources.GetSkill( CraftResource.BorlTree ), CraftResources.GetClilocMaterialName( CraftResource.BorlTree ), cannot );
			AddSubRes( typeof( CosianBoard ),		CraftResources.GetClilocCraftName( CraftResource.CosianTree ), CraftResources.GetSkill( CraftResource.CosianTree ), CraftResources.GetClilocMaterialName( CraftResource.CosianTree ), cannot );
			AddSubRes( typeof( GreelBoard ),		CraftResources.GetClilocCraftName( CraftResource.GreelTree ), CraftResources.GetSkill( CraftResource.GreelTree ), CraftResources.GetClilocMaterialName( CraftResource.GreelTree ), cannot );
			AddSubRes( typeof( JaporBoard ),		CraftResources.GetClilocCraftName( CraftResource.JaporTree ), CraftResources.GetSkill( CraftResource.JaporTree ), CraftResources.GetClilocMaterialName( CraftResource.JaporTree ), cannot );
			AddSubRes( typeof( KyshyyykBoard ),		CraftResources.GetClilocCraftName( CraftResource.KyshyyykTree ), CraftResources.GetSkill( CraftResource.KyshyyykTree ), CraftResources.GetClilocMaterialName( CraftResource.KyshyyykTree ), cannot );
			AddSubRes( typeof( LaroonBoard ),		CraftResources.GetClilocCraftName( CraftResource.LaroonTree ), CraftResources.GetSkill( CraftResource.LaroonTree ), CraftResources.GetClilocMaterialName( CraftResource.LaroonTree ), cannot );
			AddSubRes( typeof( TeejBoard ),			CraftResources.GetClilocCraftName( CraftResource.TeejTree ), CraftResources.GetSkill( CraftResource.TeejTree ), CraftResources.GetClilocMaterialName( CraftResource.TeejTree ), cannot );
			AddSubRes( typeof( VeshokBoard ),		CraftResources.GetClilocCraftName( CraftResource.VeshokTree ), CraftResources.GetSkill( CraftResource.VeshokTree ), CraftResources.GetClilocMaterialName( CraftResource.VeshokTree ), cannot );
		}
	}
}