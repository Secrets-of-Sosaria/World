using System;
using Server;

namespace Server.Items
{
	public class RightArm : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		[Constructable]
		public RightArm() : base( 0x6701 )
		{
			Name = "arm";
			Weight = 1.0;
			Hue = Utility.RandomSkinHue();
		}

		public RightArm( Serial serial ) : base( serial )
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