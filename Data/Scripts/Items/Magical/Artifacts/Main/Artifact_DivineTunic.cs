using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineTunic : GiftLeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 24; } }

		[Constructable]
		public Artifact_DivineTunic()
		{
			Name = "Divine Tunic";
			Hue = 0x482;
			ItemID = 0x13CC;
			Attributes.BonusInt = 10;
			Attributes.RegenMana = 3;
			Attributes.ReflectPhysical = 18;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_DivineTunic( Serial serial ) : base( serial )
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