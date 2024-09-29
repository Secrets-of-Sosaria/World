using System;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Mobiles;

namespace Server.Gumps
{
	public class ReportMurdererGump : Gump
	{
		private int m_Idx;
		private List<Mobile> m_Killers;
		private Mobile m_Victum;

		public static void Initialize()
		{
			EventSink.PlayerDeath += new PlayerDeathEventHandler( EventSink_PlayerDeath );
		}

		public static void EventSink_PlayerDeath( PlayerDeathEventArgs e )
		{
			Mobile m = e.Mobile;

			List<Mobile> killers = new List<Mobile>();
			List<Mobile> toGive  = new List<Mobile>();

			foreach ( AggressorInfo ai in m.Aggressors )
			{
				if ( ai.Attacker.Player && ai.CanReportMurder && !ai.Reported )
				{
					if (!Core.SE || !((PlayerMobile)m).RecentlyReported.Contains(ai.Attacker))
					{
						killers.Add(ai.Attacker);
						ai.Reported = true;
						ai.CanReportMurder = false;
					}
				}
				if ( ai.Attacker.Player && (DateTime.Now - ai.LastCombatTime) < TimeSpan.FromSeconds( 30.0 ) && !toGive.Contains( ai.Attacker ) )
					toGive.Add( ai.Attacker );
			}

			foreach ( AggressorInfo ai in m.Aggressed )
			{
				if ( ai.Defender.Player && (DateTime.Now - ai.LastCombatTime) < TimeSpan.FromSeconds( 30.0 ) && !toGive.Contains( ai.Defender ) )
					toGive.Add( ai.Defender );
			}

			foreach ( Mobile g in toGive )
			{
				int n = Notoriety.Compute( g, m );

				int theirKarma = m.Karma, ourKarma = g.Karma;
				bool innocent = ( n == Notoriety.Innocent );
				bool criminal = ( n == Notoriety.Criminal || n == Notoriety.Murderer );

				int fameAward = m.Fame / 200;
				int karmaAward = 0;

				if ( innocent )
					karmaAward = ( ourKarma > -2500 ? -850 : -110 - (m.Karma / 100) );
				else if ( criminal )
					karmaAward = 50;

				Titles.AwardFame( g, fameAward, false );
				Titles.AwardKarma( g, karmaAward, true );
			}

			if ( m is PlayerMobile && ((PlayerMobile)m).NpcGuild == NpcGuild.ThievesGuild )
				return;

			if ( killers.Count > 0 )
				new GumpTimer( m, killers ).Start();
		}

		private class GumpTimer : Timer
		{
			private Mobile m_Victim;
			private List<Mobile> m_Killers;

			public GumpTimer( Mobile victim, List<Mobile> killers ) : base( TimeSpan.FromSeconds( 4.0 ) )
			{
				m_Victim = victim;
				m_Killers = killers;
			}

			protected override void OnTick()
			{
				m_Victim.SendGump( new ReportMurdererGump( m_Victim, m_Killers ) );
			}
		}

		public ReportMurdererGump( Mobile victum, List<Mobile> killers ) : this( victum, killers, 0 )
		{
		}

		private ReportMurdererGump( Mobile victum, List<Mobile> killers, int idx ) : base( 50, 50 )
		{
			m_Killers = killers;
			m_Victum = victum;
			m_Idx = idx;

			m_Victum.SendSound( 0x4A ); 
			string color = "#92ada3";

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7001, Server.Misc.PlayerSettings.GetGumpHue( m_Victum ));
			AddButton(268, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 10, 10, 200, 20, @"<BODY><BASEFONT Color=" + color + ">MURDERED!</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 40, 285, 165, @"<BODY><BASEFONT Color=" + color + ">You have been murdered! Would you like to report this crime to the captain of the town guard? If so, their murder count will increase.</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(10, 216, 4023, 4023, 1, GumpButtonType.Reply, 0);
			AddButton(267, 217, 4020, 4020, 2, GumpButtonType.Reply, 0);
		}

		public static void ReportedListExpiry_Callback( object state )
		{
			object[] states = (object[])state;

			PlayerMobile from = (PlayerMobile)states[0];
			Mobile killer = (Mobile)states[1];

			if (from.RecentlyReported.Contains(killer))
			{
				from.RecentlyReported.Remove(killer);
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			from.SendSound( 0x4A ); 

			switch ( info.ButtonID )
			{
				case 1:
				{
					Mobile killer = m_Killers[m_Idx];
					if ( killer != null && !killer.Deleted )
					{
						killer.Kills++;
						killer.ShortTermMurders++;

						if (Core.SE)
						{
							((PlayerMobile)from).RecentlyReported.Add(killer);
							Timer.DelayCall(TimeSpan.FromMinutes(10), new TimerStateCallback(ReportedListExpiry_Callback), new object[] { from, killer });
						}

						if (killer is PlayerMobile)
						{
							PlayerMobile pk = (PlayerMobile)killer;
							pk.ResetKillTime();
							pk.SendLocalizedMessage(1049067);//You have been reported for murder!

							if (pk.Kills == 5)
							{
								pk.SendLocalizedMessage(502134);//You are now known as a murderer!
							}
							else if (SkillHandlers.Stealing.SuspendOnMurder && pk.Kills == 1 && pk.NpcGuild == NpcGuild.ThievesGuild)
							{
								pk.SendLocalizedMessage(501562); // You have been suspended by the Thieves Guild.
							}
						}
					}
					break;
				}
				case 2:
				{
					break;
				}
			}

			m_Idx++;
			if ( m_Idx < m_Killers.Count )
				from.SendGump( new ReportMurdererGump( from, m_Killers, m_Idx ) );
		}
	}
}