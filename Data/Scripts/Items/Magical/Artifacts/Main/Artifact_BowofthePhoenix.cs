using System;
using Server;

namespace Server.Items
{
	public class Artifact_BowofthePhoenix : GiftElvenCompositeLongbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BowofthePhoenix()
		{
			Hue = 0x489;
			ItemID = 0x2D1E;
			Name = "Bow of the Phoenix";
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			AosElementDamages.Fire = 100; 
			WeaponAttributes.HitFireball = 100;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BowofthePhoenix( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}