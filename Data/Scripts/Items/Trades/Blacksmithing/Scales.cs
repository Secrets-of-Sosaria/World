using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseScales : Item
	{
		public override string DefaultDescription{ get{ return "These usually come from reptilian creatures. They are commonly used for creating scalemail equipment."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
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

			if ( version < 1 )
				m_Resource = (CraftResource)reader.ReadInt();

			Hue = CraftResources.GetHue( m_Resource );
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, null );
			Built = true;
		}

		public BaseScales( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseScales( CraftResource resource, int amount ) : base( 0x26B4 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
			Name = CraftResources.GetTradeItemFullName( this, resource, false, false, null );
			Built = true;
		}

		public BaseScales( Serial serial ) : base( serial )
		{
		}
	}

	public class RedScales : BaseScales
	{
		[Constructable]
		public RedScales() : this( 1 )
		{
		}

		[Constructable]
		public RedScales( int amount ) : base( CraftResource.RedScales, amount )
		{
		}

		public RedScales( Serial serial ) : base( serial )
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

	public class YellowScales : BaseScales
	{
		[Constructable]
		public YellowScales() : this( 1 )
		{
		}

		[Constructable]
		public YellowScales( int amount ) : base( CraftResource.YellowScales, amount )
		{
		}

		public YellowScales( Serial serial ) : base( serial )
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

	public class BlackScales : BaseScales
	{
		[Constructable]
		public BlackScales() : this( 1 )
		{
		}

		[Constructable]
		public BlackScales( int amount ) : base( CraftResource.BlackScales, amount )
		{
		}

		public BlackScales( Serial serial ) : base( serial )
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

	public class GreenScales : BaseScales
	{
		[Constructable]
		public GreenScales() : this( 1 )
		{
		}

		[Constructable]
		public GreenScales( int amount ) : base( CraftResource.GreenScales, amount )
		{
		}

		public GreenScales( Serial serial ) : base( serial )
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

	public class WhiteScales : BaseScales
	{
		[Constructable]
		public WhiteScales() : this( 1 )
		{
		}

		[Constructable]
		public WhiteScales( int amount ) : base( CraftResource.WhiteScales, amount )
		{
		}

		public WhiteScales( Serial serial ) : base( serial )
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

	public class BlueScales : BaseScales
	{
		[Constructable]
		public BlueScales() : this( 1 )
		{
		}

		[Constructable]
		public BlueScales( int amount ) : base( CraftResource.BlueScales, amount )
		{
		}

		public BlueScales( Serial serial ) : base( serial )
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

	public class DinosaurScales : BaseScales
	{
		[Constructable]
		public DinosaurScales() : this( 1 )
		{
		}

		[Constructable]
		public DinosaurScales( int amount ) : base( CraftResource.DinosaurScales, amount )
		{
		}

		public DinosaurScales( Serial serial ) : base( serial )
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

	public class MetallicScales : BaseScales
	{
		[Constructable]
		public MetallicScales() : this( 1 )
		{
		}

		[Constructable]
		public MetallicScales( int amount ) : base( CraftResource.MetallicScales, amount )
		{
		}

		public MetallicScales( Serial serial ) : base( serial )
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

	public class BrazenScales : BaseScales
	{
		[Constructable]
		public BrazenScales() : this( 1 )
		{
		}

		[Constructable]
		public BrazenScales( int amount ) : base( CraftResource.BrazenScales, amount )
		{
		}

		public BrazenScales( Serial serial ) : base( serial )
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

	public class UmberScales : BaseScales
	{
		[Constructable]
		public UmberScales() : this( 1 )
		{
		}

		[Constructable]
		public UmberScales( int amount ) : base( CraftResource.UmberScales, amount )
		{
		}

		public UmberScales( Serial serial ) : base( serial )
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

	public class VioletScales : BaseScales
	{
		[Constructable]
		public VioletScales() : this( 1 )
		{
		}

		[Constructable]
		public VioletScales( int amount ) : base( CraftResource.VioletScales, amount )
		{
		}

		public VioletScales( Serial serial ) : base( serial )
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

	public class PlatinumScales : BaseScales
	{
		[Constructable]
		public PlatinumScales() : this( 1 )
		{
		}

		[Constructable]
		public PlatinumScales( int amount ) : base( CraftResource.PlatinumScales, amount )
		{
		}

		public PlatinumScales( Serial serial ) : base( serial )
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

	public class CadalyteScales : BaseScales
	{
		[Constructable]
		public CadalyteScales() : this( 1 )
		{
		}

		[Constructable]
		public CadalyteScales( int amount ) : base( CraftResource.CadalyteScales, amount )
		{
		}

		public CadalyteScales( Serial serial ) : base( serial )
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

	public class GornScales : BaseScales
	{
		[Constructable]
		public GornScales() : this( 1 )
		{
		}

		[Constructable]
		public GornScales( int amount ) : base( CraftResource.GornScales, amount )
		{
		}

		public GornScales( Serial serial ) : base( serial )
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

	public class TrandoshanScales : BaseScales
	{
		[Constructable]
		public TrandoshanScales() : this( 1 )
		{
		}

		[Constructable]
		public TrandoshanScales( int amount ) : base( CraftResource.TrandoshanScales, amount )
		{
		}

		public TrandoshanScales( Serial serial ) : base( serial )
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

	public class SilurianScales : BaseScales
	{
		[Constructable]
		public SilurianScales() : this( 1 )
		{
		}

		[Constructable]
		public SilurianScales( int amount ) : base( CraftResource.SilurianScales, amount )
		{
		}

		public SilurianScales( Serial serial ) : base( serial )
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

	public class KraytScales : BaseScales
	{
		[Constructable]
		public KraytScales() : this( 1 )
		{
		}

		[Constructable]
		public KraytScales( int amount ) : base( CraftResource.KraytScales, amount )
		{
		}

		public KraytScales( Serial serial ) : base( serial )
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