using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class Artifact_TotemOfVoid : GiftTalismanLeather
	{
		[Constructable]
		public Artifact_TotemOfVoid()
		{
			Name = "Totem of the Void";
			ItemID = 0x2F5B;
			Hue = 0x2D0;
			Attributes.RegenHits = 10;
			Attributes.LowerManaCost = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_TotemOfVoid( Serial serial ) :  base( serial )
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
