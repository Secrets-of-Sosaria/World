using System;

namespace Server.Items
{
	public class QuiverOfInfinity : BaseQuiver
	{
		[Constructable]
		public QuiverOfInfinity() : base()
		{
			Name = "Quiver of Infinity";
			ItemID = 0x2B02;
			Hue = 0x99A;
			WeightReduction = 100;
			LowerAmmoCost = 100;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.AttackChance = 10;
			Attributes.WeaponSpeed = 10;
			Attributes.Luck = 50;
			Attributes.BonusDex = 5;
			ArtifactLevel = 1;
		}

		public QuiverOfInfinity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			if( version < 1 && DamageIncrease == 0 )
			{
				DamageIncrease = 10;
			}
			ArtifactLevel = 1;
		}
	}
}
