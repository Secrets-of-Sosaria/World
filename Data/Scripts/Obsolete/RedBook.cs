using System;
using Server;

namespace Server.Items
{
	public class RedBook : BaseBook
	{
		[Constructable]
		public RedBook() : base( 0xFF1 )
		{
		}

		[Constructable]
		public RedBook( int pageCount, bool writable ) : base( 0xFF1, pageCount, writable )
		{
		}

		[Constructable]
		public RedBook( string title, string author, int pageCount, bool writable ) : base( 0xFF1, title, author, pageCount, writable )
		{
		}

		// Intended for defined books only
		public RedBook( bool writable ) : base( 0xFF1, writable )
		{
		}

		public RedBook( Serial serial ) : base( serial )
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