using System;
using Server;

namespace Server.Items
{
	public class Artifact_EmbroideredOakLeafCloak : GiftCloak
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_EmbroideredOakLeafCloak() : base( 0x2684 )
		{
			Name = "Embroidered Oak Leaf Cloak";
			Hue = 0x483;
			SkillBonuses.SetValues( 0, SkillName.Hiding, 50 );
			SkillBonuses.SetValues( 1, SkillName.Stealth, 50 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_EmbroideredOakLeafCloak( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
