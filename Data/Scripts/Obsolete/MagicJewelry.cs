using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MagicJewelryRing : GoldRing
	{
		[Constructable]
		public MagicJewelryRing()
		{
			ItemID = Utility.RandomList( 0x4CF3, 0x4CF4, 0x4CF5, 0x4CF6, 0x4CF7, 0x4CF8, 0x4CF9, 0x4CFA );
			Resource = CraftResource.None;
			Name = "ring";
		}

		public MagicJewelryRing( Serial serial ) : base( serial )
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
	public class MagicJewelryNecklace : GoldNecklace
	{
		[Constructable]
		public MagicJewelryNecklace()
		{
			Resource = CraftResource.None;

			if ( Hue == 0 )
			{
				ItemID = Utility.RandomList( 0x4CFE, 0x4CFD, 0x4CFF, 0x4D00, 0x5650 );

				Name = "necklace";
					if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ Name = "amulet"; }

					if ( ItemID == 0x4CFE || ItemID == 0x4CFD )
					{
						Name = "beads";
					}
			}
		}

		public MagicJewelryNecklace( Serial serial ) : base( serial )
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
	public class MagicJewelryEarrings : GoldEarrings
	{
		[Constructable]
		public MagicJewelryEarrings()
		{
			Resource = CraftResource.None;
			Name = "earrings";

			ItemID = Utility.RandomList( 0x4CFB, 0x4CFC );
		}

		public MagicJewelryEarrings( Serial serial ) : base( serial )
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
	public class MagicJewelryBracelet : GoldBracelet
	{
		[Constructable]
		public MagicJewelryBracelet()
		{
			Resource = CraftResource.None;
			Name = "bracelet";

			ItemID = Utility.RandomList( 0x4CEB, 0x4CEC, 0x4CED, 0x4CEE, 0x4CEF, 0x4CF0, 0x4CF1, 0x4CF2 );
		}

		public MagicJewelryBracelet( Serial serial ) : base( serial )
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
	public class MagicJewelryCirclet : GoldBracelet
	{
		[Constructable]
		public MagicJewelryCirclet()
		{
			ItemID = Utility.RandomList( 0x2B6F, 0x3166 );
			Layer = Layer.Helm;
			Resource = CraftResource.None;
			Name = "circlet";
		}

		public MagicJewelryCirclet( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new JewelryCirclet();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}