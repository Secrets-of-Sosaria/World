using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class VampiricEmbraceScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 112 ); } }

		[Constructable]
		public VampiricEmbraceScroll() : this( 1 )
		{
		}

		[Constructable]
		public VampiricEmbraceScroll( int amount ) : base( 112, 0x226C, amount )
		{
			Name = "vampric embrace scroll";
		}

		public VampiricEmbraceScroll( Serial serial ) : base( serial )
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
			Name = "vampiric embrace scroll";
		}
	}
}