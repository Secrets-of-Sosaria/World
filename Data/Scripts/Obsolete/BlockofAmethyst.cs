using System;
using Server;

namespace Server.Items
{
	public class AmethystIngot : Item
	{
		[Constructable]
		public AmethystIngot() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public AmethystIngot( int amount ) : base( 0x1BF8 )
		{
			Name = "amethyst block";
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
		}

		public AmethystIngot( Serial serial ) : base( serial )
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
			Item item = new AmethystBlocks();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}