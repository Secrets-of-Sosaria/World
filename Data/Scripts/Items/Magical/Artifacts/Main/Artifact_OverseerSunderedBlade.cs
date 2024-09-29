using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_OverseerSunderedBlade : GiftRadiantScimitar
	{
		[Constructable]
		public Artifact_OverseerSunderedBlade()
		{
			ItemID = 0x2D27;
			Hue = 0x485;
			Name = "Overseer Sundered Blade";
			Attributes.RegenStam = 2;
			Attributes.AttackChance = 10;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 45;

			Hue = this.GetElementalDamageHue();
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public Artifact_OverseerSunderedBlade( Serial serial ) : base( serial )
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