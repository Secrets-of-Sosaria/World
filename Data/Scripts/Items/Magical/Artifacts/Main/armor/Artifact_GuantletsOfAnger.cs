using System;
using Server;

namespace Server.Items
{
	public class Artifact_GuantletsOfAnger : GiftPlateGloves
	{
		public override int BasePhysicalResistance{ get{ return 14; } }
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 11; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_GuantletsOfAnger()
		{
			Name = "Gauntlets of Anger";
			Hue = 0x29b;
			ItemID = 0x1414;
			Attributes.BonusStr = 10;
			Attributes.BonusHits = 8;
			Attributes.RegenHits = 8;
			Attributes.DefendChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GuantletsOfAnger( Serial serial ) : base( serial )
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
