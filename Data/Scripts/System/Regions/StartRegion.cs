using System;
using System.Xml;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fourth;
using Server.Spells.Sixth;
using Server.Spells.Chivalry;
using System.Text;
using System.IO;

namespace Server.Regions
{
	public class StartRegion : BaseRegion
	{
		public StartRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override TimeSpan GetLogoutDelay( Mobile m )
		{
			return TimeSpan.Zero;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			if ( this.Name == "the Forest" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Swamp" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Tomb" )
				global = LightCycle.DungeonLevel;
			else if ( this.Name == "the Sea" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Pits" )
				global = LightCycle.DungeonLevel;
			else if ( this.Name == "the Woods" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Cave" )
				global = LightCycle.DungeonLevel;
			else if ( this.Name == "the Tundra" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Desert" )
				global = LightCycle.NightLevel;
			else if ( this.Name == "the Mountains" )
				global = LightCycle.NightLevel;
		}

		public override bool AllowHarmful( Mobile from, Mobile target )
		{
			if (( from is PlayerMobile ) && ( target is PlayerMobile ))
				return false;
			else
				return base.AllowHarmful( from, target );
		}

		public override bool OnBeginSpellCast( Mobile m, ISpell s )
		{
			m.SendMessage( "That does not seem to work here." );
			return false;
		}
		
		public override void OnEnter( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				m.CloseGump( typeof( NameAlterGump ) );
				m.CloseGump( typeof( WelcomeGump ) );
				m.CloseGump( typeof( MonsterGump ) );
				m.CloseGump( typeof( Joeku.MOTD.MOTD_Gump ) );

				if ( this.Name == "the Forest" )
					m.SendGump( new WelcomeGump( m ) );
				else
					m.SendGump( new MonsterGump( m ) );
			}
		}
		
		public override void OnExit( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				m.CloseGump( typeof( NameAlterGump ) );
				m.CloseGump( typeof( WelcomeGump ) );
				m.CloseGump( typeof( MonsterGump ) );
				m.CloseGump( typeof( Joeku.MOTD.MOTD_Gump ) );
				m.SendGump( new Joeku.MOTD.MOTD_Gump( m, false, 0, 0 ) );
			}
		}
	}
}