using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;

namespace Server.Items
{
    public enum EnhanceType
    {
        None,
        Property,
        AosAttribute,
        AosArmorAttribute,
        AosWeaponAttribute,
        AosElementAttribute
    }

    public class AttributeHandler
    {
        public EnhanceType Type = EnhanceType.None;
        public string Name = String.Empty;
        public string Description = String.Empty;
        public int MaxValue = 15;
        public int IncrementValue = 1;
        public int Cost = 1;
        public bool AllowArmor = false;
        public bool AllowWeapon = false;
        public bool AllowJewelry = false;
        public bool AllowSpellbook = false;
        public bool AllowShield = false;
        public bool AllowClothing= false;

        #region Attribute Definitions
        public static List<AttributeHandler> Definitions = new List<AttributeHandler>();

        public static void Initialize()
        {
            bool shield = true;
            bool armor = true;
            bool weapon = true;
            bool jewelry = true;
            bool spellbook = true;
            bool clothing = true;

            // Define Definitions
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "SpellChanneling", "Spell Channeling", 					1, 1, 200,
                !armor, weapon, !jewelry, !spellbook, shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "DefendChance", "Defense Chance Increase", 				15, 1, 10,
                armor, weapon, jewelry, !spellbook, shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "ReflectPhysical", "Reflect Physical Damage", 			50, 1, 2,
                armor, !weapon, !jewelry, !spellbook, shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "AttackChance", "Hit Chance Increase", 					15, 1, 10,
                armor, weapon, jewelry, !spellbook, shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosArmorAttribute, "LowerStatReq", "Lower Requirements", 				100, 1, 2,
                armor, !weapon, !jewelry, !spellbook, shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "LowerStatReq", "Lower Requirements", 				100, 1, 2,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosArmorAttribute, "SelfRepair", "Self Repair", 						5, 1, 100,
                armor, !weapon, !jewelry, !spellbook, shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosArmorAttribute, "MageArmor", "Mage Armor",							1, 1, 200,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "RegenHits", "Hit Point Regeneration", 					5, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "RegenStam", "Stamina Regeneration", 					5, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "RegenMana", "Mana Regeneration", 						5, 1, 5,
                armor, !weapon, !jewelry, spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "NightSight", "Night Sight",								1, 1, 6,
                armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusHits", "Hit Point Increase", 						20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusStam", "Stamina Increase", 						20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusMana", "Mana Increase", 							20, 1, 5,
                armor, !weapon, !jewelry, spellbook, !shield, clothing));
			if ( MyServerSettings.LowerMana() > 0 )
			{
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "LowerManaCost", "Lower Mana Cost", 						MyServerSettings.LowMana(), 1, 5,
                armor, !weapon, jewelry, spellbook, !shield, clothing));
			}
			if ( MyServerSettings.LowerReg() > 0 )
			{
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "LowerRegCost", "Lower Reagent Cost", 					MyServerSettings.LowReg(), 1, 5,
                armor, !weapon, jewelry, spellbook, !shield, clothing));
			}
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "Luck", "Luck", 											500, 1, 2,
                armor, weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.Property, "PhysicalBonus", "Physical Resist", 							20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.Property, "FireBonus", "Fire Resist", 									20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.Property, "ColdBonus", "Cold Resist", 									20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.Property, "PoisonBonus", "Poison Resist", 								20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.Property, "EnergyBonus", "Energy Resist", 								20, 1, 5,
                armor, !weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitPhysicalArea", "Hit Physical Area", 			50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitFireArea", "Hit Fire Area", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitColdArea", "Hit Cold Area", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitPoisonArea", "Hit Poison Area",				50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitEnergyArea", "Hit Energy Area", 				50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitMagicArrow", "Hit Magic Arrow", 				50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitHarm", "Hit Harm", 							50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitFireball", "Hit Fireball", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLightning", "Hit Lightning", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "UseBestSkill", "Use Best Weapon Skill", 			1, 1, 10,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "MageWeapon", "Mage Weapon", 						1, 1, 5,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "WeaponDamage", "Damage Increase", 						50, 1, 5,
                !armor, weapon, jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "WeaponSpeed", "Swing Speed Inrease", 					40, 1, 6,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitDispel", "Hit Dispel", 						50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLeechHits", "Hit Life Leech", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLowerAttack", "Hit Lower Attack", 				50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLowerDefend", "Hit Lower Defense", 			50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLeechMana", "Hit Mana Leech", 					50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosWeaponAttribute, "HitLeechStam", "Hit Stamina Leech", 				50, 1, 3,
                !armor, weapon, !jewelry, !spellbook, !shield, !clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosElementAttribute, "Physical", "Physical Resist", 					20, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosElementAttribute, "Fire", "Fire Resist", 							20, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosElementAttribute, "Cold", "Cold Resist", 							20, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosElementAttribute, "Poison", "Poison Resist", 						20, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosElementAttribute, "Energy", "Energy Resist", 						20, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusStr", "Strength Bonus", 							10, 1, 10,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusDex", "Dexterity Bonus", 							10, 1, 10,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "BonusInt", "Intelligence Bonus", 						10, 1, 10,
                !armor, !weapon, jewelry, spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "EnhancePotions", "Enhance Potions", 					25, 1, 2,
                !armor, !weapon, jewelry, !spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "CastSpeed", "Faster Casting", 							20, 1, 4,
                !armor, !weapon, jewelry, spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "CastRecovery", "Faster Cast Recovery", 					20, 1, 4,
                !armor, !weapon, jewelry, spellbook, !shield, clothing));
            Definitions.Add(new AttributeHandler(EnhanceType.AosAttribute, "SpellDamage", "Spell Damage Increase", 					24, 1, 4,
                !armor, !weapon, jewelry, spellbook, !shield, clothing));

        }
        #endregion

        public AttributeHandler(EnhanceType type, string name, string description, int maxValue, int incrementValue, int cost, bool armor, bool weapon, bool jewelry, bool spellbook, bool shield, bool clothing)
        {
            Type = type;
            Name = name;
            Description = description;
            MaxValue = maxValue;
            IncrementValue = incrementValue;
			Cost = cost;
            AllowArmor = armor;
            AllowWeapon = weapon;
            AllowJewelry = jewelry;
            AllowSpellbook = spellbook;
            AllowShield = shield;
            AllowClothing = clothing;
        }

        #region IsUpgradable
        public bool IsUpgradable(Item itemToTest)
        {
            bool allowed = false;

			if ( itemToTest is BaseShield || itemToTest is BaseArmor || itemToTest is BaseTrinket || itemToTest is Spellbook || itemToTest is BaseClothing || itemToTest is BaseWeapon )
				allowed = true;

			if ( itemToTest.Resource == CraftResource.None )
				allowed = false;
			else if ( itemToTest.ArtifactLevel > 0 )
				allowed = false;
			else if ( itemToTest.NotModAble )
				allowed = false;
			else if ( itemToTest is BaseShield && !AllowShield )
				allowed = false;
			else if ( itemToTest is BaseArmor && !AllowArmor )
				allowed = false;
			else if ( itemToTest is BaseTrinket && !AllowJewelry )
				allowed = false;
			else if ( itemToTest is Spellbook && !AllowSpellbook )
				allowed = false;
			else if ( itemToTest is BaseClothing && !AllowClothing )
				allowed = false;
            else if (itemToTest is BaseWeapon)
            {
                BaseWeapon weapon = (BaseWeapon)itemToTest;

                if (Name == "UseBestSkill" && weapon.WeaponAttributes.MageWeapon > 0)
                    allowed = false;

                if (Name == "MageWeapon" && weapon.WeaponAttributes.UseBestSkill > 0)
                    allowed = false;

                if (Name == "HitPhysicalArea" && (weapon.WeaponAttributes.HitFireArea > 0 || weapon.WeaponAttributes.HitColdArea > 0 || weapon.WeaponAttributes.HitPoisonArea > 0 || weapon.WeaponAttributes.HitEnergyArea > 0))
                    allowed = false;

                if (Name == "HitFireArea" && (weapon.WeaponAttributes.HitPhysicalArea > 0 || weapon.WeaponAttributes.HitColdArea > 0 || weapon.WeaponAttributes.HitPoisonArea > 0 || weapon.WeaponAttributes.HitEnergyArea > 0))
                    allowed = false;

                if (Name == "HitColdArea" && (weapon.WeaponAttributes.HitFireArea > 0 || weapon.WeaponAttributes.HitPhysicalArea > 0 || weapon.WeaponAttributes.HitPoisonArea > 0 || weapon.WeaponAttributes.HitEnergyArea > 0))
                    allowed = false;

                if (Name == "HitPoisonArea" && (weapon.WeaponAttributes.HitFireArea > 0 || weapon.WeaponAttributes.HitColdArea > 0 || weapon.WeaponAttributes.HitPhysicalArea > 0 || weapon.WeaponAttributes.HitEnergyArea > 0))
                    allowed = false;

                if (Name == "HitEnergyArea" && (weapon.WeaponAttributes.HitFireArea > 0 || weapon.WeaponAttributes.HitColdArea > 0 || weapon.WeaponAttributes.HitPoisonArea > 0 || weapon.WeaponAttributes.HitPhysicalArea > 0))
                    allowed = false;

                if (Name == "HitMagicArrow" && (weapon.WeaponAttributes.HitHarm > 0 || weapon.WeaponAttributes.HitFireball > 0 || weapon.WeaponAttributes.HitLightning > 0))
                    allowed = false;

                if (Name == "HitHarm" && (weapon.WeaponAttributes.HitMagicArrow > 0 || weapon.WeaponAttributes.HitFireball > 0 || weapon.WeaponAttributes.HitLightning > 0))
                    allowed = false;

                if (Name == "HitFireball" && (weapon.WeaponAttributes.HitHarm > 0 || weapon.WeaponAttributes.HitMagicArrow > 0 || weapon.WeaponAttributes.HitLightning > 0))
                    allowed = false;

                if (Name == "HitLightning" && (weapon.WeaponAttributes.HitHarm > 0 || weapon.WeaponAttributes.HitFireball > 0 || weapon.WeaponAttributes.HitMagicArrow > 0))
                    allowed = false;

                if ( !AllowWeapon )
                    allowed = false;
            }

            if (allowed)
            {
                int currentValue = Upgrade( itemToTest, true );

                if  (currentValue == MaxValue )
                    allowed = false;
            }

            return allowed;
        }
        #endregion

        #region Upgrade
        public int Upgrade(Item itemToEnhance, bool reportCurrentValueOnly)
        {
            int value = (reportCurrentValueOnly ? 0 : IncrementValue);

            switch (Type)
            {
                case EnhanceType.None:
                    {
                        return -1;
                    }
                case EnhanceType.AosAttribute:
                    {
                        int val = 0;
                        AosAttribute attr = (AosAttribute)Enum.Parse(typeof(AosAttribute), Name);

                        if (itemToEnhance is BaseShield)
                        {
                            val = ((BaseShield)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseShield)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseArmor)
                        {
                            val = ((BaseArmor)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseArmor)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseWeapon)
                        {
                            val = ((BaseWeapon)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseWeapon)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseTrinket)
                        {
                            val = ((BaseTrinket)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseTrinket)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseClothing)
                        {
                            val = ((BaseClothing)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseClothing)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is Spellbook)
                        {
                            val = ((Spellbook)itemToEnhance).Attributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((Spellbook)itemToEnhance).Attributes.SetValue((int)attr, val);
                        }

                        return val;
                    }
                case EnhanceType.AosArmorAttribute:
                    {
                        int val = 0;
                        AosArmorAttribute attr = (AosArmorAttribute)Enum.Parse(typeof(AosArmorAttribute), Name);

                        if (itemToEnhance is BaseShield)
                        {
                            val = ((BaseShield)itemToEnhance).ArmorAttributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseShield)itemToEnhance).ArmorAttributes.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseArmor)
                        {
                            val = ((BaseArmor)itemToEnhance).ArmorAttributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseArmor)itemToEnhance).ArmorAttributes.SetValue((int)attr, val);
                        }

                        return val;
                    }
                case EnhanceType.AosElementAttribute:
                    {
                        int val = 0;
                        AosElementAttribute attr = (AosElementAttribute)Enum.Parse(typeof(AosElementAttribute), Name);

                        if (itemToEnhance is BaseTrinket)
                        {
                            val = ((BaseTrinket)itemToEnhance).Resistances.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseTrinket)itemToEnhance).Resistances.SetValue((int)attr, val);
                        }
                        else if (itemToEnhance is BaseClothing)
                        {
                            val = ((BaseClothing)itemToEnhance).Resistances.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseClothing)itemToEnhance).Resistances.SetValue((int)attr, val);
                        }

                        return val;
                    }
                case EnhanceType.AosWeaponAttribute:
                    {
                        int val = 0;
                        AosWeaponAttribute attr = (AosWeaponAttribute)Enum.Parse(typeof(AosWeaponAttribute), Name);

                        if (itemToEnhance is BaseWeapon)
                        {
                            val = ((BaseWeapon)itemToEnhance).WeaponAttributes.GetValue((int)attr) + value;

                            if (val > MaxValue)
                                val = MaxValue;

                            ((BaseWeapon)itemToEnhance).WeaponAttributes.SetValue((int)attr, val);
                        }

                        return val;
                    }
                case EnhanceType.Property:
                    {
                        int val = 0;

                        if (itemToEnhance is BaseArmor)
                        {
                            BaseArmor armor = (BaseArmor)itemToEnhance;

                            switch (Name)
                            {
                                case "PhysicalBonus":
                                    val = armor.PhysicalBonus + value;

                                    if (val > MaxValue)
                                        val = MaxValue;

                                    armor.PhysicalBonus = val;
                                    break;
                                case "FireBonus":
                                    val = armor.FireBonus + value;

                                    if (val > MaxValue)
                                        val = MaxValue;

                                    armor.FireBonus = val;
                                    break;
                                case "ColdBonus":
                                    val = armor.ColdBonus + value;

                                    if (val > MaxValue)
                                        val = MaxValue;

                                    armor.ColdBonus = val;
                                    break;
                                case "PoisonBonus":
                                    val = armor.PoisonBonus + value;

                                    if (val > MaxValue)
                                        val = MaxValue;

                                    armor.PoisonBonus = val;
                                    break;
                                case "EnergyBonus":
                                    val = armor.EnergyBonus + value;

                                    if (val > MaxValue)
                                        val = MaxValue;

                                    armor.EnergyBonus = val;
                                    break;
                            }
                        }

                        return val;
                    }
            }

            return 0;
        }
        #endregion
    }
}