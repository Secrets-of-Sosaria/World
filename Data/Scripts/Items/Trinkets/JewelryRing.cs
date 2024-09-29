using System;

namespace Server.Items
{
	public class JewelryRing : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Jewelry; } }

		[Constructable]
		public JewelryRing() : base( 0x6731 )
		{
			Name = "ring";
			Weight = 0.1;
			Layer = Layer.Ring;
			WorldItemID = 7945;
		}

		public JewelryRing( Serial serial ) : base( serial )
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
