using System;
using Server.Mobiles;

namespace Server.Items
{
	public class Artifact_LuckyNecklace : GiftGoldNecklace
	{
		[Constructable]
		public Artifact_LuckyNecklace()
		{
			Name = "Lucky Necklace";
			Hue = 0xAFF;
			base.Attributes.Luck = 150;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 0, "" );
		}

		public Artifact_LuckyNecklace( Serial serial ) : base( serial )
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
			reader.ReadInt();
		}
	}
}
