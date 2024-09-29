using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Regions;
using System.Collections;
using Server.Accounting;

namespace Server
{
    public class PowerGump : Gump
    {
        private Mobile m_Merchant;
		private int m_Price;

        public PowerGump( string msg, Mobile from, Mobile merchant ): base(50, 50)
        {
			string color = "#81aabf";
			int display = 60;
			int line = 0;

            m_Merchant = merchant;

			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			string skill = "105";
			string cat = "WONDEROUS";
			m_Price = 10000;

			if ( merchant is WonderousDealer ){ cat = "WONDEROUS"; m_Price = 10000; skill = "105"; }
			else if ( merchant is ExaltedDealer ){ cat = "EXALTED"; m_Price = 20000; skill = "110"; }
			else if ( merchant is MythicalDealer ){ cat = "MYTHICAL"; m_Price = 40000; skill = "115"; }
			else if ( merchant is LegendaryDealer ){ cat = "LEGENDARY"; m_Price = 80000; skill = "120"; }
			else if ( merchant is PowerDealer ){ cat = "POWER"; m_Price = 160000; skill = "125"; }

			AddImage(0, 0, 9592, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddButton(962, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
			AddHtml( 12, 12, 727, 20, @"<BODY><BASEFONT Color=" + color + ">CASTLE OF KNOWLEDGE</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 46, 976, 20, @"<BODY><BASEFONT Color=" + color + ">CHOOSE A " + cat + " (" + skill + " SKILL) SCROLL TO PURCHASE FOR " + m_Price + " GOLD</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 12, 80, 976, 20, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

			while ( display > 0 )
			{
				display--;
				line++;

				GetLine( line );
			}
		}

		public void GetLine( int val )
		{
			string color = "#81aabf";
			string txt = "";

			if ( val == 1 ){ txt = "Alchemy"; }
			else if ( val == 2 ){ txt = "Anatomy"; }
			else if ( val == 3 ){ txt = "Arms Lore"; }
			else if ( val == 4 ){ txt = "Blacksmithing"; }
			else if ( val == 5 ){ txt = "Bludgeoning"; }
			else if ( val == 6 ){ txt = "Bowcrafting"; }
			else if ( val == 7 ){ txt = "Bushido"; }
			else if ( val == 8 ){ txt = "Carpentry"; }
			else if ( val == 9 ){ txt = "Cartography"; }
			else if ( val == 10 ){ txt = "Cooking"; }
			else if ( val == 11 ){ txt = "Discordance"; }
			else if ( val == 12 ){ txt = "Druidism"; }
			else if ( val == 13 ){ txt = "Elementalism"; }
			else if ( val == 14 ){ txt = "Fencing"; }
			else if ( val == 15 ){ txt = "Fist Fighting"; }
			else if ( val == 16 ){ txt = "Focus"; }
			else if ( val == 17 ){ txt = "Healing"; }
			else if ( val == 18 ){ txt = "Herding"; }
			else if ( val == 19 ){ txt = "Hiding"; }
			else if ( val == 20 ){ txt = "Inscription"; }
			else if ( val == 21 ){ txt = "Knightship"; }
			else if ( val == 22 ){ txt = "Lockpicking"; }
			else if ( val == 23 ){ txt = "Lumberjacking"; }
			else if ( val == 24 ){ txt = "Magery"; }
			else if ( val == 25 ){ txt = "Magic Resistance"; }
			else if ( val == 26 ){ txt = "Marksmanship"; }
			else if ( val == 27 ){ txt = "Meditation"; }
			else if ( val == 28 ){ txt = "Mining"; }
			else if ( val == 29 ){ txt = "Musicianship"; }
			else if ( val == 30 ){ txt = "Necromancy"; }
			else if ( val == 31 ){ txt = "Ninjitsu"; }
			else if ( val == 32 ){ txt = "Parrying"; }
			else if ( val == 33 ){ txt = "Peacemaking"; }
			else if ( val == 34 ){ txt = "Poisoning"; }
			else if ( val == 35 ){ txt = "Provocation"; }
			else if ( val == 36 ){ txt = "Psychology"; }
			else if ( val == 37 ){ txt = "Remove Trap"; }
			else if ( val == 38 ){ txt = "Seafaring"; }
			else if ( val == 39 ){ txt = "Searching"; }
			else if ( val == 40 ){ txt = "Snooping"; }
			else if ( val == 41 ){ txt = "Spiritualism"; }
			else if ( val == 42 ){ txt = "Stealing"; }
			else if ( val == 43 ){ txt = "Stealth"; }
			else if ( val == 44 ){ txt = "Swordsmanship"; }
			else if ( val == 45 ){ txt = "Tactics"; }
			else if ( val == 46 ){ txt = "Tailoring"; }
			else if ( val == 47 ){ txt = "Taming"; }
			else if ( val == 48 ){ txt = "Tinkering"; }
			else if ( val == 49 ){ txt = "Tracking"; }
			else if ( val == 50 ){ txt = "Veterinary"; }

			if ( txt != "" )
			{
				int x; int y;

				if ( val < 18 ){ x = 31; y = 25 + (val*28); }
				else if ( val < 35 ){ x = 371; y = 25 + ((val-17)*28); }
				else { x = 706; y = 25 + ((val-34)*28); }

				AddButton(x, y+77, 4011, 4011, val, GumpButtonType.Reply, 0);
				AddHtml( x+50, y+77, 252, 20, @"<BODY><BASEFONT Color=" + color + ">" + txt + "</BASEFONT></BODY>", (bool)false, (bool)false);
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

			if ( !(from.Region).IsPartOf( "the Castle of Knowledge" ) )
			{
				// THEY LEFT THE CASTLE
			}
			else if ( info.ButtonID > 0 )
			{
				Container cont = from.FindBankNoCreate();
				if ( cont != null && cont.ConsumeTotal( typeof( Gold ), m_Price ) )
				{
					int choice = info.ButtonID;
					string msg = "Wonderous";
					if ( m_Merchant is ExaltedDealer ){ choice = choice + 50; msg = "Exalted"; }
					else if ( m_Merchant is MythicalDealer ){ choice = choice + 100; msg = "Mythical"; }
					else if ( m_Merchant is LegendaryDealer ){ choice = choice + 150; msg = "Legendary"; }
					else if ( m_Merchant is PowerDealer ){ choice = choice + 200; msg = "Power"; }

					msg = "You paid " + m_Price + " gold for the " + msg + " Scroll of " + GetTxt( info.ButtonID ) + "!";

					GiveScroll( from, choice );
					from.PlaySound( 0x32 );
					from.SendGump( new PowerGump( msg, from, m_Merchant ) );
				}
				else
				{
					m_Merchant.SayTo( from, 500191 ); //Begging thy pardon, but thy bank account lacks these funds.
				}
			}
		}

		public void GiveScroll( Mobile from, int choice )
		{
			switch ( choice )
			{
				case 1: from.AddToBackpack( new DJ_SW_Alchemy() ); break;
				case 2: from.AddToBackpack( new DJ_SW_Anatomy() ); break;
				case 3: from.AddToBackpack( new DJ_SW_ArmsLore() ); break;
				case 4: from.AddToBackpack( new DJ_SW_Blacksmith() ); break;
				case 5: from.AddToBackpack( new DJ_SW_Macing() ); break;
				case 6: from.AddToBackpack( new DJ_SW_Fletching() ); break;
				case 7: from.AddToBackpack( new DJ_SW_Bushido() ); break;
				case 8: from.AddToBackpack( new DJ_SW_Carpentry() ); break;
				case 9: from.AddToBackpack( new DJ_SW_Cartography() ); break;
				case 10: from.AddToBackpack( new DJ_SW_Cooking() ); break;
				case 11: from.AddToBackpack( new DJ_SW_Discordance() ); break;
				case 12: from.AddToBackpack( new DJ_SW_AnimalLore() ); break;
				case 13: from.AddToBackpack( new DJ_SW_Elementalism() ); break;
				case 14: from.AddToBackpack( new DJ_SW_Fencing() ); break;
				case 15: from.AddToBackpack( new DJ_SW_Wrestling() ); break;
				case 16: from.AddToBackpack( new DJ_SW_Focus() ); break;
				case 17: from.AddToBackpack( new DJ_SW_Healing() ); break;
				case 18: from.AddToBackpack( new DJ_SW_Herding() ); break;
				case 19: from.AddToBackpack( new DJ_SW_Hiding() ); break;
				case 20: from.AddToBackpack( new DJ_SW_Inscribe() ); break;
				case 21: from.AddToBackpack( new DJ_SW_Chivalry() ); break;
				case 22: from.AddToBackpack( new DJ_SW_Lockpicking() ); break;
				case 23: from.AddToBackpack( new DJ_SW_Lumberjacking() ); break;
				case 24: from.AddToBackpack( new DJ_SW_Magery() ); break;
				case 25: from.AddToBackpack( new DJ_SW_MagicResist() ); break;
				case 26: from.AddToBackpack( new DJ_SW_Archery() ); break;
				case 27: from.AddToBackpack( new DJ_SW_Meditation() ); break;
				case 28: from.AddToBackpack( new DJ_SW_Mining() ); break;
				case 29: from.AddToBackpack( new DJ_SW_Musicianship() ); break;
				case 30: from.AddToBackpack( new DJ_SW_Necromancy() ); break;
				case 31: from.AddToBackpack( new DJ_SW_Ninjitsu() ); break;
				case 32: from.AddToBackpack( new DJ_SW_Parry() ); break;
				case 33: from.AddToBackpack( new DJ_SW_Peacemaking() ); break;
				case 34: from.AddToBackpack( new DJ_SW_Poisoning() ); break;
				case 35: from.AddToBackpack( new DJ_SW_Provocation() ); break;
				case 36: from.AddToBackpack( new DJ_SW_EvalInt() ); break;
				case 37: from.AddToBackpack( new DJ_SW_RemoveTrap() ); break;
				case 38: from.AddToBackpack( new DJ_SW_Fishing() ); break;
				case 39: from.AddToBackpack( new DJ_SW_DetectHidden() ); break;
				case 40: from.AddToBackpack( new DJ_SW_Snooping() ); break;
				case 41: from.AddToBackpack( new DJ_SW_SpiritSpeak() ); break;
				case 42: from.AddToBackpack( new DJ_SW_Stealing() ); break;
				case 43: from.AddToBackpack( new DJ_SW_Stealth() ); break;
				case 44: from.AddToBackpack( new DJ_SW_Swords() ); break;
				case 45: from.AddToBackpack( new DJ_SW_Tactics() ); break;
				case 46: from.AddToBackpack( new DJ_SW_Tailoring() ); break;
				case 47: from.AddToBackpack( new DJ_SW_AnimalTaming() ); break;
				case 48: from.AddToBackpack( new DJ_SW_Tinkering() ); break;
				case 49: from.AddToBackpack( new DJ_SW_Tracking() ); break;
				case 50: from.AddToBackpack( new DJ_SW_Veterinary() ); break;
				case 51: from.AddToBackpack( new DJ_SE_Alchemy() ); break;
				case 52: from.AddToBackpack( new DJ_SE_Anatomy() ); break;
				case 53: from.AddToBackpack( new DJ_SE_ArmsLore() ); break;
				case 54: from.AddToBackpack( new DJ_SE_Blacksmith() ); break;
				case 55: from.AddToBackpack( new DJ_SE_Macing() ); break;
				case 56: from.AddToBackpack( new DJ_SE_Fletching() ); break;
				case 57: from.AddToBackpack( new DJ_SE_Bushido() ); break;
				case 58: from.AddToBackpack( new DJ_SE_Carpentry() ); break;
				case 59: from.AddToBackpack( new DJ_SE_Cartography() ); break;
				case 60: from.AddToBackpack( new DJ_SE_Cooking() ); break;
				case 61: from.AddToBackpack( new DJ_SE_Discordance() ); break;
				case 62: from.AddToBackpack( new DJ_SE_AnimalLore() ); break;
				case 63: from.AddToBackpack( new DJ_SE_Elementalism() ); break;
				case 64: from.AddToBackpack( new DJ_SE_Fencing() ); break;
				case 65: from.AddToBackpack( new DJ_SE_Wrestling() ); break;
				case 66: from.AddToBackpack( new DJ_SE_Focus() ); break;
				case 67: from.AddToBackpack( new DJ_SE_Healing() ); break;
				case 68: from.AddToBackpack( new DJ_SE_Herding() ); break;
				case 69: from.AddToBackpack( new DJ_SE_Hiding() ); break;
				case 70: from.AddToBackpack( new DJ_SE_Inscribe() ); break;
				case 71: from.AddToBackpack( new DJ_SE_Chivalry() ); break;
				case 72: from.AddToBackpack( new DJ_SE_Lockpicking() ); break;
				case 73: from.AddToBackpack( new DJ_SE_Lumberjacking() ); break;
				case 74: from.AddToBackpack( new DJ_SE_Magery() ); break;
				case 75: from.AddToBackpack( new DJ_SE_MagicResist() ); break;
				case 76: from.AddToBackpack( new DJ_SE_Archery() ); break;
				case 77: from.AddToBackpack( new DJ_SE_Meditation() ); break;
				case 78: from.AddToBackpack( new DJ_SE_Mining() ); break;
				case 79: from.AddToBackpack( new DJ_SE_Musicianship() ); break;
				case 80: from.AddToBackpack( new DJ_SE_Necromancy() ); break;
				case 81: from.AddToBackpack( new DJ_SE_Ninjitsu() ); break;
				case 82: from.AddToBackpack( new DJ_SE_Parry() ); break;
				case 83: from.AddToBackpack( new DJ_SE_Peacemaking() ); break;
				case 84: from.AddToBackpack( new DJ_SE_Poisoning() ); break;
				case 85: from.AddToBackpack( new DJ_SE_Provocation() ); break;
				case 86: from.AddToBackpack( new DJ_SE_EvalInt() ); break;
				case 87: from.AddToBackpack( new DJ_SE_RemoveTrap() ); break;
				case 88: from.AddToBackpack( new DJ_SE_Fishing() ); break;
				case 89: from.AddToBackpack( new DJ_SE_DetectHidden() ); break;
				case 90: from.AddToBackpack( new DJ_SE_Snooping() ); break;
				case 91: from.AddToBackpack( new DJ_SE_SpiritSpeak() ); break;
				case 92: from.AddToBackpack( new DJ_SE_Stealing() ); break;
				case 93: from.AddToBackpack( new DJ_SE_Stealth() ); break;
				case 94: from.AddToBackpack( new DJ_SE_Swords() ); break;
				case 95: from.AddToBackpack( new DJ_SE_Tactics() ); break;
				case 96: from.AddToBackpack( new DJ_SE_Tailoring() ); break;
				case 97: from.AddToBackpack( new DJ_SE_AnimalTaming() ); break;
				case 98: from.AddToBackpack( new DJ_SE_Tinkering() ); break;
				case 99: from.AddToBackpack( new DJ_SE_Tracking() ); break;
				case 100: from.AddToBackpack( new DJ_SE_Veterinary() ); break;
				case 101: from.AddToBackpack( new DJ_SM_Alchemy() ); break;
				case 102: from.AddToBackpack( new DJ_SM_Anatomy() ); break;
				case 103: from.AddToBackpack( new DJ_SM_ArmsLore() ); break;
				case 104: from.AddToBackpack( new DJ_SM_Blacksmith() ); break;
				case 105: from.AddToBackpack( new DJ_SM_Macing() ); break;
				case 106: from.AddToBackpack( new DJ_SM_Fletching() ); break;
				case 107: from.AddToBackpack( new DJ_SM_Bushido() ); break;
				case 108: from.AddToBackpack( new DJ_SM_Carpentry() ); break;
				case 109: from.AddToBackpack( new DJ_SM_Cartography() ); break;
				case 110: from.AddToBackpack( new DJ_SM_Cooking() ); break;
				case 111: from.AddToBackpack( new DJ_SM_Discordance() ); break;
				case 112: from.AddToBackpack( new DJ_SM_AnimalLore() ); break;
				case 113: from.AddToBackpack( new DJ_SM_Elementalism() ); break;
				case 114: from.AddToBackpack( new DJ_SM_Fencing() ); break;
				case 115: from.AddToBackpack( new DJ_SM_Wrestling() ); break;
				case 116: from.AddToBackpack( new DJ_SM_Focus() ); break;
				case 117: from.AddToBackpack( new DJ_SM_Healing() ); break;
				case 118: from.AddToBackpack( new DJ_SM_Herding() ); break;
				case 119: from.AddToBackpack( new DJ_SM_Hiding() ); break;
				case 120: from.AddToBackpack( new DJ_SM_Inscribe() ); break;
				case 121: from.AddToBackpack( new DJ_SM_Chivalry() ); break;
				case 122: from.AddToBackpack( new DJ_SM_Lockpicking() ); break;
				case 123: from.AddToBackpack( new DJ_SM_Lumberjacking() ); break;
				case 124: from.AddToBackpack( new DJ_SM_Magery() ); break;
				case 125: from.AddToBackpack( new DJ_SM_MagicResist() ); break;
				case 126: from.AddToBackpack( new DJ_SM_Archery() ); break;
				case 127: from.AddToBackpack( new DJ_SM_Meditation() ); break;
				case 128: from.AddToBackpack( new DJ_SM_Mining() ); break;
				case 129: from.AddToBackpack( new DJ_SM_Musicianship() ); break;
				case 130: from.AddToBackpack( new DJ_SM_Necromancy() ); break;
				case 131: from.AddToBackpack( new DJ_SM_Ninjitsu() ); break;
				case 132: from.AddToBackpack( new DJ_SM_Parry() ); break;
				case 133: from.AddToBackpack( new DJ_SM_Peacemaking() ); break;
				case 134: from.AddToBackpack( new DJ_SM_Poisoning() ); break;
				case 135: from.AddToBackpack( new DJ_SM_Provocation() ); break;
				case 136: from.AddToBackpack( new DJ_SM_EvalInt() ); break;
				case 137: from.AddToBackpack( new DJ_SM_RemoveTrap() ); break;
				case 138: from.AddToBackpack( new DJ_SM_Fishing() ); break;
				case 139: from.AddToBackpack( new DJ_SM_DetectHidden() ); break;
				case 140: from.AddToBackpack( new DJ_SM_Snooping() ); break;
				case 141: from.AddToBackpack( new DJ_SM_SpiritSpeak() ); break;
				case 142: from.AddToBackpack( new DJ_SM_Stealing() ); break;
				case 143: from.AddToBackpack( new DJ_SM_Stealth() ); break;
				case 144: from.AddToBackpack( new DJ_SM_Swords() ); break;
				case 145: from.AddToBackpack( new DJ_SM_Tactics() ); break;
				case 146: from.AddToBackpack( new DJ_SM_Tailoring() ); break;
				case 147: from.AddToBackpack( new DJ_SM_AnimalTaming() ); break;
				case 148: from.AddToBackpack( new DJ_SM_Tinkering() ); break;
				case 149: from.AddToBackpack( new DJ_SM_Tracking() ); break;
				case 150: from.AddToBackpack( new DJ_SM_Veterinary() ); break;
				case 151: from.AddToBackpack( new DJ_SL_Alchemy() ); break;
				case 152: from.AddToBackpack( new DJ_SL_Anatomy() ); break;
				case 153: from.AddToBackpack( new DJ_SL_ArmsLore() ); break;
				case 154: from.AddToBackpack( new DJ_SL_Blacksmith() ); break;
				case 155: from.AddToBackpack( new DJ_SL_Macing() ); break;
				case 156: from.AddToBackpack( new DJ_SL_Fletching() ); break;
				case 157: from.AddToBackpack( new DJ_SL_Bushido() ); break;
				case 158: from.AddToBackpack( new DJ_SL_Carpentry() ); break;
				case 159: from.AddToBackpack( new DJ_SL_Cartography() ); break;
				case 160: from.AddToBackpack( new DJ_SL_Cooking() ); break;
				case 161: from.AddToBackpack( new DJ_SL_Discordance() ); break;
				case 162: from.AddToBackpack( new DJ_SL_AnimalLore() ); break;
				case 163: from.AddToBackpack( new DJ_SL_Elementalism() ); break;
				case 164: from.AddToBackpack( new DJ_SL_Fencing() ); break;
				case 165: from.AddToBackpack( new DJ_SL_Wrestling() ); break;
				case 166: from.AddToBackpack( new DJ_SL_Focus() ); break;
				case 167: from.AddToBackpack( new DJ_SL_Healing() ); break;
				case 168: from.AddToBackpack( new DJ_SL_Herding() ); break;
				case 169: from.AddToBackpack( new DJ_SL_Hiding() ); break;
				case 170: from.AddToBackpack( new DJ_SL_Inscribe() ); break;
				case 171: from.AddToBackpack( new DJ_SL_Chivalry() ); break;
				case 172: from.AddToBackpack( new DJ_SL_Lockpicking() ); break;
				case 173: from.AddToBackpack( new DJ_SL_Lumberjacking() ); break;
				case 174: from.AddToBackpack( new DJ_SL_Magery() ); break;
				case 175: from.AddToBackpack( new DJ_SL_MagicResist() ); break;
				case 176: from.AddToBackpack( new DJ_SL_Archery() ); break;
				case 177: from.AddToBackpack( new DJ_SL_Meditation() ); break;
				case 178: from.AddToBackpack( new DJ_SL_Mining() ); break;
				case 179: from.AddToBackpack( new DJ_SL_Musicianship() ); break;
				case 180: from.AddToBackpack( new DJ_SL_Necromancy() ); break;
				case 181: from.AddToBackpack( new DJ_SL_Ninjitsu() ); break;
				case 182: from.AddToBackpack( new DJ_SL_Parry() ); break;
				case 183: from.AddToBackpack( new DJ_SL_Peacemaking() ); break;
				case 184: from.AddToBackpack( new DJ_SL_Poisoning() ); break;
				case 185: from.AddToBackpack( new DJ_SL_Provocation() ); break;
				case 186: from.AddToBackpack( new DJ_SL_EvalInt() ); break;
				case 187: from.AddToBackpack( new DJ_SL_RemoveTrap() ); break;
				case 188: from.AddToBackpack( new DJ_SL_Fishing() ); break;
				case 189: from.AddToBackpack( new DJ_SL_DetectHidden() ); break;
				case 190: from.AddToBackpack( new DJ_SL_Snooping() ); break;
				case 191: from.AddToBackpack( new DJ_SL_SpiritSpeak() ); break;
				case 192: from.AddToBackpack( new DJ_SL_Stealing() ); break;
				case 193: from.AddToBackpack( new DJ_SL_Stealth() ); break;
				case 194: from.AddToBackpack( new DJ_SL_Swords() ); break;
				case 195: from.AddToBackpack( new DJ_SL_Tactics() ); break;
				case 196: from.AddToBackpack( new DJ_SL_Tailoring() ); break;
				case 197: from.AddToBackpack( new DJ_SL_AnimalTaming() ); break;
				case 198: from.AddToBackpack( new DJ_SL_Tinkering() ); break;
				case 199: from.AddToBackpack( new DJ_SL_Tracking() ); break;
				case 200: from.AddToBackpack( new DJ_SL_Veterinary() ); break;
				case 201: from.AddToBackpack( new DJ_SP_Alchemy() ); break;
				case 202: from.AddToBackpack( new DJ_SP_Anatomy() ); break;
				case 203: from.AddToBackpack( new DJ_SP_ArmsLore() ); break;
				case 204: from.AddToBackpack( new DJ_SP_Blacksmith() ); break;
				case 205: from.AddToBackpack( new DJ_SP_Macing() ); break;
				case 206: from.AddToBackpack( new DJ_SP_Fletching() ); break;
				case 207: from.AddToBackpack( new DJ_SP_Bushido() ); break;
				case 208: from.AddToBackpack( new DJ_SP_Carpentry() ); break;
				case 209: from.AddToBackpack( new DJ_SP_Cartography() ); break;
				case 210: from.AddToBackpack( new DJ_SP_Cooking() ); break;
				case 211: from.AddToBackpack( new DJ_SP_Discordance() ); break;
				case 212: from.AddToBackpack( new DJ_SP_AnimalLore() ); break;
				case 213: from.AddToBackpack( new DJ_SP_Elementalism() ); break;
				case 214: from.AddToBackpack( new DJ_SP_Fencing() ); break;
				case 215: from.AddToBackpack( new DJ_SP_Wrestling() ); break;
				case 216: from.AddToBackpack( new DJ_SP_Focus() ); break;
				case 217: from.AddToBackpack( new DJ_SP_Healing() ); break;
				case 218: from.AddToBackpack( new DJ_SP_Herding() ); break;
				case 219: from.AddToBackpack( new DJ_SP_Hiding() ); break;
				case 220: from.AddToBackpack( new DJ_SP_Inscribe() ); break;
				case 221: from.AddToBackpack( new DJ_SP_Chivalry() ); break;
				case 222: from.AddToBackpack( new DJ_SP_Lockpicking() ); break;
				case 223: from.AddToBackpack( new DJ_SP_Lumberjacking() ); break;
				case 224: from.AddToBackpack( new DJ_SP_Magery() ); break;
				case 225: from.AddToBackpack( new DJ_SP_MagicResist() ); break;
				case 226: from.AddToBackpack( new DJ_SP_Archery() ); break;
				case 227: from.AddToBackpack( new DJ_SP_Meditation() ); break;
				case 228: from.AddToBackpack( new DJ_SP_Mining() ); break;
				case 229: from.AddToBackpack( new DJ_SP_Musicianship() ); break;
				case 230: from.AddToBackpack( new DJ_SP_Necromancy() ); break;
				case 231: from.AddToBackpack( new DJ_SP_Ninjitsu() ); break;
				case 232: from.AddToBackpack( new DJ_SP_Parry() ); break;
				case 233: from.AddToBackpack( new DJ_SP_Peacemaking() ); break;
				case 234: from.AddToBackpack( new DJ_SP_Poisoning() ); break;
				case 235: from.AddToBackpack( new DJ_SP_Provocation() ); break;
				case 236: from.AddToBackpack( new DJ_SP_EvalInt() ); break;
				case 237: from.AddToBackpack( new DJ_SP_RemoveTrap() ); break;
				case 238: from.AddToBackpack( new DJ_SP_Fishing() ); break;
				case 239: from.AddToBackpack( new DJ_SP_DetectHidden() ); break;
				case 240: from.AddToBackpack( new DJ_SP_Snooping() ); break;
				case 241: from.AddToBackpack( new DJ_SP_SpiritSpeak() ); break;
				case 242: from.AddToBackpack( new DJ_SP_Stealing() ); break;
				case 243: from.AddToBackpack( new DJ_SP_Stealth() ); break;
				case 244: from.AddToBackpack( new DJ_SP_Swords() ); break;
				case 245: from.AddToBackpack( new DJ_SP_Tactics() ); break;
				case 246: from.AddToBackpack( new DJ_SP_Tailoring() ); break;
				case 247: from.AddToBackpack( new DJ_SP_AnimalTaming() ); break;
				case 248: from.AddToBackpack( new DJ_SP_Tinkering() ); break;
				case 249: from.AddToBackpack( new DJ_SP_Tracking() ); break;
				case 250: from.AddToBackpack( new DJ_SP_Veterinary() ); break;
			}
		}

		public string GetTxt( int val )
		{
			string txt = "";

			if ( val == 1 ){ txt = "Alchemy"; }
			else if ( val == 2 ){ txt = "Anatomy"; }
			else if ( val == 3 ){ txt = "Arms Lore"; }
			else if ( val == 4 ){ txt = "Blacksmithing"; }
			else if ( val == 5 ){ txt = "Bludgeoning"; }
			else if ( val == 6 ){ txt = "Bowcrafting"; }
			else if ( val == 7 ){ txt = "Bushido"; }
			else if ( val == 8 ){ txt = "Carpentry"; }
			else if ( val == 9 ){ txt = "Cartography"; }
			else if ( val == 10 ){ txt = "Cooking"; }
			else if ( val == 11 ){ txt = "Discordance"; }
			else if ( val == 12 ){ txt = "Druidism"; }
			else if ( val == 13 ){ txt = "Elementalism"; }
			else if ( val == 14 ){ txt = "Fencing"; }
			else if ( val == 15 ){ txt = "Fist Fighting"; }
			else if ( val == 16 ){ txt = "Focus"; }
			else if ( val == 17 ){ txt = "Healing"; }
			else if ( val == 18 ){ txt = "Herding"; }
			else if ( val == 19 ){ txt = "Hiding"; }
			else if ( val == 20 ){ txt = "Inscription"; }
			else if ( val == 21 ){ txt = "Knightship"; }
			else if ( val == 22 ){ txt = "Lockpicking"; }
			else if ( val == 23 ){ txt = "Lumberjacking"; }
			else if ( val == 24 ){ txt = "Magery"; }
			else if ( val == 25 ){ txt = "Magic Resistance"; }
			else if ( val == 26 ){ txt = "Marksmanship"; }
			else if ( val == 27 ){ txt = "Meditation"; }
			else if ( val == 28 ){ txt = "Mining"; }
			else if ( val == 29 ){ txt = "Musicianship"; }
			else if ( val == 30 ){ txt = "Necromancy"; }
			else if ( val == 31 ){ txt = "Ninjitsu"; }
			else if ( val == 32 ){ txt = "Parrying"; }
			else if ( val == 33 ){ txt = "Peacemaking"; }
			else if ( val == 34 ){ txt = "Poisoning"; }
			else if ( val == 35 ){ txt = "Provocation"; }
			else if ( val == 36 ){ txt = "Psychology"; }
			else if ( val == 37 ){ txt = "Remove Trap"; }
			else if ( val == 38 ){ txt = "Seafaring"; }
			else if ( val == 39 ){ txt = "Searching"; }
			else if ( val == 40 ){ txt = "Snooping"; }
			else if ( val == 41 ){ txt = "Spiritualism"; }
			else if ( val == 42 ){ txt = "Stealing"; }
			else if ( val == 43 ){ txt = "Stealth"; }
			else if ( val == 44 ){ txt = "Swordsmanship"; }
			else if ( val == 45 ){ txt = "Tactics"; }
			else if ( val == 46 ){ txt = "Tailoring"; }
			else if ( val == 47 ){ txt = "Taming"; }
			else if ( val == 48 ){ txt = "Tinkering"; }
			else if ( val == 49 ){ txt = "Tracking"; }
			else if ( val == 50 ){ txt = "Veterinary"; }

			return txt;
		}
    }
}