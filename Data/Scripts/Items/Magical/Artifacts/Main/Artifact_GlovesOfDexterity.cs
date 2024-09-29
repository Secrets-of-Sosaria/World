using System;
using Server;

namespace Server.Items
{
	public class Artifact_GlovesOfDexterity : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_GlovesOfDexterity()
		{
			Name = "Gloves of Dexterity";
			Hue = 0x594;
			ItemID = 0x13C6;
			Attributes.BonusDex = 20;
			Attributes.RegenStam = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_GlovesOfDexterity( Serial serial ) : base( serial )
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