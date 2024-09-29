using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class LichFormScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 106 ); } }

		[Constructable]
		public LichFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public LichFormScroll( int amount ) : base( 106, 0x2266, amount )
		{
			Name = "lich form scroll";
		}

		public LichFormScroll( Serial serial ) : base( serial )
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
			Name = "lich form scroll";
		}
	}
}