using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class Artifact_ShimmeringTalisman : GiftTalismanLeather
	{
		[Constructable]
		public Artifact_ShimmeringTalisman()
		{
			Name = "Shimmering Talisman";
			ItemID = 0x2C7F;
			Hue = 1266;
			Attributes.RegenMana = 10;
			Attributes.LowerRegCost = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}
		
		public Artifact_ShimmeringTalisman( Serial serial ) :  base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}