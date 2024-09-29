using System;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x658B,0x658C )] 
	public class DruidMirror : Item
	{
		[Constructable]
		public DruidMirror() : base( 0x658B )
		{
			Name = "druid mirror";
			Weight = 10.0;
		}

		public DruidMirror( Serial serial ) : base( serial )
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