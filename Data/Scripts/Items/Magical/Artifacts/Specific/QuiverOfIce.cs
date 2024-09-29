using System;
using Server;

namespace Server.Items
{
	public class QuiverOfIce : ElvenQuiver
	{
		[Constructable]
		public QuiverOfIce() : base()
		{
			int attributeCount = Utility.RandomMinMax(5,10);
			int min = Utility.RandomMinMax(10,20);
			int max = min + 20;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );

			Name = "Quiver of Ice";
			Hue = 0x998;
			ItemID = 0x2B02;
			ArtifactLevel = 1;
		}

		public QuiverOfIce( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			fire = pois = nrgy = chaos = direct = 0;
			phys = cold = 50;
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
