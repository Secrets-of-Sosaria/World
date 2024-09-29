using System;
using Server.Network;
using Server.Regions;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Misc
{
	public class WelcomeTimer : Timer
	{
		private Mobile m_Mobile;
		private int m_State, m_Count;

		private static string[] m_Messages = new string[] { "Welcome to the " + MySettings.S_ServerName + "" };

		public WelcomeTimer( Mobile m ) : this( m, m_Messages.Length )
		{
		}

		public WelcomeTimer( Mobile m, int count ) : base( TimeSpan.FromSeconds( 4.0 ), TimeSpan.FromSeconds( 8.0 ) )
		{
			m_Mobile = m;
			m_Count = count;
		}

		protected override void OnTick()
		{
			if ( m_State < m_Count )
			{
				m_Mobile.SendMessage( 0x35, m_Messages[m_State++] );

				if ( m_Mobile is PlayerMobile )
				{
					m_Mobile.CloseGump( typeof( Joeku.MOTD.MOTD_Gump ) );
					m_Mobile.Send(PlayMusic.GetInstance(MusicName.City));
				}
			}

			if ( m_State == m_Count )
				Stop();
		}
	}
}