using System;
using Server;

namespace Server.Items
{
	public class Artifact_EarringsOfTheVile : GiftGoldEarrings
	{
		[Constructable]
		public Artifact_EarringsOfTheVile()
		{
			Name = "Earrings of the Vile";
			Hue = 0x4F7;
			Attributes.BonusDex = 9;
			Attributes.RegenStam = 10;
			Attributes.AttackChance = 12;
			Resistances.Poison = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_EarringsOfTheVile( Serial serial ) : base( serial )
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