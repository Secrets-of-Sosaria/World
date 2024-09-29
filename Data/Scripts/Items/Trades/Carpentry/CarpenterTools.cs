using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class CarpenterTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public CarpenterTools() : base( 0x4F52 )
		{
			Weight = 1.0;
			Name = "carpenter tools";
		}

		[Constructable]
		public CarpenterTools( int uses ) : base( uses, 0x4F52 )
		{
			Weight = 2.0;
			Name = "carpenter tools";
		}

		public CarpenterTools( Serial serial ) : base( serial )
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