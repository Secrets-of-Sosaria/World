using System;
using Server;

namespace Server.Items
{
	public class Artifact_EvilMageGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseFireResistance{ get{ return 12; } } 
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 11; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

	 	[Constructable]
	 	public Artifact_EvilMageGloves()
	 	{
	 	 	Name = "Evil Mage Gloves";
	 	 	Hue = 0x8E4;
			ItemID = 0x13C6;
	 	 	Attributes.DefendChance = 10;
	 	 	Attributes.LowerManaCost = 8;
	 	 	Attributes.LowerRegCost = 15;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.BonusMana = 5;
	 	 	Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

	 	public Artifact_EvilMageGloves(Serial serial) : base( serial )
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
