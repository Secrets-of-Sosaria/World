using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Custom.DefenderOfTheRealm.Vow;

namespace Server.Custom.DefenderOfTheRealm.VowGump
{
    public class VowOfHonorGump : Gump
    {
        private VowOfHonor m_Vow;
        private Mobile m_From;

        public VowOfHonorGump(Mobile from, VowOfHonor vow) : base(50, 50)
        {
            m_From = from;
            m_Vow = vow;

            AddPage(0);

            AddBackground(0, 0, 300, 200, 9270);
            AddLabel(50, 20, 1152, "Vow of Honor");

            AddLabel(20, 50, 1152, "Vow for: " + m_Vow.Required + " deadly enemies");
            AddLabel(20, 70, 1152, "Quantity Slain: " + m_Vow.Current + "/" + m_Vow.Required);
            AddLabel(20, 90, 1152, "Reward: " + m_Vow.Reward + " Marks of Honor");

            if (m_Vow.Current < m_Vow.Required)
            {
                AddButton(100, 130, 4005, 4007, 1, GumpButtonType.Reply, 0);
                AddLabel(135, 130, 1152, "Add Trophy");
            }
            else
            {
                AddLabel(20, 130, 1152, "Return to the Defender of the Realm");
                 AddLabel(20, 150, 1152, "for your reward");
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1 && m_Vow != null && !m_Vow.Deleted)
            {
                m_From.Target = new VowTrophyTarget(m_From, m_Vow);
            }
        }
    }
}
