using System;
using Server;

namespace Server.Items
{
	public class Artifact_ProtectoroftheWildsHelmet : GiftWoodenPlateHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_ProtectoroftheWildsHelmet()
		{
			Name = "Helmet of the Wilds";
			Hue = 0x21F;
			ArtifactLevel = 2;
			SkillBonuses.SetValues( 0, SkillName.Tactics, 5);
			SkillBonuses.SetValues( 1, SkillName.Taming, 10);
			SkillBonuses.SetValues( 2, SkillName.Druidism, 10);
			SkillBonuses.SetValues( 3, SkillName.Veterinary, 5);
			Attributes.DefendChance = 5;
			Attributes.WeaponSpeed = 5;
			Attributes.WeaponDamage = 9;
			Attributes.BonusDex = 7;
			Attributes.RegenStam = 5;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ProtectoroftheWildsHelmet( Serial serial ) : base( serial )
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