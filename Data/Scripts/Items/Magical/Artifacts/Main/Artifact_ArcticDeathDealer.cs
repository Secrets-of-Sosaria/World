using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcticDeathDealer : GiftWarMace
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcticDeathDealer()
		{
			Name = "Arctic Death Dealer";
			Hue = 0xB3E;
			ItemID = 0x1407;
			WeaponAttributes.HitHarm = 33;
			WeaponAttributes.HitLowerAttack = 40;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.ResistColdBonus = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = 50;
			phys = 50;

			pois = fire = nrgy = chaos = direct = 0;
		}

		public Artifact_ArcticDeathDealer( Serial serial ) : base( serial )
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