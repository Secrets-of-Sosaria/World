using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class HorrificBeastScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 105 ); } }

		[Constructable]
		public HorrificBeastScroll() : this( 1 )
		{
		}

		[Constructable]
		public HorrificBeastScroll( int amount ) : base( 105, 0x2265, amount )
		{
			Name = "horrific beast scroll";
		}

		public HorrificBeastScroll( Serial serial ) : base( serial )
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
			Name = "horrific beast scroll";
		}
	}
}