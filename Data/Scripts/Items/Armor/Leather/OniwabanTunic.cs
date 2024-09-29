using System;

namespace Server.Items
{
	public class OniwabanTunic : LeatherChest
	{
		[Constructable]
		public OniwabanTunic()
		{
			ItemID = 0x64BD;
			Name = "oniwaban tunic";
		}

		public OniwabanTunic( Serial serial ) : base( serial )
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