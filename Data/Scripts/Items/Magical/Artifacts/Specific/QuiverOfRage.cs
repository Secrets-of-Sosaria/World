using System;
using Server;

namespace Server.Items
{
	public class QuiverOfRage : BaseQuiver
	{
		[Constructable]
		public QuiverOfRage() : base()
		{
			Hue = 0xB01;
			Name = "Quiver of Rage";
			ItemID = 0x2B02;
			WeightReduction = 75;
			LowerAmmoCost = 25;
			Attributes.WeaponSpeed = 15;
			Attributes.BonusStr = 10;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			DamageIncrease = 100;
			ArtifactLevel = 1;
		}

		public QuiverOfRage( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			chaos = direct = fire = cold = pois = nrgy = 0;
			phys = 100;
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
