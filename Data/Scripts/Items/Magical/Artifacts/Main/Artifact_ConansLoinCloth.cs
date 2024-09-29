using System;
using Server;

namespace Server.Items
{
	public class Artifact_ConansLoinCloth : GiftBelt
	{
		[Constructable]
		public Artifact_ConansLoinCloth()
		{
			Hue = 0x978;
			ItemID = 0x2B68;
			Name = "Loin Cloth of the Cimmerian";
			Attributes.BonusStr = 10;
			SkillBonuses.SetValues( 0, SkillName.Swords, 10 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "Conan's Loin Cloth " );
		}

		public Artifact_ConansLoinCloth( Serial serial ) : base( serial )
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