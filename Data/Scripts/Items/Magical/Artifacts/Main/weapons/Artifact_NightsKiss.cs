using System;
using Server;

namespace Server.Items
{
	public class Artifact_NightsKiss : GiftDagger
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_NightsKiss()
		{
			Name = "Night's Kiss";
			ItemID = 0x2677;
			Hue = 0x455;
			WeaponAttributes.HitLeechHits = 40;
			Slayer = SlayerName.Repond;
			Attributes.WeaponSpeed = 10;
			Attributes.WeaponDamage = 11;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NightsKiss( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}