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
	public class WorldMapLodor : Item
	{
		[Constructable]
		public WorldMapLodor( ) : base( 0x4CC2 )
		{
			Name = "World Map of Lodoria";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(652, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(652, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(276, 0, 9391);
				AddImage(333, 0, 9391);
				AddImage(389, 0, 9391);
				AddImage(430, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(273, 506, 9397);
				AddImage(327, 506, 9397);
				AddImage(380, 506, 9397);
				AddImage(422, 506, 9397);
				AddImage(487, 0, 9391);
				AddImage(596, 0, 9391);
				AddImage(541, 0, 9391);
				AddImage(652, 0, 9391);
				AddImage(476, 506, 9397);
				AddImage(532, 506, 9397);
				AddImage(585, 506, 9397);
				AddImage(636, 506, 9397);
				AddImage(14, 29, 10869);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapLodor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Lodoria;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapSosaria : Item
	{
		[Constructable]
		public WorldMapSosaria( ) : base( 0x4CC2 )
		{
			Name = "World Map of Sosaria";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(880, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(880, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(276, 0, 9391);
				AddImage(333, 0, 9391);
				AddImage(389, 0, 9391);
				AddImage(430, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(273, 506, 9397);
				AddImage(327, 506, 9397);
				AddImage(380, 506, 9397);
				AddImage(422, 506, 9397);
				AddImage(487, 0, 9391);
				AddImage(596, 0, 9391);
				AddImage(541, 0, 9391);
				AddImage(652, 0, 9391);
				AddImage(709, 0, 9391);
				AddImage(765, 0, 9391);
				AddImage(806, 0, 9391);
				AddImage(862, 0, 9391);
				AddImage(476, 506, 9397);
				AddImage(532, 506, 9397);
				AddImage(585, 506, 9397);
				AddImage(636, 506, 9397);
				AddImage(690, 506, 9397);
				AddImage(743, 506, 9397);
				AddImage(785, 506, 9397);
				AddImage(842, 506, 9397);
				AddImage(14, 29, 10870);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapSosaria(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Sosaria;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapBottle : Item
	{
		[Constructable]
		public WorldMapBottle( ) : base( 0x4CC2 )
		{
			Name = "World Map of Kuldar";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(235, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(234, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(14, 29, 1101);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapBottle(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Kuldar;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapSerpent : Item
	{
		[Constructable]
		public WorldMapSerpent( ) : base( 0x4CC2 )
		{
			Name = "World Map of the Serpent Island";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(453, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(452, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(276, 0, 9391);
				AddImage(333, 0, 9391);
				AddImage(389, 0, 9391);
				AddImage(430, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(273, 506, 9397);
				AddImage(327, 506, 9397);
				AddImage(380, 506, 9397);
				AddImage(422, 506, 9397);
				AddImage(487, 0, 9391);
				AddImage(476, 506, 9397);
				AddImage(14, 29, 5596);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapSerpent(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Serpent;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapUmber : Item
	{
		[Constructable]
		public WorldMapUmber( ) : base( 0x4CC2 )
		{
			Name = "World Map of Umber Veil";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(873, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(874, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(276, 506, 9397);
				AddImage(332, 506, 9397);
				AddImage(385, 506, 9397);
				AddImage(442, 506, 9397);
				AddImage(498, 506, 9397);
				AddImage(551, 506, 9397);
				AddImage(605, 506, 9397);
				AddImage(661, 506, 9397);
				AddImage(714, 506, 9397);
				AddImage(770, 506, 9397);
				AddImage(826, 506, 9397);
				AddImage(879, 506, 9397);
				AddImage(276, 0, 9391);
				AddImage(385, 0, 9391);
				AddImage(330, 0, 9391);
				AddImage(441, 0, 9391);
				AddImage(550, 0, 9391);
				AddImage(495, 0, 9391);
				AddImage(607, 0, 9391);
				AddImage(716, 0, 9391);
				AddImage(661, 0, 9391);
				AddImage(769, 0, 9391);
				AddImage(878, 0, 9391);
				AddImage(823, 0, 9391);
				AddImage(14, 29, 11414);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapUmber(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.UmberVeil;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapAmbrosia : Item
	{
		[Constructable]
		public WorldMapAmbrosia( ) : base( 0x4CC2 )
		{
			Name = "World Map of Ambrosia";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(471, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(471, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(276, 0, 9391);
				AddImage(333, 0, 9391);
				AddImage(389, 0, 9391);
				AddImage(430, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(273, 506, 9397);
				AddImage(327, 506, 9397);
				AddImage(380, 506, 9397);
				AddImage(422, 506, 9397);
				AddImage(14, 29, 11413);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapAmbrosia(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Ambrosia;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapIslesOfDread : Item
	{
		[Constructable]
		public WorldMapIslesOfDread( ) : base( 0x4CC2 )
		{
			Name = "World Map of the Isles of Dread";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(504, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(503, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(277, 506, 9397);
				AddImage(333, 506, 9397);
				AddImage(386, 506, 9397);
				AddImage(432, 506, 9397);
				AddImage(488, 506, 9397);
				AddImage(276, 0, 9391);
				AddImage(385, 0, 9391);
				AddImage(330, 0, 9391);
				AddImage(439, 0, 9391);
				AddImage(493, 0, 9391);
				AddImage(14, 29, 5597);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapIslesOfDread(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.IslesDread;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapSavage : Item
	{
		[Constructable]
		public WorldMapSavage( ) : base( 0x4CC2 )
		{
			Name = "World Map of the Savaged Empire";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(252, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(251, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(14, 29, 5598);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapSavage(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Savaged;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WorldMapUnderworld : Item
	{
		[Constructable]
		public WorldMapUnderworld( ) : base( 0x4CC2 )
		{
			Name = "Whole Map of the Underworld";
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Hue = 0xB63;
		}

		public class WorldMapGump : Gump
		{
			public WorldMapGump( Mobile from ): base( 25, 25 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9390);
				AddImage(512, 0, 9392);
				AddImage(2, 506, 9396);
				AddImage(512, 506, 9398);
				AddImage(111, 0, 9391);
				AddImage(220, 0, 9391);
				AddImage(165, 0, 9391);
				AddImage(113, 506, 9397);
				AddImage(169, 506, 9397);
				AddImage(222, 506, 9397);
				AddImage(276, 506, 9397);
				AddImage(332, 506, 9397);
				AddImage(385, 506, 9397);
				AddImage(442, 506, 9397);
				AddImage(498, 506, 9397);
				AddImage(276, 0, 9391);
				AddImage(385, 0, 9391);
				AddImage(330, 0, 9391);
				AddImage(441, 0, 9391);
				AddImage(495, 0, 9391);
				AddImage(14, 29, 1126);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WorldMapGump ) );
				e.SendGump( new WorldMapGump( e ) );
				e.PlaySound( 0x249 );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WorldMapUnderworld(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new MapWorld();
			((MapWorld)item).WorldMap = Land.Underworld;
			item.Name = "world map";
			item.ColorText3 = Lands.LandName( ((MapWorld)item).WorldMap );
			item.ColorHue3 = "63B95F";
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}