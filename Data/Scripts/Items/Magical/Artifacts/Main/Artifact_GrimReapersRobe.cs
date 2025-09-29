using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class Artifact_GrimReapersRobe : GiftRobe
	{
		[Constructable]
		public Artifact_GrimReapersRobe()
		{
			ItemID = 0x1F03;
			Name = "Grim Reaper's Robe";
			Hue = 0xAF0;
			Attributes.ReflectPhysical = 25;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, 10 );
			Attributes.LowerRegCost = 10;
			Attributes.DefendChance = 5;
			Attributes.Luck = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GrimReapersRobe( Serial serial ) : base( serial )
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