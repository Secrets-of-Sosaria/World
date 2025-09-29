using System;
using Server;

namespace Server.Items
{
	public class Artifact_Excalibur : GiftClaymore
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_Excalibur()
		{
			Hue = 0x835;
			Name = "Excalibur";
			ItemID = 0x568F;
			Attributes.BonusStr = 9;
			SkillBonuses.SetValues( 0, SkillName.Knightship, 20 );
			Attributes.AttackChance = 10;
            Slayer = SlayerName.Silver;
            Slayer2 = SlayerName.Exorcism;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "King Arthur's Lost Sword" );
		}

		public Artifact_Excalibur( Serial serial ) : base( serial )
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