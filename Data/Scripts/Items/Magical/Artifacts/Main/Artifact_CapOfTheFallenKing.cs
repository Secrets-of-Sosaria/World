using System;
using Server;

namespace Server.Items
{
	public class Artifact_CapOfTheFallenKing : GiftLeatherCap
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_CapOfTheFallenKing()
		{
			Name = "Cap of the Fallen King";
			Hue = 0x76D;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.DefendChance = 5;
			Attributes.Luck = 40;
			PhysicalBonus = 8;
			FireBonus = 8;
			PoisonBonus = 8;
			ColdBonus = 8;
			EnergyBonus = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_CapOfTheFallenKing( Serial serial ) : base( serial )
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