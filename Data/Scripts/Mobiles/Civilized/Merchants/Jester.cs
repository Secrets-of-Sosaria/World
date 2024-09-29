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
	public class Jester : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override string TalkGumpTitle{ get{ return "Surely You Jest"; } }
		public override string TalkGumpSubject{ get{ return "Jester"; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.ThievesGuild; } }

		[Constructable]
		public Jester() : base( "the jester" )
		{
			SetSkill( SkillName.Marksmanship, 55.0, 78.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Begging, 65.0, 88.0 );
			SetSkill( SkillName.Lockpicking, 60.0, 83.0 );
			SetSkill( SkillName.Psychology, 65.0, 88.0 );
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
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Jester,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	typeof( DisguiseKit )	 );
					ItemInformation.GetSellList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	typeof( Lockpick )	 );
				}
			}

			public class InternalSellInfo : GenericSellInfo
			{
				public InternalSellInfo()
				{
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.None,		ItemSalesInfo.Material.None,		ItemSalesInfo.Market.Jester,	ItemSalesInfo.World.None,	null	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	typeof( DisguiseKit )	 );
					ItemInformation.GetBuysList( m_Merchant, this, 	ItemSalesInfo.Category.All,			ItemSalesInfo.Material.All,			ItemSalesInfo.Market.All,		ItemSalesInfo.World.None,	typeof( Lockpick )	 );
				}
			}
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			if ( this.FindItemOnLayer( Layer.OuterTorso ) != null ) { this.FindItemOnLayer( Layer.OuterTorso ).Delete(); }
			if ( this.FindItemOnLayer( Layer.Shoes ) != null ) { this.FindItemOnLayer( Layer.Shoes ).Delete(); }
			if ( this.FindItemOnLayer( Layer.InnerTorso ) != null ) { this.FindItemOnLayer( Layer.InnerTorso ).Delete(); }
			if ( this.FindItemOnLayer( Layer.Shirt ) != null ) { this.FindItemOnLayer( Layer.Shirt ).Delete(); }

			if ( Utility.RandomBool() )
			{
				AddItem( new Server.Items.JesterHat( Utility.RandomBlueHue() ) );
			}
			else
			{
				AddItem( new Server.Items.JokerHat( Utility.RandomBlueHue() ) );
			}

			switch ( Utility.RandomMinMax( 0, 2 ) ) 
			{
				case 0: AddItem( new Server.Items.JokerRobe( Utility.RandomBlueHue() ) ); break;
				case 1: AddItem( new Server.Items.JesterGarb( Utility.RandomBlueHue() ) ); break;
				case 2: AddItem( new Server.Items.FoolsCoat( Utility.RandomBlueHue() ) ); break;
			}

			AddItem( new Server.Items.JesterShoes( Utility.RandomBlueHue() ) );
		}

		private class FixEntry : ContextMenuEntry
		{
			private Jester m_Jester;
			private Mobile m_From;

			public FixEntry( Jester Jester, Mobile from ) : base( 6120, 12 )
			{
				m_Jester = Jester;
				m_From = from;
				Enabled = Jester.CheckVendorAccess( from );
			}

			public override void OnClick()
			{
				m_Jester.BeginServices( m_From );
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
            if ( Deleted || !from.Alive )
                return;

			int nCost = 100;

			if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
				SayTo(from, "Since you are begging, do you still want me to alter your hat, robe, or shoes to look more foolish as it will only cost you " + nCost.ToString() + " gold?");
			}
			else { SayTo(from, "If you want me to alter your hat, robe, or shoes to be more foolish, it will cost you " + nCost.ToString() + " gold."); }

            from.Target = new RepairTarget(this);
        }

        private class RepairTarget : Target
        {
            private Jester m_Jester;

            public RepairTarget(Jester tailor) : base(12, false, TargetFlags.None)
            {
                m_Jester = tailor;
            }

            protected override void OnTarget(Mobile from, object targeted)
			{
                if ( (
					targeted is BaseShoes || 
					targeted is BaseHat || 
					targeted is LeatherCap || 
					targeted is LeatherRobe || 
					targeted is ShinobiRobe || 
					targeted is ShinobiMask || 
					targeted is ShinobiCowl || 
					targeted is ShinobiHood || 
					targeted is LeatherSandals || 
					targeted is LeatherShoes || 
					targeted is LeatherBoots || 
					targeted is HikingBoots || 
					targeted is LeatherThighBoots || 
					targeted is LeatherSoftBoots || 
					targeted is BaseOuterTorso 

					) && from.Backpack != null )
                {
                    Item ba = targeted as Item;
                    Container pack = from.Backpack;
                    int toConsume = 0;

                    if ( ba.ItemID == 0x4C27 )
                    {
						m_Jester.SayTo(from, "That does not need my services.");
                    }
                    else
                    {
						int nCost = 100;

						if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
						{
							nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
						}
						toConsume = nCost;
                    }

                    if (toConsume == 0)
                        return;

                    if (pack.ConsumeTotal(typeof(Gold), toConsume))
                    {
						if ( BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -BeggingKarma( from ), true ); } // DO ANY KARMA LOSS
                        m_Jester.SayTo(from, "Here you go.");
                        from.SendMessage(String.Format("You pay {0} gold.", toConsume));
                        Effects.PlaySound(from.Location, from.Map, 0x248);

						string cls = "jester "; if ( Utility.RandomBool() ){ cls = "joker "; }
						string adj = "";

						if (	adj == "" && 
								( targeted is LeatherCap || 
								targeted is LeatherRobe || 
								targeted is ShinobiRobe || 
								targeted is ShinobiCowl || 
								targeted is ShinobiHood || 
								targeted is ShinobiMask || 
								targeted is LeatherSandals || 
								targeted is LeatherShoes || 
								targeted is HikingBoots || 
								targeted is LeatherBoots || 
								targeted is LeatherThighBoots || 
								targeted is LeatherSoftBoots ) )
						{
							adj = "leather ";
						}

						if ( targeted is BaseShoes || targeted is LeatherSandals || targeted is LeatherShoes || targeted is HikingBoots || targeted is LeatherBoots || targeted is LeatherThighBoots || targeted is LeatherSoftBoots )
						{
							ba.ItemID = 0x4C27;
							ba.Name = adj + cls + "shoes";
						}
						else if ( targeted is BaseHat || targeted is LeatherCap || targeted is ShinobiCowl || targeted is ShinobiHood || targeted is ShinobiMask )
						{
							if ( ba.ItemID == 0x171C ){ ba.ItemID = 0x4C15; } else { ba.ItemID = 0x171C; }
							ba.Name = adj + cls + "hat";
						}
						else if ( targeted is ShinobiRobe || targeted is LeatherRobe || targeted is BaseOuterTorso )
						{
							if ( ba.ItemID == 0x4C16 ){ ba.ItemID = 0x4C17; ba.Name = adj + cls + "suit"; }
							else if ( ba.ItemID == 0x4C17 ){ ba.ItemID = 0x2B6B; ba.Name = adj + cls + "coat"; }
							else { ba.ItemID = 0x4C16; ba.Name = adj + cls + "garb"; }
						}
                    }
                    else
                    {
                        m_Jester.SayTo(from, "It would cost you {0} gold to have that done.", toConsume);
                        from.SendMessage("You do not have enough gold.");
                    }
                }
				else
				{
					m_Jester.SayTo(from, "That does not need my services.");
				}
            }
        }

		public Jester( Serial serial ) : base( serial )
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

		private DateTime m_NextTalk;
		public DateTime NextTalk{ get{ return m_NextTalk; } set{ m_NextTalk = value; } }
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m is PlayerMobile )
			{
				if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) )
				{
					Server.Mobiles.ChucklesJester.DoJokes( this );
					m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( 30 ));
				}
			}
		}
	}
}