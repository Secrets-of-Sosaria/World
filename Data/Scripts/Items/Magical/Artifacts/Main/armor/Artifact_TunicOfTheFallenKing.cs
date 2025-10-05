using System;
using Server;

namespace Server.Items
{
	public class Artifact_TunicOfTheFallenKing : GiftLeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 19; } }
		public override int BaseEnergyResistance{ get{ return 19; } }

		[Constructable]
		public Artifact_TunicOfTheFallenKing()
		{
			Name = "Tunic of the Fallen King";
			Hue = 0x76D;
			ItemID = 0x13CC;
			Attributes.BonusStr = 10;
			Attributes.RegenHits = 15;
			Attributes.RegenStam = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TunicOfTheFallenKing( Serial serial ) : base( serial )
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