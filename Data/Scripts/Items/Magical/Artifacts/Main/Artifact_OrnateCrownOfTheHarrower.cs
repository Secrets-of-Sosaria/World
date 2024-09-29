using System;
using Server;

namespace Server.Items
{
	public class Artifact_OrnateCrownOfTheHarrower : GiftBoneHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
		public override int BasePoisonResistance{ get{ return 17; } }

		[Constructable]
		public Artifact_OrnateCrownOfTheHarrower()
		{
			Name = "Ornate Crown of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 2;
			Attributes.RegenStam = 3;
			Attributes.WeaponDamage = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_OrnateCrownOfTheHarrower( Serial serial ) : base( serial )
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