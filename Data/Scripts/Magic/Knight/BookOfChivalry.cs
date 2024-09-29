using System;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class BookOfChivalry : Spellbook
	{
		public override string DefaultDescription{ get{ return "This book is used by knights, in order for them to use various abilities to spread harmony and peace throughout the land. Some books have enhanced properties, that are only effective when the book is held."; } }

		public override SpellbookType SpellbookType{ get{ return SpellbookType.Paladin; } }
		public override int BookOffset{ get{ return 200; } }
		public override int BookCount{ get{ return 10; } }

		[Constructable]
		public BookOfChivalry() : this( (ulong)0x3FF )
		{
		}

		[Constructable]
		public BookOfChivalry( ulong content ) : base( content, 0x2252 )
		{
			Name = "knightship book";
			Layer = Layer.Trinket;
		}

		public BookOfChivalry( Serial serial ) : base( serial )
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