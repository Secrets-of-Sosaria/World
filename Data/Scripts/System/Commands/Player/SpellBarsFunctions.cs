using System;
using Server;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Commands;
using Server.Commands.Generic;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;
using Server.Spells.Necromancy;
using Server.Spells.Chivalry;
using Server.Spells.DeathKnight; 
using Server.Spells.Song;
using Server.Spells.HolyMan;
using Server.Spells.Research;
using Server.Prompts;
using Server.Gumps;

namespace Server.Misc
{
    class ToolBarUpdates
    {
		public static void UpdateToolBar( Mobile m, int nChange, string ToolBar, int nTotal )
		{
			ToolBarUpdates.InitializeToolBar( m, ToolBar );

			string ToolBarSetting = "";

			if ( ToolBar == "SetupBarsArch1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch1; }
			else if ( ToolBar == "SetupBarsArch2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch2; }
			else if ( ToolBar == "SetupBarsArch3" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch3; }
			else if ( ToolBar == "SetupBarsArch4" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch4; }
			else if ( ToolBar == "SetupBarsMage1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage1; }
			else if ( ToolBar == "SetupBarsMage2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage2; }
			else if ( ToolBar == "SetupBarsMage3" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage3; }
			else if ( ToolBar == "SetupBarsMage4" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage4; }
			else if ( ToolBar == "SetupBarsNecro1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsNecro1; }
			else if ( ToolBar == "SetupBarsNecro2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsNecro2; }
			else if ( ToolBar == "SetupBarsKnight1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsKnight1; }
			else if ( ToolBar == "SetupBarsKnight2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsKnight2; }
			else if ( ToolBar == "SetupBarsDeath1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsDeath1; }
			else if ( ToolBar == "SetupBarsDeath2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsDeath2; }
			else if ( ToolBar == "SetupBarsElly1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsElly1; }
			else if ( ToolBar == "SetupBarsElly2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsElly2; }
			else if ( ToolBar == "SetupBarsBard1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsBard1; }
			else if ( ToolBar == "SetupBarsBard2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsBard2; }
			else if ( ToolBar == "SetupBarsPriest1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsPriest1; }
			else if ( ToolBar == "SetupBarsPriest2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsPriest2; }
			else if ( ToolBar == "SetupBarsMonk1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMonk1; }
			else if ( ToolBar == "SetupBarsMonk2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMonk2; }

			string[] eachSetting = ToolBarSetting.Split('#');
			int nLine = 1;
			string newSettings = "";

			foreach (string eachSettings in eachSetting)
			{
				if ( nLine == nChange )
				{
					string sChange = "0";
					if ( eachSettings == "0" ){ sChange = "1"; }
					newSettings = newSettings + sChange + "#";
				}
				else if ( nLine > nTotal )
				{
				}
				else
				{
					newSettings = newSettings + eachSettings + "#";
				}
				nLine++;
			}

			if ( ToolBar == "SetupBarsArch1" ){ ((PlayerMobile)m).SpellBarsArch1 = newSettings; }
			else if ( ToolBar == "SetupBarsArch2" ){ ((PlayerMobile)m).SpellBarsArch2 = newSettings; }
			else if ( ToolBar == "SetupBarsArch3" ){ ((PlayerMobile)m).SpellBarsArch3 = newSettings; }
			else if ( ToolBar == "SetupBarsArch4" ){ ((PlayerMobile)m).SpellBarsArch4 = newSettings; }
			else if ( ToolBar == "SetupBarsMage1" ){ ((PlayerMobile)m).SpellBarsMage1 = newSettings; }
			else if ( ToolBar == "SetupBarsMage2" ){ ((PlayerMobile)m).SpellBarsMage2 = newSettings; }
			else if ( ToolBar == "SetupBarsMage3" ){ ((PlayerMobile)m).SpellBarsMage3 = newSettings; }
			else if ( ToolBar == "SetupBarsMage4" ){ ((PlayerMobile)m).SpellBarsMage4 = newSettings; }
			else if ( ToolBar == "SetupBarsNecro1" ){ ((PlayerMobile)m).SpellBarsNecro1 = newSettings; }
			else if ( ToolBar == "SetupBarsNecro2" ){ ((PlayerMobile)m).SpellBarsNecro2 = newSettings; }
			else if ( ToolBar == "SetupBarsKnight1" ){ ((PlayerMobile)m).SpellBarsKnight1 = newSettings; }
			else if ( ToolBar == "SetupBarsKnight2" ){ ((PlayerMobile)m).SpellBarsKnight2 = newSettings; }
			else if ( ToolBar == "SetupBarsDeath1" ){ ((PlayerMobile)m).SpellBarsDeath1 = newSettings; }
			else if ( ToolBar == "SetupBarsDeath2" ){ ((PlayerMobile)m).SpellBarsDeath2 = newSettings; }
			else if ( ToolBar == "SetupBarsElly1" ){ ((PlayerMobile)m).SpellBarsElly1 = newSettings; }
			else if ( ToolBar == "SetupBarsElly2" ){ ((PlayerMobile)m).SpellBarsElly2 = newSettings; }
			else if ( ToolBar == "SetupBarsBard1" ){ ((PlayerMobile)m).SpellBarsBard1 = newSettings; }
			else if ( ToolBar == "SetupBarsBard2" ){ ((PlayerMobile)m).SpellBarsBard2 = newSettings; }
			else if ( ToolBar == "SetupBarsPriest1" ){ ((PlayerMobile)m).SpellBarsPriest1 = newSettings; }
			else if ( ToolBar == "SetupBarsPriest2" ){ ((PlayerMobile)m).SpellBarsPriest2 = newSettings; }
			else if ( ToolBar == "SetupBarsMonk1" ){ ((PlayerMobile)m).SpellBarsMonk1 = newSettings; }
			else if ( ToolBar == "SetupBarsMonk2" ){ ((PlayerMobile)m).SpellBarsMonk2 = newSettings; }
		}

		public static void InitializeToolBar( Mobile m, string ToolBar )
		{
			if ( ToolBar == "SetupBarsArch1" && ( ((PlayerMobile)m).SpellBarsArch1 == null || (((PlayerMobile)m).SpellBarsArch1).Length < 132 ) ){ ((PlayerMobile)m).SpellBarsArch1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsArch2" && ( ((PlayerMobile)m).SpellBarsArch2 == null || (((PlayerMobile)m).SpellBarsArch2).Length < 132 ) ){ ((PlayerMobile)m).SpellBarsArch2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsArch3" && ( ((PlayerMobile)m).SpellBarsArch3 == null || (((PlayerMobile)m).SpellBarsArch3).Length < 132 ) ){ ((PlayerMobile)m).SpellBarsArch3 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsArch4" && ( ((PlayerMobile)m).SpellBarsArch4 == null || (((PlayerMobile)m).SpellBarsArch4).Length < 132 ) ){ ((PlayerMobile)m).SpellBarsArch4 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMage1" && ((PlayerMobile)m).SpellBarsMage1 == null ){ ((PlayerMobile)m).SpellBarsMage1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMage2" && ((PlayerMobile)m).SpellBarsMage2 == null ){ ((PlayerMobile)m).SpellBarsMage2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMage3" && ((PlayerMobile)m).SpellBarsMage3 == null ){ ((PlayerMobile)m).SpellBarsMage3 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMage4" && ((PlayerMobile)m).SpellBarsMage4 == null ){ ((PlayerMobile)m).SpellBarsMage4 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsNecro1" && ((PlayerMobile)m).SpellBarsNecro1 == null ){ ((PlayerMobile)m).SpellBarsNecro1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsNecro2" && ((PlayerMobile)m).SpellBarsNecro2 == null ){ ((PlayerMobile)m).SpellBarsNecro2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsKnight1" && ((PlayerMobile)m).SpellBarsKnight1 == null ){ ((PlayerMobile)m).SpellBarsKnight1 = "0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsKnight2" && ((PlayerMobile)m).SpellBarsKnight2 == null ){ ((PlayerMobile)m).SpellBarsKnight2 = "0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsDeath1" && ((PlayerMobile)m).SpellBarsDeath1 == null ){ ((PlayerMobile)m).SpellBarsDeath1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsDeath2" && ((PlayerMobile)m).SpellBarsDeath2 == null ){ ((PlayerMobile)m).SpellBarsDeath2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsElly1" && ((PlayerMobile)m).SpellBarsElly1 == null ){ ((PlayerMobile)m).SpellBarsElly1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsElly2" && ((PlayerMobile)m).SpellBarsElly2 == null ){ ((PlayerMobile)m).SpellBarsElly2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsBard1" && ((PlayerMobile)m).SpellBarsBard1 == null ){ ((PlayerMobile)m).SpellBarsBard1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsBard2" && ((PlayerMobile)m).SpellBarsBard2 == null ){ ((PlayerMobile)m).SpellBarsBard2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsPriest1" && ((PlayerMobile)m).SpellBarsPriest1 == null ){ ((PlayerMobile)m).SpellBarsPriest1 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsPriest2" && ((PlayerMobile)m).SpellBarsPriest2 == null ){ ((PlayerMobile)m).SpellBarsPriest2 = "0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMonk1" && ((PlayerMobile)m).SpellBarsMonk1 == null ){ ((PlayerMobile)m).SpellBarsMonk1 = "0#0#0#0#0#0#0#0#0#0#0#0#"; }
			else if ( ToolBar == "SetupBarsMonk2" && ((PlayerMobile)m).SpellBarsMonk2 == null ){ ((PlayerMobile)m).SpellBarsMonk2 = "0#0#0#0#0#0#0#0#0#0#0#0#"; }
		}

		public static int GetToolBarSetting( Mobile m, int nSetting, string ToolBar )
		{
			PlayerMobile pm = (PlayerMobile)m;
			string sSetting = "0";

			ToolBarUpdates.InitializeToolBar( m, ToolBar );

			string ToolBarSetting = "";

			if ( ToolBar == "SetupBarsArch1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch1; }
			else if ( ToolBar == "SetupBarsArch2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch2; }
			else if ( ToolBar == "SetupBarsArch3" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch3; }
			else if ( ToolBar == "SetupBarsArch4" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsArch4; }
			else if ( ToolBar == "SetupBarsMage1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage1; }
			else if ( ToolBar == "SetupBarsMage2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage2; }
			else if ( ToolBar == "SetupBarsMage3" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage3; }
			else if ( ToolBar == "SetupBarsMage4" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMage4; }
			else if ( ToolBar == "SetupBarsNecro1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsNecro1; }
			else if ( ToolBar == "SetupBarsNecro2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsNecro2; }
			else if ( ToolBar == "SetupBarsKnight1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsKnight1; }
			else if ( ToolBar == "SetupBarsKnight2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsKnight2; }
			else if ( ToolBar == "SetupBarsDeath1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsDeath1; }
			else if ( ToolBar == "SetupBarsDeath2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsDeath2; }
			else if ( ToolBar == "SetupBarsElly1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsElly1; }
			else if ( ToolBar == "SetupBarsElly2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsElly2; }
			else if ( ToolBar == "SetupBarsBard1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsBard1; }
			else if ( ToolBar == "SetupBarsBard2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsBard2; }
			else if ( ToolBar == "SetupBarsPriest1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsPriest1; }
			else if ( ToolBar == "SetupBarsPriest2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsPriest2; }
			else if ( ToolBar == "SetupBarsMonk1" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMonk1; }
			else if ( ToolBar == "SetupBarsMonk2" ){ ToolBarSetting = ((PlayerMobile)m).SpellBarsMonk2; }

			string[] eachSetting = ToolBarSetting.Split('#');
			int nLine = 1;

			foreach (string eachSettings in eachSetting)
			{
				if ( nLine == nSetting ){ sSetting = eachSettings; }
				nLine++;
			}

			int nValue = Convert.ToInt32(sSetting);

			return nValue;
		}
	}
}