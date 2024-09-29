using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_DivineGloves()
		{
			Name = "Divine Gloves";
			Hue = 0x482;
			ItemID = 0x13C6;
			Attributes.BonusInt = 6;
			Attributes.RegenMana = 1;
			Attributes.ReflectPhysical = 8;
			Attributes.LowerManaCost = 4;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_DivineGloves( Serial serial ) : base( serial )
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