using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class WitherScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 114 ); } }

		[Constructable]
		public WitherScroll() : this( 1 )
		{
		}

		[Constructable]
		public WitherScroll( int amount ) : base( 114, 0x226E, amount )
		{
			Name = "wither scroll";
		}

		public WitherScroll( Serial serial ) : base( serial )
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
			Name = "wither scroll";
		}
	}
}