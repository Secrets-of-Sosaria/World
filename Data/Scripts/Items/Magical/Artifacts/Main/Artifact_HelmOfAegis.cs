using System;
using Server;

namespace Server.Items
{
	public class Artifact_HelmOfAegis : GiftPlateHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_HelmOfAegis()
		{
			Name = "Helm of Aegis";
			Hue = 0x47E;
			ItemID = 0x1412;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 14;
			Attributes.DefendChance = 14;
			Attributes.LowerManaCost = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_HelmOfAegis( Serial serial ) : base( serial )
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