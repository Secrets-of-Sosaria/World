using System;
using Server;

namespace Server.Items
{
	public class QuiverOfBlight : ElvenQuiver
	{
		[Constructable]
		public QuiverOfBlight() : base()
		{
			Name = "Quiver of Blight";
			Hue = 0xB79;
			ItemID = 0x2B02;
			DamageIncrease = 50;
			LowerAmmoCost = 35;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			WeightReduction = 35;
			Attributes.BonusDex = 5;
			ArtifactLevel = 1;
		}

		public QuiverOfBlight( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			phys = fire = nrgy = chaos = direct = 0;
			cold = pois = 50;
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
