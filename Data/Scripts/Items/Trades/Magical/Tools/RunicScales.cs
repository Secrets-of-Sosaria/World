using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicScales : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefDraconic.CraftSystem; } }

		[Constructable]
		public RunicScales() : base()
		{
			ItemID = 0x6705;
			Name = "scaling tools";
		}

		public RunicScales( Serial serial ) : base( serial )
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