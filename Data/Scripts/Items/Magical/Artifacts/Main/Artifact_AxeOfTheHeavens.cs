using System;
using Server;

namespace Server.Items
{
	public class Artifact_AxeOfTheHeavens : GiftDoubleAxe
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_AxeOfTheHeavens()
		{
			Name = "Axe of the Heavens";
			Hue = 0x4D5;
			ItemID = 0xF4B;
			WeaponAttributes.HitLightning = 50;
			Attributes.AttackChance = 15;
			Attributes.DefendChance = 15;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_AxeOfTheHeavens( Serial serial ) : base( serial )
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