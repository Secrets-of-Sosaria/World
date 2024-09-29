using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class Hammer : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public Hammer() : base( 0x102A )
		{
			Weight = 2.0;
		}

		[Constructable]
		public Hammer( int uses ) : base( uses, 0x102A )
		{
			Weight = 2.0;
		}

		public Hammer( Serial serial ) : base( serial )
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
			Item item = new Saw();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}