using System;
using Server;

namespace Server.Items
{
	public class Artifact_BurglarsBandana : GiftBandana
	{
		[Constructable]
		public Artifact_BurglarsBandana()
		{
			Hue = Utility.RandomBool() ? 0x58C : 0x10;
			Name = "Burglar's Bandana";
			SkillBonuses.SetValues( 0, SkillName.Stealing, 10.0 );
			SkillBonuses.SetValues( 1, SkillName.Stealth, 10.0 );
			SkillBonuses.SetValues( 2, SkillName.Snooping, 10.0 );
			Attributes.BonusDex = 5;
			Attributes.Luck = 80;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BurglarsBandana( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}