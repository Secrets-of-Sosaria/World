using System;
using Server;
using Server.Misc;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class AssassinNote : Item
	{
		public string LetterMessage;

		[CommandProperty(AccessLevel.Owner)]
		public string Letter_Message { get { return LetterMessage; } set { LetterMessage = value; InvalidateProperties(); } }

		[Constructable]
		public AssassinNote( ) : base( 0xE34 )
		{
			Weight = 1.0;
			Hue = 0xB9A;
			Name = "a letter";
			ItemID = Utility.RandomList( 0xE34, 0x14ED, 0x14EE, 0x14EF, 0x14F0 );
		}

		public class KillGump : Gump
		{
			public KillGump( Mobile from, Item parchment ): base( 100, 100 )
			{
				AssassinNote note = (AssassinNote)parchment;
				string sText = note.LetterMessage;
				from.PlaySound( 0x249 );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 10901, 2786);
				AddImage(0, 0, 10899, 2117);
				AddHtml( 45, 78, 386, 218, @"<BODY><BASEFONT Color=#d9c781>" + sText + "</BASEFONT></BODY>", (bool)false, (bool)true);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.PlaySound( 0x249 );
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) && e.CanSee( this ) && e.InLOS( this ) )
			{
				e.CloseGump( typeof( KillGump ) );
				e.SendGump( new KillGump( e, this ) );
				e.PlaySound( 0x249 );
			}
		}

		public AssassinNote(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
            writer.Write( LetterMessage );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			LetterMessage = reader.ReadString();
		}
	}
}