using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_FleshRipper : GiftAssassinSpike
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_FleshRipper()
		{
			Name = "Flesh Ripper";
			Hue = 0x341;
			ItemID = 0x2D21;

			SkillBonuses.SetValues( 0, SkillName.Anatomy, 10.0 );

			Attributes.BonusStr = 5;
			Attributes.AttackChance = 15;
			Attributes.WeaponSpeed = 40;

			WeaponAttributes.UseBestSkill = 1;
			Slayer = SlayerName.Repond;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_FleshRipper( Serial serial ) : base( serial )
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