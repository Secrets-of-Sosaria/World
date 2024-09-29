using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineGorget : GiftLeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_DivineGorget()
		{
			Name = "Divine Gorget";
			Hue = 0x482;
			ItemID = 0x13C7;
			Attributes.BonusInt = 6;
			Attributes.RegenMana = 1;
			Attributes.ReflectPhysical = 12;
			Attributes.LowerManaCost = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_DivineGorget( Serial serial ) : base( serial )
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