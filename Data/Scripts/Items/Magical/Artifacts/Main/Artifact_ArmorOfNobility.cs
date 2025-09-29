using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmorOfNobility : GiftRingmailChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmorOfNobility()
		{
			Name = "Armor of Nobility";
			Hue = 0x4FE;
			Attributes.BonusStr = 8;
			Attributes.Luck = 100;
			Attributes.WeaponDamage = 4;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArmorOfNobility( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}