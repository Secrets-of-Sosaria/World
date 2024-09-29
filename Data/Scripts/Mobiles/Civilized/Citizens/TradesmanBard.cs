using System;
using Server;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class TradesmanBard : Citizens
	{
		[Constructable]
		public TradesmanBard()
		{
			CitizenType = 12;
			SetupCitizen();
			Blessed = true;
			CantWalk = true;
			AI = AIType.AI_Melee;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextTalk )
			{
				int seconds = Utility.RandomMinMax( 10, 20 );
				BardHit music = new BardHit();
					music.Delete();

				foreach ( Item instrument in this.GetItemsInRange( 1 ) )
				{
					if ( instrument is BardHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null ){ this.FindItemOnLayer( Layer.TwoHanded ).Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null ){ this.FindItemOnLayer( Layer.TwoHanded ).Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null ){ this.FindItemOnLayer( Layer.TwoHanded ).Delete(); }
						music = (BardHit)instrument;
					}
				}

				if ( music.ItemID == 0x27B3 )
				{
					if ( music.X == X ){ Direction = Direction.South; } //music.Y = Y; }
					else if ( music.Y == Y ){ Direction = Direction.East; } //music.X = X; }
					Server.Items.BardHit.SetInstrument( this, music );
				}
				music.OnDoubleClick( this );
				if ( music.Name != "instrument"){ seconds = Utility.RandomMinMax( 5, 10 ); }

				m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( seconds ));
			}
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.TavernPatrons.RemoveSomeGear( this, false );
			Server.Misc.MorphingTime.CheckNecromancer( this );
		}

		public TradesmanBard( Serial serial ) : base( serial )
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

namespace Server.Items
{
	public class BardHit : Item
	{
		[Constructable]
		public BardHit() : base( 0x27B3 )
		{
			Name = "instrument";
			Movable = false;
			Weight = -2.0;
			ItemID = 0x27B3;
		}

		public BardHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from is TradesmanBard )
			{
				string[] song1 = new string[] {"D","L"};
				string[] song2 = new string[] {"a","e","i","o","u","ee","ah","oo"};

				int lyrics = Utility.RandomMinMax( 8, 15 );
				int chords = 0;
				string sing = "";
				bool added = true;

				while ( lyrics > 0 )
				{
					lyrics--;
					chords++;

					if ( chords > 8 && Utility.RandomBool() ){ added = false; }

					if ( added ){ sing = sing + song1[Utility.RandomMinMax( 0, (song1.Length-1) )] + song2[Utility.RandomMinMax( 0, (song2.Length-1) )] + " "; }

					added = true;
				}

				if ( this.Name != "instrument" )
				{
					if ( this.ItemID == 0x64BE || this.ItemID == 0x64BF ){ 		this.Name = "instrument";	from.PlaySound( Utility.RandomList( 0x4C, 0x403, 0x40B, 0x418 ) ); 	if ( Utility.RandomBool() ){ from.Say( sing ); } }		// LUTE
					else if ( this.ItemID == 0x64C0 || this.ItemID == 0x64C1 ){ this.Name = "instrument";	from.PlaySound( 0x504 ); }																									// FLUTE
					else if ( this.ItemID == 0x64C2 || this.ItemID == 0x64C3 ){ this.Name = "instrument";	from.PlaySound( Utility.RandomList( 0x043, 0x045 ) ); 	if ( Utility.RandomBool() ){ from.Say( sing ); } }					// HARP
					else if ( this.ItemID == 0x64C4 || this.ItemID == 0x64C5 ){ this.Name = "instrument";	from.PlaySound( 0x38 ); 	if ( Utility.RandomBool() ){ from.Say( sing ); } }												// DRUM
					else if ( this.ItemID == 0x64C6 || this.ItemID == 0x64C7 ){ this.Name = "instrument";	from.PlaySound( 0x5B1 ); 	if ( Utility.RandomBool() ){ from.Say( sing ); } }												// FIDDLE
					else if ( this.ItemID == 0x64C8 || this.ItemID == 0x64C9 ){ this.Name = "instrument";	from.PlaySound( Utility.RandomList( 0x52, 0x4B5, 0x4B6, 0x4B7 ) ); 	if ( Utility.RandomBool() ){ from.Say( sing ); } }		// TAMBOURINE
					else if ( this.ItemID == 0x64CA || this.ItemID == 0x64CB ){ this.Name = "instrument";	from.PlaySound( Utility.RandomList( 0x3CF, 0x3D0 ) ); } 																	// TRUMPET
					else if ( this.ItemID == 0x64CC || this.ItemID == 0x64CD ){ this.Name = "instrument";	from.PlaySound( 0x5B8 ); }																									// PIPES
				}
				else
				{
					SetInstrument( from, this );

					string[] part1 = new string[] { "I written this", "I learned this", "I heard this", "I was taught this", "Here is a", "This is a" };
					string[] part2 = new string[] { "ballad", "song", "tune", "melody" };
					string[] part4 = new string[] { "death", "fate", "exploits", "courage", "adventures", "journey", "demise", "victories", "legend", "conquests" };
					string[] part5 = new string[] { "battle", "rise", "destruction", "legend", "secret", "lore", "savior", "champion", "fall", "conquest" };
					string[] part6 = new string[] { "horrors", "terror", "treasure", "riches", "creatures", "monsters", "depths", "conquest", "discovery" };

					string ext1 = part1[Utility.RandomMinMax( 0, (part1.Length-1) )] + " ";
					string ext2 = part2[Utility.RandomMinMax( 0, (part2.Length-1) )] + " ";
					string ext3 = "";
					string ext4 = part4[Utility.RandomMinMax( 0, (part4.Length-1) )];
					string ext5 = part5[Utility.RandomMinMax( 0, (part5.Length-1) )];
					string ext6 = part6[Utility.RandomMinMax( 0, (part6.Length-1) )];
					string ext7 = part2[Utility.RandomMinMax( 0, (part2.Length-1) )];

					switch ( Utility.RandomMinMax( 1, 10 ) )
					{
						case 1:
							if ( ext1 == "Here is a " || ext1 == "This is a " ){ ext3 = "from " + RandomThings.GetRandomCity() + "."; }
							else { ext3 = "while I was in " + RandomThings.GetRandomCity() + "."; }
						break;
						case 2:		ext3 = "about " + RandomThings.GetRandomJobTitle(0) + " and the " + RandomThings.GetRandomThing(0) + "."; break;
						case 3:		ext3 = "about " + RandomThings.GetRandomJobTitle(0) + " and the " + RandomThings.GetRandomCreature() + "."; break;
						case 4:		ext3 = "called " + RandomThings.GetSongTitle() + "."; break;
						case 5:		ext3 = "I call " + RandomThings.GetSongTitle() + "."; break;
						case 6:
							if ( ext1 == "Here is a " || ext1 == "This is a " ){ ext3 = "from the " + RandomThings.GetRandomKingdomName() + " " + RandomThings.GetRandomKingdom() + "."; }
							else { ext3 = "while travelling through the " + RandomThings.GetRandomKingdomName() + " " + RandomThings.GetRandomKingdom() + "."; }
						break;
						case 7:		ext3 = "about the " + ext4 + " of " + NameList.RandomName( "female" ) + " the " + RandomThings.GetBoyGirlJob( 1 ) + "."; break;
						case 8:		ext3 = "about the " + ext4 + " of " + NameList.RandomName( "male" ) + " the " + RandomThings.GetBoyGirlJob( 0 ) + "."; break;
						case 9:		ext3 = "about the " + ext5 + " of " + RandomThings.GetRandomCity() + "."; break;
						case 10:	ext3 = "about the " + ext6 + " of " + RandomThings.MadeUpDungeon() + "."; break;
					}

					string say = ext1 + ext2 + ext3;

					if ( Utility.RandomBool() )
					{
						string job = RandomThings.GetBoyGirlJob(0);
							if ( Utility.RandomBool() ){ job = RandomThings.GetBoyGirlJob(1); }

						string name = RandomThings.GetRandomBoyName();
						string title = " the " + RandomThings.GetBoyGirlJob(0);
						if ( Utility.RandomBool() )
						{
							name = RandomThings.GetRandomGirlName();
							title = " the " + RandomThings.GetBoyGirlJob(1);
						}
						if ( Utility.RandomBool() )
						{
							title = "";
						}

						string dungeon = RandomThings.MadeUpDungeon();
							if ( Utility.RandomBool() ){ dungeon = QuestCharacters.SomePlace( null ); }

						string city = RandomThings.GetRandomCity();	
							if ( Utility.RandomBool() ){ city = RandomThings.MadeUpCity(); }

						string singer = "written";	
						switch( Utility.RandomMinMax( 0, 3 ) )
						{
							case 1: singer = "created"; break;
							case 2: singer = "sung"; break;
							case 3: singer = "composed"; break;
						}

						string book = "written on a scroll";	
						switch( Utility.RandomMinMax( 0, 3 ) )
						{
							case 1: book = "carved on a tablet"; break;
							case 2: book = "written in a book"; break;
							case 3: book = "scrawled on a wall"; break;
						}

						string verb = "found";	
						switch( Utility.RandomMinMax( 0, 3 ) )
						{
							case 1: verb = "discovered"; break;
							case 2: verb = "said to be"; break;
							case 3: verb = "seen"; break;
						}

						switch( Utility.RandomMinMax( 1, 9 ) )
						{
							case 1: say = "This " + ext2 + "was " + singer + " by " + name + title + "."; break;
							case 2: say = "This " + ext2 + "was " + singer + " by " + name + " from " + city + "."; break;
							case 3: say = "This " + ext2 + "was " + singer + " by a " + job + "."; break;
							case 4: say = "This " + ext2 + "was " + singer + " by a " + job + " in " + city + "."; break;
							case 5: say = "This " + ext2 + "was " + book + " " + verb + " in " + dungeon + "."; break;
							case 6: say = "While exploring " + dungeon + ", this " + ext2 + "was found " + book + "."; break;
							case 7: say = name + title + " taught me this " + ext2 + "when I was in " + city + "."; break;
							case 8: say = "A " + job + " taught me this " + ext2 + "when I was in " + city + "."; break;
							case 9: say = "A " + job + " taught me this " + ext7 + "."; break;
						}
					}

					from.Say( say );
					SetInstrument( from, this );
				}
			}
		}

		public static void SetInstrument( Mobile from, Item instrument )
		{
			string facing = "east";

			if ( from.Direction == Direction.South ){ facing = "south"; }
			instrument.Hue = 0;

			if ( facing == "south" )
			{
				switch ( Utility.RandomMinMax( 1, 8 ) )
				{
					case 1:	instrument.ItemID = 0x64BF; instrument.Name = "lute"; 		instrument.Z = from.Z + 9;	break;
					case 2:	instrument.ItemID = 0x64C1; instrument.Name = "flute"; 		instrument.Z = from.Z + 11;	break;
					case 3:	instrument.ItemID = 0x64C3; instrument.Name = "harp"; 		instrument.Z = from.Z + 8;	break;
					case 4:	instrument.ItemID = 0x64C5; instrument.Name = "drum"; 		instrument.Z = from.Z + 8;	break;
					case 5:	instrument.ItemID = 0x64C7; instrument.Name = "fiddle"; 	instrument.Z = from.Z + 10;	break;
					case 6:	instrument.ItemID = 0x64C9; instrument.Name = "tambourine"; instrument.Z = from.Z + 9;	break;
					case 7:	instrument.ItemID = 0x64CB; instrument.Name = "trumpet"; 	instrument.Z = from.Z + 9;	instrument.Hue = 0xB61;	break;
					case 8:	instrument.ItemID = 0x64CD; instrument.Name = "pipes"; 		instrument.Z = from.Z + 9;	break;
				}
			}
			else
			{
				switch ( Utility.RandomMinMax( 1, 8 ) )
				{
					case 1:	instrument.ItemID = 0x64BE; instrument.Name = "lute"; 		instrument.Z = from.Z + 9;	break;
					case 2:	instrument.ItemID = 0x64C0; instrument.Name = "flute"; 		instrument.Z = from.Z + 11;	break;
					case 3:	instrument.ItemID = 0x64C2; instrument.Name = "harp"; 		instrument.Z = from.Z + 8;	break;
					case 4:	instrument.ItemID = 0x64C4; instrument.Name = "drum"; 		instrument.Z = from.Z + 8;	break;
					case 5:	instrument.ItemID = 0x64C6; instrument.Name = "fiddle"; 	instrument.Z = from.Z + 10;	break;
					case 6:	instrument.ItemID = 0x64C8; instrument.Name = "tambourine"; instrument.Z = from.Z + 9;	break;
					case 7:	instrument.ItemID = 0x64CA; instrument.Name = "trumpet"; 	instrument.Z = from.Z + 9;	instrument.Hue = 0xB61;	break;
					case 8:	instrument.ItemID = 0x64CC; instrument.Name = "pipes"; 		instrument.Z = from.Z + 9;	break;
				}
			}
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
			Weight = -2.0;
		}
	}
}