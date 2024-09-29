using System;
using Server;

namespace Server.Items
{
	public class Artifact_RingOfTheVile : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfTheVile()
		{
			Name = "Ring of the Vile";
			ItemID = 0x6731;
			Hue = 0x4F7;
			Attributes.BonusDex = 8;
			Attributes.RegenStam = 6;
			Attributes.AttackChance = 15;
			Resistances.Poison = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_RingOfTheVile( Serial serial ) : base( serial )
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

			if ( Hue == 0x4F4 )
				Hue = 0x4F7;
		}
	}
}