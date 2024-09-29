using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicSaw : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public RunicSaw() : base()
		{
			ItemID = 0x5173;
			Name = "woodworking tools";
		}

		public RunicSaw( Serial serial ) : base( serial )
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
			ItemID = 0x5173;
			Name = "woodworking tools";
		}
	}
}