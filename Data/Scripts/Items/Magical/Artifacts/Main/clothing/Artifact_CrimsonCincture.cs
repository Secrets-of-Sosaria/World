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
			Attributes.BonusDex = 10;
			Attributes.BonusHits = 10;
			Attributes.RegenHits = 5;
			Attributes.BonusStam = 10;
			Attributes.RegenStam = 5;
			Attributes.Luck = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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

