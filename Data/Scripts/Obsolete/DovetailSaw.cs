using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 0x1028, 0x1029 )]
	public class DovetailSaw : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public DovetailSaw() : base( 0x1028 )
		{
			Weight = 2.0;
		}

		[Constructable]
		public DovetailSaw( int uses ) : base( uses, 0x1028 )
		{
			Weight = 2.0;
		}

		public DovetailSaw( Serial serial ) : base( serial )
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