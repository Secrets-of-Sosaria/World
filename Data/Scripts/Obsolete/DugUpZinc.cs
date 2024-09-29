using System;
using Server; 
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using System.Globalization;
using Server.Regions;

namespace Server.Items
{
	public class DugUpZinc : Item
	{
		public override string DefaultDescription{ get{ return "This rare material, along with copper ore, is used to create brass. If you have quantities of both, seek out a blacksmith on the Island of Umber Veil. Give them the zinc and they will make as many brass ingots as they can."; } }

		[Constructable]
		public DugUpZinc() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 2.0; }
		}

		[Constructable]
		public DugUpZinc( int amount ) : base( 0x19B9 )
		{
			Name = "zinc";
			Stackable = true;
			Hue = 0x9C4;
			Amount = amount;
		}

		public DugUpZinc( Serial serial ) : base( serial )
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
			this.Delete();
		}

		public static bool CheckForDugUpZinc( Mobile from, int qty, bool remove )
		{
			bool pass = false;
			int carry = 0;

			if ( qty > 0 )
			{
				List<Item> belongings = new List<Item>();
				foreach( Item i in from.Backpack.Items )
				{
					if ( i is CopperOre ){ carry = carry + i.Amount; }
				}

				if ( carry >= qty )
				{
					pass = true;
					Container pack = from.Backpack;
					if ( remove == true ){ pack.ConsumeTotal(typeof(CopperOre), qty) ; }
				}
			}

			return pass;
		}
	}
}