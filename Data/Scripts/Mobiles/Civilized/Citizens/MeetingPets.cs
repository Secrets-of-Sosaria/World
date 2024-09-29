using System;
using Server; 

namespace Server.Items
{
	public class MeetingPets : Item
	{
		[Constructable]
		public MeetingPets() : base( 0x6519 )
		{
			Name = "meeting pets";
			Visible = false;
			Movable = false;
		}

		public MeetingPets( Serial serial ) : base( serial )
		{
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