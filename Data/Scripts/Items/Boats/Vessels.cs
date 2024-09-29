using System;
using Server.Misc;

namespace Server.Items
{
	public class VesselsNS : BaseMulti
	{
		[Constructable]
		public VesselsNS() : base( 0x18 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x18, 0x1A, 0x24, 0x26, 0x30, 0x32, 0x40, 0x42 );
			if ( ItemID < 0x24 ){ Hue = 0xABE; }
			else if ( ItemID < 0x30 ){ Hue = 0xAC0; }
			else if ( ItemID < 0x40 ){ Hue = 0xABE; }
			else { Hue = 0xABF; }
		}

		public VesselsNS( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class VesselsEW : BaseMulti
	{
		[Constructable]
		public VesselsEW() : base( 0x19 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x19, 0x1B, 0x25, 0x27, 0x31, 0x33, 0x41, 0x43 );
			if ( ItemID < 0x24 ){ Hue = 0xABE; }
			else if ( ItemID < 0x30 ){ Hue = 0xAC0; }
			else if ( ItemID < 0x40 ){ Hue = 0xABE; }
			else { Hue = 0xABF; }
		}

		public VesselsEW( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class ShipNS : BaseMulti
	{
		[Constructable]
		public ShipNS() : base( 0x0 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x0, 0x2, 0x4, 0x6, 0x8, 0xA, 0xC, 0xE, 0x10, 0x12, 0x14, 0x16 )+163;
			Hue = Utility.RandomList( 0x509, 0x50A, 0x50B, 0x50E, 0x508, 0x50F, 0x510, 0x512, 0x50D, 0x513, 0x514, 0x511, 0x507, 0x50C, 0xABE, 0xB61, 0xABE, 0xB61, 0xABE, 0xB61, 0x5BE, 0x5BE );
		}

		public ShipNS( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class ShipEW : BaseMulti
	{
		[Constructable]
		public ShipEW() : base( 0x1 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x1, 0x3, 0x5, 0x7, 0x9, 0xB, 0xD, 0xF, 0x11, 0x13, 0x15, 0x17 )+163;
			Hue = Utility.RandomList( 0x509, 0x50A, 0x50B, 0x50E, 0x508, 0x50F, 0x510, 0x512, 0x50D, 0x513, 0x514, 0x511, 0x507, 0x50C, 0xABE, 0xB61, 0xABE, 0xB61, 0xABE, 0xB61, 0x5BE, 0x5BE );
		}

		public ShipEW( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class WreckNS : BaseMulti
	{
		[Constructable]
		public WreckNS() : base( 0x18 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x20, 0x22, 0x2C, 0x2E, 0x38, 0x3A );
			Hue = Utility.RandomList( 0xB79, 0xB51, 0xB19, 0xACF, 0xABB, 0xABC, 0x8C8 );
		}

		public WreckNS( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class WreckEW : BaseMulti
	{
		[Constructable]
		public WreckEW() : base( 0x19 )
		{
			Movable = false;
			ItemID = Utility.RandomList( 0x21, 0x23, 0x2D, 0x2F, 0x39, 0x3B );
			Hue = Utility.RandomList( 0xB79, 0xB51, 0xB19, 0xACF, 0xABB, 0xABC, 0x8C8 );
		}

		public WreckEW( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}