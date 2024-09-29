using System;
using Server;

namespace Server.Items
{
	public class Artifact_TheRobeOfBritanniaAri : GiftRobe
	{
		[Constructable]
		public Artifact_TheRobeOfBritanniaAri()
		{
			Name = "Robe of Sosaria";
			Hue = 0x48b;
			Resistances.Physical = 10;
			Resistances.Cold = 10;
			Resistances.Fire = 10;
			Resistances.Energy = 10;
			Resistances.Poison = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_TheRobeOfBritanniaAri( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
