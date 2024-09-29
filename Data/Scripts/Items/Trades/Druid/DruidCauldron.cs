using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DruidCauldron : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefDruidism.CraftSystem; } }

		[Constructable]
		public DruidCauldron() : base( 0x640A )
		{
			Name = "druid's cauldron";
			Weight = 1.0;
		}

		[Constructable]
		public DruidCauldron( int uses ) : base( uses, 0x640A )
		{
			Name = "druid's cauldron";
			Weight = 1.0;
		}

		public DruidCauldron( Serial serial ) : base( serial )
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