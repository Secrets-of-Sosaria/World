using System;
using Server;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class EssenceBaseEmpty : Item
	{
		public string ItemType;

		[CommandProperty(AccessLevel.Owner)]
		public string Item_Type { get { return ItemType; } set { ItemType = value; InvalidateProperties(); } }

		private DateTime m_DecayTime;
		private Timer m_DecayTimer;

		public virtual TimeSpan DecayDelay{ get{ return TimeSpan.FromMinutes( (double)(Utility.RandomMinMax( 15, 30 )) ); } }

		[Constructable]
		public EssenceBaseEmpty() : base( 13042 )
		{
			Name = "Pedestal";
			Movable = false;

			RefreshDecay( true );
			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( CheckAddComponents ) );
		}

		public void CheckAddComponents()
		{
			if( Deleted )
				return;
		}

		public void RemovePedestal()
		{
			this.Delete();
		}

		public virtual void RefreshDecay( bool setDecayTime )
		{
			if( Deleted )
				return;
			if( m_DecayTimer != null )
				m_DecayTimer.Stop();
			if( setDecayTime )
				m_DecayTime = DateTime.Now + DecayDelay;

			TimeSpan ts = m_DecayTime - DateTime.Now;

			if ( ts < TimeSpan.FromMinutes( 2.0 ) )
				ts = TimeSpan.FromMinutes( 2.0 );

			m_DecayTimer = Timer.DelayCall( ts, new TimerCallback( RemovePedestal ) );
		}

		public EssenceBaseEmpty( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( m_DecayTime );
            writer.Write( ItemType );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_DecayTime = reader.ReadDateTime();
					RefreshDecay( false );
					break;
				}
			}
            ItemType = reader.ReadString();
		}
	}
}