using System;
using Server;

namespace Server.Items
{
	public class Artifact_VampiresRobe : GiftRobe
	{
      [Constructable]
		public Artifact_VampiresRobe()
		{
			Name = "Nosferatu's Robe";
			Hue = 0x497;
			ItemID = 0x201D;
			Attributes.BonusHits = 50;
			SkillBonuses.SetValues( 0, SkillName.Spiritualism, 20 );
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 20 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_VampiresRobe( Serial serial ) : base( serial )
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