using System;
using Server.Commands;
using Server.Items;
using Server.Multis;
using Server.Regions;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Misc
{
    public class ShantySystem
    {
        public static List<Item> OrphanedShantyItems = new List<Item>();

        public static void AddOrphanedItem(Item item)
        {
            if (OrphanedShantyItems == null)
            {
                OrphanedShantyItems = new List<Item>();
            }

            if (item == null)
            {
                return;
            }

            OrphanedShantyItems.Add(item);
        }

        public static void StartTimer(WorldSaveEventArgs args)
        {
            Timer.DelayCall(TimeSpan.FromSeconds(Remodeling.SecondsToCleanup), CleanShantys);
        }

        public static void CleanShantys()
        {
            if (OrphanedShantyItems == null || OrphanedShantyItems.Count <= 0)
            {
                return;
            }

            for (int i = 0; i < OrphanedShantyItems.Count; i++)
            {
                if (OrphanedShantyItems[i] is ShantyItem)
                {
                    ShantyItem item = (ShantyItem)OrphanedShantyItems[i];
                    if (item == null)
                    {
                        continue;
                    }
                    item.FindHouseOfPlacer();
                    if ( item.House == null || !MySettings.S_ShantysAllowed )
                    {
                        item.Refund( item.Placer );
                    }
                }
                else if (OrphanedShantyItems[i] is ShantyDoor)
                {
                    ShantyDoor item = (ShantyDoor)OrphanedShantyItems[i];
                    if (item == null)
                    {
                        continue;
                    }
                    item.FindHouseOfPlacer();
                    if ( item.House == null || !MySettings.S_ShantysAllowed )
                    {
                        item.Refund( item.Placer );
                    }
                }
            }

            OrphanedShantyItems.Clear();
        }

		public static void RemoveVisitors( Item item )
		{
			if ( item != null && item is ShantyItem && ( item.Name == "huge fire" || item.Name == "burning pit" || item.Name == "summoning pentagram" ) )
			{
				ArrayList mobiles = new ArrayList();
				foreach ( Mobile m in item.GetMobilesInRange( 2 ) )
				{
					if ( m != null && m.Karma != 1 && m is HouseVisitor && m.Region is HouseRegion && m.Map == item.Map )
					{
						mobiles.Add( m );
					}
				}
				for ( int i = 0; i < mobiles.Count; ++i )
				{
					Mobile from = ( Mobile )mobiles[ i ];
					if ( from != null ){ from.Delete(); }
				}
			}
		}

        public static void RemoveShantys( BaseHouse house, Mobile from )
        {
			int gold = 0;
			ArrayList items = new ArrayList();
			ArrayList gates = new ArrayList();
			foreach ( Item item in World.Items.Values )
			{
				if ( item is ShantyItem && ((ShantyItem)item).House == house )
				{
					items.Add( item );
				}
				else if ( item is ShantyDoor && ((ShantyDoor)item).House == house )
				{
					gates.Add( item );
				}
			}
			for ( int i = 0; i < items.Count; ++i )
			{
				Item item = ( Item )items[ i ];
				gold = gold + ((ShantyItem)item).Price;
				RemoveVisitors( item );
				item.Delete();
			}
			for ( int i = 0; i < gates.Count; ++i )
			{
				Item gate = ( Item )gates[ i ];
				gold = gold + ((ShantyDoor)gate).Price;
				RemoveVisitors( gate );
				gate.Delete();
			}
			if ( gold > 0 )
			{
				Item toGive = new BankCheck( gold );

				BankBox box = from.BankBox;

				if ( box.TryDropItem( from, toGive, false ) )
				{
					from.SendLocalizedMessage( 1060397, ( (BankCheck)toGive ).Worth.ToString() ); // ~1_AMOUNT~ gold has been deposited into your bank box.
				}
				else
				{
					from.AddToBackpack( toGive );
					from.SendMessage( "A check for " + gold + " gold was place in your backpack." );
				}
			}
        }
    }
}
