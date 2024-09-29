using System;

namespace Server.Items
{
	public class OniwabanBoots : LeatherSoftBoots
	{
		[Constructable]
		public OniwabanBoots()
		{
			Name = "oniwaban boots";
			ItemID = 0x64BA;
		}

		public OniwabanBoots( Serial serial ) : base( serial )
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
