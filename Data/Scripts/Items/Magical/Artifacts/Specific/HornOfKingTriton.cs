using System;

namespace Server.Items
{
	public class HornOfKingTriton : BaseInstrument
	{
		public override int Hue { get { return 0; } }
		public override int InitMinUses{ get{ return 800; } }
		public override int InitMaxUses{ get{ return 800; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		[Constructable]
		public HornOfKingTriton() : base( 0x645A, 0x3CC, 0x3CD )
		{
			Name = "Horn of King Triton";
			Weight = 5.0;
			int attributeCount = Utility.RandomMinMax(8,15);
			int min = Utility.RandomMinMax(15,25);
			int max = min + 40;
			BaseRunicTool.ApplyAttributesTo( (BaseInstrument)this, attributeCount, min, max );
			ArtifactLevel = 1;

			UsesRemaining = 800;
			Slayer = SlayerName.NeptunesBane;
			SkillBonuses.SetValues( 0, SkillName.Discordance, 10 );
			SkillBonuses.SetValues( 1, SkillName.Musicianship, 10 );
			SkillBonuses.SetValues( 2, SkillName.Peacemaking, 10 );
			SkillBonuses.SetValues( 3, SkillName.Provocation, 10 );
		}

		public HornOfKingTriton( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ArtifactLevel = 1;
		}
	}
}