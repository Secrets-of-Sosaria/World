using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeOfWildLegion : GiftRobe
	{
		[Constructable]
		public Artifact_RobeOfWildLegion()
		{
			Name = "Robe of the Wild Legion";
			Hue = 0x8A0;
			Attributes.Luck = 110;
			Resistances.Poison = 10;
			SkillBonuses.SetValues(0, SkillName.Herding,  10);
			SkillBonuses.SetValues(1, SkillName.Taming,  10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_RobeOfWildLegion( Serial serial ) : base( serial )
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