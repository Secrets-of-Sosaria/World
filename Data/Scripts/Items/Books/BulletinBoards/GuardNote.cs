using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Misc;

namespace Server.Items
{
	public class GuardNote : Item
	{
		public string ScrollText;

		[CommandProperty(AccessLevel.Owner)]
		public string Scroll_Text { get { return ScrollText; } set { ScrollText = value; InvalidateProperties(); } }

		[Constructable]
		public GuardNote( ) : base( 0x2258 )
		{
			Weight = 1.0;
			Hue = 0xB9A;
			Name = "a note";
			ItemID = Utility.RandomList( 0xE34, 0x14ED, 0x14EE, 0x14EF, 0x14F0 );
		}

		public class ReadGump : Gump
		{
			public ReadGump( Mobile from, Item parchment ): base( 100, 100 )
			{
				GuardNote scroll = (GuardNote)parchment;
				string sText = scroll.ScrollText;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 10901, 2786);
				AddImage(0, 0, 10899, 2117);
				AddHtml( 45, 78, 386, 218, @"<BODY><BASEFONT Color=#d9c781>" + sText + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( !IsChildOf( e.Backpack ) ) 
			{
				e.SendMessage( "This must be in your backpack to read." );
				return;
			}
			else
			{
				e.SendGump( new ReadGump( e, this ) );
				e.PlaySound( 0x249 );
			}
		}

		public GuardNote(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
            writer.Write( ScrollText );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
            ScrollText = reader.ReadString();
		}
	}
}