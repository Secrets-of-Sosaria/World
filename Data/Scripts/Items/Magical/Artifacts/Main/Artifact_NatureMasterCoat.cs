using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_NatureMasterCoat : GiftLeatherChest
	{
		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public Artifact_NatureMasterCoat()
		{
			Hue = 0x29D;
			Name = "Coat of the Nature's Master";
			Attributes.Luck = 80;
            Attributes.DefendChance = 10;
			ArtifactLevel = 2;
			SkillBonuses.SetValues( 0, SkillName.Herding, 5 );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 );
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5 );
            Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureMasterCoat( Serial serial ) : base( serial )
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