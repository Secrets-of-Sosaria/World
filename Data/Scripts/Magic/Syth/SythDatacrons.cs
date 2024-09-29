using System;
using Server;
using Server.Items;
using Server.Spells.Syth;

namespace Server.Items
{
	public class SythDatacron01 : SpellScroll
	{
		[Constructable]
		public SythDatacron01() : base( 270, 0x4CDF )
		{
			Hue = 0xBAA;
			Name = "Psychokinesis";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 270 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron01( Serial serial ) : base( serial )
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
	public class SythDatacron02 : SpellScroll
	{
		[Constructable]
		public SythDatacron02() : base( 271, 0x4CDF )
		{
			Hue = 0xBA7;
			Name = "Death Grip";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 271 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron02( Serial serial ) : base( serial )
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
	public class SythDatacron03 : SpellScroll
	{
		[Constructable]
		public SythDatacron03() : base( 272, 0x4CDF )
		{
			Hue = 0xBA4;
			Name = "Projection";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 272 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron03( Serial serial ) : base( serial )
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
	public class SythDatacron04 : SpellScroll
	{
		[Constructable]
		public SythDatacron04() : base( 273, 0x4CDF )
		{
			Hue = 0xBA1;
			Name = "Throw Sword";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 273 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron04( Serial serial ) : base( serial )
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
	public class SythDatacron05 : SpellScroll
	{
		[Constructable]
		public SythDatacron05() : base( 274, 0x4CDF )
		{
			Hue = 0xB9E;
			Name = "Speed";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 274 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron05( Serial serial ) : base( serial )
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
	public class SythDatacron06 : SpellScroll
	{
		[Constructable]
		public SythDatacron06() : base( 275, 0x4CDF )
		{
			Hue = 0xB78;
			Name = "Syth Lightning";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 275 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron06( Serial serial ) : base( serial )
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
	public class SythDatacron07 : SpellScroll
	{
		[Constructable]
		public SythDatacron07() : base( 276, 0x4CDF )
		{
			Hue = 0xB75;
			Name = "Absorption";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 276 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron07( Serial serial ) : base( serial )
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
	public class SythDatacron08 : SpellScroll
	{
		[Constructable]
		public SythDatacron08() : base( 277, 0x4CDF )
		{
			Hue = 0xB58;
			Name = "Psychic Blast";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 277 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron08( Serial serial ) : base( serial )
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
	public class SythDatacron09 : SpellScroll
	{
		[Constructable]
		public SythDatacron09() : base( 278, 0x4CDF )
		{
			Hue = 0xB53;
			Name = "Drain Life";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 278 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron09( Serial serial ) : base( serial )
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
	public class SythDatacron10 : SpellScroll
	{
		[Constructable]
		public SythDatacron10() : base( 279, 0x4CDF )
		{
			Hue = 0xAE3;
			Name = "Clone";
			Light = LightType.Circle225;
		}

		public override string DefaultDescription{ get{ return SythSpell.SpellDescription( 279 ); } }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( "This mysticron contains the knowledge of a long dead Syth Lord." );
		}

		public SythDatacron10( Serial serial ) : base( serial )
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