using System;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Misc;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server.Mobiles
{
	public class Sage : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override string TalkGumpTitle{ get{ return "The Writing On The Wall"; } }
		public override string TalkGumpSubject{ get{ return "Sage"; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.LibrariansGuild; } }

		[Constructable]
		public Sage() : base( "the sage" )
		{
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.FistFighting, 60.0, 80.0 );
			SetSkill( SkillName.Mercantile, 64.0, 100.0 );
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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Sage,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Scribe,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Artifact,	ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Sage,		ItemSalesInfo.World.None,	null	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Sage,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Scribe,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Book,		ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	null	 );
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is Gold )
			{
				int Coins = dropped.Amount;
				string sMessage = "";

				if ( Coins == 500 )
				{
					if ( from.Skills[SkillName.Inscribe].Value >= 30 )
					{
						if ( Server.Misc.Research.AlreadyHasBag( from ) )
						{
							this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Good luck with your research." ) ); 
						}
						else
						{
							ResearchBag bag = new ResearchBag();
							from.PlaySound( 0x2E6 );
							Server.Misc.Research.SetupBag( from, bag );
							from.AddToBackpack( bag );
							this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Good luck with your research." ) ); 
						}
						dropped.Delete();
					}
					else
					{
						sMessage = "You need to be a neophyte scribe before I sell that to you.";
						from.AddToBackpack ( dropped );
					}
				}
				else if ( 	Coins == 10000 || 
							Coins == 9000 || 
							Coins == 8000 || 
							Coins == 7000 || 
							Coins == 6000 || 
							Coins == 5000 
					)
				{
					int nAllowedForAnotherQuest = SearchPage.ArtifactQuestTimeNew( from );
					int nServerQuestTimeAllowed = MyServerSettings.GetTimeBetweenArtifactQuests();
					int nWhenForAnotherQuest = nServerQuestTimeAllowed - nAllowedForAnotherQuest;

					if ( nWhenForAnotherQuest > 0 )
					{
						TimeSpan t = TimeSpan.FromMinutes( nWhenForAnotherQuest );

						string wait = string.Format("{0:D2} days {1:D2} hours and {2:D2} minutes", 
										t.Days, 
										t.Hours, 
										t.Minutes);

						sMessage = "I have no artifact encyclopedias at the moment. Check back in " + wait + ".";
						from.AddToBackpack ( dropped );
					}
					else
					{
						sMessage = "Good luck in your quest.";

						ArrayList targets = new ArrayList();
						foreach ( Item item in World.Items.Values )
						{
							if ( item is SearchBook )
							{
								SearchBook searchbook = (SearchBook)item;
								if ( searchbook.owner == from )
								{
									targets.Add( item );
								}
							}
							else if ( item is SearchPage )
							{
								SearchPage searchpage = (SearchPage)item;
								if ( searchpage.owner == from )
								{
									targets.Add( item );
								}
							}
						}
						for ( int i = 0; i < targets.Count; ++i )
						{
							Item item = ( Item )targets[ i ];
							item.Delete();
						}

						from.AddToBackpack ( new SearchBook( from, Coins ) );
						dropped.Delete();
					}
				}
				else
				{
					sMessage = "You look like you need this more than I do.";
					from.AddToBackpack ( dropped );
				}

				this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
			}

			return base.OnDragDrop( from, dropped );
		}

		public Sage( Serial serial ) : base( serial )
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