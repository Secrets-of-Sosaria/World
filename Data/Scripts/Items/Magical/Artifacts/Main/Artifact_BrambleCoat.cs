using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_BrambleCoat : GiftLeatherChest
	{
		[Constructable]
		public Artifact_BrambleCoat()
		{
			Hue = 0x1;
			Name = "Bramble Coat";
			ItemID = 0x13CC;
			ArmorAttributes.SelfRepair = 5;
			Attributes.BonusHits = 6;
			Attributes.Luck = 75;
			Attributes.ReflectPhysical = 25;
			PhysicalBonus = 10;
			FireBonus = 5;
			PoisonBonus = 5;
			ColdBonus = 5;
			EnergyBonus = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BrambleCoat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}