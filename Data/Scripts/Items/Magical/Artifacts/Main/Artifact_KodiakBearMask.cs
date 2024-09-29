using System;
using Server;

namespace Server.Items
{
	public class Artifact_KodiakBearMask : GiftBearMask
	{
		[Constructable]
		public Artifact_KodiakBearMask()
		{
			Hue = 0x76B;
			Name = "Kodiak Bear Mask";
			Resistances.Physical = 25;
			Attributes.BonusStr = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_KodiakBearMask( Serial serial ) : base( serial )
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