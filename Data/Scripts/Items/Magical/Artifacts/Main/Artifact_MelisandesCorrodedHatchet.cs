using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_MelisandesCorrodedHatchet : GiftHatchet
	{
		[Constructable]
		public Artifact_MelisandesCorrodedHatchet()
		{
			Hue = 0x494;
			Name = "Melisande's Corroded Hatchet";
			ItemID = 0xF43;
			SkillBonuses.SetValues( 0, SkillName.Lumberjacking, 5.0 );

			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 15;
			Attributes.WeaponDamage = -50;

			WeaponAttributes.SelfRepair = 4;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_MelisandesCorrodedHatchet( Serial serial ) : base( serial )
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