using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class MapmakersPen : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCartography.CraftSystem; } }

		[Constructable]
		public MapmakersPen() : base( 0x316E )
		{
			Name = "cartography quill";
			Weight = 1.0;
		}

		[Constructable]
		public MapmakersPen( int uses ) : base( uses, 0x316E )
		{
			Name = "cartography quill";
			Weight = 1.0;
		}

		public MapmakersPen( Serial serial ) : base( serial )
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
			Name = "cartography quill";
			ItemID = 0x316E;
		}
	}
}