using System;
using Server.Targeting;
using Server.Network;
using Server.Regions;
using Server.Items;
using Server.Mobiles;
using Server.Multis;

namespace Server.Items
{
	public interface ICommodity /* added IsDeedable prop so expansion-based deedables can determine true/false */
	{
		int DescriptionNumber{ get; }
		bool IsDeedable { get; }
	}

	public class CommodityDeed : Item
	{
		private Item m_Commodity;

		[CommandProperty( AccessLevel.GameMaster )]
		public Item Commodity
		{
			get
			{
				return m_Commodity;
			}
		}

		public bool SetCommodity( Item item )
		{
			InvalidateProperties();

			if ( m_Commodity == null )
			{
				m_Commodity = item;
				m_Commodity.Internalize();
				InvalidateProperties();

				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
			writer.Write( m_Commodity );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Commodity = reader.ReadItem();

			switch ( version )
			{
				case 0:
				{
					if (m_Commodity != null)
					{
						Hue = 0x592;
					}
					break;
				}
			}

			if ( m_Commodity == null )
				this.Delete();
			else
				Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			CommodityDeed item = (CommodityDeed)((Item)state);
			Item deed = item.Commodity;

			DoCleanup( (Item)state, deed );
		}

		public static void DoCleanup( Item oldItem, Item newItem )
		{
			Mobile p = null;

			if ( oldItem.Parent is Container )
			{
				(((Container)oldItem.Parent)).DropItem( newItem );
			}
			else if ( oldItem.Parent == null && Region.Find( oldItem.Location, oldItem.Map ) is HouseRegion )
			{
				BaseHouse house = ((HouseRegion)(Region.Find( oldItem.Location, oldItem.Map ))).Home;
				Mobile owner = house.Owner;

				if ( owner != null && owner.BankBox != null )
					(owner.BankBox).DropItem( newItem );
				else
					newItem.Delete();
			}
			else
			{
				newItem.Delete();
			}

			oldItem.Delete();
		}

		public CommodityDeed( Item commodity ) : base( 0x14F0 )
		{
			Weight = 1.0;
			Hue = 0x47;

			m_Commodity = commodity;

			LootType = LootType.Blessed;
		}

		[Constructable]
		public CommodityDeed() : this( null )
		{
		}

		public CommodityDeed( Serial serial ) : base( serial )
		{
		}

		public override int LabelNumber{ get{ return m_Commodity == null ? 1047016 : 1047017; } }

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if (m_Commodity != null && m_Commodity is ICommodity)
			{
				list.Add(1060658, "#{0}\t{1}", ((ICommodity)m_Commodity).DescriptionNumber, m_Commodity.Amount); // ~1_val~: ~2_val~
			}
			else
				list.Add(1060748); // unfilled
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( m_Commodity != null && m_Commodity is ICommodity )

				from.Send(new MessageLocalizedAffix(
										Serial,
										ItemID,
										MessageType.Label,
										0x3B2,
										3,
										(m_Commodity.Name == null) ? ((ICommodity)m_Commodity).DescriptionNumber : 0,
										(m_Commodity.Name != null) ? m_Commodity.Name : null,
										AffixType.Append,
										String.Format(": {0}", m_Commodity.Amount),
										null)
										);
		}

		public override void OnDoubleClick( Mobile from )
		{
			int number;

			BankBox box = from.FindBankNoCreate();
			
			if ( m_Commodity != null )
			{
				if ( box != null && IsChildOf( box ) )
				{
					number = 1047031; // The commodity has been redeemed.

					box.DropItem( m_Commodity );

					m_Commodity = null;
					Delete();
				}
				else
				{
					if( Core.ML )
					{
						number = 1080526; // That must be in your bank box or commodity deed box to use it.
					}
					else
					{
						number = 1047024; // To claim the resources ....
					}
				}
			}
			else if ( ( box == null || !IsChildOf( box ) ) )
			{
				if( Core.ML )
				{
					number = 1080526; // That must be in your bank box or commodity deed box to use it.
				}
				else
				{
					number = 1047026; // That must be in your bank box to use it.
				}
			}
			else
			{
				number = 1047029; // Target the commodity to fill this deed with.

				from.Target = new InternalTarget( this );
			}

			from.SendLocalizedMessage( number );
		}

		private class InternalTarget : Target
		{
			private CommodityDeed m_Deed;

			public InternalTarget( CommodityDeed deed ) : base( 3, false, TargetFlags.None )
			{
				m_Deed = deed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Deed.Deleted )
					return;

				int number;

				if ( m_Deed.Commodity != null )
				{
					number = 1047028; // The commodity deed has already been filled.
				}
				else if ( targeted is Item )
				{
					BankBox box = from.FindBankNoCreate();

					if ( box != null && m_Deed.IsChildOf( box ) && ((Item)targeted).IsChildOf( box ) )
					{
						if ( m_Deed.SetCommodity( (Item) targeted ) )
						{
							m_Deed.Hue = 0x592;
							number = 1047030; // The commodity deed has been filled.
						}
						else
						{
							number = 1047027; // That is not a commodity the bankers will fill a commodity deed with.
						}
					}
					else
					{
						if( Core.ML )
						{
							number = 1080526; // That must be in your bank box or commodity deed box to use it.
						}
						else
						{
							number = 1047026; // That must be in your bank box to use it.
						}
					}
				}
				else
				{
					number = 1047027; // That is not a commodity the bankers will fill a commodity deed with.
				}

				from.SendLocalizedMessage( number );
			}
		}
	}
}