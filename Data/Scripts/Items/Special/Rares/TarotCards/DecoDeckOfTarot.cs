using System;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Misc;

namespace Server.Items
{
	public class DecoDeckOfTarot : Item
	{
		[Constructable]
		public DecoDeckOfTarot() : base( 0x12AB )
		{
			Movable = true;
			Stackable = false;
			Name = "tarot cards";
		}

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.InRange(this.GetWorldLocation(), 4))
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.

            else
			{
				Server.Gumps.TarotCardsGump.SendGump( from, this );
			}
        }

		public DecoDeckOfTarot( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}

namespace Server.Gumps
{
    public class TarotCardsGump : Gump
	{
		private Item m_Cards;
		private int m_CardA;
		private int m_CardB;
		private int m_CardC;
		private int m_CardD;
		private int m_CardE;


		public TarotCardsGump( Mobile from, Item cards ) : base(50, 50)
		{
			m_Cards = cards;

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			AddPage(0);

			from.SendSound( 0x5BB );

			AddImage(0, 0, 11154); // TABLE

			AddButton(24, 15, 4029, 4029, 1, GumpButtonType.Reply, 0);
			AddButton(899, 15, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 75, 11, 805, 56, @"<BODY><BASEFONT Color=#FBFBFB><BIG><CENTER>" + randomTarot() + "</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);

			if ( Utility.RandomBool() )
			{
				AddImage( 51, 355, getCard(1) );
				AddImage( 377, 355, getCard(2) );
				AddImage( 714, 355, getCard(3) );
				AddImage( 212, 80, getCard(4) );
				AddImage( 542, 80, getCard(5) );
			}
			else
			{
				AddImage(215, 355, getCard(1) );
				AddImage(547, 355, getCard(2) );
				AddImage(46, 80, getCard(3) );
				AddImage(382, 80, getCard(4) );
				AddImage(711, 80, getCard(5) );
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

			from.CloseGump( typeof( TarotCardsGump ) );

			if ( info.ButtonID > 0 )
			{
				SendGump( from, m_Cards );
				from.SendSound( 0x5BB );
			}
			else 
				from.SendSound( 0x5BB );
		}

		public int getCard( int picked )
		{
			bool take = false;
			int card = 0;

			while ( !take )
			{
				card = Utility.RandomMinMax( 11059, 11137 );
				if ( card != m_CardA && card != m_CardB && card != m_CardC && card != m_CardD && card != m_CardE )
					take = true;

				if ( card == 11060 )
					take = false;
			}

			if ( picked == 1 )
				m_CardA = card;
			else if ( picked == 2 )
				m_CardB = card;
			else if ( picked == 3 )
				m_CardC = card;
			else if ( picked == 4 )
				m_CardD = card;
			else if ( picked == 5 )
				m_CardE = card;

			return card;
		}

		public string wordCity( bool any )
		{
			string city = RandomThings.GetRandomCity();	
				if ( Utility.RandomBool() && any ){ city = RandomThings.MadeUpCity(); }
			return city;
		}

		public string wordDungeon( bool any )
		{
			string dungeon = QuestCharacters.SomePlace( "tavern" );	
				if ( Utility.RandomBool() && any ){ dungeon = RandomThings.MadeUpDungeon(); }
			return dungeon;
		}

		public string wordPlace( bool any )
		{
			string place = wordCity( any );	
				if ( Utility.RandomBool() && any ){ place = wordDungeon( any ); }
			return place;
		}

		public string randomTarot()
		{
			string future = "";


			string name = NameList.RandomName( "female" );
				if ( Utility.RandomBool() ){ name = NameList.RandomName( "male" ); }


			string nameTitle = TavernPatrons.GetTitle();


			string person = "Someone";
			switch ( Utility.RandomMinMax( 0, 10 ) )
			{
				case 1: person = "A woman"; 						break;
				case 2: person = "A man"; 							break;
				case 3: person = "Someone named " + name + ""; 		break;
				case 4: person = "A stranger"; 						break;
				case 5: person = "A friend"; 						break;
				case 6: person = "An enemy"; 						break;
				case 7: person = "A woman named " + NameList.RandomName( "female" ) + ""; 	break;
				case 8: person = "A man named " + NameList.RandomName( "male" ) + ""; 		break;
				case 9: person = "A stranger named " + name + ""; 	break;
				case 10: person = "A friend named " + name + ""; 	break;
			}
			if ( Utility.RandomBool() ){ person = person + ", from " + wordCity( true ) + ","; }


			string action = "will betray you"; 
			switch ( Utility.RandomMinMax( 0, 12 ) )
			{
				case 1: action = "will try to kill you"; 			break;
				case 2: action = "will try to rob you"; 			break;
				case 3: action = "will try to fool you"; 			break;
				case 4: action = "will lure you into a trap"; 		break;
				case 5: action = "will steal something from you"; 	break;
				case 6: action = "will tell you falsehoods"; 		break;
				case 7: action = "will try to warn you"; 			break;
				case 8: action = "will try to help you"; 			break;
				case 9: action = "will give you something"; 		break;
				case 10: action = "will seek your help"; 			break;
				case 11: action = "will save your life"; 			break;
				case 12: action = "will give you a warning"; 		break;
			}
			if ( Utility.RandomBool() ){ action = action + " in " + wordPlace( false ) + ""; }


			string assassin = "an assassin"; 
			switch ( Utility.RandomMinMax( 0, 7 ) )
			{
				case 1: assassin = "a killer"; 			break;
				case 2: assassin = "a hunter"; 			break;
				case 3: assassin = "a thief"; 			break;
				case 4: assassin = "a rogue"; 			break;
				case 5: assassin = "a bandit"; 			break;
				case 6: assassin = "a bounty hunter"; 	break;
				case 7: assassin = "a murderer"; 		break;
			}


			string meet = "come face to face"; 
			switch ( Utility.RandomMinMax( 0, 11 ) )
			{
				case 1: meet = "have an encounter with"; break;
				case 2: meet = "meet"; 					break;
				case 3: meet = "run into"; 				break;
				case 4: meet = "cross paths with"; 		break;
				case 5: meet = "be slain by"; 			break;
				case 6: meet = "be killed by"; 			break;
				case 7: meet = "slay"; 					break;
				case 8: meet = "kill"; 					break;
				case 9: meet = "flee from"; 			break;
				case 10: meet = "chase away"; 			break;
				case 11: meet = "escape from"; 			break;
			}


			string discover = "discover"; 
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: discover = "find"; 					break;
				case 2: discover = "bring home"; 			break;
				case 3: discover = "be rewarded with"; 		break;
				case 4: discover = "unearth"; 				break;
				case 5: discover = "take"; 					break;
			}


			string power = "a powerful";
			switch ( Utility.RandomMinMax( 0, 8 ) )
			{
				case 1: power = "a magical"; 		break;
				case 2: power = "a mystical"; 		break;
				case 3: power = "an arcane"; 		break;
				case 4: power = "an enchanted"; 	break;
				case 5: power = "a cursed"; 		break;
				case 6: power = "a blessed"; 		break;
				case 7: power = "a holy"; 			break;
				case 8: power = "an evil"; 			break;
			}


			string coins = "gold";
			switch ( Utility.RandomMinMax( 0, 6 ) )
			{
				case 1: coins = "silver"; 		break;
				case 2: coins = "copper"; 		break;
				case 3: coins = "jewels"; 		break;
				case 4: coins = "gold nuggets"; break;
				case 5: coins = "cystals"; 		break;
				case 6: coins = "gems"; 		break;
			}


			string piles = "piles";
			switch ( Utility.RandomMinMax( 0, 7 ) )
			{
				case 1: piles = "mounds"; 		break;
				case 2: piles = "chests"; 		break;
				case 3: piles = "bags"; 		break;
				case 4: piles = "sacks"; 		break;
				case 5: piles = "coffers"; 		break;
				case 6: piles = "crates"; 		break;
				case 7: piles = "hoards"; 		break;
			}


			string goal = "the Codex of Ultimate Wisdom";	
			switch( Utility.RandomMinMax( 0, 22 ) )
			{
				case 1: goal = "the Dark Core of Exodus";	 	break;	
				case 2: goal = "the Staff of Five Parts";		break;	
				case 3: goal = "the Vortex Cube";				break;	
				case 4: goal = "the Runes of Virtue";			break;	
				case 5: goal = "the Book of Truth";				break;	
				case 6: goal = "the Bell of Courage";			break;	
				case 7: goal = "the Candle of Love";			break;	
				case 8: goal = "the Scales of Ethicality";		break;	
				case 9: goal = "the Orb of Logic";				break;	
				case 10: goal = "the Lantern of Discipline";	break;	
				case 11: goal = "the Breath of Air";			break;	
				case 12: goal = "the Tongue of Flame";			break;	
				case 13: goal = "the Heart of Earth";			break;	
				case 14: goal = "the Tear of the Seas";			break;	
				case 15: goal = "the Statue of Gygax";			break;	
				case 16: goal = "the Skull of Baron Almric";	break;	
				case 17: goal = "the Shard of Cowardice";		break;	
				case 18: goal = "the Shard of Falsehood";		break;	
				case 19: goal = "the Shard of Hatred";			break;	
				case 20: goal = "the Gem of Immortality";		break;	
				case 21: goal = "the Manual of Golems";			break;	
				case 22: goal = "Frankenstein's Journal";		break;	
			}


			string riches = "great riches"; 
			switch ( Utility.RandomMinMax( 0, 18 ) )
			{
				case 1: riches = "" + piles + " of " + coins + "";				break;
				case 2: riches = "" + power + " item"; 							break;
				case 3: riches = "" + power + " weapon"; 						break;
				case 4: riches = "" + power + " book"; 							break;
				case 5: riches = "great treasure"; 								break;
				case 6: riches = "hoards of treasure"; 							break;
				case 7: riches = "a huge bounty"; 								break;
				case 8: riches = "rare items"; 									break;
				case 9: riches = "" + power + " pair of boots"; 				break;
				case 10: riches = "" + power + " scroll"; 						break;
				case 11: riches = "treasures beyond belief"; 					break;
				case 12: riches = QuestCharacters.QuestItems( false ); 			break;
				case 13: riches = "" + power + " suit of armor"; 				break;
				case 14: riches = "" + power + " wand"; 						break;
				case 15: riches = "" + power + " robe"; 						break;
				case 16: riches = goal; 										break;
				case 17: riches = QuestCharacters.ArtyItems( false ); 			break;
				case 18: riches = "" + power + " shield"; 						break;
			}


			string death = "perish"; 
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: death = "die"; 					break;
				case 2: death = "be slain"; 			break;
				case 3: death = "meet your end"; 		break;
				case 4: death = "be killed"; 			break;
				case 5: death = "lose your life"; 		break;
			}


			string victory = "be victorious against"; 
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: victory = "win a fight with"; 	break;
				case 2: victory = "slay"; 				break;
				case 3: victory = "kill"; 				break;
				case 4: victory = "best"; 				break;
				case 5: victory = "vanquish"; 			break;
			}


			string journey = "journey"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: journey = "adventures"; 	break;
				case 2: journey = "quest"; 			break;
				case 3: journey = "travels"; 		break;
				case 4: journey = "exploration"; 	break;
			}


			string leads = "will lead to"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: leads = "will bring you"; 		break;
				case 2: leads = "will reveal"; 			break;
				case 3: leads = "will reward you with"; break;
				case 4: leads = "will grant you"; 		break;
			}


			string fate = "The future"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: fate = "Your destiny"; 		break;
				case 2: fate = "Your fate"; 		break;
				case 3: fate = "Your future"; 		break;
				case 4: fate = "Your fortune";	 	break;
			}


			string warn = "Take this as a warning"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: warn = "Heed this warning"; 	break;
				case 2: warn = "Be warned"; 			break;
				case 3: warn = "You have been warned"; 	break;
				case 4: warn = "The warning is clear";	break;
			}


			string stayOut = "stay away from"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: stayOut = "stay out of"; 		break;
				case 2: stayOut = "do not enter"; 		break;
				case 3: stayOut = "beware"; 			break;
				case 4: stayOut = "do not approach"; 	break;
			}


			string noGood = "nothing good will come of it"; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: noGood = "you will regret it"; 		break;
				case 2: noGood = "it will be dire"; 		break;
				case 3: noGood = "it will be your end"; 	break;
				case 4: noGood = "it will be your undoing"; break;
			}


			string luck = "good luck"; 
			switch ( Utility.RandomMinMax( 0, 10 ) )
			{
				case 1: luck = "a clue"; 			break;
				case 2: luck = "an ally"; 			break;
				case 3: luck = "a friend"; 			break;
				case 4: luck = "an enemy"; 			break;
				case 5: luck = "a lead"; 			break;
				case 6: luck = "truth"; 			break;
				case 7: luck = "only lies"; 		break;
				case 8: luck = "a rare item"; 		break;
				case 9: luck = "doom"; 				break;
				case 10: luck = "someone in need"; 	break;
			}


			string youWill = "" + death + " within " + wordDungeon( false ) + ""; 
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: youWill = "find great treasure in " + wordDungeon( false ) + ""; break;
				case 2: youWill = "die at the hands of another in " + wordPlace( false ) + ""; break;
				case 3: youWill = "" + meet + " " + assassin + " in " + wordPlace( false ) + ""; break;
				case 4: youWill = "" + discover + " " + riches + " in " + wordDungeon( false ) + ""; break;
			}


			string monsterFight = "" + fate + " shows that you will " + victory + " " + RandomThings.GetRandomMonsters() + ".";
			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 1: monsterFight = "" + fate + " shows that you will " + death + " to " + RandomThings.GetRandomMonsters() + "."; break;
				case 2: monsterFight = "" + fate + " shows that you will " + death + " to " + RandomThings.GetRandomMonsters() + " in " + wordDungeon( false ) + "."; break;
				case 3: monsterFight = "" + fate + " shows that you will " + victory + " " + RandomThings.GetRandomMonsters() + "."; break;
			}


			switch ( Utility.RandomMinMax( 1, 9 ) )
			{
				case 1: future = "" + person + " " + action + "."; break;
				case 2: future = "You will " + youWill + "."; break;
				case 3: future = "Your " + journey + " " + leads + " " + riches + "."; break;
				case 4: future = "Your " + journey + " to " + wordDungeon( false ) + " " + leads + " " + riches + "."; break;
				case 5: future = "You will find " + luck + " in " + wordCity( false ) + "."; break;
				case 6: future = "" + fate + " shows that " + riches + " awaits you in " + wordDungeon( false ) + "."; break;
				case 7: future = monsterFight; break;
				case 8: future = "" + warn + ", " + stayOut + " " + wordPlace( true ) + " as " + noGood + "."; break;
				case 9: future = "You will find " + riches + " in " + wordDungeon( true ) + "."; break;
			}


			return future;
		}

		public static void SendGump( Mobile from, Item cards )
		{
			from.CloseGump( typeof( TarotCardsGump ) );
			from.SendGump( new TarotCardsGump( from, cards ) );
			if ( cards.Name == "gypsy tarot cards" ){ from.SendSound( Utility.RandomList( 0x30A, 0x30B, 0x319, 0x31A, 0x323, 0x32B ) ); }
			from.SendSound( 0x5BB );
		}
	}
}