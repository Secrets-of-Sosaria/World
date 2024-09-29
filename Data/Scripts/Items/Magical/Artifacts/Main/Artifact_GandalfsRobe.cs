using System;
using Server;

namespace Server.Items
{
	public class Artifact_GandalfsRobe : GiftRobe
	{
		[Constructable]
		public Artifact_GandalfsRobe()
		{
			Hue = 0xB89;
			ItemID = 0x26AE;
			Name = "Merlin's Mystical Robe";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Psychology, 10 );
			SkillBonuses.SetValues( 1, SkillName.Magery, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_GandalfsRobe( Serial serial ) : base( serial )
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