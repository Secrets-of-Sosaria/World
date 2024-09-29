using System;
using Server;

namespace Server.Items
{
	public class Artifact_CavortingClub : GiftClub
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_CavortingClub()
		{
			Name = "Cavorting Club";
			Hue = 0x593;
			ItemID = 0x13B4;
			WeaponAttributes.SelfRepair = 3;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.ResistFireBonus = 8;
			WeaponAttributes.ResistColdBonus = 8;
			WeaponAttributes.ResistPoisonBonus = 8;
			WeaponAttributes.ResistEnergyBonus = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_CavortingClub( Serial serial ) : base( serial )
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