using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureVengeanceGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		[Constructable]
		public Artifact_NatureVengeanceGloves()
		{
			Name = "Gloves of Natural Vengeance";
			Hue = 0x592;
            SkillBonuses.SetValues( 0, SkillName.Elementalism, 10);
			SkillBonuses.SetValues( 1, SkillName.Taming, 10);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 10);
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			Attributes.BonusInt = 6;
			Attributes.LowerManaCost = 6;
			Attributes.CastRecovery	= 2;
			Attributes.CastSpeed = 2;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureVengeanceGloves( Serial serial ) : base( serial )
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