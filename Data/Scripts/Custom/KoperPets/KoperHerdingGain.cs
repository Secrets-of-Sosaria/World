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

        public static void TryGainHerdingSkill(Mobile owner)
        {
            if (owner == null || !owner.Alive || !MyServerSettings.KoperPets())
                return; // No skill gain for dead players/system disabled

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

                // Select a random message for variety
                if (MyServerSettings.KoperPetsImmersive()) 
                {
                    owner.SendMessage(SuccessMessages[Utility.Random(SuccessMessages.Length)]);
                }
                // Start cooldown timer
                _cooldowns[owner] = DateTime.UtcNow + CooldownTime;
            }
        }
    }
}
