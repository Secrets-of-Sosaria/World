using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;

namespace Server.Items
{
	public class MapWorld : Item, ICraftable
	{
		public override string DefaultDescription{ get{ return "These maps show a faint image of a particular world. If you happen to be traveling in that world, you will see a pin that indicates where you are."; } }

		public Land WorldMap;
		
		[CommandProperty(AccessLevel.Owner)]
		public Land World_Map { get { return WorldMap; } set { WorldMap = value; InvalidateProperties(); } }

		[Constructable]
		public MapWorld() : base( 0x4CC2 )
		{
			Weight = 1.0;
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;

			switch ( Utility.Random( 10 ) ) 
			{
				case 0: WorldMap = Land.Ambrosia; break;
				case 1: WorldMap = Land.UmberVeil; break;
				case 2: WorldMap = Land.Serpent; break;
				case 3: WorldMap = Land.IslesDread; break;
				case 4: WorldMap = Land.Savaged; break;
				case 5: WorldMap = Land.Kuldar; break;
				case 6: WorldMap = Land.Sosaria; break;
				case 7: WorldMap = Land.Lodoria; break;
				case 8: WorldMap = Land.Lodoria; break;
				case 9: WorldMap = Land.Underworld; break;
			}

			if ( WorldMap == Land.None )
				WorldMap = Land.Sosaria;

			Name = "world map";
			ColorText3 = Lands.LandName( WorldMap );
			ColorHue3 = "63B95F";
		}

		public int OnCraft( int quality, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			CraftInit( from );
			return 1;
		}

		public virtual void CraftInit( Mobile from )
		{
            Map map = from.Map;

            if (map == Map.Sosaria && from.X>5124 && from.Y>3041 && from.X<6147 && from.Y<4092)
				WorldMap = Land.Ambrosia;
            else if (map == Map.Sosaria && from.X>859 && from.Y>3181 && from.X<2133 && from.Y<4092)
				WorldMap = Land.UmberVeil;
            else if (map == Map.SerpentIsland && from.X<1870)
				WorldMap = Land.Serpent;
            else if (map == Map.IslesDread)
				WorldMap = Land.IslesDread;
            else if (map == Map.SavagedEmpire && from.X>132 && from.Y>4 && from.X<1165 && from.Y<1798)
				WorldMap = Land.Savaged;
            else if (map == Map.Sosaria && from.X>6125 && from.Y>824 && from.X<7175 && from.Y<2746)
				WorldMap = Land.Kuldar;
            else if (map == Map.Sosaria && from.X<5121 && from.Y<3128)
				WorldMap = Land.Sosaria;
            else if (map == Map.Lodor && from.X>6442 && from.Y>3051 && from.X<7007 && from.Y<3478)
				WorldMap = Land.Lodoria;
            else if (map == Map.Lodor && from.X<5420 && from.Y<4096)
				WorldMap = Land.Lodoria;
            else if (map == Map.Underworld && from.X<1581 && from.Y<1599)
				WorldMap = Land.Underworld;

			if ( WorldMap == Land.None )
				WorldMap = Land.Sosaria;

			Name = "world map";
			ColorText3 = Lands.LandName( WorldMap );
			ColorHue3 = "63B95F";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 4 ) )
			{
				from.CloseGump( typeof( Sextants.MapGump ) );
				from.SendGump( new Sextants.MapGump( from, Lands.MapName( WorldMap ), from.X, from.Y, this ) );
				from.PlaySound( 0x249 );
			}
			else
			{
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public MapWorld( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 );
            writer.Write( (int)WorldMap );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version > 0 )
			{
				WorldMap = (Land)reader.ReadInt();
			}
			else if ( version < 1 )
			{
				int world = reader.ReadInt();

				if (world == 1) 
					WorldMap = Land.Sosaria;
				else if (world == 2) 
					WorldMap = Land.Lodoria;
				else if (world == 4) 
					WorldMap = Land.Serpent;
				else if (world == 5) 
					WorldMap = Land.IslesDread;
				else if (world == 6) 
					WorldMap = Land.Savaged;
				else if (world == 7) 
					WorldMap = Land.Ambrosia;
				else if (world == 8) 
					WorldMap = Land.UmberVeil;
				else if (world == 9) 
					WorldMap = Land.Kuldar;
				else if (world == 10) 
					WorldMap = Land.Underworld;

				if ( WorldMap == Land.None )
					WorldMap = Land.Sosaria;

				Name = "world map";
				ColorText3 = Lands.LandName( WorldMap );
				ColorHue3 = "63B95F";
			}

			if ( ItemID != 0x4CC2 && ItemID != 0x4CC3 ){ ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 ); }
			Hue = 0xB63;
		}
	}
}