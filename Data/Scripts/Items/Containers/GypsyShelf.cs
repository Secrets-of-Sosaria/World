using System;
using Server; 
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class GypsyShelf : Item
	{
        [Constructable]
        public GypsyShelf() : base(0x3D05)
		{
            Name = "book shelf";
        }

        public override void OnDoubleClick(Mobile from)
		{
			if ( from.Backpack.FindItemByType( typeof ( BookGuideToAdventure ) ) != null )
			{
				from.SendMessage( "The other books here seem uninteresting to you." );
			}
			else
			{
				GiveBook( from );
			}
        }

		public static void GetRidOf( Mobile from )
		{
			ArrayList targets = new ArrayList();
			foreach ( Item item in World.Items.Values )
			if ( item is BookGuideToAdventure )
			{
				if ( ((BookGuideToAdventure)item).owner == from )
					targets.Add( item );
			}
			for ( int i = 0; i < targets.Count; ++i )
			{
				Item item = ( Item )targets[ i ];
				item.Delete();
			}
		}

		public static void GiveBook( Mobile from )
		{
			GetRidOf( from );
			BookGuideToAdventure book = new BookGuideToAdventure();
			from.PlaySound( 0x02E );
			book.owner = from;
			from.AddToBackpack( book );
			from.SendMessage( "You take a book from the gypsy's shelf." );
		}

        public GypsyShelf( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
	    }
    }
}