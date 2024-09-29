using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MagicCloak : GoldRing
	{
		private static int[] m_ItemIDs = new int[]
		{
			0x26AD, 0x1515, 0x2B04
		};

		[Constructable]
		public MagicCloak()
		{
			Resource = CraftResource.None;
			ItemID = Utility.RandomList( m_ItemIDs );
			Name = "cloak";
			Hue = Utility.RandomColor(0);
			if ( Utility.RandomBool() )
				Hue = Utility.RandomSpecialHue();
			Layer = Layer.Cloak;
			Weight = 5.0;
		}

		public MagicCloak( Serial serial ) : base( serial )
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
			Item newItem = new Cloak();
			Server.Misc.Cleanup.DoCleanup( oldItem, newItem );
		}
	}
}