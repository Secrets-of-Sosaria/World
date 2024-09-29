using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;

namespace Server.Engines.Craft
{
	public class CraftContext
	{
		private List<CraftItem> m_Items;
		private int m_LastResourceIndex;
		private int m_LastResourceIndex2;
		private int m_LastGroupIndex;
		private bool m_DoNotColor;
		private CraftResource m_CraftingResource;
		private string m_Description;
		private Type m_ItemSelected;
		private int m_ItemID;
		private int m_Hue;
		private string m_NameString;

		public List<CraftItem> Items { get { return m_Items; } }
		public int LastResourceIndex{ get{ return m_LastResourceIndex; } set{ m_LastResourceIndex = value; } }
		public int LastResourceIndex2{ get{ return m_LastResourceIndex2; } set{ m_LastResourceIndex2 = value; } }
		public int LastGroupIndex{ get{ return m_LastGroupIndex; } set{ m_LastGroupIndex = value; } }
		public bool DoNotColor{ get{ return m_DoNotColor; } set{ m_DoNotColor = value; } }
		public CraftResource CraftingResource{ get{ return m_CraftingResource; } set{ m_CraftingResource = value; } }
		public string Description{ get{ return m_Description; } set{ m_Description = value; } }
		public Type ItemSelected{ get{ return m_ItemSelected; } set{ m_ItemSelected = value; } }
		public int ItemID{ get{ return m_ItemID; } set{ m_ItemID = value; } }
		public int Hue{ get{ return m_Hue; } set{ m_Hue = value; } }
		public string NameString{ get{ return m_NameString; } set{ m_NameString = value; } }

		public CraftContext()
		{
			m_Items = new List<CraftItem>();
			m_LastResourceIndex = -1;
			m_LastResourceIndex2 = -1;
			m_LastGroupIndex = -1;
			m_CraftingResource = CraftResource.None;
			m_Description = null;
			m_ItemSelected = null;
			m_ItemID = 0;
			m_Hue = 0;
			m_NameString = null;
		}

		public CraftItem LastMade
		{
			get
			{
				if ( m_Items.Count > 0 )
					return m_Items[0];

				return null;
			}
		}

		public void OnMade( CraftItem item )
		{
			m_Items.Remove( item );

			if ( m_Items.Count == 10 )
				m_Items.RemoveAt( 9 );

			m_Items.Insert( 0, item );
		}
	}
}