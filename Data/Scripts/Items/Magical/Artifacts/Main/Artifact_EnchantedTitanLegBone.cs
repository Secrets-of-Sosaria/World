using System;
using Server;

namespace Server.Items
{
	public class Artifact_EnchantedTitanLegBone : GiftShortSpear
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_EnchantedTitanLegBone()
		{
			Name = "Enchanted Pirate Rapier";
			Hue = 0x8A5;
			ItemID = 0x1403;
			WeaponAttributes.HitLowerDefend = 40;
			WeaponAttributes.HitLightning = 40;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 20;
			WeaponAttributes.ResistPhysicalBonus = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_EnchantedTitanLegBone( Serial serial ) : base( serial )
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

			if ( Name == "Enchanted Titan Leg Bone" ){ Name = "Enchanted Pirate Rapier"; }
		}
	}
}