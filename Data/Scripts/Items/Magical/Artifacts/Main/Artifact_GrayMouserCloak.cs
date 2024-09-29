using System;
using Server;

namespace Server.Items
{
	public class Artifact_GrayMouserCloak : GiftCloak
	{
		[Constructable]
		public Artifact_GrayMouserCloak()
		{
			Name = "Cloak of the Rogue";
			Hue = 0x967;
			Attributes.BonusDex = 10;
			SkillBonuses.SetValues( 0, SkillName.Stealing, 25 );
			SkillBonuses.SetValues( 1, SkillName.Snooping, 25 );
			SkillBonuses.SetValues( 2, SkillName.RemoveTrap, 80 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "Gray Mouser's Cloak " );
		}

		public Artifact_GrayMouserCloak( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}