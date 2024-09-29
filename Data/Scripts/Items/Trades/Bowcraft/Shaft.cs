using System;
using Server.Items;

namespace Server.Items
{
	public class Shaft : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Shaft() : this( 1 )
		{
		}

		[Constructable]
		public Shaft( int amount ) : base( 0x1BD4 )
		{
			Stackable = true;
			Amount = amount;
			Name = "shaft";
			Built = true;
		}

		public Shaft( Serial serial ) : base( serial )
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
			Name = "shaft";
			Built = true;
		}
	}
}