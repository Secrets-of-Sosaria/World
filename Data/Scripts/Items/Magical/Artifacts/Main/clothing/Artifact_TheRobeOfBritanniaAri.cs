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
			Resistances.Physical = 30;
			Resistances.Cold = 30;
			Resistances.Fire = 30;
			Resistances.Energy = 30;
			Resistances.Poison = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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
