using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x2B78, 0x2B79 )]
	public class Blowpipe : BaseTool
	{
		public override CraftSystem CraftSystem { get { return DefGlassblowing.CraftSystem; } }

		public override int LabelNumber{ get{ return 1044608; } } // blow pipe

		[Constructable]
		public Blowpipe() : base( 0x2B78 )
		{
			Weight = 1.0;
			Name = "blowpipe";
		}

		[Constructable]
		public Blowpipe( int uses ) : base( uses, 0x2B78 )
		{
			Weight = 4.0;
			Name = "blowpipe";
		}

		public Blowpipe( Serial serial ) : base( serial )
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
			if ( ItemID != 0x2B78 && ItemID != 0x2B78 )
				ItemID = 0x2B78;
		}
	}
}