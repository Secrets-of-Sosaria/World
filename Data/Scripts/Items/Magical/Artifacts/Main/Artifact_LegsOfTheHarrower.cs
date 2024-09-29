using System;
using Server;

namespace Server.Items
{
	public class Artifact_LegsOfTheHarrower : GiftBoneLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePoisonResistance{ get{ return 21; } }

		[Constructable]
		public Artifact_LegsOfTheHarrower()
		{
			Name = "Leggings of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.WeaponDamage = 21;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_LegsOfTheHarrower( Serial serial ) : base( serial )
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

			if ( version < 1 )
			{
				if ( Hue == 0x55A )
					Hue = 0x4F6;

				PoisonBonus = 0;
			}
		}
	}
}