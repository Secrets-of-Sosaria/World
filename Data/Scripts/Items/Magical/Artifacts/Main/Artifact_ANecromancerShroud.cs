using System;
using Server;

namespace Server.Items
{
	public class Artifact_ANecromancerShroud : GiftRobe
	{
		public override int BaseColdResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		[Constructable]
		public Artifact_ANecromancerShroud()
		{
			Name = "Necromancer Shroud";
			Hue = 0x2FBA;
			Attributes.BonusMana = 50;
			SkillBonuses.SetValues( 0, SkillName.Spiritualism, 25 );
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 25 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ANecromancerShroud( Serial serial ) : base( serial )
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
