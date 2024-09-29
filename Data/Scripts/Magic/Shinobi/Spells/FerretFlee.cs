using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Necromancy;
using Server.Spells.Fourth;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Misc;

namespace Server.Spells.Shinobi
{
	public class FerretFlee : ShinobiSpell
	{
		public override int spellIndex { get { return 294; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Ferret Flee", "Ferettoran",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 0.5 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public FerretFlee( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( !Caster.Paralyzed && !Caster.Frozen )
			{
				Caster.SendMessage( "You are not held captive!" );
			}
			else if ( CheckBSequence( Caster ) )
			{
				int chance = (int)(Caster.Skills[SkillName.Ninjitsu].Value);

				if ( chance > Utility.Random( 120 ) )
				{
					Caster.PlaySound( Caster.Female ? 779 : 1050 );
					Caster.Paralyzed = false;
					Caster.Frozen = false;
					BuffInfo.CleanupIcons( Caster, true );
					Caster.SendMessage( "You freed yourself!" );
				}
				else
				{
					Caster.PlaySound( Caster.Female ? 815 : 1089 );
					Caster.SendMessage( "You failed to free yourself!" );
				}
			}

			FinishSequence();
		}
	}
}