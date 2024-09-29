using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_SilvanisFeywoodBow : GiftElvenCompositeLongbow
	{
		[Constructable]
		public Artifact_SilvanisFeywoodBow()
		{
			Hue = 0x1A;
			Name = "Silvani's Feywood Bow";
			ItemID = 0x2D1E;

			Attributes.SpellChanneling = 1;
			Attributes.AttackChance = 12;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 35;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}

		public Artifact_SilvanisFeywoodBow( Serial serial ) : base( serial )
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