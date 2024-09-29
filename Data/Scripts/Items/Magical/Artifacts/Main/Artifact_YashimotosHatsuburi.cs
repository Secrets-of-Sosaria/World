using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_YashimotosHatsuburi : GiftChainHatsuburi
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 5; } } 
		public override int BaseEnergyResistance{ get{ return 2; } } 
		public override int BasePhysicalResistance{ get{ return 7; } } 
		public override int BasePoisonResistance{ get{ return 3; } } 
		public override int BaseFireResistance{ get{ return 7; } } 
      
		[Constructable]
		public Artifact_YashimotosHatsuburi()
		{
			Name = "Yashimoto's Hatsuburi";
			Hue = 1157;
			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.SelfRepair = 5;
			Attributes.AttackChance = 15;
			Attributes.DefendChance = 15;
			Attributes.RegenHits = 10;
			Attributes.WeaponDamage = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_YashimotosHatsuburi( Serial serial ) : base( serial )
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
