using System;
using Server;

namespace Server.Items
{
	public class Artifact_GlovesOfTheHarrower : GiftBoneGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePoisonResistance{ get{ return 13; } }

		[Constructable]
		public Artifact_GlovesOfTheHarrower()
		{
			Name = "Gloves of the Harrower";
			Hue = 0x4F6;
			Attributes.BonusDex = 10;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.WeaponDamage = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GlovesOfTheHarrower( Serial serial ) : base( serial )
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