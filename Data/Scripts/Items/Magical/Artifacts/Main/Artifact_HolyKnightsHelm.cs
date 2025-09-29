using System;
using Server;

namespace Server.Items
{
	public class Artifact_HolyKnightsPlateHelm : GiftRoyalHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_HolyKnightsPlateHelm()
		{
			Name = "Holy Knight's Plate Helm";
			Hue = 0x47E;
			SkillBonuses.SetValues( 0, SkillName.Knightship, 10 );
			SkillBonuses.SetValues( 1, SkillName.Tactics, 10 );
			Attributes.BonusHits = 10;
			Attributes.ReflectPhysical = 15;
			Attributes.Luck = 70;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_HolyKnightsPlateHelm( Serial serial ) : base( serial )
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