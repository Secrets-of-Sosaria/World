using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseBlocks : Item
	{
		public override string DefaultDescription{ get{ return "These are a more rare, higher quality, type of ingot. They are rumored to be used by elven blacksmiths, but the art for this has seemed to be lost."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		public BaseBlocks( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseBlocks( CraftResource resource, int amount ) : base( 0x6607 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
			Name = CraftResources.GetTradeItemFullName( this, resource, false, false, null );
			Built = true;
		}

		public BaseBlocks( Serial serial ) : base( serial )
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

	public class AmethystBlocks : BaseBlocks
	{
		[Constructable]
		public AmethystBlocks() : this( 1 )
		{
		}

		[Constructable]
		public AmethystBlocks( int amount ) : base( CraftResource.AmethystBlock, amount )
		{
		}

		public AmethystBlocks( Serial serial ) : base( serial )
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

	public class EmeraldBlocks : BaseBlocks
	{
		[Constructable]
		public EmeraldBlocks() : this( 1 )
		{
		}

		[Constructable]
		public EmeraldBlocks( int amount ) : base( CraftResource.EmeraldBlock, amount )
		{
		}

		public EmeraldBlocks( Serial serial ) : base( serial )
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

	public class GarnetBlocks : BaseBlocks
	{
		[Constructable]
		public GarnetBlocks() : this( 1 )
		{
		}

		[Constructable]
		public GarnetBlocks( int amount ) : base( CraftResource.GarnetBlock, amount )
		{
		}

		public GarnetBlocks( Serial serial ) : base( serial )
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

	public class IceBlocks : BaseBlocks
	{
		[Constructable]
		public IceBlocks() : this( 1 )
		{
		}

		[Constructable]
		public IceBlocks( int amount ) : base( CraftResource.IceBlock, amount )
		{
		}

		public IceBlocks( Serial serial ) : base( serial )
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

	public class JadeBlocks : BaseBlocks
	{
		[Constructable]
		public JadeBlocks() : this( 1 )
		{
		}

		[Constructable]
		public JadeBlocks( int amount ) : base( CraftResource.JadeBlock, amount )
		{
		}

		public JadeBlocks( Serial serial ) : base( serial )
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

	public class MarbleBlocks : BaseBlocks
	{
		[Constructable]
		public MarbleBlocks() : this( 1 )
		{
		}

		[Constructable]
		public MarbleBlocks( int amount ) : base( CraftResource.MarbleBlock, amount )
		{
		}

		public MarbleBlocks( Serial serial ) : base( serial )
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

	public class OnyxBlocks : BaseBlocks
	{
		[Constructable]
		public OnyxBlocks() : this( 1 )
		{
		}

		[Constructable]
		public OnyxBlocks( int amount ) : base( CraftResource.OnyxBlock, amount )
		{
		}

		public OnyxBlocks( Serial serial ) : base( serial )
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

	public class QuartzBlocks : BaseBlocks
	{
		[Constructable]
		public QuartzBlocks() : this( 1 )
		{
		}

		[Constructable]
		public QuartzBlocks( int amount ) : base( CraftResource.QuartzBlock, amount )
		{
		}

		public QuartzBlocks( Serial serial ) : base( serial )
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

	public class RubyBlocks : BaseBlocks
	{
		[Constructable]
		public RubyBlocks() : this( 1 )
		{
		}

		[Constructable]
		public RubyBlocks( int amount ) : base( CraftResource.RubyBlock, amount )
		{
		}

		public RubyBlocks( Serial serial ) : base( serial )
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

	public class SapphireBlocks : BaseBlocks
	{
		[Constructable]
		public SapphireBlocks() : this( 1 )
		{
		}

		[Constructable]
		public SapphireBlocks( int amount ) : base( CraftResource.SapphireBlock, amount )
		{
		}

		public SapphireBlocks( Serial serial ) : base( serial )
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

	public class SilverBlocks : BaseBlocks
	{
		[Constructable]
		public SilverBlocks() : this( 1 )
		{
		}

		[Constructable]
		public SilverBlocks( int amount ) : base( CraftResource.SilverBlock, amount )
		{
		}

		public SilverBlocks( Serial serial ) : base( serial )
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

	public class SpinelBlocks : BaseBlocks
	{
		[Constructable]
		public SpinelBlocks() : this( 1 )
		{
		}

		[Constructable]
		public SpinelBlocks( int amount ) : base( CraftResource.SpinelBlock, amount )
		{
		}

		public SpinelBlocks( Serial serial ) : base( serial )
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

	public class StarRubyBlocks : BaseBlocks
	{
		[Constructable]
		public StarRubyBlocks() : this( 1 )
		{
		}

		[Constructable]
		public StarRubyBlocks( int amount ) : base( CraftResource.StarRubyBlock, amount )
		{
		}

		public StarRubyBlocks( Serial serial ) : base( serial )
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

	public class TopazBlocks : BaseBlocks
	{
		[Constructable]
		public TopazBlocks() : this( 1 )
		{
		}

		[Constructable]
		public TopazBlocks( int amount ) : base( CraftResource.TopazBlock, amount )
		{
		}

		public TopazBlocks( Serial serial ) : base( serial )
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

	public class CaddelliteBlocks : BaseBlocks
	{
		[Constructable]
		public CaddelliteBlocks() : this( 1 )
		{
		}

		[Constructable]
		public CaddelliteBlocks( int amount ) : base( CraftResource.CaddelliteBlock, amount )
		{
		}

		public CaddelliteBlocks( Serial serial ) : base( serial )
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