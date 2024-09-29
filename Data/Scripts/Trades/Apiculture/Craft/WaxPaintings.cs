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
	public class WaxPaintingA : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingA()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA1;
            PaintingFlipID2 = 0xEA2;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingA( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingB : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingB()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA3;
            PaintingFlipID2 = 0xEA4;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingB( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingC : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingC()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEC8;
            PaintingFlipID2 = 0xE9F;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingC( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingD : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingD()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA8;
            PaintingFlipID2 = 0xEA7;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingD( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingE : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingE()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA5;
            PaintingFlipID2 = 0xEA6;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingE( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingF : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingF()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA8;
            PaintingFlipID2 = 0xEA7;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingF( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPaintingG : WaxPainting
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		[Constructable]
		public WaxPaintingG()
		{
			Weight = 5.0;
			Name = "painting";
            PaintingFlipID1 = 0x42B6;
            PaintingFlipID2 = 0x42B6;
			ItemID = PaintingFlipID1;
		}

		public WaxPaintingG( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
		}
	}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class WaxPainting : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Wax; } }

		public int PaintingFlipID1;
		public int PaintingFlipID2;

		[CommandProperty(AccessLevel.Owner)]
		public int Painting_FlipID1 { get { return PaintingFlipID1; } set { PaintingFlipID1 = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Painting_FlipID2 { get { return PaintingFlipID2; } set { PaintingFlipID2 = value; InvalidateProperties(); } }

		[Constructable]
		public WaxPainting() : base( 0xEA0 )
		{
			Weight = 10.0;
			Name = "painting";
            PaintingFlipID1 = 0xEA0;
            PaintingFlipID2 = 0xEA0;
			ItemID = PaintingFlipID1;
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
				from.SendMessage( "Select the character you wish to have this painting represent." );
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
					Mobile portrait = (Mobile)targeted;

					if ( portrait.Body == 606 || portrait.Body == 605 || portrait.Body == 0x191 || portrait.Body == 0x190 )
					{
						string sTitle = "the " + GetSkillTitle( portrait );
						if ( portrait.Title != null ){ sTitle = portrait.Title; }
						sTitle = sTitle.Replace("  ", String.Empty);
						m_Wax.Name = "painting of " + portrait.Name + " " + sTitle;
						from.SendMessage( "This painting is now of that person." );
					}
					else
					{
						from.SendMessage( "This painting doesn't even look like that." );
					}
				}
				else if ( targeted is Item && (Item)targeted == m_Wax )
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
					m_Wax.Name = "painting of " + fakeName;
					from.SendMessage( "This painting is now of a fictional character." );
				}
				else
				{
					from.SendMessage( "This painting doesn't even look like that." );
				}
			}
		}

		public WaxPainting( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
            writer.Write( PaintingFlipID1 );
            writer.Write( PaintingFlipID2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            PaintingFlipID1 = reader.ReadInt();
            PaintingFlipID2 = reader.ReadInt();
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