using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ScalingTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefDraconic.CraftSystem; } }

		[Constructable]
		public ScalingTools() : base( 0x6704 )
		{
			Name = "scaling tools";
			Weight = 1.0;
		}

		[Constructable]
		public ScalingTools( int uses ) : base( uses, 0x6704 )
		{
			Name = "scaling tools";
			Weight = 2.0;
		}

		public ScalingTools( Serial serial ) : base( serial )
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