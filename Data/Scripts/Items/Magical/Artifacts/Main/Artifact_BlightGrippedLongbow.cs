using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_BlightGrippedLongbow : GiftElvenCompositeLongbow
	{
		[Constructable]
		public Artifact_BlightGrippedLongbow()
		{
			Name = "Blight Gripped Longbow";
			Hue = 0x8A4;
			ItemID = 0x2D1E;
			SkillBonuses.SetValues( 0, SkillName.Poisoning, 15 );
			WeaponAttributes.HitPoisonArea = 20;
			Attributes.RegenStam = 5;
			Attributes.WeaponSpeed = 10;
			Attributes.WeaponDamage = 21;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BlightGrippedLongbow( Serial serial ) : base( serial )
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