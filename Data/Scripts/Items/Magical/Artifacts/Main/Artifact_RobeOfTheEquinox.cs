using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeOfTheEquinox : GiftRobe
	{
		[Constructable]
		public Artifact_RobeOfTheEquinox()
		{
			ItemID = 0x1F04;
			Name = "Robe of the Equinox";
			Hue = 0xD6;
			Attributes.Luck = 200;
			Resistances.Physical = 10;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			SkillBonuses.SetValues(0, SkillName.Magery, 20);
			SkillBonuses.SetValues(1, SkillName.Psychology, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_RobeOfTheEquinox( Serial serial ) : base( serial )
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