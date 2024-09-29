using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Shinobi
{
	public class TigerStrength : ShinobiSpell
	{
		public override int spellIndex { get { return 297; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Tiger Strength", "Taigasutorengusu",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public TigerStrength( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 2) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				TimeSpan duration = TimeSpan.FromSeconds( (Caster.Skills[SkillName.Ninjitsu].Value * 12) );
				SpellHelper.Summon( new SummonedTiger(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}