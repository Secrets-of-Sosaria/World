using System;
using Server;

namespace Server.Items
{
	public class Artifact_HuntersGorget : GiftLeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_HuntersGorget()
		{
			Name = "Hunter's Gorget";
			Hue = 0x594;
			ItemID = 0x13C7;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			Attributes.BonusDex = 6;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_HuntersGorget( Serial serial ) : base( serial )
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