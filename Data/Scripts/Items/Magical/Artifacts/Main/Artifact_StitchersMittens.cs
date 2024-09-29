using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_StitchersMittens : GiftLeatherGloves
	{
		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_StitchersMittens()
		{
			Hue = 0x481;
			ItemID = 0x13C6;
			Name = "Stitcher's Mittens";
			SkillBonuses.SetValues( 0, SkillName.Healing, 25.0 );
			SkillBonuses.SetValues( 0, SkillName.Veterinary, 25.0 );

			Attributes.BonusDex = 5;
			Attributes.LowerRegCost = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_StitchersMittens( Serial serial ) : base( serial )
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