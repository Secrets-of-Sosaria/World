using System;
using Server;

namespace Server.Items
{
	public class Artifact_BlazeOfDeath : GiftHalberd
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BlazeOfDeath()
		{
			Name = "Blaze of Death";
			Hue = 0x501;
			ItemID = 0x143E;
			WeaponAttributes.HitFireArea = 50;
			WeaponAttributes.HitFireball = 50;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.ResistFireBonus = 10;
			WeaponAttributes.LowerStatReq = 100;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = 50;
			phys = 50;

			cold = pois = nrgy = chaos = direct = 0;
		}

		public Artifact_BlazeOfDeath( Serial serial ) : base( serial )
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