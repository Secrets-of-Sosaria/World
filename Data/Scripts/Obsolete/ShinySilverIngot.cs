using System;
using Server;

namespace Server.Items
{
	public class ShinySilverIngot : Item
	{
		[Constructable]
		public ShinySilverIngot() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public ShinySilverIngot( int amount ) : base( 0x1BF8 )
		{
			Name = "silver block";
			Stackable = true;
			Amount = CraftResources.GetHue( CraftResource.SilverBlock );
		}

		public ShinySilverIngot( Serial serial ) : base( serial )
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
			ItemID = 0x1BF8;
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new SilverBlocks();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}