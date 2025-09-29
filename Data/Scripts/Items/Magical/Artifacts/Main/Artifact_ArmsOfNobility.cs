using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmsOfNobility : GiftRingmailArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmsOfNobility()
		{
			Name = "Arms of Nobility";
			Hue = 0x4FE;
			Attributes.BonusStr = 8;
			Attributes.Luck = 80;
			Attributes.WeaponDamage = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArmsOfNobility( Serial serial ) : base( serial )
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