using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.DefenderOfTheRealm.Vow
{
    public enum VowType
    {
        Honor,
        Scourge
    }

    public static class VowRewardHelper
    {
        public static int GetRequiredAmount(int level)
        {
            Random rand = new Random();

            if (level <= 15)
                return rand.Next(2, 6);
            if (level <= 25)
                return rand.Next(3, 7);
            if (level <= 45)
                return rand.Next(4, 9);
            if (level <= 76)
                return rand.Next(5, 10);
            if (level <= 99)
                return rand.Next(6, 12);
            if (level <= 105)
                return rand.Next(7, 15);
            if (level <= 111)
                return rand.Next(8, 18);
            if (level <= 120)
                return rand.Next(9, 23);
            if (level <= 124)
                return rand.Next(10, 29);
            return rand.Next(15, 36);
        }

        public static void GenerateRewards(Mobile from, int rewardWorth, Container rewardBag, VowType type)
        {
            if (rewardWorth < 5)
            {
                GenerateEnchantedItem(from, 75, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(1));
                rewardBag.DropItem(Loot.RandomPotion(4, false));
            }
            else if (rewardWorth < 10)
            {
                GenerateEnchantedItem(from, 150, rewardBag);
                rewardBag.DropItem(Loot.RandomGem());
                rewardBag.DropItem(Loot.RandomPotion(4, false));
                rewardBag.DropItem(Loot.RandomPotion(4, false));
                rewardBag.DropItem(Loot.RandomScroll(3));
            }
            else if (rewardWorth < 20)
            {
                GenerateEnchantedItem(from, 200, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(4));
                rewardBag.DropItem(Loot.RandomGem());
                rewardBag.DropItem(Loot.RandomGem());
                if (Utility.RandomDouble() < 0.10)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 10));
                }
            }
            else if (rewardWorth < 40)
            {
                GenerateEnchantedItem(from, 250, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(5));
                rewardBag.DropItem(Loot.RandomPotion(8, false));
                rewardBag.DropItem(Loot.RandomPotion(8, false));
                if (Utility.RandomDouble() < 0.20)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 15));
                }
            }
            else if (rewardWorth < 60)
            {
                GenerateEnchantedItem(from, 300, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(6));
                rewardBag.DropItem(Loot.RandomPotion(8, false));
                if (Utility.RandomDouble() < 0.20)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                }
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 15));
                }
            }
            else if (rewardWorth < 80)
            {
                GenerateEnchantedItem(from, 350, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(8));
                rewardBag.DropItem(Loot.RandomPotion(12, false));
                rewardBag.DropItem(Loot.RandomPotion(12, false));
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                }
                if (Utility.RandomDouble() < 0.60)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 15));
                }
            }
            else if (rewardWorth < 90)
            {
                GenerateEnchantedItem(from, 400, rewardBag);
                if (Utility.RandomDouble() < 0.05)
                {
                    rewardBag.DropItem(Loot.RandomSArty(Server.LootPackEntry.playOrient(from), from));
                }
                if (Utility.RandomDouble() < 0.60)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                }
                if (Utility.RandomDouble() < 0.80)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 15));
                }
            }
            else if (rewardWorth < 100)
            {
                GenerateEnchantedItem(from, 450, rewardBag);
                rewardBag.DropItem(Loot.RandomRare(Utility.RandomMinMax(6, 12), from));
                if (Utility.RandomDouble() < 0.15)
                {
                    rewardBag.DropItem(Loot.RandomSArty(Server.LootPackEntry.playOrient(from), from));
                }
                if (Utility.RandomDouble() < 0.80)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                }
                if (Utility.RandomDouble() < 0.20)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(10, 15));
                }
                rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 15));
                if (Utility.RandomDouble() < 0.20)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                }
            }
            else if (rewardWorth < 120)
            {
                rewardBag.DropItem(Loot.RandomRelic(from));
                GenerateEnchantedItem(from, 500, rewardBag);
                if (Utility.RandomDouble() < 0.35)
                {
                    rewardBag.DropItem(Loot.RandomSArty(Server.LootPackEntry.playOrient(from), from));
                }
                rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(10, 15));
                }
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                }
            }
            else if (rewardWorth < 140)
            {
                rewardBag.DropItem(Loot.RandomSArty(Server.LootPackEntry.playOrient(from), from));
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(Loot.RandomRelic(from));
                }
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(Loot.RandomRare(Utility.RandomMinMax(6, 12), from));
                }
                rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                rewardBag.DropItem(PowerScroll.CreateRandom(10, 15));
                if (Utility.RandomDouble() < 0.60)
                {
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                    rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                }
                if (Utility.RandomDouble() < 0.40)
                {
                    rewardBag.DropItem(PowerScroll.CreateRandom(15, 25));
                }
                if(Utility.RandomDouble() < 0.05 )
                {
                    rewardBag.DropItem(new EternalPowerScroll());
                }
                GenerateEnchantedItem(from, 500, rewardBag);
                GenerateEnchantedItem(from, 500, rewardBag);
            }
            else
            {
                rewardBag.DropItem(Loot.RandomSArty(Server.LootPackEntry.playOrient(from), from));
                rewardBag.DropItem(Loot.RandomRelic(from));
                rewardBag.DropItem(Loot.RandomRare(Utility.RandomMinMax(6, 12), from));
                rewardBag.DropItem(PowerScroll.CreateRandom(5, 10));
                rewardBag.DropItem(PowerScroll.CreateRandom(10, 15));
                rewardBag.DropItem(PowerScroll.CreateRandom(15, 25));
                rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                rewardBag.DropItem(ScrollofTranscendence.CreateRandom(5, 25));
                GenerateEnchantedItem(from, 500, rewardBag);
                GenerateEnchantedItem(from, 500, rewardBag);
                GenerateEnchantedItem(from, 500, rewardBag);
                if(Utility.RandomDouble() < 0.25 )
                {
                    rewardBag.DropItem(new EternalPowerScroll());
                }
            }
            // Chance for artifacts
            if (CheckForArtifact(rewardWorth, from))
            {
                Item arty = CreateRandomArtifact(from, type);
                if (arty != null)
                    rewardBag.DropItem(arty);
            }
        }

        public static bool CheckForArtifact(int rewardWorth, Mobile from)
        {
            double chance = 0.0;

            if (rewardWorth < 5)
            {
                chance = 0.01; // 1% chance
            }
            else if (rewardWorth < 10)
            {
                chance = 0.02; // 2% chance
            }
            else if (rewardWorth < 20)
            {
                chance = 0.02; // 2% chance
            }
            else if (rewardWorth < 40)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 60)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 800)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 90)
            {
                chance = 0.04; // 4% chance
            }
            else if (rewardWorth < 100)
            {
                chance = 0.04; // 4% chance
            }
            else if (rewardWorth < 120)
            {
                chance = 0.05; // 5% chance
            }
            else if (rewardWorth < 140)
            {
                chance = 0.06; // 6% chance
            }
            else
            {
                chance = 0.25; // 25% chance
            }
            
            return Utility.RandomDouble() < chance;
        }

        public static Item CreateRandomArtifact(Mobile from, VowType type)
        {
            Item item = null;

            if (type == VowType.Honor)
            {
               switch (Utility.Random(6))
                {
                    case 0: 
                        return new Artifact_DefenderOfTheRealmArms();
                    case 1: 
                        return new Artifact_DefenderOfTheRealmChestpiece();
                    case 2: 
                        return new Artifact_DefenderOfTheRealmGloves();
                    case 3: 
                        return new Artifact_DefenderOfTheRealmGorget();
                    case 4: 
                        return new Artifact_DefenderOfTheRealmHelmet();
                    case 5: 
                        return new Artifact_DefenderOfTheRealmLeggings();
                    default: //hacky, need to think of a better implementation
                        return new Artifact_DefenderOfTheRealmArms();
                }
            }
            else
            {
                switch (Utility.Random(6))
                {
                    case 0: 
                        return new Artifact_ScourgeOfTheRealmArms();
                    case 1: 
                        return new Artifact_ScourgeOfTheRealmChestpiece();
                    case 2: 
                        return new Artifact_ScourgeOfTheRealmGloves();
                    case 3: 
                        return new Artifact_ScourgeOfTheRealmGorget();
                    case 4: 
                        return new Artifact_ScourgeOfTheRealmHelmet();
                    case 5: 
                        return new Artifact_ScourgeOfTheRealmLeggings();
                    default: //hacky, need to think of a better implementation
                        return new Artifact_ScourgeOfTheRealmArms();
                }
            }

            if (item != null)
                return item;
        }
        public static void GenerateEnchantedItem(Mobile from, int enchantLevel, Container rewardBag)
        {
            Item item = Loot.RandomMagicalItem(Server.LootPackEntry.playOrient(from));
            if (item != null)
            {
                item = LootPackEntry.Enchant(from, enchantLevel, item);
                rewardBag.DropItem(item);
            }
        }
    }
}
