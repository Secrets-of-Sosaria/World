using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefDraconic : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Blacksmith;	}
		}

        public override int GumpImage
        {
            get { return 9603; }
        }

        public override int GumpTitleNumber
        {
            get { return 0; }
        }
 
        public override string GumpTitleString
        {
            get { return "<BASEFONT Color=#FBFBFB><CENTER>SCALED ARMOR MENU</CENTER></BASEFONT>"; }
        }

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Scales; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Reptile Scaling"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefDraconic();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefDraconic() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
		{
			/*
			
			base( MinCraftEffect, MaxCraftEffect, Delay )
			
			MinCraftEffect	: The minimum number of time the mobile will play the craft effect
			MaxCraftEffect	: The maximum number of time the mobile will play the craft effect
			Delay			: The delay between each craft effect
			
			Example: (3, 6, 1.7) would make the mobile do the PlayCraftEffect override
			function between 3 and 6 time, with a 1.7 second delay each time.
			
			*/ 
		}

		private static Type typeofAnvil = typeof( AnvilAttribute );
		private static Type typeofForge = typeof( ForgeAttribute );

		public static bool IsForge( object obj )
		{
			if ( Core.ML && obj is Mobile && ((Mobile)obj).IsDeadBondedPet )
				return false;

			if ( obj.GetType().IsDefined( typeof( ForgeAttribute ), false ) )
				return true;

			int itemID = 0;

			if ( obj is Item )
				itemID = ((Item)obj).ItemID;
			else if ( obj is StaticTarget )
				itemID = ((StaticTarget)obj).ItemID;

			if ( itemID >= 6896 && itemID <= 6898 )
			{
				if ( obj is FireGiantForge )
				{
					FireGiantForge kettle = (FireGiantForge)obj;
					Server.Items.FireGiantForge.ConsumeCharge( kettle );
					return true;
				}
			}

			return ( itemID == 4017 || (itemID >= 0x10DE && itemID <= 0x10E0) || (itemID >= 6522 && itemID <= 6569) || (itemID >= 0x544B && itemID <= 0x544E) );
		}

		public static void CheckAnvilAndForge( Mobile from, int range, out bool anvil, out bool forge )
		{
			anvil = false;
			forge = false;

			Map map = from.Map;

			if ( map == null )
				return;

			IPooledEnumerable eable = map.GetItemsInRange( from.Location, range );

			foreach ( Item item in eable )
			{
				Type type = item.GetType();

				bool isAnvil = ( type.IsDefined( typeofAnvil, false ) || item.ItemID == 4015 || item.ItemID == 4016 || item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6 || item.ItemID == 0x2B55 || item.ItemID == 0x2B57 || item.ItemID == 0x64ED|| item.ItemID == 0x64EE|| item.ItemID == 0x64EF|| item.ItemID == 0x64F0|| item.ItemID == 0x64F1|| item.ItemID == 0x64F2|| item.ItemID == 0x64F3|| item.ItemID == 0x64F4|| item.ItemID == 0x64F5|| item.ItemID == 0x64F6|| item.ItemID == 0x64F7|| item.ItemID == 0x64F8|| item.ItemID == 0x64F9|| item.ItemID == 0x64FA|| item.ItemID == 0x64FB|| item.ItemID == 0x64FC|| item.ItemID == 0x64FD|| item.ItemID == 0x64FE|| item.ItemID == 0x64FF|| item.ItemID == 0x6500|| item.ItemID == 0x6501|| item.ItemID == 0x6502|| item.ItemID == 0x6503|| item.ItemID == 0x6504|| item.ItemID == 0x6505|| item.ItemID == 0x6506|| item.ItemID == 0x6507|| item.ItemID == 0x6508|| item.ItemID == 0x6509|| item.ItemID == 0x650A|| item.ItemID == 0x650B|| item.ItemID == 0x650C|| item.ItemID == 0x650D|| item.ItemID == 0x650E|| item.ItemID == 0x650F|| item.ItemID == 0x6510|| item.ItemID == 0x6511|| item.ItemID == 0x6512|| item.ItemID == 0x6513|| item.ItemID == 0x6514|| item.ItemID == 0x6515|| item.ItemID == 0x6516|| item.ItemID == 0x6517|| item.ItemID == 0x6518 );
				bool isForge = ( type.IsDefined( typeofForge, false ) || item.ItemID == 4017 || (item.ItemID >= 0x10DE && item.ItemID <= 0x10E0) || (item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8 || (item.ItemID >= 0x544B && item.ItemID <= 0x544E) );

				if ( isAnvil || isForge )
				{
					if ( (from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS( item ) )
						continue;

					anvil = anvil || isAnvil;
					forge = forge || isForge;

					if ( anvil && forge )
						break;
				}
			}

			eable.Free();

			for ( int x = -range; (!anvil || !forge) && x <= range; ++x )
			{
				for ( int y = -range; (!anvil || !forge) && y <= range; ++y )
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles( from.X+x, from.Y+y, true );

					for ( int i = 0; (!anvil || !forge) && i < tiles.Length; ++i )
					{
						int id = tiles[i].ID;

						bool isAnvil = ( id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6 || id == 0x2B55 || id == 0x2B57 || id == 0x64ED || id == 0x64EE || id == 0x64EF || id == 0x64F0 || id == 0x64F1 || id == 0x64F2 || id == 0x64F3 || id == 0x64F4 || id == 0x64F5 || id == 0x64F6 || id == 0x64F7 || id == 0x64F8 || id == 0x64F9 || id == 0x64FA || id == 0x64FB || id == 0x64FC || id == 0x64FD || id == 0x64FE || id == 0x64FF || id == 0x6500 || id == 0x6501 || id == 0x6502 || id == 0x6503 || id == 0x6504 || id == 0x6505 || id == 0x6506 || id == 0x6507 || id == 0x6508 || id == 0x6509 || id == 0x650A || id == 0x650B || id == 0x650C || id == 0x650D || id == 0x650E || id == 0x650F || id == 0x6510 || id == 0x6511 || id == 0x6512 || id == 0x6513 || id == 0x6514 || id == 0x6515 || id == 0x6516 || id == 0x6517 || id == 0x6518 );
						bool isForge = ( id == 4017 || (id >= 0x10DE && id <= 0x10E0) || (id >= 6522 && id <= 6569) || id == 0x2DD8 || (id >= 0x544B && id <= 0x544E) );

						if ( isAnvil || isForge )
						{
							if ( (from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z || !from.InLOS( new Point3D( from.X+x, from.Y+y, tiles[i].Z + (tiles[i].Height/2) + 1 ) ) )
								continue;

							anvil = anvil || isAnvil;
							forge = forge || isForge;
						}
					}
				}
			}
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckTool( tool, from ) )
				return 1048146; // If you have a tool equipped, you must use that tool.
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.
			else if ( from.Skills[SkillName.Blacksmith].Value < 46.0 )
				return 1063800;

			bool anvil, forge;
			CheckAnvilAndForge( from, 2, out anvil, out forge );

			if ( anvil && forge )
				return 0;

			return 1044267; // You must be near an anvil and a forge to smith items.
		}

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x541, m_Tools );
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

			AddCraft( typeof( ScalyArms ), "Scaly Armor", "scaly sleeves", 66.3, 116.3, typeof( RedScales ), "Reptile Scales", 18, 1042081 );
			AddCraft( typeof( ScalyBoots ), "Scaly Armor", "scaly boots", 46.3, 96.3, typeof( RedScales ), "Reptile Scales", 14, 1042081 );
			AddCraft( typeof( ScalyChest ), "Scaly Armor", "scaly tunic", 75, 125, typeof( RedScales ), "Reptile Scales", 25, 1042081 );
			AddCraft( typeof( ScalyGloves ), "Scaly Armor", "scaly gloves", 58.9, 108.9, typeof( RedScales ), "Reptile Scales", 12, 1042081 );
			AddCraft( typeof( ScalyGorget ), "Scaly Armor", "scaly gorget", 56.4, 106.4, typeof( RedScales ), "Reptile Scales", 10, 1042081 );
			AddCraft( typeof( ScalyHelm ), "Scaly Armor", "scaly helm", 62.6, 112.6, typeof( RedScales ), "Reptile Scales", 15, 1042081 );
			AddCraft( typeof( ScalyLegs ), "Scaly Armor", "scaly leggings", 68.8, 118.8, typeof( RedScales ), "Reptile Scales", 20, 1042081 );

			index = AddCraft( typeof( DrakboneBracers ), "Drakbone", "drakbone bracers", 66.3, 116.3, typeof( RedScales ), "Reptile Scales", 12, 1042081 );
				AddRes( index, typeof( DracoSkeletal ), "Draco Bones", 9, 1049063 );
			index = AddCraft( typeof( DrakboneGreaves ), "Drakbone", "drakbone greaves", 68.8, 118.8, typeof( RedScales ), "Reptile Scales", 14, 1042081 );
				AddRes( index, typeof( DracoSkeletal ), "Draco Bones", 10, 1049063 );
			index = AddCraft( typeof( DrakboneGuantlets ), "Drakbone", "drakbone gauntlets", 58.9, 108.9, typeof( RedScales ), "Reptile Scales", 6, 1042081 );
				AddRes( index, typeof( DracoSkeletal ), "Draco Bones", 6, 1049063 );
			index = AddCraft( typeof( DrakboneHelm ), "Drakbone", "drakbone helm", 81.4, 146.4, typeof( RedScales ), "Reptile Scales", 24, 1042081 );
				AddRes( index, typeof( DracoSkeletal ), "Draco Bones", 15, 1049063 );
			index = AddCraft( typeof( DrakboneTunic ), "Drakbone", "drakbone tunic", 75, 125, typeof( RedScales ), "Reptile Scales", 19, 1042081 );
				AddRes( index, typeof( DracoSkeletal ), "Draco Bones", 12, 1049063 );

			AddCraft( typeof( DragonArms ), "Scalemail", "scalemail arms", 86.2, 151.2, typeof( RedScales ), "Reptile Scales", 36, 1042081 );
			AddCraft( typeof( DragonChest ), "Scalemail", "scalemail tunic", 97.5, 162.5, typeof( RedScales ), "Reptile Scales", 50, 1042081 );
			AddCraft( typeof( DragonGloves ), "Scalemail", "scalemail gloves", 76.6, 141.6, typeof( RedScales ), "Reptile Scales", 24, 1042081 );
			AddCraft( typeof( DragonHelm ), "Scalemail", "scalemail helm", 81.4, 146.4, typeof( RedScales ), "Reptile Scales", 30, 1042081 );
			AddCraft( typeof( DragonLegs ), "Scalemail", "scalemail leggings", 89.4, 154.4, typeof( RedScales ), "Reptile Scales", 40, 1042081 );

			AddCraft( typeof( ScaledArms ), "Scaled Plate", "scaled arms", 92.8, 162.8, typeof( RedScales ), "Reptile Scales", 54, 1042081 );
			AddCraft( typeof( ScaledChest ), "Scaled Plate", "scaled chest", 105, 175, typeof( RedScales ), "Reptile Scales", 75, 1042081 );
			AddCraft( typeof( ScaledGloves ), "Scaled Plate", "scaled gloves", 82.5, 152.5, typeof( RedScales ), "Reptile Scales", 36, 1042081 );
			AddCraft( typeof( ScaledGorget ), "Scaled Plate", "scaled gorget", 79, 149, typeof( RedScales ), "Reptile Scales", 30, 1042081 );
			AddCraft( typeof( ScaledHelm ), "Scaled Plate", "scaled helm", 87.6, 157.6, typeof( RedScales ), "Reptile Scales", 45, 1042081 );
			AddCraft( typeof( ScaledLegs ), "Scaled Plate", "scaled legs", 96.3, 166.3, typeof( RedScales ), "Reptile Scales", 60, 1042081 );

			AddCraft( typeof( ScaledShield ), "Shields", "scaled shield", 84.3, 114.3, typeof( RedScales ), "Reptile Scales", 18, 1042081 );
			AddCraft( typeof( ScalemailShield ), "Shields", "scalemail shield", 64.3, 94.3, typeof( RedScales ), "Reptile Scales", 14, 1042081 );

			SetSubRes( typeof( RedScales ), CraftResources.GetClilocCraftName( CraftResource.RedScales ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1079598; // You have no idea how to work these scales.

			AddSubRes( typeof( RedScales ),			CraftResources.GetClilocCraftName( CraftResource.RedScales ), CraftResources.GetSkill( CraftResource.RedScales ), CraftResources.GetClilocMaterialName( CraftResource.RedScales ), cannot );
			AddSubRes( typeof( YellowScales ),		CraftResources.GetClilocCraftName( CraftResource.YellowScales ), CraftResources.GetSkill( CraftResource.YellowScales ), CraftResources.GetClilocMaterialName( CraftResource.YellowScales ), cannot );
			AddSubRes( typeof( BlackScales ),		CraftResources.GetClilocCraftName( CraftResource.BlackScales ), CraftResources.GetSkill( CraftResource.BlackScales ), CraftResources.GetClilocMaterialName( CraftResource.BlackScales ), cannot );
			AddSubRes( typeof( GreenScales ),		CraftResources.GetClilocCraftName( CraftResource.GreenScales ), CraftResources.GetSkill( CraftResource.GreenScales ), CraftResources.GetClilocMaterialName( CraftResource.GreenScales ), cannot );
			AddSubRes( typeof( WhiteScales ),		CraftResources.GetClilocCraftName( CraftResource.WhiteScales ), CraftResources.GetSkill( CraftResource.WhiteScales ), CraftResources.GetClilocMaterialName( CraftResource.WhiteScales ), cannot );
			AddSubRes( typeof( BlueScales ),		CraftResources.GetClilocCraftName( CraftResource.BlueScales ), CraftResources.GetSkill( CraftResource.BlueScales ), CraftResources.GetClilocMaterialName( CraftResource.BlueScales ), cannot );
			AddSubRes( typeof( DinosaurScales ),	CraftResources.GetClilocCraftName( CraftResource.DinosaurScales ), CraftResources.GetSkill( CraftResource.DinosaurScales ), CraftResources.GetClilocMaterialName( CraftResource.DinosaurScales ), cannot );
			AddSubRes( typeof( MetallicScales ),	CraftResources.GetClilocCraftName( CraftResource.MetallicScales ), CraftResources.GetSkill( CraftResource.MetallicScales ), CraftResources.GetClilocMaterialName( CraftResource.MetallicScales ), cannot );
			AddSubRes( typeof( BrazenScales ),		CraftResources.GetClilocCraftName( CraftResource.BrazenScales ), CraftResources.GetSkill( CraftResource.BrazenScales ), CraftResources.GetClilocMaterialName( CraftResource.BrazenScales ), cannot );
			AddSubRes( typeof( UmberScales ),		CraftResources.GetClilocCraftName( CraftResource.UmberScales ), CraftResources.GetSkill( CraftResource.UmberScales ), CraftResources.GetClilocMaterialName( CraftResource.UmberScales ), cannot );
			AddSubRes( typeof( VioletScales ),		CraftResources.GetClilocCraftName( CraftResource.VioletScales ), CraftResources.GetSkill( CraftResource.VioletScales ), CraftResources.GetClilocMaterialName( CraftResource.VioletScales ), cannot );
			AddSubRes( typeof( PlatinumScales ),	CraftResources.GetClilocCraftName( CraftResource.PlatinumScales ), CraftResources.GetSkill( CraftResource.PlatinumScales ), CraftResources.GetClilocMaterialName( CraftResource.PlatinumScales ), cannot );
			AddSubRes( typeof( CadalyteScales ),	CraftResources.GetClilocCraftName( CraftResource.CadalyteScales ), CraftResources.GetSkill( CraftResource.CadalyteScales ), CraftResources.GetClilocMaterialName( CraftResource.CadalyteScales ), cannot );
			AddSubRes( typeof( GornScales ),		CraftResources.GetClilocCraftName( CraftResource.GornScales ), CraftResources.GetSkill( CraftResource.GornScales ), CraftResources.GetClilocMaterialName( CraftResource.GornScales ), cannot );
			AddSubRes( typeof( TrandoshanScales ),	CraftResources.GetClilocCraftName( CraftResource.TrandoshanScales ), CraftResources.GetSkill( CraftResource.TrandoshanScales ), CraftResources.GetClilocMaterialName( CraftResource.TrandoshanScales ), cannot );
			AddSubRes( typeof( SilurianScales ),	CraftResources.GetClilocCraftName( CraftResource.SilurianScales ), CraftResources.GetSkill( CraftResource.SilurianScales ), CraftResources.GetClilocMaterialName( CraftResource.SilurianScales ), cannot );
			AddSubRes( typeof( KraytScales ),		CraftResources.GetClilocCraftName( CraftResource.KraytScales ), CraftResources.GetSkill( CraftResource.KraytScales ), CraftResources.GetClilocMaterialName( CraftResource.KraytScales ), cannot );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}