using System;
using Server;

namespace Server.Items
{
	public class Artifact_MantleofStratos : GiftWizardsHat
	{
		[Constructable]
		public Artifact_MantleofStratos()
		{
			ItemID = 0x5C14;
			Name = "Mantle of the Mystic Voice";
			Hue = 0xAFE;
			Resistances.Physical = 8;
			Resistances.Energy = 16;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 15;
			Attributes.RegenStam = 2;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 15);
			SkillBonuses.SetValues(1, SkillName.Focus, 10);
			SkillBonuses.SetValues(2, SkillName.Meditation, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "Stratos' Magical Hood" );
		}

		public Artifact_MantleofStratos( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}