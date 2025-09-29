using System;
using Server;

namespace Server.Items
{
	public class Artifact_GiantBlackjack : GiftClub
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_GiantBlackjack()
		{
			Hue = 0x497;
			ItemID = 0x13B4;
			Name = "Giant Blackjack";
			Attributes.BonusStr = 5;
			SkillBonuses.SetValues( 0, SkillName.Bludgeoning, 25 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GiantBlackjack( Serial serial ) : base( serial )
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