using System;
using Server;

namespace Server.Items
{
	public class QuiverOfElements : BaseQuiver
	{
		[Constructable]
		public QuiverOfElements() : base()
		{
			
			Name = "Quiver of the Elements";
			Hue = 0xAFE;
			ItemID = 0x2B02;
			WeightReduction = 75;
			LowerAmmoCost = 75;
			DamageIncrease = 50;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.DefendChance = 10;
			Attributes.RegenMana = 2;
			Attributes.RegenHits = 2;
			Attributes.RegenStam = 2;
			Attributes.BonusInt = 3;
			Attributes.BonusStr = 3;
			Attributes.BonusDex = 3;
			ArtifactLevel = 1;
		}

		public QuiverOfElements( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			chaos = phys = direct = 0;
			fire = 25;
			cold = 25;
			nrgy = 25;
			pois = 25;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			ArtifactLevel = 1;
		}
	}
}
