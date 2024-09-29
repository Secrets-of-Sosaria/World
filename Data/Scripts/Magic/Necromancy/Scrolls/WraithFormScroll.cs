using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class WraithFormScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 115 ); } }

		[Constructable]
		public WraithFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public WraithFormScroll( int amount ) : base( 115, 0x226F, amount )
		{
			Name = "wraith form scroll";
		}

		public WraithFormScroll( Serial serial ) : base( serial )
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
			Name = "wraith form scroll";
		}
	}
}