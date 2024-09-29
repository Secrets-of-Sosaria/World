using System;
using Server;

namespace Server.Items
{
	public class Artifact_ShadowDancerGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public Artifact_ShadowDancerGloves()
		{
			Name = "Shadow Dancer Gloves";
			Hue = 0x455;
			ItemID = 0x13C6;
			SkillBonuses.SetValues( 0, SkillName.Stealth, 10.0 );
			SkillBonuses.SetValues( 1, SkillName.Stealing, 10.0 );
			Attributes.BonusDex = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_ShadowDancerGloves( Serial serial ) : base( serial )
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