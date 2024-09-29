using System;
using Server;
using Server.Engines.Craft;
using Server.Misc;

namespace Server.Items
{
	public class UndertakerKit : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBonecrafting.CraftSystem; } }

		[Constructable]
		public UndertakerKit() : base( 0x661B )
		{
			Name = "undertaker kit";
			Weight = 1.0;
			Hue = 0xB61;
		}

		[Constructable]
		public UndertakerKit( int uses ) : base( uses, 0x661B )
		{
			Weight = 2.0;
		}

		public UndertakerKit( Serial serial ) : base( serial )
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
			if ( Hue == 0 ){ Hue = 0xB61; }
		}
	}
}