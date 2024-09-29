using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class VioletFungus : BaseReagent
	{
		[Constructable]
		public VioletFungus() : this( 1 )
		{
		}

		[Constructable]
		public VioletFungus( int amount ) : base( 0x6412, amount )
		{
			Name = "violet fungus";
		}

		public VioletFungus( Serial serial ) : base( serial )
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