using System;

namespace Server.Items
{
	public class Artifact_ResilientBracer : GiftGoldBracelet
	{
		public override int PhysicalResistance{ get { return 20; } }

		[Constructable]
		public Artifact_ResilientBracer()
		{
			Hue = 0x488;
			Name = "Resillient Bracer";
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15.0 );
			Attributes.BonusHits = 8;
			Attributes.RegenHits = 8;
			Attributes.DefendChance = 15;
			Resistances.Physical = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ResilientBracer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}
