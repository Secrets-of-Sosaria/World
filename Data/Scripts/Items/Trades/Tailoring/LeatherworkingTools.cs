using System;
using Server;
using Server.Engines.Craft;
using Server.Misc;

namespace Server.Items
{
	public class LeatherworkingTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefLeatherworking.CraftSystem; } }

		[Constructable]
		public LeatherworkingTools() : base( 0x66FA )
		{
			Name = "tanning tools";
			Weight = 1.0;
		}

		[Constructable]
		public LeatherworkingTools( int uses ) : base( uses, 0x66FA )
		{
			Name = "tanning tools";
			Weight = 1.0;
		}

		public LeatherworkingTools( Serial serial ) : base( serial )
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