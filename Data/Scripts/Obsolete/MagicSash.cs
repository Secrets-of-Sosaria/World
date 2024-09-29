using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MagicSash : GoldRing
	{
		[Constructable]
		public MagicSash()
		{
			Resource = CraftResource.None;
			Name = "sash";
			ItemID = 0x1541;
			Hue = Utility.RandomColor(0);
			if ( Utility.RandomBool() )
				Hue = Utility.RandomSpecialHue();
			Layer = Layer.MiddleTorso;
			Weight = 2.0;
		}

		public MagicSash( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item oldItem = (Item)state;
			Item newItem = new BodySash();
			Server.Misc.Cleanup.DoCleanup( oldItem, newItem );
		}
	}
}