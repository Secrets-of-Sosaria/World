using System;
using System.Collections.Generic;
using Server;

namespace Server
{
    public static class HealingCooldownTracker
    {
        private static Dictionary<Mobile, DateTime> m_BandageUsers = new Dictionary<Mobile, DateTime>();
        private static Dictionary<Mobile, DateTime> m_VetSupplyUsers = new Dictionary<Mobile, DateTime>();

        public static bool IsOnBandageCooldown(Mobile m)
        {
            DateTime last;
            return m_BandageUsers.TryGetValue(m, out last) && DateTime.UtcNow < last;
        }

        public static bool IsOnVetSupplyCooldown(Mobile m)
        {
            DateTime last;
            return m_VetSupplyUsers.TryGetValue(m, out last) && DateTime.UtcNow < last;
        }

        public static void SetBandageCooldown(Mobile m, TimeSpan cooldown)
        {
            m_BandageUsers[m] = DateTime.UtcNow + cooldown;
        }

        public static void SetVetSupplyCooldown(Mobile m, TimeSpan cooldown)
        {
            m_VetSupplyUsers[m] = DateTime.UtcNow + cooldown;
        }

        public static void Cleanup()
        {
            DateTime now = DateTime.UtcNow;

            CleanupDict(m_BandageUsers, now);
            CleanupDict(m_VetSupplyUsers, now);
        }

        private static void CleanupDict(Dictionary<Mobile, DateTime> dict, DateTime now)
        {
            List<Mobile> toRemove = null;

            foreach (KeyValuePair<Mobile, DateTime> kvp in dict)
            {
                if (kvp.Value <= now)
                {
                    if (toRemove == null)
                        toRemove = new List<Mobile>();

                    toRemove.Add(kvp.Key);
                }
            }

            if (toRemove != null)
            {
                foreach (Mobile m in toRemove)
                    dict.Remove(m);
            }
        }
    }
}
