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
	[Flipable( 0xE3D, 0xE3C )]
	public class MerchantCrate : Container
	{
		public override string DefaultDescription
		{
			get
			{
				if ( !MySettings.S_MerchantCrates )
					return "These crates are commonly used by merchants to store wares.";

				return "Merchant crates are something that craftsmen can secure in their homes and sell the goods they make. Once a day, someone from the Merchants Guild will pick up anything left in the crate. They will leave gold in the crate for the owner's hard work. When you put something in the crate, you will be aware of the gold value of the item placed in it. A craftsmen may only acquire gold from armor, weapons, or clothing that were crafted. Any non-crafted armor, weapons, or clothing will be valued at 0 gold. Crafted armor and weapons will have varying values depending on the resources used to create the item. Also durability and quality may increase the value. Almost anything crafted will have a value to the Merchants Guild. Other items like potions, scrolls, tools, furniture, or food can be sold for a price. Any tools must have at least 50 uses to be of any value. So if an item cannot be crafted, then you probably will not get any gold for it. The exception to this are ingots and logs, as they are highly sought in the land. Different types of ingots are worth more depending on the type.<br><br>The crate will indicate how much gold it has available to transfer to yourself in the form of a bank check. Single click the crate and select the 'Transfer' option to withdraw all of the gold from the crate. Although there is a gold value indicated on the crate, the one withdrawing the amount may get more depending on whether they are in the Merchants Guild and/or they have a good Mercantile skill. These crates must be secured in a home to be of any use.";
			}
		}

		public override bool DisplaysContent{ get{ return false; } }
		public override bool DisplayWeight{ get{ return false; } }

		public override int DefaultMaxWeight{ get{ return 0; } } // A value of 0 signals unlimited weight

		public override bool IsDecoContainer{ get{ return false; } }

		public int CrateGold;

		[CommandProperty(AccessLevel.Owner)]
		public int Crate_Gold{ get { return CrateGold; } set { CrateGold = value; InvalidateProperties(); } }

		[Constructable]
		public MerchantCrate() : base( 0xE3D )
		{
			Name = "merchant crate";
			Hue = 0x83F;
			Weight = 1.0;
		}

		public MerchantCrate( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( CrateGold );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			CrateGold = reader.ReadInt();
			QuickTimer thisTimer = new QuickTimer( this ); 
			thisTimer.Start();
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			if ( !this.Movable && BaseHouse.CheckAccessible( from, this ) && CrateGold > 0 ){ list.Add( new CashOutEntry( from, this ) ); }
		} 

		public class CashOutEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private MerchantCrate m_Crate;
	
			public CashOutEntry( Mobile from, MerchantCrate crate ) : base( 6113, 3 )
			{
				m_Mobile = from;
				m_Crate = crate;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( m_Crate.CrateGold > 0 )
					{
						double barter = (int)( m_Mobile.Skills[SkillName.Mercantile].Value / 2 );

						if ( mobile.NpcGuild == NpcGuild.MerchantsGuild )
							barter = barter + 25.0; // FOR GUILD MEMBERS

						barter = barter / 100;

						int bonus = (int)( m_Crate.CrateGold * barter );

						int cash = m_Crate.CrateGold + bonus;

						m_Mobile.AddToBackpack( new BankCheck( cash ) );
						m_Mobile.SendMessage("You now have a check for " + cash.ToString() + " gold.");
						m_Crate.CrateGold = 0;
						m_Crate.InvalidateProperties();
					}
					else
					{
						m_Mobile.SendMessage("There is no gold in this crate!");
					}
				}
            }
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !MySettings.S_MerchantCrates )
				base.OnDoubleClick( from );

			if ( CrateGold >= 500000 )
			{
                from.SendMessage("There is too much gold in here. You need to transfer it out first.");
			}
            else if ( this.Movable )
			{
                from.SendMessage("This must be locked down in a house to use!");
			}
			else if ( from.AccessLevel > AccessLevel.Player || from.InRange( this.GetWorldLocation(), 2 ) )
			{
				Open( from );
			}
			else
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			}
		}

		public virtual void Open( Mobile from )
		{
			DisplayTo( from );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( MySettings.S_MerchantCrates )
			{
				list.Add( 1049644, "Contains: " + CrateGold.ToString() + " Gold");
				list.Add( 1070722, "For Sale: " + Sale().ToString() + " Gold");
			}
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( !MySettings.S_MerchantCrates )
				return base.OnDragDrop( from, dropped );

			if ( CrateGold >= 500000 )
			{
                from.SendMessage("There is too much gold in here. You need to transfer it out first.");
				return false;
			}
            else if (this.Movable)
			{
                from.SendMessage("This must be locked down in a house to use!");
				return false;
			}
			else if ( from.Kills > 0 )
			{
                from.SendMessage("This is useless since no one deals with murderers!");
				return false;
			}

			if ( !base.OnDragDrop( from, dropped ) )
				return false;

			from.SendMessage( "The item will be picked up in about a day" );
			PublicOverheadMessage (MessageType.Regular, 0x3B2, true, "Worth " + GetItemValue( dropped, dropped.Amount ).ToString() + " gold");

			if ( m_Timer != null )
				m_Timer.Stop();
			else
				m_Timer = new EmptyTimer( this );

			m_Timer.Start();

			return true;
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			if ( !MySettings.S_MerchantCrates )
				return base.OnDragDropInto( from, item, p );

			if ( CrateGold >= 500000 )
			{
                from.SendMessage("There is too much gold in here. You need to transfer it out first.");
				return false;
			}
            else if (this.Movable)
			{
                from.SendMessage("This must be locked down in a house to use!");
				return false;
			}

			if ( !base.OnDragDropInto( from, item, p ) )
				return false;

			from.SendMessage( "The item will be picked up in about a day" );
			PublicOverheadMessage (MessageType.Regular, 0x3B2, true, "Worth " + GetItemValue( item, item.Amount ).ToString() + " gold");

			if ( m_Timer != null )
				m_Timer.Stop();
			else
				m_Timer = new EmptyTimer( this );

			m_Timer.Start();

			return true;
		}

		public void Empty()
		{
            if ( !this.Movable && MySettings.S_MerchantCrates )
			{
				List<Item> items = this.Items;

				if ( items.Count > 0 )
				{
					PublicOverheadMessage (MessageType.Regular, 0x3B2, true, "The items have been picked up");

					for ( int i = items.Count - 1; i >= 0; --i )
					{
						if ( i >= items.Count )
							continue;

						CrateGold = CrateGold + GetItemValue( items[i], items[i].Amount );
						items[i].Delete();
					}
				}
			}

			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;
		}

		public int Sale()
		{
			int gold = 0;

			List<Item> items = this.Items;

			if ( items.Count > 0 )
			{
				for ( int i = items.Count - 1; i >= 0; --i )
				{
					if ( i >= items.Count )
						continue;

					gold = gold + GetItemValue( items[i], items[i].Amount );
				}
			}

			return gold;
		}

		private Timer m_Timer;

		private class EmptyTimer : Timer
		{
			private MerchantCrate m_Crate;

			//public EmptyTimer( MerchantCrate crate ) : base( TimeSpan.FromHours( 2.0 ) )
			public EmptyTimer( MerchantCrate crate ) : base( TimeSpan.FromMinutes( 1.0 ) )
			{
				m_Crate = crate;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Crate.Empty();
			}
		}

		private class QuickTimer : Timer
		{
			private MerchantCrate m_Crate;

			public QuickTimer( MerchantCrate crate ) : base( TimeSpan.FromSeconds( 60.0 ) )
			{
				m_Crate = crate;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Crate.Empty();
			}
		}

		public static int GetItemValue( Item item, int amount )
		{
			if ( !item.Built )
				return 0;

			return ItemInformation.GetBuysPrice( ItemInformation.GetInfo( item.GetType() ), false, item, false, false ) * amount;
		}
	}
}