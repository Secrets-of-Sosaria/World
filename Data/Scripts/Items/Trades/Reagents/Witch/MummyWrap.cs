using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MummyWrap : BaseReagent
	{
		[Constructable]
		public MummyWrap() : this( 1 )
		{
		}

		[Constructable]
		public MummyWrap( int amount ) : base( 0x6411, amount )
		{
			Name = "mummy wrap";
		}

		public MummyWrap( Serial serial ) : base( serial )
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