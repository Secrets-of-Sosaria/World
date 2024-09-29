using System;
using Server;

namespace Server.Items
{
	public class GwennosHarp : BaseInstrument
	{
		public override int Hue { get { return 0x9C4; } }
		public override int InitMinUses{ get{ return 800; } }
		public override int InitMaxUses{ get{ return 800; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularWood; } }

		[Constructable]
		public GwennosHarp() : base( 0x66F4, 0x45, 0x46 )
		{
			int attributeCount = Utility.RandomMinMax(4,7);
			int min = Utility.RandomMinMax(5,10);
			int max = min + 15;
			BaseRunicTool.ApplyAttributesTo( (BaseInstrument)this, attributeCount, min, max );
			ArtifactLevel = 1;

			Name = "Gwenno's Harp";
			UsesRemaining = 800;
			Slayer = SlayerName.Repond;
			Slayer2 = SlayerName.ReptilianDeath;
			SkillBonuses.SetValues( 0, SkillName.Discordance, 10 );
			SkillBonuses.SetValues( 1, SkillName.Musicianship, 10 );
			SkillBonuses.SetValues( 2, SkillName.Peacemaking, 10 );
			SkillBonuses.SetValues( 3, SkillName.Provocation, 10 );
		}

		public GwennosHarp( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ArtifactLevel = 1;
			ItemID = 0x66F4;
		}
	}
}