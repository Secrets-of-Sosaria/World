using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PainSpikeScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 108 ); } }

		[Constructable]
		public PainSpikeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PainSpikeScroll( int amount ) : base( 108, 0x2268, amount )
		{
			Name = "pain spike scroll";
		}

		public PainSpikeScroll( Serial serial ) : base( serial )
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
			Name = "pain spike scroll";
		}
	}
}