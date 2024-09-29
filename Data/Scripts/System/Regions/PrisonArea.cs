using System;
using System.Xml;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Spells;
using System.Text;
using System.IO;
using Server.Network;
using System.Collections;
using Server.Misc;
using Server.Items;

namespace Server.Regions
{
	public class PrisonArea : BaseRegion
	{
		public PrisonArea( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
			global = LightCycle.DungeonLevel;
		}

		public override bool AllowHarmful( Mobile from, Mobile target )
		{
			return false;
		}

		public override bool OnBeginSpellCast( Mobile m, ISpell s )
		{
			m.SendMessage( "That does not seem to work here." );
			return false;
		}

		public override void OnEnter( Mobile m )
		{
			base.OnEnter( m );
			if ( m is PlayerMobile )
			{
				m.CloseGump( typeof( PrisonGump ) );
				m.SendGump( new PrisonGump( m ) );
			}

			Server.Misc.RegionMusic.MusicRegion( m, this );
		}
	}
}