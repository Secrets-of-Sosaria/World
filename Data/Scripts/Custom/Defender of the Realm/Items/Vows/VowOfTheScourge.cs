using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;
using Server.Custom.DefenderOfTheRealm.Scourge;
using Server.Custom.ScourgeOfTheRealm.VowGump;

namespace Server.Custom.DefenderOfTheRealm.Vow.VowOfTheScourge
{
    public class VowOfTheScourge : Item
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
        public VowOfTheScourge(Mobile from) : base(5360)
        {
            Hue = 0x25;
            LootType = LootType.Blessed;
            Name = from.Name+"'s Vow of the Scourge";
            m_OwnerName = from.Name;
            m_Level = IntelligentAction.GetCreatureLevel(from);
            m_Required = VowRewardHelper.GetRequiredAmount(m_Level);
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

            from.SendGump(new VowOfTheScourgeGump(from, this));
        }

        public override string DefaultDescription{ get{ return "A Vow represents a commitment to slay fearsome foes that dwell in dungeons. Once its completed, bring it to the one that bestowed it upon you. Say 'rewards' to that person in order to see what gifts can be bestowed upon you by completing them."; } }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("Belongs to {0}", m_OwnerName);
            list.Add("A vow to aqquire {0} trophies", m_Required);
            list.Add("Progress: {0}/{1}", m_Current, m_Required);
            list.Add("Reward so far: {0} Marks", m_Reward);
        }

        public void AddTrophy(Mobile from)
        {
            if (m_Current >= m_Required)
                return;

            int luck = from.Luck;
            if (luck > 2000) luck = 2000;

            int marks = 2 + (luck * (8) / 2000);//2-10 marks added based on player's luck
            m_Current++;
            m_Reward += Utility.RandomMinMax((int)(marks * 0.6), (int)(marks * 1.2)) < 1 ? 1 : Utility.RandomMinMax((int)(marks * 0.6), (int)(marks * 1.2));
            InvalidateProperties();
            from.SendMessage("You add a trophy to your vow of the Scourge.");
            if (m_Current >= m_Required)
            {
                from.SendMessage("Your vow of the Scourge is complete!");
            }
        }

        public VowOfTheScourge(Serial serial) : base(serial)
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
            if (target == null || !(target is ScourgeOfRealm))
            {
                from.SendMessage("You can only complete your Vow with a Scourge of the Realm.");
                return false;
            }
            if (from.Name != m_OwnerName)
            {
                from.SendMessage("This vow does not belong to you!");
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
            rewardBag.Name = "Spoils of War";
            rewardBag.Hue = 0x25;
            VowRewardHelper.GenerateRewards(from, m_Reward, rewardBag,VowType.Scourge);
            rewardBag.DropItem(new MarksOfTheScourge(m_Reward));
            from.AddToBackpack(rewardBag);
            from.SendMessage("You have completed your Vow of the Scourge and received a bag containing {0} marks of the Scourge and additional rewards!", m_Reward);
            Effects.PlaySound(from.Location, from.Map, 0x243);
            this.Delete();
            return true;
        }
    }

    public class VowTrophyTarget : Target
    {
        private VowOfTheScourge m_Vow;
        private Mobile m_From;

        public VowTrophyTarget(Mobile from, VowOfTheScourge vow) : base(1, false, TargetFlags.None)
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
