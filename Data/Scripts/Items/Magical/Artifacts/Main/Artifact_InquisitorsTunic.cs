using System;
using Server;

namespace Server.Items
{
	public class Artifact_InquisitorsTunic : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 27; } }
		public override int BaseEnergyResistance{ get{ return 23; } }

		[Constructable]
		public Artifact_InquisitorsTunic()
		{
			Name = "Inquisitor's Tunic";
			Hue = 0x4F2;
			ItemID = 0x1415;
			Attributes.CastRecovery = 1;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_InquisitorsTunic( Serial serial ) : base( serial )
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