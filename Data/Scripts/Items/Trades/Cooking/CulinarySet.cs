using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class CulinarySet : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCooking.CraftSystem; } }

		[Constructable]
		public CulinarySet() : base( 0x66FC )
		{
			Name = "culinary set";
			Weight = 1.0;
		}

		[Constructable]
		public CulinarySet( int uses ) : base( uses, 0x66FC )
		{
			Name = "culinary set";
			Weight = 1.0;
		}

		public CulinarySet( Serial serial ) : base( serial )
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