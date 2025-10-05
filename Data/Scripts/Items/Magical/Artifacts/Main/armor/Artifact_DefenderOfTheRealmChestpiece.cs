using System;
using Server;

namespace Server.Items
{
	public class Artifact_DefenderOfTheRealmChestpiece : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_DefenderOfTheRealmChestpiece()
		{
			Name = "Platemail of the Defender of the Realm";
			Hue = 0x35;
			ArmorAttributes.SelfRepair = 5;
			Attributes.ReflectPhysical = 10;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15 );
			Attributes.DefendChance = 10;
			Attributes.LowerManaCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_DefenderOfTheRealmChestpiece( Serial serial ) : base( serial )
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