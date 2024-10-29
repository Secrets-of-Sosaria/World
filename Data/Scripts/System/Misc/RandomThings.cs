using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Items;
using Server.Regions;

namespace Server.Misc
{
    class RandomThings
    {
		public static string GetOddityAdjective()
		{
			string sAdjective = "an odd";

			switch( Utility.RandomMinMax( 0, 6 ) )
			{
				case 0: sAdjective = "an odd"; break;
				case 1: sAdjective = "an unusual"; break;
				case 2: sAdjective = "a bizarre"; break;
				case 3: sAdjective = "a curious"; break;
				case 4: sAdjective = "a peculiar"; break;
				case 5: sAdjective = "a strange"; break;
				case 6: sAdjective = "a weird"; break;
			}
			return sAdjective;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomAuthor()
		{
			string sWhoName = RandomThings.GetRandomBoyName();
			string sWhoTitle = RandomThings.GetBoyGirlJob( 0 );
			string sWhoRoyalty = RandomThings.GetRandomBoyNoble();

			if ( Utility.RandomMinMax( 1, 3 ) == 1 ) // FEMALE
			{
				sWhoName = RandomThings.GetRandomGirlName();
				sWhoTitle = RandomThings.GetBoyGirlJob( 1 );
				sWhoRoyalty = RandomThings.GetRandomGirlNoble();
			}

			if ( Utility.RandomMinMax( 1, 4 ) == 1 )
				return sWhoName + " the " + sWhoRoyalty;

			return sWhoName + " the " + sWhoTitle;
		}

		public static int GetRandomBookItemID()
		{
			return Utility.RandomList( 0x65CC, 0x65CD, 0x5688, 0x5689, 0x4FDD, 0x4FDE, 0x4FDF, 0x4FE0, 0x4FF6, 0x4FF7, 0xAA8, 0xB3B, 0xE3B, 0x0E3B, 0xFEF, 0xFF0, 0xFF1, 0xFF2, 0x27BC, 0x2B6F, 0x2254, 0x2259, 0x225A, 0x225B, 0x22C5, 0x36A2, 0x36A3, 0x27BB, 0x27BD, 0x2D50, 0x2D9D, 0x42B7, 0x42B8, 0x1C11, 0x2253, 0x2254, 0x42BF, 0x2205, 0x220F, 0x2219, 0x2223, 0x222D, 0x225C, 0x225D, 0x225E, 0x225F, 0x2253, 0x2254, 0x3B51, 0x3B52, 0x3B53, 0x3B54, 0x3B55, 0x3B56, 0x3B57, 0x3B58, 0x3B59, 0x3B5A );
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static int GetRandomMetallicColor()
		{
			return Utility.RandomList( 0x436, 0x445, 0x435, 0x433, 0x43A, 0x424, 0x44C, 0x44B, 0x43F, 0x440, 0x449, 0x432, 0x43E, 0x44D, 0x437, 0x8D5, 0x950, 0x4A2, 0x8E2, 0xB0C, 0xB3B, 0xB5E, 0x869, 0x982, 0x5CE, 0x56A, 0x7CB, 0x7CA, 0x856, 0x99D );
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomBelongsTo( string style )
		{
			string who = RandomThings.GetRandomName();
				if ( style == "orient" ){ who = RandomThings.GetRandomOrientalName(); }

			if ( who.EndsWith( "s" ) )
			{
				who = who + "'";
			}
			else
			{
				who = who + "'s";
			}

			return who;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string MadeUpCity()
		{
			string sPlace = "Village";
			string sPerson = NameList.RandomName( "elf_female" );

			switch( Utility.RandomMinMax( 0, 4 ) )
			{
				case 0: sPlace = "Village"; break;
				case 1: sPlace = "City"; break;
				case 2: sPlace = "Town"; break;
				case 3: sPlace = "Keep"; break;
				case 4: sPlace = "Hamlet"; break;
			}

			switch( Utility.RandomMinMax( 0, 16 ) )
			{
				case 1: sPerson = NameList.RandomName( "vampire" ); break;
				case 2: sPerson = NameList.RandomName( "drakkul" ); break;
				case 3: sPerson = NameList.RandomName( "greek" ); break;
				case 4: sPerson = NameList.RandomName( "urk" ); break;
				case 5: sPerson = NameList.RandomName( "giant" ); break;
				case 6: sPerson = NameList.RandomName( "imp" ); break;
				case 7: sPerson = NameList.RandomName( "dragon" ); break;
				case 8: sPerson = NameList.RandomName( "goddess" ); break;
				case 9: sPerson = NameList.RandomName( "demonic" ); break;
				case 10: sPerson = NameList.RandomName( "ancient lich" ); break;
				case 11: sPerson = NameList.RandomName( "gargoyle name" ); break;
				case 12: sPerson = NameList.RandomName( "centaur" ); break;
				case 13: sPerson = NameList.RandomName( "devil" ); break;
				case 14: sPerson = NameList.RandomName( "evil mage" ); break;
				case 15: sPerson = NameList.RandomName( "evil witch" ); break;
				case 16: sPerson = NameList.RandomName( "elf_male" ); break;
			}

			return "the " + sPlace + " of " + sPerson;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string MadeUpDungeon()
		{
			string sPlace = "Dungeon";
			string sAdjective = "Evil";
			string sBeing = "Lich";
			string sAdj = "Mad";

			switch( Utility.RandomMinMax( 0, 18 ) )
			{
				case 0: sPlace = "Dungeon"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Dungeons"; } break;
				case 1: sPlace = "Cave"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Caves"; } break;
				case 2: sPlace = "Tomb"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Tombs"; } break;
				case 3: sPlace = "Labyrinth"; break;
				case 4: sPlace = "Hall"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Halls"; } break;
				case 5: sPlace = "Crypt"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Crypts"; } break;
				case 6: sPlace = "Tower"; break;
				case 7: sPlace = "Castle"; break;
				case 8: sPlace = "Ruins"; break;
				case 9: sPlace = "Mountain"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Mountains"; } break;
				case 10: sPlace = "Mausoleum"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Catacombs"; } break;
				case 11: sPlace = "Tunnel"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Tunnels"; } break;
				case 12: sPlace = "Maze"; break;
				case 13: sPlace = "Pit"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Pits"; } break;
				case 14: sPlace = "Vault"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Vaults"; } break;
				case 15: sPlace = "Cavern"; if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sPlace = "Caverns"; } break;
				case 16: sPlace = "Fortress"; break;
				case 17: sPlace = "Stronghold"; break;
				case 18: sPlace = "Abyss"; break;
			}

			switch( Utility.RandomMinMax( 0, 19 ) )
			{
				case 1: sBeing = "King"; break;
				case 2: sBeing = "Queen"; break;
				case 3: sBeing = "Ghost"; break;
				case 4: sBeing = "Vampire"; break;
				case 5: sBeing = "Warlord"; break;
				case 6: sBeing = "Priest"; break;
				case 7: sBeing = "Wizard"; break;
				case 8: sBeing = "Sorceress"; break;
				case 9: sBeing = "God"; break;
				case 10: sBeing = "Goddess"; break;
				case 11: sBeing = "Devil"; break;
				case 12: sBeing = "Demon"; break;
				case 13: sBeing = "Dragon"; break;
				case 14: sBeing = "Knight"; break;
				case 15: sBeing = "Tyrant"; break;
				case 16: sBeing = Server.Misc.RandomThings.GetRandomJobTitle(0); break;
				case 17: sBeing = Server.Misc.RandomThings.GetRandomThing(0); break;
				case 18: sBeing = Server.Misc.RandomThings.GetRandomJobTitle(0); break;
				case 19: sBeing = Server.Misc.RandomThings.GetRandomThing(0); break;
			}

			switch( Utility.RandomMinMax( 0, 31 ) )
			{
				case 1: sAdj = Server.Misc.RandomThings.GetRandomColorName(0); break;
				case 2: sAdj = "Hated"; break;
				case 3: sAdj = "Feared"; break;
				case 4: sAdj = "Cursed"; break;
				case 5: sAdj = "Scorned"; break;
				case 6: sAdj = "Despised"; break;
				case 7: sAdj = "Lost"; break;
				case 8: sAdj = "Insane"; break;
				case 9: sAdj = "Deranged"; break;
				case 10: sAdj = "Demented"; break;
				case 11: sAdj = "Blighted"; break;
				case 12: sAdj = "Corrupt"; break;
				case 13: sAdj = "Angry"; break;
				case 14: sAdj = "Wicked"; break;
				case 15: sAdj = "Loathsome"; break;
				case 16: sAdj = "Baneful"; break;
				case 17: sAdj = "Cruel"; break;
				case 18: sAdj = "Atrocious"; break;
				case 19: sAdj = "Barbarous"; break;
				case 20: sAdj = "Brutal"; break;
				case 21: sAdj = "Heartless"; break;
				case 22: sAdj = "Merciless"; break;
				case 23: sAdj = "Ruthless"; break;
				case 24: sAdj = "Sadistic"; break;
				case 25: sAdj = "Tyrannical"; break;
				case 26: sAdj = "Vicous"; break;
				case 27: sAdj = "Bloodthirsty"; break;
				case 28: sAdj = "Ferocious"; break;
				case 29: sAdj = "Fierce"; break;
				case 30: sAdj = "Malevolent"; break;
				case 31: sAdj = "Loathed"; break;
			}

			switch( Utility.RandomMinMax( 1, 116 ) )
			{
				case 1: sAdjective = "the Corrupt"; 	break;
				case 2: sAdjective = "Destruction"; 	break;
				case 3: sAdjective = "the Hated"; 		break;
				case 4: sAdjective = "the Heinous"; 	break;
				case 5: sAdjective = "the Malevolent"; 	break;
				case 6: sAdjective = "the Malicious"; 	break;
				case 7: sAdjective = "the Nefarious"; 	break;
				case 8: sAdjective = "the Wicked"; 		break;
				case 9: sAdjective = "the Vicious"; 	break;
				case 10: sAdjective = "the Vile"; 		break;
				case 11: sAdjective = "Villainy"; 		break;
				case 12: sAdjective = "the Foul"; 		break;
				case 13: sAdjective = "Damnation"; 		break;
				case 14: sAdjective = "Terror"; 		break;
				case 15: sAdjective = "the Cursed"; 	break;
				case 16: sAdjective = "Doom"; 			break;
				case 17: sAdjective = "Dread"; 			break;
				case 18: sAdjective = "Repulsion"; 		break;
				case 19: sAdjective = "Spite"; 			break;
				case 20: sAdjective = "Wrath"; 			break;
				case 21: sAdjective = "Death"; 			break;
				case 22: sAdjective = "the Sinister"; 	break;
				case 23: sAdjective = "Woe"; 			break;
				case 24: sAdjective = "Torment"; 		break;
				case 25: sAdjective = "Wither"; 		break;
				case 26: sAdjective = "Decay"; 			break;
				case 27: sAdjective = "Curses"; 		break;
				case 28: sAdjective = "the Damned"; 	break;
				case 29: sAdjective = "Horror"; 		break;
				case 30: sAdjective = "the Tormented"; 	break;
				case 31: sAdjective = "the Doomed"; 	break;
				case 32: sAdjective = "the Unspeakable";break;
				case 33: sAdjective = "Hatred"; 		break;
				case 34: sAdjective = "Misery"; 		break;
				case 35: sAdjective = "the Corrupted"; 	break;
				case 36: sAdjective = "Corruption"; 	break;
				case 37: sAdjective = "Rage"; 			break;
				case 38: sAdjective = "the Dreaded"; 	break;
				case 39: sAdjective = "Darkness"; 		break;
				case 40: sAdjective = "Shadows"; 		break;
				case 41: sAdjective = "the Mad"; 		break;
				case 42: sAdjective = "the Insane"; 	break;
				case 43: sAdjective = "the Nine Hells"; break;
				case 44: sAdjective = "Cthulhu"; 		break;
				case 45: sAdjective = "Hell"; 			break;
				case 46: sAdjective = "Hades"; 			break;
				case 47: sAdjective = "Satan"; 			break;
				case 48: sAdjective = "the Spirits"; 	break;
				case 49: sAdjective = "the Haunted"; 	break;
				case 50: sAdjective = "the Undead"; 	break;
				case 51: sAdjective = "the Mummy"; 		break;
				case 52: sAdjective = "the Vampire"; 	break;
				case 53: sAdjective = "Blood";			break;
				case 54: sAdjective = "the Cult"; 		break;
				case 55: sAdjective = "the Lost"; 		break;
				case 56: sAdjective = "Lost Souls"; 	break;
				case 57: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 58: sAdjective = "Gold"; 			break;
				case 59: sAdjective = "Silver"; 		break;
				case 60: sAdjective = "the Necromancer";	break;
				case 61: sAdjective = "the Witch";			break;
				case 62: sAdjective = "the Warlock";		break;
				case 63: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 64: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 65: sAdjective = "the Villain";		break;
				case 66: sAdjective = "Brass";				break;
				case 67: sAdjective = "Bronze";				break;
				case 68: sAdjective = "the Ghost";			break;
				case 69: sAdjective = "the Death Knight";	break;
				case 70: sAdjective = "the Lich";			break;
				case 71: sAdjective = "the Occultist";		break;
				case 72: sAdjective = "the Cultist";		break;
				case 73: sAdjective = "the Diabolist";		break;
				case 74: sAdjective = "the Hag";			break;
				case 75: sAdjective = "the Butcher";		break;
				case 76: sAdjective = "the Slayer";			break;
				case 77: sAdjective = "the Executioner";	break;
				case 78: sAdjective = "the Demon";			break;
				case 79: sAdjective = "the Phantom";		break;
				case 80: sAdjective = "the Shadow";			break;
				case 81: sAdjective = "the Spectre";		break;
				case 82: sAdjective = "the Devil";			break;
				case 83: sAdjective = "the Shade";			break;
				case 84: sAdjective = "the Wraith";			break;
				case 85: sAdjective = "the Vampire";		break;
				case 86: sAdjective = "the Banshee";		break;
				case 87: sAdjective = "the Dark";			break;
				case 88: sAdjective = "the Black";			break;
				case 89: sAdjective = "the Mortician";		break;
				case 90: sAdjective = "the Embalmer";		break;
				case 91: sAdjective = "Iron";				break;
				case 92: sAdjective = "the Fiend";			break;
				case 93: sAdjective = "the Daemon";			break;
				case 94: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 95: sAdjective = "the Hateful";		break;
				case 96: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 97: sAdjective = "the Hideous";		break;
				case 98: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 99: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 100: sAdjective = "the " + sAdj + " " + sBeing; break;
				case 101: sAdjective = "the Forgotten"; break;
				case 102: sAdjective = "the Ancients"; break;
				case 103: sAdjective = "the Foul";			break;
				case 104: sAdjective = "the Baneful";		break;
				case 105: sAdjective = "the Depraved";		break;
				case 106: sAdjective = "the Loathsome";		break;
				case 107: sAdjective = "the Wrathful";		break;
				case 108: sAdjective = "the Woeful";		break;
				case 109: sAdjective = "the Grim";			break;
				case 110: sAdjective = "the Dismal";		break;
				case 111: sAdjective = "the Lifeless";		break;
				case 112: sAdjective = "the Deceased";		break;
				case 113: sAdjective = "the Bloodless";		break;
				case 114: sAdjective = "the Mortified";		break;
				case 115: sAdjective = "the Departed";		break;
				case 116: sAdjective = "the Dead";			break;
			}

			return "the " + sPlace + " of " + sAdjective;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string RandomEvilTitle()
		{
			string sSubs = "Ruler";
			string sAdjective = "Evil";
			string sAdj = "Mad";

			switch( Utility.RandomMinMax( 0, 18 ) )
			{
				case 0: sSubs = "Ruler";		break;
				case 1: sSubs = "Warlord";		break;
				case 2: sSubs = "Lord";			break;
				case 3: sSubs = "Overseer"; 	break;
				case 4: sSubs = "Servant";		break;
				case 5: sSubs = "Dweller";		break;
				case 6: sSubs = "Slave";		break;
				case 7: sSubs = "Eye";			break;
				case 8: sSubs = "Hand";			break;
				case 9: sSubs = "Heart";		break;
				case 10: sSubs = "Minion";		break;
				case 11: sSubs = "Master";		break;
				case 12: sSubs = "Conqueror";	break;
				case 13: sSubs = "Leader";		break;
				case 14: sSubs = "Herald";		break;
				case 15: sSubs = "Omen";		break;
				case 16: sSubs = "Bearer";		break;
				case 17: sSubs = "Sign";		break;
				case 18: sSubs = "Disciple";	break;
			}

			switch( Utility.RandomMinMax( 0, 31 ) )
			{
				case 1: sAdj = Server.Misc.RandomThings.GetRandomColorName(0); break;
				case 2: sAdj = "Hated"; break;
				case 3: sAdj = "Feared"; break;
				case 4: sAdj = "Cursed"; break;
				case 5: sAdj = "Scorned"; break;
				case 6: sAdj = "Despised"; break;
				case 7: sAdj = "Lost"; break;
				case 8: sAdj = "Insane"; break;
				case 9: sAdj = "Deranged"; break;
				case 10: sAdj = "Demented"; break;
				case 11: sAdj = "Blighted"; break;
				case 12: sAdj = "Corrupt"; break;
				case 13: sAdj = "Angry"; break;
				case 14: sAdj = "Wicked"; break;
				case 15: sAdj = "Loathsome"; break;
				case 16: sAdj = "Baneful"; break;
				case 17: sAdj = "Cruel"; break;
				case 18: sAdj = "Atrocious"; break;
				case 19: sAdj = "Barbarous"; break;
				case 20: sAdj = "Brutal"; break;
				case 21: sAdj = "Heartless"; break;
				case 22: sAdj = "Merciless"; break;
				case 23: sAdj = "Ruthless"; break;
				case 24: sAdj = "Sadistic"; break;
				case 25: sAdj = "Tyrannical"; break;
				case 26: sAdj = "Vicous"; break;
				case 27: sAdj = "Bloodthirsty"; break;
				case 28: sAdj = "Ferocious"; break;
				case 29: sAdj = "Fierce"; break;
				case 30: sAdj = "Malevolent"; break;
				case 31: sAdj = "Loathed"; break;
			}

			switch( Utility.RandomMinMax( 1, 108 ) )
			{
				case 1: sAdjective = "the Corrupt"; 	break;
				case 2: sAdjective = "Destruction"; 	break;
				case 3: sAdjective = "the Hated"; 		break;
				case 4: sAdjective = "the Heinous"; 	break;
				case 5: sAdjective = "the Malevolent"; 	break;
				case 6: sAdjective = "the Malicious"; 	break;
				case 7: sAdjective = "the Nefarious"; 	break;
				case 8: sAdjective = "the Wicked"; 		break;
				case 9: sAdjective = "the Vicious"; 	break;
				case 10: sAdjective = "the Vile"; 		break;
				case 11: sAdjective = "Villainy"; 		break;
				case 12: sAdjective = "the Foul"; 		break;
				case 13: sAdjective = "Damnation"; 		break;
				case 14: sAdjective = "Terror"; 		break;
				case 15: sAdjective = "the Cursed"; 	break;
				case 16: sAdjective = "Doom"; 			break;
				case 17: sAdjective = "Dread"; 			break;
				case 18: sAdjective = "Repulsion"; 		break;
				case 19: sAdjective = "Spite"; 			break;
				case 20: sAdjective = "Wrath"; 			break;
				case 21: sAdjective = "Death"; 			break;
				case 22: sAdjective = "the Sinister"; 	break;
				case 23: sAdjective = "Woe"; 			break;
				case 24: sAdjective = "Torment"; 		break;
				case 25: sAdjective = "Wither"; 		break;
				case 26: sAdjective = "Decay"; 			break;
				case 27: sAdjective = "Curses"; 		break;
				case 28: sAdjective = "the Damned"; 	break;
				case 29: sAdjective = "Horror"; 		break;
				case 30: sAdjective = "the Tormented"; 	break;
				case 31: sAdjective = "the Doomed"; 	break;
				case 32: sAdjective = "the Unspeakable";break;
				case 33: sAdjective = "Hatred"; 		break;
				case 34: sAdjective = "Misery"; 		break;
				case 35: sAdjective = "the Corrupted"; 	break;
				case 36: sAdjective = "Corruption"; 	break;
				case 37: sAdjective = "Rage"; 			break;
				case 38: sAdjective = "the Dreaded"; 	break;
				case 39: sAdjective = "Darkness"; 		break;
				case 40: sAdjective = "Shadows"; 		break;
				case 41: sAdjective = "the Mad"; 		break;
				case 42: sAdjective = "the Insane"; 	break;
				case 43: sAdjective = "the Nine Hells"; break;
				case 44: sAdjective = "Cthulhu"; 		break;
				case 45: sAdjective = "Hell"; 			break;
				case 46: sAdjective = "Hades"; 			break;
				case 47: sAdjective = "Satan"; 			break;
				case 48: sAdjective = "the Spirits"; 	break;
				case 49: sAdjective = "the Haunted"; 	break;
				case 50: sAdjective = "the Undead"; 	break;
				case 51: sAdjective = "the Mummy"; 		break;
				case 52: sAdjective = "the Vampire"; 	break;
				case 53: sAdjective = "Blood";			break;
				case 54: sAdjective = "the Cult"; 		break;
				case 55: sAdjective = "the Lost"; 		break;
				case 56: sAdjective = "Lost Souls"; 	break;
				case 57: sAdjective = "the Dead";		break;
				case 58: sAdjective = "Gold"; 			break;
				case 59: sAdjective = "Silver"; 		break;
				case 60: sAdjective = "the Necromancer";	break;
				case 61: sAdjective = "the Witch";			break;
				case 62: sAdjective = "the Warlock";		break;
				case 63: sAdjective = "the Mortified";		break;
				case 64: sAdjective = "the Departed";		break;
				case 65: sAdjective = "the Villain";		break;
				case 66: sAdjective = "Brass";				break;
				case 67: sAdjective = "Bronze";				break;
				case 68: sAdjective = "the Ghost";			break;
				case 69: sAdjective = "the Death Knight";	break;
				case 70: sAdjective = "the Lich";			break;
				case 71: sAdjective = "the Occultist";		break;
				case 72: sAdjective = "the Cultist";		break;
				case 73: sAdjective = "the Diabolist";		break;
				case 74: sAdjective = "the Hag";			break;
				case 75: sAdjective = "the Butcher";		break;
				case 76: sAdjective = "the Slayer";			break;
				case 77: sAdjective = "the Executioner";	break;
				case 78: sAdjective = "the Demon";			break;
				case 79: sAdjective = "the Phantom";		break;
				case 80: sAdjective = "the Shadow";			break;
				case 81: sAdjective = "the Spectre";		break;
				case 82: sAdjective = "the Devil";			break;
				case 83: sAdjective = "the Shade";			break;
				case 84: sAdjective = "the Wraith";			break;
				case 85: sAdjective = "the Vampire";		break;
				case 86: sAdjective = "the Banshee";		break;
				case 87: sAdjective = "the Dark";			break;
				case 88: sAdjective = "the Black";			break;
				case 89: sAdjective = "the Mortician";		break;
				case 90: sAdjective = "the Embalmer";		break;
				case 91: sAdjective = "Iron";				break;
				case 92: sAdjective = "the Fiend";			break;
				case 93: sAdjective = "the Daemon";			break;
				case 94: sAdjective = "the Bloodless";		break;
				case 95: sAdjective = "the Hateful";		break;
				case 96: sAdjective = "the Deceased";		break;
				case 97: sAdjective = "the Hideous";		break;
				case 98: sAdjective = "the Grim";			break;
				case 99: sAdjective = "the Dismal";			break;
				case 100: sAdjective = "the Lifeless";		break;
				case 101: sAdjective = "the Forgotten"; 	break;
				case 102: sAdjective = "the Ancients"; 		break;
				case 103: sAdjective = "the Foul";			break;
				case 104: sAdjective = "the Baneful";		break;
				case 105: sAdjective = "the Depraved";		break;
				case 106: sAdjective = "the Loathsome";		break;
				case 107: sAdjective = "the Wrathful";		break;
				case 108: sAdjective = "the Woeful";		break;
			}

			return "the " + sAdj + " " + sSubs + " of " + sAdjective;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomDisaster()
		{
			string sEvent = "Cataclysm";
			string sAdj = "Great";

			switch( Utility.RandomMinMax( 0, 13 ) )
			{
				case 0: sEvent = "Cataclysm"; break;
				case 1: sEvent = "Flood"; break;
				case 2: sEvent = "Disaster"; break;
				case 3: sEvent = "Plague"; break;
				case 4: sEvent = "Catastrophe"; break;
				case 5: sEvent = "Holocaust"; break;
				case 6: sEvent = "Tragedy"; break;
				case 7: sEvent = "War"; break;
				case 8: sEvent = "Blight"; break;
				case 9: sEvent = "Battle"; break;
				case 10: sEvent = "Scourge"; break;
				case 11: sEvent = "Pestilence"; break;
				case 12: sEvent = "Invasion"; break;
				case 13: sEvent = "Earthquake"; break;
			}

			switch( Utility.RandomMinMax( 0, 13 ) )
			{
				case 0: sAdj = "Great"; break;
				case 1: sAdj = "Terrible"; break;
				case 2: sAdj = "Evil"; break;
				case 3: sAdj = "Vile"; break;
				case 4: sAdj = "Major"; break;
				case 5: sAdj = "Immense"; break;
				case 6: sAdj = "Ancient"; break;
				case 7: sAdj = "Destructive"; break;
				case 8: sAdj = "Historic"; break;
				case 9: sAdj = "Famous"; break;
				case 10: sAdj = "Terrific"; break;
				case 11: sAdj = "Forgotten"; break;
				case 12: sAdj = "Mysterious"; break;
				case 13: sAdj = "Unknown"; break;
			}

			return "the " + sAdj + " " + sEvent;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomNoble()
		{
			string noble = "King";

			switch( Utility.RandomMinMax( 0, 29 ) )
			{
				case 0: noble = "Emperor"; break;
				case 1: noble = "Empress"; break;
				case 2: noble = "King"; break;
				case 3: noble = "Queen"; break;
				case 4: noble = "Prince"; break;
				case 5: noble = "Princess"; break;
				case 6: noble = "Duke"; break;
				case 7: noble = "Duchess"; break;
				case 8: noble = "Marquess"; break;
				case 9: noble = "Marchioness"; break;
				case 10: noble = "Earl"; break;
				case 11: noble = "Count"; break;
				case 12: noble = "Countess"; break;
				case 13: noble = "Viscount"; break;
				case 14: noble = "Viscountess"; break;
				case 15: noble = "Baron"; break;
				case 16: noble = "Baroness"; break;
				case 17: noble = "Baronet"; break;
				case 18: noble = "Baronetess"; break;
				case 19: noble = "Knight"; break;
				case 20: noble = "Marquis"; break;
				case 21: noble = "Marquise"; break;
				case 22: noble = "Chevalier"; break;
				case 23: noble = "Tsar"; break;
				case 24: noble = "Monarch"; break;
				case 25: noble = "Archbishop"; break;
				case 26: noble = "Lady"; break;
				case 27: noble = "Lord"; break;
				case 28: noble = "Chancellor"; break;
				case 29: noble = "Dame"; break;
			}
			return noble;
		}

		public static string GetRandomGirlNoble()
		{
			string noble = "Queen";

			switch( Utility.RandomMinMax( 0, 12 ) )
			{
				case 1: noble = "Empress"; break;
				case 2: noble = "Princess"; break;
				case 3: noble = "Duchess"; break;
				case 4: noble = "Marchioness"; break;
				case 5: noble = "Countess"; break;
				case 6: noble = "Viscountess"; break;
				case 7: noble = "Baroness"; break;
				case 8: noble = "Baronetess"; break;
				case 9: noble = "Knight"; break;
				case 10: noble = "Marquise"; break;
				case 11: noble = "Lady"; break;
				case 12: noble = "Dame"; break;
			}
			return noble;
		}

		public static string GetRandomBoyNoble()
		{
			string noble = "King";

			switch( Utility.RandomMinMax( 0, 17 ) )
			{
				case 1: noble = "Emperor"; break;
				case 2: noble = "Prince"; break;
				case 3: noble = "Duke"; break;
				case 4: noble = "Marquess"; break;
				case 5: noble = "Earl"; break;
				case 6: noble = "Count"; break;
				case 7: noble = "Viscount"; break;
				case 8: noble = "Baron"; break;
				case 9: noble = "Baronet"; break;
				case 10: noble = "Knight"; break;
				case 11: noble = "Marquis"; break;
				case 12: noble = "Chevalier"; break;
				case 13: noble = "Tsar"; break;
				case 14: noble = "Monarch"; break;
				case 15: noble = "Archbishop"; break;
				case 16: noble = "Lord"; break;
				case 17: noble = "Chancellor"; break;
			}
			return noble;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomTimeFrame()
		{
			string time = "10 years";

			switch( Utility.RandomMinMax( 0, 5 ) )
			{
				case 0: time = ( Utility.RandomMinMax( 1, 90 ) * 10 ) + " years"; break;
				case 1: time = ( Utility.RandomMinMax( 1, 90 ) * 10 ) + ",000 years"; break;
				case 2: time = Utility.RandomMinMax( 1, 9 ) + ",000 years"; break;
				case 3: time = ( Utility.RandomMinMax( 1, 90 ) * 10 ) + " centuries"; break;
				case 4: time = Utility.RandomMinMax( 1, 9 ) + ",000 centuries"; break;
				case 5: time = Utility.RandomMinMax( 2, 9 ) + " centuries"; break;
			}
			return time;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomWeapon()
		{
			string item = "assassin dagger";

			switch( Utility.RandomMinMax( 1, 50 ) )
			{
				case 1: item = "assassin dagger"; break;
				case 2: item = "assassin sword"; break;
				case 3: item = "axe"; break;
				case 4: item = "barbarian axe"; break;
				case 5: item = "bardiche"; break;
				case 6: item = "battle axe"; break;
				case 7: item = "battle mace"; break;
				case 8: item = "bladed staff"; break;
				case 9: item = "sickle"; break;
				case 10: item = "broadsword"; break;
				case 11: item = "butcher knife"; break;
				case 12: item = "cleaver"; break;
				case 13: item = "club"; break;
				case 14: item = "crescent blade"; break;
				case 15: item = "cutlass"; break;
				case 16: item = "dagger"; break;
				case 17: item = "double axe"; break;
				case 18: item = "double bladed staff"; break;
				case 19: item = "executioner axe"; break;
				case 20: item = "falchion"; break;
				case 21: item = "halberd"; break;
				case 22: item = "hammer pick"; break;
				case 23: item = "hatchet"; break;
				case 24: item = "katana"; break;
				case 25: item = "kryss"; break;
				case 26: item = "large battle axe"; break;
				case 27: item = "longsword"; break;
				case 28: item = "mace"; break;
				case 29: item = "machete"; break;
				case 30: item = "maul"; break;
				case 31: item = "pickaxe"; break;
				case 32: item = "pike"; break;
				case 33: item = "quarter staff"; break;
				case 34: item = "royal sword"; break;
				case 35: item = "scepter"; break;
				case 36: item = "scimitar"; break;
				case 37: item = "scythe"; break;
				case 38: item = "rapier"; break;
				case 39: item = "skinning knife"; break;
				case 40: item = "spear"; break;
				case 41: item = "trident"; break;
				case 42: item = "two handed axe"; break;
				case 43: item = "barbarian sword"; break;
				case 44: item = "war axe"; break;
				case 45: item = "war blades"; break;
				case 46: item = "war cleaver"; break;
				case 47: item = "war dagger"; break;
				case 48: item = "war fork"; break;
				case 49: item = "war hammer"; break;
				case 50: item = "war mace"; break;
			}

			return item;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomArmorWeaponItem()
		{
			string item = "Bascinet";

			switch( Utility.RandomMinMax( 0, 253 ) )
			{
				case 0: item = "Bascinet"; break;
				case 1: item = "Bone Arms"; break;
				case 2: item = "Bone Chest"; break;
				case 3: item = "Bone Gloves"; break;
				case 4: item = "Bone Helm"; break;
				case 5: item = "Bone Legs"; break;
				case 6: item = "Buckler"; break;
				case 7: item = "Chain Chest"; break;
				case 8: item = "Chain Coif"; break;
				case 9: item = "Chain Hatsuburi"; break;
				case 10: item = "Chain Legs"; break;
				case 11: item = "Chaos Shield"; break;
				case 12: item = "Circlet"; break;
				case 13: item = "Close Helm"; break;
				case 14: item = "Decorative Plate Kabuto"; break;
				case 15: item = "Dragonscale Arms"; break;
				case 16: item = "Dragonscale Gloves"; break;
				case 17: item = "Dragonscale Helm"; break;
				case 18: item = "Dragonscale Leggings"; break;
				case 19: item = "Dragonscale Tunic"; break;
				case 20: item = "Female Leather Chest"; break;
				case 21: item = "Female Plate Chest"; break;
				case 22: item = "Female Studded Chest"; break;
				case 23: item = "Gemmed Circlet"; break;
				case 24: item = "Heater Shield"; break;
				case 25: item = "Heavy Plate Jingasa"; break;
				case 26: item = "Helmet"; break;
				case 27: item = "Leather Arms"; break;
				case 28: item = "Leather Bustier Arms"; break;
				case 29: item = "Leather Cap"; break;
				case 30: item = "Leather Chest"; break;
				case 31: item = "Leather Do"; break;
				case 32: item = "Leather Gloves"; break;
				case 33: item = "Leather Gorget"; break;
				case 34: item = "Leather Haidate"; break;
				case 35: item = "Leather HiroSode"; break;
				case 36: item = "Leather Jingasa"; break;
				case 37: item = "Leather Legs"; break;
				case 38: item = "Leather Mempo"; break;
				case 39: item = "Leather Ninja Hood"; break;
				case 40: item = "Leather Ninja Jacket"; break;
				case 41: item = "Leather Ninja Mitts"; break;
				case 42: item = "Leather Ninja Pants"; break;
				case 43: item = "Leather Shorts"; break;
				case 44: item = "Leather Skirt"; break;
				case 45: item = "Leather Suneate"; break;
				case 46: item = "Light Plate Jingasa"; break;
				case 47: item = "Metal Kite Shield"; break;
				case 48: item = "Metal Shield"; break;
				case 49: item = "Norse Helm"; break;
				case 50: item = "Horned Helm"; break;
				case 51: item = "Order Shield"; break;
				case 52: item = "Plate Arms"; break;
				case 53: item = "Plate Battle Kabuto"; break;
				case 54: item = "Plate Chest"; break;
				case 55: item = "Plate Do"; break;
				case 56: item = "Plate Gloves"; break;
				case 57: item = "Plate Gorget"; break;
				case 58: item = "Plate Haidate"; break;
				case 59: item = "Plate Hatsuburi"; break;
				case 60: item = "Plate Helm"; break;
				case 61: item = "Plate Hiro Sode"; break;
				case 62: item = "Plate Legs"; break;
				case 63: item = "Plate Mempo"; break;
				case 64: item = "Plate Suneate"; break;
				case 65: item = "Raven Helm"; break;
				case 66: item = "Ringmail Arms"; break;
				case 67: item = "Ringmail Chest"; break;
				case 68: item = "Ringmail Gloves"; break;
				case 69: item = "Ringmail Legs"; break;
				case 70: item = "Royal Arms"; break;
				case 71: item = "Royal Boots"; break;
				case 72: item = "Royal Chest"; break;
				case 73: item = "Royal Circlet"; break;
				case 74: item = "Royal Gloves"; break;
				case 75: item = "Royal Gorget"; break;
				case 76: item = "Royal Helm"; break;
				case 77: item = "Royal Legs"; break;
				case 78: item = "Royal Shield"; break;
				case 79: item = "Small Plate Jingasa"; break;
				case 80: item = "Standard Plate Kabuto"; break;
				case 81: item = "Steel Shield"; break;
				case 82: item = "Studded Arms"; break;
				case 83: item = "Studded Bustier Arms"; break;
				case 84: item = "Studded Chest"; break;
				case 85: item = "Studded Do"; break;
				case 86: item = "Studded Gloves"; break;
				case 87: item = "Studded Gorget"; break;
				case 88: item = "Studded Haidate"; break;
				case 89: item = "Studded Hiro Sode"; break;
				case 90: item = "Studded Legs"; break;
				case 91: item = "Studded Mempo"; break;
				case 92: item = "Studded Suneate"; break;
				case 93: item = "Vulture Helm"; break;
				case 94: item = "Winged Helm"; break;
				case 95: item = "Wooden Kite Shield"; break;
				case 96: item = "Wooden Plate Arms"; break;
				case 97: item = "Wooden Plate Chest"; break;
				case 98: item = "Wooden Plate Gloves"; break;
				case 99: item = "Wooden Plate Gorget"; break;
				case 100: item = "Wooden Plate Helm"; break;
				case 101: item = "Wooden Plate Legs"; break;
				case 102: item = "Wooden Shield"; break;
				case 103: item = "Assassin Dagger"; break;
				case 104: item = "Assassin Sword"; break;
				case 105: item = "Axe"; break;
				case 106: item = "Barbarian Axe"; break;
				case 107: item = "Bardiche"; break;
				case 108: item = "Battle Axe"; break;
				case 109: item = "Battle Mace"; break;
				case 110: item = "Wizard Staff"; break;
				case 111: item = "Bladed Staff"; break;
				case 112: item = "Bokuto"; break;
				case 113: item = "Sickle"; break;
				case 114: item = "Bow"; break;
				case 115: item = "Broadsword"; break;
				case 116: item = "Butcher Knife"; break;
				case 117: item = "Cleaver"; break;
				case 118: item = "Club"; break;
				case 119: item = "Composite Bow"; break;
				case 120: item = "Crescent Blade"; break;
				case 121: item = "Crossbow"; break;
				case 122: item = "Cutlass"; break;
				case 123: item = "Dagger"; break;
				case 124: item = "Daisho"; break;
				case 125: item = "Double Axe"; break;
				case 126: item = "Double Bladed Staff"; break;
				case 127: item = "Druid Staff"; break;
				case 128: item = "Executioner Axe"; break;
				case 129: item = "Falchion"; break;
				case 130: item = "Gnarled Staff"; break;
				case 131: item = "Halberd"; break;
				case 132: item = "Hammer Pick"; break;
				case 133: item = "Hatchet"; break;
				case 134: item = "Heavy Crossbow"; break;
				case 135: item = "Kama"; break;
				case 136: item = "Katana"; break;
				case 137: item = "Kryss"; break;
				case 138: item = "Lajatang"; break;
				case 139: item = "Lance"; break;
				case 140: item = "Large Battle Axe"; break;
				case 141: item = "Longsword"; break;
				case 142: item = "Mace"; break;
				case 143: item = "Machete"; break;
				case 144: item = "Maul"; break;
				case 145: item = "NoDachi"; break;
				case 146: item = "Nunchaku"; break;
				case 147: item = "Pickaxe"; break;
				case 148: item = "Pike"; break;
				case 149: item = "Pugilist Gloves"; break;
				case 150: item = "Quarter Staff"; break;
				case 151: item = "Repeating Crossbow"; break;
				case 152: item = "Royal Sword"; break;
				case 153: item = "Sai"; break;
				case 154: item = "Scepter"; break;
				case 155: item = "Scimitar"; break;
				case 156: item = "Scythe"; break;
				case 157: item = "Shepherds Crook"; break;
				case 158: item = "Rapier"; break;
				case 159: item = "Skinning Knife"; break;
				case 160: item = "Spear"; break;
				case 161: item = "Woodland Longbow"; break;
				case 162: item = "Woodland Shortbow"; break;
				case 163: item = "Tekagi"; break;
				case 164: item = "Tessen"; break;
				case 165: item = "Tetsubo"; break;
				case 166: item = "Sword"; break;
				case 167: item = "Tribal Spear"; break;
				case 168: item = "Trident"; break;
				case 169: item = "Two Handed Axe"; break;
				case 170: item = "Barbarian Sword"; break;
				case 171: item = "Wakizashi"; break;
				case 172: item = "War Axe"; break;
				case 173: item = "War Blades"; break;
				case 174: item = "War Cleaver"; break;
				case 175: item = "War Dagger"; break;
				case 176: item = "War Fork"; break;
				case 177: item = "War Hammer"; break;
				case 178: item = "War Mace"; break;
				case 179: item = "Yumi"; break;
				case 180: item = "Bandana"; break;
				case 181: item = "Bear Mask"; break;
				case 182: item = "Belt"; break;
				case 183: item = "Body Sash"; break;
				case 184: item = "Bonnet"; break;
				case 185: item = "Boots"; break;
				case 186: item = "Cap"; break;
				case 187: item = "Cloak"; break;
				case 188: item = "Cloth Ninja Hood"; break;
				case 189: item = "Cloth Ninja Jacket"; break;
				case 190: item = "Deer Mask"; break;
				case 191: item = "Doublet"; break;
				case 192: item = "Fancy Boots"; break;
				case 193: item = "Fancy Dress"; break;
				case 194: item = "Fancy Shirt"; break;
				case 195: item = "Feathered Hat"; break;
				case 196: item = "Female Kimono"; break;
				case 197: item = "Female Robe"; break;
				case 198: item = "Floppy Hat"; break;
				case 199: item = "Flower Garland"; break;
				case 200: item = "Formal Shirt"; break;
				case 201: item = "Full Apron"; break;
				case 202: item = "Gilded Dress"; break;
				case 203: item = "Hakama"; break;
				case 204: item = "Hakama Shita"; break;
				case 205: item = "Half Apron"; break;
				case 206: item = "Horned Tribal Mask"; break;
				case 207: item = "Jester Hat"; break;
				case 208: item = "Jester Suit"; break;
				case 209: item = "Jin Baori"; break;
				case 210: item = "Kamishimo"; break;
				case 211: item = "Kasa"; break;
				case 212: item = "Kilt"; break;
				case 213: item = "Loin Cloth"; break;
				case 214: item = "Long Pants"; break;
				case 215: item = "Male Kimono"; break;
				case 216: item = "Ninja Tabi"; break;
				case 217: item = "Obi"; break;
				case 218: item = "Plain Dress"; break;
				case 219: item = "Robe"; break;
				case 220: item = "Royal Cape"; break;
				case 221: item = "Samurai Tabi"; break;
				case 222: item = "Sandals"; break;
				case 223: item = "Shirt"; break;
				case 224: item = "Shoes"; break;
				case 225: item = "Short Pants"; break;
				case 226: item = "Skirt"; break;
				case 227: item = "Skull Cap"; break;
				case 228: item = "Straw Hat"; break;
				case 229: item = "Surcoat"; break;
				case 230: item = "Tall Straw Hat"; break;
				case 231: item = "Tattsuke Hakama"; break;
				case 232: item = "Thigh Boots"; break;
				case 233: item = "Tribal Mask"; break;
				case 234: item = "Tricorne Hat"; break;
				case 235: item = "Tunic"; break;
				case 236: item = "Waraji"; break;
				case 237: item = "Wide Brim Hat"; break;
				case 238: item = "Wizards Hat"; break;
				case 239: item = "Candle"; break;
				case 240: item = "Gold Bead Necklace"; break;
				case 241: item = "Gold Bracelet"; break;
				case 242: item = "Gold Earrings"; break;
				case 243: item = "Gold Necklace"; break;
				case 244: item = "Gold Ring"; break;
				case 245: item = "Lantern"; break;
				case 246: item = "Necklace"; break;
				case 247: item = "Silver Bead Necklace"; break;
				case 248: item = "Silver Bracelet"; break;
				case 249: item = "Silver Earrings"; break;
				case 250: item = "Silver Necklace"; break;
				case 251: item = "Silver Ring"; break;
				case 252: item = "Talisman"; break;
				case 253: item = "Torch"; break;
			}

			return item;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomShipName( string captain, int lower )
		{
			string sNumber = Utility.RandomMinMax( 3, 12 ).ToString();

			string[] vName1 = new string[] {"Achelous'", "Aegaeon's", "Alpheus'", "Angry", "Awful", "Black", "Bloody", "Blue", "Brass", "Buccaneer's", "Calypso's", "Captain's", "Coral", "Cruel", "Crying", "Cursed", "Damned", "Dark", "Davy Jones'", "Deathly", "Deceitful", "Delphin's", "Devil's", "Dirty", "Disgraceful", "Dishonorable", "Dishonored", "Dragon's", "Dreaming", "Emerald", "Eurybia's", "Evil", "Executioner's", "Fallen", "Forgotten", "Foul", "Gentle", "Golden", "Gray", "Greedy", "Green", "Hades'", "Hateful", "Haunted", "Hellish", "Howling", "Jade", "Killer's", "Knave's", "Lost", "Menacing", "Morbid", "Murderer's", "Neptune's", "Nereus'", "Night's", "Ocean's", "Oceanus'", "Pirate's", "Plunderer's", "Poison", "Poseidon's", "Prideful", "Privateer's", "Proteus'", "Raging", "Red", "Royal", "Ruby", "Sailor's", "Sapphire", "Savage", "Screaming", "Searching", "Sea's", "Serpent's", "Shameful", "Shrieking", "Silver", "Snake's", "Steady", "Travelling", "Tritun's", "Vile", "Wandering", "White", "Yellow"};
				string sName1 = vName1[Utility.RandomMinMax( 0, (vName1.Length-1) )];

			if ( captain != "" && captain != null ){ sName1 = captain; }

			string[] vName2 = new string[] {"Anchor", "Anger", "Barnacle", "Blade", "Buccaneer", "Captain", "Coral", "Crossbones", "Cruelty", "Cutlass", "Cutter", "Dagger", "Damnation", "Death", "Demon", "Devil", "Dishonor", "Doom", "Dream", "Executioner", "Fear", "Gale", "Galleon", "Grail", "Hate", "Horn", "Horror", "Hurricane", "Insanity", "Jewel", "Killer", "Knave", "Knife", "Lightning", "Mermaid", "Murderer", "Mystery", "Night", "Nightmare", "Pearl", "Pirate", "Poison", "Privateer", "Raider", "Saber", "Sail", "Scream", "Secret", "Serpent", "Servant", "Shark", "Ship", "Skull", "Slave", "Storm", "Strumpet", "Sun", "Sword", "Thunder", "Treasure", "Trident", "Whale", "Whirlpool", "Whore"};
				string sName2 = vName2[Utility.RandomMinMax( 0, (vName2.Length-1) )];

			string sName3 = "";
			switch( Utility.RandomMinMax( 1, 120 ) )
			{
				case 1: sName3 = " of the Cloak"; break;
				case 2: sName3 = " of the Coast"; break;
				case 3: sName3 = " of the Damned"; break;
				case 4: sName3 = " of the Dark"; break;
				case 5: sName3 = " of the Devil"; break;
				case 6: sName3 = " of the East"; break;
				case 7: sName3 = " of the Gods"; break;
				case 8: sName3 = " of the Helm"; break;
				case 9: sName3 = " of the " + sNumber + " Islands"; break;
				case 10: sName3 = " of the Isles"; break;
				case 11: sName3 = " of the Light"; break;
				case 12: sName3 = " of the Night"; break;
				case 13: sName3 = " of the North"; break;
				case 14: sName3 = " of the Ocean"; break;
				case 15: sName3 = " of the Reef"; break;
				case 16: sName3 = " of the Righteous"; break;
				case 17: sName3 = " of the Sea"; break;
				case 18: sName3 = " of the " + sNumber + " Seas"; break;
				case 19: sName3 = " of the Shield"; break;
				case 20: sName3 = " of the Shore"; break;
				case 21: sName3 = " of the South"; break;
				case 22: sName3 = " of the Storm"; break;
				case 23: sName3 = " of the Sword"; break;
				case 24: sName3 = " of the Blade"; break;
				case 25: sName3 = " of the Tropics"; break;
				case 26: sName3 = " of the Waves"; break;
				case 27: sName3 = " of the West"; break;
				case 28: sName3 = " of the Winds"; break;
				case 29: sName3 = " of the Docks"; break;
				case 30: sName3 = " of the Warf"; break;
				case 31: sName3 = " of the " + sNumber + " Blades"; break;
				case 32: sName3 = " of the " + sNumber + " Swords"; break;
				case 33: sName3 = " of the " + sNumber + " Gods"; break;
				case 34: sName3 = " of the " + sNumber + " Storms"; break;
				case 35: sName3 = " of the " + sNumber + " Shores"; break;
				case 36: sName3 = " of the " + sNumber + " Shields"; break;
				case 37: sName3 = " of the " + sNumber + " Flags"; break;
				case 38: sName3 = " of the " + sNumber + " Coasts"; break;
			}
			if ( lower > 0 ){ return "the " + sName1 + " " + sName2 + sName3; }

			return "The " + sName1 + " " + sName2 + sName3;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string RandomMagicalItem()
		{
			string sAdjective = "unusual";
			string eAdjective = "might";

			sAdjective = RandomThings.MagicItemAdj( "start", false, false, 0 );
			eAdjective = RandomThings.MagicItemAdj( "end", false, false, 0 );

			sAdjective = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(sAdjective);
			eAdjective = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(eAdjective);

			string name = GetRandomArmorWeaponItem();

			switch( Utility.RandomMinMax( 0, 1 ) )
			{
				case 0: name = sAdjective + " " + name + " of " + eAdjective;	break;
				case 1: name = name + " of " + eAdjective;						break;
			}

			return name;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomName()
		{
			string name = NameList.RandomName( "male" );

			switch( Utility.RandomMinMax( 1, 29 ) )
			{
				case 1: name = NameList.RandomName( "vampire" ); break;
				case 2: name = NameList.RandomName( "drakkul" ); break;
				case 3: name = NameList.RandomName( "imp" ); break;
				case 4: name = NameList.RandomName( "druid" ); break;
				case 5: name = NameList.RandomName( "ork" ); break;
				case 6: name = NameList.RandomName( "dragon" ); break;
				case 7: name = NameList.RandomName( "goddess" ); break;
				case 8: name = NameList.RandomName( "demonic" ); break;
				case 9: name = NameList.RandomName( "ork_male" ); break;
				case 10: name = NameList.RandomName( "ork_female" ); break;
				case 11: name = NameList.RandomName( "barb_male" ); break;
				case 12: name = NameList.RandomName( "barb_female" ); break;
				case 13: name = NameList.RandomName( "ancient lich" ); break;
				case 14: name = NameList.RandomName( "demon knight" ); break;
				case 15: name = NameList.RandomName( "shadow knight" ); break;
				case 16: name = NameList.RandomName( "gargoyle vendor" ); break;
				case 17: name = NameList.RandomName( "gargoyle name" ); break;
				case 18: name = NameList.RandomName( "centaur" ); break;
				case 19: name = NameList.RandomName( "pixie" ); break;
				case 20: name = NameList.RandomName( "golem controller" ); break;
				case 21: name = NameList.RandomName( "daemon" ); break;
				case 22: name = NameList.RandomName( "devil" ); break;
				case 23: name = NameList.RandomName( "evil mage" ); break;
				case 24: name = NameList.RandomName( "evil witch" ); break;
				case 25: name = NameList.RandomName( "elf_male" ); break;
				case 26: name = NameList.RandomName( "elf_female" ); break;
				case 27: name = NameList.RandomName( "female" ); break;
				case 28: name = NameList.RandomName( "male" ); break;
				case 29: name = NameList.RandomName( "greek" ); break;
			}

			if ( name == null || name == "" ){ name = NameList.RandomName( "male" ); }

			return name;
		}

		public static string GetRandomGirlName()
		{
			string name = NameList.RandomName( "female" );

			switch( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: name = NameList.RandomName( "ork_female" ); break;
				case 2: name = NameList.RandomName( "barb_female" ); break;
				case 3: name = NameList.RandomName( "evil witch" ); break;
				case 4: name = NameList.RandomName( "elf_female" ); break;
				case 5: name = NameList.RandomName( "tokuno female" ); break;
			}

			return name;
		}

		public static string GetRandomBoyName()
		{
			string name = NameList.RandomName( "male" );

			switch( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: name = NameList.RandomName( "ork_male" ); break;
				case 2: name = NameList.RandomName( "barb_male" ); break;
				case 3: name = NameList.RandomName( "evil mage" ); break;
				case 4: name = NameList.RandomName( "elf_male" ); break;
				case 5: name = NameList.RandomName( "tokuno male" ); break;
			}

			return name;
		}

		public static string GetRandomCharacterName()
		{
			string name = NameList.RandomName( "female" );

			switch( Utility.RandomMinMax( 0, 11 ) )
			{
				case 1: name = NameList.RandomName( "ork_female" ); break;
				case 2: name = NameList.RandomName( "barb_female" ); break;
				case 3: name = NameList.RandomName( "evil witch" ); break;
				case 4: name = NameList.RandomName( "elf_female" ); break;
				case 5: name = NameList.RandomName( "tokuno female" ); break;
				case 6: name = NameList.RandomName( "ork_male" ); break;
				case 7: name = NameList.RandomName( "barb_male" ); break;
				case 8: name = NameList.RandomName( "evil mage" ); break;
				case 9: name = NameList.RandomName( "elf_male" ); break;
				case 10: name = NameList.RandomName( "tokuno male" ); break;
				case 11: name = NameList.RandomName( "male" ); break;
			}

			return name;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomAlienRace()
		{
			string[] names = new string[] { "Romulan", "Klingon", "Vulcan", "Gorn", "Ferengi", "Orion", "Bajoran", "Abednedo", "Abyssin", "Aleena", "Amanin", "Amaran", "Annoo", "Anomid", "Ansionian", "Anzati", "Aqualish", "Arcona", "Argazdan", "Aruzan", "Askajian", "Balosar", "Bando Gora", "Barabel", "Besalisk", "Bith", "Blarina", "Boltrunians", "Bothan", "Caamasi", "Cathar", "Celegian", "Cerean", "Chadra-Fan", "Chalactan", "Chagrian", "Chiss", "Chistori", "Clawdite", "Codru-Ji", "Coway", "Dashade", "Dathomirian", "Defel", "Devaronian", "Drach'nam", "Dressellian", "Droch", "Drovian", "Dulok", "Durkii", "Duros", "Echani", "Elomin", "Epicanthix", "Er'Kit", "Ewok", "Falleen", "Feeorin", "Ferroans", "Firrerreo", "Fosh", "Frozian", "Frozarns", "Gado", "Gamorrean", "Gand", "Gank", "Gen'Dai", "Gerb", "Geonosian", "Givin", "Gizka", "Glymphid", "Gorax", "Gorith", "Gorog", "Gossam", "Gotal", "Gran", "Gree", "Grizmallt", "Gungan", "Gwurran", "Habassa", "Hallotan", "Hapan", "Harch", "Herglic", "Himoran", "H'nemthean", "Hoojib", "Huk", "Human", "Hssiss", "Hutt", "Iktotchi", "Iridonian", "Ishi Tib", "Ithorian", "Jabiimas", "Jawa", "Kaleesh", "Kaminoan", "Karkarodon", "Kel Dor", "Keshiri", "Kiffar", "Kitonak", "Klatooinian", "Kobok", "Kubaz", "Kurtzen", "Kushiban", "Kwa", "Kwi", "Kyuzo", "Lannik", "Lasat", "Lepi", "Letaki", "Lurmen", "Massassi", "Melodie", "Mimbanite", "Miraluka", "Mirialan", "Mon Calamari", "Mustafarian", "Muun", "Myneyrsh", "Myriad", "Nagai", "Nautolan", "Neimoidian", "Nelvaanian", "Neti", "Nikto", "Noghri", "Nosaurian", "Ogemite", "Omwati", "Ongree", "Ortolan", "Oswaft", "Paaerduag", "Pa'lowick", "Pau'an", "Phlog", "Polis Massan", "Porgs", "Priapulin", "Psadan", "P'w'eck", "Quarren", "Quermian", "Rakata", "Ranat", "Rattataki", "Rishii", "Roonan", "Ruurian", "Ryn", "Saffa", "Sanyassan", "Saurin", "Selkath", "Sauvax", "Selonian", "Shawda Ubb", "Shi'ido", "Shistavanen", "Sikan", "Sith", "Skakoan", "Sneevel", "Snivvian", "Squib", "Ssi-Ruuk", "Stereb", "Sullustan", "Talortai", "Talz", "Tarasin", "Taung", "Tauntaun", "Tchuukthai", "Teek", "Teevan", "Terentatek", "Thakwaash", "Theelin", "Thennqora", "Tiss'shar", "Thisspiasian", "Thrella", "Timoliini", "T'landa Til", "Tof", "Togorian", "Togruta", "Toong", "Toydarian", "Trandoshan", "Trianii", "Trogodile", "Troig", "Tunroth", "Ubese", "Ugnaught", "Umbaran", "Unu", "Utai", "Utapaun", "Vaathkree", "Vagaari", "Veknoid", "Vella", "Verpine", "Vodran", "Vor", "Voxyn", "Vratix", "Vulptereen", "Vurk", "Weequay", "Whaladon", "Wharl", "Whill", "Whiphid", "Wirutid", "Wol Cabasshite", "Wookiee", "Woostoid", "Wroonian", "X'ting", "Xexto", "Y'bith", "Yaka", "Yevetha", "Yinchorri", "Yuuzhan Vong", "Yuvernian", "Yuzzem", "Yuzzum", "Zeltron", "Zhell", "Zygerrian" };

			return names[Utility.RandomMinMax( 0, (names.Length-1) )];
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomWizardName()
		{
			string name = NameList.RandomName( "ancient lich" );

			switch( Utility.RandomMinMax( 1, 6 ) )
			{
				case 1: name = NameList.RandomName( "ancient lich" ); break;
				case 2: name = NameList.RandomName( "vampire" ); break;
				case 3: name = NameList.RandomName( "greek" ); break;
				case 4: name = NameList.RandomName( "drakkul" ); break;
				case 5: name = NameList.RandomName( "evil mage" ); break;
				case 6: name = NameList.RandomName( "evil witch" ); break;
			}

			if ( name == null || name == "" ){ name = NameList.RandomName( "male" ); }

			return name;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetBoyGirlJob( int gender )
		{
			string girlJob = "Healer";
			string boyJob = "Healer";

			switch( Utility.RandomMinMax( 1, 46 ) )
			{
				case 1: girlJob = "Adventurer"; boyJob = "Adventurer"; break;
				case 2: girlJob = "Bandit"; boyJob = "Bandit"; break;
				case 3: girlJob = "Barbarian"; boyJob = "Barbarian"; break;
				case 4: girlJob = "Bard"; boyJob = "Bard"; break;
				case 5: girlJob = "Amazon"; boyJob = "Cavalier"; break;
				case 6: girlJob = "Cleric"; boyJob = "Cleric"; break;
				case 7: girlJob = "Conjurer"; boyJob = "Conjurer"; break;
				case 8: girlJob = "Defender"; boyJob = "Defender"; break;
				case 9: girlJob = "Diviner"; boyJob = "Diviner"; break;
				case 10: girlJob = "Druid"; boyJob = "Druid"; break;
				case 11: girlJob = "Enchantress"; boyJob = "Enchanter"; break;
				case 12: girlJob = "Explorer"; boyJob = "Explorer"; break;
				case 13: girlJob = "Fighter"; boyJob = "Fighter"; break;
				case 14: girlJob = "Gladiator"; boyJob = "Gladiator"; break;
				case 15: girlJob = "Heretic"; boyJob = "Heretic"; break;
				case 16: girlJob = "Hunter"; boyJob = "Hunter"; break;
				case 17: girlJob = "Illusionist"; boyJob = "Illusionist"; break;
				case 18: girlJob = "Invoker"; boyJob = "Invoker"; break;
				case 19: girlJob = "Knight"; boyJob = "Knight"; break;
				case 20: girlJob = "Mage"; boyJob = "Mage"; break;
				case 21: girlJob = "Magician"; boyJob = "Magician"; break;
				case 22: girlJob = "Mercenary"; boyJob = "Mercenary"; break;
				case 23: girlJob = "Minstrel"; boyJob = "Minstrel"; break;
				case 24: girlJob = "Monk"; boyJob = "Monk"; break;
				case 25: girlJob = "Mystic"; boyJob = "Mystic"; break;
				case 26: girlJob = "Necromancer"; boyJob = "Necromancer"; break;
				case 27: girlJob = "Outlaw"; boyJob = "Outlaw"; break;
				case 28: girlJob = "Paladin"; boyJob = "Paladin"; break;
				case 29: girlJob = "Priestess"; boyJob = "Priest"; break;
				case 30: girlJob = "Prophetess"; boyJob = "Prophet"; break;
				case 31: girlJob = "Ranger"; boyJob = "Ranger"; break;
				case 32: girlJob = "Rogue"; boyJob = "Rogue"; break;
				case 33: girlJob = "Sage"; boyJob = "Sage"; break;
				case 34: girlJob = "Scout"; boyJob = "Scout"; break;
				case 35: girlJob = "Seeker"; boyJob = "Seeker"; break;
				case 36: girlJob = "Seer"; boyJob = "Seer"; break;
				case 37: girlJob = "Shaman"; boyJob = "Shaman"; break;
				case 38: girlJob = "Slayer"; boyJob = "Slayer"; break;
				case 39: girlJob = "Sorcereress"; boyJob = "Sorcerer"; break;
				case 40: girlJob = "Summoner"; boyJob = "Summoner"; break;
				case 41: girlJob = "Templar"; boyJob = "Templar"; break;
				case 42: girlJob = "Thief"; boyJob = "Thief"; break;
				case 43: girlJob = "Traveler"; boyJob = "Traveler"; break;
				case 44: girlJob = "Warrior"; boyJob = "Warlock"; break;
				case 45: girlJob = "Witch"; boyJob = "Warrior"; break;
				case 46: girlJob = "Wizard"; boyJob = "Wizard"; break;
			}

			if ( gender == 1 ){ return girlJob; }

			return boyJob;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomKingdomName()
		{
			string name = NameList.RandomName( "vampire" );

			switch( Utility.RandomMinMax( 1, 27 ) )
			{
				case 1: name = NameList.RandomName( "vampire" ); break;
				case 2: name = NameList.RandomName( "drakkul" ); break;
				case 3: name = NameList.RandomName( "imp" ); break;
				case 4: name = NameList.RandomName( "druid" ); break;
				case 5: name = NameList.RandomName( "ork" ); break;
				case 6: name = NameList.RandomName( "dragon" ); break;
				case 7: name = NameList.RandomName( "goddess" ); break;
				case 8: name = NameList.RandomName( "demonic" ); break;
				case 9: name = NameList.RandomName( "ork_male" ); break;
				case 10: name = NameList.RandomName( "ork_female" ); break;
				case 11: name = NameList.RandomName( "barb_male" ); break;
				case 12: name = NameList.RandomName( "barb_female" ); break;
				case 13: name = NameList.RandomName( "ancient lich" ); break;
				case 14: name = NameList.RandomName( "demon knight" ); break;
				case 15: name = NameList.RandomName( "shadow knight" ); break;
				case 16: name = NameList.RandomName( "gargoyle vendor" ); break;
				case 17: name = NameList.RandomName( "gargoyle name" ); break;
				case 18: name = NameList.RandomName( "centaur" ); break;
				case 19: name = NameList.RandomName( "pixie" ); break;
				case 20: name = NameList.RandomName( "golem controller" ); break;
				case 21: name = NameList.RandomName( "lizardman" ); break;
				case 22: name = NameList.RandomName( "devil" ); break;
				case 23: name = NameList.RandomName( "evil mage" ); break;
				case 24: name = NameList.RandomName( "evil witch" ); break;
				case 25: name = NameList.RandomName( "elf_male" ); break;
				case 26: name = NameList.RandomName( "elf_female" ); break;
				case 27: name = NameList.RandomName( "greek" ); break;
			}

			return name;
		}

		public static string GetRandomKingdom()
		{
			string kingdom = "Kingdom";

			switch( Utility.RandomMinMax( 1, 13 ) )
			{
				case 1: kingdom = "Kingdom"; break;
				case 2: kingdom = "Dynasty"; break;
				case 3: kingdom = "Empire"; break;
				case 4: kingdom = "Dominion"; break;
				case 5: kingdom = "Sovereignty"; break;
				case 6: kingdom = "Regime"; break;
				case 7: kingdom = "Reign"; break;
				case 8: kingdom = "Nation"; break;
				case 9: kingdom = "Monarchy"; break;
				case 10: kingdom = "Realm"; break;
				case 11: kingdom = "Territory"; break;
				case 12: kingdom = "Lands"; break;
				case 13: kingdom = "Islands"; break;
			}

			return kingdom;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomOrientalName()
		{
			string name = NameList.RandomName( "tokuno male" );

			switch( Utility.RandomMinMax( 1, 4 ) )
			{
				case 1: name = NameList.RandomName( "tokuno male" ); break;
				case 2: name = NameList.RandomName( "tokuno female" ); break;
				case 3: name = NameList.RandomName( "drakkul" ); break;
				case 4: name = NameList.RandomName( "goddess" ); break;
			}

			if ( name == null || name == "" ){ name = NameList.RandomName( "tokuno male" ); }

			return name;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomOrientalNation()
		{
			string name = NameList.RandomName( "dark_elf_prefix_female" );

			switch( Utility.RandomMinMax( 1, 2 ) )
			{
				case 1: name = NameList.RandomName( "dark_elf_prefix_female" ); break;
				case 2: name = NameList.RandomName( "dark_elf_prefix_male" ); break;
			}

			if ( name == null || name == "" ){ name = NameList.RandomName( "dark_elf_prefix_female" ); }

			switch( Utility.RandomMinMax( 1, 2 ) )
			{
				case 1: name = name + "anese"; break;
				case 2: name = name + "ist"; break;
			}

			return name;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomBookType( bool caps )
		{
			string book = "book";

			int tome = Utility.RandomMinMax( 0, 6 );
				if ( caps ){ Utility.RandomMinMax( 7, 13 ); }

			switch ( tome ) 
			{
				case 0 : book = "book"; break;
				case 1 : book = "lexicon"; break;
				case 2 : book = "omnibus"; break;
				case 3 : book = "manual"; break;
				case 4 : book = "folio"; break;
				case 5 : book = "codex"; break;
				case 6 : book = "tome"; break;
				case 7 : book = "Book"; break;
				case 8 : book = "Lexicon"; break;
				case 9 : book = "Omnibus"; break;
				case 10 : book = "Manual"; break;
				case 11 : book = "Folio"; break;
				case 12 : book = "Codex"; break;
				case 13 : book = "Tome"; break;
			}

			return book;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetBookTitle()
		{
			string bookTitle = "the Book of the Dead";

			string[] vName1 = new string[] {"Exotic", "Mysterious", "Enchanted", "Marvelous", "Amazing", "Astonishing", "Mystical", "Astounding", "Magical", "Divine", "Excellent", "Magnificent", "Phenomenal", "Fantastic", "Incredible", "Miraculous", "Extraordinary", "Fabulous", "Wondrous", "Glorious", "Dreadful", "Horrific", "Terrible", "Disturbing", "Frightful", "Awful", "Dire", "Grim", "Vile", "Lost", "Fabled", "Legendary", "Mythical", "Missing", "Doomed", "Endless", "Eternal", "Exalted", "Glimmering", "Sadistic", "Disrupting", "Spiritual", "Demonic", "Holy", "Heavenly", "Ancestral", "Ornate", "Ultimate", "Abyssmal", "Crazed", "Elven", "Orcish", "Dwarvish", "Gnomish", "Cursed", "Sylvan", "Wizardly", "Sturdy", "Disturbing", "Odd", "Rare", "Treasured", "Damned", "Evil", "Lawful", "Foul", "Infernal", "Royal", "Worldy", "Blasphemous", "Planar", "Wonderful", "Perfected", "Vicious", "Chaotic", "Haunted", "Travelling", "Unholy", "Infernal", "Villainous", "Accursed", "Fiendish", "Adored", "Hallowed", "Glorified", "Sacred", "Blissful", "Almighty", "Dominant", "Supreme", "Fallen", "Dark", "Earthly", "Mighty", "Unspeakable", "Unknown", "Forgotten", "Deathly", "Undead", "Infinite", "Abyssmal"};
				string sName1 = vName1[Utility.RandomMinMax( 0, (vName1.Length-1) )];

			string[] vName2 = new string[] {"Tale", "Book", "Adventures", "Lexicon", "Writings", "Omnibus", "Mystery", "Manual", "Folio", "Diary", "Tome", "Story", "Events", "History", "Chronicles", "Fable", "Legend", "Myth", "Secrets"};
				string sName2 = vName2[Utility.RandomMinMax( 0, (vName2.Length-1) )];

			string[] vName3 = new string[] {"Demon", "Devil", "Dragon", "Dwarf", "Elf", "Hag", "Hobbit", "Imp", "Leprechaun", "Vampire", "Ghost", "Lich", "Templar", "Thief", "Illusionist", "Princess", "Invoker", "Priest", "Conjurer", "Bandit", "Priestess", "Baron", "Wizard", "Cleric", "Monk", "Minstrel", "Defender", "Cavalier", "Magician", "Witch", "Fighter", "Seeker", "Slayer", "Ranger", "Barbarian", "Explorer", "Heretic", "Gladiator", "Sage", "Rogue", "Paladin", "Bard", "Diviner", "Lord", "Outlaw", "Prophet", "Mercenary", "Adventurer", "Enchanter", "King", "Scout", "Mystic", "Mage", "Traveler", "Summoner", "Queen", "Warrior", "Sorcerer", "Seer", "Hunter", "Knight", "Prince", "Necromancer", "Sorceress", "Shaman"};
				string sName3 = vName3[Utility.RandomMinMax( 0, (vName3.Length-1) )];

			string[] vName4 = new string[] {"Badger", "Basilisk", "Bear", "Boar", "Bufallo", "Bugbear", "Bull", "Centaur", "Chimera", "Cloud Giant", "Crocodile", "Cyclops", "Demon", "Devil", "Dog", "Dragon", "Drake", "Dryad", "Dwarf", "Elephant", "Elf", "Ettin", "Fire Giant", "Fish", "Frog", "Frost Giant", "Gargoyle", "Genie", "Gnoll", "Gnome", "Goblin", "Gorgon", "Griffin", "Hag", "Hobbit", "Harpy", "Hell Hound", "Hill Giant", "Hippogriff", "Hippopotamus", "Hobbit", "Hobgoblin", "Horse", "Hydra", "Imp", "Jackal", "Kobold", "Kraken", "Leprechaun", "Lion", "Lizard", "Manticore", "Imp", "Minotaur", "Mule", "Naga", "Nixie", "Nymph", "Froglok", "Ogre", "Orc", "Owlbear", "Pegasus", "Phoenix", "Pixie", "Giant Worm", "Dark Pixie", "Rot Monster", "Scorpion", "Serpent", "Reaper", "Snake", "Sphinx", "Spider", "Sprite", "Stone Giant", "Storm Giant", "Succubus", "Tiger", "Titan", "Toad", "Ent", "Neptar", "Troglodite", "Troll", "Turtle", "Unicorn", "Walrus", "Weasel", "Werewolf", "Whale", "Wisp", "Wolf", "Wolverine", "Wyrm", "Wyvern", "Zorn", "Yeti", "Templar", "Thief", "Illusionist", "Princess", "Invoker", "Priest", "Conjurer", "Bandit", "Priestess", "Baron", "Wizard", "Cleric", "Monk", "Minstrel", "Defender", "Cavalier", "Magician", "Witch", "Fighter", "Seeker", "Slayer", "Ranger", "Barbarian", "Explorer", "Heretic", "Gladiator", "Sage", "Rogue", "Paladin", "Bard", "Diviner", "Lord", "Outlaw", "Prophet", "Mercenary", "Adventurer", "Enchanter", "King", "Scout", "Mystic", "Mage", "Traveler", "Summoner", "Queen", "Warrior", "Sorcerer", "Seer", "Hunter", "Knight", "Prince", "Necromancer", "Sorceress", "Shaman"};
				string sName4 = vName4[Utility.RandomMinMax( 0, (vName4.Length-1) )];

			string[] vName5 = new string[] {"Castle", "Cave", "Mansion", "House", "Cave", "Dungeon", "Forest", "Desert", "Tower", "Desert", "Mountains", "Swamp", "Hills", "Night", "Darkness", "Fog", "Woods", "Mist", "Light", "Bottle", "Sky", "Ground", "Water", "Sea", "Sand", "Trees", "Clouds", "Stars", "Crystal", "Gem", "Lamp", "Jar", "Chains", "Keep", "City", "Village", "Tomb", "Crypt"};
				string sName5 = vName5[Utility.RandomMinMax( 0, (vName5.Length-1) )];

			string sName6 = NameList.RandomName( "author" );

			string[] vName7 = new string[] {"Goblet", "Sword", "Axe", "Dagger", "Armor", "Crystal", "Gem", "Pool", "Wand", "Ring", "Amulet", "Helm", "Crown", "Boots", "Belt", "Robe", "Chalice", "Mirror", "Lance", "Shield", "Scepter", "Staff", "Book", "Potion", "Bow", "Stone", "Fire", "Shard", "Box"};
				string sName7 = vName7[Utility.RandomMinMax( 0, (vName7.Length-1) )];

			string[] vName8 = new string[] {"Search", "Quest", "Curse", "Magic", "Mystery", "Power", "Destruction", "Murder", "Desire", "Nature", "Legend", "Myth", "Lies", "Location"};
				string sName8 = vName8[Utility.RandomMinMax( 0, (vName8.Length-1) )];

			switch ( Utility.RandomMinMax( 0, 10 ) ) 
			{
				case 0: bookTitle = "The " + sName1 + " " + sName2 + " of the " + sName4; break;
				case 1: bookTitle = "The " + sName2 + " of the " + sName1 + " " + sName4; break;
				case 2: bookTitle = "The " + sName4 + " in the " + sName5; break;
				case 3: bookTitle = "The " + sName2 + " of the " + sName3 + " in the " + sName5; break;
				case 4: bookTitle = "The " + sName1 + " " + sName5 + " of the " + sName3; break;
				case 5: bookTitle = "The " + sName8 + " of the " + sName1 + " " + sName7 + " of " + sName6; break;
				case 6: bookTitle = "The " + sName8 + " of the " + sName7 + " of " + sName6; break;
				case 7: bookTitle = "The " + sName7 + " and the " + sName3; break;
				case 8: bookTitle = "The " + sName3 + " and the " + sName7; break;
				case 9: bookTitle = "The " + sName2 + " of " + sName6 + " the " + sName3; break;
				case 10: bookTitle = "The " + sName2 + " of " + sName6 + " the " + sName3; break;
			}

			return bookTitle;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetSongTitle()
		{
			string bookTitle = "the Song of the Dead";

			string[] vName1 = new string[] {"Exotic", "Mysterious", "Enchanted", "Marvelous", "Amazing", "Astonishing", "Mystical", "Astounding", "Magical", "Divine", "Excellent", "Magnificent", "Phenomenal", "Fantastic", "Incredible", "Miraculous", "Extraordinary", "Fabulous", "Wondrous", "Glorious", "Dreadful", "Horrific", "Terrible", "Disturbing", "Frightful", "Awful", "Dire", "Grim", "Vile", "Lost", "Fabled", "Legendary", "Mythical", "Missing", "Doomed", "Endless", "Eternal", "Exalted", "Glimmering", "Sadistic", "Disrupting", "Spiritual", "Demonic", "Holy", "Heavenly", "Ancestral", "Ornate", "Ultimate", "Abyssmal", "Crazed", "Elven", "Orcish", "Dwarvish", "Gnomish", "Cursed", "Sylvan", "Wizardly", "Sturdy", "Disturbing", "Odd", "Rare", "Treasured", "Damned", "Evil", "Lawful", "Foul", "Infernal", "Royal", "Worldy", "Blasphemous", "Planar", "Wonderful", "Perfected", "Vicious", "Chaotic", "Haunted", "Travelling", "Unholy", "Infernal", "Villainous", "Accursed", "Fiendish", "Adored", "Hallowed", "Glorified", "Sacred", "Blissful", "Almighty", "Dominant", "Supreme", "Fallen", "Dark", "Earthly", "Mighty", "Unspeakable", "Unknown", "Forgotten", "Deathly", "Undead", "Infinite", "Abyssmal"};
				string sName1 = vName1[Utility.RandomMinMax( 0, (vName1.Length-1) )];

			string[] vName2 = new string[] {"Tale", "Legend", "Adventures", "Journey", "Quest", "Mystery", "Story", "Events", "History", "Chronicles", "Fable", "Myth", "Secrets"};
				string sName2 = vName2[Utility.RandomMinMax( 0, (vName2.Length-1) )];

			string[] vName3 = new string[] {"Demon", "Devil", "Dragon", "Dwarf", "Elf", "Hag", "Hobbit", "Imp", "Leprechaun", "Vampire", "Ghost", "Lich", "Templar", "Thief", "Illusionist", "Princess", "Invoker", "Priest", "Conjurer", "Bandit", "Priestess", "Baron", "Wizard", "Cleric", "Monk", "Minstrel", "Defender", "Cavalier", "Magician", "Witch", "Fighter", "Seeker", "Slayer", "Ranger", "Barbarian", "Explorer", "Heretic", "Gladiator", "Sage", "Rogue", "Paladin", "Bard", "Diviner", "Lord", "Outlaw", "Prophet", "Mercenary", "Adventurer", "Enchanter", "King", "Scout", "Mystic", "Mage", "Traveler", "Summoner", "Queen", "Warrior", "Sorcerer", "Seer", "Hunter", "Knight", "Prince", "Necromancer", "Sorceress", "Shaman"};
				string sName3 = vName3[Utility.RandomMinMax( 0, (vName3.Length-1) )];

			string[] vName4 = new string[] {"Badger", "Basilisk", "Bear", "Boar", "Bufallo", "Bugbear", "Bull", "Centaur", "Chimera", "Cloud Giant", "Crocodile", "Cyclops", "Demon", "Devil", "Dog", "Dragon", "Drake", "Dryad", "Dwarf", "Elephant", "Elf", "Ettin", "Fire Giant", "Fish", "Frog", "Frost Giant", "Gargoyle", "Genie", "Gnoll", "Gnome", "Goblin", "Gorgon", "Griffin", "Hag", "Hobbit", "Harpy", "Hell Hound", "Hill Giant", "Hippogriff", "Hippopotamus", "Hobbit", "Hobgoblin", "Horse", "Hydra", "Imp", "Jackal", "Kobold", "Kraken", "Leprechaun", "Lion", "Lizard", "Manticore", "Imp", "Minotaur", "Mule", "Naga", "Nixie", "Nymph", "Froglok", "Ogre", "Orc", "Owlbear", "Pegasus", "Phoenix", "Pixie", "Giant Worm", "Dark Pixie", "Rot Monster", "Scorpion", "Serpent", "Reaper", "Snake", "Sphinx", "Spider", "Sprite", "Stone Giant", "Storm Giant", "Succubus", "Tiger", "Titan", "Toad", "Ent", "Neptar", "Troglodite", "Troll", "Turtle", "Unicorn", "Walrus", "Weasel", "Werewolf", "Whale", "Wisp", "Wolf", "Wolverine", "Wyrm", "Wyvern", "Zorn", "Yeti", "Templar", "Thief", "Illusionist", "Princess", "Invoker", "Priest", "Conjurer", "Bandit", "Priestess", "Baron", "Wizard", "Cleric", "Monk", "Minstrel", "Defender", "Cavalier", "Magician", "Witch", "Fighter", "Seeker", "Slayer", "Ranger", "Barbarian", "Explorer", "Heretic", "Gladiator", "Sage", "Rogue", "Paladin", "Bard", "Diviner", "Lord", "Outlaw", "Prophet", "Mercenary", "Adventurer", "Enchanter", "King", "Scout", "Mystic", "Mage", "Traveler", "Summoner", "Queen", "Warrior", "Sorcerer", "Seer", "Hunter", "Knight", "Prince", "Necromancer", "Sorceress", "Shaman"};
				string sName4 = vName4[Utility.RandomMinMax( 0, (vName4.Length-1) )];

			string[] vName5 = new string[] {"Castle", "Cave", "Mansion", "House", "Cave", "Dungeon", "Forest", "Desert", "Tower", "Desert", "Mountains", "Swamp", "Hills", "Night", "Darkness", "Fog", "Woods", "Mist", "Light", "Bottle", "Sky", "Ground", "Water", "Sea", "Sand", "Trees", "Clouds", "Stars", "Crystal", "Gem", "Lamp", "Jar", "Chains", "Keep", "City", "Village", "Tomb", "Crypt"};
				string sName5 = vName5[Utility.RandomMinMax( 0, (vName5.Length-1) )];

			string sName6 = NameList.RandomName( "author" );

			string[] vName7 = new string[] {"Goblet", "Sword", "Axe", "Dagger", "Armor", "Crystal", "Gem", "Pool", "Wand", "Ring", "Amulet", "Helm", "Crown", "Boots", "Belt", "Robe", "Chalice", "Mirror", "Lance", "Shield", "Scepter", "Staff", "Book", "Potion", "Bow", "Stone", "Fire", "Shard", "Box"};
				string sName7 = vName7[Utility.RandomMinMax( 0, (vName7.Length-1) )];

			string[] vName8 = new string[] {"Search", "Quest", "Curse", "Magic", "Mystery", "Power", "Destruction", "Murder", "Desire", "Nature", "Legend", "Myth", "Lies", "Location"};
				string sName8 = vName8[Utility.RandomMinMax( 0, (vName8.Length-1) )];

			switch ( Utility.RandomMinMax( 0, 10 ) ) 
			{
				case 0: bookTitle = "the " + sName1 + " " + sName2 + " of the " + sName4; break;
				case 1: bookTitle = "the " + sName2 + " of the " + sName1 + " " + sName4; break;
				case 2: bookTitle = "the " + sName4 + " in the " + sName5; break;
				case 3: bookTitle = "the " + sName2 + " of the " + sName3 + " in the " + sName5; break;
				case 4: bookTitle = "the " + sName1 + " " + sName5 + " of the " + sName3; break;
				case 5: bookTitle = "the " + sName8 + " of the " + sName1 + " " + sName7 + " of " + sName6; break;
				case 6: bookTitle = "the " + sName8 + " of the " + sName7 + " of " + sName6; break;
				case 7: bookTitle = "the " + sName7 + " and the " + sName3; break;
				case 8: bookTitle = "the " + sName3 + " and the " + sName7; break;
				case 9: bookTitle = "the " + sName2 + " of " + sName6 + " the " + sName3; break;
				case 10: bookTitle = "the " + sName2 + " of " + sName6 + " the " + sName3; break;
			}

			return bookTitle;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomScenePainting()
		{
			string sceneType = "Hills";
			string sceneName = "Giant";
			string sceneFinal = "the Hills of Iron";

			switch( Utility.RandomMinMax( 1, 11 ) )
			{
				case 1: sceneType = "Hills"; break;
				case 2: sceneType = "Forest"; break;
				case 3: sceneType = "Woods"; break;
				case 4: sceneType = "Glade"; break;
				case 5: sceneType = "Fields"; break;
				case 6: sceneType = "Mountains"; break;
				case 7: sceneType = "Barrens"; break;
				case 8: sceneType = "Desert"; break;
				case 9: sceneType = "Grasslands"; break;
				case 10: sceneType = "Jungle"; break;
				case 11: sceneType = "Land"; break;
			}

			switch( Utility.RandomMinMax( 1, 5 ) )
			{
				case 1: sceneName = GetRandomJobTitle(0); 	sceneFinal = "the " + sceneType + " of the " + sceneName + "";								break;
				case 2: sceneName = GetRandomColorName(0); 	sceneFinal = "the " + sceneType + " of the " + sceneName + " " + GetRandomThing(0);			break;
				case 3: sceneName = GetRandomThing(0); 		sceneFinal = "the " + sceneType + " of the " + sceneName + "";								break;
				case 4: sceneName = GetRandomName(); 		sceneFinal = "the " + sceneType + " of " + sceneName + "";									break;
				case 5: sceneName = GetRandomCreature(); 	sceneFinal = "the " + sceneType + " of the " + sceneName + "";
					if ( Utility.RandomMinMax( 1, 3 ) == 1 ){ sceneFinal = "the " + sceneType + " of the " + GetRandomColorName(0) + " " + sceneName + ""; }
					break;
			}

			if ( Utility.RandomMinMax( 1, 2 ) == 1 ){ sceneFinal = "the " + sceneName + " " + sceneType + ""; }

			return sceneFinal;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomSociety()
		{
			string[] vName1 = new string[] {"Alliance", "Assembly", "Band", "Chain", "Church", "Circle", "Clan", "Coalition", "Faction", "Family", "Fellowship", "Followers", "Fraternity", "Guild", "League", "Legion", "Order", "Society", "Soldiers", "Syndicate", "Union"};
				string sName1 = vName1[Utility.RandomMinMax( 0, (vName1.Length-1) )];

			string[] vName2 = new string[] {"of the", "for the", "against the", "with the", "under the", "beneath the", "over the", "above the"};
				string sName2 = vName2[Utility.RandomMinMax( 0, (vName2.Length-1) )] + " ";

			string[] vName3 = new string[] {"Almighty", "Amazing", "Amber", "Ancestral", "Angelic", "Astonishing", "Astounding", "Azure", "Black", "Blackened", "Blessed", "Blue", "Bright", "Bronze", "Brown", "Burning", "Clear", "Copper", "Crystal", "Cursed", "Damned", "Dark", "Deathly", "Demonic", "Diamond", "Divine", "Doomed", "Electrical", "Emerald", "Enchanted", "Ethereal", "Evil", "Excellent", "Exotic", "Extraordinary", "Fabled", "Fabulous", "Fantastic", "Forgotten", "Frozen", "Glorious", "Glowing", "Gold", "Grand", "Gray", "Great", "Green", "Hexed", "High", "Holy", "Icy", "Incredible", "Indigo", "Infernal", "Ivory", "Jade", "Legendary", "Lost", "Lunar", "Magical", "Magnificent", "Maroon", "Marvelous", "Mighty", "Missing", "Mysterious", "Mystical", "Mythical", "Orange", "Ornate", "Phenomenal", "Platinum", "Purple", "Rare", "Red", "Ruby", "Sacred", "Sapphire", "Scarlet", "Secluded", "Secret", "Silver", "Solar", "Supreme", "Tan", "Twisted", "Ultimate", "Unholy", "Unknown", "Unspeakable", "Velvet", "Vile", "Violet", "White", "Wonderful", "Wondrous", "Yellow"};
				string sName3 = vName3[Utility.RandomMinMax( 0, (vName3.Length-1) )] + " ";
					if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ sName3 = ""; }
				string sName4 = vName3[Utility.RandomMinMax( 0, (vName3.Length-1) )] + " ";
					if ( Utility.RandomMinMax( 0, 1 ) == 1 && sName3 != "" ){ sName4 = ""; }

			string[] vName4 = new string[] {"Adventurer", "Amulet", "Armor", "Axe", "Bag", "Bandit", "Barbarian", "Bard", "Baron", "Beast", "Belt", "Blade", "Bones", "Book", "Boots", "Bottle", "Bow", "Bracelet", "Candle", "Cape", "Castle", "Cavalier", "Chalice", "Cleric", "Cloak", "Cloth", "Club", "Conjurer", "Crown", "Cutlass", "Dagger", "Defender", "Diviner", "Dragon", "Drum", "Dust", "Element", "Enchanter", "Explorer", "Eye", "Fighter", "Flute", "Gem", "Gladiator", "Glove", "Goblet", "Grave", "Halberd", "Hammer", "Hand", "Hat", "Heart", "Helm", "Heretic", "Horn", "Hunter", "Illusionist", "Invoker", "Key", "King", "Kingdom", "Knife", "Knight", "Kryss", "Labyrinth", "Lantern", "Light", "Lord", "Lute", "Mace", "Mage", "Magician", "Mercenary", "Minstrel", "Mirror", "Monk", "Moon", "Mystic", "Nail", "Necromancer", "Orb", "Outlaw", "Paladin", "Potion", "Pouch", "Priest", "Prince", "Prophet", "Ranger", "Riddle", "Ring", "Robe", "Rogue", "Rope", "Sage", "Scabbard", "Sceptre", "Scimitar", "Scout", "Scroll", "Seeker", "Seer", "Shackles", "Shaman", "Shield", "Skull", "Sky", "Slayer", "Sorcerer", "Staff", "Star", "Stone", "Summoner", "Sun", "Sword", "Templar", "Temple", "Thief", "Tomb", "Tome", "Tower", "Traveler", "Tree", "Trident", "Unicorn", "Wand", "Warlock", "Warrior", "Wind", "Wizard", "Word"};
				string sName5 = vName4[Utility.RandomMinMax( 0, (vName4.Length-1) )];

			string nSociety = "the '" + sName3 + sName1 + " " + sName2 + sName4 + sName5 + "'";

			return nSociety;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomJobTitle( int space )
		{
			string[] vTitle = new string[] {"Adventurer", "Bandit", "Barbarian", "Bard", "Baron", "Baroness", "Cavalier", "Cleric", "Conjurer", "Defender", "Diviner", "Druid", "Enchanter", "Enchantress", "Explorer", "Fighter", "Gladiator", "Heretic", "Hunter", "Illusionist", "Invoker", "King", "Knight", "Lady", "Lord", "Mage", "Magician", "Mercenary", "Minstrel", "Monk", "Mystic", "Necromancer", "Outlaw", "Paladin", "Priest", "Priestess", "Prince", "Princess", "Prophet", "Queen", "Ranger", "Rogue", "Sage", "Scout", "Seeker", "Seer", "Shaman", "Slayer", "Sorcerer", "Sorcereress", "Summoner", "Templar", "Thief", "Traveler", "Warlock", "Warrior", "Witch", "Wizard"};
				string sTitle = "the " + vTitle[Utility.RandomMinMax( 0, (vTitle.Length-1) )];
				if ( space > 0 ){ sTitle = sTitle + " "; }

			return sTitle;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomColorName( int space )
		{
			string[] vColor = new string[] {"Amber", "Azure", "Black", "Blue", "Bright", "Bronze", "Brown", "Burning", "Copper", "Crystal", "Dark", "Diamond", "Emerald", "Frozen", "Glowing", "Gold", "Gray", "Green", "Icy", "Indigo", "Ivory", "Jade", "Maroon", "Orange", "Platinum", "Purple", "Red", "Ruby", "Sapphire", "Scarlet", "Silver", "Velvet", "Violet", "White", "Yellow"};
				string sColor = vColor[Utility.RandomMinMax( 0, (vColor.Length-1) )];
				if ( space > 0 ){ sColor = sColor + " "; }

			return sColor;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomThing( int space )
		{
			string[] vThing = new string[] {"Adventurer", "Amulet", "Armor", "Axe", "Bandit", "Barbarian", "Bard", "Baron", "Beast", "Belt", "Blade", "Bones", "Boots", "Bottle", "Bow", "Bracelet", "Candle", "Cavalier", "Chalice", "Cleric", "Club", "Conjurer", "Crown", "Cutlass", "Dagger", "Defender", "Diviner", "Dragon", "Drum", "Element", "Enchanter", "Explorer", "Eye", "Fighter", "Flute", "Gladiator", "Goblet", "Halberd", "Hammer", "Hand", "Heart", "Helm", "Heretic", "Horn", "Hunter", "Illusionist", "Invoker", "Key", "King", "Knife", "Knight", "Kryss", "Lantern", "Lord", "Lute", "Mace", "Mage", "Magician", "Mercenary", "Minstrel", "Monk", "Mystic", "Nail", "Necromancer", "Orb", "Outlaw", "Paladin", "Priest", "Prince", "Prophet", "Ranger", "Ring", "Robe", "Rogue", "Sage", "Scabbard", "Sceptre", "Scimitar", "Scout", "Seeker", "Seer", "Shackles", "Shaman", "Shield", "Skull", "Slayer", "Sorcerer", "Staff", "Stone", "Summoner", "Sword", "Templar", "Thief", "Tower", "Traveler", "Tree", "Trident", "Unicorn", "Wand", "Warlock", "Warrior", "Wizard"};
				string sThing = vThing[Utility.RandomMinMax( 0, (vThing.Length-1) )];
				if ( space > 0 ){ sThing = sThing + " "; }

			return sThing;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomMonsters()
		{
			string[] vThing = new string[] {"a balrog", "a balron", "a bandit", "a barbarian", "a beholder", "a bugbear", "a chimera", "a cyclops", "a daemon", "a demon", "a devil", "a dracolich", "a dragon", "a dragon turtle", "a drake", "a dreadhorn", "a drow", "a gargoyle", "a gazer", "a ghost", "a ghoul", "a giant", "a giant beetle", "a giant crab", "a giant eel", "a giant scorpion", "a giant serpent", "a giant spider", "a giant squid", "a gnoll", "a gnome", "a goblin", "a golem", "a gorgon", "a griffon", "a hag", "a harpy", "a hippogriff", "a hobgoblin", "a hydra", "a kobold", "a kraken", "a leviathan", "a lich", "a lizardman", "a manticore", "a mind flayer", "a minotaur", "a morlock", "a mummy", "a naga", "a nazghoul", "a phantom", "a ratman", "a reaper", "a savage", "a slime", "a sphinx", "a sprite", "a succubus", "a terathan", "a tritun", "a troll", "a vampire", "a warrior", "a wight", "a witch", "a wizard", "a wyrm", "a wyvern", "a xorn", "a yeti", "a zombie", "an efreet", "an elemental", "an ettin", "an ifreet", "an imp", "an ogre", "an ophidian", "an orc", "an umber hulk"};
				string sThing = vThing[Utility.RandomMinMax( 0, (vThing.Length-1) )];

			return sThing;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomAttackers()
		{
			string[] vThing = new string[] {"balrogs", "balrons", "bandits", "barbarians", "bugbears", "daemons", "demons", "drow", "ettins", "giants", "gnolls", "gnomes", "goblins", "hobgoblins", "kobolds", "lizardmen", "minotaurs", "ogres", "ophidians", "orcs", "ratmen", "savages", "terathans", "trituns", "trolls"};
				string sThing = vThing[Utility.RandomMinMax( 0, (vThing.Length-1) )];

			return sThing;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomTroops()
		{
			string[] vThing = new string[] {"army", "soldiers", "troops", "balrogs", "balrons", "bandits", "barbarians", "bugbears", "daemons", "demons", "drow", "ettins", "giants", "gnolls", "gnomes", "goblins", "hobgoblins", "kobolds", "lizardmen", "minotaurs", "ogres", "ophidians", "orcs", "ratmen", "savages", "terathans", "trituns", "trolls", "wizards"};
				string sThing = vThing[Utility.RandomMinMax( 0, (vThing.Length-1) )];

			return sThing;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomCoinReward()
		{
			string[] vThing = new string[] {"500", "600", "700", "800", "900", "1,000", "1,100", "1,200", "1,300", "1,400", "1,500", "1,600", "1,700", "1,800", "1,900", "2,000", "2,100", "2,200", "2,300", "2,400", "2,500", "2,600", "2,700", "2,800", "2,900", "3,000", "3,100", "3,200", "3,300", "3,400", "3,500", "3,600", "3,700", "3,800", "3,900", "4,000", "4,100", "4,200", "4,300", "4,400", "4,500", "4,600", "4,700", "4,800", "4,900", "5,000", "5,100", "5,200", "5,300", "5,400", "5,500", "5,600", "5,700", "5,800", "5,900", "6,000", "6,100", "6,200", "6,300", "6,400", "6,500", "6,600", "6,700", "6,800", "6,900", "7,000", "7,100", "7,200", "7,300", "7,400", "7,500", "7,600", "7,700", "7,800", "7,900", "8,000", "8,100", "8,200", "8,300", "8,400", "8,500", "8,600", "8,700", "8,800", "8,900", "9,000", "9,100", "9,200", "9,300", "9,400", "9,500", "9,600", "9,700", "9,800", "9,900", "10,000"};
				string sThing = vThing[Utility.RandomMinMax( 0, (vThing.Length-1) )];

			return sThing;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomJob()
		{
			string sJob = "tinker";
			int section = Utility.RandomMinMax( 1, 23 );
			switch( section )
			{
				case 1: sJob = "blacksmith"; break;
				case 2: sJob = "jeweler"; break;
				case 3: sJob = "provisioner"; break;
				case 4: sJob = "banker"; break;
				case 5: sJob = "minter"; break;
				case 6: sJob = "waiter"; break;
				case 7: sJob = "guard"; break;
				case 8: sJob = "sage"; break;
				case 9: sJob = "mage"; break;
				case 10: sJob = "herbalist"; break;
				case 11: sJob = "alchemist"; break;
				case 12: sJob = "healer"; break;
				case 13: sJob = "guildmaster"; break;
				case 14: sJob = "tinker"; break;
				case 15: sJob = "innkeeper"; break;
				case 16: sJob = "bartender"; break;
				case 17: sJob = "butcher"; break;
				case 18: sJob = "tailor"; break;
				case 19: sJob = "weaver"; break;
				case 20: sJob = "shipwright"; break;
				case 21: sJob = "scribe"; break;
				case 22: sJob = "farmer"; break;
				case 23: sJob = "stable master"; break;
			}

			return sJob;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomShop()
		{
			string sType = "shop";
			switch( Utility.RandomMinMax( 0, 3 ) )
			{
				case 1: sType = "store"; break;
				case 2: sType = "shoppe"; break;
				case 3: sType = "market"; break;
			}
			string sJob = "tinker";
			switch( Utility.RandomMinMax( 1, 24 ) )
			{
				case 1: sJob = "a blacksmith " + sType; break;
				case 2: sJob = "a jewelry " + sType; break;
				case 3: sJob = "a provision " + sType; break;
				case 4: sJob = "a leather " + sType; break;
				case 5: sJob = "a music " + sType; break;
				case 6: sJob = "an alchemy " + sType; break;
				case 7: sJob = "a potion " + sType; break;
				case 8: sJob = "a book " + sType; break;
				case 9: sJob = "a magic " + sType; break;
				case 10: sJob = "an herb " + sType; break;
				case 11: sJob = "a garden " + sType; break;
				case 12: sJob = "an animal " + sType; break;
				case 13: sJob = "a tailor " + sType; break;
				case 14: sJob = "an inn"; break;
				case 15: sJob = "a tavern"; break;
				case 16: sJob = "a bank"; break;
				case 17: sJob = "a butcher " + sType; break;
				case 18: sJob = "a shipbuilding " + sType; break;
				case 19: sJob = "a scribe " + sType; break;
				case 20: sJob = "a guild"; break;
				case 21: sJob = "a cult"; break;
				case 22: sJob = "a church"; break;
				case 23: sJob = "a stable"; break;
				case 24: sJob = "a library"; break;
			}

			return sJob;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomGemType( string category )
		{
			string sGem = "ruby";

			int section = Utility.RandomMinMax( 1, 18 );
			if ( category == "dragyns" ){ section = Utility.RandomMinMax( 1, 12 ); }

			switch( section )
			{
				case 1: sGem = "ruby"; break;
				case 2: sGem = "jade"; break;
				case 3: sGem = "quartz"; break;
				case 4: sGem = "sapphire"; break;
				case 5: sGem = "onyx"; break;
				case 6: sGem = "spinel"; break;
				case 7: sGem = "topaz"; break;
				case 8: sGem = "amethyst"; break;
				case 9: sGem = "emerald"; break;
				case 10: sGem = "garnet"; break;
				case 11: sGem = "silver"; break;
				case 12: sGem = "star ruby"; break;
				case 13: sGem = "star sapphire"; break;
				case 14: sGem = "citrine"; break;
				case 15: sGem = "caddellite"; break;
				case 16: sGem = "amber"; break;
				case 17: sGem = "diamond"; break;
				case 18: sGem = "tourmaline"; break;
			}

			return sGem;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomCity()
		{
			string sPlace = "Britain";
			int section = Utility.RandomMinMax( 1, 23 );
			switch( section )
			{
				case 1: sPlace = "Britain"; break;
				case 2: sPlace = "Fawn"; break;
				case 3: sPlace = "Grey"; break;
				case 4: sPlace = "Moon"; break;
				case 5: sPlace = "Yew"; break;
				case 6: sPlace = "Montor"; break;
				case 7: sPlace = "Umbra"; break;
				case 8: sPlace = "Devil Guard"; break;
				case 9: sPlace = "Death Gulch"; break;
				case 10: sPlace = "Renika"; break;
				case 11: sPlace = "Glacial Hills"; break;
				case 12: sPlace = "Springvale"; break;
				case 13: sPlace = "Elidor"; break;
				case 14: sPlace = "Islegem"; break;
				case 15: sPlace = "the Port of Dusk"; break;
				case 16: sPlace = "the Port of Starguide"; break;
				case 17: sPlace = "Portshine"; break;
				case 18: sPlace = "Greensky Village"; break;
				case 19: sPlace = "the City of Lodoria"; break;
				case 20: sPlace = "the Cimmeran Hold"; break;
				case 21: sPlace = "the Village of Barako"; break;
				case 22: sPlace = "the Village of Kurak"; break;
				case 23: sPlace = "Kuldara"; break;
			}

			return sPlace;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomCreature()
		{
			string sCreature = "Giant";
			int section = Utility.RandomMinMax( 0, 120 );
			switch( section )
			{
				case 0: sCreature = "Ant"; break;
				case 1: sCreature = "Ape"; break;
				case 2: sCreature = "Baboon"; break;
				case 3: sCreature = "Badger"; break;
				case 4: sCreature = "Basilisk"; break;
				case 5: sCreature = "Bear"; break;
				case 6: sCreature = "Beaver"; break;
				case 7: sCreature = "Beetle"; break;
				case 8: sCreature = "Beholder"; break;
				case 9: sCreature = "Boar"; break;
				case 10: sCreature = "Brownie"; break;
				case 11: sCreature = "Buffalo"; break;
				case 12: sCreature = "Bull"; break;
				case 13: sCreature = "Camel"; break;
				case 14: sCreature = "Centaur"; break;
				case 15: sCreature = "Centipede"; break;
				case 16: sCreature = "Chimera"; break;
				case 17: sCreature = "Cockatrice"; break;
				case 18: sCreature = "Crocodile"; break;
				case 19: sCreature = "Deer"; break;
				case 20: sCreature = "Demon"; break;
				case 21: sCreature = "Devil"; break;
				case 22: sCreature = "Dinosaur"; break;
				case 23: sCreature = "Djinni"; break;
				case 24: sCreature = "Dog"; break;
				case 25: sCreature = "Dragon"; break;
				case 26: sCreature = "Dryad"; break;
				case 27: sCreature = "Dwarf"; break;
				case 28: sCreature = "Eagle"; break;
				case 29: sCreature = "Efreet"; break;
				case 30: sCreature = "Elemental"; break;
				case 31: sCreature = "Elephant"; break;
				case 32: sCreature = "Elf"; break;
				case 33: sCreature = "Ettin"; break;
				case 34: sCreature = "Frog"; break;
				case 35: sCreature = "Fungi"; break;
				case 36: sCreature = "Gargoyle"; break;
				case 37: sCreature = "Ghast"; break;
				case 38: sCreature = "Ghost"; break;
				case 39: sCreature = "Ghoul"; break;
				case 40: sCreature = "Giant"; break;
				case 41: sCreature = "Gnoll"; break;
				case 42: sCreature = "Gnome"; break;
				case 43: sCreature = "Goat"; break;
				case 44: sCreature = "Goblin"; break;
				case 45: sCreature = "Golem"; break;
				case 46: sCreature = "Gorgon"; break;
				case 47: sCreature = "Griffon"; break;
				case 48: sCreature = "Hag"; break;
				case 49: sCreature = "Halfling"; break;
				case 50: sCreature = "Harpy"; break;
				case 51: sCreature = "Hell Hound"; break;
				case 52: sCreature = "Hippogriff"; break;
				case 53: sCreature = "Hippopotamus"; break;
				case 54: sCreature = "Hobgoblin"; break;
				case 55: sCreature = "Horse"; break;
				case 56: sCreature = "Hydra"; break;
				case 57: sCreature = "Hyena"; break;
				case 58: sCreature = "Imp"; break;
				case 59: sCreature = "Jackal"; break;
				case 60: sCreature = "Jaguar"; break;
				case 61: sCreature = "Ki-rin"; break;
				case 62: sCreature = "Kobold"; break;
				case 63: sCreature = "Leopard"; break;
				case 64: sCreature = "Leprechaun"; break;
				case 65: sCreature = "Lich"; break;
				case 66: sCreature = "Lion"; break;
				case 67: sCreature = "Lizard"; break;
				case 68: sCreature = "Lizardman"; break;
				case 69: sCreature = "Lycanthrope"; break;
				case 70: sCreature = "Lynx"; break;
				case 71: sCreature = "Mammoth"; break;
				case 72: sCreature = "Manticore"; break;
				case 73: sCreature = "Mastodon"; break;
				case 74: sCreature = "Medusa"; break;
				case 75: sCreature = "Minotaur"; break;
				case 76: sCreature = "Mule"; break;
				case 77: sCreature = "Mummy"; break;
				case 78: sCreature = "Naga"; break;
				case 79: sCreature = "Nightmare"; break;
				case 80: sCreature = "Ogre"; break;
				case 81: sCreature = "Orc"; break;
				case 82: sCreature = "Owl"; break;
				case 83: sCreature = "Pegasus"; break;
				case 84: sCreature = "Pixie"; break;
				case 85: sCreature = "Porcupine"; break;
				case 86: sCreature = "Ram"; break;
				case 87: sCreature = "Rat"; break;
				case 88: sCreature = "Reaper"; break;
				case 89: sCreature = "Rhinoceros"; break;
				case 90: sCreature = "Roc"; break;
				case 91: sCreature = "Satyr"; break;
				case 92: sCreature = "Scorpion"; break;
				case 93: sCreature = "Serpent"; break;
				case 94: sCreature = "Shadow"; break;
				case 95: sCreature = "Skeleton"; break;
				case 96: sCreature = "Skunk"; break;
				case 97: sCreature = "Snake"; break;
				case 98: sCreature = "Spectre"; break;
				case 99: sCreature = "Sphinx"; break;
				case 100: sCreature = "Spider"; break;
				case 101: sCreature = "Sprite"; break;
				case 102: sCreature = "Stag"; break;
				case 103: sCreature = "Tiger"; break;
				case 104: sCreature = "Titan"; break;
				case 105: sCreature = "Toad"; break;
				case 106: sCreature = "Troglodyte"; break;
				case 107: sCreature = "Troll"; break;
				case 108: sCreature = "Unicorn"; break;
				case 109: sCreature = "Vampire"; break;
				case 110: sCreature = "Weasel"; break;
				case 111: sCreature = "Wight"; break;
				case 112: sCreature = "Wisp"; break;
				case 113: sCreature = "Wolf"; break;
				case 114: sCreature = "Wolverine"; break;
				case 115: sCreature = "Worm"; break;
				case 116: sCreature = "Wraith"; break;
				case 117: sCreature = "Wyvern"; break;
				case 118: sCreature = "Yeti"; break;
				case 119: sCreature = "Zombie"; break;
				case 120: sCreature = "Zorn"; break;
			}

			return sCreature;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomIntelligentRace()
		{
			string sLanguage = "balron";
			int section = Utility.RandomMinMax( 0, 28 );
			switch( section )
			{
				case 0: sLanguage = "balron"; break;
				case 1: sLanguage = "pixie"; break;
				case 2: sLanguage = "centaur"; break;
				case 3: sLanguage = "demonic"; break;
				case 4: sLanguage = "dragon"; break;
				case 5: sLanguage = "dwarvish"; break;
				case 6: sLanguage = "elven"; break;
				case 7: sLanguage = "fey"; break;
				case 8: sLanguage = "gargoyle"; break;
				case 9: sLanguage = "cyclops"; break;
				case 10: sLanguage = "gnoll"; break;
				case 11: sLanguage = "goblin"; break;
				case 12: sLanguage = "gremlin"; break;
				case 13: sLanguage = "druidic"; break;
				case 14: sLanguage = "tritun"; break;
				case 15: sLanguage = "minotaur"; break;
				case 16: sLanguage = "naga"; break;
				case 17: sLanguage = "ogrish"; break;
				case 18: sLanguage = "orkish"; break;
				case 19: sLanguage = "sphinx"; break;
				case 20: sLanguage = "treekin"; break;
				case 21: sLanguage = "trollish"; break;
				case 22: sLanguage = "undead"; break;
				case 23: sLanguage = "vampire"; break;
				case 24: sLanguage = "dark elf"; break;
				case 25: sLanguage = "magic"; break;
				case 26: sLanguage = "human"; break;
				case 27: sLanguage = "symbolic"; break;
				case 28: sLanguage = "runic"; break;
			}

			return sLanguage;
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetRandomRobot( int part )
		{
			string robot = "";

			string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

			string[] numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

			int cycle = Utility.RandomMinMax( 4, 8 );
			int dash = Utility.RandomMinMax( 5, 7 );

			while ( cycle > 0 )
			{
				if ( Utility.RandomBool() ){ robot = robot + letters[Utility.RandomMinMax( 0, (letters.Length-1) )]; }
				else { robot = robot + numbers[Utility.RandomMinMax( 0, (numbers.Length-1) )]; }

				if ( cycle == dash ){ robot = robot + "-"; }

				cycle--;
			}

			if ( part > 0 ){ return robot; }

			string type = "robot";
			switch( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: type = "robot"; break;
				case 1: type = "bot"; break;
				case 2: type = "droid"; break;
			}

			string mission = "security";
			switch( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: mission = "security"; break;
				case 1: mission = "maintenance"; break;
				case 2: mission = "medical"; break;
				case 3: mission = "war"; break;
				case 4: mission = "sentinel"; break;
				case 5: mission = "engineering"; break;
				case 6: mission = "assault"; break;
				case 7: mission = "exterminator"; break;
				case 8: mission = "interpreter"; break;
				case 9: mission = "mining"; break;
				case 10: mission = "protocol"; break;
				case 11: mission = "labor"; break;
			}

			robot = robot + " " + mission + " " + type;

			return robot;
		}


		public static string MagicItemAdj( string placed, bool oriental, bool evil, int itemid )
		{
			string sAdjective = "magical";

			int pick = Utility.RandomMinMax( 0, 37 );

			if ( placed == "end" ){ pick = Utility.RandomMinMax( 38, 116 ); }

			if ( placed == "end" && itemid == 0x2C9E ) // SAFETY CATCH FOR DEMON/DRAGON SKULL TRINKETS
			{
				pick = Utility.RandomMinMax( 0, 5 );

				switch( pick )
				{
					case 0: sAdjective = "the Demon";		break;
					case 1: sAdjective = "the Dragon";		break;
					case 2: sAdjective = "the Daemon";		break;
					case 3: sAdjective = "the Devil";		break;
					case 4: sAdjective = "the Wyrm";		break;
					case 5: sAdjective = "the Drake";		break;
				}
			}
			else
			{
				if ( oriental )
				{
					switch( pick )
					{
						case 0: sAdjective = "exotic"; 			break;
						case 1: sAdjective = "mysterious"; 		break;
						case 2: sAdjective = "enchanted"; 		break;
						case 3: sAdjective = "marvelous"; 		break;
						case 4: sAdjective = "amazing"; 		break;
						case 5: sAdjective = "astonishing"; 	break;
						case 6: sAdjective = "mystical"; 		break;
						case 7: sAdjective = "astounding"; 		break;
						case 8: sAdjective = "magical"; 		break;
						case 9: sAdjective = "divine"; 			break;
						case 10: sAdjective = "excellent"; 		break;
						case 11: sAdjective = "magnificent"; 	break;
						case 12: sAdjective = "phenomenal"; 	break;
						case 13: sAdjective = "fantastic"; 		break;
						case 14: sAdjective = "incredible"; 	break;
						case 15: sAdjective = "extraordinary"; 	break;
						case 16: sAdjective = "fabulous"; 		break;
						case 17: sAdjective = "wondrous"; 		break;
						case 18: sAdjective = "glorious"; 		break;
						case 19: sAdjective = "lost"; 			break;
						case 20: sAdjective = "fabled"; 		break;
						case 21: sAdjective = "legendary"; 		break;
						case 22: sAdjective = "mythical"; 		break;
						case 23: sAdjective = "ancestral"; 		break;
						case 24: sAdjective = "ornate"; 		break;
						case 25: sAdjective = "ultimate"; 		break;
						case 26: sAdjective = "rare"; 			break;
						case 27: sAdjective = "wonderful"; 		break;
						case 28: sAdjective = "sacred"; 		break;
						case 29: sAdjective = "almighty"; 		break;
						case 30: sAdjective = "supreme"; 		break;
						case 31: sAdjective = "mighty"; 		break;
						case 32: sAdjective = "unspeakable"; 	break;
						case 33: sAdjective = "forgotten"; 		break;
						case 34: sAdjective = "great"; 			break;
						case 35: sAdjective = "grand"; 			break;
						case 36: sAdjective = "magic"; 			break;
						case 37: sAdjective = "unusual"; 		break;
						case 38: sAdjective = "might"; 			break;
						case 39: sAdjective = "power"; 			break;
						case 40: sAdjective = "greatness"; 		break;
						case 41: sAdjective = "magic"; 			break;
						case 42: sAdjective = "supremacy"; 		break;
						case 43: sAdjective = "the almighty"; 	break;
						case 44: sAdjective = "the sacred"; 	break;
						case 45: sAdjective = "magnificence"; 	break;
						case 46: sAdjective = "excellence"; 	break;
						case 47: sAdjective = "glory"; 			break;
						case 48: sAdjective = "mystery"; 		break;
						case 49: sAdjective = "the divine"; 	break;
						case 50: sAdjective = "the forgotten"; 	break;
						case 51: sAdjective = "legend"; 		break;
						case 52: sAdjective = "the lost"; 		break;
						case 53: sAdjective = "the ancients"; 	break;
						case 54: sAdjective = "wonder"; 		break;
						case 55: sAdjective = "the mighty"; 	break;
						case 56: sAdjective = "marvel"; 		break;
						case 57: sAdjective = "nobility"; 		break;
						case 58: sAdjective = "mysticism"; 		break;
						case 59: sAdjective = "enchantment"; 	break;
						case 60: sAdjective = "the Karateka";		break;
						case 61: sAdjective = "the Ronin";			break;
						case 62: sAdjective = "the Samurai";		break;
						case 63: sAdjective = "the Ninja";			break;
						case 64: sAdjective = "the Yakuza";			break;
						case 65: sAdjective = "the Wu Jen";			break;
						case 66: sAdjective = "the Kensai";			break;
						case 67: sAdjective = "the Shukenja";		break;
						case 68: sAdjective = "the Fangshi";		break;
						case 69: sAdjective = "the Waidan";			break;
						case 70: sAdjective = "the Neidan";			break;
						case 71: sAdjective = "the Monk";			break;
						case 72: sAdjective = "the Kyudo";			break;
						case 73: sAdjective = "the Yuki Ota";		break;
						case 74: sAdjective = "the Sakushi";		break;
						case 75: sAdjective = "the Youxia";			break;
						case 76: sAdjective = "the Kyudoka";		break;
						case 77: sAdjective = "the Ashigaru";		break;
						case 78: sAdjective = "the Martial Artist";	break;
						case 79: sAdjective = "the Slayer";			break;
						case 80: sAdjective = "the Wako";			break;
						case 81: sAdjective = "the Barbarian";		break;
						case 82: sAdjective = "the Explorer";		break;
						case 83: sAdjective = "the Heretic";		break;
						case 84: sAdjective = "the Sumo";			break;
						case 85: sAdjective = "the Iaijutsu";		break;
						case 86: sAdjective = "the Emperor";		break;
						case 87: sAdjective = "of the " + Server.Misc.RandomThings.GetRandomColorName(0) + " Dynasty";		break;
						case 88: sAdjective = "the Zhuhou";			break;
						case 89: sAdjective = "the Qing";			break;
						case 90: sAdjective = "the Empress";		break;
						case 91: sAdjective = "the Daifu";			break;
						case 92: sAdjective = "the Shi";			break;
						case 93: sAdjective = "the Shumin";			break;
						case 94: sAdjective = "the Heika";			break;
						case 95: sAdjective = "the Denka";			break;
						case 96: sAdjective = "the Hidenka";		break;
						case 97: sAdjective = "the Kakka";			break;
						case 98: sAdjective = "the Daitoryo";		break;
						case 99: sAdjective = "the Renshi";			break;
						case 100: sAdjective = "the Kyoshi";		break;
						case 101: sAdjective = "the Hanshi";		break;
						case 102: sAdjective = "the Meijin";		break;
						case 103: sAdjective = "the Oyakata";		break;
						case 104: sAdjective = "the Shihan";		break;
						case 105: sAdjective = "the Shidoin";		break;
						case 106: sAdjective = "the Shisho";		break;
						case 107: sAdjective = "the Zeki";			break;
						case 108: sAdjective = "the Shaman";		break;
						case 109: sAdjective = "the Shodan";		break;
						case 110: sAdjective = "the Nidan";			break;
						case 111: sAdjective = "the Yodan";			break;
						case 112: sAdjective = "the Godan";			break;
						case 113: sAdjective = "the Rokudan";		break;
						case 114: sAdjective = "the Shichidan";		break;
						case 115: sAdjective = "the Hachidan";		break;
						case 116: sAdjective = "the Judan";			break;
					}
				}
				else if ( evil )
				{
					switch( pick )
					{
						case 0: sAdjective = "evil"; 			break;
						case 1: sAdjective = "corrupt"; 		break;
						case 2: sAdjective = "destructive"; 	break;
						case 3: sAdjective = "hateful"; 		break;
						case 4: sAdjective = "heinous"; 		break;
						case 5: sAdjective = "malevolent"; 		break;
						case 6: sAdjective = "malicious"; 		break;
						case 7: sAdjective = "nefarious"; 		break;
						case 8: sAdjective = "wicked"; 			break;
						case 9: sAdjective = "vicious"; 		break;
						case 10: sAdjective = "vile"; 			break;
						case 11: sAdjective = "villainous"; 	break;
						case 12: sAdjective = "foul"; 			break;
						case 13: sAdjective = "damnable"; 		break;
						case 14: sAdjective = "disastrous"; 	break;
						case 15: sAdjective = "harmful"; 		break;
						case 16: sAdjective = "loathsome"; 		break;
						case 17: sAdjective = "maleficent"; 	break;
						case 18: sAdjective = "repulsive"; 		break;
						case 19: sAdjective = "spiteful"; 		break;
						case 20: sAdjective = "wrathful"; 		break;
						case 21: sAdjective = "deadly"; 		break;
						case 22: sAdjective = "sinister"; 		break;
						case 23: sAdjective = "woeful"; 		break;
						case 24: sAdjective = "fatal"; 			break;
						case 25: sAdjective = "withering"; 		break;
						case 26: sAdjective = "decayed"; 		break;
						case 27: sAdjective = "cursed"; 		break;
						case 28: sAdjective = "damning"; 		break;
						case 29: sAdjective = "horrific"; 		break;
						case 30: sAdjective = "tormented"; 		break;
						case 31: sAdjective = "doomed"; 		break;
						case 32: sAdjective = "unspeakable"; 	break;
						case 33: sAdjective = "hated"; 			break;
						case 34: sAdjective = "miserable"; 		break;
						case 35: sAdjective = "infamous"; 		break;
						case 36: sAdjective = "corrupted"; 		break;
						case 37: sAdjective = "raging"; 		break;
						case 38: sAdjective = "death"; 			break;
						case 39: sAdjective = "villainy"; 		break;
						case 40: sAdjective = "darkness"; 		break;
						case 41: sAdjective = "hatred"; 		break;
						case 42: sAdjective = "evil"; 			break;
						case 43: sAdjective = "the Nine Hells"; break;
						case 44: sAdjective = "Cthulhu"; 		break;
						case 45: sAdjective = "Hell"; 			break;
						case 46: sAdjective = "Hades"; 			break;
						case 47: sAdjective = "Satan"; 			break;
						case 48: sAdjective = "spirits"; 		break;
						case 49: sAdjective = "the haunted"; 	break;
						case 50: sAdjective = "the undead"; 	break;
						case 51: sAdjective = "the mummy"; 		break;
						case 52: sAdjective = "the buried"; 	break;
						case 53: sAdjective = "the poltergeist";break;
						case 54: sAdjective = "the cult"; 		break;
						case 55: sAdjective = "the grave"; 		break;
						case 56: sAdjective = "blood"; 			break;
						case 57: sAdjective = "the " + Server.Misc.RandomThings.GetRandomColorName(0) + " Ghost"; 		break;
						case 58: sAdjective = "the tomb"; 		break;
						case 59: sAdjective = "the crypt"; 		break;
						case 60: sAdjective = "the Necromancer";	break;
						case 61: sAdjective = "the Witch";			break;
						case 62: sAdjective = "the Warlock";		break;
						case 63: sAdjective = "the Vile";			break;
						case 64: sAdjective = "the Hated";			break;
						case 65: sAdjective = "the Villain";		break;
						case 66: sAdjective = "the Murderer";		break;
						case 67: sAdjective = "the Killer";			break;
						case 68: sAdjective = "the Ghost";			break;
						case 69: sAdjective = "the Death Knight";	break;
						case 70: sAdjective = "the Lich";			break;
						case 71: sAdjective = "the Occultist";		break;
						case 72: sAdjective = "the Cultist";		break;
						case 73: sAdjective = "the Diabolist";		break;
						case 74: sAdjective = "the Hag";			break;
						case 75: sAdjective = "the Butcher";		break;
						case 76: sAdjective = "the Slayer";			break;
						case 77: sAdjective = "the Executioner";	break;
						case 78: sAdjective = "the Demon";			break;
						case 79: sAdjective = "the Phantom";		break;
						case 80: sAdjective = "the Shadow";			break;
						case 81: sAdjective = "the Spectre";		break;
						case 82: sAdjective = "the Devil";			break;
						case 83: sAdjective = "the Shade";			break;
						case 84: sAdjective = "the Wraith";			break;
						case 85: sAdjective = "the Vampire";		break;
						case 86: sAdjective = "the Banshee";		break;
						case 87: sAdjective = "the Dark";			break;
						case 88: sAdjective = "the Black";			break;
						case 89: sAdjective = "the Mortician";		break;
						case 90: sAdjective = "the Embalmer";		break;
						case 91: sAdjective = "the Grave";			break;
						case 92: sAdjective = "the Fiend";			break;
						case 93: sAdjective = "the Daemon";			break;
						case 94: sAdjective = "the Corrupt";		break;
						case 95: sAdjective = "the Hateful";		break;
						case 96: sAdjective = "the Heinous";		break;
						case 97: sAdjective = "the Hideous";		break;
						case 98: sAdjective = "the Malevolent";		break;
						case 99: sAdjective = "the Malicious";		break;
						case 100: sAdjective = "the Nefarious";		break;
						case 101: sAdjective = "the Vicious";		break;
						case 102: sAdjective = "the Wicked";		break;
						case 103: sAdjective = "the Foul";			break;
						case 104: sAdjective = "the Baneful";		break;
						case 105: sAdjective = "the Depraved";		break;
						case 106: sAdjective = "the Loathsome";		break;
						case 107: sAdjective = "the Wrathful";		break;
						case 108: sAdjective = "the Woeful";		break;
						case 109: sAdjective = "the Grim";			break;
						case 110: sAdjective = "the Dismal";		break;
						case 111: sAdjective = "the Lifeless";		break;
						case 112: sAdjective = "the Deceased";		break;
						case 113: sAdjective = "the Bloodless";		break;
						case 114: sAdjective = "the Mortified";		break;
						case 115: sAdjective = "the Departed";		break;
						case 116: sAdjective = "the Dead";			break;
					}
				}
				else
				{
					switch( pick )
					{
						case 0: sAdjective = "exotic"; 			break;
						case 1: sAdjective = "mysterious"; 		break;
						case 2: sAdjective = "enchanted"; 		break;
						case 3: sAdjective = "marvelous"; 		break;
						case 4: sAdjective = "amazing"; 		break;
						case 5: sAdjective = "astonishing"; 	break;
						case 6: sAdjective = "mystical"; 		break;
						case 7: sAdjective = "astounding"; 		break;
						case 8: sAdjective = "magical"; 		break;
						case 9: sAdjective = "divine"; 			break;
						case 10: sAdjective = "excellent"; 		break;
						case 11: sAdjective = "magnificent"; 	break;
						case 12: sAdjective = "phenomenal"; 	break;
						case 13: sAdjective = "fantastic"; 		break;
						case 14: sAdjective = "incredible"; 	break;
						case 15: sAdjective = "extraordinary"; 	break;
						case 16: sAdjective = "fabulous"; 		break;
						case 17: sAdjective = "wondrous"; 		break;
						case 18: sAdjective = "glorious"; 		break;
						case 19: sAdjective = "lost"; 			break;
						case 20: sAdjective = "fabled"; 		break;
						case 21: sAdjective = "legendary"; 		break;
						case 22: sAdjective = "mythical"; 		break;
						case 23: sAdjective = "ancestral"; 		break;
						case 24: sAdjective = "ornate"; 		break;
						case 25: sAdjective = "ultimate"; 		break;
						case 26: sAdjective = "rare"; 			break;
						case 27: sAdjective = "wonderful"; 		break;
						case 28: sAdjective = "sacred"; 		break;
						case 29: sAdjective = "almighty"; 		break;
						case 30: sAdjective = "supreme"; 		break;
						case 31: sAdjective = "mighty"; 		break;
						case 32: sAdjective = "unspeakable"; 	break;
						case 33: sAdjective = "forgotten"; 		break;
						case 34: sAdjective = "great"; 			break;
						case 35: sAdjective = "grand"; 			break;
						case 36: sAdjective = "magic"; 			break;
						case 37: sAdjective = "unusual"; 		break;
						case 38: sAdjective = "might"; 			break;
						case 39: sAdjective = "power"; 			break;
						case 40: sAdjective = "greatness"; 		break;
						case 41: sAdjective = "magic"; 			break;
						case 42: sAdjective = "supremacy"; 		break;
						case 43: sAdjective = "the almighty"; 	break;
						case 44: sAdjective = "the sacred"; 	break;
						case 45: sAdjective = "magnificence"; 	break;
						case 46: sAdjective = "excellence"; 	break;
						case 47: sAdjective = "glory"; 			break;
						case 48: sAdjective = "mystery"; 		break;
						case 49: sAdjective = "the divine"; 	break;
						case 50: sAdjective = "the forgotten"; 	break;
						case 51: sAdjective = "legend"; 		break;
						case 52: sAdjective = "the lost"; 		break;
						case 53: sAdjective = "the ancients"; 	break;
						case 54: sAdjective = "wonder"; 		break;
						case 55: sAdjective = "the mighty"; 	break;
						case 56: sAdjective = "marvel"; 		break;
						case 57: sAdjective = "nobility"; 		break;
						case 58: sAdjective = "mysticism"; 		break;
						case 59: sAdjective = "enchantment"; 	break;
						case 60: sAdjective = "the Templar";		break;
						case 61: sAdjective = "the Thief";			break;
						case 62: sAdjective = "the Illusionist";	break;
						case 63: sAdjective = "the Princess";		break;
						case 64: sAdjective = "the Invoker";		break;
						case 65: sAdjective = "the Priestess";		break;
						case 66: sAdjective = "the Conjurer";		break;
						case 67: sAdjective = "the Bandit";			break;
						case 68: sAdjective = "the Baroness";		break;
						case 69: sAdjective = "the Wizard";			break;
						case 70: sAdjective = "the Cleric";			break;
						case 71: sAdjective = "the Monk";			break;
						case 72: sAdjective = "the Minstrel";		break;
						case 73: sAdjective = "the Defender";		break;
						case 74: sAdjective = "the Cavalier";		break;
						case 75: sAdjective = "the Magician";		break;
						case 76: sAdjective = "the Witch";			break;
						case 77: sAdjective = "the Fighter";		break;
						case 78: sAdjective = "the Seeker";			break;
						case 79: sAdjective = "the Slayer";			break;
						case 80: sAdjective = "the Ranger";			break;
						case 81: sAdjective = "the Barbarian";		break;
						case 82: sAdjective = "the Explorer";		break;
						case 83: sAdjective = "the Heretic";		break;
						case 84: sAdjective = "the Gladiator";		break;
						case 85: sAdjective = "the Sage";			break;
						case 86: sAdjective = "the Rogue";			break;
						case 87: sAdjective = "the Paladin";		break;
						case 88: sAdjective = "the Bard";			break;
						case 89: sAdjective = "the Diviner";		break;
						case 90: sAdjective = "the Lady";			break;
						case 91: sAdjective = "the Outlaw";			break;
						case 92: sAdjective = "the Prophet";		break;
						case 93: sAdjective = "the Mercenary";		break;
						case 94: sAdjective = "the Adventurer";		break;
						case 95: sAdjective = "the Enchantress";	break;
						case 96: sAdjective = "the Queen";			break;
						case 97: sAdjective = "the Scout";			break;
						case 98: sAdjective = "the Mystic";			break;
						case 99: sAdjective = "the Mage";			break;
						case 100: sAdjective = "the Traveler";		break;
						case 101: sAdjective = "the Summoner";		break;
						case 102: sAdjective = "the Warrior";		break;
						case 103: sAdjective = "the Sorcereress";	break;
						case 104: sAdjective = "the Seer";			break;
						case 105: sAdjective = "the Hunter";		break;
						case 106: sAdjective = "the Knight";		break;
						case 107: sAdjective = "the Necromancer";	break;
						case 108: sAdjective = "the Shaman";		break;
						case 109: sAdjective = "the Prince";		break;
						case 110: sAdjective = "the Priest";		break;
						case 111: sAdjective = "the Baron";			break;
						case 112: sAdjective = "the Warlock";		break;
						case 113: sAdjective = "the Lord";			break;
						case 114: sAdjective = "the Enchanter";		break;
						case 115: sAdjective = "the King";			break;
						case 116: sAdjective = "the Sorcerer";		break;
					}
				}
			}

			return sAdjective;
		}

		public static string MagicItemName( Item item, Mobile m, Region from )
		{
			bool isOriental = false;
			bool isEvil = false;

			string RegionName = "";
			string xName = ContainerFunctions.GetOwner( "property" );

			if ( from is DungeonRegion && Utility.RandomBool() ){ RegionName = from.Name; }
			else
			{
				switch( Utility.RandomMinMax( 0, 3 ) )
				{
					case 0: RegionName = Server.Misc.RandomThings.MadeUpDungeon(); 												break;
					case 1: RegionName = Server.Misc.RandomThings.MadeUpCity(); 												break;
					case 2: RegionName = Server.Misc.RandomThings.GetRandomScenePainting(); 									break;
					case 3: RegionName = "the " + RandomThings.GetRandomKingdomName() + " " + RandomThings.GetRandomKingdom();	break;
				}
			}

			string OwnerName = RandomThings.GetRandomName();
			if ( ( item.ItemID >= 0x2776 && item.ItemID <= 0x27FA ) || Server.Misc.GetPlayerInfo.OrientalPlay( m ) == true )
			{
				isOriental = true;
				OwnerName = RandomThings.GetRandomOrientalName();
				xName = OwnerName + " " + MagicItemAdj( "end", true, false, item.ItemID );
			}
			else if ( Server.Misc.GetPlayerInfo.EvilPlay( m ) )
			{
				isEvil = true;
				xName = OwnerName + " " + MagicItemAdj( "end", false, true, item.ItemID );
			}

			if ( OwnerName.EndsWith( "s" ) )
			{
				OwnerName = OwnerName + "'";
			}
			else
			{
				OwnerName = OwnerName + "'s";
			}
			if ( Utility.RandomBool() ){ OwnerName = NameList.RandomName( "cultures" ); }

			string sAdjective = "unusual";
			string eAdjective = "might";

			sAdjective = MagicItemAdj( "start", isOriental, isEvil, item.ItemID );
			eAdjective = MagicItemAdj( "end", isOriental, isEvil, item.ItemID );

			string name = "item";

			if ( item.Name != null && item.Name != "" ){ name = item.Name; }
			if ( name == "item" ){ item.SyncName(); name = item.Name; }

			if ( isEvil && item is WizardWand && Utility.RandomMinMax( 1, 4 ) != 1 )
			{
				item.ItemID = Utility.RandomList( 0x269D, 0x269E );
			}

			if ( item is BambooFlute ){ name = "flute"; }
			else if ( item is Drums ){ name = "drum"; }
			else if ( item is Harp ){ name = "harp"; }
			else if ( item is LapHarp ){ name = "harp"; }
			else if ( item is Lute ){ name = "lute"; if ( Utility.RandomMinMax( 1, 2 ) == 1 ){ name = "mandolin"; } }
			else if ( item is Tambourine ){ name = "tambourine"; }
			else if ( item is TambourineTassel ){ name = "tambourine"; }
			else if ( item is Trumpet ){ name = "trumpet"; }

			int FirstLast = Utility.RandomMinMax( 0, 1 );

			int HaveNewName = 0;

			if ( SkipMagicName( item ) )
			{
				// DO NOT CHANGE THE NAME OF
			}
			else if ( FirstLast == 0 ) // FIRST COMES ADJECTIVE
			{
				int val = 15; if ( !item.Movable ){ val = 7; }
				switch( Utility.RandomMinMax( 0, val ) )
				{
					case 0: name = sAdjective + " " + name + " of " + xName; 										HaveNewName = 1; break;
					case 1: name = name + " of " + xName; 															HaveNewName = 1; break;
					case 2: name = sAdjective + " " + name; 														HaveNewName = 1; break;
					case 3: name = sAdjective + " " + name + " of " + xName; 										HaveNewName = 1; break;
					case 4: name = name + " of " + xName; 															HaveNewName = 1; break;
					case 5: name = sAdjective + " " + name; 														HaveNewName = 1; break;
					case 6: if ( RegionName != "" ){ name = sAdjective + " " + name + " from " + RegionName;	}	HaveNewName = 1; break;
					case 7: if ( RegionName != "" ){ name = name + " from " + RegionName;	}						break;
				}
			}
			else // FIRST COMES OWNER
			{
				int val = 11; if ( !item.Movable ){ val = 5; }
				switch( Utility.RandomMinMax( 0, val ) )
				{
					case 0: name = OwnerName + " " + name + " of " + eAdjective; 									HaveNewName = 1; break;
					case 1: name = name + " of " + eAdjective; 														HaveNewName = 1; break;
					case 2: name = OwnerName + " " + name; 															HaveNewName = 1; break;
					case 3: name = OwnerName + " " + sAdjective + " " + name; 										HaveNewName = 1; break;
					case 4: if ( RegionName != "" ){ name = sAdjective + " " + name + " from " + RegionName;	}	HaveNewName = 1; break;
					case 5: if ( RegionName != "" ){ name = name + " from " + RegionName;	}						break;
				}
			}

			if ( Server.Misc.GetPlayerInfo.EvilPlay( m ) == true && HaveNewName > 0 )
			{
				item.Hue = Utility.RandomEvilHue();
			}

			if ( name.Contains("The The") ){ name = name.Replace("The The", "The"); }
			if ( name.Contains("the the") ){ name = name.Replace("the the", "the"); }
			if ( name.Contains("The the") ){ name = name.Replace("The the", "the"); }
			if ( name.Contains("the The") ){ name = name.Replace("the The", "the"); }

			return name;
		}

		public static string MagicWandOwner()
		{
			string OwnerName = RandomThings.GetRandomName();

			if ( OwnerName.EndsWith( "s" ) )
			{
				OwnerName = OwnerName + "'";
			}
			else
			{
				OwnerName = OwnerName + "'s";
			}
			if ( Utility.RandomBool() ){ OwnerName = NameList.RandomName( "cultures" ); }

			return OwnerName;
		}

		public static bool SkipMagicName( Item item )
		{
			if ( item.ArtifactLevel > 0 )
				return true;

			if ( item.NotModAble && !(item is BaseTrinket) )
				return true;

			return false;
		}

		public static void SpecialName( Item item, Mobile m, Region reg )
		{
			bool isOriental = GetPlayerInfo.OrientalPlay( m );
			bool isEvil = GetPlayerInfo.EvilPlay( m );

			bool colorModHue = false;

			if ( SkipMagicName( item ) )
				return;

			if ( !( item is BaseArmor || item is BaseWeapon || item is BaseInstrument || item is BaseClothing || item is BaseTrinket || item is BaseQuiver || item is Spellbook ) )
				return;

			if ( Worlds.isSciFiRegion( m ) )
				return;

			string RegionName = null;
			string xName = ContainerFunctions.GetOwner( "property" );

			if ( reg is DungeonRegion && Utility.RandomBool() )
				RegionName = reg.Name;
			else
			{
				switch( Utility.Random( 4 ) )
				{
					case 0: RegionName = RandomThings.MadeUpDungeon(); 															break;
					case 1: RegionName = RandomThings.MadeUpCity(); 															break;
					case 2: RegionName = RandomThings.GetRandomScenePainting(); 												break;
					case 3: RegionName = "the " + RandomThings.GetRandomKingdomName() + " " + RandomThings.GetRandomKingdom();	break;
				}
			}

			string OwnerName = RandomThings.GetRandomName();

			if ( isOriental )
			{
				OwnerName = RandomThings.GetRandomOrientalName();
				xName = OwnerName + " " + MagicItemAdj( "end", true, false, item.ItemID );
			}
			else if ( isEvil )
				xName = OwnerName + " " + MagicItemAdj( "end", false, true, item.ItemID );

			if ( OwnerName.EndsWith( "s" ) )
				OwnerName = OwnerName + "'";
			else
				OwnerName = OwnerName + "'s";

			if ( Utility.RandomBool() )
				OwnerName = NameList.RandomName( "cultures" );

			string sAdjective = "unusual";
			string eAdjective = "might";

			sAdjective = MagicItemAdj( "start", isOriental, isEvil, item.ItemID );
			eAdjective = MagicItemAdj( "end", isOriental, isEvil, item.ItemID );

			string name = item.Name;
				if ( item is MagicalWand )
					name = "magic wand";

			string subname = null;

			if ( isEvil && item is WizardWand && Utility.Random( 4 ) > 0 )
				item.ItemID = Utility.RandomList( 0x269D, 0x269E );

			bool HasNewName = false;

			if ( Utility.RandomBool() ) // FIRST COMES ADJECTIVE
			{
				int val = 15; if ( !item.Movable ){ val = 7; }

				int num = Utility.RandomMinMax( 0, val );
					if ( RegionName != null && ( val == 6 || val == 7 ) )
						val = 5;

				switch( num )
				{
					case 0: name = sAdjective + " " + name + " of";		subname = xName; 			HasNewName = true; colorModHue = true; 	break;
					case 1: name = name + " of";						subname = xName; 			HasNewName = true; 						break;
					case 2: name = sAdjective + " " + name; 										HasNewName = true; colorModHue = true; 	break;
					case 3: name = sAdjective + " " + name + " of";		subname = xName; 			HasNewName = true; colorModHue = true; 	break;
					case 4: name = name + " of";						subname = xName; 			HasNewName = true; 						break;
					case 5: name = sAdjective + " " + name; 										HasNewName = true; colorModHue = true; 	break;
					case 6: name = sAdjective + " " + name + " from";	subname = RegionName;		HasNewName = true; colorModHue = true; 	break;
					case 7: name = name + " from";						subname = RegionName;		HasNewName = true; 						break;
				}
			}
			else // FIRST COMES OWNER
			{
				int val = 11; if ( !item.Movable ){ val = 5; }

				int num = Utility.RandomMinMax( 0, val );
					if ( RegionName != null && ( val == 4 || val == 5 ) )
						val = 3;

				switch( Utility.RandomMinMax( 0, val ) )
				{
					case 0: name = OwnerName + " " + name + " of";				subname = eAdjective; 		HasNewName = true; colorModHue = true; 	break;
					case 1: name = name + " of";								subname = eAdjective; 		HasNewName = true; colorModHue = true; 	break;
					case 2: name = OwnerName + " " + name; 													HasNewName = true; 						break;
					case 3: name = OwnerName + " " + sAdjective + " " + name;								HasNewName = true; colorModHue = true; 	break;
					case 4: name = sAdjective + " " + name + " from";			subname = RegionName;		HasNewName = true; colorModHue = true; 	break;
					case 5: name = name + " from";								subname = RegionName;		HasNewName = true; 						break;
				}
			}

			if ( HasNewName )
			{
				string textHue = "0080FF";

				if ( isEvil && colorModHue )
				{
					item.Hue = Utility.RandomEvilHue();
					textHue = "DE1D1D";
				}
				else if ( colorModHue && item is MagicalWand && Utility.RandomBool() )
					item.Hue = GetRandomMetallicColor();

				if ( name.Contains("The The") ){ name = name.Replace("The The", "The"); }
				if ( name.Contains("the the") ){ name = name.Replace("the the", "the"); }
				if ( name.Contains("The the") ){ name = name.Replace("The the", "the"); }
				if ( name.Contains("the The") ){ name = name.Replace("the The", "the"); }

				item.ColorText1 = name;
				item.ColorHue1 = textHue;

				if ( subname != null )
				{
					if ( subname.Contains("The The") ){ subname = subname.Replace("The The", "The"); }
					if ( subname.Contains("the the") ){ subname = subname.Replace("the the", "the"); }
					if ( subname.Contains("The the") ){ subname = subname.Replace("The the", "the"); }
					if ( subname.Contains("the The") ){ subname = subname.Replace("the The", "the"); }
					item.ColorText2 = subname;
					item.ColorHue2 = textHue;
				}
			}
		}
	}
}