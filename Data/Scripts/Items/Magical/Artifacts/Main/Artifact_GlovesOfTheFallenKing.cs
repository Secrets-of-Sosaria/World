using System;
using Server;

namespace Server.Items
{
	public class Artifact_GlovesOfTheFallenKing : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 12; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_GlovesOfTheFallenKing()
		{
			Name = "Gloves of the Fallen King";
			Hue = 0x76D;
			ItemID = 0x13C6;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_GlovesOfTheFallenKing( Serial serial ) : base( serial )
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