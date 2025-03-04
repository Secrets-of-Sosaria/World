using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Custom.KoperPets
{
    public static class PetTamingSkillGain
    {
        // Dictionary to track cooldowns (PlayerMobile -> Last Taming Gain Time)
        private static Dictionary<PlayerMobile, DateTime> _tamingCooldowns = new Dictionary<PlayerMobile, DateTime>();

        private static readonly TimeSpan TamingCooldown = TimeSpan.FromSeconds(60); //  Set cooldown time (60 Seconds default)

        private static readonly string[] TamingMessages = new string[]
        {
            "I feel closer to you, {0}!",
            "We fight as one, {0}!",
            "I trust you more, {0}.",
            "Your guidance makes me stronger, {0}.",
            "I will follow you anywhere, {0}.",
            "I understand you better now, {0}!",
            "You lead, I follow, {0}.",
            "You are a worthy master, {0}!",
            "Our bond grows, {0}!",
            "Through battle, we become one, {0}.",
            "I stand by your side, {0}.",
            "I am learning from you, {0}.",
            "You are my trusted master, {0}.",
            "This battle strengthens our bond, {0}!",
            "I heed your call, {0}.",
            "I will fight for you always, {0}.",
            "I am becoming stronger with you, {0}.",
            "Together, we are unstoppable, {0}!"
        };

        private static readonly string[] BattleCries = new string[]
        {
            "For my master!",
            "You will not harm {0}!",
            "I will defend you, {0}, with my life!",
            "Back away from {0}, or suffer my wrath!",
            "I shall tear you apart!",
            "You dare threaten my master?!",
            "Face my fury!",
            "I'll rip you to shreds!",
            "Mess with {0}, and you answer to me!",
            "Prepare to meet your end!",
            "I fight for you, {0}!",
            "Together, we are unstoppable!",
            "I will never abandon you, {0}!",
            "By your side, always!",
            "For honor and for {0}!",
            "With you, I fear nothing!",
            "We've trained for this moment!",
            "You lead, and I shall follow!",
            "Nothing shall break our bond!",
            "We fight as one!",
            "You picked the wrong fight!",
            "I'll make you regret that!",
            "You're no match for me!",
            "Let's see what you're made of!",
            "I'll bite harder than you can handle!",
            "I eat weaklings like you for breakfast!",
            "You will fall before me!",
            "I'll crush your bones!",
            "Tremble before my might!",
            "You will learn to fear me!"
        };

        public static void TryTamingGain(BaseCreature pet, Mobile target)
        {
            if (pet == null || target == null)
                return;

            PlayerMobile owner = pet.ControlMaster as PlayerMobile;
            if (owner == null)
                return;

            // Check if player is on cooldown
            DateTime lastGainTime;
            if (_tamingCooldowns.TryGetValue(owner, out lastGainTime))
            {
                if (DateTime.UtcNow < lastGainTime + TamingCooldown)
                {
                    //owner.SendMessage("You must wait before gaining more taming experience."); // debug line
                    return; // Player is still on cooldown, exit without gaining skill
                }
            }

            double tamingSkill = owner.Skills[SkillName.Taming].Base;
            double gainChance = 0.0;
            double minGain = 0.0, maxGain = 0.0;

            // Determine gain chance and amount based on skill level
            if (tamingSkill <= 30.0) { gainChance = 0.20; minGain = 0.1; maxGain = 0.3; }
            else if (tamingSkill <= 50.0) { gainChance = 0.15; minGain = 0.1; maxGain = 0.2; }
            else if (tamingSkill <= 70.0) { gainChance = 0.10; minGain = 0.1; maxGain = 0.1; }
            else if (tamingSkill <= 100.0) { gainChance = 0.05; minGain = 0.1; maxGain = 0.1; }

            // Attempt taming skill gain
            if (Utility.RandomDouble() < gainChance)
            {
                double tamingGain = minGain + (Utility.RandomDouble() * (maxGain - minGain)); // Random within range
                owner.Skills[SkillName.Taming].Base += tamingGain;

                // Select a random taming message
                string message = TamingMessages[Utility.Random(TamingMessages.Length)];

                // Display message over the pet's head
                pet.PublicOverheadMessage(MessageType.Regular, pet.SpeechHue, false, 
                    String.Format("{0} (+{1:F1} Taming)", String.Format(message, owner.Name), tamingGain));

                // Set cooldown time for this player
                _tamingCooldowns[owner] = DateTime.UtcNow;
            }
            else
            {
                // 10% chance to trigger a battle cry if no taming skill was gained
                TryPetBattleCry(pet);
            }
        }

        public static void TryPetBattleCry(BaseCreature pet)
        {
            if (pet == null || pet.ControlMaster == null)
                return;

            if (Utility.RandomDouble() < 0.10) // 10% chance if no skill gain
            {
                string battleCry = BattleCries[Utility.Random(BattleCries.Length)];

                // Display battle cry over the pet's head
                pet.PublicOverheadMessage(MessageType.Regular, pet.SpeechHue, false, 
                    String.Format(battleCry, pet.ControlMaster.Name));
            }
        }
    }
}
