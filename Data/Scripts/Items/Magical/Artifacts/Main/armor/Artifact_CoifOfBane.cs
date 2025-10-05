using System;
using Server;

namespace Server.Items
{
	public class Artifact_CoifOfBane : GiftChainCoif
	{
		[Constructable]
		public Artifact_CoifOfBane()
		{
			Name = "Coif of Bane";
			Hue = 0x4F5;
			ItemID = 0x13BB;
			ArmorAttributes.DurabilityBonus = 30;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 20;
			PoisonBonus = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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