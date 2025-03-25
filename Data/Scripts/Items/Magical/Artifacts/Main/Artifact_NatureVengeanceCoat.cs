using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_NatureVengeanceCoat : GiftLeatherChest
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_NatureVengeanceCoat()
		{
			Hue = 0x592;
			Name = "Coat of Natural Vengeance";
			Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,3)*5);
			Attributes.LowerManaCost = 8;
			ArtifactLevel = 2;
			Attributes.SpellDamage = 5 + (Utility.RandomMinMax(0,3) * 5);
			SkillBonuses.SetValues( 0, SkillName.Elementalism, 5 + (Utility.RandomMinMax(0,3)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,3)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,2)*5) );
            Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureVengeanceCoat( Serial serial ) : base( serial )
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