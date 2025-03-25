using System;
using Server;

namespace Server.Items
{
	public class Artifact_GlovesOfThePiper : GiftStuddedGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_GlovesOfThePiper()
		{
			Name = "Gloves of The Pied Piper";
			Hue = 0x668;
			SkillBonuses.SetValues( 0, SkillName.Musicianship,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Peacemaking,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Herding,  10.0 + (Utility.RandomMinMax(0,2)*5) );
			Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,2)*5);
            Attributes.RegenStam = 2;
            Attributes.BonusStam = 8;
            Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_GlovesOfThePiper( Serial serial ) : base( serial )
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