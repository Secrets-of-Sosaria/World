using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureMasterLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_NatureMasterLeggings()
		{
			Name = "Leggings of the Nature's Master";
			Hue = 0x29D;
			ArtifactLevel = 2;
            Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,3)*5);
            Attributes.Luck = 50 + (Utility.RandomMinMax(0,3)*50);
			SkillBonuses.SetValues( 0, SkillName.Herding, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,3)*5) );
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5 + (Utility.RandomMinMax(0,2)*5) );
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureMasterLeggings( Serial serial ) : base( serial )
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