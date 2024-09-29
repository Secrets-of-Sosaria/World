using System;
using Server;

namespace Server.Items
{
	public class BodyPart : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		[Constructable]
		public BodyPart() : this( 0x1DA4 )
		{
			Movable = true;
			Weight = 1.0;
		}

		[Constructable]
		public BodyPart( int itemID ) : base( itemID )
		{
			Movable = true;
			Weight = 1.0;
		}

		public BodyPart( Serial serial ) : base( serial )
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
		}
	}
}