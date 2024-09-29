using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicTinker : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefTinkering.CraftSystem; } }

		[Constructable]
		public RunicTinker() : base()
		{
			ItemID = 0x6709;
			Name = "tinker tools";
		}

		public RunicTinker( Serial serial ) : base( serial )
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
			ItemID = 0x6709;
			Name = "tinker tools";
		}
	}
}