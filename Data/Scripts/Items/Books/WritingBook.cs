using System;
using Server;

namespace Server.Items
{
	public class WritingBook : BaseBook
	{
		[Constructable]
		public WritingBook() : base( Utility.RandomMinMax(0x4FDF,0x4FE0) )
		{
		}

		[Constructable]
		public WritingBook( int pageCount, bool writable ) : base( Utility.RandomMinMax(0x4FDF,0x4FE0), pageCount, writable )
		{
		}

		[Constructable]
		public WritingBook( string title, string author, int pageCount, bool writable ) : base( Utility.RandomMinMax(0x4FDF,0x4FE0), title, author, pageCount, writable )
		{
		}

		public WritingBook( bool writable ) : base( Utility.RandomMinMax(0x4FDF,0x4FE0), writable )
		{
		}

		public WritingBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}
	}
}