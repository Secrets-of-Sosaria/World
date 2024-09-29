using System;
using Server;

namespace Server.Items
{
	public class Artifact_MantleofPyros : GiftWizardsHat
	{
		[Constructable]
		public Artifact_MantleofPyros()
		{
			ItemID = 0x5C14;
			Name = "Mantle of the Daemon King";
			Hue = 0x981;
			Resistances.Physical = 8;
			Resistances.Fire = 16;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 15;
			Attributes.RegenStam = 2;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 15);
			SkillBonuses.SetValues(1, SkillName.Focus, 10);
			SkillBonuses.SetValues(2, SkillName.Meditation, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "Pyros' Vile Hood" );
		}

		public Artifact_MantleofPyros( Serial serial ) : base( serial )
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