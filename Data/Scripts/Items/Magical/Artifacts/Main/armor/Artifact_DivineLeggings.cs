using System;
using Server;

namespace Server.Items
{
	public class Artifact_DivineLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
		public override int BaseEnergyResistance{ get{ return 22; } }

		[Constructable]
		public Artifact_DivineLeggings()
		{
			Name = "Divine Leggings";
			Hue = 0x482;
			ItemID = 0x13cb;
			Attributes.BonusInt = 9;
			Attributes.RegenMana = 2;
			Attributes.ReflectPhysical = 15;
			Attributes.LowerManaCost = 10;
			Attributes.Luck = 45;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_DivineLeggings( Serial serial ) : base( serial )
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