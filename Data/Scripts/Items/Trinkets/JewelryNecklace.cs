using System;

namespace Server.Items
{
	public class JewelryNecklace : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Jewelry; } }

		[Constructable]
		public JewelryNecklace() : base( 0x6730 )
		{
			Weight = 0.1;
			Name = "necklace";
			Layer = Layer.Neck;
			WorldItemID = 7944;
		}

		public JewelryNecklace( Serial serial ) : base( serial )
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