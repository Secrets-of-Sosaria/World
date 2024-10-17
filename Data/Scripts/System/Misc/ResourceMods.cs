using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Engines.Harvest;
using Server.Engines.Craft;

namespace Server
{
    class ResourceMods
    {
		public static CraftResource SearchResource( Item item )
		{
			return item.Resource;
		}

		public static bool SetResource( Item item, CraftResource resource )
		{
			bool success = false;

			item.Resource = resource;

			if ( item.Resource == resource )
				success = true;

			return success;
		}

		public static bool ResourceToGold( Item item, Mobile from )
		{
			bool success = false;

			if (	item is BaseBlocks || 
					item is BaseIngot || 
					item is BaseOre || 
					item is BaseScales || 
					item is BaseWoodBoard || 
					item is BaseSkeletal || 
					item is BaseLog || 
					item is BaseGranite || 
					item is BaseSpecial || 
					item is BaseHides || 
					item is BaseFabric || 
					item is BaseLeather || 
					item is BaseSkins )
			{
				success = true;
				Item ingot = new GoldIngot();
				ingot.Amount = item.Amount;
				from.AddToBackpack( ingot );
				item.Delete();
			}

			return success;
		}

		public static void ModifyItem( Item item, CraftResource resource, bool reduce, int Slayer2, int Slayer, int Skill5, int Skill5Val, int Skill4, int Skill4Val, int Skill3, int Skill3Val, int Skill2, int Skill2Val, int Skill1, int Skill1Val, int AosAttribute_RegenHits, int AosAttribute_RegenStam, int AosAttribute_RegenMana, int AosAttribute_DefendChance, int AosAttribute_AttackChance, int AosAttribute_BonusStr, int AosAttribute_BonusDex, int AosAttribute_BonusInt, int AosAttribute_BonusHits, int AosAttribute_BonusStam, int AosAttribute_BonusMana, int AosAttribute_WeaponDamage, int AosAttribute_WeaponSpeed, int AosAttribute_SpellDamage, int AosAttribute_CastRecovery, int AosAttribute_CastSpeed, int AosAttribute_LowerManaCost, int AosAttribute_LowerRegCost, int AosAttribute_ReflectPhysical, int AosAttribute_EnhancePotions, int AosAttribute_SpellChanneling, int AosAttribute_NightSight, int AosWeaponAttribute_SelfRepair, int AosWeaponAttribute_HitLeechHits, int AosWeaponAttribute_HitLeechStam, int AosWeaponAttribute_HitLeechMana, int AosWeaponAttribute_HitLowerAttack, int AosWeaponAttribute_HitLowerDefend, int AosWeaponAttribute_HitMagicArrow, int AosWeaponAttribute_HitHarm, int AosWeaponAttribute_HitFireball, int AosWeaponAttribute_HitLightning, int AosWeaponAttribute_HitDispel, int AosWeaponAttribute_HitColdArea, int AosWeaponAttribute_HitFireArea, int AosWeaponAttribute_HitPoisonArea, int AosWeaponAttribute_HitEnergyArea, int AosWeaponAttribute_HitPhysicalArea, int AosWeaponAttribute_UseBestSkill, int AosWeaponAttribute_MageWeapon, int AosArmorAttribute_SelfRepair, int AosArmorAttribute_MageArmor )
		{
			if ( item is Runebook )
			{
				Runebook rune = (Runebook)item;
				if ( reduce )
				{
					rune.MaxCharges -= CraftResources.GetWeight( resource );
				}
				else
				{
					rune.MaxCharges += CraftResources.GetWeight( resource );
				}
				if ( rune.MaxCharges < 12 )
					rune.MaxCharges = 12;
			}
			else if ( item is BaseTool )
			{
				BaseTool tool = (BaseTool)item;
				int skill = (int)( CraftResources.GetUses( resource ) / 10 );
				if ( reduce )
				{
					((BaseTool)item).SkillBonuses.SetValues(4, SkillName.Alchemy, 0);
					((BaseTool)item).UsesRemaining -= CraftResources.GetUses( resource );
				}
				else
				{
					((BaseTool)item).SkillBonuses.SetValues(4, tool.CraftSystem.MainSkill, skill);
					((BaseTool)item).UsesRemaining += CraftResources.GetUses( resource );
				}
			}
			else if ( item is BaseHarvestTool )
			{
				BaseHarvestTool tool = (BaseHarvestTool)item;
				int skill = (int)( CraftResources.GetUses( resource ) / 10 );
				if ( reduce )
				{
					((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Alchemy, 0);
					((BaseHarvestTool)item).UsesRemaining -= CraftResources.GetUses( resource );
				}
				else
				{
					if ( tool.HarvestSystem == Fishing.System )
						((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Seafaring, skill);
					else if ( tool.HarvestSystem == Librarian.System )
						((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Inscribe, skill);
					else if ( tool.HarvestSystem == GraveRobbing.System )
						((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Forensics, skill);
					else if ( tool.HarvestSystem == Mining.System )
						((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Mining, skill);
					else 
						((BaseHarvestTool)item).SkillBonuses.SetValues(4, SkillName.Lumberjacking, skill);

					((BaseHarvestTool)item).UsesRemaining += CraftResources.GetUses( resource );
				}
			}
			else if ( item is Spyglass )
			{
				if ( reduce )
				{
					item.LimitsMax = item.Limits = 20;
				}
				else
				{
					item.LimitsMax = item.Limits = 20 + CraftResources.GetXtra( resource );
				}
				item.InfoText1 = "+" + ( 25 + CraftResources.GetXtra( resource ) ) + " Tracking Skill For " + ( 2 + CraftResources.GetXtra( resource ) ) + " Minutes";
			}
			else if ( item is TenFootPole )
			{
				TenFootPole pole = (TenFootPole)item;

				if ( reduce )
				{
					pole.Weight += CraftResources.GetWeight( resource );
					pole.Tap -= CraftResources.GetBonus( resource );
					pole.LimitsMax = pole.Limits = 20;
				}
				else
				{
					pole.Weight -= CraftResources.GetWeight( resource );
					pole.Tap += CraftResources.GetBonus( resource );
					pole.LimitsMax = pole.Limits = 20 + CraftResources.GetUses( resource );
				}
				pole.InfoText1 = "" + pole.Tap + "% Avoiding Traps";
				pole.InfoText2 = "For Wall, Floor & Container Traps";
			}
			else if ( item is MagicRuneBag )
			{
				if ( reduce )
					item.EnchantUsesMax = 200;
				else
					item.EnchantUsesMax = 200 + ( 200 * CraftResources.GetXtra( resource ) );
			}
			else if ( item is HorseArmor )
			{
				HorseArmor horse = (HorseArmor)item;

				if ( reduce )
					horse.ArmorMod -= CraftResources.GetXtra( resource );
				else 
					horse.ArmorMod += CraftResources.GetXtra( resource );

				horse.InfoText1 = "+" + horse.ArmorMod + " Armor";
			}
			else if ( item is BaseWeapon )
			{
				BaseWeapon var = (BaseWeapon)item;

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }

				if ( item is IUsesRemaining )
					if ( reduce ){ ((IUsesRemaining)item).UsesRemaining -= CraftResources.GetUses( resource ); } else { ((IUsesRemaining)item).UsesRemaining += CraftResources.GetUses( resource ); }

				if ( reduce && Slayer2 > 0 ){ var.Slayer2 = SlayerName.None; } else if ( Slayer2 > 0 ){ var.Slayer2 = GetSlayer( Slayer2 ); }
				if ( reduce && Slayer > 0 ){ var.Slayer = SlayerName.None; } else if ( Slayer > 0 ){ var.Slayer = GetSlayer( Slayer ); }

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 ){ var.SkillBonuses.SetValues( 4, var.Skill, Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 ){ var.SkillBonuses.SetValues( 3, var.Skill, Skill4Val ); } else if ( Skill4 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 ){ var.SkillBonuses.SetValues( 2, var.Skill, Skill3Val ); } else if ( Skill3 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 ){ var.SkillBonuses.SetValues( 1, var.Skill, Skill2Val ); } else if ( Skill2 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }

				if ( item is IUsesRemaining )
				{
					int skill = (int)( CraftResources.GetUses( resource ) / 10 );
					if ( reduce )
					{
						((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Alchemy, 0);
					}
					else if ( item is BaseAxe )
					{
						BaseAxe axes = (BaseAxe)item;

						if ( axes.HarvestSystem == GraveRobbing.System )
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Forensics, skill);
						else if ( axes.HarvestSystem == Mining.System )
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Mining, skill);
						else 
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Lumberjacking, skill);
					}
					else if ( item is BasePoleArm )
					{
						BasePoleArm poles = (BasePoleArm)item;

						if ( poles.HarvestSystem == GraveRobbing.System )
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Forensics, skill);
						else if ( poles.HarvestSystem == Mining.System )
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Mining, skill);
						else 
							((BaseWeapon)item).SkillBonuses.SetValues(0, SkillName.Lumberjacking, skill);
					}
				}
				else if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 ){ var.SkillBonuses.SetValues( 0, var.Skill, Skill1Val ); } else if ( Skill1 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce ){ var.WeaponAttributes.SelfRepair -= AosWeaponAttribute_SelfRepair; } else { var.WeaponAttributes.SelfRepair += AosWeaponAttribute_SelfRepair; }
				if ( reduce ){ var.WeaponAttributes.HitLeechHits -= AosWeaponAttribute_HitLeechHits; } else { var.WeaponAttributes.HitLeechHits += AosWeaponAttribute_HitLeechHits; }
				if ( reduce ){ var.WeaponAttributes.HitLeechStam -= AosWeaponAttribute_HitLeechStam; } else { var.WeaponAttributes.HitLeechStam += AosWeaponAttribute_HitLeechStam; }
				if ( reduce ){ var.WeaponAttributes.HitLeechMana -= AosWeaponAttribute_HitLeechMana; } else { var.WeaponAttributes.HitLeechMana += AosWeaponAttribute_HitLeechMana; }
				if ( reduce ){ var.WeaponAttributes.HitLowerAttack -= AosWeaponAttribute_HitLowerAttack; } else { var.WeaponAttributes.HitLowerAttack += AosWeaponAttribute_HitLowerAttack; }
				if ( reduce ){ var.WeaponAttributes.HitLowerDefend -= AosWeaponAttribute_HitLowerDefend; } else { var.WeaponAttributes.HitLowerDefend += AosWeaponAttribute_HitLowerDefend; }
				if ( reduce ){ var.WeaponAttributes.HitMagicArrow -= AosWeaponAttribute_HitMagicArrow; } else { var.WeaponAttributes.HitMagicArrow += AosWeaponAttribute_HitMagicArrow; }
				if ( reduce ){ var.WeaponAttributes.HitHarm -= AosWeaponAttribute_HitHarm; } else { var.WeaponAttributes.HitHarm += AosWeaponAttribute_HitHarm; }
				if ( reduce ){ var.WeaponAttributes.HitFireball -= AosWeaponAttribute_HitFireball; } else { var.WeaponAttributes.HitFireball += AosWeaponAttribute_HitFireball; }
				if ( reduce ){ var.WeaponAttributes.HitLightning -= AosWeaponAttribute_HitLightning; } else { var.WeaponAttributes.HitLightning += AosWeaponAttribute_HitLightning; }
				if ( reduce ){ var.WeaponAttributes.HitDispel -= AosWeaponAttribute_HitDispel; } else { var.WeaponAttributes.HitDispel += AosWeaponAttribute_HitDispel; }
				if ( reduce ){ var.WeaponAttributes.HitColdArea -= AosWeaponAttribute_HitColdArea; } else { var.WeaponAttributes.HitColdArea += AosWeaponAttribute_HitColdArea; }
				if ( reduce ){ var.WeaponAttributes.HitFireArea -= AosWeaponAttribute_HitFireArea; } else { var.WeaponAttributes.HitFireArea += AosWeaponAttribute_HitFireArea; }
				if ( reduce ){ var.WeaponAttributes.HitPoisonArea -= AosWeaponAttribute_HitPoisonArea; } else { var.WeaponAttributes.HitPoisonArea += AosWeaponAttribute_HitPoisonArea; }
				if ( reduce ){ var.WeaponAttributes.HitEnergyArea -= AosWeaponAttribute_HitEnergyArea; } else { var.WeaponAttributes.HitEnergyArea += AosWeaponAttribute_HitEnergyArea; }
				if ( reduce ){ var.WeaponAttributes.HitPhysicalArea -= AosWeaponAttribute_HitPhysicalArea; } else { var.WeaponAttributes.HitPhysicalArea += AosWeaponAttribute_HitPhysicalArea; }
				if ( reduce ){ var.WeaponAttributes.UseBestSkill -= AosWeaponAttribute_UseBestSkill; } else { var.WeaponAttributes.UseBestSkill += AosWeaponAttribute_UseBestSkill; }
				if ( reduce ){ var.WeaponAttributes.MageWeapon -= AosWeaponAttribute_MageWeapon; } else { var.WeaponAttributes.MageWeapon += AosWeaponAttribute_MageWeapon; }
			}
			else if ( item is BaseArmor )
			{
				BaseArmor var = (BaseArmor)item;

				if ( reduce ){ var.ArmorAttributes.SelfRepair -= AosArmorAttribute_SelfRepair; } else { var.ArmorAttributes.SelfRepair += AosArmorAttribute_SelfRepair; }
				if ( reduce ){ var.ArmorAttributes.MageArmor -= AosArmorAttribute_MageArmor; } else { var.ArmorAttributes.MageArmor += AosArmorAttribute_MageArmor; }

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 && item is BaseShield ){ var.SkillBonuses.SetValues( 4, SkillName.Parry, Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 && item is BaseShield ){ var.SkillBonuses.SetValues( 3, SkillName.Parry, Skill4Val ); } else if ( Skill4 > 0 && Skill4 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 && item is BaseShield ){ var.SkillBonuses.SetValues( 2, SkillName.Parry, Skill3Val ); } else if ( Skill3 > 0 && Skill3 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 && item is BaseShield ){ var.SkillBonuses.SetValues( 1, SkillName.Parry, Skill2Val ); } else if ( Skill2 > 0 && Skill2 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 && item is BaseShield ){ var.SkillBonuses.SetValues( 0, SkillName.Parry, Skill1Val ); } else if ( Skill1 > 0 && Skill1 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 && !(item is BaseShield) ){ var.SkillBonuses.SetValues( 4, SkillName.Tactics, Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 && !(item is BaseShield) ){ var.SkillBonuses.SetValues( 3, SkillName.Tactics, Skill4Val ); } else if ( Skill4 > 0 && Skill4 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 && !(item is BaseShield) ){ var.SkillBonuses.SetValues( 2, SkillName.Tactics, Skill3Val ); } else if ( Skill3 > 0 && Skill3 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 && !(item is BaseShield) ){ var.SkillBonuses.SetValues( 1, SkillName.Tactics, Skill2Val ); } else if ( Skill2 > 0 && Skill2 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 && !(item is BaseShield) ){ var.SkillBonuses.SetValues( 0, SkillName.Tactics, Skill1Val ); } else if ( Skill1 > 0 && Skill1 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }

				if ( !reduce && ( item is BoneHelm || item is SavageHelm ) ) // This changes the appearance of the helm if a certain resource is used.
				{
					if (	item.Resource == CraftResource.ReptileSkeletal || 
							item.Resource == CraftResource.GargoyleSkeletal || 
							item.Resource == CraftResource.MinotaurSkeletal || 
							item.Resource == CraftResource.DevilSkeletal || 
							item.Resource == CraftResource.DracoSkeletal || 
							item.Resource == CraftResource.XenoSkeletal || 
							item.Resource == CraftResource.ZabrakSkeletal 
						)
						item.ItemID = 0x1F0B;
					else if ( item is SavageHelm )
						item.ItemID = 0x49C1;
					else
						item.ItemID = 0x1451;
				}
			}
			else if ( item is BaseTrinket )
			{
				BaseTrinket var = (BaseTrinket)item;

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 ){ var.SkillBonuses.SetValues( 4, SkillName.Tactics, Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 ){ var.SkillBonuses.SetValues( 3, SkillName.Tactics, Skill4Val ); } else if ( Skill4 > 0 && Skill4 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 ){ var.SkillBonuses.SetValues( 2, SkillName.Tactics, Skill3Val ); } else if ( Skill3 > 0 && Skill3 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 ){ var.SkillBonuses.SetValues( 1, SkillName.Tactics, Skill2Val ); } else if ( Skill2 > 0 && Skill2 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 ){ var.SkillBonuses.SetValues( 0, SkillName.Tactics, Skill1Val ); } else if ( Skill1 > 0 && Skill1 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }
			}
			else if ( item is Spellbook && !(item is HolyManSpellbook) && !(item is MysticSpellbook) && !(item is SythSpellbook) && !(item is JediSpellbook) )
			{
				Spellbook var = (Spellbook)item;

				int skills = Utility.RandomList( 17, 31, 32, 33 );

				if ( item is NecromancerSpellbook ){ skills = Utility.RandomList( 36, 44, 32, 33 ); }
				else if ( item is SongBook ){ skills = Utility.RandomList( 16, 35, 39, 41 ); }
				else if ( item is ElementalSpellbook ){ skills = Utility.RandomList( 55, 21, 32, 33 ); }
				else if ( item is AncientSpellbook ){ skills = Utility.RandomList( 17, 31, 36, 44, 32, 33 ); }
				else if ( item is BookOfNinjitsu ){ skills = Utility.RandomList( 37, 25, 46, 45, 43, 40 ); }
				else if ( item is BookOfBushido ){ skills = Utility.RandomList( 9, 48, 38, 47 ); }
				else if ( item is BookOfChivalry ){ skills = Utility.RandomList( 13, 48, 38, 47 ); }
				else if ( item is DeathKnightSpellbook ){ skills = Utility.RandomList( 13, 48, 38, 47 ); }

				if ( reduce && Slayer2 > 0 && var.MageryBook() ){ var.Slayer2 = SlayerName.None; } else if ( Slayer2 > 0 && var.MageryBook() ){ var.Slayer2 = GetSlayer( Slayer2 ); }
				if ( reduce && Slayer > 0 && var.MageryBook() ){ var.Slayer = SlayerName.None; } else if ( Slayer > 0 && var.MageryBook() ){ var.Slayer = GetSlayer( Slayer ); }

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 ){ var.SkillBonuses.SetValues( 4, GetSkill( skills ), Skill5Val ); } else if ( Skill5 > 0 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 ){ var.SkillBonuses.SetValues( 3, GetSkill( skills ), Skill4Val ); } else if ( Skill4 > 0 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 ){ var.SkillBonuses.SetValues( 2, GetSkill( skills ), Skill3Val ); } else if ( Skill3 > 0 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 ){ var.SkillBonuses.SetValues( 1, GetSkill( skills ), Skill2Val ); } else if ( Skill2 > 0 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 ){ var.SkillBonuses.SetValues( 0, GetSkill( skills ), Skill1Val ); } else if ( Skill1 > 0 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }
			}
			else if ( item is BaseClothing )
			{
				BaseClothing var = (BaseClothing)item;

				if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 ){ var.SkillBonuses.SetValues( 4, SkillName.Tactics, Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 ){ var.SkillBonuses.SetValues( 3, SkillName.Tactics, Skill4Val ); } else if ( Skill4 > 0 && Skill4 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 ){ var.SkillBonuses.SetValues( 2, SkillName.Tactics, Skill3Val ); } else if ( Skill3 > 0 && Skill3 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 ){ var.SkillBonuses.SetValues( 1, SkillName.Tactics, Skill2Val ); } else if ( Skill2 > 0 && Skill2 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 ){ var.SkillBonuses.SetValues( 0, SkillName.Tactics, Skill1Val ); } else if ( Skill1 > 0 && Skill1 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }
			}
			else if ( item is BaseInstrument )
			{
				BaseInstrument var = (BaseInstrument)item;

				// Saved for musical skill chosen below --- if ( reduce && Skill5 > 0 ){ var.SkillBonuses.SetValues( 4, SkillName.Alchemy, 0 ); } else if ( Skill5 == 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Utility.RandomList( 16, 35, 39, 41 ) ), Skill5Val ); } else if ( Skill5 > 0 && Skill5 < 99 ){ var.SkillBonuses.SetValues(4, GetSkill( Skill5 ), Skill5Val ); }
				if ( reduce && Skill4 > 0 ){ var.SkillBonuses.SetValues( 3, SkillName.Alchemy, 0 ); } else if ( Skill4 == 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Utility.RandomList( 16, 35, 39, 41 ) ), Skill4Val ); } else if ( Skill4 > 0 && Skill4 < 99 ){ var.SkillBonuses.SetValues(3, GetSkill( Skill4 ), Skill4Val ); }
				if ( reduce && Skill3 > 0 ){ var.SkillBonuses.SetValues( 2, SkillName.Alchemy, 0 ); } else if ( Skill3 == 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Utility.RandomList( 16, 35, 39, 41 ) ), Skill3Val ); } else if ( Skill3 > 0 && Skill3 < 99 ){ var.SkillBonuses.SetValues(2, GetSkill( Skill3 ), Skill3Val ); }
				if ( reduce && Skill2 > 0 ){ var.SkillBonuses.SetValues( 1, SkillName.Alchemy, 0 ); } else if ( Skill2 == 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Utility.RandomList( 16, 35, 39, 41 ) ), Skill2Val ); } else if ( Skill2 > 0 && Skill2 < 99 ){ var.SkillBonuses.SetValues(1, GetSkill( Skill2 ), Skill2Val ); }
				if ( reduce && Skill1 > 0 ){ var.SkillBonuses.SetValues( 0, SkillName.Alchemy, 0 ); } else if ( Skill1 == 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Utility.RandomList( 16, 35, 39, 41 ) ), Skill1Val ); } else if ( Skill1 > 0 && Skill1 < 99 ){ var.SkillBonuses.SetValues(0, GetSkill( Skill1 ), Skill1Val ); }

				int skill = (int)( CraftResources.GetUses( resource ) / 10 );
				int focus = Utility.RandomMinMax(1,4);

				if ( reduce )
					((BaseInstrument)item).UsesRemaining -= CraftResources.GetUses( resource );
				else 
					((BaseInstrument)item).UsesRemaining += CraftResources.GetUses( resource );

				if ( reduce )
				{
					((BaseInstrument)item).SkillBonuses.SetValues(4, SkillName.Alchemy, 0);
				}
				else if ( skill > 0 )
				{
					if ( focus == 1 )
						((BaseInstrument)item).SkillBonuses.SetValues(4, SkillName.Musicianship, skill);
					else if ( focus == 2 )
						((BaseInstrument)item).SkillBonuses.SetValues(4, SkillName.Provocation, skill);
					else if ( focus == 3 )
						((BaseInstrument)item).SkillBonuses.SetValues(4, SkillName.Peacemaking, skill);
					else
						((BaseInstrument)item).SkillBonuses.SetValues(4, SkillName.Discordance, skill);
				}

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }
			}
		}

		public static void ModifyJewelry( Item item, GemType resource, bool reduce, int AosAttribute_RegenHits, int AosAttribute_RegenStam, int AosAttribute_RegenMana, int AosAttribute_DefendChance, int AosAttribute_AttackChance, int AosAttribute_BonusStr, int AosAttribute_BonusDex, int AosAttribute_BonusInt, int AosAttribute_BonusHits, int AosAttribute_BonusStam, int AosAttribute_BonusMana, int AosAttribute_WeaponDamage, int AosAttribute_WeaponSpeed, int AosAttribute_SpellDamage, int AosAttribute_CastRecovery, int AosAttribute_CastSpeed, int AosAttribute_LowerManaCost, int AosAttribute_LowerRegCost, int AosAttribute_ReflectPhysical, int AosAttribute_EnhancePotions, int AosAttribute_SpellChanneling, int AosAttribute_NightSight )
		{
			if ( item is BaseTrinket )
			{
				BaseTrinket var = (BaseTrinket)item;

				if ( reduce ){ var.Attributes.RegenHits -= AosAttribute_RegenHits; } else { var.Attributes.RegenHits += AosAttribute_RegenHits; }
				if ( reduce ){ var.Attributes.RegenStam -= AosAttribute_RegenStam; } else { var.Attributes.RegenStam += AosAttribute_RegenStam; }
				if ( reduce ){ var.Attributes.RegenMana -= AosAttribute_RegenMana; } else { var.Attributes.RegenMana += AosAttribute_RegenMana; }
				if ( reduce ){ var.Attributes.DefendChance -= AosAttribute_DefendChance; } else { var.Attributes.DefendChance += AosAttribute_DefendChance; }
				if ( reduce ){ var.Attributes.AttackChance -= AosAttribute_AttackChance; } else { var.Attributes.AttackChance += AosAttribute_AttackChance; }
				if ( reduce ){ var.Attributes.BonusStr -= AosAttribute_BonusStr; } else { var.Attributes.BonusStr += AosAttribute_BonusStr; }
				if ( reduce ){ var.Attributes.BonusDex -= AosAttribute_BonusDex; } else { var.Attributes.BonusDex += AosAttribute_BonusDex; }
				if ( reduce ){ var.Attributes.BonusInt -= AosAttribute_BonusInt; } else { var.Attributes.BonusInt += AosAttribute_BonusInt; }
				if ( reduce ){ var.Attributes.BonusHits -= AosAttribute_BonusHits; } else { var.Attributes.BonusHits += AosAttribute_BonusHits; }
				if ( reduce ){ var.Attributes.BonusStam -= AosAttribute_BonusStam; } else { var.Attributes.BonusStam += AosAttribute_BonusStam; }
				if ( reduce ){ var.Attributes.BonusMana -= AosAttribute_BonusMana; } else { var.Attributes.BonusMana += AosAttribute_BonusMana; }
				if ( reduce ){ var.Attributes.WeaponDamage -= AosAttribute_WeaponDamage; } else { var.Attributes.WeaponDamage += AosAttribute_WeaponDamage; }
				if ( reduce ){ var.Attributes.WeaponSpeed -= AosAttribute_WeaponSpeed; } else { var.Attributes.WeaponSpeed += AosAttribute_WeaponSpeed; }
				if ( reduce ){ var.Attributes.SpellDamage -= AosAttribute_SpellDamage; } else { var.Attributes.SpellDamage += AosAttribute_SpellDamage; }
				if ( reduce ){ var.Attributes.CastRecovery -= AosAttribute_CastRecovery; } else { var.Attributes.CastRecovery += AosAttribute_CastRecovery; }
				if ( reduce ){ var.Attributes.CastSpeed -= AosAttribute_CastSpeed; } else { var.Attributes.CastSpeed += AosAttribute_CastSpeed; }
				if ( reduce ){ var.Attributes.LowerManaCost -= AosAttribute_LowerManaCost; } else { var.Attributes.LowerManaCost += AosAttribute_LowerManaCost; }
				if ( reduce ){ var.Attributes.LowerRegCost -= AosAttribute_LowerRegCost; } else { var.Attributes.LowerRegCost += AosAttribute_LowerRegCost; }
				if ( reduce ){ var.Attributes.ReflectPhysical -= AosAttribute_ReflectPhysical; } else { var.Attributes.ReflectPhysical += AosAttribute_ReflectPhysical; }
				if ( reduce ){ var.Attributes.EnhancePotions -= AosAttribute_EnhancePotions; } else { var.Attributes.EnhancePotions += AosAttribute_EnhancePotions; }
				if ( reduce ){ var.Attributes.SpellChanneling -= AosAttribute_SpellChanneling; } else { var.Attributes.SpellChanneling += AosAttribute_SpellChanneling; }
				if ( reduce ){ var.Attributes.NightSight -= AosAttribute_NightSight; } else { var.Attributes.NightSight += AosAttribute_NightSight; }
			}
		}

		public static void Modify( Item item, bool reduce ) 
		{
			CraftResource resource = SearchResource( item );

			if ( item is BaseTrinket && item.Catalog == Catalogs.Jewelry )
				CraftResources.GetGemMods( ((BaseTrinket)item).GemType, item, reduce );

			CraftResources.GetAosMods( resource, item, reduce );

			if ( item is BaseWeapon ) ////////////// THIS IS A SAFETY CATCH FOR ANY VALUES THAT GO BELOW ZERO ///////////////////////////////////////
			{
				BaseWeapon varr = (BaseWeapon)item;

				if ( varr.WeaponAttributes.LowerStatReq < 0 ){ varr.WeaponAttributes.LowerStatReq = 0; }
				if ( varr.WeaponAttributes.SelfRepair < 0 ){ varr.WeaponAttributes.SelfRepair = 0; }
				if ( varr.WeaponAttributes.HitLeechHits < 0 ){ varr.WeaponAttributes.HitLeechHits = 0; }
				if ( varr.WeaponAttributes.HitLeechStam < 0 ){ varr.WeaponAttributes.HitLeechStam = 0; }
				if ( varr.WeaponAttributes.HitLeechMana < 0 ){ varr.WeaponAttributes.HitLeechMana = 0; }
				if ( varr.WeaponAttributes.HitLowerAttack < 0 ){ varr.WeaponAttributes.HitLowerAttack = 0; }
				if ( varr.WeaponAttributes.HitLowerDefend < 0 ){ varr.WeaponAttributes.HitLowerDefend = 0; }
				if ( varr.WeaponAttributes.HitMagicArrow < 0 ){ varr.WeaponAttributes.HitMagicArrow = 0; }
				if ( varr.WeaponAttributes.HitHarm < 0 ){ varr.WeaponAttributes.HitHarm = 0; }
				if ( varr.WeaponAttributes.HitFireball < 0 ){ varr.WeaponAttributes.HitFireball = 0; }
				if ( varr.WeaponAttributes.HitLightning < 0 ){ varr.WeaponAttributes.HitLightning = 0; }
				if ( varr.WeaponAttributes.HitDispel < 0 ){ varr.WeaponAttributes.HitDispel = 0; }
				if ( varr.WeaponAttributes.HitColdArea < 0 ){ varr.WeaponAttributes.HitColdArea = 0; }
				if ( varr.WeaponAttributes.HitFireArea < 0 ){ varr.WeaponAttributes.HitFireArea = 0; }
				if ( varr.WeaponAttributes.HitPoisonArea < 0 ){ varr.WeaponAttributes.HitPoisonArea = 0; }
				if ( varr.WeaponAttributes.HitEnergyArea < 0 ){ varr.WeaponAttributes.HitEnergyArea = 0; }
				if ( varr.WeaponAttributes.HitPhysicalArea < 0 ){ varr.WeaponAttributes.HitPhysicalArea = 0; }
				if ( varr.WeaponAttributes.ResistPhysicalBonus < 0 ){ varr.WeaponAttributes.ResistPhysicalBonus = 0; }
				if ( varr.WeaponAttributes.ResistFireBonus < 0 ){ varr.WeaponAttributes.ResistFireBonus = 0; }
				if ( varr.WeaponAttributes.ResistColdBonus < 0 ){ varr.WeaponAttributes.ResistColdBonus = 0; }
				if ( varr.WeaponAttributes.ResistPoisonBonus < 0 ){ varr.WeaponAttributes.ResistPoisonBonus = 0; }
				if ( varr.WeaponAttributes.ResistEnergyBonus < 0 ){ varr.WeaponAttributes.ResistEnergyBonus = 0; }
				if ( varr.WeaponAttributes.DurabilityBonus < 0 ){ varr.WeaponAttributes.DurabilityBonus = 0; }
				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
			else if ( item is BaseArmor )
			{
				BaseArmor varr = (BaseArmor)item;

				if ( varr.ArmorAttributes.LowerStatReq < 0 ){ varr.ArmorAttributes.LowerStatReq = 0; }
				if ( varr.ArmorAttributes.SelfRepair < 0 ){ varr.ArmorAttributes.SelfRepair = 0; }
				if ( varr.ArmorAttributes.MageArmor < 0 ){ varr.ArmorAttributes.MageArmor = 0; }
				if ( varr.ArmorAttributes.DurabilityBonus < 0 ){ varr.ArmorAttributes.DurabilityBonus = 0; }
				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
			else if ( item is Spellbook )
			{
				Spellbook varr = (Spellbook)item;

				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
			else if ( item is BaseTrinket )
			{
				BaseTrinket varr = (BaseTrinket)item;

				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
			else if ( item is BaseQuiver )
			{
				BaseQuiver varr = (BaseQuiver)item;

				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
			else if ( item is BaseClothing )
			{
				BaseClothing varr = (BaseClothing)item;

				if ( varr.Attributes.RegenHits < 0 ){ varr.Attributes.RegenHits = 0; }
				if ( varr.Attributes.RegenStam < 0 ){ varr.Attributes.RegenStam = 0; }
				if ( varr.Attributes.RegenMana < 0 ){ varr.Attributes.RegenMana = 0; }
				if ( varr.Attributes.DefendChance < 0 ){ varr.Attributes.DefendChance = 0; }
				if ( varr.Attributes.AttackChance < 0 ){ varr.Attributes.AttackChance = 0; }
				if ( varr.Attributes.BonusStr < 0 ){ varr.Attributes.BonusStr = 0; }
				if ( varr.Attributes.BonusDex < 0 ){ varr.Attributes.BonusDex = 0; }
				if ( varr.Attributes.BonusInt < 0 ){ varr.Attributes.BonusInt = 0; }
				if ( varr.Attributes.BonusHits < 0 ){ varr.Attributes.BonusHits = 0; }
				if ( varr.Attributes.BonusStam < 0 ){ varr.Attributes.BonusStam = 0; }
				if ( varr.Attributes.BonusMana < 0 ){ varr.Attributes.BonusMana = 0; }
				if ( varr.Attributes.WeaponDamage < 0 ){ varr.Attributes.WeaponDamage = 0; }
				if ( varr.Attributes.WeaponSpeed < 0 ){ varr.Attributes.WeaponSpeed = 0; }
				if ( varr.Attributes.SpellDamage < 0 ){ varr.Attributes.SpellDamage = 0; }
				if ( varr.Attributes.CastRecovery < 0 ){ varr.Attributes.CastRecovery = 0; }
				if ( varr.Attributes.CastSpeed < 0 ){ varr.Attributes.CastSpeed = 0; }
				if ( varr.Attributes.LowerManaCost < 0 ){ varr.Attributes.LowerManaCost = 0; }
				if ( varr.Attributes.LowerRegCost < 0 ){ varr.Attributes.LowerRegCost = 0; }
				if ( varr.Attributes.ReflectPhysical < 0 ){ varr.Attributes.ReflectPhysical = 0; }
				if ( varr.Attributes.EnhancePotions < 0 ){ varr.Attributes.EnhancePotions = 0; }
				if ( varr.Attributes.Luck < 0 ){ varr.Attributes.Luck = 0; }
			}
		}

		public static int Rarity( CraftResource resource )
		{
			int check = Utility.Random( 1024 );
            int rarity = 1;
			
			if ( check < 2 ){			rarity = 10;}
			else if ( check < 4 ){		rarity = 9;	}
			else if ( check < 8 ){		rarity = 8;	}
			else if ( check < 16 ){		rarity = 7;	}
			else if ( check < 32 ){		rarity = 6;	}
			else if ( check < 64 ){		rarity = 5;	}
			else if ( check < 128 ){	rarity = 4;	}
			else if ( check < 256 ){	rarity = 3;	}
			else if ( check < 512 ){	rarity = 2;	}
			else {						rarity = 1;	}

            if ( RarityIgnore( resource ) )
                rarity = Utility.RandomMinMax( 1, 10 );

            return rarity;
		}

		public static bool RarityIgnore( CraftResource resource )
		{
			if ( CraftResources.GetType( resource ) == CraftResourceType.Scales )
				return true;
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Block )
				return true;
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Skin )
				return true;

			return false;
		}

		public static int RarityTest( CraftResource resource, bool rarity, int min, int max )
		{
			if ( !rarity )
				return max;

			int xtra = max-min-9;
				if ( xtra > 1 )
					xtra = Utility.Random( xtra );
						if ( xtra < 1 )
							xtra = 0;

			int rare = Rarity( resource ) + xtra;

			if ( rare > max )
				return max;

			if ( rare < min )
				return min;

			return rare;
		}

		public static void SetRandomResource( bool uncommon, bool rarity, Item item, CraftResource resource, bool nonStandard, Mobile from )
		{
			if ( item is BaseBeverage )
				return;

			if ( ResourceMods.RarityIgnore( item.Resource ) )
			{
				uncommon = false;
				nonStandard = false;
				rarity = false;
			}

			if ( uncommon && Utility.Random( 4 ) > 0 )
				return;

			if ( item.NotModAble )
				return;

			int choice = 1;
			int min = 1;
			int max = 1;
			if ( nonStandard )
				min = 2;

			int rare = 10;
				if ( rarity )
					rare = Rarity( item.Resource );

			if ( resource == CraftResource.None )
			{
				Item temp = null;
				try
				{
					temp = (Item)Activator.CreateInstance( item.GetType() );
				}
				catch {}

				if ( temp != null )
				{
					resource = SearchResource( temp );
					temp.Delete();
				}
			}

			if ( resource == CraftResource.None )
				return;

			bool special = false;
				if ( Utility.Random( 10 ) == 0 && rare > 6 )
					special = true;

			if ( from != null && Worlds.isSciFiRegion( from ) )
			{
				if ( CraftResources.GetType( resource ) == CraftResourceType.Fabric )
					resource = CraftResource.RegularLeather;
				else if ( CraftResources.GetType( resource ) == CraftResourceType.Block )
					resource = CraftResource.Iron;
				else if ( CraftResources.GetType( resource ) == CraftResourceType.Scales )
					resource = CraftResource.Iron;
				else if ( CraftResources.GetType( resource ) == CraftResourceType.Skin )
					resource = CraftResource.RegularLeather;

				if ( nonStandard || rare > 9 )
					item.Resource = SciFiResource( resource );
				else
				{
					Item sci = (Item)Activator.CreateInstance( item.GetType() );
					sci.Resource = SciFiResource( sci.Resource );
					item.SubResource = sci.Resource;
					sci.Delete();
				}

				return;
			}

			if ( CraftResources.GetType( resource ) == CraftResourceType.Metal )
			{
				min = min+0;
				max = RarityTest( resource, rarity, min, 10 );
				choice = Utility.RandomMinMax( min, max );
				if ( from != null && rare > 6 && special && Worlds.IsWaterSea( from ) ){ choice = 12; }
				else if ( from != null && rare > 6 && special && from.Land == Land.Serpent ){ choice = 11; }
				else if ( from != null && rare > 7 && special && from.Land == Land.UmberVeil ){ choice = 14; }
				else if ( from != null && rare > 7 && special && from.Land == Land.Savaged ){ choice = 13; }
				else if ( from != null && rare > 7 && special && from.Land == Land.Underworld ){ choice = 15; }

				if ( item.Catalog == Catalogs.Stone )
					choice = Utility.RandomList( 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 15 );
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Leather )
			{
				min = min+15;
				max = RarityTest( resource, rarity, min, 24 );
				choice = Utility.RandomMinMax( min, max );
				if ( from != null && rare > 8 && special && from.Land == Land.Savaged ){ choice = 26; }
				else if ( from != null && rare > 8 && special && Worlds.isHauntedRegion( from ) && Utility.RandomBool() ){ choice = 19; }
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Fabric )
			{
				min = min+26;
				max = RarityTest( resource, rarity, min, 38 );
				choice = Utility.RandomMinMax( min, max );
				if ( from != null && rare > 3 && special && Worlds.isHauntedRegion( from ) && Utility.RandomBool() ){ choice = 31; }
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Scales )
			{
				min = 39;
				max = 51;
				choice = Utility.RandomMinMax( min, max );
					if ( choice == 45 && Utility.RandomBool() )
						choice = Utility.RandomMinMax( min, 44 );
					else if ( choice == 45 )
						choice = Utility.RandomMinMax( 46, 51 );
				if ( from != null && special && from.Land == Land.Savaged ){ choice = 45; }
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Wood )
			{
				min = min+51;
				max = RarityTest( resource, rarity, min, 63 );
				choice = Utility.RandomMinMax( min, max );
				if ( from != null && rare > 7 && special && Worlds.IsWaterSea( from ) ){ choice = 66; }
				else if ( from != null && rare > 7 && special && from.Land == Land.Underworld ){ choice = 65; }
				else if ( from != null && rare > 7 && special && Worlds.isHauntedRegion( from ) && Utility.RandomBool() ){ choice = 64; }
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Block )
			{
				min = 67;
				max = 81;
				choice = Utility.RandomMinMax( min, max );
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Skin )
			{
				min = 82;
				max = 91;
				choice = Utility.RandomMinMax( min, max );
				if ( from != null && special && Worlds.isHauntedRegion( from ) && Utility.RandomBool() ){ choice = 91; }
			}
			else if ( CraftResources.GetType( resource ) == CraftResourceType.Skeletal )
			{
				min = min+91;
				max = RarityTest( resource, rarity, min, 108 );
				choice = Utility.RandomMinMax( min, max );
			}

			switch ( choice ) 
			{
				case 1: SetResource( item, CraftResource.Iron ); break;
				case 2: SetResource( item, CraftResource.DullCopper ); break;
				case 3: SetResource( item, CraftResource.ShadowIron ); break;
				case 4: SetResource( item, CraftResource.Copper ); break;
				case 5: SetResource( item, CraftResource.Bronze ); break;
				case 6: SetResource( item, CraftResource.Gold ); break;
				case 7: SetResource( item, CraftResource.Agapite ); break;
				case 8: SetResource( item, CraftResource.Verite ); break;
				case 9: SetResource( item, CraftResource.Valorite ); break;
				case 10: SetResource( item, CraftResource.Dwarven ); break;
				case 11: SetResource( item, CraftResource.Obsidian ); break;
				case 12: SetResource( item, CraftResource.Nepturite ); break;
				case 13: SetResource( item, CraftResource.Steel ); break;
				case 14: SetResource( item, CraftResource.Brass ); break;
				case 15: SetResource( item, CraftResource.Mithril ); break;

				case 16: SetResource( item, CraftResource.RegularLeather ); break;
				case 17: SetResource( item, CraftResource.HornedLeather ); break;
				case 18: SetResource( item, CraftResource.BarbedLeather ); break;
				case 19: SetResource( item, CraftResource.NecroticLeather ); break;
				case 20: SetResource( item, CraftResource.VolcanicLeather ); break;
				case 21: SetResource( item, CraftResource.FrozenLeather ); break;
				case 22: SetResource( item, CraftResource.GoliathLeather ); break;
				case 23: SetResource( item, CraftResource.DraconicLeather ); break;
				case 24: SetResource( item, CraftResource.HellishLeather ); break;
				case 25: SetResource( item, CraftResource.SpinedLeather ); break;
				case 26: SetResource( item, CraftResource.DinosaurLeather ); break;

				case 27: SetResource( item, CraftResource.Fabric ); break;
				case 28: SetResource( item, CraftResource.FurryFabric ); break;
				case 29: SetResource( item, CraftResource.WoolyFabric ); break;
				case 30: SetResource( item, CraftResource.SilkFabric ); break;
				case 31: SetResource( item, CraftResource.HauntedFabric ); break;
				case 32: SetResource( item, CraftResource.ArcticFabric ); break;
				case 33: SetResource( item, CraftResource.PyreFabric ); break;
				case 34: SetResource( item, CraftResource.VenomousFabric ); break;
				case 35: SetResource( item, CraftResource.MysteriousFabric ); break;
				case 36: SetResource( item, CraftResource.VileFabric ); break;
				case 37: SetResource( item, CraftResource.DivineFabric ); break;
				case 38: SetResource( item, CraftResource.FiendishFabric ); break;

				case 39: SetResource( item, CraftResource.RedScales ); break;
				case 40: SetResource( item, CraftResource.YellowScales ); break;
				case 41: SetResource( item, CraftResource.BlackScales ); break;
				case 42: SetResource( item, CraftResource.GreenScales ); break;
				case 43: SetResource( item, CraftResource.WhiteScales ); break;
				case 44: SetResource( item, CraftResource.BlueScales ); break;
				case 45: SetResource( item, CraftResource.DinosaurScales ); break;
				case 46: SetResource( item, CraftResource.MetallicScales ); break;
				case 47: SetResource( item, CraftResource.BrazenScales ); break;
				case 48: SetResource( item, CraftResource.UmberScales ); break;
				case 49: SetResource( item, CraftResource.VioletScales ); break;
				case 50: SetResource( item, CraftResource.PlatinumScales ); break;
				case 51: SetResource( item, CraftResource.CadalyteScales ); break;

				case 52: SetResource( item, CraftResource.RegularWood ); break;
				case 53: SetResource( item, CraftResource.AshTree ); break;
				case 54: SetResource( item, CraftResource.CherryTree ); break;
				case 55: SetResource( item, CraftResource.EbonyTree ); break;
				case 56: SetResource( item, CraftResource.GoldenOakTree ); break;
				case 57: SetResource( item, CraftResource.HickoryTree ); break;
				case 58: SetResource( item, CraftResource.MahoganyTree ); break;
				case 59: SetResource( item, CraftResource.OakTree ); break;
				case 60: SetResource( item, CraftResource.PineTree ); break;
				case 61: SetResource( item, CraftResource.RosewoodTree ); break;
				case 62: SetResource( item, CraftResource.WalnutTree ); break;
				case 63: SetResource( item, CraftResource.ElvenTree ); break;
				case 64: SetResource( item, CraftResource.GhostTree ); break;
				case 65: SetResource( item, CraftResource.PetrifiedTree ); break;
				case 66: SetResource( item, CraftResource.DriftwoodTree ); break;

				case 67: SetResource( item, CraftResource.AmethystBlock ); break;
				case 68: SetResource( item, CraftResource.EmeraldBlock ); break;
				case 69: SetResource( item, CraftResource.GarnetBlock ); break;
				case 70: SetResource( item, CraftResource.IceBlock ); break;
				case 71: SetResource( item, CraftResource.JadeBlock ); break;
				case 72: SetResource( item, CraftResource.MarbleBlock ); break;
				case 73: SetResource( item, CraftResource.OnyxBlock ); break;
				case 74: SetResource( item, CraftResource.QuartzBlock ); break;
				case 75: SetResource( item, CraftResource.RubyBlock ); break;
				case 76: SetResource( item, CraftResource.SapphireBlock ); break;
				case 77: SetResource( item, CraftResource.SilverBlock ); break;
				case 78: SetResource( item, CraftResource.SpinelBlock ); break;
				case 79: SetResource( item, CraftResource.StarRubyBlock ); break;
				case 80: SetResource( item, CraftResource.TopazBlock ); break;
				case 81: SetResource( item, CraftResource.CaddelliteBlock ); break;

				case 82: SetResource( item, CraftResource.DemonSkin ); break;
				case 83: SetResource( item, CraftResource.DragonSkin ); break;
				case 84: SetResource( item, CraftResource.NightmareSkin ); break;
				case 85: SetResource( item, CraftResource.SnakeSkin ); break;
				case 86: SetResource( item, CraftResource.TrollSkin ); break;
				case 87: SetResource( item, CraftResource.UnicornSkin ); break;
				case 88: SetResource( item, CraftResource.IcySkin ); break;
				case 89: SetResource( item, CraftResource.LavaSkin ); break;
				case 90: SetResource( item, CraftResource.Seaweed ); break;
				case 91: SetResource( item, CraftResource.DeadSkin ); break;

				case 92: SetResource( item, CraftResource.BrittleSkeletal ); break;
				case 93: SetResource( item, CraftResource.DrowSkeletal ); break;
				case 94: SetResource( item, CraftResource.OrcSkeletal ); break;
				case 95: SetResource( item, CraftResource.ReptileSkeletal ); break;
				case 96: SetResource( item, CraftResource.OgreSkeletal ); break;
				case 97: SetResource( item, CraftResource.TrollSkeletal ); break;
				case 98: SetResource( item, CraftResource.GargoyleSkeletal ); break;
				case 99: SetResource( item, CraftResource.MinotaurSkeletal ); break;
				case 100: SetResource( item, CraftResource.LycanSkeletal ); break;
				case 101: SetResource( item, CraftResource.SharkSkeletal ); break;
				case 102: SetResource( item, CraftResource.ColossalSkeletal ); break;
				case 103: SetResource( item, CraftResource.MysticalSkeletal ); break;
				case 104: SetResource( item, CraftResource.VampireSkeletal ); break;
				case 105: SetResource( item, CraftResource.LichSkeletal ); break;
				case 106: SetResource( item, CraftResource.SphinxSkeletal ); break;
				case 107: SetResource( item, CraftResource.DevilSkeletal ); break;
				case 108: SetResource( item, CraftResource.DracoSkeletal ); break;
			}

			if ( Utility.RandomBool() && ( item is BaseWeapon || item is BaseArmor || item is BaseClothing || item is BaseInstrument || ( item is BaseTrinket && item.Catalog == Catalogs.Jewelry ) ) )
			{
				if ( item.Resource == CraftResource.Fabric )
					item.SubResource = ClothResource();
				else if ( item.Resource == CraftResource.Iron )
					item.SubResource = MetalResource();
				else if ( item.Resource == CraftResource.RegularLeather )
					item.SubResource = LeatherResource();
				else if ( item.Resource == CraftResource.RegularWood )
					item.SubResource = WoodResource();
				else if ( item.Resource == CraftResource.BrittleSkeletal )
					item.SubResource = BoneResource();
			}

			DefaultItemHue( item );
		}

		public static CraftResource ClothResource()
		{
			CraftResource resource = CraftResource.FurryFabric;

			int rare = Rarity( resource );
				if ( rare == 10 && Utility.RandomBool() )
					rare = 11;

			switch ( rare ) 
			{
				case 1: resource = CraftResource.FurryFabric; break;
				case 2: resource = CraftResource.WoolyFabric; break;
				case 3: resource = CraftResource.SilkFabric; break;
				case 4: resource = CraftResource.HauntedFabric; break;
				case 5: resource = CraftResource.ArcticFabric; break;
				case 6: resource = CraftResource.PyreFabric; break;
				case 7: resource = CraftResource.VenomousFabric; break;
				case 8: resource = CraftResource.MysteriousFabric; break;
				case 9: resource = CraftResource.VileFabric; break;
				case 10: resource = CraftResource.DivineFabric; break;
				case 11: resource = CraftResource.FiendishFabric; break;
			}

			return resource;
		}

		public static CraftResource MetalResource()
		{
			CraftResource resource = CraftResource.DullCopper;

			int rare = Rarity( resource );
				if ( rare == 10 )
					rare = Utility.RandomMinMax(10,14);

			switch ( rare ) 
			{
				case 1: resource = CraftResource.DullCopper; break;
				case 2: resource = CraftResource.ShadowIron; break;
				case 3: resource = CraftResource.Copper; break;
				case 4: resource = CraftResource.Bronze; break;
				case 5: resource = CraftResource.Gold; break;
				case 6: resource = CraftResource.Agapite; break;
				case 7: resource = CraftResource.Verite; break;
				case 8: resource = CraftResource.Valorite; break;
				case 9: resource = CraftResource.Nepturite; break;
				case 10: resource = CraftResource.Dwarven; break;
				case 11: resource = CraftResource.Obsidian; break;
				case 12: resource = CraftResource.Steel; break;
				case 13: resource = CraftResource.Brass; break;
				case 14: resource = CraftResource.Mithril; break;
			}

			return resource;
		}

		public static CraftResource LeatherResource()
		{
			CraftResource resource = CraftResource.HornedLeather;

			int rare = Rarity( resource );

			switch ( rare ) 
			{
				case 1: resource = CraftResource.HornedLeather; break;
				case 2: resource = CraftResource.BarbedLeather; break;
				case 3: resource = CraftResource.NecroticLeather; break;
				case 4: resource = CraftResource.VolcanicLeather; break;
				case 5: resource = CraftResource.FrozenLeather; break;
				case 6: resource = CraftResource.GoliathLeather; break;
				case 7: resource = CraftResource.DraconicLeather; break;
				case 8: resource = CraftResource.HellishLeather; break;
				case 9: resource = CraftResource.SpinedLeather; break;
				case 10: resource = CraftResource.DinosaurLeather; break;
			}

			return resource;
		}

		public static CraftResource WoodResource()
		{
			CraftResource resource = CraftResource.AshTree;

			int rare = Rarity( resource );
				if ( rare == 10 )
					rare = Utility.RandomMinMax(10,14);

			switch ( rare ) 
			{
				case 1: resource = CraftResource.AshTree; break;
				case 2: resource = CraftResource.CherryTree; break;
				case 3: resource = CraftResource.EbonyTree; break;
				case 4: resource = CraftResource.GoldenOakTree; break;
				case 5: resource = CraftResource.HickoryTree; break;
				case 6: resource = CraftResource.MahoganyTree; break;
				case 7: resource = CraftResource.OakTree; break;
				case 8: resource = CraftResource.PineTree; break;
				case 9: resource = CraftResource.RosewoodTree; break;
				case 10: resource = CraftResource.WalnutTree; break;
				case 11: resource = CraftResource.ElvenTree; break;
				case 12: resource = CraftResource.GhostTree; break;
				case 13: resource = CraftResource.PetrifiedTree; break;
				case 14: resource = CraftResource.DriftwoodTree; break;
			}

			return resource;
		}

		public static CraftResource BoneResource()
		{
			CraftResource resource = CraftResource.DrowSkeletal;

			int rare = Rarity( resource );
				if ( rare == 10 )
					rare = Utility.RandomMinMax(10,16);

			switch ( rare ) 
			{
				case 1: resource = CraftResource.DrowSkeletal; break;
				case 2: resource = CraftResource.OrcSkeletal; break;
				case 3: resource = CraftResource.ReptileSkeletal; break;
				case 4: resource = CraftResource.OgreSkeletal; break;
				case 5: resource = CraftResource.TrollSkeletal; break;
				case 6: resource = CraftResource.GargoyleSkeletal; break;
				case 7: resource = CraftResource.MinotaurSkeletal; break;
				case 8: resource = CraftResource.LycanSkeletal; break;
				case 9: resource = CraftResource.SharkSkeletal; break;
				case 10: resource = CraftResource.ColossalSkeletal; break;
				case 11: resource = CraftResource.MysticalSkeletal; break;
				case 12: resource = CraftResource.VampireSkeletal; break;
				case 13: resource = CraftResource.LichSkeletal; break;
				case 14: resource = CraftResource.SphinxSkeletal; break;
				case 15: resource = CraftResource.DevilSkeletal; break;
				case 16: resource = CraftResource.DracoSkeletal; break;
			}

			return resource;
		}

		public static CraftResource SciFiResource( CraftResource resource )
		{
			CraftResourceType resType = CraftResources.GetType( resource );

			if ( resType == CraftResourceType.Leather || resType == CraftResourceType.Skin || resType == CraftResourceType.Fabric )
			{
				switch ( Utility.RandomMinMax( 1, 12 ) ) 
				{
					case 1:		resource = CraftResource.AlienLeather;			break;
					case 2:		resource = CraftResource.Adesote;				break;
					case 3:		resource = CraftResource.Biomesh;				break;
					case 4:		resource = CraftResource.Cerlin;				break;
					case 5:		resource = CraftResource.Durafiber;				break;
					case 6:		resource = CraftResource.Flexicris;				break;
					case 7:		resource = CraftResource.Hypercloth;			break;
					case 8:		resource = CraftResource.Nylar;					break;
					case 9:		resource = CraftResource.Nylonite;				break;
					case 10:	resource = CraftResource.Polyfiber;				break;
					case 11:	resource = CraftResource.Syncloth;				break;
					case 12:	resource = CraftResource.Thermoweave;			break;
				}
			}
			else if ( resType == CraftResourceType.Metal || resType == CraftResourceType.Block )
			{
				switch ( Utility.RandomMinMax( 1, 16 ) ) 
				{
					case 1:		resource = CraftResource.Agrinium;				break;
					case 2:		resource = CraftResource.Beskar;				break;
					case 3:		resource = CraftResource.Carbonite;				break;
					case 4:		resource = CraftResource.Cortosis;				break;
					case 5:		resource = CraftResource.Durasteel;				break;
					case 6:		resource = CraftResource.Durite;				break;
					case 7:		resource = CraftResource.Farium;				break;
					case 8:		resource = CraftResource.Laminasteel;			break;
					case 9:		resource = CraftResource.Neuranium;				break;
					case 10:	resource = CraftResource.Phrik;					break;
					case 11:	resource = CraftResource.Promethium;			break;
					case 12:	resource = CraftResource.Quadranium;			break;
					case 13:	resource = CraftResource.Songsteel;				break;
					case 14:	resource = CraftResource.Titanium;				break;
					case 15:	resource = CraftResource.Trimantium;			break;
					case 16:	resource = CraftResource.Xonolite;				break;
				}
			}
			else if ( resType == CraftResourceType.Wood )
			{
				switch ( Utility.RandomMinMax( 1, 8 ) ) 
				{
					case 1:		resource = CraftResource.BorlTree;				break;
					case 2:		resource = CraftResource.CosianTree;			break;
					case 3:		resource = CraftResource.GreelTree;				break;
					case 4:		resource = CraftResource.JaporTree;				break;
					case 5:		resource = CraftResource.KyshyyykTree;			break;
					case 6:		resource = CraftResource.LaroonTree;			break;
					case 7:		resource = CraftResource.TeejTree;				break;
					case 8:		resource = CraftResource.VeshokTree;			break;
				}
			}
			else if ( resType == CraftResourceType.Skeletal )
			{
				switch ( Utility.RandomMinMax( 1, 9 ) ) 
				{
					case 1:		resource = CraftResource.XenoSkeletal;			break;
					case 2:		resource = CraftResource.AndorianSkeletal;		break;
					case 3:		resource = CraftResource.CardassianSkeletal;	break;
					case 4:		resource = CraftResource.MartianSkeletal;		break;
					case 5:		resource = CraftResource.RodianSkeletal;		break;
					case 6:		resource = CraftResource.TuskenSkeletal;		break;
					case 7:		resource = CraftResource.TwilekSkeletal;		break;
					case 8:		resource = CraftResource.XindiSkeletal;			break;
					case 9:		resource = CraftResource.ZabrakSkeletal;		break;
				}
			}
			else if ( resType == CraftResourceType.Scales )
			{
				switch ( Utility.RandomMinMax( 1, 4 ) ) 
				{
					case 1:		resource = CraftResource.GornScales;			break;
					case 2:		resource = CraftResource.TrandoshanScales;		break;
					case 3:		resource = CraftResource.SilurianScales;		break;
					case 4:		resource = CraftResource.KraytScales;			break;
				}
			}

			return resource;
		}

		public static Item GetRandomItem( Item item, Mobile from )
		{
			if ( item.Catalog != Catalogs.Crafting )
				return item;

			int choice = 0;

			bool special = false;
				if ( Utility.RandomMinMax( 1, 10 ) == 1 )
					special = true;

			if ( item is BaseIngot ){ choice = Utility.RandomMinMax( 1, 15 ); }
			else if ( item is BaseWoodBoard ){ choice = Utility.RandomMinMax( 159, 170 ); }
			else if ( item is BaseScales ){ choice = Utility.RandomMinMax( 33, 44 ); }
			else if ( item is BaseLeather ){ choice = Utility.RandomMinMax( 46, 54 ); }
			else if ( item is BaseLog ){ choice = Utility.RandomMinMax( 69, 80 ); }
			else if ( item is BaseFabric ){ choice = Utility.RandomMinMax( 84, 95 ); }
			else if ( item is BaseBlocks ){ choice = Utility.RandomMinMax( 96, 110 ); }
			else if ( item is BaseSkins ){ choice = Utility.RandomMinMax( 111, 120 ); }
			else if ( item is BaseSkeletal ){ choice = Utility.RandomMinMax( 121, 137 ); }
			else if ( item is BaseHides ){ choice = Utility.RandomMinMax( 147, 154 ); }
			else if ( item is BaseOre ){ choice = Utility.RandomMinMax( 182, 191 ); }
			else if ( item is BaseGranite ){ choice = Utility.RandomMinMax( 211, 220 ); }

			if ( from != null )
			{
				if ( item is BaseWoodBoard && Worlds.IsWaterSea( from ) && special ){ choice = 173; }
				else if ( item is BaseLog && Worlds.IsWaterSea( from ) && special ){ choice = 83; }
				else if ( item is BaseIngot && Worlds.IsWaterSea( from ) && special ){ choice = 10; }
				else if ( item is BaseOre && Worlds.IsWaterSea( from ) && special ){ choice = 192; }
				else if ( item is BaseGranite && Worlds.IsWaterSea( from ) && special ){ choice = 221; }
				else if ( item is BaseLeather && Worlds.IsWaterSea( from ) && special ){ choice = 55; }
				else if ( item is BaseHides && Worlds.IsWaterSea( from ) && special ){ choice = 156; }
				else if ( item is BaseIngot && from.Land == Land.Serpent && special ){ choice = 11; }
				else if ( item is BaseOre && from.Land == Land.Serpent && special ){ choice = 193; }
				else if ( item is BaseOre && from.Land == Land.Savaged && special ){ choice = 231; }
				else if ( item is BaseOre && from.Land == Land.UmberVeil && special ){ choice = 232; }
				else if ( item is BaseGranite && from.Land == Land.Serpent && special ){ choice = 222; }
				else if ( item is BaseGranite && from.Land == Land.Savaged && special ){ choice = 229; }
				else if ( item is BaseGranite && from.Land == Land.UmberVeil && special ){ choice = 230; }
				else if ( item is BaseIngot && from.Land == Land.UmberVeil && special ){ choice = 13; }
				else if ( item is BaseIngot && from.Land == Land.Savaged && special ){ choice = 12; }
				else if ( item is BaseLeather && from.Land == Land.Savaged && special ){ choice = 56; }
				else if ( item is BaseHides && from.Land == Land.Savaged && special ){ choice = 157; }
				else if ( item is BaseScales && from.Land == Land.Ambrosia && special ){ choice = 45; }
				else if ( item is BaseIngot && !Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 14; }
				else if ( item is BaseOre && !Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 194; }
				else if ( item is BaseGranite && !Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 223; }
				else if ( item is BaseGranite && Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 224; }
				else if ( item is BaseWoodBoard && !Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 172; }
				else if ( item is BaseLog && !Worlds.isSciFiRegion( from ) && from.Land == Land.Underworld && special ){ choice = 82; }

				if ( Worlds.isSciFiRegion( from ) )
				{
					if ( item is BaseIngot || item is BaseOre || item is BaseBlocks ){ choice = Utility.RandomMinMax( 16, 32 ); }
					else if ( item is BaseWoodBoard || item is BaseLog ){ choice = Utility.RandomMinMax( 174, 181 ); }
					else if ( item is BaseHides && Utility.RandomBool() ){ choice = 158; }
					else if ( item is BaseLeather || item is BaseHides || item is BaseFabric || item is BaseSkins ){ choice = Utility.RandomMinMax( 57, 68 ); }
					else if ( item is BaseSkeletal ){ choice = Utility.RandomMinMax( 138, 146 ); }
					else if ( item is BaseScales ){ choice = Utility.RandomMinMax( 225, 228 ); }
					else if ( item is BaseGranite ){ choice = 224; }
				}

				if ( Worlds.isHauntedRegion( from ) && special && Utility.RandomBool() )
				{
					if ( item is BaseWoodBoard ){ choice = 171; }
					else if ( item is BaseLeather ){ choice = 50; }
					else if ( item is BaseLog ){ choice = 81; }
					else if ( item is BaseFabric ){ choice = 88; }
					else if ( item is BaseSkins ){ choice = 120; }
					else if ( item is BaseHides ){ choice = 151; }
				}
			}

			if ( choice > 0 )
				item.Delete();

			switch ( choice ) 
			{
				case 1: item = new IronIngot(); break;
				case 2: item = new DullCopperIngot(); break;
				case 3: item = new ShadowIronIngot(); break;
				case 4: item = new CopperIngot(); break;
				case 5: item = new BronzeIngot(); break;
				case 6: item = new GoldIngot(); break;
				case 7: item = new AgapiteIngot(); break;
				case 8: item = new VeriteIngot(); break;
				case 9: item = new ValoriteIngot(); break;
				case 10: item = new NepturiteIngot(); break;
				case 11: item = new ObsidianIngot(); break;
				case 12: item = new SteelIngot(); break;
				case 13: item = new BrassIngot(); break;
				case 14: item = new MithrilIngot(); break;
				case 15: item = new DwarvenIngot(); break;
				case 16: item = new XormiteIngot(); break;
				case 17: item = new AgriniumIngot(); break;
				case 18: item = new BeskarIngot(); break;
				case 19: item = new CarboniteIngot(); break;
				case 20: item = new CortosisIngot(); break;
				case 21: item = new DurasteelIngot(); break;
				case 22: item = new DuriteIngot(); break;
				case 23: item = new FariumIngot(); break;
				case 24: item = new LaminasteelIngot(); break;
				case 25: item = new NeuraniumIngot(); break;
				case 26: item = new PhrikIngot(); break;
				case 27: item = new PromethiumIngot(); break;
				case 28: item = new QuadraniumIngot(); break;
				case 29: item = new SongsteelIngot(); break;
				case 30: item = new TitaniumIngot(); break;
				case 31: item = new TrimantiumIngot(); break;
				case 32: item = new XonoliteIngot(); break;

				case 33: item = new RedScales(); break;
				case 34: item = new YellowScales(); break;
				case 35: item = new BlackScales(); break;
				case 36: item = new GreenScales(); break;
				case 37: item = new WhiteScales(); break;
				case 38: item = new BlueScales(); break;
				case 39: item = new DinosaurScales(); break;
				case 40: item = new MetallicScales(); break;
				case 41: item = new BrazenScales(); break;
				case 42: item = new UmberScales(); break;
				case 43: item = new VioletScales(); break;
				case 44: item = new PlatinumScales(); break;
				case 45: item = new CadalyteScales(); break;
				case 225: item = new GornScales(); break;
				case 226: item = new TrandoshanScales(); break;
				case 227: item = new SilurianScales(); break;
				case 228: item = new KraytScales(); break;

				case 46: item = new Leather(); break;
				case 47: item = new HornedLeather(); break;
				case 48: item = new BarbedLeather(); break;
				case 49: item = new NecroticLeather(); break;
				case 50: item = new VolcanicLeather(); break;
				case 51: item = new FrozenLeather(); break;
				case 52: item = new GoliathLeather(); break;
				case 53: item = new DraconicLeather(); break;
				case 54: item = new HellishLeather(); break;
				case 55: item = new SpinedLeather(); break;
				case 56: item = new DinosaurLeather(); break;
				case 57: item = new AlienLeather(); break;
				case 58: item = new AdesoteLeather(); break;
				case 59: item = new BiomeshLeather(); break;
				case 60: item = new CerlinLeather(); break;
				case 61: item = new DurafiberLeather(); break;
				case 62: item = new FlexicrisLeather(); break;
				case 63: item = new HyperclothLeather(); break;
				case 64: item = new NylarLeather(); break;
				case 65: item = new NyloniteLeather(); break;
				case 66: item = new PolyfiberLeather(); break;
				case 67: item = new SynclothLeather(); break;
				case 68: item = new ThermoweaveLeather(); break;

				case 69: item = new Log(); break;
				case 70: item = new AshLog(); break;
				case 71: item = new CherryLog(); break;
				case 72: item = new EbonyLog(); break;
				case 73: item = new GoldenOakLog(); break;
				case 74: item = new HickoryLog(); break;
				case 75: item = new MahoganyLog(); break;
				case 76: item = new OakLog(); break;
				case 77: item = new PineLog(); break;
				case 78: item = new RosewoodLog(); break;
				case 79: item = new WalnutLog(); break;
				case 80: item = new ElvenLog(); break;
				case 81: item = new GhostLog(); break;
				case 82: item = new PetrifiedLog(); break;
				case 83: item = new DriftwoodLog(); break;

				case 84: item = new Fabric(); break;
				case 85: item = new FurryFabric(); break;
				case 86: item = new WoolyFabric(); break;
				case 87: item = new SilkFabric(); break;
				case 88: item = new HauntedFabric(); break;
				case 89: item = new ArcticFabric(); break;
				case 90: item = new PyreFabric(); break;
				case 91: item = new VenomousFabric(); break;
				case 92: item = new MysteriousFabric(); break;
				case 93: item = new VileFabric(); break;
				case 94: item = new DivineFabric(); break;
				case 95: item = new FiendishFabric(); break;

				case 96: item = new AmethystBlocks(); break;
				case 97: item = new EmeraldBlocks(); break;
				case 98: item = new GarnetBlocks(); break;
				case 99: item = new IceBlocks(); break;
				case 100: item = new JadeBlocks(); break;
				case 101: item = new MarbleBlocks(); break;
				case 102: item = new OnyxBlocks(); break;
				case 103: item = new QuartzBlocks(); break;
				case 104: item = new RubyBlocks(); break;
				case 105: item = new SapphireBlocks(); break;
				case 106: item = new SilverBlocks(); break;
				case 107: item = new SpinelBlocks(); break;
				case 108: item = new StarRubyBlocks(); break;
				case 109: item = new TopazBlocks(); break;
				case 110: item = new CaddelliteBlocks(); break;

				case 111: item = new DemonSkins(); break;
				case 112: item = new DragonSkins(); break;
				case 113: item = new NightmareSkins(); break;
				case 114: item = new SnakeSkins(); break;
				case 115: item = new TrollSkins(); break;
				case 116: item = new UnicornSkins(); break;
				case 117: item = new IcySkins(); break;
				case 118: item = new LavaSkins(); break;
				case 119: item = new Seaweeds(); break;
				case 120: item = new DeadSkins(); break;

				case 121: item = new BrittleSkeletal(); break;
				case 122: item = new DrowSkeletal(); break;
				case 123: item = new OrcSkeletal(); break;
				case 124: item = new ReptileSkeletal(); break;
				case 125: item = new OgreSkeletal(); break;
				case 126: item = new TrollSkeletal(); break;
				case 127: item = new GargoyleSkeletal(); break;
				case 128: item = new MinotaurSkeletal(); break;
				case 129: item = new LycanSkeletal(); break;
				case 130: item = new SharkSkeletal(); break;
				case 131: item = new ColossalSkeletal(); break;
				case 132: item = new MysticalSkeletal(); break;
				case 133: item = new VampireSkeletal(); break;
				case 134: item = new LichSkeletal(); break;
				case 135: item = new SphinxSkeletal(); break;
				case 136: item = new DevilSkeletal(); break;
				case 137: item = new DracoSkeletal(); break;
				case 138: item = new XenoSkeletal(); break;
				case 139: item = new AndorianSkeletal(); break;
				case 140: item = new CardassianSkeletal(); break;
				case 141: item = new MartianSkeletal(); break;
				case 142: item = new RodianSkeletal(); break;
				case 143: item = new TuskenSkeletal(); break;
				case 144: item = new TwilekSkeletal(); break;
				case 145: item = new XindiSkeletal(); break;
				case 146: item = new ZabrakSkeletal(); break;

				case 147: item = new Hides(); break;
				case 148: item = new HornedHides(); break;
				case 149: item = new BarbedHides(); break;
				case 150: item = new NecroticHides(); break;
				case 151: item = new VolcanicHides(); break;
				case 152: item = new FrozenHides(); break;
				case 153: item = new GoliathHides(); break;
				case 154: item = new DraconicHides(); break;
				case 155: item = new HellishHides(); break;
				case 156: item = new SpinedHides(); break;
				case 157: item = new DinosaurHides(); break;
				case 158: item = new AlienHides(); break;

				case 159: item = new Board(); break;
				case 160: item = new AshBoard(); break;
				case 161: item = new CherryBoard(); break;
				case 162: item = new EbonyBoard(); break;
				case 163: item = new GoldenOakBoard(); break;
				case 164: item = new HickoryBoard(); break;
				case 165: item = new MahoganyBoard(); break;
				case 166: item = new OakBoard(); break;
				case 167: item = new PineBoard(); break;
				case 168: item = new RosewoodBoard(); break;
				case 169: item = new WalnutBoard(); break;
				case 170: item = new ElvenBoard(); break;
				case 171: item = new GhostBoard(); break;
				case 172: item = new PetrifiedBoard(); break;
				case 173: item = new DriftwoodBoard(); break;
				case 174: item = new BorlBoard(); break;
				case 175: item = new CosianBoard(); break;
				case 176: item = new GreelBoard(); break;
				case 177: item = new JaporBoard(); break;
				case 178: item = new KyshyyykBoard(); break;
				case 179: item = new LaroonBoard(); break;
				case 180: item = new TeejBoard(); break;
				case 181: item = new VeshokBoard(); break;

				case 182: item = new IronOre(); break;
				case 183: item = new DullCopperOre(); break;
				case 184: item = new ShadowIronOre(); break;
				case 185: item = new CopperOre(); break;
				case 186: item = new BronzeOre(); break;
				case 187: item = new GoldOre(); break;
				case 188: item = new AgapiteOre(); break;
				case 189: item = new VeriteOre(); break;
				case 190: item = new ValoriteOre(); break;
				case 191: item = new DwarvenOre(); break;
				case 192: item = new NepturiteOre(); break;
				case 193: item = new ObsidianOre(); break;
				case 231: item = new SteelOre(); break;
				case 232: item = new BrassOre(); break;
				case 194: item = new MithrilOre(); break;
				case 195: item = new XormiteOre(); break;
				case 196: item = new AmethystStone(); break;
				case 197: item = new EmeraldStone(); break;
				case 198: item = new GarnetStone(); break;
				case 199: item = new IceStone(); break;
				case 200: item = new JadeStone(); break;
				case 201: item = new MarbleStone(); break;
				case 202: item = new OnyxStone(); break;
				case 203: item = new QuartzStone(); break;
				case 204: item = new RubyStone(); break;
				case 205: item = new SapphireStone(); break;
				case 206: item = new SilverStone(); break;
				case 207: item = new SpinelStone(); break;
				case 208: item = new StarRubyStone(); break;
				case 209: item = new TopazStone(); break;
				case 210: item = new CaddelliteStone(); break;

				case 211: item = new Granite(); break;
				case 212: item = new DullCopperGranite(); break;
				case 213: item = new ShadowIronGranite(); break;
				case 214: item = new CopperGranite(); break;
				case 215: item = new BronzeGranite(); break;
				case 216: item = new GoldGranite(); break;
				case 217: item = new AgapiteGranite(); break;
				case 218: item = new VeriteGranite(); break;
				case 219: item = new ValoriteGranite(); break;
				case 220: item = new DwarvenGranite(); break;
				case 221: item = new NepturiteGranite(); break;
				case 222: item = new ObsidianGranite(); break;
				case 223: item = new MithrilGranite(); break;
				case 224: item = new XormiteGranite(); break;
				case 229: item = new SteelGranite(); break;
				case 230: item = new BrassGranite(); break;
			}

			return item;
		}

		public static int DefaultItemHue( Item item )
		{
			if ( item.Hue == 0 && item.SubResource != CraftResource.None && Item.IsStandardResource( item.Resource ) )
				item.Hue = CraftResources.GetHue( item.SubResource );

			int WoodColor = 0xB61;
			int HideColor = 0xB61;
			int IronColor = 0xB3A;

			if ( item is FishingPole && item.Hue == 0 && item.Resource == CraftResource.RegularWood )
				item.Hue = WoodColor;
			else if ( item is DruidCauldron && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x594;
			else if ( item is WitchCauldron && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x673;
			else if ( item is TomeOfWands && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x846;
			else if ( item is ScribesPen && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x847;
			else if ( item is MapmakersPen && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x84F;
			else if ( item is UndertakerKit && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = WoodColor;
			else if ( item is LeatherworkingTools && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = HideColor;
			else if ( item is MagicRuneBag && item.Hue == 0 && item.Resource == CraftResource.RegularLeather )
				item.Hue = HideColor;
			else if ( item is CulinarySet && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0x99A;
			else if ( item is FletcherTools && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = WoodColor;
			else if ( item is MortarPestle && item.Hue == 0 && item.Resource == CraftResource.Iron )
				item.Hue = 0xAFF;
			else if ( ( item is BaseBook || item is Runebook || item is Spellbook ) && item.Hue == 0 && item.Resource == CraftResource.RegularLeather )
			{
				if ( item is Spellbook && ((Spellbook)item).MageryBook() ){ item.Hue = 0x845; }
				else if ( item is DeathKnightSpellbook ){ item.Hue = 0xB63; }
				else if ( item is NecromancerSpellbook ){ item.Hue = 0x99E; }
				else if ( item is BookOfChivalry ){ item.Hue = 0xB4D; }
				else if ( item is HolyManSpellbook ){ item.Hue = 0x924; }
				else if ( item.ItemID == 0x6713 || item.ItemID == 0x6714 ){ item.Hue = 0xBA3; }
				else if ( item.ItemID == 0x6715 || item.ItemID == 0x6716 ){ item.Hue = 0xB3F; }
				else if ( item.ItemID == 0x6717 || item.ItemID == 0x6718 ){ item.Hue = 0xAFE; }
				else if ( item.ItemID == 0x6719 || item.ItemID == 0x671A ){ item.Hue = 0xB17; }
				else { item.Hue = HideColor; }
			}
			else if ( item is BaseTool )
			{
				if ( item is FletcherTools && item.Resource == CraftResource.Iron ){ item.Hue = HideColor; }
			}
			else if ( item is BaseInstrument )
			{
				if ( ( item is Lute || item is TambourineTassel || item is Tambourine || item is Pipes || item is BambooFlute || item is Harp || item is LapHarp || item is Fiddle || item is Drums ) && item.Hue == 0 && item.Resource == CraftResource.RegularWood )
					item.Hue = WoodColor;
			}
			else if ( item is BaseWeapon )
			{
				BaseWeapon weapon = (BaseWeapon)item;

				if ( 	weapon is GiftPitchfork || 
						weapon is Pitchfork || 
						weapon is BaseGiftStave || 
						weapon is BaseLevelStave || 
						weapon is BaseWizardStaff || 
						weapon is LevelPitchfork )
				{
					if ( weapon.Resource == CraftResource.None )
						weapon.Resource = CraftResource.Iron;

					if ( weapon.Hue == 0 )
						weapon.Hue = IronColor;
				}
				else if ( 	weapon is BaseWhip || 
							weapon is BaseLevelWhip || 
							weapon is BaseGiftWhip  )
				{
					if ( weapon.Resource == CraftResource.None )
						weapon.Resource = CraftResource.RegularLeather;

					if ( weapon.Hue == 0 )
						weapon.Hue = HideColor;
				}

				if ( weapon.Layer == Layer.TwoHanded )
					weapon.NeedsBothHands = true;
			}
			else if ( item is BaseArmor )
			{
				BaseArmor armor = (BaseArmor)item;

				if ( armor.Resource == CraftResource.Iron && item.Hue == 0 && armor is RingmailSkirt ){ armor.Hue = 0xABF; }

				if ( 	armor is LeatherCloak || armor is LeatherNinjaPants || armor is LeatherNinjaJacket || armor is LeatherNinjaHood || 
						armor is LeatherNinjaPants || armor is LevelLeatherNinjaPants || armor is LevelLeatherNinjaJacket || armor is LevelLeatherNinjaHood || 
						armor is GiftLeatherNinjaPants || armor is GiftLeatherNinjaJacket || armor is GiftLeatherNinjaHood || armor is ShinobiRobe || 
						armor is ShinobiHood || armor is ShinobiMask || armor is ShinobiCowl || armor is LeatherSandals || armor is LeatherShoes || 
						armor is LeatherBoots || armor is HikingBoots || armor is LeatherThighBoots || armor is LeatherSoftBoots || armor is LeatherRobe )
				{
					if ( armor.Resource == CraftResource.None && armor.Hue == 0 )
						armor.Resource = CraftResource.RegularLeather;

					if ( armor.Hue == 0 )
						armor.Hue = HideColor;
				}
				else if (	armor is BronzeShield || armor is GiftBronzeShield || armor is LevelBronzeShield || 
							armor is PlateSkirt || armor is RingmailSkirt || armor is ChainSkirt )
				{
					if ( armor.Resource == CraftResource.None )
						armor.Resource = CraftResource.Iron;

					if ( armor.Hue == 0 )
					{
						if ( armor.Resource == CraftResource.Iron && armor is RingmailSkirt ){ armor.Hue = 0xABF; }
						else if ( armor.Resource == CraftResource.Iron ){ armor.Hue = IronColor; }
						else { armor.Hue = CraftResources.GetHue( armor.Resource ); }
					}
				}
			}

			if ( SearchResource( item ) == CraftResource.Iron && item.Hue == 0 && 
				( item.ItemID == 0x1B72 || item.ItemID == 0xE87 || item.ItemID == 0x1C08 || item.ItemID == 0x1C09 || item is GiftStave || item is GiftPitchfork || item is LevelStave || item is LevelPitchfork || item is WizardStaff || item is Pitchfork )
				) // ROUND SHIELD, TRIDENT, PLATE SKIRT, & OTHERS
				item.Hue = IronColor;

			if ( item.Hue < 1 )
			{
				// WOODEN BOXES PARTIAL HUE
				if ( item.ItemID == 0x0E42 || item.ItemID == 0x0E43 || item.ItemID == 0x4C2B || item.ItemID == 0x4C2C || item.ItemID == 0x5718 || item.ItemID == 0x5719 || item.ItemID == 0x571A || item.ItemID == 0x571B || item.ItemID == 0x5752 || item.ItemID == 0x5753 || item.ItemID == 0x1C0E || item.ItemID == 0x1C0F )
					item.Hue = WoodColor;

				// LEATHER BAGS PARTIAL HUE
				if ( item.ItemID == 0x0E76 || item.ItemID == 0x4C53 || item.ItemID == 0x4C54 || item.ItemID == 0x55DD || item.ItemID == 0x5776 || item.ItemID == 0x5777 || item.ItemID == 0x577E || item.ItemID == 0x1248 || item.ItemID == 0x1264 || item.ItemID == 0x1C10 || item.ItemID == 0x1CC6 )
					item.Hue = HideColor;

				if ( item is GiantBag || item is LargeSack || item is BigBag || item is Bag )
					item.Hue = HideColor;

				if ( 	item is PotionKeg || item is SewingKit || item is FletcherTools || item is LeatherworkingTools ||
						item is WoodenChest || item is AdventurerCrate || item is AlchemyCrate || item is ArmsCrate || item is BakerCrate || item is BeekeeperCrate || 
						item is BlacksmithCrate || item is BowyerCrate || item is ButcherCrate || item is CarpenterCrate || item is FletcherCrate || item is HealerCrate || 
						item is HugeCrate || item is JewelerCrate || item is LibrarianCrate || item is MusicianCrate || item is NecromancerCrate || item is ProvisionerCrate || 
						item is SailorCrate || item is StableCrate || item is SupplyCrate || item is TailorCrate || item is TavernCrate || item is TinkerCrate || 
						item is TreasureCrate || item is WizardryCrate || item is SailorShelf ||  item is ColoredArmoireA || item is ColoredArmoireB || item is ColoredCabinetA || 
						item is ColoredCabinetB || item is ColoredCabinetC || item is ColoredCabinetD || item is ColoredCabinetE || item is ColoredCabinetF || 
						item is ColoredCabinetG || item is ColoredCabinetH || item is ColoredCabinetI || item is ColoredCabinetJ || item is ColoredCabinetK || 
						item is ColoredCabinetL || item is ColoredCabinetM || item is ColoredCabinetN || item is ColoredDresserA || item is ColoredDresserB || 
						item is ColoredDresserC || item is ColoredDresserD || item is ColoredDresserE || item is ColoredDresserF || item is ColoredDresserG || 
						item is ColoredDresserH || item is ColoredDresserI || item is ColoredDresserJ || item is ColoredShelf1 || item is ColoredShelf2 || 
						item is ColoredShelf3 || item is ColoredShelf4 || item is ColoredShelf5 || item is ColoredShelf6 || item is ColoredShelf7 || item is ColoredShelf8 || 
						item is ColoredShelfA || item is ColoredShelfB || item is ColoredShelfC || item is ColoredShelfD || item is ColoredShelfE || item is ColoredShelfF || 
						item is ColoredShelfG || item is ColoredShelfH || item is ColoredShelfI || item is ColoredShelfJ || item is ColoredShelfK || item is ColoredShelfL || 
						item is ColoredShelfM || item is ColoredShelfN || item is ColoredShelfO || item is ColoredShelfP || item is ColoredShelfQ || item is ColoredShelfR || 
						item is ColoredShelfS || item is ColoredShelfT || item is ColoredShelfU || item is ColoredShelfV || item is ColoredShelfW || item is ColoredShelfX || 
						item is ColoredShelfY || item is ColoredShelfZ )
				{ item.Hue = WoodColor; }
			}

			return item.Hue;
		}

		public static SlayerName GetSlayer( int var )
		{
			SlayerName slayer = SlayerName.None;
			if ( var == 1 ){ slayer = SlayerName.Silver; }
			else if ( var == 2 ){ slayer = SlayerName.OrcSlaying; }
			else if ( var == 3 ){ slayer = SlayerName.TrollSlaughter; }
			else if ( var == 4 ){ slayer = SlayerName.OgreTrashing; }
			else if ( var == 5 ){ slayer = SlayerName.Repond; }
			else if ( var == 6 ){ slayer = SlayerName.DragonSlaying; }
			else if ( var == 7 ){ slayer = SlayerName.Terathan; }
			else if ( var == 8 ){ slayer = SlayerName.SnakesBane; }
			else if ( var == 9 ){ slayer = SlayerName.LizardmanSlaughter; }
			else if ( var == 10 ){ slayer = SlayerName.ReptilianDeath; }
			else if ( var == 11 ){ slayer = SlayerName.DaemonDismissal; }
			else if ( var == 12 ){ slayer = SlayerName.GargoylesFoe; }
			else if ( var == 13 ){ slayer = SlayerName.BalronDamnation; }
			else if ( var == 14 ){ slayer = SlayerName.Exorcism; }
			else if ( var == 15 ){ slayer = SlayerName.Ophidian; }
			else if ( var == 16 ){ slayer = SlayerName.SpidersDeath; }
			else if ( var == 17 ){ slayer = SlayerName.ScorpionsBane; }
			else if ( var == 18 ){ slayer = SlayerName.ArachnidDoom; }
			else if ( var == 19 ){ slayer = SlayerName.FlameDousing; }
			else if ( var == 20 ){ slayer = SlayerName.WaterDissipation; }
			else if ( var == 21 ){ slayer = SlayerName.Vacuum; }
			else if ( var == 22 ){ slayer = SlayerName.ElementalHealth; }
			else if ( var == 23 ){ slayer = SlayerName.EarthShatter; }
			else if ( var == 24 ){ slayer = SlayerName.BloodDrinking; }
			else if ( var == 25 ){ slayer = SlayerName.SummerWind; }
			else if ( var == 26 ){ slayer = SlayerName.ElementalBan; }
			else if ( var == 27 ){ slayer = SlayerName.WizardSlayer; }
			else if ( var == 28 ){ slayer = SlayerName.AvianHunter; }
			else if ( var == 29 ){ slayer = SlayerName.SlimyScourge; }
			else if ( var == 30 ){ slayer = SlayerName.AnimalHunter; }
			else if ( var == 31 ){ slayer = SlayerName.GiantKiller; }
			else if ( var == 32 ){ slayer = SlayerName.GolemDestruction; }
			else if ( var == 33 ){ slayer = SlayerName.WeedRuin; }
			else if ( var == 34 ){ slayer = SlayerName.NeptunesBane; }
			else if ( var == 35 ){ slayer = SlayerName.Fey; }

			return slayer;
		}

		public static SkillName GetSkill( int var )
		{
			SkillName skill = SkillName.Alchemy;

			if ( var == 1 ){ skill = SkillName.Alchemy; }
			else if ( var == 2 ){ skill = SkillName.Anatomy; }
			else if ( var == 3 ){ skill = SkillName.Druidism; }
			else if ( var == 4 ){ skill = SkillName.Taming; }
			else if ( var == 5 ){ skill = SkillName.Marksmanship; }
			else if ( var == 6 ){ skill = SkillName.ArmsLore; }
			else if ( var == 7 ){ skill = SkillName.Begging; }
			else if ( var == 8 ){ skill = SkillName.Blacksmith; }
			else if ( var == 9 ){ skill = SkillName.Bushido; }
			else if ( var == 10 ){ skill = SkillName.Camping; }
			else if ( var == 11 ){ skill = SkillName.Carpentry; }
			else if ( var == 12 ){ skill = SkillName.Cartography; }
			else if ( var == 13 ){ skill = SkillName.Knightship; }
			else if ( var == 14 ){ skill = SkillName.Cooking; }
			else if ( var == 15 ){ skill = SkillName.Searching; }
			else if ( var == 16 ){ skill = SkillName.Discordance; }
			else if ( var == 17 ){ skill = SkillName.Psychology; }
			else if ( var == 18 ){ skill = SkillName.Fencing; }
			else if ( var == 19 ){ skill = SkillName.Seafaring; }
			else if ( var == 20 ){ skill = SkillName.Bowcraft; }
			else if ( var == 21 ){ skill = SkillName.Focus; }
			else if ( var == 22 ){ skill = SkillName.Forensics; }
			else if ( var == 23 ){ skill = SkillName.Healing; }
			else if ( var == 24 ){ skill = SkillName.Herding; }
			else if ( var == 25 ){ skill = SkillName.Hiding; }
			else if ( var == 26 ){ skill = SkillName.Inscribe; }
			else if ( var == 27 ){ skill = SkillName.Mercantile; }
			else if ( var == 28 ){ skill = SkillName.Lockpicking; }
			else if ( var == 29 ){ skill = SkillName.Lumberjacking; }
			else if ( var == 30 ){ skill = SkillName.Bludgeoning; }
			else if ( var == 31 ){ skill = SkillName.Magery; }
			else if ( var == 32 ){ skill = SkillName.MagicResist; }
			else if ( var == 33 ){ skill = SkillName.Meditation; }
			else if ( var == 34 ){ skill = SkillName.Mining; }
			else if ( var == 35 ){ skill = SkillName.Musicianship; }
			else if ( var == 36 ){ skill = SkillName.Necromancy; }
			else if ( var == 37 ){ skill = SkillName.Ninjitsu; }
			else if ( var == 38 ){ skill = SkillName.Parry; }
			else if ( var == 39 ){ skill = SkillName.Peacemaking; }
			else if ( var == 40 ){ skill = SkillName.Poisoning; }
			else if ( var == 41 ){ skill = SkillName.Provocation; }
			else if ( var == 42 ){ skill = SkillName.RemoveTrap; }
			else if ( var == 43 ){ skill = SkillName.Snooping; }
			else if ( var == 44 ){ skill = SkillName.Spiritualism; }
			else if ( var == 45 ){ skill = SkillName.Stealing; }
			else if ( var == 46 ){ skill = SkillName.Stealth; }
			else if ( var == 47 ){ skill = SkillName.Swords; }
			else if ( var == 48 ){ skill = SkillName.Tactics; }
			else if ( var == 49 ){ skill = SkillName.Tailoring; }
			else if ( var == 50 ){ skill = SkillName.Tasting; }
			else if ( var == 51 ){ skill = SkillName.Tinkering; }
			else if ( var == 52 ){ skill = SkillName.Tracking; }
			else if ( var == 53 ){ skill = SkillName.Veterinary; }
			else if ( var == 54 ){ skill = SkillName.FistFighting; }
			else if ( var == 55 ){ skill = SkillName.Elementalism; }

			return skill;
		}
	}
}