using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_ArmsOfToxicity : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
      
		[Constructable]
		public Artifact_ArmsOfToxicity()
		{
			Name = "Arms Of Toxicity";
			Hue = 1272;
			ItemID = 0x13cd;
			ArmorAttributes.SelfRepair = 5;
			Attributes.BonusStam = 5;
			Attributes.BonusDex = 4;
			Attributes.AttackChance = 5;
			Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 10;
			PoisonBonus = 15;
			PhysicalBonus = 2;
			FireBonus = 2;
			ColdBonus = 2;
			EnergyBonus = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}
		public Artifact_ArmsOfToxicity( Serial serial ) : base( serial )
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
