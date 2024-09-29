using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x2B76, 0x2B77 )]
	public class TomeOfWands : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWands.CraftSystem; } }

		[Constructable]
		public TomeOfWands() : base( 0x2B77 )
		{
			Name = "tome of wands";
			Weight = 1.0;
			UsesRemaining = 10;
		}

		public TomeOfWands( Serial serial ) : base( serial )
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
			if ( ItemID != 0x2B76 && ItemID != 0x2B77 )
				ItemID = 0x2B77;
		}
	}
}