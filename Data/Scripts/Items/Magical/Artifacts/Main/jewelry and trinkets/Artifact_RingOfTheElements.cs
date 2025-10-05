using System;
using Server;

namespace Server.Items
{
	public class Artifact_RingOfTheElements : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfTheElements()
		{
			Name = "Ring of the Elements";
			Hue = 0x4E9;
			ItemID = 0x6731;
			Attributes.Luck = 90;
			Resistances.Fire = 15;
			Resistances.Cold = 15;
			Resistances.Poison = 15;
			Resistances.Energy = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_RingOfTheElements( Serial serial ) : base( serial )
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
		}
	}
}