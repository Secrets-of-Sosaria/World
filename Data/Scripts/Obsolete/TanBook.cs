using System;
using Server;

namespace Server.Items
{
	public class TanBook : BaseBook
	{
		[Constructable]
		public TanBook() : base( 0xFF0 )
		{
		}

		[Constructable]
		public TanBook( int pageCount, bool writable ) : base( 0xFF0, pageCount, writable )
		{
		}

		[Constructable]
		public TanBook( string title, string author, int pageCount, bool writable ) : base( 0xFF0, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public TanBook( bool writable ) : base( 0xFF0, writable )
		{
		}

		public TanBook( Serial serial ) : base( serial )
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