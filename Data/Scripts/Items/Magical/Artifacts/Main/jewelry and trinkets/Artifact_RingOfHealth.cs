using System;
using Server;

namespace Server.Items
{
	public class Artifact_RingOfHealth : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfHealth()
		{
			Name = "Ring of Health";
			Hue = 0x21;
			ItemID = 0x6731;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 5;
			Attributes.Luck = 50;
			SkillBonuses.SetValues( 0, SkillName.Healing, 25 );
			SkillBonuses.SetValues( 1, SkillName.Anatomy, 25 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_RingOfHealth( Serial serial ) : base( serial )
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