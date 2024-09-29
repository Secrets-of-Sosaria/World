using System;
using Server;

namespace Server.Items
{
	public class Artifact_EarringsOfHealth : GiftGoldEarrings
	{
		[Constructable]
		public Artifact_EarringsOfHealth()
		{
			Name = "Earrings of Health";
			Hue = 0x21;
			Attributes.BonusHits = 3;
			Attributes.RegenHits = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_EarringsOfHealth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();

			ItemID = 0x672F;
		}
	}
}