using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseGranite : Item
	{
		public override string DefaultDescription{ get{ return "This rock is used by carpenters, to create stone statues and furniture. You would need a mallet and chisel to use this."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 2 )
				m_Resource = (CraftResource)reader.ReadInt();

			Stackable = true;
			Hue = CraftResources.GetClr( m_Resource );
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, true, true, null );
			ItemID = 0x2158;
			Built = true;
		}

		public override double DefaultWeight
		{
			get { return 5.0; }
		}

		public BaseGranite( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseGranite( CraftResource resource, int amount ) : base( 0x2158 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetClr( resource );
			Name = CraftResources.GetTradeItemFullName( this, resource, true, true, null );
			Built = true;
		}

		public BaseGranite( Serial serial ) : base( serial )
		{
		}

		public override int LabelNumber{ get{ return 1044607; } } // high quality granite
	}

	public class Granite : BaseGranite
	{
		[Constructable]
		public Granite() : this( 1 )
		{
		}

		[Constructable]
		public Granite( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public Granite( Serial serial ) : base( serial )
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

	public class DullCopperGranite : BaseGranite
	{
		[Constructable]
		public DullCopperGranite() : this( 1 )
		{
		}

		[Constructable]
		public DullCopperGranite( int amount ) : base( CraftResource.DullCopper, amount )
		{
		}

		public DullCopperGranite( Serial serial ) : base( serial )
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

	public class ShadowIronGranite : BaseGranite
	{
		[Constructable]
		public ShadowIronGranite() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIronGranite( int amount ) : base( CraftResource.ShadowIron, amount )
		{
		}

		public ShadowIronGranite( Serial serial ) : base( serial )
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

	public class CopperGranite : BaseGranite
	{
		[Constructable]
		public CopperGranite() : this( 1 )
		{
		}

		[Constructable]
		public CopperGranite( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperGranite( Serial serial ) : base( serial )
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

	public class BronzeGranite : BaseGranite
	{
		[Constructable]
		public BronzeGranite() : this( 1 )
		{
		}

		[Constructable]
		public BronzeGranite( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeGranite( Serial serial ) : base( serial )
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

	public class GoldGranite : BaseGranite
	{
		[Constructable]
		public GoldGranite() : this( 1 )
		{
		}

		[Constructable]
		public GoldGranite( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldGranite( Serial serial ) : base( serial )
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

	public class AgapiteGranite : BaseGranite
	{
		[Constructable]
		public AgapiteGranite() : this( 1 )
		{
		}

		[Constructable]
		public AgapiteGranite( int amount ) : base( CraftResource.Agapite, amount )
		{
		}

		public AgapiteGranite( Serial serial ) : base( serial )
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

	public class VeriteGranite : BaseGranite
	{
		[Constructable]
		public VeriteGranite() : this( 1 )
		{
		}

		[Constructable]
		public VeriteGranite( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteGranite( Serial serial ) : base( serial )
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

	public class ValoriteGranite : BaseGranite
	{
		[Constructable]
		public ValoriteGranite() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteGranite( int amount ) : base( CraftResource.Valorite, amount )
		{
		}

		public ValoriteGranite( Serial serial ) : base( serial )
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

	public class ObsidianGranite : BaseGranite
	{
		[Constructable]
		public ObsidianGranite() : this( 1 )
		{
		}

		[Constructable]
		public ObsidianGranite( int amount ) : base( CraftResource.Obsidian, amount )
		{
		}

		public ObsidianGranite( Serial serial ) : base( serial )
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

	public class MithrilGranite : BaseGranite
	{
		[Constructable]
		public MithrilGranite() : this( 1 )
		{
		}

		[Constructable]
		public MithrilGranite( int amount ) : base( CraftResource.Mithril, amount )
		{
		}

		public MithrilGranite( Serial serial ) : base( serial )
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

	public class DwarvenGranite : BaseGranite
	{
		[Constructable]
		public DwarvenGranite() : this( 1 )
		{
		}

		[Constructable]
		public DwarvenGranite( int amount ) : base( CraftResource.Dwarven, amount )
		{
		}

		public DwarvenGranite( Serial serial ) : base( serial )
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

	public class XormiteGranite : BaseGranite
	{
		[Constructable]
		public XormiteGranite() : this( 1 )
		{
		}

		[Constructable]
		public XormiteGranite( int amount ) : base( CraftResource.Xormite, amount )
		{
		}

		public XormiteGranite( Serial serial ) : base( serial )
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

	public class NepturiteGranite : BaseGranite
	{
		[Constructable]
		public NepturiteGranite() : this( 1 )
		{
		}

		[Constructable]
		public NepturiteGranite( int amount ) : base( CraftResource.Nepturite, amount )
		{
		}

		public NepturiteGranite( Serial serial ) : base( serial )
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

	public class SteelGranite : BaseGranite
	{
		[Constructable]
		public SteelGranite() : this( 1 )
		{
		}

		[Constructable]
		public SteelGranite( int amount ) : base( CraftResource.Steel, amount )
		{
		}

		public SteelGranite( Serial serial ) : base( serial )
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

	public class BrassGranite : BaseGranite
	{
		[Constructable]
		public BrassGranite() : this( 1 )
		{
		}

		[Constructable]
		public BrassGranite( int amount ) : base( CraftResource.Brass, amount )
		{
		}

		public BrassGranite( Serial serial ) : base( serial )
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