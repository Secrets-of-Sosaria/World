using System;
using Server;

namespace Server.Items
{
	public class Artifact_EarringsOfTheElements : GiftGoldEarrings
	{
		[Constructable]
		public Artifact_EarringsOfTheElements()
		{
			Name = "Earrings of the Elements";
			Hue = 0x4E9;
			Attributes.Luck = 95;
			Resistances.Fire = 14;
			Resistances.Cold = 14;
			Resistances.Poison = 14;
			Resistances.Energy = 14;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_EarringsOfTheElements( Serial serial ) : base( serial )
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