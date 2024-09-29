using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MagicBelt : GoldRing
	{
		[Constructable]
		public MagicBelt()
		{
			Resource = CraftResource.None;
			Name = "belt";
			ItemID = 0x567B;
			switch( Utility.Random( 5 ) )
			{
				case 0: Name = "belt";				ItemID = 0x2790;		break;
				case 1: Name = "loin cloth";		ItemID = 0x2B68;		break;
				case 2: Name = "apron";				ItemID = 0x153b;		break;
				case 3: Name = "royal loin cloth";	ItemID = 0x55DB;		break;
			}
			Hue = Utility.RandomColor(0);
			if ( Utility.RandomBool() )
				Hue = Utility.RandomSpecialHue();
			Layer = Layer.Waist;
			Weight = 2.0;
		}

		public MagicBelt( Serial serial ) : base( serial )
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
			Item newItem = null;

			if ( (oldItem.Name).Contains("belt") )
				newItem = new Belt();
			else if ( (oldItem.Name).Contains("royal loin") )
				newItem = new RoyalLoinCloth();
			else if ( (oldItem.Name).Contains("loin") )
				newItem = new LoinCloth();
			else
				newItem = new HalfApron();

			Server.Misc.Cleanup.DoCleanup( oldItem, newItem );
		}
	}
}