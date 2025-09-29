using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.PartySystem;

namespace Server.Items
{
	public class Artifact_HolySword : GiftLongsword
	{
		private DateTime m_NextAoE;

		[Constructable]
		public Artifact_HolySword()
		{
			Name = "Carsomyr";
			Hue = 0x482;
			ItemID = 0xF61;
			Slayer = SlayerName.Silver;
			Attributes.WeaponDamage = 45;
			WeaponAttributes.SelfRepair = 10;
			WeaponAttributes.UseBestSkill = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}
		
		public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
    	{
    	    base.OnHit(attacker, defender, damageBonus);
    	    if (attacker == null || defender == null)
    	        return;
    	    if (DateTime.UtcNow < m_NextAoE)
    	        return;
    	    double skill = attacker.Skills[SkillName.Knightship].Value; 
    	    double chance = 0.05 + (skill / 125.0) * 0.20; // 5% chant at 0 skill, 25% chance at 125 skill
    	    if (Utility.RandomDouble() > chance)
    	        return;
    	    double seconds = 120.0 - (skill * (90.0 / 125.0)); // 120secs cooldown at 0 skill, 30 secs cooldown at 125 skill
    	    m_NextAoE = DateTime.UtcNow + TimeSpan.FromSeconds(seconds);
			m_NextAoE = DateTime.UtcNow + TimeSpan.FromSeconds(1);
			int minDmg = attacker.Karma / 777; // 19 base min damage at 15k karma
		    int maxDmg = attacker.Karma / 555; // 27 base max damage at 15k karma
		    if (minDmg < 0) minDmg = 0;
		    if (maxDmg < 0) maxDmg = 0;
		    if (maxDmg < minDmg) maxDmg = minDmg;
    	    foreach (Mobile mob in defender.GetMobilesInRange(8))
    	    {
    	        if (mob == null || mob == attacker || mob == defender)
    	            continue;
				// dont smite pets/owned summoned creatures
    	        if (mob is BaseCreature)
    	        {
    	            BaseCreature bc = (BaseCreature)mob;
    	            if ((bc.Controlled && bc.ControlMaster == attacker) || (bc.Summoned && bc.SummonMaster == attacker))
    	                continue;
    	        }
    	        // don't smite party members
    	        Party attackerParty = Party.Get(attacker);
    	        Party mobParty = Party.Get(mob);
				if (attackerParty != null && mobParty != null && attackerParty == mobParty)
					continue;
    	        // dont smite guild mates
    	        if (attacker.Guild != null && mob.Guild != null && attacker.Guild == mob.Guild)
    	            continue;
    	        // Only smite evil things
    	        if (mob.Karma > 0)
    	            continue;
				// adds damage based on how mean the target is
				// adds up to 25 damage when hitting something with -15k karma or lower
				int bonus = 0;
				if (mob.Karma < 0)
				{
				    int scaled = 1 + ((-mob.Karma) * 24 / 15000);
					if (scaled < 1) scaled = 0;
				    if (scaled > 25) scaled = 25;
				    bonus = scaled;
				}
				// smiting!
				int dmg = Utility.RandomMinMax(minDmg, maxDmg) + bonus;
				if (dmg > 0)
				{
					AOS.Damage(mob, attacker, dmg, 0, 100, 0, 0, 0);
					// Fire effect + sound
					mob.FixedParticles(0x36BD, 20, 10, 5044, 1161, 0, EffectLayer.Waist);
					mob.PlaySound(0x208);
    				attacker.SendMessage("Your Holy Sword unleashes a burst of divine fire!");
       			}
    	    }
    	}

		public Artifact_HolySword(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}