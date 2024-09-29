using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class Artifact_GrimReapersMask : GiftWizardsHat
	{
		[Constructable]
		public Artifact_GrimReapersMask()
		{
			Hue = 0x47E;
			ItemID = 0x1451;
			Name = "Grim Reaper's Mask";
			Resistances.Physical = 15;
			Resistances.Fire = 10;
			Resistances.Cold = 10;
			Resistances.Poison = 10;
			Resistances.Energy = 10;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, 10 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_GrimReapersMask( Serial serial ) : base( serial )
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