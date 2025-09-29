using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineArms : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_DivineArms()
		{
			Name = "Divine Arms";
			Hue = 0x482;
			ItemID = 0x13cd;
			Attributes.BonusInt = 6;
			Attributes.RegenMana = 4;
			Attributes.ReflectPhysical = 10;
			Attributes.LowerManaCost = 4;
			Attributes.Luck = 80;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_DivineArms( Serial serial ) : base( serial )
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