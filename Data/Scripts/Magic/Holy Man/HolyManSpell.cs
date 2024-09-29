using System;
using Server;
using Server.Spells;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
using System.Collections;

namespace Server.Spells.HolyMan
{
	public abstract class HolyManSpell : Spell
	{
		public abstract int RequiredTithing { get; }
		public abstract double RequiredSkill { get; }
		public abstract int RequiredMana{ get; }
		public override bool ClearHandsOnCast { get { return false; } }
		public override SkillName CastSkill { get { return SkillName.Spiritualism; } }
		public override SkillName DamageSkill { get { return SkillName.Healing; } }
		public override int CastRecoveryBase { get { return 7; } }

		public HolyManSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
		{
		}

		public static string SpellDescription( int spell )
		{
			string txt = "This symbol holds the knowledge of spiritual blessings: ";
			string skl = "0";

			if ( spell == 770 ){ 		skl = "60";	txt += "Sends demons and the dead back to the realms of hell."; }
			else if ( spell == 771 ){ 	skl = "70";	txt += "Absorbs mana from others and bestows it to the priest."; }
			else if ( spell == 772 ){ 	skl = "90";	txt += "Temporarily imbues a weapon with holy powers."; }
			else if ( spell == 773 ){ 	skl = "50";	txt += "Temporarily summons a hammer from the gods."; }
			else if ( spell == 774 ){ 	skl = "10";	txt += "Destroys the darkness, allowing for one to see better."; }
			else if ( spell == 775 ){ 	skl = "10";	txt += "The priest is able to help those that are starving or thirsty."; }
			else if ( spell == 776 ){ 	skl = "40";	txt += "Removes curses and other ailing effects."; }
			else if ( spell == 777 ){ 	skl = "80";	txt += "Brings one back to life, or summons an orb to resurrect the priest later on."; }
			else if ( spell == 778 ){ 	skl = "20";	txt += "Surrounds one with a holy aura that heals wounds much quicker."; }
			else if ( spell == 779 ){ 	skl = "30";	txt += "The gods grant the priest greater strength, speed, and intelligence."; }
			else if ( spell == 780 ){ 	skl = "60";	txt += "Allows the priest to enter the realm of the dead, avoiding any harm."; }
			else if ( spell == 781 ){ 	skl = "40";	txt += "Calls down a bolt from the heavens, doing double damage to demons and undead."; }
			else if ( spell == 782 ){ 	skl = "20";	txt += "Restores health and stamina to the weary."; }
			else if ( spell == 783 ){ 	skl = "30";	txt += "Engulfs the priest in holy flames, reflecting magic back at the caster."; }

			if ( skl == "0" )
				return txt;

			return txt + " It requires a Priest to be at least a " + skl + " in Spiritualism.";
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( Caster.Karma < 2500 )
			{
				Caster.SendMessage( "You have too little Karma to invoke this prayer." );
				return false;
			}
			else if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "You must have at least " + RequiredSkill + " Spiritualism to invoke this prayer." );
				return false;
			}
			else if ( GetSoulsInSymbol( Caster ) < RequiredTithing )
			{
				Caster.SendMessage( "You must have at least " + RequiredTithing + " piety to invoke this prayer." );
				return false;
			}
			else if ( Caster.Mana < GetMana() )
			{
				Caster.SendMessage( "You must have at least " + GetMana() + " Mana to invoke this prayer." );
				return false;
			}

			return true;
		}

		public override bool CheckFizzle()
		{
			int requiredTithing = GetTithing( Caster, this );
			int mana = GetMana();

			if ( Caster.Karma < 2500 )
			{
				Caster.SendMessage( "You have too little Karma to invoke this prayer." );
				return false;
			}
			else if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "You must have at least " + RequiredSkill + " Spiritualism to invoke this prayer" );
				return false;
			}
			else if ( GetSoulsInSymbol( Caster ) < requiredTithing )
			{
				Caster.SendMessage( "You must have at least " + requiredTithing + " piety to invoke this prayer." );
				return false;
			}
			else if ( Caster.Mana < mana )
			{
				Caster.SendMessage( "You must have at least " + mana + " Mana to invoke this prayer." );
				return false;
			}

			return true;
		}

		public override void FinishSequence()
		{
			DrainSoulsInSymbol( Caster, RequiredTithing );
			base.FinishSequence();
		}

		public override void DoFizzle()
		{
			Caster.PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, "You fail to invoke the power.", Caster.NetState);
			Caster.FixedParticles( 0x3735, 1, 30, 9503, EffectLayer.Waist );
			Caster.PlaySound( 0x1D6 );
			Caster.NextSpellTime = DateTime.Now;
		}

		public override int GetMana()
		{
			return ScaleMana( RequiredMana );
		}

		public static int GetTithing( Mobile Caster, HolyManSpell spell )
		{
			if ( AosAttributes.GetValue( Caster, AosAttribute.LowerRegCost ) > Utility.Random( 100 ) )
				return 0;

			return spell.RequiredTithing;
		}

		public override void SayMantra()
		{
			Caster.PublicOverheadMessage( MessageType.Regular, 0x3B2, false, Info.Mantra );
		}

		public override void DoHurtFizzle()
		{
			Caster.PlaySound( 0x1D6 );
		}

		public override void OnDisturb( DisturbType type, bool message )
		{
			base.OnDisturb( type, message );

			if ( message )
				Caster.PlaySound( 0x1D6 );
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.FixedEffect( 0x37C4, 10, 42, 4, 3 );
		}

		public override void GetCastSkills( out double min, out double max )
		{
			min = RequiredSkill;
			max = RequiredSkill + 40.0;
		}

		public int ComputePowerValue( int div )
		{
			return ComputePowerValue( Caster, div );
		}

		public static int ComputePowerValue( Mobile from, int div )
		{
			if ( from == null )
				return 0;

			int v = (int) Math.Sqrt( ( from.Karma * -1 ) + 20000 + ( from.Skills.Spiritualism.Fixed * 10 ) );

			return v / div;
		}

		public static void DrainSoulsInSymbol( Mobile from, int tithing )
		{
			if ( AosAttributes.GetValue( from, AosAttribute.LowerRegCost ) > Utility.Random( 100 ) )
				tithing = 0;

			if ( tithing > 0 )
			{
				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				{
					if ( item is HolySymbol )
					{
						HolySymbol symbol = (HolySymbol)item;
						if ( symbol.owner == from )
						{
							symbol.BanishedEvil = symbol.BanishedEvil - tithing;
							if ( symbol.BanishedEvil < 1 ){ symbol.BanishedEvil = 0; }
							symbol.InvalidateProperties();
						}
					}
				}
			}
		}

		public static int GetSoulsInSymbol( Mobile from )
		{
			int souls = 0;

			ArrayList targets = new ArrayList();
			foreach ( Item item in World.Items.Values )
			{
				if ( item is HolySymbol )
				{
					HolySymbol symbol = (HolySymbol)item;
					if ( symbol.owner == from )
					{
						souls = symbol.BanishedEvil;
					}
				}
			}

			return souls;
		}
	}
}