using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SummonFamiliarScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 111 ); } }

		[Constructable]
		public SummonFamiliarScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonFamiliarScroll( int amount ) : base( 111, 0x226B, amount )
		{
			Name = "summon familiar scroll";
		}

		public SummonFamiliarScroll( Serial serial ) : base( serial )
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
			Name = "summon familiar scroll";
		}
	}
}