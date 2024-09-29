using System;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Items;

namespace Server.Commands
{
	public class SpecialAttacksDisplayCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register( "SpecialAttacksDisplay", AccessLevel.Player, new CommandEventHandler( SpecialAttacksDisplay_Command ) );
			CommandSystem.Register( "SAD", AccessLevel.Player, new CommandEventHandler( SpecialAttacksDisplay_Command ) );
		}

		[Usage( "SpecialAttacksDisplay" )]
		[Aliases( "SAD" )]
		[Description( "Opens your Weapons Special Attacks Display." )]
		private static void SpecialAttacksDisplay_Command( CommandEventArgs e )
		{
			double sk1 = MyServerSettings.SpecialWeaponAbilSkill();
			double sk2 = sk1+10;
			double sk3 = sk2+10;
			double sk4 = sk3+10;
			double sk5 = sk4+10;

			PlayerMobile pm = e.Mobile as PlayerMobile;
			BaseWeapon weapon = (BaseWeapon)(pm.Weapon);
			int number = 0;
			if ( ( weapon.PrimaryAbility!=null ) 	&& ( pm.Skills[weapon.DefSkill].Value >= sk1 	|| pm.Skills[weapon.GetUsedSkill(pm,true)].Value >= sk1 ) 	&& pm.Skills[SkillName.Tactics].Value >= sk1 ) 	number++;
			if ( ( weapon.SecondaryAbility!=null ) 	&& ( pm.Skills[weapon.DefSkill].Value >= sk2 	|| pm.Skills[weapon.GetUsedSkill(pm,true)].Value >= sk2 ) 	&& pm.Skills[SkillName.Tactics].Value >= sk2 ) 	number++;
			if ( ( weapon.ThirdAbility!=null ) 		&& ( pm.Skills[weapon.DefSkill].Value >= sk3 	|| pm.Skills[weapon.GetUsedSkill(pm,true)].Value >= sk3 ) 	&& pm.Skills[SkillName.Tactics].Value >= sk3 ) 	number++;
			if ( ( weapon.FourthAbility!=null )		&& ( pm.Skills[weapon.DefSkill].Value >= sk4 	|| pm.Skills[weapon.GetUsedSkill(pm,true)].Value >= sk4 )	&& pm.Skills[SkillName.Tactics].Value >= sk4 ) 	number++;
			if ( ( weapon.FifthAbility!=null ) 		&& ( pm.Skills[weapon.DefSkill].Value >= sk5 	|| pm.Skills[weapon.GetUsedSkill(pm,true)].Value >= sk5 )	&& pm.Skills[SkillName.Tactics].Value >= sk5 ) 	number++;
			if (number > 0) pm.SendGump(new SpecialAttackGump( weapon, pm, number ));
			else pm.SendMessage("Your weapon skills are not high enough to use a special attack of any kind");
		}
	}
}
