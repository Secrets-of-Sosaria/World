using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class Humanoid : Citizens
	{
		[Constructable]
		public Humanoid() : base()
		{
			Hue = 0;
			Title = "";
		}

		public static void HumanoidSetup( Mobile m, bool spawned )
		{
			if ( m is Humanoid )
			{
				m.Hue = 0;
				Server.Misc.MorphingTime.RemoveMyClothes( m );
				if ( m.Backpack != null ){ m.Backpack.Delete(); }
				if ( !spawned ){ m.AddItem( new LightCitizen( false ) ); }

				if ( Server.Misc.Worlds.IsCrypt( m.Location, m.Map ) )
				{
					if ( !(Server.Misc.Worlds.InBuilding( m )) && !spawned && Utility.RandomMinMax( 1, 10 ) == 1 )
					{
						switch ( Utility.RandomMinMax( 1, 4 ) )
						{
							case 1: m.Body = Utility.RandomList( 10, 9, 320, 93, 427, 191 ); m.Name = NameList.RandomName( "devil" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 357; break; // daemon
							case 2: m.Body = 88; m.Name = NameList.RandomName( "devil" ); m.BaseSoundID = 372; break; // abysmal daemon
							case 3: m.Body = 139; m.Name = NameList.RandomName( "dragon" ); m.BaseSoundID = 362; break; // dragon ghost
							case 4: m.Body = 313; m.Name = NameList.RandomName( "trees" ); m.BaseSoundID = 442; break; // an ent
						}
					}
					else
					{
						switch ( Utility.RandomMinMax( 1, 23 ) )
						{
							case 1: m.Body = 689; m.Name = NameList.RandomName( "goddess" ); m.BaseSoundID = 0x4B0; break; // succubus
							case 2: m.Body = Utility.RandomList( 202, 359 ); m.Name = NameList.RandomName( "imp" ); m.BaseSoundID = 594; m.Hue = Utility.RandomList( 0xB88, 0xB8C, 0xB85, 0x846, 0x84C, 0x84E, 0x4001, 0x5B7, 0x5B6, 0x550, 0x497, 0x48D, 0x482, 0x47E, 0x4AA, 0 ); break; // imp
							case 3: m.Body = 93; m.Name = "a shadow demon"; m.BaseSoundID = 655; break; // shadow demon
							case 4: m.Body = Utility.RandomList( 57, 168, 170, 327, 247 ); if ( m.Body == 327 ){ m.Hue = 0x9C4; } m.Name = "a skeleton"; m.BaseSoundID = 451; break; // skeleton
							case 5: m.Body = 0x3CA; m.Name = Server.Misc.RandomThings.GetRandomWizardName(); m.Title = "the ghost"; m.Hue = 1150; m.AddItem( new DeathShroud( 1150 ) ); m.BaseSoundID = 0x482; break; // ghost
							case 6: m.Body = 181; m.Name = "a ghoul"; m.BaseSoundID = 471; break; // ghoul
							case 7: m.Body = 24; m.Name = NameList.RandomName( "ancient lich" ); m.BaseSoundID = Utility.RandomList( 0x19C, 0x3E9 ); m.Title = "the lich"; break; // lich
							case 8: m.Body = 154; m.Name = "a mummy"; m.BaseSoundID = 471; break; // mummy
							case 9: m.Body = Utility.RandomList( 148, 110 ); m.Name = "a skeletal wizard"; m.BaseSoundID = 451; break; // skeletal wizard
							case 10: m.Body = 810; m.Name = "a zombie mage"; m.BaseSoundID = 471; break; // zombie mage
							case 11:
								m.Body = Utility.RandomList( 3, 728 );
								switch( Utility.RandomMinMax( 0, 9 ) )
								{
									case 0: m.Name = "a zombie";			break;
									case 1: m.Name = "a walking dead";		break;
									case 2: m.Name = "a corpse";			break;
									case 3: m.Name = "a rotten corpse";		break;
									case 4: m.Name = "an undead corpse";	break;
									case 5: m.Name = "a rotting zombie";	break;
									case 6: m.Name = "a zombie";			break;
									case 7: m.Name = "a decaying zombie";	break;
									case 8: m.Name = "a decaying corpse";	break;
									case 9: m.Name = "a walking corpse";	break;
								}
								m.Hue = 0xB97;
								switch( Utility.RandomMinMax( 0, 12 ) )
								{
									case 0: m.Hue = 0x83B;	break;
									case 1: m.Hue = 0x89F;	break;
									case 2: m.Hue = 0x8A0;	break;
									case 3: m.Hue = 0x8A1;	break;
									case 4: m.Hue = 0x8A2;	break;
									case 5: m.Hue = 0x8A3;	break;
									case 6: m.Hue = 0x8A4;	break;
								}
								m.BaseSoundID = 471;
								break; // zombie
							case 12: m.Body = 307; m.Name = "a wight"; m.BaseSoundID = 471; break; // wight
							case 13: m.Body = 26; m.Name = "a spectre"; m.BaseSoundID = 0x482; break; // spectre
							case 14: m.Body = Utility.RandomList( 124, 125 ); m.Name = NameList.RandomName( "vampire" ); m.Title = "the vampire"; m.BaseSoundID = 0x47D; break; // vampire
							case 15: m.Body = 340; m.Name = "a hell lion"; m.BaseSoundID = 0x3EE; m.Hue = 0x4AA; break;
							case 16: m.Body = 243; m.Name = "a raven"; m.BaseSoundID = 0x2EE; m.Hue = 0x497; break;
							case 17: m.Body = 672; m.Name = "a placeron"; m.BaseSoundID = 0xA8; m.Hue = 0x99E; break;
							case 18: m.Body = 354; m.Name = "a dreadhorn"; m.BaseSoundID = 0x4BC; break;
							case 19: m.Body = 226; m.Name = "a nightmare"; m.BaseSoundID = 0xA8; m.Hue = 1109; break;
							case 20: m.Body = 795; m.Name = "an ancient nightmare"; m.BaseSoundID = 0xA8; break;
							case 21: m.Body = 0x11C; m.Name = "a gorgon"; m.BaseSoundID = 0xA3; m.Hue = 0xB63; break;
							case 22: m.Body = 277; m.Name = "a black wolf"; m.Hue = 0xB3A; m.BaseSoundID = 0xE5; break;
							case 23: m.Body = 793; m.Name = "a skeletal horse"; m.BaseSoundID = 0xA8; break;
						}
					}
				}
				else if ( ( !(Server.Misc.Worlds.InBuilding( m )) && Utility.RandomBool() ) || spawned )
				{
					int category = Utility.RandomMinMax(1,3);
						if ( spawned ){ category = Utility.RandomMinMax(2,3); }

					if ( category == 1 )
					{
						switch ( Utility.RandomMinMax( 1, 7 ) )
						{
							case 1: m.Body = Utility.RandomList( 312, 309 ); m.Name = NameList.RandomName( "trees" ); m.BaseSoundID = 442; break; // an ent
							case 2: m.Body = Utility.RandomList( 10, 9, 320, 93, 427, 191 ); m.Name = NameList.RandomName( "devil" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 357; break; // daemon
							case 3: m.Body = Utility.RandomList( 61, 59 ); m.Name = NameList.RandomName( "dragon" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 362; break; // dragon
							case 4: m.Body = Utility.RandomList( 10, 9, 320, 93, 427, 191 ); m.Name = NameList.RandomName( "devil" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 357; break; // daemon
							case 5: m.Body = Utility.RandomList( 61, 59 ); m.Name = NameList.RandomName( "dragon" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 362; break; // dragon
							case 6: m.Body = Utility.RandomList( 10, 9, 320, 93, 427, 191 ); m.Name = NameList.RandomName( "devil" ); m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 357; break; // daemon
							case 7: m.Body = Utility.RandomList( 609, 610, 602, 603, 655, 589, 604 ); m.Name = NameList.RandomName( "dragon" ); m.BaseSoundID = 362; break; // dragon
						}
					}
					else if ( category == 2 )
					{
						Item temp = null;
						BaseCreature bc = null;

						switch ( Utility.RandomMinMax( 1, 13 ) )
						{
							case 1: m.Body = 203; m.Name = "a tree elemental"; m.BaseSoundID = 655; break;
							case 2: m.Body = 754; m.Name = "a runic golem"; m.BaseSoundID = 268; break;
							case 3: m.Body = 755; m.Name = "a firerock elemental"; m.BaseSoundID = 268; break;
							case 4: m.Body = 696; m.Name = "a mud elemental"; m.BaseSoundID = 268; break;
							case 5: m.Body = 322; m.Name = "an ice elemental"; m.BaseSoundID = 268; break;
							case 6: m.Body = 698; m.Name = "a lava elemental"; m.BaseSoundID = 268; break;
							case 7: m.Body = 13; m.Name = "an air elemental"; m.BaseSoundID = 655; break;
							case 8: 
								m.Body = Utility.RandomList(142, 14); m.Name = "an earth elemental"; m.BaseSoundID = 268; 
								temp = new PlateHelm();
								ResourceMods.SetRandomResource( false, false, temp, CraftResource.Iron, true, null );
								bc = m as BaseCreature;
								bc.Resource = temp.Resource;
								m.Hue = CraftResources.GetClr(bc.Resource);
								m.Name = CraftResources.GetName(bc.Resource) + " elemental";
								if ( bc.Resource == CraftResource.Iron )
								{
									m.Name = "earth elemental";
									m.Hue = 0;
								}
								temp.Delete();
							break;
							case 9: m.Body = 15; m.Name = "a fire elemental"; m.BaseSoundID = 838; break;
							case 10: m.Body = Utility.RandomList(707, 16); m.Name = "a water elemental"; m.BaseSoundID = 278; break;
							case 11: m.Body = 16; m.Name = "a blood elemental"; m.BaseSoundID = 278; m.Hue = Utility.RandomList( 0xB1E, 0xABD, 0xAB4, 0x9A2, 0x8B3, 0x7CA ); break;
							case 12: m.Body = 16; m.Name = "an acid elemental"; m.BaseSoundID = 278; m.Hue = 60; break;
							case 13: 
								m.Body = 322; m.Name = "caddellite elemental"; m.BaseSoundID = 268; m.Hue = 0x5B6;
								temp = new PlateHelm();
								ResourceMods.SetRandomResource( false, false, temp, CraftResource.AmethystBlock, true, null );
								bc = m as BaseCreature;
								bc.Resource = temp.Resource;
								m.Hue = CraftResources.GetClr(bc.Resource);
								m.Name = CraftResources.GetName(bc.Resource) + " elemental";
								temp.Delete();
							break;
						}
					}
					else
					{
						int pick = Utility.RandomMinMax( 1, 11 );
							if ( spawned ){ pick = Utility.RandomMinMax( 1, 10 ); }

						switch ( pick )
						{
							case 1: m.Body = Utility.RandomList(212, 213, 177, 190, 179); m.Name = "a bear"; m.BaseSoundID = 0xA3; break;
							case 2: m.Body = Utility.RandomList(178, 291); m.Name = "a pack horse"; m.BaseSoundID = 0xA8; break;
							case 3: m.Body = 21; m.Name = "a serpent"; m.Hue = Utility.RandomMonsterHue(); m.BaseSoundID = 219;break;
							case 4: 
								switch ( Utility.RandomMinMax( 1, 3 ) )
								{
									case 1: m.Body = 277; m.Name = "a black wolf"; m.Hue = 0xB3A; m.BaseSoundID = 0xE5; break;
									case 2: m.Body = 277; m.Name = "a dire wolf"; m.Hue = 0xB61; m.BaseSoundID = 0xE5; break;
									case 3: m.Body = 277; m.Name = "a white wolf"; m.Hue = 0x9C3; m.BaseSoundID = 0xE5; break;
								}
							break;
							case 5: 
								switch ( Utility.RandomMinMax( 1, 7 ) )
								{
									case 1: m.Body = 118; m.Name = "a crag cat"; m.BaseSoundID = 0x462; break;
									case 2: m.Body = 187; m.Name = "a lion"; m.BaseSoundID = 0x3EE; break;
									case 3: m.Body = 187; m.Name = "a snow lion"; m.BaseSoundID = 0x3EE; m.Hue = 0x9C2; break;
									case 4: m.Body = 885; m.Name = "a panther"; m.BaseSoundID = 0x3EE; m.Hue = 0x96C; break;
									case 5: m.Body = 340; m.Name = "a hell lion"; m.BaseSoundID = 0x3EE; m.Hue = 0x4AA; break;
									case 6: m.Body = 340; m.Name = "a tiger"; m.BaseSoundID = 0x3EE; m.Hue = 0x54F; break;
									case 7: m.Body = 340; m.Name = "a tiger"; m.BaseSoundID = 0x3EE; m.Hue = 0x9C2; break;
								}
							break;
							case 6: 
								switch ( Utility.RandomMinMax( 1, 2 ) )
								{
									case 1: m.Body = Utility.RandomList( 0x1D, 161 ); m.Name = "a gorilla"; m.BaseSoundID = 0x9E; break;
									case 2: m.Body = 332; m.Name = "an ape"; m.BaseSoundID = 0x3EE; m.Hue = 0x902; break;
								}
							break;
							case 7: 
								switch ( Utility.RandomMinMax( 1, 2 ) )
								{
									case 1: m.Body = 81; m.Name = "a frog"; m.BaseSoundID = 0x266; m.Hue = Utility.RandomList( 0x7D7, 0x7D8, 0x7D9, 0x7DA, 0x7DB, 0x7DC ); break;
									case 2: m.Body = 80; m.Name = "a toad"; m.BaseSoundID = 0x26B; m.Hue = Utility.RandomList( 0, 0xB79, 0xB19, 0xB0D, 0xACE, 0xACF, 0xAB0 ); break;
								}
							break;
							case 8: 
								switch ( Utility.RandomMinMax( 1, 4 ) )
								{
									case 1: m.Body = 243; m.Name = "a phoenix"; m.BaseSoundID = 0x8F; m.Hue = 0xB73; break;
									case 2: m.Body = 243; m.Name = "a roc"; m.BaseSoundID = 0x2EE; break;
									case 3: m.Body = 243; m.Name = "a hawk"; m.BaseSoundID = 0x2EE; m.Hue = 2708; break;
									case 4: m.Body = 243; m.Name = "a raven"; m.BaseSoundID = 0x2EE; m.Hue = 0x497; break;
								}
							break;
							case 9: 
								switch ( Utility.RandomMinMax( 1, 7 ) )
								{
									case 1: m.Body = 672; m.Name = "a pegasus"; m.BaseSoundID = 0xA8; m.Hue = 2500; break;
									case 2: m.Body = 672; m.Name = "a placeron"; m.BaseSoundID = 0xA8; m.Hue = 0x99E; break;
									case 3: m.Body = 132; m.Name = "a kirin"; m.BaseSoundID = 0x3C5; break;
									case 4: m.Body = 354; m.Name = "a dreadhorn"; m.BaseSoundID = 0x4BC; break;
									case 5: m.Body = 0x7A; m.Name = "a unicorn"; m.BaseSoundID = 0x4BC; break;
									case 6: m.Body = 226; m.Name = "a nightmare"; m.BaseSoundID = 0xA8; m.Hue = 1109; break;
									case 7: m.Body = 795; m.Name = "an ancient nightmare"; m.BaseSoundID = 0xA8; break;
								}
							break;
							case 10: m.Body = Utility.RandomList( 116, 117, 219 ); m.Name = "a raptor"; m.BaseSoundID = 0x5A; break;
							case 11: 
								int roll = Utility.RandomMinMax( 1, 6 );
									if ( spawned ){ roll = 5; }
								switch ( roll )
								{
									case 1: m.Body = 19; m.Name = "a grum"; m.BaseSoundID = 0xA3; break;
									case 2: m.Body = Utility.RandomList(98, 97); m.Name = "an alien"; m.BaseSoundID = 959; break;
									case 3: m.Body = Utility.RandomList(334, 752); m.Name = "a golem"; m.BaseSoundID = 1368; break;
									case 4: m.Body = Utility.RandomList(705, 697, 934); m.Name = "a dinosaur"; m.BaseSoundID = 362; break;
									case 5: m.Body = 0x11C; m.Name = "a gorgon"; m.BaseSoundID = 0xA3; m.Hue = 0xB63; break;
								}
							break;
						}
					}
				}
				else
				{
					switch ( Utility.RandomMinMax( 1, 62 ) )
					{
						case 1: m.Body = 343; m.Name = NameList.RandomName( "giant" ); m.BaseSoundID = 427; break; // bugbear
						case 2: m.Body = 176; m.Name = NameList.RandomName( "gargoyle vendor" ); m.Title = "the kilrathi"; m.BaseSoundID = 0x3EE; break; // cat
						case 3: m.Body = 162; m.Name = NameList.RandomName( "savage" ); m.BaseSoundID = 427; break; // caveman
						case 4: m.Body = 101; m.Name = NameList.RandomName( "centaur" ); m.BaseSoundID = 679; break; // centaur
						case 5: m.Body = 65; m.Name = NameList.RandomName( "vampire" ); m.BaseSoundID = 0x47D; break; // death knight
						case 6: m.Body = 593; m.Name = NameList.RandomName( "dwarf" ); m.Female = false; break; // dwarf
						case 7: m.Body = 597; m.Name = NameList.RandomName( "dwarf" ); m.Female = false; break; // dwarf
						case 8: m.Body = 598; m.Name = NameList.RandomName( "dwarf" ); m.Female = false; break; // dwarf
						case 9: m.Body = 676; m.Name = NameList.RandomName( "cthulhu" ); m.BaseSoundID = 0x553; break; // fish
						case 10: m.Body = 677; m.Name = NameList.RandomName( "cthulhu" ); m.BaseSoundID = 0x553; break; // fish
						case 11: m.Body = 678; m.Name = NameList.RandomName( "cthulhu" ); m.BaseSoundID = 0x553; break; // fish
						case 12: m.Body = 690; m.Name = NameList.RandomName( "cthulhu" ); m.BaseSoundID = 0x553; break; // fish
						case 13: m.Body = 127; m.Name = NameList.RandomName( "gargoyle name" ); m.BaseSoundID = 372; break; // gargoyle
						case 14: m.Body = 510; m.Name = NameList.RandomName( "giant" ); m.BaseSoundID = 0x4F5; break; // gnoll
						case 15: m.Body = 632; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // goblin
						case 16: m.Body = 647; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // goblin
						case 17: m.Body = 592; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // goblin
						case 18: m.Body = 11; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 0x45A; break; // hobgoblin
						case 19: m.Body = 328; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 0x45A; break; // hobgoblin
						case 20: m.Body = 108; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 0x45A; break; // hobgoblin
						case 21: m.Body = 245; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // kobold
						case 22: m.Body = 253; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // kobold
						case 23: m.Body = 255; m.Name = NameList.RandomName( "goblin" ); m.BaseSoundID = 422; break; // kobold
						case 24: m.Body = 33; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 25: m.Body = 35; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 26: m.Body = 36; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 27: m.Body = 324; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 28: m.Body = 326; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 29: m.Body = 333; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 30: m.Body = 534; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 31: m.Body = 541; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 32: m.Body = 373; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 33: m.Body = 374; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 34: m.Body = 375; m.Name = NameList.RandomName( "lizardman" ); m.BaseSoundID = 417; break; // lizard
						case 35: m.Body = 78; m.Name = NameList.RandomName( "greek" ); m.BaseSoundID = 0x54E; break; // minotaur
						case 36: m.Body = 650; m.Name = NameList.RandomName( "greek" ); m.BaseSoundID = 0x54E; break; // minotaur
						case 37: m.Body = 107; m.Name = NameList.RandomName( "greek" ); m.BaseSoundID = 0x54E; break; // minotaur
						case 38: m.Body = 281; m.Name = NameList.RandomName( "greek" ); m.BaseSoundID = 0x54E; break; // minotaur
						case 39: 
							switch ( Utility.RandomMinMax( 1, 2 ) )
							{
								case 1: m.Body = 356; m.Name = NameList.RandomName( "pixie" ); m.BaseSoundID = 0x467; break;
								case 2: m.Body = 128; m.Name = NameList.RandomName( "pixie" ); m.BaseSoundID = 0x467; break;
							}
						break;
						case 40: m.Body = 145; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // naga
						case 41: m.Body = 704; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // naga
						case 42: m.Body = 7; m.Name = NameList.RandomName( "urk" ); m.BaseSoundID = 0x45A; break; // orc
						case 43: m.Body = 17; m.Name = NameList.RandomName( "ork" ); m.BaseSoundID = 0x45A; break; // orc
						case 44: m.Body = 41; m.Name = NameList.RandomName( "urk" ); m.BaseSoundID = 0x45A; break; // orc
						case 45: m.Body = 157; m.Name = NameList.RandomName( "ork" ); m.BaseSoundID = 0x45A; break; // orc
						case 46: m.Body = 20; m.Name = NameList.RandomName( "orc" ); m.BaseSoundID = 0x45A; break; // orc
						case 47: m.Body = 252; m.Name = NameList.RandomName( "orc" ); m.BaseSoundID = 0x45A; break; // orc
						case 48: m.Body = 42; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 49: m.Body = 44; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 50: m.Body = 45; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 51: m.Body = 163; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 52: m.Body = 164; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 53: m.Body = 165; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 54: m.Body = 73; m.Name = NameList.RandomName( "ratman" ); m.BaseSoundID = 437; break; // rat
						case 55: m.Body = 271; m.Name = NameList.RandomName( "druid" ); m.BaseSoundID = 0x586; break; // satyr
						case 56: m.Body = 85; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 57: m.Body = 86; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 58: m.Body = 87; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 59: m.Body = 306; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 60: m.Body = 371; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 61: m.Body = 372; m.Name = NameList.RandomName( "drakkul" ); m.BaseSoundID = 644; break; // snake
						case 62: m.Body = 689; m.Name = NameList.RandomName( "goddess" ); m.BaseSoundID = 0x4B0; break; // succubus
					}
				}
			}
		}

		public Humanoid( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}