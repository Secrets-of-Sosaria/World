using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
	public class Artifact_RingOfProtection : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfProtection()
		{
			Name = "Ring of Protection";
			Hue = 0;
			Resistances.Physical = Utility.RandomMinMax(5,10);
			Resistances.Fire = Utility.RandomMinMax(5,10);
			Resistances.Cold = Utility.RandomMinMax(5,10);
			Resistances.Poison = Utility.RandomMinMax(5,10);
			Resistances.Energy = Utility.RandomMinMax(5,10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_RingOfProtection( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}



