using System;
using Server;

namespace Server.Items
{
	public class Artifact_NatureMasterHeaddress : GiftDeerMask
	{
		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 11; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 8; } }

		[Constructable]
		public Artifact_NatureMasterHeaddress()
		{
			Hue = 0x29D;
			Name = "Nature's Master Headdress";
			SkillBonuses.SetValues( 0, SkillName.Herding, 5);
			SkillBonuses.SetValues( 1, SkillName.Taming, 5);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 5);
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5);
			Attributes.NightSight = 1;
            Attributes.Luck = 97;
            Attributes.DefendChance = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_NatureMasterHeaddress( Serial serial ) : base( serial )
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