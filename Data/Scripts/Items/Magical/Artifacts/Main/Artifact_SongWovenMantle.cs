using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_SongWovenMantle : GiftLeatherArms
	{
		public override int BasePhysicalResistance{ get{ return 14; } }
		public override int BaseColdResistance{ get{ return 14; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		[Constructable]
		public Artifact_SongWovenMantle()
		{
			Hue = 0x493;
			Name = "Song Woven Mantle";
			ItemID = 0x13cd;
			SkillBonuses.SetValues( 0, SkillName.Musicianship, 25.0 );

			Attributes.Luck = 100;
			Attributes.DefendChance = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_SongWovenMantle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}