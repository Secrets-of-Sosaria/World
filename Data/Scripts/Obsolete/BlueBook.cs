using System;
using Server;

namespace Server.Items
{
	public class BlueBook : BaseBook
	{

		[Constructable]
		public BlueBook() : base( 0xFF2, 40, true )
		{
		}

		[Constructable]
		public BlueBook( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBook( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public BlueBook( bool writable ) : base( 0xFF2, writable )
		{
		}

		public BlueBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new WritingBook();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
	}
}
