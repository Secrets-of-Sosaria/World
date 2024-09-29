using System;
using Server;

namespace Server.Items
{
	public class Artifact_TotemLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_TotemLeggings()
		{
			Name = "Totem Leggings";
			Hue = 0x455;
			ItemID = 0x13cb;
			Attributes.BonusStr = 18;
			Attributes.ReflectPhysical = 12;
			Attributes.AttackChance = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_TotemLeggings( Serial serial ) : base( serial )
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