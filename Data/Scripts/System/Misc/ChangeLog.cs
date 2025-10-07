using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Targeting;
using System.Collections.Generic;
using Server.Items;
using Server.Spells.Fifth;
using System.IO;
using System.Xml;

namespace Server.Misc
{
    class ChangeLog
    {
		public static string Version()
		{
			return "Version: Sacrifice (7 October 2025)";
		}

		public static string Versions()
        {
			string versionTEXT = ""

       
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        + "Sacrifice - 7 October 2025<br>"

        + "<br>"

        + "New Features & Quality of Life<br>"
        + "* Defenders of the Realm & The Scourge Rise!<br>"
        + "    - Two new questlines have appeared in Sosaria:<br>"
        + "        • The Defenders of the Realm call upon heroes of Virtue to bring tribute from powerful foes.<br>"
        + "        • The Scourge of the Realm seeks champions of darkness to do the same — but for more sinister ends.<br>"
        + "    - Positive karma adventurers will find their patron in Britain, while darker souls will find theirs at Stonewall Inn.<br>"
        + "    - Completing a Vow and returning it to your patron earns new rewards — including new currencies:<br>"
        + "        • Marks of Honor (for heroes) or Marks of the Scourge (for villains).<br>"
        + "    - Say “rewards” near your patron to view all available prizes — dyes, mounts, artifacts, and more.<br>"
        + "    - 12 new artifacts have been added exclusively for this system.<br>"
        + "    - Marks can also rarely drop from powerful enemies.<br>"
        + "* Hard Mode Dungeons:<br>"
        + "    - Server owners can now enable 'Hard Mode,' dramatically increasing dungeon spawn rates. Not for the faint of heart.<br>"
        + "* Quiver Autoloading:<br>"
        + "    - Quivers now have a context menu option to automatically refill from your pack.<br>"
        + "* Boating & the Seas:<br>"
        + "    - Added smooth sailing: boats are faster and smoother to pilot.<br>"
        + "    - 4 new pirate-themed artifacts have been added to the global drop pool.<br>"
        + "* Tracking Buff:<br>"
        + "    - Hunters now deal up to +15% bonus damage (at 125 skill) to their tracked prey.<br>"
        + "* Fugitives can now join the Necromancer’s Guild.<br>"
        + "* New Setting: S_ArtifactEnchantment — controls whether artifacts have enchantment points (default: false).<br>"
        + "* Bags of Holding can now be used more frequently.<br>"
        + "* Potions of Rebirth and Soul Orbs now resurrect players much faster.<br>"
        + "* Herding Buffs:<br>"
        + "    - After feeding your pet once, you now have a chance to bond it through Herding skill when gaining skill.<br>"
        + "    - Higher Herding = better bonding odds.<br>"
        + "    - Also reduces the chance of your future pet becoming violent while taming.<br>"
        + "* Dagger of Venom: Now properly scales with Poisoning skill when applying poison on hit.<br>"
        + "* Carsomyr, the Holy Sword: Formerly “Holy Sword.” Now renamed and empowered to *Smite Evil* for virtuous knights.<br>"
        + "* Contraband Rewards Update: Thieves Guildmaster now rewards contraband turn-ins with enchanted items instead of junk.<br>"
        + "<br>"

        + "Balance Changes<br>"
        + "* Items:<br>"
        + "    - Artifact Normalization: All artifacts now grant around 300 enchantment points. Expect smoother progression.<br>"
        + "    - Golden Feather Blessings: No longer enchant items (per Harpy Union requests).<br>"
        + "    - Lucky Horseshoes: Max effectiveness reduced to 500 (from 1000). Luck bonus now varies 25–125 instead of a flat 100.<br>"
        + "    - Crafting Material Rebalance:<br>"
        + "        • Removed random low-value junk properties in favor of focused, thematic bonuses.<br>"
        + "        • Easier to find materials that complement enhancements.<br>"
        + "        • Damage bonuses reduced — Dwarven weapons remain strong, but no longer dominate all crafted gear.<br>"
        + "        • Quest altar crafts significantly buffed.<br>"
        + "    - Treasure Hoards: More diverse loot, no more useless random gems.<br>"
        + "    - Item Drops: Reduced the number of random properties to improve clarity when sorting loot.<br>"
        + "    - Alien Raw Materials: Price reduced across the board.<br>"
        + "    - Weapon Crafting: Weapons no longer provide resistances from crafting material.<br>"
        + "    - Magic Wands: Now roll with less extreme properties for better balance.<br>"
        + "    - Alchemists and Herbalists now sell jars.<br>"
        + "    - Harpoon:<br>"
        + "        • 3rd ability changed to Dexterity Drain (was Moving Shot).<br>"
        + "        • 5th ability changed to Armor Ignore (was Infectious Strike).<br>"
        + "<br>"
        + "* Gameplay:<br>"
        + "    - Trap Survival: Adventurers can now survive deadly traps based on Remove Trap skill.<br>"
        + "    - Pack Animals: Carrying capacity reduced from 65,000 stones (!) to 6,500.<br>"
        + "    - Smarter Spellcasters: Enemies use stronger spells more often and won’t break invisibility immediately.<br>"
        + "    - Sage Quests: Cheap scam contracts removed. Standard quest now costs 10k gold and has 75% accuracy (up from 70%).<br>"
        + "    - Vendors: Restock every hour (was every 2 hours).<br>"
        + "    - Veterinary Supplies: Cooldown reduced by 2 seconds.<br>"
        + "    - Boss Drops: Adjusted enchantment intensity — very high-end enchants reduced from 500 → 300.<br>"
        + "    - Gem Drops: Regular dragons drop fewer gems (8 → 4). High-end dragons drop more (5 → 8).<br>"
        + "<br>"
        + "* Skills:<br>"
        + "    - Mercantile: Reduced effectiveness — less of a money printer.<br>"
        + "    - Hiding: Added 5-second cooldown to prevent abuse.<br>"
        + "    - Inscription: Crafting scrolls for Mages, Necromancers, and Elementalists now costs 1/3 the previous mana.<br>"
        + "<br>"

        + "Bug Fixes<br>"
        + "* Sanctuary can now be cast from within dungeon dwellings.<br>"
        + "* Owned creatures no longer lose loyalty when their masters log out.<br>"
        + "* 'Pack lobsters' are now a distinct item rather than a pack bear variant.<br>"
        + "* Merchant crates correctly detect crafted items and reject raw resources.<br>"
        + "* Fixed a bug that allowed buying dungeon stealables from the Sage.<br>"
        + "* Artifact enchantment window now only lists Spell Channeling for weapons.<br>"
        + "* Players can no longer drop unbound items on Shinobi Scrolls or crash the server doing so.<br>"
        + "* Assassin Guildmaster now removes murder counts for non-guild members.<br>"
        + "* Fixed broken image reference on Vendor Management screen.<br>"
        + "* Fixed spawn points for Serpents of Order/Chaos quests.<br>"
        + "* Grandmaster Mage/Necromancer ethereal mount is now more visible.<br>"
        + "* Xormite Elementals are now properly composed of Xormite instead of Caddlellite.<br>"
        + "* Fishing SoS no longer drops multiple artifacts at once.<br>"
        + "* Fist Fighting correctly counts for 'Use Best Skill' weapons.<br>"
        + "* [loot command no longer bypasses traps to loot inside chests.<br>"
        + "* Crafting multiple items now respects stat gain delay settings.<br>"
        + "* [showskillgainchance no longer displays gain chances for locked or capped skills.<br>"
        + "<br>"

        + sepLine()

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Spirituality - 20 July 2025<br>"

				+ "<br>"

				+ "New Features & Quality of Life<br>"
				+ "* Veterinarian Kits: Added new kits purchasable from farmers and veterinarians. When used, they attempt to heal all nearby tamed pets.<br>"
				+ "* Enhancement Stones: Replaced sharpening stones. They now work for *any* weapon, not just swordsmanship weapons.<br>"
				+ "* Stealing: Thieves can now steal while wielding a weapon. Thieves no longer steal random items from an npc inventory, instead, they steal an amount of gold based on the target's fame. There's a 1 minute cooldown between stealing attempts.<br>"
				+ "* Contraband System for Thieves guild members: Thieves can now occasionally acquire *contraband boxes* while stealing from non-tamed, non-summoned npc enemies. These can be turned in to the Thieves Guildmaster for rewards once per hour. Rarity is based on the target’s fame.<br>"
				+ "* Library Search: Players can now search the library page by author's name, book title, or lorebook contents. (Thanks Erika!)<br>"
				+ "* Vendor Gold Handling: Vendors can now draw gold from a player's bank if not enough is present in the backpack. They will use both sources if needed.<br>"
				+ "* Bulk Sale Bank Checks: When selling more than 20,000 gold worth of goods to an NPC, players will receive a bank check instead of gold.<br>"
				+ "* Spellcasting Flavor: NPCs now say mantras when casting spells.<br>"
				+ "* Ranger Maps: These maps are no longer deleted if used without first unlocking the corresponding world.<br>"
				+ "* Henchman Dialogue: Added additional banter lines for henchmen.<br>"
				+ "* Strange Liquids & Alcohol: Characters will now sip strange liquids instead of guzzling entire kegs, following Sosarian Alcoholics Anonymous’ PSA campaign.<br>"
				+ "* Container Identification: Players can now use Arms Lore, Mercantile, or Tasting on containers in their backpack to identify all applicable items inside.<br>"
				+ "* Skill Gump Improvements:<br>"
				+ "    - Meditation skill added to the list.<br>"
				+ "    - Inscription entry updated to clarify it increases magery spell damage.<br>"
				+ "* Double Shot Description: Now more clearly explains what the ability does.<br>"
				+ "* Ninjitsu Animal Form Gump: Now displays required skill levels for each form.<br>"
				+ "* ShowSkillGainChance: Players can now toggle the skill gain chance on and off in their journal using a command.<br>"
				+ "* Ethereal scrolls: Ethereal scrolls now have a confirmation gump on use.<br>"
				+ "* Ethereal and eternal scrolls: now have a visual effect when used, similar to the old power scrolls.<br>"
				+ "* Added player footstep sounds.<br>"
				+ "* Added the [organizepotions command to automatically few an alchemist's belt pouch.<br>"
				+ "* Added the [checksecure command to notify a player of items that might disappear if left unatended.<br>"
				+ "* There's now an overhead warning when a Xorn eats your coins.<br>"
				+ "* Oilcloth can now be used to remove disguises.<br>"
        + "* Added a message explaining that a player needs cooking tools to prepare raw meat.<br>"
        + "* Added a setting to adjust the frequency of random city visitors<br>"
				+ "<br>"
				+ "Balance Changes<br>"
				+ "* Rare Skins: Reduced prices across the board.<br>"
				+ "* Trapdoors: Now spawn in randomized levels based on searching skill rather than fixed tiers.<br>"
				+ "* Summon Dispel Resistance: Greatly reduced the base chance that a summoned creature will be dispelled when hit.<br>"
				+ "* Animal Trainer Lords:<br>"
				+ "    - 1-hour cooldown added between pet sales.<br>"
				+ "    - Base sale value reduced by one-third.<br>"
				+ "    - Rare item values from Taming BoDs rebalanced.<br>"
				+ "    - A message now shows remaining time until another sale or BoD is available.<br>"
				+ "* Scaled Shields: Removed from global loot drops (still craftable).<br>"
				+ "* Ancient Pyramid: Third floor now includes additional monster spawns.<br>"
				+ "* Newbie Dungeon Challenge Rooms: Each newbie dungeon now has one slightly tougher room.<br>"
				+ "* Dungeon Adventurers: Small chance to encounter NPC adventurers while exploring Sosarian dungeons.<br>"
				+ "* Class Balance:<br>"
				+ "    - Death Knight & Priest spell costs halved.<br>"
				+ "    - Tithing point gain from enemy kills (while wearing class item) roughly doubled.<br>"
				+ "* Animate Dead Spell: Now summons more powerful minions for skilled necromancers.<br>"
				+ "* Docking Lanterns: No longer considered rare drops.<br>"
				+ "* Pedestal boxes: The reward calculation has been changed. These boxes no longer award silver/copper, and the chance of additional loot is entirely dependent on a character's luck. The S_PedStealThrottle setting was removed and made redundant.<br>"
				+ "* Paralyze durations are now based on a character's magic resist skill (and monster fame). Minimum duration is 2 seconds, maximum is 8. The S_paralyzeDuration is no longer needed and has been removed.<br>"
        + "* Added level-based damage scaling to legendary weapons. Non-jedi Weapons get up to 75% increased base damage at level cap.<br>"
        + "* Merchants no longer steal your items when they do not have enough gold to pay for all of them.<br>"
				+ "<br>"
				+ "Bug Fixes<br>"
				+ "* Archery Buttes: Now correctly consume arrows from quivers.<br>"
				+ "* Taming/Herding Exploits: Players no longer gain skill from commanding henchmen or summons. System messages are also suppressed if no tamed pet is present.<br>"
				+ "* Sailor Death Crash: Fixed a potential server crash when a sailor is killed by a player.<br>"
				+ "* Pack Mule Loyalty: Loyalty no longer drops while the player is logged out.<br>"
				+ "* Citizen Purchase Crash: Fixed a server crash caused by repeated purchase attempts from citizens.<br>"
				+ "* NPC Spellcasting: NPCs no longer fail spells due to missing reagents.<br>"
				+ "* Monster Boot Speed: Gift and level hiking boots now correctly apply speed bonuses.<br>"
				+ "* Noble Sacrifice Crash: Fixed a server crash when casting Noble Sacrifice near living players.<br>"
				+ "* Fixed various spelling errors.<br>"
				+ "* The chest in the inn room now properly closes when a player moves.<br>"
				+ "* Elementalist's soul orb now checks if the players inventory is full before attempting to add an item to it.<br>"
				+ "* Magical flasks of water are now properly destroyed when dumped into the floor.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Honesty - 19 April 2025<br>"

				+ "<br>"
				+ "* Added Ethereal and Eternal power scrolls to the game.<br>"
				+ "   - They can be found as endgame loot.<br>"
				+ "* Fixed a bug related to creatures remaining aggressive after being tamed.<br>"
				+ "* Now containers with items inside cannot be broken down via crafting window.<br>"
				+ "* Added 5 missing power scrolls and rebalanced their cost.<br>"
				+ "* Added starting equipment for new characters based on their chosen skills.<br>"
				+ "   - Mages will start with their spellbooks.<br>"
				+ "   - Crafters with related tools.<br>"
				+ "   - Archers with bows and so on.<br>"
				+ "* Shovels can now be used to dig for treasure directly from the backpack.<br>"
				+ "* Holy priest mallets can now be bought at priests.<br>"
				+ "   - The requirement to unlock the class has been lowered.<br>"
				+ "* Scale armor no longer drops.<br>"
				+ "   - It can still be crafted.<br>"
				+ "* Cooldown of the acid proof robe has been reduced from 2 hours to 30 minutes for generating acid bottles.<br>"
				+ "   - Those bottles can also be used when the robe is not being worn.<br>"
				+ "* The ability Force of Nature now scales damage out of Druidism instead of Spiritualism.<br>"
				+ "* Peacemaking used by monsters now has its duration dependent on the monster barding skill.<br>"
				+ "* Added a confirmation gump to the artifact selection from the sage book.<br>"
				+ "* Pelvis bones can now be polished.<br>"
				+ "* Undertaker kits can now be crafted by tinkers.<br>"
				+ "* Fixed a bug with the [e whistle command.<br>"
				+ "* Fixed incorrect text on the magic reflection spell.<br>"
				+ "* Zombie lords now have much lower health and do much more damage.<br>"
				+ "* Fixed a bug that caused unwanted taming/herding gains.<br>"
				+ "* Corrected the spawn locations for the animal broker.<br>"
				+ "* Added 31 new taming-related artifacts to the game.<br>"
				+ "   - They can be found via random drop and sage quest.<br>"
				+ "* Added missing potions to the druidic herbalism book.<br>"
				+ "* Added missing potions to the witch book.<br>"
				+ "* Fixed the description of the treant potion from druidic herbalism.<br>"
				+ "* Made hunger/thirst influence skill gain slightly.<br>"
				+ "   - Well fed characters will have faster gains.<br>"
				+ "   - Hungry/thirsty characters will have slower gains.<br>"
				+ "* Allows for the crafting gump to be used while the cooldown for multicraft is still ongoing.<br>"
				+ "* Increased the cooldown on bandaging pets slightly.<br>"
				+ "* Using 'dotnet build' now outputs to system dir.<br>"
				+ "* The warnings for Skara Brae and Kuldar are now on by default in the server settings.<br>"
				+ "* Added many new messages that are displayed during taming attempts.<br>"
				+ "* Added a small chance that an adventurer found in the wilds will have a rare item on their bag.<br>"
				+ "   - It can be stolen or taken if the adventurer is murdered.<br>"
				+ "* Added missing harvest tool logic.<br>"
				+ "<br>"

				+ sepLine()
				
				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Justice - 11 March 2025<br>"

				+ "<br>"
				+ "* Fixed a hole in the mountain at the Corrupt Pass.<br>"
				+ "* Updated documentation for death stat and skill loss settings to clarify they do not affect alien characters.<br>"
				+ "* Fixed a bug where the Noble Sacrifice spell was attempting to resurrect horses, causing server crashes.<br>"
				+ "* Added a new setting, S_DeathStatAndSkillLoss, to adjust stat and skill loss upon death when not resurrecting at a healer. The loss ranges from 1% to 10% of current stats and skills, defaulting to 5%.<br>"
				+ "* Fixed door and sign positions for certain houses.<br>"
				+ "* Introduced a small chance for skill gains when using a tamed pet in combat, with adjustable cooldown and player notifications. Pets may also occasionally display battlecries.<br>"
				+ "* Made additional follow slots configurable.<br>"
				+ "* Implemented a check to prevent resource loss when dropping items onto a shoppe, ensuring the quantity does not exceed the remaining space.<br>"
				+ "* Resolved an issue with obtaining Tailoring BODs due to conflicts with the new leatherworking system in Secrets of Sosaria.<br>"
				+ "* Restored the ability to use basic crafting and harvesting tools from the backpack without equipping them, with optional settings.<br>"
				+ "* Added spell channeling to the default item properties of wizard staffs to correct sale price issues.<br>"
				+ "* Fixed a crash that occurred when using Herbal Healing potions on out-of-range followers.<br>"
				+ "* Updated tamed animal/follower behavior to prevent directional glitches when using 'all stop' and to limit roaming to 5 spaces from their home.<br>"
				+ "* Added gift and levelable hiking boots for monster characters, obtainable from gift item chests and the artifact book with the titan.<br>"
				+ "* Improved skill point limit configuration, allowing server admins to control the maximum skill points for a single character through a single setting.<br>"
				+ "* Fixed height display on the enhancement gump.<br>"
				+ "* Rebalanced stealable boxes to adjust gold amounts and added a skill check for poisoning to benefit expert poisoners.<br>"
				+ "* Updated the `S_PedStealThrottle` setting to control artifact acquisition from boxes and removed the artificial time gate for stealing.<br>"
				+ "* Adjusted skill gain rate and food check settings.<br>"
				+ "* Allow worlds with only pre-built classic houses to still change the house sign type.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Compassion - 02 December 2024<br>"

				+ "<br>"
				+ "* Balanced loot from treasure hunting chests found by cartographers.<br>"
				+ "* Added pet broker spawns and the taming BOD system (ported from Ultima Adventures, thanks!).<br>"
				+ "* Fixed a bug with the spawner for the serpents of chaos and order.<br>"
				+ "* Increased the chances of random notes and citizen rumors being true.<br>"
				+ "* Fixed the spawn location for the quest pedestal in the Sanctum of Saltmarsh.<br>"
				+ "* Added missing fabric drops to various creatures.<br>"
				+ "* Fixed issues with spell channeling for staves and scepters.<br>"
				+ "* Added a toggle to settings to control restrictions on marking and recalling.<br>"
				+ "* Added a toggle to settings to restrict skill bonuses from items to the character skill cap.<br>"
				+ "* Fixed an issue where repair and durability potions were not working on clothing.<br>"
				+ "* Added bank vaults to banker NPCs, available for a large price.<br>"
				+ "* Added base clothing to the list of items that repair and durability potions can affect.<br>"
				+ "* Fixed an issue where bard songs could crash the world.<br>"
				+ "* Performed a grammar and spelling pass on skill descriptions.<br>"
				+ "* Renamed 'bedrool' to 'bedroll.'<br>"
				+ "* Fixed an issue with the elemental steed when rebuilding the world.<br>"
				+ "* Fixed a crash that occurred when fishing up certain items.<br>"
				+ "* Fixed the skill range issue for candelabras.<br>"
				+ "* Removed young player checks for level 0 chests.<br>"
				+ "* Players can now decode simply drawn treasure maps with a minimum skill of 0.0.<br>"
				+ "* Made it possible to remove a flaming skill from a house.<br>"
				+ "* Fixed an issue where small BODs were generated by mistake.<br>"
				+ "* Removed single- and double-bladed laser swords from regular loot.<br>"
				+ "* Fixed an issue with maximum poison charges.<br>"
				+ "* Fixed an issue where fugitives were not being recognized as evil.<br>"
				+ "* Added skill-based poisoning charge limits and weapon coating.<br>"
				+ "* Added an index to settings.cs to improve navigation.<br>"
				+ "* Rebalanced stealing coffers.<br>"
				+ "* Fixed an issue that made it impossible for a mage to create the Staff of Five Parts.<br>"
				+ "* Corrected the name of the Nox Ranger's light crossbow.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Honor - 02 November 2024<br>"

				+ "<br>"
				+ "* Fixed a bug with text on rare anvils.<br>"
				+ "* Added checks for maximum password length.<br>"
				+ "* Fixed bone types on all lich creates.<br>"
				+ "* Corrected text in the golden ranger's book.<br>"
				+ "* Improved writing in syth power descriptions.<br>"
				+ "* Corrected writing in skill descriptions.<br>"
				+ "* Tillerman now uses the gender neutral captain rather than sir.<br>"
				+ "* Bards can now also undress men.<br>"
				+ "* Locations in blue ore book fixed.<br>"
				+ "* Skill requirements for skinning creatures fixed.<br>"
				+ "* Paralyze duration from monsters made configurable.<br>"
				+ "* Great axe now called Executioner axe for consistency.<br>"
				+ "* Magic skeleton key made minor artifact.<br>"
				+ "* Karma traps now give a penalty rather than reversing karma.<br>"
				+ "* Fix trap door duping bug.<br>"
				+ "<br>"
				
				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Valor - 20 October 2024<br>"

				+ "<br>"
				+ "* Fixed a bug when using arms lore and item disappears.<br>"
				+ "* Monster players now have proper starting gold.<br>"
				+ "* Fixed crash when monsters would loot elemental or mystic spellbook.<br>"
				+ "* Fixed a bug in resource rarity calculation.<br>"
				+ "* Fixed a bug in range check.<br>"
				+ "* Added message when harvesting dwarven resources.<br>"
				+ "* Added missing tile to list of mineable tiles.<br>"
				+ "* Added caps in information display.<br>"
				+ "* Fixed drop rate of gender change potion.<br>"
				+ "* Added Frankenstein's journal back as loot.<br>"
				+ "* Fixed issue with books not being added to the library.<br>"
				+ "* Fixed mongbat spawner in Devil's guard.<br>"
				+ "<br>"
				
				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Secrets of Sosaria - 29 September 2024<br>"

				+ "<br>"
				+ "<strong>New Branch called Secrets of Sosaria</strong>"
				+ "<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
				+ "Samurai - 25 September 2024<br>"

				+ "<br>"

				+ "* Frogs will now only tongue those they are attacking.<br>"
				+ "   - Applies to similar creatures like vrocks and ropers.<br>"
				+ "* Fixed a bug where singing monsters sang too much.<br>"
				+ "* Fixed the ninjitsu skills to match the book values.<br>"
				+ "* Added descriptions to training dummies and archer buttes.<br>"
				+ "* Fixed some mispellings in various areas.<br>"
				+ "* Magic resist can now maybe resist song effects.<br>"
				+ "* The buildworld commands now run when needed.<br>"
				+ "   - Whenever you change the script files.<br>"
				+ "   - You no longer need to run it unless you want to.<br>"
				+ "* You no longer give thieves chests and stolen deco.<br>"
				+ "   - You sell it to them instead.<br>"
				+ "   - It makes the overall mechanics consistent.<br>"
				+ "* Added some new creatures and variants.<br>"
				+ "* The staff of ultimate power will no longer vanish when held by another.<br>"
				+ "   - It will just leave their hand and no longer drain of power.<br>"
				+ "   - The lore for this item has been updated.<br>"
				+ "* Items, that once allowed only 1 to exist at time, are now character specific.<br>"
				+ "   - Each character can have one, and only one, of each type.<br>"
				+ "   - Items like staff pieces, bane items, or shadowlord items.<br>"
				+ "   - Also items for quest searches like the Chest of Suffering.<br>"
				+ "* Fixed an issue with Tarjan being spawnable too soon.<br>"
				+ "* Priest books now show coordinates and work with sextants.<br>"
				+ "* Jedi holocrons now show coordinates and work with sextants.<br>"
				+ "* Syth datacrons now show coordinates and work with sextants.<br>"
				+ "* Fixed an issue where power scrolls were not displaying the values.<br>"
				+ "* There are two custom settings to control the spawn rates of creatures.<br>"
				+ "* Merchants will say something if they have nothing in stock.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Executioner - 22 September 2024<br>"

				+ "<br>"

				+ "* Added the remaining sextant coordinate items to use a sextant map.<br>"
				+ "* Fixed an issue where fugitives could not join the theives guild.<br>"
				+ "* The Dungeon Masters Guide has been redone for ease of use.<br>"
				+ "* You can now see hidden creatures under your control.<br>"
				+ "* Fixed an accidental issue where disguises were removed when you move.<br>"
				+ "* Books on crafting and resources have been updated for this game.<br>"
				+ "* Fixed an issue where quests had way too much gold reward.<br>"
				+ "* Scrolls on crafting and materials have been all redone.<br>"
				+ "   - They are now books, but if you found them, you still have them.<br>"
				+ "   - The contents of the books now align with the current trades.<br>"
				+ "* Fixed an error where tasting was tested on non-poisoned food or drink.<br>"
				+ "* Fixed a resource break down that produced more than expected.<br>"
				+ "   - Tried to use the weight variable, but it was unreliable.<br>"
				+ "   - Instead got each exact crafting amount and halved them.<br>"
				+ "* Wax items can now be broken down.<br>"
				+ "* Items needing one resource to craft, can no longer be broken down.<br>"
				+ "* Some merchants will now be busy doing their trades.<br>"
				+ "   - They rotate randomly every hour where half will work.<br>"
				+ "   - Simply provides atmosphere in towns.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Berserker - 18 September 2024<br>"

				+ "<br>"

				+ "* Provided slight exceptional crafting if skill is over 100.<br>"
				+ "   - Previously, some items were really hard to craft.<br>"
				+ "   - This would make a skill of 125 have no chance at exceptional.<br>"
				+ "* Fixed vendors selling wares they shouldn't for 24x7 servers.<br>"
				+ "* Consolidated chat code for merchants.<br>"
				+ "* Fixed an issue where tools would not provide skill bonuses.<br>"
				+ "   - This would occur if you logged out and back in.<br>"
				+ "   - Prior to this, you would need to re-equip the tool.<br>"
				+ "* Bone brushes now work toward base forensic skill for bone types.<br>"
				+ "* Consolidated creature functions that sing or play instruments.<br>"
				+ "* Added buff icons for creature song effects.<br>"
				+ "* Stone masonry has been resourced like other trades.<br>"
				+ "   - They should now track their resource types.<br>"
				+ "   - You can break them down back into granite.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cleric - 14 September 2024<br>"

				+ "<br>"

				+ "* Fixed an issue with taking items from discovered trapped doors.<br>"
				+ "* Fixed the graphics used in the custom hairstylist interface.<br>"
				+ "* Redesigned the paperdoll for tools and trinkets.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Joker - 12 September 2024<br>"

				+ "<br>"

				+ "* Addressed an issue where some quest rewards were zero gold.<br>"
				+ "   - If you currently have a zero gold quest, drop some gold to clear it.<br>"
				+ "* Addressed an issue where some citizens sell things for zero gold.<br>"
				+ "* Identified items will now stay in the location they are identified.<br>"
				+ "* Items sold will now provide higher values for skill bonuses.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Bandit - 5 September 2024<br>"

				+ "<br>"

				+ "* Fixed the pirate coat to not be so confusing.<br>"
				+ "* Bracelet of Protection appearance fixed.<br>"
				+ "* Food and drink display fill values.<br>"
				+ "* Bags of holding should no longer put values in the negatives.<br>"
				+ "* Sage no longer says to click on `Status`.<br>"
				+ "* The Time Lord is invulnerable and will attack no one (even criminals).<br>"
				+ "* Treasure map coordinates glitch should be fixed.<br>"
				+ "* Scaled/Gemmed/Skinned armor should not appear in low level dungeons.<br>"
				+ "* Forgotten Halls map bug fixed.<br>"
				+ "* Rock Flesh spell crash fixed.<br>"
				+ "* Buff icons for disguise kits should now remove when the effect ends.<br>"
				+ "* Beeswax should now appear in the pack when harvested.<br>"
				+ "* All 64 Ancient Spells have been fixed and tested.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Knight - 16 August 2024<br>"

				+ "<br>"

				+ "* Added verbiage when using the alchemy belt pouch.<br>"
				+ "* Fixed a region name that was mispelled.<br>"
				+ "* Fixed a bug where rugs showed a price before identification.<br>"
				+ "* Fixed some repair functions from not repairing some items.<br>"
				+ "* Fixed a bug where some quest world locations all said Sosaria.<br>"
				+ "* Fixed a treasure map, monster spawning crash.<br>"
				+ "* Fixed a crash for the golden ranger quest.<br>"
				+ "* Fixed an issue with rune bags and meditating.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Prophet - 8 August 2024<br>"

				+ "<br>"

				+ "* Magical necromancer wands added.<br>"
				+ "* Another treasure map crash addressed.<br>"
				+ "* Tools should now stay in the hand when meditating.<br>"
				+ "* Characters can now cast travel magic in any house.<br>"
				+ "* Bard songs, that increase resistance, now are capped.<br>"
				+ "* Ancient magic toolbar crash addressed.<br>"
				+ "* A crash with clothing losing durability addressed.<br>"
				+ "* Rune bags have been revamped with new mechanics and interface.<br>"
				+ "* Some spelling or wording errors fixed.<br>"
				+ "* The stuck menu no longer works in homes.<br>"
				+ "* Game client package now has both ClassicUO and TazUO.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Buccaneer - 20 July 2024<br>"

				+ "<br>"

				+ "* Merchants now carry random, mundane items in their backpacks.<br>"
				+ "* Stamina bug fixed.<br>"
				+ "* Minimum taming skill required no longer go past impossible.<br>"
				+ "* Peacemaking bug fixed.<br>"
				+ "* Fixed treasure map crash.<br>"
				+ "* Item durability loss tweaked to be less frequent.<br>"
				+ "* Fixed a crash with certain traps.<br>"
				+ "* Beneficial bard songs now only affect friends.<br>"
				+ "* Fixed a weapon durability flaw.<br>"
				+ "* Hippogriff Karma fixed.<br>"
				+ "* Vendor coin purse bug fixed.<br>"
				+ "* Secret door fixed.<br>"
				+ "* Sextants have been changed.<br>"
				+ "   They still perform the same function. Having one in your pack may provide<br>"
				+ "   a button on parchements that have coordinates on them. Pressing the<br>"
				+ "   button will open a world map, that will have a pin showing the location.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Magician - 16 July 2024<br>"

				+ "<br>"

				+ "This version now comes packaged with the TazUO game client preconfigured.<br>"
				+ "<br>"
				+ "* Moved the custom merchant wagon at the Stonewall Inn.<br>"
				+ "* Fixed animations when riding wyverns, etc.<br>"
				+ "* Drinking beverages will now provide messages.<br>"
				+ "* Treasure tweaks in regards to resources items.<br>"
				+ "* Some items have a new Density attribute.<br>"
				+ "   - See the Library -> Item Properties for more details.<br>"
				+ "* Custom game settings have been added.<br>"
				+ "   - Set a chance of enemy dispel summons.<br>"
				+ "   - Reduce gold given for sold items.<br>"
				+ "   - Configure guild join fees.<br>"
				+ "   - Configure resurrection fees.<br>"
				+ "   - Set a chance loot drops on corpses and chests.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Warlord - 14 June 2024<br>"

				+ "<br>"

				+ "This update has a primary goal of reorganizing, standardizing, and straightening up the current game. Although some new features have been added, they are a small part with the overall effects of this version. Obsolete things have been removed, redunandant items and systems have been combined into a more cohesive system, and the new player experience was given some much needed attention. Below are some general changes with this update, as the details are too great to list.<br>"
				+ "<br>"
				+ "* Crafting overhauled.<br>"
				+ "* Resources overhauled.<br>"
				+ "* Resource crafting properties overhauled.<br>"
				+ "* Interfaces overhauled.<br>"
				+ "* Equipment slot attributes added.<br>"
				+ "* New scalemail armors.<br>"
				+ "* Unidentified items overhauled.<br>"
				+ "* Vendors overhauled.<br>"
				+ "* Additional context menus added.<br>"
				+ "* Options for loot, harvest, and crafting default containers.<br>"
				+ "* Option to gather ordrinary resources.<br>"
				+ "* Unused scripts removed.<br>"
				+ "* Obsolete scripts staged for removal.<br>"
				+ "   - Will be deleted after beta.<br>"
				+ "* Unused scripts removed.<br>"
				+ "* Code reorganized.<br>"
				+ "* Searching skill may allow for 1 chance to avoid chest traps.<br>"
				+ "* Pet bonding delay setting fixed.<br>"
				+ "* Player guide update.<br>"
				+ "   - PDF included.<br>"
				+ "   - Characters will start with a book again.<br>"
				+ "   - The character's Library has this new version.<br>"
				+ "   - Should help new players navigate the game.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Blacksmith - 3 March 2024<br>"

				+ "<br>"

				+ "* The game manual has been updated for completeness.<br>"
				+ "   It will explain much of the changes noted below,<br>"
				+ "   but in a more comprehensive way. READ IT!<br>"
				+ "* Fixed a color issue with purchased rucksacks.<br>"
				+ "* New server setting for character starting gold.<br>"
				+ "* More server settings for network and server name options.<br>"
				+ "* New server setting for enabling custom merchants.<br>"
				+ "   - Adds a wagon and merchant in each settlement.<br>"
				+ "   - List of goods are stored in your INFO folder.<br>"
				+ "   - Allows you to sell custom items.<br>"
				+ "* Lined up item names in the crafting gump.<br>"
				+ "* Tools now have higher uses (around 100 or so).<br>"
				+ "* New setting to allow for crafting many items at once.<br>"
				+ "   Creates new buttons on the crafting window<br>"
				+ "   for making 1, 10, or 100 items at a time.<br>"
				+ "* Drag and drop script support added.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   Extract the `Scripts` folder in your INFO directory<br>"
				+ "   that you find in the update package.<br>"
				+ "* World saving has been changed to skip backing up.<br>"
				+ "   files such as articles, news, and your server rules.<br>"
				+ "   It also no longer backs up custom spawns or decorations<br>"
				+ "   as it was unnecessary.<br>"
				+ "* Hidden floor traps have been configured a bit differently.<br>"
				+ "   If they are found, they will become visible and<br>"
				+ "   have a slight glow to them. The graphics are an<br>"
				+ "   animated type when they are still dangerous. If<br>"
				+ "   They are no longer dangerous, they will be motionless.<br>"
				+ "   If you have a good searching skill, and you walk over<br>"
				+ "   a hidden trap, the game will check your skill to see<br>"
				+ "   if you discover it. This will make the trap visible<br>"
				+ "   and dangerous, but you will not trigger it at that<br>"
				+ "   moment.<br>"
				+ "* Custom game settings have been redone.<br>"
				+ "   The settings file is found in the INFO `Scripts`<br>"
				+ "   folder, in a file named `Settings.cs`. You can<br>"
				+ "   edit this to your preferences and then restart the<br>"
				+ "   game. Do a `[buildworld` with the admin account.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   - Reference your `settings.xml` file.<br>"
				+ "   - Update your `Settings.cs` to match.<br>"
				+ "   - Delete your `settings.xml` file.<br>"
				+ "* INFO directory reorganized.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   Create a `Data` folder in your `Saves` directory<br>"
				+ "   and move these files into it...<br>"
				+ "   - adventures.txt<br>"
				+ "   - battles.txt<br>"
				+ "   - deaths.txt<br>"
				+ "   - journies.txt<br>"
				+ "   - murderers.txt<br>"
				+ "   - online.txt<br>"
				+ "   - quests.txt<br>"
				+ "   - server.txt<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Archmage - 25 February 2024<br>"

				+ "<br>"

				+ "* Both client and server update.<br>"
				+ "* Strange portals now have an entrance and exit.<br>"
				+ "* Ancient Spellbooks are now in the game.<br>"
				+ "   - Part of the spell research system.<br>"
				+ "   - All text and help menus updated.<br>"
				+ "   - Book graphics added.<br>"
				+ "   - Can be equipped like other spellbooks.<br>"
				+ "   - Provides traditional casting gameplay.<br>"
				+ "   - Original research system remains intact.<br>"
				+ "   - Learn about these books from the research bag.<br>"
				+ "* Research bags now hold 50,000 of need items<br>"
				+ "   like scrolls, quills, and ink.<br>"
				+ "* Character level now calculates with the game<br>"
				+ "   skill setttings for any set extra skill points.<br>"
				+ "* Client `music` folder renamed to `Music` to<br>"
				+ "   reduce confusion for Linux clients.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Beggar - 19 February 2024<br>"

				+ "<br>"

				+ "* More item naming fixes, requiring a World.exe update.<br>"
				+ "* Added some new monsters.<br>"
				+ "* Fixed some spell references to incorrect skills.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Enchanter - 12 February 2024<br>"

				+ "<br>"

				+ "* Fixed map decoration issues in Dungeon Clues.<br>"
				+ "* Did a source change to fix naming issues of items added to the game.<br>"
				+ "* Fixed the Artist to give money for paintings you give them.<br>"
				+ "   Both client and server update<br>"
				+ "   Replace your World.exe<br>"
				+ "   Do a [buildworld<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cultist - 30 January 2024<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Added a settings.xml option for time between hunger and thirst reduction.<br>"
				+ "* Added a settings.xml option for the number of days you can bond a tamed creature.<br>"
				+ "   The screen about the taming skill has been updated about bonding<br>"
				+ "   and it will reflect the number of days you set it at.<br>"
				+ "* Added a settings.xml option to disable the selling of tailor items.<br>"
				+ "   (cloth, cotton, flax, wool, and string)<br>"
				+ "   For those who want to eliminate gold acquisition<br>"
				+ "   from harvesting farms and profiting from cloth.<br>"
				+ "* Fix a bug caused by Razor allowing the casting of unavailable spells.<br>"
				+ "* Updated the client to the latest version of Razor (1.9.77.0).<br>"
				+ "* Updated the client to the latest version of ClassicUO (1.0.0.0).<br>"
				+ "   If upgrading, look at the new settings.xml<br>"
				+ "   where the new settings at the bottom need<br>"
				+ "   to be added to your settings.xml file.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Barbarian - 21 January 2024<br>"

				+ "<br>"

				+ "* Fixed grabbing to use line of sight (toads, ropers, etc).<br>"
				+ "* Fixed the strength potion buff icon.<br>"
				+ "* Added more buff icons for eating magic fish, bandage timers, charm and fear spells.<br>"
				+ "* Standardized curse removal magic. Added other spells that caused curse-type effects.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Jester - 8 January 2024<br>"

				+ "<br>"

				+ "* This is just a world-server update.<br>"
				+ "* Fixed saw mills placed in shops.<br>"
				+ "* Fixed other naming for addons as well.<br>"
				+ "* Like other updates, do a [buildworld.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Druid - 6 January 2024<br>"

				+ "<br>"

				+ "* Buff icons have been added to the game.<br>"
				+ "   Basic testing was done so there may be<br>"
				+ "   slight issues with things like timing,<br>"
				+ "   but the base is all done so tweaking<br>"
				+ "   will be a very simple matter if needed.<br>"
				+ "    - every skill, spell, or potion with a duration effect.<br>"
				+ "    - icons all redone to have the same visual theme.<br>"
				+ "    - information provided when hovering over them.<br>"
				+ "    - about 120 buff icons in the game now.<br>"
				+ "    - added additional icons that the base game did not.<br>"
				+ "         for magics such as necromancy, magery, and.<br>"
				+ "         knight-paladin magic.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Rogue - 26 December 2023<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Update your World.exe file as well.<br>"
				+ "* The [admin window has been cleaned up of old functions.<br>"
				+ "* Ninja animal form lists at least 1 animal to remove confusion.<br>"
				+ "* 4 server settings have been removed:<br>"
				+ "   IF UPGRADING YOU MUST remove these<br>"
				+ "   from you settings.xml file:<br>"
				+ "    - forest cats will use the larger model.<br>"
				+ "    - elephants will be in your game world.<br>"
				+ "    - zebras will be in your game world.<br>"
				+ "    - foxes will be in your game world.<br>"
				+ "* Some new animals added to the game.<br>"
				+ "* Occasional invisible elephant corpses should be fixed.<br>"
				+ "* Added server settings to adjust safari animals in some lands.<br>"
				+ "* New setting to adjust more skill points for characters.<br>"
				+ "    - set in amounts of 100 from 0 to 1,000 extra points.<br>"
				+ "    - still provides benefits for aliens, fugitives, etc.<br>"
				+ "    - in game text about skill points adapt to your settings.<br>"
				+ "* New setting to adjust skill gain for characters.<br>"
				+ "   If upgrading, look at the new settings.xml<br>"
				+ "   where the new settings at the bottom need<br>"
				+ "   to be added to your settings.xml file.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Gladiator - 16 December 2023<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Fixed a saw mill bug found by Nephtan.<br>"
				+ "* Changed the graphic for some player character demon paperdolls.<br>"
				+ "* Fixed a bug when using the barbaric satchel to change equipment.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cavalier - 22 November 2023<br>"

				+ "<br>"

				+ "* Fixed a wood oil issue found by Nephtan.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Bard - 16 October 2023<br>"

				+ "<br>"

				+ "* Changed the bank box to the larger format.<br>"
				+ "    - Special Update Instructions:<br>"
				+ "    - Download a new client and copy the<br>"
				+ "    - Game/Data/Client/containers.txt<br>"
				+ "    - files and replace yours.<br>"
				+ "* Brass is now based on science where you need copper instead of iron ore.<br>"
				+ "* Fixed some spelling errors.<br>"
				+ "* Added a bit more of the various bags of holding to the treasure tables.<br>"
				+ "* Created mounting bases where you can mount certain slain monsters for the home.<br>"
				+ "* Created stuffing baskets where you can stuff certain slain monsters for the home.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Wizard - 28 July 2023<br>"

				+ "<br>"

				+ "* Did some game and world branding changes.<br>"
				+ "* Implemented a fix for boats crashing while sailing.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Xork - 24 July 2023<br>"

				+ "<br>"

				+ "Game branched off, called the Adventurers of Akalabeth.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "LIZARD - 24 May 2023<br>"

				+ "<br>"

				+ "* Fixed an issue with the last update causing vendors to vanish.<br>"
				+ "* Fixed damages for a couple of elemental spells.<br>"
				+ "* Renamed a targeting mobile to TARGET instead of MOUSE but only the admin saw this.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "MASTADON - 23 May 2023<br>"

				+ "<br>"

				+ "* Another potential fix for monster spawning infinite loop while on the sea.<br>"
				+ "* Another potential fix for wandering healer random land spawning.<br>"
				+ "* Fixed an issue with bearskin rugs spawning in the land.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "UNICORN - 24 April 2023<br>"

				+ "<br>"

				+ "* Consolidated cloth appearances for cut and folded.<br>"
				+ "* Added an option to fold up cut cloth by double clicking it.<br>"
				+ "  - The scroll on tailoring has been updated with this new feature.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "SCORPION - 16 April 2023<br>"

				+ "<br>"

				+ "Fixed a damage calculation flaw with Poison Strike.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "GARGOYLE - 6 April 2023<br>"

				+ "<br>"

				+ "Suggested fixed by Nephtan.<br>"
				+ "* Research bag spell and reagent information.<br>"
				+ "* Fixed Mass Might spell.<br>"
				+ "* Fixed Enchant spell.<br>"
				+ "* Fixed Sneak spell.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "BOAR - 29 March 2023<br>"

				+ "<br>"

				+ "* Implemented a potential patch for sage and courier quests, regarding the dungeon pedestal locations.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "SPIDER - 26 March 2023<br>"

				+ "<br>"

				+ "* Fixed an issue with the jester's hilarity ability (Thanks Nephtan).<br>"
				+ "* Fixed an exploit with shoppes (Thanks Nephtan).<br>"
				+ "* Editted the welcoming gypsy's conversation to come from the first person.<br>"
				+ "* Fixed an issue with jester abilities that would cause server crashes.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "WYVERN - 21 March 2023<br>"

				+ "<br>"

				+ "* Fixed a bedroll issue when in public areas like banks and taverns (Thanks Nephtan).<br>"
				+ "* Fixed a graphic issue for a fairy race paperdoll (Thanks Nephtan).<br>"
				+ "* Expanded the definition of knives for skinning leather (Thanks Nephtan).<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "GREMLIN - 19 March 2023<br>"

				+ "<br>"

				+ "* Enabled more water troughs and barrels (frozen ones) to be used for filling waterskins.<br>"
				+ "* Added an extra check for wandering healers spawning at top left corner of the map (Thanks Nephtan).<br>"
				+ "* Elemental Protection spell now provides casting protection (Thanks Nephtan).<br>"
				+ "* Fixed a Legendary Artifact error in regards to armor attributes (Thanks Nephtan).<br>"
				+ "> Not being able to see monsters when you are dead and line of site is enabled is performing as designed (Sorry Nephtan).<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "BALRON - 2 March 2023<br>"

				+ "<br>"

				+ "Expanded the 'random daemons, balrons, dragons and wyrms' settings.xml option to encompass or omit more of the land.<br>"
				+ "* It previously only affected the random spawns and not the more precise area spawns.<br>"
				+ "* It does NOT include creatures on the high seas.<br>"
				+ "* There are exact location spawns that this setting does NOT affect.<br>"
				+ "* It now includes the good creatures like angels, oriental dragons, and ancient ents.<br>"
				+ "* Description in settings.xml has changed to reflect this.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "GRIFFON - 26 February 2023<br>"

				+ "<br>"

				+ "* Fixed an issue where the quick bar was not counting crystals properly.<br>"
				+ "* Fixed a bug with the slaver net and captured creatures hiding.<br>"
				+ "* Corrected a crash where shinobi items could not be created as legendary or artifact types.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "DRAKE - 8 February 2023<br>"

				+ "<br>"

				+ "Look over the included settings.xml file to see the added setting options and then add it to your settings.xml file if you are updating.<br>"
				+ "* Fixed graphics for jars to partial hue so the lids would show when randomly colored.<br>"
				+ "* Increased strength and storage weight for invulnerable porter-type creature followers.<br>"
				+ "* Added a setting option to stop hunger and thirst decay while in places like banks or inns.<br>"
				+ "* Fixed some graphical map issues in Dungeon Clues.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "KOBOLD - 29 January 2023<br>"

				+ "<br>"

				+ "Fixed an issue with Druidism not working on special acquired creatures like flesh golems and skeletal dragons.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "ORCUS - 4 January 2023<br>"

				+ "<br>"

				+ "Look over the included settings.xml file to see the added setting options and then add it to your settings.xml file if you are updating.<br>"
				+ "* Added a setting option to tweak how much you can learn from training dummies, training daemons, and archery buttes.<br>"
				+ "* Added a setting option to tweak how much you can learn from pickpocket dips.<br>"
				+ "* Added a setting option to have training dummies, training daemons, archery buttes and pickpocket dips train a character quicker.<br>"
				+ "* Added a setting option to turn off the dragons, wyrms, daemons, and balrons that randomly spawn in the world.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "GOBLIN - 3 January 2023<br>"

				+ "<br>"

				+ "* Fixed an issue where the term 'viking sword' was still in use when they were supposed to be replaced by 'barbarian swords'.<br>"
				+ "* Added a new dinosaur to the game.<br>"
				+ "* Some cosmetic map fixes.<br>"
				+ "* Various small script fixes like spelling errors.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "DRACULA - 20 September 2022<br>"

				+ "<br>"

				+ "* Added new animations for a bit more diverse monster appearances.<br>"
				+ "* Some cosmetic map fixes.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				
				+ "Further changes lost to time...<br>"

				+ "<br>"

				+ sepLine()

				+ "???? - ???? 2020?<br>"

				+ "* a companion maker<br>"

				+ "<br>"

				+ sepLine()

				+ "Dawn - ???? 2012?<br>"
        */

			+ "";

			return versionTEXT;
		}

		public static string sepLine()
		{
			return "---------------------------------------------------------------------------------<BR><BR>";
		}
	}
}
