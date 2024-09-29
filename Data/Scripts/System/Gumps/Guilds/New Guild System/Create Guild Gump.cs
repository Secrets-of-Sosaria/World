using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Guilds
{
	public class CreateGuildGump : Gump
	{
		public CreateGuildGump( PlayerMobile pm ) : this( pm, "Guild Name", "GLD" )
		{
		}

		public CreateGuildGump( PlayerMobile pm, string guildName, string guildAbbrev ) : base( 50, 50 )
		{
			pm.SendSound( 0x4A ); 
			string color = "#c3c3c3";

			pm.CloseGump( typeof( CreateGuildGump ) );
			pm.CloseGump( typeof( BaseGuildGump ) );

			AddPage( 0 );

			AddImage(0, 0, 7009, Server.Misc.PlayerSettings.GetGumpHue( pm ));

			AddHtml( 12, 11, 479, 20, @"<BODY><BASEFONT Color=" + color + ">GUILD MENU</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 42, 487, 66, @"<BODY><BASEFONT Color=" + color + ">As you are not a member of any guild, you can create your own by providing a unique guild name and paying the standard guild registration fee.</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 120, 146, 20, @"<BODY><BASEFONT Color=" + color + ">Registration Fee:</BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 160, 120, 146, 20, @"<BODY><BASEFONT Color=" + color + ">" + Guild.RegistrationFee.ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 150, 146, 20, @"<BODY><BASEFONT Color=" + color + ">Enter Guild Name:</BASEFONT></BODY>", (bool)false, (bool)false);
			AddTextEntry(160, 150, 317, 20, 0x481, 5, guildName);

			AddHtml( 12, 180, 146, 20, @"<BODY><BASEFONT Color=" + color + ">Abbreviation:</BASEFONT></BODY>", (bool)false, (bool)false);
			AddTextEntry(160, 180, 313, 20, 0x481, 6, guildAbbrev);

			AddButton(17, 215, 0xF2, 0xF2, 0, GumpButtonType.Reply, 0);
			AddButton(429, 215, 0xF7, 0xF7, 1, GumpButtonType.Reply, 0);

			if( pm.AcceptGuildInvites )
				AddButton( 9, 287, 3609, 4017, 2, GumpButtonType.Reply, 0 );
			else
				AddButton( 9, 287, 4017, 3609, 2, GumpButtonType.Reply, 0 );

			AddHtml( 48, 287, 200, 20, @"<BODY><BASEFONT Color=" + color + ">Ignore Guild Invites</BASEFONT></BODY>", (bool)false, (bool)false);
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;
			pm.SendSound( 0x4A ); 

			if( pm == null || pm.Guild != null )
				return;		//Sanity

			switch( info.ButtonID )
			{
				case 1:
				{
					TextRelay tName = info.GetTextEntry( 5 );
					TextRelay tAbbrev = info.GetTextEntry( 6 );

					string guildName = (tName == null) ? "" : tName.Text;
					string guildAbbrev = (tAbbrev == null) ? "" : tAbbrev.Text;

					guildName = Utility.FixHtml( guildName.Trim() );
					guildAbbrev = Utility.FixHtml( guildAbbrev.Trim() );

					if( guildName.Length <= 0 )
						pm.SendLocalizedMessage( 1070884 ); // Guild name cannot be blank.
					else if( guildAbbrev.Length <= 0 )
						pm.SendLocalizedMessage( 1070885 ); // You must provide a guild abbreviation.
                    else if( guildName.Length > Guild.NameLimit )
						pm.SendLocalizedMessage( 1063036, Guild.NameLimit.ToString() ); // A guild name cannot be more than ~1_val~ characters in length.
					else if( guildAbbrev.Length > Guild.AbbrevLimit )
						pm.SendLocalizedMessage( 1063037, Guild.AbbrevLimit.ToString() ); // An abbreviation cannot exceed ~1_val~ characters in length.
					else if( Guild.FindByAbbrev( guildAbbrev ) != null || !BaseGuildGump.CheckProfanity( guildAbbrev ) )
						pm.SendLocalizedMessage( 501153 ); // That abbreviation is not available.
					else if( Guild.FindByName( guildName ) != null || !BaseGuildGump.CheckProfanity( guildName ) )
						pm.SendLocalizedMessage( 1063000 ); // That guild name is not available.
					else if( !Banker.Withdraw( pm, Guild.RegistrationFee ) )
						pm.SendLocalizedMessage( 1063001, Guild.RegistrationFee.ToString() ); // You do not possess the ~1_val~ gold piece fee required to create a guild.
					else
					{
						pm.SendLocalizedMessage( 1060398, Guild.RegistrationFee.ToString() ); // ~1_AMOUNT~ gold has been withdrawn from your bank box.
						pm.SendLocalizedMessage( 1063238 ); // Your new guild has been founded.
						pm.Guild = new Guild( pm, guildName, guildAbbrev );
					}

					break;
				}
				case 2:
				{
					pm.AcceptGuildInvites = !pm.AcceptGuildInvites;

					if( pm.AcceptGuildInvites )
						pm.SendLocalizedMessage( 1070699 ); // You are now accepting guild invitations.
					else
						pm.SendLocalizedMessage( 1070698 ); // You are now ignoring guild invitations.

					break;
				}
			}
		}
	}
}