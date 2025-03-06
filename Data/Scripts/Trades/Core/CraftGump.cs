using System;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class CraftGump : Gump
	{
		private Mobile m_From;
		private CraftSystem m_CraftSystem;
		private BaseTool m_Tool;

		private CraftPage m_Page;

		private const int LabelHue = 0x480;
		private const string TextColor = "#FFFFFF";
		private const int LabelColor = 0x7FFF;
		private const int FontColor = 0xFFFFFF;
		private const int moveUp = -252;
		private const int moveDown = 147;

		private enum CraftPage
		{
			None,
			PickResource,
			PickResource2
		}

		public CraftGump( Mobile from, CraftSystem craftSystem, BaseTool tool, object notice ) : this( from, craftSystem, tool, notice, CraftPage.None )
		{
		}

		private CraftGump( Mobile from, CraftSystem craftSystem, BaseTool tool, object notice, CraftPage page ) : base( 40, 40 )
		{
			m_From = from;
			m_CraftSystem = craftSystem;
			m_Tool = tool;
				craftSystem.Tools = m_Tool;
			m_Page = page;

			CraftContext context = craftSystem.GetContext( from );

			from.CloseGump( typeof( CraftGump ) );
			from.CloseGump( typeof( CraftGumpItem ) );

			if ( tool.Parent == from || ( MySettings.S_AllowBackpackCraftTool && tool.IsChildOf(from.Backpack) ) )
			{
				AddPage( 0 );

				AddImage(0, 0, craftSystem.GumpImage, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddImage(0, 0, 9594, 0);

				if ( craftSystem.ShowGumpInfo )
					AddImage(527, 0, 9596, 0);

				if ( craftSystem.GumpTitleNumber > 0 )
					AddHtmlLocalized( 10, 12, 510, 20, craftSystem.GumpTitleNumber, LabelColor, false, false );
				else
					AddHtml( 10, 12, 510, 20, craftSystem.GumpTitleString, false, false );

				AddHtmlLocalized( 10, 37+moveDown, 200, 22, 1044010, LabelColor, false, false ); // <CENTER>CATEGORIES</CENTER>
				AddHtmlLocalized( 215, 37+moveDown, 305, 22, 1044011, LabelColor, false, false ); // <CENTER>SELECTIONS</CENTER>

				if ( craftSystem.ShowGumpInfo )
					AddHtml( 538, 7, 254, 422, @"<BODY><BASEFONT Color=" + TextColor + ">" + context.Description + "</BASEFONT></BODY>", false, true);

				AddButton( 175, 402+moveUp, 4017, 4019, 0, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 210, 405+moveUp, 150, 18, 1011441, LabelColor, false, false ); // EXIT

				if ( CraftSystem.AllowManyCraft( m_Tool ) && context.LastMade != null )
				{
					AddButton( 340, 404+moveUp, 11316, 11316, GetButtonID( 6, 2 ), GumpButtonType.Reply, 0 );
					AddButton( 370, 404+moveUp, 11317, 11317, 1000+GetButtonID( 6, 2 ), GumpButtonType.Reply, 0 );
					AddButton( 405, 404+moveUp, 11318, 11318, 2000+GetButtonID( 6, 2 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 445, 405+moveUp, 150, 18, 1044132, LabelColor, false, false ); // MAKE LAST
				}
				else if ( context.LastMade != null )
				{
					AddButton( 340, 402+moveUp, 4005, 4007, GetButtonID( 6, 2 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 375, 405+moveUp, 150, 18, 1044132, LabelColor, false, false ); // MAKE LAST
				}

				// Break down option
				if ( craftSystem.BreakDown )
				{
					AddButton( 175, 342+moveUp, 4005, 4007, GetButtonID( 6, 1 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 210, 345+moveUp, 150, 18, 1044259, LabelColor, false, false ); // BREAK DOWN
				}
				// ****************************************

				// Repair option
				if ( craftSystem.Repair )
				{
					AddButton( 340, 342+moveUp, 4005, 4007, GetButtonID( 6, 5 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 375, 345+moveUp, 150, 18, 1044260, LabelColor, false, false ); // REPAIR ITEM
				}
				// ****************************************

				// Enhance option
				if ( craftSystem.CanEnhance )
				{
					AddButton( 340, 371+moveUp, 4005, 4007, GetButtonID( 6, 8 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 375, 373+moveUp, 150, 18, 1061001, LabelColor, false, false ); // ENHANCE ITEM
				}
				// ****************************************

				DrawItem();

				if ( notice is int && (int)notice > 0 )
					AddHtmlLocalized( 170, 295+moveUp, 350, 40, (int)notice, LabelColor, false, false );
				else if ( notice is string )
					AddHtml( 170, 295+moveUp, 350, 40, String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", FontColor, notice ), false, false );
				else if ( m_Tool is BaseRunicTool )
				{
					string material = "This tool will create magical armor or weapons into " + CraftResources.GetName( ((BaseRunicTool)m_Tool).Resource ) + " material from any resource.";
					AddHtml( 170, 295+moveUp, 350, 40, String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", FontColor, material ), false, false );
				}

				if ( craftSystem.CraftSubRes.Init )
				{
					string nameString = craftSystem.CraftSubRes.NameString;
					int nameNumber = craftSystem.CraftSubRes.NameNumber;

					int resIndex = ( context == null ? -1 : context.LastResourceIndex );

					Type resourceType = craftSystem.CraftSubRes.ResType;

					if ( resIndex > -1 )
					{
						CraftSubRes subResource = craftSystem.CraftSubRes.GetAt( resIndex );

						nameString = subResource.NameString;
						nameNumber = subResource.NameNumber;
						resourceType = subResource.ItemType;
					}

					int resourceCount = 0;

					if ( from.Backpack != null )
					{
						Item[] items = from.Backpack.FindItemsByType( resourceType, true );

						for ( int i = 0; i < items.Length; ++i )
							resourceCount += items[i].Amount;
					}

					AddButton( 175, 371+moveUp, 4005, 4007, GetButtonID( 6, 0 ), GumpButtonType.Reply, 0 );

					if ( nameNumber > 0 )
						AddHtmlLocalized( 210, 373+moveUp, 250, 18, nameNumber, resourceCount.ToString(), LabelColor, false, false );
					else
						AddLabel( 210, 373+moveUp, LabelHue, String.Format( "{0} ({1} Available)", nameString, resourceCount ) );
				}

				CreateGroupList();

				if ( page == CraftPage.PickResource )
					CreateResList( false, from );
				else if ( page == CraftPage.PickResource2 )
					CreateResList( true, from );
				else if ( context != null && context.LastGroupIndex > -1 )
					CreateItemList( context.LastGroupIndex );
			}
		}

		public void DrawItem()
		{
			if ( (m_CraftSystem.GetContext( m_From )).ItemID > 0 )
				AddItem( 20, 50, (m_CraftSystem.GetContext( m_From )).ItemID, (m_CraftSystem.GetContext( m_From )).Hue );
		}

		public void CreateResList( bool opt, Mobile from )
		{
			CraftSubResCol res = m_CraftSystem.CraftSubRes;

			for ( int i = 0; i < res.Count; ++i )
			{
				int index = i % 10;

				CraftSubRes subResource = res.GetAt( i );

				if ( index == 0 )
				{
					if ( i > 0 )
						AddButton( 485, 260+moveDown, 4005, 4007, 0, GumpButtonType.Page, (i / 10) + 1 );

					AddPage( (i / 10) + 1 );

					if ( i > 0 )
						AddButton( 455, 260+moveDown, 4014, 4015, 0, GumpButtonType.Page, i / 10 );

					CraftContext context = m_CraftSystem.GetContext( m_From );

					AddButton( 220, 260+moveDown, 4005, 4007, GetButtonID( 6, 4 ), GumpButtonType.Reply, 0 );
					AddHtmlLocalized( 255, 263+moveDown, 200, 18, (context == null || !context.DoNotColor) ? 1061591 : 1061590, LabelColor, false, false );
				}

				int resourceCount = 0;

				if ( from.Backpack != null )
				{
					Item[] items = from.Backpack.FindItemsByType( subResource.ItemType, true );

					for ( int j = 0; j < items.Length; ++j )
						resourceCount += items[j].Amount;
				}

				AddButton( 220, 60+moveDown + (index * 20), 4005, 4007, GetButtonID( 5, i ), GumpButtonType.Reply, 0 );

				if ( subResource.NameNumber > 0 )
					AddHtmlLocalized( 255, 62+moveDown + (index * 20), 250, 18, subResource.NameNumber, resourceCount.ToString(), LabelColor, false, false );
				else
					AddLabel( 255, 62+moveDown + ( index * 20 ), LabelHue, String.Format( "{0} ({1})", subResource.NameString, resourceCount ) );
			}
		}

		public void CreateMakeLastList()
		{
			CraftContext context = m_CraftSystem.GetContext( m_From );

			if ( context == null )
				return;

			List<CraftItem> items = context.Items;

			if ( items.Count > 0 )
			{
				for ( int i = 0; i < items.Count; ++i )
				{
					int index = i % 10;

					CraftItem craftItem = items[i];

					if ( index == 0 )
					{
						if ( i > 0 )
						{
							AddButton( 370, 260+moveDown, 4005, 4007, 0, GumpButtonType.Page, (i / 10) + 1 );
							AddHtmlLocalized( 405, 263+moveDown, 100, 18, 1044045, LabelColor, false, false ); // NEXT PAGE
						}

						AddPage( (i / 10) + 1 );

						if ( i > 0 )
						{
							AddButton( 220, 260+moveDown, 4014, 4015, 0, GumpButtonType.Page, i / 10 );
							AddHtmlLocalized( 255, 263+moveDown, 100, 18, 1044044, LabelColor, false, false ); // PREV PAGE
						}
					}

					if ( CraftSystem.AllowManyCraft( m_Tool ) )
					{
						AddButton( 220, 60+moveDown + (index * 20), 4011, 4012, GetButtonID( 4, i ), GumpButtonType.Reply, 0 ); // LAST 10 ITEM INFO BUTTON
						AddButton( 411, 60+moveDown + (index * 20), 11316, 11316, GetButtonID( 3, i ), GumpButtonType.Reply, 0 );
						AddButton( 441, 60+moveDown + (index * 20), 11317, 11317, 1000+GetButtonID( 3, i ), GumpButtonType.Reply, 0 );
						AddButton( 476, 60+moveDown + (index * 20), 11318, 11318, 2000+GetButtonID( 3, i ), GumpButtonType.Reply, 0 );
					}
					else
					{
						AddButton( 220, 60+moveDown + (index * 20), 4005, 4007, GetButtonID( 3, i ), GumpButtonType.Reply, 0 ); // LAST 10 MAKE ITEM BUTTON
						AddButton( 480, 60+moveDown + (index * 20), 4011, 4012, GetButtonID( 4, i ), GumpButtonType.Reply, 0 ); // LAST 10 ITEM INFO BUTTON
					}

					if ( craftItem.NameNumber > 0 )
						AddHtmlLocalized( 255, 62+moveDown + (index * 20), 220, 18, craftItem.NameNumber, LabelColor, false, false );
					else
						AddLabel( 255, 62+moveDown + (index * 20), LabelHue, craftItem.NameString );
				}
			}
			else
			{
				// NOTE: This is not as OSI; it is an intentional difference

				AddHtmlLocalized( 230, 62+moveDown, 200, 22, 1044165, LabelColor, false, false ); // You haven't made anything yet.
			}
		}

		public void CreateItemList( int selectedGroup )
		{
			if ( selectedGroup == 501 ) // 501 : Last 10
			{
				CreateMakeLastList();
				return;
			}

			CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;
			CraftGroup craftGroup = craftGroupCol.GetAt( selectedGroup );
			CraftItemCol craftItemCol = craftGroup.CraftItems;

			for ( int i = 0; i < craftItemCol.Count; ++i )
			{
				int index = i % 10;

				CraftItem craftItem = craftItemCol.GetAt( i );

				if ( index == 0 )
				{
					if ( i > 0 )
					{
						AddButton( 370, 260+moveDown, 4005, 4007, 0, GumpButtonType.Page, (i / 10) + 1 );
						AddHtmlLocalized( 405, 263+moveDown, 100, 18, 1044045, LabelColor, false, false ); // NEXT PAGE
					}

					AddPage( (i / 10) + 1 );

					if ( i > 0 )
					{
						AddButton( 220, 260+moveDown, 4014, 4015, 0, GumpButtonType.Page, i / 10 );
						AddHtmlLocalized( 255, 263+moveDown, 100, 18, 1044044, LabelColor, false, false ); // PREV PAGE
					}
				}

				if ( CraftSystem.AllowManyCraft( m_Tool ) )
				{
					AddButton( 220, 60+moveDown + (index * 20), 4011, 4012, GetButtonID( 2, i ), GumpButtonType.Reply, 0 ); // ITEM LIST INFO BUTTON
					if ( MySettings.S_CraftButtons )
					{
						AddButton( 411, 60+moveDown + (index * 20), 11316, 11316, GetButtonID( 1, i ), GumpButtonType.Reply, 0 );
						AddButton( 441, 60+moveDown + (index * 20), 11317, 11317, 1000+GetButtonID( 1, i ), GumpButtonType.Reply, 0 );
						AddButton( 476, 60+moveDown + (index * 20), 11318, 11318, 2000+GetButtonID( 1, i ), GumpButtonType.Reply, 0 );
					}
				}
				else
				{
					AddButton( 220, 60+moveDown + (index * 20), 4005, 4007, GetButtonID( 1, i ), GumpButtonType.Reply, 0 ); // ITEM LIST MAKE BUTTON
					AddButton( 480, 60+moveDown + (index * 20), 4011, 4012, GetButtonID( 2, i ), GumpButtonType.Reply, 0 ); // ITEM LIST INFO BUTTON
				}

				if ( craftItem.NameNumber > 0 )
					AddHtmlLocalized( 255, 62+moveDown + (index * 20), 220, 18, craftItem.NameNumber, LabelColor, false, false );
				else
					AddLabel( 255, 62+moveDown + (index * 20), LabelHue, craftItem.NameString );
			}
		}

		public int CreateGroupList()
		{
			CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;

			AddButton( 15, 60+moveDown, 4005, 4007, GetButtonID( 6, 3 ), GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 50, 63+moveDown, 150, 18, 1044014, LabelColor, false, false ); // LAST TEN

			for ( int i = 0; i < craftGroupCol.Count; i++ )
			{
				CraftGroup craftGroup = craftGroupCol.GetAt( i );

				AddButton( 15, 80+moveDown + (i * 20), 4005, 4007, GetButtonID( 0, i ), GumpButtonType.Reply, 0 );

				if ( craftGroup.NameNumber > 0 )
					AddHtmlLocalized( 50, 82+moveDown + (i * 20), 150, 18, craftGroup.NameNumber, LabelColor, false, false );
				else
					AddLabel( 50, 82+moveDown + (i * 20), LabelHue, craftGroup.NameString );
			}

			return craftGroupCol.Count;
		}

		public static int GetButtonID( int type, int index )
		{
			return 1 + type + (index * 7);
		}

		public void CraftItem( CraftItem item )
		{
			int num = m_CraftSystem.CanCraft( m_From, m_Tool, item.ItemType );

			int extra = 0;

			bool CraftMany = CraftSystem.CraftingMany( m_From );

			CraftSystem.CraftStarting( m_From );

			CraftSystem.SetDescription( m_CraftSystem.GetContext( m_From ), m_Tool, item.ItemType, m_CraftSystem, item.NameString, m_From, item );

			if ( CraftMany )
				((PlayerMobile)m_From).CraftMessage();

			CraftSystem.CraftStartTool( m_From );

			while ( CraftSystem.CraftGetQueue( m_From ) > 0 )
			{
				CraftSystem.CraftReduceQueue( m_From, 1 );

				if ( CraftMany )
				{
					m_From.EndAction( typeof( CraftSystem ) );
					extra++;
					if ( extra > MyServerSettings.StatGainDelayNum() ){ extra = 1; }
					Server.Misc.SkillCheck.ResetStatGain( m_From, extra );
				}

				if ( num > 0 )
				{
					m_From.CloseGump( typeof( CraftGump ) );
					m_From.CloseGump( typeof( CraftGumpItem ) );
					m_From.SendGump( new CraftGump( m_From, m_CraftSystem, m_Tool, num ) );
				}
				else
				{
					Type type = null;

					CraftContext context = m_CraftSystem.GetContext( m_From );

					if ( context != null )
					{
						CraftSubResCol res = m_CraftSystem.CraftSubRes;
						int resIndex = context.LastResourceIndex;

						if ( resIndex >= 0 && resIndex < res.Count )
							type = res.GetAt( resIndex ).ItemType;
					}

					m_CraftSystem.CreateItem( m_From, item.ItemType, type, m_Tool, item );
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( CraftSystem.AllowManyCraft( m_Tool ) && !CraftSystem.CraftFinished( m_From, m_Tool ) )
			{
				m_From.SendGump( new CraftGump( m_From, m_CraftSystem, m_Tool, null ) );
				return;
			}

			CraftSystem.CraftClear( m_From );

			int buttonID = info.ButtonID;

			if ( buttonID <= 0 )
			{
				m_From.CloseGump( typeof( CraftGump ) );
				m_From.CloseGump( typeof( CraftGumpItem ) );
				return; // Canceled
			}

			if ( buttonID > 2000 && CraftSystem.AllowManyCraft( m_Tool ) )
			{
				buttonID = buttonID - 2000;
				CraftSystem.CraftSetQueue( m_From, 100 );
				((PlayerMobile)m_From).CraftSound = -1;
				((PlayerMobile)m_From).CraftSoundAfter = -1;
			}
			else if ( buttonID > 1000 && CraftSystem.AllowManyCraft( m_Tool ) )
			{
				buttonID = buttonID - 1000;
				CraftSystem.CraftSetQueue( m_From, 10 );
				((PlayerMobile)m_From).CraftSound = -1;
				((PlayerMobile)m_From).CraftSoundAfter = -1;
			}
			else
				CraftSystem.CraftSetQueue( m_From, 1 );

			buttonID = buttonID - 1;
			int type = buttonID % 7;
			int index = buttonID / 7;

			CraftSystem system = m_CraftSystem;
			CraftGroupCol groups = system.CraftGroups;
			CraftContext context = system.GetContext( m_From );

			switch ( type )
			{
				case 0: // Show group
				{
					if ( context == null )
						break;

					if ( index >= 0 && index < groups.Count )
					{
						context.LastGroupIndex = index;
						m_From.SendGump( new CraftGump( m_From, system, m_Tool, null ) );
					}

					break;
				}
				case 1: // Create item
				{
					if ( context == null )
						break;

					int groupIndex = context.LastGroupIndex;

					if ( groupIndex >= 0 && groupIndex < groups.Count )
					{
						CraftGroup group = groups.GetAt( groupIndex );

						if ( index >= 0 && index < group.CraftItems.Count )
							CraftItem( group.CraftItems.GetAt( index ) );
					}

					break;
				}
				case 2: // Item details
				{
					if ( context == null )
						break;

					int groupIndex = context.LastGroupIndex;

					if ( groupIndex >= 0 && groupIndex < groups.Count )
					{
						CraftGroup group = groups.GetAt( groupIndex );

						if ( index >= 0 && index < group.CraftItems.Count )
							m_From.SendGump( new CraftGumpItem( m_From, system, group.CraftItems.GetAt( index ), m_Tool ) );
					}

					break;
				}
				case 3: // Create item (last 10)
				{
					if ( context == null )
						break;

					List<CraftItem> lastTen = context.Items;

					if ( index >= 0 && index < lastTen.Count )
						CraftItem( lastTen[index] );

					break;
				}
				case 4: // Item details (last 10)
				{
					if ( context == null )
						break;

					List<CraftItem> lastTen = context.Items;

					if ( index >= 0 && index < lastTen.Count )
						m_From.SendGump( new CraftGumpItem( m_From, system, lastTen[index], m_Tool ) );

					break;
				}
				case 5: // Resource selected
				{
					if ( m_Page == CraftPage.PickResource && index >= 0 && index < system.CraftSubRes.Count )
					{
						int groupIndex = ( context == null ? -1 : context.LastGroupIndex );

						CraftSubRes res = system.CraftSubRes.GetAt( index );

						if ( m_From.Skills[system.MainSkill].Value < res.RequiredSkill )
						{
							m_From.SendGump( new CraftGump( m_From, system, m_Tool, res.Message ) );
						}
						else
						{
							if ( context != null )
								context.LastResourceIndex = index;

							CraftSystem.SetCraftResource( context, index, res );

							if ( context.LastMade != null )
								CraftSystem.SetDescription( context, m_Tool, (context.LastMade).ItemType, system, (context.LastMade).NameString, m_From, context.LastMade );
							else if ( context.ItemSelected != null )
								CraftSystem.SetDescription( context, m_Tool, context.ItemSelected, system, context.NameString, m_From, null );

							m_From.SendGump( new CraftGump( m_From, system, m_Tool, null ) );
						}
					}

					break;
				}
				case 6: // Misc. buttons
				{
					switch ( index )
					{
						case 0: // Resource selection
						{
							if ( system.CraftSubRes.Init )
								m_From.SendGump( new CraftGump( m_From, system, m_Tool, null, CraftPage.PickResource ) );

							break;
						}
						case 1: // Break down item
						{
							if ( system.BreakDown )
								BreakDown.Do( m_From, system, m_Tool );

							break;
						}
						case 2: // Make last
						{
							if ( context == null )
								break;

							CraftItem item = context.LastMade;

							if ( item != null )
								CraftItem( item );
							else
								m_From.SendGump( new CraftGump( m_From, m_CraftSystem, m_Tool, 1044165, m_Page ) ); // You haven't made anything yet.

							break;
						}
						case 3: // Last 10
						{
							if ( context == null )
								break;

							context.LastGroupIndex = 501;
							m_From.SendGump( new CraftGump( m_From, system, m_Tool, null ) );

							break;
						}
						case 4: // Toggle use resource hue
						{
							if ( context == null )
								break;

							context.DoNotColor = !context.DoNotColor;

							m_From.SendGump( new CraftGump( m_From, m_CraftSystem, m_Tool, null, m_Page ) );

							break;
						}
						case 5: // Repair item
						{
							if ( system.Repair )
								Repair.Do( m_From, system, m_Tool );

							break;
						}
						case 8: // Enhance item
						{
							if ( system.CanEnhance )
								Enhance.BeginTarget( m_From, system, m_Tool );

							break;
						}
					}

					break;
				}
			}
		}
	}
}