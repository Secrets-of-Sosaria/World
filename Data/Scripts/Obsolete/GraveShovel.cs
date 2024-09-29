using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class GraveShovel : Shovel
	{
		public override HarvestSystem HarvestSystem { get { return GraveRobbing.System; } }

		[Constructable]
		public GraveShovel() : this( 50 )
		{
		}

		[Constructable]
		public GraveShovel( int uses ) : base( 0x0F3A )
		{
			Name = "grave shovel";
			Layer = Layer.TwoHanded;
			UsesRemaining = uses;
			NeedsBothHands = true;
		}

		public GraveShovel( Serial serial ) : base( serial )
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
			Item item = new GraveSpade();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}