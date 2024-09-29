using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_RighteousAnger : GiftElvenMachete
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_RighteousAnger()
		{
			Name = "Righteous Anger";
			Hue = 0x284;

			Attributes.AttackChance = 15;
			Attributes.DefendChance = 5;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_RighteousAnger( Serial serial ) : base( serial )
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