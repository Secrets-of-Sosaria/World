using System;
using Server.Items;
using Server.Misc;

namespace Server
{
    class ItemSkills
    {
		public static string BaseToolSkills( BaseTool var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseHarvestToolSkills( BaseHarvestTool var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseArmorSkills( BaseArmor var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseWeaponSkills( BaseWeapon var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseClothingSkills( BaseClothing var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseInstrumentSkills( BaseInstrument var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string BaseTrinketSkills( BaseTrinket var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}

		public static string SpellbookSkills( Spellbook var, string text )
		{
			SkillName skill0;
			SkillName skill1;
			SkillName skill2;
			SkillName skill3;
			SkillName skill4;

			double bonus0;
			double bonus1;
			double bonus2;
			double bonus3;
			double bonus4;

			var.SkillBonuses.GetValues( 0, out skill0, out bonus0 );
			var.SkillBonuses.GetValues( 1, out skill1, out bonus1 );
			var.SkillBonuses.GetValues( 2, out skill2, out bonus2 );
			var.SkillBonuses.GetValues( 3, out skill3, out bonus3 );
			var.SkillBonuses.GetValues( 4, out skill4, out bonus4 );

			if ( bonus0 > 0 )
			{
				if ( skill0 == skill1 && bonus1 > 0 ){		bonus0 += bonus1;	bonus1 = 0.0;	}
				if ( skill0 == skill2 && bonus2 > 0 ){		bonus0 += bonus2;	bonus2 = 0.0;	}
				if ( skill0 == skill3 && bonus3 > 0 ){		bonus0 += bonus3;	bonus3 = 0.0;	}
				if ( skill0 == skill4 && bonus4 > 0 ){		bonus0 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus1 > 0 )
			{
				if ( skill1 == skill0 && bonus0 > 0 ){		bonus1 += bonus0;	bonus0 = 0.0;	}
				if ( skill1 == skill2 && bonus2 > 0 ){		bonus1 += bonus2;	bonus2 = 0.0;	}
				if ( skill1 == skill3 && bonus3 > 0 ){		bonus1 += bonus3;	bonus3 = 0.0;	}
				if ( skill1 == skill4 && bonus4 > 0 ){		bonus1 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus2 > 0 )
			{
				if ( skill2 == skill0 && bonus0 > 0 ){		bonus2 += bonus0;	bonus0 = 0.0;	}
				if ( skill2 == skill1 && bonus1 > 0 ){		bonus2 += bonus1;	bonus1 = 0.0;	}
				if ( skill2 == skill3 && bonus3 > 0 ){		bonus2 += bonus3;	bonus3 = 0.0;	}
				if ( skill2 == skill4 && bonus4 > 0 ){		bonus2 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus3 > 0 )
			{
				if ( skill3 == skill0 && bonus0 > 0 ){		bonus3 += bonus0;	bonus0 = 0.0;	}
				if ( skill3 == skill1 && bonus1 > 0 ){		bonus3 += bonus1;	bonus1 = 0.0;	}
				if ( skill3 == skill2 && bonus2 > 0 ){		bonus3 += bonus2;	bonus2 = 0.0;	}
				if ( skill3 == skill4 && bonus4 > 0 ){		bonus3 += bonus4;	bonus4 = 0.0;	}
			}
			if ( bonus4 > 0 )
			{
				if ( skill4 == skill0 && bonus0 > 0 ){		bonus4 += bonus0;	bonus0 = 0.0;	}
				if ( skill4 == skill1 && bonus1 > 0 ){		bonus4 += bonus1;	bonus1 = 0.0;	}
				if ( skill4 == skill2 && bonus2 > 0 ){		bonus4 += bonus2;	bonus2 = 0.0;	}
				if ( skill4 == skill3 && bonus3 > 0 ){		bonus4 += bonus3;	bonus3 = 0.0;	}
			}

			if ( bonus0 > 0 )
				text += "" + SkillInfo.Table[(int)skill0].Name + " +" + bonus0 + "<BR>";
			if ( bonus1 > 0 )
				text += "" + SkillInfo.Table[(int)skill1].Name + " +" + bonus1 + "<BR>";
			if ( bonus2 > 0 )
				text += "" + SkillInfo.Table[(int)skill2].Name + " +" + bonus2 + "<BR>";
			if ( bonus3 > 0 )
				text += "" + SkillInfo.Table[(int)skill3].Name + " +" + bonus3 + "<BR>";
			if ( bonus4 > 0 )
				text += "" + SkillInfo.Table[(int)skill4].Name + " +" + bonus4 + "<BR>";

			return text;
		}
    }
}