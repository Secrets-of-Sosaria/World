using System;
using Server;

namespace Server.Items
{
	public class Artifact_PolarBearCape : GiftFurCape
	{
		[Constructable]
		public Artifact_PolarBearCape()
		{
			Hue = 0x47E;
			Name = "Polar Bear Cape";
			Resistances.Cold = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 1, "" );
		}

		public Artifact_PolarBearCape( Serial serial ) : base( serial )
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