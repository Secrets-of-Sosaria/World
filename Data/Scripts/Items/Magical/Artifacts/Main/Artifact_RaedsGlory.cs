using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_RaedsGlory : GiftWarCleaver
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_RaedsGlory()
		{
			Name = "Raed's Glory";
			ItemID = 0x2D23;
			Hue = 0x1E6;

			Attributes.BonusMana = 8;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 20;

			WeaponAttributes.HitLeechHits = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_RaedsGlory( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}