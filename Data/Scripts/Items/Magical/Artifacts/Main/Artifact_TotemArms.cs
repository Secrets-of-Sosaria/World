using System;
using Server;

namespace Server.Items
{
	public class Artifact_TotemArms : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_TotemArms()
		{
			Name = "Totem Arms";
			Hue = 0x455;
			ItemID = 0x13cd;
			Attributes.BonusStr = 8;
			Attributes.ReflectPhysical = 8;
			Attributes.AttackChance = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_TotemArms( Serial serial ) : base( serial )
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