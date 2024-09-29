using System;
using Server;

namespace Server.Items
{
	public class IceIngot : Item
	{
		[Constructable]
		public IceIngot() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public IceIngot( int amount ) : base( 0x1BF8 )
		{
			Name = "ice block";
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
		}

		public IceIngot( Serial serial ) : base( serial )
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
			Item item = new IceBlocks();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}