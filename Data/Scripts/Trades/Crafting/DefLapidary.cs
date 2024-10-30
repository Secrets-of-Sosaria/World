using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefLapidary : CraftSystem
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
            get { return "<BASEFONT Color=#FBFBFB><CENTER>LAPIDARY MENU</CENTER></BASEFONT>"; }
        }

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

		public override CraftResourceType BreakDownType
		{
			get { return CraftResourceType.Block; }
		}

		public override string CraftSystemTxt
		{
			get { return "Crafting: Lapidary"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefLapidary();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefLapidary() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !(tool.Parent == from ) )
				return 1044263; // The tool must be on your person to use.
			else if ( from.Skills[SkillName.Blacksmith].Value < 65.0 )
				return 1063800;
			else if ( !( from.Map == Map.SavagedEmpire && from.X > 1104 && from.X < 1125 && from.Y > 1960 && from.Y < 1978 ) )
				return 1044147;

			bool anvil, forge;
			CheckAnvilAndForge( from, 2, out anvil, out forge );

			if ( anvil && forge )
				return 0;

			return 1044147; // You must be near an anvil and a forge to smith items.
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
				return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			#region Chainmail
			AddCraft( typeof( ChainCoif ), "Chain/Ringmail", 1025051, 14.5, 64.5, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( ChainLegs ), "Chain/Ringmail", 1025054, 36.7, 86.7, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( ChainChest ), "Chain/Ringmail", 1025055, 39.1, 89.1, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( ChainSkirt ), "Chain/Ringmail", "chainmail skirt", 36.7, 86.7, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			#endregion

			#region Ringmail
			AddCraft( typeof( RingmailGloves ), "Chain/Ringmail", 1025099, 12.0, 62.0, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( RingmailLegs ), "Chain/Ringmail", 1025104, 19.4, 69.4, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( RingmailArms ), "Chain/Ringmail", 1025103, 16.9, 66.9, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( RingmailChest ), "Chain/Ringmail", 1025100, 21.9, 71.9, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( RingmailSkirt ), "Chain/Ringmail", "ringmail skirt", 19.4, 69.4, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			#endregion

			int index = -1;

			#region Platemail
			AddCraft( typeof( PlateArms ), "Platemail", 1025136, 66.3, 116.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( PlateGloves ), "Platemail", 1025140, 58.9, 108.9, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( PlateGorget ), "Platemail", 1025139, 56.4, 106.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( PlateLegs ), "Platemail", 1025137, 68.8, 118.8, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( PlateSkirt ), "Platemail", "platemail skirt", 68.8, 118.8, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( PlateChest ), "Platemail", 1046431, 75.0, 125.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( FemalePlateChest ), "Platemail", 1046430, 44.1, 94.1, typeof( AmethystBlocks ), 1063706, 20, 1044513 );

			AddCraft( typeof( PlateMempo ), "Platemail", 1030180, 80.0, 130.0, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( PlateDo ), "Platemail", 1030184, 80.0, 130.0, typeof( AmethystBlocks ), 1063706, 28, 1044513 );
			AddCraft( typeof( PlateHiroSode ), "Platemail", 1030187, 80.0, 130.0, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( PlateSuneate ), "Platemail", 1030195, 65.0, 115.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( PlateHaidate ), "Platemail", 1030200, 65.0, 115.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			#endregion

			#region Royal
			AddCraft( typeof( RoyalBoots ), "Royal Armor", "royal boots", 88.9, 118.9, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( RoyalGloves ), "Royal Armor", "royal bracers", 88.9, 118.9, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( RoyalGorget ), "Royal Armor", "royal gorget", 86.4, 116.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( RoyalHelm ), "Royal Armor", "royal helm", 92.6, 122.6, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( RoyalsLegs ), "Royal Armor", "royal leggings", 96.8, 125.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( RoyalArms ), "Royal Armor", "royal mantle", 96.3, 125.0, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( RoyalChest ), "Royal Armor", "royal tunic", 98.0, 125.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			#endregion

			#region Helmets
			AddCraft( typeof( Bascinet ), "Helmets", 1025132, 8.3, 58.3, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( CloseHelm ), "Helmets", 1025128, 37.9, 87.9, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( Helmet ), "Helmets", 1025130, 37.9, 87.9, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( NorseHelm ), "Helmets", 1025134, 37.9, 87.9, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( PlateHelm ), "Helmets", 1025138, 62.6, 112.6, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( DreadHelm ), "Helmets", "dread helm", 62.6, 112.6, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( ChainHatsuburi ), "Helmets", 1030175, 30.0, 80.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( PlateHatsuburi ), "Helmets", 1030176, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( HeavyPlateJingasa ), "Helmets", 1030178, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( LightPlateJingasa ), "Helmets", 1030188, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( SmallPlateJingasa ), "Helmets", 1030191, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( DecorativePlateKabuto ), "Helmets", 1030179, 90.0, 140.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( PlateBattleKabuto ), "Helmets", 1030192, 90.0, 140.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( StandardPlateKabuto ), "Helmets", 1030196, 90.0, 140.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			#endregion

			#region Shields
			AddCraft( typeof( Buckler ), "Shields", 1027027, -25.0, 25.0, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( BronzeShield ), "Shields", "large shield", -15.2, 34.8, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( WoodenKiteShield ), "Shields", 1027032, -15.2, 34.8, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( MetalShield ), "Shields", 1027035, -10.2, 39.8, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( MetalKiteShield ), "Shields", 1027028, 4.6, 54.6, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( HeaterShield ), "Shields", 1027030, 24.3, 74.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( ChampionShield ), "Shields", "champion shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( CrestedShield ), "Shields", "crested shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( DarkShield ), "Shields", "dark shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( ElvenShield ), "Shields", "elven shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( GuardsmanShield ), "Shields", "guardsman shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			index = AddCraft( typeof( JeweledShield ), "Shields", "jeweled shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
				AddRes( index, typeof( StarSapphire ), 1023855, 1, 1044513 );
			AddCraft( typeof( RoyalShield ), "Shields", "royal shield", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( ChaosShield ), "Shields", "chaos shield", 85.0, 135.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( OrderShield ), "Shields", "order shield", 85.0, 135.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( SunShield ), "Shields", "sun shield", 85.0, 135.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( VirtueShield ), "Shields", "virtue shield", 85.0, 135.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			#endregion

			#region Bladed
			AddCraft( typeof( AssassinSpike ), "Bladed", "assassin dagger", 10.0, 49.6, typeof( AmethystBlocks ), 1063706, 3, 1044513 );
			AddCraft( typeof( ElvenSpellblade ), "Bladed", "assassin sword", 44.1, 94.1, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( VikingSword ), "Bladed", "barbarian sword", 24.3, 74.3, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( Broadsword ), "Bladed", 1023934, 35.4, 85.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( Claymore ), "Bladed", "claymore", 34.3, 84.3, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( CrescentBlade ), "Bladed", 1029921, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( Cutlass ), "Bladed", 1025185, 24.3, 74.3, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( Dagger ), "Bladed", 1023921, -0.4, 49.6, typeof( AmethystBlocks ), 1063706, 3, 1044513 );
			AddCraft( typeof( RadiantScimitar ), "Bladed", "falchion", 35.4, 85.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( Katana ),"Bladed", 1025119, 44.1, 94.1, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( Kryss ), "Bladed", 1025121, 36.7, 86.7, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( LargeKnife ), "Bladed", "large knife", -0.4, 49.6, typeof( AmethystBlocks ), 1063706, 3, 1044513 );
			AddCraft( typeof( Longsword ), "Bladed", 1023937, 28.0, 78.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( ElvenMachete ), "Bladed", "machete", 33.0, 83.0, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( ShortSpear ), "Bladed", "rapier", 45.3, 95.3, typeof( AmethystBlocks ), 1063706, 6, 1044513 );
			AddCraft( typeof( RoyalSword ), "Bladed", "royal sword", 54.3, 84.3, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( ShortSword ), "Bladed", "short sword", 33.0, 83.0, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( BoneHarvester ), "Bladed", "sickle", 33.0, 83.0, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( Scimitar ), "Bladed", 1025046, 31.7, 81.7, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( RuneBlade ), "Bladed", "war blades", 28.0, 78.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( WarCleaver ), "Bladed", "war cleaver", 10.0, 49.6, typeof( AmethystBlocks ), 1063706, 3, 1044513 );
			AddCraft( typeof( Leafblade ), "Bladed", "war dagger", 20.0, 59.6, typeof( AmethystBlocks ), 1063706, 5, 1044513 );
			AddCraft( typeof( NoDachi ), "Bladed", 1030221, 75.0, 125.0, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( Wakizashi ), "Bladed", 1030223, 50.0, 100.0, typeof( AmethystBlocks ), 1063706, 8, 1044513 );
			AddCraft( typeof( Lajatang ), "Bladed", 1030226, 80.0, 130.0, typeof( AmethystBlocks ), 1063706, 25, 1044513 );
			AddCraft( typeof( Daisho ), "Bladed", 1030228, 60.0, 110.0, typeof( AmethystBlocks ), 1063706, 15, 1044513 );
			AddCraft( typeof( Tekagi ), "Bladed", 1030230, 55.0, 105.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( Shuriken ), "Bladed", 1030231, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 5, 1044513 );
			AddCraft( typeof( Kama ), "Bladed", 1030232, 40.0, 90.0, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( Sai ), "Bladed", 1030234, 50.0, 100.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			#endregion

			#region Axes
			AddCraft( typeof( Axe ), "Axes", 1023913, 34.2, 84.2, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( BattleAxe ), "Axes", 1023911, 30.5, 80.5, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( DoubleAxe ), "Axes", 1023915, 29.3, 79.3, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( ExecutionersAxe ), "Axes", "executioner axe", 34.2, 84.2, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( LargeBattleAxe ), "Axes", 1025115, 28.0, 78.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( TwoHandedAxe ), "Axes", 1025187, 33.0, 83.0, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( WarAxe ), "Axes", 1025040, 39.1, 89.1, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( OrnateAxe ), "Axes", "barbarian axe", 24.3, 74.3, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			#endregion

			#region Pole Arms
			AddCraft( typeof( Bardiche ), "Polearms", 1023917, 31.7, 81.7, typeof( AmethystBlocks ), 1063706, 18, 1044513 );
			AddCraft( typeof( BladedStaff ), "Polearms", 1029917, 40.0, 90.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( DoubleBladedStaff ), "Polearms", 1029919, 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( Halberd ), "Polearms", 1025183, 39.1, 89.1, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( Harpoon ), "Polearms", "harpoon", 30.0, 70.0, typeof( AmethystBlocks ), 1015101, 12, 1044351 );
			AddCraft( typeof( Lance ), "Polearms", 1029920, 48.0, 98.0, typeof( AmethystBlocks ), 1063706, 20, 1044513 );
			AddCraft( typeof( Pike ), "Polearms", 1029918, 47.0, 97.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( Pitchforks ), "Polearms", "pitchfork", 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( Scythe ), "Polearms", 1029914, 39.0, 89.0, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( Spear ), "Polearms", 1023938, 49.0, 99.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( Pitchfork ), "Polearms", "trident", 45.0, 95.0, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			AddCraft( typeof( WarFork ), "Polearms", 1025125, 42.9, 92.9, typeof( AmethystBlocks ), 1063706, 12, 1044513 );
			#endregion

			#region Bashing
			AddCraft( typeof( DiamondMace ), "Bashing", "battle mace", 28.0, 78.0, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( Hammers ), "Bashing", "hammer", 14.5, 64.5, typeof( AmethystBlocks ), 1063706, 6, 1044513 );
			AddCraft( typeof( HammerPick ), "Bashing", 1025181, 34.2, 84.2, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			AddCraft( typeof( Mace ), "Bashing", 1023932, 14.5, 64.5, typeof( AmethystBlocks ), 1063706, 6, 1044513 );
			AddCraft( typeof( Maul ), "Bashing", 1025179, 19.4, 69.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( Scepter ), "Bashing", 1029916, 21.4, 71.4, typeof( AmethystBlocks ), 1063706, 10, 1044513 );
			AddCraft( typeof( SpikedClub ), "Bashing", "spiked mace", 14.5, 64.5, typeof( AmethystBlocks ), 1063706, 6, 1044513 );
			AddCraft( typeof( WarMace ), "Bashing", 1025127, 28.0, 78.0, typeof( AmethystBlocks ), 1063706, 14, 1044513 );
			AddCraft( typeof( WarHammer ), "Bashing", 1025177, 34.2, 84.2, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
			index = AddCraft( typeof( Tessen ), "Bashing", 1030222, 85.0, 135.0, typeof( AmethystBlocks ), 1063706, 16, 1044513 );
				AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
				AddRes( index, typeof( Fabric ), 1044286, 10, 1044287 );

			#endregion
			
			// Set the overridable material
			SetSubRes( typeof( AmethystBlocks ), CraftResources.GetClilocCraftName( CraftResource.AmethystBlock ) );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material

			int cannot = 1079599; // You have no idea how to work this gemstone.

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( AmethystBlocks ),	CraftResources.GetClilocCraftName( CraftResource.AmethystBlock ), CraftResources.GetSkill( CraftResource.AmethystBlock ), CraftResources.GetClilocMaterialName( CraftResource.AmethystBlock ), cannot );
			AddSubRes( typeof( EmeraldBlocks ),		CraftResources.GetClilocCraftName( CraftResource.EmeraldBlock ), CraftResources.GetSkill( CraftResource.EmeraldBlock ), CraftResources.GetClilocMaterialName( CraftResource.EmeraldBlock ), cannot );
			AddSubRes( typeof( GarnetBlocks ),		CraftResources.GetClilocCraftName( CraftResource.GarnetBlock ), CraftResources.GetSkill( CraftResource.GarnetBlock ), CraftResources.GetClilocMaterialName( CraftResource.GarnetBlock ), cannot );
			AddSubRes( typeof( IceBlocks ),			CraftResources.GetClilocCraftName( CraftResource.IceBlock ), CraftResources.GetSkill( CraftResource.IceBlock ), CraftResources.GetClilocMaterialName( CraftResource.IceBlock ), cannot );
			AddSubRes( typeof( JadeBlocks ),		CraftResources.GetClilocCraftName( CraftResource.JadeBlock ), CraftResources.GetSkill( CraftResource.JadeBlock ), CraftResources.GetClilocMaterialName( CraftResource.JadeBlock ), cannot );
			AddSubRes( typeof( MarbleBlocks ),		CraftResources.GetClilocCraftName( CraftResource.MarbleBlock ), CraftResources.GetSkill( CraftResource.MarbleBlock ), CraftResources.GetClilocMaterialName( CraftResource.MarbleBlock ), cannot );
			AddSubRes( typeof( OnyxBlocks ),		CraftResources.GetClilocCraftName( CraftResource.OnyxBlock ), CraftResources.GetSkill( CraftResource.OnyxBlock ), CraftResources.GetClilocMaterialName( CraftResource.OnyxBlock ), cannot );
			AddSubRes( typeof( QuartzBlocks ),		CraftResources.GetClilocCraftName( CraftResource.QuartzBlock ), CraftResources.GetSkill( CraftResource.QuartzBlock ), CraftResources.GetClilocMaterialName( CraftResource.QuartzBlock ), cannot );
			AddSubRes( typeof( RubyBlocks ),		CraftResources.GetClilocCraftName( CraftResource.RubyBlock ), CraftResources.GetSkill( CraftResource.RubyBlock ), CraftResources.GetClilocMaterialName( CraftResource.RubyBlock ), cannot );
			AddSubRes( typeof( SapphireBlocks ),	CraftResources.GetClilocCraftName( CraftResource.SapphireBlock ), CraftResources.GetSkill( CraftResource.SapphireBlock ), CraftResources.GetClilocMaterialName( CraftResource.SapphireBlock ), cannot );
			AddSubRes( typeof( SilverBlocks ),		CraftResources.GetClilocCraftName( CraftResource.SilverBlock ), CraftResources.GetSkill( CraftResource.SilverBlock ), CraftResources.GetClilocMaterialName( CraftResource.SilverBlock ), cannot );
			AddSubRes( typeof( SpinelBlocks ),		CraftResources.GetClilocCraftName( CraftResource.SpinelBlock ), CraftResources.GetSkill( CraftResource.SpinelBlock ), CraftResources.GetClilocMaterialName( CraftResource.SpinelBlock ), cannot );
			AddSubRes( typeof( StarRubyBlocks ),	CraftResources.GetClilocCraftName( CraftResource.StarRubyBlock ), CraftResources.GetSkill( CraftResource.StarRubyBlock ), CraftResources.GetClilocMaterialName( CraftResource.StarRubyBlock ), cannot );
			AddSubRes( typeof( TopazBlocks ),		CraftResources.GetClilocCraftName( CraftResource.TopazBlock ), CraftResources.GetSkill( CraftResource.TopazBlock ), CraftResources.GetClilocMaterialName( CraftResource.TopazBlock ), cannot );
			AddSubRes( typeof( CaddelliteBlocks ),	CraftResources.GetClilocCraftName( CraftResource.CaddelliteBlock ), CraftResources.GetSkill( CraftResource.CaddelliteBlock ), CraftResources.GetClilocMaterialName( CraftResource.CaddelliteBlock ), cannot );

			BreakDown = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}