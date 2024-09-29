using System;
using Server;

namespace Server.Items
{
	public class Artifact_GlovesOfTheHarrower : GiftBoneGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePoisonResistance{ get{ return 17; } }

		[Constructable]
		public Artifact_GlovesOfTheHarrower()
		{
			Name = "Gloves of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 3;
			Attributes.RegenStam = 2;
			Attributes.WeaponDamage = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
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