using System;

namespace Server.Items
{
	public class MagicHorn : BaseInstrument
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		[Constructable]
		public MagicHorn() : base( 0x645B, 0x3CE, 0x3CD )
		{
			Name = "magic horn";
			Weight = 5.0;
		}

		public MagicHorn( Serial serial ) : base( serial )
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