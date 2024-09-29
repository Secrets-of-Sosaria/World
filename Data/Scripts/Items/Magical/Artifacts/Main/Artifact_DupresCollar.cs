using System;
using Server;

namespace Server.Items
{
	public class Artifact_DupresCollar : GiftPlateGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_DupresCollar()
		{
			Name = "Dupre's Collar";
			Hue = 794;
			ItemID = 0x1413;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 2;
			Attributes.DefendChance = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_DupresCollar( Serial serial ) : base( serial )
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