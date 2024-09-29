using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_TheNightReaper : GiftRepeatingCrossbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TheNightReaper()
		{
			Name = "Night Reaper";
			ItemID = 0x26CD;
			Hue = 0x41C;

			Slayer = SlayerName.Exorcism;
			Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 55;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_TheNightReaper( Serial serial ) : base( serial )
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