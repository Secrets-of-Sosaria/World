using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_Retort : GiftWarFork
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_Retort()
		{
			Name = "Retort";
			Hue = 910;
			WeaponAttributes.HitLeechHits = 20;
			WeaponAttributes.HitLeechStam = 35;
			WeaponAttributes.HitLowerDefend = 30;
			WeaponAttributes.SelfRepair = 3;
			Attributes.BonusDex = 5;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_Retort( Serial serial ) : base( serial )
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
