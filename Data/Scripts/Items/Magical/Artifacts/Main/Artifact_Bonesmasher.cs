using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_Bonesmasher : GiftDiamondMace
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_Bonesmasher()
		{
			Name = "Bonesmasher";
			Hue = 0x482;
			ItemID = 0x2D24;

			SkillBonuses.SetValues( 0, SkillName.Bludgeoning, 10.0 );

			WeaponAttributes.HitLeechMana = 40;
			WeaponAttributes.SelfRepair = 2;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_Bonesmasher( Serial serial ) : base( serial )
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