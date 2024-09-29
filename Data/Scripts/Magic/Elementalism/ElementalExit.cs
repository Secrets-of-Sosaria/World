using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
	public class ElementalExit : Item
	{
		[Constructable]
		public ElementalExit() : base(0x1B72)
		{
			Movable = false;
			Visible = false;
			Name = "lyceum exit";
		}

		public ElementalExit(Serial serial) : base(serial)
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				string sPublicDoor = ((PlayerMobile)m).CharacterPublicDoor;

				Point3D loc = new Point3D(1831, 758, 12);
				Map map = Map.Sosaria;
				bool success = false;

				if ( sPublicDoor != null )
				{
					int mX = 0;
					int mY = 0;
					int mZ = 0;
					Map mWorld = null;
					string mZone = "";

					string[] sPublicDoors = sPublicDoor.Split('#');
					int nEntry = 1;
					foreach (string exits in sPublicDoors)
					{
						if ( nEntry == 1 ){ mX = Convert.ToInt32(exits); }
						else if ( nEntry == 2 ){ mY = Convert.ToInt32(exits); }
						else if ( nEntry == 3 ){ mZ = Convert.ToInt32(exits); }
						else if ( nEntry == 4 ){ try { mWorld = Map.Parse( exits ); } catch{} if ( mWorld == null ){ mWorld = Map.Sosaria; } }
						else if ( nEntry == 5 ){ mZone = exits; }
						nEntry++;
					}

					loc = new Point3D( mX, mY, mZ );
					map = mWorld;

					if ( loc != Point3D.Zero )
					{
						Server.Mobiles.BaseCreature.TeleportPets( m, loc, map );
						m.MoveToWorld( loc, map );
						success = true;
					}
				}
				if ( !success )
				{
					loc = new Point3D(1831, 758, 12);
					map = Map.Sosaria;
					Server.Mobiles.BaseCreature.TeleportPets( m, loc, map );
					m.MoveToWorld( loc, map );
					m.LocalOverheadMessage(MessageType.Emote, 1150, true, "You emerge from the portal into the open land.");
				}

				Item gate = new ElementalEffect( 0x3D5E, 5.0, null );
				gate.Name = "magic portal";
				gate.Hue = 0xAFE;
				gate.Movable = false;
				gate.Light = LightType.Circle300;
				gate.MoveToWorld( loc, map );
				Effects.PlaySound( loc, map, 0x20E );

				((PlayerMobile)m).CharacterPublicDoor = null;
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