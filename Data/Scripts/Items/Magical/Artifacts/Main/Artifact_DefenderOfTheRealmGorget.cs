using System;
using Server;

namespace Server.Items
{
	public class Artifact_DefenderOfTheRealmGorget : GiftPlateGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_DefenderOfTheRealmGorget()
		{
			Name = "Gorget of the Defender of the Realm";
			Hue = 0x35;
			Attributes.ReflectPhysical = 7;
            SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
			Attributes.DefendChance = 7;
			Attributes.LowerManaCost = 6;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_DefenderOfTheRealmGorget( Serial serial ) : base( serial )
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