using System;
using Server;

namespace Server.Items
{
	public class PearTreeAddon : BaseFruitTreeAddon
	{
		public override BaseAddonDeed Deed { get { return new PearTreeDeed(); } }
		public override Item Fruit { get { return new Pear(); } }

		[Constructable]
		public PearTreeAddon() : base()
		{
			AddComponent( new LocalizedAddonComponent( 0xDA4, 1023492 ), 0, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xDA6, 1023492 ), 0, 0, 0 );
		}

		public PearTreeAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class PearTreeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new PearTreeAddon(); } }
		public override int LabelNumber { get { return 1023492; } } // Apple Tree

		[Constructable]
		public PearTreeDeed() : base()
		{
		}

		public PearTreeDeed( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "Grows Fruit" );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
