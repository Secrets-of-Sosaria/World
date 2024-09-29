using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_SpellWovenBritches : GiftLeatherLegs
	{
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_SpellWovenBritches()
		{
			Hue = 0x487;
			ItemID = 0x13cb;
			Name = "Spell Woven Britches";
			SkillBonuses.SetValues( 0, SkillName.Meditation, 25.0 );

			Attributes.BonusInt = 8;
			Attributes.SpellDamage = 10;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_SpellWovenBritches( Serial serial ) : base( serial )
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