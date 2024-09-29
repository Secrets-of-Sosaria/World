using System;
using Server;

namespace Server.Items
{
	public class Artifact_SinbadsSword : GiftCutlass
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_SinbadsSword()
		{
			Hue = 0x491;
			ItemID = 0x1441;
			Name = "Sword of Sinbad";
			Attributes.BonusDex = 10;
			SkillBonuses.SetValues( 0, SkillName.Cartography, 30 );
			SkillBonuses.SetValues( 1, SkillName.Seafaring, 30 );
			SkillBonuses.SetValues( 2, SkillName.Lockpicking, 30 );
			Quality = WeaponQuality.Exceptional;
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_SinbadsSword( Serial serial ) : base( serial )
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