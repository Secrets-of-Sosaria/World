using System;

namespace Server.Items
{
	public class GiftOniwabanTunic : GiftLeatherChest
	{
		[Constructable]
		public GiftOniwabanTunic()
		{
			ItemID = 0x64BD;
			Name = "oniwaban tunic";
		}

		public GiftOniwabanTunic( Serial serial ) : base( serial )
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