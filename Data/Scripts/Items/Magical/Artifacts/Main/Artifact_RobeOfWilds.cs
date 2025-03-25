using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeOfWilds : GiftRobe
	{
		[Constructable]
		public Artifact_RobeOfWilds()
		{
			Name = "Robe of the Wilds";
			Hue = 0x3A;
			Attributes.Luck = 100 + (Utility.RandomMinMax(0,3)*50);
			Resistances.Poison = 10;
			SkillBonuses.SetValues(0, SkillName.Druidism,  5 + (Utility.RandomMinMax(0,3)*5));
			SkillBonuses.SetValues(1, SkillName.Taming,  5 + (Utility.RandomMinMax(0,3)*5));
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_RobeOfWilds( Serial serial ) : base( serial )
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