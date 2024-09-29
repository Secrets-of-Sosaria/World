using System;
using Server;
using Server.Engines.Craft;
using Server.Misc;

namespace Server.Items
{
	public class SewingKit : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefTailoring.CraftSystem; } }

		[Constructable]
		public SewingKit() : base( 0x4C81 )
		{
			Name = "sewing kit";
			Weight = 1.0;
		}

		[Constructable]
		public SewingKit( int uses ) : base( uses, 0x4C81 )
		{
			Weight = 1.0;
			if ( Utility.RandomBool() ){ ItemID = 0x4C80; }
		}

		public SewingKit( Serial serial ) : base( serial )
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
			ItemID = 0x4C81;
		}
	}
}