using System;
using Server;

namespace Server.Items
{
	public class Artifact_GorgetOfAegis : GiftPlateGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_GorgetOfAegis()
		{
			Name = "Gorget of Aegis";
			Hue = 0x47E;
			ItemID = 0x1413;
			Attributes.Luck = 55;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 12;
			Attributes.DefendChance = 13;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GorgetOfAegis( Serial serial ) : base( serial )
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