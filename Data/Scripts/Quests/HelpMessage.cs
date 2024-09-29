using System;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public class HelpMessage : Item
	{
		public override bool HandlesOnMovement{ get{ return true; } }

		private DateTime m_NextTalk;
		public DateTime NextTalk{ get{ return m_NextTalk; } set{ m_NextTalk = value; } }

		public override void OnMovement( Mobile from, Point3D oldLocation )
		{
			if( from is PlayerMobile )
			{
				if ( DateTime.Now >= m_NextTalk && Utility.InRange( from.Location, this.Location, 5 ) )
				{
					if ( Name == "gypsy bag" ){ from.SendMessage( 68, "Double click the backpack, on your character window, to open it." ); }
					else if ( Name == "gypsy help" ){ from.SendMessage( 68, "Single click the gypsy and select 'Talk' to speak with her." ); }

					m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( 15 ));
				}
			}
		}

		[Constructable]
		public HelpMessage( ) : base( 0x181E )
		{
			Movable = false;
			Visible = false;
			Name = "help";
		}

		public HelpMessage( Serial serial ) : base( serial )
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
		}
	}	
}