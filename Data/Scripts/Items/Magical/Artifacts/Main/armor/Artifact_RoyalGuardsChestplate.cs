using System;
using Server;

namespace Server.Items
{
	public class Artifact_RoyalGuardsChestplate : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_RoyalGuardsChestplate()
		{
			Name = "Royal Guard's Chest Plate";
			Hue = 0x47E;
			ItemID = 0x1415;
			Attributes.BonusHits = 12;
			Attributes.BonusMana = 12;
			Attributes.BonusStam = 12;
			Attributes.RegenHits = 12;
			Attributes.ReflectPhysical = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_RoyalGuardsChestplate( Serial serial ) : base( serial )
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