using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmsOfAegis : GiftPlateArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmsOfAegis()
		{
			Name = "Arms of Aegis";
			Hue = 0x47E;
			ItemID = 0x1410;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 15;
			Attributes.DefendChance = 15;
			Attributes.LowerManaCost = 6;
			Attributes.Luck = 45;
			PhysicalBonus = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArmsOfAegis( Serial serial ) : base( serial )
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