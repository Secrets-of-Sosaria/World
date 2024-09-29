using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Misc;

namespace Server.Items
{
	public class BookWitchBrewing : Item
	{
		[Constructable]
		public BookWitchBrewing( ) : base( 0x5689 )
		{
			Weight = 1.0;
			Name = "The Witch's Brew";
			Hue = 0x9A2;
		}

		public class BookGump : Gump
		{
			public BookGump( Mobile from, int page ): base( 100, 100 )
			{
				string color = "#d89191";
				from.SendSound( 0x55 );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7005, 2845);
				AddImage(0, 0, 7006);
				AddImage(0, 0, 7024, 2736);
				AddImage(87, 117, 7053);
				AddImage(382, 117, 7053);

				int prev = page - 1;
					if ( prev < 1 ){ prev = 99; }
				int next = page + 1;

				AddButton(72, 45, 4014, 4014, prev, GumpButtonType.Reply, 0);
				AddButton(590, 48, 4005, 4005, next, GumpButtonType.Reply, 0);

				int potion = 0;

				if ( page == 2 ){ potion = 2; }
				else if ( page == 3 ){ potion = 4; }
				else if ( page == 4 ){ potion = 6; }
				else if ( page == 5 ){ potion = 8; }
				else if ( page == 6 ){ potion = 10; }
				else if ( page == 7 ){ potion = 11; }
				else if ( page == 8 ){ potion = 12; }
				else if ( page == 9 ){ potion = 14; }
				else if ( page == 10 ){ potion = 16; }

				// --------------------------------------------------------------------------------

				if ( page == 1 )
				{
					AddHtml( 107, 46, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>THE WITCH'S BREW</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 398, 48, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>THE WITCH'S BREW</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 78, 75, 248, 318, @"<BODY><BASEFONT Color=" + color + ">Witchery brewing is the art of taking morbid reagents and creating concoctions that necromancers can use in their dark magics. You would use your forensics skill to create the potions, and your necromancy skill to use them. This book explains the various mixtures you can make, as well as additional information to manage these potions effectively. Unlike other potions, these require jars as the liquid needs a thicker glass to store as it is acidic enough to dissolve bottle glass and even the wood of a keg.</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 372, 75, 248, 318, @"<BODY><BASEFONT Color=" + color + ">You will need a small cauldron to brew these concoctions. You can also get a belt pouch to store the ingredients, cauldrons, jars, potions, and this book to make them easier to carry. Single click this bag to organize it for easier use of the mixtures.</BASEFONT></BODY>", (bool)false, (bool)false);
				}
				else
				{
					AddHtml( 107, 46, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + potionInfo( potion, 1 ) + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 73, 72, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Forensics:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 267, 72, 47, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 4 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 73, 98, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Necromancy:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 267, 98, 47, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 5 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddImage(77, 128, Int32.Parse( potionInfo( potion, 2 ) ) );
					AddHtml( 133, 139, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Ingredients</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 73, 180, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 6 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 73, 206, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 7 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 73, 232, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 8 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 73, 258, 245, 133, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 3 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

					potion++;

					AddHtml( 398, 48, 186, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + potionInfo( potion, 1 ) + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 366, 72, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Forensics:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 560, 72, 47, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 4 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 366, 98, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Necromancy:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 560, 98, 47, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 5 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddImage(366, 128, Int32.Parse( potionInfo( potion, 2 ) ) );
					AddHtml( 422, 139, 187, 20, @"<BODY><BASEFONT Color=" + color + ">Ingredients</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 366, 180, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 6 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 366, 206, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 7 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 366, 232, 246, 20, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 8 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 366, 258, 245, 133, @"<BODY><BASEFONT Color=" + color + ">" + potionInfo( potion, 3 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;
				int page = info.ButtonID;
					if ( page == 99 ){ page = 9; }
					else if ( page > 9 ){ page = 1; }

				if ( info.ButtonID > 0 )
				{
					from.SendGump( new BookGump( from, page ) );
				}
				else
					from.SendSound( 0x55 );
			}

			public static string potionDesc( int potion )
			{
				string txt = "";

				txt = "This is created from a witch's brew: " + potionInfo( potion, 3 ) + " To use it, one should have a " + potionInfo( potion, 4 ) + " in Forensics and a " + potionInfo( potion, 5 ) + " in Necromancy.";

				return txt;
			}

			public static string potionInfo( int page, int val )
			{
				string txtName = "";
				string txtIcon = "";
				string txtInfo = "";
				string txtSklA = "";
				string txtSklB = "";
				string txtIngA = "";
				string txtIngB = "";
				string txtIngC = "";

				if ( page == 2 ){ txtName = "Eyes of the Dead Mixture"; txtIcon = "11460"; txtInfo = "Gives one the same sight of the undead, where they are able to see in the dark."; txtSklA = "10"; txtSklB = "5"; txtIngA = "Mummy Wrap"; txtIngB = "Eye of Toad"; txtIngC = ""; }
				else if ( page == 3 ){ txtName = "Tomb Raiding Concoction"; txtIcon = "11468"; txtInfo = "Summons the spirits to unlock something for you."; txtSklA = "15"; txtSklB = "10"; txtIngA = "Maggot"; txtIngB = "Beetle Shell"; txtIngC = ""; }
				else if ( page == 4 ){ txtName = "Disease Draught"; txtIcon = "11458"; txtInfo = "Causes one to suffer from a poisonous disease."; txtSklA = "20"; txtSklB = "15"; txtIngA = "Violet Fungus"; txtIngB = "Nox Crystal"; txtIngC = ""; }
				else if ( page == 5 ){ txtName = "Phantasm Elixir"; txtIcon = "11465"; txtInfo = "Summons a spirit to disable a trap."; txtSklA = "25"; txtSklB = "20"; txtIngA = "Dried Toad"; txtIngB = "Gargoyle Ear"; txtIngC = ""; }
				else if ( page == 6 ){ txtName = "Retched Air Elixir"; txtIcon = "11466"; txtInfo = "Creates a burst of harmful gas."; txtSklA = "30"; txtSklB = "25"; txtIngA = "Black Sand"; txtIngB = "Grave Dust"; txtIngC = ""; }
				else if ( page == 7 ){ txtName = "Lich Leech Mixture"; txtIcon = "11464"; txtInfo = "Absorbs mana from the target, giving it to you in return."; txtSklA = "35"; txtSklB = "30"; txtIngA = "Dried Toad"; txtIngB = "Red Lotus"; txtIngC = ""; }
				else if ( page == 8 ){ txtName = "Wall of Spike Draught"; txtIcon = "11470"; txtInfo = "Creates a protective wall of spikes."; txtSklA = "40"; txtSklB = "35"; txtIngA = "Bitter Root"; txtIngB = "Pig Iron"; txtIngC = ""; }
				else if ( page == 9 ){ txtName = "Disease Curing Concoction"; txtIcon = "11459"; txtInfo = "Cures one of poisonous diseases."; txtSklA = "45"; txtSklB = "40"; txtIngA = "Wolfsbane"; txtIngB = "Swamp Berries"; txtIngC = ""; }
				else if ( page == 10 ){ txtName = "Blood Pact Elixir"; txtIcon = "11456"; txtInfo = "Takes some of your life and bestows it upon another."; txtSklA = "50"; txtSklB = "45"; txtIngA = "Blood Rose"; txtIngB = "Daemon Blood"; txtIngC = ""; }
				else if ( page == 11 ){ txtName = "Spectre Shadow Elixir"; txtIcon = "11467"; txtInfo = "Turns the body into an invisible ghostly form that cannot be seen."; txtSklA = "55"; txtSklB = "50"; txtIngA = "Violet Fungus"; txtIngB = "Silver Widow"; txtIngC = ""; }
				else if ( page == 12 ){ txtName = "Ghost Phase Concoction"; txtIcon = "11461"; txtInfo = "Turns your body into ghostly matter that reappears in a nearby location."; txtSklA = "60"; txtSklB = "55"; txtIngA = "Bitter Root"; txtIngB = "Moon Crystal"; txtIngC = ""; }
				else if ( page == 13 ){ txtName = "Demonic Fire Ooze"; txtIcon = "11457"; txtInfo = "Ignites a marked rune with power to transport one to that location."; txtSklA = "65"; txtSklB = "60"; txtIngA = "Maggot"; txtIngB = "Black Pearl"; txtIngC = ""; }
				else if ( page == 14 ){ txtName = "Ghostly Images Draught"; txtIcon = "11462"; txtInfo = "Creates an illusionary image of you, distracting your foes."; txtSklA = "70"; txtSklB = "65"; txtIngA = "Mummy Wrap"; txtIngB = "Bloodmoss"; txtIngC = ""; }
				else if ( page == 15 ){ txtName = "Hellish Branding Ooze"; txtIcon = "11463"; txtInfo = "Marks a rune location with symbols of evil, so you can use recalling magic on it to return to that location."; txtSklA = "75"; txtSklB = "70"; txtIngA = "Werewolf Claw"; txtIngB = "Brimstone"; txtIngC = ""; }
				else if ( page == 16 ){ txtName = "Black Gate Draught"; txtIcon = "11455"; txtInfo = "Uses a magic rune to create a horrific black gate. Those that enter will appear at the runic location."; txtSklA = "80"; txtSklB = "75"; txtIngA = "Black Sand"; txtIngB = "Wolfsbane"; txtIngC = "Pixie Skull"; }
				else if ( page == 17 ){ txtName = "Vampire Blood Draught"; txtIcon = "11469"; txtInfo = "Dumps vampire blood in your pack, that will resurrect you a few moments after losing your life. You can also directly resurrect others."; txtSklA = "85"; txtSklB = "80"; txtIngA = "Werewolf Claw"; txtIngB = "Bat Wing"; txtIngC = "Blood Rose"; }

				if ( val == 1 )
					return txtName;
				else if ( val == 2 )
					return txtIcon;
				else if ( val == 3 )
					return txtInfo;
				else if ( val == 4 )
					return txtSklA;
				else if ( val == 5 )
					return txtSklB;
				else if ( val == 6 )
					return txtIngA;
				else if ( val == 7 )
					return txtIngB;

				return txtIngC;
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( !IsChildOf( e.Backpack ) ) 
			{
				e.SendMessage( "This must be in your backpack to read." );
			}
			else
			{
				e.CloseGump( typeof( BookGump ) );
				e.SendGump( new BookGump( e, 1 ) );
			}
		}

		public BookWitchBrewing(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}