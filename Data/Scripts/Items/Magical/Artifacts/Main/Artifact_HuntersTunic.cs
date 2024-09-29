using System;
using Server;

namespace Server.Items
{
	public class Artifact_HuntersTunic : GiftLeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 25; } }

		[Constructable]
		public Artifact_HuntersTunic()
		{
			Name = "Hunter's Tunic";
			Hue = 0x594;
			ItemID = 0x13CC;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 18;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_HuntersTunic( Serial serial ) : base( serial )
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