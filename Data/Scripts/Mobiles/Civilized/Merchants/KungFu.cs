using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using System.Collections;
using Server.ContextMenus;
using Server.Gumps;
using Server.Multis;
using Server.Misc;
using Server.Guilds;

namespace Server.Mobiles
{
	public class KungFu : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
		public override bool IsBlackMarket { get { return true; } }

		public override string TalkGumpTitle{ get{ return "The Ways of the Orient"; } }
		public override string TalkGumpSubject{ get{ return "Monk"; } }
		
		[Constructable]
		public KungFu() : base( "the Monk" )
		{
			SetSkill( SkillName.Bushido, 85.0, 125.0 );
			SetSkill( SkillName.Fencing, 64.0, 80.0 );
			SetSkill( SkillName.Bludgeoning, 64.0, 80.0 );
			SetSkill( SkillName.Ninjitsu, 85.0, 125.0 );
			SetSkill( SkillName.Parry, 64.0, 80.0 );
			SetSkill( SkillName.Tactics, 64.0, 85.0 );
			SetSkill( SkillName.Swords, 64.0, 85.0 );
			SetSkill( SkillName.FistFighting, 85.0, 125.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Stealth, 65.0, 88.0 );
		}

		public override void InitSBInfo( Mobile m )
		{
			m_Merchant = m;
			m_SBInfos.Add( new MyStock() );
		}

		public class MyStock: SBInfo
		{
			private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
			private IShopSellInfo m_SellInfo = new InternalSellInfo();

			public MyStock()
			{
			}

			public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
			public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

			public class InternalBuyInfo : List<GenericBuyInfo>
			{
				public InternalBuyInfo()
				{
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Book,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.Cloth,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Armor,		ItemSalesInfo.Material.Leather,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Armor,		ItemSalesInfo.Material.Metal,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.Wood,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.Metal,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Book,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.Cloth,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Armor,		ItemSalesInfo.Material.Leather,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Armor,		ItemSalesInfo.Material.Metal,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.Wood,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.Metal,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient,	null	 );
				}
			}
		}

		public override void UpdateBlackMarket()
		{
			base.UpdateBlackMarket();

			if ( IsBlackMarket && MyServerSettings.BlackMarket() )
			{
				int v=1; while ( v > 0 ){ v--;
				ItemInformation.BlackMarketList( this, ItemSalesInfo.Category.Armor,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient	 );
				ItemInformation.BlackMarketList( this, ItemSalesInfo.Category.Weapon,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Monk,		ItemSalesInfo.World.Orient	 );
				}
			}
		}

		public override void InitOutfit()
		{
			Server.Misc.MorphingTime.RemoveMyClothes( this );
			Title = "the Monk";
			Server.Misc.IntelligentAction.DressUpWizards( this, true );
		}

		public KungFu( Serial serial ) : base( serial )
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