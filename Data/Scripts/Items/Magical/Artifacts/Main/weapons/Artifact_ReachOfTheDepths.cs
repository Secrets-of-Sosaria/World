using System;
using Server;

namespace Server.Items
{
	public class Artifact_ReachOfTheDepths : GiftHarpoon
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ReachOfTheDepths()
		{
			Name = "Reach of the Depths";
			Hue = 597;
			ItemID = 0xF63;
			SkillBonuses.SetValues(0, SkillName.Seafaring,  10);
			WeaponAttributes.HitLeechHits = 36;
			Attributes.WeaponSpeed = 15;
			Attributes.BonusDex = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = fire = pois = nrgy = phys = 0;
			cold = 100;
		}

		public Artifact_ReachOfTheDepths( Serial serial ) : base( serial )
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