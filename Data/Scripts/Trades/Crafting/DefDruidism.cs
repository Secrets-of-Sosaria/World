using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefDruidism : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Druidism; }
		}

        public override int GumpImage
        {
            get { return 9598; }
        }

		public override int GumpTitleNumber
		{
			get { return 1044124; } // <CENTER>DRUIDIC HERBALISM MENU</CENTER>
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Druid Herbalism"; }
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefDruidism();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefDruidism() : base( 1, 1, 1.25 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044125; // You have use the cauldron too much and the metal corroded!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044126; // The cauldron must be in your pack to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x020, m_Tools );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, CraftItem item )
		{
			Server.Gumps.RegBar.RefreshRegBar( from );

			if ( toolBroken )
				from.SendLocalizedMessage( 1044125 ); // You have use the cauldron too much and the metal corroded!

			if ( failed )
			{
				from.AddToBackpack( new Jar() );
				return 500287; // You fail to create a useful potion.
			}
			else
			{
				CraftSystem.CraftSoundAfter( from, 0x240, m_Tools ); // Sound of a filling bottle
				return 1044127; // You pour the potion into a jar...
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			index = AddCraft( typeof( LureStonePotion ), "Brews", "stone in a jar", 10.0, 30.0, typeof( MoonCrystal ), "Moon Crystal", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 5.0, 15.0 );
			AddRes( index, typeof ( SilverWidow ), "Silver Widow", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( NaturesPassagePotion ), "Brews", "nature passage mixture", 15.0, 35.0, typeof( SeaSalt ), "Sea Salt", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 10.0, 20.0 );
			AddRes( index, typeof ( FairyEgg ), "Fairy Egg", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( ShieldOfEarthPotion ), "Brews", "shield of earth liquid", 20.0, 40.0, typeof( Ginseng ), "Ginseng", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 15.0, 25.0 );
			AddRes( index, typeof ( BlackPearl ), "Black Pearl", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( WoodlandProtectionPotion ), "Brews", "woodland protection oil", 25.0, 45.0, typeof( Garlic ), "Garlic", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 20.0, 30.0 );
			AddRes( index, typeof ( SwampBerries ), "Swamp Berries", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( StoneCirclePotion ), "Brews", "stone rising concoction", 30.0, 50.0, typeof( BeetleShell ), "Beetle Shell", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 25.0, 35.0 );
			AddRes( index, typeof ( SeaSalt ), "Sea Salt", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( GraspingRootsPotion ), "Brews", "grasping roots mixture", 35.0, 55.0, typeof( MandrakeRoot ), "Mandrake Root", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 30.0, 40.0 );
			AddRes( index, typeof ( Ginseng ), "Ginseng", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( DruidicRunePotion ), "Brews", "druidic marking oil", 40.0, 60.0, typeof( BlackPearl ), "Black Pearl", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 35.0, 45.0 );
			AddRes( index, typeof ( EyeOfToad ), "Eye of Toad", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( HerbalHealingPotion ), "Brews", "herbal healing elixir", 45.0, 65.0, typeof( RedLotus ), "Red Lotus", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 40.0, 50.0 );
			AddRes( index, typeof ( Garlic ), "Garlic", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( BlendWithForestPotion ), "Brews", "forest blending oil", 50.0, 70.0, typeof( SilverWidow ), "Silver Widow", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 45.0, 55.0 );
			AddRes( index, typeof ( Nightshade ), "Nightshade", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( FireflyPotion ), "Brews", "jar of fireflies", 55.0, 75.0, typeof( SpidersSilk ), "Spider Silk", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 50.0, 60.0 );
			AddRes( index, typeof ( ButterflyWings ), "Butterfly Wings", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( MushroomGatewayPotion ), "Brews", "mushroom gateway growth", 60.0, 80.0, typeof( Bloodmoss ), "Bloodmoss", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 55.0, 65.0 );
			AddRes( index, typeof ( EyeOfToad ), "Eye of Toad", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( SwarmOfInsectsPotion ), "Brews", "jar of insects", 65.0, 85.0, typeof( ButterflyWings ), "Butterfly Wings", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 60.0, 70.0 );
			AddRes( index, typeof ( BeetleShell ), "Beetle Shell", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( ProtectiveFairyPotion ), "Brews", "fairy in a jar", 70.0, 90.0, typeof( FairyEgg ), "Fairy Egg", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 65.0, 75.0 );
			AddRes( index, typeof ( MoonCrystal ), "Moon Crystal", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( TreefellowPotion ), "Brews", "treant fertilizer", 75.0, 95.0, typeof( SwampBerries ), "Swamp Berries", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 70.0, 80.0 );
			AddRes( index, typeof ( MandrakeRoot ), "Mandrake Root", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( VolcanicEruptionPotion ), "Brews", "volcanic fluid", 80.0, 110.0, typeof( Brimstone ), "Brimstone", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 75.0, 85.0 );
			AddRes( index, typeof ( SulfurousAsh ), "Sulfurous Ash", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( RestorativeSoilPotion ), "Brews", "jar of magical mud", 85.0, 120.0, typeof( Nightshade ), "Nightshade", 1, 1044129 );
			AddSkill( index, SkillName.Veterinary, 80.0, 90.0 );
			AddRes( index, typeof ( RedLotus ), "Red Lotus", 1, 1044129 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );
		}
	}
}