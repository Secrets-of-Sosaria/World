using System;
using Server;
using Server.Items;
using Server.Spells.HolyMan;

namespace Server.Items
{
	public class HolyManSymbol770 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 770 ); } }

		[Constructable]
		public HolyManSymbol770() : base( 770, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Patriarch Morden";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Banish";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol770( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol771 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 771 ); } }

		[Constructable]
		public HolyManSymbol771() : base( 771, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Archbishop Halyrn";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Dampen Spirit";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol771( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol772 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 772 ); } }

		[Constructable]
		public HolyManSymbol772() : base( 772, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Bishop Leantre";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Enchant";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol772( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol773 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 773 ); } }

		[Constructable]
		public HolyManSymbol773() : base( 773, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Deacon Wilems";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Hammer of Faith";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol773( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol774 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 774 ); } }

		[Constructable]
		public HolyManSymbol774() : base( 774, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Drumat the Apostle";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Heavenly Light";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol774( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol775 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 775 ); } }

		[Constructable]
		public HolyManSymbol775() : base( 775, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Vincent the Priest";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Nourish";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol775( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol776 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 776 ); } }

		[Constructable]
		public HolyManSymbol776() : base( 776, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Abigayl the Preacher";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Purge";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol776( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol777 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 777 ); } }

		[Constructable]
		public HolyManSymbol777() : base( 777, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Cardinal Greggs";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Rebirth";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol777( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol778 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 778 ); } }

		[Constructable]
		public HolyManSymbol778() : base( 778, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Father Michal";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Sacred Boon";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol778( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol779 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 779 ); } }

		[Constructable]
		public HolyManSymbol779() : base( 779, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Sister Tiana";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Sanctify";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol779( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol780 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 780 ); } }

		[Constructable]
		public HolyManSymbol780() : base( 780, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Brother Kurklan";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Seance";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol780( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol781 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 781 ); } }

		[Constructable]
		public HolyManSymbol781() : base( 781, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Edwin the Pope";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Smite";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol781( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol782 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 782 ); } }

		[Constructable]
		public HolyManSymbol782() : base( 782, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Xephyn the Monk";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Touch of Life";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol782( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class HolyManSymbol783 : SpellScroll
	{
		public override string DefaultDescription{ get{ return HolyManSpell.SpellDescription( 783 ); } }

		[Constructable]
		public HolyManSymbol783() : base( 783, 0xE5B )
		{
			Hue = 0xB89;
			Name = "holy symbol";

			ColorText4 = "Chancellor Davis";
			ColorHue4 = "4FE9E4";
			ColorText5 = "Trial by Fire";
			ColorHue5 = "E5EC79";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This symbol once belonged to a great holy man." );
		}

		public HolyManSymbol783( Serial serial ) : base( serial )
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