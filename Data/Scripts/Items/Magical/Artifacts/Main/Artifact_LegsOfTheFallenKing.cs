using System;
using Server;

namespace Server.Items
{
	public class Artifact_LegsOfTheFallenKing : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		[Constructable]
		public Artifact_LegsOfTheFallenKing()
		{
			Name = "Leggings of the Fallen King";
			Hue = 0x76D;
			ItemID = 0x13cb;
			Attributes.BonusStr = 6;
			Attributes.RegenHits = 10;
			Attributes.RegenStam = 3;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_LegsOfTheFallenKing( Serial serial ) : base( serial )
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