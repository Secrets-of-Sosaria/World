using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Custom.DefenderOfTheRealm
{
    public static class MarkLootHelper
    {
        public static void CheckForMarks(BaseCreature bc, Container c, Mobile killer)
        {
            if (bc == null || c == null || killer == null)
                return;

            if (bc.Controlled || bc.Summoned || bc.Player)
                return;

            if (bc.Fame < 10000)
                return;
            
            if (Utility.RandomDouble() > 0.25)
                return;

            int baseMin = 1;
            int baseMax = 9;

            int luck = killer.Luck;
            if (luck < 0) luck = 0;
            if (luck > 2000) luck = 2000;

            int bonus = (luck * 2 / 2000);
            int amount = Utility.RandomMinMax(baseMin, baseMax + bonus);

            if (amount <= 0)
                return;

            if (bc.Karma >= 10000 && killer.Karma < 0)
            {
                c.DropItem(new MarksOfTheScourge(amount));
            }
            else if (bc.Karma <= -10000 && killer.Karma > 0)
            {
                c.DropItem(new MarksOfHonor(amount));
            }
        }
    }
}
