using System;
using Server;
using System.Collections.Generic;
using System.Collections;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using System.Reflection;
using System.Text;
using Server.Regions;
using Server.Misc;

namespace Server.Misc
{
    class ContainerFunctions
    {
		public static int LockTheContainer( int level, LockableContainer box, int nContainerLockable )
		{
			if ( level > 0 )
			{
				switch ( Utility.Random( 9 ) )
				{
					case 0: box.TrapType = TrapType.DartTrap; break;
					case 1: box.TrapType = TrapType.None; break;
					case 2: box.TrapType = TrapType.ExplosionTrap; break;
					case 3: box.TrapType = TrapType.MagicTrap; break;
					case 4: box.TrapType = TrapType.PoisonTrap; break;
					case 5: box.TrapType = TrapType.None; break;
					case 6: box.TrapType = TrapType.None; break;
					case 7: box.TrapType = TrapType.None; break;
					case 8: box.TrapType = TrapType.None; break;
				}

				if ( box is TreasureMapChest ){ box.TrapType = TrapType.ExplosionTrap; }

				if ( box.Catalog == Catalogs.SciFi && box.TrapType != TrapType.None ){ box.TrapType = TrapType.ExplosionTrap; }

				if ( box is ParagonChest )
				{
					switch ( Utility.Random( 4 ) )
					{
						case 0: box.TrapType = TrapType.DartTrap; break;
						case 1: box.TrapType = TrapType.ExplosionTrap; break;
						case 2: box.TrapType = TrapType.MagicTrap; break;
						case 3: box.TrapType = TrapType.PoisonTrap; break;
					}
				}

				box.TrapPower = (level * Utility.RandomMinMax( 20, 30 )) + Utility.RandomMinMax( 1, 10 );
				box.TrapLevel = level;
					if ( box.TrapLevel > 90 ){ box.TrapLevel = 90; }
					if ( box.TrapLevel < 0 ){ box.TrapLevel = 0; }
			}

			int LockWatch = 0;
				if ( nContainerLockable < 7 || nContainerLockable == 16 || nContainerLockable == 18 ){ LockWatch = 1; }
				else { box.Locked = false; box.LockLevel = 0; box.MaxLockLevel = 0; box.RequiredSkill = 0; }

			if ( LockWatch > 0 )
			{
				box.Locked = false;
				switch( Utility.Random( 3 ) )
				{
					case 0: box.Locked = true; break;
				}
				if ( box is TreasureMapChest || box is ParagonChest ){ box.Locked = true; }

				box.LockLevel = 1+(level * 10);
					if ( box.LockLevel > 90 ){ box.LockLevel = 90; }
					if ( box.LockLevel < 0 ){ box.LockLevel = 0; }
				box.MaxLockLevel = box.LockLevel + 20;
				box.RequiredSkill = box.LockLevel;
			}
			else { box.Locked = false; box.LockLevel = 0; box.MaxLockLevel = 0; box.RequiredSkill = 0; }

			return LockWatch;
		}

		public static void FillTheContainer( int level, LockableContainer box, Mobile opener )
		{
			level = LootPackChange.ScaleLevel( level );
			LootPackChange.AddGoldToContainer( 0, box, opener, level );
			GenerateTreasure( level, box, opener );
		}

		public static void GenerateTreasure( int level, LockableContainer box, Mobile from )
		{
			if ( from.Land == Land.SkaraBrae && Utility.Random( 20 ) == 0 )
			{
				Item note = new BardsTaleNote();
				box.DropItem( note );
			}

			int var = 1;
			int fill = level + Utility.Random(3);

			for ( int i = 0; i < LootPackChange.FillCycle( fill ); ++i )
			{
				var = level - 4;
					if ( var < 1 )
						var = 1;

				switch( Utility.RandomMinMax( var, level ) )
				{
					case 1: AddTreasure( level, box, from, LootPack.TreasurePoor ); break;
					case 2: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasurePoor ); } else { AddTreasure( level, box, from, LootPack.TreasureMeager ); } break;
					case 3: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasureMeager ); } else { AddTreasure( level, box, from, LootPack.TreasureAverage ); } break;
					case 4: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasureRich ); } else { AddTreasure( level, box, from, LootPack.TreasureAverage ); } break;
					case 5: AddTreasure( level, box, from, LootPack.TreasureRich ); break;
					case 6: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasureRich ); } else { AddTreasure( level, box, from, LootPack.TreasureFilthyRich ); } break;
					case 7: AddTreasure( level, box, from, LootPack.TreasureFilthyRich ); break;
					case 8: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasureFilthyRich ); } else { AddTreasure( level, box, from, LootPack.TreasureUltraRich ); } break;
					case 9: AddTreasure( level, box, from, LootPack.TreasureUltraRich );	break;
					case 10: if ( Utility.RandomBool() ){ AddTreasure( level, box, from, LootPack.TreasureUltraRich ); } else { AddTreasure( level, box, from, LootPack.TreasureMegaRich ); } break;
					case 11: AddTreasure( level, box, from, LootPack.TreasureMegaRich );	break;
					case 12: AddTreasure( level, box, from, LootPack.TreasureMegaRich );	break;
				}
			}
		}

		public static void AddTreasure( int level, LockableContainer box, Mobile from, LootPack pack )
		{
			pack.Generate( from, box, false, from.Luck, level );

			if ( box is TreasureMapChest || box is GraveChest || box is ParagonChest || box is SunkenChest || box is BuriedChest || box is BuriedBody ){} else
			{
				int c = level;

				while ( c > 0 )
				{
					c--;

					if ( Utility.Random(4) == 0 && MySettings.S_LootChance > Utility.Random(100) )
					{
						Item regular = Loot.RandomItem( from, level );
						regular = LootPackChange.ChangeItem( regular, from, level );
						box.DropItem( regular );
						LootPackChange.RemoveItem( regular, from, level );
					}
				}
			}
			if ( Utility.Random(24) < level && MySettings.S_LootChance > Utility.Random(100) )
			{
				Item treasure = Loot.RandomTreasure( from, level );
				treasure = LootPackChange.ChangeItem( treasure, from, level );
				box.DropItem( treasure );
				LootPackChange.RemoveItem( treasure, from, level );
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static int BuildContainer( LockableContainer box, int thisHue, int thisItem, int thisGump, int thisDesign )
		{
			///// DECIDE ON THE APPEARANCE OF THE CONTAINERS /////
			int myBox = Utility.RandomMinMax( 1, 11 );
				if ( thisItem > 0 ){ myBox = thisItem; }
			if ( box.Locked == true ){ myBox = Utility.RandomMinMax( 1, 6 ); }

			if ( thisDesign == 2 ){ myBox = Utility.RandomList( 9, 10, 11, 12 ); }
			else if ( thisDesign == 4 ){ myBox = 12; }
			else if ( thisDesign == 5 ){ myBox = Utility.RandomList( 9, 10, 11 ); }
			else if ( thisDesign == 6 ){ myBox = Utility.RandomList( 2, 2, 6 ); }
			else if ( thisDesign == 7 ){ myBox = Utility.RandomList( 2, 6, 12, 13 ); }
			else if ( thisDesign == 8 ){ myBox = Utility.RandomList( 2, 6, 13, 14 ); }
			else if ( thisDesign == 9 ){ myBox = 14; }
			else if ( thisDesign == 10 ){ myBox = 15; } // LOST BOATS
			else if ( thisDesign == 11 ){ myBox = Utility.RandomList( 1, 2, 13, 16 ); } // SEA DUNGEONS
			else if ( thisDesign == 12 ){ myBox = Utility.RandomList( 1, 2, 7, 8, 12 ); } // HALL OF THE MOUNTAIN KING
			else if ( thisDesign == 13 ){ myBox = Utility.RandomList( 17, 18, 18, 18 ); box.Catalog = Catalogs.SciFi; } // ALIEN SPACE SHIP
			else if ( thisDesign == 14 ){ myBox = 18; box.Catalog = Catalogs.SciFi; } // ALIEN SPACE SHIP - CRATES ONLY
			else if ( thisDesign == 15 ){ myBox = Utility.RandomList( 1, 2, 12, 16 ); } // DESTARD
			else if ( thisDesign == 16 ){ myBox = Utility.RandomList( 2, 6, 13, 13, 16 ); } // ROCK DUNGEON

			int nContainerLockable = 0;

			if ( myBox == 1 )
			{
				nContainerLockable = 1;
				box.Weight = 10.0;
				box.ItemID = Utility.RandomList( 0xe42, 0xe43 );	box.GumpID = 0x49;		box.Name = "Wooden Chest";		box.Hue = 0x724;
					if ( Utility.RandomMinMax(1,20) == 1 ){ box.ItemID = Utility.RandomList( 0x5718, 0x5719, 0x571A, 0x571B, 0x5752, 0x5753 ); }
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
				if ( thisDesign == 3 ){ box.ItemID = Utility.RandomList( 0x10EC, 0x10ED );	box.GumpID = 0x976;		box.Name = "Rusty Metal Crate";		box.Hue = 0; }
			}
			else if ( myBox == 2 )
			{
				nContainerLockable = 2;
				box.Weight = 20.0;
				box.ItemID = Utility.RandomList( 0xE40, 0xE41, 0x4FE1, 0x4FE2 );	box.GumpID = 0x4A;		box.Name = "Iron Chest";
				ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, null );
				if ( thisDesign == 3 ){ box.ItemID = Utility.RandomList( 0x10EA, 0x10EB );	box.GumpID = 0x976;		box.Name = "Metal Crate";		box.Hue = 0; }
			}
			else if ( myBox == 3 )
			{
				nContainerLockable = 3;
				box.Weight = 12.0;
				box.ItemID = Utility.RandomList( 0x2811, 0x2812 );	box.GumpID = 0x10C;	box.Name = "Wooden Footlocker";
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
			}
			else if ( myBox == 4 )
			{
				nContainerLockable = 4;
				box.Weight = 15.0;
				box.ItemID = Utility.RandomList( 0x2813, 0x2814 );	box.GumpID = 0x10D;	box.Name = "Wooden Trunk";
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
			}
			else if ( myBox == 5 )
			{
				nContainerLockable = 5;
				box.Locked = false;
				string boxy = "Box";
				box.ItemID = Utility.RandomList( 0x9AA, 0xE7D, 0x4C2B, 0x4C2C, 0x1C0E, 0x1C0F );

				if ( box.ItemID == 0x4C2B || box.ItemID == 0x4C2C ){ boxy = "Chest"; }
				else if ( box.ItemID == 0x1C0E || box.ItemID == 0x1C0F ){ boxy = "Coffer"; }

				box.GumpID = 0x43;		box.Name = "Wooden " + boxy;			box.Hue = 0x83E;

				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );

				if ( box.ItemID == 0x4C2B || box.ItemID == 0x4C2C || box.ItemID == 0x1C0E || box.ItemID == 0x1C0F ){ box.GumpID = 0x49; }
			}
			else if ( myBox == 6 )
			{
				nContainerLockable = 6;
				box.Weight = 10.0;
				box.ItemID = Utility.RandomList( 0x9A8, 0xE80 );	box.GumpID = 0x4B;		box.Name = "Metal Box";			box.Hue = 0x835;
				ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, null );
			}
			else if ( myBox == 7 )
			{
				nContainerLockable = 7;
				box.Weight = 2.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0xE76, 0xE76, 0xE76, 0xE76, 0x1E3F, 0x1E52, 0x1248, 0x1264, 0x5777, 0x5776 );
				box.Name = "Bag";
				box.Hue = Utility.RandomMinMax( 2401, 2430 );
				box.GumpID = 0x3D;

				if ( box.ItemID == 0x1E3F || box.ItemID == 0x1E52 ){ box.Name = "Sack"; }
				else if ( box.ItemID == 0x1248 || box.ItemID == 0x1264 || box.ItemID == 0x5777 || box.ItemID == 0x5776 ){ box.Name = "Sack"; }

				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularLeather, false, null );
			}
			else if ( myBox == 8 )
			{
				nContainerLockable = 8;
				box.Weight = 3.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0xE75, 0x53D5, 0x27BE, 0x27D7, 0x4C53, 0x4C54, 0x1C10, 0x1CC6 );
				box.GumpID = 0x3C;
				box.Name = "Backpack";
				box.Hue = Utility.RandomMinMax( 2401, 2430 );

				if ( box.ItemID == 0x27BE || box.ItemID == 0x27D7 ){ box.Name = "Satchel"; }
				else if ( box.ItemID == 0x4C53 || box.ItemID == 0x4C54 ){ box.Name = "Satchel"; }
				else if ( box.ItemID == 0x1C10 || box.ItemID == 0x1CC6 ){ box.Name = "Backpack"; }

				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularLeather, false, null );
			}
			else if ( myBox == 9 )
			{
				nContainerLockable = 9;
				box.Weight = 10.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0xE3D, 0xE3C );	box.GumpID = 0x44;		box.Name = "Wooden Crate";			box.Hue = Utility.RandomMinMax( 2413, 2430 );
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
			}
			else if ( myBox == 10 )
			{
				nContainerLockable = 10;
				box.Weight = 8.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0xE3F, 0xE3E );	box.GumpID = 0x44;		box.Name = "Wooden Crate";			box.Hue = Utility.RandomMinMax( 2413, 2430 );
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
            }
			else if ( myBox == 11 )
			{
				nContainerLockable = 11;
				box.Weight = 25.0;
				box.Locked = false;
				box.ItemID = 0xFAE;	box.GumpID = 0x3E;		box.Name = "Barrel";
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
            }
			else if ( myBox == 12 )
			{
				nContainerLockable = 12;
				thisHue = 0;
				box.Weight = 25.0;
				box.Locked = false;
				box.ItemID = Utility.RandomMinMax( 19290, 19371 );
					if ( box.ItemID > 19357 ){ box.Hue = Utility.RandomColor( 0 ); }
				box.GumpID = 0x3C;
				box.Name = GetOwner( "Corpse" );
				box.Resource = CraftResource.BrittleSkeletal;
            }
			else if ( myBox == 13 )
			{
				nContainerLockable = 13;
				box.Weight = 20.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0x1AFC, 0x1AFD, 0x1AFE, 0x1AFF, 0x398B, 0x39A2, 0x4B59, 0x4C2A );
				box.GumpID = 0x13B1;

				switch( Utility.Random( 2 ) )
				{
					case 0:		box.Name = "Urn";	break;
					case 1:		box.Name = "Vase";	break;
				}
				ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, null );
				box.Catalog = Catalogs.Stone;
            }
			else if ( myBox == 14 )
			{
				nContainerLockable = 14;
				box.Locked = false;

				if ( Utility.Random( 4 ) == 1 )
				{
					box.Weight = 100.0;
					box.ItemID = Utility.RandomList( 0x27E0, 0x280A, 0x2802, 0x2803 );
					box.GumpID = 0x1D;
					box.Name = "Sarcophagus";
					ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, null );
					box.Catalog = Catalogs.Stone;
				}
				else
				{
					box.Weight = 25.0;
					box.ItemID = Utility.RandomList( 0x2800, 0x2801, 0x27E9, 0x27EA );
					box.GumpID = 0x41D;

					string coffin = "Coffin";
						if ( box.ItemID == 0x27E9 || box.ItemID == 0x27EA ){ coffin = "Casket"; }

					box.Name = coffin;
					ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, null );
				}
            }
			else if ( myBox == 15 )
			{
				nContainerLockable = 15;
				box.Weight = 100.0;
				box.Locked = false;
				box.Movable = false;
				box.ItemID = Utility.RandomList( 0x2299, 0x229A, 0x229B, 0x229C, 0x229D, 0x229E, 0x229F, 0x22A0 );
				box.GumpID = 0x4C;

				box.Name = "Boat";
				box.Resource = CraftResource.RegularWood;
				switch( Utility.Random( 6 ) )
				{
					case 0:		/* Plain */		break;
					case 1:		box.Name = "Abandoned " + box.Name;		break;
					case 2:		box.Name = "Deserted " + box.Name;		break;
					case 3:		box.Name = "Discarded " + box.Name;		break;
					case 4:		box.Name = "Lost " + box.Name;			break;
					case 5:		box.Name = "Adrift " + box.Name;		break;
				}
            }
			else if ( myBox == 16 )
			{
				nContainerLockable = 16;
				box.Weight = 10.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0x281D, 0x281E );	box.GumpID = 0x2810;		box.Name = "Stone Coffer";			box.Hue = 0;
				switch( Utility.Random( 6 ) )
				{
					case 0:		box.ItemID = Utility.RandomList( 0x281D, 0x281E );	box.Name = "Stone Coffer";				break;
					case 1:		box.ItemID = Utility.RandomList( 0x281F, 0x2820 );	box.Name = "Stone Chest";				break;
					case 2:		box.ItemID = Utility.RandomList( 0x2821, 0x2822 );	box.Name = "Stone Chest";				break;
					case 3:		box.ItemID = Utility.RandomList( 0x2825, 0x2826 );	box.Name = "Stone Strongbox";			break;
					case 4:		box.ItemID = Utility.RandomList( 0x2823, 0x2824 );	box.Name = "Stone Chest";				break;
					case 5:		box.ItemID = Utility.RandomList( 0x4FE6, 0x4FE7 );	box.Name = "Stone Chest";				break;
				}
				ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, null );
				box.Catalog = Catalogs.Stone;
			}
			else if ( myBox == 17 )
			{
				nContainerLockable = 17;
				thisHue = 0;
				box.Weight = 25.0;
				box.Locked = false;
				box.ItemID = Utility.RandomList( 0x3564, 0x3565, 0x3582, 0x3583, 0x35AD, 0x3868 );
				box.GumpID = 0x3C;
				box.Name = GetOwner( "Corpse" );

				string body = "corpse";
				box.Resource = CraftResource.BrittleSkeletal;
				switch( Utility.Random( 7 ) )
				{
					case 1: body = "remains"; break;
					case 2: body = "body"; break;
					case 3: body = "carcass"; break;
					case 4: body = "cadaver"; break;
					case 5: body = "corpse"; break;
					case 6: body = "body"; break;
				}

				if ( box.ItemID == 0x3564 || box.ItemID == 0x3565 )
				{ 
					box.GumpID = 0x976;
					string broke = "broken";
					switch( Utility.Random( 10 ) )
					{
						case 1: broke = "busted"; break;
						case 2: broke = "crippled"; break;
						case 3: broke = "crumbled"; break;
						case 4: broke = "crushed"; break;
						case 5: broke = "damaged"; break;
						case 6: broke = "defective"; break;
						case 7: broke = "demolished"; break;
						case 8: broke = "mangled"; break;
						case 9: broke = "smashed"; break;
					}

					box.Name = broke + " " + Server.Misc.RandomThings.GetRandomRobot(0);
					box.Resource = CraftResource.Iron;
				}
				else if ( box.ItemID == 0x3582 || box.ItemID == 0x3583 )
				{
					box.Name = "alien " + body;
					box.Resource = ResourceMods.SciFiResource( CraftResource.BrittleSkeletal );
					box.Hue = 0;
				}
				else
				{
					box.Name = "mutant " + body;
					box.Resource = ResourceMods.SciFiResource( CraftResource.BrittleSkeletal );
					box.Hue = 0;
				}
            }
			else
			{
				nContainerLockable = 18;
				box.Weight = 10.0;
				box.ItemID = Utility.RandomList( 0x10EA, 0x10EB, 0x10EC, 0x10ED );
				box.Resource = ResourceMods.SciFiResource( CraftResource.Iron );
				box.GumpID = 0x976;
				box.Name = "Cargo Container";
			}

			if ( thisHue > 0 ){ box.Hue = thisHue; }
			if ( thisGump > 0 ){ box.GumpID = thisGump; }

			if ( thisDesign == 1 )
			{
				box.Hue = Utility.RandomList( 0x47E, 0x47F, 0x481, 0x482, 0x48D, 0x9C2 );
			}
			else if ( thisDesign == 6 )
			{
				box.Hue = Utility.RandomOrangeHue();
			}

			return nContainerLockable;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetOwner( string box )
		{
			string sName0 = "";
			string sName1 = "";
			string sName2 = "";
			string sName3 = "";
			string pName3 = "";

			int nGender = Utility.RandomMinMax( 1, 2 );
			int nNameSection = 0;

			if ( nGender == 1 )
			{
				// MALE TITLES
				sName0 = NameList.RandomName( "men_titles" );

				// MALE NAMES
				if (Utility.RandomMinMax( 1, 3 ) == 1)
				{
					nNameSection = 1;
					sName1 = NameList.RandomName( "men_names_1" );
					sName2 = NameList.RandomName( "men_names_2" );
					sName3 = sName1 + sName2 + " the " + sName0;
				}
				else
				{
					sName3 = NameList.RandomName( "men_owners" );
					pName3 = sName3;
					sName3 = sName3 + " the " + sName0;
				}
			}
			else
			{
				// FEMALE TITLES
				sName0 = NameList.RandomName( "women_titles" );

				// FEMALE NAMES
				if (Utility.RandomMinMax( 1, 3 ) == 1)
				{
					nNameSection = 1;
					sName1 = NameList.RandomName( "women_names_1" );
					sName2 = NameList.RandomName( "women_names_2" );
					sName3 = sName1 + sName2 + " the " + sName0;
				}
				else
				{
					sName3 = NameList.RandomName( "women_owners" );
					pName3 = sName3;
					sName3 = sName3 + " the " + sName0;
				}
			}

			string[] vAdj = new string[] {"Exotic", "Mysterious", "Marvelous", "Amazing", "Astonishing", "Mystical", "Astounding", "Magnificent", "Phenomenal", "Fantastic", "Incredible", "Extraordinary", "Fabulous", "Wondrous", "Glorious", "Lost", "Fabled", "Legendary", "Mythical", "Missing", "Ancestral", "Ornate", "Wonderful", "Sacred", "Unspeakable", "Unknown", "Forgotten"};
				string sAdj = vAdj[Utility.RandomMinMax( 0, (vAdj.Length-1) )] + " ";

			if ( box == "Pilfer" )
			{
				return sName3;
			}
			else if ( box == "cargo" )
			{
				if ( Utility.RandomBool() )
				{
					sName3 = NameList.RandomName( "female" );
				}
				else
				{
					sName3 = NameList.RandomName( "male" );
				}

				string[] spaceTitles = new string[] {"Mechanic", "Scientist", "Doctor", "Soldier", "Mercenary", "Engineer", "Chief Medical Officer", "Science Officer", "Counselor", "Marine", "Soldier", "Trooper", "Navigator", "Medical Officer", "Officer", "Helmsman", "Gunner", "Pilot", "Weapons Officer", "Tactical Officer", "Biologist", "Chemist", "Security Officer", "Robotics Engineer", "Avionics Engineer", "Chief Engineering", "Chief of Security", "Linguist", "Botanist", "Pathologist", "Anthropologist", "Sociologist", "First Officer", "Logistics Officer", "Nurse"};
					string spaceTitle = spaceTitles[Utility.RandomMinMax( 0, (spaceTitles.Length-1) )];

				return sName3 + " the " + spaceTitle;
			}
			else if ( box == "Sunken" )
			{
				string[] sPirate = new string[] {"Captain", "First Mate", "Quartermaster", "Boatswain", "Sailing Master", "Sea Artist", "Navigator", "Master Gunner", "Gunner", "Sail Maker", "Cabin Boy", "Sailor", "Powder Monkey", "Buccaneer", "Privateer", "Rigger", "Swab"};
				string xPirate = sPirate[Utility.RandomMinMax( 0, (sPirate.Length-1) )];
				if ( nNameSection == 1 ){ sName3 = sName1 + sName2 + " the " + xPirate; } else { sName3 = pName3 + " the " + xPirate; }
				return "The " + sAdj + "Chest of " + sName3;
			}
			else if ( box == "SunkenBag" )
			{
				string[] sPirate = new string[] {"Captain", "First Mate", "Quartermaster", "Boatswain", "Sailing Master", "Sea Artist", "Navigator", "Master Gunner", "Gunner", "Sail Maker", "Cabin Boy", "Sailor", "Powder Monkey", "Buccaneer", "Privateer", "Rigger", "Swab"};
				string xPirate = sPirate[Utility.RandomMinMax( 0, (sPirate.Length-1) )];
				
				if ( Utility.RandomMinMax( 1, 3 ) == 3 ) 
				{
					pName3 = NameList.RandomName( "female" );
				}
				else 
				{ 
					pName3 = NameList.RandomName( "male" ); 
				}

				if ( Utility.RandomMinMax( 1, 3 ) == 3 ) 
				{
					sName3 = pName3 + " the " + sName0;
				}
				else 
				{ 
					sName3 = pName3 + " the " + xPirate;
				}

				return sName3;
			}
			else if ( box == "Body" )
			{
				sAdj = "";
				string sCorpse = "bones";
				switch ( Utility.RandomMinMax( 0, 3 ) ) 
				{
					case 0: sCorpse = "bones"; break;
					case 1: sCorpse = "body"; break;
					case 2: sCorpse = "skeletal remains"; break;
					case 3: sCorpse = "skeletal bones"; break;
				}
				return "The " + sCorpse + " of " + sName3;
			}
			else if ( box == "BodySailor" )
			{
				sAdj = "";
				string sCorpse = "bones";
				switch ( Utility.RandomMinMax( 0, 3 ) ) 
				{
					case 0: sCorpse = "bones"; break;
					case 1: sCorpse = "body"; break;
					case 2: sCorpse = "skeletal remains"; break;
					case 3: sCorpse = "skeletal bones"; break;
				}
				
				string[] sPirate = new string[] {"Captain", "First Mate", "Quartermaster", "Boatswain", "Sailing Master", "Sea Artist", "Navigator", "Master Gunner", "Gunner", "Sail Maker", "Cabin Boy", "Sailor", "Powder Monkey", "Buccaneer", "Privateer", "Rigger", "Swab"};
				string xPirate = sPirate[Utility.RandomMinMax( 0, (sPirate.Length-1) )];
				
				if ( Utility.RandomMinMax( 1, 3 ) == 3 ) 
				{
					pName3 = NameList.RandomName( "female" );
				}
				else 
				{ 
					pName3 = NameList.RandomName( "male" ); 
				}

				if ( Utility.RandomMinMax( 1, 3 ) == 3 ) 
				{
					sName3 = pName3 + " the " + sName0;
				}
				else 
				{ 
					sName3 = pName3 + " the " + xPirate;
				}

				return "The " + sCorpse + " of " + sName3;
			}
			else if ( box == "Treasure Chest" || box == "property" )
			{
				return sName3;
			}
			else if ( box == "Corpse" )
			{
				sAdj = "";
			}

			return "The " + sAdj + box + " of " + sName3;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void MakeTomb( LockableContainer box, Mobile m, int tomb )
		{
			box.Locked = false;

			string owner = m.Name;
				if ( m.Title != null && m.Title != "" ){ owner = m.Name + " " + m.Title; }

			if ( ( Utility.Random( 4 ) == 1 || tomb == 1 ) && tomb != 2 )
			{
				box.ItemID = Utility.RandomList( 0x27E0, 0x280A, 0x2802, 0x2803 );
				box.Name = "Sarcophagus of " + owner;
				ResourceMods.SetRandomResource( false, false, box, CraftResource.Iron, false, m );
				box.Catalog = Catalogs.Stone;
				box.GumpID = 0x1D;
			}
			else
			{
				box.ItemID = Utility.RandomList( 0x2800, 0x2801, 0x27E9, 0x27EA );
				box.GumpID = 0x41D;

				string coffin = "Coffin";
					if ( box.ItemID == 0x27E9 || box.ItemID == 0x27EA ){ coffin = "Casket"; }

				box.Name = coffin + " of " + owner;
				ResourceMods.SetRandomResource( false, false, box, CraftResource.RegularWood, false, m );
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void MakeDemonBox( LockableContainer box, Mobile m )
		{
			box.Locked = false;

			string owner = m.Name;
				if ( m.Title != null && m.Title != "" ){ owner = m.Name + " " + m.Title; }

			box.ItemID = Utility.RandomList( 0x281F, 0x2820, 0x4FE6, 0x4FE7 );
			box.Name = "Chest of " + owner;
			box.Resource = CraftResource.Iron;
			box.Hue = m.Hue;
			box.GumpID = 0x975;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void MakeSpaceCrate( LockableContainer box )
		{
			box.ItemID = Utility.RandomList( 0x10EA, 0x10EB, 0x10EC, 0x10ED );
			box.GumpID = 0x976;
			box.Name = "Cargo Container";
			box.Resource = ResourceMods.SciFiResource( CraftResource.Iron );
			box.Catalog = Catalogs.SciFi;
		}
	}
}