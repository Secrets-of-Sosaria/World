using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class WitchCauldron : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWitchery.CraftSystem; } }

		[Constructable]
		public WitchCauldron() : base( 0x640B )
		{
			Name = "witch's cauldron";
			Weight = 1.0;
		}

		[Constructable]
		public WitchCauldron( int uses ) : base( uses, 0x640B )
		{
			Name = "witch's cauldron";
			Weight = 1.0;
		}

		public WitchCauldron( Serial serial ) : base( serial )
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