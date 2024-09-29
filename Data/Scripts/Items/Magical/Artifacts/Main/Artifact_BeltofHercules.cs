using System;
using Server;

namespace Server.Items
{
	public class Artifact_BeltofHercules : GiftBelt
	{
		[Constructable]
		public Artifact_BeltofHercules()
		{
			Hue = 0xB54;
			ItemID = 0x2790;
			Name = "Belt of Hercules";
			Attributes.BonusStr = 30;
			SkillBonuses.SetValues( 0, SkillName.FistFighting, 50 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BeltofHercules( Serial serial ) : base( serial )
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