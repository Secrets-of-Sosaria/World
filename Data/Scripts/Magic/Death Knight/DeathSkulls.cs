using System;
using Server;
using Server.Items;
using Server.Spells.DeathKnight;

namespace Server.Items
{
	public class DeathKnightSkull750 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull750() : base( 750, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Saint Kargoth";
			ColorHue4 = "CC1313";
			ColorText5 = "Banish";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 750 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull750( Serial serial ) : base( serial )
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
	public class DeathKnightSkull751 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull751() : base( 751, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Lord Monduiz Dephaar";
			ColorHue4 = "CC1313";
			ColorText5 = "Demonic Touch";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 751 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull751( Serial serial ) : base( serial )
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
	public class DeathKnightSkull752 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull752() : base( 752, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Lady Kath of Naelex";
			ColorHue4 = "CC1313";
			ColorText5 = "Devil Pact";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 752 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull752( Serial serial ) : base( serial )
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
	public class DeathKnightSkull753 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull753() : base( 753, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Prince Myrhal of Rax";
			ColorHue4 = "CC1313";
			ColorText5 = "Grim Reaper";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 753 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull753( Serial serial ) : base( serial )
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
	public class DeathKnightSkull754 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull754() : base( 754, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Maeril of Naelax";
			ColorHue4 = "CC1313";
			ColorText5 = "Hag Hand";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 754 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull754( Serial serial ) : base( serial )
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
	public class DeathKnightSkull755 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull755() : base( 755, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Farian of Lirtham";
			ColorHue4 = "CC1313";
			ColorText5 = "Hellfire";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 755 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull755( Serial serial ) : base( serial )
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
	public class DeathKnightSkull756 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull756() : base( 756, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Lord Androma of Gara";
			ColorHue4 = "CC1313";
			ColorText5 = "Lucifer's Bolt";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 756 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull756( Serial serial ) : base( serial )
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
	public class DeathKnightSkull757 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull757() : base( 757, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Oslan Knarren";
			ColorHue4 = "CC1313";
			ColorText5 = "Orb of Orcus";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 757 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull757( Serial serial ) : base( serial )
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
	public class DeathKnightSkull758 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull758() : base( 758, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Rezinar of Haxx";
			ColorHue4 = "CC1313";
			ColorText5 = "Shield of Hate";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 758 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull758( Serial serial ) : base( serial )
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
	public class DeathKnightSkull759 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull759() : base( 759, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Lord Thyrian of Naelax";
			ColorHue4 = "CC1313";
			ColorText5 = "Soul Reaper";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 759 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull759( Serial serial ) : base( serial )
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
	public class DeathKnightSkull760 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull760() : base( 760, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Minar of Darmen";
			ColorHue4 = "CC1313";
			ColorText5 = "Strength of Steel";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 760 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull760( Serial serial ) : base( serial )
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
	public class DeathKnightSkull761 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull761() : base( 761, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Duke Urkar of Torquann";
			ColorHue4 = "CC1313";
			ColorText5 = "Strike";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 761 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull761( Serial serial ) : base( serial )
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
	public class DeathKnightSkull762 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull762() : base( 762, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Sir Luren the Boar";
			ColorHue4 = "CC1313";
			ColorText5 = "Succubus Skin";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 762 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull762( Serial serial ) : base( serial )
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
	public class DeathKnightSkull763 : SpellScroll
	{
		[Constructable]
		public DeathKnightSkull763() : base( 763, 0x1AE0 )
		{
			ItemID = Utility.RandomList( 0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3 );
			Hue = 0xB9A;
			Name = "Death Knight Skull";

			ColorText4 = "Lord Khayven of Rax";
			ColorHue4 = "CC1313";
			ColorText5 = "Wrath";
			ColorHue5 = "D03DD9";
		}

		public override string DefaultDescription{ get{ return DeathKnightSpell.SpellDescription( 763 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This skull is from a long dead death knight." );
		}

		public DeathKnightSkull763( Serial serial ) : base( serial )
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