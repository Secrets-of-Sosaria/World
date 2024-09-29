using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Menus;
using Server.Menus.Questions;
using Server.Accounting;
using Server.Multis;
using Server.Mobiles;
using Server.Regions;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Misc;
using Server.Items;
using System.Globalization;

namespace Server.Gumps 
{
    public class RegBar : Gump
    {
		public int m_Origin;

		public static void Initialize()
		{
            CommandSystem.Register( "regbar", AccessLevel.Player, new CommandEventHandler( ToolBar_OnCommand ) );
			CommandSystem.Register( "regclose", AccessLevel.Player, new CommandEventHandler( CReagent_OnCommand ) );
		}

		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}

		[Usage( "regbar" )]
		[Description( "Opens the Reagent Bar." )]
		public static void ToolBar_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			from.CloseGump( typeof( RegBar ) );
			from.SendGump( new RegBar( from ) );
        }

		[Usage( "regclose" )]
		[Description( "Closes the Reagent Bar." )]
		public static void CReagent_OnCommand(CommandEventArgs e )
		{
			Mobile pm = e.Mobile;
			pm.CloseGump( typeof( RegBar ) );
		}

		public RegBar ( Mobile from ) : base ( 85, 85 )
		{
			int set1 = 0; 
			//int set2 = 0; 
			int set3 = 0; 
			int set4 = 0; 
			int set5 = 0; 
			int set6 = 0; 
			int set7 = 0; 
			int set8 = 0; 
			int set9 = 0; 
			int set10 = 0; 
			int set11 = 0; 
			int set12 = 0; 
			int set13 = 0; 
			int set14 = 0; 
			int set15 = 0; 
			int set16 = 0; 
			int set17 = 0; 
			int set18 = 0; 
			int set19 = 0; 
			int set20 = 0; 
			int set21 = 0; 
			int set22 = 0; 
			int set23 = 0; 
			int set24 = 0; 
			int set25 = 0; 
			int set26 = 0; 
			int set27 = 0; 
			int set28 = 0; 
			int set29 = 0; 
			int set30 = 0; 
			int set31 = 0; 
			int set32 = 0; 
			int set33 = 0; 
			int set34 = 0; 
			int set35 = 0; 
			int set36 = 0; 

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddImage(0, 0, 10340); // GRAB ICON

			string keys = PlayerSettings.ValReagentConfig( from );;

			if ( keys.Length > 0 )
			{
				string[] configures = keys.Split('#');
				int nEntry = 1;

				foreach (string key in configures)
				{
					if ( nEntry == 1 && key == "1" ){ set1 = 1; }
					//else if ( nEntry == 2 && key == "1" ){ set2 = 1; }
					else if ( nEntry == 3 && key == "1" ){ set3 = 1; }
					else if ( nEntry == 4 && key == "1" ){ set4 = 1; }
					else if ( nEntry == 5 && key == "1" ){ set5 = 1; }
					else if ( nEntry == 6 && key == "1" ){ set6 = 1; }
					else if ( nEntry == 7 && key == "1" ){ set7 = 1; }
					else if ( nEntry == 8 && key == "1" ){ set8 = 1; }
					else if ( nEntry == 9 && key == "1" ){ set9 = 1; }
					else if ( nEntry == 10 && key == "1" ){ set10 = 1; }
					else if ( nEntry == 11 && key == "1" ){ set11 = 1; }
					else if ( nEntry == 12 && key == "1" ){ set12 = 1; }
					else if ( nEntry == 13 && key == "1" ){ set13 = 1; }
					else if ( nEntry == 14 && key == "1" ){ set14 = 1; }
					else if ( nEntry == 15 && key == "1" ){ set15 = 1; }
					else if ( nEntry == 16 && key == "1" ){ set16 = 1; }
					else if ( nEntry == 17 && key == "1" ){ set17 = 1; }
					else if ( nEntry == 18 && key == "1" ){ set18 = 1; }
					else if ( nEntry == 19 && key == "1" ){ set19 = 1; }
					else if ( nEntry == 20 && key == "1" ){ set20 = 1; }
					else if ( nEntry == 21 && key == "1" ){ set21 = 1; }
					else if ( nEntry == 22 && key == "1" ){ set22 = 1; }
					else if ( nEntry == 23 && key == "1" ){ set23 = 1; }
					else if ( nEntry == 24 && key == "1" ){ set24 = 1; }
					else if ( nEntry == 25 && key == "1" ){ set25 = 1; }
					else if ( nEntry == 26 && key == "1" ){ set26 = 1; }
					else if ( nEntry == 27 && key == "1" ){ set27 = 1; }
					else if ( nEntry == 28 && key == "1" ){ set28 = 1; }
					else if ( nEntry == 29 && key == "1" ){ set29 = 1; }
					else if ( nEntry == 30 && key == "1" ){ set30 = 1; }
					else if ( nEntry == 31 && key == "1" ){ set31 = 1; }
					else if ( nEntry == 32 && key == "1" ){ set32 = 1; }
					else if ( nEntry == 33 && key == "1" ){ set33 = 1; }
					else if ( nEntry == 34 && key == "1" ){ set34 = 1; }
					else if ( nEntry == 35 && key == "1" ){ set35 = 1; }
					else if ( nEntry == 36 && key == "1" ){ set36 = 1; }

					nEntry++;
				}
			}

			int i = 2;

			int v = 0;
			int w = 35;

			if ( set1 == 1 )
			{
				v = 35;
				w = 0;
			}

			int x = 0;
			int y = 0;

			int q = 0;
			int a = 0;

			x=x+v;
			y=y+w;

			AddButton(x, y, 10349, 10349, 666, GumpButtonType.Reply, 0); // HELP ICON

			bool showICON = false;

			while ( i < 36 )
			{
				i++;
				showICON = false;

				if ( i == 3 && set3 == 1 ){ showICON = true; }
				else if ( i == 4 && set4 == 1 ){ showICON = true; }
				else if ( i == 5 && set5 == 1 ){ showICON = true; }
				else if ( i == 6 && set6 == 1 ){ showICON = true; }
				else if ( i == 7 && set7 == 1 ){ showICON = true; }
				else if ( i == 8 && set8 == 1 ){ showICON = true; }
				else if ( i == 9 && set9 == 1 ){ showICON = true; }
				else if ( i == 10 && set10 == 1 ){ showICON = true; }
				else if ( i == 11 && set11 == 1 ){ showICON = true; }
				else if ( i == 12 && set12 == 1 ){ showICON = true; }
				else if ( i == 13 && set13 == 1 ){ showICON = true; }
				else if ( i == 14 && set14 == 1 ){ showICON = true; }
				else if ( i == 15 && set15 == 1 ){ showICON = true; }
				else if ( i == 16 && set16 == 1 ){ showICON = true; }
				else if ( i == 17 && set17 == 1 ){ showICON = true; }
				else if ( i == 18 && set18 == 1 ){ showICON = true; }
				else if ( i == 19 && set19 == 1 ){ showICON = true; }
				else if ( i == 20 && set20 == 1 ){ showICON = true; }
				else if ( i == 21 && set21 == 1 ){ showICON = true; }
				else if ( i == 22 && set22 == 1 ){ showICON = true; }
				else if ( i == 23 && set23 == 1 ){ showICON = true; }
				else if ( i == 24 && set24 == 1 ){ showICON = true; }
				else if ( i == 25 && set25 == 1 ){ showICON = true; }
				else if ( i == 26 && set26 == 1 ){ showICON = true; }
				else if ( i == 27 && set27 == 1 ){ showICON = true; }
				else if ( i == 28 && set28 == 1 ){ showICON = true; }
				else if ( i == 29 && set29 == 1 ){ showICON = true; }
				else if ( i == 30 && set30 == 1 ){ showICON = true; }
				else if ( i == 31 && set31 == 1 ){ showICON = true; }
				else if ( i == 32 && set32 == 1 ){ showICON = true; }
				else if ( i == 33 && set33 == 1 ){ showICON = true; }
				else if ( i == 34 && set34 == 1 ){ showICON = true; }
				else if ( i == 35 && set35 == 1 ){ showICON = true; }
				else if ( i == 36 && set36 == 1 ){ showICON = true; }

				if ( showICON )
				{
					x=x+v;
					y=y+w;

					if ( v == 0 )
					{
						AddHtml( x+35, y+7, 50, 20, @"<BODY><BASEFONT Color=#34ee39>" + RegConfig.rowInfoCat( i, 2, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					else 
					{
						if ( q == 0 ){ q = 1; } else { q = 0; }

						if ( q == 1 ){ a = 35; } else { a = -20; }

						AddHtml( x+4, a, 50, 20, @"<BODY><BASEFONT Color=#34ee39>" + RegConfig.rowInfoCat( i, 2, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					}

					AddImage( x, y, Int32.Parse( RegConfig.rowInfoCat( i, 1, from ) ) );
				}
			}
		}

		public static void RefreshRegBar( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				if( from.HasGump( typeof(RegBar)) )
				{
					from.CloseGump( typeof(RegBar) );
					from.SendGump( new RegBar( from ) );
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

			from.CloseGump( typeof( RegBar ) );

			if ( info.ButtonID > 0 ){ from.SendGump( new RegBar( from ) ); from.SendSound( 0x4A ); }

			if ( info.ButtonID == 666 )
			{
				from.CloseGump( typeof( RegConfig ) );
				from.SendGump( new RegConfig( from ) );
			}
		}
    }

    public class RegConfig : Gump
    {
		public RegConfig( Mobile from ) : base( 50, 50 )
		{
			int btn1 = 3609;
			int btn2 = 3609;
			int btn3 = 3609;
			int btn4 = 3609;
			int btn5 = 3609;
			int btn6 = 3609;
			int btn7 = 3609;
			int btn8 = 3609;
			int btn9 = 3609;
			int btn10 = 3609;
			int btn11 = 3609;
			int btn12 = 3609;
			int btn13 = 3609;
			int btn14 = 3609;
			int btn15 = 3609;
			int btn16 = 3609;
			int btn17 = 3609;
			int btn18 = 3609;
			int btn19 = 3609;
			int btn20 = 3609;
			int btn21 = 3609;
			int btn22 = 3609;
			int btn23 = 3609;
			int btn24 = 3609;
			int btn25 = 3609;
			int btn26 = 3609;
			int btn27 = 3609;
			int btn28 = 3609;
			int btn29 = 3609;
			int btn30 = 3609;
			int btn31 = 3609;
			int btn32 = 3609;
			int btn33 = 3609;
			int btn34 = 3609;
			int btn35 = 3609;
			int btn36 = 3609;

			PlayerMobile pm = (PlayerMobile)from;

			string keys = PlayerSettings.ValReagentConfig( from );;

			if ( keys.Length > 0 )
			{
				string[] configures = keys.Split('#');
				int nEntry = 1;
				foreach (string key in configures)
				{
					if ( nEntry == 1 && key == "1" ){ btn1 = 4017; }
					else if ( nEntry == 2 && key == "1" ){ btn2 = 4017; }
					else if ( nEntry == 3 && key == "1" ){ btn3 = 4017; }
					else if ( nEntry == 4 && key == "1" ){ btn4 = 4017; }
					else if ( nEntry == 5 && key == "1" ){ btn5 = 4017; }
					else if ( nEntry == 6 && key == "1" ){ btn6 = 4017; }
					else if ( nEntry == 7 && key == "1" ){ btn7 = 4017; }
					else if ( nEntry == 8 && key == "1" ){ btn8 = 4017; }
					else if ( nEntry == 9 && key == "1" ){ btn9 = 4017; }
					else if ( nEntry == 10 && key == "1" ){ btn10 = 4017; }
					else if ( nEntry == 11 && key == "1" ){ btn11 = 4017; }
					else if ( nEntry == 12 && key == "1" ){ btn12 = 4017; }
					else if ( nEntry == 13 && key == "1" ){ btn13 = 4017; }
					else if ( nEntry == 14 && key == "1" ){ btn14 = 4017; }
					else if ( nEntry == 15 && key == "1" ){ btn15 = 4017; }
					else if ( nEntry == 16 && key == "1" ){ btn16 = 4017; }
					else if ( nEntry == 17 && key == "1" ){ btn17 = 4017; }
					else if ( nEntry == 18 && key == "1" ){ btn18 = 4017; }
					else if ( nEntry == 19 && key == "1" ){ btn19 = 4017; }
					else if ( nEntry == 20 && key == "1" ){ btn20 = 4017; }
					else if ( nEntry == 21 && key == "1" ){ btn21 = 4017; }
					else if ( nEntry == 22 && key == "1" ){ btn22 = 4017; }
					else if ( nEntry == 23 && key == "1" ){ btn23 = 4017; }
					else if ( nEntry == 24 && key == "1" ){ btn24 = 4017; }
					else if ( nEntry == 25 && key == "1" ){ btn25 = 4017; }
					else if ( nEntry == 26 && key == "1" ){ btn26 = 4017; }
					else if ( nEntry == 27 && key == "1" ){ btn27 = 4017; }
					else if ( nEntry == 28 && key == "1" ){ btn28 = 4017; }
					else if ( nEntry == 29 && key == "1" ){ btn29 = 4017; }
					else if ( nEntry == 30 && key == "1" ){ btn30 = 4017; }
					else if ( nEntry == 31 && key == "1" ){ btn31 = 4017; }
					else if ( nEntry == 32 && key == "1" ){ btn32 = 4017; }
					else if ( nEntry == 33 && key == "1" ){ btn33 = 4017; }
					else if ( nEntry == 34 && key == "1" ){ btn34 = 4017; }
					else if ( nEntry == 35 && key == "1" ){ btn35 = 4017; }
					else if ( nEntry == 36 && key == "1" ){ btn36 = 4017; }

					nEntry++;
				}
			}

			string color = "#ddbc4b";
			from.SendSound( 0x4A ); 

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 9548, PlayerSettings.GetGumpHue( from ));
			AddHtml( 12, 12, 300, 20, @"<BODY><BASEFONT Color=" + color + ">CONFIGURE REAGENT BAR</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(967, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 14, 55, 981, 94, @"<BODY><BASEFONT Color=" + color + ">This toolbar provides a quick and convenient way to keep an eye on your reagents. You must choose what icons will appear on your quick bar, and you can select those here. The bar will display reagents by category of magery, necromancy, research/misc, and witch brewing.</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(277, 151, btn1, btn1, 1, GumpButtonType.Reply, 0);
			AddHtml( 316, 151, 223, 20, @"<BODY><BASEFONT Color=" + color + ">Horizontal Bar</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(580, 151, btn2, btn2, 2, GumpButtonType.Reply, 0);
			AddHtml( 619, 151, 223, 20, @"<BODY><BASEFONT Color=" + color + ">Open At Login</BASEFONT></BODY>", (bool)false, (bool)false);

			int icons = 2;

			int p = 39;

			int x = 77;
			int y = 158;

			int button = btn3;

			while ( icons < 36 )
			{
				icons++;

				if ( icons == 16 || icons == 29 ){ x = x+332; y = 158; }
				y = y + p;

				if ( icons == 3 ){ button = btn3; }
				else if ( icons == 4 ){ button = btn4; }
				else if ( icons == 5 ){ button = btn5; }
				else if ( icons == 6 ){ button = btn6; }
				else if ( icons == 7 ){ button = btn7; }
				else if ( icons == 8 ){ button = btn8; }
				else if ( icons == 9 ){ button = btn9; }
				else if ( icons == 10 ){ button = btn10; }
				else if ( icons == 11 ){ button = btn11; }
				else if ( icons == 12 ){ button = btn12; }
				else if ( icons == 13 ){ button = btn13; }
				else if ( icons == 14 ){ button = btn14; }
				else if ( icons == 15 ){ button = btn15; }
				else if ( icons == 16 ){ button = btn16; }
				else if ( icons == 17 ){ button = btn17; }
				else if ( icons == 18 ){ button = btn18; }
				else if ( icons == 19 ){ button = btn19; }
				else if ( icons == 20 ){ button = btn20; }
				else if ( icons == 21 ){ button = btn21; }
				else if ( icons == 22 ){ button = btn22; }
				else if ( icons == 23 ){ button = btn23; }
				else if ( icons == 24 ){ button = btn24; }
				else if ( icons == 25 ){ button = btn25; }
				else if ( icons == 26 ){ button = btn26; }
				else if ( icons == 27 ){ button = btn27; }
				else if ( icons == 28 ){ button = btn28; }
				else if ( icons == 29 ){ button = btn29; }
				else if ( icons == 30 ){ button = btn30; }
				else if ( icons == 31 ){ button = btn31; }
				else if ( icons == 32 ){ button = btn32; }
				else if ( icons == 33 ){ button = btn33; }
				else if ( icons == 34 ){ button = btn34; }
				else if ( icons == 35 ){ button = btn35; }
				else if ( icons == 36 ){ button = btn36; }

				AddImage(x+36, y, Int32.Parse( rowInfoCat( icons, 1, from ) ) );
				AddButton(x, y+6, button, button, icons, GumpButtonType.Reply, 0);
				AddHtml( x+74, y+5, 223, 20, @"<BODY><BASEFONT Color=" + color + ">" + rowInfoCat( icons, 0, from ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

			if ( info.ButtonID > 0 )
			{
				PlayerSettings.SetReagentConfig( from, info.ButtonID );
				from.SendGump( new RegConfig( from ) );
				from.CloseGump( typeof(RegBar) );
				from.SendGump( new RegBar( from ) );
			}
			else
				from.SendSound( 0x4A );
		}

		public static string rowInfoCat( int set, int cat, Mobile m )
		{
			string icon = "0";
			string name = "";
			int count = 0;

			set = set - 2;

			switch ( set )
			{
				case 1: icon = "10937"; name = "Black Pearl"; count = m.Backpack.GetAmount( typeof( BlackPearl ), true ); break;
				case 2: icon = "10938"; name = "Bloodmoss"; count = m.Backpack.GetAmount( typeof( Bloodmoss ), true ); break;
				case 3: icon = "10939"; name = "Garlic"; count = m.Backpack.GetAmount( typeof( Garlic ), true ); break;
				case 4: icon = "10940"; name = "Ginseng"; count = m.Backpack.GetAmount( typeof( Ginseng ), true ); break;
				case 5: icon = "10941"; name = "Mandrake Root"; count = m.Backpack.GetAmount( typeof( MandrakeRoot ), true ); break;
				case 6: icon = "10942"; name = "Nightshade"; count = m.Backpack.GetAmount( typeof( Nightshade ), true ); break;
				case 7: icon = "10943"; name = "Spider Silk"; count = m.Backpack.GetAmount( typeof( SpidersSilk ), true ); break;
				case 8: icon = "10944"; name = "Sulfurous Ash"; count = m.Backpack.GetAmount( typeof( SulfurousAsh ), true ); break;
				case 9: icon = "10945"; name = "Bat Wing"; count = m.Backpack.GetAmount( typeof( BatWing ), true ); break;
				case 10: icon = "10946"; name = "Daemon Blood"; count = m.Backpack.GetAmount( typeof( DaemonBlood ), true ); break;
				case 11: icon = "10947"; name = "Grave Dust"; count = m.Backpack.GetAmount( typeof( GraveDust ), true ); break;
				case 12: icon = "10948"; name = "Nox Crystal"; count = m.Backpack.GetAmount( typeof( NoxCrystal ), true ); break;
				case 13: icon = "10949"; name = "Pig Iron"; count = m.Backpack.GetAmount( typeof( PigIron ), true ); break;
				case 14: icon = "10950"; name = "BeetleShell"; count = m.Backpack.GetAmount( typeof( BeetleShell ), true ); break;
				case 15: icon = "10951"; name = "Brimstone"; count = m.Backpack.GetAmount( typeof( Brimstone ), true ); break;
				case 16: icon = "10952"; name = "Butterfly Wings"; count = m.Backpack.GetAmount( typeof( ButterflyWings ), true ); break;
				case 17: icon = "10953"; name = "Eye of Toad"; count = m.Backpack.GetAmount( typeof( EyeOfToad ), true ); break;
				case 18: icon = "10954"; name = "Fairy Egg"; count = m.Backpack.GetAmount( typeof( FairyEgg ), true ); break;
				case 19: icon = "10955"; name = "Gargoyle Ear"; count = m.Backpack.GetAmount( typeof( GargoyleEar ), true ); break;
				case 20: icon = "10956"; name = "Moon Crystal"; count = m.Backpack.GetAmount( typeof( MoonCrystal ), true ); break;
				case 21: icon = "10957"; name = "Pixie Skull"; count = m.Backpack.GetAmount( typeof( PixieSkull ), true ); break;
				case 22: icon = "10958"; name = "Red Lotus"; count = m.Backpack.GetAmount( typeof( RedLotus ), true ); break;
				case 23: icon = "10959"; name = "Sea Salt"; count = m.Backpack.GetAmount( typeof( SeaSalt ), true ); break;
				case 24: icon = "10960"; name = "Silver Widow"; count = m.Backpack.GetAmount( typeof( SilverWidow ), true ); break;
				case 25: icon = "10961"; name = "Swamp Berries"; count = m.Backpack.GetAmount( typeof( SwampBerries ), true ); break;
				case 26: icon = "10962"; name = "Bitter Root"; count = m.Backpack.GetAmount( typeof( BitterRoot ), true ); break;
				case 27: icon = "10963"; name = "Black Sand"; count = m.Backpack.GetAmount( typeof( BlackSand ), true ); break;
				case 28: icon = "10964"; name = "Blood Rose"; count = m.Backpack.GetAmount( typeof( BloodRose ), true ); break;
				case 29: icon = "10965"; name = "Dried Toad"; count = m.Backpack.GetAmount( typeof( DriedToad ), true ); break;
				case 30: icon = "10966"; name = "Maggot"; count = m.Backpack.GetAmount( typeof( Maggot ), true ); break;
				case 31: icon = "10967"; name = "Mummy Wrap"; count = m.Backpack.GetAmount( typeof( MummyWrap ), true ); break;
				case 32: icon = "10968"; name = "Violet Fungus"; count = m.Backpack.GetAmount( typeof( VioletFungus ), true ); break;
				case 33: icon = "10969"; name = "Werewolf Claw"; count = m.Backpack.GetAmount( typeof( WerewolfClaw ), true ); break;
				case 34: icon = "10970"; name = "Wolfsbane"; count = m.Backpack.GetAmount( typeof( Wolfsbane ), true ); break;
			}

			if ( cat == 1 )
				return icon;
			else if ( cat == 2 )
				return "" + count + "";

			return name;
		}
	}
}