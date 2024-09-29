using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_JadeScimitar : GiftScimitar
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_JadeScimitar()
		{
			Name = "Jade Scimitar";
			Hue = 2964;
			ItemID = 0x13B6;
			WeaponAttributes.HitColdArea = 30;
			WeaponAttributes.HitEnergyArea = 25;
			WeaponAttributes.HitFireArea = 30;
			WeaponAttributes.HitPhysicalArea = 50;
			WeaponAttributes.HitPoisonArea = 20;
			WeaponAttributes.UseBestSkill = 1;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 15, "" );
		}

		public Artifact_JadeScimitar( Serial serial ) : base( serial )
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
