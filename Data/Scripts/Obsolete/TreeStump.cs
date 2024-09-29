using System;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	public class TreeStump : BaseAddon
	{
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		private int m_Logs;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Logs
		{
			get{ return m_Logs; }
			set{ m_Logs = value; InvalidateProperties(); }
		}

		private Timer m_Timer;

		[Constructable]
		public TreeStump( int itemID ) : base()
		{
			AddComponent( new AddonComponent( itemID ), 0, 0, 0 );

			m_Timer = Timer.DelayCall( TimeSpan.FromDays( 1 ), TimeSpan.FromDays( 1 ), new TimerCallback( GiveLogs ) );
		}

		public TreeStump( Serial serial ) : base( serial )
		{
		}

		private void GiveLogs()
		{
			m_Logs = Math.Min( 100, m_Logs + 10 );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( (bool) m_IsRewardItem );
			writer.Write( (int) m_Logs );

			if ( m_Timer != null )
				writer.Write( (DateTime) m_Timer.Next );
			else
				writer.Write( (DateTime) DateTime.Now + TimeSpan.FromDays( 1 ) );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_IsRewardItem = reader.ReadBool();
			m_Logs = reader.ReadInt();

			DateTime next = reader.ReadDateTime();

			this.Delete();
		}
	}

	public class TreeStumpDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				TreeStump addon = new TreeStump( m_ItemID );
				addon.IsRewardItem = m_IsRewardItem;
				addon.Logs = m_Logs;

				return addon;
			}
		}
		private int m_ItemID;
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		private int m_Logs;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Logs
		{
			get{ return m_Logs; }
			set{ m_Logs = value; InvalidateProperties(); }
		}

		[Constructable]
		public TreeStumpDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public TreeStumpDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( (bool) m_IsRewardItem );
			writer.Write( (int) m_Logs );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_IsRewardItem = reader.ReadBool();
			m_Logs = reader.ReadInt();
			this.Delete();
		}
	}
}