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
using Server.Regions;

namespace Server.Mobiles
{
	public class Priest : BaseHealer
	{
		public override bool CanTeach{ get{ return true; } }

		public override string TalkGumpTitle{ get{ return "Thou Art Going To Get Hurt"; } }
		public override string TalkGumpSubject{ get{ return "Healer"; } }

		public override bool CheckTeach( SkillName skill, Mobile from )
		{
			if ( !base.CheckTeach( skill, from ) )
				return false;

			return ( skill == SkillName.Healing )
				|| ( skill == SkillName.Spiritualism )
				|| ( skill == SkillName.Bludgeoning );
		}

		[Constructable]
		public Priest()
		{
			Title = "the priest";
			Direction = Direction.East;
			CantWalk = true;
			SpeechHue = Utility.RandomTalkHue();
			NameHue = 0xB0C;
			SetSkill( SkillName.Spiritualism, 80.0, 100.0 );
			SetSkill( SkillName.Bludgeoning, 80.0, 100.0 );
		}

		public override bool IsActiveVendor{ get{ return true; } }

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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( LesserHealPotion )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( Ginseng )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( Garlic )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( RefreshPotion )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( HealPotion )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.Christmas,	ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( MalletStake )	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( LesserHealPotion )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( Ginseng )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( Garlic )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( RefreshPotion )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.Healer,	ItemSalesInfo.World.None,	typeof( HealPotion )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.Christmas,	ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	null	 );
				}
			}
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new BlackStaff() );
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			int hasSymbol = 0;
			int hasBook = 0;
			int isPriest = 0;

			if ( dropped is MalletStake )
			{
				MalletStake stake = (MalletStake)dropped;

				int reward = stake.VampiresSlain;

				if ( reward > 0 )
				{
					from.AddToBackpack( new Gold( reward ) );

					string sMessage = "Thank you. Here is " + reward + " gold for your bravery.";

					if ( reward >= 1000 && from.Karma >= 2500 && from.Skills[SkillName.Spiritualism].Base > 0 && from.Skills[SkillName.Healing].Base > 0 )
					{
						foreach ( Item item in World.Items.Values )
						{
							if ( item is HolySymbol )
							{
								HolySymbol symbol = (HolySymbol)item;
								if ( symbol.owner == from )
								{
									from.AddToBackpack( symbol );
									hasSymbol = 1;
								}
							}
							else if ( item is HolyManSpellbook )
							{
								HolyManSpellbook book = (HolyManSpellbook)item;
								if ( book.owner == from )
								{
									from.AddToBackpack( book );
									hasBook = 1;
								}
							}
						}

						if ( hasSymbol == 0 ){ from.AddToBackpack ( new HolySymbol( from ) ); }
						if ( hasBook == 0 ){ HolyManSpellbook tome = new HolyManSpellbook( (ulong)0, from ); from.AddToBackpack ( tome ); }

						from.SendMessage( "You have been given your holy symbol and prayer book." );

						if ( hasSymbol + hasBook == 0 )
						{
							isPriest = 1;
							LoggingFunctions.LogGenericQuest( from, "has become a priest" );
							from.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
							from.PlaySound( 0x1EA );
							sMessage = from.Name + ", take the gold and these as well. You may be a good priest one day.";
						}
					}

					this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
					if ( isPriest == 0 ){ from.SendSound( 0x3D ); }
					dropped.Delete();
					return true;
				}

				return false;
			}
			else if ( dropped is Gold && dropped.Amount >= 5 && Server.Misc.GetPlayerInfo.isJedi ( from, false ) )
			{
				int crystals = (int)( dropped.Amount / 5 );
				this.Say( "Bring light to the world with these, Jedi." );
				from.AddToBackpack ( new KaranCrystal( crystals ) );
				dropped.Delete();
			}

			return base.OnDragDrop( from, dropped );
		}

		public Priest( Serial serial ) : base( serial )
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