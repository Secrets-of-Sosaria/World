using Server.Commands;
using Server.Engines.PartySystem;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Server.Engines.PartySystem
{
	public class AddPartyTarget : Target
	{
		public AddPartyTarget( Mobile from ) : base( 8, false, TargetFlags.None )
		{
			from.SendLocalizedMessage( 1005454 ); // Who would you like to add to your party?
		}

		protected override void OnTarget( Mobile from, object o )
		{
			if ( o is Mobile )
			{
				Mobile m = (Mobile)o;
				Party p = Party.Get( from );
				Party mp = Party.Get( m );

				if ( from == m )
					from.SendLocalizedMessage( 1005439 ); // You cannot add yourself to a party.
				else if ( p != null && p.Leader != from )
					from.SendLocalizedMessage( 1005453 ); // You may only add members to the party if you are the leader.
				else if ( m.Party is Mobile )
					return;
				else if ( p != null && (p.Members.Count + p.Candidates.Count) >= Party.Capacity )
					from.SendLocalizedMessage( 1008095 ); // You may only have 10 in your party (this includes candidates).
				else if ( !m.Player && m.Body.IsHuman )
					m.SayTo( from, 1005443 ); // Nay, I would rather stay here and watch a nail rust.
				else if ( !m.Player )
					from.SendLocalizedMessage( 1005444 ); // The creature ignores your offer.
				else if ( mp != null && mp == p )
					from.SendLocalizedMessage( 1005440 ); // This person is already in your party!
				else if ( mp != null )
					from.SendLocalizedMessage( 1005441 ); // This person is already in a party!
				else
					Party.Invite( from, m );
			}
			else
			{
				from.SendLocalizedMessage( 1005442 ); // You may only add living things to your party!
			}
		}
	}
}

namespace Server.Engines.PartySystem
{
	public sealed class PartyEmptyList : Packet
	{
		public PartyEmptyList( Mobile m ) : base( 0xBF )
		{
			EnsureCapacity( 7 );

			m_Stream.Write( (short) 0x0006 );
			m_Stream.Write( (byte) 0x02 );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (int) m.Serial );
		}
	}

	public sealed class PartyMemberList : Packet
	{
		public PartyMemberList( Party p ) : base( 0xBF )
		{
			EnsureCapacity( 7 + p.Count*4 );

			m_Stream.Write( (short) 0x0006 );
			m_Stream.Write( (byte) 0x01 );
			m_Stream.Write( (byte) p.Count );

			for ( int i = 0; i < p.Count; ++i )
				m_Stream.Write( (int) p[i].Mobile.Serial );
		}
	}

	public sealed class PartyRemoveMember : Packet
	{
		public PartyRemoveMember( Mobile removed, Party p ) : base( 0xBF )
		{
			EnsureCapacity( 11 + p.Count*4 );

			m_Stream.Write( (short) 0x0006 );
			m_Stream.Write( (byte) 0x02 );
			m_Stream.Write( (byte) p.Count );

			m_Stream.Write( (int) removed.Serial );

			for ( int i = 0; i < p.Count; ++i )
				m_Stream.Write( (int) p[i].Mobile.Serial );
		}
	}

	public sealed class PartyTextMessage : Packet
	{
		public PartyTextMessage( bool toAll, Mobile from, string text ) : base( 0xBF )
		{
			if ( text == null )
				text = "";

			EnsureCapacity( 12 + text.Length*2 );

			m_Stream.Write( (short) 0x0006 );
			m_Stream.Write( (byte) (toAll ? 0x04 : 0x03) );
			m_Stream.Write( (int) from.Serial );
			m_Stream.WriteBigUniNull( text );
		}
	}

	public sealed class PartyInvitation : Packet
	{
		public PartyInvitation( Mobile leader ) : base( 0xBF )
		{
			EnsureCapacity( 10 );

			m_Stream.Write( (short) 0x0006 );
			m_Stream.Write( (byte) 0x07 );
			m_Stream.Write( (int) leader.Serial );
		}
	}
}

namespace Server.Engines.PartySystem
{
	public class PartyCommandHandlers : PartyCommands
	{
		public static void Initialize()
		{
			PartyCommands.Handler = new PartyCommandHandlers();
		}

		public override void OnAdd( Mobile from )
		{
			Party p = Party.Get( from );

			if ( p != null && p.Leader != from )
				from.SendLocalizedMessage( 1005453 ); // You may only add members to the party if you are the leader.
			else if ( p != null && (p.Members.Count + p.Candidates.Count) >= Party.Capacity )
				from.SendLocalizedMessage( 1008095 ); // You may only have 10 in your party (this includes candidates).
			else
				from.Target = new AddPartyTarget( from );
		}

		public override void OnRemove( Mobile from, Mobile target )
		{
			Party p = Party.Get( from );

			if ( p == null )
			{
				from.SendLocalizedMessage( 3000211 ); // You are not in a party.
				return;
			}

			if ( p.Leader == from && target == null )
			{
				from.SendLocalizedMessage( 1005455 ); // Who would you like to remove from your party?
				from.Target = new RemovePartyTarget();
			}
			else if ( (p.Leader == from || from == target) && p.Contains( target ) )
			{
				p.Remove( target );
			}
		}

		public override void OnPrivateMessage( Mobile from, Mobile target, string text )
		{
			if ( text.Length > 128 || (text = text.Trim()).Length == 0 )
				return;

			Party p = Party.Get( from );

			if ( p != null && p.Contains( target ) )
				p.SendPrivateMessage( from, target, text );
			else
				from.SendLocalizedMessage( 3000211 ); // You are not in a party.
		}

		public override void OnPublicMessage( Mobile from, string text )
		{
			if ( text.Length > 128 || (text = text.Trim()).Length == 0 )
				return;

			Party p = Party.Get( from );

			if ( p != null )
				p.SendPublicMessage( from, text );
			else
				from.SendLocalizedMessage( 3000211 ); // You are not in a party.
		}

		public override void OnSetCanLoot( Mobile from, bool canLoot )
		{
			Party p = Party.Get( from );

			if ( p == null )
			{
				from.SendLocalizedMessage( 3000211 ); // You are not in a party.
			}
			else
			{
				PartyMemberInfo mi = p[from];

				if ( mi != null )
				{
					mi.CanLoot = canLoot;

					if ( canLoot )
						from.SendLocalizedMessage( 1005447 ); // You have chosen to allow your party to loot your corpse.
					else
						from.SendLocalizedMessage( 1005448 ); // You have chosen to prevent your party from looting your corpse.
				}
			}
		}

		public override void OnAccept( Mobile from, Mobile sentLeader )
		{
			Mobile leader = from.Party as Mobile;
			from.Party = null;

			Party p = Party.Get( leader );

			if ( leader == null || p == null || !p.Candidates.Contains( from ) )
				from.SendLocalizedMessage( 3000222 ); // No one has invited you to be in a party.
			else if ( (p.Members.Count + p.Candidates.Count) <= Party.Capacity )
				p.OnAccept( from );
		}

		public override void OnDecline( Mobile from, Mobile sentLeader )
		{
			Mobile leader = from.Party as Mobile;
			from.Party = null;

			Party p = Party.Get( leader );

			if ( leader == null || p == null || !p.Candidates.Contains( from ) )
				from.SendLocalizedMessage( 3000222 ); // No one has invited you to be in a party.
			else
				p.OnDecline( from, leader );
		}
	}
}

namespace Server.Engines.PartySystem
{
	public class PartyMemberInfo
	{
		private Mobile m_Mobile;
		private bool m_CanLoot;

		public Mobile Mobile{ get{ return m_Mobile; } }
		public bool CanLoot{ get{ return m_CanLoot; } set{ m_CanLoot = value; } }

		public PartyMemberInfo( Mobile m )
		{
			m_Mobile = m;
			m_CanLoot = !Core.ML;
		}
	}
}

namespace Server.Engines.PartySystem
{
	public class Party : IParty
	{
		private Mobile m_Leader;
		private List<PartyMemberInfo> m_Members;
		private List<Mobile> m_Candidates;
        private List<Mobile> m_Listeners; // staff listening

		public const int Capacity = 10;

		public static void Initialize()
		{
			EventSink.Logout += new LogoutEventHandler( EventSink_Logout );
			EventSink.Login += new LoginEventHandler( EventSink_Login );
			EventSink.PlayerDeath += new PlayerDeathEventHandler( EventSink_PlayerDeath );

			CommandSystem.Register( "ListenToParty", AccessLevel.GameMaster, new CommandEventHandler( ListenToParty_OnCommand ) );
		}

		public static void ListenToParty_OnCommand( CommandEventArgs e )
		{
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( ListenToParty_OnTarget ) );
			e.Mobile.SendMessage( "Target a partied player." );
		}

		public static void ListenToParty_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile )
			{
				Party p = Party.Get( (Mobile) obj );

				if ( p == null )
				{
					from.SendMessage( "They are not in a party." );
				}
				else if ( p.m_Listeners.Contains( from ) )
				{
					p.m_Listeners.Remove( from );
					from.SendMessage( "You are no longer listening to that party." );
				}
				else
				{
					p.m_Listeners.Add( from );
					from.SendMessage( "You are now listening to that party." );
				}
			}
		}

		public static void EventSink_PlayerDeath( PlayerDeathEventArgs e )
		{
			Mobile from = e.Mobile;
			Party p = Party.Get( from );

			if ( p != null )
			{
				Mobile m = from.LastKiller;

				if ( m == from )
					p.SendPublicMessage( from, "I killed myself!" );
				else if ( m == null )
					p.SendPublicMessage( from, "I was killed!" );
				else
					p.SendPublicMessage( from, String.Format( "I was killed by {0}!", m.Name ) );
			}
		}

		private class RejoinTimer : Timer
		{
			private Mobile m_Mobile;

			public RejoinTimer( Mobile m ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				Party p = Party.Get( m_Mobile );

				if ( p == null )
					return;

				m_Mobile.SendLocalizedMessage( 1005437 ); // You have rejoined the party.
				m_Mobile.Send( new PartyMemberList( p ) );

				Packet message = Packet.Acquire( new MessageLocalizedAffix( Serial.MinusOne, -1, MessageType.Label, 0x3B2, 3, 1008087, "", AffixType.Prepend | AffixType.System, m_Mobile.Name, "" ) );
				Packet attrs   = Packet.Acquire( new MobileAttributesN( m_Mobile ) );

				foreach ( PartyMemberInfo mi in p.Members )
				{
					Mobile m = mi.Mobile;

					if ( m != m_Mobile )
					{
						m.Send( message );
						m.Send( new MobileStatusCompact( m_Mobile.CanBeRenamedBy( m ), m_Mobile ) );
						m.Send( attrs );
						m_Mobile.Send( new MobileStatusCompact( m.CanBeRenamedBy( m_Mobile ), m ) );
						m_Mobile.Send( new MobileAttributesN( m ) );
					}
				}

				Packet.Release( message );
				Packet.Release( attrs );
			}
		}

		public static void EventSink_Login( LoginEventArgs e )
		{
			Mobile from = e.Mobile;
			Party p = Party.Get( from );

			if ( p != null )
				new RejoinTimer( from ).Start();
			else
				from.Party = null;
		}

		public static void EventSink_Logout( LogoutEventArgs e )
		{
			Mobile from = e.Mobile;
			Party p = Party.Get( from );

			if ( p != null )
				p.Remove( from );

			from.Party = null;
		}

		public static Party Get( Mobile m )
		{
			if ( m == null )
				return null;

			return m.Party as Party;
		}

		public Party( Mobile leader )
		{
			m_Leader = leader;

			m_Members = new List<PartyMemberInfo>();
			m_Candidates = new List<Mobile>();
            m_Listeners = new List<Mobile>();

			m_Members.Add( new PartyMemberInfo( leader ) );
		}

		public void Add( Mobile m )
		{
			PartyMemberInfo mi = this[m];

			if ( mi == null )
			{
				m_Members.Add( new PartyMemberInfo( m ) );
				m.Party = this;

				Packet memberList = Packet.Acquire( new PartyMemberList( this ) );
				Packet attrs = Packet.Acquire( new MobileAttributesN( m ) );

				for ( int i = 0; i < m_Members.Count; ++i )
				{
					Mobile f = ((PartyMemberInfo)m_Members[i]).Mobile;

					f.Send( memberList );

					if ( f != m )
					{
						f.Send( new MobileStatusCompact( m.CanBeRenamedBy( f ), m ) );
						f.Send( attrs );
						m.Send( new MobileStatusCompact( f.CanBeRenamedBy( m ), f ) );
						m.Send( new MobileAttributesN( f ) );
					}
				}

				Packet.Release( memberList );
				Packet.Release( attrs );
			}
		}

		public void OnAccept( Mobile from )
		{
			OnAccept( from, false );
		}

		public void OnAccept( Mobile from, bool force )
		{
			//  : joined the party.
			SendToAll( new MessageLocalizedAffix( Serial.MinusOne, -1, MessageType.Label, 0x3B2, 3, 1008094, "", AffixType.Prepend | AffixType.System, from.Name, "" ) );

			from.SendLocalizedMessage( 1005445 ); // You have been added to the party.

			m_Candidates.Remove( from );
			Add( from );
		}

		public void OnDecline( Mobile from, Mobile leader )
		{
			//  : Does not wish to join the party.
			leader.SendLocalizedMessage( 1008091, false, from.Name );

			from.SendLocalizedMessage( 1008092 ); // You notify them that you do not wish to join the party.

			m_Candidates.Remove( from );
			from.Send( new PartyEmptyList( from ) );

			if ( m_Candidates.Count == 0 && m_Members.Count <= 1 )
			{
				for ( int i = 0; i < m_Members.Count; ++i )
				{
					this[i].Mobile.Send( new PartyEmptyList( this[i].Mobile ) );
					this[i].Mobile.Party = null;
				}

				m_Members.Clear();
			}
		}

		public void Remove( Mobile m )
		{
			if ( m == m_Leader )
			{
				Disband();
			}
			else
			{
				for ( int i = 0; i < m_Members.Count; ++i )
				{
					if ( ((PartyMemberInfo)m_Members[i]).Mobile == m )
					{
						m_Members.RemoveAt( i );

						m.Party = null;
						m.Send( new PartyEmptyList( m ) );

						m.SendLocalizedMessage( 1005451 ); // You have been removed from the party.

						SendToAll( new PartyRemoveMember( m, this ) );
						SendToAll( 1005452 ); // A player has been removed from your party.

						break;
					}
				}

				if ( m_Members.Count == 1 )
				{
					SendToAll( 1005450 ); // The last person has left the party...
					Disband();
				}
			}
		}

		public bool Contains( Mobile m )
		{
			return ( this[m] != null );
		}

		public void Disband()
		{
			SendToAll( 1005449 ); // Your party has disbanded.

			for ( int i = 0; i < m_Members.Count; ++i )
			{
				this[i].Mobile.Send( new PartyEmptyList( this[i].Mobile ) );
				this[i].Mobile.Party = null;
			}

			m_Members.Clear();
		}

		public static void Invite( Mobile from, Mobile target )
		{
			Party p = Party.Get( from );

			if ( p == null )
				from.Party = p = new Party( from );

			if ( !p.Candidates.Contains( target ) )
				p.Candidates.Add( target );

			//  : You are invited to join the party. Type /accept to join or /decline to decline the offer.
			//target.Send( new MessageLocalizedAffix( Serial.MinusOne, -1, MessageType.Label, 0x3B2, 3, 1008089, "", AffixType.Prepend | AffixType.System, from.Name, "" ) );
			target.SendGump(new PartyGump(from, target));

			from.SendLocalizedMessage( 1008090 ); // You have invited them to join the party.

			target.Send( new PartyInvitation( from ) );
			target.Party = from;

			DeclineTimer.Start( target, from );
		}

		public void SendToAll( int number )
		{
			SendToAll( number, "", 0x3B2 );
		}

		public void SendToAll( int number, string args )
		{
			SendToAll( number, args, 0x3B2 );
		}

		public void SendToAll( int number, string args, int hue )
		{
			SendToAll( new MessageLocalized( Serial.MinusOne, -1, MessageType.Regular, hue, 3, number, "System", args ) );
		}

		public void SendPublicMessage( Mobile from, string text )
		{
			SendToAll( new PartyTextMessage( true, from, text ) );

			for ( int i = 0; i < m_Listeners.Count; ++i )
			{
				Mobile mob = m_Listeners[i];

				if ( mob.Party != this )
					m_Listeners[i].SendMessage( "[{0}]: {1}", from.Name, text );
			}

			SendToStaffMessage( from, "[Party]: {0}", text );
		}

		public void SendPrivateMessage( Mobile from, Mobile to, string text )
		{
			to.Send( new PartyTextMessage( false, from, text ) );

			for ( int i = 0; i < m_Listeners.Count; ++i )
			{
				Mobile mob = m_Listeners[i];

				if ( mob.Party != this )
					m_Listeners[i].SendMessage( "[{0}]->[{1}]: {2}", from.Name, to.Name, text );
			}

			SendToStaffMessage( from, "[Party]->[{0}]: {1}", to.Name, text );
		}

		private void SendToStaffMessage( Mobile from, string text )
		{	
			Packet p = null;

			foreach( NetState ns in from.GetClientsInRange( 8 ) )
			{
				Mobile mob = ns.Mobile;

				if( mob != null && mob.AccessLevel >= AccessLevel.GameMaster && mob.AccessLevel > from.AccessLevel && mob.Party != this && !m_Listeners.Contains( mob ) )
				{
					if( p == null )
						p = Packet.Acquire( new UnicodeMessage( from.Serial, from.Body, MessageType.Regular, from.SpeechHue, 3, from.Language, from.Name, text ) );

					ns.Send( p );
				}
			}

			Packet.Release( p );
		}
		private void SendToStaffMessage( Mobile from, string format, params object[] args )
		{
			SendToStaffMessage( from, String.Format( format, args ) );
		}

		public void SendToAll( Packet p )
		{
			p.Acquire();

			for ( int i = 0; i < m_Members.Count; ++i )
				m_Members[i].Mobile.Send( p );

			if ( p is MessageLocalized || p is MessageLocalizedAffix || p is UnicodeMessage || p is AsciiMessage )
			{
				for ( int i = 0; i < m_Listeners.Count; ++i )
				{
					Mobile mob = m_Listeners[i];

					if ( mob.Party != this )
						mob.Send( p );
				}
			}

			p.Release();
		}

		public void OnStamChanged( Mobile m )
		{
			Packet p = null;

			for ( int i = 0; i < m_Members.Count; ++i )
			{
				Mobile c = m_Members[i].Mobile;

				if ( c != m && m.Map == c.Map && Utility.InUpdateRange( c, m ) && c.CanSee( m ) )
				{
					if ( p == null )
						p = Packet.Acquire( new MobileStamN( m ) );

					c.Send( p );
				}
			}

			Packet.Release( p );
		}

		public void OnManaChanged( Mobile m )
		{
			Packet p = null;

			for ( int i = 0; i < m_Members.Count; ++i )
			{
				Mobile c = m_Members[i].Mobile;

				if ( c != m && m.Map == c.Map && Utility.InUpdateRange( c, m ) && c.CanSee( m ) )
				{
					if ( p == null )
						p = Packet.Acquire( new MobileManaN( m ) );

					c.Send( p );
				}
			}

			Packet.Release( p );
		}

		public void OnStatsQuery( Mobile beholder, Mobile beheld )
		{
			if ( beholder != beheld && Contains( beholder ) && beholder.Map == beheld.Map && Utility.InUpdateRange( beholder, beheld ) )
			{
				if ( !beholder.CanSee( beheld ) )
					beholder.Send( new MobileStatusCompact( beheld.CanBeRenamedBy( beholder ), beheld ) );

				beholder.Send( new MobileAttributesN( beheld ) );
			}
		}

		public int Count{ get{ return m_Members.Count; } }
		public bool Active{ get{ return m_Members.Count > 1; } }
		public Mobile Leader{ get{ return m_Leader; } }
		public List<PartyMemberInfo> Members{ get{ return m_Members; } }
        public List<Mobile> Candidates { get { return m_Candidates; } }

		public PartyMemberInfo this[int index]{ get{ return m_Members[index]; } }
		public PartyMemberInfo this[Mobile m]
		{
			get
			{
				for ( int i = 0; i < m_Members.Count; ++i )
					if ( m_Members[i].Mobile == m )
						return m_Members[i];

				return null;
			}
		}
	}
}

namespace Server.ContextMenus
{
	public class RemoveFromPartyEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private Mobile m_Target;
		
		public RemoveFromPartyEntry( Mobile from, Mobile target ) : base( 0198, 12 )
		{
			m_From = from;
			m_Target = target;
		}

		public override void OnClick()
		{			
			Party p = Party.Get( m_From );

			if ( p == null || p.Leader != m_From || !p.Contains( m_Target ) )
				return;

			if ( m_From == m_Target )
				m_From.SendLocalizedMessage( 1005446 ); // You may only remove yourself from a party if you are not the leader.
			else
				p.Remove( m_Target );
		}
	}
}

namespace Server.Engines.PartySystem
{
	public class RemovePartyTarget : Target
	{
		public RemovePartyTarget() : base( 8, false, TargetFlags.None )
		{
		}

		protected override void OnTarget( Mobile from, object o )
		{
			if ( o is Mobile )
			{
				Mobile m = (Mobile)o;
				Party p = Party.Get( from );

				if ( p == null || p.Leader != from || !p.Contains( m ) )
					return;

				if ( from == m )
					from.SendLocalizedMessage( 1005446 ); // You may only remove yourself from a party if you are not the leader.
				else
					p.Remove( m );
			}
		}
	}
}

namespace Server.Engines.PartySystem
{
	public class DeclineTimer : Timer
	{
		private Mobile m_Mobile, m_Leader;

		private static Hashtable m_Table = new Hashtable();

		public static void Start( Mobile m, Mobile leader )
		{
			DeclineTimer t = (DeclineTimer)m_Table[m];

			if ( t != null )
				t.Stop();

			m_Table[m] = t = new DeclineTimer( m, leader );
			t.Start();
		}

		private DeclineTimer( Mobile m, Mobile leader ) : base( TimeSpan.FromSeconds( 20.0 ) )
		{
			m_Mobile = m;
			m_Leader = leader;
		}

		protected override void OnTick()
		{
			m_Table.Remove( m_Mobile );

            if (m_Mobile.Party == m_Leader && PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnDecline(m_Mobile, m_Leader);
                m_Mobile.CloseGump(typeof(PartyGump));
            }
		}
	}
}