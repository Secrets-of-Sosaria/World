using System;
using Server;

namespace Server.Items
{
	public class Artifact_BootsOfThePiper : GiftBoots
	{

		[Constructable]
		public Artifact_BootsOfThePiper()
		{
			Name = "Boots of The Pied Piper";
			Hue = 0x668;
			SkillBonuses.SetValues( 0, SkillName.Musicianship,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Provocation,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Herding,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,2)*5);
            Attributes.RegenStam = 2;
            Attributes.BonusStam = 8;
            Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_BootsOfThePiper( Serial serial ) : base( serial )
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