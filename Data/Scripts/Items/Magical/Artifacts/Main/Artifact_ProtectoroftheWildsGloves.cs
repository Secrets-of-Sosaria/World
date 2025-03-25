using System;
using Server;

namespace Server.Items
{
	public class Artifact_ProtectoroftheWildsGloves : GiftWoodenPlateGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_ProtectoroftheWildsGloves()
		{
			Name = "Gloves of the Wilds";
			Hue = 0x21F;
			ArtifactLevel = 2;
			SkillBonuses.SetValues( 0, SkillName.Tactics, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 1, SkillName.Taming, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5 + (Utility.RandomMinMax(0,2)*5) );
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5 + (Utility.RandomMinMax(0,2)*5) );
			Attributes.DefendChance = 5 + (Utility.RandomMinMax(0,3)*5);
			Attributes.WeaponSpeed = 5 + (Utility.RandomMinMax(0,3)*5);
			Attributes.WeaponDamage = 5 + (Utility.RandomMinMax(0,3)*5);
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ProtectoroftheWildsGloves( Serial serial ) : base( serial )
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