using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class EvilOmenScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 104 ); } }

		[Constructable]
		public EvilOmenScroll() : this( 1 )
		{
		}

		[Constructable]
		public EvilOmenScroll( int amount ) : base( 104, 0x2264, amount )
		{
			Name = "evil omen scroll";
		}

		public EvilOmenScroll( Serial serial ) : base( serial )
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
			Name = "evil omen scroll";
		}
	}
}