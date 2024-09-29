using System;
using Server;

namespace Server.Items
{
	public class QuiverOfLightning : ElvenQuiver
	{
		[Constructable]
		public QuiverOfLightning() : base()
		{
			int attributeCount = Utility.RandomMinMax(5,10);
			int min = Utility.RandomMinMax(10,20);
			int max = min + 20;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );

			Name = "Quiver of Lightning";
			Hue = 0x8D9;
			ItemID = 0x2B02;
			ArtifactLevel = 1;
		}

		public QuiverOfLightning( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			fire = cold = pois = chaos = direct = 0;
			phys = nrgy = 50;
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
