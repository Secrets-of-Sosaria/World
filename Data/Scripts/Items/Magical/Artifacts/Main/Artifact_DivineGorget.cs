using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineGorget : GiftLeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseEnergyResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_DivineGorget()
		{
			Name = "Divine Gorget";
			Hue = 0x482;
			ItemID = 0x13C7;
			Attributes.BonusInt = 6;
			Attributes.RegenMana = 2;
			Attributes.ReflectPhysical = 15;
			Attributes.LowerManaCost = 5;
			Attributes.Luck = 75;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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