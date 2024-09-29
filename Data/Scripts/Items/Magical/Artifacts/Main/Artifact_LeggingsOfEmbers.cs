using System;
using Server;

namespace Server.Items
{
	public class Artifact_LeggingsOfEmbers : GiftPlateLegs
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public Artifact_LeggingsOfEmbers()
		{
			Name = "Royal Leggings of Embers";
			Hue = 0x2C;
			ItemID = 0x46AA;
			ArmorAttributes.SelfRepair = 10;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.LowerStatReq = 100;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_LeggingsOfEmbers( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}