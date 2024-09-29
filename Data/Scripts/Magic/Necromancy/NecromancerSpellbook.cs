using System;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class NecromancerSpellbook : Spellbook
	{
		public override string DefaultDescription{ get{ return "This evil book is used by necromancers, where they can record the deathly magic they can unleash. Dropping such scrolls onto this book will place the spell within its pages. Some books have enhanced properties, that are only effective when the book is held."; } }

		public override SpellbookType SpellbookType{ get{ return SpellbookType.Necromancer; } }
		public override int BookOffset{ get{ return 100; } }
		public override int BookCount{ get{ return ((Core.SE) ? 17 : 16); } }

		[Constructable]
		public NecromancerSpellbook() : this( (ulong)0 )
		{
		}

		[Constructable]
		public NecromancerSpellbook( ulong content ) : base( content, 0x2253 )
		{
			Name = "necromancer spellbook";
			Layer = Layer.Trinket;
		}

		public NecromancerSpellbook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public static string SpellDescription( int spell )
		{
			string txt = "This is a necromancer spell: ";
			string skl = "0";

			if ( spell == 100 ){ 		skl = "40";	txt = "Animates the Targeted corpse, creating a mindless, wandering undead. The strength of the risen undead is greatly modified by the power of the original creature and the power of the necromancer."; }
			else if ( spell == 101 ){ 	skl = "20";	txt = "Temporarily creates a dark pact between the Caster and the Target. Any damage dealt by the Target to the Caster is increased, but the Target receives the same amount of damage."; }
			else if ( spell == 102 ){ 	skl = "20";	txt = "Transmogrifies the flesh of the Target creature or player to resemble rotted corpse flesh, making them more vulnerable to Fire and Poison damage, but increasing their Resistance to Physical and Cold damage."; }
			else if ( spell == 103 ){ 	skl = "0";	txt = "Temporarily imbues a weapon with a life draining effect."; }
			else if ( spell == 104 ){ 	skl = "20";	txt = "Curses the Target so that the next harmful event that affects them is magnified."; }
			else if ( spell == 105 ){ 	skl = "40";	txt = "Transforms the Caster into a horrific demonic beast, which deals more damage, and recovers hit points faster, but can no longer cast any spells except for Necromancer Transformation spells. Caster remains in this form until they recast the Horrific Beast spell."; }
			else if ( spell == 106 ){ 	skl = "70";	txt = "Transforms the Caster into a lich, increasing their mana regeneration and some Resistances, while lowering their Fire Resist and slowly sapping their life. Caster remains in this form until they recast the Lich Form spell."; }
			else if ( spell == 107 ){ 	skl = "30";	txt = "Attempts to place a curse on the Target that increases the mana cost of any spells they cast, for a duration based off a comparison between the Caster`s Spiritualism skill and the Target`s Magic Resistance skill."; }
			else if ( spell == 108 ){ 	skl = "20";	txt = "Temporarily causes intense physical pain to the Target, dealing Direct damage. Once the spell wears off, if the Target is still alive, some of the Hit Points lost through the Pain Spike are restored."; }
			else if ( spell == 109 ){ 	skl = "50";	txt = "Creates a blast of poisonous energy centered on the Target. The main Target is inflicted with a large amount of Poison damage, and all valid Targets in a radius around the main Target are inflicted with a lesser effect."; }
			else if ( spell == 110 ){ 	skl = "65";	txt = "Temporarily chokes off the air supply of the Target with poisonous fumes. The Target is inflicted with Poison damage over time. The amount of damage dealt each hit is based off of the Caster`s Spiritualism skill and the Target`s current Stamina."; }
			else if ( spell == 111 ){	skl = "30";	txt = "Allows the Caster to summon a Familiar from a selected list. A Familiar will follow and fight with its owner, in addition to granting unique bonuses to the Caster, dependent upon the type of Familiar summoned."; }
			else if ( spell == 112 ){ 	skl = "99";	txt = "Transforms the Caster into a powerful Vampire, which increases his Stamina and Mana regeneration while lowering his Fire Resistance. Vampires also perform Life Drain when striking their enemies. Caster remains in this form until they recast the Vampiric Embrace spell."; }
			else if ( spell == 113 ){ 	skl = "80";	txt = "Summons a vile Spirit which haunts the Target until either the Target or the Spirit is dead. Vengeful Spirits have the ability to track down their Targets wherever they may travel. A Spirit`s strength is determined by the Necromancy and Spiritualism skills of the Caster."; }
			else if ( spell == 114 ){ 	skl = "60";	txt = "Creates a withering frost around the Caster, which deals Cold Damage to all valid targets in a radius."; }
			else if ( spell == 115 ){ 	skl = "20";	txt = "Transforms the Caster into an ethereal Wraith, lowering some Elemental Resists, while increasing their Physical resist. Wraith Form also allows the caster to always succeed when using the Recall spell, and causes a Mana Drain effect when hitting enemies. Caster remains in this form until they recast the Wraith Form spell."; }
			else if ( spell == 116 ){	skl = "80";	txt = "This spell can force the undead to meet the true death, or it can send demonic creatures back to hell. Some may be too powerful for this spell, but many are not."; }

			if ( skl == "0" )
				return txt;

			return txt + " It requires at least a " + skl + " in Necromancy to cast.";
		}
	}
}