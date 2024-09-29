using System;
using Server;
using Server.Items;
using Server.Spells.Jedi;

namespace Server.Items
{
	public class JediDatacron01 : SpellScroll
	{
		[Constructable]
		public JediDatacron01() : base( 280, 0x543C )
		{
			Hue = 0xBAA;
			Name = "Force Grip";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 280 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron01( Serial serial ) : base( serial )
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
	public class JediDatacron02 : SpellScroll
	{
		[Constructable]
		public JediDatacron02() : base( 281, 0x543C )
		{
			Hue = 0xBA7;
			Name = "Mind's Eye";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 281 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron02( Serial serial ) : base( serial )
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
	public class JediDatacron03 : SpellScroll
	{
		[Constructable]
		public JediDatacron03() : base( 282, 0x543C )
		{
			Hue = 0xBA4;
			Name = "Mirage";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 282 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron03( Serial serial ) : base( serial )
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
	public class JediDatacron04 : SpellScroll
	{
		[Constructable]
		public JediDatacron04() : base( 283, 0x543C )
		{
			Hue = 0xBA1;
			Name = "Throw Sabre";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 283 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron04( Serial serial ) : base( serial )
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
	public class JediDatacron05 : SpellScroll
	{
		[Constructable]
		public JediDatacron05() : base( 284, 0x543C )
		{
			Hue = 0xB9E;
			Name = "Celerity";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 284 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron05( Serial serial ) : base( serial )
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
	public class JediDatacron06 : SpellScroll
	{
		[Constructable]
		public JediDatacron06() : base( 285, 0x543C )
		{
			Hue = 0xB78;
			Name = "Psychic Aura";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 285 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron06( Serial serial ) : base( serial )
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
	public class JediDatacron07 : SpellScroll
	{
		[Constructable]
		public JediDatacron07() : base( 286, 0x543C )
		{
			Hue = 0xB75;
			Name = "Deflection";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 286 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron07( Serial serial ) : base( serial )
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
	public class JediDatacron08 : SpellScroll
	{
		[Constructable]
		public JediDatacron08() : base( 287, 0x543C )
		{
			Hue = 0xB58;
			Name = "Soothing Touch";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 287 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron08( Serial serial ) : base( serial )
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
	public class JediDatacron09 : SpellScroll
	{
		[Constructable]
		public JediDatacron09() : base( 288, 0x543C )
		{
			Hue = 0xB53;
			Name = "Stasis Field";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 288 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron09( Serial serial ) : base( serial )
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
	public class JediDatacron10 : SpellScroll
	{
		[Constructable]
		public JediDatacron10() : base( 289, 0x543C )
		{
			Hue = 0xAE3;
			Name = "Replicate";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return JediSpell.SpellDescription( 289 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This holocron contains the wisdom of a Jedi Master from long ago." );
		}

		public JediDatacron10( Serial serial ) : base( serial )
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