using System;
using Server;

namespace Server.Items
{
	public class Artifact_TotemTunic : GiftLeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_TotemTunic()
		{
			Name = "Totem Tunic";
			Hue = 0x455;
			ItemID = 0x13CC;
			Attributes.BonusStr = 15;
			Attributes.ReflectPhysical = 10;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_TotemTunic( Serial serial ) : base( serial )
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