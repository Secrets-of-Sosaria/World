using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureVengeanceLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 9; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_NatureVengeanceLeggings()
		{
			Name = "Leggings of Natural Vengeance";
			Hue = 0x592;
			Attributes.BonusInt = 5;
			Attributes.RegenMana = 8;
			Attributes.LowerManaCost = 8;
			ArtifactLevel = 2;
			Attributes.SpellDamage = 16;
			SkillBonuses.SetValues( 0, SkillName.Elementalism, 10);
			SkillBonuses.SetValues( 1, SkillName.Taming, 10);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 10);
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureVengeanceLeggings( Serial serial ) : base( serial )
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