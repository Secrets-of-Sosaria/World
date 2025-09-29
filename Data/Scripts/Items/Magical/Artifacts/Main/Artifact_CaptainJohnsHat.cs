using System;
using Server;

namespace Server.Items
{
	public class Artifact_CaptainJohnsHat : GiftTricorneHat
	{
		public override int BaseEnergyResistance{ get{ return 23; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_CaptainJohnsHat()
		{
			Hue = 0x455;
			Name = "Captain John's Hat";
			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 15;
			SkillBonuses.Skill_1_Name = SkillName.Swords;
			SkillBonuses.Skill_1_Value = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_CaptainJohnsHat( Serial serial ) : base( serial )
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
