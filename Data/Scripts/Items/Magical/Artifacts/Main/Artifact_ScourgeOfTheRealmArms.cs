using System;
using Server;

namespace Server.Items
{
	public class Artifact_ScourgeOfTheRealmArms : GiftPlateArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 12; } }

		[Constructable]
		public Artifact_ScourgeOfTheRealmArms()
		{
			Name = "Arms of the Scourge of the Realm";
			Hue = 0x25;
			Attributes.ReflectPhysical = 12;
			Attributes.DefendChance = 8;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
			Attributes.LowerManaCost = 6;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_ScourgeOfTheRealmArms( Serial serial ) : base( serial )
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