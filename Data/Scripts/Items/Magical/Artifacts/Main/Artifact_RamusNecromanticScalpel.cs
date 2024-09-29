using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_RamusNecromanticScalpel : GiftDagger
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_RamusNecromanticScalpel()
		{
			Name = "Ramus' Necromantic Scalpel";
			Hue = 1372;
			ItemID = 0x2677;
			WeaponAttributes.HitLeechHits = 60;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 20;
			Slayer = SlayerName.Repond ;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_RamusNecromanticScalpel( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}
