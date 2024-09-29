using System;
using Server;

namespace Server.Items
{
	public class Artifact_BloodwoodSpirit : GiftTalismanLeather
	{
		[Constructable]
		public Artifact_BloodwoodSpirit()
		{
			Name = "Bloodwood Spirit";
			ItemID = 0x2C95;
			Hue = 0x27;
			SkillBonuses.SetValues( 0, SkillName.Spiritualism, 30.0 );
			SkillBonuses.SetValues( 1, SkillName.Necromancy, 20.0 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_BloodwoodSpirit( Serial serial ) :  base( serial )
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
