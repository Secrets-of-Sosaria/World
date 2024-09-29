using System;
using Server;

namespace Server.Items
{
	public class Artifact_JackalsTunic : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseFireResistance{ get{ return 23; } }
		public override int BaseColdResistance{ get{ return 29; } }

		[Constructable]
		public Artifact_JackalsTunic()
		{
			Name = "Jackal's Tunic";
			Hue = 0x6D1;
			ItemID = 0x1415;
			Attributes.BonusDex = 15;
			Attributes.RegenHits = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_JackalsTunic( Serial serial ) : base( serial )
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