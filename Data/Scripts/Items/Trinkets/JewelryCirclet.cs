using System;

namespace Server.Items
{
	public class JewelryCirclet : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Jewelry; } }

		[Constructable]
		public JewelryCirclet() : base( 0x672E )
		{
			Name = "circlet";
			Weight = 0.1;
			Layer = Layer.Helm;
		}

		public JewelryCirclet( Serial serial ) : base( serial )
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
