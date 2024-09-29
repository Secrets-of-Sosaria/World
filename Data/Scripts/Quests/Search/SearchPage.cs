using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Gumps;

namespace Server.Items
{
	public class SearchPage : Item
	{
		public Mobile owner;
		public string SearchMessage;
		public string SearchDungeon;
		public Map DungeonMap;
		public string SearchWorld;
		public string SearchType;
		public string SearchItem;
		public int LegendReal;
		public int LegendPercent;

		public Map GetMap;
		public int GetX;
		public int GetY;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner { get{ return owner; } set{ owner = value; } }

		[CommandProperty(AccessLevel.Owner)]
		public string Search_Message { get { return SearchMessage; } set { SearchMessage = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Search_Dungeon { get { return SearchDungeon; } set { SearchDungeon = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public Map Dungeon_Map { get { return DungeonMap; } set { DungeonMap = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Search_World { get { return SearchWorld; } set { SearchWorld = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Search_Type { get { return SearchType; } set { SearchType = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Search_Item { get { return SearchItem; } set { SearchItem = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Legend_Real { get { return LegendReal; } set { LegendReal = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Legend_Percent { get { return LegendPercent; } set { LegendPercent = value; InvalidateProperties(); } }

		[Constructable]
		public SearchPage( Mobile from, int LegendLore, string seekType, string seekName ) : base( 0x2159 )
		{
			SearchItem = seekName;
			SearchType = seekType;

			this.owner = from;
			Weight = 1.0;
			Hue = 0x995;
			Name = "a parchment";

			switch ( LegendLore )
			{
				case 1:	Name = "highly unlikely legend for " + from.Name;	break;
				case 2:	Name = "unlikely legend for " + from.Name;	break;
				case 3:	Name = "somewhat unlikely legend for " + from.Name;	break;
				case 4:	Name = "somewhat reliable legend for " + from.Name;	break;
				case 5:	Name = "reliable legend for " + from.Name;	break;
				case 6:	Name = "highly reliable legend for " + from.Name;	break;
			}

			/// CHECK TO SEE IF THE NOTE IS FALSE OR TRUE
			LegendLore = ( LegendLore * 10 ) + 10;
			LegendReal = 0;
			if ( LegendLore >= Utility.RandomMinMax( 1, 100 ) ){ LegendReal = 1; }
			LegendPercent = LegendLore;

			PickSearchLocation( this, "No Dungeon Yet", from );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, SearchItem);
            list.Add( 1049644, SearchDungeon);
        }

		public class SearchGump : Gump
		{
			private SearchPage m_Book;
			private Map m_Map;
			private int m_X;
			private int m_Y;

			public SearchGump( Mobile from, Item parchment ): base( 100, 100 )
			{
				SearchPage scroll = (SearchPage)parchment;
				string sText = scroll.SearchMessage;
				from.PlaySound( 0x249 );

				m_Book = scroll;
				m_Map = scroll.GetMap;
				m_X = scroll.GetX;
				m_Y = scroll.GetY;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 10901, 2786);
				AddImage(0, 0, 10899, 2117);
				AddHtml( 45, 78, 386, 218, @"<BODY><BASEFONT Color=#d9c781>" + sText + "</BASEFONT></BODY>", (bool)false, (bool)true);

				if ( Sextants.HasSextant( from ) )
					AddButton(377, 325, 10461, 10461, 1, GumpButtonType.Reply, 0);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 

				if ( info.ButtonID > 0 )
				{
					from.CloseGump( typeof( Sextants.MapGump ) );
					from.SendGump( new SearchGump( from, m_Book ) );
					from.SendGump( new Sextants.MapGump( from, m_Map, m_X, m_Y, null ) );
				}
				else
				{
					from.PlaySound( 0x249 );
					from.CloseGump( typeof( Sextants.MapGump ) );
				}
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
				e.CloseGump( typeof( SearchGump ) );
				e.SendGump( new SearchGump( e, this ) );
			}
		}

		public static void PickSearchLocation( SearchPage scroll, string DungeonNow, Mobile from )
		{
			string thisWorld = "the Land of Sosaria";
			string thisPlace = "the Dungeon of Doom";
			Map realMap = Map.Sosaria;
			Map thisMap = Map.Sosaria;

			int aCount = 0;
			ArrayList targets = new ArrayList();
			foreach ( Item target in World.Items.Values )
			if ( target is SearchBase && ( Server.Difficult.GetDifficulty( target.Location, target.Map ) <= GetPlayerInfo.GetPlayerDifficulty( from ) ) )
			{
				targets.Add( target );
				aCount++;
			}

			aCount = Utility.RandomMinMax( 1, aCount );

			int xCount = 0;
			for ( int i = 0; i < targets.Count; ++i )
			{
				xCount++;

				if ( xCount == aCount )
				{
					Item finding = ( Item )targets[ i ];
					thisMap = Server.Misc.Worlds.GetMyDefaultMap( finding.Land );
					realMap = finding.Map;
					thisPlace = Server.Misc.Worlds.GetRegionName( finding.Map, finding.Location );
					thisWorld = Lands.LandName( finding.Land );
				}
			}

			string Word1 = "Legends";
			switch ( Utility.RandomMinMax( 1, 4 ) )
			{
				case 1:	Word1 = "Rumors"; break;
				case 2:	Word1 = "Myths"; break;
				case 3:	Word1 = "Tales"; break;
				case 4:	Word1 = "Stories"; break;
			}
			string Word2 = "lost";
			switch ( Utility.RandomMinMax( 1, 4 ) )
			{
				case 1:	Word2 = "kept"; break;
				case 2:	Word2 = "seen"; break;
				case 3:	Word2 = "taken"; break;
				case 4:	Word2 = "hidden"; break;
			}
			string Word3 = "deep in";
			switch ( Utility.RandomMinMax( 1, 4 ) )
			{
				case 1:	Word3 = "within"; break;
				case 2:	Word3 = "somewhere in"; break;
				case 3:	Word3 = "somehow in"; break;
				case 4:	Word3 = "far in"; break;
			}
			string Word4 = "centuries ago";
			switch ( Utility.RandomMinMax( 1, 4 ) )
			{
				case 1:	Word4 = "thousands of years ago"; break;
				case 2:	Word4 = "decades ago"; break;
				case 3:	Word4 = "millions of years ago"; break;
				case 4:	Word4 = "many years ago"; break;
			}

			string sMessage = 

            scroll.SearchDungeon = thisPlace;
            scroll.SearchWorld = thisWorld;
			scroll.DungeonMap = thisMap;

			Map placer;
			int xc;
			int yc;

			string EntranceLocation = Worlds.GetAreaEntrance( 0, scroll.SearchDungeon, realMap, out placer, out xc, out yc );

			scroll.GetMap = placer;
			scroll.GetX = xc;
			scroll.GetY = yc;

			string OldMessage = "<br><br><br><br><br><br>" + scroll.SearchMessage;

			scroll.SearchMessage = scroll.SearchItem + "<br><br>" + Word1 + " tell of the " + scroll.SearchItem + " being " + Word2 + " " + Word3;
			scroll.SearchMessage = scroll.SearchMessage + " " + scroll.SearchDungeon + " " + Word4 + " by " + QuestCharacters.QuestGiver() + ".";
			scroll.SearchMessage = scroll.SearchMessage + " in " + scroll.SearchWorld + " at the below sextant coordinates.<br><br>" + EntranceLocation + OldMessage;

			scroll.InvalidateProperties();
		}

		public static void ArtifactQuestTimeAllowed( Mobile m )
		{
			DateTime TimeFinished = DateTime.Now;
			((PlayerMobile)m).ArtifactQuestTime = Convert.ToString(TimeFinished);
		}

		public static int ArtifactQuestTimeNew( Mobile m )
		{
			int QuestTime = 90000;

			string sTime = ((PlayerMobile)m).ArtifactQuestTime;

			if ( sTime != null )
			{
				DateTime TimeThen = Convert.ToDateTime(sTime);
				DateTime TimeNow = DateTime.Now;
				long ticksThen = TimeThen.Ticks;
				long ticksNow = TimeNow.Ticks;
				int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
				int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
				QuestTime = minsNow - minsThen;
			}

			return QuestTime;
		}

		public SearchPage(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)2);

			writer.Write( GetMap );
			writer.Write( GetX );
			writer.Write( GetY );

			writer.Write( (Mobile)owner);
            writer.Write( SearchMessage );
            writer.Write( SearchDungeon );
            writer.Write( DungeonMap );
            writer.Write( SearchWorld );
            writer.Write( SearchType );
            writer.Write( SearchItem );
            writer.Write( LegendReal );
            writer.Write( LegendPercent );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					GetMap = reader.ReadMap();
					GetX = reader.ReadInt();
					GetY = reader.ReadInt();
					break;
				}
			}

			owner = reader.ReadMobile();
			SearchMessage = reader.ReadString();
			SearchDungeon = reader.ReadString();
			DungeonMap = reader.ReadMap();
			SearchWorld = reader.ReadString();
			SearchType = reader.ReadString();
			SearchItem = reader.ReadString();
			LegendReal = reader.ReadInt();
			LegendPercent = reader.ReadInt();
			ItemID = 0x2159;
			Hue = 0x995;
		}
	}
}