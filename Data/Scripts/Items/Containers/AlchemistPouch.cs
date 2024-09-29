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

namespace Server.Items
{
    public class AlchemistPouch : Bag
    {
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public AlchemistPouch() : base()
		{
			Weight = 2.0;
			MaxItems = 50;
			ItemID = 0x5776;
			Name = "alchemist's belt pouch";
			Hue = 0xAFE;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			if ( this.Weight > 1.0 ){ list.Add( 1070722, "Single Click to Organize" ); }
		}

		public override bool OnDragDropInto( Mobile from, Item dropped, Point3D p )
        {
			if ( isAlchemy( dropped ) )
				return base.OnDragDropInto(from, dropped, p);
			else if ( dropped.Catalog == Catalogs.Potion )
				from.SendMessage("That particular item cannot be used in this pouch.");
			else
				from.SendMessage("This belt pouch is for alchemy potions.");

			return false;
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
        {
			if ( isAlchemy( dropped ) )
				return base.OnDragDrop(from, dropped);
			else if ( dropped.Catalog == Catalogs.Potion )
				from.SendMessage("That particular item cannot be used in this pouch.");
			else
				from.SendMessage("This belt pouch is for alchemy potions.");

			return false;
        }

		public class AlchemistBag : Gump
		{
			private AlchemistPouch m_Pouch;

			public AlchemistBag( Mobile from, AlchemistPouch bag ) : base( 50, 50 )
			{
				string color = "#AA7BAA";
				m_Pouch = bag;
				m_Pouch.Weight = 1.0;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7027, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 13, 13, 300, 20, @"<BODY><BASEFONT Color=" + color + ">ALCHEMY BELT POUCH</BASEFONT></BODY>", (bool)false, (bool)false);
				AddImage(531, 51, 10900);
				AddButton(863, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);


				AddHtml( 15, 57, 497, 176, @"<BODY><BASEFONT Color=" + color + ">This bag is only for potions created by alchemists, which will have their weight greatly reduced while in this bag. Here you can configure a quick belt pouch for these potions. This is also the only place where you can open and close the quick belt pouch, which is a bar that will open with icons for easy potion access. You can configure the bar to be either horizontal or vertical. You can choose to display abbreviated names next to the icons. You have to select which potions will appear in the bar and you can only effectively use one alchemy belt pouch at a time.</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int bDisplay = 3609; if ( bag.Titles > 0 ){ bDisplay = 4017; }
					AddButton(15, 231, bDisplay, bDisplay, 52, GumpButtonType.Reply, 0);
						AddHtml( 55, 231, 229, 20, @"<BODY><BASEFONT Color=" + color + ">Display Abbreviations</BASEFONT></BODY>", (bool)false, (bool)false);
				int bVertical = 3609; if ( bag.Bar > 0 ){ bVertical = 4017; }
					AddButton(15, 265, bVertical, bVertical, 53, GumpButtonType.Reply, 0);
						AddHtml( 55, 265, 225, 20, @"<BODY><BASEFONT Color=" + color + ">Vertical Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(353, 231, 4029, 4029, 50, GumpButtonType.Reply, 0);
					AddHtml( 393, 231, 150, 20, @"<BODY><BASEFONT Color=" + color + ">Open Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(353, 265, 4020, 4020, 51, GumpButtonType.Reply, 0);
					AddHtml( 393, 265, 150, 20, @"<BODY><BASEFONT Color=" + color + ">Close Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int val = 1;

				AddButton(15, 330, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 325, 9509);
						AddHtml( 95, 330, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Agility</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 372, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 367, 9510);
						AddHtml( 95, 372, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Agility (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 414, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 409, 9511);
						AddHtml( 95, 414, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Conflagration</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 456, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 451, 9512);
						AddHtml( 95, 456, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Conflagration (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 498, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 493, 9513);
						AddHtml( 95, 498, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Confusion Blast</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 540, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 535, 9514);
						AddHtml( 95, 540, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Confusion Blast (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 582, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 577, 9515);
						AddHtml( 95, 582, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Cure (L)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 624, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 619, 9516);
						AddHtml( 95, 624, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Cure</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 666, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 661, 9517);
						AddHtml( 95, 666, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Cure (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 708, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 703, 9518);
						AddHtml( 95, 708, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Explosion (L)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(15, 750, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(55, 745, 9519);
						AddHtml( 95, 750, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Explosion</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(330, 330, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 325, 9520);
						AddHtml( 410, 330, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Explosion (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 372, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 367, 9521);
						AddHtml( 410, 372, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Frostbite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 414, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 409, 9522);
						AddHtml( 410, 414, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Frostbite (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 456, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 451, 9523);
						AddHtml( 410, 456, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Heal (L)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 498, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 493, 9524);
						AddHtml( 410, 498, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Heal</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 540, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 535, 9525);
						AddHtml( 410, 540, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Heal (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 582, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 577, 9526);
						AddHtml( 410, 582, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Invisibility (L)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 624, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 619, 9527);
						AddHtml( 410, 624, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Invisibility</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 666, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 661, 9528);
						AddHtml( 410, 666, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Invisibility (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 708, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 703, 9529);
						AddHtml( 410, 708, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Invulnerability</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(330, 750, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(370, 745, 9530);
						AddHtml( 410, 750, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Mana (L)</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(645, 372, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 367, 9531);
						AddHtml( 725, 372, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Mana</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 414, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 409, 9532);
						AddHtml( 725, 414, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Mana (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 456, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 451, 9533);
						AddHtml( 725, 456, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Night Sight</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 498, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 493, 9534);
						AddHtml( 725, 498, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Refresh</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 540, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 535, 9535);
						AddHtml( 725, 540, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Refresh, Total</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 582, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 577, 9536);
						AddHtml( 725, 582, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Rejuvenate (L)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 624, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 619, 9537);
						AddHtml( 725, 624, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Rejuvenate</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 666, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 661, 9538);
						AddHtml( 725, 666, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Rejuvenate (G)</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 708, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 703, 9539);
						AddHtml( 725, 708, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Strength</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(645, 750, buttonVal(val, bag), buttonVal(val, bag), val, GumpButtonType.Reply, 0); val++;
					AddImage(685, 745, 9540);
						AddHtml( 725, 750, 153, 20, @"<BODY><BASEFONT Color=" + color + ">Strength (G)</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public int buttonVal( int val, AlchemistPouch bag )
			{
				int button = 3609;

				if ( val == 1 && bag.v_01_Agility > 0 ){ button = 4017; }
				else if ( val == 2 && bag.v_02_GreaterAgility > 0 ){ button = 4017; }
				else if ( val == 3 && bag.v_03_Conflagration > 0 ){ button = 4017; }
				else if ( val == 4 && bag.v_04_GreaterConflagration > 0 ){ button = 4017; }
				else if ( val == 5 && bag.v_05_ConfusionBlast > 0 ){ button = 4017; }
				else if ( val == 6 && bag.v_06_GreaterConfusionBlast > 0 ){ button = 4017; }
				else if ( val == 7 && bag.v_07_LesserCure > 0 ){ button = 4017; }
				else if ( val == 8 && bag.v_08_Cure > 0 ){ button = 4017; }
				else if ( val == 9 && bag.v_09_GreaterCure > 0 ){ button = 4017; }
				else if ( val == 10 && bag.v_10_LesserExplosion > 0 ){ button = 4017; }
				else if ( val == 11 && bag.v_11_Explosion > 0 ){ button = 4017; }
				else if ( val == 12 && bag.v_12_GreaterExplosion > 0 ){ button = 4017; }
				else if ( val == 13 && bag.v_13_Frostbite > 0 ){ button = 4017; }
				else if ( val == 14 && bag.v_14_GreaterFrostbite > 0 ){ button = 4017; }
				else if ( val == 15 && bag.v_15_LesserHeal > 0 ){ button = 4017; }
				else if ( val == 16 && bag.v_16_Heal > 0 ){ button = 4017; }
				else if ( val == 17 && bag.v_17_GreaterHeal > 0 ){ button = 4017; }
				else if ( val == 18 && bag.v_18_LesserInvisibility > 0 ){ button = 4017; }
				else if ( val == 19 && bag.v_19_Invisibility > 0 ){ button = 4017; }
				else if ( val == 20 && bag.v_20_GreaterInvisibility > 0 ){ button = 4017; }
				else if ( val == 21 && bag.v_21_Invulnerability > 0 ){ button = 4017; }
				else if ( val == 22 && bag.v_22_LesserMana > 0 ){ button = 4017; }
				else if ( val == 23 && bag.v_23_Mana > 0 ){ button = 4017; }
				else if ( val == 24 && bag.v_24_GreaterMana > 0 ){ button = 4017; }
				else if ( val == 25 && bag.v_25_NightSight > 0 ){ button = 4017; }
				else if ( val == 26 && bag.v_26_Refresh > 0 ){ button = 4017; }
				else if ( val == 27 && bag.v_27_TotalRefresh > 0 ){ button = 4017; }
				else if ( val == 28 && bag.v_28_LesserRejuvenate > 0 ){ button = 4017; }
				else if ( val == 29 && bag.v_29_Rejuvenate > 0 ){ button = 4017; }
				else if ( val == 30 && bag.v_30_GreaterRejuvenate > 0 ){ button = 4017; }
				else if ( val == 31 && bag.v_31_Strength > 0 ){ button = 4017; }
				else if ( val == 32 && bag.v_32_GreaterStrength > 0 ){ button = 4017; }

				return button;
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 

				if ( m_Pouch.IsChildOf( from.Backpack ) )
				{
					if ( info.ButtonID == 50 )
					{
						from.SendSound( 0x4A );
						from.CloseGump( typeof( ChemistBar ) );
						from.SendGump( new AlchemistBag( from, m_Pouch ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new ChemistBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new ChemistBar( from, m_Pouch, false ) ); }
					}
					else if ( info.ButtonID == 51 )
					{
						from.SendSound( 0x4A );
						from.CloseGump( typeof( ChemistBar ) );
						from.SendGump( new AlchemistBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 52 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Titles == 1 ){ m_Pouch.Titles = 0; } else { m_Pouch.Titles = 1; }
						from.CloseGump( typeof( AlchemistBag ) );
						from.SendGump( new AlchemistBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 53 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Bar == 1 ){ m_Pouch.Bar = 0; } else { m_Pouch.Bar = 1; }
						from.CloseGump( typeof( AlchemistBag ) );
						from.SendGump( new AlchemistBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID > 0 && info.ButtonID < 40 )
					{
						from.SendSound( 0x4A );
						if ( info.ButtonID == 1 ){ if ( m_Pouch.v_01_Agility == 1 ){ m_Pouch.v_01_Agility = 0; } else { m_Pouch.v_01_Agility = 1; } }
						else if ( info.ButtonID == 2 ){ if ( m_Pouch.v_02_GreaterAgility == 1 ){ m_Pouch.v_02_GreaterAgility = 0; } else { m_Pouch.v_02_GreaterAgility = 1; } }
						else if ( info.ButtonID == 3 ){ if ( m_Pouch.v_03_Conflagration == 1 ){ m_Pouch.v_03_Conflagration = 0; } else { m_Pouch.v_03_Conflagration = 1; } }
						else if ( info.ButtonID == 4 ){ if ( m_Pouch.v_04_GreaterConflagration == 1 ){ m_Pouch.v_04_GreaterConflagration = 0; } else { m_Pouch.v_04_GreaterConflagration = 1; } }
						else if ( info.ButtonID == 5 ){ if ( m_Pouch.v_05_ConfusionBlast == 1 ){ m_Pouch.v_05_ConfusionBlast = 0; } else { m_Pouch.v_05_ConfusionBlast = 1; } }
						else if ( info.ButtonID == 6 ){ if ( m_Pouch.v_06_GreaterConfusionBlast == 1 ){ m_Pouch.v_06_GreaterConfusionBlast = 0; } else { m_Pouch.v_06_GreaterConfusionBlast = 1; } }
						else if ( info.ButtonID == 7 ){ if ( m_Pouch.v_07_LesserCure == 1 ){ m_Pouch.v_07_LesserCure = 0; } else { m_Pouch.v_07_LesserCure = 1; } }
						else if ( info.ButtonID == 8 ){ if ( m_Pouch.v_08_Cure == 1 ){ m_Pouch.v_08_Cure = 0; } else { m_Pouch.v_08_Cure = 1; } }
						else if ( info.ButtonID == 9 ){ if ( m_Pouch.v_09_GreaterCure == 1 ){ m_Pouch.v_09_GreaterCure = 0; } else { m_Pouch.v_09_GreaterCure = 1; } }
						else if ( info.ButtonID == 10 ){ if ( m_Pouch.v_10_LesserExplosion == 1 ){ m_Pouch.v_10_LesserExplosion = 0; } else { m_Pouch.v_10_LesserExplosion = 1; } }
						else if ( info.ButtonID == 11 ){ if ( m_Pouch.v_11_Explosion == 1 ){ m_Pouch.v_11_Explosion = 0; } else { m_Pouch.v_11_Explosion = 1; } }
						else if ( info.ButtonID == 12 ){ if ( m_Pouch.v_12_GreaterExplosion == 1 ){ m_Pouch.v_12_GreaterExplosion = 0; } else { m_Pouch.v_12_GreaterExplosion = 1; } }
						else if ( info.ButtonID == 13 ){ if ( m_Pouch.v_13_Frostbite == 1 ){ m_Pouch.v_13_Frostbite = 0; } else { m_Pouch.v_13_Frostbite = 1; } }
						else if ( info.ButtonID == 14 ){ if ( m_Pouch.v_14_GreaterFrostbite == 1 ){ m_Pouch.v_14_GreaterFrostbite = 0; } else { m_Pouch.v_14_GreaterFrostbite = 1; } }
						else if ( info.ButtonID == 15 ){ if ( m_Pouch.v_15_LesserHeal == 1 ){ m_Pouch.v_15_LesserHeal = 0; } else { m_Pouch.v_15_LesserHeal = 1; } }
						else if ( info.ButtonID == 16 ){ if ( m_Pouch.v_16_Heal == 1 ){ m_Pouch.v_16_Heal = 0; } else { m_Pouch.v_16_Heal = 1; } }
						else if ( info.ButtonID == 17 ){ if ( m_Pouch.v_17_GreaterHeal == 1 ){ m_Pouch.v_17_GreaterHeal = 0; } else { m_Pouch.v_17_GreaterHeal = 1; } }
						else if ( info.ButtonID == 18 ){ if ( m_Pouch.v_18_LesserInvisibility == 1 ){ m_Pouch.v_18_LesserInvisibility = 0; } else { m_Pouch.v_18_LesserInvisibility = 1; } }
						else if ( info.ButtonID == 19 ){ if ( m_Pouch.v_19_Invisibility == 1 ){ m_Pouch.v_19_Invisibility = 0; } else { m_Pouch.v_19_Invisibility = 1; } }
						else if ( info.ButtonID == 20 ){ if ( m_Pouch.v_20_GreaterInvisibility == 1 ){ m_Pouch.v_20_GreaterInvisibility = 0; } else { m_Pouch.v_20_GreaterInvisibility = 1; } }
						else if ( info.ButtonID == 21 ){ if ( m_Pouch.v_21_Invulnerability == 1 ){ m_Pouch.v_21_Invulnerability = 0; } else { m_Pouch.v_21_Invulnerability = 1; } }
						else if ( info.ButtonID == 22 ){ if ( m_Pouch.v_22_LesserMana == 1 ){ m_Pouch.v_22_LesserMana = 0; } else { m_Pouch.v_22_LesserMana = 1; } }
						else if ( info.ButtonID == 23 ){ if ( m_Pouch.v_23_Mana == 1 ){ m_Pouch.v_23_Mana = 0; } else { m_Pouch.v_23_Mana = 1; } }
						else if ( info.ButtonID == 24 ){ if ( m_Pouch.v_24_GreaterMana == 1 ){ m_Pouch.v_24_GreaterMana = 0; } else { m_Pouch.v_24_GreaterMana = 1; } }
						else if ( info.ButtonID == 25 ){ if ( m_Pouch.v_25_NightSight == 1 ){ m_Pouch.v_25_NightSight = 0; } else { m_Pouch.v_25_NightSight = 1; } }
						else if ( info.ButtonID == 26 ){ if ( m_Pouch.v_26_Refresh == 1 ){ m_Pouch.v_26_Refresh = 0; } else { m_Pouch.v_26_Refresh = 1; } }
						else if ( info.ButtonID == 27 ){ if ( m_Pouch.v_27_TotalRefresh == 1 ){ m_Pouch.v_27_TotalRefresh = 0; } else { m_Pouch.v_27_TotalRefresh = 1; } }
						else if ( info.ButtonID == 28 ){ if ( m_Pouch.v_28_LesserRejuvenate == 1 ){ m_Pouch.v_28_LesserRejuvenate = 0; } else { m_Pouch.v_28_LesserRejuvenate = 1; } }
						else if ( info.ButtonID == 29 ){ if ( m_Pouch.v_29_Rejuvenate == 1 ){ m_Pouch.v_29_Rejuvenate = 0; } else { m_Pouch.v_29_Rejuvenate = 1; } }
						else if ( info.ButtonID == 30 ){ if ( m_Pouch.v_30_GreaterRejuvenate == 1 ){ m_Pouch.v_30_GreaterRejuvenate = 0; } else { m_Pouch.v_30_GreaterRejuvenate = 1; } }
						else if ( info.ButtonID == 31 ){ if ( m_Pouch.v_31_Strength == 1 ){ m_Pouch.v_31_Strength = 0; } else { m_Pouch.v_31_Strength = 1; } }
						else if ( info.ButtonID == 32 ){ if ( m_Pouch.v_32_GreaterStrength == 1 ){ m_Pouch.v_32_GreaterStrength = 0; } else { m_Pouch.v_32_GreaterStrength = 1; } }

						from.CloseGump( typeof( AlchemistBag ) );
						from.SendGump( new AlchemistBag( from, m_Pouch ) );
					}
					else
					{
						from.PlaySound( 0x48 );
					}

					if ( from.HasGump( typeof( ChemistBar ) ) )
					{
						from.CloseGump( typeof( ChemistBar ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new ChemistBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new ChemistBar( from, m_Pouch, false ) ); }
					}
				}
			}
		}

		public class ChemistBar : Gump
		{
			private AlchemistPouch m_Pouch;
			public ChemistBar( Mobile from, AlchemistPouch bag, bool vertical ): base( 50, 50 )
			{
				this.Closable=false;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;
				AddPage(0);
				m_Pouch = bag;
				int btn = 0;
				int img = 9508;
				int val = 0;
				int cyc = 0;
				int abs = 0;
				bool overHalf = OverHalf( bag );

				if ( vertical )
				{
					if ( overHalf ){ AddImage(10, -18, 10903); } else { AddImage(0, 0, 10902); }

					int mod = 34;

					btn++; img++; if ( bag.v_01_Agility > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_02_GreaterAgility > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_03_Conflagration > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_04_GreaterConflagration > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_05_ConfusionBlast > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_06_GreaterConfusionBlast > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_07_LesserCure > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_08_Cure > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_09_GreaterCure > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_10_LesserExplosion > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_11_Explosion > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_12_GreaterExplosion > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_13_Frostbite > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_14_GreaterFrostbite > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_15_LesserHeal > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_16_Heal > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_17_GreaterHeal > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_18_LesserInvisibility > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_19_Invisibility > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_20_GreaterInvisibility > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_21_Invulnerability > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_22_LesserMana > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_23_Mana > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_24_GreaterMana > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_25_NightSight > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_26_Refresh > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_27_TotalRefresh > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_28_LesserRejuvenate > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_29_Rejuvenate > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_30_GreaterRejuvenate > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_31_Strength > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
					btn++; img++; if ( bag.v_32_GreaterStrength > 0 ){ cyc++; val=val+mod; AddButton(abs, val, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 33; val = 0; }
				}
				else
				{
					if ( overHalf ){ AddImage(-18, 10, 10903); } else { AddImage(0, 0, 10902); }

					int mod = 33;

					btn++; img++; if ( bag.v_01_Agility > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_02_GreaterAgility > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_03_Conflagration > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_04_GreaterConflagration > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_05_ConfusionBlast > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_06_GreaterConfusionBlast > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_07_LesserCure > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_08_Cure > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_09_GreaterCure > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_10_LesserExplosion > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_11_Explosion > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_12_GreaterExplosion > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_13_Frostbite > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_14_GreaterFrostbite > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_15_LesserHeal > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_16_Heal > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_17_GreaterHeal > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_18_LesserInvisibility > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_19_Invisibility > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_20_GreaterInvisibility > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_21_Invulnerability > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_22_LesserMana > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_23_Mana > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_24_GreaterMana > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_25_NightSight > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_26_Refresh > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_27_TotalRefresh > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_28_LesserRejuvenate > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_29_Rejuvenate > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_30_GreaterRejuvenate > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_31_Strength > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
					btn++; img++; if ( bag.v_32_GreaterStrength > 0 ){ cyc++; val=val+mod; AddButton(val, abs, img, img, btn, GumpButtonType.Reply, 0); } if ( cyc > 15 && abs == 0 ){ abs = 34; val = 0; }
				}

				if ( bag.Titles > 0 )
				{
					cyc = 0;
					int hue = nameColor(0);

					if ( bag.v_01_Agility > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Ag"); cyc++; hue = nameColor(hue); }
					if ( bag.v_02_GreaterAgility > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"AgG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_03_Conflagration > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Cf"); cyc++; hue = nameColor(hue); }
					if ( bag.v_04_GreaterConflagration > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"CfG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_05_ConfusionBlast > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Cb"); cyc++; hue = nameColor(hue); }
					if ( bag.v_06_GreaterConfusionBlast > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"CbG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_07_LesserCure > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"CuL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_08_Cure > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Cu"); cyc++; hue = nameColor(hue); }
					if ( bag.v_09_GreaterCure > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"CuG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_10_LesserExplosion > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"ExL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_11_Explosion > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Ex"); cyc++; hue = nameColor(hue); }
					if ( bag.v_12_GreaterExplosion > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"ExG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_13_Frostbite > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Fb"); cyc++; hue = nameColor(hue); }
					if ( bag.v_14_GreaterFrostbite > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"FbG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_15_LesserHeal > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"HeL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_16_Heal > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"He"); cyc++; hue = nameColor(hue); }
					if ( bag.v_17_GreaterHeal > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"HeG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_18_LesserInvisibility > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"InL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_19_Invisibility > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"InG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_20_GreaterInvisibility > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"In"); cyc++; hue = nameColor(hue); }
					if ( bag.v_21_Invulnerability > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"<->"); cyc++; hue = nameColor(hue); }
					if ( bag.v_22_LesserMana > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"MnL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_23_Mana > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Mn"); cyc++; hue = nameColor(hue); }
					if ( bag.v_24_GreaterMana > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"MnG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_25_NightSight > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"NiS"); cyc++; hue = nameColor(hue); }
					if ( bag.v_26_Refresh > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Rf"); cyc++; hue = nameColor(hue); }
					if ( bag.v_27_TotalRefresh > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"RfT"); cyc++; hue = nameColor(hue); }
					if ( bag.v_28_LesserRejuvenate > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"RjL"); cyc++; hue = nameColor(hue); }
					if ( bag.v_29_Rejuvenate > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"Rj"); cyc++; hue = nameColor(hue); }
					if ( bag.v_30_GreaterRejuvenate > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"RjG"); cyc++; hue = nameColor(hue); }
					if ( bag.v_31_Strength > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"St"); cyc++; hue = nameColor(hue); }
					if ( bag.v_32_GreaterStrength > 0 ){ AddLabel(cordVal(cyc,overHalf,vertical,0), cordVal(cyc,overHalf,vertical,1), hue, @"StG"); cyc++; hue = nameColor(hue); }
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile;
				if ( m_Pouch.IsChildOf( from.Backpack ) )
				{
					usePotion( info.ButtonID, from );
					from.CloseGump( typeof( ChemistBar ) );
					bool vertical = false; if ( m_Pouch.Bar == 1 ){ vertical = true; }
					from.SendGump( new ChemistBar( from, m_Pouch, vertical ) );
				}
			}

			public static int nameColor( int hue )
			{
				if ( hue == 2929 )
					return 2770;

				return 2929;
			}

			public static int cordVal( int cyc, bool overHalf, bool vertical, int prt )
			{
				int x = 0;
				int y = 0;
				cyc++;
				int num = cyc;
				if ( num > 16 ){ num = num-16; }

				if ( vertical && overHalf )
				{
					x = -28;
					y = 8;
					if ( cyc < 17 ){ x = -28; y = y + (num*34); }
					else if ( cyc == 17 ){ x = 36+33; y = 8+34; }
					else { x = 36+33; y = y + (num*34); }
				}
				else if ( vertical )
				{
					x = 36;
					y = 8 + (num*34);
				}
				else if ( !vertical && overHalf )
				{
					x = 5;
					y = -21;
					if ( cyc < 17 ){ x = x + (num*33); y = -21; }
					else if ( cyc == 17 ){ x = x + (num*33); y = 35+34; }
					else { x = x + (num*33); y = 35+34; }
				}
				else
				{
					x = 5 + (num*33);
					y = 35;
				}

				if ( prt == 1 )
					return y;

				return x;
			}

			public static bool OverHalf( AlchemistPouch bag )
			{
				int val = 0;

				if ( bag.v_01_Agility > 0 ){ val++; }
				if ( bag.v_02_GreaterAgility > 0 ){ val++; }
				if ( bag.v_03_Conflagration > 0 ){ val++; }
				if ( bag.v_04_GreaterConflagration > 0 ){ val++; }
				if ( bag.v_05_ConfusionBlast > 0 ){ val++; }
				if ( bag.v_06_GreaterConfusionBlast > 0 ){ val++; }
				if ( bag.v_07_LesserCure > 0 ){ val++; }
				if ( bag.v_08_Cure > 0 ){ val++; }
				if ( bag.v_09_GreaterCure > 0 ){ val++; }
				if ( bag.v_10_LesserExplosion > 0 ){ val++; }
				if ( bag.v_11_Explosion > 0 ){ val++; }
				if ( bag.v_12_GreaterExplosion > 0 ){ val++; }
				if ( bag.v_13_Frostbite > 0 ){ val++; }
				if ( bag.v_14_GreaterFrostbite > 0 ){ val++; }
				if ( bag.v_15_LesserHeal > 0 ){ val++; }
				if ( bag.v_16_Heal > 0 ){ val++; }
				if ( bag.v_17_GreaterHeal > 0 ){ val++; }
				if ( bag.v_18_LesserInvisibility > 0 ){ val++; }
				if ( bag.v_19_Invisibility > 0 ){ val++; }
				if ( bag.v_20_GreaterInvisibility > 0 ){ val++; }
				if ( bag.v_21_Invulnerability > 0 ){ val++; }
				if ( bag.v_22_LesserMana > 0 ){ val++; }
				if ( bag.v_23_Mana > 0 ){ val++; }
				if ( bag.v_24_GreaterMana > 0 ){ val++; }
				if ( bag.v_25_NightSight > 0 ){ val++; }
				if ( bag.v_26_Refresh > 0 ){ val++; }
				if ( bag.v_27_TotalRefresh > 0 ){ val++; }
				if ( bag.v_28_LesserRejuvenate > 0 ){ val++; }
				if ( bag.v_29_Rejuvenate > 0 ){ val++; }
				if ( bag.v_30_GreaterRejuvenate > 0 ){ val++; }
				if ( bag.v_31_Strength > 0 ){ val++; }
				if ( bag.v_32_GreaterStrength > 0 ){ val++; }

				if ( val > 16 )
					return true;

				return false;
			}
		}

		public static void usePotion( int potion, Mobile from )
		{
			bool warn = true;

			if ( potion == 1 && from.Backpack.FindItemByType( typeof ( AgilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( AgilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 2 && from.Backpack.FindItemByType( typeof ( GreaterAgilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterAgilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 3 && from.Backpack.FindItemByType( typeof ( ConflagrationPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ConflagrationPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 4 && from.Backpack.FindItemByType( typeof ( GreaterConflagrationPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterConflagrationPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 5 && from.Backpack.FindItemByType( typeof ( ConfusionBlastPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ConfusionBlastPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 6 && from.Backpack.FindItemByType( typeof ( GreaterConfusionBlastPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterConfusionBlastPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 7 && from.Backpack.FindItemByType( typeof ( LesserCurePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserCurePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 8 && from.Backpack.FindItemByType( typeof ( CurePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( CurePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 9 && from.Backpack.FindItemByType( typeof ( GreaterCurePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterCurePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 10 && from.Backpack.FindItemByType( typeof ( LesserExplosionPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserExplosionPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 11 && from.Backpack.FindItemByType( typeof ( ExplosionPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ExplosionPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 12 && from.Backpack.FindItemByType( typeof ( GreaterExplosionPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterExplosionPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 13 && from.Backpack.FindItemByType( typeof ( FrostbitePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( FrostbitePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 14 && from.Backpack.FindItemByType( typeof ( GreaterFrostbitePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterFrostbitePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 15 && from.Backpack.FindItemByType( typeof ( LesserHealPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserHealPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 16 && from.Backpack.FindItemByType( typeof ( HealPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( HealPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 17 && from.Backpack.FindItemByType( typeof ( GreaterHealPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterHealPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 18 && from.Backpack.FindItemByType( typeof ( LesserInvisibilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserInvisibilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 19 && from.Backpack.FindItemByType( typeof ( InvisibilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( InvisibilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 20 && from.Backpack.FindItemByType( typeof ( GreaterInvisibilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterInvisibilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 21 && from.Backpack.FindItemByType( typeof ( InvulnerabilityPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( InvulnerabilityPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 22 && from.Backpack.FindItemByType( typeof ( LesserManaPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserManaPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 23 && from.Backpack.FindItemByType( typeof ( ManaPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ManaPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 24 && from.Backpack.FindItemByType( typeof ( GreaterManaPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterManaPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 25 && from.Backpack.FindItemByType( typeof ( NightSightPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( NightSightPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 26 && from.Backpack.FindItemByType( typeof ( RefreshPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( RefreshPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 27 && from.Backpack.FindItemByType( typeof ( TotalRefreshPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( TotalRefreshPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 28 && from.Backpack.FindItemByType( typeof ( LesserRejuvenatePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LesserRejuvenatePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 29 && from.Backpack.FindItemByType( typeof ( RejuvenatePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( RejuvenatePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 30 && from.Backpack.FindItemByType( typeof ( GreaterRejuvenatePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterRejuvenatePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 31 && from.Backpack.FindItemByType( typeof ( StrengthPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( StrengthPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 32 && from.Backpack.FindItemByType( typeof ( GreaterStrengthPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GreaterStrengthPotion ) ) ).OnDoubleClick(from); warn = false; }

			if ( warn ){ warnMe( from ); }
		}

		public static void warnMe( Mobile from )
		{
			string text = "You don't have that potion!";

			from.SendMessage( text );
			from.LocalOverheadMessage(MessageType.Emote, 1150, true, text);
		}

		public override bool OnDragLift( Mobile from )
		{
			from.SendMessage( "Single click this bag to organize it." );
			return base.OnDragLift( from );
		}

		public AlchemistPouch( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( Bar );
			writer.Write( Titles );
			writer.Write( v_01_Agility );
			writer.Write( v_02_GreaterAgility );
			writer.Write( v_03_Conflagration );
			writer.Write( v_04_GreaterConflagration );
			writer.Write( v_05_ConfusionBlast );
			writer.Write( v_06_GreaterConfusionBlast );
			writer.Write( v_07_LesserCure );
			writer.Write( v_08_Cure );
			writer.Write( v_09_GreaterCure );
			writer.Write( v_10_LesserExplosion );
			writer.Write( v_11_Explosion );
			writer.Write( v_12_GreaterExplosion );
			writer.Write( v_13_Frostbite );
			writer.Write( v_14_GreaterFrostbite );
			writer.Write( v_15_LesserHeal );
			writer.Write( v_16_Heal );
			writer.Write( v_17_GreaterHeal );
			writer.Write( v_18_LesserInvisibility );
			writer.Write( v_19_Invisibility );
			writer.Write( v_20_GreaterInvisibility );
			writer.Write( v_21_Invulnerability );
			writer.Write( v_22_LesserMana );
			writer.Write( v_23_Mana );
			writer.Write( v_24_GreaterMana );
			writer.Write( v_25_NightSight );
			writer.Write( v_26_Refresh );
			writer.Write( v_27_TotalRefresh );
			writer.Write( v_28_LesserRejuvenate );
			writer.Write( v_29_Rejuvenate );
			writer.Write( v_30_GreaterRejuvenate );
			writer.Write( v_31_Strength );
			writer.Write( v_32_GreaterStrength );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Bar = reader.ReadInt();
			Titles = reader.ReadInt();
			v_01_Agility = reader.ReadInt();
			v_02_GreaterAgility = reader.ReadInt();
			v_03_Conflagration = reader.ReadInt();
			v_04_GreaterConflagration = reader.ReadInt();
			v_05_ConfusionBlast = reader.ReadInt();
			v_06_GreaterConfusionBlast = reader.ReadInt();
			v_07_LesserCure = reader.ReadInt();
			v_08_Cure = reader.ReadInt();
			v_09_GreaterCure = reader.ReadInt();
			v_10_LesserExplosion = reader.ReadInt();
			v_11_Explosion = reader.ReadInt();
			v_12_GreaterExplosion = reader.ReadInt();
			v_13_Frostbite = reader.ReadInt();
			v_14_GreaterFrostbite = reader.ReadInt();
			v_15_LesserHeal = reader.ReadInt();
			v_16_Heal = reader.ReadInt();
			v_17_GreaterHeal = reader.ReadInt();
			v_18_LesserInvisibility = reader.ReadInt();
			v_19_Invisibility = reader.ReadInt();
			v_20_GreaterInvisibility = reader.ReadInt();
			v_21_Invulnerability = reader.ReadInt();
			v_22_LesserMana = reader.ReadInt();
			v_23_Mana = reader.ReadInt();
			v_24_GreaterMana = reader.ReadInt();
			v_25_NightSight = reader.ReadInt();
			v_26_Refresh = reader.ReadInt();
			v_27_TotalRefresh = reader.ReadInt();
			v_28_LesserRejuvenate = reader.ReadInt();
			v_29_Rejuvenate = reader.ReadInt();
			v_30_GreaterRejuvenate = reader.ReadInt();
			v_31_Strength = reader.ReadInt();
			v_32_GreaterStrength = reader.ReadInt();
			Weight = 1.0;
			MaxItems = 50;
		}

		public bool isAlchemy( Item item )
		{
			if (
				item is AgilityPotion || 
				item is GreaterAgilityPotion || 
				item is ConflagrationPotion || 
				item is GreaterConflagrationPotion || 
				item is ConfusionBlastPotion || 
				item is GreaterConfusionBlastPotion || 
				item is LesserCurePotion || 
				item is CurePotion || 
				item is GreaterCurePotion || 
				item is LesserExplosionPotion || 
				item is ExplosionPotion || 
				item is GreaterExplosionPotion || 
				item is FrostbitePotion || 
				item is GreaterFrostbitePotion || 
				item is LesserHealPotion || 
				item is HealPotion || 
				item is GreaterHealPotion || 
				item is LesserInvisibilityPotion || 
				item is InvisibilityPotion || 
				item is GreaterInvisibilityPotion || 
				item is InvulnerabilityPotion || 
				item is LesserManaPotion || 
				item is ManaPotion || 
				item is GreaterManaPotion || 
				item is NightSightPotion || 
				item is RefreshPotion || 
				item is TotalRefreshPotion || 
				item is LesserRejuvenatePotion || 
				item is RejuvenatePotion || 
				item is GreaterRejuvenatePotion || 
				item is StrengthPotion || 
				item is GreaterStrengthPotion 
			){ return true; }
			return false;
		}

		public override int GetTotal(TotalType type)
        {
			if (type != TotalType.Weight)
				return base.GetTotal(type);
			else
			{
				return (int)(TotalItemWeights() * (0.05));
			}
        }

		public override void UpdateTotal(Item sender, TotalType type, int delta)
        {
            if (type != TotalType.Weight)
                base.UpdateTotal(sender, type, delta);
            else
                base.UpdateTotal(sender, type, (int)(delta * (0.05)));
        }

		private double TotalItemWeights()
        {
			double weight = 0.0;

			foreach (Item item in Items)
				weight += (item.Weight * (double)(item.Amount));

			return weight;
        }

		public class BagWindow : ContextMenuEntry 
		{ 
			private AlchemistPouch AlchemistBag; 
			private Mobile m_From; 

			public BagWindow( Mobile from, AlchemistPouch bag ) : base( 6172, 1 ) 
			{ 
				m_From = from; 
				AlchemistBag = bag; 
			} 

			public override void OnClick() 
			{          
				if( AlchemistBag.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.CloseGump( typeof( AlchemistBag ) );
					m_From.SendGump( new AlchemistBag( m_From, AlchemistBag ) );
					m_From.PlaySound( 0x48 );
				} 
				else 
				{
					m_From.SendMessage( "This must be in your backpack to organize." );
				} 
			} 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive )
				list.Add( new BagWindow( from, this ) );
		}

		public int Bar;
		[CommandProperty(AccessLevel.Owner)]
		public int m_Bar{ get { return Bar; } set { Bar = value; InvalidateProperties(); } }

		public int Titles;
		[CommandProperty(AccessLevel.Owner)]
		public int m_Titles { get { return Titles; } set { Titles = value; InvalidateProperties(); } }

		public int v_01_Agility;
		[CommandProperty(AccessLevel.Owner)]
		public int m_01_Agility { get { return v_01_Agility; } set { v_01_Agility = value; InvalidateProperties(); } }

		public int v_02_GreaterAgility;
		[CommandProperty(AccessLevel.Owner)]
		public int m_02_GreaterAgility { get { return v_02_GreaterAgility; } set { v_02_GreaterAgility = value; InvalidateProperties(); } }

		public int v_03_Conflagration;
		[CommandProperty(AccessLevel.Owner)]
		public int m_03_Conflagration { get { return v_03_Conflagration; } set { v_03_Conflagration = value; InvalidateProperties(); } }

		public int v_04_GreaterConflagration;
		[CommandProperty(AccessLevel.Owner)]
		public int m_04_GreaterConflagration { get { return v_04_GreaterConflagration; } set { v_04_GreaterConflagration = value; InvalidateProperties(); } }

		public int v_05_ConfusionBlast;
		[CommandProperty(AccessLevel.Owner)]
		public int m_05_ConfusionBlast { get { return v_05_ConfusionBlast; } set { v_05_ConfusionBlast = value; InvalidateProperties(); } }

		public int v_06_GreaterConfusionBlast;
		[CommandProperty(AccessLevel.Owner)]
		public int m_06_GreaterConfusionBlast { get { return v_06_GreaterConfusionBlast; } set { v_06_GreaterConfusionBlast = value; InvalidateProperties(); } }

		public int v_07_LesserCure;
		[CommandProperty(AccessLevel.Owner)]
		public int m_07_LesserCure { get { return v_07_LesserCure; } set { v_07_LesserCure = value; InvalidateProperties(); } }

		public int v_08_Cure;
		[CommandProperty(AccessLevel.Owner)]
		public int m_08_Cure { get { return v_08_Cure; } set { v_08_Cure = value; InvalidateProperties(); } }

		public int v_09_GreaterCure;
		[CommandProperty(AccessLevel.Owner)]
		public int m_09_GreaterCure { get { return v_09_GreaterCure; } set { v_09_GreaterCure = value; InvalidateProperties(); } }

		public int v_10_LesserExplosion;
		[CommandProperty(AccessLevel.Owner)]
		public int m_10_LesserExplosion { get { return v_10_LesserExplosion; } set { v_10_LesserExplosion = value; InvalidateProperties(); } }

		public int v_11_Explosion;
		[CommandProperty(AccessLevel.Owner)]
		public int m_11_Explosion { get { return v_11_Explosion; } set { v_11_Explosion = value; InvalidateProperties(); } }

		public int v_12_GreaterExplosion;
		[CommandProperty(AccessLevel.Owner)]
		public int m_12_GreaterExplosion { get { return v_12_GreaterExplosion; } set { v_12_GreaterExplosion = value; InvalidateProperties(); } }

		public int v_13_Frostbite;
		[CommandProperty(AccessLevel.Owner)]
		public int m_13_Frostbite { get { return v_13_Frostbite; } set { v_13_Frostbite = value; InvalidateProperties(); } }

		public int v_14_GreaterFrostbite;
		[CommandProperty(AccessLevel.Owner)]
		public int m_14_GreaterFrostbite { get { return v_14_GreaterFrostbite; } set { v_14_GreaterFrostbite = value; InvalidateProperties(); } }

		public int v_15_LesserHeal;
		[CommandProperty(AccessLevel.Owner)]
		public int m_15_LesserHeal { get { return v_15_LesserHeal; } set { v_15_LesserHeal = value; InvalidateProperties(); } }

		public int v_16_Heal;
		[CommandProperty(AccessLevel.Owner)]
		public int m_16_Heal { get { return v_16_Heal; } set { v_16_Heal = value; InvalidateProperties(); } }

		public int v_17_GreaterHeal;
		[CommandProperty(AccessLevel.Owner)]
		public int m_17_GreaterHeal { get { return v_17_GreaterHeal; } set { v_17_GreaterHeal = value; InvalidateProperties(); } }

		public int v_18_LesserInvisibility;
		[CommandProperty(AccessLevel.Owner)]
		public int m_18_LesserInvisibility { get { return v_18_LesserInvisibility; } set { v_18_LesserInvisibility = value; InvalidateProperties(); } }

		public int v_19_Invisibility;
		[CommandProperty(AccessLevel.Owner)]
		public int m_19_Invisibility { get { return v_19_Invisibility; } set { v_19_Invisibility = value; InvalidateProperties(); } }

		public int v_20_GreaterInvisibility;
		[CommandProperty(AccessLevel.Owner)]
		public int m_20_GreaterInvisibility { get { return v_20_GreaterInvisibility; } set { v_20_GreaterInvisibility = value; InvalidateProperties(); } }

		public int v_21_Invulnerability;
		[CommandProperty(AccessLevel.Owner)]
		public int m_21_Invulnerability { get { return v_21_Invulnerability; } set { v_21_Invulnerability = value; InvalidateProperties(); } }

		public int v_22_LesserMana;
		[CommandProperty(AccessLevel.Owner)]
		public int m_22_LesserMana { get { return v_22_LesserMana; } set { v_22_LesserMana = value; InvalidateProperties(); } }

		public int v_23_Mana;
		[CommandProperty(AccessLevel.Owner)]
		public int m_23_Mana { get { return v_23_Mana; } set { v_23_Mana = value; InvalidateProperties(); } }

		public int v_24_GreaterMana;
		[CommandProperty(AccessLevel.Owner)]
		public int m_24_GreaterMana { get { return v_24_GreaterMana; } set { v_24_GreaterMana = value; InvalidateProperties(); } }

		public int v_25_NightSight;
		[CommandProperty(AccessLevel.Owner)]
		public int m_25_NightSight { get { return v_25_NightSight; } set { v_25_NightSight = value; InvalidateProperties(); } }

		public int v_26_Refresh;
		[CommandProperty(AccessLevel.Owner)]
		public int m_26_Refresh { get { return v_26_Refresh; } set { v_26_Refresh = value; InvalidateProperties(); } }

		public int v_27_TotalRefresh;
		[CommandProperty(AccessLevel.Owner)]
		public int m_27_TotalRefresh { get { return v_27_TotalRefresh; } set { v_27_TotalRefresh = value; InvalidateProperties(); } }

		public int v_28_LesserRejuvenate;
		[CommandProperty(AccessLevel.Owner)]
		public int m_28_LesserRejuvenate { get { return v_28_LesserRejuvenate; } set { v_28_LesserRejuvenate = value; InvalidateProperties(); } }

		public int v_29_Rejuvenate;
		[CommandProperty(AccessLevel.Owner)]
		public int m_29_Rejuvenate { get { return v_29_Rejuvenate; } set { v_29_Rejuvenate = value; InvalidateProperties(); } }

		public int v_30_GreaterRejuvenate;
		[CommandProperty(AccessLevel.Owner)]
		public int m_30_GreaterRejuvenate { get { return v_30_GreaterRejuvenate; } set { v_30_GreaterRejuvenate = value; InvalidateProperties(); } }

		public int v_31_Strength;
		[CommandProperty(AccessLevel.Owner)]
		public int m_31_Strength { get { return v_31_Strength; } set { v_31_Strength = value; InvalidateProperties(); } }

		public int v_32_GreaterStrength;
		[CommandProperty(AccessLevel.Owner)]
		public int m_32_GreaterStrength { get { return v_32_GreaterStrength; } set { v_32_GreaterStrength = value; InvalidateProperties(); } }
	}
}