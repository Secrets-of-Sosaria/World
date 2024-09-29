using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_Pestilence: BaseQuiver
	{		
		[Constructable]
		public Artifact_Pestilence() : base()
        {
			int attributeCount = Utility.RandomMinMax(5,8);
			int min = Utility.RandomMinMax(6,16);
			int max = min + 15;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );

			Name = "Pestilence";
			Hue = 1151;
            DamageIncrease = 5;
			Attributes.DefendChance = 5;
			Attributes.AttackChance = 5;
			LowerAmmoCost = 5;
			ItemID = 0x2B02;
			WeightReduction = 100;
			ArtifactLevel = 1;
		}

		public Artifact_Pestilence( Serial serial ) : base( serial )
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
			ArtifactLevel = 1;
		}
	}
}