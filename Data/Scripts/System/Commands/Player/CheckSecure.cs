using System;
using Server;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
using Server.Commands;
using Server.Multis; // Added namespace

namespace Server.Scripts.Commands
{
    public class CheckSecureCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("CheckSecure", AccessLevel.Player, new CommandEventHandler(CheckSecure));
        }

        private static void CheckSecure(CommandEventArgs e)
        {
            Mobile player = e.Mobile;
            BaseHouse house = BaseHouse.FindHouseAt(player);

            if (house == null)
            {
                player.SendMessage("You are not in a house.");
                return;
            }

            List<Item> unsecuredItems = new List<Item>();

            foreach (Item item in player.GetItemsInRange(5)) 
            {
                BaseHouse itemHouse = BaseHouse.FindHouseAt(item);

                if (itemHouse == null || itemHouse != house) continue; // Ensure item belongs to the same house


                // Prevent coloring **non-movable house parts** (like walls, floors, doors)
                if (!item.Movable) continue; 

                // If the item is locked down or secure, skip it
                if (item.IsLockedDown || item.IsSecure) continue;

                int originalHue = item.Hue; // Store original color

                item.Hue = 0x22; // Temporarily mark unsecured items
                item.InvalidateProperties(); 
                item.PublicOverheadMessage(0, 0x35, false, "This item is not locked down or secure!");
                Effects.PlaySound(player.Location, player.Map, 0x249);

                unsecuredItems.Add(item);

                // Restore original hue after 10 seconds
                Timer.DelayCall(TimeSpan.FromSeconds(10), () =>
                {
                    item.Hue = originalHue;
                    item.InvalidateProperties(); // Ensure item returns to its normal color
                });
            }

            if (unsecuredItems.Count > 0)
            {
                player.SendMessage(string.Format("{0} unsecured items have been marked!", unsecuredItems.Count));
            }
            else
            {
                player.SendMessage("There are no unsecured items in your house.");
            }
        }
    }
}
