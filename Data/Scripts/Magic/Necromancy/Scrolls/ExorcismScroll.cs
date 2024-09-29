using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ExorcismScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 116 ); } }

		[Constructable]
		public ExorcismScroll() : this( 1 )
		{
		}

		[Constructable]
		public ExorcismScroll( int amount ) : base( 116, 0x2270, amount )
		{
			Name = "exorcism scroll";
		}

		public ExorcismScroll( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Name = "exorcism scroll";
		}
	}
}