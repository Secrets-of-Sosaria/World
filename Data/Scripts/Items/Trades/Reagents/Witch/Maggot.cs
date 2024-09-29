using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Maggot : BaseReagent
	{
		[Constructable]
		public Maggot() : this( 1 )
		{
		}

		[Constructable]
		public Maggot( int amount ) : base( 0x6410, amount )
		{
			Name = "maggot";
		}

		public Maggot( Serial serial ) : base( serial )
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