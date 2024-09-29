using System;

namespace Server.Items
{
	public abstract class BaseEarrings : BaseTrinket
	{
		public override int BaseGemTypeNumber{ get{ return 1044203; } } // star sapphire earrings

		public BaseEarrings( int itemID ) : base( itemID, Layer.Earrings )
		{
		}

		public BaseEarrings( Serial serial ) : base( serial )
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
			Item item = new JewelryEarrings();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class GoldEarrings : BaseEarrings
	{
		[Constructable]
		public GoldEarrings() : base( 0x4CFB )
		{
			Name = "earrings";
			Weight = 0.1;
		}

		public GoldEarrings( Serial serial ) : base( serial )
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

	public class SilverEarrings : BaseEarrings
	{
		[Constructable]
		public SilverEarrings() : base( 0x4CFC )
		{
			Name = "earrings";
			Weight = 0.1;
		}

		public SilverEarrings( Serial serial ) : base( serial )
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