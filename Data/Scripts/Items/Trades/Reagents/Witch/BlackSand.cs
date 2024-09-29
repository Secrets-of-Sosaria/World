using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BlackSand : BaseReagent
	{
		[Constructable]
		public BlackSand() : this( 1 )
		{
		}

		[Constructable]
		public BlackSand( int amount ) : base( 0x640D, amount )
		{
			Name = "black sand";
		}

		public BlackSand( Serial serial ) : base( serial )
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