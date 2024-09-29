using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class VengefulSpiritScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 113 ); } }

		[Constructable]
		public VengefulSpiritScroll() : this( 1 )
		{
		}

		[Constructable]
		public VengefulSpiritScroll( int amount ) : base( 113, 0x226D, amount )
		{
			Name = "vengeful spirit scroll";
		}

		public VengefulSpiritScroll( Serial serial ) : base( serial )
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
			Name = "vengeful spirit scroll";
		}
	}
}