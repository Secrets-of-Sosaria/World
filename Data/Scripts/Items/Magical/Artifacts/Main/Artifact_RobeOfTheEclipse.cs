using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeOfTheEclipse : GiftRobe
	{
		[Constructable]
		public Artifact_RobeOfTheEclipse()
		{
			ItemID = 0x1F04;
			Name = "Robe of the Eclipse";
			Hue = 0x486;
			Attributes.Luck = 200;
			Resistances.Physical = 10;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			SkillBonuses.SetValues(0, SkillName.Necromancy, 20);
			SkillBonuses.SetValues(1, SkillName.Spiritualism, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_RobeOfTheEclipse( Serial serial ) : base( serial )
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