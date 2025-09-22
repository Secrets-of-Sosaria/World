using System;
using Server;

namespace Server.Items
{
	public class Artifact_DefenderOfTheRealmGloves : GiftPlateGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 8; } }

		[Constructable]
		public Artifact_DefenderOfTheRealmGloves()
		{
			Name = "Gloves of the Defender of the Realm";
			Hue = 0x35;
            SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
			Attributes.ReflectPhysical = 8;
			Attributes.DefendChance = 8;
			Attributes.LowerManaCost = 4;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_DefenderOfTheRealmGloves( Serial serial ) : base( serial )
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