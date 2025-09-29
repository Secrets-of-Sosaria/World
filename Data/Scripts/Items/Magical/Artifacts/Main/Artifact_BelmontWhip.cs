using System;
using Server;

namespace Server.Items
{
	public class Artifact_BelmontWhip : GiftWhips
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BelmontWhip()
		{
			Hue = 0x986;
			Name = "Vampire Killer";
			ItemID = 0x6453;
			Attributes.BonusStr = 9;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.AttackChance = 10;
            Slayer = SlayerName.Silver;
            Slayer2 = SlayerName.Exorcism;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Simon Belmonts's Whip " );
		}

		public Artifact_BelmontWhip( Serial serial ) : base( serial )
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