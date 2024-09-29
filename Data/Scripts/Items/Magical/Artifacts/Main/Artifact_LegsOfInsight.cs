using System;
using Server;

namespace Server.Items
{
	public class Artifact_LegsOfInsight : GiftPlateLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseEnergyResistance{ get{ return 19; } }

		[Constructable]
		public Artifact_LegsOfInsight()
		{
			Name = "Legging of Insight";
			Hue = 0x554;
			ItemID = 0x46AA;
			Attributes.BonusInt = 8;
			Attributes.BonusMana = 15;
			Attributes.RegenMana = 2;
			Attributes.LowerManaCost = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_LegsOfInsight( Serial serial ) : base( serial )
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

			if ( version < 1 )
				EnergyBonus = 0;
		}
	}
}