using System;
using Server;

namespace Server.Items
{
	public class Artifact_DupresShield : GiftOrderShield
	{
		public override int BasePhysicalResistance { get { return 10; } }
		public override int BaseFireResistance { get { return 0; } }
		public override int BaseColdResistance { get { return 0; } }
		public override int BasePoisonResistance { get { return 0; } }
		public override int BaseEnergyResistance { get { return 10; } }

		public override int InitMinHits { get { return 80; } }
		public override int InitMaxHits { get { return 160; } }

		[Constructable]
		public Artifact_DupresShield()
		{
			Name = "Dupre’s Shield";
			Weight = 6.0;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 5;
			SkillBonuses.SetValues( 0, SkillName.Swords, 10 );
			SkillBonuses.SetValues( 1, SkillName.Parry, 10 );
			SkillBonuses.SetValues( 2, SkillName.Tactics, 10 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_DupresShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}
