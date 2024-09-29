using System;

namespace Server.Items
{
	public class Tambourine : BaseInstrument
	{
		[Constructable]
		public Tambourine() : base( 0x66F5, 0x52, 0x53 )
		{
			Name = "tambourine";
			Weight = 1.0;
		}

		public Tambourine( Serial serial ) : base( serial )
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
			ItemID = 0x66F5;
		}
	}
}