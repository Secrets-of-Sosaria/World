using System;
using Server;

namespace Server.Items
{
	public class Artifact_DreadPirateHat : GiftTricorneHat
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 14; } }
		public override int BasePoisonResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_DreadPirateHat()
		{
			Hue = 0x497;
			Name = "Dread Pirate Hat";
			SkillBonuses.SetValues( 0, SkillName.Seafaring, 20 );
			SkillBonuses.SetValues( 1, SkillName.Cartography, 20 );
			SkillBonuses.SetValues( 2, SkillName.Swords, 10 );
			SkillBonuses.SetValues( 3, SkillName.Tactics, 10 );
			Attributes.BonusDex = 8;
			Attributes.AttackChance = 10;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_DreadPirateHat( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();

			if ( version < 3 )
			{
				Resistances.Cold = 0;
				Resistances.Poison = 0;
			}

			if ( version < 1 )
			{
				Attributes.Luck = 0;
				Attributes.AttackChance = 10;
				Attributes.NightSight = 1;
				SkillBonuses.SetValues( 0, Utility.RandomCombatSkill(), 10.0 );
				SkillBonuses.SetBonus( 1, 0 );
			}
		}
	}
}