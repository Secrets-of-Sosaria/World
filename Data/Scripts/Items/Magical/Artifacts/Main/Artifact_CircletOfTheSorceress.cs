using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_CircletOfTheSorceress : GiftLeatherCap
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 12; } } 
		public override int BasePhysicalResistance{ get{ return 2; } } 
		public override int BasePoisonResistance{ get{ return 8; } } 
		public override int BaseFireResistance{ get{ return 12; } } 
      
      [Constructable]
		public Artifact_CircletOfTheSorceress()
		{
			ItemID = 0x672E;
			Resource = CraftResource.None;
			Name = "Circlet Of The Sorceress";
			Hue = 2062;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.SelfRepair = 3;
			Attributes.BonusMana = 15;
			Attributes.LowerManaCost = 6;
			Attributes.LowerRegCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_CircletOfTheSorceress( Serial serial ) : base( serial )
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
			ItemID = 0x672E;
		}
	}
}
