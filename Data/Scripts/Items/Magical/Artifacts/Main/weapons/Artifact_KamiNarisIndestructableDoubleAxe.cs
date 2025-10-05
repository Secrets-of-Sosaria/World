using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_KamiNarisIndestructableDoubleAxe : GiftDoubleAxe
	{
		public override int InitMinHits{ get{ return 250; } }
		public override int InitMaxHits{ get{ return 250; } }

		[Constructable]
		public Artifact_KamiNarisIndestructableDoubleAxe()
		{
			Name = "Kami-Naris Indestructable Axe";
			Hue = 1161;
			ItemID = 0xF4B;
			WeaponAttributes.DurabilityBonus = 75;
			WeaponAttributes.HitFireArea = 15;
			WeaponAttributes.HitHarm = 20;
			WeaponAttributes.HitLeechHits = 15;
			WeaponAttributes.HitLeechStam = 15;
			WeaponAttributes.HitLightning = 15;
			WeaponAttributes.SelfRepair = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_KamiNarisIndestructableDoubleAxe( Serial serial ) : base( serial )
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
