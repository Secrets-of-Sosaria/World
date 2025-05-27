using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Systems
{
    public enum ContrabandRarity
    {
        Common,
        Uncommon,
        Rare,
        VeryRare,
        ExtremelyRare,
        Legendary
    }

    public static class ContrabandSystem
    {
        public static void TryGiveContraband(Mobile thief, Mobile victim)
        {
            if (thief == null || victim == null)
                return;

            // Base chance: stealing skill / 10
            double stealSkill = thief.Skills[SkillName.Stealing].Value;
            // Luck bonus: 2000 luck = +10% => luck / 20000
            double luckBonus;
            if (thief.Luck <= 0)
            {
                luckBonus = 0;
            } 
            else if (thief.Luck > 2000) 
            {
                luckBonus = 10.0;
            } 
            else
            {
                luckBonus = thief.Luck / 20000.0; 
            }

            double chance = (stealSkill / 10.0) + luckBonus;

            // Roll for any contraband
            if (Utility.RandomDouble() * 100.0 > chance)
                return;

            // Determine rarity
            ContrabandRarity rarity = DetermineRarity(victim.Fame);

            // Create and award box
            Item box = CreateContrabandBox(rarity);
            thief.AddToBackpack(box);
            thief.SendMessage("You have acquired a {0} contraband box!", rarity);
            Effects.PlaySound(thief.Location, thief.Map, 0x32);
        }

        private static ContrabandRarity DetermineRarity(int fame)
        {
            double roll = Utility.RandomDouble() * 100.0;

            if (fame >= 15000)
            {
                if (roll <  4.0) return ContrabandRarity.Legendary;
                if (roll <  8.0) return ContrabandRarity.ExtremelyRare;
                if (roll <  16.0) return ContrabandRarity.VeryRare;
                if (roll <  32.0) return ContrabandRarity.Rare;
                return ContrabandRarity.Uncommon;
            }
            else if (fame >= 7500)
            {
                if (roll <  2.0) return ContrabandRarity.Legendary;
                if (roll <  4.0) return ContrabandRarity.ExtremelyRare;
                if (roll <  8.0) return ContrabandRarity.VeryRare;
                if (roll <  16.0) return ContrabandRarity.Rare;
                if (roll <  48.0) return ContrabandRarity.Uncommon;
                return ContrabandRarity.Common;
            }
            else if (fame >= 5000)
            {
                if (roll <  2.0) return ContrabandRarity.ExtremelyRare;
                if (roll <  4.0) return ContrabandRarity.VeryRare;
                if (roll <  8.0) return ContrabandRarity.Rare;
                if (roll <  32.0) return ContrabandRarity.Uncommon;
                return ContrabandRarity.Common;
            }
            else if (fame >= 1000)
            {
                if (roll <  2.0) return ContrabandRarity.VeryRare;
                if (roll <  4.0) return ContrabandRarity.Rare;
                if (roll <  24.0) return ContrabandRarity.Uncommon;
                return ContrabandRarity.Common;
            }
            else
            {
                if (roll <  8.0) return ContrabandRarity.Uncommon;
                return ContrabandRarity.Common;
            }
        }

        private static Item CreateContrabandBox(ContrabandRarity rarity)
        {
            Item box;
            switch (rarity)
            {
                case ContrabandRarity.Legendary:     box = new LegendaryContrabandBox(); break;
                case ContrabandRarity.ExtremelyRare: box = new ExtremelyRareContrabandBox(); break;
                case ContrabandRarity.VeryRare:      box = new VeryRareContrabandBox(); break;
                case ContrabandRarity.Rare:          box = new RareContrabandBox(); break;
                case ContrabandRarity.Uncommon:      box = new UncommonContrabandBox(); break;
                default:                             box = new CommonContrabandBox(); break;
            }

            box.Name     = String.Format("{0} Contraband Box", rarity);
            box.Weight   = 5.0;
            box.Movable  = true;
            return box;
        }
    }
}
