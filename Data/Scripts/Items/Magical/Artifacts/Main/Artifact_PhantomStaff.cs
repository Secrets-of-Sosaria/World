using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_PhantomStaff : GiftWildStaff
	{
		[Constructable]
		public Artifact_PhantomStaff()
		{
			Hue = 0x1;
			Name = "Phantom Staff";
			Attributes.RegenHits = 2;
			Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 60;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = nrgy = chaos = direct = 0;
			cold = pois = 50;
		}

		public Artifact_PhantomStaff( Serial serial ) : base( serial )
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