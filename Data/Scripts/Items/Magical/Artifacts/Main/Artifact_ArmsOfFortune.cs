using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmsOfFortune : GiftStuddedArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArmsOfFortune()
		{
			Name = "Arms of Fortune";
			Hue = 0x501;
			Attributes.Luck = 100;
			Attributes.DefendChance = 5;
			Attributes.LowerRegCost = 8;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_ArmsOfFortune( Serial serial ) : base( serial )
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