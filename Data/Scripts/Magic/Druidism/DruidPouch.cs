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
    public class DruidPouch : Bag
    {
		[Constructable]
		public DruidPouch() : base()
		{
			Weight = 2.0;
			MaxItems = 50;
			ItemID = 0x5776;
			Name = "druid's belt pouch";
			Hue = 0x8A1;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			if ( this.Weight > 1.0 ){ list.Add( 1070722, "Single Click to Organize" ); }
		}

		public override bool OnDragDropInto( Mobile from, Item dropped, Point3D p )
        {
			if ( isDruidery( dropped ) )
			{
				return base.OnDragDropInto(from, dropped, p);
			}

			from.SendMessage("This belt pouch is for witchery brewing items.");
			return false;
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
        {
			if ( isDruidery( dropped ) )
			{
				return base.OnDragDrop(from, dropped);
			}

			from.SendMessage("This belt pouch is for druidic herbalism items.");
			return false;
        }

		public class DruidBag : Gump
		{
			private DruidPouch m_Pouch;

			public DruidBag( Mobile from, DruidPouch bag ) : base( 50, 50 )
			{
				string color = "#80d080";
				m_Pouch = bag;
				m_Pouch.Weight = 1.0;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7026, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 13, 13, 300, 20, @"<BODY><BASEFONT Color=" + color + ">DRUID'S BELT POUCH</BASEFONT></BODY>", (bool)false, (bool)false);
				AddImage(10, 43, 11438);
				AddButton(863, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 325, 42, 565, 142, @"<BODY><BASEFONT Color=" + color + ">This bag is only for items used in the creation of druidic mixtures, as well as the potions created by it. These items will have their weight greatly reduced while in this bag. Here you can configure a quick belt pouch for these potions. This is also the only place where you can open and close the quick belt pouch, which is a bar that will open with icons for easy potion access. You can configure the bar to be either horizontal or vertical. You can choose if you want the names of the potions to appear with a vertical bar. You have to select which potions will appear in the bar. To learn more about druidic herbalism, seek out the book titled - Druidic Herbalism.</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b1 = 3609; if ( bag.LureStone > 0 ){ b1 = 4017; }
				AddButton(18, 338, b1, b1, 1, GumpButtonType.Reply, 0);
				AddImage(57, 328, 11446);
				AddHtml( 113, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Stone in a Jar</BASEFONT></BODY>", (bool)false, (bool)false);

				int b2 = 3609; if ( bag.NaturesPassage > 0 ){ b2 = 4017; }
				AddButton(18, 393, b2, b2, 2, GumpButtonType.Reply, 0);
				AddImage(57, 383, 11449);
				AddHtml( 113, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Nature Passage</BASEFONT></BODY>", (bool)false, (bool)false);

				int b3 = 3609; if ( bag.ShieldOfEarth > 0 ){ b3 = 4017; }
				AddButton(18, 448, b3, b3, 3, GumpButtonType.Reply, 0);
				AddImage(57, 438, 11450);
				AddHtml( 113, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Shield of Earth</BASEFONT></BODY>", (bool)false, (bool)false);

				int b4 = 3609; if ( bag.WoodlandProtection > 0 ){ b4 = 4017; }
				AddButton(18, 503, b4, b4, 4, GumpButtonType.Reply, 0);
				AddImage(57, 493, 11454);
				AddHtml( 113, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Woodland Protection</BASEFONT></BODY>", (bool)false, (bool)false);

				int b5 = 3609; if ( bag.StoneCircle > 0 ){ b5 = 4017; }
				AddButton(18, 558, b5, b5, 5, GumpButtonType.Reply, 0);
				AddImage(57, 548, 11451);
				AddHtml( 113, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Stone Rising</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b6 = 3609; if ( bag.GraspingRoots > 0 ){ b6 = 4017; }
				AddButton(322, 283, b6, b6, 6, GumpButtonType.Reply, 0);
				AddImage(361, 273, 11443);
				AddHtml( 417, 283, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Grasping Roots</BASEFONT></BODY>", (bool)false, (bool)false);

				int b7 = 3609; if ( bag.DruidicRune > 0 ){ b7 = 4017; }
				AddButton(322, 338, b7, b7, 7, GumpButtonType.Reply, 0);
				AddImage(361, 328, 11439);
				AddHtml( 417, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Druidic Marking</BASEFONT></BODY>", (bool)false, (bool)false);

				int b8 = 3609; if ( bag.HerbalHealing > 0 ){ b8 = 4017; }
				AddButton(322, 393, b8, b8, 8, GumpButtonType.Reply, 0);
				AddImage(361, 383, 11444);
				AddHtml( 417, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Herbal Healing</BASEFONT></BODY>", (bool)false, (bool)false);

				int b9 = 3609; if ( bag.BlendWithForest > 0 ){ b9 = 4017; }
				AddButton(322, 448, b9, b9, 9, GumpButtonType.Reply, 0);
				AddImage(361, 438, 11442);
				AddHtml( 417, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Forest Blending</BASEFONT></BODY>", (bool)false, (bool)false);

				int b10 = 3609; if ( bag.Firefly > 0 ){ b10 = 4017; }
				AddButton(322, 503, b10, b10, 10, GumpButtonType.Reply, 0);
				AddImage(361, 493, 11445);
				AddHtml( 417, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Jar of Fireflies</BASEFONT></BODY>", (bool)false, (bool)false);

				int b11 = 3609; if ( bag.MushroomGateway > 0 ){ b11 = 4017; }
				AddButton(322, 558, b11, b11, 11, GumpButtonType.Reply, 0);
				AddImage(361, 548, 11448);
				AddHtml( 417, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Mushroom Gateway</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b12 = 3609; if ( bag.SwarmOfInsects > 0 ){ b12 = 4017; }
				AddButton(631, 338, b12, b12, 12, GumpButtonType.Reply, 0);
				AddImage(670, 328, 11441);
				AddHtml( 726, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Jar of Insects</BASEFONT></BODY>", (bool)false, (bool)false);

				int b13 = 3609; if ( bag.ProtectiveFairy > 0 ){ b13 = 4017; }
				AddButton(631, 393, b13, b13, 13, GumpButtonType.Reply, 0);
				AddImage(670, 383, 11440);
				AddHtml( 726, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Fairy in a Jar</BASEFONT></BODY>", (bool)false, (bool)false);

				int b14 = 3609; if ( bag.Treefellow > 0 ){ b14 = 4017; }
				AddButton(631, 448, b14, b14, 14, GumpButtonType.Reply, 0);
				AddImage(670, 438, 11452);
				AddHtml( 726, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Treant Fertilizer</BASEFONT></BODY>", (bool)false, (bool)false);

				int b15 = 3609; if ( bag.VolcanicEruption > 0 ){ b15 = 4017; }
				AddButton(631, 503, b15, b15, 15, GumpButtonType.Reply, 0);
				AddImage(670, 493, 11453);
				AddHtml( 726, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Volcanic Fluid</BASEFONT></BODY>", (bool)false, (bool)false);

				int b16 = 3609; if ( bag.RestorativeSoil > 0 ){ b16 = 4017; }
				AddButton(631, 558, b16, b16, 16, GumpButtonType.Reply, 0);
				AddImage(670, 548, 11447);
				AddHtml( 726, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Magical Mud</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				AddButton(675, 201, 4029, 4029, 20, GumpButtonType.Reply, 0);
				AddHtml( 715, 201, 170, 20, @"<BODY><BASEFONT Color=" + color + ">Open Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(675, 231, 4020, 4020, 21, GumpButtonType.Reply, 0);
				AddHtml( 715, 231, 170, 20, @"<BODY><BASEFONT Color=" + color + ">Close Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);

				int bDisplay = 3609; if ( bag.Titles > 0 ){ bDisplay = 4017; }
				AddButton(325, 201, bDisplay, bDisplay, 22, GumpButtonType.Reply, 0);
				AddHtml( 365, 201, 295, 20, @"<BODY><BASEFONT Color=" + color + ">Display Potion Names When Vertical</BASEFONT></BODY>", (bool)false, (bool)false);

				int bVertical = 3609; if ( bag.Bar > 0 ){ bVertical = 4017; }
				AddButton(325, 231, bVertical, bVertical, 23, GumpButtonType.Reply, 0);
				AddHtml( 365, 231, 295, 20, @"<BODY><BASEFONT Color=" + color + ">Vertical Belt Pouch</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 

				if ( m_Pouch.IsChildOf( from.Backpack ) )
				{
					if ( info.ButtonID == 20 )
					{
						from.SendSound( 0x4A );
						from.CloseGump( typeof( DruidBar ) );
						from.SendGump( new DruidBag( from, m_Pouch ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new DruidBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new DruidBar( from, m_Pouch, false ) ); }
					}
					else if ( info.ButtonID == 21 )
					{
						from.SendSound( 0x4A );
						from.CloseGump( typeof( DruidBar ) );
						from.SendGump( new DruidBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 22 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Titles == 1 ){ m_Pouch.Titles = 0; } else { m_Pouch.Titles = 1; }
						from.CloseGump( typeof( DruidBag ) );
						from.SendGump( new DruidBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 23 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Bar == 1 ){ m_Pouch.Bar = 0; } else { m_Pouch.Bar = 1; }
						from.CloseGump( typeof( DruidBag ) );
						from.SendGump( new DruidBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID > 0 && info.ButtonID < 17 )
					{
						from.SendSound( 0x4A );
						if ( info.ButtonID == 1 ){ if ( m_Pouch.LureStone == 1 ){ m_Pouch.LureStone = 0; } else { m_Pouch.LureStone = 1; } }
						else if ( info.ButtonID == 2 ){ if ( m_Pouch.NaturesPassage == 1 ){ m_Pouch.NaturesPassage = 0; } else { m_Pouch.NaturesPassage = 1; } }
						else if ( info.ButtonID == 3 ){ if ( m_Pouch.ShieldOfEarth == 1 ){ m_Pouch.ShieldOfEarth = 0; } else { m_Pouch.ShieldOfEarth = 1; } }
						else if ( info.ButtonID == 4 ){ if ( m_Pouch.WoodlandProtection == 1 ){ m_Pouch.WoodlandProtection = 0; } else { m_Pouch.WoodlandProtection = 1; } }
						else if ( info.ButtonID == 5 ){ if ( m_Pouch.StoneCircle == 1 ){ m_Pouch.StoneCircle = 0; } else { m_Pouch.StoneCircle = 1; } }
						else if ( info.ButtonID == 6 ){ if ( m_Pouch.GraspingRoots == 1 ){ m_Pouch.GraspingRoots = 0; } else { m_Pouch.GraspingRoots = 1; } }
						else if ( info.ButtonID == 7 ){ if ( m_Pouch.DruidicRune == 1 ){ m_Pouch.DruidicRune = 0; } else { m_Pouch.DruidicRune = 1; } }
						else if ( info.ButtonID == 8 ){ if ( m_Pouch.HerbalHealing == 1 ){ m_Pouch.HerbalHealing = 0; } else { m_Pouch.HerbalHealing = 1; } }
						else if ( info.ButtonID == 9 ){ if ( m_Pouch.BlendWithForest == 1 ){ m_Pouch.BlendWithForest = 0; } else { m_Pouch.BlendWithForest = 1; } }
						else if ( info.ButtonID == 10 ){ if ( m_Pouch.Firefly == 1 ){ m_Pouch.Firefly = 0; } else { m_Pouch.Firefly = 1; } }
						else if ( info.ButtonID == 11 ){ if ( m_Pouch.MushroomGateway == 1 ){ m_Pouch.MushroomGateway = 0; } else { m_Pouch.MushroomGateway = 1; } }
						else if ( info.ButtonID == 12 ){ if ( m_Pouch.SwarmOfInsects == 1 ){ m_Pouch.SwarmOfInsects = 0; } else { m_Pouch.SwarmOfInsects = 1; } }
						else if ( info.ButtonID == 13 ){ if ( m_Pouch.ProtectiveFairy == 1 ){ m_Pouch.ProtectiveFairy = 0; } else { m_Pouch.ProtectiveFairy = 1; } }
						else if ( info.ButtonID == 14 ){ if ( m_Pouch.Treefellow == 1 ){ m_Pouch.Treefellow = 0; } else { m_Pouch.Treefellow = 1; } }
						else if ( info.ButtonID == 15 ){ if ( m_Pouch.VolcanicEruption == 1 ){ m_Pouch.VolcanicEruption = 0; } else { m_Pouch.VolcanicEruption = 1; } }
						else if ( info.ButtonID == 16 ){ if ( m_Pouch.RestorativeSoil == 1 ){ m_Pouch.RestorativeSoil = 0; } else { m_Pouch.RestorativeSoil = 1; } }

						from.CloseGump( typeof( DruidBag ) );
						from.SendGump( new DruidBag( from, m_Pouch ) );
					}
					else
					{
						from.PlaySound( 0x48 );
					}

					if ( from.HasGump( typeof( DruidBar ) ) )
					{
						from.CloseGump( typeof( DruidBar ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new DruidBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new DruidBar( from, m_Pouch, false ) ); }
					}
				}
			}
		}

		public class DruidBar : Gump
		{
			private DruidPouch m_Pouch;
			public DruidBar( Mobile from, DruidPouch bag, bool vertical ): base( 25, 25 )
			{
				this.Closable=false;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;
				AddPage(0);
				m_Pouch = bag;

				if ( vertical )
				{
					int val = 3;
					int txt = 17;

					AddImage(15, 4, 11436);
					if ( bag.LureStone > 0 ){ val = val + 50; AddButton(15, val, 11446, 11446, 1, GumpButtonType.Reply, 0); }
					if ( bag.NaturesPassage > 0 ){ val = val + 50; AddButton(15, val, 11449, 11449, 2, GumpButtonType.Reply, 0); }
					if ( bag.ShieldOfEarth > 0 ){ val = val + 50; AddButton(15, val, 11450, 11450, 3, GumpButtonType.Reply, 0); }
					if ( bag.WoodlandProtection > 0 ){ val = val + 50; AddButton(15, val, 11454, 11454, 4, GumpButtonType.Reply, 0); }
					if ( bag.StoneCircle > 0 ){ val = val + 50; AddButton(15, val, 11451, 11451, 5, GumpButtonType.Reply, 0); }
					if ( bag.GraspingRoots > 0 ){ val = val + 50; AddButton(15, val, 11443, 11443, 6, GumpButtonType.Reply, 0); }
					if ( bag.DruidicRune > 0 ){ val = val + 50; AddButton(15, val, 11439, 11439, 7, GumpButtonType.Reply, 0); }
					if ( bag.HerbalHealing > 0 ){ val = val + 50; AddButton(15, val, 11444, 11444, 8, GumpButtonType.Reply, 0); }
					if ( bag.BlendWithForest > 0 ){ val = val + 50; AddButton(15, val, 11442, 11442, 9, GumpButtonType.Reply, 0); }
					if ( bag.Firefly > 0 ){ val = val + 50; AddButton(15, val, 11445, 11445, 10, GumpButtonType.Reply, 0); }
					if ( bag.MushroomGateway > 0 ){ val = val + 50; AddButton(15, val, 11448, 11448, 11, GumpButtonType.Reply, 0); }
					if ( bag.SwarmOfInsects > 0 ){ val = val + 50; AddButton(15, val, 11441, 11441, 12, GumpButtonType.Reply, 0); }
					if ( bag.ProtectiveFairy > 0 ){ val = val + 50; AddButton(15, val, 11440, 11440, 13, GumpButtonType.Reply, 0); }
					if ( bag.Treefellow > 0 ){ val = val + 50; AddButton(15, val, 11452, 11452, 14, GumpButtonType.Reply, 0); }
					if ( bag.VolcanicEruption > 0 ){ val = val + 50; AddButton(15, val, 11453, 11453, 15, GumpButtonType.Reply, 0); }
					if ( bag.RestorativeSoil > 0 ){ val = val + 50; AddButton(15, val, 11447, 11447, 16, GumpButtonType.Reply, 0); }

					if ( bag.Titles > 0 )
					{
						if ( bag.LureStone > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Stone in a Jar"); }
						if ( bag.NaturesPassage > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Nature Passage"); }
						if ( bag.ShieldOfEarth > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Shield of Earth"); }
						if ( bag.WoodlandProtection > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Woodland Protection"); }
						if ( bag.StoneCircle > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Stone Rising"); }
						if ( bag.GraspingRoots > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Grasping Roots"); }
						if ( bag.DruidicRune > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Druidic Marking"); }
						if ( bag.HerbalHealing > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Herbal Healing"); }
						if ( bag.BlendWithForest > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Forest Blending"); }
						if ( bag.Firefly > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Jar of Fireflies"); }
						if ( bag.MushroomGateway > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Mushroom Gateway"); }
						if ( bag.SwarmOfInsects > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Jar of Insects"); }
						if ( bag.ProtectiveFairy > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Fairy in a Jar"); }
						if ( bag.Treefellow > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Treant Fertilizer"); }
						if ( bag.VolcanicEruption > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Volcanic Fluid"); }
						if ( bag.RestorativeSoil > 0 ){ txt = txt + 50; AddLabel(70, txt, 2962, @"Magical Mud"); }
					}
				}
				else
				{
					int val = 27;

					AddImage(32, 0, 11436);
					if ( bag.LureStone > 0 ){ val = val + 50; AddButton(val, 0, 11446, 11446, 1, GumpButtonType.Reply, 0); }
					if ( bag.NaturesPassage > 0 ){ val = val + 50; AddButton(val, 0, 11449, 11449, 2, GumpButtonType.Reply, 0); }
					if ( bag.ShieldOfEarth > 0 ){ val = val + 50; AddButton(val, 0, 11450, 11450, 3, GumpButtonType.Reply, 0); }
					if ( bag.WoodlandProtection > 0 ){ val = val + 50; AddButton(val, 0, 11454, 11454, 4, GumpButtonType.Reply, 0); }
					if ( bag.StoneCircle > 0 ){ val = val + 50; AddButton(val, 0, 11451, 11451, 5, GumpButtonType.Reply, 0); }
					if ( bag.GraspingRoots > 0 ){ val = val + 50; AddButton(val, 0, 11443, 11443, 6, GumpButtonType.Reply, 0); }
					if ( bag.DruidicRune > 0 ){ val = val + 50; AddButton(val, 0, 11439, 11439, 7, GumpButtonType.Reply, 0); }
					if ( bag.HerbalHealing > 0 ){ val = val + 50; AddButton(val, 0, 11444, 11444, 8, GumpButtonType.Reply, 0); }
					if ( bag.BlendWithForest > 0 ){ val = val + 50; AddButton(val, 0, 11442, 11442, 9, GumpButtonType.Reply, 0); }
					if ( bag.Firefly > 0 ){ val = val + 50; AddButton(val, 0, 11445, 11445, 10, GumpButtonType.Reply, 0); }
					if ( bag.MushroomGateway > 0 ){ val = val + 50; AddButton(val, 0, 11448, 11448, 11, GumpButtonType.Reply, 0); }
					if ( bag.SwarmOfInsects > 0 ){ val = val + 50; AddButton(val, 0, 11441, 11441, 12, GumpButtonType.Reply, 0); }
					if ( bag.ProtectiveFairy > 0 ){ val = val + 50; AddButton(val, 0, 11440, 11440, 13, GumpButtonType.Reply, 0); }
					if ( bag.Treefellow > 0 ){ val = val + 50; AddButton(val, 0, 11452, 11452, 14, GumpButtonType.Reply, 0); }
					if ( bag.VolcanicEruption > 0 ){ val = val + 50; AddButton(val, 0, 11453, 11453, 15, GumpButtonType.Reply, 0); }
					if ( bag.RestorativeSoil > 0 ){ val = val + 50; AddButton(val, 0, 11447, 11447, 16, GumpButtonType.Reply, 0); }
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile;
				if ( m_Pouch.IsChildOf( from.Backpack ) )
				{
					castSpell( info.ButtonID, from );
					from.CloseGump( typeof( DruidBar ) );
					bool vertical = false; if ( m_Pouch.Bar == 1 ){ vertical = true; }
					from.SendGump( new DruidBar( from, m_Pouch, vertical ) );
				}
			}
		}

		public static void castSpell( int potion, Mobile from )
		{
			bool warn = true;

			if ( potion == 1 && from.Backpack.FindItemByType( typeof ( LureStonePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( LureStonePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 2 && from.Backpack.FindItemByType( typeof ( NaturesPassagePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( NaturesPassagePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 3 && from.Backpack.FindItemByType( typeof ( ShieldOfEarthPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ShieldOfEarthPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 4 && from.Backpack.FindItemByType( typeof ( WoodlandProtectionPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( WoodlandProtectionPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 5 && from.Backpack.FindItemByType( typeof ( StoneCirclePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( StoneCirclePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 6 && from.Backpack.FindItemByType( typeof ( GraspingRootsPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GraspingRootsPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 7 && from.Backpack.FindItemByType( typeof ( DruidicRunePotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( DruidicRunePotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 8 && from.Backpack.FindItemByType( typeof ( HerbalHealingPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( HerbalHealingPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 9 && from.Backpack.FindItemByType( typeof ( BlendWithForestPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( BlendWithForestPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 10 && from.Backpack.FindItemByType( typeof ( FireflyPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( FireflyPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 11 && from.Backpack.FindItemByType( typeof ( MushroomGatewayPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( MushroomGatewayPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 12 && from.Backpack.FindItemByType( typeof ( SwarmOfInsectsPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( SwarmOfInsectsPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 13 && from.Backpack.FindItemByType( typeof ( ProtectiveFairyPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ProtectiveFairyPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 14 && from.Backpack.FindItemByType( typeof ( TreefellowPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( TreefellowPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 15 && from.Backpack.FindItemByType( typeof ( VolcanicEruptionPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( VolcanicEruptionPotion ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 16 && from.Backpack.FindItemByType( typeof ( RestorativeSoilPotion ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( RestorativeSoilPotion ) ) ).OnDoubleClick(from); warn = false; }

			if ( warn ){ warnMe( from ); }
		}

		public static void warnMe( Mobile from )
		{
			string text = "You don't have that mixture!";

			from.SendMessage( text );
			from.LocalOverheadMessage(MessageType.Emote, 1150, true, text);
		}

		public override bool OnDragLift( Mobile from )
		{
			from.SendMessage( "Single click this bag to organize it." );
			return base.OnDragLift( from );
		}

		public DruidPouch( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( Bar );
			writer.Write( Titles );
			writer.Write( LureStone );
			writer.Write( NaturesPassage );
			writer.Write( ShieldOfEarth );
			writer.Write( WoodlandProtection );
			writer.Write( StoneCircle );
			writer.Write( GraspingRoots );
			writer.Write( DruidicRune );
			writer.Write( HerbalHealing );
			writer.Write( BlendWithForest );
			writer.Write( Firefly );
			writer.Write( MushroomGateway );
			writer.Write( SwarmOfInsects );
			writer.Write( ProtectiveFairy );
			writer.Write( Treefellow );
			writer.Write( VolcanicEruption );
			writer.Write( RestorativeSoil );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Bar = reader.ReadInt();
			Titles = reader.ReadInt();
			LureStone = reader.ReadInt();
			NaturesPassage = reader.ReadInt();
			ShieldOfEarth = reader.ReadInt();
			WoodlandProtection = reader.ReadInt();
			StoneCircle = reader.ReadInt();
			GraspingRoots = reader.ReadInt();
			DruidicRune = reader.ReadInt();
			HerbalHealing = reader.ReadInt();
			BlendWithForest = reader.ReadInt();
			Firefly = reader.ReadInt();
			MushroomGateway = reader.ReadInt();
			SwarmOfInsects = reader.ReadInt();
			ProtectiveFairy = reader.ReadInt();
			Treefellow = reader.ReadInt();
			VolcanicEruption = reader.ReadInt();
			RestorativeSoil = reader.ReadInt();
			Weight = 1.0;
			MaxItems = 50;
		}

		public static bool isDruidery( Item item )
		{
			if (
				item is BookDruidBrewing || 
				item is DruidCauldron || 
				item is Jar || 
				item is BlackPearl || 
				item is Bloodmoss || 
				item is Garlic || 
				item is Ginseng || 
				item is MandrakeRoot || 
				item is Nightshade || 
				item is SpidersSilk || 
				item is SulfurousAsh || 
				item is Brimstone || 
				item is ButterflyWings || 
				item is EyeOfToad || 
				item is FairyEgg || 
				item is BeetleShell || 
				item is MoonCrystal || 
				item is RedLotus || 
				item is SeaSalt || 
				item is SilverWidow || 
				item is SwampBerries || 
				item is LureStonePotion || 
				item is NaturesPassagePotion || 
				item is ShieldOfEarthPotion || 
				item is WoodlandProtectionPotion || 
				item is StoneCirclePotion || 
				item is GraspingRootsPotion || 
				item is DruidicRunePotion || 
				item is HerbalHealingPotion || 
				item is BlendWithForestPotion || 
				item is FireflyPotion || 
				item is MushroomGatewayPotion || 
				item is SwarmOfInsectsPotion || 
				item is ProtectiveFairyPotion || 
				item is TreefellowPotion || 
				item is VolcanicEruptionPotion || 
				item is RestorativeSoilPotion 
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
			private DruidPouch druidBag; 
			private Mobile m_From; 

			public BagWindow( Mobile from, DruidPouch bag ) : base( 6172, 1 ) 
			{ 
				m_From = from; 
				druidBag = bag; 
			} 

			public override void OnClick() 
			{          
				if( druidBag.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.CloseGump( typeof( DruidBag ) );
					m_From.SendGump( new DruidBag( m_From, druidBag ) );
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

		public int LureStone;
		[CommandProperty(AccessLevel.Owner)]
		public int m_LureStone { get { return LureStone; } set { LureStone = value; InvalidateProperties(); } }

		public int NaturesPassage;
		[CommandProperty(AccessLevel.Owner)]
		public int m_NaturesPassage { get { return NaturesPassage; } set { NaturesPassage = value; InvalidateProperties(); } }

		public int ShieldOfEarth;
		[CommandProperty(AccessLevel.Owner)]
		public int m_ShieldOfEarth { get { return ShieldOfEarth; } set { ShieldOfEarth = value; InvalidateProperties(); } }

		public int WoodlandProtection;
		[CommandProperty(AccessLevel.Owner)]
		public int m_WoodlandProtection { get { return WoodlandProtection; } set { WoodlandProtection = value; InvalidateProperties(); } }

		public int StoneCircle;
		[CommandProperty(AccessLevel.Owner)]
		public int m_StoneCircle { get { return StoneCircle; } set { StoneCircle = value; InvalidateProperties(); } }

		public int GraspingRoots;
		[CommandProperty(AccessLevel.Owner)]
		public int m_GraspingRoots { get { return GraspingRoots; } set { GraspingRoots = value; InvalidateProperties(); } }

		public int DruidicRune;
		[CommandProperty(AccessLevel.Owner)]
		public int m_DruidicRune { get { return DruidicRune; } set { DruidicRune = value; InvalidateProperties(); } }

		public int HerbalHealing;
		[CommandProperty(AccessLevel.Owner)]
		public int m_HerbalHealing { get { return HerbalHealing; } set { HerbalHealing = value; InvalidateProperties(); } }

		public int BlendWithForest;
		[CommandProperty(AccessLevel.Owner)]
		public int m_BlendWithForest { get { return BlendWithForest; } set { BlendWithForest = value; InvalidateProperties(); } }

		public int Firefly;
		[CommandProperty(AccessLevel.Owner)]
		public int m_Firefly { get { return Firefly; } set { Firefly = value; InvalidateProperties(); } }

		public int MushroomGateway;
		[CommandProperty(AccessLevel.Owner)]
		public int m_MushroomGateway { get { return MushroomGateway; } set { MushroomGateway = value; InvalidateProperties(); } }

		public int SwarmOfInsects;
		[CommandProperty(AccessLevel.Owner)]
		public int m_SwarmOfInsects { get { return SwarmOfInsects; } set { SwarmOfInsects = value; InvalidateProperties(); } }

		public int ProtectiveFairy;
		[CommandProperty(AccessLevel.Owner)]
		public int m_ProtectiveFairy { get { return ProtectiveFairy; } set { ProtectiveFairy = value; InvalidateProperties(); } }

		public int Treefellow;
		[CommandProperty(AccessLevel.Owner)]
		public int m_Treefellow { get { return Treefellow; } set { Treefellow = value; InvalidateProperties(); } }

		public int VolcanicEruption;
		[CommandProperty(AccessLevel.Owner)]
		public int m_VolcanicEruption { get { return VolcanicEruption; } set { VolcanicEruption = value; InvalidateProperties(); } }

		public int RestorativeSoil;
		[CommandProperty(AccessLevel.Owner)]
		public int m_RestorativeSoil { get { return RestorativeSoil; } set { RestorativeSoil = value; InvalidateProperties(); } }
	}
}