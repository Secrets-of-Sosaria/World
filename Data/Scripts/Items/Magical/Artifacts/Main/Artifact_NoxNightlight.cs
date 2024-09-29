using System;
using Server;

namespace Server.Items
{
	public class Artifact_NoxNightlight : GiftLantern
	{
		[Constructable]
		public Artifact_NoxNightlight()
		{
            Name = "Nox Nightlight";
            Hue = Utility.RandomList( 1267, 1268, 1269, 1270, 1271, 1271, 1372, 1167 );
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 15;
            Attributes.Luck = 150;
			Resistances.Poison = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_NoxNightlight( Serial serial ) : base( serial )
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