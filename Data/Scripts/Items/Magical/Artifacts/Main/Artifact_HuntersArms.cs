using System;
using Server;

namespace Server.Items
{
	public class Artifact_HuntersArms : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 15; } }

		[Constructable]
		public Artifact_HuntersArms()
		{
			Name = "Hunter's Arms";
			Hue = 0x594;
			ItemID = 0x13cd;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			Attributes.BonusDex = 4;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_HuntersArms( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}