using System;
using Server;

namespace Server.Items
{
	public class IolosLute : BaseInstrument
	{
		public override int Hue { get { return 0x9C4; } }
		public override int InitMinUses{ get{ return 800; } }
		public override int InitMaxUses{ get{ return 800; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularWood; } }

		[Constructable]
		public IolosLute() : base( 0x66F3, 0x4C, 0x4D )
		{
			int attributeCount = Utility.RandomMinMax(8,15);
			int min = Utility.RandomMinMax(15,25);
			int max = min + 40;
			BaseRunicTool.ApplyAttributesTo( (BaseInstrument)this, attributeCount, min, max );

			Name = "Iolo's Lute";
			UsesRemaining = 800;
			Slayer = SlayerName.Silver;
			Slayer2 = SlayerName.Exorcism;
			ArtifactLevel = 1;
		}

		public IolosLute( Serial serial ) : base( serial )
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
			ItemID = 0x66F3;
		}
	}
}