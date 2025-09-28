using System;
using Server;

namespace Server.Items
{
	public class Artifact_ScourgeOfTheRealmHelmet : GiftPlateHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 10; } }

		[Constructable]
		public Artifact_ScourgeOfTheRealmHelmet()
		{
			Name = "Helm of the Scourge of the Realm";
			Hue = 0x25;
			Attributes.ReflectPhysical = 14;
			Attributes.DefendChance = 14;
			Attributes.LowerManaCost = 7;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ScourgeOfTheRealmHelmet( Serial serial ) : base( serial )
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