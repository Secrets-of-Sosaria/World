using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmorOfInsight : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmorOfInsight()
		{
			Name = "Armor of Insight";
			Hue = 0x554;
			ItemID = 0x1415;
			Attributes.BonusInt = 8;
			Attributes.BonusMana = 11;
			Attributes.RegenMana = 7;
			Attributes.LowerManaCost = 8;
			ArmorAttributes.MageArmor = 1;
			EnergyBonus = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArmorOfInsight( Serial serial ) : base( serial )
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