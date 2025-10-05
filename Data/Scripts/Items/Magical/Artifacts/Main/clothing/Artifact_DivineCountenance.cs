using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineCountenance : GiftHornedTribalMask
	{
		public override int BaseEnergyResistance{ get{ return 25; } }

		[Constructable]
		public Artifact_DivineCountenance()
		{
			Hue = 0x482;
			Name = "Divine Countenance";
			Attributes.BonusInt = 8;
			Attributes.RegenMana = 5;
			Attributes.BonusMana = 5;
			Attributes.ReflectPhysical = 25;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_DivineCountenance( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}