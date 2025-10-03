using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;

namespace Server.Custom.DefenderOfTheRealm
{
    public class RewardGump : Gump
    {
        private Mobile m_From;
        private RewardInfo[] m_Rewards;
        private int m_Page;
        private bool m_IsDefender;

        public RewardGump(Mobile from, bool isDefender, int page) : base(50, 50)
        {
            m_From = from;
            m_Page = page;
            m_IsDefender = isDefender;

            AddBackground(0, 0, 420, 420, 9270);
            AddLabel(160, 20, 1152, isDefender ? "Defender of the Realm Rewards" : "Scourge of the Realm Rewards");

            List<RewardInfo> list = new List<RewardInfo>();
            list.AddRange(RewardTables.CommonRewards);
            if (isDefender)
                list.AddRange(RewardTables.DefenderRewards);
            else
                list.AddRange(RewardTables.ScourgeRewards);

            m_Rewards = list.ToArray();

            int perPage = 6;
            int start = page * perPage;
            int end = Math.Min(start + perPage, m_Rewards.Length);

            int x = 30, y = 60;
            for (int i = start; i < end; i++)
            {
                RewardInfo info = m_Rewards[i];
                int buttonID = 1000 + i;
                int hue = 0;
                string currencyType = m_IsDefender ? "Marks of Honor" : "Marks of the Scourge";
                if (info.Hue > 0)
                {
                    hue = info.Hue;
                }
                else if (info.Hueable)
                {
                    hue = m_IsDefender ? 0x35 : 0x25;
                }

                AddItem(x, y, info.ItemID,hue);
                AddLabel(x + 50, y, 1152, info.Name);
                AddLabel(x + 50, y + 20, 1153, "Cost: " + info.Cost+ " " + currencyType);
                AddButton(x + 300, y, 4005, 4007, buttonID, GumpButtonType.Reply, 0);

                y += 50;
            }

            if (page > 0)
                AddButton(100, 380, 4014, 4016, 1, GumpButtonType.Reply, 0); // prev
            if (end < m_Rewards.Length)
                AddButton(250, 380, 4005, 4007, 2, GumpButtonType.Reply, 0); // next
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (info.ButtonID == 1) // prev
                m_From.SendGump(new RewardGump(m_From, m_IsDefender, m_Page - 1));
            else if (info.ButtonID == 2) // next
                m_From.SendGump(new RewardGump(m_From, m_IsDefender, m_Page + 1));
            else if (info.ButtonID >= 1000)
            {
                int index = info.ButtonID - 1000;
                if (index >= 0 && index < m_Rewards.Length)
                    m_From.SendGump(new RewardConfirmGump(m_From, m_Rewards[index], m_IsDefender));
            }
        }
    }
}
