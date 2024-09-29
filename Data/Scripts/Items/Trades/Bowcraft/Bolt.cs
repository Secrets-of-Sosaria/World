using System;
using Server.Mobiles;

namespace Server.Items
{
	public class Bolt : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Bolt() : this( 1 )
		{
		}

		[Constructable]
		public Bolt( int amount ) : base( 0x1BFB )
		{
			Stackable = true;
			Amount = amount;
			Name = "bolt";
			Built = true;
		}

		public Bolt( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m is PlayerMobile && m.Alive && Movable )
			{
				m.PlaceInBackpack( this );
			}
			return true;
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
			Name = "bolt";
			Built = true;
		}
	}
}