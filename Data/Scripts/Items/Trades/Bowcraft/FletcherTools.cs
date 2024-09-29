using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class FletcherTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBowFletching.CraftSystem; } }

		[Constructable]
		public FletcherTools() : base( 0x66F9 )
		{
			Name = "bowcrafting tools";
			Weight = 1.0;
		}

		public FletcherTools( Serial serial ) : base( serial )
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

			ItemID = 0x66F9;
			Name = "bowcrafting tools";
		}
	}
}