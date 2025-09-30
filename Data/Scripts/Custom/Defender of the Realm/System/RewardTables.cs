using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.DefenderOfTheRealm
{
    public class RewardTables
    {
        public static RewardInfo[] CommonRewards = new RewardInfo[]
        {
            new RewardInfo(typeof(RoughEnhancementStone),50,0x1F14,"Rough Enhancement Stone",false),
            new RewardInfo(typeof(HeavyEnhancementStone),100,0x1F14,"Heavy Enhancement Stone",false),
            new RewardInfo(typeof(SlayerDeed), 1000, 0x400B, "Slayer Deed",false),
            new RewardInfo(typeof(EtherealPowerScroll), 750, 0x14F0, "Ethereal Power Scroll",false),
            new RewardInfo(typeof(EternalPowerScroll), 1000, 0x14F0, "Eternal Power Scroll",false),
            new RewardInfo(typeof(LuckyHorseShoes), 1250, 0xFB6, "Lucky Horse Shoes",false),
            new RewardInfo(typeof(ChargerOfTheFallen), 500, 0x0499, "Charger of the Fallen",true),
            new RewardInfo(typeof(EtherealReptalon), 500, 0x2D95, "Ethereal Reptalon",true),
            new RewardInfo(typeof(EtherealHorse), 250, 0x20DD, "Ethereal Horse",true),
            new RewardInfo(typeof(EtherealLlama), 250, 0x20F6, "Ethereal Llama",true),
            new RewardInfo(typeof(EtherealOstard), 250, 0x2135, "Ethereal Ostard",true),
            new RewardInfo(typeof(MagicalDyes), 50, 0xF7D, "Magical Dyes",true)
        };

        public static RewardInfo[] DefenderRewards = new RewardInfo[]
        {
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmArms), 900, 0x1410, "Defender's Arms",true),
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmChestpiece), 1000, 0x1415, "Defender's Chest",true),
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmGloves), 900, 0x1414, "Defender's Gloves",true),
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmGorget), 900, 0x1413, "Defender's Gorget",true),
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmHelmet), 900, 0x1412, "Defender's Helmet",true),
            new RewardInfo(typeof(Artifact_DefenderOfTheRealmLeggings), 1000, 0x46AA, "Defender's Leggings",true)
        };

        public static RewardInfo[] ScourgeRewards = new RewardInfo[]
        {
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmArms), 900, 0x1410, "Scourge's Arms",true),
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmChestpiece), 1000, 0x1415, "Scourge's Chest",true),
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmGloves), 900, 0x1414, "Scourge's Gloves",true),
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmGorget), 900, 0x1413, "Scourge's Gorget",true),
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmHelmet), 900, 0x1412, "Scourge's Helmet",true),
            new RewardInfo(typeof(Artifact_ScourgeOfTheRealmLeggings), 1000, 0x46AA, "Scourge's Leggings",true)
        };
    }
}
