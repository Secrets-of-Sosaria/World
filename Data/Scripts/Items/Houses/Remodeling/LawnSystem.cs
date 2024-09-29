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
    public class LawnSystem
    {
        public static List<Item> OrphanedLawnItems = new List<Item>();

        public static void AddOrphanedItem(Item item)
        {
            if (OrphanedLawnItems == null)
            {
                OrphanedLawnItems = new List<Item>();
            }

            if (item == null)
            {
                return;
            }

            OrphanedLawnItems.Add(item);
        }

        public static void StartTimer(WorldSaveEventArgs args)
        {
            Timer.DelayCall(TimeSpan.FromSeconds(Remodeling.SecondsToCleanup), CleanLawns);
        }

        public static void CleanLawns()
        {
            if (OrphanedLawnItems == null || OrphanedLawnItems.Count <= 0)
            {
                return;
            }

            for (int i = 0; i < OrphanedLawnItems.Count; i++)
            {
                if (OrphanedLawnItems[i] is LawnItem)
                {
                    LawnItem item = (LawnItem)OrphanedLawnItems[i];
                    if (item == null)
                    {
                        continue;
                    }
                    item.FindHouseOfPlacer();
                    if ( item.House == null || !MySettings.S_LawnsAllowed )
                    {
                        item.Refund( item.Placer );
                    }
                }
                else if (OrphanedLawnItems[i] is LawnGate)
                {
                    LawnGate item = (LawnGate)OrphanedLawnItems[i];
                    if (item == null)
                    {
                        continue;
                    }
                    item.FindHouseOfPlacer();
                    if ( item.House == null || !MySettings.S_LawnsAllowed )
                    {
                        item.Refund( item.Placer );
                    }
                }
            }

            OrphanedLawnItems.Clear();
        }

		public static void RemoveVisitors( Item item )
		{
			if ( item != null && item is LawnItem && ( item.Name == "huge fire" || item.Name == "burning pit" || item.Name == "summoning pentagram" ) )
			{
				ArrayList mobiles = new ArrayList();
				foreach ( Mobile m in item.GetMobilesInRange( 2 ) )
				{
					if ( m != null && m.Karma != 1 && m is HouseVisitor && !(m.Region is HouseRegion) && m.Map == item.Map )
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

        public static void RemoveLawns( BaseHouse house, Mobile from )
        {
			int gold = 0;
			ArrayList items = new ArrayList();
			ArrayList gates = new ArrayList();
			foreach ( Item item in World.Items.Values )
			{
				if ( item is LawnItem && ((LawnItem)item).House == house )
				{
					items.Add( item );
				}
				else if ( item is LawnGate && ((LawnGate)item).House == house )
				{
					gates.Add( item );
				}
			}
			for ( int i = 0; i < items.Count; ++i )
			{
				Item item = ( Item )items[ i ];
				gold = gold + ((LawnItem)item).Price;
				RemoveVisitors( item );
				item.Delete();
			}
			for ( int i = 0; i < gates.Count; ++i )
			{
				Item gate = ( Item )gates[ i ];
				gold = gold + ((LawnGate)gate).Price;
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
