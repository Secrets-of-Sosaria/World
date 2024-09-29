using System;
using Server;

namespace Server.Items
{
	public class Artifact_BladeOfTheRighteous : GiftLongsword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BladeOfTheRighteous()
		{
			Hue = 0x47E;
			ItemID = 0xF61;
			Name = "Blade of the Righteous";
			Slayer = SlayerName.DaemonDismissal;
			Slayer2 = SlayerName.Exorcism;
			WeaponAttributes.HitLeechHits = 50;
			WeaponAttributes.UseBestSkill = 1;
			Attributes.BonusHits = 10;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_BladeOfTheRighteous( Serial serial ) : base( serial )
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