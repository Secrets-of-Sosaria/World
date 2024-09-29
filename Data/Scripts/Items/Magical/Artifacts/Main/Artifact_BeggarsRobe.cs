using System;
using Server;

namespace Server.Items
{
	public class Artifact_BeggarsRobe : GiftRobe
	{
      [Constructable]
		public Artifact_BeggarsRobe()
		{
			Name = "Beggar's Robe";
			Hue = 0x978;
			ItemID = 0x567D;
			Attributes.Luck = 100;
			SkillBonuses.SetValues( 0, SkillName.Begging, 30 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_BeggarsRobe( Serial serial ) : base( serial )
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