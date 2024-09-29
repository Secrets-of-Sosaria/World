using System;

namespace Server.Items
{
	public class LapHarp : BaseInstrument
	{
		[Constructable]
		public LapHarp() : base( 0x66F4, 0x45, 0x46 )
		{
			Name = "harp";
			Weight = 10.0;
		}

		public LapHarp( Serial serial ) : base( serial )
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
			ItemID = 0x66F4;
		}
	}
}