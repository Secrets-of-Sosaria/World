using System;
using Server;

namespace Server.Items
{
	public class QuartzIngot : Item
	{
		[Constructable]
		public QuartzIngot() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public QuartzIngot( int amount ) : base( 0x1BF8 )
		{
			Name = "quartz block";
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
		}

		public QuartzIngot( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new QuartzBlocks();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}