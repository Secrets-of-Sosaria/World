using System;
using Server;

namespace Server.Items
{
	public class Artifact_Stormbringer : GiftVikingSword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_Stormbringer()
		{
			Hue = 0x76B;
			Name = "Stormbringer";
			ItemID = 0x2D00;
			WeaponAttributes.HitLeechHits = 10;
			WeaponAttributes.HitLeechStam = 10;
			Attributes.BonusStr = 10;
			DamageLevel = WeaponDamageLevel.Vanq;
            Slayer = SlayerName.Repond;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "Elric's Lost Sword " );
		}

		public Artifact_Stormbringer( Serial serial ) : base( serial )
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