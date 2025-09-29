using System;
using Server;

namespace Server.Items
{
	public class Artifact_PolarBearMask : GiftBearMask
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 30; } }

		[Constructable]
		public Artifact_PolarBearMask()
		{
			Name = "Spirit of the Polar Bear";
			Hue = 0x481;
			ClothingAttributes.SelfRepair = 5;
			Attributes.RegenHits = 5;
			Attributes.NightSight = 1;
			Attributes.Luck = 100;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_PolarBearMask( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();

			if ( version < 2 )
			{
				Resistances.Physical = 0;
				Resistances.Cold = 0;
			}

			if ( Attributes.NightSight == 0 )
				Attributes.NightSight = 1;
		}
	}
}