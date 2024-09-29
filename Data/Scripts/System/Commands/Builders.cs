using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using System.IO;
using Server.Targeting;
using System.Text;

namespace Server.Scripts.Commands 
{
    public class Builder
    {
        public static void Initialize()
        {
            CommandSystem.Register("Builders", AccessLevel.Counselor, new CommandEventHandler( Builders ));
        }

        [Usage("Builders")]
        [Description("A large scale command to build something specific.")]
        public static void Builders( CommandEventArgs e )
        {
			Console.WriteLine( "Builder Command Running..." );

			Command_1();
			Command_2();
			Command_3();
			Command_4();

			Console.WriteLine( "Builder Complete!" );
        }

		public static void Command_1()
		{
			bool run = true;
			int x = 0;
			int y = 0;
			int z = 0;
			Map map = Map.SavagedEmpire;
			Point3D loc = new Point3D( 0, 0, 0 );

			while ( run )
			{
				if ( PickMe( map, x, y ) )
				{
					z = map.GetAverageZ( x, y );
					loc = new Point3D( x, y, z );
					InternalItem item = new InternalItem( loc, map );
					item.MoveToWorld( loc, map );
				}

				x++;

				if ( x > 1168 )
				{
					x = 0;
					y++;
				}

				if ( y > 1798 )
					run = false;
			}
		}

		public static void Command_2()
		{
			bool run = true;
			int x = 0;
			int y = 0;
			int z = 0;
			Map map = Map.Lodor;
			Point3D loc = new Point3D( 0, 0, 0 );

			while ( run )
			{
				if ( PickMe( map, x, y ) )
				{
					z = map.GetAverageZ( x, y );
					loc = new Point3D( x, y, z );
					InternalItem item = new InternalItem( loc, map );
					item.MoveToWorld( loc, map );
				}

				x++;

				if ( x > 5120 )
				{
					x = 0;
					y++;
				}

				if ( y > 4095 )
					run = false;
			}
		}

		public static void Command_3()
		{
			bool run = true;
			int x = 5130;
			int y = 3040;
			int z = 0;
			Map map = Map.Sosaria;
			Point3D loc = new Point3D( 0, 0, 0 );

			while ( run )
			{
				if ( PickMe( map, x, y ) )
				{
					z = map.GetAverageZ( x, y );
					loc = new Point3D( x, y, z );
					InternalItem item = new InternalItem( loc, map );
					item.MoveToWorld( loc, map );
				}

				x++;

				if ( x > 6120 )
				{
					x = 5130;
					y++;
				}

				if ( y > 4095 )
					run = false;
			}
		}

		public static void Command_4()
		{
			bool run = true;
			int x = 6132;
			int y = 832;
			int z = 0;
			Map map = Map.Sosaria;
			Point3D loc = new Point3D( 0, 0, 0 );

			while ( run )
			{
				if ( PickMe( map, x, y ) )
				{
					z = map.GetAverageZ( x, y );
					loc = new Point3D( x, y, z );
					InternalItem item = new InternalItem( loc, map );
					item.MoveToWorld( loc, map );
				}

				x++;

				if ( x > 7162 )
				{
					x = 6132;
					y++;
				}

				if ( y > 2738 )
					run = false;
			}
		}

		public static bool PickMe( Map map, int x, int y )
		{
			bool success = false;
			Point3D loc = new Point3D(0,0,0);

			StaticTile[] tiles = map.Tiles.GetStaticTiles( x, y, true );

			for ( int i = 0; i < tiles.Length; ++i )
			{
				if ( IsValid( tiles[i].ID ) )
				{
					if ( Terrains.GetTerrain( map, loc, x, y ) == Terrain.Dirt && map == Map.Sosaria ){}
					else
						success = true;
				}
			}

			return success;
		}

		public static bool IsValid( int id )
		{
			if ( 	id == 0xCCA || 
					id == 0xCCB || 
					id == 0xCCC || 
					id == 0xCCD || 
					id == 0xCCE || 
					id == 0xCCF || 
					id == 0xCD0 || 
					id == 0xCD1 || 
					id == 0xCD2 || 
					id == 0xCD3 || 
					id == 0xCD4 || 
					id == 0xCD5 || 
					id == 0xCD6 || 
					id == 0xCD7 || 
					id == 0xCD8 || 
					id == 0xCD9 || 
					id == 0xCDA || 
					id == 0xCDB || 
					id == 0xCDC || 
					id == 0xCDD || 
					id == 0xCDE || 
					id == 0xCDF || 
					id == 0xCE0 || 
					id == 0xCE1 || 
					id == 0xCE2 || 
					id == 0xCE3 || 
					id == 0xCE4 || 
					id == 0xCE5 || 
					id == 0xCE6 || 
					id == 0xCE7 || 
					id == 0xCE8 || 
					id == 0xD94 || 
					id == 0xD95 || 
					id == 0xD96 || 
					id == 0xD97 || 
					id == 0xD98 || 
					id == 0xD99 || 
					id == 0xD9A || 
					id == 0xD9B || 
					id == 0xD9C || 
					id == 0xD9D || 
					id == 0xD9E || 
					id == 0xD9F || 
					id == 0xDA0 || 
					id == 0xDA1 || 
					id == 0xDA2 || 
					id == 0xDA3 || 
					id == 0xDA4 || 
					id == 0xDA5 || 
					id == 0xDA6 || 
					id == 0xDA7 || 
					id == 0xDA8 || 
					id == 0xDA9 || 
					id == 0xDAA || 
					id == 0xDAB ){ return true; }

			return false;
		}

		public static int ExportID()
		{
			return 0x35D2; // SET THIS TO A SPECIFIC ITEM ID YOU WANT FROZEN
			//return 0;
		}

		private class InternalItem : Item
		{
			public InternalItem( Point3D loc, Map map ) : base( 0x35D2 )
			{
				Movable = false;
				Name = "ice";
				MoveToWorld( loc, map );
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );
				writer.Write( (int)0 ); // version
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );
				int version = reader.ReadInt();
			}
		}

    }
}