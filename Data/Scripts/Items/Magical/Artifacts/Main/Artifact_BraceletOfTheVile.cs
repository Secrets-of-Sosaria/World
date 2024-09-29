using System;
using Server;

namespace Server.Items
{
	public class Artifact_BraceletOfTheVile : GiftGoldBracelet
	{
		[Constructable]
		public Artifact_BraceletOfTheVile()
		{
			Name = "Bracelet of the Vile";
			Hue = 0x4F7;
			Attributes.BonusDex = 10;
			Attributes.RegenStam = 8;
			Attributes.AttackChance = 18;
			Resistances.Poison = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_BraceletOfTheVile( Serial serial ) : base( serial )
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