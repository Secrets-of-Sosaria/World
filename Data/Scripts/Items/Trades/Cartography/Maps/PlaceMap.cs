using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;

namespace Server.Items
{
	public class PlaceMap : Item
	{
		public override string DefaultDescription{ get{ return "These maps show a faint image of a particular world and the location of a particular place. If you happen to be traveling in that world, you will see a pin that indicates where you are."; } }

		public Map WorldMap;
		public int WorldX;
		public int WorldY;

		[Constructable]
		public PlaceMap() : base( 0x14EB )
		{
			Weight = 1.0;
			ItemID = Utility.RandomList( 0x14EB, 0x14EC );
			Hue = 0xB80;
			Name = "map";

			if ( WorldX == 0 )
			{
				if ( Utility.Random(5) > 0 )
					Name = "Map to " + Worlds.GetAreaEntrance( Utility.RandomMinMax(1,85), null, Map.Internal, out WorldMap, out WorldX, out WorldY );
				else
					Name = "Map to " + Worlds.GetTown( Utility.RandomMinMax(1,28), null, Map.Internal, out WorldMap, out WorldX, out WorldY );
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 4 ) )
			{
				from.CloseGump( typeof( Sextants.MapGump ) );
				from.SendGump( new Sextants.MapGump( from, WorldMap, WorldX, WorldY, this ) );
				from.PlaySound( 0x249 );
			}
			else
			{
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public PlaceMap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 );
            writer.Write( WorldMap );
            writer.Write( WorldX );
            writer.Write( WorldY );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			WorldMap = reader.ReadMap();
			WorldX = reader.ReadInt();
			WorldY = reader.ReadInt();
		}
	}
}