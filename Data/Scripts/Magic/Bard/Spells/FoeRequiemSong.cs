using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;

namespace Server.Spells.Song
{
	public class FoeRequiemSong : Song
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Foe Requiem", "*plays an foe requiem*",
				-1
			);
		
		public FoeRequiemSong( Mobile caster, Item scroll) : base( caster, scroll, m_Info )
		{
		}
		
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2 ); } }
		public override double RequiredSkill{ get{ return 80.0; } }
		public override int RequiredMana{ get{ return 30; } }
		
		public override void OnCast()
		{
			base.OnCast();

			Caster.Target = new InternalTarget( this );
		}

		public virtual bool CheckSlayer( BaseInstrument instrument, Mobile defender )
		{
			SlayerEntry atkSlayer = SlayerGroup.GetEntryByName( instrument.Slayer );
			SlayerEntry atkSlayer2 = SlayerGroup.GetEntryByName( instrument.Slayer2 );

			if ( atkSlayer != null && atkSlayer.Slays( defender )  || atkSlayer2 != null && atkSlayer2.Slays( defender ) )
				return true;

			return false;
		}

		public void Target( Mobile m )
		{
            Spellbook book = Spellbook.Find(Caster, -1, SpellbookType.Song);
            if (book == null)
                return;

            m_Book = (SongBook)book;

			if ( m == null )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
				FinishSequence();
			}
			else
			{
				bool sings = false;

				if ( !Caster.CanSee( m ) )
				{
					Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
					return;
				}
				else if ( CheckHSequence( m ) )
				{
					sings = true;

					Mobile source = Caster;

					SpellHelper.Turn( Caster, m );

					bool IsSlayer = false;
					if ( m is BaseCreature ){ IsSlayer = CheckSlayer( m_Book.Instrument, m ); }

					double damage = (double)( MusicSkill( Caster ) / 15 );

					if ( IsSlayer )
					{
						damage = damage * 2;
					}

					m.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Head );
					source.MovingParticles( m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211 );
					m.PlaySound( 0x1EA );

					SpellHelper.Damage( this, m, damage, 20, 20, 20, 20, 20 );
				}

				BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
				FinishSequence();
			}
		}
		
		private class InternalTarget : Target
		{
			private FoeRequiemSong m_Owner;

			public InternalTarget( FoeRequiemSong owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile && o != null )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
