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
        private static Dictionary<PlayerMobile, DateTime> _tamingCooldowns = new Dictionary<PlayerMobile, DateTime>();

        private static readonly TimeSpan TamingCooldown = TimeSpan.FromSeconds(MyServerSettings.KoperCooldown()); //  Set cooldown time (20 Seconds default)

        private static readonly string[] TamingMessages = new string[]
        {
            "*{0} seems to trust their master more.*",
            "*{0} appears more in sync with their master.*",
            "*{0} moves with greater confidence alongside their master.*",
            "*{0} looks to their master with newfound understanding.*",
            "*{0} follows their master's guidance more closely.*",
            "*{0} seems to grow stronger under their master's leadership.*",
            "*{0} and their master fight in perfect harmony.*",
            "*{0} moves with greater coordination beside their master.*",
            "*{0} watches their master carefully, learning from every movement.*",
            "*{0} responds to commands with increased precision.*",
            "*{0} fights as though truly bonded with their master.*",
            "*{0} appears more devoted to their master's cause.*",
            "*{0} follows their master with unwavering loyalty.*",
            "*{0} carries themselves with a newfound sense of purpose.*",
            "*{0} seems more confident with their master by their side.*",
            "*{0} appears more attuned to their master's presence.*",
            "*{0} trusts their master more deeply after the battle.*",
            "*{0} has grown more in tune with their master's instincts.*",
            "*{0} learns from their master's movements, adapting quickly.*",
            "*{0} fights with the precision of a well-trained companion.*",
            "*{0} and their master move as one in battle.*",
            "*{0} seems to have strengthened their bond through combat.*",
            "*{0} watches their master with admiration and understanding.*",
            "*{0} seems to feel a stronger connection with their master.*",
            "*{0} reacts instantly to their master's unspoken commands.*",
            "*{0} stands by their master with newfound resolve.*",
            "*{0} seems more attuned to their master's emotions and intent.*",
            "*{0} moves with perfect synchronization beside their master.*",
            "*{0} fights with the dedication of a truly loyal companion.*",
            "*{0} carries themselves like a seasoned warrior beside their master.*"
        };

        private static readonly string[] BattleCries = new string[]
        {
            "*{0} fights with everything they have!*",
            "*{0} defends their master with unshakable loyalty!*",
            "*{0} lunges at the enemy with full force!*",
            "*{0} refuses to back down!*",
            "*{0} charges fearlessly into battle!*",
            "*{0} fights tooth and claw to protect their master!*",
            "*{0} moves with incredible speed and precision!*",
            "*{0} strikes fiercely, showing no mercy!*",
            "*{0} launches a devastating attack!*",
            "*{0} fights like a true warrior of the wild!*",
            "*{0} stands their ground, refusing to falter!*",
            "*{0} thrashes about with raw fury!*",
            "*{0} roars in defiance as they attack!*",
            "*{0} pushes themselves to the limit!*",
            "*{0} is a blur of movement, overwhelming their foe!*",
            "*{0} unleashes a powerful assault!*",
            "*{0} gives it their all, undeterred by danger!*",
            "*{0} fights with the might of a beast unchained!*",
            "*{0} is relentless, never giving an inch!*",
            "*{0} fights with unwavering determination!*",
            "*{0} refuses to let their master come to harm!*",
            "*{0} battles fiercely, driven by instinct!*",
            "*{0} moves like a storm, striking again and again!*",
            "*{0} delivers a crushing blow!*",
            "*{0} does not hesitate, striking with full force!*",
            "*{0} tears into their foe with savage intent!*",
            "*{0} battles like a beast possessed!*",
            "*{0} is relentless in their pursuit of victory!*",
            "*{0} meets their foe head-on without fear!*",
            "*{0} fights as if their very survival depends on it!*"
        };


        public static void TryTamingGain(BaseCreature pet, Mobile target)
        {
            if (pet == null || target == null || !MyServerSettings.KoperPets())
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
            double tamingMultiplier = MyServerSettings.KoperTamingChance();  // Determine gain chance and amount based on skill level
          
            // Determine gain chance and amount based on skill level
            if (tamingMultiplier <= 0) tamingMultiplier = 1.0; // Ensure valid value
            if (tamingMultiplier >= 10) tamingMultiplier = 10.0; // Ensure valid value
            if (tamingSkill <= 30.0) { gainChance = 0.20 * tamingMultiplier;}
            else if (tamingSkill <= 50.0) { gainChance = 0.15 * tamingMultiplier;}
            else if (tamingSkill <= 70.0) { gainChance = 0.10 * tamingMultiplier;}
            else if (tamingSkill < 125.0) { gainChance = 0.05 * tamingMultiplier;}
            else return; // No gain if at max skill

            // Attempt taming skill gain
            if (Utility.RandomDouble() < gainChance)
            {
                owner.CheckSkill(SkillName.Taming, 0.0 , 125.0);
            
                // Select a random taming message
                string message = string.Format(TamingMessages[Utility.Random(TamingMessages.Length)], pet.Name);

                // Display message in system log
                owner.SendMessage(0x83A, message);

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

            if (Utility.RandomDouble() < 0.10 && MyServerSettings.KoperPetsImmersive()) // 10% chance if no skill gain
            {
                string battleCry = String.Format(BattleCries[Utility.Random(BattleCries.Length)], pet.Name);

                // Display battle cry in grey text
                pet.PublicOverheadMessage(MessageType.Emote, 0x83A, false, battleCry);
            }
        }
    }
}
