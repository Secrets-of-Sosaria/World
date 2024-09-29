using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class AnimateDeadScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 100 ); } }

		[Constructable]
		public AnimateDeadScroll() : this( 1 )
		{
		}

		[Constructable]
		public AnimateDeadScroll( int amount ) : base( 100, 0x2260, amount )
		{
			Name = "animate dead scroll";
		}

		public AnimateDeadScroll( Serial serial ) : base( serial )
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
			Name = "animate dead scroll";
		}
	}
}