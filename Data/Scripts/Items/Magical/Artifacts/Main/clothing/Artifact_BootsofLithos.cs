using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class Artifact_BootsofLithos : GiftBoots
	{
		[Constructable]
		public Artifact_BootsofLithos()
		{
			ItemID = 0x2FC4;
			Name = "Boots of the Mountain King";
			Hue = 0x85D;
			Resistances.Poison = 15;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 12;
			Attributes.LowerRegCost = 12;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 15);
			SkillBonuses.SetValues(1, SkillName.Focus, 10);
			SkillBonuses.SetValues(2, SkillName.Meditation, 10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Lithos' Mystical Boots" );
		}

		public Artifact_BootsofLithos( Serial serial ) : base( serial )
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