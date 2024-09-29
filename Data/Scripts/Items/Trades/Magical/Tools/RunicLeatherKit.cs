using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicLeatherKit : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefLeatherworking.CraftSystem; } }

		[Constructable]
		public RunicLeatherKit() : base()
		{
			ItemID = 0x66FB;
			Name = "tanning kit";
		}

		public RunicLeatherKit( Serial serial ) : base( serial )
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