using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
	public class RaceTeleporter : Item
	{
		[Constructable]
		public RaceTeleporter() : base(0x1B72)
		{
			Movable = false;
			Visible = false;
			Name = "teleporter";
		}

		public RaceTeleporter(Serial serial) : base(serial)
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				UseTeleporter( m );
			}

			return false;
		}

		public override void OnDoubleClick( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				UseTeleporter( m );
			}
		}

        public override void OnDoubleClickDead( Mobile m )
        {
			if ( m is PlayerMobile )
			{
				UseTeleporter( m );
			}
        }

		public void UseTeleporter( Mobile m )
		{
			Point3D loc = new Point3D(0, 0, 0);
			Point3D cur = this.Location;
			Map map = Map.Sosaria;
			bool allow = false;
			int sound = 0;

			if ( this.Name == "kraken" && m is PlayerMobile && Server.Items.BaseRace.IsEvilSeaCreature( m ) && m.RaceHomeLand == 2 )
			{
				loc = new Point3D(5520, 4036, 0);
				map = Map.Lodor;
				sound = 0x026;
				allow = true;
			}
			else if ( this.Name == "anchor" && m is PlayerMobile && Server.Items.BaseRace.IsEvilSeaCreature( m ) && m.RaceHomeLand == 1 )
			{
				loc = new Point3D(7085, 343, 0);
				map = Map.Sosaria;
				sound = 0x026;
				allow = true;
			}
			else if ( this.Name == "gargoyle" && m is PlayerMobile && Server.Items.BaseRace.IsEvilDemonCreature( m ) )
			{
				loc = new Point3D(2521, 1011, 0);
				map = Map.SerpentIsland;
				sound = 0x208;
				allow = true;
			}
			else if ( this.Name == "furnace" && m is PlayerMobile && !Server.Items.BaseRace.IsEvilDemonCreature( m ) )
			{
				loc = new Point3D(cur.X+2, cur.Y, cur.Z+5);
				map = Map.SerpentIsland;
				sound = 236;
				allow = true;
			}
			else if ( this.Name == "furnace" && m is PlayerMobile && Server.Items.BaseRace.IsEvilDemonCreature( m ) && PlayerSettings.GetDiscovered( m, "the Serpent Island" ) )
			{
				loc = new Point3D(cur.X+2, cur.Y, cur.Z+5);
				map = Map.SerpentIsland;
				sound = 236;
				allow = true;
			}
			else if ( this.Name == "furnace" && m is PlayerMobile && Server.Items.BaseRace.IsEvilDemonCreature( m ) && !PlayerSettings.GetDiscovered( m, "the Serpent Island" ) )
			{
				m.SendMessage( "The guards feel it is unsafe to leave the city!" );
			}
			else if ( this.Name == "dead" && m is PlayerMobile && Server.Items.BaseRace.IsEvilDeadCreature( m ) && m.RaceHomeLand == 2 )
			{
				loc = new Point3D(5281, 3664, 0);
				map = Map.Lodor;
				sound = 235;
				allow = true;
			}
			else if ( this.Name == "dead" )
			{
				m.SendMessage( "The doors seem to be rusted shut!" );
			}
			else if ( this.Name == "umbra" && m is PlayerMobile && Server.Items.BaseRace.IsEvilDeadCreature( m ) && m.RaceHomeLand == 1 )
			{
				loc = new Point3D(cur.X, cur.Y-1, cur.Z);
					if ( m.Y < cur.Y )
						loc = new Point3D(cur.X, cur.Y+1, cur.Z);
				map = Map.Sosaria;
				sound = 235;
				allow = true;
			}
			else if ( this.Name == "umbra" )
			{
				m.SendMessage( "The doors seem to be rusted shut!" );
			}

			if ( allow )
			{
				Server.Mobiles.BaseCreature.TeleportPets( m, loc, map );
				m.MoveToWorld( loc, map );
				m.PlaySound( sound );
			}
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