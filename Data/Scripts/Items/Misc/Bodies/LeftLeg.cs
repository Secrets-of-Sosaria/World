using System;
using Server;

namespace Server.Items
{
	public class LeftLeg : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		[Constructable]
		public LeftLeg() : base( 0x6702 )
		{
			Name = "leg";
			Weight = 1.0;
			Hue = Utility.RandomSkinHue();
		}

		public LeftLeg( Serial serial ) : base( serial )
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