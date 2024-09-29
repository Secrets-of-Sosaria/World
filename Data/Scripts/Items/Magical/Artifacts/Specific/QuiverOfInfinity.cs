using System;

namespace Server.Items
{
	public class QuiverOfInfinity : BaseQuiver
	{
		[Constructable]
		public QuiverOfInfinity() : base()
		{
			int attributeCount = Utility.RandomMinMax(3,7);
			int min = Utility.RandomMinMax(5,15);
			int max = min + 20;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );

			Name = "Quiver of Infinity";
			ItemID = 0x2B02;
			Hue = 0x99A;
			WeightReduction = 80;
			LowerAmmoCost = 20;
			Attributes.DefendChance = 5;
			ArtifactLevel = 1;
		}

		public QuiverOfInfinity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			if( version < 1 && DamageIncrease == 0 )
			{
				DamageIncrease = 10;
			}
			ArtifactLevel = 1;
		}
	}
}
