using System;
using Server;

namespace Server.Items
{
	public class QuiverOfIce : ElvenQuiver
	{
		[Constructable]
		public QuiverOfIce() : base()
		{
			Name = "Quiver of Ice";
			Hue = 0x998;
			ItemID = 0x2B02;
			DamageIncrease = 50;
			LowerAmmoCost = 35;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			WeightReduction = 35;
			Attributes.BonusDex = 5;
			Attributes.BonusStam = 5;
			ArtifactLevel = 1;
		}

		public QuiverOfIce( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			fire = pois = nrgy = chaos = direct = 0;
			phys = cold = 50;
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
