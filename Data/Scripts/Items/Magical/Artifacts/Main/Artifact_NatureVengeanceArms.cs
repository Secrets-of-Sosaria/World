using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureVengeanceArms : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public Artifact_NatureVengeanceArms()
		{
			Name = "Arms of Natural Vengeance";
			Hue = 0x592;
			SkillBonuses.SetValues( 0, SkillName.Elementalism, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,2)*5) );
			Attributes.SpellDamage = 5 + (Utility.RandomMinMax(0,3) * 5);
			Attributes.BonusInt = 2;
			Attributes.RegenMana = 1;
			Attributes.LowerManaCost = 4;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureVengeanceArms( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}