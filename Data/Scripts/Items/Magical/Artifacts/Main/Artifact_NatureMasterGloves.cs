using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureMasterGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_NatureMasterGloves()
		{
			Name = "Gloves of the Nature's Master";
			Hue = 0x29D;
          	SkillBonuses.SetValues( 0, SkillName.Herding, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5 + (Utility.RandomMinMax(0,2)*5) );
			Attributes.Luck = 50 + (Utility.RandomMinMax(0,3)*50);
			Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,3)*5);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureMasterGloves( Serial serial ) : base( serial )
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