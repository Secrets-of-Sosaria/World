using System;
using Server;

namespace Server.Items
{
	public class SnakeSkin : Item
	{
		[Constructable]
		public SnakeSkin() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public SnakeSkin( int amount ) : base( 0x1081 )
		{
			Name = "serpent skin";
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );
		}

		public SnakeSkin( Serial serial ) : base( serial )
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
			Item item = new SnakeSkins();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}