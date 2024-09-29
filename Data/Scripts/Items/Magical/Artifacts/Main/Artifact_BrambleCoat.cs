using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_BrambleCoat : GiftLeatherChest
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_BrambleCoat()
		{
			Hue = 0x1;
			Name = "Bramble Coat";
			ItemID = 0x13CC;
			ArmorAttributes.SelfRepair = 3;
			Attributes.BonusHits = 4;
			Attributes.Luck = 150;
			Attributes.ReflectPhysical = 25;
			Attributes.DefendChance = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
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