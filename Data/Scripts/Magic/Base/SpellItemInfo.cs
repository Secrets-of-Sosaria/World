using Server;
using System;
using Server.Spells;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using System.Globalization;

namespace Server.Items
{
	public class SpellItemInfo
	{
		private MagicSpell m_MagicSpell;
		private int m_SpellID;
		private Type m_ScrollType;
		private string m_SpellName;
		private string m_Description;
		private string m_Circle;
		private int m_Icon;
		private string m_Runes;

		public MagicSpell MageSpell{ get{ return m_MagicSpell; } }
		public int SpellID{ get{ return m_SpellID; } }
		public Type ScrollType{ get{ return m_ScrollType; } }
		public string SpellName{ get{ return m_SpellName; } }
		public string Description{ get{ return m_Description; } }
		public string Circle{ get{ return m_Circle; } }
		public int Icon{ get{ return m_Icon; } }
		public string Runes{ get{ return m_Runes; } }

		public SpellItemInfo( MagicSpell magic, int id, Type scrollType, string name, string desc, string circle, int icon, string runes )
		{
			m_MagicSpell = magic;
			m_SpellID = id;
			m_ScrollType = scrollType;
			m_SpellName = name;
			m_Description = desc;
			m_Circle = circle;
			m_Icon = icon;
			m_Runes = runes;
		}
	}

	public class SpellItems
	{
		private static SpellItemInfo[] m_MagicInfo = new SpellItemInfo[]																														
		{
			new SpellItemInfo( MagicSpell.None, 0, typeof( BlankScroll ), "", "", "", 0, "" ),
			new SpellItemInfo( MagicSpell.Clumsy, 0, typeof( ClumsyScroll ), "clumsy", "Temporarily reduces Target's Dexterity.", "First", 2240, "Uus Jux" ),
			new SpellItemInfo( MagicSpell.CreateFood, 1, typeof( CreateFoodScroll ), "create food", "Creates random food item in Caster’s backpack.", "First", 2241, "In Mani Ylem" ),
			new SpellItemInfo( MagicSpell.Feeblemind, 2, typeof( FeeblemindScroll ), "feeblemind", "Temporarily reduces Target’s Intelligence.", "First", 2242, "Rel Wis" ),
			new SpellItemInfo( MagicSpell.Heal, 3, typeof( HealScroll ), "heal", "Heals Target of a small amount of lost Hit Points.", "First", 2243, "In Mani" ),
			new SpellItemInfo( MagicSpell.MagicArrow, 4, typeof( MagicArrowScroll ), "magic arrow", "Shoots a magical arrow at Target, which deals Fire damage.", "First", 2244, "In Por Ylem" ),
			new SpellItemInfo( MagicSpell.NightSight, 5, typeof( NightSightScroll ), "night sight", "Temporarily allows Target to see in darkness.", "First", 2245, "In Lor" ),
			new SpellItemInfo( MagicSpell.ReactiveArmor, 6, typeof( ReactiveArmorScroll ), "reactive armor", "Increases the Caster’s Physical Resistance while reducing their Elemental Resistances.  The Caster’s Inscription skill adds a bonus to the amount of Physical Resist applied. Active until spell is deactivated by re-casting the spell on the same Target.", "First", 2246, "Flam Sanct" ),
			new SpellItemInfo( MagicSpell.Weaken, 7, typeof( WeakenScroll ), "weaken", "Temporarily reduces Target’s Strength.", "First", 2247, "Des Mani" ),
			new SpellItemInfo( MagicSpell.Agility, 8, typeof( AgilityScroll ), "agility", "Temporarily increases Target’s Dexterity.", "Second", 2248, "Ex Uus" ),
			new SpellItemInfo( MagicSpell.Cunning, 9, typeof( CunningScroll ), "cunning", "Temporarily increases Target’s Intelligence.", "Second", 2249, "Uus Wis" ),
			new SpellItemInfo( MagicSpell.Cure, 10, typeof( CureScroll ), "cure", "Attempts to neutralize poisons affecting the Target.", "Second", 2250, "An Nox" ),
			new SpellItemInfo( MagicSpell.Harm, 11, typeof( HarmScroll ), "harm", "Affects the Target with a chilling effect, dealing Cold damage.  The closer the Target is to the Caster, the more damage is dealt.", "Second", 2251, "An Mani" ),
			new SpellItemInfo( MagicSpell.MagicTrap, 12, typeof( MagicTrapScroll ), "magic trap", "Places an explosive magic ward on a container that deals Fire damage to the next person to open it. You can also target the ground and place a random trap for the careless.", "Second", 2252, "In Jux" ),
			new SpellItemInfo( MagicSpell.RemoveTrap, 13, typeof( MagicUnTrapScroll ), "magic untrap", "Deactivates a magical trap on a container, or you can cast on yourself to summon an orb of trap detection. item orb would remain in your pack and help you avoid hidden traps.", "Second", 2253, "An Jux" ),
			new SpellItemInfo( MagicSpell.Protection, 14, typeof( ProtectionScroll ), "protection", "Prevents the Target from having their spells disrupted, but lowers their Physical Resistance and Magic Resistance.  Active until the spell is deactivated by recasting on the same Target.", "Second", 2254, "Uus Sanct" ),
			new SpellItemInfo( MagicSpell.Strength, 15, typeof( StrengthScroll ), "strength", "Temporarily increases Target’s Strength.", "Second", 2255, "Uus Mani" ),
			new SpellItemInfo( MagicSpell.Bless, 16, typeof( BlessScroll ), "bless", "Temporarily increases Target’s Strength, Dexterity, and Intelligence.", "Third", 2256, "Rel Sanct" ),
			new SpellItemInfo( MagicSpell.Fireball, 17, typeof( FireballScroll ), "fireball", "Shoots a ball of roiling flames at a Target, dealing Fire damage.", "Third", 2257, "Vas Flam" ),
			new SpellItemInfo( MagicSpell.MagicLock, 18, typeof( MagicLockScroll ), "magic lock", "Magically lock a container or dungeon door, but also lock a creatures soul in an iron flask.", "Third", 2258, "An Por" ),
			new SpellItemInfo( MagicSpell.Poison, 19, typeof( PoisonScroll ), "poison", "The Target is afflicted by poison, of a strength determined by the Caster’s Magery and Poison skills, and the distance from the Target.", "Third", 2259, "In Nox" ),
			new SpellItemInfo( MagicSpell.Telekinesis, 20, typeof( TelekinisisScroll ), "telekinisis", "Allows the Caster to Use an item at a distance. You may also be able to grab smaller objects from a distance and put them in your pack.", "Third", 2260, "Ort Por Ylem" ),
			new SpellItemInfo( MagicSpell.Teleport, 21, typeof( TeleportScroll ), "teleport", "Caster is transported to the Target Location.", "Third", 2261, "Rel Por" ),
			new SpellItemInfo( MagicSpell.Unlock, 22, typeof( UnlockScroll ), "unlock", "Unlocks a magical lock or low level normal lock.", "Third", 2262, "Ex Por" ),
			new SpellItemInfo( MagicSpell.WallOfStone, 23, typeof( WallOfStoneScroll ), "wall of stone", "Creates a temporary wall of stone that blocks movement.", "Third", 2263, "In Sanct Ylem" ),
			new SpellItemInfo( MagicSpell.ArchCure, 24, typeof( ArchCureScroll ), "arch cure", "Neutralizes poisons on all characters within a small radius around the caster.", "Fourth", 2264, "Vas An Nox" ),
			new SpellItemInfo( MagicSpell.ArchProtection, 25, typeof( ArchProtectionScroll ), "arch protection", "Applies the Protection spell to all valid targets within a small radius around the Target Location.", "Fourth", 2265, "Vas Uus Sanct" ),
			new SpellItemInfo( MagicSpell.Curse, 26, typeof( CurseScroll ), "curse", "Lowers the Strength, Dexterity, and Intelligence of the Target. When cast during Player vs. Player combat the spell also reduces the target's maximum resistance values.", "Fourth", 2266, "Des Sanct" ),
			new SpellItemInfo( MagicSpell.FireField, 27, typeof( FireFieldScroll ), "fire field", "Summons a wall of fire that deals Fire damage to all who walk through it", "Fourth", 2267, "In Flam Grav" ),
			new SpellItemInfo( MagicSpell.GreaterHeal, 28, typeof( GreaterHealScroll ), "greater heal", "Heals the target of a medium amount of lost Hit Points.", "Fourth", 2268, "In Vas Mani" ),
			new SpellItemInfo( MagicSpell.Lightning, 29, typeof( LightningScroll ), "lightning", "Strikes the Target with a bolt of lightning, which deals Energy damage.", "Fourth", 2269, "Por Ort Grav" ),
			new SpellItemInfo( MagicSpell.ManaDrain, 30, typeof( ManaDrainScroll ), "mana drain", "Temporarily removes an amount of mana from the Target, based on a comparison between the Caster’s Psychology skill and the Target’s Magic Resistance skill.", "Fourth", 2270, "Ort Rel" ),
			new SpellItemInfo( MagicSpell.Recall, 31, typeof( RecallScroll ), "recall", "Caster is transported to the location marked on the Target rune. If a ship key is target, Caster is transported to the boat the key opens.", "Fourth", 2271, "Kal Ort Por" ),
			new SpellItemInfo( MagicSpell.BladeSpirits, 32, typeof( BladeSpiritsScroll ), "blade spirits", "Summons a whirling pillar of blades that selects a Target to attack based off its combat strength and proximity.  The Blade Spirit disappears after a set amount of time.  Requires 2 pet control slots.", "Fifth", 2272, "In Jux Hur Ylem" ),
			new SpellItemInfo( MagicSpell.DispelField, 33, typeof( DispelFieldScroll ), "dispel field", "Destroys one tile of a target Field spell.", "Fifth", 2273, "An Grav" ),
			new SpellItemInfo( MagicSpell.Incognito, 34, typeof( IncognitoScroll ), "incognito", "Disguises the Caster with a randomly generated appearance and name.", "Fifth", 2274, "Kal In Ex" ),
			new SpellItemInfo( MagicSpell.MagicReflect, 35, typeof( MagicReflectScroll ), "magic reflect", "Causes the magery spells cast at you to be reflected back toward the one who cast it. The better your magery and psychology, the more magic you can reflect back before the spell wears off. You will need a diamond to make item spell work, along with the reagents.", "Fifth", 2275, "In Jux Sanct" ),
			new SpellItemInfo( MagicSpell.MindBlast, 36, typeof( MindBlastScroll ), "mind blast", "Deals Cold damage to the Target based off Caster's Magery and Intelligence.", "Fifth", 2276, "Por Corp Wis" ),
			new SpellItemInfo( MagicSpell.Paralyze, 37, typeof( ParalyzeScroll ), "paralyze", "Immobilizes the Target for a brief amount of time.  The Target’s Magic Resistance skill affects the Duration of the immobilization.", "Fifth", 2277, "An Ex Por" ),
			new SpellItemInfo( MagicSpell.PoisonField, 38, typeof( PoisonFieldScroll ), "poison field", "Conjures a wall of poisonous vapor that poisons anything that walks through it.  The strength of the Poison is based off of the Caster’s Magery and Poison skills.", "Fifth", 2278, "In Nox Grav" ),
			new SpellItemInfo( MagicSpell.SummonCreature, 39, typeof( SummonCreatureScroll ), "summon creature", "Summons a random creature as a Pet for a limited duration.  The strength of the summoned creature is based off of the Caster’s Magery skill.", "Fifth", 2279, "Kal Xen" ),
			new SpellItemInfo( MagicSpell.Dispel, 40, typeof( DispelScroll ), "dispel", "Attempts to Dispel a summoned creature, causing it to disappear from the world. The Dispel difficulty is affected by the Magery skill of the creature’s owner.", "Sixth", 2280, "An Ort" ),
			new SpellItemInfo( MagicSpell.EnergyBolt, 41, typeof( EnergyBoltScroll ), "energy bolt", "Fires a bolt of magical force at the Target, dealing Energy damage.", "Sixth", 2281, "Corp Por" ),
			new SpellItemInfo( MagicSpell.Explosion, 42, typeof( ExplosionScroll ), "explosion", "Strikes the Target with an explosive blast of energy, dealing Fire damage.", "Sixth", 2282, "Vas Ort Flam" ),
			new SpellItemInfo( MagicSpell.Invisibility, 43, typeof( InvisibilityScroll ), "invisibility", "Temporarily causes the Target to become invisible.", "Sixth", 2283, "An Lor Xen" ),
			new SpellItemInfo( MagicSpell.Mark, 44, typeof( MarkScroll ), "mark", "Marks a rune to the Caster’s current Location. There are magic spells and abilities that can be used on the rune to teleport one to the location it is marked with.", "Sixth", 2284, "Kal Por Ylem" ),
			new SpellItemInfo( MagicSpell.MassCurse, 45, typeof( MassCurseScroll ), "mass curse", "Casts the Curse spell on a Target, and any creatures within a two tile radius.", "Sixth", 2285, "Vas Des Sanct" ),
			new SpellItemInfo( MagicSpell.ParalyzeField, 46, typeof( ParalyzeFieldScroll ), "paralyze field", "Conjures a field of paralyzing energy that affects any creature that enters it with the effects of the Paralyze spell.", "Sixth", 2286, "In Ex Grav" ),
			new SpellItemInfo( MagicSpell.Reveal, 47, typeof( RevealScroll ), "reveal", "Reveals the presence of any invisible or hiding creatures or players within a radius around the targeted tile.", "Sixth", 2287, "Wis Quas" ),
			new SpellItemInfo( MagicSpell.ChainLightning, 48, typeof( ChainLightningScroll ), "chain lightning", "Damages nearby targets with a series of lightning bolts that deal Energy damage.", "Seventh", 2288, "Vas Ort Grav" ),
			new SpellItemInfo( MagicSpell.EnergyField, 49, typeof( EnergyFieldScroll ), "energy field", "Conjures a temporary field of energy on the ground at the Target Location that blocks all movement.", "Seventh", 2289, "In Sanct Grav" ),
			new SpellItemInfo( MagicSpell.FlameStrike, 50, typeof( FlamestrikeScroll ), "flamestrike", "Envelopes the target in a column of magical flame the deals Fire damage.", "Seventh", 2290, "Kal Vas Flam" ),
			new SpellItemInfo( MagicSpell.GateTravel, 51, typeof( GateTravelScroll ), "gate travel", "Targeting a rune marked with the Mark spell opens a temporary portal to the rune’s marked location.  The portal can be used by anyone to travel to that location.", "Seventh", 2291, "Vas Rel Por" ),
			new SpellItemInfo( MagicSpell.ManaVampire, 52, typeof( ManaVampireScroll ), "mana vampire", "Drains mana from the Target and transfers it to the Caster. The amount of mana drained is determined by a comparison between the Caster’s Psychology skill and the Target’s Magic Resistance skill.", "Seventh", 2292, "Ort Sanct" ),
			new SpellItemInfo( MagicSpell.MassDispel, 53, typeof( MassDispelScroll ), "mass dispel", "Attempts to dispel any summoned creature within an eight tile radius.", "Seventh", 2293, "Vas An Ort" ),
			new SpellItemInfo( MagicSpell.MeteorSwarm, 54, typeof( MeteorSwarmScroll ), "meteor swarm", "Summons a swarm of fiery meteors that strike all targets within a radius around the Target Location.  The total Fire damage dealt is split between all Targets of the spell.", "Seventh", 2294, "Flam Kal Des Ylem" ),
			new SpellItemInfo( MagicSpell.Polymorph, 55, typeof( PolymorphScroll ), "polymorph", "Temporarily transforms the Caster into a creature selected from a specified list.  While polymorphed, other players will see the Caster as a criminal.", "Seventh", 2295, "Vas Ylem Rel" ),
			new SpellItemInfo( MagicSpell.Earthquake, 56, typeof( EarthquakeScroll ), "earthquake", "Causes a violent shaking of the earth that damages all nearby creatures and characters.", "Eighth", 2296, "In Vas Por" ),
			new SpellItemInfo( MagicSpell.EnergyVortex, 57, typeof( EnergyVortexScroll ), "energy vortex", "Summons a spinning mass of energy that selects a Target to attack based off its intelligence and proximity.  The Energy Vortex disappears after a set amount of time. Requires 2 pet control slots.", "Eighth", 2297, "Vas Corp Por" ),
			new SpellItemInfo( MagicSpell.Resurrection, 58, typeof( ResurrectionScroll ), "resurrection", "Resurrects another or summons a magical item to resurrect yourself at a later time.", "Eighth", 2298, "An Corp" ),
			new SpellItemInfo( MagicSpell.AirElemental, 59, typeof( SummonAirElementalScroll ), "summon air elemental", "An air elemental is summoned to serve the Caster. Requires 2 pet control slots.", "Eighth", 2299, "Kal Vas Xen Hur" ),
			new SpellItemInfo( MagicSpell.SummonDaemon, 60, typeof( SummonDaemonScroll ), "summon daemon", "A daemon is summoned to serve the Caster. Results in a large Karma loss for the Caster. Requires 4 pet control slots.", "Eighth", 2300, "Kal Vas Xen Corp" ),
			new SpellItemInfo( MagicSpell.EarthElemental, 61, typeof( SummonEarthElementalScroll ), "summon earth elemental", "An earth elemental is summoned to serve the caster. Requires 2 pet control slots", "Eighth", 2301, "Kal Vas Xen Ylem" ),
			new SpellItemInfo( MagicSpell.FireElemental, 62, typeof( SummonFireElementalScroll ), "summon fire elemental", "A fire elemental is summoned to serve the caster. Requires 4 pet control slots.", "Eighth", 2302, "Kal Vas Xen Flam" ),
			new SpellItemInfo( MagicSpell.WaterElemental, 63, typeof( SummonWaterElementalScroll ), "summon water elemental", "A water elemental is summoned to serve the caster. Requires 3 pet control slots.", "Eighth", 2303, "Kal Vas Xen An Flam" ),
			new SpellItemInfo( MagicSpell.SummonSnakes, 700, typeof( BlankScroll ), "", "", "", 0, "" ),
			new SpellItemInfo( MagicSpell.SummonDragon, 701, typeof( BlankScroll ), "", "", "", 0, "" ),
			new SpellItemInfo( MagicSpell.SummonSkeleton, 704, typeof( BlankScroll ), "", "", "", 0, "" ),
			new SpellItemInfo( MagicSpell.Identify, 705, typeof( BlankScroll ), "", "", "", 0, "" ),
			new SpellItemInfo( MagicSpell.CurseWeapon, 103, typeof( CurseWeaponScroll ), "curse weapon", "Temporarily imbues a weapon with a life draining effect.", "First", 20483, "An Sanct Grav Corp" ),
			new SpellItemInfo( MagicSpell.BloodOath, 101, typeof( BloodOathScroll ), "blood oath", "Temporarily creates a dark pact between the Caster and the Target. Any damage dealt by the Target to the Caster is increased, but the Target receives the same amount of damage.", "First", 20481, "In Jux Mani Xen" ),
			new SpellItemInfo( MagicSpell.CorpseSkin, 102, typeof( CorpseSkinScroll ), "corpse skin", "Transmogrifies the flesh of the Target creature or player to resemble rotted corpse flesh, making them more vulnerable to Fire and Poison damage, but increasing their Resistance to Physical and Cold damage.", "First", 20482, "In An Corp Ylem" ),
			new SpellItemInfo( MagicSpell.EvilOmen, 104, typeof( EvilOmenScroll ), "evil omen", "Curses the Target so that the next harmful event that affects them is magnified.", "First", 20484, "Por Tym An Sanct" ),
			new SpellItemInfo( MagicSpell.PainSpike, 108, typeof( PainSpikeScroll ), "pain spike", "Temporarily causes intense physical pain to the Target, dealing Direct damage. Once the spell wears off, if the Target is still alive, some of the Hit Points lost through the Pain Spike are restored.", "First", 20488, "In Sanct" ),
			new SpellItemInfo( MagicSpell.WraithForm, 115, typeof( WraithFormScroll ), "wraith form", "Transforms the Caster into an ethereal Wraith, lowering some Elemental Resists, while increasing their Physical resist. Wraith Form also allows the caster to always succeed when using the Recall spell, and causes a Mana Drain effect when hitting enemies. Caster remains in this form until they recast the Wraith Form spell.", "First", 20495, "Rel Xen Uus" ),
			new SpellItemInfo( MagicSpell.MindRot, 107, typeof( MindRotScroll ), "mind rot", "Attempts to place a curse on the Target that increases the mana cost of any spells they cast, for a duration based off a comparison between the Caster’s Spiritualism skill and the Target’s Magic Resistance skill.", "Second", 20487, "Wis An Bet" ),
			new SpellItemInfo( MagicSpell.SummonFamiliar, 111, typeof( SummonFamiliarScroll ), "summon familiar", "Allows the Caster to summon a Familiar from a selected list. A Familiar will follow and fight with its owner, in addition to granting unique bonuses to the Caster, dependent upon the type of Familiar summoned.", "Second", 20491, "Kal Xen Bet" ),
			new SpellItemInfo( MagicSpell.AnimateDead, 100, typeof( AnimateDeadScroll ), "animate dead", "Animates the Targeted corpse, creating a mindless, wandering undead. The strength of the risen undead is greatly modified by the power of the original creature and the power of the necromancer.", "Third", 20480, "Uus Corp" ),
			new SpellItemInfo( MagicSpell.HorrificBeast, 105, typeof( HorrificBeastScroll ), "horrific beast", "Transforms the Caster into a horrific demonic beast, which deals more damage, and recovers hit points faster, but can no longer cast any spells except for Necromancer Transformation spells. Caster remains in this form until they recast the Horrific Beast spell.", "Third", 20485, "Rel Xen Vas Bet" ),
			new SpellItemInfo( MagicSpell.PoisonStrike, 109, typeof( PoisonStrikeScroll ), "poison strike", "Creates a blast of poisonous energy centered on the Target. The main Target is inflicted with a large amount of Poison damage, and all valid Targets in a radius around the main Target are inflicted with a lesser effect.", "Fourth", 20489, "In Vas Nox" ),
			new SpellItemInfo( MagicSpell.Wither, 114, typeof( WitherScroll ), "wither", "Creates a withering frost around the Caster, which deals Cold Damage to all valid targets in a radius.", "Fifth", 20494, "Kal Vas An Flam" ),
			new SpellItemInfo( MagicSpell.Strangle, 110, typeof( StrangleScroll ), "strangle", "Temporarily chokes off the air supply of the Target with poisonous fumes. The Target is inflicted with Poison damage over time. The amount of damage dealt each hit is based off of the Caster’s Spiritualism skill and the Target’s current Stamina.", "Fifth", 20490, "In Bet Nox" ),
			new SpellItemInfo( MagicSpell.LichForm, 106, typeof( LichFormScroll ), "lich form", "Transforms the Caster into a lich, increasing their mana regeneration and some Resistances, while lowering their Fire Resist and slowly sapping their life. Caster remains in this form until they recast the Lich Form spell.", "Sixth", 20486, "Rel Xen Corp Ort" ),
			new SpellItemInfo( MagicSpell.Exorcism, 116, typeof( ExorcismScroll ), "exorcism", "This spell can force the undead to meet the true death, or it can send demonic creatures back to hell. Some may be too powerful for this spell, but many are not.", "Seventh", 20496, "Ort Corp Grav" ),
			new SpellItemInfo( MagicSpell.VengefulSpirit, 113, typeof( VengefulSpiritScroll ), "vengeful spirit", "Summons a vile Spirit which haunts the Target until either the Target or the Spirit is dead. Vengeful Spirits have the ability to track down their Targets wherever they may travel. A Spirit’s strength is determined by the Necromancy and Spiritualism skills of the Caster.", "Seventh", 20493, "Kal Xen Bet Zu" ),
			new SpellItemInfo( MagicSpell.VampiricEmbrace, 112, typeof( VampiricEmbraceScroll ), "vampiric embrace", "Transforms the Caster into a powerful Vampire, which increases his Stamina and Mana regeneration while lowering his Fire Resistance. Vampires also perform Life Drain when striking their enemies. Caster remains in this form until they recast the Vampiric Embrace spell.", "Eighth", 20492, "Rel Xen An Sanct" )
		};

		public static void setSpell( int level, Item item )
		{
			if ( level > 1000 ) // SPECIFIC WAND
			{
				level = level - 1000;
				item.Enchanted = ( MagicSpell )( level );
			}
			else
			{
				if ( level < 1 )
					level = Utility.RandomMinMax(1,8);

				if ( level > 8 )
					level = 8;

				if ( Utility.Random(25) == 0 ) // NECRO WANDS
				{
					int necro = Utility.RandomMinMax( 69, 74 );
					if ( level == 2 )
						necro = Utility.RandomMinMax( 75, 76 );
					else if ( level == 3 )
						necro = Utility.RandomMinMax( 77, 78 );
					else if ( level == 4 )
						necro = 79;
					else if ( level == 5 )
						necro = Utility.RandomMinMax( 80, 81 );
					else if ( level == 6 )
						necro = 82;
					else if ( level == 7 )
						necro = Utility.RandomMinMax( 83, 84 );
					else if ( level == 8 )
						necro = 85;

					item.Enchanted = ( MagicSpell )( necro );

					if ( item is MagicalWand )
					{
						item.ItemID = 0x6729;
						item.Hue = Utility.RandomEvilHue();
					}
				}
				else
					item.Enchanted = ( MagicSpell )( ( ( level * 8 ) - 8 ) + Utility.RandomMinMax( 1, 8 ) );
			}
		}

		public static void Cast( Spell spell, Mobile caster )
		{
			bool m = caster.CantWalk;
			caster.CantWalk = false;
			spell.Cast();
			caster.CantWalk = m;
		}

		public static void ChangeMagicSpell( MagicSpell spell, Item item, bool chargeable )
		{
			if ( spell == MagicSpell.None )
			{
				item.InfoData = null;
				item.InfoText2 = null;
				item.EnchantUsesMax = 0;
				item.EnchantUses = 0;
			}
			else
			{
				int level = SpellItems.GetLevel( (int)spell );
				item.EnchantUsesMax = 90 - ( level * 10 );
				item.EnchantUses = item.EnchantUsesMax;

				if ( !chargeable )
					item.EnchantUsesMax = 0;

				item.InfoData = "This can cast the " + SpellItems.GetName( item.Enchanted ) + " spell. " + SpellItems.GetData( item.Enchanted ) + " It must be equipped to cast spells, where mana is usually required. Once the charges deplete, the magic will be gone. To cast the enchanted spell, single click the item and select 'Magic'.";
			}
		}

		public static void CastEnchantment( Mobile from, Item item )
		{
			int uses = 1;
				if ( item.EnchantMod > 0 )
					uses = item.EnchantMod;

			if ( item.Parent != from )
				from.SendMessage("That must be equipped to use.");
			else if ( item.EnchantUses >= uses )
				SpellItems.Cast( SpellRegistry.NewSpell( GetRegNum( item.Enchanted ), from, item ), from );
			else
				from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
		}

		public static SpellItemInfo GetInfo( MagicSpell magicspell )
		{
			SpellItemInfo[] list = m_MagicInfo;

			int index = GetIndex( magicspell );

			if ( index >= 0 && index < list.Length )
				return list[index];

			return null;
		}

		public static int GetIndex( MagicSpell magicspell )
		{
			if ( magicspell == MagicSpell.None )
				return 0;

			return (int)(magicspell);
		}

		public static int GetRegNum( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			if ( info == null || magicspell == MagicSpell.None )
				return -1;

			return info.SpellID;
		}

		public static string GetCircle( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			if ( info == null )
				return null;

			if ( info.Circle == "" )
				return null;

			return info.Circle + " Circle";
		}

		public static string GetRunes( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			if ( info == null )
				return null;

			if ( info.Runes == "" )
				return null;

			return info.Runes;
		}

		public static int GetIcon( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			if ( info == null )
				return 0;

			if ( info.Icon < 1 )
				return 0;

			return info.Icon;
		}

		public static int GetCircleNumber( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			if ( info == null )
				return 0;

			if ( info.Circle == "" )
				return 0;

			if ( info.Circle == "First" )
				return 3;
			else if ( info.Circle == "Second" )
				return 6;
			else if ( info.Circle == "Third" )
				return 9;
			else if ( info.Circle == "Fourth" )
				return 12;
			else if ( info.Circle == "Fifth" )
				return 15;
			else if ( info.Circle == "Sixth" )
				return 18;
			else if ( info.Circle == "Seventh" )
				return 21;
			else if ( info.Circle == "Eighth" )
				return 24;

			return 0;
		}

		public static string GetData( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			return ( info == null ? null : info.Description );
		}

		public static string GetName( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			return ( info == null ? null : info.SpellName );
		}

		public static string GetNameUpper( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );
			TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

			return ( info == null ? null : cultInfo.ToTitleCase( info.SpellName ) );
		}

		public static Type GetScroll( MagicSpell magicspell )
		{
			SpellItemInfo info = GetInfo( magicspell );

			return ( info == null ? null : info.ScrollType );
		}

		public static MagicSpell GetID( Type itemtype )
		{
			SpellItemInfo[] list = m_MagicInfo;
			int entries = list.Length;
			int val = 0;

			while ( entries > 0 )
			{
				if ( list[val].ScrollType == itemtype )
					entries = 0;
				else
					val++;

				entries--;
			}

			return (MagicSpell)val;
		}

		public static int GetWand( string name )
		{
			SpellItemInfo[] list = m_MagicInfo;
			int entries = list.Length;
			int val = 0;

			while ( entries > 0 )
			{
				if ( list[val].SpellName == name )
					entries = 0;
				else
					val++;

				entries--;
			}

			return 1000+val;
		}

		public static int GetLevel( int level )
		{
			if ( level == 69 )
				level = 1;
			else if ( level == 70 )
				level = 1;
			else if ( level == 71 )
				level = 1;
			else if ( level == 72 )
				level = 1;
			else if ( level == 73 )
				level = 1;
			else if ( level == 74 )
				level = 1;
			else if ( level == 75 )
				level = 2;
			else if ( level == 76 )
				level = 2;
			else if ( level == 77 )
				level = 3;
			else if ( level == 78 )
				level = 3;
			else if ( level == 79 )
				level = 4;
			else if ( level == 80 )
				level = 5;
			else if ( level == 81 )
				level = 5;
			else if ( level == 82 )
				level = 6;
			else if ( level == 83 )
				level = 7;
			else if ( level == 84 )
				level = 7;
			else if ( level == 85 )
				level = 8;
			else if ( level >= 57 )
				level = 8;
			else if ( level >= 49 )
				level = 7;
			else if ( level >= 41 )
				level = 6;
			else if ( level >= 33 )
				level = 5;
			else if ( level >= 25 )
				level = 4;
			else if ( level >= 17 )
				level = 3;
			else if ( level >= 9 )
				level = 2;
			else
				level = 1;

			return level;
		}
	}
}