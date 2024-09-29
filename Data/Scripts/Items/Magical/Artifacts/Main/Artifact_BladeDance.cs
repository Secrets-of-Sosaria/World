using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_BladeDance : GiftRuneBlade
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BladeDance()
		{
			Name = "Blade Dance";
			Hue = 0x66C;

			Attributes.BonusMana = 8;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 30;
			WeaponAttributes.HitLeechMana = 20;
			WeaponAttributes.UseBestSkill = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}
		public Artifact_BladeDance( Serial serial ) : base( serial )
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