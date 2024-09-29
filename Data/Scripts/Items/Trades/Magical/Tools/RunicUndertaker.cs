using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicUndertaker : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBonecrafting.CraftSystem; } }

		[Constructable]
		public RunicUndertaker() : base()
		{
			ItemID = 0x661C;
			Name = "undertaker tools";
		}

		public RunicUndertaker( Serial serial ) : base( serial )
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