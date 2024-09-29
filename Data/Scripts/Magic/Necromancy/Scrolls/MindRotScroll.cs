using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MindRotScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 107 ); } }

		[Constructable]
		public MindRotScroll() : this( 1 )
		{
		}

		[Constructable]
		public MindRotScroll( int amount ) : base( 107, 0x2267, amount )
		{
			Name = "mind rot scroll";
		}

		public MindRotScroll( Serial serial ) : base( serial )
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
			Name = "mind rot scroll";
		}
	}
}