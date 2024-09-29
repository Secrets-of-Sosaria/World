using System;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class BookOfNinjitsu : Spellbook
	{
		public override string DefaultDescription{ get{ return "This book is used by ninja, in order for them to use various abilities akin to this ancient order of assassins. Some books have enhanced properties, that are only effective when the book is held."; } }

		public override SpellbookType SpellbookType{ get{ return SpellbookType.Ninja; } }
		public override int BookOffset{ get{ return 500; } }
		public override int BookCount{ get{ return 8; } }

		[Constructable]
		public BookOfNinjitsu() : this( (ulong)0xFF )
		{
		}

		[Constructable]
		public BookOfNinjitsu( ulong content ) : base( content, 0x23A0 )
		{
			Name = "ninjitsu book";
			Layer = Layer.Trinket;
		}

		public BookOfNinjitsu( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}