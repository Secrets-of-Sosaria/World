using System;

namespace Server.Items
{
	public class Trumpet : BaseInstrument
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		[Constructable]
		public Trumpet() : base( 0x6458, 0x3CE, 0x3CD )
		{
			Name = "trumpet";
			Weight = 5.0;
			ItemID = Utility.RandomList( 0x6458, 0x6459 );
		}

		public Trumpet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}