using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x3CF5, 0x3CF6 )]
	public class BaseShoppe : Item, ISecurable
	{
		[Constructable]
		public BaseShoppe() : base( 0x3CF5 )
		{
			Name = "Work Shoppe";
			Weight = 20.0;
			m_Level = SecureLevel.Anyone;
			SetupShelf();
			QuickTimer thisTimer = new QuickTimer( this ); 
			thisTimer.Start();
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);
			list.Add( 1049644, "Contains: " + ShoppeGold.ToString() + " Gold");
			if ( ShoppeOwner.Name == null ){ list.Add( 1070722, "Owner: " + ShoppeName + "" ); }
			else { list.Add( 1070722, "Owner: " + ShoppeOwner.Name + "" ); }
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			SetSecureLevelEntry.AddTo( from, this, list );
			if ( !this.Movable && CheckAccess( from ) )
			{
				list.Add( new CashOutEntry( from, this ) );
			}
		}

		public static string MakeTask( BaseShoppe shoppe )
		{
			string task = null;

			if ( shoppe is MorticianShoppe ){ task = Server.Items.MorticianShoppe.MakeThisTask(); }
			else if ( shoppe is HerbalistShoppe ){ task = Server.Items.HerbalistShoppe.MakeThisTask(); }
			else if ( shoppe is AlchemistShoppe ){ task = Server.Items.AlchemistShoppe.MakeThisTask(); }
			else if ( shoppe is BlacksmithShoppe ){ task = Server.Items.BlacksmithShoppe.MakeThisTask(); }
			else if ( shoppe is BowyerShoppe ){ task = Server.Items.BowyerShoppe.MakeThisTask(); }
			else if ( shoppe is CarpentryShoppe ){ task = Server.Items.CarpentryShoppe.MakeThisTask(); }
			else if ( shoppe is CartographyShoppe ){ task = Server.Items.CartographyShoppe.MakeThisTask(); }
			else if ( shoppe is BakerShoppe ){ task = Server.Items.BakerShoppe.MakeThisTask(); }
			else if ( shoppe is LibrarianShoppe ){ task = Server.Items.LibrarianShoppe.MakeThisTask(); }
			else if ( shoppe is TailorShoppe ){ task = Server.Items.TailorShoppe.MakeThisTask(); }
			else if ( shoppe is TinkerShoppe ){ task = Server.Items.TinkerShoppe.MakeThisTask(); }

			if ( task == null || task == "" ){ task = "Craft that item they need for their upcoming journey"; }

			return task;
		}

		public void SetupShelf() 
		{
			ShoppeGold = 0;
			ShoppeTools = 0;
			ShoppeResources = 0;
			ShoppeReputation = 0;
			Customer01 = "";
			Customer02 = "";
			Customer03 = "";
			Customer04 = "";
			Customer05 = "";
			Customer06 = "";
			Customer07 = "";
			Customer08 = "";
			Customer09 = "";
			Customer10 = "";
			Customer11 = "";
			Customer12 = "";
		} 

		public static void GiveNewShoppe( Mobile from, Mobile merchant )
		{
			Item shoppe = null;

			if ( merchant is Witches || merchant is Necromancer || merchant is NecromancerGuildmaster ){ shoppe = new MorticianShoppe(); }
			else if ( merchant is Herbalist || merchant is DruidTree || merchant is Druid || merchant is DruidGuildmaster ){ shoppe = new HerbalistShoppe(); }
			else if ( merchant is Alchemist || merchant is AlchemistGuildmaster ){ shoppe = new AlchemistShoppe(); }
			else if ( merchant is Blacksmith || merchant is BlacksmithGuildmaster ){ shoppe = new BlacksmithShoppe(); }
			else if ( merchant is Bowyer || merchant is ArcherGuildmaster ){ shoppe = new BowyerShoppe(); }
			else if ( merchant is Carpenter || merchant is CarpenterGuildmaster ){ shoppe = new CarpentryShoppe(); }
			else if ( merchant is Mapmaker || merchant is CartographersGuildmaster ){ shoppe = new CartographyShoppe(); }
			else if ( merchant is Cook || merchant is Baker || merchant is CulinaryGuildmaster ){ shoppe = new BakerShoppe(); }
			else if ( merchant is Scribe || merchant is Sage || merchant is LibrarianGuildmaster ){ shoppe = new LibrarianShoppe(); }
			else if ( merchant is Weaver || merchant is Tailor || merchant is LeatherWorker || merchant is TailorGuildmaster ){ shoppe = new TailorShoppe(); }
			else if ( merchant is Tinker || merchant is TinkerGuildmaster ){ shoppe = new TinkerShoppe(); }

			int gold = from.TotalGold;
			int fee = 10000;
			bool begging = false;

			if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				int cut = (int)(from.Skills[SkillName.Begging].Value * 25 );
					if ( cut > 3000 ){ cut = 3000; }
				fee = fee - cut;
				begging = true;
			}

			if ( from.Kills > 0 )
			{
                from.SendMessage("I don't think anyone really wants to deal with murderers.");
			}
			else if ( AlreadyHasShoppe( from, shoppe ) )
			{
				merchant.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Good luck with your shoppe." ) ); 
			}
			else if ( gold >= fee && shoppe != null )
			{
				Container cont = from.Backpack;
				cont.ConsumeTotal( typeof( Gold ), fee );
				BaseShoppe store = (BaseShoppe)shoppe;
				from.SendSound( 0x23D );
				store.ShoppeOwner = from;
				store.ShoppeName = from.Name;
				from.AddToBackpack( store );
				Server.Misc.Customers.CustomerCycle( from, store );
				
				if ( begging )
					merchant.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Since you are begging, this shoppe is only " + fee + " gold." ) ); 
				else
					merchant.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Good luck with your shoppe." ) ); 
			}
			else
				merchant.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Sorry, but you do not have enough gold to start a shoppe." ) ); 
		}

		public static bool AlreadyHasShoppe( Mobile from, Item shelf )
		{
			BaseShoppe shoppe = (BaseShoppe)shelf;
			bool HasShoppe = false;

			ArrayList targets = new ArrayList();
			foreach ( Item item in World.Items.Values )
			{
				if ( item is MorticianShoppe && item != shoppe && shoppe is MorticianShoppe ){ targets.Add( item ); }
				else if ( item is HerbalistShoppe && item != shoppe && shoppe is HerbalistShoppe ){ targets.Add( item ); }
				else if ( item is AlchemistShoppe && item != shoppe && shoppe is AlchemistShoppe ){ targets.Add( item ); }
				else if ( item is BlacksmithShoppe && item != shoppe && shoppe is BlacksmithShoppe ){ targets.Add( item ); }
				else if ( item is BowyerShoppe && item != shoppe && shoppe is BowyerShoppe ){ targets.Add( item ); }
				else if ( item is CarpentryShoppe && item != shoppe && shoppe is CarpentryShoppe ){ targets.Add( item ); }
				else if ( item is CartographyShoppe && item != shoppe && shoppe is CartographyShoppe ){ targets.Add( item ); }
				else if ( item is BakerShoppe && item != shoppe && shoppe is BakerShoppe ){ targets.Add( item ); }
				else if ( item is LibrarianShoppe && item != shoppe && shoppe is LibrarianShoppe ){ targets.Add( item ); }
				else if ( item is TailorShoppe && item != shoppe && shoppe is TailorShoppe ){ targets.Add( item ); }
				else if ( item is TinkerShoppe && item != shoppe && shoppe is TinkerShoppe ){ targets.Add( item ); }
			}
			for ( int i = 0; i < targets.Count; ++i )
			{
				Item item = ( Item )targets[ i ];

				if ( item is BaseShoppe )
				{
					BaseShoppe store = (BaseShoppe)item;

					if ( store.ShoppeOwner == from )
					{
						HasShoppe = true; 

						from.SendSound( 0x23D );

						shoppe.ShoppeOwner = store.ShoppeOwner;
						shoppe.ShoppeName = store.ShoppeName;
						shoppe.ShoppeGold = store.ShoppeGold;
						shoppe.ShoppeTools = store.ShoppeTools;
						shoppe.ShoppeResources = store.ShoppeResources;
						shoppe.ShoppeReputation = store.ShoppeReputation;
						shoppe.ShoppePage = store.ShoppePage;
						shoppe.ShelfTitle = store.ShelfTitle;
						shoppe.ShelfItem = store.ShelfItem;
						shoppe.ShelfSkill = store.ShelfSkill;
						shoppe.ShelfGuild = store.ShelfGuild;
						shoppe.ShelfTools = store.ShelfTools;
						shoppe.ShelfResources = store.ShelfResources;
						shoppe.ShelfSound = store.ShelfSound;
						shoppe.Customer01 = store.Customer01;
						shoppe.Customer02 = store.Customer02;
						shoppe.Customer03 = store.Customer03;
						shoppe.Customer04 = store.Customer04;
						shoppe.Customer05 = store.Customer05;
						shoppe.Customer06 = store.Customer06;
						shoppe.Customer07 = store.Customer07;
						shoppe.Customer08 = store.Customer08;
						shoppe.Customer09 = store.Customer09;
						shoppe.Customer10 = store.Customer10;
						shoppe.Customer11 = store.Customer11;
						shoppe.Customer12 = store.Customer12;
						from.AddToBackpack( shelf );
						store.Delete();
					}
				}
			}

			return HasShoppe;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Movable )
			{
				from.SendMessage( "This must be secured down in a home to use." );
			}
			else if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.SendMessage( "You will have to get closer to use that." );
			}
			else if ( from.Kills > 0 )
			{
                from.SendMessage("This is useless since no one deals with murderers!");
			}
			else if ( ShoppeOwner != from )
			{
				from.SendMessage ("This is not your shoppe.");
			}
			else
			{
				ShoppeName = from.Name;
				from.SendSound( 0x2F );
				from.CloseGump( typeof( Server.Items.ShoppeGump ) );
				from.SendGump( new Server.Items.ShoppeGump( this, from ) );
			}

			return;
		}

		public static void ProgressSkill( Mobile from, BaseShoppe shoppe )
		{
			if ( shoppe is MorticianShoppe ){ from.CheckSkill( SkillName.Forensics, 0, 125 ); }
			else if ( shoppe is HerbalistShoppe ){ from.CheckSkill( SkillName.Druidism, 0, 125 ); }
			else if ( shoppe is AlchemistShoppe ){ from.CheckSkill( SkillName.Alchemy, 0, 125 ); }
			else if ( shoppe is BlacksmithShoppe ){ from.CheckSkill( SkillName.Blacksmith, 0, 125 ); }
			else if ( shoppe is BowyerShoppe ){ from.CheckSkill( SkillName.Bowcraft, 0, 125 ); }
			else if ( shoppe is CarpentryShoppe ){ from.CheckSkill( SkillName.Carpentry, 0, 125 ); }
			else if ( shoppe is CartographyShoppe ){ from.CheckSkill( SkillName.Cartography, 0, 125 ); }
			else if ( shoppe is BakerShoppe ){ from.CheckSkill( SkillName.Cooking, 0, 125 ); }
			else if ( shoppe is LibrarianShoppe ){ from.CheckSkill( SkillName.Inscribe, 0, 125 ); }
			else if ( shoppe is TailorShoppe ){ from.CheckSkill( SkillName.Tailoring, 0, 125 ); }
			else if ( shoppe is TinkerShoppe ){ from.CheckSkill( SkillName.Tinkering, 0, 125 ); }
		}

		public class CashOutEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private BaseShoppe m_Shoppe;
	
			public CashOutEntry( Mobile from, BaseShoppe shelf ) : base( 6113, 3 )
			{
				m_Mobile = from;
				m_Shoppe = shelf;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( m_Shoppe.ShoppeGold > 0 )
					{
						double barter = (int)( m_Mobile.Skills[SkillName.Mercantile].Value / 2 );

						if ( mobile.NpcGuild == NpcGuild.MerchantsGuild )
							barter = barter + 25.0; // FOR GUILD MEMBERS

						barter = barter / 100;

						int bonus = (int)( m_Shoppe.ShoppeGold * barter );

						int cash = m_Shoppe.ShoppeGold + bonus;

						m_Mobile.AddToBackpack( new BankCheck( cash ) );
						m_Mobile.SendMessage("You now have a check for " + cash.ToString() + " gold.");
						m_Shoppe.ShoppeGold = 0;
						m_Shoppe.InvalidateProperties();
					}
					else
					{
						m_Mobile.SendMessage("There is no gold in this shoppe!");
					}
				}
            }
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
			bool procResource = false;
			bool procTools = false;

			if ( ( dropped.ItemID >= 0x1BE3 && dropped.ItemID <= 0x1BFA ) && this is BlacksmithShoppe ){ procResource = true; }
			else if ( ( dropped.ItemID >= 0x1BE3 && dropped.ItemID <= 0x1BFA ) && this is TinkerShoppe ){ procResource = true; }
			else if ( ( dropped is BaseFabric || 
						dropped is BaseLeather ) && this is TailorShoppe ){ procResource = true; }
			else if ( dropped.Catalog == Catalogs.Reagent && Server.Items.WitchPouch.isWitchery( dropped ) && this is MorticianShoppe ){ procResource = true; }
			else if ( ( dropped is BlankScroll ) && this is LibrarianShoppe ){ procResource = true; }
			else if ( ( dropped is Dough || dropped is SweetDough ) && this is BakerShoppe ){ procResource = true; }
			else if ( dropped is BlankScroll && this is CartographyShoppe ){ procResource = true; }
			else if ( ( dropped is BaseLog || 
						dropped is BaseWoodBoard ) && this is CarpentryShoppe ){ procResource = true; }
			else if ( ( dropped is BaseLog || 
						dropped is BaseWoodBoard ) && this is BowyerShoppe ){ procResource = true; }
			else if ( dropped.Catalog == Catalogs.Reagent && Server.Items.DruidPouch.isDruidery( dropped ) && this is HerbalistShoppe ){ procResource = true; }
			else if ( dropped.Catalog == Catalogs.Reagent && this is AlchemistShoppe ){ procResource = true; }

			else if ( ( dropped is GodSmithing || 
						dropped is SmithHammer || 
						dropped is ScalingTools ) && this is BlacksmithShoppe ){ procTools = true; }
			else if ( dropped is TinkerTools && this is TinkerShoppe ){ procTools = true; }
			else if ( ( dropped is GodSewing || 
						dropped is SewingKit ) && this is TailorShoppe ){ procTools = true; }
			else if ( dropped is ScribesPen && this is LibrarianShoppe ){ procTools = true; }
			else if ( dropped is MapmakersPen && this is CartographyShoppe ){ procTools = true; }
			else if ( dropped is FletcherTools && this is BowyerShoppe ){ procTools = true; }
			else if ( dropped is WitchCauldron && this is MorticianShoppe ){ procTools = true; }
			else if ( dropped is DruidCauldron && this is HerbalistShoppe ){ procTools = true; }
			else if ( ( dropped is MortarPestle || 
						dropped is GodBrewing ) && this is AlchemistShoppe ){ procTools = true; }
			else if ( dropped is CulinarySet && this is BakerShoppe ){ procTools = true; }
			else if ( dropped is CarpenterTools && this is CarpentryShoppe ){ procTools = true; }

			if ( Movable )
			{
				from.SendMessage( "This must be secured down in a home to use." );
			}
			else if ( from.Kills > 0 )
			{
                from.SendMessage("This is useless since no one deals with murderers!");
			}
			else if ( procResource )
			{
				if ( ShoppeResources >= 5000 )
				{
					ShoppeResources = 5000;
					from.SendMessage( "Your shoppe is already full of resources." );
				}
				else
				{
					int remainingSpace = 5000 - ShoppeResources;

                    // Prevent consuming dropped resources beyond shoppe maximum
                    if ( dropped.Amount > remainingSpace )
                    {
                        from.SendMessage( "You can only add " + remainingSpace + " more resources." );
                        return false;
                    }
                    
					ShoppeResources = ShoppeResources + dropped.Amount;

                    from.SendMessage( "You add " + dropped.Amount + " resources to your shoppe." );

                    if ( ShoppeResources == 5000 )
                    {
                        from.SendMessage( "Your shoppe is now full of resources." );
                    }

					from.SendSound( 0x42 );
					dropped.Delete();
					return true;
				}
			}
			else if ( procTools )
			{
				if ( ShoppeTools >= 1000 )
				{
					ShoppeTools = 1000;
					from.SendMessage( "Your shoppe is already full of tools." );
				}
				else
				{
					BaseTool tool = (BaseTool)dropped;
					ShoppeTools = ShoppeTools + tool.UsesRemaining;
					if ( ShoppeTools >= 1000 )
					{
						ShoppeTools = 1000;
						from.SendMessage( "You add another tool but now your shoppe is full." );
					}
					from.SendSound( 0x42 );
					dropped.Delete();
					return true;
				}
			}

			return false;
		}

		public void Customers()
		{
			if ( ShoppeOwner != null )
			{
				Server.Misc.Customers.CustomerCycle( ShoppeOwner, this );

				if ( m_Timer != null )
					m_Timer.Stop();

				m_Timer = new CustomerTimer( this ); 
				m_Timer.Start();
			}
			else
			{
				this.Delete();
			}
		}

		public bool CheckAccess(Mobile m)
		{
			BaseHouse house = BaseHouse.FindHouseAt(this);

			if (house != null && (house.Public ? house.IsBanned(m) : !house.HasAccess(m)))
				return false;

			return (house != null && house.HasSecureAccess(m, m_Level));
		}

		public BaseShoppe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write((int)m_Level);
			writer.Write( (Mobile)ShoppeOwner);
			writer.Write( ShoppeName );
			writer.Write( ShoppeGold );
			writer.Write( ShoppeTools );
			writer.Write( ShoppeResources );
			writer.Write( ShoppeReputation );
			writer.Write( ShoppePage );
			writer.Write( ShelfTitle );
			writer.Write( ShelfItem );
			writer.Write( ShelfSkill );
			writer.Write( (int) ShelfGuild );
			writer.Write( ShelfTools );
			writer.Write( ShelfResources );
			writer.Write( ShelfSound );
			writer.Write( Customer01 );
			writer.Write( Customer02 );
			writer.Write( Customer03 );
			writer.Write( Customer04 );
			writer.Write( Customer05 );
			writer.Write( Customer06 );
			writer.Write( Customer07 );
			writer.Write( Customer08 );
			writer.Write( Customer09 );
			writer.Write( Customer10 );
			writer.Write( Customer11 );
			writer.Write( Customer12 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel)reader.ReadInt();
			ShoppeOwner = reader.ReadMobile();
			ShoppeName = reader.ReadString();
			ShoppeGold = reader.ReadInt();
			ShoppeTools = reader.ReadInt();
			ShoppeResources = reader.ReadInt();
			ShoppeReputation = reader.ReadInt();
			ShoppePage = reader.ReadInt();
			ShelfTitle = reader.ReadString();
			ShelfItem = reader.ReadInt();
			ShelfSkill = reader.ReadInt();
			ShelfGuild = (NpcGuild)reader.ReadInt();
			ShelfTools = reader.ReadString();
			ShelfResources = reader.ReadString();
			ShelfSound = reader.ReadInt();
			Customer01 = reader.ReadString();
			Customer02 = reader.ReadString();
			Customer03 = reader.ReadString();
			Customer04 = reader.ReadString();
			Customer05 = reader.ReadString();
			Customer06 = reader.ReadString();
			Customer07 = reader.ReadString();
			Customer08 = reader.ReadString();
			Customer09 = reader.ReadString();
			Customer10 = reader.ReadString();
			Customer11 = reader.ReadString();
			Customer12 = reader.ReadString();

			QuickTimer thisTimer = new QuickTimer( this ); 
			thisTimer.Start();
		}

		private Timer m_Timer;

		private class CustomerTimer : Timer
		{
			private BaseShoppe m_Shoppe;

			public CustomerTimer( BaseShoppe shoppe ) : base( TimeSpan.FromHours( 2.0 ) )
			{
				m_Shoppe = shoppe;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Shoppe.Customers();
			}
		}

		private class QuickTimer : Timer
		{
			private BaseShoppe m_Shoppe;

			public QuickTimer( BaseShoppe shoppe ) : base( TimeSpan.FromSeconds( 60.0 ) )
			{
				m_Shoppe = shoppe;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Shoppe.Customers();
			}
		}

        public SecureLevel m_Level;
        [CommandProperty(AccessLevel.GameMaster)]
        public SecureLevel Level { get { return m_Level; } set { m_Level = value; } }

		// ------------------------------------------------------------------------------------------------------------------------------------------

		public Mobile ShoppeOwner;
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Shoppe_Owner { get{ return ShoppeOwner; } set{ ShoppeOwner = value; InvalidateProperties(); } }

		public string ShoppeName;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Shoppe_Name { get{ return ShoppeName; } set{ ShoppeName = value; InvalidateProperties(); } }

		public int ShoppeGold;
		[CommandProperty(AccessLevel.Owner)]
		public int Shoppe_Gold{ get { return ShoppeGold; } set { ShoppeGold = value; InvalidateProperties(); } }

		public int ShoppeTools;
		[CommandProperty(AccessLevel.Owner)]
		public int Shoppe_Tools{ get { return ShoppeTools; } set { ShoppeTools = value; InvalidateProperties(); } }

		public int ShoppeResources;
		[CommandProperty(AccessLevel.Owner)]
		public int Shoppe_Resources{ get { return ShoppeResources; } set { ShoppeResources = value; InvalidateProperties(); } }

		public int ShoppeReputation;
		[CommandProperty(AccessLevel.Owner)]
		public int Shoppe_Reputation{ get { return ShoppeReputation; } set { ShoppeReputation = value; InvalidateProperties(); } }

		public int ShoppePage;
		[CommandProperty(AccessLevel.Owner)]
		public int Shoppe_Page{ get { return ShoppePage; } set { ShoppePage = value; InvalidateProperties(); } }

		// ------------------------------------------------------------------------------------------------------------------------------------------

		public string ShelfTitle;
		[CommandProperty(AccessLevel.Owner)]
		public string Shelf_Title{ get { return ShelfTitle; } set { ShelfTitle = value; InvalidateProperties(); } }

		public int ShelfItem;
		[CommandProperty(AccessLevel.Owner)]
		public int Shelf_Item{ get { return ShelfItem; } set { ShelfItem = value; InvalidateProperties(); } }

		public int ShelfSkill;
		[CommandProperty(AccessLevel.Owner)]
		public int Shelf_Skill{ get { return ShelfSkill; } set { ShelfSkill = value; InvalidateProperties(); } }

		public NpcGuild ShelfGuild;
		[CommandProperty(AccessLevel.Owner)]
		public NpcGuild Shelf_Guild{ get { return ShelfGuild; } set { ShelfGuild = value; InvalidateProperties(); } }

		public string ShelfTools;
		[CommandProperty(AccessLevel.Owner)]
		public string Shelf_Tools{ get { return ShelfTools; } set { ShelfTools = value; InvalidateProperties(); } }

		public string ShelfResources;
		[CommandProperty(AccessLevel.Owner)]
		public string Shelf_Resources{ get { return ShelfResources; } set { ShelfResources = value; InvalidateProperties(); } }

		public int ShelfSound;
		[CommandProperty(AccessLevel.Owner)]
		public int Shelf_Sound{ get { return ShelfSound; } set { ShelfSound = value; InvalidateProperties(); } }

		// ------------------------------------------------------------------------------------------------------------------------------------------

		public string Customer01;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_01{ get { return Customer01; } set { Customer01 = value; InvalidateProperties(); } }

		public string Customer02;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_02{ get { return Customer02; } set { Customer02 = value; InvalidateProperties(); } }

		public string Customer03;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_03{ get { return Customer03; } set { Customer03 = value; InvalidateProperties(); } }

		public string Customer04;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_04{ get { return Customer04; } set { Customer04 = value; InvalidateProperties(); } }

		public string Customer05;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_05{ get { return Customer05; } set { Customer05 = value; InvalidateProperties(); } }

		public string Customer06;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_06{ get { return Customer06; } set { Customer06 = value; InvalidateProperties(); } }

		public string Customer07;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_07{ get { return Customer07; } set { Customer07 = value; InvalidateProperties(); } }

		public string Customer08;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_08{ get { return Customer08; } set { Customer08 = value; InvalidateProperties(); } }

		public string Customer09;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_09{ get { return Customer09; } set { Customer09 = value; InvalidateProperties(); } }

		public string Customer10;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_10{ get { return Customer10; } set { Customer10 = value; InvalidateProperties(); } }

		public string Customer11;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_11{ get { return Customer11; } set { Customer11 = value; InvalidateProperties(); } }

		public string Customer12;
		[CommandProperty(AccessLevel.Owner)]
		public string Customer_12{ get { return Customer12; } set { Customer12 = value; InvalidateProperties(); } }

		public static int GetSkillValue( int job, Mobile from )
		{
			SkillName skill = SkillName.Alchemy;

			if ( job > 0 )
			{
				if ( job == 1 ){ skill = SkillName.Alchemy; }
				else if ( job == 2 ){ skill = SkillName.Anatomy; }
				else if ( job == 3 ){ skill = SkillName.Druidism; }
				else if ( job == 4 ){ skill = SkillName.Taming; }
				else if ( job == 5 ){ skill = SkillName.Marksmanship; }
				else if ( job == 6 ){ skill = SkillName.ArmsLore; }
				else if ( job == 7 ){ skill = SkillName.Begging; }
				else if ( job == 8 ){ skill = SkillName.Blacksmith; }
				else if ( job == 9 ){ skill = SkillName.Bushido; }
				else if ( job == 10 ){ skill = SkillName.Camping; }
				else if ( job == 11 ){ skill = SkillName.Carpentry; }
				else if ( job == 12 ){ skill = SkillName.Cartography; }
				else if ( job == 13 ){ skill = SkillName.Knightship; }
				else if ( job == 14 ){ skill = SkillName.Cooking; }
				else if ( job == 15 ){ skill = SkillName.Searching; }
				else if ( job == 16 ){ skill = SkillName.Discordance; }
				else if ( job == 17 ){ skill = SkillName.Psychology; }
				else if ( job == 18 ){ skill = SkillName.Fencing; }
				else if ( job == 19 ){ skill = SkillName.Seafaring; }
				else if ( job == 20 ){ skill = SkillName.Bowcraft; }
				else if ( job == 21 ){ skill = SkillName.Focus; }
				else if ( job == 22 ){ skill = SkillName.Forensics; }
				else if ( job == 23 ){ skill = SkillName.Healing; }
				else if ( job == 24 ){ skill = SkillName.Herding; }
				else if ( job == 25 ){ skill = SkillName.Hiding; }
				else if ( job == 26 ){ skill = SkillName.Inscribe; }
				else if ( job == 27 ){ skill = SkillName.Mercantile; }
				else if ( job == 28 ){ skill = SkillName.Lockpicking; }
				else if ( job == 29 ){ skill = SkillName.Lumberjacking; }
				else if ( job == 30 ){ skill = SkillName.Bludgeoning; }
				else if ( job == 31 ){ skill = SkillName.Magery; }
				else if ( job == 32 ){ skill = SkillName.MagicResist; }
				else if ( job == 33 ){ skill = SkillName.Meditation; }
				else if ( job == 34 ){ skill = SkillName.Mining; }
				else if ( job == 35 ){ skill = SkillName.Musicianship; }
				else if ( job == 36 ){ skill = SkillName.Necromancy; }
				else if ( job == 37 ){ skill = SkillName.Ninjitsu; }
				else if ( job == 38 ){ skill = SkillName.Parry; }
				else if ( job == 39 ){ skill = SkillName.Peacemaking; }
				else if ( job == 40 ){ skill = SkillName.Poisoning; }
				else if ( job == 41 ){ skill = SkillName.Provocation; }
				else if ( job == 42 ){ skill = SkillName.RemoveTrap; }
				else if ( job == 43 ){ skill = SkillName.Snooping; }
				else if ( job == 44 ){ skill = SkillName.Spiritualism; }
				else if ( job == 45 ){ skill = SkillName.Stealing; }
				else if ( job == 46 ){ skill = SkillName.Stealth; }
				else if ( job == 47 ){ skill = SkillName.Swords; }
				else if ( job == 48 ){ skill = SkillName.Tactics; }
				else if ( job == 49 ){ skill = SkillName.Tailoring; }
				else if ( job == 50 ){ skill = SkillName.Tasting; }
				else if ( job == 51 ){ skill = SkillName.Tinkering; }
				else if ( job == 52 ){ skill = SkillName.Tracking; }
				else if ( job == 53 ){ skill = SkillName.Veterinary; }
				else if ( job == 54 ){ skill = SkillName.FistFighting; }
				else if ( job == 55 ){ return (int)((from.Skills[SkillName.Druidism].Value + from.Skills[SkillName.Veterinary].Value)/2); }
				else if ( job == 56 ){ return (int)((from.Skills[SkillName.Forensics].Value + from.Skills[SkillName.Necromancy].Value)/2); }

				return (int)(from.Skills[skill].Value);
			}

			return 0;
		}
	}

    public class ExplainShopped : Gump
    {
        private Mobile m_From;
        private Mobile m_Merchant;

        public ExplainShopped( Mobile from, Mobile merchant ): base( 50, 50 )
        {
            m_From = from;
            m_Merchant = merchant;
			from.SendSound( 0x4A ); 
			string color = "#b7765d";

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddHtml( 11, 11, 200, 20, @"<BODY><BASEFONT Color=" + color + ">SETTING UP SHOPPE</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 13, 44, 582, 437, @"<BODY><BASEFONT Color=" + color + ">So you want to setup a Shoppe of your own. In order to do that, you would need your own home built somewhere in the land. These Shoppes usually demand you to part with 10,000 gold, but they can quickly pay for themselves if you are good at your craft. You may only have one type of this Shoppe at any given time. You will be the only one to use the Shoppe, but you may give permission to others to transfer the gold out into a bank check for themselves. Shoppes require to be stocked with tools and resources, and the Shoppe will indicate what those are. Simply drop such things onto your Shoppe to amass an inventory. When you drop tools onto your Shoppe, the number of tool uses will add to the Shoppe's tool count. A Shoppe may only hold 1,000 tools and 5,000 resources. These will get used up as you perform tasks for others. After a set period of time, customers will make requests of you which you can fulfill or refuse. Each request will display the task, who it is for, the amount of tools needed, the amount of resources required, your chance to fulfill the request (based on the difficulty and your skill), and the amount of reputation your Shoppe will acquire if you are successful.<br><br>If you fail to perform a selected task, or refuse to do it, your Shoppe's reputation will drop by that same value you would have been rewarded with. Word of mouth travels fast in the land and you will have less prestigious work if your reputation is low. If you find yourself reaching the lows of becoming a murderer, your Shoppe will be useless as no one deals with murderers. Any gold earned will stay within the Shoppe until you single click the Shoppe and Transfer the funds out of it. Your Shoppe can have no more than 500,000 gold at a time, and you will not be able to conduct any more business in it until you withdraw the funds so it can amass more. The reputation for the Shoppe cannot go below 0, and it cannot go higher than 10,000. Again, the higher the reputation, the more lucrative work you will be asked to do. If you are a member of the associated crafting guild, your reputation will have a bonus toward it based on your crafting skill. If you have enough gold in your pack, do you want me to build a Shoppe for you?</BASEFONT></BODY>", (bool)false, (bool)true);
			AddButton(568, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddButton(9, 498, 4023, 4023, 1, GumpButtonType.Reply, 0);
			AddButton(568, 498, 4020, 4020, 0, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			if ( info.ButtonID > 0 )
			{
				Server.Items.BaseShoppe.GiveNewShoppe( m_From, m_Merchant );
			}
		}
	}

    public class ShoppeGump : Gump
    {
        private BaseShoppe m_Shop;
        private Mobile m_From;

        public ShoppeGump( BaseShoppe shoppe, Mobile from ): base( 50, 50 )
        {
            m_Shop = shoppe;
            m_From = from;
			string color = "#b7765d";
			string hilit = "#cfcc82";

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7028, Server.Misc.PlayerSettings.GetGumpHue( from ));

			int i = -24;
			int o = 85;

			if ( shoppe.ShoppePage == 3 )
			{
				string mercrate = "<br><br>If you want to earn more gold from your home, see the local provisioner and see if you can buy a merchant crate. These crates allow you to craft items, place them in the crate, and the Merchants Guild will pick up your wares after a set period of time. If you decide you want something back from the crate, make sure to take it out before the guild shows up.";

				if ( !MySettings.S_MerchantCrates )
					mercrate = "";

				AddHtml( 11, 11, 532, 20, @"<BODY><BASEFONT Color=" + color + ">ABOUT SHOPPES</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 13, 44, 879, 360, @"<BODY><BASEFONT Color=" + color + ">The world is filled with opportunity, where adventurers seek the help of other in order to achieve their goals. With filled coin purses, they seek experts in various crafts to acquire their skills. Some would need armor repaired, maps deciphered, potions concocted, scrolls translated, clothing fixed, or many other things. The merchants, in the cities and villages, often cannot keep up with the demand of these requests. This provides opportunity for those that practice a trade and have their own home from which to conduct business. Seek out a tradesman and see if they have an option for you to have them build you a Shoppe of your own. These Shoppes usually demand you to part with 10,000 gold, but they can quickly pay for themselves if you are good at your craft. You may only have one type of each Shoppe at any given time. So if you are skilled in two different types of crafts, then you can have a Shoppe for each. You will be the only one to use the Shoppe, but you may give permission to others to transfer the gold out into a bank check for themselves. Shoppes require to be stocked with tools and resources, and the Shoppe will indicate what those are at the bottom. Simply drop such things onto your Shoppe to amass an inventory. When you drop tools onto your Shoppe, the number of tool uses will add to the Shoppe's tool count. A Shoppe may only hold 1,000 tools and 5,000 resources. After a set period of time, customers will make requests of you which you can fulfill or refuse. Each request will display the task, who it is for, the amount of tools needed, the amount of resources required, your chance to fulfill the request (based on the difficulty and your skill), and the amount of reputation your Shoppe will acquire if you are successful.<br><br>If you fail to perform a selected task, or refuse to do it, your Shoppe's reputation will drop by that same value you would have been rewarded with. Word of mouth travels fast in the land and you will have less prestigious work if your reputation is low. If you find yourself reaching the lows of becoming a murderer, your Shoppe will be useless as no one deals with murderers. Any gold earned will stay within the Shoppe until you single click the Shoppe and Transfer the funds out of it. Your Shoppe can have no more than 500,000 gold at a time, and you will not be able to conduct any more business in it until you withdraw the funds so it can amass more. The reputation for the Shoppe cannot go below 0, and it cannot go higher than 10,000. Again, the higher the reputation, the more lucrative work you will be asked to do. If you are a member of the associated crafting guild, your reputation will have a bonus toward it based on your crafting skill." + mercrate + "</BASEFONT></BODY>", (bool)false, (bool)true);
				AddButton(864, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

				AddItem(102+i, 346+o, 3823);
				AddItem(113+i, 493+o, 10283);
				AddItem(114+i, 378+o, 10174);
				AddItem(102+i, 436+o, 4030);
				AddItem(102+i, 468+o, 10922);
				AddItem(94+i, 403+o, 3710);

				AddHtml( 153+i, 348+o, 717, 20, @"<BODY><BASEFONT Color=" + color + ">Shows your shoppe's gold at the top, or for each individual contract.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 378+o, 717, 20, @"<BODY><BASEFONT Color=" + hilit + ">Shows your shoppe's tool count at the top, or tools needed for each individual contract.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 408+o, 717, 20, @"<BODY><BASEFONT Color=" + color + ">Shows your shoppe's resource count at the top, or resources needed for each individual contract.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 438+o, 717, 20, @"<BODY><BASEFONT Color=" + hilit + ">Shows your reputation bonus if you are a member of the associated guild.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 468+o, 717, 20, @"<BODY><BASEFONT Color=" + color + ">Shows your chance to successfully fulfill a contract.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 498+o, 717, 20, @"<BODY><BASEFONT Color=" + hilit + ">Shows your shoppe's reputation at the top, or for each individual contract.</BASEFONT></BODY>", (bool)false, (bool)false);

				AddImage(108+i, 538+o, 4023);
				AddImage(108+i, 594+o, 4020);
				AddHtml( 153+i, 536+o, 717, 40, @"<BODY><BASEFONT Color=" + color + ">This will attempt to fulfill the contract. If you fail, you will lose materials and reputation. If you succeed, you will gain reputation and gold, as well as using up the appropriate materials.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 153+i, 595+o, 717, 20, @"<BODY><BASEFONT Color=" + hilit + ">This will refuse the request, but you will take a reduction in your shoppe's reputation by doing so.</BASEFONT></BODY>", (bool)false, (bool)false);
			}
			else
			{

				AddHtml( 11, 11, 532, 20, @"<BODY><BASEFONT Color=" + color + ">" + shoppe.ShelfTitle + "</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(843, 9, 3610, 3610, 3, GumpButtonType.Reply, 0);

				// ------------------------------------------------------------------------------------

				if ( shoppe.ShoppePage == 1 )
				{
					AddButton(735, 9, 4014, 4014, 1, GumpButtonType.Reply, 0); // LEFT ARROW
				}
				else
				{
					AddButton(783, 9, 4005, 4005, 2, GumpButtonType.Reply, 0); // RIGHT ARROW
				}

				// ------------------------------------------------------------------------------------

				i = -21;
				o = -36;

				AddItem(93+o, 99+i, 3823);
				AddHtml( 132+o, 100+i, 113, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + shoppe.ShoppeGold + "</BASEFONT></BODY>", (bool)false, (bool)false); // TOTAL GOLD

				AddItem(328+o, 99+i, 10174);
				AddHtml( 358+o, 100+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + shoppe.ShoppeTools + "</BASEFONT></BODY>", (bool)false, (bool)false); // TOTAL TOOLS

				AddItem(476+o, 96+i, 3710);
				AddHtml( 521+o, 100+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + shoppe.ShoppeResources + "</BASEFONT></BODY>", (bool)false, (bool)false); // TOTAL RESOURCES

				int guildBonus = 0;
				if ( ((PlayerMobile)from).NpcGuild == shoppe.ShelfGuild ){ guildBonus = 500 + (int)(Server.Items.BaseShoppe.GetSkillValue( shoppe.ShelfSkill, from ) * 5 ); }
				AddItem(631+o, 97+i, 10922);
				AddHtml( 682+o, 100+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + guildBonus + "</BASEFONT></BODY>", (bool)false, (bool)false); // GUILD BONUS 

				AddItem(808+o, 97+i, 10283);
				AddHtml( 833+o, 100+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + shoppe.ShoppeReputation + "</BASEFONT></BODY>", (bool)false, (bool)false); // TOTAL REPUTATION

				// ------------------------------------------------------------------------------------

				AddHtml( 261+o, 636+i, 123, 20, @"<BODY><BASEFONT Color=" + color + ">Shoppe Owner:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 393+o, 635+i, 485, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + shoppe.ShoppeName + "</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(334+o, 667+i, 10174);
				AddHtml( 364+o, 667+i, 209, 20, @"<BODY><BASEFONT Color=" + color + ">" + shoppe.ShelfTools + "</BASEFONT></BODY>", (bool)false, (bool)false); // NEEDED TOOLS

				AddItem(597+o, 664+i, 3710);
				AddHtml( 640+o, 669+i, 209, 20, @"<BODY><BASEFONT Color=" + color + ">" + shoppe.ShelfResources + "</BASEFONT></BODY>", (bool)false, (bool)false); // NEEDED RESOURCES

				// ------------------------------------------------------------------------------------

				int entries = 6;
				int line = 0; if ( shoppe.ShoppePage == 1 ){ line = 6; }
				string customer = shoppe.Customer01;

				string taskJob = "";
				string taskWho = "";
				int taskStatus = 0;
				int taskGold = 0;
				int taskTools = 0;
				int taskResources = 0;
				int taskDifficulty = 0;
				int taskReputation = 0;
				int y = 175;

				while ( entries > 0 )
				{
					entries--;
					line++;

					int no = 100 + line;
					int yes = 200 + line;

					if ( line == 1 ){ customer = shoppe.Customer01; }					else if ( line == 2 ){ customer = shoppe.Customer02; }
					else if ( line == 3 ){ customer = shoppe.Customer03; }				else if ( line == 4 ){ customer = shoppe.Customer04; }
					else if ( line == 5 ){ customer = shoppe.Customer05; }				else if ( line == 6 ){ customer = shoppe.Customer06; }
					else if ( line == 7 ){ customer = shoppe.Customer07; }				else if ( line == 8 ){ customer = shoppe.Customer08; }
					else if ( line == 9 ){ customer = shoppe.Customer09; }				else if ( line == 10 ){ customer = shoppe.Customer10; }
					else if ( line == 11 ){ customer = shoppe.Customer11; }				else if ( line == 12 ){ customer = shoppe.Customer12; }

					taskJob = Server.Misc.Customers.GetDataElement( customer, 1 );
					taskWho = Server.Misc.Customers.GetDataElement( customer, 2 );
					taskStatus = Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 3 ) );
					taskGold = Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 4 ) );
					taskTools = Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 5 ) );
					taskResources = Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 6 ) );
					taskDifficulty = Server.Misc.Customers.GetChance( Server.Items.BaseShoppe.GetSkillValue( shoppe.ShelfSkill, from ), Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 7 ) ) );
					taskReputation = Convert.ToInt32( Server.Misc.Customers.GetDataElement( customer, 8 ) );

					if ( customer != "" )
					{
						if ( taskDifficulty > 0 && shoppe.ShoppeTools >= taskTools && shoppe.ShoppeResources >= taskResources && ( shoppe.ShoppeGold + taskGold ) < 500001 )
						{
							AddButton(105+o, y+i, 4005, 4005, yes, GumpButtonType.Reply, 0); // WILL FIX IT
						}

						AddHtml( 104+o, y-30+i, 780, 20, @"<BODY><BASEFONT Color=" + color + ">" + taskJob + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 146+o, y+i, 319, 20, @"<BODY><BASEFONT Color=" + hilit + ">for " + taskWho + "</BASEFONT></BODY>", (bool)false, (bool)false);

						AddButton(854+o, y+i, 4020, 4020, no, GumpButtonType.Reply, 0); // WILL NOT FIX IT

						AddItem(462+o, y-1+i, 3823);
						AddHtml( 501+o, y+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + taskGold + "</BASEFONT></BODY>", (bool)false, (bool)false); // PAYMENT

						AddItem(561+o, y+i, 10174);
						AddHtml( 587+o, y+i, 30, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + taskTools + "</BASEFONT></BODY>", (bool)false, (bool)false); // RESOURCES NEEDED

						AddItem(614+o, y-3+i, 3710);
						AddHtml( 659+o, y+i, 30, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + taskResources + "</BASEFONT></BODY>", (bool)false, (bool)false); // RESOURCES NEEDED

						AddItem(691+o, y-2+i, 4030);
						AddHtml( 733+o, y+i, 48, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + taskDifficulty + "%</BASEFONT></BODY>", (bool)false, (bool)false); // CHANCE TO SUCCEED

						AddItem(786+o, y-5+i, 10283);
						AddHtml( 811+o, y+i, 30, 20, @"<BODY><BASEFONT Color=" + hilit + ">" + taskReputation + "</BASEFONT></BODY>", (bool)false, (bool)false); // REPUTATION GAINED
					}
					else
					{
						AddHtml( 104+o, y-30+i, 780, 20, @"<BODY><BASEFONT Color=#284F9F>Done - Awaiting Next Customer</BASEFONT></BODY>", (bool)false, (bool)false);
					}

					// ------------------------------------------------------------------------------------

					y=y+80;
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			from.SendSound( 0x4A );

			if ( info.ButtonID == 1 )
			{
				m_Shop.ShoppePage = 0;
				from.SendGump( new ShoppeGump( m_Shop, m_From ) );
			}
			else if ( info.ButtonID == 2 )
			{
				m_Shop.ShoppePage = 1;
				from.SendGump( new ShoppeGump( m_Shop, m_From ) );
			}
			else if ( info.ButtonID == 3 )
			{
				m_Shop.ShoppePage = 3;
				from.SendGump( new ShoppeGump( m_Shop, m_From ) );
			}
			else if ( m_Shop.ShoppePage == 3 )
			{
				m_Shop.ShoppePage = 0;
				from.SendGump( new ShoppeGump( m_Shop, m_From ) );
			}
            else if (info.ButtonID > 200)
            {
                int customerId = info.ButtonID - 200;
                bool isValid = true;

                switch (customerId)
                {
                    case 1:
                        if (m_Shop.Customer01 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 2:
                        if (m_Shop.Customer02 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 3:
                        if (m_Shop.Customer03 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 4:
                        if (m_Shop.Customer04 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 5:
                        if (m_Shop.Customer05 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 6:
                        if (m_Shop.Customer06 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 7:
                        if (m_Shop.Customer07 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 8:
                        if (m_Shop.Customer08 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 9:
                        if (m_Shop.Customer09 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 10:
                        if (m_Shop.Customer10 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 11:
                        if (m_Shop.Customer11 == "")
                        {
                            isValid = false;
                        }
                        break;
                    case 12:
                        if (m_Shop.Customer12 == "")
                        {
                            isValid = false;
                        }
                        break;

                }

                if (isValid)
                {
                    Server.Misc.Customers.FillOrder(m_From, m_Shop, customerId);
                    from.SendGump(new ShoppeGump(m_Shop, m_From));
                }
			}
			else if ( info.ButtonID > 100 )
			{
				Server.Misc.Customers.CancelOrder( m_From, m_Shop, (info.ButtonID-100) );
				from.SendGump( new ShoppeGump( m_Shop, m_From ) );
			}
		}
	}
}