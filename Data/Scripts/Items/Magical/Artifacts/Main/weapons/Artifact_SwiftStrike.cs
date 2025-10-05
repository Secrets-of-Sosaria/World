using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_SwiftStrike : GiftWakizashi
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_SwiftStrike()
		{
			Name = "Swift Strike";
			Hue = 2111;
			WeaponAttributes.HitLeechHits = 25;
			WeaponAttributes.HitLeechStam = 25;
			WeaponAttributes.HitLowerAttack = 25;
			WeaponAttributes.HitLowerDefend = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_SwiftStrike( Serial serial ) : base( serial )
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
