using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class Artifact_BootsofHydros : GiftBoots
	{
		[Constructable]
		public Artifact_BootsofHydros()
		{
			ItemID = 0x2FC4;
			Name = "Boots of the Lurker";
			Hue = 0x97F;
			Resistances.Physical = 8;
			Resistances.Cold = 16;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 15;
			Attributes.RegenStam = 2;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 15);
			SkillBonuses.SetValues(1, SkillName.Focus, 10);
			SkillBonuses.SetValues(2, SkillName.Meditation, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "Hydros' Enchanted Boots" );
		}

		public Artifact_BootsofHydros( Serial serial ) : base( serial )
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