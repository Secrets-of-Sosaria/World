using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
	public class PrisonExit : Item
	{
		[Constructable]
		public PrisonExit() : base(0x1BC3)
		{
			Movable = false;
			Visible = false;
			Name = "teleporter";
		}

		public PrisonExit(Serial serial) : base(serial)
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			Point3D p = Worlds.GetRandomLocation( m.Land, "land" );
			Map map = Worlds.GetMyDefaultMap( m.Land );

			if ( p != Point3D.Zero && m is PlayerMobile )
			{
				Server.Mobiles.BaseCreature.TeleportPets( m, p, map );
				m.MoveToWorld( p, map );
				m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The tunnel leads you to the surface of the land!");
			}

			return false;
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