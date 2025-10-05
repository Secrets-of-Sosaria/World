using System;
using Server;

namespace Server.Items
{
	public class Artifact_ShaMontorrossbow : GiftRepeatingCrossbow
	{
		[Constructable]
		public Artifact_ShaMontorrossbow()
		{
			Name = "Shamino's Crossbow";
			Hue = 0x504;
			ItemID = 0x26C3;
			Attributes.AttackChance = 8;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.SelfRepair = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ShaMontorrossbow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}