using System;
using Server;

namespace Server.Items
{
	public class Artifact_DetectiveBoots : GiftBoots
	{
		[Constructable]
		public Artifact_DetectiveBoots()
		{
			Name = "Detective Boots of the Royal Guard";
			Hue = 0x455;
			Attributes.BonusInt = 10;
			SkillBonuses.SetValues( 0, SkillName.Searching, Utility.RandomMinMax(10,25) );
			SkillBonuses.SetValues( 1, SkillName.Psychology, Utility.RandomMinMax(10,25) );
			SkillBonuses.SetValues( 2, SkillName.RemoveTrap, Utility.RandomMinMax(10,25) );
			SkillBonuses.SetValues( 3, SkillName.Lockpicking, Utility.RandomMinMax(10,25) );
			SkillBonuses.SetValues( 4, SkillName.Snooping, Utility.RandomMinMax(10,25) );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_DetectiveBoots( Serial serial ) : base( serial )
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
