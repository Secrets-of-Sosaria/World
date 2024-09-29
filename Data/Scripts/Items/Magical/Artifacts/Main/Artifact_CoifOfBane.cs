using System;
using Server;

namespace Server.Items
{
	public class Artifact_CoifOfBane : GiftChainCoif
	{
		public override int BasePoisonResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_CoifOfBane()
		{
			Name = "Coif of Bane";
			Hue = 0x4F5;
			ItemID = 0x13BB;
			ArmorAttributes.DurabilityBonus = 50;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_CoifOfBane( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}