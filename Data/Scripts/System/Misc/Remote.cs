using Server.Accounting;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server;
using System.Collections;
using System.Text;
using System;

namespace Server.RemoteAdmin
{
	public class AdminNetwork
	{
		private static ArrayList m_Auth = new ArrayList();
		private static bool m_NewLine = true;
		private static StringBuilder m_ConsoleData = new StringBuilder();

		private const string DateFormat = "MMMM dd hh:mm:ss.f tt";

		public static void Configure()
		{
			PacketHandlers.Register( 0xF1, 0, false, new OnPacketReceive( OnReceive ) );

#if !MONO
			Core.MultiConsoleOut.Add( new EventTextWriter( new EventTextWriter.OnConsoleChar( OnConsoleChar ), new EventTextWriter.OnConsoleLine( OnConsoleLine ), new EventTextWriter.OnConsoleStr( OnConsoleString ) ) );
#endif
			Timer.DelayCall( TimeSpan.FromMinutes( 2.5 ), TimeSpan.FromMinutes( 2.5 ), new TimerCallback( CleanUp ) );
		}

		public static void OnConsoleString( string str )
		{
			string outStr;
			if ( m_NewLine )
			{
				outStr = String.Format( "[{0}]: {1}", DateTime.Now.ToString( DateFormat ), str );
				m_NewLine = false;
			}
			else
			{
				outStr = str;
			}

			m_ConsoleData.Append( outStr );
			if ( m_ConsoleData.Length >= 4096 )
				m_ConsoleData.Remove( 0, 2048 );

			for (int i=0;i<m_Auth.Count;i++)
				((NetState)m_Auth[i]).Send( new ConsoleData( str ) );
		}

		public static void OnConsoleChar( char ch )
		{
			if ( m_NewLine )
			{
				string outStr;
				outStr = String.Format( "[{0}]: {1}", DateTime.Now.ToString( DateFormat ), ch );

				m_ConsoleData.Append( outStr );

				for (int i=0;i<m_Auth.Count;i++)
					((NetState)m_Auth[i]).Send( new ConsoleData( outStr ) );

				m_NewLine = false;
			}
			else
			{
				m_ConsoleData.Append( ch );

				for (int i=0;i<m_Auth.Count;i++)
					((NetState)m_Auth[i]).Send( new ConsoleData( ch ) );
			}

			if ( m_ConsoleData.Length >= 4096 )
				m_ConsoleData.Remove( 0, 2048 );
		}

		public static void OnConsoleLine( string line )
		{
			string outStr;
			if ( m_NewLine )
				outStr = String.Format( "[{0}]: {1}{2}", DateTime.Now.ToString( DateFormat ), line, Console.Out.NewLine );
			else
				outStr = String.Format( "{0}{1}", line, Console.Out.NewLine );

			m_ConsoleData.Append( outStr );
			if ( m_ConsoleData.Length >= 4096 )
				m_ConsoleData.Remove( 0, 2048 );

			for (int i=0;i<m_Auth.Count;i++)
				((NetState)m_Auth[i]).Send( new ConsoleData( outStr ) );

			m_NewLine = true;
		}

		public static void OnReceive( NetState state, PacketReader pvSrc )
		{
			byte cmd = pvSrc.ReadByte();
			if ( cmd == 0x02 )
			{
				Authenticate( state, pvSrc );
			}
			else if ( cmd == 0xFF )
			{
				string statStr = String.Format( ", Name={0}, Age={1}, Clients={2}, Items={3}, Chars={4}, Mem={5}K", MySettings.S_ServerName, (int)(DateTime.Now-Server.Items.Clock.ServerStart).TotalHours, NetState.Instances.Count, World.Items.Count, World.Mobiles.Count, (int)(System.GC.GetTotalMemory(false)/1024) );
				state.Send( new UOGInfo( statStr ) );
				state.Dispose();
			}
			else if ( !IsAuth( state ) )
			{
				Console.WriteLine( "ADMIN: Unauthorized packet from {0}, disconnecting", state );
				Disconnect( state );
			}
			else
			{
				if ( !RemoteAdminHandlers.Handle( cmd, state, pvSrc ) )
					Disconnect( state );
			}
		}

		private static void DelayedDisconnect( NetState state )
		{
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerStateCallback( Disconnect ), state );
		}
		
		private static void Disconnect( object state )
		{
			m_Auth.Remove( state );
			((NetState)state).Dispose();
		}
		
		public static void Authenticate( NetState state, PacketReader pvSrc )
		{
			string user = pvSrc.ReadString( 30 );
			string pw = pvSrc.ReadString( 30 );

			Account a = Accounts.GetAccount( user ) as Account;
			if ( a == null )
			{
				state.Send( new Login( LoginResponse.NoUser ) );
				Console.WriteLine( "ADMIN: Invalid username '{0}' from {1}", user, state );
				DelayedDisconnect( state );
			}
			else if ( !a.HasAccess( state ) )
			{
				state.Send( new Login( LoginResponse.BadIP ) );
				Console.WriteLine( "ADMIN: Access to '{0}' from {1} denied.", user, state );
				DelayedDisconnect( state );
			}
			else if ( !a.CheckPassword( pw ) )
			{
				state.Send( new Login( LoginResponse.BadPass ) );
				Console.WriteLine( "ADMIN: Invalid password '{0}' for user '{1}' from {2}", pw, user, state );
				DelayedDisconnect( state );
			}
			else if ( a.AccessLevel < AccessLevel.Administrator || a.Banned )
			{
				Console.WriteLine( "ADMIN: Account '{0}' does not have admin access. Connection Denied.", user );
				state.Send( new Login( LoginResponse.NoAccess ) ); 
				DelayedDisconnect( state );
			}
			else
			{
				Console.WriteLine( "ADMIN: Access granted to '{0}' from {1}", user, state );
				state.Account = a;
				a.LogAccess( state );
				a.LastLogin = DateTime.Now;

				state.Send( new Login( LoginResponse.OK ) );
				state.Send( Compress( new ConsoleData( m_ConsoleData.ToString() ) ) );
				m_Auth.Add( state );
			}
		}

		public static bool IsAuth( NetState state )
		{
			return m_Auth.Contains( state );
		}

		private static void CleanUp()
		{//remove dead instances from m_Auth
			ArrayList list = new ArrayList();
			for (int i=0;i<m_Auth.Count;i++)
			{
				NetState ns = (NetState) m_Auth[i];
				if ( ns.Running )
					list.Add( ns );
			}

			m_Auth = list;
		}

		public static Packet Compress( Packet p )
		{
			int length;
			byte[] source = p.Compile( false, out length );

			if ( length > 100 && length < 60000 )
			{
				byte[] dest = new byte[(int)(length*1.001)+1];
				int destSize = dest.Length;

				ZLibError error = Compression.Pack( dest, ref destSize, source, length, ZLibQuality.Default );

				if ( error != ZLibError.Okay )
				{
					Console.WriteLine( "WARNING: Unable to compress admin packet, zlib error: {0}", error );
					return p;
				}
				else
				{
					return new AdminCompressedPacket( dest, destSize, length );
				}
			}
			else
			{
				return p;
			}
		}
	}
	
	public class EventTextWriter : System.IO.TextWriter
	{
		public delegate void OnConsoleChar( char ch );
		public delegate void OnConsoleLine( string line );
		public delegate void OnConsoleStr( string str );

		private OnConsoleChar m_OnChar;
		private OnConsoleLine m_OnLine;
		private OnConsoleStr m_OnStr;

		public EventTextWriter( OnConsoleChar onChar, OnConsoleLine onLine, OnConsoleStr onStr )
		{
			m_OnChar = onChar;
			m_OnLine = onLine;
			m_OnStr = onStr;
		}

		public override void Write( char ch )
		{
			if ( m_OnChar != null )
				m_OnChar( ch );
		}

		public override void Write( string str )
		{
			if ( m_OnStr != null )
				m_OnStr( str );
		}

		public override void WriteLine( string line )
		{
			if ( m_OnLine != null )
				m_OnLine( line );
		}

		public override System.Text.Encoding Encoding{ get{ return System.Text.Encoding.ASCII; } }
	}
}

namespace Server.RemoteAdmin
{
	public class RemoteAdminHandlers
	{
		public enum AcctSearchType : byte
		{
			Username = 0,
			IP = 1,
		}

		private static OnPacketReceive[] m_Handlers = new OnPacketReceive[256];

		static RemoteAdminHandlers()
		{
			//0x02 = login request, handled by AdminNetwork
			Register( 0x04, new OnPacketReceive( ServerInfoRequest ) );
			Register( 0x05, new OnPacketReceive( AccountSearch ) );
			Register( 0x06, new OnPacketReceive( RemoveAccount ) );
			Register( 0x07, new OnPacketReceive( UpdateAccount ) );
		}

		public static void Register( byte command, OnPacketReceive handler )
		{
			m_Handlers[command] = handler;
		}

		public static bool Handle( byte command, NetState state, PacketReader pvSrc )
		{
			if ( m_Handlers[command] == null )
			{
				Console.WriteLine( "ADMIN: Invalid packet 0x{0:X2} from {1}, disconnecting", command, state );
				return false;
			}
			else
			{
				m_Handlers[command]( state, pvSrc );
				return true;
			}
		}

		private static void ServerInfoRequest( NetState state, PacketReader pvSrc )
		{
			state.Send( AdminNetwork.Compress( new ServerInfo() ) );
		}

		private static void AccountSearch( NetState state, PacketReader pvSrc )
		{
			AcctSearchType type = (AcctSearchType)pvSrc.ReadByte();
			string term = pvSrc.ReadString();

			if ( type == AcctSearchType.IP && !Utility.IsValidIP( term ) )
			{
				state.Send( new MessageBoxMessage( "Invalid search term.\nThe IP sent was not valid.", "Invalid IP" ) );
				return;
			}
			else
			{
				term = term.ToUpper();
			}

			ArrayList list = new ArrayList();

			foreach ( Account a in Accounts.GetAccounts() )
			{
				switch ( type )
				{
					case AcctSearchType.Username:
					{
						if ( a.Username.ToUpper().IndexOf( term ) != -1 )
							list.Add( a );
						break;
					}
					case AcctSearchType.IP:
					{
						for( int i=0;i<a.LoginIPs.Length;i++ )
						{
							if ( Utility.IPMatch( term, a.LoginIPs[i] ) )
							{
								list.Add( a );
								break;
							}
						}
						break;
					}
				}
			}

			if ( list.Count > 0 )
			{
				if ( list.Count <= 25 )
					state.Send( AdminNetwork.Compress( new AccountSearchResults( list ) ) );
				else
					state.Send( new MessageBoxMessage( "There were more than 25 matches to your search.\nNarrow the search parameters and try again.", "Too Many Results" ) );
			}
			else
			{
				state.Send( new MessageBoxMessage( "There were no results to your search.\nPlease try again.", "No Matches" ) );
			}
		}

		private static void RemoveAccount( NetState state, PacketReader pvSrc )
		{
			IAccount a = Accounts.GetAccount( pvSrc.ReadString() );

			if ( a == null )
			{
				state.Send( new MessageBoxMessage( "The account could not be found (and thus was not deleted).", "Account Not Found" ) );
			}
			else if ( a == state.Account )
			{
				state.Send( new MessageBoxMessage( "You may not delete your own account.", "Not Allowed" ) );
			}
			else
			{
				a.Delete();
				state.Send( new MessageBoxMessage( "The requested account (and all it's characters) has been deleted.", "Account Deleted" ) );
			}
		}

		private static void UpdateAccount( NetState state, PacketReader pvSrc )
		{ 
			string username = pvSrc.ReadString();
			string pass = pvSrc.ReadString();

			Account a = Accounts.GetAccount( username ) as Account;

			if ( a == null )
				a = new Account( username, pass );
			else if ( pass != "(hidden)" )
				a.SetPassword( pass );

			if ( a != state.Account )
			{
				a.AccessLevel = (AccessLevel)pvSrc.ReadByte();
				a.Banned = pvSrc.ReadBoolean();
			}
			else
			{
				pvSrc.ReadInt16();//skip both
				state.Send( new MessageBoxMessage( "Warning: When editing your own account, account status and accesslevel cannot be changed.", "Editing Own Account" ) );
			}
			
			ArrayList list = new ArrayList();
			ushort length = pvSrc.ReadUInt16();
			bool invalid = false;
			for (int i=0;i<length;i++)
			{
				string add = pvSrc.ReadString();
				if ( Utility.IsValidIP( add ) )
					list.Add( add );
				else
					invalid = true;
			}
			
			if ( list.Count > 0 )
				a.IPRestrictions = (string[])list.ToArray( typeof( string ) );
			else
				a.IPRestrictions = new string[0];

			if ( invalid )
				state.Send( new MessageBoxMessage( "Warning: one or more of the IP Restrictions you specified was not valid.", "Invalid IP Restriction" ) );
			state.Send( new MessageBoxMessage( "Account updated successfully.", "Account Updated" ) );
		}
	}
}

namespace Server.RemoteAdmin
{
	public enum LoginResponse : byte
	{
		NoUser = 0,
		BadIP,
		BadPass,
		NoAccess,
		OK
	}

	public sealed class AdminCompressedPacket : Packet
	{
		public AdminCompressedPacket( byte[] CompData, int CDLen, int unCompSize ) : base( 0x01 )
		{
			EnsureCapacity( 1 + 2 + 2 + CDLen );
			m_Stream.Write( (ushort)unCompSize );
			m_Stream.Write( CompData, 0, CDLen );
		}
	}
	
	public sealed class Login : Packet
	{
		public Login( LoginResponse resp ) : base( 0x02, 2 )
		{
			m_Stream.Write( (byte)resp );
		}
	}

	public sealed class ConsoleData : Packet
	{
		public ConsoleData( string str ) : base( 0x03 )
		{
			EnsureCapacity( 1 + 2 + 1 + str.Length + 1 );
			m_Stream.Write( (byte) 2 );

			m_Stream.WriteAsciiNull( str );
		}

		public ConsoleData( char ch ) : base( 0x03 )
		{
			EnsureCapacity( 1 + 2 + 1 + 1 );
			m_Stream.Write( (byte) 3 );

			m_Stream.Write( (byte) ch );
		}
	}

	public sealed class ServerInfo : Packet
	{
		public ServerInfo() : base( 0x04 )
		{
			string netVer = Environment.Version.ToString();
			string os = Environment.OSVersion.ToString();

			EnsureCapacity( 1 + 2 + (10*4) + netVer.Length+1 + os.Length+1 );
			int banned = 0;
			int active = 0;

			foreach ( Account acct in Accounts.GetAccounts() )
			{
				if ( acct.Banned )
					++banned;
				else
					++active;
			}

			m_Stream.Write( (int) active );
			m_Stream.Write( (int) banned );
			m_Stream.Write( (int) Firewall.List.Count );
			m_Stream.Write( (int) NetState.Instances.Count );

			m_Stream.Write( (int) World.Mobiles.Count );
			m_Stream.Write( (int) Core.ScriptMobiles );
			m_Stream.Write( (int) World.Items.Count );
			m_Stream.Write( (int) Core.ScriptItems );

			m_Stream.Write( (uint)(DateTime.Now - Clock.ServerStart).TotalSeconds );
			m_Stream.Write( (uint) GC.GetTotalMemory( false ) );
			m_Stream.WriteAsciiNull( netVer );
			m_Stream.WriteAsciiNull( os );
		}
	}

	public sealed class AccountSearchResults : Packet
	{
		public AccountSearchResults( ArrayList results ) : base( 0x05 )
		{
			EnsureCapacity( 1 + 2 + 2 );

			m_Stream.Write( (byte)results.Count );
			
			foreach ( Account a in results )
			{
				m_Stream.WriteAsciiNull( a.Username );

				string pwToSend = a.PlainPassword;

				if ( pwToSend == null )
					pwToSend = "(hidden)";

				m_Stream.WriteAsciiNull( pwToSend );
				m_Stream.Write( (byte)a.AccessLevel );
				m_Stream.Write( a.Banned );
				unchecked { m_Stream.Write( (uint)a.LastLogin.Ticks ); }
				
				m_Stream.Write( (ushort)a.LoginIPs.Length );
				for (int i=0;i<a.LoginIPs.Length;i++)
					m_Stream.WriteAsciiNull( a.LoginIPs[i].ToString() );

				m_Stream.Write( (ushort)a.IPRestrictions.Length );
				for (int i=0;i<a.IPRestrictions.Length;i++)
					m_Stream.WriteAsciiNull( a.IPRestrictions[i] );
			}
		}
	}

	public sealed class UOGInfo : Packet
	{
		public UOGInfo( string str ) : base( 0x52, str.Length+6 ) // 'R'
		{
			m_Stream.WriteAsciiFixed( "unUO", 4 );
			m_Stream.WriteAsciiNull( str );
		}
	}

	public sealed class MessageBoxMessage : Packet
	{
		public MessageBoxMessage( string msg, string caption ) : base( 0x08 )
		{
			EnsureCapacity( 1 + 2 + msg.Length + 1 + caption.Length + 1 );

			m_Stream.WriteAsciiNull( msg );
			m_Stream.WriteAsciiNull( caption );
		}
	}
}