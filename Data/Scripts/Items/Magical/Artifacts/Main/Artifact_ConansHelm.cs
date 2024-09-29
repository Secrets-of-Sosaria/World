using System;
using Server;

namespace Server.Items
{
	public class Artifact_ConansHelm : GiftPlateHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ConansHelm()
		{
			ItemID = 0x2645;
			Hue = 0x835;
			Name = "Helm of the Cimmerian";
			Attributes.BonusStr = 5;
			SkillBonuses.SetValues( 0, SkillName.Swords, 5 );
			Attributes.DefendChance = 30;
			PhysicalBonus = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "Conan's Lost Helm " );
		}

		public Artifact_ConansHelm( Serial serial ) : base( serial )
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