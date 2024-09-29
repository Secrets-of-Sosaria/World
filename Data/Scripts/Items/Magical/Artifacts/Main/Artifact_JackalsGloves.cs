using System;
using Server;

namespace Server.Items
{
	public class Artifact_JackalsGloves : GiftPlateGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 9; } }

		[Constructable]
		public Artifact_JackalsGloves()
		{
			Name = "Jackal's Gloves";
			Hue = 0x6D1;
			ItemID = 0x1414;
			Attributes.BonusDex = 15;
			Attributes.RegenHits = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_JackalsGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}