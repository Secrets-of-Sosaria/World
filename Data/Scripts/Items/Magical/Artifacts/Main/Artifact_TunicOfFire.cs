using System;
using Server;

namespace Server.Items
{
	public class Artifact_TunicOfFire : GiftChainChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 24; } }
		public override int BaseFireResistance{ get{ return 34; } }

		[Constructable]
		public Artifact_TunicOfFire()
		{
			Name = "Tunic of Fire";
			Hue = 0x54F;
			ItemID = 0x13BF;
			ArmorAttributes.SelfRepair = 5;
			Attributes.NightSight = 1;
			Attributes.ReflectPhysical = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 3, "" );
		}

		public Artifact_TunicOfFire( Serial serial ) : base( serial )
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

			if ( version < 1 )
			{
				if ( Hue == 0x54E )
					Hue = 0x54F;

				if ( Attributes.NightSight == 0 )
					Attributes.NightSight = 1;

				PhysicalBonus = 0;
				FireBonus = 0;
			}
		}
	}
}