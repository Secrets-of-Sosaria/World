using System;
using Server;

namespace Server.Items
{
	public class Artifact_LeggingsOfAegis : GiftPlateLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 18; } }

		[Constructable]
		public Artifact_LeggingsOfAegis()
		{
			Name = "Leggings of Aegis";
			Hue = 0x47E;
			ItemID = 0x46AA;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 18;
			Attributes.DefendChance = 18;
			Attributes.LowerManaCost = 14;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_LeggingsOfAegis( Serial serial ) : base( serial )
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