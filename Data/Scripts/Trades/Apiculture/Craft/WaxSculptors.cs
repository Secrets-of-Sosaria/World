using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Mobiles;
using Server.Misc;

namespace Server.Items
{
	public class WaxSculptorsA : WaxSculptors
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxSculptorsA()
		{
			Weight = 5.0;
			Name = "wax sculptor";
            SculptorsFlipID1 = 0x1225;
            SculptorsFlipID2 = 0x1225;
			ItemID = SculptorsFlipID1;
		}

		public WaxSculptorsA( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( SculptorsFlipID1 );
            writer.Write( SculptorsFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            SculptorsFlipID1 = reader.ReadInt();
            SculptorsFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxSculptorsB : WaxSculptors
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxSculptorsB()
		{
			Weight = 5.0;
			Name = "wax sculptor";
            SculptorsFlipID1 = 0x139A;
            SculptorsFlipID2 = 0x1224;
			ItemID = SculptorsFlipID1;
		}

		public WaxSculptorsB( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( SculptorsFlipID1 );
            writer.Write( SculptorsFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            SculptorsFlipID1 = reader.ReadInt();
            SculptorsFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxSculptorsC : WaxSculptors
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxSculptorsC()
		{
			Weight = 5.0;
			Name = "wax sculptor";
            SculptorsFlipID1 = 0x12CA;
            SculptorsFlipID2 = 0x12CB;
			ItemID = SculptorsFlipID1;
		}

		public WaxSculptorsC( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( SculptorsFlipID1 );
            writer.Write( SculptorsFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            SculptorsFlipID1 = reader.ReadInt();
            SculptorsFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	[Flipable( 0x139B, 0x1226 )]
	public class WaxSculptorsD : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxSculptorsD() : base( 0x139B )
		{
			Weight = 5.0;
			Name = "wax sculptor of an angel";
			Hue = 0x47E;
		}

		public WaxSculptorsD( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxSculptorsE : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxSculptorsE() : base( 0x42BB )
		{
			Weight = 10.0;
			Name = "wax sculptor of a dragon";
		}

		public WaxSculptorsE( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxSculptors : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		public int SculptorsFlipID1;
		public int SculptorsFlipID2;

		[CommandProperty(AccessLevel.Owner)]
		public int Sculptors_FlipID1 { get { return SculptorsFlipID1; } set { SculptorsFlipID1 = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Sculptors_FlipID2 { get { return SculptorsFlipID2; } set { SculptorsFlipID2 = value; InvalidateProperties(); } }

		[Constructable]
		public WaxSculptors() : base( 0x1227 )
		{
			Weight = 5.0;
			Name = "wax sculptor";
            SculptorsFlipID1 = 0x1227;
            SculptorsFlipID2 = 0x139C;
			ItemID = SculptorsFlipID1;
			Hue = 0x47E;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendMessage( "Select the character you wish to have this sculptor represent." );
				t = new WaxTarget( this );
				from.Target = t;
			}
		}

		private class WaxTarget : Target
		{
			private Item m_Wax;

			public WaxTarget( Item pics ) : base( 10, false, TargetFlags.None )
			{
				m_Wax = pics;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					Mobile carving = (Mobile)targeted;

					if ( carving.Body == 606 || carving.Body == 605 || carving.Body == 0x191 || carving.Body == 0x190 )
					{
						string sTitle = "the " + GetSkillTitle( carving );
						if ( carving.Title != null ){ sTitle = carving.Title; }
						sTitle = sTitle.Replace("  ", String.Empty);
						m_Wax.Name = "wax sculptor of " + carving.Name + " " + sTitle;
						from.SendMessage( "This wax sculptor is now of that person." );
					}
					else
					{
						from.SendMessage( "This wax sculptor doesn't even look like that." );
					}
				}
				else if ( (Item)targeted == m_Wax )
				{
					string fakeName = "";
					if ( Utility.RandomMinMax( 1, 2 ) == 1 ) 
					{ 
						fakeName = NameList.RandomName( "female" );
					}
					else 
					{ 		
						fakeName = NameList.RandomName( "male" ); 
					}
					fakeName = fakeName + " " + TavernPatrons.GetTitle();
					m_Wax.Name = "sculptor of " + fakeName;
					from.SendMessage( "This wax sculptor is now of a fictional character." );
				}
				else
				{
					from.SendMessage( "This wax sculptor doesn't even look like that." );
				}
			}
		}

		public WaxSculptors( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( SculptorsFlipID1 );
            writer.Write( SculptorsFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            SculptorsFlipID1 = reader.ReadInt();
            SculptorsFlipID2 = reader.ReadInt();
		}

		public static string GetSkillTitle( Mobile mob ) {
			Skill highest = GetHighestSkill( mob );// beheld.Skills.Highest;

			if ( highest != null && highest.BaseFixedPoint >= 300 )
			{
				string skillLevel = GetSkillLevel( highest );
				string skillTitle = highest.Info.Title;
				if ( skillTitle.Contains("Detective") ){ skillTitle = skillTitle.Replace("Detective", "Undertaker"); }

				if ( mob.Female && skillTitle.EndsWith( "man" ) )
					skillTitle = skillTitle.Substring( 0, skillTitle.Length - 3 ) + "woman";

				return String.Concat( skillLevel, " ", skillTitle );
			}

			return null;
		}

		private static Skill GetHighestSkill( Mobile m )
		{
			Skills skills = m.Skills;

			if ( !Core.AOS )
				return skills.Highest;

			Skill highest = null;

			for ( int i = 0; i < m.Skills.Length; ++i )
			{
				Skill check = m.Skills[i];

				if ( highest == null || check.BaseFixedPoint > highest.BaseFixedPoint )
					highest = check;
				else if ( highest != null && highest.Lock != SkillLock.Up && check.Lock == SkillLock.Up && check.BaseFixedPoint == highest.BaseFixedPoint )
					highest = check;
			}

			return highest;
		}

		private static string[,] m_Levels = new string[,]
			{
				{ "Neophyte",		"Neophyte",		"Neophyte"		},
				{ "Novice",			"Novice",		"Novice"		},
				{ "Apprentice",		"Apprentice",	"Apprentice"	},
				{ "Journeyman",		"Journeyman",	"Journeyman"	},
				{ "Expert",			"Expert",		"Expert"		},
				{ "Adept",			"Adept",		"Adept"			},
				{ "Master",			"Master",		"Master"		},
				{ "Grandmaster",	"Grandmaster",	"Grandmaster"	},
				{ "Elder",			"Tatsujin",		"Shinobi"		},
				{ "Legendary",		"Kengo",		"Ka-ge"			}
			};

		private static string GetSkillLevel( Skill skill )
		{
			return m_Levels[GetTableIndex( skill ), GetTableType( skill )];
		}

		private static int GetTableType( Skill skill )
		{
			switch ( skill.SkillName )
			{
				default: return 0;
				case SkillName.Bushido: return 1;
				case SkillName.Ninjitsu: return 2;
			}
		}

		private static int GetTableIndex( Skill skill )
		{
			int fp = Math.Min( skill.BaseFixedPoint, 1200 );

			return (fp - 300) / 100;
		}
	}
}