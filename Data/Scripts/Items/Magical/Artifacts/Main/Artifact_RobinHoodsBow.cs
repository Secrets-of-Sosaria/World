using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobinHoodsBow : GiftCompositeBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_RobinHoodsBow()
		{
			Hue = 0x483;
			Name = "Robin Hood's Bow";
			ItemID = 0x13B2;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 20 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			Attributes.AttackChance = 5;
			Attributes.Luck = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_RobinHoodsBow( Serial serial ) : base( serial )
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