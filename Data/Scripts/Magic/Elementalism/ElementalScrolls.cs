using System;
using Server;
using Server.Items;
using Server.Spells.Elementalism;

namespace Server.Items
{
	public class Elemental_Armor_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 300 ); } }

		[Constructable]
		public Elemental_Armor_Scroll() : this( 300 )
		{
		}

		[Constructable]
		public Elemental_Armor_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Armor_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Bolt_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 301 ); } }

		[Constructable]
		public Elemental_Bolt_Scroll() : this( 301 )
		{
		}

		[Constructable]
		public Elemental_Bolt_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Bolt_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Mend_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 302 ); } }

		[Constructable]
		public Elemental_Mend_Scroll() : this( 302 )
		{
		}

		[Constructable]
		public Elemental_Mend_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Mend_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Sanctuary_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 303 ); } }

		[Constructable]
		public Elemental_Sanctuary_Scroll() : this( 303 )
		{
		}

		[Constructable]
		public Elemental_Sanctuary_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Sanctuary_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Pain_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 304 ); } }

		[Constructable]
		public Elemental_Pain_Scroll() : this( 304 )
		{
		}

		[Constructable]
		public Elemental_Pain_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Pain_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Protection_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 305 ); } }

		[Constructable]
		public Elemental_Protection_Scroll() : this( 305 )
		{
		}

		[Constructable]
		public Elemental_Protection_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Protection_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Purge_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 306 ); } }

		[Constructable]
		public Elemental_Purge_Scroll() : this( 306 )
		{
		}

		[Constructable]
		public Elemental_Purge_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Purge_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Steed_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 307 ); } }

		[Constructable]
		public Elemental_Steed_Scroll() : this( 307 )
		{
		}

		[Constructable]
		public Elemental_Steed_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Steed_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Call_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 308 ); } }

		[Constructable]
		public Elemental_Call_Scroll() : this( 308 )
		{
		}

		[Constructable]
		public Elemental_Call_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Call_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Force_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 309 ); } }

		[Constructable]
		public Elemental_Force_Scroll() : this( 309 )
		{
		}

		[Constructable]
		public Elemental_Force_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Force_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Wall_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 310 ); } }

		[Constructable]
		public Elemental_Wall_Scroll() : this( 310 )
		{
		}

		[Constructable]
		public Elemental_Wall_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Wall_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Warp_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 311 ); } }

		[Constructable]
		public Elemental_Warp_Scroll() : this( 311 )
		{
		}

		[Constructable]
		public Elemental_Warp_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Warp_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Field_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 312 ); } }

		[Constructable]
		public Elemental_Field_Scroll() : this( 312 )
		{
		}

		[Constructable]
		public Elemental_Field_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Field_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Restoration_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 313 ); } }

		[Constructable]
		public Elemental_Restoration_Scroll() : this( 313 )
		{
		}

		[Constructable]
		public Elemental_Restoration_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Restoration_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Strike_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 314 ); } }

		[Constructable]
		public Elemental_Strike_Scroll() : this( 314 )
		{
		}

		[Constructable]
		public Elemental_Strike_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Strike_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Void_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 315 ); } }

		[Constructable]
		public Elemental_Void_Scroll() : this( 315 )
		{
		}

		[Constructable]
		public Elemental_Void_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Void_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Blast_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 316 ); } }

		[Constructable]
		public Elemental_Blast_Scroll() : this( 316 )
		{
		}

		[Constructable]
		public Elemental_Blast_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Blast_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Echo_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 317 ); } }

		[Constructable]
		public Elemental_Echo_Scroll() : this( 317 )
		{
		}

		[Constructable]
		public Elemental_Echo_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Echo_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Fiend_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 318 ); } }

		[Constructable]
		public Elemental_Fiend_Scroll() : this( 318 )
		{
		}

		[Constructable]
		public Elemental_Fiend_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Fiend_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Hold_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 319 ); } }

		[Constructable]
		public Elemental_Hold_Scroll() : this( 319 )
		{
		}

		[Constructable]
		public Elemental_Hold_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Hold_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Barrage_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 320 ); } }

		[Constructable]
		public Elemental_Barrage_Scroll() : this( 320 )
		{
		}

		[Constructable]
		public Elemental_Barrage_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Barrage_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Rune_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 321 ); } }

		[Constructable]
		public Elemental_Rune_Scroll() : this( 321 )
		{
		}

		[Constructable]
		public Elemental_Rune_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Rune_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Storm_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 322 ); } }

		[Constructable]
		public Elemental_Storm_Scroll() : this( 322 )
		{
		}

		[Constructable]
		public Elemental_Storm_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Storm_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Summon_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 323 ); } }

		[Constructable]
		public Elemental_Summon_Scroll() : this( 323 )
		{
		}

		[Constructable]
		public Elemental_Summon_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Summon_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Devastation_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 324 ); } }

		[Constructable]
		public Elemental_Devastation_Scroll() : this( 324 )
		{
		}

		[Constructable]
		public Elemental_Devastation_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Devastation_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Fall_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 325 ); } }

		[Constructable]
		public Elemental_Fall_Scroll() : this( 325 )
		{
		}

		[Constructable]
		public Elemental_Fall_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Fall_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Gate_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 326 ); } }

		[Constructable]
		public Elemental_Gate_Scroll() : this( 326 )
		{
		}

		[Constructable]
		public Elemental_Gate_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Gate_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Havoc_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 327 ); } }

		[Constructable]
		public Elemental_Havoc_Scroll() : this( 327 )
		{
		}

		[Constructable]
		public Elemental_Havoc_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Havoc_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Apocalypse_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 328 ); } }

		[Constructable]
		public Elemental_Apocalypse_Scroll() : this( 328 )
		{
		}

		[Constructable]
		public Elemental_Apocalypse_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Apocalypse_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Lord_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 329 ); } }

		[Constructable]
		public Elemental_Lord_Scroll() : this( 329 )
		{
		}

		[Constructable]
		public Elemental_Lord_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Lord_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Soul_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 330 ); } }

		[Constructable]
		public Elemental_Soul_Scroll() : this( 330 )
		{
		}

		[Constructable]
		public Elemental_Soul_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Soul_Scroll( Serial serial ) : base( serial )
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
	public class Elemental_Spirit_Scroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return ElementalSpell.SpellDescription( 331 ); } }

		[Constructable]
		public Elemental_Spirit_Scroll() : this( 331 )
		{
		}

		[Constructable]
		public Elemental_Spirit_Scroll( int id ) : base( id, ElementalSpell.ScrollLook( id, 1 ) )
		{
			Hue = ElementalSpell.ScrollLook( id, 2 );
			Name = ElementalSpell.CommonInfo( id, 2 ) + " Scroll";
		}

		public Elemental_Spirit_Scroll( Serial serial ) : base( serial )
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