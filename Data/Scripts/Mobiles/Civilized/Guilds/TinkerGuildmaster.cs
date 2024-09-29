using System;
using System.Collections.Generic;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class TinkerGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.TinkersGuild; } }

		[Constructable]
		public TinkerGuildmaster() : base( "tinker" )
		{
			SetSkill( SkillName.Lockpicking, 65.0, 88.0 );
			SetSkill( SkillName.Tinkering, 90.0, 100.0 );
			SetSkill( SkillName.RemoveTrap, 85.0, 100.0 );
		}

		public TinkerGuildmaster( Serial serial ) : base( serial )
		{
		}

		public override void InitSBInfo( Mobile m )
		{
			m_Merchant = m;
			SBInfos.Add( new MyStock() );
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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Resource,	ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Smith,			ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( CulinarySet )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( Hatchet )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( Pickaxe )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( ScalingTools )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( SewingKit )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( Spade )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( SkinningKnife )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( SmithHammer )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( LeatherworkingTools )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( TinkerTools )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	typeof( WoodworkingTools )	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Tinker,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Resource,	ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Smith,			ItemSalesInfo.World.None,	null	 );
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
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{	
			if ( Core.ML && from.Alive )
			{
				RechargeEntry entry = new RechargeEntry( from, this );
				
				if ( WeaponEngravingTool.Find( from ) == null )
					entry.Enabled = false;
					
				list.Add( entry );
			}
			
			base.AddCustomContextEntries( from, list );
		}
		
		private class RechargeEntry : ContextMenuEntry
		{
			private Mobile m_From;
			private Mobile m_Vendor;

			public RechargeEntry( Mobile from, Mobile vendor ) : base( 6271, 6 )
			{
				m_From = from;
				m_Vendor = vendor;
				Enabled = ((BaseVendor)m_Vendor).CheckVendorAccess( from );
			}

			public override void OnClick()
			{
				if ( !Core.ML || m_Vendor == null || m_Vendor.Deleted )
					return;
					
				WeaponEngravingTool tool = WeaponEngravingTool.Find( m_From );
				
				if ( tool != null && tool.UsesRemaining <= 0 )
				{
					if ( Banker.GetBalance( m_From ) >= 100000 )
						m_From.SendGump( new WeaponEngravingTool.ConfirmGump( tool, m_Vendor ) );
					else
						m_Vendor.Say( 1076167 ); // You need a 100,000 gold and a blue diamond to recharge the weapon engraver.
				}
				else
					m_Vendor.Say( 1076164 ); // I can only help with this if you are carrying an engraving tool that needs repair.
			}
		}
	}
}