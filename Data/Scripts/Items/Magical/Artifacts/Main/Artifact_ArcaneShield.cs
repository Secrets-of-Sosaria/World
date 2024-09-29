using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneShield : GiftWoodenKiteShield
	{
		[Constructable]
		public Artifact_ArcaneShield()
		{
			Name = "Arcane Shield";
			ItemID = 0x1B78;
			Hue = 0x556;
			Attributes.NightSight = 1;
			Attributes.SpellChanneling = 1;
			Attributes.DefendChance = 15;
			Attributes.CastSpeed = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_ArcaneShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}