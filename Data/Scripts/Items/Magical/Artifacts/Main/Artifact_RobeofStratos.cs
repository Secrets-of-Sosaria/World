using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeofStratos : GiftRobe
	{
		[Constructable]
		public Artifact_RobeofStratos()
		{
			ItemID = 0x2B6A;
			Name = "Robe of the Mystic Voice";
			Hue = 0xAFE;
			Resistances.Physical = 8;
			Resistances.Energy = 16;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 20;
			Attributes.LowerRegCost = 20;
			Attributes.RegenStam = 4;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 20);
			SkillBonuses.SetValues(1, SkillName.Focus, 15);
			SkillBonuses.SetValues(2, SkillName.Meditation, 15);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "Stratos' Magical Robe" );
		}

		public Artifact_RobeofStratos( Serial serial ) : base( serial )
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