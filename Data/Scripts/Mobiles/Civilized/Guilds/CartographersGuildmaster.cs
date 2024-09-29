using System;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class CartographersGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.CartographersGuild; } }

		public override string TalkGumpTitle{ get{ return "X Marks The Spot"; } }
		public override string TalkGumpSubject{ get{ return "Mapmaker"; } }

		[Constructable]
		public CartographersGuildmaster() : base( "cartographer" )
		{
			SetSkill( SkillName.Cartography, 90.0, 100.0 );
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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Cartographer,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Cartographer,		ItemSalesInfo.World.None,	typeof( BlankScroll )	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Cartographer,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,		ItemSalesInfo.Material.All,		ItemSalesInfo.Market.Cartographer,		ItemSalesInfo.World.None,	typeof( BlankScroll )	 );
				}
			}
		}

		private class FixEntry : ContextMenuEntry
		{
			private CartographersGuildmaster m_CartographersGuildmaster;
			private Mobile m_From;

			public FixEntry( CartographersGuildmaster CartographersGuildmaster, Mobile from ) : base( 6120, 12 )
			{
				m_CartographersGuildmaster = CartographersGuildmaster;
				m_From = from;
				Enabled = m_CartographersGuildmaster.CheckVendorAccess( from );
			}

			public override void OnClick()
			{
				m_CartographersGuildmaster.BeginServices( m_From );
			}
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( CheckChattingAccess( from ) )
				list.Add( new FixEntry( this, from ) );

			base.AddCustomContextEntries( from, list );
		}

        public void BeginServices(Mobile from)
        {
			int money = 1000;

			double w = money * (MyServerSettings.GetGoldCutRate() * .01);
			money = (int)w;

            if ( Deleted || !from.Alive )
                return;

			int nCost = money;

			if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
				SayTo(from, "Since you are begging, do you still want me to decipher a treasure map for you, it will only cost " + nCost.ToString() + " gold per level of the map?");
			}
			else { SayTo(from, "If you want me to decipher a treasure map for you, it will cost " + nCost.ToString() + " gold per level of the map"); }

            from.Target = new RepairTarget(this);
        }

        private class RepairTarget : Target
        {
            private CartographersGuildmaster m_CartographersGuildmaster;

            public RepairTarget(CartographersGuildmaster CartographersGuildmaster) : base(12, false, TargetFlags.None)
            {
                m_CartographersGuildmaster = CartographersGuildmaster;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
				int money = 1000;

				double w = money * (MyServerSettings.GetGoldCutRate() * .01);
				money = (int)w;

                if (targeted is TreasureMap && from.Backpack != null)
                {
                    TreasureMap tmap = targeted as TreasureMap;
                    Container pack = from.Backpack;
                    int toConsume = tmap.Level * money;

					if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
					{
						toConsume = toConsume - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * toConsume );
					}

                    if (toConsume == 0)
                        return;

					if ( tmap.Decoder != null )
					{
						m_CartographersGuildmaster.SayTo(from, "That map has already been deciphered.");
					}
                    else if (pack.ConsumeTotal(typeof(Gold), toConsume))
                    {
						if ( BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -BeggingKarma( from ), true ); } // DO ANY KARMA LOSS
						if ( tmap.Level == 1 ){ m_CartographersGuildmaster.SayTo(from, "This map was really quite simple."); }
						else if ( tmap.Level == 2 ){ m_CartographersGuildmaster.SayTo(from, "Seemed pretty easy...so here it is."); }
						else if ( tmap.Level == 3 ){ m_CartographersGuildmaster.SayTo(from, "This map was a bit of a challenge."); }
						else if ( tmap.Level == 4 ){ m_CartographersGuildmaster.SayTo(from, "Whoever drew this map, did not want it found."); }
						else if ( tmap.Level == 5 ){ m_CartographersGuildmaster.SayTo(from, "This took more research than normal."); }
						else { m_CartographersGuildmaster.SayTo(from, "With the ancient writings and riddles, this map should now lead you there."); }

                        from.SendMessage(String.Format("You pay {0} gold.", toConsume));
                        Effects.PlaySound(from.Location, from.Map, 0x249);
						tmap.Decoder = from;
                    }
                    else
                    {
                        m_CartographersGuildmaster.SayTo(from, "It would cost you {0} gold for me to decipher that map.", toConsume);
                        from.SendMessage("You do not have enough gold.");
                    }
                }
				else
				{
					m_CartographersGuildmaster.SayTo(from, "That does not need my services.");
				}
            }
        }

		public CartographersGuildmaster( Serial serial ) : base( serial )
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