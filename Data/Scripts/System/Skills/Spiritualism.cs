using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.SkillHandlers
{
	class Spiritualism
	{
		public static void Initialize()
		{
			SkillInfo.Table[32].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			if ( Core.AOS )
			{
				Spell spell = new SpiritualismSpell( m );

				spell.Cast();

				if ( spell.IsCasting )
					return TimeSpan.FromSeconds( 5.0 );

				return TimeSpan.Zero;
			}

			m.RevealingAction();

			if ( m.CheckSkill( SkillName.Spiritualism, 0, 100 ) )
			{	
				if ( !m.CanHearGhosts )
				{
					Timer t = new SpiritualismTimer( m );
					double secs = m.Skills[SkillName.Spiritualism].Base / 50;
					secs *= 90;
					if ( secs < 15 )
						secs = 15;

					t.Delay = TimeSpan.FromSeconds( secs );//15seconds to 3 minutes
					t.Start();
					m.CanHearGhosts = true;
				}

				m.PlaySound( 0x24A );
				m.SendLocalizedMessage( 502444 );//You contact the neitherworld.
			}
			else
			{
				m.SendLocalizedMessage( 502443 );//You fail to contact the neitherworld.
				m.CanHearGhosts = false;
			}

			return TimeSpan.FromSeconds( 1.0 );
		}

		private class SpiritualismTimer : Timer
		{
			private Mobile m_Owner;
			public SpiritualismTimer( Mobile m ) : base( TimeSpan.FromMinutes( 2.0 ) )
			{
				m_Owner = m;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.CanHearGhosts = false;
				m_Owner.SendLocalizedMessage( 502445 );//You feel your contact with the neitherworld fading.
			}
		}

		private class SpiritualismSpell : Spell
		{
			private static SpellInfo m_Info = new SpellInfo( "Spiritualism", "", 269 );

			public override bool BlockedByHorrificBeast{ get{ return false; } }

			public SpiritualismSpell( Mobile caster ) : base( caster, null, m_Info )
			{
			}

			public override bool ClearHandsOnCast{ get{ return false; } }

			public override double CastDelayFastScalar { get { return 0; } }
			public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }

			public override int GetMana()
			{
				return 0;
			}

			public override void OnCasterHurt()
			{
				if ( IsCasting )
					Disturb( DisturbType.Hurt, false, true );
			}

			public override bool ConsumeReagents()
			{
				return true;
			}

			public override bool CheckFizzle()
			{
				return true;
			}

			public override bool CheckNextSpellTime{ get{ return false; } }

			public override void OnDisturb( DisturbType type, bool message )
			{
				Caster.NextSkillTime = DateTime.Now;

				base.OnDisturb( type, message );
			}

			public override bool CheckDisturb( DisturbType type, bool checkFirst, bool resistable )
			{
				if ( type == DisturbType.EquipRequest || type == DisturbType.UseRequest )
					return false;

				return true;
			}

			public override void SayMantra()
			{
				if ( Caster.Karma < 0 )
				{
					Caster.Say( "Xtee Mee Glau" );
					if ( Caster.RaceID > 0 )
						Caster.PlaySound( Caster.RaceAngerSound );
					else
						Caster.PlaySound( 0x481 );
				}
				else
				{
					Caster.Say( "Anh Mi Sah Ko" );
					if ( Caster.RaceID > 0 )
						Caster.PlaySound( Caster.RaceIdleSound );
					else
						Caster.PlaySound( 0x24A );
				}
			}

			public override void OnCast()
			{
				Corpse toChannel = null;

				foreach ( Item item in Caster.GetItemsInRange( 3 ) )
				{
					if( item is Corpse && !( (Corpse)item ).Channeled && !( (Corpse)item ).Animated && Caster.Karma < 0 )
					{
						toChannel = (Corpse)item;
						break;
					}
				}

				int max, min, mana;
				string message;

				if ( toChannel != null )
				{
					min = MyServerSettings.PlayerLevelMod( 1 + (int)(Caster.Skills[SkillName.Spiritualism].Value * 0.25) + (int)(Caster.Skills[SkillName.FistFighting].Value * 0.15), Caster );
					max = MyServerSettings.PlayerLevelMod( min + MyServerSettings.PlayerLevelMod( 4, Caster ), Caster );
					mana = 0;
					message = "You channel the corpse's energy to restore yourself.";
				}
				else
				{
					min = MyServerSettings.PlayerLevelMod( 1 + (int)(Caster.Skills[SkillName.Spiritualism].Value * 0.25) + (int)(Caster.Skills[SkillName.FistFighting].Value * 0.15), Caster );
					max = MyServerSettings.PlayerLevelMod( min + MyServerSettings.PlayerLevelMod( 4, Caster ), Caster );
					mana = 10;
					message = "You channel your spiritual energy to restore yourself.";
				}

				if ( Caster.Mana < mana )
				{
					Caster.SendLocalizedMessage( 1061285 ); // You lack the mana required to use this skill.
				}
				else if ( Caster.Poisoned )
				{	
					Caster.SendMessage( "You cannot do that while poison is in your veins!" );
				}
				else if ( Caster.Hunger < 1 )
				{	
					Caster.SendMessage( "You are starving to death and cannot do that!" );
				}
				else if ( Caster.Thirst < 1 )
				{	
					Caster.SendMessage( "You are dying of thirst and cannot do that!" );
				}
				else
				{
					Caster.CheckSkill( SkillName.Spiritualism, 0.0, 120.0 );

					if ( Utility.RandomDouble() > (Caster.Skills[SkillName.Spiritualism].Value / 100.0) )
					{
						Caster.SendLocalizedMessage( 502443 ); // You fail your attempt at contacting the netherworld.
					}
					else
					{
						if ( toChannel != null )
						{
							toChannel.Channeled = true;
							toChannel.Hue = 0x835;
						}

						Caster.Mana -= mana;
						Caster.SendMessage( message );

						if ( min > max )
							min = max;

						Caster.Hits += Utility.RandomMinMax( min, max );
						Caster.Stam += Utility.RandomMinMax( min, max );

						if ( Caster.Karma < 0 )
						{
							//Caster.FixedParticles( 0x3400, 1, 15, 9501, 0, 4, EffectLayer.Waist );
							Effects.SendLocationEffect( Caster.Location, Caster.Map, 0x3400, 60 );
						}
						else
						{
							//Caster.FixedParticles( 0x375A, 1, 15, 9501, 0, 4, EffectLayer.Waist );
							Effects.SendLocationEffect( Caster.Location, Caster.Map, 0x375A, 60 );
						}
					}
				}

				FinishSequence();
			}
		}
	}
}