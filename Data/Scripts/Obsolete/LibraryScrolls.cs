using System;
using Server;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class LibraryScroll1 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll1()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( 1 );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LibraryScroll2 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll2()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( Utility.RandomMinMax(2,3) );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LibraryScroll3 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll3()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll3( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( Utility.RandomMinMax(4,5) );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LibraryScroll4 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll4()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll4( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( Utility.RandomMinMax(6,7) );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LibraryScroll5 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll5()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll5( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( Utility.RandomMinMax(8,9) );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LibraryScroll6 : UnknownScroll
	{
		[Constructable]
		public LibraryScroll6()
		{
			string scroll = "magery";
			ScrollLevel = 1;

			switch( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: ScrollType = 1;		 scroll = "magery";		break;
				case 1: ScrollType = 1;		 scroll = "magery";		break;
				case 2: ScrollType = 1;		 scroll = "magery";		break;
				case 3: ScrollType = 1;		 scroll = "magery";		break;
				case 4: ScrollType = 1;		 scroll = "magery";		break;
				case 5: ScrollType = 1;		 scroll = "magery";		break;
				case 6: ScrollType = 2;		 scroll = "necromancy";	break;
				case 7: ScrollType = 2;		 scroll = "necromancy";	break;
				case 8: ScrollType = 3;		 scroll = "bardic";		break;
				case 9: ScrollType = 7;		 scroll = "elemental";	break;
				case 10: ScrollType = 7;	 scroll = "elemental";	break;
			}

			string writing = "a plainly";
				if ( ScrollLevel == 2 ){ writing = "an expertly"; }
				else if ( ScrollLevel == 3 ){ writing = "an adeptly"; }
				else if ( ScrollLevel == 4 ){ writing = "a cleverly"; }
				else if ( ScrollLevel == 5 ){ writing = "a deviously"; }
				else if ( ScrollLevel == 6 ){ writing = "an ingeniously"; }

			ScrollOrigin = "may be " + writing + " written " + scroll + " scroll";
		}

		public LibraryScroll6( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomScroll( Utility.RandomMinMax(10,12) );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}