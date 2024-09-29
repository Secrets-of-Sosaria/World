using System;
using Server;

namespace Server.Items
{
	public class Artifact_TunicOfBane : GiftChainChest
	{
		public override int BasePoisonResistance{ get{ return 26; } }

		[Constructable]
		public Artifact_TunicOfBane()
		{
			Name = "Tunic of Bane";
			Hue = 0x4F5;
			ItemID = 0x13BF;
			ArmorAttributes.DurabilityBonus = 50;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_TunicOfBane( Serial serial ) : base( serial )
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