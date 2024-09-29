using System;
using Server;

namespace Server.Items
{
	public class Artifact_ShroudOfDeciet : GiftBoneChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 18; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 13; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_ShroudOfDeciet()
		{
			Name = "Shroud of Deceit";
			Hue = 0x38F;
			Attributes.RegenHits = 3;
			ArmorAttributes.MageArmor = 1;
			Attributes.BonusDex = 10;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 10 );

			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ShroudOfDeciet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}
