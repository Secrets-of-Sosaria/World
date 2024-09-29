using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefBonecrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Forensics; }
		}

        public override int GumpImage
        {
            get { return 9614; }
        }

		public override int GumpTitleNumber
		{
			get { return 1044131; } // <CENTER>BONECRAFTING MENU</CENTER>
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Skeletal; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Bone"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBonecrafting();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefBonecrafting() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
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
			#region Bone Armor
			AddCraft( typeof( BoneArms ), 1049149, "bone bracers", 42.0, 67.0, typeof( BrittleSkeletal ), 1049064, 12, 1049063 );
			AddCraft( typeof( BoneLegs ), 1049149, "bone greaves", 45.0, 70.0, typeof( BrittleSkeletal ), 1049064, 16, 1049063 );
			AddCraft( typeof( BoneGloves ), 1049149, "bone gauntlets", 39.0, 64.0, typeof( BrittleSkeletal ), 1049064, 8, 1049063 );
			AddCraft( typeof( BoneHelm ), 1049149, "bone helm", 35.0, 60.0, typeof( BrittleSkeletal ), 1049064, 6, 1049063 );
			AddCraft( typeof( BoneSkirt ), 1049149, "bone skirt", 45.0, 70.0, typeof( BrittleSkeletal ), 1049064, 16, 1049063 );
			AddCraft( typeof( BoneChest ), 1049149, "bone tunic", 46.0, 71.0, typeof( BrittleSkeletal ), 1049064, 22, 1049063 );
			#endregion

			#region Skeletal Armor
			AddCraft( typeof( SavageArms ), "Skeletal Armor", "skeletal bracers", 92.0, 117.0, typeof( BrittleSkeletal ), 1049064, 16, 1049063 );
			AddCraft( typeof( SavageLegs ), "Skeletal Armor", "skeletal greaves", 95.0, 120.0, typeof( BrittleSkeletal ), 1049064, 20, 1049063 );
			AddCraft( typeof( SavageGloves ), "Skeletal Armor", "skeletal gauntlets", 89.0, 114.0, typeof( BrittleSkeletal ), 1049064, 12, 1049063 );
			AddCraft( typeof( SavageHelm ), "Skeletal Armor", "skeletal helm", 85.0, 110.0, typeof( BrittleSkeletal ), 1049064, 10, 1049063 );
			AddCraft( typeof( SavageChest ), "Skeletal Armor", "skeletal tunic", 96.0, 121.0, typeof( BrittleSkeletal ), 1049064, 26, 1049063 );
			#endregion

			// Set the overridable material
			SetSubRes( typeof( BrittleSkeletal ), CraftResources.GetClilocCraftName( CraftResource.BrittleSkeletal ) );

			int cannot = 1079594; // You have no idea how to work this bone.

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			AddSubRes( typeof( BrittleSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.BrittleSkeletal ), CraftResources.GetSkill( CraftResource.BrittleSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.BrittleSkeletal ), cannot );
			AddSubRes( typeof( DrowSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.DrowSkeletal ), CraftResources.GetSkill( CraftResource.DrowSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.DrowSkeletal ), cannot );
			AddSubRes( typeof( OrcSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.OrcSkeletal ), CraftResources.GetSkill( CraftResource.OrcSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.OrcSkeletal ), cannot );
			AddSubRes( typeof( ReptileSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.ReptileSkeletal ), CraftResources.GetSkill( CraftResource.ReptileSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.ReptileSkeletal ), cannot );
			AddSubRes( typeof( OgreSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.OgreSkeletal ), CraftResources.GetSkill( CraftResource.OgreSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.OgreSkeletal ), cannot );
			AddSubRes( typeof( TrollSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.TrollSkeletal ), CraftResources.GetSkill( CraftResource.TrollSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.TrollSkeletal ), cannot );
			AddSubRes( typeof( GargoyleSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.GargoyleSkeletal ), CraftResources.GetSkill( CraftResource.GargoyleSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.GargoyleSkeletal ), cannot );
			AddSubRes( typeof( MinotaurSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.MinotaurSkeletal ), CraftResources.GetSkill( CraftResource.MinotaurSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.MinotaurSkeletal ), cannot );
			AddSubRes( typeof( LycanSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.LycanSkeletal ), CraftResources.GetSkill( CraftResource.LycanSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.LycanSkeletal ), cannot );
			AddSubRes( typeof( SharkSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.SharkSkeletal ), CraftResources.GetSkill( CraftResource.SharkSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.SharkSkeletal ), cannot );
			AddSubRes( typeof( ColossalSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.ColossalSkeletal ), CraftResources.GetSkill( CraftResource.ColossalSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.ColossalSkeletal ), cannot );
			AddSubRes( typeof( MysticalSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.MysticalSkeletal ), CraftResources.GetSkill( CraftResource.MysticalSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.MysticalSkeletal ), cannot );
			AddSubRes( typeof( VampireSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.VampireSkeletal ), CraftResources.GetSkill( CraftResource.VampireSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.VampireSkeletal ), cannot );
			AddSubRes( typeof( LichSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.LichSkeletal ), CraftResources.GetSkill( CraftResource.LichSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.LichSkeletal ), cannot );
			AddSubRes( typeof( SphinxSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.SphinxSkeletal ), CraftResources.GetSkill( CraftResource.SphinxSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.SphinxSkeletal ), cannot );
			AddSubRes( typeof( DevilSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.DevilSkeletal ), CraftResources.GetSkill( CraftResource.DevilSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.DevilSkeletal ), cannot );
			AddSubRes( typeof( DracoSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.DracoSkeletal ), CraftResources.GetSkill( CraftResource.DracoSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.DracoSkeletal ), cannot );
			AddSubRes( typeof( XenoSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.XenoSkeletal ), CraftResources.GetSkill( CraftResource.XenoSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.XenoSkeletal ), cannot );
			AddSubRes( typeof( AndorianSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.AndorianSkeletal ), CraftResources.GetSkill( CraftResource.AndorianSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.AndorianSkeletal ), cannot );
			AddSubRes( typeof( CardassianSkeletal ),CraftResources.GetClilocCraftName( CraftResource.CardassianSkeletal ), CraftResources.GetSkill( CraftResource.CardassianSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.CardassianSkeletal ), cannot );
			AddSubRes( typeof( MartianSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.MartianSkeletal ), CraftResources.GetSkill( CraftResource.MartianSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.MartianSkeletal ), cannot );
			AddSubRes( typeof( RodianSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.RodianSkeletal ), CraftResources.GetSkill( CraftResource.RodianSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.RodianSkeletal ), cannot );
			AddSubRes( typeof( TuskenSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.TuskenSkeletal ), CraftResources.GetSkill( CraftResource.TuskenSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.TuskenSkeletal ), cannot );
			AddSubRes( typeof( TwilekSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.TwilekSkeletal ), CraftResources.GetSkill( CraftResource.TwilekSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.TwilekSkeletal ), cannot );
			AddSubRes( typeof( XindiSkeletal ),		CraftResources.GetClilocCraftName( CraftResource.XindiSkeletal ), CraftResources.GetSkill( CraftResource.XindiSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.XindiSkeletal ), cannot );
			AddSubRes( typeof( ZabrakSkeletal ),	CraftResources.GetClilocCraftName( CraftResource.ZabrakSkeletal ), CraftResources.GetSkill( CraftResource.ZabrakSkeletal ), CraftResources.GetClilocMaterialName( CraftResource.ZabrakSkeletal ), cannot );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}