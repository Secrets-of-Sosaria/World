using System; 
using Server; 
using Server.Items; 
using Server.Network; 
using Server.Misc; 
using Server.Gumps;

namespace Server.Items
{
	public class BeginnerBook : Item
	{
		[Constructable]
		public BeginnerBook() : base( 0x0FF1 )
		{
			Name = "The Journey Begins";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( GetWorldLocation(), 1 ) )
			{
				from.CloseGump( typeof( BeginnerBookGump ) );
				from.SendGump( new BeginnerBookGump( from, 1 ) );
			}
		}

		public void TitleBook()
		{
			if ( ColorText1 == null && X > 0 )
			{
				ColorText1 = "The Journey Begins";
				ColorText2 = "How to start a new";
				ColorText3 = "life in this world";
				ColorHue1 = "FF9900";
				ColorHue2 = "B57B24";
				ColorHue3 = "B57B24";
			}
		}

        public override void OnAfterSpawn()
        {
			TitleBook();
			base.OnAfterSpawn();
		}

		public override void OnAdded( object parent )
		{
			TitleBook();
			base.OnAdded( parent );
		}

		public override void OnLocationChange( Point3D oldLocation )
		{
			TitleBook();
			base.OnLocationChange( oldLocation );
		}

		public BeginnerBook( Serial serial ) : base( serial )
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

namespace Server.Gumps 
{ 
	public class BeginnerBookGump : Gump 
	{
		public BeginnerBookGump( Mobile from, int page ) : base( 50, 50 ) 
		{
			if ( page < 1 || page > 49 )
				page = 1;

			from.PlaySound( 0x55 );

			Closable=true;
			Disposable=false;
			Dragable=true;
			Resizable=false;

			AddPage(0);
			AddImage(0, 0, 7010, 1993);
			AddImage(0, 0, 7011, 2989);
			AddImage(0, 0, 7025, 2268);

			int paper = 23014+page;
				paper = paper+page;

			AddImage(68, 22, paper);
			AddImage(489, 25, paper+1);

			AddButton(118, 15, 4014, 4014, Page( page, -1 ), GumpButtonType.Reply, 0);

			AddButton(901, 18, 4005, 4005, Page( page, 1 ), GumpButtonType.Reply, 0);

			AddButton(124, 635, 4011, 4011, 2, GumpButtonType.Reply, 0); // TOC

			if ( page == 2 )
			{
				int g = 58;
				int h = 32;

				AddButton(113, g+=h, 2117, 2117, 1, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 2, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 3, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 4, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 5, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 5, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 7, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 8, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 11, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 11, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 12, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 13, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 14, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 15, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 15, GumpButtonType.Reply, 0);
				AddButton(113, g+=h, 2117, 2117, 16, GumpButtonType.Reply, 0);

				g = 38;
				AddButton(534, g+=h, 2117, 2117, 18, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 21, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 22, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 24, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 25, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 27, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 29, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 30, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 33, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 35, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 38, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 38, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 39, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 40, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 47, GumpButtonType.Reply, 0);
				AddButton(534, g+=h, 2117, 2117, 49, GumpButtonType.Reply, 0);
			}
		}

		public int Page( int page, int mod )
		{
			page = page + mod;

			if ( page < 1 )
				page = 49;
			else if ( page > 49 )
				page = 1;

			return page;
		}
       
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile; 

			if ( info.ButtonID > 0 )
				from.SendGump( new BeginnerBookGump( from, info.ButtonID ) );

			from.PlaySound( 0x55 );
		}
	} 
}
