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
	public class CourierMail : Item
	{
		public Mobile owner;
		public string SearchMessage;
		public string SearchDungeon;
		public Map DungeonMap;
		public string SearchWorld;
		public string SearchItem;
		public string ForWho;
		public string ForWhere;
		public string ForAlignment;
		public int MsgComplete;
		public int MsgReward;

		public Map mapA;
		public int xA;
		public int yA;

		public Map mapB;
		public int xB;
		public int yB;

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
		public string Search_Item { get { return SearchItem; } set { SearchItem = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string For_Who { get { return ForWho; } set { ForWho = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string For_Where { get { return ForWhere; } set { ForWhere = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string For_Alignment { get { return ForAlignment; } set { ForAlignment = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Msg_Complete { get { return MsgComplete; } set { MsgComplete = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Msg_Reward { get { return MsgReward; } set { MsgReward = value; InvalidateProperties(); } }

		[Constructable]
		public CourierMail( Mobile from ) : base( 0x2159 )
		{
			Weight = 1.0;
			Hue = 0x9C4;
			Name = "Message for " + from.Name;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "From " + ForWho);
			if ( MsgComplete > 0 ){ list.Add( 1049644, "Complete"); }
        }

		public class SearchGump : Gump
		{
			private Item m_Paper;
			private Map m_Map1;
			private int m_X1;
			private int m_Y1;
			private Map m_Map2;
			private int m_X2;
			private int m_Y2;

			public SearchGump( Mobile from, Item parchment ): base( 100, 100 )
			{
				CourierMail scroll = (CourierMail)parchment;
				string sText = scroll.SearchMessage;
				m_Paper = parchment;

				m_Map1 = scroll.mapA;
				m_X1 = scroll.xA;
				m_Y1 = scroll.yA;
				m_Map2 = scroll.mapB;
				m_X2 = scroll.xB;
				m_Y2 = scroll.yB;

				if ( scroll.MsgComplete > 0 ){ sText = "You have found the '" + scroll.SearchItem + "'. Return to " + scroll.ForWho + " and bring them this message.<br><br>" + sText; }

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 10901, 2786);
				AddImage(0, 0, 10899, 2117);
				AddHtml( 45, 78, 386, 218, @"<BODY><BASEFONT Color=#d9c781>" + sText + "</BASEFONT></BODY>", (bool)false, (bool)true);


				if ( Sextants.HasSextant( from ) )
				{
					AddButton(68, 325, 10461, 10461, 1, GumpButtonType.Reply, 0);
					AddButton(377, 325, 10461, 10461, 2, GumpButtonType.Reply, 0);
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 

				if ( info.ButtonID > 0 )
				{
					from.CloseGump( typeof( Sextants.MapGump ) );
					from.CloseGump( typeof( SearchGump ) );
					from.SendGump( new SearchGump( from, m_Paper ) );

					if ( info.ButtonID == 1 )
						from.SendGump( new Sextants.MapGump( from, m_Map1, m_X1, m_Y1, null ) );
					else
						from.SendGump( new Sextants.MapGump( from, m_Map2, m_X2, m_Y2, null ) );
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
				e.PlaySound( 0x249 );
			}
		}

		public CourierMail(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)1);

			writer.Write( mapA );
			writer.Write( xA );
			writer.Write( yA );
			writer.Write( mapB );
			writer.Write( xB );
			writer.Write( yB );

			writer.Write( (Mobile)owner);
			writer.Write( SearchMessage );
			writer.Write( SearchDungeon );
			writer.Write( DungeonMap );
			writer.Write( SearchWorld );
			writer.Write( SearchItem );
			writer.Write( ForWho );
			writer.Write( ForWhere );
			writer.Write( ForAlignment );
			writer.Write( MsgComplete );
			writer.Write( MsgReward );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					mapA = reader.ReadMap();
					xA = reader.ReadInt();
					yA = reader.ReadInt();
					mapB = reader.ReadMap();
					xB = reader.ReadInt();
					yB = reader.ReadInt();
					goto case 0;
				}
				case 0:
				{
					owner = reader.ReadMobile();
					SearchMessage = reader.ReadString();
					SearchDungeon = reader.ReadString();
					DungeonMap = reader.ReadMap();
					SearchWorld = reader.ReadString();
					SearchItem = reader.ReadString();
					ForWho = reader.ReadString();
					ForWhere = reader.ReadString();
					ForAlignment = reader.ReadString();
					MsgComplete = reader.ReadInt();
					MsgReward = reader.ReadInt();
					break;
				}
			}
			ItemID = 0x2159;
		}
	}
}