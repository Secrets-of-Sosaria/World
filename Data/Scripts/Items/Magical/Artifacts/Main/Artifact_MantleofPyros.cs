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
			Resistances.Fire = 15;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 7;
			Attributes.LowerRegCost = 7;
			Attributes.RegenStam = 5;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 15);
			SkillBonuses.SetValues(1, SkillName.Focus, 10);
			SkillBonuses.SetValues(2, SkillName.Meditation, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Pyros' Vile Hood" );
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