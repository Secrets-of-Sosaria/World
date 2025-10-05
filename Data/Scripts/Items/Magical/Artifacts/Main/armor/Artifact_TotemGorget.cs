using System;
using Server;

namespace Server.Items
{
	public class Artifact_TotemGorget : GiftLeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_TotemGorget()
		{
			Name = "Totem Gorget";
			Hue = 0x455;
			ItemID = 0x13C7;
			Attributes.BonusStr = 14;
			Attributes.ReflectPhysical = 10;
			Attributes.AttackChance = 14;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TotemGorget( Serial serial ) : base( serial )
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