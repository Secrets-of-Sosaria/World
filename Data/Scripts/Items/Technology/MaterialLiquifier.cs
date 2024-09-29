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
	public class MaterialLiquifier : Item
	{
		[Constructable]
		public MaterialLiquifier() : base( 0x4C13 )
		{
			Weight = 5.0;
			Name = "material liquifier";
			Technology = true;
			Light = LightType.Circle150;
			LimitsMax = Utility.RandomMinMax( 10, 20 );
			Limits = LimitsMax;
			LimitsName = "Uses";
			LimitsDelete = true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendSound( 0x54D );
				from.CloseGump( typeof( MaterialLiquifierGump ) );
				from.SendGump( new MaterialLiquifierGump( from ) );
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			from.PlaySound( 0x55B );
			from.RevealingAction();

			if ( from.Backpack.FindItemByType( typeof ( Bottle ) ) != null )
			{
				from.RevealingAction();
				from.PlaySound( 0x23E );

				if ( dropped.Hue < 1 )
				{
					from.SendMessage( "Something went wrong and the item was destroyed." );
				}
				else
				{
					from.SendMessage( "The item has been destroyed." );
					Item bottle = from.Backpack.FindItemByType( typeof ( Bottle ) );
					if ( bottle.Amount > 1 ){ bottle.Amount = bottle.Amount - 1; } else { bottle.Delete(); }
					from.SendMessage( "You place a colored vial of in your pack." );
					MagicalDyes vial = new MagicalDyes();
					vial.Name = "colored dye";
					vial.Hue = dropped.Hue;
					from.AddToBackpack( vial );
				}

				ConsumeLimits( 1 );
				dropped.Delete();
			}
			else
			{
				from.SendMessage( "You need an empty bottle!" );
			}

			return false;
		}

		public MaterialLiquifier( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)2 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 2 )
			{
				LimitsMax = reader.ReadInt();
				Limits = LimitsMax;
				LimitsName = "Uses";
				LimitsDelete = true;
			}
		}

		public class MaterialLiquifierGump : Gump
		{
			public MaterialLiquifierGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 1242);
				AddItem(328, 33, 19475);
				AddHtml( 44, 41, 200, 20, @"<BODY><BASEFONT Color=#00FF06>MATERIAL LIQUIFIER</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 48, 76, 305, 186, @"<BODY><BASEFONT Color=#00FF06>This device is not only strange from its eerie glow, but from what it does to items you put in it. If you place an item in it, it will be melted into a vial of liquid that matches the material's color. Make sure you have an empty bottle to put the liquid into, or the item you place in it will be wasted. This liquid can be used to coat an item of your choice, where it will become the color of the liquefied material. Any other item one puts in this device will simply be destroyed, so be careful what you do with this device.</BASEFONT></BODY>", (bool)false, (bool)true);
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x54D );
			}
		}
	}
}