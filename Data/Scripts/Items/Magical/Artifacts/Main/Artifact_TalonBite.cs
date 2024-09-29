using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_TalonBite : GiftOrnateAxe
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TalonBite()
		{
			ItemID = 0x2D34;
			Hue = 0x47E;
			Name = "Talon Bite";

			SkillBonuses.SetValues( 0, SkillName.Tactics, 10.0 );

			Attributes.BonusDex = 8;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 35;

			WeaponAttributes.HitHarm = 33;
			WeaponAttributes.UseBestSkill = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_TalonBite( Serial serial ) : base( serial )
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