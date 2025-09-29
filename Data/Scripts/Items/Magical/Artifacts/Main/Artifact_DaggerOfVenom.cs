using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_DaggerOfVenom : GiftDagger
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_DaggerOfVenom()
		{
			Name = "Dagger of Venom";
			Hue = 0x4F6;
			ItemID = 0x2677;
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.AttackChance = 10;
			Attributes.BonusDex = 10;
			AosElementDamages.Physical = 50;
			AosElementDamages.Poison = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Dripping With Venom " );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			if (Utility.RandomDouble() > 0.25)
				return;
			double poisoning = attacker.Skills[SkillName.Poisoning].Value;
		    double roll = Utility.RandomDouble();
			Poison chosen = null;

    		if (poisoning < 25.0)
    		{
    		    if (roll < 0.20) chosen = Poison.Regular;
    		    else chosen = Poison.Lesser;
    		}
    		else if (poisoning < 50.0)
    		{
    		    if (roll < 0.20) chosen = Poison.Greater;
    		    else if (roll < 0.60) chosen = Poison.Regular;
    		    else chosen = Poison.Lesser;
    		}
    		else if (poisoning < 75.0)
    		{
    		    if (roll < 0.20) chosen = Poison.Deadly;
    		    else if (roll < 0.40) chosen = Poison.Greater;
    		    else chosen = Poison.Lesser;
    		}
    		else if (poisoning < 100.0)
    		{
    		    if (roll < 0.33) chosen = Poison.Deadly;
    		    else if (roll < 0.77) chosen = Poison.Greater;
    		    else chosen = Poison.Lesser;
    		}
    		else
    		{
    		    if (roll < 0.44) chosen = Poison.Deadly;
    		    else chosen = Poison.Greater;
    		}

    		if (chosen != null)
    		{
    		    defender.ApplyPoison(attacker, chosen);

    		    if (chosen == Poison.Lesser)
    		        Misc.Titles.AwardKarma(attacker, -50, true);
    		    else if (chosen == Poison.Regular)
    		        Misc.Titles.AwardKarma(attacker, -60, true);
    		    else if (chosen == Poison.Greater)
    		        Misc.Titles.AwardKarma(attacker, -70, true);
    		    else if (chosen == Poison.Deadly)
    		        Misc.Titles.AwardKarma(attacker, -80, true);
    		}
		}

		public Artifact_DaggerOfVenom( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
