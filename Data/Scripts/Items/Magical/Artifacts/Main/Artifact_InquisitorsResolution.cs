using System;
using Server;

namespace Server.Items
{
	public class Artifact_InquisitorsResolution : GiftPlateGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 22; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		[Constructable]
		public Artifact_InquisitorsResolution()
		{
			Name = "Inquisitor's Resolution";
			Hue = 0x4F2;
			ItemID = 0x1414;
			Attributes.CastRecovery = 1;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_InquisitorsResolution( Serial serial ) : base( serial )
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