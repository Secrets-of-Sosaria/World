using System;
using Server;

namespace Server.Items
{
	public class Artifact_LeggingsOfBane : GiftChainLegs
	{
		public override int InitMinHits{ get{ return 250; } }
		public override int InitMaxHits{ get{ return 250; } }

		public override int BasePoisonResistance{ get{ return 36; } }

		[Constructable]
		public Artifact_LeggingsOfBane()
		{
			Name = "Leggings of Bane";
			Hue = 0x4F5;
			ItemID = 0x13BE;
			ArmorAttributes.DurabilityBonus = 100;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_LeggingsOfBane( Serial serial ) : base( serial )
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