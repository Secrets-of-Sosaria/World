using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmsOfTheFallenKing : GiftLeatherArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmsOfTheFallenKing()
		{
			Name = "Arms of the Fallen King";
			Hue = 0x76D;
			ItemID = 0x13cd;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.Luck = 60;
			PhysicalBonus = 8;
			FireBonus = 8;
			PoisonBonus = 8;
			ColdBonus = 8;
			EnergyBonus = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArmsOfTheFallenKing( Serial serial ) : base( serial )
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