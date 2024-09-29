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
			Attributes.BonusHits = 4;
			Attributes.RegenHits = 7;
			SkillBonuses.SetValues( 0, SkillName.Healing, 25 );
			SkillBonuses.SetValues( 1, SkillName.Veterinary, 25 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
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