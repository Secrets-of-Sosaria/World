using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_GlovesOfRegeneration : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 8; } } 
		public override int BaseEnergyResistance{ get{ return 10; } } 
		public override int BasePhysicalResistance{ get{ return 15; } } 
		public override int BasePoisonResistance{ get{ return 15; } } 
		public override int BaseFireResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_GlovesOfRegeneration()
		{
			Name = "Gloves Of Regeneration";
			Hue = 1284;
			ItemID = 0x13C6;
			Attributes.RegenHits = 15;
			Attributes.RegenMana = 15;
			Attributes.RegenStam = 15;
			ArmorAttributes.SelfRepair = 5;
			ArmorAttributes.DurabilityBonus = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GlovesOfRegeneration( Serial serial ) : base( serial )
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
