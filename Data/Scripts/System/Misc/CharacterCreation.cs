using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Accounting;
using System.Collections.Generic; //Unique Naming System//

namespace Server.Misc
{
	public class CharacterCreation
	{
		public const string GENERIC_NAME = "Generic Player"; //Unique Naming System//
		public static void Initialize()
		{
			// Register our event handler
			EventSink.CharacterCreated += new CharacterCreatedEventHandler( EventSink_CharacterCreated );
		}

		private static void AddBackpack( Mobile m )
		{
			Container pack = m.Backpack;

			if ( pack == null )
			{
				pack = new Backpack();
				pack.Movable = false;

				m.AddItem( pack );
			}

			PackItem(pack, new BeginnerBook() );

			//---------------------------------------------
			if ( MyServerSettings.StartingGold() > 0 )
				PackItem(pack, new Gold( MyServerSettings.StartingGold() ) );

			PackItem(pack,  new Pitcher( BeverageType.Water ) );

			switch ( Utility.RandomMinMax( 1, 2 ) )
			{
				case 1: PackItem(pack,  new Dagger() ); break;
				case 2: PackItem(pack,  new LargeKnife() ); break;
			}
			//---------------------------------------------
			Container bag = new Bag();
			int food = 10;
			while ( food > 0 )
			{
				food--;
				bag.DropItem( Loot.RandomFoods( true, true ) );
			}
			PackItem(pack,  bag );
			//---------------------------------------------
			switch ( Utility.RandomMinMax( 1, 3 ) )
			{
				case 1: PackItem(pack, new Torch() ); break;
				case 2: PackItem(pack, new Lantern() ); break;
				case 3: PackItem(pack, new Candle() ); break;
			}
			//---------------------------------------------

			((PlayerMobile)m).WeaponBarOpen = 1;
			((PlayerMobile)m).GumpHue = 1;
		}

		private static Mobile CreateMobile( Account a )
		{
			if ( a.Count >= a.Limit )
				return null;

			for ( int i = 0; i < a.Length; ++i )
			{
				if ( a[i] == null )
					return (a[i] = new PlayerMobile());
			}

			return null;
		}

		private static void EventSink_CharacterCreated( CharacterCreatedEventArgs args )
		{
			if ( !VerifyProfession( args.Profession ) )
				args.Profession = 0;

			NetState state = args.State;

			if ( state == null )
				return;

			Mobile newChar = CreateMobile( args.Account as Account );

			if ( newChar == null )
			{
				Console.WriteLine( "Login: {0}: Character creation failed, account full", state );
				return;
			}

			args.Mobile = newChar;
			m_Mobile = newChar;

			newChar.Player = true;
			newChar.StatCap = 250; 
			MyServerSettings.SkillBegin( "default", (PlayerMobile)newChar );
			newChar.AccessLevel = args.Account.AccessLevel;
			newChar.Female = args.Female;
			newChar.Race = Race.Human;
			newChar.RaceMakeSounds = true;

			newChar.Hue = newChar.Race.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;

			if ( newChar.Hue >= 33770 ){ newChar.Hue = newChar.Hue - 32768; }

			newChar.Hunger = 20;
			newChar.Thirst = 20;

			bool young = false;

			if ( newChar is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile) newChar;
				pm.PublicInfo = true;
				young = pm.Young = false;
			}

			SetName( newChar, args.Name );

			AddBackpack( newChar );

			SetStats( newChar, state, args.Str, args.Dex, args.Int );
			SkillNameValue[] setSkills = SetSkills( newChar, args.Skills, args.Profession );
			AddSkillBasedItems(newChar, setSkills);

			newChar.Mana = args.Int * 2;
			newChar.Hits = args.Str * 2;
			newChar.Stam = args.Dex * 2;

			Race race = newChar.Race;

			if( race.ValidateHair( newChar, args.HairID ) )
			{
				newChar.HairItemID = args.HairID;
				newChar.HairHue = race.ClipHairHue( args.HairHue );
				newChar.RecordsHair( true );
			}

			if( race.ValidateFacialHair( newChar, args.BeardID ) )
			{
				newChar.FacialHairItemID = args.BeardID;
				newChar.FacialHairHue = race.ClipHairHue( args.BeardHue );
				newChar.RecordsHair( true );
			}

			Server.Misc.IntelligentAction.DressUpMerchants( newChar );

			switch ( Utility.RandomMinMax( 1, 3 ) )
			{
				case 1: Item torch = new Torch(); 		newChar.AddItem( torch ); 	torch.OnDoubleClick( newChar); 	break;
				case 2: Item lamp = new Lantern(); 		newChar.AddItem( lamp ); 	lamp.OnDoubleClick( newChar); 	break;
				case 3: Item candle = new Candle(); 	newChar.AddItem( candle );	candle.OnDoubleClick( newChar); break;
			}

			newChar.RecordFeatures( true );

			CityInfo city = new CityInfo( "Sosaria", "Forest", 3579, 3423, 0, Map.Sosaria );

			newChar.MoveToWorld( city.Location, city.Map );

			Console.WriteLine( "Login: {0}: New character being created (account={1})", state, args.Account.Username );

			new WelcomeTimer( newChar ).Start();
		}

		public static bool VerifyProfession( int profession )
		{
			if ( profession < 0 )
				return false;
			else if ( profession < 4 )
				return true;
			else if ( Core.AOS && profession < 6 )
				return true;
			else if ( Core.SE && profession < 8 )
				return true;
			else
				return false;
		}

		private class BadStartMessage : Timer
		{
			Mobile m_Mobile;
			int m_Message;
			public BadStartMessage( Mobile m, int message ) : base( TimeSpan.FromSeconds ( 3.5 ) )
			{
				m_Mobile = m;
				m_Message = message;
				this.Start();
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( m_Message );
			}
		}

		private static void FixStats( ref int str, ref int dex, ref int intel, int max )
		{
			int vMax = max - 30;

			int vStr = str - 10;
			int vDex = dex - 10;
			int vInt = intel - 10;

			if ( vStr < 0 )
				vStr = 0;

			if ( vDex < 0 )
				vDex = 0;

			if ( vInt < 0 )
				vInt = 0;

			int total = vStr + vDex + vInt;

			if ( total == 0 || total == vMax )
				return;

			double scalar = vMax / (double)total;

			vStr = (int)(vStr * scalar);
			vDex = (int)(vDex * scalar);
			vInt = (int)(vInt * scalar);

			FixStat( ref vStr, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vDex, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vInt, (vStr + vDex + vInt) - vMax, vMax );

			str = vStr + 10;
			dex = vDex + 10;
			intel = vInt + 10;
		}

		private static void FixStat( ref int stat, int diff, int max )
		{
			stat += diff;

			if ( stat < 0 )
				stat = 0;
			else if ( stat > max )
				stat = max;
		}

		private static void SetStats( Mobile m, NetState state, int str, int dex, int intel )
		{
			int max = state.NewCharacterCreation ? 90 : 80;

			FixStats( ref str, ref dex, ref intel, max );

			if ( str < 10 || str > 60 || dex < 10 || dex > 60 || intel < 10 || intel > 60 || (str + dex + intel) != max )
			{
				str = 10;
				dex = 10;
				intel = 10;
			}

			m.InitStats( str, dex, intel );
		}

		private static void SetName( Mobile m, string name )
		{
			name = name.Trim();

			if (!CheckDupe(m, name))
				m.Name = GENERIC_NAME;
			else
				m.Name = name;
		}
      
		public static bool CheckDupe( Mobile m, string name )
		{
			if( m == null || name == null || name.Length == 0 )
				return false;

			name = name.Trim(); //Trim the name and re-assign it

			if( !NameVerification.Validate( name, 2, 16, true, true, true, 1, NameVerification.SpaceDashPeriodQuote ) )
				return false;

			foreach( Mobile wm in World.Mobiles.Values )
			{
				if( wm != m && !wm.Deleted && wm is PlayerMobile && Insensitive.Equals(wm.RawName, name) ) //Filter Mobiles by PlayerMobile type and do the name check in one go, no need for another list.
					return false; // No need to clear anything since we did not make any temporary lists.
			}

			return true;
		}

		private static bool ValidSkills( SkillNameValue[] skills )
		{
			int total = 0;

			for ( int i = 0; i < skills.Length; ++i )
			{
				if ( skills[i].Value < 0 || skills[i].Value > 50 )
					return false;

				total += skills[i].Value;

				for ( int j = i + 1; j < skills.Length; ++j )
				{
					if ( skills[j].Value > 0 && skills[j].Name == skills[i].Name )
						return false;
				}
			}

			return ( total == 100 || total == 120 );
		}

		private static Mobile m_Mobile;

		private static SkillNameValue[] SetSkills( Mobile m, SkillNameValue[] skills, int prof )
		{
			switch ( prof )
			{
				case 6: // Mage
				{
					m.InitStats( 15, 20, 45 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Magery, 35 ),
							new SkillNameValue( SkillName.Psychology, 35 ),
							new SkillNameValue( SkillName.MagicResist, 30 )
						};

					break;
				}
				case 7:	// Archer
				{
					m.InitStats( 30, 35, 15 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Marksmanship, 35 ),
							new SkillNameValue( SkillName.Tactics, 35 ),
							new SkillNameValue( SkillName.Bowcraft, 30 )
						};
					break;
				}
				case 5:	// Warrior
				{
					m.InitStats( 50, 20, 10 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Swords, 35 ),
							new SkillNameValue( SkillName.Tactics, 35 ),
							new SkillNameValue( SkillName.Parry, 30 )
						};
					break;
				}
				case 4: // Necromancer
				{
					m.InitStats( 15, 20, 45 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Necromancy, 35 ),
							new SkillNameValue( SkillName.Spiritualism, 35 ),
							new SkillNameValue( SkillName.MagicResist, 30 )
						};

					break;
				}
				case 1: // Thief
				{
					m.InitStats( 20, 40, 20 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Stealing, 35 ),
							new SkillNameValue( SkillName.Snooping, 35 ),
							new SkillNameValue( SkillName.Lockpicking, 30 )
						};

					break;
				}
				case 2: // Bard
				{
					m.InitStats( 25, 30, 20 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Musicianship, 35 ),
							new SkillNameValue( SkillName.Peacemaking, 35 ),
							new SkillNameValue( SkillName.Discordance, 30 )
						};

					break;
				}
				case 3: // Druid
				{
					m.InitStats( 20, 20, 40 ); // 80
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Druidism, 35 ),
							new SkillNameValue( SkillName.Taming, 35 ),
							new SkillNameValue( SkillName.Veterinary, 30 )
						};

					break;
				}
				default:
				{
					if ( !ValidSkills( skills ) )
						return new SkillNameValue[] { };

					break;
				}
			}

			for ( int i = 0; i < skills.Length; ++i )
			{
				SkillNameValue snv = skills[i];

				if ( snv.Value > 0 && ( snv.Name != SkillName.Stealth || prof == 1 ) && snv.Name != SkillName.RemoveTrap && snv.Name != SkillName.Elementalism )
				{
					Skill skill = m.Skills[snv.Name];

					if ( skill != null )
					{
						skill.BaseFixedPoint = snv.Value * 10;
					}
				}
			}

			return skills;
		}

		private static void PackItem(Container pack, int count, Func<Item> itemFactory)
		{
			for (var i = 0; i < count; i++)
			{
				PackItem(pack, itemFactory());
			}
		}

		private static void PackItem(Container pack, Item item)
		{
			if (pack != null)
			{
				pack.DropItem(item);
			}
			else
				item.Delete();
		}

		private static void PackInstruments(Bag bag)
		{
			switch (Utility.RandomMinMax(1, 4))
			{
				case 1: PackItem(bag, new Lute()); break;
				case 2: PackItem(bag, new BambooFlute()); break;
				case 3: PackItem(bag, new LapHarp()); break;
				case 4: PackItem(bag, new Tambourine()); break;
			}
		}

		private static void PackRandomGold(Bag bag, int min, int max)
		{
			PackItem(bag, new Gold { Amount = Utility.RandomMinMax(min, max) });
		}

		private static void AddSkillBasedItems(Mobile m, SkillNameValue[] skills)
		{
			for (int i = 0; i < skills.Length; i++)
			{
				var skill = skills[i];
				if (skill.Value == 0) continue;

				Bag bag = new Bag { Name = m.Skills[skill.Name].Name };
				m.Backpack.AddItem(bag);

				switch (skill.Name)
				{
					case SkillName.Alchemy:
						PackItem(bag, new MortarPestle());
						PackItem(bag, new Bottle { Amount = 15 });
						break;

					case SkillName.Anatomy:
						PackItem(bag, new Bandage { Amount = 250 });
						break;

					case SkillName.Druidism:
						PackItem(bag, new DruidCauldron());
						PackItem(bag, new BookDruidBrewing());
						break;

					case SkillName.Mercantile:
					case SkillName.ArmsLore:
					case SkillName.Begging:
					case SkillName.Searching:
					case SkillName.Psychology:
					case SkillName.Snooping:
					case SkillName.Spiritualism:
					case SkillName.Stealing:
					case SkillName.Meditation:
					case SkillName.Focus:
						PackRandomGold(bag, 50, 125);
						break;

					case SkillName.Parry:
						PackItem(bag, new Buckler());
						break;

					case SkillName.Blacksmith:
						PackItem(bag, new SmithHammer());
						PackItem(bag, new IronIngot { Amount = 50 });
						break;

					case SkillName.Bowcraft:
						PackItem(bag, new FletcherTools());
						PackItem(bag, new Board { Amount = 50 });
						PackItem(bag, new Feather { Amount = 50 });
						break;

					case SkillName.Peacemaking:
					case SkillName.Discordance:
					case SkillName.Provocation:
					case SkillName.Musicianship:
						PackInstruments(bag);
						break;

					case SkillName.Camping:
						PackItem(bag, new SmallTent());
						PackItem(bag, new Kindling { Amount = 10 });
						break;

					case SkillName.Carpentry:
						PackItem(bag, new CarpenterTools());
						PackItem(bag, new Board { Amount = 50 });
						break;

					case SkillName.Cartography:
						PackItem(bag, new MapmakersPen());
						PackItem(bag, new BlankScroll { Amount = 50 });
						break;

					case SkillName.Cooking:
						PackItem(bag, new CulinarySet());
						PackItem(bag, new RawBird { Amount = 5 });
						break;

					case SkillName.Healing:
						PackItem(bag, new Scissors());
						PackItem(bag, new Bandage { Amount = 250 });
						break;

					case SkillName.Seafaring:
						PackItem(bag, new FishingPole());
						PackItem(bag, new Fish());
						PackItem(bag, new RawFishSteak(3));
						break;

					case SkillName.Forensics:
						PackItem(bag, new SkinningKnife());
						PackItem(bag, new GraveSpade());
						break;

					case SkillName.Herding:
						PackItem(bag, new ShepherdsCrook());
						PackItem(bag, new CagedSheep { Weight = 10 });
						break;

					case SkillName.Hiding:
						PackItem(bag, new LeatherNinjaHood());
						PackItem(bag, new LeatherNinjaJacket());
						break;

					case SkillName.Inscribe:
						PackItem(bag, new Monocle());
						PackItem(bag, new ScribesPen());
						PackItem(bag, new BlankScroll { Amount = 50 });
						break;

					case SkillName.Lockpicking:
						PackItem(bag, new Lockpick { Amount = 10 });
						PackItem(bag, new PickBoxDifficult { Movable = true });
						break;

					case SkillName.Magery:
						PackItem(bag, new Spellbook());
						PackItem(bag, new HealScroll());
						PackItem(bag, new MagicArrowScroll());

						switch (Utility.RandomMinMax(1, 8))
						{
							case 1: PackItem(bag, new AgilityScroll()); break;
							case 2: PackItem(bag, new CunningScroll()); break;
							case 3: PackItem(bag, new CureScroll()); break;
							case 4: PackItem(bag, new HarmScroll()); break;
							case 5: PackItem(bag, new MagicTrapScroll()); break;
							case 6: PackItem(bag, new MagicUnTrapScroll()); break;
							case 7: PackItem(bag, new ProtectionScroll()); break;
							case 8: PackItem(bag, new StrengthScroll()); break;
						}

						var mageBag = new BagOfReagents();
						mageBag.Open(m);
						PackItem(bag, mageBag);
						break;

					case SkillName.MagicResist:
					case SkillName.Tactics:
						PackItem(bag, new RefreshPotion{ Amount = 3});
						PackItem(bag, new LesserCurePotion { Amount = 3 });
						PackItem(bag, new HealPotion { Amount = 3 });
						break;

					case SkillName.Poisoning:
						PackItem(bag, new LesserPoisonPotion { Amount = 6 });
						break;

					case SkillName.Marksmanship:
						PackItem(bag, new Bow());
						PackItem(bag, new RepeatingCrossbow());
						PackItem(bag, new Arrow { Amount = 50 });
						PackItem(bag, new Bolt { Amount = 50 });
						break;

					case SkillName.Tailoring:
						PackItem(bag, new Scissors());
						PackItem(bag, new SewingKit());
						PackItem(bag, new Fabric { Amount = 50 });
						break;

					case SkillName.Taming:
						switch (Utility.RandomMinMax(1, 4))
						{
							case 1: PackItem(bag, new CagedBlackBear { Weight = 10 }); break;
							case 2: PackItem(bag, new CagedPanther { Weight = 10 }); break;
							case 3: PackItem(bag, new CagedTimberWolf { Weight = 10 }); break;
							case 4: PackItem(bag, new CagedAlligator { Weight = 10 }); break;
						}
						break;

					case SkillName.Tasting:
						switch (Utility.RandomMinMax(1, 2))
						{
							case 1: PackItem(bag, new LesserCurePotion { Amount = 10 }); break;
							case 2: PackItem(bag, new HealPotion { Amount = 10 }); break;
						}
						break;

					case SkillName.Tinkering:
						PackItem(bag, new TinkerTools());
						PackItem(bag, new IronIngot { Amount = 50 });
						break;

					case SkillName.Tracking:
						PackItem(bag, new Spyglass());
						break;

					case SkillName.Veterinary:
						PackItem(bag, new Bandage { Amount = 200 });
						break;

					case SkillName.Swords:
						switch (Utility.RandomMinMax(1, 3))
						{
							case 1: PackItem(bag, new Bokuto()); break;
							case 2: PackItem(bag, new Cleaver()); break;
							case 3: PackItem(bag, new Cutlass()); break;
						}
						break;

					case SkillName.Bludgeoning:
						switch (Utility.RandomMinMax(1, 4))
						{
							case 1: PackItem(bag, new Tessen()); break;
							case 2: PackItem(bag, new Club()); break;
							case 3: PackItem(bag, new WildStaff()); break;
							case 4: PackItem(bag, new Mace()); break;
						}
						break;

					case SkillName.Fencing:
						switch (Utility.RandomMinMax(1, 4))
						{
							case 1: PackItem(bag, new Dagger()); break;
							case 2: PackItem(bag, new Kryss()); break;
							case 3: PackItem(bag, new AssassinSpike()); break;
							case 4: PackItem(bag, new Sai()); break;
						}
						break;

					case SkillName.FistFighting:
						PackItem(bag, new PugilistGloves());
						break;

					case SkillName.Lumberjacking:
						PackItem(bag, new Hatchet());
						PackItem(bag, new Hatchet());
						break;

					case SkillName.Mining:
						PackItem(bag, new Spade());
						PackItem(bag, new Spade());
						break;

					case SkillName.RemoveTrap:
						PackItem(bag, new TenFootPole { Weight = 20 });
						break;

					case SkillName.Necromancy:
						PackItem(bag, new NecromancerSpellbook());
						PackItem(bag, new PainSpikeScroll());
						PackItem(bag, new CurseWeaponScroll());
						var necroBag = new BagOfNecroReagents();
						necroBag.Open(m);
						PackItem(bag, necroBag);
						break;

					case SkillName.Knightship:
						PackItem(bag, new BookOfChivalry());
						break;

					case SkillName.Bushido:
						PackItem(bag, new BookOfBushido());
						break;

					case SkillName.Ninjitsu:
						PackItem(bag, new BookOfNinjitsu());
						break;

					case SkillName.Stealth:
						PackItem(bag, new LeatherNinjaMitts());
						PackItem(bag, new LeatherNinjaPants());
						break;

					case SkillName.Elementalism:
					case SkillName.Mysticism:
					case SkillName.Imbuing:
					case SkillName.Throwing:
						// Not pickable
						break;
				}
			}
		}
    }
}