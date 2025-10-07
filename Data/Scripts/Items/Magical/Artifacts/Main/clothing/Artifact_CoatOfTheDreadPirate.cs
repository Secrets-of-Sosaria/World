using System;
using Server;

namespace Server.Items
{
	public class Artifact_CoatOfTheDreadPirate : GiftRobe
	{
		[Constructable]
		public Artifact_CoatOfTheDreadPirate()
		{
			ItemID = 0x567E;
			Name = "Coat of the Dread Pirate";
			Hue = 0x497;
			Resistances.Cold = 15;
			Resistances.Physical = 5;
			Attributes.BonusDex = 5;
			Attributes.BonusStr = 5;
			SkillBonuses.SetValues(0, SkillName.Seafaring, 20);
			SkillBonuses.SetValues(1, SkillName.Cartography, 10);
			Attributes.WeaponDamage = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_CoatOfTheDreadPirate( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}