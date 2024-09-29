using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MerchantWagonSouth : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {0x21A3, -2, -2, 0}, {0x21A3, -2, -1, 0}, {0x21A3, -2, 0, 0}
			, {0x21A3, -2, 1, 0}, {0x21A3, -2, 2, 0}, {0x21A3, -1, -3, 0}
			, {0x21A3, -1, -2, 0}, {0x21A3, -1, -1, 0}, {0x21A3, -1, 0, 0}
			, {0x21A3, -1, 1, 0}, {0x21A3, -1, 2, 0}, {0x21A3, 0, -3, 0}
			, {0x21A3, 0, -2, 0}, {0x21A3, 0, -1, 0}, {0x21A3, 0, 0, 0}
			, {0x21A3, 0, 1, 0}, {0x21A3, 0, 2, 0}, {0x21A3, 1, -3, 0}
			, {0x21A3, 1, -2, 0}, {0x21A3, 1, -1, 0}, {0x21A3, 1, 0, 0}
			, {0x21A3, 1, 1, 0}, {0x21A3, 1, 2, 0}, {26095, 2, 2, 0}
			, {0x21A3, -1, 3, 0}, {0x21A3, 0, 3, 0}, {0x21A3, 1, 3, 0}
			, {0x21A3, 2, -1, 0}, {0x21A3, 2, 0, 0}, {0x21A3, 2, 1, 0}
			, {0x21A3, 2, 2, 0}
		};

		[ Constructable ]
		public MerchantWagonSouth()
		{
            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );
		}

		public MerchantWagonSouth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class MerchantWagonEast : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {26096, 2, 2, 0}, {0x21A3, -3, -1, 0}, {0x21A3, -3, 0, 0}
			, {0x21A3, -3, 1, 0}, {0x21A3, -2, -2, 0}, {0x21A3, -2, -1, 0}
			, {0x21A3, -2, 0, 0}, {0x21A3, -2, 1, 0}, {0x21A3, -1, -2, 0}
			, {0x21A3, -1, -1, 0}, {0x21A3, -1, 0, 0}, {0x21A3, -1, 1, 0}
			, {0x21A3, -1, 2, 0}, {0x21A3, 0, -2, 0}, {0x21A3, 0, -1, 0}
			, {0x21A3, 0, 0, 0}, {0x21A3, 0, 1, 0}, {0x21A3, 0, 2, 0}
			, {0x21A3, 1, -2, 0}, {0x21A3, 1, -1, 0}, {0x21A3, 1, 0, 0}
			, {0x21A3, 1, 1, 0}, {0x21A3, 1, 2, 0}, {0x21A3, 2, -2, 0}
			, {0x21A3, 2, -1, 0}, {0x21A3, 2, 0, 0}, {0x21A3, 2, 1, 0}
			, {0x21A3, 2, 2, 0}, {0x21A3, 3, -1, 0}, {0x21A3, 3, 0, 0}
			, {0x21A3, 3, 1, 0}
		};

		[ Constructable ]
		public MerchantWagonEast()
		{
            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );
		}

		public MerchantWagonEast( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

}