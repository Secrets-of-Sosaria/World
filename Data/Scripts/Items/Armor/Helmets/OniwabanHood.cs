using System;

namespace Server.Items
{
	public class OniwabanHood : LeatherCap
	{
		[Constructable]
		public OniwabanHood()
		{
			ItemID = 0x64BB;
			Name = "oniwaban hood";
		}

		public OniwabanHood( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}