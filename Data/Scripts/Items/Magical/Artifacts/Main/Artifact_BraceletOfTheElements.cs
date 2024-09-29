using System;
using Server;

namespace Server.Items
{
	public class Artifact_BraceletOfTheElements : GiftGoldBracelet
	{
		[Constructable]
		public Artifact_BraceletOfTheElements()
		{
			Name = "Bracelet of the Elements";
			Hue = 0x4E9;
			Attributes.Luck = 125;
			Resistances.Fire = 18;
			Resistances.Cold = 18;
			Resistances.Poison = 18;
			Resistances.Energy = 18;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BraceletOfTheElements( Serial serial ) : base( serial )
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