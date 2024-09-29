using System;
using Server;

namespace Server.Items
{
	public class Artifact_EternalFlame : GiftLantern
	{
		[Constructable]
		public Artifact_EternalFlame()
		{
            Name = "Eternal Flame";
            Hue = Utility.RandomList( 1355, 1356, 1357, 1358, 1359, 1360, 1161, 1260 );
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 15;
            Attributes.Luck = 150;
			Resistances.Fire = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_EternalFlame( Serial serial ) : base( serial )
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