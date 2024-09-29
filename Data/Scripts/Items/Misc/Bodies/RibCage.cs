using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x1B17, 0x1B18 )]
	public class RibCage : Item, IScissorable
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		[Constructable]
		public RibCage() : base( 0x1B17 + Utility.Random( 2 ) )
		{
			Stackable = false;
			Weight = 1.0;
		}

		public RibCage( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) )
				return false;

			base.ScissorHelper( from, new BrittleSkeletal(), Utility.RandomMinMax( 3, 5 ) );

			return true;
		}
	}
}