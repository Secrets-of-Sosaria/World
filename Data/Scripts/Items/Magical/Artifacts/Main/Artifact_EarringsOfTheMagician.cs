using System;
using Server;

namespace Server.Items
{
	public class Artifact_EarringsOfTheMagician : GiftGoldEarrings
	{
		[Constructable]
		public Artifact_EarringsOfTheMagician()
		{
			Name = "Earrings of the Magician";
			Hue = 0x554;
			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 10;
			Resistances.Energy = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_EarringsOfTheMagician( Serial serial ) : base( serial )
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