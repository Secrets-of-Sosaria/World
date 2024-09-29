using System;
using Server;

namespace Server.Items
{
	public class Artifact_HoodedShroudOfShadows : GiftRobe
	{
		[Constructable]
		public Artifact_HoodedShroudOfShadows()
		{
			ItemID = 0x2B69;
			Hue = 0x455;
			Name = "Shroud of Shadows";
			SkillBonuses.SetValues( 0, SkillName.Hiding, 80 );
			SkillBonuses.SetValues( 1, SkillName.Stealth, 80 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_HoodedShroudOfShadows( Serial serial ) : base( serial )
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
