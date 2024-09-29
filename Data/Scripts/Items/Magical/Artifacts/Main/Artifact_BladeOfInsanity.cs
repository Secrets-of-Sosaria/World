using System;
using Server;

namespace Server.Items
{
	public class Artifact_BladeOfInsanity : GiftKatana
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BladeOfInsanity()
		{
			Name = "Blade of Insanity";
			Hue = 0x76D;
			ItemID = 0x13FF;
			WeaponAttributes.HitLeechStam = 100;
			Attributes.RegenStam = 2;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_BladeOfInsanity( Serial serial ) : base( serial )
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