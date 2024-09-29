using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicFletching : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBowFletching.CraftSystem; } }

		[Constructable]
		public RunicFletching() : base()
		{
			ItemID = 0x670A;
			Name = "bowyer tools";
		}

		public RunicFletching( Serial serial ) : base( serial )
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
			ItemID = 0x670A;
			Name = "bowyer tools";
		}
	}
}