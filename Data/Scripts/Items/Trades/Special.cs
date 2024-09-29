using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseSpecial : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		public BaseSpecial( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseSpecial( CraftResource resource, int amount ) : base( 0x660A )
		{
			Stackable = true;
			Amount = amount;
			Name = CraftResources.GetTradeItemFullName( this, resource, false, false, null );
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
			Built = true;
		}

		public BaseSpecial( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Built = true;
		}
	}

	public class SpectralSpec : BaseSpecial
	{
		[Constructable]
		public SpectralSpec() : this( 1 )
		{
		}

		[Constructable]
		public SpectralSpec( int amount ) : base( CraftResource.SpectralSpec, amount )
		{
		}

		public SpectralSpec( Serial serial ) : base( serial )
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

	public class DreadSpec : BaseSpecial
	{
		[Constructable]
		public DreadSpec() : this( 1 )
		{
		}

		[Constructable]
		public DreadSpec( int amount ) : base( CraftResource.DreadSpec, amount )
		{
		}

		public DreadSpec( Serial serial ) : base( serial )
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

	public class GhoulishSpec : BaseSpecial
	{
		[Constructable]
		public GhoulishSpec() : this( 1 )
		{
		}

		[Constructable]
		public GhoulishSpec( int amount ) : base( CraftResource.GhoulishSpec, amount )
		{
		}

		public GhoulishSpec( Serial serial ) : base( serial )
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

	public class WyrmSpec : BaseSpecial
	{
		[Constructable]
		public WyrmSpec() : this( 1 )
		{
		}

		[Constructable]
		public WyrmSpec( int amount ) : base( CraftResource.WyrmSpec, amount )
		{
		}

		public WyrmSpec( Serial serial ) : base( serial )
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

	public class HolySpec : BaseSpecial
	{
		[Constructable]
		public HolySpec() : this( 1 )
		{
		}

		[Constructable]
		public HolySpec( int amount ) : base( CraftResource.HolySpec, amount )
		{
		}

		public HolySpec( Serial serial ) : base( serial )
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

	public class BloodlessSpec : BaseSpecial
	{
		[Constructable]
		public BloodlessSpec() : this( 1 )
		{
		}

		[Constructable]
		public BloodlessSpec( int amount ) : base( CraftResource.BloodlessSpec, amount )
		{
		}

		public BloodlessSpec( Serial serial ) : base( serial )
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

	public class GildedSpec : BaseSpecial
	{
		[Constructable]
		public GildedSpec() : this( 1 )
		{
		}

		[Constructable]
		public GildedSpec( int amount ) : base( CraftResource.GildedSpec, amount )
		{
		}

		public GildedSpec( Serial serial ) : base( serial )
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

	public class DemilichSpec : BaseSpecial
	{
		[Constructable]
		public DemilichSpec() : this( 1 )
		{
		}

		[Constructable]
		public DemilichSpec( int amount ) : base( CraftResource.DemilichSpec, amount )
		{
		}

		public DemilichSpec( Serial serial ) : base( serial )
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

	public class WintrySpec : BaseSpecial
	{
		[Constructable]
		public WintrySpec() : this( 1 )
		{
		}

		[Constructable]
		public WintrySpec( int amount ) : base( CraftResource.WintrySpec, amount )
		{
		}

		public WintrySpec( Serial serial ) : base( serial )
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

	public class FireSpec : BaseSpecial
	{
		[Constructable]
		public FireSpec() : this( 1 )
		{
		}

		[Constructable]
		public FireSpec( int amount ) : base( CraftResource.FireSpec, amount )
		{
		}

		public FireSpec( Serial serial ) : base( serial )
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

	public class ColdSpec : BaseSpecial
	{
		[Constructable]
		public ColdSpec() : this( 1 )
		{
		}

		[Constructable]
		public ColdSpec( int amount ) : base( CraftResource.ColdSpec, amount )
		{
		}

		public ColdSpec( Serial serial ) : base( serial )
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

	public class PoisSpec : BaseSpecial
	{
		[Constructable]
		public PoisSpec() : this( 1 )
		{
		}

		[Constructable]
		public PoisSpec( int amount ) : base( CraftResource.PoisSpec, amount )
		{
		}

		public PoisSpec( Serial serial ) : base( serial )
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

	public class EngySpec : BaseSpecial
	{
		[Constructable]
		public EngySpec() : this( 1 )
		{
		}

		[Constructable]
		public EngySpec( int amount ) : base( CraftResource.EngySpec, amount )
		{
		}

		public EngySpec( Serial serial ) : base( serial )
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

	public class ExodusSpec : BaseSpecial
	{
		[Constructable]
		public ExodusSpec() : this( 1 )
		{
		}

		[Constructable]
		public ExodusSpec( int amount ) : base( CraftResource.ExodusSpec, amount )
		{
		}

		public ExodusSpec( Serial serial ) : base( serial )
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

	public class TurtleSpec : BaseSpecial
	{
		[Constructable]
		public TurtleSpec() : this( 1 )
		{
		}

		[Constructable]
		public TurtleSpec( int amount ) : base( CraftResource.TurtleSpec, amount )
		{
		}

		public TurtleSpec( Serial serial ) : base( serial )
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