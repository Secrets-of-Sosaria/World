using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class NoxCrystal : BaseReagent
	{
		[Constructable]
		public NoxCrystal() : this( 1 )
		{
		}

		[Constructable]
		public NoxCrystal( int amount ) : base( 0xF8E, amount )
		{
		}

		public NoxCrystal( Serial serial ) : base( serial )
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