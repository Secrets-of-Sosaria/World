using System;
using Server;
using Server.Misc;
using System.Collections.Generic;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;

namespace Server.Mobiles
{
	public abstract class BaseGuildmaster : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool IsActiveVendor{ get{ return true; } }

		public override bool ClickTitle{ get{ return true; } }

		public override void InitSBInfo( Mobile m )
		{
		}

		public virtual void SayGuildTo( Mobile m )
		{
			SayTo( m, 1008055 + (int)NpcGuild );
		}

		public virtual void SayWelcomeTo( Mobile m )
		{
			SayTo( m, "Welcome to the guild! Thou shalt find it beneficial to your future endeavors." );
		}

		public static void SayPriceTo( Mobile m, Mobile guildmaster )
		{
			m.Send( new MessageLocalizedAffix( guildmaster.Serial, guildmaster.Body, MessageType.Regular, guildmaster.SpeechHue, 3, 1008052, guildmaster.Name, AffixType.Append, " " + MyServerSettings.JoiningFee( m ).ToString(), "" ) );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			PlayerMobile pm = (PlayerMobile)from;

			base.GetContextMenuEntries( from, list );

			if ( !IntelligentAction.GetMyEnemies( from, this, false ) && pm.NpcGuild != this.NpcGuild )
			{
				if ( ((PlayerMobile)from).Fugitive == 1 && from.Kills < 2 && this is ThiefGuildmaster )
					list.Add( new JoinEntry( from, this ) );
				else if ( ((PlayerMobile)from).Fugitive == 1 ){} else
					list.Add( new JoinEntry( from, this ) );
			}

			if ( pm.NpcGuild == this.NpcGuild )
				list.Add( new ResignEntry( from, this ) );
		} 

		public class JoinEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Guildmaster;
			
			public JoinEntry( Mobile from, Mobile guildmaster ) : base( 6116, 3 )
			{
				m_Mobile = from;
				m_Guildmaster = guildmaster;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				JoinGuild( m_Mobile, m_Guildmaster );
            }
        }

		public class ResignEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Guildmaster;
			
			public ResignEntry( Mobile from, Mobile guildmaster ) : base( 6115, 3 )
			{
				m_Mobile = from;
				m_Guildmaster = guildmaster;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				ResignGuild( m_Mobile, m_Guildmaster );
            }
        }

		public static void JoinGuild( Mobile player, Mobile guildmaster )
		{
			PlayerMobile pm = (PlayerMobile)player;

			if ( player.Blessed )
				guildmaster.SayTo( player, "Speak to me when that strange effect has worn off." );
			else if ( ((PlayerMobile)player).Fugitive == 1 && ((BaseVendor)guildmaster).NpcGuild != NpcGuild.AssassinsGuild && ((BaseVendor)guildmaster).NpcGuild != NpcGuild.NecromancersGuild && ((BaseVendor)guildmaster).NpcGuild != NpcGuild.ThievesGuild )
				guildmaster.SayTo( player, "I don't think we could let someone like you join." );
			else if ( pm.NpcGuild == ((BaseVendor)guildmaster).NpcGuild )
				guildmaster.SayTo( player, 501047 ); // Thou art already a member of our guild.
			else if ( pm.NpcGuild != NpcGuild.None )
				guildmaster.SayTo( player, 501046 ); // Thou must resign from thy other guild first.
			else
				SayPriceTo( player, guildmaster );
		}

		public static void ResignGuild( Mobile player, Mobile guildmaster )
		{
			PlayerMobile pm = (PlayerMobile)player;

			if ( guildmaster != null && pm.NpcGuild != ((BaseVendor)guildmaster).NpcGuild )
			{
				guildmaster.SayTo( player, 501052 ); // Thou dost not belong to my guild!
			}
			else
			{
				if ( guildmaster == null )
					player.SendMessage(0x22, "You have resigned from the local guild.");
				else
					guildmaster.SayTo( player, 501054 ); // I accept thy resignation.

				pm.NpcGuild = NpcGuild.None;

				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				if ( item is GuildRing )
				{
					GuildRing guildring = (GuildRing)item;
					if ( guildring.RingOwner == player )
					{
						targets.Add( item );
					}
				}
				for ( int i = 0; i < targets.Count; ++i )
				{
					Item item = ( Item )targets[ i ];
					item.Delete();
				}
			}
		}

		public override bool OnGoldGiven( Mobile from, Gold dropped )
		{
			ProcessGuild( from, dropped );
			return base.OnGoldGiven( from, dropped );
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			ProcessGuild( from, dropped );
			return base.OnDragDrop( from, dropped );
		}

		public void ProcessGuild( Mobile from, Item dropped )
		{
			PlayerMobile pm = (PlayerMobile)from;

			int fee = 0;
			if ( dropped is Gold ){ fee = dropped.Amount; }
			else if ( dropped is BankCheck ){ fee = ((BankCheck)dropped).Worth; }

			bool CanProcess = true;

			if ( pm.Fugitive == 1 && NpcGuild != NpcGuild.AssassinsGuild && NpcGuild != NpcGuild.NecromancersGuild && NpcGuild != NpcGuild.ThievesGuild )
				CanProcess = false;

			if ( from is PlayerMobile && !from.Blessed && fee == MyServerSettings.JoiningFee( from ) && CanProcess )
			{
				if ( pm.NpcGuild == this.NpcGuild )
				{
					SayTo( from, 501047 ); // Thou art already a member of our guild.
				}
				else if ( pm.NpcGuild != NpcGuild.None )
				{
					SayTo( from, 501046 ); // Thou must resign from thy other guild first.
				}
				else
				{
					SayWelcomeTo( from );

					pm.NpcGuild = this.NpcGuild;
					pm.NpcGuildJoinTime = DateTime.Now;
					pm.NpcGuildGameTime = pm.GameTime;
					pm.CharacterGuilds++;

					dropped.Delete();

					ArrayList targets = new ArrayList();
					foreach ( Item item in World.Items.Values )
					if ( item is GuildRing )
					{
						GuildRing guildring = (GuildRing)item;
						if ( guildring.RingOwner == from )
						{
							targets.Add( item );
						}
					}
					for ( int i = 0; i < targets.Count; ++i )
					{
						Item item = ( Item )targets[ i ];
						item.Delete();
					}

					int GuildType = 1;
					if ( this.NpcGuild == NpcGuild.MagesGuild ){ GuildType = 1; }
					else if ( this.NpcGuild == NpcGuild.WarriorsGuild ){ GuildType = 2; }
					else if ( this.NpcGuild == NpcGuild.ThievesGuild ){ GuildType = 3; }
					else if ( this.NpcGuild == NpcGuild.RangersGuild ){ GuildType = 4; }
					else if ( this.NpcGuild == NpcGuild.HealersGuild ){ GuildType = 5; }
					else if ( this.NpcGuild == NpcGuild.MinersGuild ){ GuildType = 6; }
					else if ( this.NpcGuild == NpcGuild.MerchantsGuild ){ GuildType = 7; }
					else if ( this.NpcGuild == NpcGuild.TinkersGuild ){ GuildType = 8; }
					else if ( this.NpcGuild == NpcGuild.TailorsGuild ){ GuildType = 9; }
					else if ( this.NpcGuild == NpcGuild.FishermensGuild ){ GuildType = 10; }
					else if ( this.NpcGuild == NpcGuild.BardsGuild ){ GuildType = 11; }
					else if ( this.NpcGuild == NpcGuild.BlacksmithsGuild ){ GuildType = 12; }
					else if ( this.NpcGuild == NpcGuild.NecromancersGuild ){ GuildType = 13; }
					else if ( this.NpcGuild == NpcGuild.AlchemistsGuild ){ GuildType = 14; }
					else if ( this.NpcGuild == NpcGuild.DruidsGuild ){ GuildType = 15; }
					else if ( this.NpcGuild == NpcGuild.ArchersGuild ){ GuildType = 16; }
					else if ( this.NpcGuild == NpcGuild.CarpentersGuild ){ GuildType = 17; }
					else if ( this.NpcGuild == NpcGuild.CartographersGuild ){ GuildType = 18; }
					else if ( this.NpcGuild == NpcGuild.LibrariansGuild ){ GuildType = 19; }
					else if ( this.NpcGuild == NpcGuild.CulinariansGuild ){ GuildType = 20; }
					else if ( this.NpcGuild == NpcGuild.AssassinsGuild ){ GuildType = 21; }
					else if ( this.NpcGuild == NpcGuild.ElementalGuild ){ GuildType = 22; }

					from.AddToBackpack( new GuildRing( from, GuildType ) );
					from.SendSound( 0x3D );
				}
			}
			if ( from is PlayerMobile && fee == 400 && pm.NpcGuild == this.NpcGuild )
			{
				dropped.Delete();

				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				if ( item is GuildRing )
				{
					GuildRing guildring = (GuildRing)item;
					if ( guildring.RingOwner == from )
					{
						targets.Add( item );
					}
				}
				for ( int i = 0; i < targets.Count; ++i )
				{
					Item item = ( Item )targets[ i ];
					item.Delete();
				}

				int GuildType = 1;
				if ( this.NpcGuild == NpcGuild.MagesGuild ){ GuildType = 1; }
				else if ( this.NpcGuild == NpcGuild.WarriorsGuild ){ GuildType = 2; }
				else if ( this.NpcGuild == NpcGuild.ThievesGuild ){ GuildType = 3; }
				else if ( this.NpcGuild == NpcGuild.RangersGuild ){ GuildType = 4; }
				else if ( this.NpcGuild == NpcGuild.HealersGuild ){ GuildType = 5; }
				else if ( this.NpcGuild == NpcGuild.MinersGuild ){ GuildType = 6; }
				else if ( this.NpcGuild == NpcGuild.MerchantsGuild ){ GuildType = 7; }
				else if ( this.NpcGuild == NpcGuild.TinkersGuild ){ GuildType = 8; }
				else if ( this.NpcGuild == NpcGuild.TailorsGuild ){ GuildType = 9; }
				else if ( this.NpcGuild == NpcGuild.FishermensGuild ){ GuildType = 10; }
				else if ( this.NpcGuild == NpcGuild.BardsGuild ){ GuildType = 11; }
				else if ( this.NpcGuild == NpcGuild.BlacksmithsGuild ){ GuildType = 12; }
				else if ( this.NpcGuild == NpcGuild.NecromancersGuild ){ GuildType = 13; }
				else if ( this.NpcGuild == NpcGuild.AlchemistsGuild ){ GuildType = 14; }
				else if ( this.NpcGuild == NpcGuild.DruidsGuild ){ GuildType = 15; }
				else if ( this.NpcGuild == NpcGuild.ArchersGuild ){ GuildType = 16; }
				else if ( this.NpcGuild == NpcGuild.CarpentersGuild ){ GuildType = 17; }
				else if ( this.NpcGuild == NpcGuild.CartographersGuild ){ GuildType = 18; }
				else if ( this.NpcGuild == NpcGuild.LibrariansGuild ){ GuildType = 19; }
				else if ( this.NpcGuild == NpcGuild.CulinariansGuild ){ GuildType = 20; }
				else if ( this.NpcGuild == NpcGuild.AssassinsGuild ){ GuildType = 21; }
				else if ( this.NpcGuild == NpcGuild.ElementalGuild ){ GuildType = 22; }


				Say( "Here is your replacement ring." );
				from.AddToBackpack( new GuildRing( from, GuildType ) );
			}
		}

		public BaseGuildmaster( string title ) : base( title )
		{
			Title = String.Format( "the {0} {1}", title, Female ? "guildmistress" : "guildmaster" );
		}

		public BaseGuildmaster( Serial serial ) : base( serial )
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
	}
}