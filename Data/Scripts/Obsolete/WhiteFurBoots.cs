using System;

namespace Server.Items
{
	public class WhiteFurBoots : Boots
	{
		[Constructable]
		public WhiteFurBoots() : base( 0x2307 )
		{
			Resource = CraftResource.None;
			Name = "fur boots";
			Hue = 0x481;
			Weight = 3.0;
			Resistances.Cold = 5;
			ItemID = 0x2307;
		}

		public WhiteFurBoots( Serial serial ) : base( serial )
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
			Item item = new Boots();
			item.Resource = CraftResource.WoolyFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}
