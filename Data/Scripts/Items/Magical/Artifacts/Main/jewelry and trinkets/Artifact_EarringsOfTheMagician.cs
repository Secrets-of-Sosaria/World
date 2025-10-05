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
			Attributes.CastSpeed = 2;
			Attributes.LowerManaCost = 14;
			Attributes.LowerRegCost = 14;
			Attributes.BonusMana = 20;
			Resistances.Energy = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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