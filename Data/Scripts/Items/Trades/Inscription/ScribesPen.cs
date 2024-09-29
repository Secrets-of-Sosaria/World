using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ScribesPen : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefInscription.CraftSystem; } }

		[Constructable]
		public ScribesPen() : base( 0x316D )
		{
			Name = "scribe quill";
			Weight = 1.0;
		}

		[Constructable]
		public ScribesPen( int uses ) : base( uses, 0x316D )
		{
			Name = "scribe quill";
			Weight = 1.0;
		}

		public ScribesPen( Serial serial ) : base( serial )
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
			Name = "scribe quill";
			ItemID = 0x316D;
		}
	}
}