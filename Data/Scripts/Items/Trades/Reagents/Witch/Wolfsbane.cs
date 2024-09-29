using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Wolfsbane : BaseReagent
	{
		[Constructable]
		public Wolfsbane() : this( 1 )
		{
		}

		[Constructable]
		public Wolfsbane( int amount ) : base( 0x6414, amount )
		{
			Name = "wolfsbane";
		}

		public Wolfsbane( Serial serial ) : base( serial )
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