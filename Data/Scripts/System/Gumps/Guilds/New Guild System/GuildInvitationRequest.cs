using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Guilds
{
	public class GuildInvitationRequest : BaseGuildGump
	{
		PlayerMobile m_Inviter;
		public GuildInvitationRequest( PlayerMobile pm, Guild g, PlayerMobile inviter ) : base( pm, g )
		{
			m_Inviter = inviter;

			PopulateGump();
		}

		public override void PopulateGump()
		{
			player.SendSound( 0x4A ); 
			string color = "#c3c3c3";

			AddPage( 0 );

			AddImage(0, 0, 7009, Server.Misc.PlayerSettings.GetGumpHue( player ));

			AddHtml( 11, 11, 479, 20, @"<BODY><BASEFONT Color=" + color + ">GUILD INVITATION</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 42, 487, 66, @"<BODY><BASEFONT Color=" + color + ">You have been invited to join a guild!<BR>(Warning: Accepting will make you attackable!)</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 14, 144, 480, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>" + guild.Name + "</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(17, 215, 0xF2, 0xF2, 0, GumpButtonType.Reply, 0);
			AddButton(429, 215, 0xF7, 0xF7, 1, GumpButtonType.Reply, 0);

			if( player.AcceptGuildInvites )
				AddButton( 9, 287, 3609, 4017, 2, GumpButtonType.Reply, 0 );
			else
				AddButton( 9, 287, 4017, 3609, 2, GumpButtonType.Reply, 0 );

			AddHtml( 48, 287, 200, 20, @"<BODY><BASEFONT Color=" + color + ">Ignore Guild Invites</BASEFONT></BODY>", (bool)false, (bool)false);
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if( guild.Disbanded || player.Guild != null )
				return;

			switch( info.ButtonID )
			{
				case 0:
				{
					m_Inviter.SendLocalizedMessage( 1063250, String.Format( "{0}\t{1}", player.Name, guild.Name ) ); // ~1_val~ has declined your invitation to join ~2_val~.
					break;
				}
				case 1:
				{
					guild.AddMember( player );
					player.SendLocalizedMessage( 1063056, guild.Name ); // You have joined ~1_val~.
					m_Inviter.SendLocalizedMessage( 1063249, String.Format( "{0}\t{1}", player.Name, guild.Name ) ); // ~1_val~ has accepted your invitation to join ~2_val~.

					break;
				}
				case 2: 
				{
					player.AcceptGuildInvites = false;
					player.SendLocalizedMessage( 1070698 ); // You are now ignoring guild invitations.

					break;
				}
			}
			player.SendSound( 0x4A ); 
		}
	}
}