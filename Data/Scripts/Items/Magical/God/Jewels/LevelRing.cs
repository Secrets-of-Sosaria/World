using System;

namespace Server.Items
{
    public abstract class BaseLevelRing : BaseLevelJewel
	{
		public BaseLevelRing( int itemID ) : base( itemID, Layer.Ring )
		{
		}

		public BaseLevelRing( Serial serial ) : base( serial )
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

			if ( ItemID == 0x4CFA )
				ItemID = GraphicID = 0x6731;
		}
	}

	public class LevelGoldRing : BaseLevelRing
	{
		[Constructable]
		public LevelGoldRing() : base( 0x6731 )
		{
			Name = "ring";
			Weight = 0.1;
		}

        public LevelGoldRing(Serial serial)
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

	public class LevelSilverRing : BaseLevelRing
	{
		[Constructable]
		public LevelSilverRing() : base( 0x6731 )
		{
			Name = "ring";
			Weight = 0.1;
		}

        public LevelSilverRing(Serial serial)
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
