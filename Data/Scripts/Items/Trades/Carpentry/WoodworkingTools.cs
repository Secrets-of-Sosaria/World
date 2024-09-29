using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class WoodworkingTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefShelves.CraftSystem; } }

		[Constructable]
		public WoodworkingTools() : base( 0x5173 )
		{
			Name = "woodworking tools";
			Weight = 1.0;
		}

		[Constructable]
		public WoodworkingTools( int uses ) : base( uses, 0x5173 )
		{
			Name = "woodworking tools";
			Weight = 2.0;
			InfoText1 = "Crates, Chests";
			InfoText2 = "Shelves, Dressers,";
			InfoText3 = "and Cabinets";
		}

		public WoodworkingTools( Serial serial ) : base( serial )
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
			ItemID = 0x5173;
		}
	}
}