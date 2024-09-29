using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	[Flipable(0x52FE, 0x52FF)]
	public class WantedMangar : Item
	{
		[Constructable]
		public WantedMangar( ) : base( 0x52FE )
		{
			Name = "Wanted!";
		}

		public class WantedMangarGump : Gump
		{
			public WantedMangarGump( Mobile from ): base( 50, 50 )
			{
				from.SendSound( 0x59 ); 
				string color = "#a2a2cb";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9584, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddImage(582, 204, 10906);
				AddButton(568, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddItem(265, 3, 7905);
				AddItem(437, 6, 577);
				AddItem(461, 28, 577);
				AddItem(485, 51, 577);
				AddItem(462, 63, 26404);
				AddItem(509, 74, 577);
				AddItem(530, 96, 579);
				AddItem(288, 90, 5360, 0xB98);
				AddHtml( 11, 11, 243, 20, @"<BODY><BASEFONT Color=" + color + ">WANTED: Mangar the Dark</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 316, 17, 115, 20, @"<BODY><BASEFONT Color=" + color + ">Magic Mouth</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 496, 34, 115, 20, @"<BODY><BASEFONT Color=" + color + ">Secret Doors</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 339, 94, 115, 20, @"<BODY><BASEFONT Color=" + color + ">Clues</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 10, 169, 563, 160, @"<BODY><BASEFONT Color=" + color + ">You are trapped in Skara Brae, regardless of the rumors that it was destroyed in Sosaria. It seems that Mangar has moved this village into the void for his own nefarious purposes. You can only assume that if you can find Mangar and defeat him, then you may find a way to escape this void. To do that, you will need to explore and talk to any unusual citizens. Searching the dungeons for clues, secret doors, or magic mouths may prove helpful in your quest. You may slay powerful creatures that will drop chests on the floor you can use to acquire more clues or treasure. Keep an eye on your quest log, as it will show you the steps you accomplished. You feel a bit thirsty now, however, so you may want to get some wine in the cellar behind the tavern of the Scarlet Bard.</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse(NetState state, RelayInfo info)
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x59 ); 
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				e.CloseGump( typeof( WantedMangarGump ) );
				e.SendGump( new WantedMangarGump( e ) );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public WantedMangar(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}