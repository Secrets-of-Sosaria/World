using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_WhistleofthePiper : GiftWhips
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_WhistleofthePiper()
		{
			Name = "Whistle of the Pied Piper";
			Hue = 0x668;
			SkillBonuses.SetValues( 0, SkillName.Taming,  10.0 + (Utility.RandomMinMax(0,3)*5) );
			SkillBonuses.SetValues( 1, SkillName.Herding,  10.0 + (Utility.RandomMinMax(0,3)*5) );
			WeaponAttributes.HitLeechStam = 30;
			WeaponAttributes.HitLeechHits = 30;
            AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.WeaponSpeed = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = 100;

			pois = fire = phys = nrgy = chaos = direct = 0;
		}

		public Artifact_WhistleofthePiper( Serial serial ) : base( serial )
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