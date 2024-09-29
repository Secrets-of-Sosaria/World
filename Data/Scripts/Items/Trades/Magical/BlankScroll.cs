using System;

namespace Server.Items
{
	public class BlankScroll : Item
	{
		public override string DefaultDescription{ get{ return "These scrolls have nothing written on them. They are used by scribes to create spells and books, or by cartographers to make maps."; } }

		[Constructable]
		public BlankScroll() : this( 1 )
		{
		}

		[Constructable]
		public BlankScroll( int amount ) : base( 0xEF3 )
		{
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
		}

		public BlankScroll( Serial serial ) : base( serial )
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
			Weight = 0.1;
		}
	}
}