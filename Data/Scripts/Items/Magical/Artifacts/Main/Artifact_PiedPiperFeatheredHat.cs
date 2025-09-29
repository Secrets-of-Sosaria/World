using System;
using Server;

namespace Server.Items
{
	public class Artifact_PiedPiperFeatheredHat : GiftFeatheredHat
	{
		[Constructable]
		public Artifact_PiedPiperFeatheredHat()
		{
			Hue = 0x668;
			Name = "Pied Piper's Feathered Hat";
			SkillBonuses.SetValues( 0, SkillName.Musicianship, 10.0);
			SkillBonuses.SetValues( 1, SkillName.Taming,  10.0);
			SkillBonuses.SetValues( 2, SkillName.Herding,  10.0);
			Attributes.BonusDex = 8;
            Attributes.RegenStam = 4;
            Attributes.BonusStam = 6;
			Attributes.Luck = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_PiedPiperFeatheredHat( Serial serial ) : base( serial )
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