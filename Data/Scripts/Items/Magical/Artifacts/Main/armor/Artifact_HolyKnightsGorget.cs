using System;
using Server;

namespace Server.Items
{
	public class Artifact_HolyKnightsGorget : GiftRoyalGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 7; } }

		[Constructable]
		public Artifact_HolyKnightsGorget()
		{
			Name = "Holy Knight's Gorget";
			Hue = 0x47E;
			SkillBonuses.SetValues( 0, SkillName.Knightship, 10 );
			SkillBonuses.SetValues( 1, SkillName.Tactics, 10 );
			Attributes.Luck = 55;
			Attributes.BonusHits = 10;
			Attributes.ReflectPhysical = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_HolyKnightsGorget( Serial serial ) : base( serial )
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