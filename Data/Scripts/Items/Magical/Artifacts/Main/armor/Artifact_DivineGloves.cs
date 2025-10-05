using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_DivineGloves()
		{
			Name = "Divine Gloves";
			Hue = 0x482;
			ItemID = 0x13C6;
			Attributes.BonusInt = 6;
			Attributes.RegenMana = 4;
			Attributes.ReflectPhysical = 10;
			Attributes.LowerManaCost = 10;
			Attributes.Luck = 70;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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