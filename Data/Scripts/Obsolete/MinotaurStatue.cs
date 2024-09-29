using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public enum MinotaurStatueType
	{
		AttackSouth		= 100,
		AttackEast		= 101,
		DefendSouth		= 102,
		DefendEast		= 103
	}

	public class MinotaurStatue : BaseAddon
	{
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		[Constructable]
		public MinotaurStatue( MinotaurStatueType type ) : base()
		{
			switch ( type )
			{
				case MinotaurStatueType.AttackSouth:
					AddComponent( new AddonComponent( 0x306C ), 0, 0, 0 );
					AddComponent( new AddonComponent( 0x306D ), -1, 0, 0 );
					AddComponent( new AddonComponent( 0x306E ), 0, -1, 0 );
					break;
				case MinotaurStatueType.AttackEast:
					AddComponent( new AddonComponent( 0x3074 ), 0, 0, 0 );
					AddComponent( new AddonComponent( 0x3075 ), -1, 0, 0 );
					AddComponent( new AddonComponent( 0x3076 ), 0, -1, 0 );
					break;
				case MinotaurStatueType.DefendSouth:
					AddComponent( new AddonComponent( 0x3072 ), 0, 0, 0 );
					AddComponent( new AddonComponent( 0x3073 ), 0, -1, 0 );
					break;
				case MinotaurStatueType.DefendEast:
					AddComponent( new AddonComponent( 0x306F ), 0, 0, 0 );
					AddComponent( new AddonComponent( 0x3070 ), -1, 0, 0 );
					AddComponent( new AddonComponent( 0x3071 ), 0, -1, 0 );
					break;
			}
		}

		public MinotaurStatue( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
			
			writer.Write( (bool) m_IsRewardItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
			
			m_IsRewardItem = reader.ReadBool();
			this.Delete();
		}
	}	
	
	public class MinotaurStatueDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{ 
			get
			{ 
				MinotaurStatue addon = new MinotaurStatue( m_StatueType );
				addon.IsRewardItem = m_IsRewardItem;

				return addon; 
			} 
		}
		private MinotaurStatueType m_StatueType;
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		[Constructable]
		public MinotaurStatueDeed() : base()
		{
		}

		public MinotaurStatueDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( (bool) m_IsRewardItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
			
			m_IsRewardItem = reader.ReadBool();
			this.Delete();
		}
	}
}
