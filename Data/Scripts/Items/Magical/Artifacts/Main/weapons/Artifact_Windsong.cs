using System;
using Server;

namespace Server.Items
{
	public class Artifact_Windsong : GiftMagicalShortbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_Windsong() : base()
		{
			Hue = 0xAC;
			Name = "Windsong";
			ItemID = 0x2D2B;
			Attributes.WeaponDamage = 19;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.AttackChance = 5;
			Velocity = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_Windsong( Serial serial ) : base( serial )
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
