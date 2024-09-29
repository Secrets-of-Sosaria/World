using System;

namespace Server.Items
{
	public class JewelryBracelet : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Jewelry; } }

		[Constructable]
		public JewelryBracelet() : base( 0x672D ) 
		{
			Name = "bracelet";
			Weight = 0.1;
			Layer = Layer.Bracelet;
			WorldItemID = 7942;
		}

		public JewelryBracelet( Serial serial ) : base( serial )
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
