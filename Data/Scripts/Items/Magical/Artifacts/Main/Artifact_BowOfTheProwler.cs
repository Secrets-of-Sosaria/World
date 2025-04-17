using System;
using Server;

namespace Server.Items
{
	public class Artifact_BowOfTheProwler : GiftBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BowOfTheProwler()
		{
			Name = "Bow of the Prowler";
			Hue = 0x30A;
			Slayer = SlayerName.Repond;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.HitLeechStam = 40;
			WeaponAttributes.HitLeechHits = 40;
			SkillBonuses.SetValues(0, SkillName.Marksmanship,  5 + (Utility.RandomMinMax(0,2)*5));
			SkillBonuses.SetValues(1, SkillName.Hiding,  5 + (Utility.RandomMinMax(0,2)*5));
			SkillBonuses.SetValues(2, SkillName.Stealth,  5 + (Utility.RandomMinMax(0,2)*5));
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_BowOfTheProwler( Serial serial ) : base( serial )
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