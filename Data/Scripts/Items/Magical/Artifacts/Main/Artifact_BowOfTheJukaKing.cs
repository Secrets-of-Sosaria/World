using System;
using Server;

namespace Server.Items
{
	public class Artifact_BowOfTheJukaKing : GiftBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BowOfTheJukaKing()
		{
			Name = "Bow of the Juka King";
			Hue = 0x460;
			ItemID = 0x13B2;
			WeaponAttributes.HitMagicArrow = 25;
			Slayer = SlayerName.ReptilianDeath;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_BowOfTheJukaKing( Serial serial ) : base( serial )
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