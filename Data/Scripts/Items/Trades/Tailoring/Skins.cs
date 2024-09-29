using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseSkins : Item
	{
		public override string DefaultDescription{ get{ return "These are a more rare, higher quality, type of leather. They are rumored to be used by elven tailors, but the art for this has seemed to be lost."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		public BaseSkins( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseSkins( CraftResource resource, int amount ) : base( 0x1081 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
			Name = CraftResources.GetTradeItemFullName( this, resource, false, false, null );
		}

		public BaseSkins( Serial serial ) : base( serial )
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
			ItemID = 0x1081;
			Hue = CraftResources.GetHue( m_Resource );
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, null );
		}
	}

	public class DemonSkins : BaseSkins
	{
		[Constructable]
		public DemonSkins() : this( 1 )
		{
		}

		[Constructable]
		public DemonSkins( int amount ) : base( CraftResource.DemonSkin, amount )
		{
		}

		public DemonSkins( Serial serial ) : base( serial )
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

	public class DragonSkins : BaseSkins
	{
		[Constructable]
		public DragonSkins() : this( 1 )
		{
		}

		[Constructable]
		public DragonSkins( int amount ) : base( CraftResource.DragonSkin, amount )
		{
		}

		public DragonSkins( Serial serial ) : base( serial )
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

	public class NightmareSkins : BaseSkins
	{
		[Constructable]
		public NightmareSkins() : this( 1 )
		{
		}

		[Constructable]
		public NightmareSkins( int amount ) : base( CraftResource.NightmareSkin, amount )
		{
		}

		public NightmareSkins( Serial serial ) : base( serial )
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

	public class SnakeSkins : BaseSkins
	{
		[Constructable]
		public SnakeSkins() : this( 1 )
		{
		}

		[Constructable]
		public SnakeSkins( int amount ) : base( CraftResource.SnakeSkin, amount )
		{
		}

		public SnakeSkins( Serial serial ) : base( serial )
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

	public class TrollSkins : BaseSkins
	{
		[Constructable]
		public TrollSkins() : this( 1 )
		{
		}

		[Constructable]
		public TrollSkins( int amount ) : base( CraftResource.TrollSkin, amount )
		{
		}

		public TrollSkins( Serial serial ) : base( serial )
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

	public class UnicornSkins : BaseSkins
	{
		[Constructable]
		public UnicornSkins() : this( 1 )
		{
		}

		[Constructable]
		public UnicornSkins( int amount ) : base( CraftResource.UnicornSkin, amount )
		{
		}

		public UnicornSkins( Serial serial ) : base( serial )
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

	public class IcySkins : BaseSkins
	{
		[Constructable]
		public IcySkins() : this( 1 )
		{
		}

		[Constructable]
		public IcySkins( int amount ) : base( CraftResource.IcySkin, amount )
		{
		}

		public IcySkins( Serial serial ) : base( serial )
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

	public class LavaSkins : BaseSkins
	{
		[Constructable]
		public LavaSkins() : this( 1 )
		{
		}

		[Constructable]
		public LavaSkins( int amount ) : base( CraftResource.LavaSkin, amount )
		{
		}

		public LavaSkins( Serial serial ) : base( serial )
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

	public class Seaweeds : BaseSkins
	{
		[Constructable]
		public Seaweeds() : this( 1 )
		{
		}

		[Constructable]
		public Seaweeds( int amount ) : base( CraftResource.Seaweed, amount )
		{
		}

		public Seaweeds( Serial serial ) : base( serial )
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

	public class DeadSkins : BaseSkins
	{
		[Constructable]
		public DeadSkins() : this( 1 )
		{
		}

		[Constructable]
		public DeadSkins( int amount ) : base( CraftResource.DeadSkin, amount )
		{
		}

		public DeadSkins( Serial serial ) : base( serial )
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