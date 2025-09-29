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
			WeaponAttributes.HitColdArea = 10;
			WeaponAttributes.HitEnergyArea = 10;
			WeaponAttributes.HitFireArea = 10;
			WeaponAttributes.HitPhysicalArea = 10;
			WeaponAttributes.HitPoisonArea = 10;
			WeaponAttributes.UseBestSkill = 1;
			Attributes.AttackChance = 14;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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
