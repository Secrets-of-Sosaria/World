using Server;
using System;
using System.Collections.Generic;
using System.Collections;
using Server.Items;
using Server.Multis;
using Server.Guilds;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;

namespace Server.Mobiles
{
	public class Painter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override string TalkGumpTitle{ get{ return "Portraits of Adventurers"; } }
		public override string TalkGumpSubject{ get{ return "Painter"; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.BardsGuild; } }

		[Constructable]
		public Painter() : base( "the artist" )
		{
			SetSkill( SkillName.Anatomy, 65.0, 88.0 );
			SetSkill( SkillName.Cartography, 65.0, 88.0 );
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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Painter,			ItemSalesInfo.World.None,	null	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Painter,			ItemSalesInfo.World.None,	null	 );
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is PaintCanvas )
			{
				Container pack = from.Backpack;
				int paintPrice = 5000;

				if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
				{
					paintPrice = paintPrice - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * paintPrice ); if ( paintPrice < 1 ){ paintPrice = 1; }
				}

				if (pack.ConsumeTotal(typeof(Gold), paintPrice))
				{
					if ( BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -BeggingKarma( from ), true ); } // DO ANY KARMA LOSS
					this.SayTo(from, "Here is a nice painting of you.");
					from.SendMessage(String.Format("You pay {0} gold.", paintPrice));

					WaxPaintingA portrait = new WaxPaintingA();

					string sTitle = "the " + Server.Misc.GetPlayerInfo.GetSkillTitle( from );
					if ( from.Title != null && from.Title != "" ){ sTitle = from.Title; }
					sTitle = sTitle.Replace("  ", String.Empty);
					portrait.Name = "painting of " + from.Name + " " + sTitle;
					portrait.PaintingFlipID1 = 0xEA3;
					portrait.PaintingFlipID2 = 0xEA4;
					portrait.ItemID = 0xEA3;
					portrait.Weight = 15.0;

					from.AddToBackpack ( portrait );
				}
				else
				{
					this.SayTo(from, "It would cost you {0} gold to have a portrait done.", paintPrice);
					from.SendMessage("You do not have enough gold.");
					from.AddToBackpack ( new PaintCanvas() );
				}
				dropped.Delete();
			}
			else if ( dropped is WaxPaintingA && dropped.Weight == 15.0 )
			{
				this.SayTo(from, "How about this?");

				WaxPaintingA portrait = (WaxPaintingA)dropped;

				string sTitle = "the " + Server.Misc.GetPlayerInfo.GetSkillTitle( from );
				if ( from.Title != null ){ sTitle = from.Title; }
				sTitle = sTitle.Replace("  ", String.Empty);
				portrait.Name = "painting of " + from.Name + " " + sTitle;

				if ( dropped.ItemID == 0xEA3 || dropped.ItemID == 0xEA4 ){ 			portrait.PaintingFlipID1 = 0xEE7;	portrait.PaintingFlipID2 = 0xEC9;	portrait.ItemID = 0xEE7; }
				else if ( dropped.ItemID == 0xEE7 || dropped.ItemID == 0xEC9 ){		portrait.PaintingFlipID1 = 0xE9F;	portrait.PaintingFlipID2 = 0xEC8;	portrait.ItemID = 0xE9F; }
				else if ( dropped.ItemID == 0xE9F || dropped.ItemID == 0xEC8 ){		portrait.PaintingFlipID1 = 0xEA6;	portrait.PaintingFlipID2 = 0xEA8;	portrait.ItemID = 0xEA6; }
				else if ( dropped.ItemID == 0xEA6 || dropped.ItemID == 0xEA8 ){ 	portrait.PaintingFlipID1 = 0x2A5D;	portrait.PaintingFlipID2 = 0x2A61;	portrait.ItemID = 0x2A5D; }
				else if ( dropped.ItemID == 0x2A5D || dropped.ItemID == 0x2A61 ){	portrait.PaintingFlipID1 = 0x2A65;	portrait.PaintingFlipID2 = 0x2A67;	portrait.ItemID = 0x2A65; }
				else if ( dropped.ItemID == 0x2A65 || dropped.ItemID == 0x2A67 ){	portrait.PaintingFlipID1 = 0x2A69;	portrait.PaintingFlipID2 = 0x2A6D;	portrait.ItemID = 0x2A69; }
				else {																portrait.PaintingFlipID1 = 0xEA3;	portrait.PaintingFlipID2 = 0xEA4;	portrait.ItemID = 0xEA3; }

				from.AddToBackpack ( dropped );
			}
			return base.OnDragDrop( from, dropped );
		}

		///////////////////////////////////////////////////////////////////////////

		public Painter( Serial serial ) : base( serial )
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