using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using System.Collections;

namespace Server.Items
{
    public class DungeonMastersGuide : Item
	{
        [Constructable]
        public DungeonMastersGuide() : base( 0x3046 )
		{
            Name = "Dungeon Masters Guide";
			Weight = 1.0;
        }

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Dungeons & Dragons");
        }

		public override void OnDoubleClick( Mobile e )
		{
			e.CloseGump( typeof( DMGuideGump ) );
			e.SendGump( new DMGuideGump( e ) );
			e.SendSound( 0x55 );
		}

		public class DMGuideGump : Gump
		{
			public DMGuideGump( Mobile from ): base( 50, 50 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 11415, Server.Misc.PlayerSettings.GetGumpHue( from ));

				AddButton(1367, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 16, 14, 1330, 21, @"<BODY><BASEFONT Color=#DC7676>DUNGEON MASTERS GUIDE - This Book Contains a Listing of Almost All of the Dungeons in the " + MySettings.S_ServerName + "</BASEFONT></BODY>", (bool)false, (bool)false);

				string world = null;
				string location = null;
				Map placer = Map.Internal;
				int xc = 0;
				int yc = 0;
				string dungeon = null;

				int cyc = 0;
				int btn = 36;
				int add = 19;
				int yor = 0;

				string color = "DC7676";

				while ( cyc < 85 )
				{
					cyc++;

					if ( cyc > 43 )
						yor = 792;

					if ( cyc == 44 )
						btn = 36;

					dungeon = Server.Misc.Worlds.GetDungeonListing( cyc, out world, out location, out placer, out xc, out yc );

					AddButton(35+yor, btn+2, 216, 216, cyc, GumpButtonType.Reply, 0);
					AddHtml( 55+yor, btn, 110, 21, @"<BODY><BASEFONT Color=#" + color + ">" + world + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 175+yor, btn, 200, 21, @"<BODY><BASEFONT Color=#" + color + ">" + dungeon + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 382+yor, btn, 200, 21, @"<BODY><BASEFONT Color=#" + color + ">" + location + "</BASEFONT></BODY>", (bool)false, (bool)false);

					btn += add;

					if ( color == "DC7676" )
						color = "B7A1BE";
					else
						color = "DC7676";
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.CloseGump( typeof( Sextants.MapGump ) );
				from.CloseGump( typeof( DMGuideGump ) );

				if ( info.ButtonID > 0 )
				{
					from.SendGump( new DMGuideGump( from ) );

					string world = "";
					string location = "";
					Map placer = Map.Internal;
					int xc = 0;
					int yc = 0;

					string dungeon = Server.Misc.Worlds.GetDungeonListing( info.ButtonID, out world, out location, out placer, out xc, out yc );

					from.SendGump( new Sextants.MapGump( from, placer, xc, yc, null ) );
				}
				else
				{
					from.SendSound( 0x55 );
				}
			}
		}

        public DungeonMastersGuide( Serial serial ) : base( serial )
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
	    }
    }
}