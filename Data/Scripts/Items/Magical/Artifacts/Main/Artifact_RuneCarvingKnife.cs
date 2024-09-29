using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_RuneCarvingKnife : GiftAssassinSpike
	{
		[Constructable]
		public Artifact_RuneCarvingKnife()
		{
			Hue = 0x48D;
			Name = "Rune Carving Knife";
			ItemID = 0x2677;

			WeaponAttributes.HitLeechMana = 40;
			Attributes.RegenStam = 2;
			Attributes.LowerManaCost = 10;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_RuneCarvingKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}