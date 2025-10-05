using System;
using Server;

namespace Server.Items
{
	public class Artifact_ProwleroftheWildsTunic : GiftOniwabanTunic
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 8; } }

		[Constructable]
		public Artifact_ProwleroftheWildsTunic()
		{
			Name = "Tunic of the Prowler";
			Hue = 0x30A;
			ArtifactLevel = 2;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 15);
			SkillBonuses.SetValues( 1, SkillName.Taming, 15);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 15);
			SkillBonuses.SetValues( 3, SkillName.Stealth, 15);
			Attributes.AttackChance = 5;
			Attributes.WeaponDamage = 2;
			Attributes.BonusStr = 5;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ProwleroftheWildsTunic( Serial serial ) : base( serial )
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