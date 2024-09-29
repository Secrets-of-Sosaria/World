using System;
using Server;

namespace Server.Items
{
	public class Artifact_HuntersLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 25; } }

		[Constructable]
		public Artifact_HuntersLeggings()
		{
			Name = "Hunter's Leggings";
			Hue = 0x594;
			ItemID = 0x13cb;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 16;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_HuntersLeggings( Serial serial ) : base( serial )
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