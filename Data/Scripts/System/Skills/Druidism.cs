using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;

namespace Server.SkillHandlers
{
	public class Druidism
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Druidism].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse(Mobile m)
		{
			m.Target = new InternalTarget();

			m.SendLocalizedMessage( 500328 ); // What animal should I look at?

			return TimeSpan.FromSeconds( 1.0 );
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base( 8, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( !from.Alive )
				{
					from.SendLocalizedMessage( 500331 ); // The spirits of the dead are not the province of druidism.
				}
				else if ( targeted is HenchmanMonster || targeted is HenchmanWizard || targeted is HenchmanFighter || targeted is HenchmanArcher )
				{
					from.SendLocalizedMessage( 500329 ); // That's not an animal!
				}
				else if ( targeted is BaseCreature )
				{
					BaseCreature c = (BaseCreature)targeted;

					SlayerEntry skipTypeA = SlayerGroup.GetEntryByName( SlayerName.SlimyScourge );
					SlayerEntry skipTypeB = SlayerGroup.GetEntryByName( SlayerName.ElementalBan );
					SlayerEntry skipTypeC = SlayerGroup.GetEntryByName( SlayerName.Repond );
					SlayerEntry skipTypeD = SlayerGroup.GetEntryByName( SlayerName.Silver );
					SlayerEntry skipTypeE = SlayerGroup.GetEntryByName( SlayerName.GiantKiller );
					SlayerEntry skipTypeF = SlayerGroup.GetEntryByName( SlayerName.GolemDestruction );

					bool specialCreature = false;
					if ( targeted is RidingDragon || targeted is Daemonic || targeted is DrakkhenRed || targeted is DrakkhenBlack || targeted is SkeletonDragon || targeted is FrankenFighter )
					{
						if ( c.Controlled && c.ControlMaster == from )
							specialCreature = true;
					}

					if ( !c.IsDeadPet )
					{
						if ( specialCreature || ( !skipTypeA.Slays( c ) && !skipTypeB.Slays( c ) && !skipTypeC.Slays( c ) && !skipTypeD.Slays( c ) && !skipTypeE.Slays( c ) && !skipTypeF.Slays( c ) ) )
						{
							if ( c.ControlMaster == from )
							{
								from.CloseGump( typeof( DruidismGump ) );
								from.SendGump( new DruidismGump( from, c, 0 ) );
								from.SendSound( 0x0F9 );
							}
							else if ( (!c.Controlled || !c.Tamable) && from.Skills[SkillName.Druidism].Value < 100.0 )
							{
								from.SendLocalizedMessage( 1049674 ); // At your skill level, you can only lore tamed creatures.
							}
							else if ( !c.Tamable && from.Skills[SkillName.Druidism].Value < 110.0 )
							{
								from.SendLocalizedMessage( 1049675 ); // At your skill level, you can only lore tamed or tameable creatures.
							}
							else if ( !from.CheckTargetSkill( SkillName.Druidism, c, 0.0, 125.0 ) )
							{
								from.SendLocalizedMessage( 500334 ); // You can't think of anything you know offhand.
							}
							else
							{
								from.CloseGump( typeof( DruidismGump ) );
								from.SendGump( new DruidismGump( from, c, 0 ) );
								from.SendSound( 0x0F9 );
							}
						}
						else
						{
							from.SendLocalizedMessage( 500329 ); // That's not an animal!
						}
					}
					else
					{
						from.SendLocalizedMessage( 500331 ); // The spirits of the dead are not the province of druidism.
					}
				}
				else
				{
					from.SendLocalizedMessage( 500329 ); // That's not an animal!
				}
			}
		}
	}

	public class DruidismGump : Gump
	{
		private int m_Book; 

		private static string FormatSkill( BaseCreature c, SkillName name )
		{
			Skill skill = c.Skills[name];

			if ( skill.Base < 10.0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0:F1}</div>", skill.Value );
		}

		private static string FormatCombat( BaseCreature from )
		{
			int c = 0;
			double skills = 0.0;

			double skill1 = from.Skills[SkillName.Marksmanship].Value;
				if ( skill1 > 10.0 ){ c++; skills = skills + skill1; }
			double skill2 = from.Skills[SkillName.Fencing].Value;
				if ( skill2 > 10.0 ){ c++; skills = skills + skill2; }
			double skill3 = from.Skills[SkillName.Bludgeoning].Value;
				if ( skill3 > 10.0 ){ c++; skills = skills + skill3; }
			double skill4 = from.Skills[SkillName.Swords].Value;
				if ( skill4 > 10.0 ){ c++; skills = skills + skill4; }
			double skill5 = from.Skills[SkillName.FistFighting].Value;
				if ( skill5 > 10.0 ){ c++; skills = skills + skill5; }

			if ( c == 0 )
			{
				return "<div align=right>---</div>";
			}
			else
			{
				skills = skills / c;
			}

			if ( skills > 125.0 )
				skills = 125.0;

			return String.Format( "<div align=right>{0:F1}</div>", skills );
		}

		private static string FormatFight( BaseCreature from )
		{
			int c = 0;
			double skills = 0.0;

			double skill1 = from.Skills[SkillName.Marksmanship].Value;
				if ( skill1 > 10.0 ){ c++; skills = skills + skill1; }
			double skill2 = from.Skills[SkillName.Fencing].Value;
				if ( skill2 > 10.0 ){ c++; skills = skills + skill2; }
			double skill3 = from.Skills[SkillName.Bludgeoning].Value;
				if ( skill3 > 10.0 ){ c++; skills = skills + skill3; }
			double skill4 = from.Skills[SkillName.Swords].Value;
				if ( skill4 > 10.0 ){ c++; skills = skills + skill4; }
			double skill5 = from.Skills[SkillName.FistFighting].Value;
				if ( skill5 > 10.0 ){ c++; skills = skills + skill5; }

			if ( c == 0 )
			{
				return "0";
			}
			else
			{
				skills = skills / c;
			}

			if ( skills > 125.0 )
				skills = 125.0;

			return skills.ToString("0.0");
		}

		private static string FormatTalent( double skill )
		{
			if ( skill < 10 )
				return "---";

			return skill.ToString("0.0");
		}

		private static string FormatTaming( double skill )
		{
			if ( skill == 0 )
				return "---";

			return skill.ToString("0.0");
		}

		private static string FormatPercent( double skill )
		{
			if ( skill < 10 )
				return "---";

			return skill.ToString() + "%";
		}

		private static string FormatNumber( int val )
		{
			if ( val < 1 )
				return "---";

			return val.ToString();
		}

		private static string FormatAttributes( int cur, int max )
		{
			if ( max == 0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0}/{1}</div>", cur, max );
		}

		private static string FormatStat( int val )
		{
			if ( val == 0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0}</div>", val );
		}

		private static string FormatDouble( double val )
		{
			if ( val == 0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0:F1}</div>", val );
		}

		private static string FormatElement( int val )
		{
			if ( val <= 0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0}%</div>", val );
		}

		private static string FormatDamage( int min, int max )
		{
			if ( min <= 0 || max <= 0 )
				return "<div align=right>---</div>";

			return String.Format( "<div align=right>{0}-{1}</div>", min, max );
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile; 
			if ( m_Book > 0 ){ from.SendSound( 0x55 ); }
			else { from.SendSound( 0x0F9 ); }
		}

		public DruidismGump( Mobile from, BaseCreature c, int source ) : base( 50, 50 )
		{
            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			// 0 - ANIMAL LORE // 1 - MONSTER MANUAL // 2 - PLAYERS HANDBOOK

			m_Book = 0;

			int img = 11416;
			string color = "#79BFDC";
			string combat = "Combat Skill";
			string skill = "" + FormatTalent( c.Skills[SkillName.FistFighting].Value ) + "";
			string title = "MONSTER MANUAL";

			if ( source == 1 || source == 2 ){ m_Book = 1; }

			if ( source == 2 )
			{
				img = 11417;
				color = "#DCB179";
				combat = "Combat Skill";
				skill = FormatFight( c );
				title = "PLAYERS HANDBOOK";
			}
			else if ( source == 0 )
			{
				img = 11418;
				color = "#83B587";
				combat = "Combat Skill";
				skill = "" + FormatTalent( c.Skills[SkillName.FistFighting].Value ) + "";
				title = "ANIMAL LORE";
			}
			else if ( source == 3 )
			{
				img = 11419;
				color = "#E59DE2";
				combat = "Combat Skill";
				skill = "" + FormatTalent( c.Skills[SkillName.FistFighting].Value ) + "";
				title = "DIVINATION";
			}
			else if ( source == 4 )
			{
				img = 11419;
				color = "#E59DE2";
				combat = "Combat Skill";
				skill = FormatFight( c );
				title = "DIVINATION";
			}

			AddImage(1, 1, img, Server.Misc.PlayerSettings.GetGumpHue( from ));

			string name = c.Name;
				if ( c.Title != "" && c.Title != null ){ name = name + " " + c.Title; }

			AddHtml( 14, 15, 167, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 179, 15, 344, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + name.ToUpper() + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(667, 12, 4017, 4017, 0, GumpButtonType.Reply, 0);

			string colA = "INFORMATION<BR> <BR>";
			colA = colA + "  Level<BR>";
			colA = colA + "  Hits<BR>";
			colA = colA + "  Stamina<BR>";
			colA = colA + "  Mana<BR>";
			colA = colA + "  Strength<BR>";
			colA = colA + "  Dexterity<BR>";
			colA = colA + "  Intelligence<BR>";
			colA = colA + "  Barding<BR>";
			colA = colA + "    Difficulty<BR>";

			if ( source == 0 && c.MinTameSkill > 0 )
			{
				colA = colA + "  Taming Needed<BR>";
				colA = colA + "  Loyalty Rating<BR>";
					string loyalty = "Wild";
					int loyal = 1 + (c.Loyalty / 10);
					switch ( loyal ) 
					{
						case 1: loyalty = "Confused"; break;
						case 2: loyalty = "Extremely Unhappy"; break;
						case 3: loyalty = "Rather Unhappy"; break;
						case 4: loyalty = "Unhappy"; break;
						case 5: loyalty = "Somewhat Content"; break;
						case 6: loyalty = "Content"; break;
						case 7: loyalty = "Happy"; break;
						case 8: loyalty = "Rather Happy"; break;
						case 9: loyalty = "Very Happy"; break;
						case 10: loyalty = "Extremely Happy"; break;
						case 11: loyalty = "Wonderfully Happy"; break;
						case 12: loyalty = "Euphoric"; break;
					}
					colA = colA + "    " + loyalty + "<BR>";
				colA = colA + "  Pack Instinct<BR>";
					string packInstinct = "None";
					if ( (c.PackInstinct & PackInstinct.Canine) != 0 )
						packInstinct = "Canine";
					else if ( (c.PackInstinct & PackInstinct.Ostard) != 0 )
						packInstinct = "Ostard";
					else if ( (c.PackInstinct & PackInstinct.Feline) != 0 )
						packInstinct = "Feline";
					else if ( (c.PackInstinct & PackInstinct.Arachnid) != 0 )
						packInstinct = "Arachnid";
					else if ( (c.PackInstinct & PackInstinct.Daemon) != 0 )
						packInstinct = "Daemon";
					else if ( (c.PackInstinct & PackInstinct.Bear) != 0 )
						packInstinct = "Bear";
					else if ( (c.PackInstinct & PackInstinct.Equine) != 0 )
						packInstinct = "Equine";
					else if ( (c.PackInstinct & PackInstinct.Bull) != 0 )
						packInstinct = "Bull";
					colA = colA + "    " + packInstinct + "<BR>";
				colA = colA + "  Foods<BR>";
					string foodPref = "";

					if ( (c.FavoriteFood & FoodType.None) != 0 )
						foodPref = foodPref + "    None<br>";
					if ( (c.FavoriteFood & FoodType.FruitsAndVegies) != 0 )
					{
						foodPref = foodPref + "    Fruits<br>";
						foodPref = foodPref + "    Vegetables<br>";
					}
					if ( (c.FavoriteFood & FoodType.GrainsAndHay) != 0 )
						foodPref = foodPref + "    Grains & Hay<br>";
					if ( (c.FavoriteFood & FoodType.Fish) != 0 )
						foodPref = foodPref + "    Fish<br>";
					if ( (c.FavoriteFood & FoodType.Meat) != 0 )
						foodPref = foodPref + "    Meat<br>";
					if ( (c.FavoriteFood & FoodType.Eggs) != 0 )
						foodPref = foodPref + "    Eggs<br>";
					if ( (c.FavoriteFood & FoodType.Gold) != 0 )
						foodPref = foodPref + "    Gold<br>";
					if ( (c.FavoriteFood & FoodType.Fire) != 0 )
					{
						foodPref = foodPref + "    Brimstone<br>";
						foodPref = foodPref + "    Sulfurous Ash<br>";
					}
					if ( (c.FavoriteFood & FoodType.Gems) != 0 )
						foodPref = foodPref + "    Gems<br>";
					if ( (c.FavoriteFood & FoodType.Nox) != 0 )
					{
						foodPref = foodPref + "    Swamp Berries<br>";
						foodPref = foodPref + "    Nox Crystals<br>";
						foodPref = foodPref + "    Nightshade<br>";
					}
					if ( (c.FavoriteFood & FoodType.Sea) != 0 )
					{
						foodPref = foodPref + "    Seaweed<br>";
						foodPref = foodPref + "    Sea Salt<br>";
					}
					if ( (c.FavoriteFood & FoodType.Moon) != 0 )
						foodPref = foodPref + "    Moon Crystals<br>";
					colA = colA + "" + foodPref + "<BR>";
			}

			string colB = " <BR> <BR>" + IntelligentAction.GetCreatureLevel( c ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Hits ) + " / " + FormatNumber( c.HitsMax ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Stam ) + " / " + FormatNumber( c.StamMax ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Mana ) + " / " + FormatNumber( c.ManaMax ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Str ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Dex ) + "<BR>";
			colB = colB + "" + FormatNumber( c.Int ) + "<BR> <BR>";

				double bd = Items.BaseInstrument.GetBaseDifficulty( c );
				if ( c.Uncalmable )
					bd = 0;

			colB = colB + "" + FormatTalent( bd ) + "<BR>";

			if ( source == 0 && c.MinTameSkill > 0 ){ colB = colB + "" + FormatTaming( c.MinTameSkill ) + "<BR>"; }

			AddHtml( 20, 50, 200, 370, @"<BODY><BASEFONT Color=" + color + ">" + colA + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 135, 50, 80, 370, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colB + "</div></BASEFONT></BODY>", (bool)false, (bool)false);

			///////////////////////////////////////////////////////////////////////////////////

			string colC = "RESISTANCE<BR> <BR>";
			colC = colC + "  Physical<BR>";
			colC = colC + "  Fire<BR>";
			colC = colC + "  Cold<BR>";
			colC = colC + "  Poison<BR>";
			colC = colC + "  Energy<BR>";
			colC = colC + "<BR> <BR>DAMAGE<BR> <BR>";
			colC = colC + "  Physical<BR>";
			colC = colC + "  Fire<BR>";
			colC = colC + "  Cold<BR>";
			colC = colC + "  Poison<BR>";
			colC = colC + "  Energy<BR>";
			colC = colC + "  Base Damage<BR>";

			string colD = " <BR> <BR>" + FormatNumber( c.PhysicalResistance ) + "<BR>";
			colD = colD + "" + FormatNumber( c.FireResistance ) + "<BR>";
			colD = colD + "" + FormatNumber( c.ColdResistance ) + "<BR>";
			colD = colD + "" + FormatNumber( c.PoisonResistance ) + "<BR>";
			colD = colD + "" + FormatNumber( c.EnergyResistance ) + "<BR> <BR>";
			colD = colD + "<BR> <BR> <BR>" + FormatPercent( c.PhysicalDamage ) + "<BR>";
			colD = colD + "" + FormatPercent( c.FireDamage ) + "<BR>";
			colD = colD + "" + FormatPercent( c.ColdDamage ) + "<BR>";
			colD = colD + "" + FormatPercent( c.PoisonDamage ) + "<BR>";
			colD = colD + "" + FormatPercent( c.EnergyDamage ) + "<BR>";
			colD = colD + "" + c.DamageMin + " / " + c.DamageMax + "<BR>";

			AddHtml( 260, 50, 105, 370, @"<BODY><BASEFONT Color=" + color + ">" + colC + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 375, 50, 80, 370, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colD + "</div></BASEFONT></BODY>", (bool)false, (bool)false);

			///////////////////////////////////////////////////////////////////////////////////

			string colE = "COMBAT RATINGS<BR> <BR>";
			colE = colE + "  Anatomy<BR>";
			colE = colE + "  Magic Resist<BR>";
			colE = colE + "  Poisoning<BR>";
			colE = colE + "  Tactics<BR>";
			colE = colE + "  " + combat + "<BR>";
			colE = colE + "<BR> <BR>LORE & KNOWLEDGE<BR> <BR>";
			colE = colE + "  Magery<BR>";
			colE = colE + "  Meditation<BR>";
			colE = colE + "  Psychology<BR>";

			string colF = " <BR> <BR>" + FormatTalent( c.Skills[SkillName.Anatomy].Value ) + "<BR>";
			colF = colF + "" + FormatTalent( c.Skills[SkillName.MagicResist].Value ) + "<BR>";
			colF = colF + "" + FormatTalent( c.Skills[SkillName.Poisoning].Value ) + "<BR>";
			colF = colF + "" + FormatTalent( c.Skills[SkillName.Tactics].Value ) + "<BR>";
			colF = colF + "" + skill + "<BR> <BR>";
			colF = colF + "<BR> <BR> <BR>" + FormatTalent( c.Skills[SkillName.Magery].Value ) + "<BR>";
			colF = colF + "" + FormatTalent( c.Skills[SkillName.Meditation].Value ) + "<BR>";
			colF = colF + "" + FormatTalent( c.Skills[SkillName.Psychology].Value ) + "<BR>";

			AddHtml( 500, 50, 150, 370, @"<BODY><BASEFONT Color=" + color + ">" + colE + "</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 615, 50, 80, 370, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colF + "</div></BASEFONT></BODY>", (bool)false, (bool)false);
		}
	}
}