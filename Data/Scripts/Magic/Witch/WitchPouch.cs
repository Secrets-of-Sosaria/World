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
    public class WitchPouch : Bag
    {
		[Constructable]
		public WitchPouch() : base()
		{
			Weight = 2.0;
			MaxItems = 50;
			ItemID = 0x5776;
			Name = "witch's belt pouch";
			Hue = 0x845;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			if ( this.Weight > 1.0 ){ list.Add( 1070722, "Single Click to Organize" ); }
		}

		public override bool OnDragDropInto( Mobile from, Item dropped, Point3D p )
        {
			if ( isWitchery( dropped ) )
			{
				return base.OnDragDropInto(from, dropped, p);
			}

			from.SendMessage("This belt pouch is for witchery brewing items.");
			return false;
        }

		public override bool OnDragDrop( Mobile from, Item dropped )
        {
			if ( isWitchery( dropped ) )
			{
				return base.OnDragDrop(from, dropped);
			}

			from.SendMessage("This belt pouch is for witchery brewing items.");
			return false;
        }

		public class WitchBag : Gump
		{
			private WitchPouch m_Pouch;

			public WitchBag( Mobile from, WitchPouch bag ) : base( 50, 50 )
			{
				string color = "#d89191";
				m_Pouch = bag;
				m_Pouch.Weight = 1.0;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7026, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 13, 13, 300, 20, @"<BODY><BASEFONT Color=" + color + ">WITCH'S BELT POUCH</BASEFONT></BODY>", (bool)false, (bool)false);
				AddImage(10, 43, 11437);
				AddButton(863, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 325, 42, 565, 142, @"<BODY><BASEFONT Color=" + color + ">This bag is only for items used in the creation of witchery brews, as well as the concoctions created by it. These items will have their weight greatly reduced while in this bag. Here you can configure a quick belt pouch for these potions. This is also the only place where you can open and close the quick belt pouch, which is a bar that will open with icons for easy potion access. You can configure the bar to be either horizontal or vertical. You can choose if you want the names of the potions to appear with a vertical bar. You have to select which potions will appear in the bar. To learn more about witchery brewing, seek out the book titled - The Witch's Brew.</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b1 = 3609; if ( bag.UndeadEyes > 0 ){ b1 = 4017; }
				AddButton(18, 338, b1, b1, 1, GumpButtonType.Reply, 0);
				AddImage(57, 328, 0x2CC4);
				AddHtml( 113, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Eyes of the Dead</BASEFONT></BODY>", (bool)false, (bool)false);

				int b2 = 3609; if ( bag.NecroUnlock > 0 ){ b2 = 4017; }
				AddButton(18, 393, b2, b2, 2, GumpButtonType.Reply, 0);
				AddImage(57, 383, 0x2CCC);
				AddHtml( 113, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Tomb Raiding</BASEFONT></BODY>", (bool)false, (bool)false);

				int b3 = 3609; if ( bag.NecroPoison > 0 ){ b3 = 4017; }
				AddButton(18, 448, b3, b3, 3, GumpButtonType.Reply, 0);
				AddImage(57, 438, 0x2CC2);
				AddHtml( 113, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Disease</BASEFONT></BODY>", (bool)false, (bool)false);

				int b4 = 3609; if ( bag.Phantasm > 0 ){ b4 = 4017; }
				AddButton(18, 503, b4, b4, 4, GumpButtonType.Reply, 0);
				AddImage(57, 493, 0x2CC9);
				AddHtml( 113, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Phantasm</BASEFONT></BODY>", (bool)false, (bool)false);

				int b5 = 3609; if ( bag.RetchedAir > 0 ){ b5 = 4017; }
				AddButton(18, 558, b5, b5, 5, GumpButtonType.Reply, 0);
				AddImage(57, 548, 0x2CCA);
				AddHtml( 113, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Retched Air</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b6 = 3609; if ( bag.ManaLeech > 0 ){ b6 = 4017; }
				AddButton(322, 283, b6, b6, 6, GumpButtonType.Reply, 0);
				AddImage(361, 273, 0x2CC8);
				AddHtml( 417, 283, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Lich Leech</BASEFONT></BODY>", (bool)false, (bool)false);

				int b7 = 3609; if ( bag.WallOfSpikes > 0 ){ b7 = 4017; }
				AddButton(322, 338, b7, b7, 7, GumpButtonType.Reply, 0);
				AddImage(361, 328, 0x2CCE);
				AddHtml( 417, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Wall of Spikes</BASEFONT></BODY>", (bool)false, (bool)false);

				int b8 = 3609; if ( bag.NecroCurePoison > 0 ){ b8 = 4017; }
				AddButton(322, 393, b8, b8, 8, GumpButtonType.Reply, 0);
				AddImage(361, 383, 0x2CC3);
				AddHtml( 417, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Disease Curing</BASEFONT></BODY>", (bool)false, (bool)false);

				int b9 = 3609; if ( bag.BloodPact > 0 ){ b9 = 4017; }
				AddButton(322, 448, b9, b9, 9, GumpButtonType.Reply, 0);
				AddImage(361, 438, 0x2CC0);
				AddHtml( 417, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Blood Pact</BASEFONT></BODY>", (bool)false, (bool)false);

				int b10 = 3609; if ( bag.SpectreShadow > 0 ){ b10 = 4017; }
				AddButton(322, 503, b10, b10, 10, GumpButtonType.Reply, 0);
				AddImage(361, 493, 0x2CCB);
				AddHtml( 417, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Spectre Shadow</BASEFONT></BODY>", (bool)false, (bool)false);

				int b11 = 3609; if ( bag.GhostPhase > 0 ){ b11 = 4017; }
				AddButton(322, 558, b11, b11, 11, GumpButtonType.Reply, 0);
				AddImage(361, 548, 0x2CC5);
				AddHtml( 417, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Ghost Phase</BASEFONT></BODY>", (bool)false, (bool)false);

				// ------------------------------------------------------------------------

				int b12 = 3609; if ( bag.HellsGate > 0 ){ b12 = 4017; }
				AddButton(631, 338, b12, b12, 12, GumpButtonType.Reply, 0);
				AddImage(670, 328, 0x2CC1);
				AddHtml( 726, 338, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Demonic Fire</BASEFONT></BODY>", (bool)false, (bool)false);

				int b13 = 3609; if ( bag.GhostlyImages > 0 ){ b13 = 4017; }
				AddButton(631, 393, b13, b13, 13, GumpButtonType.Reply, 0);
				AddImage(670, 383, 0x2CC6);
				AddHtml( 726, 393, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Ghostly Images</BASEFONT></BODY>", (bool)false, (bool)false);

				int b14 = 3609; if ( bag.HellsBrand > 0 ){ b14 = 4017; }
				AddButton(631, 448, b14, b14, 14, GumpButtonType.Reply, 0);
				AddImage(670, 438, 0x2CC7);
				AddHtml( 726, 448, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Hellish Branding</BASEFONT></BODY>", (bool)false, (bool)false);

				int b15 = 3609; if ( bag.GraveyardGateway > 0 ){ b15 = 4017; }
				AddButton(631, 503, b15, b15, 15, GumpButtonType.Reply, 0);
				AddImage(670, 493, 0x2CBF);
				AddHtml( 726, 503, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Black Gate</BASEFONT></BODY>", (bool)false, (bool)false);

				int b16 = 3609; if ( bag.VampireGift > 0 ){ b16 = 4017; }
				AddButton(631, 558, b16, b16, 16, GumpButtonType.Reply, 0);
				AddImage(670, 548, 0x2CCD);
				AddHtml( 726, 558, 144, 20, @"<BODY><BASEFONT Color=" + color + ">Vampire Blood</BASEFONT></BODY>", (bool)false, (bool)false);

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
						from.CloseGump( typeof( WitchBar ) );
						from.SendGump( new WitchBag( from, m_Pouch ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new WitchBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new WitchBar( from, m_Pouch, false ) ); }
					}
					else if ( info.ButtonID == 21 )
					{
						from.SendSound( 0x4A );
						from.CloseGump( typeof( WitchBar ) );
						from.SendGump( new WitchBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 22 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Titles == 1 ){ m_Pouch.Titles = 0; } else { m_Pouch.Titles = 1; }
						from.CloseGump( typeof( WitchBag ) );
						from.SendGump( new WitchBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID == 23 )
					{
						from.SendSound( 0x4A );
						if ( m_Pouch.Bar == 1 ){ m_Pouch.Bar = 0; } else { m_Pouch.Bar = 1; }
						from.CloseGump( typeof( WitchBag ) );
						from.SendGump( new WitchBag( from, m_Pouch ) );
					}
					else if ( info.ButtonID > 0 && info.ButtonID < 17 )
					{
						from.SendSound( 0x4A );
						if ( info.ButtonID == 1 ){ if ( m_Pouch.UndeadEyes == 1 ){ m_Pouch.UndeadEyes = 0; } else { m_Pouch.UndeadEyes = 1; } }
						else if ( info.ButtonID == 2 ){ if ( m_Pouch.NecroUnlock == 1 ){ m_Pouch.NecroUnlock = 0; } else { m_Pouch.NecroUnlock = 1; } }
						else if ( info.ButtonID == 3 ){ if ( m_Pouch.NecroPoison == 1 ){ m_Pouch.NecroPoison = 0; } else { m_Pouch.NecroPoison = 1; } }
						else if ( info.ButtonID == 4 ){ if ( m_Pouch.Phantasm == 1 ){ m_Pouch.Phantasm = 0; } else { m_Pouch.Phantasm = 1; } }
						else if ( info.ButtonID == 5 ){ if ( m_Pouch.RetchedAir == 1 ){ m_Pouch.RetchedAir = 0; } else { m_Pouch.RetchedAir = 1; } }
						else if ( info.ButtonID == 6 ){ if ( m_Pouch.ManaLeech == 1 ){ m_Pouch.ManaLeech = 0; } else { m_Pouch.ManaLeech = 1; } }
						else if ( info.ButtonID == 7 ){ if ( m_Pouch.WallOfSpikes == 1 ){ m_Pouch.WallOfSpikes = 0; } else { m_Pouch.WallOfSpikes = 1; } }
						else if ( info.ButtonID == 8 ){ if ( m_Pouch.NecroCurePoison == 1 ){ m_Pouch.NecroCurePoison = 0; } else { m_Pouch.NecroCurePoison = 1; } }
						else if ( info.ButtonID == 9 ){ if ( m_Pouch.BloodPact == 1 ){ m_Pouch.BloodPact = 0; } else { m_Pouch.BloodPact = 1; } }
						else if ( info.ButtonID == 10 ){ if ( m_Pouch.SpectreShadow == 1 ){ m_Pouch.SpectreShadow = 0; } else { m_Pouch.SpectreShadow = 1; } }
						else if ( info.ButtonID == 11 ){ if ( m_Pouch.GhostPhase == 1 ){ m_Pouch.GhostPhase = 0; } else { m_Pouch.GhostPhase = 1; } }
						else if ( info.ButtonID == 12 ){ if ( m_Pouch.HellsGate == 1 ){ m_Pouch.HellsGate = 0; } else { m_Pouch.HellsGate = 1; } }
						else if ( info.ButtonID == 13 ){ if ( m_Pouch.GhostlyImages == 1 ){ m_Pouch.GhostlyImages = 0; } else { m_Pouch.GhostlyImages = 1; } }
						else if ( info.ButtonID == 14 ){ if ( m_Pouch.HellsBrand == 1 ){ m_Pouch.HellsBrand = 0; } else { m_Pouch.HellsBrand = 1; } }
						else if ( info.ButtonID == 15 ){ if ( m_Pouch.GraveyardGateway == 1 ){ m_Pouch.GraveyardGateway = 0; } else { m_Pouch.GraveyardGateway = 1; } }
						else if ( info.ButtonID == 16 ){ if ( m_Pouch.VampireGift == 1 ){ m_Pouch.VampireGift = 0; } else { m_Pouch.VampireGift = 1; } }

						from.CloseGump( typeof( WitchBag ) );
						from.SendGump( new WitchBag( from, m_Pouch ) );
					}
					else
					{
						from.PlaySound( 0x48 );
					}

					if ( from.HasGump( typeof( WitchBar ) ) )
					{
						from.CloseGump( typeof( WitchBar ) );
						if ( m_Pouch.Bar == 1 ){ from.SendGump( new WitchBar( from, m_Pouch, true ) ); }
						else { from.SendGump( new WitchBar( from, m_Pouch, false ) ); }
					}
				}
			}
		}

		public class WitchBar : Gump
		{
			private WitchPouch m_Pouch;
			public WitchBar( Mobile from, WitchPouch bag, bool vertical ): base( 25, 25 )
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

					AddImage(15, 4, 11471);
					if ( bag.UndeadEyes > 0 ){ val = val + 50; AddButton(15, val, 0x2CC4, 0x2CC4, 1, GumpButtonType.Reply, 0); }
					if ( bag.NecroUnlock > 0 ){ val = val + 50; AddButton(15, val, 0x2CCC, 0x2CCC, 2, GumpButtonType.Reply, 0); }
					if ( bag.NecroPoison > 0 ){ val = val + 50; AddButton(15, val, 0x2CC2, 0x2CC2, 3, GumpButtonType.Reply, 0); }
					if ( bag.Phantasm > 0 ){ val = val + 50; AddButton(15, val, 0x2CC9, 0x2CC9, 4, GumpButtonType.Reply, 0); }
					if ( bag.RetchedAir > 0 ){ val = val + 50; AddButton(15, val, 0x2CCA, 0x2CCA, 5, GumpButtonType.Reply, 0); }
					if ( bag.ManaLeech > 0 ){ val = val + 50; AddButton(15, val, 0x2CC8, 0x2CC8, 6, GumpButtonType.Reply, 0); }
					if ( bag.WallOfSpikes > 0 ){ val = val + 50; AddButton(15, val, 0x2CCE, 0x2CCE, 7, GumpButtonType.Reply, 0); }
					if ( bag.NecroCurePoison > 0 ){ val = val + 50; AddButton(15, val, 0x2CC3, 0x2CC3, 8, GumpButtonType.Reply, 0); }
					if ( bag.BloodPact > 0 ){ val = val + 50; AddButton(15, val, 0x2CC0, 0x2CC0, 9, GumpButtonType.Reply, 0); }
					if ( bag.SpectreShadow > 0 ){ val = val + 50; AddButton(15, val, 0x2CCB, 0x2CCB, 10, GumpButtonType.Reply, 0); }
					if ( bag.GhostPhase > 0 ){ val = val + 50; AddButton(15, val, 0x2CC5, 0x2CC5, 11, GumpButtonType.Reply, 0); }
					if ( bag.HellsGate > 0 ){ val = val + 50; AddButton(15, val, 0x2CC1, 0x2CC1, 12, GumpButtonType.Reply, 0); }
					if ( bag.GhostlyImages > 0 ){ val = val + 50; AddButton(15, val, 0x2CC6, 0x2CC6, 13, GumpButtonType.Reply, 0); }
					if ( bag.HellsBrand > 0 ){ val = val + 50; AddButton(15, val, 0x2CC7, 0x2CC7, 14, GumpButtonType.Reply, 0); }
					if ( bag.GraveyardGateway > 0 ){ val = val + 50; AddButton(15, val, 0x2CBF, 0x2CBF, 15, GumpButtonType.Reply, 0); }
					if ( bag.VampireGift > 0 ){ val = val + 50; AddButton(15, val, 0x2CCD, 0x2CCD, 16, GumpButtonType.Reply, 0); }

					if ( bag.Titles > 0 )
					{
						if ( bag.UndeadEyes > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Eyes of the Dead"); }
						if ( bag.NecroUnlock > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Tomb Raiding"); }
						if ( bag.NecroPoison > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Disease"); }
						if ( bag.Phantasm > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Phantasm"); }
						if ( bag.RetchedAir > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Retched Air"); }
						if ( bag.ManaLeech > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Lich Leech"); }
						if ( bag.WallOfSpikes > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Wall of Spikes"); }
						if ( bag.NecroCurePoison > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Disease Curing"); }
						if ( bag.BloodPact > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Blood Pact"); }
						if ( bag.SpectreShadow > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Spectre Shadow"); }
						if ( bag.GhostPhase > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Ghost Phase"); }
						if ( bag.HellsGate > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Demonic Fire"); }
						if ( bag.GhostlyImages > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Ghostly Images"); }
						if ( bag.HellsBrand > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Hellish Brand"); }
						if ( bag.GraveyardGateway > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Black Gate"); }
						if ( bag.VampireGift > 0 ){ txt = txt + 50; AddLabel(70, txt, 2433, @"Vampire Blood"); }
					}
				}
				else
				{
					int val = 27;

					AddImage(32, 0, 11471);
					if ( bag.UndeadEyes > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC4, 0x2CC4, 1, GumpButtonType.Reply, 0); }
					if ( bag.NecroUnlock > 0 ){ val = val + 50; AddButton(val, 0, 0x2CCC, 0x2CCC, 2, GumpButtonType.Reply, 0); }
					if ( bag.NecroPoison > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC2, 0x2CC2, 3, GumpButtonType.Reply, 0); }
					if ( bag.Phantasm > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC9, 0x2CC9, 4, GumpButtonType.Reply, 0); }
					if ( bag.RetchedAir > 0 ){ val = val + 50; AddButton(val, 0, 0x2CCA, 0x2CCA, 5, GumpButtonType.Reply, 0); }
					if ( bag.ManaLeech > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC8, 0x2CC8, 6, GumpButtonType.Reply, 0); }
					if ( bag.WallOfSpikes > 0 ){ val = val + 50; AddButton(val, 0, 0x2CCE, 0x2CCE, 7, GumpButtonType.Reply, 0); }
					if ( bag.NecroCurePoison > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC3, 0x2CC3, 8, GumpButtonType.Reply, 0); }
					if ( bag.BloodPact > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC0, 0x2CC0, 9, GumpButtonType.Reply, 0); }
					if ( bag.SpectreShadow > 0 ){ val = val + 50; AddButton(val, 0, 0x2CCB, 0x2CCB, 10, GumpButtonType.Reply, 0); }
					if ( bag.GhostPhase > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC5, 0x2CC5, 11, GumpButtonType.Reply, 0); }
					if ( bag.HellsGate > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC1, 0x2CC1, 12, GumpButtonType.Reply, 0); }
					if ( bag.GhostlyImages > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC6, 0x2CC6, 13, GumpButtonType.Reply, 0); }
					if ( bag.HellsBrand > 0 ){ val = val + 50; AddButton(val, 0, 0x2CC7, 0x2CC7, 14, GumpButtonType.Reply, 0); }
					if ( bag.GraveyardGateway > 0 ){ val = val + 50; AddButton(val, 0, 0x2CBF, 0x2CBF, 15, GumpButtonType.Reply, 0); }
					if ( bag.VampireGift > 0 ){ val = val + 50; AddButton(val, 0, 0x2CCD, 0x2CCD, 16, GumpButtonType.Reply, 0); }
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile;
				if ( m_Pouch.IsChildOf( from.Backpack ) )
				{
					castSpell( info.ButtonID, from );
					from.CloseGump( typeof( WitchBar ) );
					bool vertical = false; if ( m_Pouch.Bar == 1 ){ vertical = true; }
					from.SendGump( new WitchBar( from, m_Pouch, vertical ) );
				}
			}
		}

		public static void castSpell( int potion, Mobile from )
		{
			bool warn = true;

			if ( potion == 1 && from.Backpack.FindItemByType( typeof ( UndeadEyesScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( UndeadEyesScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 2 && from.Backpack.FindItemByType( typeof ( NecroUnlockScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( NecroUnlockScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 3 && from.Backpack.FindItemByType( typeof ( NecroPoisonScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( NecroPoisonScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 4 && from.Backpack.FindItemByType( typeof ( PhantasmScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( PhantasmScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 5 && from.Backpack.FindItemByType( typeof ( RetchedAirScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( RetchedAirScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 6 && from.Backpack.FindItemByType( typeof ( ManaLeechScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( ManaLeechScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 7 && from.Backpack.FindItemByType( typeof ( WallOfSpikesScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( WallOfSpikesScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 8 && from.Backpack.FindItemByType( typeof ( NecroCurePoisonScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( NecroCurePoisonScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 9 && from.Backpack.FindItemByType( typeof ( BloodPactScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( BloodPactScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 10 && from.Backpack.FindItemByType( typeof ( SpectreShadowScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( SpectreShadowScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 11 && from.Backpack.FindItemByType( typeof ( GhostPhaseScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GhostPhaseScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 12 && from.Backpack.FindItemByType( typeof ( HellsGateScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( HellsGateScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 13 && from.Backpack.FindItemByType( typeof ( GhostlyImagesScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GhostlyImagesScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 14 && from.Backpack.FindItemByType( typeof ( HellsBrandScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( HellsBrandScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 15 && from.Backpack.FindItemByType( typeof ( GraveyardGatewayScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( GraveyardGatewayScroll ) ) ).OnDoubleClick(from); warn = false; }
			else if ( potion == 16 && from.Backpack.FindItemByType( typeof ( VampireGiftScroll ) ) != null ){
				( from.Backpack.FindItemByType( typeof ( VampireGiftScroll ) ) ).OnDoubleClick(from); warn = false; }

			if ( warn ){ warnMe( from ); }
		}

		public static void warnMe( Mobile from )
		{
			string text = "You don't have that brewed!";

			from.SendMessage( text );
			from.LocalOverheadMessage(MessageType.Emote, 1150, true, text);
		}

		public override bool OnDragLift( Mobile from )
		{
			from.SendMessage( "Single click this bag to organize it." );
			return base.OnDragLift( from );
		}

		public WitchPouch( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( Bar );
			writer.Write( Titles );
			writer.Write( UndeadEyes );
			writer.Write( NecroUnlock );
			writer.Write( NecroPoison );
			writer.Write( Phantasm );
			writer.Write( RetchedAir );
			writer.Write( ManaLeech );
			writer.Write( WallOfSpikes );
			writer.Write( NecroCurePoison );
			writer.Write( BloodPact );
			writer.Write( SpectreShadow );
			writer.Write( GhostPhase );
			writer.Write( HellsGate );
			writer.Write( GhostlyImages );
			writer.Write( HellsBrand );
			writer.Write( GraveyardGateway );
			writer.Write( VampireGift );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Bar = reader.ReadInt();
			Titles = reader.ReadInt();
			UndeadEyes = reader.ReadInt();
			NecroUnlock = reader.ReadInt();
			NecroPoison = reader.ReadInt();
			Phantasm = reader.ReadInt();
			RetchedAir = reader.ReadInt();
			ManaLeech = reader.ReadInt();
			WallOfSpikes = reader.ReadInt();
			NecroCurePoison = reader.ReadInt();
			BloodPact = reader.ReadInt();
			SpectreShadow = reader.ReadInt();
			GhostPhase = reader.ReadInt();
			HellsGate = reader.ReadInt();
			GhostlyImages = reader.ReadInt();
			HellsBrand = reader.ReadInt();
			GraveyardGateway = reader.ReadInt();
			VampireGift = reader.ReadInt();
			Weight = 1.0;
			MaxItems = 50;
		}

		public static bool isWitchery( Item item )
		{
			if (
				item is BookWitchBrewing || 
				item is WitchCauldron || 
				item is Jar || 
				item is BatWing || 
				item is DaemonBlood || 
				item is PigIron || 
				item is NoxCrystal || 
				item is GraveDust || 
				item is BlackPearl || 
				item is Bloodmoss || 
				item is Brimstone || 
				item is EyeOfToad || 
				item is GargoyleEar || 
				item is BeetleShell || 
				item is MoonCrystal || 
				item is PixieSkull || 
				item is RedLotus || 
				item is SilverWidow || 
				item is SwampBerries || 
				item is BitterRoot || 
				item is BlackSand || 
				item is BloodRose || 
				item is DriedToad || 
				item is Maggot || 
				item is MummyWrap || 
				item is VioletFungus || 
				item is WerewolfClaw || 
				item is Wolfsbane || 
				item is UndeadEyesScroll || 
				item is NecroUnlockScroll || 
				item is NecroPoisonScroll || 
				item is PhantasmScroll || 
				item is RetchedAirScroll || 
				item is ManaLeechScroll || 
				item is WallOfSpikesScroll || 
				item is NecroCurePoisonScroll || 
				item is BloodPactScroll || 
				item is SpectreShadowScroll || 
				item is GhostPhaseScroll || 
				item is HellsGateScroll || 
				item is GhostlyImagesScroll || 
				item is HellsBrandScroll || 
				item is GraveyardGatewayScroll || 
				item is VampireGiftScroll 
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
			private WitchPouch witchBag; 
			private Mobile m_From; 

			public BagWindow( Mobile from, WitchPouch bag ) : base( 6172, 1 ) 
			{ 
				m_From = from; 
				witchBag = bag; 
			} 

			public override void OnClick() 
			{          
				if( witchBag.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.CloseGump( typeof( WitchBag ) );
					m_From.SendGump( new WitchBag( m_From, witchBag ) );
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

		public int UndeadEyes;
		[CommandProperty(AccessLevel.Owner)]
		public int m_UndeadEyes { get { return UndeadEyes; } set { UndeadEyes = value; InvalidateProperties(); } }

		public int NecroUnlock;
		[CommandProperty(AccessLevel.Owner)]
		public int m_NecroUnlock { get { return NecroUnlock; } set { NecroUnlock = value; InvalidateProperties(); } }

		public int NecroPoison;
		[CommandProperty(AccessLevel.Owner)]
		public int m_NecroPoison { get { return NecroPoison; } set { NecroPoison = value; InvalidateProperties(); } }

		public int Phantasm;
		[CommandProperty(AccessLevel.Owner)]
		public int m_Phantasm { get { return Phantasm; } set { Phantasm = value; InvalidateProperties(); } }

		public int RetchedAir;
		[CommandProperty(AccessLevel.Owner)]
		public int m_RetchedAir { get { return RetchedAir; } set { RetchedAir = value; InvalidateProperties(); } }

		public int ManaLeech;
		[CommandProperty(AccessLevel.Owner)]
		public int m_ManaLeech { get { return ManaLeech; } set { ManaLeech = value; InvalidateProperties(); } }

		public int WallOfSpikes;
		[CommandProperty(AccessLevel.Owner)]
		public int m_WallOfSpikes { get { return WallOfSpikes; } set { WallOfSpikes = value; InvalidateProperties(); } }

		public int NecroCurePoison;
		[CommandProperty(AccessLevel.Owner)]
		public int m_NecroCurePoison { get { return NecroCurePoison; } set { NecroCurePoison = value; InvalidateProperties(); } }

		public int BloodPact;
		[CommandProperty(AccessLevel.Owner)]
		public int m_BloodPact { get { return BloodPact; } set { BloodPact = value; InvalidateProperties(); } }

		public int SpectreShadow;
		[CommandProperty(AccessLevel.Owner)]
		public int m_SpectreShadow { get { return SpectreShadow; } set { SpectreShadow = value; InvalidateProperties(); } }

		public int GhostPhase;
		[CommandProperty(AccessLevel.Owner)]
		public int m_GhostPhase { get { return GhostPhase; } set { GhostPhase = value; InvalidateProperties(); } }

		public int HellsGate;
		[CommandProperty(AccessLevel.Owner)]
		public int m_HellsGate { get { return HellsGate; } set { HellsGate = value; InvalidateProperties(); } }

		public int GhostlyImages;
		[CommandProperty(AccessLevel.Owner)]
		public int m_GhostlyImages { get { return GhostlyImages; } set { GhostlyImages = value; InvalidateProperties(); } }

		public int HellsBrand;
		[CommandProperty(AccessLevel.Owner)]
		public int m_HellsBrand { get { return HellsBrand; } set { HellsBrand = value; InvalidateProperties(); } }

		public int GraveyardGateway;
		[CommandProperty(AccessLevel.Owner)]
		public int m_GraveyardGateway { get { return GraveyardGateway; } set { GraveyardGateway = value; InvalidateProperties(); } }

		public int VampireGift;
		[CommandProperty(AccessLevel.Owner)]
		public int m_VampireGift { get { return VampireGift; } set { VampireGift = value; InvalidateProperties(); } }
	}
}