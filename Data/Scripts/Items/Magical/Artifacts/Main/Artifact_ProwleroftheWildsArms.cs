using System;
using Server;

namespace Server.Items
{
	public class Artifact_ProwleroftheWildsArms : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 9; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 8; } }

		[Constructable]
		public Artifact_ProwleroftheWildsArms()
		{
			Name = "Arms of the Prowler";
			Hue = 0x30A;
			ArtifactLevel = 2;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5);
			SkillBonuses.SetValues( 1, SkillName.Taming, 10);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 10);
			SkillBonuses.SetValues( 3, SkillName.Stealth, 5);
			Attributes.AttackChance = 5;
			Attributes.WeaponSpeed = 5;
			Attributes.WeaponDamage = 5;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 9;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ProwleroftheWildsArms( Serial serial ) : base( serial )
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