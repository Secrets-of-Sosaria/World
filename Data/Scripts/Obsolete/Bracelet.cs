using System;

namespace Server.Items
{
	public abstract class BaseBracelet : BaseTrinket
	{
		public override int BaseGemTypeNumber{ get{ return 1044221; } } // star sapphire bracelet

		public BaseBracelet( int itemID ) : base( itemID, Layer.Bracelet )
		{
		}

		public BaseBracelet( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 30.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new JewelryBracelet();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class GoldBracelet : BaseBracelet
	{
		[Constructable]
		public GoldBracelet() : base( 0x4CF1 ) 
		{
			Name = "bracelet";
			Weight = 0.1;
		}

		public GoldBracelet( Serial serial ) : base( serial )
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

	public class SilverBracelet : BaseBracelet
	{
		[Constructable]
		public SilverBracelet() : base( 0x4CF2 ) 
		{
			Name = "bracelet";
			Weight = 0.1;
		}

		public SilverBracelet( Serial serial ) : base( serial )
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
