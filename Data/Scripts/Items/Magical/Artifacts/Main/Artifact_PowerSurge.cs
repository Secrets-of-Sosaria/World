using System;
using Server;

namespace Server.Items
{
	public class Artifact_PowerSurge : GiftLantern
	{
		[Constructable]
		public Artifact_PowerSurge()
		{
            Name = "Lantern of Power";
            Hue = Utility.RandomList( 1158, 1159, 1163, 1168, 1170, 16 );
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 15;
            Attributes.Luck = 150;
			Resistances.Energy = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_PowerSurge( Serial serial ) : base( serial )
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