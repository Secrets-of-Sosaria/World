using System;
using Server;

namespace Server.Items
{
	public class Artifact_TrousersOfThePiper : GiftLongPants
	{

		[Constructable]
		public Artifact_TrousersOfThePiper()
		{
			Name = "Trousers of The Pied Piper";
			Hue = 0x668;
			SkillBonuses.SetValues( 0, SkillName.Musicianship,  10.0);
			SkillBonuses.SetValues( 1, SkillName.Peacemaking,  10.0);
			SkillBonuses.SetValues( 2, SkillName.Herding,  10.0);
			Attributes.DefendChance = 5;
            Attributes.RegenStam = 13;
            Attributes.BonusStam = 13;
            Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TrousersOfThePiper( Serial serial ) : base( serial )
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