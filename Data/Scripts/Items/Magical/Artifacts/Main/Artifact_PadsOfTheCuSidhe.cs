using System;
using Server;

namespace Server.Items
{
	public class Artifact_PadsOfTheCuSidhe : GiftFurBoots
	{
		[Constructable]
		public Artifact_PadsOfTheCuSidhe()
		{
			Name = "Pads of the Cu Sidhe";
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 0, "" );
		}

		public Artifact_PadsOfTheCuSidhe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}