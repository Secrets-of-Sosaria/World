using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class GodBrewing : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefApothecary.CraftSystem; } }

		[Constructable]
		public GodBrewing() : base( 0x66F8 )
		{
			Weight = 1.0;
			Name = "apothecary set";
			UsesRemaining = 10;
			NotModAble = true;
			Hue = 0xB17;
		}

		public GodBrewing( Serial serial ) : base( serial )
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
			Name = "apothecary set";
			Hue = 0xB17;
			ItemID = 0x66F8;
			NotModAble = true;
		}
	}
}