using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureVengeanceMask : GiftBearMask
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public Artifact_NatureVengeanceMask()
		{
			Hue = 0x592;
			Name = "Mask of Natural Vengeance";
			ArtifactLevel = 2;
			Attributes.BonusInt = 5;
			Attributes.SpellDamage = 5 + (Utility.RandomMinMax(0,4) * 5);
			SkillBonuses.SetValues( 0, SkillName.Elementalism, 5 + (Utility.RandomMinMax(0,3)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,2)*5) );
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureVengeanceMask( Serial serial ) : base( serial )
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