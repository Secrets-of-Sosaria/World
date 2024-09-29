using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcticBeacon : GiftLantern
	{
		[Constructable]
		public Artifact_ArcticBeacon()
		{
            Name = "Winter Beacon";
            Hue = Utility.RandomList( 1150, 1151, 1152, 1153, 1154, 2066 );
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 15;
            Attributes.Luck = 150;
			Resistances.Cold = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ArcticBeacon( Serial serial ) : base( serial )
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