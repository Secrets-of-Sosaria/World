using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_ShardThrasher : GiftDiamondMace
	{
		[Constructable]
		public Artifact_ShardThrasher()
		{
			Hue = 0x4F2;
			Name = "Shard Thrasher";
			ItemID = 0x2D24;

			WeaponAttributes.HitPhysicalArea = 30;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 10;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ShardThrasher( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}