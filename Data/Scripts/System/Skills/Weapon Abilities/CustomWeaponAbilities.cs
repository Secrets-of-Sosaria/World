using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server
{
	public static class CustomWeaponAbilities
	{
		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}
		
		private static void EventSink_Login( LoginEventArgs args )
		{
			Mobile from = args.Mobile;
			
			if ( from != null && Server.Misc.PlayerSettings.AutoOpenWepBar( from ) )
			{
				Check(from);
			}
		}
		
		public static void Check(Mobile from)
		{
			BaseWeapon weapon = (BaseWeapon)(from.Weapon);
			Check(weapon,from);
		}
		
		public static void Check(BaseWeapon weapon, Mobile from)
		{
			from.CloseGump(typeof(SpecialAttackGump));
			
			int abilities=0;
			
			if ( from != null && weapon != null )
			{
				abilities=HasAbilities( weapon, from );
				
				if( abilities > 0 )
				{
					from.SendGump(new SpecialAttackGump( weapon, from, abilities ));
				}
			}
		}
		
		private static int HasAbilities(BaseWeapon weapon, Mobile from)
		{
			int number = 0;

			double sk1 = MyServerSettings.SpecialWeaponAbilSkill();
			double sk2 = sk1+10;
			double sk3 = sk2+10;
			double sk4 = sk3+10;
			double sk5 = sk4+10;

			if(weapon.PrimaryAbility != null)
			{
				if ( ( from.Skills[weapon.DefSkill].Value >= sk1 || from.Skills[weapon.GetUsedSkill(from,true)].Value >= sk1 ) && ( from.Skills[SkillName.Tactics].Value >= sk1 ) )
				{
					number++;
				}
			}
			
			if(weapon.SecondaryAbility != null)
			{
				if ( ( from.Skills[weapon.DefSkill].Value >= sk2 || from.Skills[weapon.GetUsedSkill(from,true)].Value >= sk2 ) && ( from.Skills[SkillName.Tactics].Value >= sk2 ) )
				{
					number++;
				}
			}
			if(weapon.ThirdAbility != null)
			{
				if ( ( from.Skills[weapon.DefSkill].Value >= sk3 || from.Skills[weapon.GetUsedSkill(from,true)].Value >= sk3 ) && ( from.Skills[SkillName.Tactics].Value >= sk3 ) )
				{
					number++;
				}
			}
			if(weapon.FourthAbility != null)
			{
				if ( ( from.Skills[weapon.DefSkill].Value >= sk4 || from.Skills[weapon.GetUsedSkill(from,true)].Value >= sk4 ) && ( from.Skills[SkillName.Tactics].Value >= sk4 ) )
				{
					number++;
				}
			}
			if(weapon.FifthAbility != null)
			{
				if ( ( from.Skills[weapon.DefSkill].Value >= sk5 || from.Skills[weapon.GetUsedSkill(from,true)].Value >= sk5 ) && ( from.Skills[SkillName.Tactics].Value >= sk5 ) )
				{
					number++;
				}
			}
			
			return number;
		}
		
		public static bool ServerSideSetAbility(Mobile from, int index)
		{
			if ( index == 0 )
				WeaponAbility.ClearCurrentAbility( from );
			else if ( index >= 1 && index < WeaponAbility.Abilities.Length )
			{
				if(WeaponAbility.SetCurrentAbility( from, WeaponAbility.Abilities[index] ))
					return true;
			}
			return false;
		}
		
		public static void SetAbilities(BaseWeapon weapon, ref int Primary, ref int Secondary, ref int Third, ref int Fourth, ref int Fifth)
		{
			WeaponAbility prim = weapon.PrimaryAbility;
			WeaponAbility second = weapon.SecondaryAbility;
			WeaponAbility third = weapon.ThirdAbility;
			WeaponAbility fourth = weapon.FourthAbility;
			WeaponAbility fifth = weapon.FifthAbility;
			
			for(int i=0;i<WeaponAbility.Abilities.Length;i++)
			{
				WeaponAbility index = WeaponAbility.Abilities[i];
				if(index!=null)
				{
					if(prim == index)Primary=i;
					if(second == index)Secondary=i;
					if(third == index)Third=i;
					if(fourth == index)Fourth=i;
					if(fifth == index)Fifth=i;
				}
			}
		}
	}
}
