using System;
using Server;

namespace Server.Items
{
	public class EmeraldIngot : Item
	{
		[Constructable]
		public EmeraldIngot() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public EmeraldIngot( int amount ) : base( 0x1BF8 )
		{
			Name = "emerald block";
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
		}

		public EmeraldIngot( Serial serial ) : base( serial )
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
			Item item = new EmeraldBlocks();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}