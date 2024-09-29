using System;
using Server;

namespace Server.Items
{
	public class Artifact_NoxRangersHeavyCrossbow : GiftHeavyCrossbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_NoxRangersHeavyCrossbow()
		{
			Name = "Nox Ranger's Heavy Crossbow";
			Hue = 0x58C;
			ItemID = 0x13FD;
			WeaponAttributes.HitLeechStam = 40;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 20;
			WeaponAttributes.ResistPoisonBonus = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			pois = 50;
			phys = 50;

			fire = cold = nrgy = chaos = direct = 0;
		}

		public Artifact_NoxRangersHeavyCrossbow( Serial serial ) : base( serial )
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