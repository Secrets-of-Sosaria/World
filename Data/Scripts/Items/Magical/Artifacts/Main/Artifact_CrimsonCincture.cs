using System;

namespace Server.Items
{
    public class Artifact_CrimsonCincture : GiftHalfApron
	{
		[Constructable]
		public Artifact_CrimsonCincture() : base()
		{
			Hue = 0x485;
			Name = "Crimson Cincture";
			Attributes.BonusDex = 5;
			Attributes.BonusHits = 10;
			Attributes.RegenHits = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_CrimsonCincture( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}

