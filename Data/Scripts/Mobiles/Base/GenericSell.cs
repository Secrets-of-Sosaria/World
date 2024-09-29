using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class GenericSellInfo : IShopSellInfo
	{
		private Dictionary<Type, int> m_Table = new Dictionary<Type, int>();
		private Type[] m_Types;

		public GenericSellInfo()
		{
		}

		public void Add( Type type, int price )
		{
			m_Table[type] = price;
			m_Types = null;
		}

		public int GetSellPriceFor( Item item, int barter )
		{
			int price = 0;
			m_Table.TryGetValue( item.GetType(), out price );

			price = ItemInformation.AddUpBenefits( item, price, false, false );

			price = (int)(price / 2);
				if ( barter > 0 )
				{
					if ( barter > 100 ){ barter = 100; }
					double nId = 1 + ( barter * 0.03 );
					price = (int)(price * nId);
				}
				if ( price < 1 )
					price = 1;

			return price;
		}

		public int GetBuyPriceFor( Item item )
		{
			return (int)( 1.90 * GetSellPriceFor( item, 0 ) );
		}

		public Type[] Types
		{
			get
			{
				if ( m_Types == null )
				{
					m_Types = new Type[m_Table.Keys.Count];
					m_Table.Keys.CopyTo( m_Types, 0 );
				}

				return m_Types;
			}
		}

		public string GetNameFor( Item item )
		{
			if ( item.Name != null )
				return item.Name;
			else
				return item.LabelNumber.ToString();
		}

		public bool IsSellable( Item item )
		{
			return IsInList( item.GetType() );
		}
	 
		public bool IsResellable( Item item )
		{
			return false;
		}

		public bool IsInList( Type type )
		{
			return m_Table.ContainsKey( type );
		}
	}
}
