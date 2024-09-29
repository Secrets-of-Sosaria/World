using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class OreShovel : BaseHarvestTool
	{
		public override HarvestSystem HarvestSystem{ get{ return Mining.System; } }

		[Constructable]
		public OreShovel() : this( 50 )
		{
		}

		[Constructable]
		public OreShovel( int uses ) : base( uses, 0x6608 )
		{
			Name = "ore spade";
			Weight = 5.0;
		}

		public OreShovel( Serial serial ) : base( serial )
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
			Item item = new Spade();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}