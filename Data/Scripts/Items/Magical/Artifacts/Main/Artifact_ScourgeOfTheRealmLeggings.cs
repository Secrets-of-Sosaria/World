using System;
using Server;

namespace Server.Items
{
	public class Artifact_ScourgeOfTheRealmLeggings : GiftPlateLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 18; } }

		[Constructable]
		public Artifact_ScourgeOfTheRealmLeggings()
		{
			Name = "Leggings of the Scourge of the Realm";
			Hue = 0x25;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 10 );
			Attributes.ReflectPhysical = 12;
			Attributes.DefendChance = 12;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ScourgeOfTheRealmLeggings( Serial serial ) : base( serial )
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