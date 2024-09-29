using System;
using Server;

namespace Server.Items
{
	public class Artifact_LegacyOfTheDreadLord : GiftBardiche
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_LegacyOfTheDreadLord()
		{
			Name = "Legacy of the Dread Lord";
			Hue = 0x676;
			ItemID = 0xF4D;
			Attributes.SpellChanneling = 1;
			Attributes.CastRecovery = 3;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_LegacyOfTheDreadLord( Serial serial ) : base( serial )
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