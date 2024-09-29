using System;
using Server;

namespace Server.Items
{
	public class Artifact_ColdBlood : GiftCleaver
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ColdBlood()
		{
			Hue = 0x4F2;
			ItemID = 0x2AB6;
			Name = "Cold Blood";
			Attributes.WeaponSpeed = 40;

			Attributes.BonusHits = 6;
			Attributes.BonusStam = 6;
			Attributes.BonusMana = 6;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = 100;
			fire = phys = pois = nrgy = chaos = direct = 0;
		}

		public Artifact_ColdBlood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}