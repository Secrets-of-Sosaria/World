using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;

namespace Server.Custom.DefenderOfTheRealm
{
    public class RewardConfirmGump : Gump
    {
        private Mobile m_From;
        private RewardInfo m_Info;
        private bool m_IsDefender;
        private bool hueable;

        public RewardConfirmGump(Mobile from, RewardInfo info, bool isDefender) : base(100, 100)
        {
            m_From = from;
            m_Info = info;
            m_IsDefender = isDefender;
            string currencyType = m_IsDefender ? "Marks of Honor" : "Marks of the Scourge";
            int hue = 0;
            if (info.Hue > 0)
            {
                hue = info.Hue;
            }
            else if (info.Hueable)
            {
                hue = m_IsDefender ? 0x35 : 0x25;                    
            }
            AddBackground(0, 0, 300, 200, 9270);
            AddLabel(80, 20, 1152, "Confirm your selection");

            AddItem(40, 60, info.ItemID,hue);
            AddLabel(100, 60, 1152, info.Name);
            AddLabel(100, 80, 1153, "Cost: " + info.Cost+ " " + currencyType);

            AddButton(50, 150, 4005, 4007, 1, GumpButtonType.Reply, 0); // Yes
            AddLabel(90, 150, 1152, "Yes");

            AddButton(150, 150, 4017, 4019, 2, GumpButtonType.Reply, 0); // No
            AddLabel(190, 150, 1152, "No");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (info.ButtonID == 1)
            {
                Type currencyType = m_IsDefender ? typeof(MarksOfHonor) : typeof(MarksOfTheScourge);
                int total = 0;

                foreach (Item item in m_From.Backpack.FindItemsByType(currencyType))
                    total += item.Amount;

                if (total < m_Info.Cost)
                {
                    m_From.SendMessage("You have not proven yourself worthy of this item yet.");
                }
                else
                {
                    m_From.Backpack.ConsumeTotal(currencyType, m_Info.Cost);
                    Item reward = m_Info.CreateItem(m_IsDefender);
                    m_From.AddToBackpack(reward);
                    m_From.SendMessage("You receive: " + m_Info.Name);
                }
            }
        }
    }
}
