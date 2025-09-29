using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;
using Server.Custom.DefenderOfTheRealm.Knight;
using Server.Custom.DefenderOfTheRealm.VowGump;

namespace Server.Custom.DefenderOfTheRealm.Vow
{
    public class VowOfHonor : Item
    {
        private string m_OwnerName;
        private int m_Level;
        private int m_Required;
        private int m_Current;
        private int m_Reward;

        public string OwnerName { get { return m_OwnerName; } set { m_OwnerName = value; InvalidateProperties(); } }
        public int Level { get { return m_Level; } set { m_Level = value; InvalidateProperties(); } }
        public int Required { get { return m_Required; } set { m_Required = value; InvalidateProperties(); } }
        public int Current { get { return m_Current; } set { m_Current = value; InvalidateProperties(); } }
        public int Reward { get { return m_Reward; } set { m_Reward = value; InvalidateProperties(); } }

        [Constructable]
        public VowOfHonor(Mobile from) : base(5360)
        {
            Hue = 0x35;
            LootType = LootType.Blessed;
            Name = from.Name+"'s Vow of Honor";
            m_OwnerName = from.Name;
            m_Level = IntelligentAction.GetCreatureLevel(from);
            m_Required = GetRequiredAmount(m_Level);
            m_Current = 0;
            m_Reward = 0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from == null || from.Deleted)
                return;

            if (from.Backpack == null || !IsChildOf(from.Backpack))
            {
                from.SendMessage("The Vow must be in your backpack to use.");
                return;
            }

            from.SendGump(new VowOfHonorGump(from, this));
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("Belongs to {0}", m_OwnerName);
            list.Add("A vow to slay {0} deadly enemies", m_Required);
            list.Add("Progress: {0}/{1}", m_Current, m_Required);
            list.Add("Reward so far: {0} Gold", m_Reward);
        }

        private int GetRequiredAmount(int level)
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

        public void AddTrophy(Mobile from)
        {
            if (m_Current >= m_Required)
                return;

            int luck = from.Luck;
            if (luck > 2000) luck = 2000;

            int gold = 50 + (luck * (335 - 50) / 2000);//at 2k luck, base reward is always 335 at 2k luck and 50 at 0 luck
            m_Current++;
            m_Reward += Utility.RandomMinMax((int)(gold * 0.8), (int)(gold * 1.2));//adds a 20% variance to the base reward
            InvalidateProperties();

            from.SendMessage("You add a trophy to your Vow of Honor.");

            if (m_Current >= m_Required)
            {
                from.SendMessage("Your vow is complete!");
            }
        }

        public VowOfHonor(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
            writer.Write(m_OwnerName);
            writer.Write(m_Level);
            writer.Write(m_Required);
            writer.Write(m_Current);
            writer.Write(m_Reward);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_OwnerName = reader.ReadString();
            m_Level = reader.ReadInt();
            m_Required = reader.ReadInt();
            m_Current = reader.ReadInt();
            m_Reward = reader.ReadInt();
        }
        public override bool OnDroppedToMobile(Mobile from, Mobile target)
        {
            if (target == null || !(target is DefenderOfRealm))
            {
                from.SendMessage("You can only complete your Vow with a Defender of the Realm.");
                return false;
            }
            if (from.Name != m_OwnerName)
            {
                from.SendMessage("This Vow does not belong to you!");
                return false;
            }
            if (m_Current < m_Required)
            {
                from.SendMessage("Your vow is not yet complete. You need {0} more trophies.", m_Required - m_Current);
                return false;
            }
            if (from.Backpack == null || from.Backpack.Items.Count >= from.Backpack.MaxItems)
            {
                from.SendMessage("You do not have enough space in your backpack to receive the rewards.");
                return false;
            }
            Bag rewardBag = new Bag();
            rewardBag.Name = "Deeds of Valor";
            rewardBag.Hue = 0x35;
            GenerateRewards(from, m_Reward, rewardBag);
            rewardBag.DropItem(new Gold(m_Reward));
            from.AddToBackpack(rewardBag);
            from.SendMessage("You have completed your Vow of Honor and received a bag containing {0} gold and additional rewards!", m_Reward);
            Effects.PlaySound(from.Location, from.Map, 0x243);
            this.Delete();
            return true;
        }

        private void GenerateRewards(Mobile from, int rewardWorth, Container rewardBag)
        {
            CheckForDefenderArtifact(rewardWorth, rewardBag);

            if (rewardWorth < 500)
            {
                GenerateEnchantedItem(from, 75, rewardBag);
                rewardBag.DropItem(Loot.RandomScroll(1));
                rewardBag.DropItem(Loot.RandomPotion(4, false));
            }
            else if (rewardWorth < 1000)
            {
                GenerateEnchantedItem(from, 150, rewardBag);
                rewardBag.DropItem(Loot.RandomGem());
                rewardBag.DropItem(Loot.RandomPotion(4, false));
                rewardBag.DropItem(Loot.RandomPotion(4, false));
                rewardBag.DropItem(Loot.RandomScroll(3));
            }
            else if (rewardWorth < 2000)
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
            else if (rewardWorth < 4000)
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
            else if (rewardWorth < 6000)
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
            else if (rewardWorth < 8000)
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
            else if (rewardWorth < 9000)
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
            else if (rewardWorth < 10000)
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
            else if (rewardWorth < 12000)
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
            else if (rewardWorth < 14000)
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
        }

        private void CheckForDefenderArtifact(int rewardWorth, Container rewardBag)
        {
            double chance = 0.0;

            if (rewardWorth < 500)
            {
                chance = 0.01; // 1% chance
            }
            else if (rewardWorth < 1000)
            {
                chance = 0.02; // 2% chance
            }
            else if (rewardWorth < 2000)
            {
                chance = 0.02; // 2% chance
            }
            else if (rewardWorth < 4000)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 6000)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 8000)
            {
                chance = 0.03; // 3% chance
            }
            else if (rewardWorth < 9000)
            {
                chance = 0.04; // 4% chance
            }
            else if (rewardWorth < 10000)
            {
                chance = 0.04; // 4% chance
            }
            else if (rewardWorth < 12000)
            {
                chance = 0.05; // 5% chance
            }
            else if (rewardWorth < 14000)
            {
                chance = 0.06; // 6% chance
            }
            else
            {
                chance = 0.25; // 25% chance
            }

            if (Utility.RandomDouble() < chance)
            {
                Item artifact = CreateRandomDefenderArtifact();
                if (artifact != null)
                {
                    rewardBag.DropItem(artifact);
                }
            }
        }

        private Item CreateRandomDefenderArtifact()
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

        private void GenerateEnchantedItem(Mobile from, int enchantLevel, Container rewardBag)
        {
            Item item = Loot.RandomMagicalItem(Server.LootPackEntry.playOrient(from));
            if (item != null)
            {
                item = LootPackEntry.Enchant(from, enchantLevel, item);
                rewardBag.DropItem(item);
            }
        }
    }

    public class VowTrophyTarget : Target
    {
        private VowOfHonor m_Vow;
        private Mobile m_From;

        public VowTrophyTarget(Mobile from, VowOfHonor vow) : base(1, false, TargetFlags.None)
        {
            m_From = from;
            m_Vow = vow;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (m_Vow == null || m_Vow.Deleted)
                return;
            Item item = targeted as Item;
            if (item == null)
            {
                from.SendMessage("That is not a valid trophy. Only items acquired from fearsome foes in deep dungeons can be added to it.");
                return;
            }
            if (from.Name != m_Vow.OwnerName)
            {
                from.SendMessage("This vow does not belong to you!");
                return;
            }
            if (!(item is SummonItems))
            {
                from.SendMessage("That item cannot be added to your Vow. Only items acquired from fearsome foes in deep dungeons can be added to it.");
                return;
            }
            SummonItems summonItem = (SummonItems)item;
            if (summonItem.Owner == null)
            {
                from.SendMessage("This trophy has no owner and cannot be added to your vow.");
                return;
            }
            if (summonItem.Owner.Name != m_Vow.OwnerName)
            {
                from.SendMessage("This trophy was not seized by you!");
                return;
            }
            item.Delete();
            m_Vow.AddTrophy(from);
        }
    }
}
