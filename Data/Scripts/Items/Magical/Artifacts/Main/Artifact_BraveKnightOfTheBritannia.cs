using System;
using Server;

namespace Server.Items
{
	public class Artifact_BraveKnightOfTheBritannia : GiftKatana
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_BraveKnightOfTheBritannia()
		{
			Hue = 0x47e;
			ItemID = 0x13FF;
			Name = "Brave Knight of Sosaria";
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 35;

			WeaponAttributes.HitLeechStam = 48;
			WeaponAttributes.HitHarm = 26;
			WeaponAttributes.HitLeechHits = 22;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = chaos = direct = 0;
			fire = 40;
			cold = 30;
			pois = 10;
			nrgy = 20;
		}

		public Artifact_BraveKnightOfTheBritannia( Serial serial ) : base( serial )
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
