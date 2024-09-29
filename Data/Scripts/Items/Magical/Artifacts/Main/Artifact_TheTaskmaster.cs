using System;
using Server;

namespace Server.Items
{
	public class Artifact_TheTaskmaster : GiftWarFork
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TheTaskmaster()
		{
			Name = "Taskmaster";
			Hue = 0x4F8;
			WeaponAttributes.HitPoisonArea = 100;
			Attributes.BonusDex = 5;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = nrgy = chaos = direct = 0;
			pois = 100;
		}

		public Artifact_TheTaskmaster( Serial serial ) : base( serial )
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