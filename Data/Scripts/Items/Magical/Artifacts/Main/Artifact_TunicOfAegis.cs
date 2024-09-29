using System;
using Server;

namespace Server.Items
{
	public class Artifact_TunicOfAegis : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_TunicOfAegis()
		{
			Name = "Tunic of Aegis";
			Hue = 0x47E;
			ItemID = 0x1415;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 18;
			Attributes.DefendChance = 18;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_TunicOfAegis( Serial serial ) : base( serial )
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