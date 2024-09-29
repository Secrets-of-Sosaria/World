using System;
using Server;

namespace Server.Items
{
	public class QuiverOfRage : BaseQuiver
	{
		[Constructable]
		public QuiverOfRage() : base()
		{
			int attributeCount = Utility.RandomMinMax(5,8);
			int min = Utility.RandomMinMax(6,16);
			int max = min + 15;
			BaseRunicTool.ApplyAttributesTo( (BaseQuiver)this, attributeCount, min, max );

			Hue = 0xB01;
			Name = "Quiver of Rage";
			ItemID = 0x2B02;
			WeightReduction = 100;
			if ( DamageIncrease < 10 ){ DamageIncrease = 10; }
			ArtifactLevel = 1;
		}

		public QuiverOfRage( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			chaos = direct = 0;
			phys = fire = cold = pois = nrgy = 20;
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
