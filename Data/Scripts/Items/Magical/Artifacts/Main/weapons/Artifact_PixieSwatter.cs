using System;
using Server;

namespace Server.Items
{
	public class Artifact_PixieSwatter : GiftScepter
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_PixieSwatter()
		{
			Name = "Pixie Swatter";
			Hue = 0x8A;
			WeaponAttributes.HitPoisonArea = 55;
			Attributes.WeaponSpeed = 10;
			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.ResistFireBonus = 10;
			WeaponAttributes.ResistEnergyBonus = 10;
			Slayer = SlayerName.Fey;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = 100;

			cold = pois = phys = nrgy = chaos = direct = 0;
		}

		public Artifact_PixieSwatter( Serial serial ) : base( serial )
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