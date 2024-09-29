using System;
using Server;

namespace Server.Items
{
	public class Artifact_TunicOfTheHarrower : GiftBoneChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePoisonResistance{ get{ return 25; } }

		[Constructable]
		public Artifact_TunicOfTheHarrower()
		{
			Name = "Tunic of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 7;
			Attributes.RegenStam = 7;
			Attributes.WeaponDamage = 35;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_TunicOfTheHarrower( Serial serial ) : base( serial )
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