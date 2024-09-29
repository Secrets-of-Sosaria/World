using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BitterRoot : BaseReagent
	{
		[Constructable]
		public BitterRoot() : this( 1 )
		{
		}

		[Constructable]
		public BitterRoot( int amount ) : base( 0x640C, amount )
		{
			Name = "bitter root";
		}

		public BitterRoot( Serial serial ) : base( serial )
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