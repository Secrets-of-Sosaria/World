using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PoisonStrikeScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 109 ); } }

		[Constructable]
		public PoisonStrikeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoisonStrikeScroll( int amount ) : base( 109, 0x2269, amount )
		{
			Name = "poison strike scroll";
		}

		public PoisonStrikeScroll( Serial serial ) : base( serial )
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
			Name = "poison strike scroll";
		}
	}
}