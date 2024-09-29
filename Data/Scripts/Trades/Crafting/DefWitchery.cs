using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefWitchery : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Forensics; }
		}

        public override int GumpImage
        {
            get { return 9598; }
        }

		public override int GumpTitleNumber
		{
			get { return 1044000; } // <CENTER>WITCH BREWING MENU</CENTER>
		}

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override string CraftSystemTxt
		{
			get { return "Crafting: Witch Brewing"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWitchery();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefWitchery() : base( 1, 1, 1.25 )
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

			index = AddCraft( typeof( UndeadEyesScroll ), "Brews", "eyes of the dead mixture", 10.0, 30.0, typeof( MummyWrap ), "Mummy Wrap", 1, 1044129 );
			AddRes( index, typeof ( EyeOfToad ), "Eye of Toad", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 5.0, 15.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( NecroUnlockScroll ), "Brews", "tomb raiding concoction", 15.0, 40.0, typeof( Maggot ), "Maggot", 1, 1044129 );
			AddRes( index, typeof ( BeetleShell ), "Beetle Shell", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 10.0, 20.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( NecroPoisonScroll ), "Brews", "disease draught", 20.0, 45.0, typeof( VioletFungus ), "Violet Fungus", 1, 1044129 );
			AddRes( index, typeof ( NoxCrystal ), "Nox Crystal", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 15.0, 25.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( PhantasmScroll ), "Brews", "phantasm elixir", 25.0, 50.0, typeof( DriedToad ), "Dried Toad", 1, 1044129 );
			AddRes( index, typeof ( GargoyleEar ), "Gargoyle Ear", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 20.0, 30.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( RetchedAirScroll ), "Brews", "retched air elixir", 30.0, 55.0, typeof( BlackSand ), "Black Sand", 1, 1044129 );
			AddRes( index, typeof ( GraveDust ), "Grave Dust", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 25.0, 35.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( ManaLeechScroll ), "Brews", "lich leech mixture", 35.0, 60.0, typeof( DriedToad ), "Dried Toad", 1, 1044129 );
			AddRes( index, typeof ( RedLotus ), "Red Lotus", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 30.0, 40.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( WallOfSpikesScroll ), "Brews", "wall of spikes draught", 40.0, 65.0, typeof( BitterRoot ), "Bitter Root", 1, 1044129 );
			AddRes( index, typeof ( PigIron ), "Pig Iron", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 35.0, 45.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( NecroCurePoisonScroll ), "Brews", "disease curing concoction", 45.0, 70.0, typeof( Wolfsbane ), "Wolfsbane", 1, 1044129 );
			AddRes( index, typeof ( SwampBerries ), "Swamp Berries", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 40.0, 50.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( BloodPactScroll ), "Brews", "blood pact elixir", 50.0, 75.0, typeof( BloodRose ), "Blood Rose", 1, 1044129 );
			AddRes( index, typeof ( DaemonBlood ), "Daemon Blood", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 45.0, 55.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( SpectreShadowScroll ), "Brews", "spectre shadow elixir", 55.0, 80.0, typeof( VioletFungus ), "Violet Fungus", 1, 1044129 );
			AddRes( index, typeof ( SilverWidow ), "Silver Widow", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 50.0, 60.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( GhostPhaseScroll ), "Brews", "ghost phase concoction", 60.0, 85.0, typeof( BitterRoot ), "Bitter Root", 1, 1044129 );
			AddRes( index, typeof ( MoonCrystal ), "Moon Crystal", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 55.0, 65.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( HellsGateScroll ), "Brews", "demonic fire ooze", 65.0, 90.0, typeof( Maggot ), "Maggot", 1, 1044129 );
			AddRes( index, typeof ( BlackPearl ), "Black Pearl", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 60.0, 70.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( GhostlyImagesScroll ), "Brews", "ghostly images draught", 70.0, 95.0, typeof( MummyWrap ), "Mummy Wrap", 1, 1044129 );
			AddRes( index, typeof ( Bloodmoss ), "Bloodmoss", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 65.0, 75.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( HellsBrandScroll ), "Brews", "hellish branding ooze", 75.0, 100.0, typeof( WerewolfClaw ), "Werewolf Claw", 1, 1044129 );
			AddRes( index, typeof ( Brimstone ), "Brimstone", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 70.0, 80.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( GraveyardGatewayScroll ), "Brews", "black gate draught", 80.0, 105.0, typeof( BlackSand ), "Black Sand", 1, 1044129 );
			AddRes( index, typeof( Wolfsbane ), "Wolfsbane", 1, 1044129 );
			AddRes( index, typeof ( PixieSkull ), "Pixie Skull", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 75.0, 85.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );

			index = AddCraft( typeof( VampireGiftScroll ), "Brews", "vampire blood draught", 85.0, 120.0, typeof( WerewolfClaw ), "Werewolf Claw", 1, 1044129 );
			AddRes( index, typeof ( BatWing ), "Bat Wing", 1, 1044129 );
			AddRes( index, typeof( BloodRose ), "Blood Rose", 1, 1044129 );
			AddSkill( index, SkillName.Necromancy, 80.0, 90.0 );
			AddRes( index, typeof ( Jar ), 1044128, 1, 1044130 );
		}
	}
}