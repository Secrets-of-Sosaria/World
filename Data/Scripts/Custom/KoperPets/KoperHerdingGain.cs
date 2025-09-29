using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Custom.KoperPets
{
    public static class KoperHerdingGain
    {
        private static readonly Dictionary<Mobile, DateTime> _cooldowns = new Dictionary<Mobile, DateTime>();
        private static readonly TimeSpan CooldownTime = TimeSpan.FromSeconds(MyServerSettings.KoperCooldown()); //  Set cooldown time (20 Seconds default)

        private static readonly string[] SuccessMessages = new string[]
        {
            "You feel more confident in guiding animals.",
            "Your understanding of animal behavior improves.",
            "You refine your ability to control creatures.",
            "Your herding instincts grow stronger.",
            "You sense a deeper connection with the animals.",
            "You observe the subtle body language of the herd.",
            "The creatures seem to respond to your commands more easily.",
            "You learn to anticipate the movements of the animals.",
            "Your patience with the herd pays off.",
            "You develop a rhythm in directing the animals.",
            "The bond between you and your animals strengthens.",
            "You notice an improvement in how quickly animals obey you.",
            "You gain insight into the instincts of the creatures you guide.",
            "You master a new technique in controlling stubborn animals.",
            "Your steady guidance makes the animals trust you more."
        };

        private static readonly string[] BondingMessages = new string[]
        {
            "Your deep understanding of animal behavior has forged a special bond!",
            "Through your skilled herding, the creature has grown to trust you completely.",
            "Your patient guidance has earned the creature's unwavering loyalty.",
            "The animal looks at you with newfound devotion and trust.",
            "Your herding expertise has created a bond that will last a lifetime.",
            "The creature's eyes reflect a deep connection forged through your skill."
        };

        public static void TryGainHerdingSkill(Mobile owner)
        {

            bool hasNonSummoned = false;
            bool hasNonHumanBody = false;

            if (owner.Map != null)
            {
            	IPooledEnumerable eable = owner.Map.GetMobilesInRange(owner.Location, 5);

            	foreach (Mobile m in eable)
            	{
            		if (m is BaseCreature)
            		{
            			BaseCreature pet = (BaseCreature)m;
                        // we need to check if the player has followers that are not summons or henchman before applying the rest of the function
            			if (pet.Controlled && pet.ControlMaster == owner)
            			{
            				if (!pet.Summoned)
            					hasNonSummoned = true;

            				if (!pet.Body.IsHuman)
            					hasNonHumanBody = true;

            				if (hasNonSummoned && hasNonHumanBody)
            					break;
            			}
            		}
            	}
            	eable.Free();
            }


            if (owner == null || !owner.Alive || !MyServerSettings.KoperPets() || !hasNonSummoned || !hasNonHumanBody)
                return; // No skill gain for dead players/system disabled// or players that have only summons or henchman

            // Check if the player is on cooldown
            if (_cooldowns.ContainsKey(owner) && DateTime.UtcNow < _cooldowns[owner])
            {
                return; // Cooldown is active, exit without giving skill
            }

            double herdingSkill = owner.Skills[SkillName.Herding].Base;
            double gainChance;
            double herdingMultiplier = MyServerSettings.KoperHerdingChance();


            // Determine gain chance and amount based on skill level
            if (herdingMultiplier <= 0) herdingMultiplier = 1.0; // Ensure valid value
            if (herdingMultiplier >= 10) herdingMultiplier = 10.0; // Ensure valid value
            if (herdingSkill <= 30.0) { gainChance = 0.20 * herdingMultiplier;}
            else if (herdingSkill <= 50.0) { gainChance = 0.15 * herdingMultiplier;}
            else if (herdingSkill <= 70.0) { gainChance = 0.10 * herdingMultiplier;}
            else if (herdingSkill < 125.0) { gainChance = 0.05 * herdingMultiplier;}
            else return; // No gain if at max skill

            if (Utility.RandomDouble() <= gainChance)
            {
                owner.CheckSkill(SkillName.Herding, 0.0 , 125.0 );

                // Check for pet bonding after skill check
                TryBondUnbondedPets(owner, herdingSkill);

                // Select a random message for variety
                if (MyServerSettings.KoperPetsImmersive()) 
                {
                    owner.SendMessage(SuccessMessages[Utility.Random(SuccessMessages.Length)]);
                }
                // Start cooldown timer
                _cooldowns[owner] = DateTime.UtcNow + CooldownTime;
            }
        }

        private static void TryBondUnbondedPets(Mobile owner, double herdingSkill)
        {
            if (owner.Map == null) return;

            // 1% chance at skill 1, 25% chance at skill 125)
            double bondingChance = Math.Max(1.0, Math.Min(25.0, (herdingSkill / 125.0) * 25.0)) / 100.0;

            List<BaseCreature> unbondedPets = new List<BaseCreature>();

            IPooledEnumerable eable = owner.Map.GetMobilesInRange(owner.Location, 5);
            foreach (Mobile m in eable)
            {
                if (m is BaseCreature)
                {
                    BaseCreature pet = (BaseCreature)m;
                    if (pet.Controlled && pet.ControlMaster == owner && !pet.Summoned && 
                        !pet.Body.IsHuman && !pet.IsBonded && pet.BondingBegin != DateTime.MinValue)
                    {
                        unbondedPets.Add(pet);
                    }
                }
            }
            eable.Free();

            foreach (BaseCreature pet in unbondedPets)
            {
                if (Utility.RandomDouble() <= bondingChance)
                {
                    pet.IsBonded = true;
                    pet.BondingBegin = DateTime.MinValue; // Clear bonding timer
                    pet.Loyalty = BaseCreature.MaxLoyalty; // Set to maximum loyalty

                    if (MyServerSettings.KoperPetsImmersive())
                    {
                        owner.SendMessage(BondingMessages[Utility.Random(BondingMessages.Length)]);
                        owner.PublicOverheadMessage(Network.MessageType.Regular, 0x3B2, false, "Your " + pet.Name + " has bonded with you!");
                    }
                }
            }
        }
    }
}