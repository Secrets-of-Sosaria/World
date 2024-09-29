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

			PackItem( new BeginnerBook() );

			//---------------------------------------------
			if ( MyServerSettings.StartingGold() > 0 )
				PackItem( new Gold( MyServerSettings.StartingGold() ) );

			PackItem( new Pitcher( BeverageType.Water ) );

			switch ( Utility.RandomMinMax( 1, 2 ) )
			{
				case 1: PackItem( new Dagger() ); break;
				case 2: PackItem( new LargeKnife() ); break;
			}
			//---------------------------------------------
			Container bag = new Bag();
			int food = 10;
			while ( food > 0 )
			{
				food--;
				bag.DropItem( Loot.RandomFoods( true, true ) );
			}
			PackItem( bag );
			//---------------------------------------------
			int light = 2;
			while ( light > 0 )
			{
				light--;
				switch ( Utility.RandomMinMax( 1, 3 ) )
				{
					case 1: PackItem( new Torch() ); break;
					case 2: PackItem( new Lantern() ); break;
					case 3: PackItem( new Candle() ); break;
				}
			}
			//---------------------------------------------

			((PlayerMobile)m).WeaponBarOpen = 1;
			((PlayerMobile)m).GumpHue = 1;
		}

		private static void PlaceItemIn( Container parent, int x, int y, Item item )
		{
			parent.AddItem( item );
			item.Location = new Point3D( x, y, 0 );
		}

		private static void AddShirt( Mobile m, int shirtHue )
		{
			int hue = Utility.ClipDyedHue( shirtHue & 0x3FFF );

			switch ( Utility.Random( 3 ) )
			{
				case 0: EquipItem( new Shirt( hue ), true ); break;
				case 1: EquipItem( new FancyShirt( hue ), true ); break;
				case 2: EquipItem( new Doublet( hue ), true ); break;
			}
		}

		private static void AddPants( Mobile m, int pantsHue )
		{
			int hue = Utility.ClipDyedHue( pantsHue & 0x3FFF );

			if ( m.Female )
			{
				switch ( Utility.Random( 2 ) )
				{
					case 0: EquipItem( new Skirt( hue ), true ); break;
					case 1: EquipItem( new Kilt( hue ), true ); break;
				}
			}
			else
			{
				switch ( Utility.Random( 2 ) )
				{
					case 0: EquipItem( new LongPants( hue ), true ); break;
					case 1: EquipItem( new ShortPants( hue ), true ); break;
				}
			}
		}

		private static void AddShoes( Mobile m )
		{
			EquipItem( new Shoes( Utility.RandomYellowHue() ), true );
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
			SetSkills( newChar, args.Skills, args.Profession );

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

		private static void SetSkills( Mobile m, SkillNameValue[] skills, int prof )
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
						return;

					break;
				}
			}

			for ( int i = 0; i < skills.Length; ++i )
			{
				SkillNameValue snv = skills[i];

				if ( snv.Value > 0 && ( snv.Name != SkillName.Stealth || prof == 7 ) && snv.Name != SkillName.RemoveTrap && snv.Name != SkillName.Elementalism )
				{
					Skill skill = m.Skills[snv.Name];

					if ( skill != null )
					{
						skill.BaseFixedPoint = snv.Value * 10;
					}
				}
			}
		}

		private static void EquipItem( Item item )
		{
			EquipItem( item, false );
		}

		private static void EquipItem( Item item, bool mustEquip )
		{
			if ( m_Mobile != null && m_Mobile.EquipItem( item ) )
				return;

			Container pack = m_Mobile.Backpack;

			if ( !mustEquip && pack != null )
				pack.DropItem( item );
			else
				item.Delete();
		}

		private static void PackItem( Item item )
		{
			Container pack = m_Mobile.Backpack;

			if ( pack != null )
				pack.DropItem( item );
			else
				item.Delete();
		}
	}
}