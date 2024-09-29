using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Spells.Shinobi;
using Server.Mobiles;
using Server.Network;
using Server.SkillHandlers;

namespace Server.Items
{
	public class DisguiseKit : Item
	{
		public override string DefaultDescription{ get{ return "These disguises can be used to appear as someone else. It is helpful if you are one trying to avoid the local guards. You need to be very skilled in hiding, stealth, ninjitsu, snooping, or psychology to use these."; } }

		[Constructable]
		public DisguiseKit() : base( 0xE05 )
		{
			Name = "disguise kit";
			Weight = 1.0;
		}

		public DisguiseKit( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public bool ValidateUse( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( !IsChildOf( from.Backpack ) )
			{
				// That must be in your pack for you to use it.
				from.SendLocalizedMessage( 1042001 );
			}
			else if ( 
				from.Skills[SkillName.Ninjitsu].Base < 50 && 
				from.Skills[SkillName.Stealth].Base < 50 && 
				from.Skills[SkillName.Hiding].Base < 50 && 
				from.Skills[SkillName.Psychology].Base < 50 && 
				from.Skills[SkillName.Snooping].Base < 50 )
			{
				from.SendMessage("You don't seem to have the skills to apply this disguise.");
				return false;
			}
			else if ( !from.CanBeginAction( typeof( IncognitoSpell ) ) )
			{
				// You cannot disguise yourself while incognitoed.
				from.SendLocalizedMessage( 501704 );
			}
			else if ( !from.CanBeginAction( typeof( Deception ) ) )
			{
				from.SendMessage("You cannot disguise yourself since you already are using deception.");
			}
			else if ( TransformationSpellHelper.UnderTransformation( from ) )
			{
				// You cannot disguise yourself while in that form.
				from.SendLocalizedMessage( 1061634 );
			}
			else if ( !from.CanBeginAction( typeof( PolymorphSpell ) ) || ( from.IsBodyMod && from.RaceID < 1 ) )
			{
				// You cannot disguise yourself while polymorphed.
				from.SendLocalizedMessage( 501705 );
			}
			else
			{
				return true;
			}

			return false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( ValidateUse( from ) )
			{
				if ( from.RaceID != 0 )
				{
					from.HueMod = Utility.RandomColor( Utility.RandomMinMax( 1, 13 ) );
					from.BodyMod = 970;
					from.NameMod = from.RaceWasFemale ? NameList.RandomName( "female" ) : NameList.RandomName( "male" );
					from.SendLocalizedMessage( 501706 ); // Disguises wear off after 2 hours.

					DisguiseTimers.CreateTimer( from, TimeSpan.FromHours( 2.0 ) );
					DisguiseTimers.StartTimer( from );
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.Incognito, 1075821, 1075820, TimeSpan.FromHours( 2.0 ), from ) );
					this.Delete();
				}
				else 
				{
					from.HueMod = from.Race.RandomSkinHue();
					from.NameMod = from.Female ? NameList.RandomName( "female" ) : NameList.RandomName( "male" );

					PlayerMobile pm = from as PlayerMobile;

					if ( pm != null && pm.Race != null )
					{
						pm.SetHairMods( pm.Race.RandomHair( pm.Female ), pm.Race.RandomFacialHair( pm.Female ) );
						pm.HairHue = Utility.RandomHairHue();
						pm.FacialHairHue = Utility.RandomHairHue();
					}

					from.SendLocalizedMessage( 501706 ); // Disguises wear off after 2 hours.

					DisguiseTimers.CreateTimer( from, TimeSpan.FromHours( 2.0 ) );
					DisguiseTimers.StartTimer( from );
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.Incognito, 1075821, 1075820, TimeSpan.FromHours( 2.0 ), from ) );
					this.Delete();
				}
			}
		}
	}
	
	public class DisguiseTimers
	{
		public static void Initialize()
		{
			new DisguisePersistance();
		}
		
		private class InternalTimer : Timer
		{
			private Mobile m_Player;
			
			public InternalTimer( Mobile m, TimeSpan delay ) : base( delay )
			{
				m_Player = m;
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m_Player.NameMod = null;

				if ( m_Player.RaceID != 0 )
				{
					m_Player.HueMod = 0;
					m_Player.BodyMod = 0;
					m_Player.RaceBody();
				}
				else if ( m_Player is PlayerMobile )
				{
					((PlayerMobile)m_Player).SetHairMods( -1, -1 );

					m_Player.BodyMod = 0;
					m_Player.HueMod = -1;
					m_Player.NameMod = null;
					m_Player.RaceBody();
				}
			
				DisguiseTimers.RemoveTimer( m_Player );
			}
		}
		
		public static void CreateTimer( Mobile m, TimeSpan delay )
		{
			if ( m != null )
				if ( !m_Timers.Contains( m ) )
					m_Timers[m] = new InternalTimer( m, delay );
		}
		
		public static void StartTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];
			
			if ( t != null )
				t.Start();
		}

		public static bool IsDisguised( Mobile m )
		{
			return m_Timers.Contains( m );
		}

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Delay = t.Next - DateTime.Now;
				t.Stop();
			}

			return ( t != null );
		}
		
		public static bool RemoveTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );
			}
			
			return ( t != null );
		}
		
		public static TimeSpan TimeRemaining( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				return t.Next - DateTime.Now;
			}
			
			return TimeSpan.Zero;
		}
		
		private static Hashtable m_Timers = new Hashtable();
		
		public static Hashtable Timers
		{
			get { return m_Timers; }
		}

		public static void RemoveDisguise( Mobile from )
		{
			if ( TransformationSpellHelper.UnderTransformation( from, typeof( Spells.Necromancy.VampiricEmbraceSpell ) ) ){ /* IGNORE */ }
			else if ( TransformationSpellHelper.UnderTransformation( from, typeof( Spells.Necromancy.WraithFormSpell ) ) ){ /* IGNORE */ }
			else if ( TransformationSpellHelper.UnderTransformation( from, typeof( Spells.Necromancy.LichFormSpell ) ) ){ /* IGNORE */ }
			else if ( TransformationSpellHelper.UnderTransformation( from, typeof( Spells.Necromancy.HorrificBeastSpell ) ) ){ /* IGNORE */ }
			else if ( from.NameMod != null )
			{
				BuffInfo.RemoveBuff( from, BuffIcon.Incognito );
				from.HueMod = -1;
				from.NameMod = null;
				((PlayerMobile)from).SavagePaintExpiration = TimeSpan.Zero;

				((PlayerMobile)from).SetHairMods( -1, -1 );

				PolymorphSpell.StopTimer( from );
				IncognitoSpell.StopTimer( from );
				Deception.StopTimer( from );
				DisguiseTimers.RemoveTimer( from );

				from.EndAction( typeof( PolymorphSpell ) );
				from.EndAction( typeof( IncognitoSpell ) );
				from.EndAction( typeof( Deception ) );
			}
		}
	}
}