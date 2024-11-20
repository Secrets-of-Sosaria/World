using System;
using Server.Items;

namespace Server.Items
{
	public class Artifact_Pestilence: BaseQuiver
	{		
		[Constructable]
		public Artifact_Pestilence() : base()
        {
			Name = "Pestilence";
			Hue = 1151;
            DamageIncrease = 70;
			LowerAmmoCost = 65;
			ItemID = 0x2B02;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			SkillBonuses.SetValues( 1, SkillName.Poisoning, 5 );
			WeightReduction = 65;
			Attributes.RegenStam = 5;
			Attributes.BonusDex = 5;
			Attributes.BonusStam = 5;
			ArtifactLevel = 1;
		}

		public Artifact_Pestilence( Serial serial ) : base( serial )
		{
		}

		public override void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
			cold = fire = nrgy = chaos = direct = 0;
			phys = 25; pois = 75;
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
		}
	}
}