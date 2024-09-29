using System;

namespace Server.Items
{
    public abstract class BaseGiftRing : BaseGiftJewel
	{
		public BaseGiftRing( int itemID ) : base( itemID, Layer.Ring )
		{
		}

		public BaseGiftRing( Serial serial ) : base( serial )
		{
			ItemID = 0x6731;
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

			if ( ItemID == 0x4CFA )
				ItemID = GraphicID = 0x6731;
		}
	}

	public class GiftGoldRing : BaseGiftRing
	{
		[Constructable]
		public GiftGoldRing() : base( 0x6731 )
		{
			Name = "ring";
			Weight = 0.1;
		}

        public GiftGoldRing(Serial serial)
            : base(serial)
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

	public class GiftSilverRing : BaseGiftRing
	{
		[Constructable]
		public GiftSilverRing() : base( 0x6731 )
		{
			Name = "ring";
			Weight = 0.1;
		}

        public GiftSilverRing(Serial serial)
            : base(serial)
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
