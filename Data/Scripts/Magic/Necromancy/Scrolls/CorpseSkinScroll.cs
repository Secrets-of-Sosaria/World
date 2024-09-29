using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CorpseSkinScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 102 ); } }

		[Constructable]
		public CorpseSkinScroll() : this( 1 )
		{
		}

		[Constructable]
		public CorpseSkinScroll( int amount ) : base( 102, 0x2262, amount )
		{
			Name = "corpse skin scroll";
		}

		public CorpseSkinScroll( Serial serial ) : base( serial )
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
			Name = "corpse skin scroll";
		}
	}
}