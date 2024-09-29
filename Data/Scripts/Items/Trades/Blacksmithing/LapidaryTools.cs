using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class GodSmithing : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefLapidary.CraftSystem; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.None; } }

		[Constructable]
		public GodSmithing() : base( 0x267E )
		{
			Name = "lapidary hammer";
			Weight = 1.0;
			Layer = Layer.OneHanded;
			UsesRemaining = 10;
			Hue = 0xB17;
			NotModAble = true;
		}

		public GodSmithing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override int isWeapon()
		{
			return 25744;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ItemID = 0x267E;
			Name = "lapidary hammer";
			Hue = 0xB17;
			NotModAble = true;
		}
	}
}