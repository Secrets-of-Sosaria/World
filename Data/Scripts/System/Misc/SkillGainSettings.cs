using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Mobiles;


public static class SkillGainSettings
{
    private static Hashtable m_ShowChance = new Hashtable();

    public static bool ShowChance(Mobile m)
    {
        return m != null && m_ShowChance.Contains(m) && (bool)m_ShowChance[m];
    }

    public static void Toggle(Mobile m)
    {
        if (m == null) return;

        bool current = ShowChance(m);
        m_ShowChance[m] = !current;

        m.SendMessage("Skill gain chance display has been {0}.", current ? "disabled" : "enabled");
    }
}
