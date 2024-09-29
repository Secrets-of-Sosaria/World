using System;
using System.Collections.Generic;
using System.Text;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Gumps;

namespace Server.Misc
{
    public class StairRefundEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private LawnStair m_Stair;
        private int value = 0;

        public StairRefundEntry(Mobile from, LawnStair stair, int price): base(6104, 9)
        {
            m_From = from;
            m_Stair = stair;
            value = price;
        }

        public override void OnClick()
        {
            m_Stair.Refund( m_From );
        }
    }

    public class LawnSecurityEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private BaseDoor m_Gate;

        public LawnSecurityEntry(Mobile from, LawnGate gate): base(6203, 9)
        {
            m_From = from;
            m_Gate = gate;
        }

        public override void OnClick()
        {
            m_From.SendGump(new LawnSecurityGump(m_From, m_Gate));
        }
    }

    public class RefundEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private LawnGate m_Gate;
        private int value = 0;

        public RefundEntry(Mobile from, LawnGate gate, int price): base(6104, 9)
        {
            m_From = from;
            m_Gate = gate;
            value = price;
        }

        public override void OnClick()
        {
            m_Gate.Refund( m_From );
        }
    }

    public class ShantyStairShantyRefundEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private ShantyStair m_Stair;
        private int value = 0;

        public ShantyStairShantyRefundEntry(Mobile from, ShantyStair stair, int price): base(6104, 9)
        {
            m_From = from;
            m_Stair = stair;
            value = price;
        }

        public override void OnClick()
        {
            m_Stair.Refund( m_From );
        }
    }

    public class ShantySecurityEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private BaseDoor m_Gate;

        public ShantySecurityEntry(Mobile from, ShantyDoor gate): base(6203, 9)
        {
            m_From = from;
            m_Gate = gate;
        }

        public override void OnClick()
        {
            m_From.SendGump(new ShantySecurityGump(m_From, m_Gate));
        }
    }

    public class ShantyRefundEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private ShantyDoor m_Gate;
        private int value = 0;

        public ShantyRefundEntry(Mobile from, ShantyDoor gate, int price): base(6104, 9)
        {
            m_From = from;
            m_Gate = gate;
            value = price;
        }

        public override void OnClick()
        {
            m_Gate.Refund( m_From );
        }
    }
}