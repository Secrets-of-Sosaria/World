using System;
using Server.Items;

namespace Server.Items
{
    public class Artifact_LeggingsOfEnlightenment : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }


		[Constructable]
		public Artifact_LeggingsOfEnlightenment()
		{
			Name = "Leggings Of Enlightenment";
			Hue = 0x487;
			ItemID = 0x13cb;

			SkillBonuses.SetValues( 0, SkillName.Psychology, 10.0 );

			Attributes.BonusInt = 8;
			Attributes.BonusMana = 8;
			Attributes.SpellDamage = 10;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_LeggingsOfEnlightenment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}