using System;
using Server;

namespace Server.Items
{
	public class QuiverOfFire : ElvenQuiver
	{
		[Constructable]
		public QuiverOfFire() : base()
		{
			int attributeCount = Utility.RandomMinMax(5,10);
			int min = Utility.RandomMinMax(10,20);
			int max = min + 20;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );
			ArtifactLevel = 1;

			Name = "Quiver of Fire";
			Hue = 0xB17;
			ItemID = 0x2B02;
		}

		public QuiverOfFire( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			cold = pois = nrgy = chaos = direct = 0;
			phys = fire = 50;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			ArtifactLevel = 1;
		}
	}
}
