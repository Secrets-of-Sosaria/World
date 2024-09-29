using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_GlassSword : GiftVikingSword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_GlassSword()
		{
			Name = "Sword of Shattered Hopes";
			ItemID = 0x26CE;
			Weight = 5.0;
			Hue = 91;
			WeaponAttributes.HitDispel = 25;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
			WeaponAttributes.ResistFireBonus = 15;
			MinDamage = 15;
			MaxDamage = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "Glass Sword " );
		}

		public Artifact_GlassSword( Serial serial ) : base( serial )
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