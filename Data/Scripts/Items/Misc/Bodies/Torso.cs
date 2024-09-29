using System;
using Server;

namespace Server.Items
{
	public class Torso : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		[Constructable]
		public Torso() : base( 0x66FF )
		{
			Name = "torso";
			Weight = 2.0;
			Hue = Utility.RandomSkinHue();
		}

		public Torso( Serial serial ) : base( serial )
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