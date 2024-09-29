using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Whips : BaseWhip
	{
		[Constructable]
		public Whips() : base( 0x6453 )
		{
		}

		public Whips( Serial serial ) : base( serial )
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