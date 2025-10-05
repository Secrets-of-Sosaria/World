using System;
using Server;

namespace Server.Items
{
	public class Artifact_AchillesSpear : GiftSpear
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_AchillesSpear()
		{
			Hue = 0xB1B;
			Name = "Achille's Spear";
			ItemID = 0xF62;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 25 );
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_AchillesSpear( Serial serial ) : base( serial )
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