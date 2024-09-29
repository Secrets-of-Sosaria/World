using System;
using Server;

namespace Server.Items
{
	public class Artifact_RingOfTheMagician : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfTheMagician()
		{
			Name = "Ring of the Magician";
			Hue = 0x554;
			ItemID = 0x6731;
			Attributes.CastRecovery = 3;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			Resistances.Energy = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_RingOfTheMagician( Serial serial ) : base( serial )
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

			if ( Hue == 0x12B )
				Hue = 0x554;
		}
	}
}