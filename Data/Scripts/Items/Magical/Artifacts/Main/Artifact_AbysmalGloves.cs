using System;
using Server;

namespace Server.Items
{
	public class Artifact_AbysmalGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_AbysmalGloves()
		{
			Hue = 1172;
			ItemID = 0x13C6;
			Name = "Abysmal Gloves";
			ColdBonus = 3;
			EnergyBonus = 9;
			PhysicalBonus = 7;
			PoisonBonus = 7;
			FireBonus = 10;
			ArmorAttributes.SelfRepair = 10;
			Attributes.BonusInt = 5;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 10;
			Attributes.SpellDamage = 35;
			Attributes.RegenMana = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "" );
		}

		public Artifact_AbysmalGloves( Serial serial ) : base( serial )
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
