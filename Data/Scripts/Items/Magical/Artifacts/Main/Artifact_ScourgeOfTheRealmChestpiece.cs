using System;
using Server;

namespace Server.Items
{
	public class Artifact_ScourgeOfTheRealmChestpiece : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_ScourgeOfTheRealmChestpiece()
		{
			Name = "Platemail of the Scourge of the Realm";
			Hue = 0x25;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 10;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15 );
			Attributes.DefendChance = 10;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_ScourgeOfTheRealmChestpiece( Serial serial ) : base( serial )
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