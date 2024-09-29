using System;
using Server;

namespace Server.Items
{
	public class Artifact_TotemGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_TotemGloves()
		{
			Name = "Totem Gloves";
			Hue = 0x455;
			ItemID = 0x13C6;
			Attributes.BonusStr = 10;
			Attributes.ReflectPhysical = 8;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_TotemGloves( Serial serial ) : base( serial )
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