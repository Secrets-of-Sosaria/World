using System;
using Server;

namespace Server.Items
{
	public class BraceletOfBinding : JewelryBracelet
	{
		public override int LabelNumber{ get{ return 1061103; } } // Bracelet of Health

		[Constructable]
		public BraceletOfBinding()
		{
			ItemID = 0x672D;
			Hue = 0x489;
			Weight = 1.0;
			Name = "Bracelet of Protection";
			Resistances.Physical = 20;
		}

		public BraceletOfBinding( Serial serial ) : base( serial )
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
			ItemID = 0x672D;
		}
	}
}